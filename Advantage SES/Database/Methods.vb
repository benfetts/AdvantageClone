Namespace Database

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const _ConstConnectionStringBaseWindowsAuthentication As String = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;Persist Security Info=False;APP={2}"
        Private Const _ConstConnectionStringBaseSQLAuthentication As String = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};APP={4}"

#End Region

#Region " Enum "

        Public Enum Action
            Inserting
            Updating
            Deleting
        End Enum
        Public Enum DatabaseTypes
            [Default]
            Reporting
            Security
            BillingCommandCenter
            Nielsen
            National
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadDatabaseCollation(ConnectionString As String) As String

            'objects
            Dim DatabaseCollation As String = ""
            Dim DatabaseDetail As Database.MasterDatabase.Entities.DatabaseDetail = Nothing

            Try

                Using DataContext = New Database.MasterDatabase.DataContext(ConnectionString, "")

                    DatabaseDetail = DataContext.DatabaseDetails.Where(Function(DBDetail) DBDetail.Name = DataContext.Connection.Database).SingleOrDefault

                    DatabaseCollation = DatabaseDetail.Collation

                End Using

            Catch ex As Exception
                DatabaseCollation = ""
            End Try

            LoadDatabaseCollation = DatabaseCollation

        End Function
        Public Sub CloseDbContext(DbContext As System.Data.Entity.DbContext)

            If DbContext IsNot Nothing Then

                DbContext.Dispose()

                DbContext = Nothing

            End If

        End Sub
        Public Sub CloseDataContext(DataContext As System.Data.Linq.DataContext)

            If DataContext IsNot Nothing Then

                DataContext.Dispose()

                DataContext = Nothing

            End If

        End Sub
        Public Function CreateConnectionString(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Boolean,
                                               Optional UserName As String = "", Optional Password As String = "", Optional Application As String = "Advantage") As String

            'objects
            Dim ConnectionString As String = ""
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder

            SqlConnectionStringBuilder.ApplicationName = Application
            SqlConnectionStringBuilder.DataSource = ServerName
            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            If UseWindowsAuthentication Then

                SqlConnectionStringBuilder.IntegratedSecurity = UseWindowsAuthentication
                SqlConnectionStringBuilder.PersistSecurityInfo = False

            Else

                SqlConnectionStringBuilder.PersistSecurityInfo = True
                SqlConnectionStringBuilder.UserID = UserName
                SqlConnectionStringBuilder.Password = Password

            End If

            ConnectionString = SqlConnectionStringBuilder.ConnectionString

            CreateConnectionString = ConnectionString

        End Function
        Public Function IsValidConnectionString(ConnectionString As String) As Boolean


            'objects
            Dim IsValid As Boolean = True
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) OrElse String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) Then

                    IsValid = False

                End If

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid Then

                IsValid = TestConnectionString(ConnectionString)

            End If

            IsValidConnectionString = IsValid

        End Function
        Public Function IsValidConnectionStringWithTimeoutSet(ConnectionString As String) As Boolean


            'objects
            Dim IsValid As Boolean = True
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

                SqlConnectionStringBuilder.ConnectTimeout = 1

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) OrElse String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) Then

                    IsValid = False

                End If

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid Then

                IsValid = TestConnectionString(SqlConnectionStringBuilder.ToString)

            End If

            IsValidConnectionStringWithTimeoutSet = IsValid

        End Function
        Public Function TestConnectionString(ConnectionString As String) As Boolean

            TestConnectionString = TestConnectionString(ConnectionString, "")

        End Function
        Public Function TestConnectionString(ConnectionString As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim CanConnect As Boolean = True

            Try

                Using DataContext = New Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                    If DataContext.Databases.Any Then

                        CanConnect = True

                    Else

                        CanConnect = False

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
                CanConnect = False
            Finally
                TestConnectionString = CanConnect
            End Try

        End Function
        Public Function LoadSQLUser(ConnectionString As String) As String


            'objects
            Dim SQLUser As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

                SQLUser = SqlConnectionStringBuilder.UserID

            Catch ex As Exception
                SQLUser = String.Empty
            End Try

            LoadSQLUser = SQLUser

        End Function
        Public Function ValidateServerAndDatabase(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Boolean, UserName As String, ByRef Password As String, Application As String, CheckPasswordPolicyMessages As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ConnectionString As String = ""
            Dim IsValid As Boolean = False

            Try

                ConnectionString = Database.CreateConnectionString(ServerName, "master", UseWindowsAuthentication, UserName, Password, Application)

                Using DataContext = New Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                    If DataContext.Databases.Any(Function(Database) Database.Name = DatabaseName) Then

                        IsValid = True

                    Else

                        ErrorMessage = "Invalid database (" & DatabaseName & ")"
                        IsValid = False

                    End If

                End Using

                'Using Conn = New SqlClient.SqlConnection(ConnectionString)

                '    Conn.Open()

                '    If Conn.State = ConnectionState.Open Then

                '        IsValid = True
                '        Conn.Close()

                '    End If

                'End Using

            Catch ex As Exception

                If TypeOf ex Is System.Data.SqlClient.SqlException Then

                    If DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18487 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = Security.Application.Advantage.ToString Then

                        '    Navigation.ShowMessageBox("Your password has expired.")

                        '    If Navigation.ShowChangePassword(SSConnectionString, UserName, Password) = WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "Your password has expired."

                        '    Navigation.ShowChangePasswordWithMessage(SSConnectionString, UserName, Password, ErrorMessage)

                        'End If

                    ElseIf DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18488 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = Security.Application.Advantage.ToString Then

                        '    Navigation.ShowMessageBox("You must change password on first login.")

                        '    If Navigation.ShowChangePassword(ServerName, DatabaseName, UserName, Password) = WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "You must change password on first login."

                        '    Navigation.ShowChangePasswordWithMessage(ServerName, DatabaseName, UserName, Password, ErrorMessage)

                        'End If

                    ElseIf DirectCast(ex, System.Data.SqlClient.SqlException).Number = -1 Then

                        ErrorMessage = "Invalid server (" & ServerName & ")"
                        IsValid = False

                    Else

                        ErrorMessage = DirectCast(ex, System.Data.SqlClient.SqlException).Message
                        IsValid = False

                    End If

                End If

            Finally
                ValidateServerAndDatabase = IsValid
            End Try

        End Function
        <System.Runtime.CompilerServices.Extension>
        Public Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function

#End Region

    End Module

End Namespace
