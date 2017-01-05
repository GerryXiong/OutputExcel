#include <IE.au3>

Local $oIE = _IECreate("http://eschedule.shanghaigm.com/WH/DunsLogin.jsp")
Local $oForm = _IEFormGetObjByName($oIE, "formname")

Local $oText1 = _IEFormElementGetObjByName($oForm, "loginId")
_IEFormElementSetValue($oText1, "skfxs00000")

Local $oText2 = _IEFormElementGetObjByName($oForm, "pwd")
_IEFormElementSetValue($oText2, "Dd123456")

_IEFormSubmit($oForm)