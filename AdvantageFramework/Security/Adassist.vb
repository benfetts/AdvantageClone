'Namespace Security.Interfaces

'    <System.Runtime.InteropServices.ComVisible(True),
'    System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None),
'    System.Runtime.InteropServices.ProgId("AdvantageFramework.Security.Adassist"),
'    System.Runtime.InteropServices.Guid("F3D743BC-5A92-4510-9B04-2FE2C01792B8")>
'    Public Class Adassist
'        Implements Interfaces.IAdassist

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "



'#End Region

'#Region " Methods "

'        Public Function Login(Server As String, Database As String, UserCode As String, Password As String) As Boolean Implements IAdassist.Login

'            Dim SuccessfulLogin As Boolean = False
'            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
'            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
'            Dim UserID As Integer = 0
'            Dim EncryptedPassword As String = String.Empty

'            Try

'                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage(True)

'                Try

'                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

'                Catch ex As Exception
'                    ConnectionDatabaseProfile = Nothing
'                End Try

'                If ConnectionDatabaseProfile IsNot Nothing Then

'                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString, UserCode)

'                        DbContext.Database.Connection.Open()

'                        Try

'                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

'                        Catch ex As Exception
'                            UserID = 0
'                        End Try

'                        If UserID > 0 Then

'                            Try

'                                EncryptedPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT PWD_D FROM dbo.SEC_USER_AUTH WHERE SEC_USER_ID = {0}", UserID)).FirstOrDefault

'                            Catch ex As Exception
'                                EncryptedPassword = String.Empty
'                            End Try

'                            If String.IsNullOrWhiteSpace(EncryptedPassword) = False Then

'                                If EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

'                                    SuccessfulLogin = True

'                                End If

'                            End If

'                        End If

'                    End Using

'                End If

'            Catch ex As Exception

'            End Try

'            Login = SuccessfulLogin

'        End Function
'        Public Function SetPassword(Server As String, Database As String, UserCode As String, Password As String) As Boolean Implements IAdassist.SetPassword

'            Dim PasswordUpdated As Boolean = False
'            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
'            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
'            Dim UserID As Integer = 0
'            Dim AlreadyHasPassword As Boolean = False
'            Dim EncryptedPassword As String = String.Empty

'            Try

'                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage(True)

'                Try

'                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

'                Catch ex As Exception
'                    ConnectionDatabaseProfile = Nothing
'                End Try

'                If ConnectionDatabaseProfile IsNot Nothing Then

'                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString, UserCode)

'                        DbContext.Database.Connection.Open()

'                        Try

'                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

'                        Catch ex As Exception
'                            UserID = 0
'                        End Try

'                        If UserID > 0 Then

'                            EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password)

'                            AlreadyHasPassword = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.SEC_USER_AUTH WHERE SEC_USER_ID = {0}", UserID)).FirstOrDefault > 0)

'                            If AlreadyHasPassword Then

'                                PasswordUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_AUTH SET PWD_D = '{0}' WHERE SEC_USER_ID = {1}", EncryptedPassword, UserID))

'                            Else

'                                PasswordUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SEC_USER_AUTH (SEC_USER_ID, PWD_D) VALUES ({0}, '{1}')", UserID, EncryptedPassword))

'                            End If

'                        End If

'                    End Using

'                End If

'            Catch ex As Exception

'            End Try

'            SetPassword = PasswordUpdated

'        End Function
'        Public Function DeleteLogin(Server As String, Database As String, UserCode As String) As Boolean Implements IAdassist.DeleteLogin

'            Dim LoginDeleted As Boolean = False
'            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
'            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
'            Dim UserID As Integer = 0

'            Try

'                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage(True)

'                Try

'                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

'                Catch ex As Exception
'                    ConnectionDatabaseProfile = Nothing
'                End Try

'                If ConnectionDatabaseProfile IsNot Nothing Then

'                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString, UserCode)

'                        DbContext.Database.Connection.Open()

'                        Try

'                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

'                        Catch ex As Exception
'                            UserID = 0
'                        End Try

'                        If UserID > 0 Then

'                            LoginDeleted = DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.SEC_USER_AUTH WHERE SEC_USER_ID = {0}", UserID))

'                        End If

'                    End Using

'                End If

'            Catch ex As Exception

'            End Try

'            DeleteLogin = LoginDeleted

'        End Function

'#End Region

'    End Class

'End Namespace

