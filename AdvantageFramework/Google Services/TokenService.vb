Namespace GoogleServices

    Public Class TokenService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private Shared _Assembly As System.Reflection.Assembly = Nothing
        Private Shared _MethodInfos As System.Reflection.MethodInfo() = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region " Shared "

        Private Shared Function GetServicesAssembly() As System.Reflection.Assembly

            Try

                If _Assembly Is Nothing Then

                    _Assembly = System.Reflection.Assembly.Load("AdvantageFramework.GoogleServices")

                End If

            Catch ex As Exception
                _Assembly = Nothing
            End Try

            GetServicesAssembly = _Assembly

        End Function
        Private Shared Function GetServiceMethodInfos() As System.Reflection.MethodInfo()

            Dim Assembly As System.Reflection.Assembly = Nothing
            Dim BaseMethodType As System.Type = Nothing

            Try

                If _MethodInfos Is Nothing Then

                    Assembly = GetServicesAssembly()

                    If Assembly IsNot Nothing Then

                        BaseMethodType = LoadBaseMethodTypeShared(Assembly)

                        If BaseMethodType IsNot Nothing Then

                            _MethodInfos = BaseMethodType.GetMethods()

                        End If

                    End If

                End If

            Catch ex As Exception
                _MethodInfos = Nothing
            End Try

            GetServiceMethodInfos = _MethodInfos

        End Function
        Private Shared Function LoadBaseMethodTypeShared(Assembly As System.Reflection.Assembly) As System.Type

            'objects
            Dim BaseMethodType As System.Type = Nothing

            Try

                BaseMethodType = Assembly.GetTypes().Where(Function([Type]) [Type].FullName = "AdvantageFramework.GoogleServices.Methods").SingleOrDefault

            Catch ex As Exception
                BaseMethodType = Nothing
            Finally
                LoadBaseMethodTypeShared = BaseMethodType
            End Try

        End Function
        Public Shared Function GetOrRefreshToken(ConnectionString As String, UseWindowsAuthentication As Boolean, EmployeeCode As String, Scopes() As String, ClientCode As String) As String

            'objects
            Dim AccessToken As String = String.Empty
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                MethodInfos = GetServiceMethodInfos()

                If MethodInfos IsNot Nothing Then

                    AccessToken = MethodInfos.Where(Function(Method) Method.Name = "GetOrRefreshToken").SingleOrDefault.Invoke(Nothing, {ConnectionString, UseWindowsAuthentication, EmployeeCode, Scopes, ClientCode})

                End If

            Catch ex As Exception
                AccessToken = Nothing
            Finally
                GetOrRefreshToken = AccessToken
            End Try

        End Function

#End Region

#End Region

    End Class

End Namespace

