Imports System.Diagnostics
Imports System.IO
Imports System.Web
Imports System.Web.Caching
Imports System.Web.SessionState

Public Class SessionEndModule
    Implements IHttpModule

    Public Shared Event SessionEnd(sender As Object, e As SessionEndedEventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _HttpApplication As HttpApplication = Nothing
    Private Shared _SessionObjectKey As String = ""

#End Region

#Region " Properties "

    Public Shared Property SessionObjectKey() As String
        Get
            SessionObjectKey = _SessionObjectKey
        End Get
        Set(value As String)
            _SessionObjectKey = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init

        _HttpApplication = context
        AddHandler _HttpApplication.PreRequestHandlerExecute, AddressOf OnPreRequestHandlerExecute

    End Sub
    Public Sub Dispose() Implements IHttpModule.Dispose

        'RemoveHandler _HttpApplication.PreRequestHandlerExecute, AddressOf OnPreRequestHandlerExecute

    End Sub
    Private Sub OnPreRequestHandlerExecute(sender As Object, e As EventArgs)

        'objects
        Dim CurrentSession As HttpSessionState = Nothing
        Dim SessionTimeout As TimeSpan = Nothing
        Dim SessionObject As Object = Nothing
        Dim CacheDependencyFile As String = ""
        Dim CacheDependencyDirectory As String = ""
        Dim CacheInserted As Boolean = False

        If SessionObjectKey = "" Then

            Exit Sub

        End If

        If Path.GetExtension(_HttpApplication.Context.Request.Path).ToLower() = ".aspx" Then

            If HttpContext.Current IsNot Nothing Then

                CurrentSession = HttpContext.Current.Session

                If CurrentSession IsNot Nothing Then

                    SessionTimeout = New TimeSpan(0, 0, CurrentSession.Timeout, 0, 0)

                    If CurrentSession("UserGUID") IsNot Nothing Then

                        SessionObject = CurrentSession(SessionObjectKey) & "ClientPortalUserName=" & CurrentSession("UserName")

                    Else

                        If MiscFN.IsNTAuth = True Then

                            SessionObject = CurrentSession("AdminConnString") & "AdvantageUserCode=" & CurrentSession("UserCode")

                        Else

                            SessionObject = CurrentSession(SessionObjectKey)

                        End If

                        SessionObject &= "UserLoginAuditID=" & CurrentSession("UserLoginAuditID")

                    End If

                    If SessionObject IsNot Nothing AndAlso SessionTimeout <> Nothing Then

                        Try

                            If CurrentSession("CurrentSessionId") IsNot Nothing AndAlso CurrentSession("CurrentSessionId") <> "" Then

                                Try

                                    If System.Configuration.ConfigurationManager.AppSettings("CacheDependencyDirectory").ToString().Trim() = "" Then

                                        CacheDependencyDirectory = "CacheDependency"

                                    End If

                                    CacheDependencyDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CacheDependencyDirectory, "\")

                                    If CacheDependencyDirectory.IndexOf(":\") = -1 And CacheDependencyDirectory.IndexOf("\\") = -1 Then 'not a full path or UNC path, stick it under WV

                                        CacheDependencyDirectory = HttpContext.Current.Server.MapPath("~\") & CacheDependencyDirectory


                                    End If

                                    If Directory.Exists(CacheDependencyDirectory) = False Then

                                        Directory.CreateDirectory(CacheDependencyDirectory)

                                    End If

                                    If CacheDependencyDirectory.Trim = "\" Then

                                        CacheDependencyDirectory = ""

                                    End If

                                Catch ex As Exception
                                    CacheDependencyDirectory = ""
                                End Try

                                If CacheDependencyDirectory <> "" Then

                                    Try

                                        If Directory.Exists(CacheDependencyDirectory) = True Then

                                            CacheDependencyFile = CacheDependencyDirectory & CurrentSession("CurrentSessionId") & ".txt"

                                            If File.Exists(CacheDependencyFile) = False Then

                                                File.Create(CacheDependencyFile).Close()

                                            End If

                                            HttpContext.Current.Cache.Insert(CacheDependencyFile, SessionObject, New System.Web.Caching.CacheDependency(CacheDependencyFile), DateTime.MaxValue, _
                                                                             SessionTimeout, CacheItemPriority.NotRemovable, New CacheItemRemovedCallback(AddressOf CacheItemRemovedCallbackMethod))

                                            CacheInserted = True

                                        End If

                                    Catch ex As Exception
                                        CacheInserted = False
                                    End Try

                                End If

                                If CacheInserted = False Then

                                    CacheDependencyFile = CurrentSession("CurrentSessionId") & ".txt"

                                    HttpContext.Current.Cache.Insert(CacheDependencyFile, SessionObject, Nothing, DateTime.MaxValue, _
                                                                     SessionTimeout, CacheItemPriority.NotRemovable, New CacheItemRemovedCallback(AddressOf CacheItemRemovedCallbackMethod))

                                End If

                            End If

                        Catch ex As Exception
                            Err.Raise(Err.Number, "Error: SessionEndModule.vb, OnPreRequestHandlerExecute" & Environment.NewLine & _
                                      ex.Message.ToString() & Environment.NewLine & Environment.NewLine & ex.InnerException.ToString())
                        End Try

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub CacheItemRemovedCallbackMethod(key As String, value As Object, reason As CacheItemRemovedReason)

        'objects
        Dim SessionEndedEventArgs As SessionEndedEventArgs = Nothing
        Dim CacheDependencyFile As String = ""
        Dim SessionID As String = ""

        If key = "" Then

            Exit Sub

        End If

        Try

            If reason = CacheItemRemovedReason.Expired Then

                CacheDependencyFile = key

                For Each StringSection In Split(CacheDependencyFile, "\")

                    If StringSection.EndsWith(".txt") Then

                        SessionID = StringSection.Replace(".txt", "").Trim

                    End If

                Next

                SessionEndedEventArgs = New SessionEndedEventArgs(SessionID, value)

                AdvantageFramework.Security.AddWebvantageEventLog("Cache item expired, going to raise SessionEnd event")

                RaiseEvent SessionEnd(Me, SessionEndedEventArgs)

                Try

                    If File.Exists(CacheDependencyFile) Then

                        File.Delete(CacheDependencyFile)

                    End If

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            'Err.Raise(Err.Number, "Error: SessionEndModule.vb, CacheItemRemovedCallbackMethod" & Environment.NewLine & _
            '          ex.Message.ToString() & Environment.NewLine & Environment.NewLine & ex.InnerException.ToString())
        End Try

    End Sub

#End Region

End Class

Public Class SessionEndedEventArgs
    Inherits EventArgs

    Public ReadOnly SessionId As String
    Public ReadOnly SessionObject As Object

    Public Sub New(EndedSessionID As String, EndedSessionObject As Object)

        SessionId = EndedSessionID
        SessionObject = EndedSessionObject

    End Sub

End Class
