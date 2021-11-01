Namespace Interfaces

    <System.Runtime.InteropServices.ComVisible(True)>
    <System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsDual)>
    <System.Runtime.InteropServices.Guid("21A515F0-7A14-46D9-8EC7-E8B87ADF467A")>
    Public Interface IAdassist

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Function Encrypt(PlainText As String) As String
        Function Decrypt(EncryptedText As String) As String
        Function EncryptPassword(PlainText As String) As String
        Function Login(DNSName As String, UserCode As String, Password As String) As Boolean
        Function SetPassword(DNSName As String, UserCode As String, Password As String) As Boolean
        Function DeleteLogin(DNSName As String, UserCode As String) As Boolean

#End Region

    End Interface

End Namespace

