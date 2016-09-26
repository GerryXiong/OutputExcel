#include <IE.au3>

Local $oIE = _IECreate("http://eschedule.shanghaigm.com/JQ/DunsLogin.jsp")
Local $oForm = _IEFormGetObjByName($oIE, "formname")

Local $oText1 = _IEFormElementGetObjByName($oForm, "loginId")
_IEFormElementSetValue($oText1, "SKF China0")

Local $oText2 = _IEFormElementGetObjByName($oForm, "pwd")
_IEFormElementSetValue($oText2, "Bb123456")

_IEFormSubmit($oForm)