Namespace Maintenance.Client.Presentation

    Public Class ClientMediaPercentagesSetupForm

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum PercentageType
            RadioRebate
            TVRebate
            MagazineRebate
            NewspaperRebate
            OutdoorRebate
            InternetRebate
            RadioMarkup
            TVMarkup
            MagazineMarkup
            NewspaperMarkup
            OutdoorMarkup
            InternetMarkup
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BandedDataGridViewLeftSection_CDPRates.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)(String.Format("exec advsp_maintenance_media_percentages '{0}'", DbContext.UserCode)).ToList

                BandedDataGridViewLeftSection_CDPRates.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim ClientMediaPercentage As AdvantageFramework.Database.Classes.ClientMediaPercentage = Nothing

            ProductMediaOverrideControlRightSection_Overrides.ClearControl()

            If BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow Then

                ClientMediaPercentage = BandedDataGridViewLeftSection_CDPRates.GetRowDataBoundItem(BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedRowHandle)

                ProductMediaOverrideControlRightSection_Overrides.LoadControl(ClientMediaPercentage.ClientCode, ClientMediaPercentage.DivisionCode, ClientMediaPercentage.ProductCode)

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged OrElse ProductMediaOverrideControlRightSection_Overrides.CheckUserEntryChangedSetting
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged OrElse ProductMediaOverrideControlRightSection_Overrides.CheckUserEntryChangedSetting

            ButtonItemProductPercentages_Copy.Enabled = BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow AndAlso Not Me.UserEntryChanged

            ButtonItemSalesClassOverrides_Copy.Enabled = BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow AndAlso Not Me.UserEntryChanged AndAlso ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.HasRows
            ButtonItemSalesClassOverrides_Add.Enabled = BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow

            ProductMediaOverrideControlRightSection_Overrides.Enabled = BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow

            If ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.IsNewItemRow Then

                ButtonItemSalesClassOverrides_Cancel.Enabled = True
                ButtonItemSalesClassOverrides_Delete.Enabled = False

            Else

                ButtonItemSalesClassOverrides_Cancel.Enabled = False
                ButtonItemSalesClassOverrides_Delete.Enabled = ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.HasASelectedRow

            End If

        End Sub
        Private Sub LoadGridBands()

            'objects
            Dim CDPGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim InternetGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim MagazineGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim NewspaperGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim OutdoorGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim RadioGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim TvGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            CDPGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CDPGridBand.Caption = "Client / Division / Product"
            CDPGridBand.Name = "CDP"
            CDPGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            CDPGridBand.AppearanceHeader.Options.UseTextOptions = True

            InternetGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            InternetGridBand.Caption = "Internet"
            InternetGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            InternetGridBand.AppearanceHeader.Options.UseTextOptions = True

            MagazineGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            MagazineGridBand.Caption = "Magazine"
            MagazineGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            MagazineGridBand.AppearanceHeader.Options.UseTextOptions = True

            NewspaperGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            NewspaperGridBand.Caption = "Newspaper"
            NewspaperGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            NewspaperGridBand.AppearanceHeader.Options.UseTextOptions = True

            OutdoorGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            OutdoorGridBand.Caption = "Out of Home"
            OutdoorGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            OutdoorGridBand.AppearanceHeader.Options.UseTextOptions = True

            RadioGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            RadioGridBand.Caption = "Radio"
            RadioGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            RadioGridBand.AppearanceHeader.Options.UseTextOptions = True

            TvGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            TvGridBand.Caption = "Television"
            TvGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            TvGridBand.AppearanceHeader.Options.UseTextOptions = True

            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(CDPGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(InternetGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(MagazineGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(NewspaperGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(OutdoorGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(RadioGridBand)
            BandedDataGridViewLeftSection_CDPRates.CurrentView.Bands.Add(TvGridBand)

            For Each GridColumn In BandedDataGridViewLeftSection_CDPRates.Columns

                If GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductDescription.ToString Then

                    CDPGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.InternetMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.InternetRebate.ToString Then

                    InternetGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.MagazineMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.MagazineRebate.ToString Then

                    MagazineGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.NewspaperMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.NewspaperRebate.ToString Then

                    NewspaperGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.OutdoorMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.OutdoorRebate.ToString Then

                    OutdoorGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.RadioMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.RadioRebate.ToString Then

                    RadioGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.TVMarkup.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.TVRebate.ToString Then

                    TvGridBand.Columns.Add(GridColumn)

                Else

                    GridColumn.Visible = False

                End If

            Next

            BandedDataGridViewLeftSection_CDPRates.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If ProductMediaOverrideControlRightSection_Overrides.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim ErrorMessage As String = ""
            Dim ClientMediaPercentages As Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If BandedDataGridViewLeftSection_CDPRates.HasRows Then

                BandedDataGridViewLeftSection_CDPRates.CurrentView.CloseEditorForUpdating()

                ClientMediaPercentages = BandedDataGridViewLeftSection_CDPRates.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)().ToList

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each ClientMediaPercentage In ClientMediaPercentages

                        Product = DbContext.Products.Find(ClientMediaPercentage.ClientCode, ClientMediaPercentage.DivisionCode, ClientMediaPercentage.ProductCode)

                        If Product IsNot Nothing Then

                            Product.InternetMarkup = ClientMediaPercentage.InternetMarkup
                            Product.InternetRebate = ClientMediaPercentage.InternetRebate
                            Product.MagazineMarkup = ClientMediaPercentage.MagazineMarkup
                            Product.MagazineRebate = ClientMediaPercentage.MagazineRebate
                            Product.NewspaperMarkup = ClientMediaPercentage.NewspaperMarkup
                            Product.NewspaperRebate = ClientMediaPercentage.NewspaperRebate
                            Product.OutOfHomeMarkup = ClientMediaPercentage.OutdoorMarkup
                            Product.OutOfHomeRebate = ClientMediaPercentage.OutdoorRebate
                            Product.RadioMarkup = ClientMediaPercentage.RadioMarkup
                            Product.RadioRebate = ClientMediaPercentage.RadioRebate
                            Product.TelevisionMarkup = ClientMediaPercentage.TVMarkup
                            Product.TelevisionRebate = ClientMediaPercentage.TVRebate

                        End If

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception
                        Saved = False
                    End Try

                End Using

                If BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow AndAlso Saved Then

                    Saved = ProductMediaOverrideControlRightSection_Overrides.Save()

                End If

                If Saved Then

                    Me.ClearChanged()

                    LoadGrid()

                    ToggleColumnVisibility()

                End If

            End If

            Save = Saved

        End Function
        Private Sub UpdatePercentageValue(PctType As PercentageType, ClientMediaPercentage As AdvantageFramework.Database.Classes.ClientMediaPercentage, Value As Decimal)

            Select Case PctType

                Case PercentageType.InternetMarkup

                    ClientMediaPercentage.InternetMarkup = Value

                Case PercentageType.InternetRebate

                    ClientMediaPercentage.InternetRebate = Value

                Case PercentageType.MagazineMarkup

                    ClientMediaPercentage.MagazineMarkup = Value

                Case PercentageType.MagazineRebate

                    ClientMediaPercentage.MagazineRebate = Value

                Case PercentageType.NewspaperMarkup

                    ClientMediaPercentage.NewspaperMarkup = Value

                Case PercentageType.NewspaperRebate

                    ClientMediaPercentage.NewspaperRebate = Value

                Case PercentageType.OutdoorMarkup

                    ClientMediaPercentage.OutdoorMarkup = Value

                Case PercentageType.OutdoorRebate

                    ClientMediaPercentage.OutdoorRebate = Value

                Case PercentageType.RadioMarkup

                    ClientMediaPercentage.RadioMarkup = Value

                Case PercentageType.RadioRebate

                    ClientMediaPercentage.RadioRebate = Value

                Case PercentageType.TVMarkup

                    ClientMediaPercentage.TVMarkup = Value

                Case PercentageType.TVRebate

                    ClientMediaPercentage.TVRebate = Value

            End Select

        End Sub
        Private Sub UpdatePercentage(PctType As PercentageType)

            'objects
            Dim NewPercent As Decimal = Nothing
            Dim ClientMediaPercentage As AdvantageFramework.Database.Classes.ClientMediaPercentage = Nothing

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Percent", "Enter new percentage:", 0, NewPercent, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Decimal, IsRequired:=True, DisplayFormat:="n3", MaxLength:=9, MaxValue:=9999.999, MinValue:=-9999.999) = Windows.Forms.DialogResult.OK Then

                BandedDataGridViewLeftSection_CDPRates.CurrentView.CloseEditorForUpdating()

                For Each RowHandlesAndDataBoundItem In BandedDataGridViewLeftSection_CDPRates.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        ClientMediaPercentage = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        ClientMediaPercentage = Nothing
                    End Try

                    If ClientMediaPercentage IsNot Nothing Then

                        UpdatePercentageValue(PctType, ClientMediaPercentage, NewPercent)

                        BandedDataGridViewLeftSection_CDPRates.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                        BandedDataGridViewLeftSection_CDPRates.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                Next

                BandedDataGridViewLeftSection_CDPRates.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub HideOrShowColumn(FieldName As String, Visible As Boolean, ByRef VisibleIndex As Integer)

            If BandedDataGridViewLeftSection_CDPRates.CurrentView.Columns(FieldName) IsNot Nothing Then

                BandedDataGridViewLeftSection_CDPRates.CurrentView.Columns(FieldName).Visible = Visible

                If BandedDataGridViewLeftSection_CDPRates.CurrentView.Columns(FieldName).Visible Then

                    BandedDataGridViewLeftSection_CDPRates.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Sub ToggleColumnVisibility()

            Dim ColumnVisibleIndex As Integer = Nothing

            If Me.FormShown Then

                ColumnVisibleIndex = 1

                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientCode.ToString, True, ColumnVisibleIndex)
                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientName.ToString, ButtonItemActions_ShowDescriptions.Checked, ColumnVisibleIndex)
                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionCode.ToString, True, ColumnVisibleIndex)
                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionName.ToString, ButtonItemActions_ShowDescriptions.Checked, ColumnVisibleIndex)
                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductCode.ToString, True, ColumnVisibleIndex)
                HideOrShowColumn(AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductDescription.ToString, ButtonItemActions_ShowDescriptions.Checked, ColumnVisibleIndex)

            End If

        End Sub
        Private Sub AddSalesClassOverrides(MediaType As String)

            Dim ClientMediaPercentage As AdvantageFramework.Database.Classes.ClientMediaPercentage = Nothing
            Dim SalesClassList As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim ExistingProductMediaOverrides As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            ClientMediaPercentage = BandedDataGridViewLeftSection_CDPRates.GetRowDataBoundItem(BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedRowHandle)

            If ClientMediaPercentage IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If MediaType = "ALL" Then

                        SalesClassList = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).Where(Function(SC) SC.SalesClassTypeCode IsNot Nothing AndAlso SC.SalesClassTypeCode <> "P").ToList

                    Else

                        SalesClassList = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).Where(Function(SC) SC.SalesClassTypeCode = MediaType).ToList

                    End If

                End Using

                ExistingProductMediaOverrides = ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductMediaOverrides).ToList

                For Each SalesClass In SalesClassList

                    If Not ExistingProductMediaOverrides.Where(Function(PMO) PMO.MediaType = SalesClass.SalesClassTypeCode AndAlso PMO.SalesClassCode = SalesClass.Code).Any Then

                        ProductMediaOverrides = New AdvantageFramework.Database.Entities.ProductMediaOverrides

                        ProductMediaOverrides.ClientCode = ClientMediaPercentage.ClientCode
                        ProductMediaOverrides.DivisionCode = ClientMediaPercentage.DivisionCode
                        ProductMediaOverrides.ProductCode = ClientMediaPercentage.ProductCode
                        ProductMediaOverrides.MediaType = SalesClass.SalesClassTypeCode
                        ProductMediaOverrides.SalesClassCode = SalesClass.Code
                        ProductMediaOverrides.RebatePercent = Nothing
                        ProductMediaOverrides.MarkupPercent = Nothing
                        ProductMediaOverrides.CreatedByUserCode = Session.UserCode

                        ExistingProductMediaOverrides.Add(ProductMediaOverrides)

                    End If

                Next

                ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.DataSource = ExistingProductMediaOverrides

                EnableOrDisableActions()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientMediaPercentagesSetupForm As AdvantageFramework.Maintenance.Client.Presentation.ClientMediaPercentagesSetupForm = Nothing

            ClientMediaPercentagesSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.ClientMediaPercentagesSetupForm()

            ClientMediaPercentagesSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientMediaPercentagesSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'objects
            BandedDataGridViewLeftSection_CDPRates.MultiSelect = True
            BandedDataGridViewLeftSection_CDPRates.OptionsCustomization.AllowSort = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            ButtonItemProductPercentages_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProductPercentages_Internet.Image = AdvantageFramework.My.Resources.InternetImage
            ButtonItemProductPercentages_Magazine.Image = AdvantageFramework.My.Resources.MagazineOrderImage
            ButtonItemProductPercentages_Newspaper.Image = AdvantageFramework.My.Resources.NewspaperOrdersImage
            ButtonItemProductPercentages_OutOfHome.Image = AdvantageFramework.My.Resources.OutOfHomeOrdersImage
            ButtonItemProductPercentages_Radio.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage
            ButtonItemProductPercentages_TV.Image = AdvantageFramework.My.Resources.BroadcastOrdersTVImage

            ButtonItemSalesClassOverrides_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemSalesClassOverrides_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemSalesClassOverrides_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSalesClassOverrides_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemSalesClassOverrides_Add.Image = AdvantageFramework.My.Resources.DetailAddImage

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            LoadGrid()

            LoadGridBands()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ClientMediaPercentagesSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientMediaPercentagesSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientMediaPercentagesSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ToggleColumnVisibility()

            LoadSelectedItemDetails()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "   CDP Rates Grid "

        Private Sub BandedDataGridViewLeftSection_CDPRates_GotFocusEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewLeftSection_CDPRates.GotFocusEvent

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewLeftSection_CDPRates_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewLeftSection_CDPRates.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_CDPRates_LostFocusEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewLeftSection_CDPRates.LostFocusEvent

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewLeftSection_CDPRates_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles BandedDataGridViewLeftSection_CDPRates.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If BandedDataGridViewLeftSection_CDPRates.HasOnlyOneSelectedRow Then

                    Me.ShowWaitForm()

                    LoadSelectedItemDetails()

                    Me.CloseWaitForm()

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_CDPRates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedDataGridViewLeftSection_CDPRates.ShowingEditorEvent

            If BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientCode.ToString OrElse
                    BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientName.ToString OrElse
                    BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionCode.ToString OrElse
                    BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionName.ToString OrElse
                    BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductCode.ToString OrElse
                    BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductDescription.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region "   Ribbon Bar Buttons "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            ToggleColumnVisibility()

            Me.ClearChanged()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            BandedDataGridViewLeftSection_CDPRates.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDescriptions.CheckedChanged

            ToggleColumnVisibility()

        End Sub
        Private Sub ButtonItemSalesClassOverrides_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemSalesClassOverrides_Delete.Click

            ProductMediaOverrideControlRightSection_Overrides.Delete()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSalesClassOverrides_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemSalesClassOverrides_Cancel.Click

            ProductMediaOverrideControlRightSection_Overrides.DataGridViewForm_ProductMediaOverrides.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSalesClassOverrides_Copy_Click(sender As System.Object, e As EventArgs) Handles ButtonItemSalesClassOverrides_Copy.Click

            ClientMediaSalesClassOverrideCopyDialog.ShowFormDialog(BandedDataGridViewLeftSection_CDPRates.GetRowDataBoundItem(BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedRowHandle), ClientMediaSalesClassOverrideCopyDialog.CopyMode.CopySalesClassOverrides)

        End Sub
        Private Sub ButtonItemProductPercentages_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemProductPercentages_Copy.Click

            If ClientMediaSalesClassOverrideCopyDialog.ShowFormDialog(BandedDataGridViewLeftSection_CDPRates.GetRowDataBoundItem(BandedDataGridViewLeftSection_CDPRates.CurrentView.FocusedRowHandle), ClientMediaSalesClassOverrideCopyDialog.CopyMode.CopyProductPercentages) = Windows.Forms.DialogResult.OK Then

                LoadGrid()

                ToggleColumnVisibility()

            End If

        End Sub
        Private Sub ButtonItemInternet_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemInternet_Markup.Click

            UpdatePercentage(PercentageType.InternetMarkup)

        End Sub
        Private Sub ButtonItemInternet_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemInternet_Rebate.Click

            UpdatePercentage(PercentageType.InternetRebate)

        End Sub
        Private Sub ButtonItemMagazine_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemMagazine_Markup.Click

            UpdatePercentage(PercentageType.MagazineMarkup)

        End Sub
        Private Sub ButtonItemMagazine_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemMagazine_Rebate.Click

            UpdatePercentage(PercentageType.MagazineRebate)

        End Sub
        Private Sub ButtonItemNewspaper_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemNewspaper_Markup.Click

            UpdatePercentage(PercentageType.NewspaperMarkup)

        End Sub
        Private Sub ButtonItemNewspaper_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemNewspaper_Rebate.Click

            UpdatePercentage(PercentageType.NewspaperRebate)

        End Sub
        Private Sub ButtonItemOutOfHome_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemOutOfHome_Markup.Click

            UpdatePercentage(PercentageType.OutdoorMarkup)

        End Sub
        Private Sub ButtonItemOutOfHome_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemOutOfHome_Rebate.Click

            UpdatePercentage(PercentageType.OutdoorRebate)

        End Sub
        Private Sub ButtonItemRadio_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemRadio_Markup.Click

            UpdatePercentage(PercentageType.RadioMarkup)

        End Sub
        Private Sub ButtonItemRadio_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemRadio_Rebate.Click

            UpdatePercentage(PercentageType.RadioRebate)

        End Sub
        Private Sub ButtonItemSalesClassOverrides_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemSalesClassOverrides_Export.Click

            'objects
            Dim CDPs As IEnumerable(Of String) = Nothing
            Dim ProductMediaOverrides As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            CDPs = (From Entity In BandedDataGridViewLeftSection_CDPRates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)
                    Select Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ProductMediaOverrides = (From Entity In AdvantageFramework.Database.Procedures.ProductMediaOverrides.Load(DbContext)
                                         Where CDPs.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode)).OrderBy(Function(PMO) PMO.ClientCode).ThenBy(Function(PMO) PMO.DivisionCode).ThenBy(Function(PMO) PMO.ProductCode).ToList

            End Using

            DataGridView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView

            DataGridView.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            DataGridView.OptionsView.ShowViewCaption = False
            DataGridView.OptionsPrint.AutoWidth = False
            DataGridView.DataSource = ProductMediaOverrides
            DataGridView.CurrentView.BestFitColumns()

            DataGridView.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, "Sales Class Overrides Report")

        End Sub
        Private Sub ButtonItemTelevision_Markup_Click(sender As Object, e As EventArgs) Handles ButtonItemTelevision_Markup.Click

            UpdatePercentage(PercentageType.TVMarkup)

        End Sub
        Private Sub ButtonItemTelevision_Rebate_Click(sender As Object, e As EventArgs) Handles ButtonItemTelevision_Rebate.Click

            UpdatePercentage(PercentageType.TVRebate)

        End Sub
        Private Sub ButtonItemAdd_All_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_All.Click

            AddSalesClassOverrides("ALL")

        End Sub
        Private Sub ButtonItemAdd_Internet_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_Internet.Click

            AddSalesClassOverrides("I")

        End Sub
        Private Sub ButtonItemAdd_Magazine_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_Magazine.Click

            AddSalesClassOverrides("M")

        End Sub
        Private Sub ButtonItemAdd_Newspaper_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_Newspaper.Click

            AddSalesClassOverrides("N")

        End Sub
        Private Sub ButtonItemAdd_OutOfHome_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_OutOfHome.Click

            AddSalesClassOverrides("O")

        End Sub
        Private Sub ButtonItemAdd_Radio_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_Radio.Click

            AddSalesClassOverrides("R")

        End Sub
        Private Sub ButtonItemAdd_Television_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_Television.Click

            AddSalesClassOverrides("T")

        End Sub
        Private Sub ProductMediaOverrideControlRightSection_Overrides_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ProductMediaOverrideControlRightSection_Overrides.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductMediaOverrideControlRightSection_Overrides_SelectionChangedEvent(sender As Object, e As EventArgs) Handles ProductMediaOverrideControlRightSection_Overrides.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
