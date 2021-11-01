Namespace Exporting.Presentation

    Public Class ExportInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ExportDataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing
        Private _GLACoresList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
        Private _PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ExportDataFilter() As AdvantageFramework.Exporting.Interfaces.IExportDataFilter
            Get
                ExportDataFilter = _ExportDataFilter
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Title As String, ByVal ExportDataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ExportDataFilter = ExportDataFilter
            Me.Text = Title

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Title As String, ByRef ExportDataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter) As Windows.Forms.DialogResult

            'objects
            Dim ExportInitialLoadingDialog As AdvantageFramework.Exporting.Presentation.ExportInitialLoadingDialog = Nothing

            ExportInitialLoadingDialog = New AdvantageFramework.Exporting.Presentation.ExportInitialLoadingDialog(Title, ExportDataFilter)

            ShowFormDialog = ExportInitialLoadingDialog.ShowDialog()

            ExportDataFilter = ExportInitialLoadingDialog.ExportDataFilter

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            PropertyGridForm_Item.OptionsBehavior.Editable = True
            PropertyGridForm_Item.SelectedObject = _ExportDataFilter

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf _ExportDataFilter Is AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail Then

                    _PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    _GLACoresList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session))

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If _ExportDataFilter.Validate(ErrorMessage) Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If
                
            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub PropertyGridForm_Item_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridForm_Item.CellValueChanged

            If TypeOf PropertyGridForm_Item.SelectedObject Is AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail Then

                If e.Row.Properties.FieldName = AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail.Properties.UseBaseAccountCodes.ToString Then

                    CType(PropertyGridForm_Item.SelectedObject, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail).FromAccount = Nothing
                    CType(PropertyGridForm_Item.SelectedObject, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail).ToAccount = Nothing

                End If

            End If

        End Sub
        Private Sub PropertyGridForm_Item_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridForm_Item.QueryPopupNeedDatasource

            'objects

            If TypeOf PropertyGridForm_Item.SelectedObject Is AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail Then

                If FieldName = AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail.Properties.FromPostPeriod.ToString OrElse _
                        FieldName = AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail.Properties.ToPostPeriod.ToString Then

                    Try

                        Datasource = _PostPeriods

                        OverrideDefaultDatasource = True

                    Catch ex As Exception
                        OverrideDefaultDatasource = False
                        Datasource = False
                    End Try

                ElseIf FieldName = AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail.Properties.FromAccount.ToString OrElse _
                        FieldName = AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail.Properties.ToAccount.ToString Then

                    Try

                        If CType(PropertyGridForm_Item.SelectedObject, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail).UseBaseAccountCodes Then

                            If CType(PropertyGridForm_Item.SelectedObject, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail).IncludeInactiveAccounts Then

                                Datasource = (From GLA In _GLACoresList _
                                              Select [Code] = GLA.BaseCode, _
                                                     [Description] = GLA.Description _
                                              Order By Code, Description _
                                              Distinct).ToList

                            Else

                                Datasource = (From GLA In _GLACoresList.Where(Function(Entity) Entity.Active = "A").ToList _
                                              Select [Code] = GLA.BaseCode, _
                                                     [Description] = GLA.Description _
                                              Order By Code, Description _
                                              Distinct).ToList

                            End If

                        Else

                            If CType(PropertyGridForm_Item.SelectedObject, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail).IncludeInactiveAccounts Then
                                
                                Datasource = _GLACoresList

                            Else

                                Datasource = _GLACoresList.Where(Function(Entity) Entity.Active = "A").ToList

                            End If

                        End If

                        OverrideDefaultDatasource = True

                    Catch ex As Exception
                        OverrideDefaultDatasource = False
                        Datasource = False
                    End Try

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
