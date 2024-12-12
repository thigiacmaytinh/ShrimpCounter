#include "TGMTbridgeHardware.h"
#using <system.management.dll>
#include "TGMTbridgeUtil.h"
#include "TGMTbridgeRegistry.h"

using namespace System;
using namespace System::Management;
using namespace System::Net::NetworkInformation;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetCpuId()
{
	ManagementObjectSearcher^ mbs = gcnew ManagementObjectSearcher("Select ProcessorID From Win32_processor");
	ManagementObjectCollection^ mbsList = mbs->Get();
	String^ id = "";
	for each(ManagementObject^ mo in mbsList)
	{
		if (mo["ProcessorID"] != nullptr)
			id = mo["ProcessorID"]->ToString();
	}
	return id;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//DO NOT use because sometime return empty string

//String^ TGMTbridgeHardware::GetMainboardId()
//{
//	ManagementObjectSearcher^ mos = gcnew ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
//	ManagementObjectCollection^ moc = mos->Get();
//	String^ serial = "";
//	for each(ManagementObject^ mo in moc)
//	{
//		serial = mo["SerialNumber"]->ToString();
//	}
//	if (serial == "To be filled by O.E.M." ||
//		serial == "Default string")
//		return "";
//	return serial;
//}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetDiskId()
{
	TGMTbridgeRegistry^ reg = gcnew TGMTbridgeRegistry();
	reg->Init("Microsoft");
	String^ serial = reg->ReadValueString("serial", "");
	if (serial != "")
		return serial;

	ManagementObjectSearcher^ searcher = gcnew ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

	for each(ManagementObject^ wmi_HD in searcher->Get())
	{
		String^ serialNo = wmi_HD["SerialNumber"]->ToString();
		reg->WriteValue("serial", serialNo);
		return serialNo;
	}
	return "";
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//changed when use reinstall Windows
String^ TGMTbridgeHardware::GetPartitionId(String^ partition)
{
	ManagementObject^ part = gcnew ManagementObject("win32_logicaldisk.deviceid=\"" + partition + "\"");
	part->Get();
	String^ partitionId = part["VolumeSerialNumber"]->ToString();
	return partitionId;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetMacAddress()
{

	TGMTbridgeRegistry^ reg = gcnew TGMTbridgeRegistry();
	reg->Init("Windows");

	String^ interface = reg->ReadValueString("interface", "");
	if (interface != "")
		return interface;

	for each(NetworkInterface^ nic in NetworkInterface::GetAllNetworkInterfaces())
	{
		// Only consider Ethernet network interfaces
		if (nic->NetworkInterfaceType == NetworkInterfaceType::Ethernet || nic->NetworkInterfaceType == NetworkInterfaceType::GigabitEthernet)
		{
			reg->WriteValue("interface", nic->GetPhysicalAddress()->ToString()->Replace(":", ""));
			return nic->GetPhysicalAddress()->ToString();
		}
	}

	ManagementObjectSearcher^ objMOS = gcnew ManagementObjectSearcher("Select MacAddress FROM Win32_NetworkAdapterConfiguration");
	ManagementObjectCollection^ objMOC = objMOS->Get();

	for each(ManagementObject^ objMO in objMOC)
	{
		Object^ tempMacAddrObj = objMO["MacAddress"];

		if (tempMacAddrObj != nullptr) //Skip objects without a MACAddress
		{
			reg->WriteValue("interface", tempMacAddrObj->ToString()->Replace(":", ""));
			return tempMacAddrObj->ToString()->Replace(":", "");
		}
	}
	return "";
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetUDID()
{
	String^ udid = GetCpuId();

	String^ diskID = GetDiskId();
	udid += diskID;

	udid->Replace(" ", "");

	udid = TGMTbridgeUtil::RemoveSpecialCharacter(udid);
	udid = udid->ToLower();
	return udid;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetPCname()
{
	return Environment::MachineName;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

String^ TGMTbridgeHardware::GetPCuserName()
{
	return Environment::UserName;
}