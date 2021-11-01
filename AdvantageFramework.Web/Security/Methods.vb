Namespace Web.Security

    Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Shared Function DeleteCacheDependencyFile(ByVal Key As String, Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim DeletedCacheDependencyFile As Boolean = True
            Dim CacheDependencyDirectory As String = ""
            Dim CacheDependencyFile As String = ""

            Try

                If Key.Trim() <> "" Then

                    Try

                        If System.Configuration.ConfigurationManager.AppSettings("CacheDependencyDirectory").ToString().Trim() = "" Then
                            CacheDependencyDirectory = "CacheDependency"
                        End If

                        CacheDependencyDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CacheDependencyDirectory, "\")

                        If CacheDependencyDirectory.IndexOf(":\") = -1 And CacheDependencyDirectory.IndexOf("\\") = -1 Then 'not a full path or UNC path, stick it under WV

                            CacheDependencyDirectory = System.Web.HttpContext.Current.Server.MapPath("~\") & CacheDependencyDirectory

                        End If

                        If CacheDependencyDirectory.Trim = "\" Then

                            CacheDependencyDirectory = ""

                        End If

                    Catch ex As Exception
                        CacheDependencyDirectory = ""
                    End Try

                    If CacheDependencyDirectory <> "" Then

                        If System.IO.Directory.Exists(CacheDependencyDirectory) = True Then

                            CacheDependencyFile = CacheDependencyDirectory & Key & ".txt"

                            Try

                                If System.IO.File.Exists(CacheDependencyFile) Then
                                    System.IO.File.Delete(CacheDependencyFile)
                                End If

                            Catch ex As Exception
                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                DeletedCacheDependencyFile = False
                            End Try

                        End If

                    End If

                End If

                If DeletedCacheDependencyFile Then

                    ErrorMessage = ""

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                DeletedCacheDependencyFile = False
            End Try

            DeleteCacheDependencyFile = DeletedCacheDependencyFile

        End Function
        Public Shared Function BuildConnectionString(ByVal Server As String, ByVal Database As String, ByVal UserCode As String, ByVal Password As String) As String
            Dim sb As New System.Text.StringBuilder
            Dim WebSettings As New AdvantageFramework.Web.Settings

            With sb

                .Append("Application Name=Webvantage;")
                .Append("Persist Security Info=False;")

                .Append("Data Source=")
                .Append(Server)
                .Append(";")

                .Append("Initial Catalog=")
                .Append(Database)
                .Append(";")

                If WebSettings.IsNTAuth = True Then

                    .Append("Trusted_Connection=yes;")

                Else

                    .Append("User ID=")
                    .Append(UserCode)
                    .Append(";")

                    .Append("Password=")
                    .Append(Password)
                    .Append(";")

                End If

                '.Append("Pooling=")
                '.Append(WebSettings.ConnString_Pooling.ToString())
                '.Append(";")

                '.Append("Connect Timeout=")
                '.Append(WebSettings.ConnString_Timeout.ToString())
                '.Append(";")

                '.Append("Connection Lifetime=")
                '.Append(WebSettings.ConnString_Lifetime.ToString())
                '.Append(";")

                '.Append("Connection Reset=")
                '.Append(WebSettings.ConnString_Reset.ToString())
                '.Append(";")

                '.Append("Max Pool Size=")
                '.Append(WebSettings.ConnString_MaxPoolSize.ToString())
                '.Append(";")

                '.Append("Min Pool Size=")
                '.Append(WebSettings.ConnString_MinPoolSize.ToString())
                '.Append(";")

            End With

            Return sb.ToString()

        End Function
        Public Shared Function BuildAdminConnectionString(ByVal Server As String, ByVal Database As String, ByVal UserCode As String, ByVal Password As String) As String

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim WebSettings As AdvantageFramework.Web.Settings = Nothing

            StringBuilder = New System.Text.StringBuilder
            WebSettings = New AdvantageFramework.Web.Settings

            With StringBuilder

                .Append("Application Name=Webvantage;")
                .Append("Persist Security Info=False;")

                .Append("Data Source=")
                .Append(Server)
                .Append(";")

                .Append("Initial Catalog=")
                .Append(Database)
                .Append(";")

                .Append("User ID=")
                .Append(UserCode)
                .Append(";")

                .Append("Password=")
                .Append(Password)
                .Append(";")

                .Append("Pooling=")
                .Append(WebSettings.ConnString_Pooling.ToString())
                .Append(";")

                .Append("Connect Timeout=")
                .Append(WebSettings.ConnString_Timeout.ToString())
                .Append(";")

                .Append("Connection Lifetime=")
                .Append(WebSettings.ConnString_Lifetime.ToString())
                .Append(";")

                .Append("Connection Reset=")
                .Append(WebSettings.ConnString_Reset.ToString())
                .Append(";")

                .Append("Max Pool Size=")
                .Append(WebSettings.ConnString_MaxPoolSize.ToString())
                .Append(";")

                .Append("Min Pool Size=")
                .Append(WebSettings.ConnString_MinPoolSize.ToString())
                .Append(";")

            End With

            BuildAdminConnectionString = StringBuilder.ToString()

        End Function

#End Region

    End Class

End Namespace
