#include <IE.au3>

Local $oIE = _IECreate("http://eschedule.shanghaigm.com/NS/DunsLogin.jsp")
Local $oForm = _IEFormGetObjByName($oIE, "formname")

Local $oText1 = _IEFormElementGetObjByName($oForm, "loginId")
_IEFormElementSetValue($oText1, "skf0000000")

Local $oText2 = _IEFormElementGetObjByName($oForm, "pwd")
_IEFormElementSetValue($oText2, "Init1234")

_IEFormSubmit($oForm)