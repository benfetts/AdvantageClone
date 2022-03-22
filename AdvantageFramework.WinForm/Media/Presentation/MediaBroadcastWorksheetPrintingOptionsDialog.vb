Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetPrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions
            Get
                WorksheetPrintOptions = _WorksheetPrintOptions
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _WorksheetPrintOptions = WorksheetPrintOptions

        End Sub
        Private Sub LoadProductionTab()

            'objects
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim WorksheetPrintOptionsList As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions) = Nothing

            Try

                If _WorksheetPrintOptions IsNot Nothing Then

                    WorksheetPrintOptionsList = New List(Of DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)

                    WorksheetPrintOptionsList.Add(_WorksheetPrintOptions)

                    For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                        EntityAttribute = Nothing
                        Row = Nothing

                        Row = GetRowAndInitialize(VerticalGridProduction_Settings, PropertyDescriptor, EntityAttribute)

                        If Row IsNot Nothing Then

                            RepositoryItem = Nothing

                            If Row.Properties.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions.Properties.LocationCode.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                                                                          AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions.Properties.LocationCode.ToString, EntityAttribute, PropertyDescriptor, Nothing, True)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = _WorksheetPrintOptions.PrintLocation

                                End If

                            End If

                            If RepositoryItem IsNot Nothing Then

                                VerticalGridProduction_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        End If

                    Next

                    VerticalGridProduction_Settings.DataSource = WorksheetPrintOptionsList

                    VerticalGridProduction_Settings.ExpandAllRows()

                    VerticalGridProduction_Settings.BestFit()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Function GetRowAndInitialize(VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As DevExpress.XtraVerticalGrid.Rows.BaseRow

            'objects
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                Row = VerticalGrid.Rows.GetRowByFieldName(PropertyDescriptor.Name, True)

            Catch ex As Exception
                Row = Nothing
            End Try

            If Row IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                End Try

                If EntityAttribute IsNot Nothing Then

                    If EntityAttribute.DisplayFormat <> "" Then

                        If EntityAttribute.DisplayFormat.StartsWith("c") OrElse EntityAttribute.DisplayFormat.StartsWith("n") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric

                        ElseIf EntityAttribute.DisplayFormat.StartsWith("d") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime

                        End If

                        Row.Properties.Format.FormatString = EntityAttribute.DisplayFormat

                    End If

                End If

                Row.OptionsRow.AllowMove = False
                Row.OptionsRow.AllowMoveToCustomizationForm = False
                Row.OptionsRow.ShowInCustomizationForm = False

            End If

            GetRowAndInitialize = Row

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef WorksheetPrintOptions As DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetPrintingOptionsDialog As MediaBroadcastWorksheetPrintingOptionsDialog = Nothing

            MediaBroadcastWorksheetPrintingOptionsDialog = New MediaBroadcastWorksheetPrintingOptionsDialog(WorksheetPrintOptions)

            ShowFormDialog = MediaBroadcastWorksheetPrintingOptionsDialog.ShowDialog()

            WorksheetPrintOptions = MediaBroadcastWorksheetPrintingOptionsDialog.WorksheetPrintOptions

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetPrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            VerticalGridProduction_Settings.OptionsBehavior.Editable = True
            VerticalGridProduction_Settings.OptionsView.ShowRootCategories = True
            VerticalGridProduction_Settings.OptionsBehavior.UseDefaultEditorsCollection = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadProductionTab()

            Catch ex As Exception

            End Try

            VerticalGridProduction_Settings.RowHeaderWidth = VerticalGridProduction_Settings.RowHeaderWidth + 10

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaBroadcastWorksheetPrintingOptionsDialog_ClearChangedEvent() Handles MyBase.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaBroadcastWorksheetPrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles MyBase.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim RowErrorMessage As String = ""

            VerticalGridProduction_Settings.CloseEditor()

            If VerticalGridProduction_Settings.HasRowErrors = False Then

                Try

                    _WorksheetPrintOptions = VerticalGridProduction_Settings.GetRecordObject(0)

                Catch ex As Exception

                End Try

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each Row In VerticalGridProduction_Settings.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                    RowErrorMessage = VerticalGridProduction_Settings.GetRowError(Row.Properties)

                    If String.IsNullOrEmpty(RowErrorMessage) = False Then

                        If ErrorMessage = "" Then

                            ErrorMessage = RowErrorMessage

                        Else

                            ErrorMessage &= vbNewLine & RowErrorMessage

                        End If

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub VerticalGridProduction_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridProduction_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            _UserEntryChanged = True

            Me.RaiseUserEntryChangedEvent(Nothing)

            If e.Row.Properties.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions.Properties.PrintLocation.ToString Then

                BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions.Properties.LocationCode.ToString, True)

                If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                    If e.Value = True Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                    Else

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
