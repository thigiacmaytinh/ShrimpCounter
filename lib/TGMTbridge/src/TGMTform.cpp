#include "TGMTbridgeUtil.h"

#include "TGMTbridge.h"

using namespace System::Windows::Forms;
using namespace System::Text::RegularExpressions;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTbridgeUtil::ShowMessageBox(System::String^ title, System::String^ content)
{
	MessageBox::Show(content, title, MessageBoxButtons::OK, MessageBoxIcon::Information);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTbridgeUtil::ShowMessageBox(std::string title, std::string content)
{
	ShowMessageBox(TGMTbridge::stdStrToSystemStr(title), TGMTbridge::stdStrToSystemStr(content));
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTbridgeUtil::ShowErrorBox(System::String^ title, System::String^ content)
{
	MessageBox::Show(content, title, MessageBoxButtons::OK, MessageBoxIcon::Error);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTbridgeUtil::ShowErrorBox(std::string title, std::string content)
{
	ShowErrorBox(TGMTbridge::stdStrToSystemStr(title), TGMTbridge::stdStrToSystemStr(content));
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTbridgeUtil::OnlyInputNumber(Object^ sender, KeyPressEventArgs^ e)
{
	//if (!char->IsControl(e->KeyChar) && !char.IsDigit(e->KeyChar) && (e->KeyChar != '.'))
	//{
	//	e->Handled = true;
	//}

	// only allow one decimal point
	//if ((e->KeyChar == '.') && ((TextBox^)sender)->Text->IndexOf('.') > -1)
	//{
	//	e->Handled = true;
	//}
}
