Namespace Security.Classes

    Public Class DataServiceUser

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UserCode As String = ""
        Public Property Password As String = ""
        Public Property DatabaseName As String = ""
        Public Property DatabaseServer As String = ""
        Public Property ConnectionString As String = ""
        Public Property Token As String = ""
        Public Property IsValid As Boolean = False
        Public Property SessionID As String = ""

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
