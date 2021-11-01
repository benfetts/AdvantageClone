Namespace Client

    Public Class ProductDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty
        Private _ProductContacts As Hashtable = Nothing
        Private _ProductAccountExecutives As Hashtable = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ProductContacts = New Hashtable
            _ProductAccountExecutives = New Hashtable

        End Sub
        Private Function LoadCurrentProduct() As AdvantageFramework.Database.Entities.Product

            Try

                LoadCurrentProduct = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product)

            Catch ex As Exception
                LoadCurrentProduct = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ProductDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            Dim ID As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim AccountExecutiveList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            Dim ClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
            Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
            Dim ClientContactDetailList As Integer() = Nothing

            Try

                ID = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ID
                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContactIDs = New Generic.List(Of Integer)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = DivisionCode AndAlso
                                                     Entity.ProductCode = ProductCode
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = DivisionCode AndAlso
                                                     Entity.ProductCode Is Nothing
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode).Include("ClientContactDetail")
                                               Where Entity.ClientContactDetail.Count = 0
                                               Select Entity.ContactID).ToArray)

                    ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                    ClientContactList = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode)
                                         Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                    _ProductContacts(ID) = ClientContactList

                    AccountExecutiveList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).Include("Employee").ToList

                    _ProductAccountExecutives(ID) = AccountExecutiveList

                End Using

            Catch ex As Exception

            End Try

            If (ClientContactList Is Nothing OrElse ClientContactList.Count = 0) AndAlso (AccountExecutiveList Is Nothing OrElse AccountExecutiveList.Count = 0) Then

                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                DetailReportAccountExecutives.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                DetailReportContacts.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

            ElseIf (ClientContactList Is Nothing OrElse ClientContactList.Count = 0) AndAlso (AccountExecutiveList IsNot Nothing AndAlso AccountExecutiveList.Count > 0) Then

                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                DetailReportAccountExecutives.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                DetailReportContacts.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

            Else

                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                DetailReportAccountExecutives.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                DetailReportContacts.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

            End If

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub DetailReportContacts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportContacts.BeforePrint

            Dim ID As String = Nothing
            Dim ClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing

            Try

                ID = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ID

                ClientContactList = _ProductContacts(ID)

                BindingSourceClientContact.DataSource = ClientContactList

            Catch ex As Exception
                DetailReportContacts.DataSource = Nothing
            End Try

            If DetailReportContacts.DataSource Is Nothing OrElse ClientContactList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub CheckBox_NewBusiness_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBox_NewBusiness.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Checked As Boolean = False

            Try

                Product = LoadCurrentProduct()

                If Product IsNot Nothing AndAlso Product.Client IsNot Nothing Then

                    Checked = If(Product.Client.IsNewBusiness.GetValueOrDefault(0) = 1, True, False)

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_NewBusiness.Checked = Checked
            End Try

        End Sub
        Private Sub Label_ProductStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductStatus.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Status As String = ""

            Try

                Product = LoadCurrentProduct()

                If Product IsNot Nothing Then

                    Status = If(Product.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_ProductStatus.Text = Status
            End Try

        End Sub
        Private Sub LabelContact_Status_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelContact_Status.BeforePrint

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim Status As String = ""

            Try

                ClientContact = TryCast(Me.DetailReportContacts.GetCurrentRow, AdvantageFramework.Database.Entities.ClientContact)

                If ClientContact IsNot Nothing Then

                    Status = If(ClientContact.IsInactive.GetValueOrDefault(0) = 1, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                LabelContact_Status.Text = Status
            End Try

        End Sub
        Private Sub LabelBilling_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelBilling_CityStateZip.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim CityStateZip As String = ""

            Try

                Product = LoadCurrentProduct()

                If Product IsNot Nothing Then

                    CityStateZip = Product.BillingCity & ", " & Product.BillingState & "  " & Product.BillingZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelBilling_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub LabelContact_ContactName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelContact_ContactName.BeforePrint

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ContactName As String = ""

            Try

                ClientContact = TryCast(DetailReportContacts.GetCurrentRow, AdvantageFramework.Database.Entities.ClientContact)

                If ClientContact IsNot Nothing Then

                    ContactName = ClientContact.ToString

                End If

            Catch ex As Exception
                ContactName = ""
            Finally
                LabelContact_ContactName.Text = ContactName
            End Try

        End Sub
        Private Sub LabelStatement_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelStatement_CityStateZip.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim CityStateZip As String = ""

            Try

                Product = LoadCurrentProduct()

                If Product IsNot Nothing Then

                    CityStateZip = Product.StatementCity & ", " & Product.StatementState & "  " & Product.StatementZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelStatement_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub CheckBox_UseEstimateTimeBillingRate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBox_UseEstimateTimeBillingRate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBox_UseEstimateTimeBillingRate.Checked = CBool(Product.ProductionUseEstimateBillingRate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxProduction_AllowVendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxProduction_AllowVendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxProduction_AllowVendorDiscounts.Checked = CBool(Product.ProductionVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxProduction_ApprovedEstimateRequired_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxProduction_ApprovedEstimateRequired.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxProduction_ApprovedEstimateRequired.Checked = CBool(Product.ProductionApprovedEstimatedRequired.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxProduction_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxProduction_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxProduction_BillingSetupComplete.Checked = CBool(Product.ProductionBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxProduction_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxProduction_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxProduction_BillNet.Checked = CBool(Product.ProductionBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxProduction_ConsolidateFunctions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxProduction_ConsolidateFunctions.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxProduction_ConsolidateFunctions.Checked = CBool(Product.ProductionConsolidateFunctions.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.RadioPrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxRadio_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxRadio_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.RadioPrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxRadio_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxRadio_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_BillNet.Checked = CBool(Product.RadioBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_CommissionOnly.Checked = CBool(Product.RadioCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_BeforeBroadcastDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_BeforeBroadcastDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.RadioBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.RadioBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxRadio_BeforeBroadcastDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxRadio_AfterBroadcastDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_AfterBroadcastDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.RadioBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxRadio_AfterBroadcastDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxRadio_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.RadioBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxRadio_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxRadio_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_VendorDiscounts.Checked = CBool(Product.RadioVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_BillingSetupComplete.Checked = CBool(Product.RadioBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.TelevisionPrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxTV_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxTV_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.TelevisionPrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxTV_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxTV_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_BillNet.Checked = CBool(Product.TelevisionBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_CommissionOnly.Checked = CBool(Product.TelevisionCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_BeforeBroadcastDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_BeforeBroadcastDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.TelevisionBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.TelevisionBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxTV_BeforeBroadcastDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxTV_AfterBroadcastDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_AfterBroadcastDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.TelevisionBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxTV_AfterBroadcastDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxTV_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.TelevisionBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxTV_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxTV_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_VendorDiscounts.Checked = CBool(Product.TelevisionVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_BillingSetupComplete.Checked = CBool(Product.TelevisionBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_UseFlags.Checked = CBool(Product.RadioApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_LineNet.Checked = CBool(Product.RadioApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_NetCharge.Checked = CBool(Product.RadioApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_AddlCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_AddlCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_AddlCharge.Checked = CBool(Product.RadioApplyTaxAddlCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_Commission.Checked = CBool(Product.RadioApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_Rebate.Checked = CBool(Product.RadioApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxRadio_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxRadio_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxRadio_NetDiscount.Checked = CBool(Product.RadioApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_UseFlags.Checked = CBool(Product.TelevisionApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_LineNet.Checked = CBool(Product.TelevisionApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_NetCharge.Checked = CBool(Product.TelevisionApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_AddlCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_AddlCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_AddlCharge.Checked = CBool(Product.TelevisionApplyTaxAddlCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_Commission.Checked = CBool(Product.TelevisionApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_Rebate.Checked = CBool(Product.TelevisionApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxTV_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxTV_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxTV_NetDiscount.Checked = CBool(Product.TelevisionApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.MagazinePrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxMagazine_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxMagazine_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.MagazinePrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxMagazine_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxMagazine_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_BillNet.Checked = CBool(Product.MagazineBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_CommissionOnly.Checked = CBool(Product.MagazineCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_BeforeInsertionDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_BeforeInsertionDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.MagazineBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.MagazineBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxMagazine_BeforeInsertionDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxMagazine_AfterInsertionDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_AfterInsertionDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.MagazineBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxMagazine_AfterInsertionDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxMagazine_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.MagazineBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxMagazine_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxMagazine_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_VendorDiscounts.Checked = CBool(Product.MagazineVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_BillingSetupComplete.Checked = CBool(Product.MagazineBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_UseFlags.Checked = CBool(Product.MagazineApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_LineNet.Checked = CBool(Product.MagazineApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_NetCharge.Checked = CBool(Product.MagazineApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_AddlCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_AddlCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_AddlCharge.Checked = CBool(Product.MagazineApplyTaxAddlCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_Commission.Checked = CBool(Product.MagazineApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_Rebate.Checked = CBool(Product.MagazineApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxMagazine_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMagazine_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxMagazine_NetDiscount.Checked = CBool(Product.MagazineApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.NewspaperPrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxNewspaper_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxNewspaper_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.NewspaperPrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxNewspaper_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxNewspaper_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_BillNet.Checked = CBool(Product.NewspaperBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_CommissionOnly.Checked = CBool(Product.NewspaperCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_BeforeInsertionDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_BeforeInsertionDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.NewspaperBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.NewspaperBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxNewspaper_BeforeInsertionDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxNewspaper_AfterInsertionDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_AfterInsertionDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.NewspaperBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxNewspaper_AfterInsertionDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxNewspaper_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.NewspaperBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxNewspaper_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxNewspaper_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_VendorDiscounts.Checked = CBool(Product.NewspaperVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_BillingSetupComplete.Checked = CBool(Product.NewspaperBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_UseFlags.Checked = CBool(Product.NewspaperApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_LineNet.Checked = CBool(Product.NewspaperApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_NetCharge.Checked = CBool(Product.NewspaperApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_Commission.Checked = CBool(Product.NewspaperApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_Rebate.Checked = CBool(Product.NewspaperApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxNewspaper_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxNewspaper_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxNewspaper_NetDiscount.Checked = CBool(Product.NewspaperApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.InternetPrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxInternet_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxInternet_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.InternetPrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxInternet_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxInternet_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_BillNet.Checked = CBool(Product.InternetBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_CommissionOnly.Checked = CBool(Product.InternetCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_BeforeRunDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_BeforeRunDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.InternetBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.InternetBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxInternet_BeforeRunDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxInternet_AfterRunDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_AfterRunDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.InternetBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxInternet_AfterRunDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxInternet_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.InternetBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxInternet_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxInternet_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_VendorDiscounts.Checked = CBool(Product.InternetVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_BillingSetupComplete.Checked = CBool(Product.InternetBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_UseFlags.Checked = CBool(Product.InternetApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_LineNet.Checked = CBool(Product.InternetApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_NetCharge.Checked = CBool(Product.InternetApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_AddlCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_AddlCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_AddlCharge.Checked = CBool(Product.InternetApplyTaxAddlCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_Commission.Checked = CBool(Product.InternetApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_Rebate.Checked = CBool(Product.InternetApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxInternet_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxInternet_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxInternet_NetDiscount.Checked = CBool(Product.InternetApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_PreBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_PreBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.OutOfHomePrePostBill.GetValueOrDefault(0) <> 2 Then

                    CheckBoxOutofHome_PreBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxOutofHome_PostBill_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_PostBill.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.OutOfHomePrePostBill.GetValueOrDefault(0) = 2 Then

                    CheckBoxOutofHome_PostBill.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxOutofHome_BillNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_BillNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_BillNet.Checked = CBool(Product.OutOfHomeBillNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_CommissionOnly_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_CommissionOnly.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_CommissionOnly.Checked = CBool(Product.OutOfHomeCommissionOnly.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_BeforePostDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_BeforePostDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.OutOfHomeBillSetting.GetValueOrDefault(0) <> 2 AndAlso Product.OutOfHomeBillSetting.GetValueOrDefault(0) <> 3 Then

                    CheckBoxOutofHome_BeforePostDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxOutofHome_AfterPostDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_AfterPostDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.OutOfHomeBillSetting.GetValueOrDefault(0) = 2 Then

                    CheckBoxOutofHome_AfterPostDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxOutofHome_BeforeCloseDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_BeforeCloseDate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                If Product.OutOfHomeBillSetting.GetValueOrDefault(0) = 3 Then

                    CheckBoxOutofHome_BeforeCloseDate.Checked = True

                End If

            End If

        End Sub
        Private Sub CheckBoxOutofHome_VendorDiscounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_VendorDiscounts.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_VendorDiscounts.Checked = CBool(Product.OutOfHomeVendorDiscounts.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_BillingSetupComplete_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_BillingSetupComplete.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_BillingSetupComplete.Checked = CBool(Product.OutOfHomeBillingSetupComplete.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_UseFlags_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_UseFlags.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_UseFlags.Checked = CBool(Product.OutOfHomeApplyTaxUseFlags.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_LineNet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_LineNet.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_LineNet.Checked = CBool(Product.OutOfHomeApplyTaxLineNet.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_NetCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_NetCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_NetCharge.Checked = CBool(Product.OutOfHomeApplyTaxNetCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_AddlCharge_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_AddlCharge.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_AddlCharge.Checked = CBool(Product.OutOfHomeApplyTaxAddlCharge.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_Commission.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_Commission.Checked = CBool(Product.OutOfHomeApplyTaxCommission.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_Rebate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_Rebate.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_Rebate.Checked = CBool(Product.OutOfHomeApplyTaxRebate.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub CheckBoxOutofHome_NetDiscount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxOutofHome_NetDiscount.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = LoadCurrentProduct()

            If Product IsNot Nothing Then

                CheckBoxOutofHome_NetDiscount.Checked = CBool(Product.OutOfHomeApplyTaxNetDiscount.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub DetailReportAccountExecutives_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportAccountExecutives.BeforePrint

            Dim ID As String = Nothing
            Dim AccountExecutiveList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing

            Try

                ID = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ID

                AccountExecutiveList = _ProductAccountExecutives(ID)

                BindingSourceAccountExecutive.DataSource = AccountExecutiveList

            Catch ex As Exception
                DetailReportAccountExecutives.DataSource = Nothing
            End Try

            If DetailReportAccountExecutives.DataSource Is Nothing OrElse AccountExecutiveList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub CheckBox_IsDefaultAE_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBox_IsDefaultAE.BeforePrint

            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

            AccountExecutive = TryCast(Me.DetailReportAccountExecutives.GetCurrentRow, AdvantageFramework.Database.Entities.AccountExecutive)

            If AccountExecutive IsNot Nothing Then

                CheckBox_IsDefaultAE.Checked = CBool(AccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0))

            End If

        End Sub
        Private Sub LabelAccountExecutive_EmployeeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelAccountExecutive_EmployeeName.BeforePrint

            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

            AccountExecutive = TryCast(Me.DetailReportAccountExecutives.GetCurrentRow, AdvantageFramework.Database.Entities.AccountExecutive)

            If AccountExecutive IsNot Nothing Then

                LabelAccountExecutive_EmployeeName.Text = AccountExecutive.Employee.ToString

            End If

        End Sub
        Private Sub LabelAccountExecutive_Status_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelAccountExecutive_Status.BeforePrint

            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

            AccountExecutive = TryCast(Me.DetailReportAccountExecutives.GetCurrentRow, AdvantageFramework.Database.Entities.AccountExecutive)

            If AccountExecutive IsNot Nothing Then

                LabelAccountExecutive_Status.Text = If(AccountExecutive.IsInactive.GetValueOrDefault(0) = 1, "Inactive", "Active")

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
