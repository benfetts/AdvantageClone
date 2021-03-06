Public Class Reporting_SaveDynamicJobVersionReportTemplate
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

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    'For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Reporting.DynamicReports)).OrderBy(Function(KeyValue) KeyValue.Value)

                    '    RadComboBoxReportTemplate.Items.Add(New Telerik.Web.UI.RadComboBoxItem(KeyValuePair.Value, KeyValuePair.Key))

                    'Next
                    Me.RadComboBoxReportTemplate.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadAllActive(DbContext).ToList
                    Me.RadComboBoxReportTemplate.DataTextField = "Description"
                    Me.RadComboBoxReportTemplate.DataValueField = "Code"
                    Me.RadComboBoxReportTemplate.DataBind()

                    RadComboBoxReportTemplate.SelectedIndex = 0

                    PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Description)

                    If PropertyDescriptor IsNot Nothing Then

                        TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                    End If

                    RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList.OrderBy(Function(UserDefinedReportCategory) UserDefinedReportCategory.Description).ToList
                    RadComboBoxReportCategory.DataBind()
                    RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    RadComboBoxReportTemplate.Visible = True
                    TextBoxDescription.Visible = True
                    RadComboBoxReportCategory.Visible = True
                    RadComboBoxReportTemplate.SelectedValue = Session("DynamicReportTemplateCode")
                    TextBoxDescription.Text = Session("DRPT_Description")
                    RadComboBoxReportCategory.SelectedValue = Session("DRPT_UDRCategory")
                    LabelReportType.Visible = True
                    LabelDescription.Visible = True
                    LabelReportCategory.Visible = True

                    RadComboBoxReportTemplate.Enabled = False

                End Using

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                If TextBoxDescription.Text <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

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

                            DynamicReport.DbContext = DbContext
                            DynamicReport.Description = TextBoxDescription.Text
                            DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                            DynamicReport.AllowCellMerge = False
                            DynamicReport.AutoSizeColumnsWhenPrinting = False
                            DynamicReport.PrintHeader = False
                            DynamicReport.PrintFooter = False
                            DynamicReport.PrintGroupFooter = False
                            DynamicReport.PrintSelectedRowsOnly = False
                            DynamicReport.PrintFilterInformation = False

                            DynamicReport.CreatedByUserCode = DbContext.UserCode
                            DynamicReport.CreatedDate = Now

                            DynamicReport.UpdatedByUserCode = DbContext.UserCode
                            DynamicReport.UpdatedDate = Now

                            DynamicReport.TemplateCode = Session("DynamicReportTemplateCode")

                            If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, DynamicReport) Then

                                DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
                                For Each DynamicReportColumn In DynamicReportColumnsList

                                    JobTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCodeAndFieldName(DbContext, DynamicReport.TemplateCode, DynamicReportColumn.FieldName)

                                    If JobTemplateDetail Is Nothing Then
                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, DynamicReportColumn.FieldName,
                                                                                                                    DynamicReportColumn.HeaderText, DynamicReportColumn.IsVisible, DynamicReportColumn.SortIndex,
                                                                                                                    DynamicReportColumn.SortOrder, DynamicReportColumn.GroupIndex, DynamicReportColumn.Width,
                                                                                                                    DynamicReportColumn.VisibleIndex, Nothing, Nothing)
                                    Else
                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, DynamicReportColumn.FieldName,
                                                                                                                    DynamicReportColumn.HeaderText, DynamicReportColumn.IsVisible, DynamicReportColumn.SortIndex,
                                                                                                                    DynamicReportColumn.SortOrder, DynamicReportColumn.GroupIndex, DynamicReportColumn.Width,
                                                                                                                    DynamicReportColumn.VisibleIndex, JobTemplateDetail.ID, Nothing)
                                    End If
                                Next

                                Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobVersion.aspx?From=reportJV&DynamicReportTemplateID={0}", DynamicReport.ID), True, True)

                            End If

                        End Using

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
