Partial Public Class purchaseorder_approval
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _PONumber As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub CreatePOReportForAttachment(ByVal PONumber As Integer, ByRef DocumentID As Integer)

        'objects
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder) = Nothing
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim FileName As String = Nothing
        Dim ReportFormat As String = Nothing
        Dim PrintOptionsForActiveReports As String = ""
        Dim ReportViewer As popReportViewer = Nothing
        Dim IsActiveReport As Boolean = False

        Try

            PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, PONumber)

            If PurchaseOrder IsNot Nothing Then

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(_DbContext, _Session.UserCode)

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    ReportFormat = PurchaseOrderPrintDefault.ReportFormat

                    If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.LocationID) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, PurchaseOrderPrintDefault.LocationID)

                        End Using

                    End If

                End If

                If String.IsNullOrWhiteSpace(ReportFormat) Then

                    ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                End If

                If Not AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports)).Select(Function(EnumObject) EnumObject.Code).ToArray.Contains(ReportFormat) Then

                    IsActiveReport = True

                End If

                If IsActiveReport Then

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        PrintOptionsForActiveReports = String.Join(";", {PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0)}.ToArray)

                    End If

                    If Location IsNot Nothing Then

                        Session("LocationOverride") = Location
                        Session("POPrintLocationID") = Location.ID
                        Session("POPrintLocationPath") = Location.LogoPath
                        Session("POPrintLocationName") = Location.Name

                    Else

                        Session("LocationOverride") = Nothing
                        Session("POPrintLocationID") = "None"
                        Session("POPrintLocationPath") = ""
                        Session("POPrintLocationName") = ""

                    End If

                Else

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder)
                    DataSource.Add(PurchaseOrder)
                    ParameterDictionary("DataSource") = DataSource

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

                    End If

                    ParameterDictionary("DefaultLocation") = Location

                    If ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code Then

                        ParameterDictionary("FooterAboveSignature") = True

                    End If

                End If

                FileName = "Purchase_Order_" & AdvantageFramework.StringUtilities.PadWithCharacter(PONumber, 8, "0", True, True) & "_" & cEmployee.TimeZoneToday.ToString("yyyyMd") & ".PDF"

                If Not IsActiveReport Then

                    If AdvantageFramework.Reporting.Reports.AddReportToDocumentRepository(_Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing, FileName, Nothing, Nothing, DocumentID) = False Then

                        DocumentID = Nothing

                    End If

                Else

                    ReportViewer = New popReportViewer

                    DocumentID = ReportViewer.AddToDocumentRepository(Request.PhysicalApplicationPath & FileName, ReportFormat, PurchaseOrder.Number.ToString, "", "", "", "", 1, Request.PhysicalApplicationPath & "Images\logo_print.gif", PrintOptionsForActiveReports)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

#Region " Page Events "

    Private Sub purchaseorder_approval_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        Try

            If Not [String].IsNullOrWhiteSpace(Request.QueryString("PONum")) Then

                _PONumber = CInt(AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("PONum")))

            End If

        Catch ex As Exception
            _PONumber = Nothing
        End Try

    End Sub
    Private Sub purchaseorder_approval_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim POTotal As Decimal = Nothing

        If Not Me.IsPostBack Then

            PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, _PONumber)

            If PurchaseOrder IsNot Nothing Then

                If AdvantageFramework.Database.Procedures.Agency.Load(_DbContext).POAmountRequired.GetValueOrDefault(0) = 1 Then

                    Try

                        POTotal = (From Entity In AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(_DbContext, _PONumber)
                                   Select Entity.LineTotal).Sum

                    Catch ex As Exception
                        POTotal = 0
                    End Try

                    If POTotal = Nothing OrElse POTotal = 0 Then

                        Me.ShowMessage("Purchase Order total must be greater than 0.")
                        Me.CloseThisWindow()
                        Exit Sub

                    End If

                End If

            Else

                Me.ShowMessage("There was a problem loading the purchase order.")
                Me.CloseThisWindow()
                Exit Sub

            End If

        End If

    End Sub
    Private Sub purchaseorder_approval_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            _DbContext.Dispose()

            _DbContext = Nothing

        Catch ex As Exception

        End Try

        Try

            RemoveHandler AdvantageFramework.PurchaseOrders.CreatePOReportForAttachment, AddressOf CreatePOReportForAttachment

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        'objects
        Dim PONumbers As Integer() = Nothing
        Dim QueryString As String = ""
        Dim PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels = Nothing
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim Submitted As Boolean = False
        Dim ErrorMessage As String = ""

        PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, _PONumber)

        If PurchaseOrder IsNot Nothing Then

            AddHandler AdvantageFramework.PurchaseOrders.CreatePOReportForAttachment, AddressOf CreatePOReportForAttachment

            PriorityLevel = CType(CInt(rblPriority.SelectedValue), AdvantageFramework.AlertSystem.PriorityLevels)

            'send alert 
            If AdvantageFramework.PurchaseOrders.SubmitForApproval(_Session, PurchaseOrder, PriorityLevel, ErrorMessage) Then

                Submitted = True

            ElseIf String.IsNullOrEmpty(ErrorMessage) Then

                ErrorMessage = "There was a problem submitting the purchase order."

            End If

            If String.IsNullOrEmpty(ErrorMessage) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            End If

            If Submitted Then

                Session("POApproval") = True
                Session("PONumberApproval") = _PONumber

                Me.CloseThisWindowAndRefreshCaller("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit")
                'Me.CloseThisWindowAndRefreshCaller("purchaseorder.aspx")

            End If

        Else

            AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading the purchase order.")

        End If

    End Sub
    Private Sub CancelButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton2.Click

        Me.CloseThisWindow()

    End Sub

#End Region

#End Region

End Class
