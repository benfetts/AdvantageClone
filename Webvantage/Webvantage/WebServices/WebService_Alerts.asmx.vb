Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService_Alerts
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetNotifications(ByVal EmployeeCode As String, ByVal ConnectionString As String) As DataSet

        Dim arP(1) As SqlParameter

        Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        pEMP_CODE.Value = EmployeeCode
        arP(0) = pEMP_CODE

        Return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "usp_wv_alert_GetList", arP)

    End Function

End Class