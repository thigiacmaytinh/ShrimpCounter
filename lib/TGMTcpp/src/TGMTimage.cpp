#include "TGMTimage.h"
#include "TGMTdebugger.h"

//TGMTimage::TGMTimage(void)
//{
//
//}
//
//////////////////////////////////////////////////////////////////////////////////////////////////////
//
//TGMTimage::~TGMTimage(void)
//{
//
//}

////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTimage::GetImageType(cv::Mat img)
{
	std::string r = "";

	uchar depth = img.type() & CV_MAT_DEPTH_MASK;
	uchar chans = 1 + (img.type() >> CV_CN_SHIFT);

	switch (depth)
	{
	case CV_8U:  r = "8U"; break;
	case CV_8S:  r = "8S"; break;
	case CV_16U: r = "16U"; break;
	case CV_16S: r = "16S"; break;
	case CV_32S: r = "32S"; break;
	case CV_32F: r = "32F"; break;
	case CV_64F: r = "64F"; break;
	default:     r = "User"; break;
	}

	r += "C";
	r += (chans + '0');

	return r;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTimage::ConvertToGray(const cv::Mat matInput)
{
	ASSERT(matInput.data, "Mat input is null");

	cv::Mat matGray;
	if (matInput.channels() == 3) 
	{
		cv::cvtColor(matInput, matGray, cv::COLOR_BGR2GRAY);
	}
	else if (matInput.channels() == 4) 
	{
		cv::cvtColor(matInput, matGray, cv::COLOR_BGRA2GRAY);
	}
	else
	{
		matGray = matInput.clone();
	}		
	return matGray;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTimage::Compare(cv::Mat mat1, cv::Mat mat2)
{
	if (!mat1.data || !mat2.data)
		return false;

	return (cv::sum(mat1 != mat2) == cv::Scalar(0, 0, 0, 0));
}

////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTimage::GetBitDepth(cv::Mat matInput)
{
	uchar depth = matInput.depth() & CV_MAT_DEPTH_MASK;

	switch (depth)
	{
	case CV_8U:
	case CV_8S:
		return 8;
	case CV_16U:
	case CV_16S:
		return 16;
	case CV_32S:
	case CV_32F:
		return 32;
	case CV_64F:
		return 64;
	default:
		ASSERT(false, "What happen with this image?");
		return 0;
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTimage::GetNumChannels(cv::Mat matInput)
{
	uchar channels = 1 + (matInput.type() >> CV_CN_SHIFT);
	return channels;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTimage::Blend(cv::Mat mat1, cv::Mat mat2, float alpha)
{
	ASSERT(mat1.size() == mat2.size(), "2 mats must same size");
	cv::Mat dst = cv::Mat(mat1.size(), CV_8UC3);
	float beta = 1.f - alpha;
	cv::addWeighted(mat1, alpha, mat2, beta, 0.0, dst);
	return dst;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTimage::SelectRoi(cv::Mat matInput, cv::Rect roi)
{
	cv::Mat mat = cv::Mat::zeros(matInput.size(), matInput.type());
	matInput(roi).copyTo(mat(roi));
	return mat;
}

////////////////////////////////////////////////////////////////////////////////////////////////////
static const std::string base64_chars =
"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
"abcdefghijklmnopqrstuvwxyz"
"0123456789+/";


static inline bool is_base64(BYTE c) {
	return (isalnum(c) || (c == '+') || (c == '/'));
}

std::string base64_encode(BYTE const* buf, unsigned int bufLen) {
	std::string ret;
	int i = 0;
	int j = 0;
	BYTE char_array_3[3];
	BYTE char_array_4[4];

	while (bufLen--) {
		char_array_3[i++] = *(buf++);
		if (i == 3) {
			char_array_4[0] = (char_array_3[0] & 0xfc) >> 2;
			char_array_4[1] = ((char_array_3[0] & 0x03) << 4) + ((char_array_3[1] & 0xf0) >> 4);
			char_array_4[2] = ((char_array_3[1] & 0x0f) << 2) + ((char_array_3[2] & 0xc0) >> 6);
			char_array_4[3] = char_array_3[2] & 0x3f;

			for (i = 0; (i < 4); i++)
				ret += base64_chars[char_array_4[i]];
			i = 0;
		}
	}

	if (i)
	{
		for (j = i; j < 3; j++)
			char_array_3[j] = '\0';

		char_array_4[0] = (char_array_3[0] & 0xfc) >> 2;
		char_array_4[1] = ((char_array_3[0] & 0x03) << 4) + ((char_array_3[1] & 0xf0) >> 4);
		char_array_4[2] = ((char_array_3[1] & 0x0f) << 2) + ((char_array_3[2] & 0xc0) >> 6);
		char_array_4[3] = char_array_3[2] & 0x3f;

		for (j = 0; (j < i + 1); j++)
			ret += base64_chars[char_array_4[j]];

		while ((i++ < 3))
			ret += '=';
	}

	return ret;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

static std::string base64_decode(const std::string& in) {

	std::string out;

	std::vector<int> T(256, -1);
	for (int i = 0; i < 64; i++) T["ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[i]] = i;

	int val = 0, valb = -8;
	for (uchar c : in) {
		if (T[c] == -1) break;
		val = (val << 6) + T[c];
		valb += 6;
		if (valb >= 0) {
			out.push_back(char((val >> valb) & 0xFF));
			valb -= 8;
		}
	}
	return out;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTimage::MatToBase64(cv::Mat matInput)
{
	if (matInput.empty())
		return "";

	std::vector<uchar> buf;
	cv::imencode(".jpg", matInput, buf);
	auto* enc_msg = reinterpret_cast<unsigned char*>(buf.data());
	std::string encoded = base64_encode(enc_msg, buf.size());
	return encoded;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTimage::Base64ToMat(std::string base64)
{
	std::string dec_jpg = base64_decode(base64);
	std::vector<uchar> data(dec_jpg.begin(), dec_jpg.end());
	cv::Mat mat = cv::imdecode(cv::Mat(data), 1);
	return mat;
}