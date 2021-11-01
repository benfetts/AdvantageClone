Namespace GeneralLedger.Maintenance.Presentation

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub SetSegmentVisibility(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal SegmentType As Nullable(Of Long), ByRef VisibleIndex As Integer)

            If SegmentType.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base Then

                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString).VisibleIndex = VisibleIndex
                VisibleIndex += 1
                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString).Visible = True

            ElseIf SegmentType.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString).VisibleIndex = VisibleIndex
                VisibleIndex += 1
                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString).Visible = True

            ElseIf SegmentType.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department Then

                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString).VisibleIndex = VisibleIndex
                VisibleIndex += 1
                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString).Visible = True

            ElseIf SegmentType.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other Then

                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString).VisibleIndex = VisibleIndex
                VisibleIndex += 1
                DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString).Visible = True

            End If

        End Sub
        Public Sub OrderColumnsBasedOnConfiguration(ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig, _
                                                    ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, _
                                                    Optional ByVal VisibleIndex As Integer = 0)

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString).Visible = False
            DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString).Visible = False
            DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString).Visible = False
            DataGridView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString).Visible = False

            If GeneralLedgerConfig.Segment1Format IsNot Nothing Then

                SetSegmentVisibility(DataGridView, GeneralLedgerConfig.Segment1Type, VisibleIndex)

            End If

            If GeneralLedgerConfig.Segment2Format IsNot Nothing Then

                SetSegmentVisibility(DataGridView, GeneralLedgerConfig.Segment2Type, VisibleIndex)

            End If

            If GeneralLedgerConfig.Segment3Format IsNot Nothing Then

                SetSegmentVisibility(DataGridView, GeneralLedgerConfig.Segment3Type, VisibleIndex)

            End If

            If GeneralLedgerConfig.Segment4Format IsNot Nothing Then

                SetSegmentVisibility(DataGridView, GeneralLedgerConfig.Segment4Type, VisibleIndex)

            End If

            For Each GridColumn In DataGridView.Columns

                If GridColumn.FieldName <> AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString AndAlso _
                        GridColumn.FieldName <> AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString AndAlso _
                        GridColumn.FieldName <> AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString AndAlso _
                        GridColumn.FieldName <> AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString Then

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = GridColumn.FieldName).SingleOrDefault

                        If PropertyDescriptor IsNot Nothing Then

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault

                            If EntityAttribute.ShowColumnInGrid Then

                                GridColumn.VisibleIndex = VisibleIndex
                                VisibleIndex += 1
                                GridColumn.Visible = True

                            Else

                                GridColumn.VisibleIndex = -1
                                GridColumn.Visible = False

                            End If

                        End If

                    Catch ex As Exception
                        GridColumn.VisibleIndex = -1
                        GridColumn.Visible = False
                    End Try

                End If

                'If GridColumn.Visible = False Then

                '    GridColumn.OptionsColumn.AllowShowHide = False
                '    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                '    GridColumn.OptionsColumn.ShowInExpressionEditor = False

                'End If

            Next

        End Sub
        Public Sub DataGridView_GeneralLedgerAccounts_CellValueChanged(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            If DataGridView.CurrentView.FocusedColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Type.ToString Then

                If e.Value <> AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseOperating Then

                    DirectCast(DataGridView.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).Payroll = 0

                End If

                If e.Value = GeneralLedger.ReportWriter.AccountTypes.CurrentAsset OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.NonCurrentAsset OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.FixedAsset OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.ExpenseCOS OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.ExpenseOperating OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.ExpenseOther OrElse _
                        e.Value = GeneralLedger.ReportWriter.AccountTypes.ExpenseTaxes Then

                    DirectCast(DataGridView.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).BalanceType = AdvantageFramework.GeneralLedger.BalanceTypes.Debit

                Else

                    DirectCast(DataGridView.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).BalanceType = AdvantageFramework.GeneralLedger.BalanceTypes.Credit

                End If

            End If

        End Sub
        Public Sub DataGridView_GeneralLedgerAccounts_QueryPopupNeedDatasourceEvent(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object, ByVal Session As AdvantageFramework.Security.Session)

            Dim CurrencyList As IEnumerable(Of String) = Nothing

            'If FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.CurrencyCode.ToString Then

            '    OverrideDefaultDatasource = True

            '    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '        CurrencyList = (From Entity In AdvantageFramework.Database.Procedures.Currency.LoadAllActive(DbContext)
            '                        Select Entity.CurrencyCode).ToList

            '        Datasource = (From Entity In AdvantageFramework.Database.Procedures.CurrencyCode.Load(DbContext)
            '                      Where CurrencyList.Contains(Entity.Code)
            '                      Select Entity).ToList

            '    End Using

            If FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadWithOfficeLimitsOrderByOffice(Session, DbContext)
                                  Select Entity).ToList

                End Using

            End If

        End Sub
        Public Sub DataGridView_GeneralLedgerAccounts_ShowingEditorEvent(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal sender As Object, ByRef e As ComponentModel.CancelEventArgs,
                                                                         Session As AdvantageFramework.Security.Session)

            'objects
            Dim GLACode As String = Nothing

            If DataGridView.CurrentView.FocusedColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Payroll.ToString Then

                If DataGridView.CurrentView.GetRowCellValue(DataGridView.CurrentView.FocusedRowHandle, AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Type.ToString) <> AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseOperating Then

                    e.Cancel = True

                    AdvantageFramework.WinForm.MessageBox.Show("You can only set an 'Expense-Operating' type account as a payroll account.")

                End If

                'ElseIf DataGridView.CurrentView.FocusedColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.CurrencyCode.ToString Then

                '    GLACode = DataGridView.CurrentView.GetRowCellValue(DataGridView.CurrentView.FocusedRowHandle, AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Code.ToString)

                '    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                '        If (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Load(DbContext)
                '            Where Entity.GLACode = GLACode
                '            Select Entity).Any Then

                '            e.Cancel = True

                '        End If

                '    End Using

            End If

        End Sub

#End Region

    End Module

End Namespace

