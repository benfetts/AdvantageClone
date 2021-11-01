Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Web.UI
Imports System.IO
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Web.SessionState
Imports System.ComponentModel

Namespace Web.UserSettings

#Region " Enum "

    Public Enum ApplicationPage

        'AlertInbox
        'BillingApprovalByJobComponent
        BookmarksDO
        ProjectViewpoint
        SearchAll
        'Timesheet

    End Enum

#End Region

#Region " Settings Classes "

    <Serializable()> _
    Public Class SearchAllOptions

        Public Property ExactSearch As Boolean = False

        Public Property JobsOpen As Boolean = False
        Public Property JobsClosed As Boolean = False
        Public Property JobsDescription As Boolean = False
        Public Property JobsComments As Boolean = False

        Public Property AlertsStandard As Boolean = False
        Public Property AlertsAssignments As Boolean = False
        Public Property AlertsSubject As Boolean = False
        Public Property AlertsDescription As Boolean = False
        Public Property AlertsOpen As Boolean = False
        Public Property AlertsDismissedCompleted As Boolean = False

        Public Property ScheduleComments As Boolean = False
        Public Property ScheduleIncludeClosed As Boolean = False

        Public Property ScheduleTaskIncludeClosed As Boolean = False
        Public Property ScheduleTaskDescription As Boolean = False
        Public Property ScheduleTaskFunctionComments As Boolean = False
        Public Property ScheduleTaskDueDateComments As Boolean = False
        Public Property ScheduleTaskRevisionDateComments As Boolean = False

        Public Property EstimateDescription As Boolean = False
        Public Property EstimateComments As Boolean = False
        Public Property EstimateFooterComments As Boolean = False
        Public Property EstimateComponentDescription As Boolean = False
        Public Property EstimateComponentComments As Boolean = False
        Public Property EstimateQuoteDetailComments As Boolean = False
        Public Property EstimateQuoteDetailDescription As Boolean = False

        Public Property CampaignComments As Boolean = False

        Public Property PurchaseOrderDescription As Boolean = False
        Public Property PurchaseOrderMainInstruction As Boolean = False
        Public Property PurchaseOrderDeliveryInstruction As Boolean = False
        Public Property PurchaseOrderDetailDescription As Boolean = False
        Public Property PurchaseOrderDetailLineDescription As Boolean = False
        Public Property PurchaseOrderDetailInstruction As Boolean = False

        Sub New()

        End Sub

    End Class
    <Serializable()> _
    Public Class ProjectViewpointOptions



        Sub New()

        End Sub

    End Class
    <Serializable()> _
    Public Class BookmarksDOOptions

        Public Enum DisplayType

            Tree = 0
            Tiles = 1
            Grid = 2

        End Enum
        Private Enum PropertyName
            ViewAs
        End Enum

        Public Property ViewAs As DisplayType = DisplayType.Tree

        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""
        Private Property _Context As HttpContext = Nothing

        Public Sub Save()

            Dim Settings As New AdvantageFramework.Web.UserSettings.Settings(New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode),
                                                                             AdvantageFramework.Web.UserSettings.ApplicationPage.BookmarksDO,
                                                                             _Context)

            Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing
            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.BookmarksDO.ToString()
                .Group = "0"
                .Type = "Integer"
                .Name = PropertyName.ViewAs.ToString()
                .Value = CType(Me.ViewAs, Integer)

            End With

            Settings.Update(Setting)

            Setting = Nothing
            Settings = Nothing

        End Sub
        Public Sub Load()

            Dim Settings As New AdvantageFramework.Web.UserSettings.Settings(New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode),
                                                                             AdvantageFramework.Web.UserSettings.ApplicationPage.BookmarksDO,
                                                                             _Context)

            Settings.Load()

            For Each Setting In Settings.List

                Select Case Setting.Name
                    Case PropertyName.ViewAs.ToString()
                        Me.ViewAs = CType(CType(Setting.Value, Integer), DisplayType)

                End Select

            Next

            Settings = Nothing

        End Sub
        Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal Context As HttpContext)

            _ConnectionString = ConnectionString
            _UserCode = UserCode
            _Context = Context

        End Sub

    End Class
    'Public Enum TimesheetParameters

    '    CopyFromTemplateInsertHours
    '    DaysToDisplay
    '    DivisionLabel
    '    FuncCatLabel
    '    JobLabel
    '    JobCompLabel
    '    ProdCatLabel
    '    ProductLabel
    '    ShowCommentUsing
    '    StartWeekOn
    '    DeleteZero

    'End Enum
    'Public Enum BillingApprovalByJobComponentParameters

    '    JobComponentPanelVisible
    '    ApprovalPanelVisible
    '    CommentsPanelVisible
    '    DetailsPanelVisible
    '    FunctionsPanelVisible

    'End Enum

#End Region

    Public Class Settings

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Options As Object = Nothing

        Public Property [List] As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)

        Private Property _DbContext As Database.DbContext = Nothing
        Private Property _HttpContext As HttpContext = Nothing
        Private Property _ApplicationPage As Web.UserSettings.ApplicationPage
        Private Property _SessionKey As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Sub Load()

            If Not Me._HttpContext Is Nothing Then

                If Not Me._HttpContext.Session(Me._SessionKey) Is Nothing Then

                    Me.[List] = CType(Me._HttpContext.Session(Me._SessionKey), Generic.List(Of AdvantageFramework.Database.Entities.AppVars))

                Else

                    Me.LoadFromDatabase()

                End If

            Else

                Me.LoadFromDatabase()

            End If

        End Sub
        Private Sub LoadFromDatabase()

            Using _DbContext

                [List] = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(_DbContext, _DbContext.UserCode, _ApplicationPage.ToString()).ToList()

            End Using

        End Sub

        Public Sub Update()

            Using _DbContext

                If AdvantageFramework.Database.Procedures.AppVars.Delete(_DbContext, _DbContext.UserCode, _ApplicationPage.ToString()) = True Then

                    If AdvantageFramework.Database.Procedures.AppVars.BulkInsertList(_DbContext, Me.[List]) = True Then

                        Me._HttpContext.Session(Me._SessionKey) = Nothing

                    End If

                End If

            End Using

        End Sub
        Public Sub Update(ByVal AppVar As AdvantageFramework.Database.Entities.AppVars)

            Dim ThisAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Using _DbContext

                ThisAppVar = AdvantageFramework.Database.Procedures.AppVars.Load(_DbContext, AppVar)

                If ThisAppVar Is Nothing Then

                    If AdvantageFramework.Database.Procedures.AppVars.Insert(_DbContext, AppVar) = True Then

                        Me._HttpContext.Session(Me._SessionKey) = Nothing

                    End If

                Else

                    If AdvantageFramework.Database.Procedures.AppVars.Update(_DbContext, ThisAppVar) = True Then

                        Me._HttpContext.Session(Me._SessionKey) = Nothing

                    End If

                End If

            End Using

        End Sub
        Public Sub UpdateGroup(ByVal Group As String)

            Using _DbContext

                If AdvantageFramework.Database.Procedures.AppVars.Delete(_DbContext, _DbContext.UserCode, _ApplicationPage.ToString(), Group) = True Then

                    If AdvantageFramework.Database.Procedures.AppVars.BulkInsertList(_DbContext, Me.[List]) = True Then

                        Me._HttpContext.Session(Me._SessionKey) = Nothing

                    End If

                End If

            End Using

        End Sub

        Public Sub New(ByVal DbContext As Database.DbContext, ByVal ApplicationPage As Web.UserSettings.ApplicationPage,
                        Optional ByVal HttpContext As HttpContext = Nothing)

            _DbContext = DbContext

            _HttpContext = HttpContext
            _ApplicationPage = ApplicationPage

            Me._SessionKey = Me._ApplicationPage.ToString() & "UserSettings"

            Me._UserCode = Me._DbContext.UserCode

            Select Case ApplicationPage
                Case UserSettings.ApplicationPage.SearchAll

                    Options = New AdvantageFramework.Web.UserSettings.SearchAllOptions()

            End Select

            Me.[List] = New Generic.List(Of AdvantageFramework.Database.Entities.AppVars)

        End Sub

#End Region

    End Class

End Namespace