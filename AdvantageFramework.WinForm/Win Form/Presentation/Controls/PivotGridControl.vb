Namespace WinForm.Presentation.Controls

    Public Class PivotGridControl
        Inherits DevExpress.XtraPivotGrid.PivotGridControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserEntryChanged As Boolean = False
        Protected _ObjectType As System.Type = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _WriteEditValueToAllDataSourceItems As Boolean = False
        Protected _RetrieveFieldsOnLoadDataSource As Boolean = True

#End Region

#Region " Properties "

        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.DataSource
            End Get
            Set(ByVal value As Object)
                LoadDataSource(value)
            End Set
        End Property
        Public Property WriteEditValueToAllDataSourceItems() As Boolean
            Get
                WriteEditValueToAllDataSourceItems = _WriteEditValueToAllDataSourceItems
            End Get
            Set(ByVal value As Boolean)
                _WriteEditValueToAllDataSourceItems = value
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property RetrieveFieldsOnLoadDataSource() As Boolean
            Get
                RetrieveFieldsOnLoadDataSource = _RetrieveFieldsOnLoadDataSource
            End Get
            Set(ByVal value As Boolean)
                _RetrieveFieldsOnLoadDataSource = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            If TypeOf Value Is IEnumerable Then

                _ObjectType = DirectCast(Value, IEnumerable).AsQueryable.ElementType

            End If

            MyBase.DataSource = Value

            If Me.RetrieveFieldsOnLoadDataSource Then

                Me.RetrieveFields()

            End If

            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.AlertGroupCategory) Then

                For Each PivotGridField In Me.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).ToList

                    If PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.AlertCategory.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                        PivotGridField.AreaIndex = 0
                        PivotGridField.SortBySummaryInfo.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.GroupLevelSecurity.ToString

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.AlertGroup.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                        PivotGridField.AreaIndex = 0

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.IsActive.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                        PivotGridField.AreaIndex = 0
                        PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max

                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemCheckBox(_Session, Me, PivotGridField, False, CheckBoxValueType.Boolean)

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.GroupLevelSecurity.ToString Then

                        PivotGridField.Visible = False

                    End If

                Next

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.AlertCategorySetting) Then

                For Each PivotGridField In Me.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).ToList

                    If PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertCategorySetting.Properties.AlertCategory.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                        PivotGridField.AreaIndex = 0
                        PivotGridField.SortBySummaryInfo.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.GroupLevelSecurity.ToString

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertCategorySetting.Properties.EventSetting.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                        PivotGridField.AreaIndex = 0

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertCategorySetting.Properties.IsActive.ToString Then

                        PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                        PivotGridField.AreaIndex = 0
                        PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max

                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemCheckBox(_Session, Me, PivotGridField, False, AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Boolean)

                    ElseIf PivotGridField.FieldName = AdvantageFramework.Database.Classes.AlertGroupCategory.Properties.GroupLevelSecurity.ToString Then

                        PivotGridField.Visible = False

                    End If

                Next

            End If

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean

            'If keyData = System.Windows.Forms.Keys.Tab Then

            '	If Me.ActiveEditor IsNot Nothing AndAlso Me.IsAsyncInProgress = False Then

            '		Me.ActiveEditor.SendKey(New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter))

            '		ProcessDialogKey = False

            '	Else

            '		ProcessDialogKey = MyBase.ProcessDialogKey(keyData)

            '	End If

            'Else

            '	ProcessDialogKey = MyBase.ProcessDialogKey(keyData)

            'End If
            Dim key As System.Windows.Forms.Keys = keyData And (Not System.Windows.Forms.Keys.Modifiers)

            If key = System.Windows.Forms.Keys.Tab Then

                Return False

            End If

            Return MyBase.ProcessDialogKey(keyData)

        End Function
        Public Sub PrintPivotGrid(ByVal LookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, ByVal DocumentDescription As String, Optional ByVal Images() As System.Drawing.Image = Nothing)

            'objects
            Dim ComponentResourceManager As System.ComponentModel.ComponentResourceManager = Nothing
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageFramework.Desktop.Presentation.DynamicReportEditForm))

            PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                            PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), DocumentDescription))

                            'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

            End If

            If KeepLoading Then

                PrintingSystem.Links.AddRange(New Object() {PrintableComponentLink})

                PrintableComponentLink.ImageCollection.ImageStream = CType(ComponentResourceManager.GetObject("PrintableComponentLink.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
                PrintableComponentLink.PrintingSystem = PrintingSystem

                If Images IsNot Nothing Then

                    For Each Image In Images

                        PrintableComponentLink.Images.Add(Image)

                    Next

                End If

                PrintableComponentLink.Component = Me
                PrintableComponentLink.Landscape = True

                PrintableComponentLink.CreateDocument()

                PrintableComponentLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                PrintableComponentLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                PrintableComponentLink.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription

                PrintableComponentLink.ShowRibbonPreviewDialog(LookAndFeel)

            End If

        End Sub
        Public Sub SetUserEntryChanged()

            _UserEntryChanged = True

            AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

        End Sub
        Public Sub RaiseFieldAreaIndexChangedEvent(PivotGridField As DevExpress.XtraPivotGrid.PivotGridField)

            Me.RaiseFieldAreaIndexChanged(PivotGridField)

        End Sub
        Protected Overrides Function CreateData() As DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData
            Return New MyPivotGridViewInfoData(Me)
        End Function

#Region "  Control Event Handlers "

        Private Sub PivotGridControl_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.EditValueChangedEventArgs) Handles Me.EditValueChanged

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            If _WriteEditValueToAllDataSourceItems Then

                Try

                    PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    For RowIndex As Integer = 0 To PivotDrillDownDataSource.RowCount - 1

                        PivotDrillDownDataSource(RowIndex)(e.DataField) = e.Editor.EditValue

                    Next

                Catch ex As Exception

                End Try

            End If

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

    Public Class MyPivotGridViewInfo
        Inherits DevExpress.XtraPivotGrid.ViewInfo.PivotGridViewInfo

        Public Sub New(ByVal data As DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData)
            MyBase.New(data)
        End Sub

        Private Sub ProcessTabKey(ByVal shift As Boolean)
            Dim newFocusedCell As System.Drawing.Point = VisualItems.FocusedCell
            If shift Then
                If newFocusedCell.X = 0 AndAlso newFocusedCell.Y > 0 Then
                    newFocusedCell.X = CellsArea.ColumnCount - 1
                    newFocusedCell.Y -= 1
                ElseIf newFocusedCell.X > 0 Then
                    newFocusedCell.X -= 1
                End If
            Else
                If newFocusedCell.X = CellsArea.ColumnCount - 1 AndAlso newFocusedCell.Y < CellsArea.RowCount - 1 Then
                    newFocusedCell.X = 0
                    newFocusedCell.Y += 1
                ElseIf newFocusedCell.X < CellsArea.ColumnCount - 1 Then
                    newFocusedCell.X += 1
                End If
            End If
            VisualItems.StartSelection(True)
            VisualItems.FocusedCell = newFocusedCell
        End Sub

        Public Overrides Sub KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Tab Then
                ProcessTabKey(e.Shift)
            Else
                MyBase.KeyDown(e)
            End If
        End Sub
    End Class

    Public Class MyPivotGridViewInfoData
        Inherits DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData

        Public Sub New()

            MyBase.New()

        End Sub
        Public Sub New(ByVal control As DevExpress.XtraPivotGrid.ViewInfo.IViewInfoControl)

            MyBase.New(control)

        End Sub

        Protected Overrides Function CreateViewInfo() As DevExpress.XtraPivotGrid.ViewInfo.PivotGridViewInfo

            Return New MyPivotGridViewInfo(Me)

        End Function
    End Class

End Namespace
