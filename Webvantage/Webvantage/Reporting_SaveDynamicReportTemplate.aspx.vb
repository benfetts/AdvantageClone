Public Class Reporting_SaveDynamicReportTemplate
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

    Private Sub Reporting_SaveDynamicReportTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Reporting.DynamicReports)).OrderBy(Function(KeyValue) KeyValue.Value)

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

                RadComboBoxReportType.Visible = True
                TextBoxDescription.Visible = True
                RadComboBoxReportCategory.Visible = True
                RadComboBoxReportType.SelectedValue = Session("DRPT_Type")
                TextBoxDescription.Text = Session("DRPT_Description")
                RadComboBoxReportCategory.SelectedValue = Session("DRPT_UDRCategory")
                LabelReportType.Visible = True
                LabelDescription.Visible = True
                LabelReportCategory.Visible = True

                RadComboBoxReportType.Enabled = False

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                If TextBoxDescription.Text <> "" Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport

                        Try

                            DynamicReport.Type = Session("DRPT_Type")

                        Catch ex As Exception
                            DynamicReport.Type = 0
                        End Try

                        Try

                            DynamicReport.ShowGroupByBox = Session("DRPT_ShowGroupByBox")

                        Catch ex As Exception
                            DynamicReport.ShowGroupByBox = False
                        End Try

                        Try

                            DynamicReport.ShowViewCaption = Session("DRPT_ShowViewCaption")

                        Catch ex As Exception
                            DynamicReport.ShowViewCaption = False
                        End Try

                        Try

                            DynamicReport.ShowAutoFilterRow = Session("DRPT_ShowAutoFilterRow")

                        Catch ex As Exception
                            DynamicReport.ShowAutoFilterRow = False
                        End Try

                        Try

                            DynamicReport.ActiveFilter = Session("DRPT_ActiveFilter")

                        Catch ex As Exception
                            DynamicReport.ActiveFilter = ""
                        End Try

                        Try

                            UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

                        Catch ex As Exception
                            UserDefinedReportCategoryID = Nothing
                        End Try

                        DynamicReport.DbContext = ReportingDbContext
                        DynamicReport.Description = TextBoxDescription.Text
                        DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                        DynamicReport.AllowCellMerge = False
                        DynamicReport.AutoSizeColumnsWhenPrinting = False
                        DynamicReport.PrintHeader = False
                        DynamicReport.PrintFooter = False
                        DynamicReport.PrintGroupFooter = False
                        DynamicReport.PrintSelectedRowsOnly = False
                        DynamicReport.PrintFilterInformation = False

                        DynamicReport.CreatedByUserCode = ReportingDbContext.UserCode
                        DynamicReport.CreatedDate = Now

                        DynamicReport.UpdatedByUserCode = ReportingDbContext.UserCode
                        DynamicReport.UpdatedDate = Now

                        If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, DynamicReport) Then

                            DynamicReportColumnsList = Session("DRPT_ColumnsList")

                            For Each DynamicReportColumn In DynamicReportColumnsList

                                AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, DynamicReportColumn.FieldName,
                                                                                                  DynamicReportColumn.HeaderText, DynamicReportColumn.IsVisible, DynamicReportColumn.SortIndex,
                                                                                                  DynamicReportColumn.SortOrder, DynamicReportColumn.GroupIndex, DynamicReportColumn.Width,
                                                                                                  DynamicReportColumn.VisibleIndex, Nothing, Nothing)

                            Next

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReport.ID), True, True)

                        End If

                    End Using

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