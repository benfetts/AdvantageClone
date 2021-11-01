Imports System.Data
Imports System.Data.SqlClient
<Serializable()> Public Class cVisible
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Function ProductCategoryVisible() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ProductCategoryVisible"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_visible_product_category"))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function
    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class
