Public Class Reporting_UserDefinedReportEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Private Sub Reporting_UserDefinedReportEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each KeyValuePair In AdvantageFramework.Reporting.LoadAvailableDynamicReportDataSets(_Session)

                    RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(KeyValuePair.Value, KeyValuePair.Key))

                Next

                RadComboBoxReportType.SelectedIndex = 0

                PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Description)

                If PropertyDescriptor IsNot Nothing Then

                    TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                End If

                RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).OrderBy(Function(c) c.Description).ToList
                RadComboBoxReportCategory.DataBind()
                RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

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
        Dim DynamicReportType As Integer = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonAdd.Value

                If TextBoxDescription.Text <> "" Then

                    If RadComboBoxReportType.SelectedIndex > -1 Then

                        Session("DRPT_UseBlankData") = True
                        Session("DRPT_DashboardLoaded") = False
                        Session("DRPT_Data") = Nothing

                        Session("DRPT_Criteria") = Nothing
                        Session("DRPT_FilterString") = Nothing
                        Session("DRPT_From") = Nothing
                        Session("DRPT_To") = Nothing
                        Session("DRPT_ShowJobsWithNoDetails") = Nothing
                        Session("DRPT_ParameterDictionary") = Nothing
                        Session("DRPT_Type") = Nothing
                        Session("DRPT_ShowGroupByBox") = Nothing
                        Session("DRPT_ShowViewCaption") = Nothing
                        Session("DRPT_ShowAutoFilterRow") = Nothing
                        Session("DRPT_ActiveFilter") = Nothing
                        Session("DRPT_ColumnsList") = Nothing
                        Session("DRPT_Layout") = Nothing
                        Session("DRPT_UDRCategory") = Nothing
                        Session("DRPT_Description") = Nothing

                        Try

                            Session("DRPT_Type") = RadComboBoxReportType.SelectedValue

                        Catch ex As Exception
                            Session("DRPT_Type") = Nothing
                        End Try

                        Try

                            Session("DRPT_Description") = TextBoxDescription.Text

                        Catch ex As Exception
                            Session("DRPT_Description") = Nothing
                        End Try

                        Try

                            Session("DRPT_UDRCategory") = RadComboBoxReportCategory.SelectedValue

                        Catch ex As Exception
                            Session("DRPT_UDRCategory") = Nothing
                        End Try

                        Me.CloseThisWindowAndOpenNewWindow("Reporting_DynamicReportEdit.aspx", True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please select a report type.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please enter a description.")

                End If

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class
