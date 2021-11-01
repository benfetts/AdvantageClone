Public Class Reporting_InitialLoadingRefreshData
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _DynamicReportTemplateID As Integer = 0
    Protected _DynamicReportType As Integer = 0
    Protected _DynamicReportShowGroupByBox As Boolean = False
    Protected _DynamicReportShowViewCaption As Boolean = False
    Protected _DynamicReportShowAutoFilterRow As Boolean = False
    Protected _DynamicReportActiveFilter As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            _DynamicReportType = Session("DRPT_Type")

        Catch ex As Exception
            _DynamicReportType = 0
        End Try

        Try

            _DynamicReportShowGroupByBox = Session("DRPT_ShowGroupByBox")

        Catch ex As Exception
            _DynamicReportShowGroupByBox = False
        End Try

        Try

            _DynamicReportShowViewCaption = Session("DRPT_ShowViewCaption")

        Catch ex As Exception
            _DynamicReportShowViewCaption = False
        End Try

        Try

            _DynamicReportShowAutoFilterRow = Session("DRPT_ShowAutoFilterRow")

        Catch ex As Exception
            _DynamicReportShowAutoFilterRow = False
        End Try

        Try

            _DynamicReportActiveFilter = Session("DRPT_ActiveFilter")

        Catch ex As Exception
            _DynamicReportActiveFilter = ""
        End Try

    End Sub


#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingSaveDynamicReportTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _DynamicReportTemplateID > 0 Then

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                End If

                Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, DynamicReport.Type)

                End Using

                If DynamicReportDataset IsNot Nothing AndAlso DynamicReportDataset.LastUpdated.HasValue Then

                    LabelQuestion.Text = "Report Data Last Updated on " & DynamicReportDataset.LastUpdated.Value.ToShortDateString & " " & DynamicReportDataset.LastUpdated.Value.ToShortTimeString

                Else

                    LabelQuestion.Text = "Report Data has not been updated"

                End If

                LabelQuestion1.Text = "Do you want to update report data now?"

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim DynamicReportColList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumnList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) = Nothing
        Dim DynamicReportCol As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim ContinueSaving As Boolean = False
        Dim IsAddingTemplate As Boolean = False
        Dim UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing
        Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonYes.Value

                Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.Reporting.LoadJobDetailItemDataSet(DbContext)

                        DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _DynamicReportType)

                        DynamicReportDataset.LastUpdated = Date.Now
                        DynamicReportDataset.UpdatedBy = _Session.UserCode

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.Update(ReportDbContext, DynamicReportDataset)

                    End Using

                End Using

                Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

            Case RadToolBarButtonNo.Value

                Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

        End Select

    End Sub

#End Region

#End Region

End Class
