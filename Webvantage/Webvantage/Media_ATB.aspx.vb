Imports AdvantageFramework.AlertSystem.Classes

Public Class Media_ATB
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "

    Private Enum ApprovalOption
        None
        Approve
        Unapprove
    End Enum

#End Region

#Region " Variables "

    Private _RevisionID As Integer = Nothing
    Private _ATBNumber As Integer = Nothing
    Private _RevisionNumber As Short = Nothing
    Private _Product As AdvantageFramework.Database.Entities.Product = Nothing
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _DataContext As AdvantageFramework.Database.DataContext = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property IsATBEditable() As Boolean
        Get

            If IsHighestRevision = False OrElse IsCanceled = True OrElse Me.IsApproved = True Then

                IsATBEditable = False

            Else

                IsATBEditable = True

            End If

        End Get
    End Property
    Private Property IsHighestRevision() As Boolean
        Get

            Try

                IsHighestRevision = CBool(Session("CurATBHighestRevision"))

            Catch ex As Exception
                IsHighestRevision = True
            End Try

        End Get
        Set(value As Boolean)
            Session("CurATBHighestRevision") = value
        End Set
    End Property
    Private Property IsCanceled() As Boolean
        Get

            Try

                IsCanceled = CBool(Session("CurATBCanceled"))

            Catch ex As Exception
                IsCanceled = True
            End Try

        End Get
        Set(value As Boolean)
            Session("CurATBCanceled") = value
        End Set
    End Property
    Private Property IsApproved As Boolean
        Get

            Try

                IsApproved = CBool(Session("CurATBApproved"))

            Catch ex As Exception
                IsApproved = False
            End Try

        End Get
        Set(value As Boolean)

            Session("CurATBApproved") = value

            If value = True Then

                ATBApproved.Value = 1

            Else

                ATBApproved.Value = 0

            End If

        End Set
    End Property
    Private Property IsOnlyRevision As Boolean
        Get

            Try

                IsOnlyRevision = CBool(Session("CurATBOnlyRev"))

            Catch ex As Exception
                IsOnlyRevision = False
            End Try

        End Get
        Set(value As Boolean)
            Session("CurATBOnlyRev") = value
        End Set
    End Property
    Private Property IsOrdering As Boolean
        Get
            Try

                IsOrdering = Session("ATBOrdering")

            Catch ex As Exception
                IsOrdering = False
            End Try

        End Get
        Set(value As Boolean)
            Session("ATBOrdering") = value
        End Set
    End Property
    Private Property ProductMarkupPercent As Decimal?
        Get

            'objects
            Dim MarkupPercent As Decimal? = Nothing

            Try

                MarkupPercent = ViewState("ProductMarkupPercent")

            Catch ex As Exception

            End Try

            If MarkupPercent.HasValue = False Then

                MarkupPercent = 17.647

            End If

            ProductMarkupPercent = MarkupPercent

        End Get
        Set(value As Decimal?)
            ViewState("ProductMarkupPercent") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub LoadOrder()

        'objects
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ATBNumber > 0 Then

                    MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, _ATBNumber)

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                        Select Entity).Count > 1 Then

                        Me.IsOnlyRevision = False

                    Else

                        Me.IsOnlyRevision = True

                    End If

                    If MediaATB IsNot Nothing Then

                        Try

                            MediaATBRevision = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                                                Where Entity.RevisionNumber = _RevisionNumber
                                                Select Entity).Single

                        Catch ex As Exception
                            MediaATBRevision = Nothing
                        End Try

                        TextBox_ATBDescription.MaxLength = Math.Max(MediaATBRevision.Description.Length, 40)

                        If MediaATB.IsInactive.GetValueOrDefault(0) = 0 Then

                            RadToolBarButtonCancel.Visible = True
                            RadToolBarButtonUnCancel.Visible = False
                            Me.TrClosed.Visible = False
                            Me.IsCanceled = False

                        ElseIf MediaATB.IsInactive.GetValueOrDefault(0) = 1 Then

                            RadToolBarButtonCancel.Visible = False
                            RadToolBarButtonUnCancel.Visible = True
                            Me.TrClosed.Visible = True
                            Me.IsCanceled = True

                        End If

                        Hidden_ATBNumber.Value = MediaATBRevision.ATBNumber
                        Hidden_RevisionNumber.Value = MediaATBRevision.RevisionNumber

                        TextBox_ATBNumber.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATB.Number.ToString, 6, "0", True)
                        TextBox_ClientCode.Text = MediaATB.ClientCode
                        TextBox_ClientDescription.Text = MediaATB.Client.Name
                        TextBox_DivisionCode.Text = MediaATB.DivisionCode
                        TextBox_DivisionDescription.Text = MediaATB.Division.Name
                        TextBox_ProductCode.Text = MediaATB.ProductCode
                        TextBox_ProductDescription.Text = MediaATB.Product.Name

                        LoadAvailableCampaigns()

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode)

                        If Product IsNot Nothing Then

                            Me.ProductMarkupPercent = Product.InternetMarkup.GetValueOrDefault(0)

                            Try

                                Me.HiddenFieldProductCommission.Value = DbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT [COMM_PCT] FROM [dbo].[advtf_med_calc_comm_mu](0, {0})", Me.ProductMarkupPercent)).SingleOrDefault

                            Catch ex As Exception
                                Me.HiddenFieldProductCommission.Value = 0
                            End Try

                        End If

                        If MediaATBRevision IsNot Nothing Then

                            TextBox_ATBDescription.Text = MediaATBRevision.Description
                            RadDatePicker_DateOfRequest.DbSelectedDate = MediaATBRevision.DateRequested

                            RadComboBox_Revision.Items.Clear()

                            For Each RevisionNumber In (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, MediaATBRevision.ATBNumber)
                                                        Select [RN] = Entity.RevisionNumber).ToArray

                                RadComboBox_Revision.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.StringUtilities.PadWithCharacter(RevisionNumber.ToString, 3, "0", True), RevisionNumber))

                            Next

                            RadComboBox_Revision.SelectedValue = MediaATBRevision.RevisionNumber

                            If MediaATBRevision.CampaignID.HasValue AndAlso MediaATBRevision.CampaignID > 0 Then

                                RadComboBox_Campaign.SelectedValue = CStr(MediaATBRevision.CampaignID)

                            End If

                            If MediaATBRevision.CampaignStartDate.HasValue Then

                                RadDatePicker_CampaignBeginningDate.DbSelectedDate = MediaATBRevision.CampaignStartDate

                            End If

                            If MediaATBRevision.CampaignEndDate.HasValue Then

                                RadDatePicker_CampaignEndingDate.DbSelectedDate = MediaATBRevision.CampaignEndDate

                            End If

                            If MediaATBRevision.ClientBudget.HasValue Then

                                RadTextBox_ClientBudget.Value = MediaATBRevision.ClientBudget

                            End If

                            TextBox_Comments.Text = MediaATBRevision.Comments

                            If MediaATBRevision.BuyGrossOrNetFlag.GetValueOrDefault(0) = 0 Then

                                RadToolBarButtonBuyNet.Checked = True
                                RadToolBarButtonBuyGross.Checked = False

                                'RadToolBarButtonAddAdServing.Visible = True
                                'RadToolBarButtonSubtractAdServing.Visible = True
                                'RadToolBarButtonCalcOptionSeparator.Visible = True

                                'If MediaATBRevision.NetCalculationOption.GetValueOrDefault(0) = 0 Then

                                '    RadToolBarButtonAddAdServing.Checked = True
                                '    RadToolBarButtonSubtractAdServing.Checked = False

                                'Else

                                '    RadToolBarButtonAddAdServing.Checked = False
                                '    RadToolBarButtonSubtractAdServing.Checked = True

                                'End If

                            ElseIf MediaATBRevision.BuyGrossOrNetFlag.GetValueOrDefault(0) = 1 Then

                                RadToolBarButtonBuyGross.Checked = True
                                RadToolBarButtonBuyNet.Checked = False

                                'RadToolBarButtonAddAdServing.Visible = False
                                'RadToolBarButtonSubtractAdServing.Visible = False
                                'RadToolBarButtonCalcOptionSeparator.Visible = False

                            End If

                            RadComboBox_SalesClass.SelectedValue = MediaATBRevision.SalesClassCode

                            TextBox_BillingComment.Text = MediaATBRevision.BillingComments
                            TextBox_ClientPO.Text = MediaATBRevision.ClientPO
                            RadComboBox_BillingMethod.SelectedValue = CInt(MediaATBRevision.BillingMethod.GetValueOrDefault(0))
                            RadDatePicker_DateToBill.DbSelectedDate = MediaATBRevision.BillingDate

                            RadButton_BillCommissionOnly.Checked = CBool(MediaATBRevision.CommissionOnlyFlag.GetValueOrDefault(0))

                            If GetHighestRevisionNumber() = MediaATBRevision.RevisionNumber Then

                                Me.IsHighestRevision = True

                            Else

                                Me.IsHighestRevision = False

                            End If

                            ApprovedRevNum.Value = "-1"

                            If String.IsNullOrEmpty(MediaATBRevision.ApprovedByUserCode) = False Then

                                Me.IsApproved = True
                                RadToolBarButtonApproval.Visible = False
                                RadToolBarButtonUnApprove.Visible = True
                                RadToolBarButtonCreateOrder.Visible = True
                                TrApproved.Visible = True

                            Else

                                Me.IsApproved = False
                                RadToolBarButtonApproval.Visible = True
                                RadToolBarButtonUnApprove.Visible = False
                                RadToolBarButtonCreateOrder.Visible = False
                                TrApproved.Visible = False

                                If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, MediaATB.Number)
                                    Where Entity.ApprovedByUserCode IsNot Nothing
                                    Select Entity).Any = True Then

                                    ApprovedRevNum.Value = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, MediaATB.Number)
                                                            Where Entity.ApprovedByUserCode IsNot Nothing
                                                            Select Entity).OrderByDescending(Function(Entity) Entity.RevisionNumber).FirstOrDefault.RevisionNumber

                                End If

                                'If MediaATBRevision.CreatedByUserCode = _Session.UserCode Then

                                '    RadToolBarButtonApproval.Visible = False

                                'End If

                            End If

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
        End Try

    End Sub
    Private Sub LoadOrderEntity(ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision, ByVal IsNew As Boolean)

        If MediaATBRevision IsNot Nothing Then

            MediaATBRevision.Description = TextBox_ATBDescription.Text.Trim

            If RadDatePicker_DateOfRequest.SelectedDate.HasValue Then

                MediaATBRevision.DateRequested = RadDatePicker_DateOfRequest.SelectedDate

            Else

                MediaATBRevision.DateRequested = Nothing

            End If

            If String.IsNullOrEmpty(RadComboBox_Campaign.SelectedValue) = False Then

                MediaATBRevision.CampaignID = CInt(RadComboBox_Campaign.SelectedValue)

            Else

                MediaATBRevision.CampaignID = Nothing

            End If

            If RadTextBox_ClientBudget.Value.HasValue Then

                MediaATBRevision.ClientBudget = CDec(RadTextBox_ClientBudget.Value)

            Else

                MediaATBRevision.ClientBudget = Nothing

            End If

            If RadDatePicker_CampaignBeginningDate.SelectedDate.HasValue Then

                MediaATBRevision.CampaignStartDate = RadDatePicker_CampaignBeginningDate.SelectedDate

            Else

                MediaATBRevision.CampaignStartDate = Nothing

            End If

            If RadDatePicker_CampaignEndingDate.SelectedDate.HasValue Then

                MediaATBRevision.CampaignEndDate = RadDatePicker_CampaignEndingDate.SelectedDate

            Else

                MediaATBRevision.CampaignEndDate = Nothing

            End If

            MediaATBRevision.Comments = TextBox_Comments.Text

            If RadToolBarButtonBuyNet.Checked Then

                MediaATBRevision.BuyGrossOrNetFlag = 0

            ElseIf RadToolBarButtonBuyGross.Checked Then

                MediaATBRevision.BuyGrossOrNetFlag = 1

            Else

                MediaATBRevision.BuyGrossOrNetFlag = 0

            End If

            If RadComboBox_SalesClass.SelectedValue <> "" Then

                MediaATBRevision.SalesClassCode = RadComboBox_SalesClass.SelectedValue

            Else

                MediaATBRevision.SalesClassCode = Nothing

            End If

            MediaATBRevision.BillingComments = TextBox_BillingComment.Text
            MediaATBRevision.ClientPO = TextBox_ClientPO.Text
            MediaATBRevision.BillingMethod = CShort(RadComboBox_BillingMethod.SelectedValue)
            MediaATBRevision.BillingDate = RadDatePicker_DateToBill.SelectedDate
            MediaATBRevision.CommissionOnlyFlag = RadButton_BillCommissionOnly.Checked

        End If

    End Sub
    Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.MediaATBRevision

        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing

        Try

            If IsNew Then

                MediaATBRevision = New AdvantageFramework.Database.Entities.MediaATBRevision

                LoadOrderEntity(MediaATBRevision, True)

                MediaATBRevision.RevisionNumber = MediaATBRevision.RevisionNumber + 1

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber)

                    If MediaATBRevision IsNot Nothing Then

                        LoadOrderEntity(MediaATBRevision, False)

                    End If

                End Using

            End If

        Catch ex As Exception
            MediaATBRevision = Nothing
        End Try

        FillObject = MediaATBRevision

    End Function
    Private Function Save(ByVal ApprovalOption As Webvantage.Media_ATB.ApprovalOption) As Boolean

        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False
        Dim DetailID As Integer = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevision = Me.FillObject(False)

                If MediaATBRevision IsNot Nothing Then

                    If ApprovalOption <> Media_ATB.ApprovalOption.None Then

                        If ApprovalOption = Media_ATB.ApprovalOption.Approve Then

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID)
                                Select Entity).Any = True Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV] SET [APPROVED_BY] = NULL, [APPROVED_DATE] = NULL, [APPROVAL_FLAG] = NULL WHERE [ATB_NUMBER] = {0}", MediaATBRevision.ATBNumber))

                                MediaATBRevision.ApprovalFlag = 1
                                MediaATBRevision.ApprovedByUserCode = _Session.UserCode
                                MediaATBRevision.ApprovedDate = System.DateTime.Now

                            Else

                                ErrorMessage = "Please enter at least one line item before approving."

                            End If

                        ElseIf ApprovalOption = Media_ATB.ApprovalOption.Unapprove Then

                            MediaATBRevision.ApprovalFlag = Nothing
                            MediaATBRevision.ApprovedByUserCode = Nothing
                            MediaATBRevision.ApprovedDate = Nothing

                        End If

                    End If

                    MediaATBRevision.ModifiedByUserCode = _Session.UserCode
                    MediaATBRevision.ModifiedDate = System.DateTime.Now

                    If MediaATBRevision.CampaignStartDate.HasValue = False Then

                        ErrorMessage &= "Beginning Date is required. " & Environment.NewLine

                    End If

                    If MediaATBRevision.CampaignEndDate.HasValue = False Then

                        ErrorMessage &= "Ending Date is required. " & Environment.NewLine

                    End If

                    'MediaATBRevision.SetRequired(AdvantageFramework.Database.Entities.MediaATBRevision.Properties.CampaignStartDate.ToString, True)
                    'MediaATBRevision.SetRequired(AdvantageFramework.Database.Entities.MediaATBRevision.Properties.CampaignEndDate.ToString, True)

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        Saved = AdvantageFramework.Database.Procedures.MediaATBRevision.Update(DbContext, MediaATBRevision)

                        If Saved Then

                            For Each GridItem In RadGrid_ATBDetails.Items.OfType(Of Telerik.Web.UI.GridItem)()

                                If GridItem.ItemType = Telerik.Web.UI.GridItemType.Item OrElse GridItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                                    If TypeOf GridItem Is Telerik.Web.UI.GridDataItem Then

                                        DetailID = CInt(DirectCast(GridItem, Telerik.Web.UI.GridDataItem).GetDataKeyValue("DetailID"))

                                        SaveMediaATBRevisionDetail(DetailID, GridItem)

                                    End If

                                End If

                            Next

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Save = Saved

    End Function
    Private Function Revise(ByRef RevisionNumber As Short) As Boolean

        'objects
        Dim Revised As Boolean = False
        Dim ErrorMessage As String = Nothing
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim NewMediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim NewMediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        Dim OldAndNewIDs As Generic.Dictionary(Of Integer, Integer) = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    MediaATBRevision = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                                        Order By Entity.RevisionNumber Descending
                                        Select Entity).FirstOrDefault

                Catch ex As Exception
                    MediaATBRevision = Nothing
                End Try

                If MediaATBRevision IsNot Nothing Then

                    NewMediaATBRevision = New AdvantageFramework.Database.Entities.MediaATBRevision
                    NewMediaATBRevision.DbContext = DbContext

                    NewMediaATBRevision.ATBNumber = MediaATBRevision.ATBNumber
                    NewMediaATBRevision.Description = MediaATBRevision.Description
                    NewMediaATBRevision.RevisionNumber = MediaATBRevision.RevisionNumber + 1
                    NewMediaATBRevision.DateRequested = MediaATBRevision.DateRequested
                    NewMediaATBRevision.CampaignID = MediaATBRevision.CampaignID
                    NewMediaATBRevision.CampaignStartDate = MediaATBRevision.CampaignStartDate
                    NewMediaATBRevision.CampaignEndDate = MediaATBRevision.CampaignEndDate
                    NewMediaATBRevision.ClientBudget = MediaATBRevision.ClientBudget
                    NewMediaATBRevision.Comments = MediaATBRevision.Comments
                    NewMediaATBRevision.BuyGrossOrNetFlag = MediaATBRevision.BuyGrossOrNetFlag
                    NewMediaATBRevision.SalesClassCode = MediaATBRevision.SalesClassCode
                    NewMediaATBRevision.BillingComments = MediaATBRevision.BillingComments
                    NewMediaATBRevision.BillingDate = MediaATBRevision.BillingDate
                    NewMediaATBRevision.ClientPO = MediaATBRevision.ClientPO
                    NewMediaATBRevision.CommissionOnlyFlag = MediaATBRevision.CommissionOnlyFlag
                    NewMediaATBRevision.BillingMethod = MediaATBRevision.BillingMethod
                    NewMediaATBRevision.NetCalculationOption = MediaATBRevision.NetCalculationOption
                    NewMediaATBRevision.CreatedByUserCode = _Session.UserCode
                    NewMediaATBRevision.CreatedDate = System.DateTime.Now

                    If AdvantageFramework.Database.Procedures.MediaATBRevision.Insert(DbContext, NewMediaATBRevision) Then

                        RevisionNumber = NewMediaATBRevision.RevisionNumber

                        Revised = True

                        OldAndNewIDs = New Generic.Dictionary(Of Integer, Integer)

                        For Each MediaATBRevisionDetail In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).ToList.OrderBy(Function(RevDtl) RevDtl.AdServingForDetailID.GetValueOrDefault(0))

                            NewMediaATBRevisionDetail = New AdvantageFramework.Database.Entities.MediaATBRevisionDetail

                            MediaATBRevisionDetail.DbContext = DbContext

                            NewMediaATBRevisionDetail.RevisionID = NewMediaATBRevision.RevisionID
                            NewMediaATBRevisionDetail.VendorCode = MediaATBRevisionDetail.VendorCode
                            NewMediaATBRevisionDetail.Quantity = MediaATBRevisionDetail.Quantity
                            NewMediaATBRevisionDetail.Rate = MediaATBRevisionDetail.Rate
                            NewMediaATBRevisionDetail.CostType = MediaATBRevisionDetail.CostType
                            NewMediaATBRevisionDetail.GrossBudget = MediaATBRevisionDetail.GrossBudget
                            NewMediaATBRevisionDetail.Amount = MediaATBRevisionDetail.Amount
                            NewMediaATBRevisionDetail.MarkupPercent = MediaATBRevisionDetail.MarkupPercent
                            NewMediaATBRevisionDetail.MarkupAmount = MediaATBRevisionDetail.MarkupAmount
                            NewMediaATBRevisionDetail.NetChargePercent = MediaATBRevisionDetail.NetChargePercent
                            NewMediaATBRevisionDetail.NetChargeAmount = MediaATBRevisionDetail.NetChargeAmount
                            NewMediaATBRevisionDetail.NetSpend = MediaATBRevisionDetail.NetSpend
                            NewMediaATBRevisionDetail.LineTotal = MediaATBRevisionDetail.LineTotal
                            NewMediaATBRevisionDetail.AdServingForDetailID = Nothing

                            If MediaATBRevisionDetail.AdServingForDetailID.HasValue AndAlso MediaATBRevisionDetail.AdServingForDetailID.GetValueOrDefault(0) > 0 Then

                                If OldAndNewIDs.ContainsKey(MediaATBRevisionDetail.AdServingForDetailID) Then

                                    NewMediaATBRevisionDetail.AdServingForDetailID = OldAndNewIDs(MediaATBRevisionDetail.AdServingForDetailID)

                                End If

                            End If

                            If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Insert(DbContext, NewMediaATBRevisionDetail) Then

                                OldAndNewIDs.Add(MediaATBRevisionDetail.DetailID, NewMediaATBRevisionDetail.DetailID)

                            End If

                        Next

                    End If

                End If

            End Using

            If Not Revised Then

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Revise = Revised

    End Function
    Private Function DeleteMediaATBRevisionDetail(ByVal ID As Integer) As Boolean

        'objects
        Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        Dim Deleted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevisionDetail = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByID(DbContext, ID)

                If MediaATBRevisionDetail IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Delete(DbContext, MediaATBRevisionDetail)

                End If

            End Using

        Catch ex As Exception
            Deleted = False
        End Try

        DeleteMediaATBRevisionDetail = Deleted

    End Function
    Private Function SaveMediaATBRevisionDetail(ByVal ID As Integer, ByVal GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        Dim Saved As Boolean = False

        Try

            If GridDataItem IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATBRevisionDetail = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByID(DbContext, ID)

                    If MediaATBRevisionDetail IsNot Nothing Then

                        LoadDetailEntity(MediaATBRevisionDetail, GridDataItem)

                        Saved = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Update(DbContext, MediaATBRevisionDetail)

                    End If

                End Using

            End If

        Catch ex As Exception
            Saved = False
        End Try

        SaveMediaATBRevisionDetail = Saved

    End Function
    Private Sub LoadDetailEntity(ByRef MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail, ByVal GridItem As Telerik.Web.UI.GridItem)

        'objects
        Dim VendorComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim CostTypeComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim QuantityInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetSpendInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TotalAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox = Nothing

        If MediaATBRevisionDetail IsNot Nothing AndAlso GridItem IsNot Nothing Then

            LoadGridItemControls(GridItem, VendorComboBox, QuantityInput, RateInput, CostTypeComboBox, AmountInput, MarkupPercentInput,
                                 MarkupAmountInput, NetChargePercentInput, NetChargeAmountInput, NetSpendInput, TotalAmountInput, Nothing,
                                 Nothing, Nothing, Nothing, GrossBudgetInput)

            MediaATBRevisionDetail.VendorCode = VendorComboBox.Text

            If QuantityInput.Value.HasValue Then

                MediaATBRevisionDetail.Quantity = CInt(QuantityInput.Value.GetValueOrDefault(0))

            Else

                MediaATBRevisionDetail.Quantity = Nothing

            End If

            If RateInput.Value.HasValue Then

                MediaATBRevisionDetail.Rate = RateInput.Value.GetValueOrDefault(0)

            Else

                MediaATBRevisionDetail.Rate = Nothing

            End If

            If String.IsNullOrWhiteSpace(CostTypeComboBox.SelectedValue) = False Then

                MediaATBRevisionDetail.CostType = CostTypeComboBox.SelectedValue

            Else

                MediaATBRevisionDetail.CostType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code

            End If

            If GrossBudgetInput.Value.HasValue Then

                MediaATBRevisionDetail.GrossBudget = GrossBudgetInput.Value.GetValueOrDefault(0)

            Else

                MediaATBRevisionDetail.GrossBudget = Nothing

            End If

            MediaATBRevisionDetail.Amount = AmountInput.Value
            MediaATBRevisionDetail.MarkupPercent = MarkupPercentInput.Value
            MediaATBRevisionDetail.MarkupAmount = MarkupAmountInput.Value
            MediaATBRevisionDetail.NetChargePercent = NetChargePercentInput.Value
            MediaATBRevisionDetail.NetChargeAmount = NetChargeAmountInput.Value
            MediaATBRevisionDetail.NetSpend = NetSpendInput.Value
            MediaATBRevisionDetail.LineTotal = TotalAmountInput.Value

        End If

    End Sub
    Private Sub ClearGridRow(ByVal GridItem As Telerik.Web.UI.GridItem)

        Dim VendorComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim CostTypeComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim QuantityInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetSpendInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TotalAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox = Nothing

        If GridItem IsNot Nothing Then

            LoadGridItemControls(GridItem, VendorComboBox, QuantityInput, RateInput, CostTypeComboBox, AmountInput, MarkupPercentInput, MarkupAmountInput,
                                 NetChargePercentInput, NetChargeAmountInput, NetSpendInput, TotalAmountInput, Nothing, Nothing, NetAmountInput, Nothing,
                                 GrossBudgetInput)

            VendorComboBox.Text = ""
            VendorComboBox.ClearSelection()
            AddVendorCommissionAttribute(VendorComboBox, Nothing)

            QuantityInput.Value = Nothing
            RateInput.Value = Nothing
            CostTypeComboBox.Text = ""
            CostTypeComboBox.ClearSelection()
            AmountInput.Value = Nothing
            'MarkupPercentInput.Value = Nothing
            MarkupAmountInput.Value = Nothing
            NetChargePercentInput.Value = Nothing
            NetChargeAmountInput.Value = Nothing
            NetSpendInput.Value = Nothing
            TotalAmountInput.Value = Nothing
            GrossBudgetInput.Value = Nothing

        End If

    End Sub
    Private Sub LoadGridItemControls(ByVal GridItem As Telerik.Web.UI.GridItem, Optional ByRef VendorComboBox As Telerik.Web.UI.RadComboBox = Nothing,
                                     Optional ByRef QuantityInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef RateInput As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef CostTypeComboBox As Telerik.Web.UI.RadComboBox = Nothing, Optional ByRef AmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef NetSpendInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef TotalAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef OrderedIndicatorDiv As HtmlControls.HtmlControl = Nothing, Optional ByRef ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef NetAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef ImageButtonSave As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef SaveButtonDiv As HtmlControls.HtmlControl = Nothing,
                                     Optional ByRef DeleteButtonDiv As HtmlControls.HtmlControl = Nothing)

        If GridItem IsNot Nothing Then

            Try

                VendorComboBox = DirectCast(GridItem.FindControl("RadComboBox_Vendor"), Telerik.Web.UI.RadComboBox)
                CostTypeComboBox = DirectCast(GridItem.FindControl("RadComboBox_CostType"), Telerik.Web.UI.RadComboBox)
                QuantityInput = DirectCast(GridItem.FindControl("RadNumericTextBox_Quantity"), Telerik.Web.UI.RadNumericTextBox)
                RateInput = DirectCast(GridItem.FindControl("RadNumericTextBox_Rate"), Telerik.Web.UI.RadNumericTextBox)
                AmountInput = DirectCast(GridItem.FindControl("RadNumericTextBox_Amount"), Telerik.Web.UI.RadNumericTextBox)
                MarkupPercentInput = DirectCast(GridItem.FindControl("RadNumericTextBox_MarkupPercent"), Telerik.Web.UI.RadNumericTextBox)
                MarkupAmountInput = DirectCast(GridItem.FindControl("RadNumericTextBox_MarkupAmount"), Telerik.Web.UI.RadNumericTextBox)
                NetChargePercentInput = DirectCast(GridItem.FindControl("RadNumericTextBox_NetChargePercent"), Telerik.Web.UI.RadNumericTextBox)
                NetChargeAmountInput = DirectCast(GridItem.FindControl("RadNumericTextBox_NetChargeAmount"), Telerik.Web.UI.RadNumericTextBox)
                NetSpendInput = DirectCast(GridItem.FindControl("RadNumericTextBox_NetSpend"), Telerik.Web.UI.RadNumericTextBox)
                TotalAmountInput = DirectCast(GridItem.FindControl("RadNumericTextBox_TotalAmount"), Telerik.Web.UI.RadNumericTextBox)
                OrderedIndicatorDiv = DirectCast(GridItem.FindControl("DivOrderedIndicator"), HtmlControls.HtmlControl)
                ImageButtonDelete = DirectCast(GridItem.FindControl("ImageButton_Delete"), System.Web.UI.WebControls.ImageButton)
                NetAmountInput = DirectCast(GridItem.FindControl("RadNumericTextBox_NetAmount"), Telerik.Web.UI.RadNumericTextBox)
                ImageButtonSave = DirectCast(GridItem.FindControl("ImageButton_Save"), System.Web.UI.WebControls.ImageButton)
                GrossBudgetInput = DirectCast(GridItem.FindControl("RadNumericTextBox_GrossBudget"), Telerik.Web.UI.RadNumericTextBox)
                SaveButtonDiv = DirectCast(GridItem.FindControl("DivSaveButton"), HtmlControls.HtmlControl)
                DeleteButtonDiv = DirectCast(GridItem.FindControl("DivDeleteButton"), HtmlControls.HtmlControl)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub LoadCampaignInformation()

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
        Dim CampaignID As Integer = Nothing
        Dim StartDate As Date? = Nothing
        Dim EndDate As Date? = Nothing

        If RadComboBox_Campaign.SelectedValue <> "" Then

            CampaignID = CInt(RadComboBox_Campaign.SelectedValue)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CampaignID)

                StartDate = Campaign.StartDate
                EndDate = Campaign.EndDate

                Try

                    RadTextBox_ClientBudget.Value = Campaign.BillingBudgetAmount.Value

                Catch ex As Exception
                    RadTextBox_ClientBudget.Value = Nothing
                End Try

            End Using

        Else

            StartDate = Nothing
            EndDate = Nothing
            RadTextBox_ClientBudget.Value = Nothing

        End If

        ' if ordered, dates are disabled. Campaign should not change the dates
        If RadDatePicker_CampaignBeginningDate.Enabled Then

            RadDatePicker_CampaignBeginningDate.DbSelectedDate = StartDate

        End If

        If RadDatePicker_CampaignEndingDate.Enabled Then

            RadDatePicker_CampaignEndingDate.DbSelectedDate = EndDate

        End If

    End Sub
    Private Sub LoadAvailableCampaigns()

        RadComboBox_Campaign.Items.Clear()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing

            For Each Campaign In (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, TextBox_ClientCode.Text)
                                  Where (Entity.IsClosed Is Nothing OrElse Entity.IsClosed = 0) AndAlso
                                        (Entity.DivisionCode Is Nothing OrElse Entity.DivisionCode = TextBox_DivisionCode.Text) AndAlso
                                        (Entity.ProductCode Is Nothing OrElse Entity.ProductCode = TextBox_ProductCode.Text)
                                  Select Entity.ID,
                                         Entity.Code,
                                         Entity.Name).ToList

                RadComboBox_Campaign.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Campaign.Code & " - " & Campaign.Name, Campaign.ID))

            Next

        End Using

        RadComboBox_Campaign.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

    End Sub
    Private Sub EnableOrDisableActions()

        'objects
        Dim AllowEdit As Boolean = True
        Dim IsApproved As Boolean = False

        IsApproved = Me.IsApproved

        Try

            AllowEdit = Me.IsATBEditable

        Catch ex As Exception
            AllowEdit = True
        End Try

        TextBox_ATBDescription.Enabled = AllowEdit
        RadDatePicker_DateOfRequest.Enabled = AllowEdit
        RadComboBox_Campaign.Enabled = AllowEdit
        RadComboBox_SalesClass.Enabled = AllowEdit
        TextBox_Comments.Enabled = AllowEdit
        TextBox_BillingComment.Enabled = AllowEdit
        RadDatePicker_DateToBill.Enabled = AllowEdit
        TextBox_ClientPO.Enabled = AllowEdit
        RadButton_BillCommissionOnly.Enabled = AllowEdit
        RadComboBox_BillingMethod.Enabled = AllowEdit
        RadTextBox_ClientBudget.Enabled = AllowEdit
        RadGrid_ATBDetails.Enabled = AllowEdit

        RadToolBarButtonSave.Enabled = AllowEdit
        RadToolBarButtonBuyGross.Enabled = AllowEdit
        RadToolBarButtonBuyNet.Enabled = AllowEdit
        'RadToolBarButtonAddAdServing.Enabled = AllowEdit
        'RadToolBarButtonSubtractAdServing.Enabled = AllowEdit

        If Me.IsCanceled Then

            RadToolBarButtonDelete.Enabled = False
            RadToolBarButtonRevise.Enabled = False

        Else

            If Me.IsHighestRevision = False Then

                RadToolBarButtonDelete.Visible = False

            ElseIf Me.IsOnlyRevision = True Then

                RadToolBarButtonDelete.Visible = False

            Else

                RadToolBarButtonDelete.Visible = True

            End If

            RadToolBarButtonDelete.Enabled = Not Me.IsApproved

            RadToolBarButtonRevise.Enabled = True

        End If

        RadToolBarButtonDeleteRevisionSeparator.Visible = RadToolBarButtonDelete.Visible
        RadToolbar_MediaATB.FindItemByValue("SendAssignment").Enabled = True
        RadToolbar_MediaATB.FindItemByValue("Print").Enabled = True
        RadToolbar_MediaATB.FindItemByValue("SendEmail").Enabled = True
        RadToolbar_MediaATB.FindItemByValue("SendAlert").Enabled = True
        RadToolbar_MediaATB.FindItemByValue("PrintSendOptions").Enabled = True

        CheckUserRights()

    End Sub
    Private Function GetHighestRevisionNumber() As Integer

        'objects
        Dim HighestRevisionNumber As Integer = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                HighestRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                                         Select Entity.RevisionNumber).Max

            End Using

        Catch ex As Exception
            HighestRevisionNumber = 0
        Finally
            GetHighestRevisionNumber = HighestRevisionNumber
        End Try

    End Function
    Private Function DeleteRevision() As Boolean

        'objects
        Dim RevisionNumber As Integer = Nothing
        Dim ATBNumber As Integer = Nothing
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim ErrorText As String = Nothing
        Dim Deleted As Boolean = False

        Try

            RevisionNumber = CInt(RadComboBox_Revision.SelectedValue)
            ATBNumber = _ATBNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, ATBNumber)
                    Select Entity).Count = 1 Then

                    ErrorText = "Cannot delete the only revision."

                Else

                    MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, ATBNumber, RevisionNumber)

                    If MediaATBRevision IsNot Nothing Then

                        If String.IsNullOrEmpty(MediaATBRevision.ApprovedByUserCode) = False Then

                            ErrorText = "Cannot delete an approved revision."

                        Else

                            Deleted = AdvantageFramework.Database.Procedures.MediaATBRevision.Delete(DbContext, MediaATBRevision)

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            Deleted = False
            ErrorText = "Error deleting revision."
        Finally

            If String.IsNullOrEmpty(ErrorText) = False Then

                Me.ShowMessage(ErrorText)

            End If

            DeleteRevision = Deleted

        End Try

    End Function
    Private Function ActivateOrDeactivateATB(ByVal Active As Boolean) As Boolean

        'objects
        Dim Updated As Boolean = False
        Dim ErrorText As String = Nothing
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing

        Try

            If Save(ApprovalOption.Unapprove) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, _ATBNumber)

                    If MediaATB IsNot Nothing Then

                        If Active Then

                            MediaATB.IsInactive = 0

                        Else

                            MediaATB.IsInactive = 1

                        End If

                        Updated = AdvantageFramework.Database.Procedures.MediaATB.Update(DbContext, MediaATB)

                    End If

                End Using

            End If

            If Updated = False Then

                ErrorText = "Error updating ATB."

            End If

        Catch ex As Exception
            Updated = False
            ErrorText = "Error updating ATB."
        Finally

            If String.IsNullOrEmpty(ErrorText) = False Then

                Me.ShowMessage(ErrorText)

            End If

            ActivateOrDeactivateATB = Updated

        End Try

    End Function
    Private Sub CheckUserRights()

        Dim CanPrint As Boolean = False
        Dim CanEdit As Boolean = False
        Dim CanInsert As Boolean = False

        CanPrint = Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
        CanEdit = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
        CanInsert = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

        If CanPrint = False Then

            RadToolbar_MediaATB.FindItemByValue("Print").Enabled = False

        End If

        If CanEdit = False AndAlso CanInsert = False Then

            Me.RadToolBarButtonSave.Enabled = False
            Me.RadToolBarButtonNewATB.Enabled = False
            Me.RadToolBarButtonCancel.Enabled = False
            Me.RadToolBarButtonUnCancel.Enabled = False
            Me.RadToolBarButtonDelete.Enabled = False
            Me.RadToolBarButtonRevise.Enabled = False
            Me.RadToolBarButtonBuyNet.Enabled = False
            Me.RadToolBarButtonBuyGross.Enabled = False
            'Me.RadToolBarButtonAddAdServing.Enabled = False
            'Me.RadToolBarButtonSubtractAdServing.Enabled = False
            Me.RadToolBarButtonApproval.Enabled = False
            Me.RadToolBarButtonUnApprove.Enabled = False

            RadComboBox_Campaign.Enabled = False
            RadGrid_ATBDetails.Enabled = False

        ElseIf CanEdit = False AndAlso CanInsert = True Then

            Me.RadToolBarButtonSave.Enabled = False
            Me.RadToolBarButtonCancel.Enabled = False
            Me.RadToolBarButtonUnCancel.Enabled = False
            Me.RadToolBarButtonDelete.Enabled = False
            Me.RadToolBarButtonBuyNet.Enabled = False
            Me.RadToolBarButtonBuyGross.Enabled = False
            'Me.RadToolBarButtonAddAdServing.Enabled = False
            'Me.RadToolBarButtonSubtractAdServing.Enabled = False
            Me.RadToolBarButtonApproval.Enabled = False
            Me.RadToolBarButtonUnApprove.Enabled = False

            RadComboBox_Campaign.Enabled = False

        End If

    End Sub
    Private Function LoadVendors() As Generic.List(Of AdvantageFramework.Database.Core.Vendor)

        'objects
        Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
        Dim VendorObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor)

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                VendorObjectQuery = From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                    Where Vendor.InternetCategory = 1 OrElse
                                          Vendor.VendorCategory = "I"
                                    Select Vendor

                VendorList = AdvantageFramework.Database.Procedures.Vendor.LoadCore(VendorObjectQuery)

            End Using

        Catch ex As Exception
            VendorList = Nothing
        Finally
            LoadVendors = VendorList
        End Try

    End Function
    Private Sub ReloadLoadMarkupPercent(ByVal ChangedFromAddToSubtract As Boolean)

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, TextBox_ClientCode.Text, TextBox_DivisionCode.Text, TextBox_ProductCode.Text)

        For Each GridItem In RadGrid_ATBDetails.Items.OfType(Of Telerik.Web.UI.GridItem)()

            LoadMarkupPercent(GridItem, Product, False, ChangedFromAddToSubtract)

        Next

    End Sub
    Private Sub LoadMarkupPercent(ByVal GridItem As Telerik.Web.UI.GridItem, ByVal Product As AdvantageFramework.Database.Entities.Product, ByVal FocusOnQuantityInput As Boolean, ByVal ChangedFromAddToSubtract As Boolean)

        'objects
        Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Dim VendorComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim CostTypeComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim QuantityInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetSpendInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TotalAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim CommissionOrMarkupPercent As Decimal? = Nothing
        Dim VendorCommission As Decimal? = Nothing
        Dim JavascriptString As String = Nothing
        Dim ControlChanged As System.Web.UI.WebControls.WebControl = Nothing

        If GridItem IsNot Nothing Then

            LoadGridItemControls(GridItem, VendorComboBox, QuantityInput, RateInput, CostTypeComboBox, AmountInput, MarkupPercentInput,
                                 MarkupAmountInput, NetChargePercentInput, NetChargeAmountInput, NetSpendInput, TotalAmountInput,
                                 Nothing, Nothing, NetAmountInput, Nothing, GrossBudgetInput)

            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, VendorComboBox.Text)

            GetMarkupPercent(Product, Vendor, CommissionOrMarkupPercent, VendorCommission)

            MarkupPercentInput.Value = CommissionOrMarkupPercent

            AddVendorCommissionAttribute(VendorComboBox, VendorCommission)

            If AmountInput.Value.HasValue Then

                If ChangedFromAddToSubtract = True Then

                    ControlChanged = NetChargeAmountInput

                Else

                    ControlChanged = Nothing 'refresh

                End If

                JavascriptString = GenerateCalculateFieldsJavascript(CostTypeComboBox, QuantityInput, RateInput, AmountInput, MarkupPercentInput, MarkupAmountInput, NetChargePercentInput,
                                                                     NetChargeAmountInput, NetAmountInput, NetSpendInput, TotalAmountInput, GrossBudgetInput, VendorComboBox, ControlChanged)

                Me.AddJavascriptToPage(JavascriptString)

            End If

            If FocusOnQuantityInput Then

                QuantityInput.Focus()

            End If

        End If

    End Sub
    Private Sub LoadMarkupPercent(ByVal GridItem As Telerik.Web.UI.GridItem, ByVal FocusOnQuantityInput As Boolean, ByVal ChangedFromAddToSubtract As Boolean)

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        If GridItem IsNot Nothing Then

            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, TextBox_ClientCode.Text, TextBox_DivisionCode.Text, TextBox_ProductCode.Text)

            LoadMarkupPercent(GridItem, Product, FocusOnQuantityInput, ChangedFromAddToSubtract)

        End If

    End Sub
    Private Sub GetMarkupPercent(ByVal Product As AdvantageFramework.Database.Entities.Product,
                                 ByVal Vendor As AdvantageFramework.Database.Entities.Vendor,
                                 ByRef CommissionOrMarkupPercent As Decimal?,
                                 ByRef VendorCommission As Decimal?)

        If Product IsNot Nothing AndAlso Vendor IsNot Nothing Then

            If Vendor.Commission.HasValue Then

                VendorCommission = Vendor.Commission

            Else

                VendorCommission = 15

            End If

            VendorCommission = VendorCommission.GetValueOrDefault(0) - Product.InternetRebate.GetValueOrDefault(0)

            If RadToolBarButtonBuyGross.Checked Then

                CommissionOrMarkupPercent = VendorCommission

            Else

                CommissionOrMarkupPercent = Product.InternetMarkup

            End If

        End If

    End Sub
    Private Function GenerateCalculateFieldsJavascript(ByVal CostTypeComboBox As Telerik.Web.UI.RadComboBox, ByVal QuantityInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal RateInput As Telerik.Web.UI.RadNumericTextBox, ByVal AmountInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox, ByVal MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox, ByVal NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal NetAmountInput As Telerik.Web.UI.RadNumericTextBox, ByVal NetSpendInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal TotalAmountInput As Telerik.Web.UI.RadNumericTextBox, ByVal GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox,
                                                       ByVal VendorComboBox As Telerik.Web.UI.RadComboBox, ByVal ControlChanged As System.Web.UI.WebControls.WebControl) As String

        'objects
        Dim CalculateString As String = Nothing
        Dim JavascriptAction As String = Nothing

        CalculateString = "CalculateFields('" & QuantityInput.ClientID & "', '" & RateInput.ClientID & "', '" & CostTypeComboBox.ClientID & "', '" & AmountInput.ClientID & "','" &
                          MarkupPercentInput.ClientID & "','" & MarkupAmountInput.ClientID & "','" & NetAmountInput.ClientID & "','" & NetChargePercentInput.ClientID & "','" &
                          NetChargeAmountInput.ClientID & "','" & NetSpendInput.ClientID & "','" & TotalAmountInput.ClientID & "','" & GrossBudgetInput.ClientID & "', '" & VendorComboBox.ClientID & "', "

        If ControlChanged IsNot Nothing Then

            If ControlChanged Is CostTypeComboBox Then

                JavascriptAction = "COSTTYPE"

            ElseIf ControlChanged Is QuantityInput Then

                JavascriptAction = "RATE"

            ElseIf ControlChanged Is RateInput Then

                JavascriptAction = "COSTTYPE"

            ElseIf ControlChanged Is AmountInput Then

                JavascriptAction = "AMOUNT"

            ElseIf ControlChanged Is MarkupPercentInput Then

                JavascriptAction = "COMMISSIONPCT"

            ElseIf ControlChanged Is MarkupAmountInput Then

                JavascriptAction = "COMMISSIONAMT"

            ElseIf ControlChanged Is NetChargePercentInput Then

                JavascriptAction = "NETCHARGEPCT"

            ElseIf ControlChanged Is NetChargeAmountInput Then

                JavascriptAction = "NETCHARGEAMT"

            ElseIf ControlChanged Is GrossBudgetInput Then

                JavascriptAction = "GROSSBUDGET"

            End If

        End If

        If String.IsNullOrWhiteSpace(JavascriptAction) Then

            JavascriptAction = "REFRESH"

        End If

        CalculateString = CalculateString & "'" & JavascriptAction & "');"

        GenerateCalculateFieldsJavascript = CalculateString

    End Function
    Private Sub AddVendorCommissionAttribute(ByVal VendorComboBox As Telerik.Web.UI.RadComboBox, ByVal Commission As Decimal?)

        Try

            If VendorComboBox IsNot Nothing Then

                If VendorComboBox.Attributes("Commission") IsNot Nothing Then

                    VendorComboBox.Attributes("Commission") = Commission

                Else

                    VendorComboBox.Attributes.Add("Commission", Commission)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

#Region " Show Form "

    Public Shared Function GenerateBaseQueryString(ByVal ATBNumber As Integer, ByVal RevisionNumber As Integer, ByVal Ordering As Boolean) As String

        Dim VariableList As Generic.Dictionary(Of String, String) = Nothing
        Dim QueryString As String = ""

        Try

            VariableList = New Generic.Dictionary(Of String, String)

            VariableList.Add("ATBNbr", ATBNumber.ToString)
            VariableList.Add("RevNbr", RevisionNumber.ToString)

            HttpContext.Current.Session("ATBOrdering") = Ordering

            QueryString = "Media_ATB.aspx?"

            Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            For Each Variable In VariableList

                QueryString &= Variable.Key & "=" & Sanitizer.Sanitize(Variable.Value) & "&"

            Next

            QueryString = QueryString.Substring(0, QueryString.Length - 1)

        Catch ex As Exception
            QueryString = "Media_ATB.aspx"
        Finally
            GenerateBaseQueryString = QueryString
        End Try

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub Media_ATB_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
        _DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        If Request.QueryString("ATBNbr") IsNot Nothing Then

            _ATBNumber = CInt(Request.QueryString("ATBNbr"))

        End If

        If Request.QueryString("RevNbr") IsNot Nothing Then

            _RevisionNumber = CShort(Request.QueryString("RevNbr"))

        Else

            _RevisionNumber = GetHighestRevisionNumber()

        End If

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _RevisionID = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber).RevisionID

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Authorization to Buy Digital Media"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadComboBox_BillingMethod.DataTextField = "Description"
                    RadComboBox_BillingMethod.DataValueField = "Code"

                    RadComboBox_BillingMethod.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaATBBillingMethod))
                                                            Select [Code] = EnumObject.Code,
                                                                   [Description] = EnumObject.Description).ToList

                    RadComboBox_BillingMethod.DataBind()

                    RadComboBox_SalesClass.DataTextField = "Description"
                    RadComboBox_SalesClass.DataValueField = "Code"

                    RadComboBox_SalesClass.DataSource = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                                         Where Entity.SalesClassTypeCode Is Nothing OrElse
                                                               Entity.SalesClassTypeCode = "I"
                                                         Select Entity.Code,
                                                                Entity.Description).ToList.Select(Function(SalesClass) New With {.Code = SalesClass.Code,
                                                                                                                                 .Description = SalesClass.Code & " - " & SalesClass.Description}).ToList
                    RadComboBox_SalesClass.DataBind()

                    RadComboBox_SalesClass.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                End Using

                LoadOrder()
                EnableOrDisableActions()

            Catch ex As Exception
                _ATBNumber = 0
            End Try

            If Me.IsOrdering Then

                Me.OpenWindow("", Webvantage.Importing_CreateOrder.GenerateBaseQueryString(Session("ATBImportOrders"), False))

                Me.IsOrdering = False

            End If

        End If

    End Sub
    Private Sub Media_ATB_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        AdvantageFramework.Database.CloseDbContext(_DbContext)
        AdvantageFramework.Database.CloseDataContext(_DataContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGrid_ATBDetails_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid_ATBDetails.ItemCommand

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        Dim Reload As Boolean = False
        Dim Command As String = Nothing
        Dim CommandArgument As String = Nothing
        Dim ErrorText As String = Nothing

        Command = e.CommandName.ToString.ToUpper
        CommandArgument = e.CommandArgument.ToString

        Try

            GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

        Catch ex As Exception
            GridDataItem = Nothing
        End Try

        Select Case Command

            Case "DELETE"

                If DeleteMediaATBRevisionDetail(CommandArgument) = False Then

                    ErrorText = "Error deleting item."

                Else

                    Reload = True

                End If

            Case "SAVE"

                If GridDataItem IsNot Nothing Then

                    If SaveMediaATBRevisionDetail(CommandArgument, GridDataItem) Then

                        Reload = True

                    Else

                        ErrorText = "Error saving item."

                    End If

                End If

            Case "ADDITEM"

                If GridDataItem IsNot Nothing Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            MediaATBRevisionDetail = New AdvantageFramework.Database.Entities.MediaATBRevisionDetail

                            LoadDetailEntity(MediaATBRevisionDetail, GridDataItem)

                            MediaATBRevisionDetail.DbContext = DbContext
                            MediaATBRevisionDetail.RevisionID = _RevisionID

                            Reload = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Insert(DbContext, MediaATBRevisionDetail)

                        End Using

                    Catch ex As Exception
                        ErrorText = "Adding item failed."
                    End Try

                End If

            Case "CANCELITEM"

                ClearGridRow(e.Item)

        End Select

        If ErrorText <> "" Then

            Me.ShowMessage(ErrorText)

        End If

        If Reload Then

            RadGrid_ATBDetails.Rebind()

        End If

    End Sub
    Private Sub RadGrid_ATBDetails_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid_ATBDetails.ItemDataBound

        'objects
        Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim VendorComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim CostTypeComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim QuantityInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupPercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim MarkupAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargePercentInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetChargeAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim NetSpendInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TotalAmountInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim OrderedIndicatorDiv As HtmlControls.HtmlControl = Nothing
        Dim SaveButtonDiv As HtmlControls.HtmlControl = Nothing
        Dim DeleteButtonDiv As HtmlControls.HtmlControl = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonSave As System.Web.UI.WebControls.ImageButton = Nothing
        Dim GrossBudgetInput As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim CommissionString As String = Nothing
        Dim NetString As String = Nothing
        Dim AgencyString As String = Nothing
        Dim NetSpendString As String = Nothing
        Dim TotalAgencyFeeString As String = Nothing
        Dim TotalString As String = Nothing
        Dim CalculateString As String = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim StringBuilderValues As System.Text.StringBuilder = Nothing
        Dim TotalAgency As Decimal = Nothing
        Dim TotalNetSpend As Decimal = Nothing
        Dim TotalAmount As Decimal = Nothing
        Dim VendorCommission As Decimal? = Nothing
        Dim CommissionOrMarkup As Decimal? = Nothing
        Dim CalculatedControls As System.Web.UI.WebControls.WebControl() = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

            Try

                GridItem = DirectCast(e.Item, Telerik.Web.UI.GridItem)

            Catch ex As Exception

            End Try

            If GridItem IsNot Nothing Then

                LoadGridItemControls(GridItem, VendorComboBox, QuantityInput, RateInput, CostTypeComboBox, AmountInput, MarkupPercentInput,
                                     MarkupAmountInput, NetChargePercentInput, NetChargeAmountInput, NetSpendInput, TotalAmountInput,
                                     OrderedIndicatorDiv, ImageButtonDelete, NetAmountInput, ImageButtonSave, GrossBudgetInput, SaveButtonDiv, DeleteButtonDiv)

                CostTypeComboBox.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Media.CostType))
                                               Select [Code] = Entity.Code).ToList
                CostTypeComboBox.DataBind()

                If GridItem.ItemType <> Telerik.Web.UI.GridItemType.EditItem Then

                    Try

                        MediaATBRevisionDetail = DirectCast(e.Item.DataItem, AdvantageFramework.Database.Entities.MediaATBRevisionDetail)

                    Catch ex As Exception
                        MediaATBRevisionDetail = Nothing
                    End Try

                    If MediaATBRevisionDetail IsNot Nothing Then

                        VendorComboBox.Text = MediaATBRevisionDetail.VendorCode
                        QuantityInput.Value = MediaATBRevisionDetail.Quantity
                        RateInput.Value = MediaATBRevisionDetail.Rate
                        CostTypeComboBox.SelectedValue = MediaATBRevisionDetail.CostType

                        If String.IsNullOrWhiteSpace(CostTypeComboBox.SelectedValue) Then

                            CostTypeComboBox.SelectedValue = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code

                        End If

                        AmountInput.Value = MediaATBRevisionDetail.Amount
                        MarkupAmountInput.Value = MediaATBRevisionDetail.MarkupAmount
                        MarkupPercentInput.Value = MediaATBRevisionDetail.MarkupPercent
                        NetChargePercentInput.Value = MediaATBRevisionDetail.NetChargePercent
                        NetChargeAmountInput.Value = MediaATBRevisionDetail.NetChargeAmount
                        NetSpendInput.Value = MediaATBRevisionDetail.NetSpend
                        TotalAmountInput.Value = MediaATBRevisionDetail.LineTotal
                        GrossBudgetInput.Value = MediaATBRevisionDetail.GrossBudget
                        NetAmountInput.Value = MediaATBRevisionDetail.Amount.GetValueOrDefault(0) - MediaATBRevisionDetail.MarkupAmount.GetValueOrDefault(0)

                        If RadToolBarButtonBuyNet.Checked = True Then

                            If _Product Is Nothing Then

                                _Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, TextBox_ClientCode.Text, TextBox_DivisionCode.Text, TextBox_ProductCode.Text)

                            End If

                            If _Product IsNot Nothing Then

                                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, MediaATBRevisionDetail.VendorCode)

                                If Vendor IsNot Nothing Then

                                    GetMarkupPercent(_Product, Vendor, CommissionOrMarkup, VendorCommission)
                                    AddVendorCommissionAttribute(VendorComboBox, VendorCommission.Value)

                                End If

                            End If

                        End If

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(_DataContext)
                            Where Entity.DetailID = MediaATBRevisionDetail.DetailID AndAlso
                                    Entity.OrderID IsNot Nothing AndAlso
                                    Entity.OrderID > 0
                            Select Entity).Any Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(SaveButtonDiv)
                            AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteButtonDiv)

                        Else

                            If Not Me.IsATBEditable Then

                                AdvantageFramework.Web.Presentation.Controls.DivHide(SaveButtonDiv)
                                AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteButtonDiv)

                            End If

                            AdvantageFramework.Web.Presentation.Controls.DivHide(OrderedIndicatorDiv)

                        End If

                        ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                    End If

                Else

                    CostTypeComboBox.SelectedValue = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code

                    'new row
                    If RadToolBarButtonBuyGross.Checked Then

                        MarkupPercentInput.Value = 15

                    ElseIf RadToolBarButtonBuyNet.Checked Then

                        MarkupPercentInput.Value = Me.ProductMarkupPercent

                    End If

                End If

                CalculatedControls = {QuantityInput, RateInput, CostTypeComboBox, AmountInput, MarkupPercentInput, MarkupAmountInput, NetChargePercentInput, NetChargeAmountInput, GrossBudgetInput}

                For Each CalculatedControl In CalculatedControls

                    CalculateString = "function() { " & GenerateCalculateFieldsJavascript(CostTypeComboBox, QuantityInput, RateInput, AmountInput, MarkupPercentInput, MarkupAmountInput,
                                                                                          NetChargePercentInput, NetChargeAmountInput, NetAmountInput, NetSpendInput, TotalAmountInput,
                                                                                          GrossBudgetInput, VendorComboBox, CalculatedControl) & "}"

                    If TypeOf CalculatedControl Is Telerik.Web.UI.RadNumericTextBox Then

                        DirectCast(CalculatedControl, Telerik.Web.UI.RadNumericTextBox).ClientEvents.OnValueChanged = CalculateString

                    ElseIf TypeOf CalculatedControl Is Telerik.Web.UI.RadComboBox Then

                        DirectCast(CalculatedControl, Telerik.Web.UI.RadComboBox).OnClientSelectedIndexChanged = CalculateString

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub RadGrid_ATBDetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_ATBDetails.NeedDataSource

        'objects
        Dim MediaATBRevisionDetailList As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
        Dim DetailIDs As Integer() = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevisionDetailList = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, _RevisionID).ToList

                DetailIDs = MediaATBRevisionDetailList.Select(Function(Dtl) Dtl.DetailID).ToArray

                If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                    Where Entity.OrderID.HasValue = True AndAlso
                          DetailIDs.Contains(Entity.DetailID)
                    Select Entity).Any Then

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                        Where Entity.OrderID.HasValue = False AndAlso
                              DetailIDs.Contains(Entity.DetailID)
                        Select Entity).Any = True Then

                        Label_OrderedStatus.Text = "PARTIALLY ORDERED&nbsp;&nbsp;"

                    Else

                        Label_OrderedStatus.Text = "ORDERED&nbsp;&nbsp;"

                    End If

                    RadToolBarButtonOrderDetail.Visible = True
                    HiddenFieldMediaOrderCreated.Value = 1
                    TrOrdered.Visible = True
                    RadDatePicker_CampaignBeginningDate.Enabled = False
                    RadDatePicker_CampaignEndingDate.Enabled = False
                    RadComboBox_BillingMethod.Enabled = False
                    RadComboBox_SalesClass.Enabled = False

                Else

                    RadToolBarButtonOrderDetail.Visible = Me.IsATBEditable
                    TrOrdered.Visible = False
                    HiddenFieldMediaOrderCreated.Value = 0
                    RadDatePicker_CampaignBeginningDate.Enabled = Me.IsATBEditable
                    RadDatePicker_CampaignEndingDate.Enabled = Me.IsATBEditable
                    RadComboBox_BillingMethod.Enabled = Me.IsATBEditable
                    RadComboBox_SalesClass.Enabled = Me.IsATBEditable

                End If

                If Me.IsApproved = True Then

                    RadToolBarButtonApproval.Enabled = False
                    RadToolBarButtonUnApprove.Enabled = Not Me.IsCanceled AndAlso Me.IsHighestRevision

                Else

                    RadToolBarButtonApproval.Enabled = Me.IsATBEditable AndAlso MediaATBRevisionDetailList.Count > 0
                    RadToolBarButtonUnApprove.Enabled = False

                End If

                RadGrid_ATBDetails.DataSource = MediaATBRevisionDetailList

            End Using

        End Using

        RadGrid_ATBDetails.MasterTableView.IsItemInserted = Me.IsATBEditable

    End Sub
    Private Sub RadToolbar_MediaATB_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbar_MediaATB.ButtonClick

        'objects
        Dim RevisionNumber As Short = 0
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim UpdatedAlertIDs As New Generic.List(Of Integer)

        Select Case e.Item.Value

            Case RadToolBarButtonNewATB.Value

                If Save(ApprovalOption.None) = True Then

                    Me.OpenWindow("New Order", "Media_ATB_Add.aspx", 700, 350)

                End If

            Case RadToolBarButtonSearch.Value

                Save(ApprovalOption.None)

                Me.OpenWindow("", "Media_ATB_Search.aspx")

            Case RadToolBarButtonSave.Value

                Save(ApprovalOption.None)

            Case RadToolBarButtonRevise.Value

                If Save(ApprovalOption.None) = True Then

                    If Revise(RevisionNumber) Then

                        Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, RevisionNumber, False))

                    End If

                End If

            Case RadToolBarButtonDelete.Value

                If DeleteRevision() Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            RevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                                              Select [RN] = Entity.RevisionNumber).Max

                        End Using

                    Catch ex As Exception
                        RevisionNumber = 0
                    End Try

                    Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, RevisionNumber, False))

                End If

            Case RadToolBarButtonCancel.Value

                If ActivateOrDeactivateATB(False) Then

                    AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(Me._Session, Me._Session.UserCode, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.ATB_Cancel,
                                                                                 False, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , _ATBNumber, _RevisionNumber, UpdatedAlertIDs)

                    Try

                        If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                            For Each AlertId In UpdatedAlertIDs

                                Try

                                    SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                    Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, _RevisionNumber, False))

                End If

            Case RadToolBarButtonUnCancel.Value

                If ActivateOrDeactivateATB(True) Then

                    AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(Me._Session, Me._Session.UserCode, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.ATB_Uncancel,
                                                                            True, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , _ATBNumber, _RevisionNumber, UpdatedAlertIDs)

                    Try

                        If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                            For Each AlertId In UpdatedAlertIDs

                                Try

                                    SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                    Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, _RevisionNumber, False))

                End If

            Case "Print"

                If Save(ApprovalOption.None) = True Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Media_ATB_Print.aspx"
                        .Add("ATBNbr", _ATBNumber.ToString)
                        .Add("RevNbr", _RevisionNumber.ToString)
                        .Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                    End With

                    Me.OpenPrintSendSilently(QueryString)

                End If

            Case "PrintSendOptions"

                If Save(ApprovalOption.None) = True Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Media_ATB_Print.aspx"
                        .Add("ATBNbr", _ATBNumber.ToString)
                        .Add("RevNbr", _RevisionNumber.ToString)
                        .Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                    End With

                    Me.OpenWindow(QueryString)

                End If

            Case "SendAssignment"

                If Save(ApprovalOption.None) = True Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Media_ATB_Print.aspx"
                        .Add("ATBNbr", _ATBNumber.ToString)
                        .Add("RevNbr", _RevisionNumber.ToString)
                        .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                    End With

                    Me.OpenPrintSendSilently(QueryString)

                End If

            Case "SendAlert"

                If Save(ApprovalOption.None) = True Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Media_ATB_Print.aspx"
                        .Add("ATBNbr", _ATBNumber.ToString)
                        .Add("RevNbr", _RevisionNumber.ToString)
                        .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                    End With

                    Me.OpenPrintSendSilently(QueryString)

                End If

            Case "SendEmail"

                If Save(ApprovalOption.None) = True Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Media_ATB_Print.aspx"
                        .Add("ATBNbr", _ATBNumber.ToString)
                        .Add("RevNbr", _RevisionNumber.ToString)
                        .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                    End With

                    Me.OpenPrintSendSilently(QueryString)

                End If

            Case RadToolBarButtonApproval.Value

                If Save(ApprovalOption.Approve) = True Then

                    AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(Me._Session, Me._Session.UserCode, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.ATB_Approval,
                                                                                            False, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , _ATBNumber, _RevisionNumber, UpdatedAlertIDs)

                    Try

                        If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                            For Each AlertId In UpdatedAlertIDs

                                Try

                                    SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                    Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, _RevisionNumber, False))

                End If

            Case RadToolBarButtonUnApprove.Value

                If Save(ApprovalOption.Unapprove) = True Then

                    AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(Me._Session, Me._Session.UserCode, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.ATB_Unapprove,
                                                                                           True, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , _ATBNumber, _RevisionNumber, UpdatedAlertIDs)

                    Try

                        If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                            For Each AlertId In UpdatedAlertIDs

                                Try

                                    SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                    Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, _RevisionNumber, False))

                End If

            Case RadToolBarButtonCreateOrder.Value

                If Save(ApprovalOption.None) = True Then

                    Me.OpenWindow("", Webvantage.Media_ATB_CreateOrder.GenerateBaseQueryString(_ATBNumber, _RevisionNumber), IsModal:=True, Width:=600, Height:=400)

                End If

            Case "Alerts"

                Save(ApprovalOption.None)

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_List.aspx"
                qs.MediaATBNumber = Me._ATBNumber
                qs.MediaATBRevisionNumber = Me._RevisionNumber
                qs.Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.MediaATB)

                Me.OpenWindow(qs)

            Case RadToolBarButtonOrderDetail.Value

                Me.OpenWindow("", Webvantage.Media_ATB_OrderDetails.GenerateBaseQueryString(_ATBNumber, _RevisionNumber), IsModal:=True)

            Case RadToolBarButtonBuyGross.Value, RadToolBarButtonBuyNet.Value

                _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV] SET [ATB_BUY_GROSS_NET] = {0} WHERE [ATB_NUMBER] = {1} AND [REV_NBR] = {2}", If(e.Item.Value = RadToolBarButtonBuyGross.Value, 1, 0), _ATBNumber, _RevisionNumber))

                ReloadLoadMarkupPercent(False)

                'Case RadToolBarButtonAddAdServing.Value, RadToolBarButtonSubtractAdServing.Value

                '    _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV] SET [NET_CALC_OPTION] = {0} WHERE [ATB_NUMBER] = {1} AND [REV_NBR] = {2}", If(e.Item.Value = RadToolBarButtonSubtractAdServing.Value, 1, 0), _ATBNumber, _RevisionNumber))

                '    ReloadLoadMarkupPercent(If(e.Item.Value = RadToolBarButtonSubtractAdServing.Value, True, False))

                '    Save(ApprovalOption.None)
                '    'ReloadLoadMarkupPercent(True)

        End Select

    End Sub
    Protected Sub RadComboBox_Vendor_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs)

        'objects
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim DataSource As IEnumerable = Nothing
        Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
        Dim Vendor As AdvantageFramework.Database.Core.Vendor = Nothing
        Dim Offset As Integer = Nothing
        Dim EndOffset As Integer = Nothing
        Dim ItemsPerRequest As Integer = 20

        Try

            RadComboBox = DirectCast(sender, Telerik.Web.UI.RadComboBox)

        Catch ex As Exception

        End Try

        If RadComboBox IsNot Nothing Then

            VendorList = LoadVendors()

            Offset = e.NumberOfItems
            EndOffset = Math.Min(Offset + ItemsPerRequest, VendorList.Count)
            e.EndOfItems = If(EndOffset = VendorList.Count, True, False)

            For I = Offset To EndOffset - 1

                Try

                    Vendor = VendorList(I)

                Catch ex As Exception
                    Vendor = Nothing
                End Try

                If Vendor IsNot Nothing Then

                    RadComboBox.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Vendor.ToString, Vendor.Code))

                End If

            Next

        End If

    End Sub
    Protected Sub RadComboBox_Vendor_TextChanged(sender As Object, e As EventArgs)

        'objects
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing

        Try

            GridItem = DirectCast(sender, Telerik.Web.UI.RadComboBox).Parent.Parent

        Catch ex As Exception
            GridItem = Nothing
        End Try

        AddVendorCommissionAttribute(sender, Nothing)

        If GridItem IsNot Nothing Then

            LoadMarkupPercent(GridItem, True, False)

        End If

    End Sub
    Protected Sub RadComboBox_SalesClass_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs)

        'objects
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

        Try

            RadComboBox = DirectCast(sender, Telerik.Web.UI.RadComboBox)

        Catch ex As Exception

        End Try

        If RadComboBox IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SalesClasses = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, "I").ToList

                For Each SalesClass In SalesClasses

                    RadComboBox.Items.Add(New Telerik.Web.UI.RadComboBoxItem(SalesClass.Code & " - " & SalesClass.Description, SalesClass.Code))

                Next

            End Using

        End If

    End Sub
    Protected Sub RadComboBox_Campaign_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

        LoadCampaignInformation()
        EnableOrDisableActions()

    End Sub
    Protected Sub RadComboBox_Revision_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

        'objects
        Dim RevisionNumber As Integer = Nothing

        RevisionNumber = CInt(RadComboBox_Revision.SelectedValue)

        Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, RevisionNumber, False))

        '_RevisionNumber = CInt(RadComboBox_Revision.SelectedValue)

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    _RevisionID = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber).RevisionID

        'End Using

        'LoadOrder()

        'RadGrid_ATBDetails.Rebind()

        'EnableOrDisableActions()

    End Sub

#End Region

#End Region

End Class
