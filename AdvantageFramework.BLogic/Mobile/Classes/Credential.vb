Namespace Mobile.Enums 'Just testing

    Public Enum AuthorizationType

        None = 0
        Basic = 1
        Forms = 2

    End Enum

End Namespace
Namespace Mobile.Classes
    <Serializable()>
    Public Class Credential

        Public Property Type As Mobile.Enums.AuthorizationType
        Public Property ServerName As String = ""
        Public Property DatabaseName As String = ""
        Public Property IsWindowsAuth As Boolean = False
        Public Property DomainName As String = ""
        Public Property FullDomainName As String = ""
        Public Property GenericIdentity As String = ""
        Public Property NetworkUserID As String = ""
        Public Property NetworkPassword As String = ""
        Public Property SSOUserCode As String = ""
        Public Property UserCode As String = ""
        Public Property Password As String = ""
        Public Property Invalid As Boolean = False

        Public Property UpperCaseUser As Boolean = True
        Public Property UpperCaseDatabase As Boolean = True
        Public Property ChooseServer As Boolean = True
        Public Property SqlControlledAdmin As Boolean = False
        Public Property NTAuthIgnoreCase As Boolean = True
        Public Property IsConfigSet As Boolean = False

        Public Property AdvantageUserLicenseInUseID As Integer = 0
        Public Property ApplicationTimeOutMinutes As Integer = 20

        Public Sub New(ByVal ApplicationHeader As String)

            If String.IsNullOrWhiteSpace(ApplicationHeader) = False Then

                Dim cred = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(ApplicationHeader)).Split(":"c)

                If cred.Length = 19 Then

                    Me.Invalid = False
                    If IsNumeric(cred(1)) = True Then Me.Type = CType(CType(cred(1), Integer), Mobile.Enums.AuthorizationType)
                    Me.ServerName = cred(2)
                    Me.DatabaseName = cred(3)
                    Me.UserCode = cred(4)
                    Me.Password = cred(5)
                    Me.IsWindowsAuth = cred(6)
                    If Me.IsWindowsAuth = True Then Me.Type = Enums.AuthorizationType.Basic
                    Me.DomainName = cred(7)
                    Me.UpperCaseUser = cred(10).ToLower() = "true"
                    Me.UpperCaseDatabase = cred(11).ToLower() = "true"
                    Me.ChooseServer = cred(12).ToLower() = "true"
                    Me.SqlControlledAdmin = cred(13).ToLower() = "true"
                    Me.NTAuthIgnoreCase = cred(14).ToLower() = "true"
                    Me.IsConfigSet = cred(15).ToLower() = "true"
                    If IsNumeric(cred(16)) = True Then Me.AdvantageUserLicenseInUseID = CType(cred(16), Integer)
                    If IsNumeric(cred(17)) = True Then Me.ApplicationTimeOutMinutes = CType(cred(17), Integer)
                    Me.GenericIdentity = Me.UserCode
                    Me.FullDomainName = Me.DomainName & "\" & Me.GenericIdentity

                Else

                    Me.Invalid = True

                End If

            End If

        End Sub

    End Class

End Namespace