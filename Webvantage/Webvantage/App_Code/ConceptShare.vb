Imports Newtonsoft.Json

<CLSCompliant(False)>
<Serializable()>
Public Class ConceptShareSession

#Region " Constants "

    Public Const CsIsRouted As String = "LOLT20150321_CSIR"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Session As AdvantageFramework.Security.Session

#End Region

#Region " Properties "

    Public Property Reviewers As New Generic.List(Of AdvantageFramework.ConceptShare.Classes.Reviewer)
    Public Property Employees As New Generic.List(Of ConceptShareEmployee)

#End Region

#Region " Methods "

    Public Shared Function GetUserReviewRoutedSetting(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

        Dim IsRoutedChecked As Boolean = False

        If HttpContext.Current.Session(CsIsRouted) Is Nothing Then

            IsRoutedChecked = AdvantageFramework.AlertSystem.GetUserReviewRoutedSetting(DbContext)
            HttpContext.Current.Session(CsIsRouted) = IsRoutedChecked

        Else

            IsRoutedChecked = CType(HttpContext.Current.Session(CsIsRouted), Boolean)

        End If

        Return IsRoutedChecked

    End Function
    Public Shared Function SetUserReviewRoutedSetting(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal Checked As Boolean) As Boolean

        AdvantageFramework.AlertSystem.SetUserReviewRoutedSetting(DbContext, Checked)
        HttpContext.Current.Session(CsIsRouted) = Checked

    End Function
    Public Function LoadReviewStatusList() As Generic.List(Of AdvantageFramework.ConceptShareAPI.Status)

        Dim ReviewStatusList As Generic.List(Of AdvantageFramework.ConceptShareAPI.Status) = Nothing

        If HttpContext.Current.Session("ReviewStatusList") Is Nothing Then

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                ReviewStatusList = AdvantageFramework.ConceptShare.LoadStatus(DataContext, AdvantageFramework.ConceptShareAPI.StatusType.Review)

            End Using

            If ReviewStatusList Is Nothing Then ReviewStatusList = New Generic.List(Of AdvantageFramework.ConceptShareAPI.Status)

            HttpContext.Current.Session("ReviewStatusList") = Newtonsoft.Json.JsonConvert.SerializeObject(ReviewStatusList)

        Else

            ReviewStatusList = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.ConceptShareAPI.Status))(HttpContext.Current.Session("ReviewStatusList"))

        End If

        Return ReviewStatusList

    End Function

    Public Sub ReloadReviewers()

        HttpContext.Current.Session("ConceptShareReviewersList") = Nothing
        LoadConceptShareReviewers()

    End Sub
    Public Sub LoadConceptShareReviewers()

        If HttpContext.Current.Session("ConceptShareReviewersList") Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    Reviewers = DbContext.Database.SqlQuery(Of AdvantageFramework.ConceptShare.Classes.Reviewer)("EXEC [dbo].[advsp_cs_load_all_reviewers];").ToList

                Catch ex As Exception
                    Reviewers = Nothing
                End Try

                If Reviewers Is Nothing Then Reviewers = New Generic.List(Of AdvantageFramework.ConceptShare.Classes.Reviewer)

            End Using

            HttpContext.Current.Session("ConceptShareReviewersList") = Reviewers

        Else

            Reviewers = HttpContext.Current.Session("ConceptShareReviewersList")

        End If

    End Sub
    Public Sub LoadConceptShareEmployees()

        If HttpContext.Current.Session("ConceptShareEmployeesList") Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
                        Dim CsEmp As New ConceptShareEmployee

                        Employees = (From Entity In DbContext.Employees
                                     Where Entity.ConceptShareUserID IsNot Nothing And Entity.ConceptShareUserID > 0).ToList

                        If Employees IsNot Nothing Then

                            For Each e As AdvantageFramework.Database.Views.Employee In Employees

                                CsEmp = New ConceptShareEmployee

                                CsEmp.EmployeeCode = e.Code
                                CsEmp.ConceptShareUserID = e.ConceptShareUserID

                                Me.Employees.Add(CsEmp)

                                CsEmp = Nothing

                            Next

                        End If

                        Dim ClientPortalUsers As Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) = Nothing

                        Try

                            ClientPortalUsers = (From Entity In SecurityContext.ClientPortalUsers
                                                 Where Entity.ConceptShareUserID IsNot Nothing And Entity.ConceptShareUserID > 0
                                                 Select Entity).ToList

                        Catch ex As Exception
                            ClientPortalUsers = Nothing
                        End Try

                        If ClientPortalUsers IsNot Nothing AndAlso ClientPortalUsers.Count > 0 Then

                            For Each c As AdvantageFramework.Security.Database.Entities.ClientPortalUser In ClientPortalUsers

                                CsEmp = New ConceptShareEmployee

                                CsEmp.ConceptShareUserID = c.ConceptShareUserID
                                CsEmp.ClientContactID = c.ClientContactID

                                Me.Employees.Add(CsEmp)

                                CsEmp = Nothing

                            Next

                        End If

                    Catch ex As Exception
                        Employees = Nothing
                    End Try

                    If Employees Is Nothing Then Employees = New Generic.List(Of ConceptShareEmployee)

                End Using

            End Using

            HttpContext.Current.Session("ConceptShareEmployeesList") = Employees

        Else

            Employees = HttpContext.Current.Session("ConceptShareEmployeesList")

        End If

    End Sub

    Public Function CreateConceptShareConnection() As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        Return Nothing

        ''Using DataContext = New AdvantageFramework.Database.DataContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''    If MiscFN.IsClientPortal = False Then

        ''        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''            Dim Employee As AdvantageFramework.Database.Views.Employee

        ''            Employee = Nothing
        ''            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode"))

        ''            CreateConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext, Employee)

        ''        End Using

        ''    Else

        ''        Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''            Dim ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser

        ''            ClientPortalUser = Nothing
        ''            ClientPortalUser = New AdvantageFramework.Security.Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(DbContext, HttpContext.Current.Session("UserID")))

        ''            CreateConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext, DbContext, ClientPortalUser)

        ''        End Using

        ''    End If

        ''End Using

    End Function
    Public Function CreateClientPortalConceptShareConnection() As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        Return Nothing
        ''Using DataContext = New AdvantageFramework.Database.DataContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''    Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''        Dim ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser

        ''        ClientPortalUser = Nothing
        ''        ClientPortalUser = New AdvantageFramework.Security.Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(DbContext, HttpContext.Current.Session("UserID")))

        ''        CreateClientPortalConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext, DbContext, ClientPortalUser)

        ''    End Using

        ''End Using

    End Function
    Public Function CreateAdminConceptShareConnection() As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        Return Nothing

        ''Using DataContext = New AdvantageFramework.Database.DataContext(Me._Session.ConnectionString, Me._Session.UserCode)

        ''    CreateAdminConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext)

        ''End Using

    End Function

    Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

        _Session = SecuritySession

    End Sub

#End Region

    'simple poco for web session
    <Serializable()>
    Public Class ConceptShareEmployee

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String = String.Empty
        Public Property ClientContactID As Integer = 0
        Public Property ConceptShareUserID As Integer = 0


#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Class
