Public Class PurchaseOrder_CopyWizard
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Private Enum ModifyPOGridControls
        RadComboBoxClient
        RadComboBoxDivision
        RadComboBoxProduct
        RadComboBoxJob
        RadComboBoxComponent
    End Enum

#End Region

#Region " Variables "

    Private _PONumber As Integer = 0
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Private Property SelectedPONumber As Integer
        Get
            Try
                SelectedPONumber = CInt(ViewState("PO_Copy_SelectedPONumber"))
            Catch ex As Exception
                SelectedPONumber = 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("PO_Copy_SelectedPONumber") = value
        End Set
    End Property
    Private Property SelectedPurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)
        Get
            Try

                SelectedPurchaseOrderDetails = ViewState("PO_Copy_SelectedPurchaseOrderDetails")

            Catch ex As Exception
                SelectedPurchaseOrderDetails = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)
            End Try
        End Get
        Set(value As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable))
            ViewState("PO_Copy_SelectedPurchaseOrderDetails") = value
        End Set
    End Property

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadPurchaseOrders()

        RadGridPurchaseOrders.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(_DbContext, _Session.UserCode, False, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                                            Where Entity.Number <> _PONumber
                                            Order By Entity.Number Descending
                                            Select Entity).ToList

    End Sub
    Private Sub LoadPurchaseOrderDetails()

        If Me.SelectedPONumber > 0 Then

            Dim PODetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            PODetails = Nothing
            PODetails = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(_DbContext, Me.SelectedPONumber).ToList

            Me.SelectedPurchaseOrderDetails = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetailsSerializableList(PODetails)

        Else

            Me.SelectedPurchaseOrderDetails = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)

        End If

        RadGridSelectPODetails.DataSource = Me.SelectedPurchaseOrderDetails

    End Sub
    Private Sub LoadPurchaseOrderDetailsToModify()

        'Objects
        Dim PurchaseOrderDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing

        If Me.SelectedPONumber > 0 AndAlso Me.SelectedPurchaseOrderDetails.Count > 0 Then

            PurchaseOrderDetailList = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetailsList(Me.SelectedPurchaseOrderDetails)

            AdvantageFramework.PurchaseOrders.PreparePurchaseOrderListForCopy(_DbContext, _Session.UserCode, PurchaseOrderDetailList, CheckBoxExcludeJobComponentInformation.Checked)

        Else

            PurchaseOrderDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

        End If

        RadGridModifyPODetails.DataSource = PurchaseOrderDetailList

    End Sub
    Private Sub CopyPurchaseOrderDetails()

        'objects
        Dim RadProgressContext As Telerik.Web.UI.RadProgressContext = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        RadProgressContext = Telerik.Web.UI.RadProgressContext.Current

        If True Then

            CopyPurchaseOrderDetails(RadProgressContext)

        Else

            CopyPurchaseOrderDetailsSimulator(RadProgressContext)

        End If

        Me.SelectedPurchaseOrderDetails.Clear()

        StringBuilder = New System.Text.StringBuilder
        StringBuilder.AppendLine("<script type='text/javascript'>")
        StringBuilder.AppendLine("progressUpdateComplete();")
        StringBuilder.AppendLine("</script>")

        RegisterStartupScript("PoCopyComplete", StringBuilder.ToString())

    End Sub
    Private Sub CopyPurchaseOrderDetails(ByVal RadProgressContext As Telerik.Web.UI.RadProgressContext)

        'objects
        Dim Total As Integer = Nothing
        Dim PurchaseOrderDetailToCopy As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing

        PurchaseOrderDetails = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetailsList(Me.SelectedPurchaseOrderDetails)

        If PurchaseOrderDetails IsNot Nothing Then

            Total = Me.SelectedPurchaseOrderDetails.Count - 1

            RadProgressContext.SecondaryTotal = Total

            For I = 0 To Total

                PurchaseOrderDetailToCopy = Nothing

                Try

                    PurchaseOrderDetailToCopy = PurchaseOrderDetails(I)

                Catch ex As Exception
                    PurchaseOrderDetailToCopy = Nothing
                End Try

                If PurchaseOrderDetailToCopy IsNot Nothing Then

                    AdvantageFramework.PurchaseOrders.CopyPurchaseOrderDetail(_DbContext, _PONumber, PurchaseOrderDetailToCopy)

                End If

                With RadProgressContext

                    .SecondaryValue = I
                    .SecondaryPercent = I

                End With

                If Not Response.IsClientConnected Then

                    Exit Sub

                End If

            Next

        End If

    End Sub
    Private Sub CopyPurchaseOrderDetailsSimulator(ByVal RadProgressContext As Telerik.Web.UI.RadProgressContext)

        'this method simulates a long process
        Const Total As Integer = 100

        RadProgressContext.SecondaryTotal = Total

        For I = 0 To Total

            With RadProgressContext

                .SecondaryValue = I
                .SecondaryPercent = I

            End With

            If Not Response.IsClientConnected Then

                Exit Sub

            End If

            RadProgressContext.TimeEstimated = (Total - I) * 100

            System.Threading.Thread.Sleep(100)

        Next

    End Sub
    Private Function ValidateStep(ByVal RadWizardStep As Telerik.Web.UI.RadWizardStep) As Boolean

        'objects
        Dim StepIsValid As Boolean = False

        If RadWizardStep Is RadWizardStepSelectPO Then

            StepIsValid = ValidateSelectPOStep()

        ElseIf RadWizardStep Is RadWizardStepSelectPODetails Then

            StepIsValid = ValidateSelectPODetailsStep()

        ElseIf RadWizardStep Is RadWizardStepModifyPODetails Then

            StepIsValid = ValidateSelectModifyPODetailsStep()

        Else

            StepIsValid = True

        End If

        ValidateStep = StepIsValid

    End Function
    Private Function ValidateSelectPOStep() As Boolean

        'objects
        Dim StepIsValid As Boolean = True

        Try

            If RadGridPurchaseOrders.MasterTableView.GetSelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).Count <> 1 Then

                Me.ShowMessage("Please select a Purchase Order to continue.")
                StepIsValid = False

            End If

        Catch ex As Exception
            StepIsValid = False
        Finally
            ValidateSelectPOStep = StepIsValid
        End Try

    End Function
    Private Function ValidateSelectPODetailsStep() As Boolean

        'objects
        Dim StepIsValid As Boolean = True

        Try

            If RadGridSelectPODetails.MasterTableView.GetSelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).Count <= 0 Then

                Me.ShowMessage("Please select at lease one Purchase Order detail to continue.")
                StepIsValid = False

            End If

        Catch ex As Exception
            StepIsValid = False
        Finally
            ValidateSelectPODetailsStep = StepIsValid
        End Try

    End Function
    Private Function ValidateSelectModifyPODetailsStep() As Boolean

        'objects
        Dim StepIsValid As Boolean = True
        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing
        Dim JobNumber As Integer? = Nothing
        Dim JobComponentNumber As Short? = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable = Nothing
        Dim IsValid As Boolean = True
        Dim ErrorText As String = Nothing
        Dim Hashtable As System.Collections.Hashtable = Nothing

        Try

            If RadGridModifyPODetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem).Count <= 0 Then

                Me.ShowMessage("Please select at lease one Purchase Order detail to continue.")
                StepIsValid = False

            Else

                For Each GridDataItem In RadGridModifyPODetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    ClientCode = Nothing
                    DivisionCode = Nothing
                    ProductCode = Nothing
                    JobNumber = Nothing
                    JobComponentNumber = Nothing
                    PurchaseOrderDetail = Nothing

                    Hashtable = New System.Collections.Hashtable

                    RadGridModifyPODetails.MasterTableView.ExtractValuesFromItem(Hashtable, GridDataItem)

                    If String.IsNullOrWhiteSpace(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)) = False Then

                        ClientCode = Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)

                    End If

                    If String.IsNullOrWhiteSpace(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)) = False Then

                        DivisionCode = Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)

                    End If

                    If String.IsNullOrWhiteSpace(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)) = False Then

                        ProductCode = Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)

                    End If

                    If String.IsNullOrWhiteSpace(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString)) = False Then

                        JobNumber = CInt(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString))

                    End If

                    If String.IsNullOrWhiteSpace(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString)) = False Then

                        JobComponentNumber = CShort(Hashtable(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString))

                    End If

                    Try

                        PurchaseOrderDetail = Me.SelectedPurchaseOrderDetails.Single(Function(PODtl) PODtl.LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber")))

                    Catch ex As Exception
                        PurchaseOrderDetail = Nothing
                    End Try

                    If PurchaseOrderDetail IsNot Nothing Then

                        With PurchaseOrderDetail

                            .ClientCode = ClientCode
                            .DivisionCode = DivisionCode
                            .ProductCode = ProductCode
                            .JobNumber = JobNumber
                            .JobComponentNumber = JobComponentNumber

                            If .JobNumber.GetValueOrDefault(0) > 0 AndAlso .JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                .JobComponentID = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(_DbContext, .JobNumber.GetValueOrDefault(0), .JobComponentNumber.GetValueOrDefault(0)).ID

                            Else

                                .JobComponentID = Nothing

                            End If

                        End With

                    End If

                Next

                Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing

                PurchaseOrderDetails = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetailsList(Me.SelectedPurchaseOrderDetails)

                If PurchaseOrderDetails IsNot Nothing Then

                    For Each PurachaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail In PurchaseOrderDetails

                        PurachaseOrderDetail.DbContext = _DbContext

                        ErrorText = PurachaseOrderDetail.ValidateEntity(IsValid)

                        If IsValid = False Then

                            Me.ShowMessage(ErrorText)
                            StepIsValid = False
                            Exit For

                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            StepIsValid = False
        Finally
            ValidateSelectModifyPODetailsStep = StepIsValid
        End Try

    End Function
    Private Sub SetupGridColumns()

        'objects
        Dim DataField As String = Nothing
        Dim EntityDataField As String = Nothing
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        For Each GridColumn In RadGridModifyPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

            If TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                DataField = TryCast(GridColumn, Telerik.Web.UI.GridBoundColumn).DataField

            ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridTemplateColumn Then

                DataField = TryCast(GridColumn, Telerik.Web.UI.GridTemplateColumn).DataField

            End If

            If String.IsNullOrWhiteSpace(DataField) = False Then

                Try

                    If DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                        EntityDataField = AdvantageFramework.Database.Entities.PurchaseOrderDetail.Properties.GLACode.ToString

                    Else

                        EntityDataField = DataField

                    End If

                    If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Database.Entities.PurchaseOrderDetail.Properties), False).Any(Function(Name) Name = EntityDataField) = True Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.PurchaseOrderDetail), EntityDataField)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Client), AdvantageFramework.Database.Entities.Client.Properties.Code.ToString)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Division), AdvantageFramework.Database.Entities.Division.Properties.Code.ToString)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Product), AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)

                    End If

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

            End If

            If TypeOf GridColumn Is Telerik.Web.UI.GridNumericColumn Then

                With DirectCast(GridColumn, Telerik.Web.UI.GridNumericColumn)

                    .ItemStyle.Width = Unit.Pixel(80)
                    .HeaderStyle.Width = Unit.Pixel(80)
                    .ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    .AllowRounding = True
                    .NumericType = Telerik.Web.UI.NumericType.Number

                    If PropertyDescriptor IsNot Nothing Then

                        .DecimalDigits = CInt(AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor))

                    Else

                        .DecimalDigits = 2

                    End If

                    If EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                        EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString Then

                        .DataFormatString = "{0:F0}"

                    Else

                        .DataFormatString = "{0:N" & .DecimalDigits.ToString & "}"

                    End If

                End With

            ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                If GridColumn.IsEditable = True Then

                    With TryCast(GridColumn, Telerik.Web.UI.GridBoundColumn)

                        If PropertyDescriptor IsNot Nothing Then

                            .MaxLength = CInt(AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor))

                        End If

                    End With

                End If

            End If

        Next

    End Sub

#Region "  Form Event Handlers "

    Protected Sub PurchaseOrder_CopyWizard_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        HiddenFieldSecMod.Value = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        QueryString = New AdvantageFramework.Web.QueryString

        QueryString = QueryString.FromCurrent

        Try

            _PONumber = QueryString.PurchaseOrderNumber

        Catch ex As Exception
            _PONumber = 0
        End Try

        SetupGridColumns()

    End Sub
    Protected Sub PurchaseOrder_CopyWizard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim RadProgressContext As Telerik.Web.UI.RadProgressContext = Nothing
        Dim IsLocked As Boolean = False
        Dim CanUserEdit As Boolean = True
        Dim CanUserInsert As Boolean = True

        Me.PageTitle = "Purchase Order"

        If Not Me.IsPostBack Then

            If _PONumber > 0 Then

                If AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, _PONumber) IsNot Nothing Then

                    AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(_DbContext, _PONumber, "", False, False, False, IsLocked, "")

                    If IsLocked Then

                        Me.ShowMessage("Purchase Order " & _PONumber & " is locked and cannot be modified.")
                        Me.CloseThisWindow()

                    Else

                        CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
                        CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

                        If CanUserEdit = False OrElse CanUserInsert = False Then

                            Me.ShowMessage("Access denied!")
                            Me.CloseThisWindow()

                        End If

                    End If

                End If

            End If

        End If

        Try

            RadProgressContext = Telerik.Web.UI.RadProgressContext.Current

            RadProgressContext.PrimaryTotal = 0
            RadProgressContext.PrimaryValue = 0
            RadProgressContext.PrimaryPercent = 0

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub PurchaseOrder_CopyWizard_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        Try

            _DbContext.Dispose()

            _DbContext = Nothing

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadWizardPurchaseOrderCopy_ActiveStepChanged(sender As Object, e As EventArgs) Handles RadWizardPurchaseOrderCopy.ActiveStepChanged

        If RadWizardPurchaseOrderCopy.ActiveStep Is RadWizardStepSelectPO Then

            RadGridPurchaseOrders.DataSource = Nothing
            RadGridPurchaseOrders.Rebind()

        ElseIf RadWizardPurchaseOrderCopy.ActiveStep Is RadWizardStepSelectPODetails Then

            RadGridSelectPODetails.DataSource = Nothing
            RadGridSelectPODetails.Rebind()

        ElseIf RadWizardPurchaseOrderCopy.ActiveStep Is RadWizardStepModifyPODetails Then

            RadGridModifyPODetails.DataSource = Nothing
            RadGridModifyPODetails.Rebind()

        End If

    End Sub
    Private Sub RadWizardPurchaseOrderCopy_FinishButtonClick(sender As Object, e As Telerik.Web.UI.WizardEventArgs) Handles RadWizardPurchaseOrderCopy.FinishButtonClick

        Me.CloseThisWindowAndRefreshCaller("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit")

    End Sub
    Private Sub RadWizardPurchaseOrderCopy_NextButtonClick(sender As Object, e As Telerik.Web.UI.WizardEventArgs) Handles RadWizardPurchaseOrderCopy.NextButtonClick

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        If e.CurrentStepIndex < e.NextStepIndex Then 'moving forward

            If ValidateStep(e.CurrentStep) Then

                If e.CurrentStep Is RadWizardStepSelectPO Then

                    Try

                        Me.SelectedPONumber = CInt(RadGridPurchaseOrders.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).First.GetDataKeyValue("Number"))

                    Catch ex As Exception

                    End Try

                ElseIf e.CurrentStep Is RadWizardStepSelectPODetails Then

                    Try

                        Me.SelectedPurchaseOrderDetails = (From Item In Me.SelectedPurchaseOrderDetails
                                                           Where RadGridSelectPODetails.MasterTableView.GetSelectedItems().Select(Function(GridDataItem) CInt(GridDataItem.GetDataKeyValue("LineNumber"))).ToArray.Contains(Item.LineNumber)
                                                           Select Item).ToList

                    Catch ex As Exception

                    End Try

                ElseIf e.CurrentStep Is RadWizardStepModifyPODetails Then

                    For Each RadWizardStep In RadWizardPurchaseOrderCopy.WizardSteps.OfType(Of Telerik.Web.UI.RadWizardStep)()

                        If RadWizardStep IsNot RadWizardStepFinal Then

                            RadWizardStep.AllowReturn = False

                        End If

                    Next

                End If

            Else

                RadWizardPurchaseOrderCopy.ActiveStepIndex = e.CurrentStepIndex

            End If

        End If

    End Sub

#Region " -- Select PO -- "

    Private Sub RadGridPurchaseOrders_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridPurchaseOrders.NeedDataSource

        LoadPurchaseOrders()

    End Sub
    Private Sub RadGridPurchaseOrders_PreRender(sender As Object, e As EventArgs) Handles RadGridPurchaseOrders.PreRender

        'objects
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing

        For Each FilterItem In RadGridPurchaseOrders.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.FilteringItem)

            Try

                RadComboBox = FilterItem.FindControl("RadComboBoxIsCompleteFilter")

                If RadComboBox IsNot Nothing Then

                    RadComboBox.SelectedValue = RadGridPurchaseOrders.MasterTableView.GetColumnSafe("GridTemplateColumnIsComplete").CurrentFilterValue

                End If

            Catch ex As Exception

            End Try

            Try

                RadComboBox = FilterItem.FindControl("RadComboBoxIsCompleteFilter")

                If RadComboBox IsNot Nothing Then

                    RadComboBox.SelectedValue = RadGridPurchaseOrders.MasterTableView.GetColumnSafe("GridTemplateColumnIsComplete").CurrentFilterValue

                End If

            Catch ex As Exception

            End Try

        Next

    End Sub

#End Region

#Region " -- Select Details -- "

    Private Sub RadGridSelectPODetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSelectPODetails.NeedDataSource

        LoadPurchaseOrderDetails()

    End Sub

#End Region

#Region " -- Modify Details -- "

    Private Sub RadGridModifyPODetails_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridModifyPODetails.ItemCreated

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

                GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                For Each GridNumericColumn In RadGridModifyPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn).Where(Function(GridCol) GridCol.Visible = True AndAlso GridCol.IsEditable = True)

                    RadNumericTextBox = GridDataItem(GridNumericColumn.UniqueName).Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox).FirstOrDefault

                    If RadNumericTextBox IsNot Nothing Then

                        RadNumericTextBox.Width = GridNumericColumn.ItemStyle.Width
                        RadNumericTextBox.NumberFormat.DecimalDigits = GridNumericColumn.DecimalDigits
                        RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
                        RadNumericTextBox.EnabledStyle.HorizontalAlign = HorizontalAlign.Right

                        If GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString Then

                            RadNumericTextBox.Attributes.Add("adv-lookup", GridNumericColumn.DataField.Replace("Number", ""))
                            RadNumericTextBox.NumberFormat.GroupSeparator = ""

                        End If

                        If GridNumericColumn.DecimalDigits = 0 Then

                            RadNumericTextBox.ClientEvents.OnKeyPress = "RadNumericTextBoxPreventDecimal"

                        End If

                    End If

                Next

                For Each GridBoundColumn In RadGridModifyPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).Where(Function(GridCol) GridCol.Visible = True AndAlso GridCol.IsEditable = True)

                    TextBox = GridDataItem(GridBoundColumn.UniqueName).Controls.OfType(Of System.Web.UI.WebControls.TextBox).FirstOrDefault

                    If TextBox IsNot Nothing Then

                        TextBox.MaxLength = GridBoundColumn.MaxLength

                        If GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString Then

                            TextBox.Width = Unit.Pixel(90)

                            TextBox.Attributes.Add("adv-lookup", GridBoundColumn.DataField.Replace("Code", ""))

                        End If

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub RadGridModifyPODetails_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridModifyPODetails.ItemDataBound

        'objects
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

            GridDataItem = e.Item

            If TypeOf GridDataItem.DataItem Is AdvantageFramework.Database.Classes.PurchaseOrderDetail Then

                PurchaseOrderDetail = TryCast(GridDataItem.DataItem, AdvantageFramework.Database.Classes.PurchaseOrderDetail)

                If PurchaseOrderDetail IsNot Nothing Then



                End If

            End If

        End If

    End Sub
    Private Sub RadGridModifyPODetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridModifyPODetails.NeedDataSource

        LoadPurchaseOrderDetailsToModify()

    End Sub
    Private Sub RadGridModifyPODetails_PreRender(sender As Object, e As EventArgs) Handles RadGridModifyPODetails.PreRender

        'objects
        Dim CanEdit As Boolean = Nothing
        Dim Rebind As Boolean = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        For Each Item In RadGridModifyPODetails.MasterTableView.Items

            CanEdit = True

            If TypeOf Item Is Telerik.Web.UI.GridEditableItem Then

                GridDataItem = CType(Item, Telerik.Web.UI.GridDataItem)

                If GridDataItem.Edit = False Then

                    Rebind = True

                    GridDataItem.Edit = True

                End If

            End If

        Next

        If Rebind Then

            RadGridModifyPODetails.Rebind()

        End If

    End Sub

#End Region

#Region " -- Final -- "

    Protected Sub RadButtonDoCopy_Click(sender As Object, e As EventArgs)

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        RadButtonDoCopy.AutoPostBack = False 'allow click once!!

        StringBuilder = New Text.StringBuilder

        StringBuilder.AppendLine("<script type='text/javascript'>")
        StringBuilder.AppendLine("$('.RadUploadProgressArea').addClass('RadUploadProgressAreaVisible');")
        StringBuilder.AppendLine("</script>")

        Me.RegisterStartupScript("PO_Copy_ShowProgressAlways", StringBuilder.ToString)

        CopyPurchaseOrderDetails()

    End Sub

#End Region

#End Region

#End Region

End Class
