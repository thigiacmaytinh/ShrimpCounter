#include "TGMTsvm.h"
#include "TGMTdebugger.h"
#include "TGMTfile.h"
#if defined(WIN32) || defined(WIN64)
#include "TGMTConfig.h"
#endif

TGMTsvm* TGMTsvm::m_instance = nullptr;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

TGMTsvm::TGMTsvm()
{
#if defined(WIN32) || defined(WIN64)
	m_isAutoTrain = GetTGMTConfig()->ReadBool("SVM", "auto_train");
#endif

	svm = SVM::create();
	svm->setType(SVM::Types::C_SVC);
	svm->setKernel(SVM::KernelTypes::LINEAR);
	svm->setTermCriteria(cv::TermCriteria(cv::TermCriteria::MAX_ITER, 300, 1e-6));

	if (!m_isAutoTrain)
	{		
		
	}	
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

TGMTsvm::~TGMTsvm()
{
	svm.release();	
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTsvm::TrainData(cv::Mat matData, cv::Mat matLabel)
{
	ASSERT(matData.data, "Mat data to train is empty");
	ASSERT(matLabel.data, "Mat label to train is empty");

	SET_CONSOLE_TITLE("Traning data svm...");
	if (m_isAutoTrain)
	{
		cv::Ptr<cv::ml::TrainData> trainData = cv::ml::TrainData::create(matData, cv::ml::ROW_SAMPLE, matLabel);
		m_isInited = svm->trainAuto(trainData);
	}
	else
	{
		m_isInited = svm->train(matData, ROW_SAMPLE, matLabel);
	}
	return m_isInited;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

float TGMTsvm::Predict(std::string filePath)
{
	cv::Mat mat = cv::imread(filePath, CV_LOAD_IMAGE_GRAYSCALE);
	return Predict(mat);
}

////////////////////////////////////////////////////////////////////////////////////////////////////

float TGMTsvm::Predict(cv::Mat matInput)
{
	ASSERT(m_isInited, "You must train SVM before use");

	cv::Mat matData = PrepareMatData(matInput);
	return svm->predict(matData);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTsvm::SaveModel(std::string filePath)
{
	svm->save(filePath.c_str());
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTsvm::LoadModel(std::string filePath)
{
	ASSERT(TGMTfile::FileExist(filePath), "File svm \'%s\' does not exist", filePath.c_str());

	svm = StatModel::load<SVM>(filePath);
	
	m_isInited = true;
	return m_isInited;
}
