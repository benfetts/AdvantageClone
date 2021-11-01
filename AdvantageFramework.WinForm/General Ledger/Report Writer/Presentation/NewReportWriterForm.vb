Namespace GeneralLedger.ReportWriter.Presentation

    Public Class NewReportWriterForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GeneralLedgerReportList As Generic.List(Of AdvantageFramework.Database.Views.GeneralLedgerReport) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim NewReportWriterForm As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.NewReportWriterForm = Nothing

            NewReportWriterForm = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.NewReportWriterForm()

            NewReportWriterForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub NewReportWriterForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ButtonItemActions_View.Image = My.Resources.ReportImage

            DateTimePickerReportDate_ReportDate.ReadOnly = True
            DateTimePickerReportDate_ReportDate.ReadOnly = False

            ComboBoxPostPeriod_PostPeriod.SetRequired(True)
            TextBoxReportName_ReportName.SetRequired(True)

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxPostPeriod_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(ObjectContext).Where(Function(Entity) Entity.Month < 13).OrderByDescending(Function(Entity) Entity.Code)

            End Using

            PivotGridForm_GLReport.OptionsData.AllowCrossGroupVariation = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemReportTypes_BalanceSheet_Click(sender As Object, e As EventArgs) Handles ButtonItemReportTypes_BalanceSheet.Click

            ButtonItemActions_View.RaiseClick()

        End Sub
        Private Sub ButtonItemReportTypes_Income_Click(sender As Object, e As EventArgs) Handles ButtonItemReportTypes_Income.Click

            ButtonItemActions_View.RaiseClick()

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ReportType As Integer = 1

            If Me.Validator Then

                Me.ShowWaitForm()

                Try

                    Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(ObjectContext, ComboBoxPostPeriod_PostPeriod.SelectedValue)

                        If PostPeriod IsNot Nothing Then

                            If ButtonItemReportTypes_Income.Checked Then

                                ReportType = 1

                            Else

                                ReportType = 2

                            End If

                            PivotGridForm_GLReport.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerReportView.Load(ObjectContext).Where(Function(Entity) Entity.Month < 13 AndAlso (Entity.Year < PostPeriod.Year OrElse (Entity.Year = PostPeriod.Year AndAlso Entity.Month <= PostPeriod.Month)) AndAlso Entity.ReportType = ReportType).ToList

                            For Each PivotGridField In PivotGridForm_GLReport.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).ToList

                                If PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.ID.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.GLACode.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.GLADescription.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.GeneralLedgerAccount.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.ReportType.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Type.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.TypeOrder.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Category.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.CategoryOrder.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.PostPeriodCode.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                                    PivotGridField.RunningTotal = True

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Year.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                                    PivotGridField.RunningTotal = True

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Month.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                                    PivotGridField.RunningTotal = True

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.MonthName.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                                    PivotGridField.RunningTotal = True

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.DepartmentTeamCode.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.DepartmentTeamDescription.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.DepartmentTeam.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.OfficeCode.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.OfficeName.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Office.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Credit.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Debit.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Total.ToString Then

                                    PivotGridField.Visible = True
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
                                    PivotGridField.RunningTotal = True

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Quantity.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Budget1.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Budget2.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Budget3.ToString Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                ElseIf PivotGridField.FieldName = "EntityKey" OrElse PivotGridField.FieldName = "EntityState" Then

                                    PivotGridField.Visible = False
                                    PivotGridField.Options.AllowDragInCustomizationForm = False
                                    PivotGridField.Options.ShowInCustomizationForm = False
                                    PivotGridField.Options.ShowInPrefilter = False
                                    PivotGridField.Options.ShowUnboundExpressionMenu = False
                                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea

                                End If

                            Next

                            For Each PivotGridField In PivotGridForm_GLReport.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).ToList

                                If PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.GeneralLedgerAccount.ToString Then

                                    PivotGridField.AreaIndex = 4

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Type.ToString Then

                                    PivotGridField.AreaIndex = 3

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.TypeOrder.ToString Then

                                    PivotGridField.AreaIndex = 2

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Category.ToString Then

                                    PivotGridField.AreaIndex = 1

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.CategoryOrder.ToString Then

                                    PivotGridField.AreaIndex = 0

                                    PivotGridField.CollapseAll()

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.PostPeriodCode.ToString Then

                                    PivotGridField.AreaIndex = 3

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Year.ToString Then

                                    PivotGridField.AreaIndex = 0

                                    PivotGridField.CollapseAll()

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Month.ToString Then

                                    PivotGridField.AreaIndex = 1

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.MonthName.ToString Then

                                    PivotGridField.AreaIndex = 2

                                ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Views.GeneralLedgerReport.Properties.Total.ToString Then

                                    PivotGridField.AreaIndex = 0

                                End If

                            Next

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If
            
        End Sub
        'Private Sub PivotGridForm_GLReport_CustomFieldValueCells(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomFieldValueCellsEventArgs) Handles PivotGridForm_GLReport.CustomFieldValueCells

        '    'objects
        '    Dim FieldValueCell As DevExpress.XtraPivotGrid.FieldValueCell = Nothing

        '    ' Iterates through all row headers.
        '    For i As Integer = e.GetCellCount(False) - 1 To 0 Step -1

        '        FieldValueCell = e.GetCell(False, i)

        '        If FieldValueCell IsNot Nothing Then

        '            ' If the current header corresponds to the "Employee B"
        '            ' field value, and is not the Total Row header,
        '            ' it is removed with all corresponding rows.
        '            If Object.Equals(FieldValueCell.Value, "Fixed Asset") Then

        '                e.Remove(FieldValueCell)

        '            End If

        '        End If

        '    Next i

        'End Sub

#End Region

#End Region

    End Class

End Namespace