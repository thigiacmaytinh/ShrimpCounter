#include "TGMTbrightness.h"
#include "TGMTdebugger.h"
#include "TGMTimage.h"

////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTbrightness::GetLuxValue(cv::Mat matInput)
{
	cv::Mat matHls;
	cv::cvtColor(matInput, matHls, cv::COLOR_BGR2HSV);
	cv::Mat mats[3];
	cv::split(matHls, mats);
	cv::Mat matV = mats[2];
	cv::Scalar scalar = cv::mean(matV);
	return scalar[0];
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::EqualizeHist(cv::Mat matInput)
{
	if (matInput.channels() == 1)
	{
		// Can bang histogram anh xam
		cv::Mat matResult;
		cv::equalizeHist(matInput, matResult);
		return matResult;
	}
	else if (matInput.channels() == 3)
	{
		// Can bang histogram anh mau

		cv::Mat hsv, matResult;
		cv::cvtColor(matInput, hsv, cv::COLOR_BGR2HSV);
		std::vector<cv::Mat> hsv_channels;
		// Tach hsv thanh 3 kenh mau
		cv::split(hsv, hsv_channels);
		// Can bang histogram kenh mau v (value)
		cv::equalizeHist(hsv_channels[2], hsv_channels[2]);
		// Tron anh
		cv::merge(hsv_channels, hsv);
		// Chuyen doi hsv sang rgb de hien thi
		cv::cvtColor(hsv, matResult, cv::COLOR_HSV2BGR);

		return matResult;
	}
	else
	{
		ASSERT(false, "Only support image has 1 or 3 channels");
	}
    return matInput;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::AutoLuminance(cv::Mat matInput)
{
	cv::Mat matResult;
	int maxValue = pow(2, TGMTimage::GetBitDepth(matInput)) - 1;
	cv::normalize(matInput, matResult, 0, maxValue, cv::NORM_MINMAX);
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::SetBrightness(cv::Mat matInput, double alpha, int beta)
{
	cv::Mat matResult = matInput.clone();
	for (uint i = 0; i < matResult.rows; i++)
	{
		for (uint j = 0; j < matResult.cols; j++)
		{
			for (uint k = 0; k < 3; k++)
			{
				matResult.at<cv::Vec3b>(i, j)[k] = cv::saturate_cast<uchar>(alpha*(matResult.at<cv::Vec3b>(i, j)[k]) + beta);
			}				
		}			
	}
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::AutoContrast(cv::Mat matInput)
{
	cv::Mat matOutput;
	cv::GaussianBlur(matInput, matOutput, cv::Size(11, 11), 0);
	cv::addWeighted(matInput, 1.5, matOutput, -0.5, 1, matOutput);
	return matOutput;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::CLAHE(cv::Mat matInput)
{
	// READ RGB color image and convert it to Lab
	cv::Mat matLab;
	cv::cvtColor(matInput, matLab, cv::COLOR_BGR2Lab);

	// Extract the L channel
	std::vector<cv::Mat> lab_planes(3);
	cv::split(matLab, lab_planes);  // now we have the L image in lab_planes[0]

	// apply the CLAHE algorithm to the L channel
	static cv::Ptr<cv::CLAHE> clahe = cv::createCLAHE();
	clahe->setClipLimit(4);
	cv::Mat dst;
	clahe->apply(lab_planes[0], dst);

	// Merge the the color planes back into an Lab image
	dst.copyTo(lab_planes[0]);
	cv::merge(lab_planes, matLab);

	// convert back to RGB
	cv::Mat matResult;
	cv::cvtColor(matLab, matResult, cv::COLOR_Lab2BGR);

	return matResult;
}
