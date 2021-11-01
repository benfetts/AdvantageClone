Namespace Security

    Public Class Impersonate

#Region " Enum "

        Private Enum Logon32Options As Integer
            ProviderDefault = 0
            LogonInteractive = 2
            LogonNetwork = 3
            LogonBatch = 4
            LogonService = 5
            LogonUnlock = 7
            LogonNetworkCleartext = 8
            LogonNewCredentials = 9
        End Enum

#End Region

#Region " Variables "

        Private Shared _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
        Private Shared _OriginalImpersonationIdentity As System.Security.Principal.WindowsIdentity

#End Region

#Region " Methods "

        Public Shared Function CheckNTAuthentication() As Boolean

            Dim Authentication As String = Nothing
            Dim IsAuthenticated As Boolean = False

            Try

                Authentication = System.Configuration.ConfigurationManager.AppSettings("Authentication")

                If Authentication = "Forms" Then

                    IsAuthenticated = False

                Else

                    IsAuthenticated = True

                End If

            Catch ex As Exception
                IsAuthenticated = False
            Finally
                CheckNTAuthentication = IsAuthenticated
            End Try

        End Function
        Public Overloads Shared Function BeginImpersonation(ByVal UserName As String, ByVal Domain As String, ByVal Password As String) As Boolean

            'objects
            Dim Token As IntPtr = IntPtr.Zero
            Dim TokenDuplicate As IntPtr = IntPtr.Zero
            Dim TempWindowsIdentity As System.Security.Principal.WindowsIdentity = Nothing
            Dim HasBegun As Boolean = False
            Dim Win32ErrorNumber As Long = Nothing
            Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity = Nothing

            Try

                CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

                If CurrentWindowsIdentity IsNot Nothing Then

                    If CurrentWindowsIdentity.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation Then

                        _OriginalImpersonationIdentity = CurrentWindowsIdentity

                    End If

                End If

                If RevertToSelf() Then

                    If LogonUserA(UserName, Domain, Password, Logon32Options.LogonInteractive, Logon32Options.ProviderDefault, Token) <> 0 Then

                        If DuplicateToken(Token, 2, TokenDuplicate) <> 0 Then

                            TempWindowsIdentity = New System.Security.Principal.WindowsIdentity(TokenDuplicate)

                            _ImpersonationContext = TempWindowsIdentity.Impersonate()

                            If _ImpersonationContext IsNot Nothing Then

                                HasBegun = True

                            End If

                        End If

                    ElseIf LogonUserA(UserName, Domain, AdvantageFramework.Security.Encryption.Decrypt(Password), Logon32Options.LogonInteractive, Logon32Options.ProviderDefault, Token) <> 0 Then

                        If DuplicateToken(Token, 2, TokenDuplicate) <> 0 Then

                            TempWindowsIdentity = New System.Security.Principal.WindowsIdentity(TokenDuplicate)

                            _ImpersonationContext = TempWindowsIdentity.Impersonate()

                            If _ImpersonationContext IsNot Nothing Then

                                HasBegun = True

                            End If

                        End If

                    End If

                End If

                If Not TokenDuplicate.Equals(IntPtr.Zero) Then

                    CloseHandle(TokenDuplicate)

                End If

                If Not Token.Equals(IntPtr.Zero) Then

                    CloseHandle(Token)

                End If

            Catch ex As Exception
                HasBegun = False
            Finally
                BeginImpersonation = HasBegun
            End Try

        End Function
        Public Overloads Shared Function BeginImpersonation(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim HasBegun As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                End Using

                HasBegun = BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

            Catch ex As Exception
                HasBegun = False
            Finally
                BeginImpersonation = HasBegun
            End Try

        End Function
        Public Overloads Shared Sub EndImpersonation()

            Try

                If _ImpersonationContext IsNot Nothing Then

                    _ImpersonationContext.Dispose()

                End If

            Catch ex As Exception

            End Try

            Try

                If _OriginalImpersonationIdentity IsNot Nothing Then

                    _OriginalImpersonationIdentity.Impersonate()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Overloads Shared Sub EndImpersonation(ByVal OriginalIdentity As System.Security.Principal.WindowsIdentity)

            Try

                If _ImpersonationContext IsNot Nothing Then

                    _ImpersonationContext.Dispose()

                End If

            Catch ex As Exception

            End Try

            Try

                If _OriginalImpersonationIdentity IsNot Nothing Then

                    _OriginalImpersonationIdentity.Impersonate()

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region " External Declarations and Helpers "

        Declare Function LogonUserA Lib "advapi32.dll" (ByVal UserName As String, ByVal Domain As String, ByVal Password As String,
                                                                ByVal LogonType As Integer, ByVal LogonProvider As Integer, ByRef Token As IntPtr) As Integer
        Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, ByVal ImpersonationLevel As Integer, ByRef DuplicateTokenHandle As IntPtr) As Integer
        Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
        Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal Handle As IntPtr) As Long
        Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal UserName As [String], ByVal Domain As [String], ByVal Password As [String], ByVal LogonType As Integer,
                                                                    ByVal LogonProvider As Integer, ByRef Token As IntPtr) As Boolean
        <System.Runtime.InteropServices.DllImport("kernel32.dll")>
        Private Shared Function FormatMessage(ByVal Flags As Integer, ByRef Source As IntPtr, ByVal MessageID As Integer, ByVal LanguageID As Integer, ByRef Message As [String],
                                              ByVal Size As Integer, ByRef Arguments As IntPtr) As Integer
        End Function
        Private Shared Function GetErrorMessage(ByVal ErrorCode As Integer) As String

            Dim FormatMessageAllocateBugger As Integer = Nothing
            Dim FormatMessageIgnoreInserts As Integer = Nothing
            Dim FormatMessageFromSystem As Integer = Nothing
            Dim MessageSize As Integer = Nothing
            Dim Message As String = Nothing
            Dim Flags As Integer = Nothing
            Dim Source As IntPtr = Nothing
            Dim Arguments As IntPtr = Nothing

            FormatMessageAllocateBugger = &H100
            FormatMessageIgnoreInserts = &H200
            FormatMessageFromSystem = &H1000
            MessageSize = 255
            Source = IntPtr.Zero
            Arguments = IntPtr.Zero

            Flags = FormatMessageAllocateBugger Or FormatMessageFromSystem Or FormatMessageIgnoreInserts

            If FormatMessage(Flags, Source, ErrorCode, 0, Message, MessageSize, Arguments) = 0 Then

                Throw New System.Exception("Failed to format message for error code " + ErrorCode.ToString() + ". ")

            End If

            GetErrorMessage = Message

        End Function

#End Region

    End Class

End Namespace
