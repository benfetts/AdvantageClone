Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderSubmitDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _PONumber As Integer = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property PONumber As Integer
            Get
                PONumber = _PONumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal PONumber As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            _PONumber = PONumber

            ' Add any initialization after the InitializeComponent() call.
            RadioButtonControlForm_High.ByPassUserEntryChanged = True
            RadioButtonControlForm_Highest.ByPassUserEntryChanged = True
            RadioButtonControlForm_Low.ByPassUserEntryChanged = True
            RadioButtonControlForm_Lowest.ByPassUserEntryChanged = True
            RadioButtonControlForm_Normal.ByPassUserEntryChanged = True

        End Sub
        Private Sub EnableOrDisableActions()

            
        End Sub
        Private Sub CreatePOReportForAttachment(ByVal PONumber As Integer, ByRef DocumentID As Integer)

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder) = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim FileName As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)

                If PurchaseOrder IsNot Nothing Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder)

                    DataSource.Add(PurchaseOrder)

                    ParameterDictionary("DataSource") = DataSource

                    PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Me.Session.UserCode)

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

                        If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.LocationID) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, PurchaseOrderPrintDefault.LocationID)

                            End Using

                            If Location IsNot Nothing Then

                                ParameterDictionary("DefaultLocation") = Location

                            End If

                        End If

                        If PurchaseOrderPrintDefault.ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code Then

                            ParameterDictionary("FooterAboveSignature") = True

                        Else

                            ParameterDictionary("FooterAboveSignature") = False

                        End If

                    End If

                    FileName = "Purchase_Order_" & AdvantageFramework.StringUtilities.PadWithCharacter(PONumber, 8, "0", True, True) & "_" & System.DateTime.Today.ToString("yyyyMd") & ".PDF"

                    If AdvantageFramework.Reporting.Reports.AddReportToDocumentRepository(Me.Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing, FileName, Nothing, Nothing, DocumentID) = False Then

                        DocumentID = Nothing

                    End If

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PONumber As Integer) As Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderSubmitDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSubmitDialog = Nothing

            PurchaseOrderSubmitDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSubmitDialog(PONumber)

            ShowFormDialog = PurchaseOrderSubmitDialog.ShowDialog()

            PONumber = PurchaseOrderSubmitDialog.PONumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderSubmitDialog_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.PurchaseOrders.CreatePOReportForAttachment, AddressOf CreatePOReportForAttachment

        End Sub
        Private Sub PurchaseOrderSubmitDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim POTotal As Decimal = Nothing
            Dim Loaded As Boolean = True
            Dim ErrorMessage As String = Nothing

            RadioButtonControlForm_Normal.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                If PurchaseOrder IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).POAmountRequired.GetValueOrDefault(0) = 1 Then

                        Try

                            POTotal = (From Entity In AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(DbContext, PONumber)
                                       Select Entity.LineTotal).Sum

                        Catch ex As Exception
                            POTotal = 0
                        End Try

                        If POTotal = Nothing OrElse POTotal = 0 Then

                            Loaded = False
                            ErrorMessage = "Purchase Order total must be greater than 0."

                        End If

                    End If

                Else

                    Loaded = False
                    ErrorMessage = "There was a problem loading the purchase order."

                End If

            End Using

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                Me.Close()

            End If

            AddHandler AdvantageFramework.PurchaseOrders.CreatePOReportForAttachment, AddressOf CreatePOReportForAttachment

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_GetApproval.Click

            'objects
            Dim PONumbers As Integer() = Nothing
            Dim QueryString As String = ""
            Dim PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Submitted As Boolean = False
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Submitting...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                    If PurchaseOrder IsNot Nothing Then

                        If RadioButtonControlForm_Highest.Checked Then

                            PriorityLevel = AlertSystem.PriorityLevels.Highest

                        ElseIf RadioButtonControlForm_High.Checked Then

                            PriorityLevel = AlertSystem.PriorityLevels.High

                        ElseIf RadioButtonControlForm_Normal.Checked Then

                            PriorityLevel = AlertSystem.PriorityLevels.Normal

                        ElseIf RadioButtonControlForm_Low.Checked Then

                            PriorityLevel = AlertSystem.PriorityLevels.Low

                        ElseIf RadioButtonControlForm_Lowest.Checked Then

                            PriorityLevel = AlertSystem.PriorityLevels.Lowest

                        Else

                            PriorityLevel = AlertSystem.PriorityLevels.Normal

                        End If

                        'send alert 
                        If AdvantageFramework.PurchaseOrders.SubmitForApproval(Me.Session, PurchaseOrder, PriorityLevel, ErrorMessage) Then

                            Submitted = True

                        ElseIf String.IsNullOrEmpty(ErrorMessage) Then

                            ErrorMessage = "There was a problem submitting the purchase order."

                        End If

                        If String.IsNullOrEmpty(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                        If Submitted Then

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading the purchase order.")

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace