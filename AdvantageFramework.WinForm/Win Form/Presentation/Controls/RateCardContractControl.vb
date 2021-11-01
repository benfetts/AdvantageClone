Namespace WinForm.Presentation.Controls

    Public Class RateCardContractControl

        Public Event SelectedTabChanged()
        Public Event RateCardDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event RateCardDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event RateCardColorChargesInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event RateCardColorChargesSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event RateCardInActiveChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _RateCardID As Integer = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _RateCardDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail) = Nothing
        Private _RateCardColorChargesList As Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge) = Nothing
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property RateCardDetailList() As Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail)
            Get
                RateCardDetailList = _RateCardDetailsList
            End Get
        End Property
        Public ReadOnly Property DataGridViewRateDetailsHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewRateDetailsHasOnlyOneSelectedRow = DataGridViewRateDetail_RateDetails.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property RateCardDetailsIsNewItemRow() As Boolean
            Get
                RateCardDetailsIsNewItemRow = DataGridViewRateDetail_RateDetails.CurrentView.IsNewItemRow(DataGridViewRateDetail_RateDetails.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property RateCardDetailsFocusedRowHandle() As Integer
            Get
                RateCardDetailsFocusedRowHandle = DataGridViewRateDetail_RateDetails.CurrentView.FocusedRowHandle
            End Get
        End Property
        Public ReadOnly Property RateCardDetailHasRows As Boolean
            Get
                RateCardDetailHasRows = DataGridViewRateDetail_RateDetails.HasRows
            End Get
        End Property
        Public ReadOnly Property RateCardColorChargesList() As Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge)
            Get
                RateCardColorChargesList = _RateCardColorChargesList
            End Get
        End Property
        Public ReadOnly Property DataGridViewRateCardColorChargesHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewRateCardColorChargesHasOnlyOneSelectedRow = DataGridViewColorCharges_ColorCharges.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DataGridViewRateCardColorChargesIsNewItemRow() As Boolean
            Get
                DataGridViewRateCardColorChargesIsNewItemRow = DataGridViewColorCharges_ColorCharges.CurrentView.IsNewItemRow(DataGridViewColorCharges_ColorCharges.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property ColorChargesHasRows As Boolean
            Get
                ColorChargesHasRows = DataGridViewColorCharges_ColorCharges.HasRows
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ' General Information tab
                            SearchableComboBoxGeneralInformation_Vendor.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.VendorCode)

                            TextBoxGeneralInformation_Code.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.Code)
                            TextBoxGeneralInformation_Description.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.Description)

                            DateTimePickerGeneralInformation_DateFrom.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.DateFrom)
                            DateTimePickerGeneralInformation_DateFrom.SetRequired(True)

                            DateTimePickerGeneralInformation_DateTo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.DateTo)
                            DateTimePickerGeneralInformation_DateTo.SetRequired(True)

                            NumericInputDefaultInformation_VendorCommissionPercentage.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.CommissionPercent)
                            NumericInputDefaultInformation_VendorCommissionPercentage.SetFormat("###0.##0")

                            NumericInputDefaultInformation_MaterialCloseDays.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.MaterialClose)
                            NumericInputDefaultInformation_MaterialCloseDays.Properties.MinValue = 0
                            NumericInputDefaultInformation_MaterialCloseDays.Properties.MaxValue = 999
                            NumericInputDefaultInformation_MaterialCloseDays.Properties.MaxLength = 3

                            NumericInputDefaultInformation_SpaceCloseDays.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.SpaceClose)
                            NumericInputDefaultInformation_SpaceCloseDays.Properties.MinValue = 0
                            NumericInputDefaultInformation_SpaceCloseDays.Properties.MaxValue = 999
                            NumericInputDefaultInformation_SpaceCloseDays.Properties.MaxLength = 3

                            ' Rate Detail tab
                            DataGridViewRateDetail_RateDetails.MultiSelect = False

                            ' Color Changes tab
                            DataGridViewColorCharges_ColorCharges.MultiSelect = False

                            ' Other rate information tab
                            NumericInputFlatChargesDiscounts_NetCharge.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.NetCharge)
                            TextBoxFlatChargesDiscounts_NetChargeDescription.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.NetChargeDescription)
                            NumericInputFlatChargesDiscounts_NetDiscount.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.NetDiscountAmount)
                            TextBoxFlatChargesDiscounts_NetDiscountDescription.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.NetDiscountDescription)

                            NumericInputRateCharges_BleedPercent.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.BleedPercent)
                            NumericInputRateCharges_BleedPercent.SetFormat("##0.##0")

                            NumericInputRateCharges_PositionPercent.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.PositionPercent)
                            NumericInputRateCharges_PositionPercent.SetFormat("##0.##0")

                            NumericInputRateCharges_PremiumPercent.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.PremiumPercent)
                            NumericInputRateCharges_PremiumPercent.SetFormat("##0.##0")

                            ' Comments tab
                            TextBoxComments_CloseInfo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.ClosingInfo)
                            TextBoxComments_ContractInfo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.ContractInfo)
                            TextBoxComments_MiscInfo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.MiscInfo)
                            TextBoxComments_PositionInfo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.PositionInfo)
                            TextBoxComments_RateInfo.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.RateInfo)

                            LoadDropDownDataSources()

                        End Using

                        CheckBoxGeneralInformation_Inactive.ByPassUserEntryChanged = True

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadRateDetailsTab()

            Dim RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail = Nothing
            Dim RateCardDetails As Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail) = Nothing

            If _RateCardID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCardDetails = AdvantageFramework.Database.Procedures.RateCardDetail.LoadByRateCardID(DbContext, _RateCardID).ToList

                End Using

            Else

                RateCardDetails = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail)

                For Each RateCardDetail In _RateCardDetailsList

                    RateCardDetails.Add(RateCardDetail)

                Next

            End If

            DataGridViewRateDetail_RateDetails.DataSource = RateCardDetails

            DataGridViewRateDetail_RateDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadColorChargesTab()

            Dim RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge = Nothing
            Dim RateCardColorCharges As Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge) = Nothing

            If _RateCardID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCardColorCharges = AdvantageFramework.Database.Procedures.RateCardColorCharge.LoadByRateCardID(DbContext, _RateCardID).ToList

                End Using

            Else

                RateCardColorCharges = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge)

                For Each RateCardColorCharge In _RateCardColorChargesList

                    RateCardColorCharges.Add(RateCardColorCharge)

                Next

            End If

            DataGridViewColorCharges_ColorCharges.DataSource = RateCardColorCharges

            DataGridViewColorCharges_ColorCharges.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGeneralInformationTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            If RateCard IsNot Nothing Then

                SearchableComboBoxGeneralInformation_Vendor.SelectedValue = RateCard.VendorCode
                CheckBoxGeneralInformation_Inactive.CheckValue = IIf(RateCard.IsInactive = 1, False, True)
                TextBoxGeneralInformation_Code.Text = RateCard.Code
                TextBoxGeneralInformation_Description.Text = RateCard.Description

                If RateCard.IsContract Then
                    RadioButtonType_ContractRateCard.Checked = True
                    SearchableComboBoxType_Client.SelectedValue = RateCard.ContractClientCode
                Else
                    RadioButtonType_StandardRateCard.Checked = True
                    SearchableComboBoxType_Client.SelectedValue = Nothing
                End If

                DateTimePickerGeneralInformation_DateFrom.Value = RateCard.DateFrom
                DateTimePickerGeneralInformation_DateTo.Value = RateCard.DateTo

                If RateCard.CommissionPercent IsNot Nothing Then

                    NumericInputDefaultInformation_VendorCommissionPercentage.EditValue = RateCard.CommissionPercent

                End If

                If RateCard.MaterialClose IsNot Nothing Then

                    NumericInputDefaultInformation_MaterialCloseDays.EditValue = RateCard.MaterialClose

                End If

                If RateCard.SpaceClose IsNot Nothing Then

                    NumericInputDefaultInformation_SpaceCloseDays.EditValue = RateCard.SpaceClose

                End If

            End If

        End Sub
        Private Sub LoadOtherRateInformationTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            Dim RadioButtonControl As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing

            If RateCard IsNot Nothing Then

                If RateCard.NetCharge IsNot Nothing Then

                    NumericInputFlatChargesDiscounts_NetCharge.EditValue = RateCard.NetCharge

                End If

                If RateCard.NetDiscountAmount IsNot Nothing Then

                    NumericInputFlatChargesDiscounts_NetDiscount.EditValue = RateCard.NetDiscountAmount

                End If

                TextBoxFlatChargesDiscounts_NetChargeDescription.Text = RateCard.NetChargeDescription
                TextBoxFlatChargesDiscounts_NetDiscountDescription.Text = RateCard.NetDiscountDescription

                If RateCard.BleedPercent IsNot Nothing Then

                    NumericInputRateCharges_BleedPercent.EditValue = RateCard.BleedPercent

                End If

                If RateCard.PositionPercent IsNot Nothing Then

                    NumericInputRateCharges_PositionPercent.EditValue = RateCard.PositionPercent

                End If

                If RateCard.PremiumPercent IsNot Nothing Then

                    NumericInputRateCharges_PremiumPercent.EditValue = RateCard.PremiumPercent

                End If

            End If

        End Sub
        Private Sub LoadCommentsTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            If RateCard IsNot Nothing Then

                TextBoxComments_CloseInfo.Text = RateCard.ClosingInfo
                TextBoxComments_ContractInfo.Text = RateCard.ContractInfo
                TextBoxComments_MiscInfo.Text = RateCard.MiscInfo
                TextBoxComments_PositionInfo.Text = RateCard.PositionInfo
                TextBoxComments_RateInfo.Text = RateCard.RateInfo

            End If

        End Sub
        Private Sub SaveGeneralInformationTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            If RateCard IsNot Nothing Then

                If SearchableComboBoxGeneralInformation_Vendor.HasASelectedValue Then

                    RateCard.VendorCode = SearchableComboBoxGeneralInformation_Vendor.GetSelectedValue

                Else

                    RateCard.VendorCode = Nothing

                End If

                RateCard.IsInactive = If(CheckBoxGeneralInformation_Inactive.Checked, 0, 1)
                RateCard.Code = TextBoxGeneralInformation_Code.Text
                RateCard.Description = TextBoxGeneralInformation_Description.Text

                If RadioButtonType_StandardRateCard.Checked Then
                    RateCard.IsContract = 0
                ElseIf RadioButtonType_ContractRateCard.Checked Then
                    RateCard.IsContract = 1
                End If

                If SearchableComboBoxType_Client.HasASelectedValue Then

                    RateCard.ContractClientCode = SearchableComboBoxType_Client.GetSelectedValue

                Else

                    RateCard.ContractClientCode = Nothing

                End If

                If DateTimePickerGeneralInformation_DateFrom.ValueObject IsNot Nothing Then
                    RateCard.DateFrom = Convert.ToDateTime(DateTimePickerGeneralInformation_DateFrom.Value)
                Else
                    RateCard.DateFrom = Nothing
                End If

                If DateTimePickerGeneralInformation_DateTo.ValueObject IsNot Nothing Then
                    RateCard.DateTo = Convert.ToDateTime(DateTimePickerGeneralInformation_DateTo.Value)
                Else
                    RateCard.DateTo = Nothing
                End If

                RateCard.CommissionPercent = CDec(NumericInputDefaultInformation_VendorCommissionPercentage.EditValue)
                RateCard.MaterialClose = CDec(NumericInputDefaultInformation_MaterialCloseDays.EditValue)
                RateCard.SpaceClose = CDec(NumericInputDefaultInformation_SpaceCloseDays.EditValue)

            End If

        End Sub
        Private Sub SaveRateDetailTab()

            'objects
            Dim RateCardDetails As Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail) = Nothing

            If DataGridViewRateDetail_RateDetails.HasRows Then

                DataGridViewRateDetail_RateDetails.CurrentView.CloseEditorForUpdating()

                RateCardDetails = DataGridViewRateDetail_RateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.RateCardDetail)().ToList

                _RateCardDetailsList = RateCardDetails

            End If

        End Sub
        Private Sub SaveColorChargesTab()

            'objects
            Dim RateCardColorCharges As Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge) = Nothing

            If DataGridViewColorCharges_ColorCharges.HasRows Then

                DataGridViewColorCharges_ColorCharges.CurrentView.CloseEditorForUpdating()

                RateCardColorCharges = DataGridViewColorCharges_ColorCharges.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.RateCardColorCharge)().ToList

                _RateCardColorChargesList = RateCardColorCharges

            End If

        End Sub
        Private Sub SaveOtherRateInformationTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            RateCard.NetCharge = CDec(NumericInputFlatChargesDiscounts_NetCharge.EditValue)
            RateCard.NetChargeDescription = TextBoxFlatChargesDiscounts_NetChargeDescription.Text

            RateCard.NetDiscountAmount = CDec(NumericInputFlatChargesDiscounts_NetDiscount.EditValue)
            RateCard.NetDiscountDescription = TextBoxFlatChargesDiscounts_NetDiscountDescription.Text

            RateCard.BleedPercent = CDec(NumericInputRateCharges_BleedPercent.EditValue)
            RateCard.PositionPercent = CDec(NumericInputRateCharges_PositionPercent.EditValue)
            RateCard.PremiumPercent = CDec(NumericInputRateCharges_PremiumPercent.EditValue)

        End Sub
        Private Sub SaveCommentsTab(ByVal RateCard As AdvantageFramework.Database.Entities.RateCard)

            RateCard.PositionInfo = TextBoxComments_PositionInfo.Text
            RateCard.ClosingInfo = TextBoxComments_CloseInfo.Text
            RateCard.RateInfo = TextBoxComments_RateInfo.Text
            RateCard.MiscInfo = TextBoxComments_MiscInfo.Text
            RateCard.ContractInfo = TextBoxComments_ContractInfo.Text

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewRateDetail_RateDetails.UseEmbeddedNavigator = True
                DataGridViewColorCharges_ColorCharges.UseEmbeddedNavigator = True

            Else

                DataGridViewRateDetail_RateDetails.UseEmbeddedNavigator = False
                DataGridViewColorCharges_ColorCharges.UseEmbeddedNavigator = False

            End If

        End Sub
        Private Function CheckDates() As Boolean

            Dim IsValid As Boolean = True

            If DateTimePickerGeneralInformation_DateTo.Value.Equals(#12:00:00 AM#) = False AndAlso DateTimePickerGeneralInformation_DateFrom.Value.Equals(#12:00:00 AM#) = False Then

                If DateTimePickerGeneralInformation_DateFrom.Value > DateTimePickerGeneralInformation_DateTo.Value Then

                    IsValid = False

                End If

            End If

            CheckDates = IsValid

        End Function
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxGeneralInformation_Vendor.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                                                          Where Entity.VendorCategory = "M" OrElse Entity.VendorCategory = "N"
                                                                          Select Entity).ToList

                SearchableComboBoxType_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonType_ContractRateCard.Checked Then

                SearchableComboBoxType_Client.Enabled = True
                SearchableComboBoxType_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Client.Properties.Code)

            Else

                SearchableComboBoxType_Client.SelectedValue = Nothing
                SearchableComboBoxType_Client.Enabled = False
                SearchableComboBoxType_Client.SetPropertySettings(AdvantageFramework.Database.Entities.RateCard.Properties.ContractClientCode)

            End If

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal RateCardID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing

            _RateCardID = RateCardID

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _RateCardID <> 0 Then

                    RateCard = AdvantageFramework.Database.Procedures.RateCard.LoadByID(DbContext, _RateCardID)

                    _IsLoading = True

                    SearchableComboBoxGeneralInformation_Vendor.Enabled = False
                    TextBoxGeneralInformation_Code.Enabled = False

                    If RateCard IsNot Nothing Then

                        LoadGeneralInformationTab(RateCard)

                        LoadRateDetailsTab()

                        LoadColorChargesTab()

                        LoadOtherRateInformationTab(RateCard)

                        LoadCommentsTab(RateCard)

                    Else

                        Loaded = False

                    End If

                    _IsLoading = False

                Else

                    SearchableComboBoxGeneralInformation_Vendor.Enabled = True
                    TextBoxGeneralInformation_Code.Enabled = True

                    DataGridViewRateDetail_RateDetails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail)
                    DataGridViewColorCharges_ColorCharges.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge)

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.RateCard

            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing

            If Me.Validate Then

                Try

                    If IsNew Then

                        RateCard = New AdvantageFramework.Database.Entities.RateCard

                        SaveGeneralInformationTab(RateCard)
                        SaveRateDetailTab()
                        SaveColorChargesTab()
                        SaveOtherRateInformationTab(RateCard)
                        SaveCommentsTab(RateCard)

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            RateCard = AdvantageFramework.Database.Procedures.RateCard.LoadByID(DbContext, _RateCardID)

                            If RateCard IsNot Nothing Then

                                SaveGeneralInformationTab(RateCard)
                                SaveRateDetailTab()
                                SaveColorChargesTab()
                                SaveOtherRateInformationTab(RateCard)
                                SaveCommentsTab(RateCard)

                            End If

                        End Using

                    End If

                Catch ex As Exception
                    RateCard = Nothing
                End Try

            End If

            FillObject = RateCard

        End Function
        Public Sub ClearControl()

            _IsClearing = True

            'general information
            SearchableComboBoxGeneralInformation_Vendor.SelectedValue = Nothing
            CheckBoxGeneralInformation_Inactive.Checked = False
            TextBoxGeneralInformation_Code.Text = Nothing
            TextBoxGeneralInformation_Description.Text = Nothing
            RadioButtonType_ContractRateCard.Checked = False
            RadioButtonType_StandardRateCard.Checked = False
            SearchableComboBoxType_Client.SelectedValue = Nothing
            DateTimePickerGeneralInformation_DateFrom.Value = Nothing
            DateTimePickerGeneralInformation_DateTo.Value = Nothing
            NumericInputDefaultInformation_VendorCommissionPercentage.EditValue = Nothing
            NumericInputDefaultInformation_MaterialCloseDays.EditValue = Nothing
            NumericInputDefaultInformation_SpaceCloseDays.EditValue = Nothing

            'rate detail
            DataGridViewRateDetail_RateDetails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail)

            'color charges
            DataGridViewColorCharges_ColorCharges.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge)

            'other rate information
            NumericInputFlatChargesDiscounts_NetCharge.EditValue = Nothing
            NumericInputFlatChargesDiscounts_NetDiscount.EditValue = Nothing
            TextBoxFlatChargesDiscounts_NetChargeDescription.Text = Nothing
            TextBoxFlatChargesDiscounts_NetDiscountDescription.Text = Nothing

            NumericInputRateCharges_BleedPercent.EditValue = Nothing
            NumericInputRateCharges_PositionPercent.EditValue = Nothing
            NumericInputRateCharges_PremiumPercent.EditValue = Nothing

            'comments
            TextBoxComments_CloseInfo.Text = Nothing
            TextBoxComments_ContractInfo.Text = Nothing
            TextBoxComments_MiscInfo.Text = Nothing
            TextBoxComments_PositionInfo.Text = Nothing
            TextBoxComments_RateInfo.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

        End Sub
        Public Sub DeleteSelectedRateCardDetail()

            'objects
            Dim RateCardDetails As Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail) = Nothing
            Dim RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail = Nothing

            Dim Deleted As Boolean = False

            If DataGridViewRateDetail_RateDetails.HasASelectedRow Then

                DataGridViewRateDetail_RateDetails.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    RateCardDetails = DataGridViewRateDetail_RateDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.RateCardDetail)().ToList

                    If _RateCardID <> 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each RateCardDetail In RateCardDetails

                                AdvantageFramework.Database.Procedures.RateCardDetail.Delete(DbContext, RateCardDetail)

                            Next

                        End Using

                    Else

                        For Each RateCardDetail In RateCardDetails

                            _RateCardDetailsList.Remove(RateCardDetail)

                        Next

                    End If

                    Me.CloseWaitForm()

                    LoadRateDetailsTab()

                End If

            End If

        End Sub
        Public Sub CancelAddNewRateCardDetail()

            DataGridViewRateDetail_RateDetails.CancelNewItemRow()

            LoadRateDetailsTab()

        End Sub
        Public Sub DeleteSelectedColorChargeDetail()

            'objects
            Dim RateCardColorCharges As Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge) = Nothing
            Dim RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge = Nothing

            Dim Deleted As Boolean = False

            If DataGridViewColorCharges_ColorCharges.HasASelectedRow Then

                DataGridViewColorCharges_ColorCharges.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    RateCardColorCharges = DataGridViewColorCharges_ColorCharges.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.RateCardColorCharge)().ToList

                    If _RateCardID <> 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each RateCardColorCharge In RateCardColorCharges

                                AdvantageFramework.Database.Procedures.RateCardColorCharge.Delete(DbContext, RateCardColorCharge)

                            Next

                        End Using

                    Else

                        For Each RateCardColorCharge In RateCardColorCharges

                            _RateCardColorChargesList.Remove(RateCardColorCharge)

                        Next

                    End If

                    Me.CloseWaitForm()

                    LoadColorChargesTab()

                End If

            End If

        End Sub
        Public Sub CancelAddNewColorCharge()

            DataGridViewColorCharges_ColorCharges.CancelNewItemRow()

            LoadColorChargesTab()

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCard = Me.FillObject(False)

                    If RateCard IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.RateCard.Update(DbContext, RateCard) Then

                            Saved = True

                            For Each RateCardDetail In RateCardDetailList

                                RateCardDetail.DbContext = DbContext

                                RateCardDetail.RateCardID = RateCard.ID

                                AdvantageFramework.Database.Procedures.RateCardDetail.Update(DbContext, RateCardDetail)

                            Next

                            For Each RateCardColorCharge In RateCardColorChargesList

                                RateCardColorCharge.DbContext = DbContext

                                RateCardColorCharge.RateCardID = RateCard.ID

                                AdvantageFramework.Database.Procedures.RateCardColorCharge.Update(DbContext, RateCardColorCharge)

                            Next

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCard = Me.FillObject(False)

                    If RateCard IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.RateCard.Delete(DbContext, RateCard)

                        If Deleted = False Then

                            ErrorMessage = "The Rate Card is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ID As Integer) As Boolean

            'objects
            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCard = Me.FillObject(True)

                    If RateCard IsNot Nothing Then

                        RateCard.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.RateCard.Insert(DbContext, RateCard) Then

                            Inserted = True

                            For Each RateCardDetail In RateCardDetailList

                                RateCardDetail.DbContext = DbContext

                                RateCardDetail.RateCardID = RateCard.ID

                                AdvantageFramework.Database.Procedures.RateCardDetail.Insert(DbContext, RateCardDetail)

                            Next

                            For Each RateCardColorCharge In RateCardColorChargesList

                                RateCardColorCharge.DbContext = DbContext

                                RateCardColorCharge.RateCardID = RateCard.ID

                                AdvantageFramework.Database.Procedures.RateCardColorCharge.Insert(DbContext, RateCardColorCharge)

                            Next

                            ID = RateCard.ID

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RateCardContractControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            _RateCardDetailsList = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardDetail)

            _RateCardColorChargesList = New Generic.List(Of AdvantageFramework.Database.Entities.RateCardColorCharge)

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxGeneralInformation_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxGeneralInformation_Inactive.CheckedChanged

            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing

            If Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RateCard = AdvantageFramework.Database.Procedures.RateCard.LoadByID(DbContext, _RateCardID)

                    If RateCard IsNot Nothing Then

                        RateCard.IsInactive = If(CheckBoxGeneralInformation_Inactive.Checked, 0, 1)

                        If AdvantageFramework.Database.Procedures.RateCard.Update(DbContext, RateCard) Then

                            RaiseEvent RateCardInActiveChanged()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub TabControlControl_GeneralInformation_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_GeneralInformation.SelectedTabChanging

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub DataGridViewRateDetail_RateDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRateDetail_RateDetails.AddNewRowEvent

            'objects
            Dim RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.RateCardDetail Then

                Me.ShowWaitForm("Processing...")

                RateCardDetail = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If RateCardDetail.IsEntityBeingAdded() Then

                        If _RateCardID <> 0 Then

                            RateCardDetail.DbContext = DbContext

                            RateCardDetail.RateCardID = _RateCardID

                            If AdvantageFramework.Database.Procedures.RateCardDetail.Insert(DbContext, RateCardDetail) Then

                                LoadRateDetailsTab()

                            End If

                        Else

                            _RateCardDetailsList.Add(RateCardDetail)

                            LoadRateDetailsTab()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRateDetail_RateDetails_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewRateDetail_RateDetails.EmbeddedNavigatorButtonClick

            Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                    CancelAddNewRateCardDetail()

                    e.Handled = True

                Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                    DeleteSelectedRateCardDetail()

                    e.Handled = True

            End Select

        End Sub
        Private Sub DataGridViewRateDetail_RateDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRateDetail_RateDetails.InitNewRowEvent

            RaiseEvent RateCardDetailsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewRateDetail_RateDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRateDetail_RateDetails.SelectionChangedEvent

            If DataGridViewRateDetail_RateDetails.CustomDeleteButton IsNot Nothing Then

                DataGridViewRateDetail_RateDetails.CustomDeleteButton.Enabled = Not DataGridViewRateDetail_RateDetails.CurrentView.IsNewItemRow(DataGridViewRateDetail_RateDetails.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent RateCardDetailsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewColorCharges_ColorCharges_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewColorCharges_ColorCharges.AddNewRowEvent

            'objects
            Dim RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.RateCardColorCharge Then

                Me.ShowWaitForm("Processing...")

                RateCardColorCharge = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If RateCardColorCharge.IsEntityBeingAdded() Then

                        If _RateCardID <> 0 Then

                            RateCardColorCharge.DbContext = DbContext

                            RateCardColorCharge.RateCardID = _RateCardID

                            If AdvantageFramework.Database.Procedures.RateCardColorCharge.Insert(DbContext, RateCardColorCharge) Then

                                LoadColorChargesTab()

                            End If

                        Else

                            _RateCardColorChargesList.Add(RateCardColorCharge)

                            LoadColorChargesTab()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewColorCharges_ColorCharges_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewColorCharges_ColorCharges.EmbeddedNavigatorButtonClick

            Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                    CancelAddNewColorCharge()

                    e.Handled = True

                Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                    DeleteSelectedColorChargeDetail()

                    e.Handled = True

            End Select

        End Sub
        Private Sub DataGridViewColorCharges_ColorCharges_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewColorCharges_ColorCharges.InitNewRowEvent

            RaiseEvent RateCardColorChargesInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewColorCharges_ColorCharges_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewColorCharges_ColorCharges.SelectionChangedEvent

            If DataGridViewColorCharges_ColorCharges.CustomDeleteButton IsNot Nothing Then

                DataGridViewColorCharges_ColorCharges.CustomDeleteButton.Enabled = Not DataGridViewColorCharges_ColorCharges.CurrentView.IsNewItemRow(DataGridViewColorCharges_ColorCharges.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent RateCardColorChargesSelectionChangedEvent(sender, e)

        End Sub
        Private Sub RadioButtonType_ContractRateCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonType_ContractRateCard.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonType_StandardRateCard_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonType_StandardRateCard.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxGeneralInformation_Vendor_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxGeneralInformation_Vendor.EditValueChanged

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If SearchableComboBoxGeneralInformation_Vendor.SelectedValue = Nothing Then

                GroupBoxOtherRateInformation_RateCharges.Visible = False

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, SearchableComboBoxGeneralInformation_Vendor.SelectedValue.ToString)

                    If Vendor IsNot Nothing Then

                        If Vendor.VendorCategory = "M" Then

                            GroupBoxOtherRateInformation_RateCharges.Visible = True

                        Else

                            GroupBoxOtherRateInformation_RateCharges.Visible = False

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub DateTimePickerGeneralInformation_DateFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerGeneralInformation_DateFrom.Validating

            If CheckDates() = False Then

                AdvantageFramework.WinForm.MessageBox.Show("'Date To' is before 'Date From'")

                DateTimePickerGeneralInformation_DateTo.Value = #12:00:00 AM#

            End If

        End Sub
        Private Sub DateTimePickerGeneralInformation_DateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerGeneralInformation_DateTo.Validating

            If CheckDates() = False Then

                AdvantageFramework.WinForm.MessageBox.Show("'Date To' is before 'Date From'")

                DateTimePickerGeneralInformation_DateTo.Value = #12:00:00 AM#

            End If

        End Sub
        Private Sub TextBoxComment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxComments_CloseInfo.GotFocus, TextBoxComments_ContractInfo.GotFocus,
                                                                                                         TextBoxComments_MiscInfo.GotFocus, TextBoxComments_PositionInfo.GotFocus,
                                                                                                         TextBoxComments_RateInfo.GotFocus

            RaiseEvent CommentGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxComments_CloseInfo.LostFocus, TextBoxComments_ContractInfo.LostFocus,
                                                                                                          TextBoxComments_MiscInfo.LostFocus, TextBoxComments_PositionInfo.LostFocus,
                                                                                                          TextBoxComments_RateInfo.LostFocus

            RaiseEvent CommentLostFocusEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
