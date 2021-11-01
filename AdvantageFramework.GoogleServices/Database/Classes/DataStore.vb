Namespace Database.Classes

    Public Class DataStore
        Implements Google.Apis.Util.Store.IDataStore

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DataContext As AdvantageFramework.GoogleServices.Database.DataContext = Nothing
        Private _IsDoubleClick As Boolean = False
        Private _ClientCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            MyBase.New()

        End Sub
        Public Sub New(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal IsDoubleClick As Boolean, ClientCode As String)

            _DataContext = DataContext
            _IsDoubleClick = IsDoubleClick
            _ClientCode = ClientCode

        End Sub
        Public Function ClearAsync() As Threading.Tasks.Task Implements Google.Apis.Util.Store.IDataStore.ClearAsync

            'objects
            Dim WindowsImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

            If _DataContext.CurrentIdentity IsNot Nothing Then

                WindowsImpersonationContext = _DataContext.CurrentIdentity.Impersonate()

            End If

            _DataContext.ExecuteCommand("UPDATE [dbo].[EMPLOYEE] SET [GOOGLE_TOKEN] = NULL")

            If WindowsImpersonationContext IsNot Nothing Then

                WindowsImpersonationContext.Undo()

            End If

            'ClearAsync = System.Threading.Tasks.TaskEx.Delay(0)
            ClearAsync = System.Threading.Tasks.Task.Delay(0)

        End Function
        Public Function DeleteAsync(Of T)(EmployeeCode As String) As Threading.Tasks.Task Implements Google.Apis.Util.Store.IDataStore.DeleteAsync

            'objects
            Dim WindowsImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

            If _DataContext.CurrentIdentity IsNot Nothing Then

                WindowsImpersonationContext = _DataContext.CurrentIdentity.Impersonate()

            End If

            Delete(_DataContext, EmployeeCode, _IsDoubleClick, _ClientCode)

            If WindowsImpersonationContext IsNot Nothing Then

                WindowsImpersonationContext.Undo()

            End If

            'DeleteAsync = System.Threading.Tasks.TaskEx.Delay(0)
            DeleteAsync = System.Threading.Tasks.Task.Delay(0)

        End Function
        Public Function GetAsync(Of T)(EmployeeCode As String) As Threading.Tasks.Task(Of T) Implements Google.Apis.Util.Store.IDataStore.GetAsync

            'objects
            Dim TaskCompletionSource As System.Threading.Tasks.TaskCompletionSource(Of T) = Nothing
            Dim GoogleToken As String = Nothing
            Dim WindowsImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

            If _DataContext.CurrentIdentity IsNot Nothing Then

                WindowsImpersonationContext = _DataContext.CurrentIdentity.Impersonate()

            End If

            If String.IsNullOrWhiteSpace(EmployeeCode) Then ' agency email address

                If _IsDoubleClick Then

                    If String.IsNullOrWhiteSpace(_ClientCode) Then

                        GoogleToken = _DataContext.ExecuteQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'DC_OAUTH2_TOKEN'").SingleOrDefault

                    Else

                        GoogleToken = _DataContext.ExecuteQuery(Of String)(String.Format("SELECT [DC_OAUTH2_TOKEN] FROM [dbo].[CLIENT] WHERE [CL_CODE] = '{0}'", _ClientCode)).SingleOrDefault

                    End If

                Else

                    GoogleToken = _DataContext.ExecuteQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'SMTP_OAUTH2_TOKEN'").SingleOrDefault

                End If

            Else

                GoogleToken = _DataContext.ExecuteQuery(Of String)(String.Format("SELECT [GOOGLE_TOKEN] FROM [dbo].[EMPLOYEE] WHERE [EMP_CODE] = '{0}'", EmployeeCode)).SingleOrDefault

            End If

            TaskCompletionSource = New Threading.Tasks.TaskCompletionSource(Of T)

            If String.IsNullOrWhiteSpace(GoogleToken) = False Then

                Try

                    TaskCompletionSource.SetResult(Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize(Of T)(GoogleToken))

                Catch ex As Exception
                    TaskCompletionSource.SetException(ex)
                End Try

            Else

                TaskCompletionSource.SetResult(Nothing)

            End If

            If WindowsImpersonationContext IsNot Nothing Then

                WindowsImpersonationContext.Undo()

            End If

            GetAsync = TaskCompletionSource.Task

        End Function
        Public Function StoreAsync(Of T)(EmployeeCode As String, TokenValue As T) As Threading.Tasks.Task Implements Google.Apis.Util.Store.IDataStore.StoreAsync

            'objects
            Dim GoogleToken As String = Nothing
            Dim WindowsImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

            If _DataContext.CurrentIdentity IsNot Nothing Then

                WindowsImpersonationContext = _DataContext.CurrentIdentity.Impersonate()

            End If

            GoogleToken = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Serialize(TokenValue)

            Update(_DataContext, EmployeeCode, GoogleToken, _IsDoubleClick, _ClientCode)

            If WindowsImpersonationContext IsNot Nothing Then

                WindowsImpersonationContext.Undo()

            End If

            'Return System.Threading.Tasks.TaskEx.Delay(0)
            Return System.Threading.Tasks.Task.Delay(0)

        End Function
        Public Shared Function Update(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeCode As String, ByVal GoogleToken As String,
                                      IsDoubleClick As Boolean, ClientCode As String) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) Then 'agency 

                    If IsDoubleClick Then

                        If String.IsNullOrWhiteSpace(ClientCode) Then

                            DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'DC_OAUTH2_TOKEN'", GoogleToken))

                        Else

                            DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[CLIENT] SET [DC_OAUTH2_TOKEN] = '{0}' WHERE [CL_CODE] = '{1}'", GoogleToken, ClientCode))

                        End If

                    Else

                        DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'SMTP_OAUTH2_TOKEN'", GoogleToken))

                    End If

                Else

                    DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[EMPLOYEE] SET [GOOGLE_TOKEN] = '{0}' WHERE [EMP_CODE] = '{1}'", GoogleToken, EmployeeCode))

                End If

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Shared Function Delete(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeCode As String, IsDoubleClick As Boolean, ClientCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) Then 'agency

                    If IsDoubleClick Then

                        If String.IsNullOrWhiteSpace(ClientCode) Then

                            DataContext.ExecuteCommand("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = NULL WHERE [AGY_SETTINGS_CODE] = 'DC_OAUTH2_TOKEN'")

                        Else

                            DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[CLIENT] SET [DC_OAUTH2_TOKEN] = NULL WHERE [CL_CODE] = '{0}'", ClientCode))

                        End If

                    Else

                        DataContext.ExecuteCommand("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = NULL WHERE [AGY_SETTINGS_CODE] = 'SMTP_OAUTH2_TOKEN'")

                    End If

                Else

                    DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[EMPLOYEE] SET [GOOGLE_TOKEN] = NULL WHERE [EMP_CODE] = '{0}'", EmployeeCode))

                End If

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Class

End Namespace
