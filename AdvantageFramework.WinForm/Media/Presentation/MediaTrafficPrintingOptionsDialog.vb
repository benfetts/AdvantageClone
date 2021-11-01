Namespace Media.Presentation

    Public Class MediaTrafficPrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficPrintSettingViewModel = Nothing
        Private _MediaType As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaType As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaType = MediaType

        End Sub
        Private Sub LoadViewModel()

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            rowLocationID.Visible = False

            If _MediaType = "R" OrElse _MediaType = "T" Then

                rowLocationID.Visible = True
                rowIncludeGuidelines.Visible = True

            End If

            If _ViewModel.PrintSettings IsNot Nothing AndAlso _ViewModel.PrintSettings.Count > 0 Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.Media.Traffic.PrintSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                    EntityAttribute = Nothing
                    Row = Nothing

                    Row = GetRowAndInitialize(VerticalGridMediaTraffic_Settings, PropertyDescriptor, EntityAttribute)

                    If Row IsNot Nothing Then

                        If Row.Properties.FieldName = AdvantageFramework.DTO.Media.Traffic.PrintSetting.Properties.LocationID.ToString Then

                            RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                         AdvantageFramework.DTO.Media.Traffic.PrintSetting.Properties.LocationID,
                                                                         EntityAttribute, PropertyDescriptor,
                                                                         Nothing, True)

                        Else

                            RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.DTO.Media.Traffic.PrintSetting))

                        End If

                        If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                            CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                        End If

                        VerticalGridMediaTraffic_Settings.RepositoryItems.Add(RepositoryItem)

                        Row.Properties.RowEdit = RepositoryItem

                    End If

                Next

            End If

            VerticalGridMediaTraffic_Settings.DataSource = _ViewModel.PrintSettings

            VerticalGridMediaTraffic_Settings.ExpandAllRows()

            'VerticalGridMediaRFP_Settings.BestFit()

        End Sub
        Private Function CreateSubItemGridLookupEdit(SubItemGridLookUpEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type,
                                                     PrintSettingProperty As AdvantageFramework.DTO.Media.Traffic.PrintSetting.Properties,
                                                     EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                     PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                     EnumType As System.Type, AllowExtraComboItems As Boolean) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, SubItemGridLookUpEditControlType, PrintSettingProperty.ToString, EntityAttribute, PropertyDescriptor, EnumType, AllowExtraComboItems)

            If RepositoryItem IsNot Nothing Then

                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

            End If

            CreateSubItemGridLookupEdit = RepositoryItem

        End Function
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
        Private Sub GetVerticalGridErrorMessage(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal ParentRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef ErrorMessage As String)

            'objects
            Dim RowErrorMessage As String = ""

            For Each Row In ParentRow.ChildRows

                RowErrorMessage = ""

                If String.IsNullOrEmpty(RowErrorMessage) = False Then

                    If ErrorMessage = "" Then

                        ErrorMessage = VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    Else

                        ErrorMessage &= vbNewLine & VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    End If

                End If

            Next

        End Sub
        Private Sub GetVerticalGridErrorMessage(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByRef ErrorMessage As String)

            'objects
            Dim RowErrorMessage As String = ""

            For Each Row In VerticalGrid.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                If String.IsNullOrEmpty(RowErrorMessage) = False Then

                    If ErrorMessage = "" Then

                        ErrorMessage = VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    Else

                        ErrorMessage &= vbNewLine & VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    End If

                End If

            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaType As String) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficPrintingOptionsDialog As AdvantageFramework.Media.Presentation.MediaTrafficPrintingOptionsDialog = Nothing

            MediaTrafficPrintingOptionsDialog = New AdvantageFramework.Media.Presentation.MediaTrafficPrintingOptionsDialog(MediaType)

            ShowFormDialog = MediaTrafficPrintingOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficPrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

            _ViewModel = _Controller.PrintSettings_Load(_MediaType)

            LabelForm_Format.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Media.MediaTypes), _MediaType)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaTrafficPrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaTrafficPrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            VerticalGridMediaTraffic_Settings.CloseEditor()

            If VerticalGridMediaTraffic_Settings.HasRowErrors = False Then

                _Controller.PrintSettings_Save(_ViewModel)

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                GetVerticalGridErrorMessage(VerticalGridMediaTraffic_Settings, ErrorMessage)

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace