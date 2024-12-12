#pragma once
using namespace System;


ref class TGMTbridgeHardware
{
	static System::String^ GetCpuId();
	//DO NOT use because sometime return empty string
	//static System::String^ GetMainboardId();
	static System::String^ GetDiskId();

	//changed when use reinstall Windows
	static System::String^ GetPartitionId(String^ partition); //C:	
	static System::String^ GetMacAddress();
public:
	static System::String^ GetUDID();
	static System::String^ GetPCname();
	static System::String^ GetPCuserName();
};
