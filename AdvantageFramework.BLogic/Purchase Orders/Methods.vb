Namespace PurchaseOrders

    <HideModuleName()>
    Public Module Methods

        Public Event CreatePOReportForAttachment(ByVal PONumber As Integer, ByRef DocumentID As Integer)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ApprovalStatus As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Pending")>
            Pending = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Approved")>
            Approved = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Denied")>
            Denied = 3
        End Enum

        Public Enum FooterTypes
            AgencyDefined
            StandardComment
            Custom
        End Enum

#End Region

#Region " Variables "

        Private _AllowedProcessControls As Integer() = {1, 3, 4, 8, 9}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadPurchaseOrderDetailsList(ByRef PurchaseOrderDetailsWebSerializable As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)) As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Try

                If PurchaseOrderDetailsWebSerializable IsNot Nothing AndAlso PurchaseOrderDetailsWebSerializable.Count > 0 Then

                    Dim NewItem As AdvantageFramework.Database.Classes.PurchaseOrderDetail

                    For Each POD As AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable In PurchaseOrderDetailsWebSerializable

                        NewItem = New Database.Classes.PurchaseOrderDetail

                        NewItem.PONumber = POD.PONumber
                        NewItem.LineNumber = POD.LineNumber
                        NewItem.LineDescription = POD.LineDescription
                        NewItem.DetailDescription = POD.DetailDescription
                        NewItem.Instructions = POD.Instructions
                        NewItem.ClientCode = POD.ClientCode
                        NewItem.ClientName = POD.ClientName
                        NewItem.DivisionCode = POD.DivisionCode
                        NewItem.DivisionName = POD.DivisionName
                        NewItem.ProductCode = POD.ProductCode
                        NewItem.ProductDescription = POD.ProductDescription
                        NewItem.JobNumber = POD.JobNumber
                        NewItem.JobDescription = POD.JobDescription
                        NewItem.JobComponentNumber = POD.JobComponentNumber
                        NewItem.JobComponentID = POD.JobComponentID
                        NewItem.JobComponentDescription = POD.JobComponentDescription
                        NewItem.FunctionCode = POD.FunctionCode
                        NewItem.FunctionDescription = POD.FunctionDescription
                        NewItem.GeneralLedgerCode = POD.GeneralLedgerCode
                        NewItem.Quantity = POD.Quantity
                        NewItem.Rate = POD.Rate
                        NewItem.ExtendedAmount = POD.ExtendedAmount
                        NewItem.CommissionPercent = POD.CommissionPercent
                        NewItem.TaxPercent = POD.TaxPercent
                        NewItem.ExtendedMarkupAmount = POD.ExtendedMarkupAmount
                        NewItem.LineTotal = POD.LineTotal
                        NewItem.BillingApprovalID = POD.BillingApprovalID
                        NewItem.UseCPM = POD.UseCPM
                        NewItem.IsAttachedToAP = POD.IsAttachedToAP
                        NewItem.CanDelete = POD.CanDelete
                        NewItem.IsComplete = POD.IsComplete
                        NewItem.BalanceNet = POD.BalanceNet
                        NewItem.POUsed = POD.POUsed
                        NewItem.EstimateBudgetNet = POD.EstimateBudgetNet
                        NewItem.LockedByJobComp = POD.LockedByJobComp

                        list.Add(NewItem)
                        NewItem = Nothing

                    Next

                End If

            Catch ex As Exception
                Return Nothing
            End Try

            Return list

        End Function
        Public Function LoadPurchaseOrderDetailsSerializableList(ByRef PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)) As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable)

            Try

                If PurchaseOrderDetails IsNot Nothing AndAlso PurchaseOrderDetails.Count > 0 Then

                    Dim NewItem As AdvantageFramework.Database.Classes.PurchaseOrderDetailWebSerializable

                    For Each POD As AdvantageFramework.Database.Classes.PurchaseOrderDetail In PurchaseOrderDetails

                        NewItem = New Database.Classes.PurchaseOrderDetailWebSerializable

                        NewItem.PONumber = POD.PONumber
                        NewItem.LineNumber = POD.LineNumber
                        NewItem.LineDescription = POD.LineDescription
                        NewItem.DetailDescription = POD.DetailDescription
                        NewItem.Instructions = POD.Instructions
                        NewItem.ClientCode = POD.ClientCode
                        NewItem.ClientName = POD.ClientName
                        NewItem.DivisionCode = POD.DivisionCode
                        NewItem.DivisionName = POD.DivisionName
                        NewItem.ProductCode = POD.ProductCode
                        NewItem.ProductDescription = POD.ProductDescription
                        NewItem.JobNumber = POD.JobNumber
                        NewItem.JobDescription = POD.JobDescription
                        NewItem.JobComponentNumber = POD.JobComponentNumber
                        NewItem.JobComponentID = POD.JobComponentID
                        NewItem.JobComponentDescription = POD.JobComponentDescription
                        NewItem.FunctionCode = POD.FunctionCode
                        NewItem.FunctionDescription = POD.FunctionDescription
                        NewItem.GeneralLedgerCode = POD.GeneralLedgerCode
                        NewItem.Quantity = POD.Quantity
                        NewItem.Rate = POD.Rate
                        NewItem.ExtendedAmount = POD.ExtendedAmount
                        NewItem.CommissionPercent = POD.CommissionPercent
                        NewItem.TaxPercent = POD.TaxPercent
                        NewItem.ExtendedMarkupAmount = POD.ExtendedMarkupAmount
                        NewItem.LineTotal = POD.LineTotal
                        NewItem.BillingApprovalID = POD.BillingApprovalID
                        NewItem.UseCPM = POD.UseCPM
                        NewItem.IsAttachedToAP = POD.IsAttachedToAP
                        NewItem.CanDelete = POD.CanDelete
                        NewItem.IsComplete = POD.IsComplete
                        NewItem.BalanceNet = POD.BalanceNet
                        NewItem.POUsed = POD.POUsed
                        NewItem.EstimateBudgetNet = POD.EstimateBudgetNet
                        NewItem.LockedByJobComp = POD.LockedByJobComp

                        list.Add(NewItem)
                        NewItem = Nothing

                    Next

                End If

            Catch ex As Exception
                Return Nothing
            End Try

            Return list

        End Function

        Public Function LoadPurchaseOrderDisplayNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderNumber As Integer) As String

            'objects
            Dim DisplayPONumber As String = ""
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                DisplayPONumber = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [dbo].[advfn_get_po_display_num]({0})", PurchaseOrderNumber)).SingleOrDefault

                DisplayPONumber = DisplayPONumber.Replace(" ", "")

            Catch ex As Exception
                DisplayPONumber = ""
            Finally
                LoadPurchaseOrderDisplayNumber = DisplayPONumber
            End Try

        End Function
        Public Sub LoadPurchaseOrderInformation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderNumber As Integer,
                                                ByRef DisplayPONumber As String, Optional ByRef AllowPrint As Boolean = False,
                                                Optional ByRef AllowCancelApproval As Boolean = False, Optional ByRef AllowRevision As Boolean = False,
                                                Optional ByRef POLocked As Boolean = False, Optional ByRef DisplayMessage As String = "")

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PurchaseOrderNumber)

            LoadPurchaseOrderInformation(DbContext, PurchaseOrder, DisplayPONumber, AllowPrint, AllowCancelApproval, AllowRevision, POLocked, DisplayMessage)

        End Sub
        Public Sub LoadPurchaseOrderInformation(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder,
                                                ByRef DisplayPONumber As String, Optional ByRef AllowPrint As Boolean = False,
                                                Optional ByRef AllowCancelApproval As Boolean = False, Optional ByRef AllowRevision As Boolean = False,
                                                Optional ByRef POLocked As Boolean = False, Optional ByRef DisplayMessage As String = "", Optional ByRef WebvantageHeaderMessage As String = "")

            'objects
            Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing

            Try

                If PurchaseOrder IsNot Nothing Then

                    DisplayPONumber = LoadPurchaseOrderDisplayNumber(DbContext, PurchaseOrder.Number)

                    If PurchaseOrder.IsComplete.GetValueOrDefault(0) Then

                        POLocked = True
                        DisplayMessage = "P.O. is complete. No further editing permitted."
                        AllowPrint = True

                    Else

                        If AdvantageFramework.Database.Procedures.POApproval.LoadByPurchaseOrderNumber(DbContext, PurchaseOrder.Number).Count > 0 Then

                            Select Case PurchaseOrder.ApprovalFlag.GetValueOrDefault(0)

                                Case 0, 1 ' pending

                                    AllowPrint = False
                                    AllowCancelApproval = True
                                    AllowRevision = False
                                    POLocked = True
                                    WebvantageHeaderMessage = "Pending"

                                Case 2 'approved

                                    AllowPrint = True
                                    AllowCancelApproval = True
                                    AllowRevision = False
                                    POLocked = True
                                    DisplayMessage = "Approved"
                                    WebvantageHeaderMessage = "Approved"

                                Case 3 'denied

                                    AllowPrint = True
                                    AllowCancelApproval = False
                                    AllowRevision = True
                                    POLocked = False
                                    WebvantageHeaderMessage = "Denied"

                                Case Else

                                    AllowPrint = True
                                    AllowCancelApproval = False
                                    AllowRevision = True
                                    POLocked = False

                            End Select

                        Else

                            If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).POAmountRequired.GetValueOrDefault(0) = 1 Then

                                Try

                                    PurchaseOrderDetails = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, PurchaseOrder.Number).ToList

                                Catch ex As Exception
                                    PurchaseOrderDetails = Nothing
                                End Try

                                If PurchaseOrderDetails Is Nothing OrElse PurchaseOrderDetails.Count = 0 OrElse
                                   PurchaseOrderDetails.Select(Function(PODetail) PODetail.ExtendedAmount.GetValueOrDefault(0)).Sum = 0 Then

                                    AllowPrint = False
                                    AllowCancelApproval = False
                                    AllowRevision = True
                                    POLocked = False

                                Else

                                    If String.IsNullOrEmpty(PurchaseOrder.PurchaseOrderApprovalRuleCode) = False Then

                                        If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode).PurchaseOrderLimit.GetValueOrDefault(0) = 0 Then

                                            AllowPrint = True
                                            AllowCancelApproval = False
                                            AllowRevision = True
                                            POLocked = False

                                        Else

                                            If PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 0 AndAlso PurchaseOrder.IsPrinted.GetValueOrDefault(0) = 0 Then

                                                AllowPrint = True
                                                AllowCancelApproval = False
                                                AllowRevision = True
                                                POLocked = False

                                            ElseIf PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 0 AndAlso PurchaseOrder.IsPrinted.GetValueOrDefault(0) = 1 Then

                                                AllowPrint = True
                                                AllowCancelApproval = False
                                                AllowRevision = True
                                                POLocked = False

                                            ElseIf PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 1 Then

                                                AllowPrint = True
                                                AllowCancelApproval = False
                                                AllowRevision = True
                                                POLocked = False

                                            End If

                                        End If

                                    Else

                                        AllowPrint = True
                                        AllowCancelApproval = False
                                        AllowRevision = True
                                        POLocked = False

                                    End If

                                End If

                            Else

                                If String.IsNullOrEmpty(PurchaseOrder.PurchaseOrderApprovalRuleCode) = False Then

                                    If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode).PurchaseOrderLimit.GetValueOrDefault(0) = 0 Then

                                        AllowPrint = True
                                        AllowCancelApproval = False
                                        AllowRevision = True
                                        POLocked = False

                                    Else

                                        If PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 0 AndAlso PurchaseOrder.IsPrinted.GetValueOrDefault(0) = 0 Then

                                            AllowPrint = True
                                            AllowCancelApproval = False
                                            AllowRevision = True
                                            POLocked = False

                                        ElseIf PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 0 AndAlso PurchaseOrder.IsPrinted.GetValueOrDefault(0) = 1 Then

                                            AllowPrint = True
                                            AllowCancelApproval = False
                                            AllowRevision = True
                                            POLocked = False

                                        ElseIf PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 1 Then

                                            AllowPrint = True
                                            AllowCancelApproval = False
                                            AllowRevision = True
                                            POLocked = False

                                        End If

                                    End If

                                Else

                                    AllowPrint = True
                                    AllowCancelApproval = False
                                    AllowRevision = True
                                    POLocked = False

                                End If

                            End If

                        End If

                    End If

                    If CBool(PurchaseOrder.IsVoid.GetValueOrDefault(0)) = True Then

                        If PurchaseOrder.ApprovalFlag.GetValueOrDefault(0) = 3 Then

                            DisplayMessage = "Denied."

                        Else

                            If DisplayMessage <> "" Then

                                DisplayMessage = "Void."

                            Else

                                DisplayMessage = "Void. " & DisplayMessage

                            End If

                            POLocked = True
                            AllowPrint = False

                        End If

                    End If

                Else

                    DisplayPONumber = "(New)"
                    AllowPrint = False
                    AllowCancelApproval = False
                    AllowRevision = False
                    POLocked = False

                End If

            Catch ex As Exception
                DisplayMessage = "Error loading purchase order information."
            End Try

        End Sub
        Public Function Void(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder) As Boolean

            'objects
            Dim Voided As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                PurchaseOrder.VoidDate = System.DateTime.Now
                PurchaseOrder.VoidedByUserCode = DbContext.UserCode
                PurchaseOrder.IsVoid = 1

                Voided = AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder)

            Catch ex As Exception
                Voided = False
            Finally
                Void = Voided
            End Try

        End Function
        Public Function Revise(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder) As Boolean

            'objects
            Dim Revised As Boolean = False

            Try

                PurchaseOrder.Revision = PurchaseOrder.Revision.GetValueOrDefault(0) + 1

                Revised = AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder)

            Catch ex As Exception
                Revised = False
            Finally
                Revise = Revised
            End Try

        End Function
        Public Function Copy(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CopyFromPONumber As Integer, ByVal UserCode As String,
                             ByVal PODate As Date, ByVal DueDate As Date, ByVal ChangeToEmployeeCode As String, ByVal CopyMemos As Boolean, ByVal POApprovalRuleCode As String,
                             ByRef NewPONumber As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim VendorCode As String = Nothing
            Dim VendorContactCode As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim PODescription As String = Nothing
            Dim NewNumber As Integer = Nothing
            Dim Instructions As String = Nothing
            Dim Delivery As String = Nothing
            Dim Footer As String = Nothing
            Dim POLimit As Decimal = Nothing
            Dim POTotal As Decimal = Nothing
            Dim CopyFromPurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim NewPurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim NewPurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                CopyFromPurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, CopyFromPONumber)

                If CopyFromPurchaseOrder IsNot Nothing Then

                    NewPurchaseOrder = New AdvantageFramework.Database.Entities.PurchaseOrder

                    NewPurchaseOrder.DbContext = DbContext

                    NewPurchaseOrder.VendorCode = CopyFromPurchaseOrder.VendorCode
                    NewPurchaseOrder.VendorContactCode = CopyFromPurchaseOrder.VendorContactCode

                    If String.IsNullOrEmpty(ChangeToEmployeeCode) = False Then

                        NewPurchaseOrder.EmployeeCode = ChangeToEmployeeCode

                    Else

                        NewPurchaseOrder.EmployeeCode = CopyFromPurchaseOrder.EmployeeCode

                    End If

                    NewPurchaseOrder.Description = CopyFromPurchaseOrder.Description

                    If CopyMemos = False Then

                        NewPurchaseOrder.DeliveryInstruction = Nothing
                        NewPurchaseOrder.MainInstruction = Nothing

                    End If

                    If AdvantageFramework.Database.Procedures.PurchaseOrder.Insert(DbContext, NewPurchaseOrder) Then

                        For Each PurchaseOrderDetail In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, CopyFromPONumber).ToList

                            NewPurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                            NewPurchaseOrderDetail.DbContext = DbContext
                            NewPurchaseOrderDetail = PurchaseOrderDetail.DuplicateEntity()

                            NewPurchaseOrderDetail.IsComplete = Nothing
                            NewPurchaseOrderDetail.PurchaseOrderNumber = NewPurchaseOrder.Number

                            If PurchaseOrderDetail.JobComponentNumber.HasValue Then

                                If (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                    Where Entity.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                                          Entity.Number = PurchaseOrderDetail.JobComponentNumber AndAlso
                                          (Entity.JobProcessNumber = 6 OrElse
                                           Entity.JobProcessNumber = 12)
                                    Select Entity).Any Then

                                    NewPurchaseOrderDetail.JobNumber = Nothing
                                    NewPurchaseOrderDetail.JobComponentNumber = Nothing

                                End If

                            End If

                            AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, NewPurchaseOrderDetail)

                        Next

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                Copy = Copied
            End Try

        End Function
        Public Function FormatPurchaseOrderNumber(ByVal PurchaseOrderNumber As Integer) As String

            'objects
            Dim PONumber As Integer = Nothing

            Try

                If PurchaseOrderNumber <> Nothing Then

                    PONumber = PurchaseOrderNumber

                Else

                    PONumber = 0

                End If

                FormatPurchaseOrderNumber = AdvantageFramework.StringUtilities.PadWithCharacter(PONumber.ToString, 6, "0", True)

            Catch ex As Exception
                FormatPurchaseOrderNumber = PurchaseOrderNumber
            End Try

        End Function
        Public Function FormatPurchaseOrderRevisionNumber(ByVal PurchaseOrderRevisionNumber As Integer) As String

            'objects
            Dim Revision As Integer = Nothing

            Try

                If PurchaseOrderRevisionNumber <> Nothing Then

                    Revision = PurchaseOrderRevisionNumber

                Else

                    Revision = 0

                End If

                FormatPurchaseOrderRevisionNumber = AdvantageFramework.StringUtilities.PadWithCharacter(Revision.ToString, 3, "0", True)

            Catch ex As Exception
                FormatPurchaseOrderRevisionNumber = PurchaseOrderRevisionNumber
            End Try

        End Function
        Public Function UpdatePOCompleteFlag(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderNumber As Integer,
                                                    ByVal PurchaseOrderComplete As Integer) As Boolean

            'objects
            Dim MarkedComplete As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction


                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_UpdatePOCompleteFlag] {0}, {1}", PurchaseOrderNumber, PurchaseOrderComplete))

                    MarkedComplete = True

                Catch ex As Exception

                End Try




                If MarkedComplete Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

            Catch ex As Exception
                MarkedComplete = False
            Finally
                UpdatePOCompleteFlag = MarkedComplete
            End Try

        End Function
        Public Function UpdatePOLineItemCompleteFlag(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderNumber As Integer,
                                                    ByVal LineNumber As Integer, PurchaseOrderComplete As Integer) As Boolean

            'objects
            Dim MarkedComplete As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction


                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_UpdatePOLineItemCompleteFlag] {0}, {1}, {2}", PurchaseOrderNumber, LineNumber, PurchaseOrderComplete))

                    MarkedComplete = True

                Catch ex As Exception

                End Try




                If MarkedComplete Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

            Catch ex As Exception
                MarkedComplete = False
            Finally
                UpdatePOLineItemCompleteFlag = MarkedComplete
            End Try

        End Function
        Public Function CancelApproval(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderNumber As Integer) As Boolean

            'objects
            Dim Canceled As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                If AdvantageFramework.Database.Procedures.POApproval.LoadByPurchaseOrderNumber(DbContext, PurchaseOrderNumber).Any Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[PO_APPROVAL] WHERE [PO_NUMBER] = {0}", PurchaseOrderNumber))

                        Canceled = True

                    Catch ex As Exception

                    End Try

                End If

                If Canceled Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

            Catch ex As Exception
                Canceled = False
            Finally
                CancelApproval = Canceled
            End Try

        End Function
        Public Function CanPrintPurchaseOrder(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder) As Boolean

            'objects
            Dim CanPrint As Boolean = False

            Try

                If PurchaseOrder IsNot Nothing Then



                End If

            Catch ex As Exception
                CanPrint = False
            Finally
                CanPrintPurchaseOrder = CanPrint
            End Try

        End Function
        Public Function LimitPOToCurrentEmployee(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Limit As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, "PR_PO_DO_OWN")

                    If UserSetting IsNot Nothing Then

                        If UserSetting.StringValue = "Y" Then

                            Limit = True

                        Else

                            Limit = False

                        End If

                    End If

                End Using

            Catch ex As Exception
                Limit = False
            Finally
                LimitPOToCurrentEmployee = Limit
            End Try

        End Function
        Public Function SubmitForApproval(ByVal Session As AdvantageFramework.Security.Session,
                                          ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder,
                                          ByVal PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels,
                                          ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrderApprovalRuleDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim PurchaseOrderApprovalRuleEmployees As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) = Nothing
            Dim AlertRecipients As Generic.List(Of String) = Nothing
            Dim POTotal As Decimal = Nothing
            Dim SequenceNumber As Integer = -1
            Dim Submitted As Boolean = False

            Try

                If PurchaseOrder IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        CancelApproval(DbContext, PurchaseOrder.Number) 'deletes all existing approvals

                        Try

                            PurchaseOrderDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC [dbo].[advsp_load_po_details] {0}", PurchaseOrder.Number)).ToList

                            POTotal = (From Entity In PurchaseOrderDetails
                                       Select Entity.ExtendedAmount).Sum

                        Catch ex As Exception
                            PurchaseOrderDetails = Nothing
                        End Try

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                        If String.IsNullOrEmpty(Employee.PurchaseOrderApprovalRuleCode) = False Then

                            PurchaseOrderApprovalRule = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, Employee.PurchaseOrderApprovalRuleCode)

                        Else

                            DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, Employee.DepartmentTeamCode)

                            If DepartmentTeam IsNot Nothing Then

                                PurchaseOrderApprovalRule = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, DepartmentTeam.PurchaseOrderApprovalRuleCode)

                            End If

                        End If

                        Try

                            PurchaseOrderApprovalRuleDetails = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCode(DbContext, PurchaseOrderApprovalRule.Code)
                                                                Where Entity.ApprovalMinimum <= POTotal AndAlso
                                                                     Entity.ApprovalMaximum >= POTotal AndAlso
                                                                     (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                                                                Select Entity).ToList

                        Catch ex As Exception
                            PurchaseOrderApprovalRuleDetails = Nothing
                        End Try

                        If PurchaseOrderApprovalRuleDetails IsNot Nothing AndAlso PurchaseOrderApprovalRuleDetails.Count > 0 Then

                            AlertRecipients = New Generic.List(Of String)

                            For Each PurchaseOrderApprovalRuleDetail In PurchaseOrderApprovalRuleDetails

                                PurchaseOrderApprovalRuleEmployees = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetail.SequenceNumber)
                                                                      Where Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0
                                                                      Order By Entity.PurchaseOrderApprovalRuleDetailSequenceNumber Ascending, Entity.Order Ascending
                                                                      Select Entity).ToList

                                SequenceNumber = -1

                                For Each PurchaseOrderApprovalRuleEmployee In PurchaseOrderApprovalRuleEmployees

                                    If SequenceNumber = -1 Then

                                        If GetPOEmployeeInOutStatus(DbContext, PurchaseOrderApprovalRuleEmployee.EmployeeCode) <> 1 Then

                                            If AlertRecipients.Contains(PurchaseOrderApprovalRuleEmployee.EmployeeCode) = False Then

                                                AlertRecipients.Add(PurchaseOrderApprovalRuleEmployee.EmployeeCode)

                                                CreatePOApproval(DbContext, PurchaseOrder.Number, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber, PurchaseOrderApprovalRuleEmployee.ID)

                                                SequenceNumber = PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber

                                            End If

                                        End If

                                    ElseIf SequenceNumber <> PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber Then

                                        If GetPOEmployeeInOutStatus(DbContext, PurchaseOrderApprovalRuleEmployee.EmployeeCode) <> 1 Then

                                            If AlertRecipients.Contains(PurchaseOrderApprovalRuleEmployee.EmployeeCode) = False Then

                                                AlertRecipients.Add(PurchaseOrderApprovalRuleEmployee.EmployeeCode)

                                                CreatePOApproval(DbContext, PurchaseOrder.Number, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber, PurchaseOrderApprovalRuleEmployee.ID)

                                            End If

                                            SequenceNumber = PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber

                                        End If

                                    End If

                                Next

                            Next

                            If AlertRecipients.Any = False Then

                                ErrorMessage = "No recipients available."
                                Submitted = False

                            Else

                                If CreatePOApprovalAlert(Session, DbContext, PurchaseOrder, PurchaseOrderDetails, Employee, PriorityLevel, AlertRecipients, POTotal, Alert, ErrorMessage) Then

                                    AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert] ", Nothing, Nothing, "PO Approval Request", ErrorMessage)

                                    Submitted = True

                                End If

                            End If

                        Else

                            ErrorMessage = "No Approval rules found."
                            Submitted = False

                        End If

                        If Submitted Then

                            PurchaseOrder.VoidDate = Nothing
                            PurchaseOrder.IsVoid = Nothing
                            PurchaseOrder.VoidedByUserCode = Nothing

                            AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder)

                        End If

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = "There was an error submitting the purchase order for approval. Please contact software support."
                Submitted = False
            Finally
                SubmitForApproval = Submitted
            End Try

        End Function
        Private Function CreatePOApproval(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal PONumber As Integer, ByVal POApprovalRuleCode As String,
                                          ByVal SequenceNumber As Integer, ByVal POApprovalRuleEmployeeID As Integer) As Boolean

            'objects
            Dim POApproval As AdvantageFramework.Database.Entities.POApproval = Nothing
            Dim Created As Boolean = False

            Try

                POApproval = New AdvantageFramework.Database.Entities.POApproval

                POApproval.DbContext = DbContext

                POApproval.Number = PONumber
                POApproval.POApprovalRuleCode = POApprovalRuleCode
                POApproval.POApprovalRuleDetailSequenceNumber = SequenceNumber
                POApproval.POApprovalRuleEmployeeID = POApprovalRuleEmployeeID
                POApproval.IsApproved = Nothing
                POApproval.UserCode = Nothing
                POApproval.Date = Nothing
                POApproval.Notes = Nothing

                Created = AdvantageFramework.Database.Procedures.POApproval.Insert(DbContext, POApproval)

            Catch ex As Exception
                Created = False
            Finally
                CreatePOApproval = Created
            End Try

        End Function
        Private Function CreatePOApprovalAlert(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder,
                                               ByVal PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail),
                                               ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                               ByVal PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels,
                                               ByVal Recipients As IEnumerable, ByVal POTotal As Decimal,
                                               ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PurchaseOrderEstimates As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderEstimate) = Nothing
            Dim POBudgetComparisons As Generic.List(Of AdvantageFramework.Database.Classes.POBudgetComparison) = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim BodyString As String = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Created As Boolean = False
            Dim FileName As String = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim RealFileName As String = Nothing
            Dim MIMEType As String = Nothing
            Dim FileBytes As Byte() = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim DocumentID As Integer = 0

            Try

                If Alert Is Nothing Then

                    Alert = New AdvantageFramework.Database.Entities.Alert

                End If

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, PurchaseOrder.VendorCode)

                Alert.AlertTypeID = 3 'approvals
                Alert.AlertCategoryID = 38

                Alert.Subject = "PO Approval Request - " & Vendor.Name & " - " & PurchaseOrder.Description

                If PurchaseOrder.Revision.GetValueOrDefault(0) > 0 Then

                    Alert.Subject &= " - Revision: " & PurchaseOrder.Revision.GetValueOrDefault(0)

                End If

                BodyString &= "--------------------------------------" & "<br/>"
                BodyString &= "Purchase Order Details:" & "<br/>"
                BodyString &= "--------------------------------------" & "<br/>"
                BodyString &= "PO Number: " & FormatPurchaseOrderNumber(PurchaseOrder.Number) & "<br/>"
                BodyString &= "PO Description: " & PurchaseOrder.Description & "<br/>"
                BodyString &= "Issued By: " & Employee.ToString & "<br/>"
                BodyString &= "Issued To: " & Vendor.Name & "<br/>"
                BodyString &= "Total PO Amount: " & String.Format("{0:#,##0.00}", POTotal) & "<br/>"
                BodyString &= "Employee's Limit: " & String.Format("{0:#,##0.00}", Employee.PurchaseOrderLimit.GetValueOrDefault(0)) & "<br/>"

                If PurchaseOrder.Revision > 0 Then

                    BodyString &= "PO Revision: " & PurchaseOrder.Revision & "<br/>" & "<br/>"

                Else

                    BodyString &= "<br/>"

                End If

                If PurchaseOrderDetails IsNot Nothing AndAlso PurchaseOrderDetails.Count > 0 Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.Append("<table style=""font-size: 9pt; font-family: Arial;"">")
                    StringBuilder.Append("<tr>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Line Nbr</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Description</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>C/D/P</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Job/Comp</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Job Desc</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Function</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>GL Account</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Line Total</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Estimate/Budget</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>PO Used</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("<td>")
                    StringBuilder.Append("<u>Balance</u>")
                    StringBuilder.Append("</td>")
                    StringBuilder.Append("</tr>")

                    For Each PurchaseOrderDetail In PurchaseOrderDetails

                        StringBuilder.Append("<tr>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.LineNumber)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.LineDescription)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.ClientCode & "/" & PurchaseOrderDetail.DivisionCode & "/" & PurchaseOrderDetail.ProductCode)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.JobNumber & "/" & PurchaseOrderDetail.JobComponentNumber)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.JobDescription)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.FunctionCode & " - " & PurchaseOrderDetail.FunctionDescription)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(PurchaseOrderDetail.GeneralLedgerCode)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append(String.Format("{0:#,##0.00}", PurchaseOrderDetail.LineTotal))
                        StringBuilder.Append("</td>")

                        If PurchaseOrderDetail.JobNumber.HasValue = True AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue = True Then


                            Try

                                PurchaseOrderEstimates = AdvantageFramework.Database.Procedures.PurchaseOrderEstimateComplex.Load(DbContext, 1, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber, PurchaseOrderDetail.FunctionCode).ToList

                            Catch ex As Exception
                                PurchaseOrderEstimates = Nothing
                            End Try

                            If PurchaseOrderEstimates IsNot Nothing AndAlso PurchaseOrderEstimates.Count > 0 Then

                                For Each PurchaseOrderEstimate In PurchaseOrderEstimates

                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PurchaseOrderEstimate.EstimateRevisionExtendedAmount))
                                    StringBuilder.Append("</td>")
                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PurchaseOrderEstimate.PurchaseOrderExistingAmount))
                                    StringBuilder.Append("</td>")
                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PurchaseOrderEstimate.Balance))
                                    StringBuilder.Append("</td>")

                                Next

                            Else

                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")
                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")
                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")

                            End If

                        ElseIf Employee.AllowPOGLSelection.GetValueOrDefault(0) = 1 Then

                            Try

                                POBudgetComparisons = AdvantageFramework.Database.Procedures.POBudgetComparisonComplex.Load(DbContext, PurchaseOrderDetail.GeneralLedgerCode, PurchaseOrder.Date).ToList

                            Catch ex As Exception
                                POBudgetComparisons = Nothing
                            End Try

                            If POBudgetComparisons IsNot Nothing AndAlso POBudgetComparisons.Count > 0 Then

                                For Each PoBudgetComparison In POBudgetComparisons

                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PoBudgetComparison.Budget))
                                    StringBuilder.Append("</td>")
                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PoBudgetComparison.POUsed))
                                    StringBuilder.Append("</td>")
                                    StringBuilder.Append("<td>")
                                    StringBuilder.Append(String.Format("{0:#,##0.00}", PoBudgetComparison.Balance))
                                    StringBuilder.Append("</td>")

                                Next

                            Else

                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")
                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")
                                StringBuilder.Append("<td>")
                                StringBuilder.Append("</td>")

                            End If

                        Else

                            StringBuilder.Append("<td>")
                            StringBuilder.Append("</td>")
                            StringBuilder.Append("<td>")
                            StringBuilder.Append("</td>")
                            StringBuilder.Append("<td>")
                            StringBuilder.Append("</td>")

                        End If

                        StringBuilder.Append("</tr>")

                        StringBuilder.Append("<tr>")
                        StringBuilder.Append("<td>")
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("<td colspan='12'>")
                        StringBuilder.Append("Description:  ")
                        StringBuilder.Append(PurchaseOrderDetail.DetailDescription)
                        StringBuilder.Append("</td>")
                        StringBuilder.Append("</tr>")

                    Next

                End If

                StringBuilder.Append("</table>")

                Alert.Body = BodyString & StringBuilder.ToString
                Alert.EmailBody = BodyString & StringBuilder.ToString
                Alert.GeneratedDate = System.DateTime.Now
                Alert.PriorityLevel = PriorityLevel
                Alert.PONumber = PurchaseOrder.Number
                Alert.EmployeeCode = Session.User.EmployeeCode
                Alert.AlertLevel = "NA"
                Alert.UserCode = Session.UserCode

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                    Created = True

                    For Each Recipient In Recipients.OfType(Of String)()

                        AdvantageFramework.AlertSystem.AddAlertRecipient(DbContext, Alert.ID, Recipient)

                    Next

                    If Created Then

                        RaiseEvent CreatePOReportForAttachment(PurchaseOrder.Number, DocumentID)

                        If DocumentID <> 0 Then

                            AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment
                            AlertAttachment.AlertID = Alert.ID
                            AlertAttachment.UserCode = Session.UserCode
                            AlertAttachment.GeneratedDate = System.DateTime.Now
                            AlertAttachment.DocumentID = DocumentID

                            AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Error creating alert."
                Created = False
            Finally
                CreatePOApprovalAlert = Created
            End Try

        End Function
        Private Function GetPOEmployeeInOutStatus(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Object

            'objects
            Dim InOutStatus As Object = Nothing

            Try

                InOutStatus = CShort(DbContext.Database.SqlQuery(Of Short)(String.Format("EXEC [dbo].[proc_WV_PO_GetPOEmpInOutStatus] '{0}'", EmployeeCode)).SingleOrDefault)

            Catch ex As Exception
                InOutStatus = Nothing
            Finally
                GetPOEmployeeInOutStatus = InOutStatus
            End Try

        End Function
        Private Function OutputReportFilePO(ByVal Session As AdvantageFramework.Security.Session,
                                            ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder,
                                            ByRef PurchaseOrderPrintDefaultLogoPath As String, ByRef PurchaseOrderPrintDefaultLocationID As String) As String

            'objects
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
            Dim FileNameStringBuilder As System.Text.StringBuilder = Nothing
            Dim TimeStampStringBuilder As System.Text.StringBuilder = Nothing
            Dim ReportNameStringBuilder As System.Text.StringBuilder = Nothing

            Try

                FileNameStringBuilder = New System.Text.StringBuilder
                TimeStampStringBuilder = New System.Text.StringBuilder
                ReportNameStringBuilder = New System.Text.StringBuilder

                TimeStampStringBuilder.Append(Now.Year.ToString())
                TimeStampStringBuilder.Append(Now.Month.ToString())
                TimeStampStringBuilder.Append(Now.Day.ToString())

                'TO DO: WEBVANTAGE APPLICATION PATH 
                'FileNameStringBuilder.Append(Request.PhysicalApplicationPath.Trim)
                FileNameStringBuilder.Append("TEMP\")
                FileNameStringBuilder.Append("Purchase_Order_")
                FileNameStringBuilder.Append(PurchaseOrder.Number.ToString.PadLeft(8, "0"))
                FileNameStringBuilder.Append("_")
                FileNameStringBuilder.Append(TimeStampStringBuilder.ToString())
                FileNameStringBuilder.Append(".PDF")
                ReportNameStringBuilder.Append("purchaseorder")

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Session.UserCode)

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    If String.IsNullOrEmpty(PurchaseOrderPrintDefault.LogoPath) = False Then

                        PurchaseOrderPrintDefaultLogoPath = PurchaseOrderPrintDefault.LogoPath
                        PurchaseOrderPrintDefaultLocationID = PurchaseOrderPrintDefault.LocationID

                    End If

                End If

                ' TO DO : GENERATE REPORT FOR ALERT

                'Dim rpt As New popReportViewer

                'Try
                '    rpt.renderDoc(FileNameStringBuilder.ToString(), ReportNameStringBuilder.ToString(), Request.QueryString("PONum"), "", "", "", "", 1, "", "1;1;1;1;1;1;1;1;1;1;1")
                '    Return FileNameStringBuilder.ToString
                'Catch ex As Exception
                '    'Me.lbl_msg.Text = ex.Message.Trim
                '    Return ""
                'End Try

            Catch ex As Exception

            Finally
                OutputReportFilePO = ""
            End Try

        End Function
        Public Function UpdatePODetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PODetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail, ByRef Message As String) As Boolean

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim Updated As Boolean = False

            Try

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, PODetail.PONumber, PODetail.LineNumber)

                If PurchaseOrderDetail IsNot Nothing Then

                    PurchaseOrderDetail.Description = PODetail.DetailDescription
                    PurchaseOrderDetail.LineDescription = PODetail.LineDescription
                    PurchaseOrderDetail.Instructions = PODetail.Instructions
                    PurchaseOrderDetail.Quantity = PODetail.Quantity
                    PurchaseOrderDetail.Rate = PODetail.Rate
                    PurchaseOrderDetail.ExtendedAmount = PODetail.ExtendedAmount
                    PurchaseOrderDetail.TaxPercent = PODetail.TaxPercent
                    PurchaseOrderDetail.IsComplete = PODetail.IsComplete
                    PurchaseOrderDetail.JobNumber = PODetail.JobNumber
                    PurchaseOrderDetail.JobComponentNumber = PODetail.JobComponentNumber
                    PurchaseOrderDetail.FunctionCode = PODetail.FunctionCode
                    PurchaseOrderDetail.CommissionPercent = PODetail.CommissionPercent
                    PurchaseOrderDetail.ExtendedMarkupAmount = PODetail.ExtendedMarkupAmount
                    PurchaseOrderDetail.GLACode = PODetail.GeneralLedgerCode
                    PurchaseOrderDetail.BillingApprovalID = PODetail.BillingApprovalID

                    If ValidatePODetailEstimateApproval(DbContext, PurchaseOrderDetail, False, Message) Then

                        Updated = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Update(DbContext, PurchaseOrderDetail)

                    End If

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdatePODetail = Updated
            End Try

        End Function
        Public Function InsertPODetail(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PODetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail, ByRef Message As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim Cancel As Boolean = False
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim POTotal As Decimal = Nothing

            Try

                PurchaseOrderDetail = PODetail.GetPurchaseOrderDetail()

                If PODetail.JobNumber IsNot Nothing Then
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Session.User.EmployeeCode, PODetail.JobNumber) = False Then
                        Message = "Access to this job is denied."
                        Cancel = True
                    End If
                End If

                If ValidatePODetailEstimateApproval(DbContext, PurchaseOrderDetail, True, Message) Then

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PurchaseOrderDetail.PurchaseOrderNumber)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                    If String.IsNullOrWhiteSpace(Employee.PurchaseOrderApprovalRuleCode) AndAlso Employee.PurchaseOrderLimit.HasValue Then

                        Try

                            POTotal = (From Item In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, PurchaseOrder.Number).ToList
                                       Select Item.ExtendedAmount.GetValueOrDefault(0)).Sum

                        Catch ex As Exception
                            POTotal = Nothing
                        End Try

                        POTotal = POTotal + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                        If POTotal > Employee.PurchaseOrderLimit.GetValueOrDefault(0) Then

                            Message = "The PO total exceeds the limit (" & Employee.PurchaseOrderLimit.Value.ToString("C") & ") for " & Employee.ToString & "."
                            Cancel = True

                        End If

                    End If

                    If Not Cancel Then

                        Inserted = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

                    End If

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                InsertPODetail = Inserted
            End Try

        End Function
        Public Function CopyPurchaseOrderDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail,
                                                ByVal NewPONumber As Integer, Optional ByRef LineNumber As Short = Nothing) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim PurchaseOrderDetailCopy As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            Try

                If PurchaseOrderDetail IsNot Nothing Then

                    PurchaseOrderDetailCopy = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                    PurchaseOrderDetailCopy.DbContext = DbContext
                    PurchaseOrderDetailCopy.PurchaseOrderNumber = NewPONumber
                    PurchaseOrderDetailCopy.LineDescription = PurchaseOrderDetail.LineDescription
                    PurchaseOrderDetailCopy.Description = PurchaseOrderDetail.Description
                    PurchaseOrderDetailCopy.Instructions = PurchaseOrderDetail.Instructions
                    PurchaseOrderDetailCopy.JobNumber = PurchaseOrderDetail.JobNumber
                    PurchaseOrderDetailCopy.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
                    PurchaseOrderDetailCopy.FunctionCode = PurchaseOrderDetail.FunctionCode
                    PurchaseOrderDetailCopy.GLACode = PurchaseOrderDetail.GLACode
                    PurchaseOrderDetailCopy.Quantity = PurchaseOrderDetail.Quantity
                    PurchaseOrderDetailCopy.Rate = PurchaseOrderDetail.Rate
                    PurchaseOrderDetailCopy.ExtendedAmount = PurchaseOrderDetail.ExtendedAmount
                    PurchaseOrderDetailCopy.CommissionPercent = PurchaseOrderDetail.CommissionPercent
                    PurchaseOrderDetailCopy.TaxPercent = PurchaseOrderDetail.TaxPercent
                    PurchaseOrderDetailCopy.ExtendedMarkupAmount = PurchaseOrderDetail.ExtendedMarkupAmount
                    PurchaseOrderDetailCopy.BillingApprovalID = PurchaseOrderDetail.BillingApprovalID
                    PurchaseOrderDetailCopy.IsComplete = Nothing

                    Try

                        If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, NewPONumber).Any Then

                            PurchaseOrderDetailCopy.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, NewPONumber)
                                                                  Select [LN] = Entity.LineNumber).Max + 1

                        Else

                            PurchaseOrderDetailCopy.LineNumber = 1

                        End If

                    Catch ex As Exception
                        PurchaseOrderDetailCopy.LineNumber = 1
                    End Try

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetailCopy) Then

                        Copied = True
                        LineNumber = PurchaseOrderDetailCopy.LineNumber

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyPurchaseOrderDetail = Copied
            End Try

        End Function
        Public Function CopyPurchaseOrderDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail,
                                                ByVal NewPONumber As Integer, Optional ByRef LineNumber As Short = Nothing) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim PurchaseOrderDetailCopy As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            Try

                If PurchaseOrderDetail IsNot Nothing Then

                    PurchaseOrderDetailCopy = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                    PurchaseOrderDetailCopy.DbContext = DbContext
                    PurchaseOrderDetailCopy.PurchaseOrderNumber = NewPONumber
                    PurchaseOrderDetailCopy.LineDescription = PurchaseOrderDetail.LineDescription
                    PurchaseOrderDetailCopy.Description = PurchaseOrderDetail.DetailDescription
                    PurchaseOrderDetailCopy.Instructions = PurchaseOrderDetail.Instructions
                    PurchaseOrderDetailCopy.JobNumber = PurchaseOrderDetail.JobNumber
                    PurchaseOrderDetailCopy.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
                    PurchaseOrderDetailCopy.FunctionCode = PurchaseOrderDetail.FunctionCode
                    PurchaseOrderDetailCopy.GLACode = PurchaseOrderDetail.GeneralLedgerCode
                    PurchaseOrderDetailCopy.Quantity = PurchaseOrderDetail.Quantity
                    PurchaseOrderDetailCopy.Rate = PurchaseOrderDetail.Rate
                    PurchaseOrderDetailCopy.ExtendedAmount = PurchaseOrderDetail.ExtendedAmount
                    PurchaseOrderDetailCopy.CommissionPercent = PurchaseOrderDetail.CommissionPercent
                    PurchaseOrderDetailCopy.TaxPercent = PurchaseOrderDetail.TaxPercent
                    PurchaseOrderDetailCopy.ExtendedMarkupAmount = PurchaseOrderDetail.ExtendedMarkupAmount
                    PurchaseOrderDetailCopy.BillingApprovalID = PurchaseOrderDetail.BillingApprovalID
                    PurchaseOrderDetailCopy.IsComplete = Nothing

                    Try

                        If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, NewPONumber).Any Then

                            PurchaseOrderDetailCopy.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, NewPONumber)
                                                                  Select [LN] = Entity.LineNumber).Max + 1

                        Else

                            PurchaseOrderDetailCopy.LineNumber = 1

                        End If

                    Catch ex As Exception
                        PurchaseOrderDetailCopy.LineNumber = 1
                    End Try

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetailCopy) Then

                        Copied = True
                        LineNumber = PurchaseOrderDetailCopy.LineNumber

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyPurchaseOrderDetail = Copied
            End Try

        End Function
        Public Function CopyPurchaseOrderDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal PONumber As Integer, ByVal LineNumber As Short,
                                                ByVal NewPONumber As Integer, Optional ByRef NewLineNumber As Short = Nothing) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            Try

                PurchaseOrderDetail = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC advsp_load_po_details {0}", PONumber)).ToList
                                       Where Entity.LineNumber = LineNumber
                                       Select Entity).SingleOrDefault

                Copied = CopyPurchaseOrderDetail(DbContext, PurchaseOrderDetail, NewPONumber, NewLineNumber)

            Catch ex As Exception
                Copied = False
            Finally
                CopyPurchaseOrderDetail = Copied
            End Try

        End Function
        Public Function EstimateItem(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByRef JobComponentNumber As Integer, ByRef HasDetails As Boolean, ByRef ErrorMessage As String, Optional ByVal FunctionCode As String = Nothing) As AdvantageFramework.Database.Entities.EstimateRevisionDetail

            'objects
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
            Dim EstimateRevisionDetail As AdvantageFramework.Database.Entities.EstimateRevisionDetail = Nothing
            Dim EstimateRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.EstimateRevisionDetail) = Nothing
            Dim JobCompNumber As Integer = Nothing

            Try

                If JobNumber <> 0 Then

                    If JobComponentNumber = 0 Then

                        Try

                            JobComponentNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                  Where Entity.JobNumber = JobNumber
                                                  Select Entity.Number).Max

                        Catch ex As Exception
                            JobComponentNumber = 1
                        End Try

                    End If

                    JobCompNumber = JobComponentNumber

                    Try

                        EstimateApproval = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                            Where Entity.JobNumber = JobNumber AndAlso
                                                  Entity.JobComponentNumber = JobCompNumber
                                            Select Entity).SingleOrDefault

                    Catch ex As Exception
                        EstimateApproval = Nothing
                    End Try

                    If EstimateApproval IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(FunctionCode) Then

                            FunctionCode = ""

                        End If

                        EstimateRevisionDetails = (From Entity In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                   Where Entity.EstimateNumber = EstimateApproval.EstimateNumber AndAlso
                                                         Entity.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber AndAlso
                                                         Entity.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber AndAlso
                                                         Entity.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber AndAlso
                                                         Entity.Function.Type = "V" AndAlso
                                                         Entity.FunctionCode = If(FunctionCode <> "", FunctionCode, Entity.FunctionCode)
                                                   Select Entity).ToList

                        If EstimateRevisionDetails IsNot Nothing AndAlso EstimateRevisionDetails.Count > 0 Then

                            HasDetails = True

                            If EstimateRevisionDetails.Count = 1 Then

                                EstimateRevisionDetail = EstimateRevisionDetails.SingleOrDefault

                            End If

                        Else

                            HasDetails = False
                            ErrorMessage = "An estimate has not been approved for this job and component."

                        End If

                    End If

                End If

            Catch ex As Exception
                HasDetails = False
                EstimateRevisionDetail = Nothing
            End Try

            EstimateItem = EstimateRevisionDetail

        End Function
        Public Function LoadPurchaseOrderDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer) As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Try

                LoadPurchaseOrderDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC [dbo].[advsp_load_po_details] {0}", PONumber)).ToList

            Catch ex As Exception
                LoadPurchaseOrderDetails = Nothing
            End Try

        End Function
        Public Function ValidatePODetailEstimateApproval(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail,
                                                         ByVal IsInserting As Boolean, ByRef Message As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim AllowWithoutApprovedEstimate As Boolean = False
            Dim EstimateProcessingOption As AdvantageFramework.Database.Entities.EstimateProcessingOption = Nothing
            Dim UsedAmount As Decimal = 0
            Dim ApprovedAmount As Decimal = 0
            Dim ApprovalInfo As String = ""
            Dim HasEstimateApprovals As Boolean = False

            Try

                If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                    EstimateProcessingOption = AdvantageFramework.Database.Procedures.EstimateProcessingOption.LoadPurchaseOrderOption(DbContext)

                    If EstimateProcessingOption IsNot Nothing Then

                        AllowWithoutApprovedEstimate = CBool(EstimateProcessingOption.AllowProcessing.GetValueOrDefault(0))

                        If AllowWithoutApprovedEstimate = False Then

                            If AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, PurchaseOrderDetail.JobNumber).IsEstimateRequired.GetValueOrDefault(0) = 0 Then

                                AllowWithoutApprovedEstimate = True

                            End If

                        End If

                        HasEstimateApprovals = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                                Where Entity.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                                                      Entity.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
                                                Select Entity).Any

                        If AllowWithoutApprovedEstimate = False AndAlso HasEstimateApprovals = False Then

                            Message = "No approved estimates exist for job/comp " & PurchaseOrderDetail.JobNumber.Value.ToString & "/" & PurchaseOrderDetail.JobComponentNumber.Value.ToString
                            IsValid = False

                        ElseIf HasEstimateApprovals Then

                            Try

                                UsedAmount = DbContext.Database.SqlQuery(Of Decimal)("SELECT ISNULL(SUM(PURCHASE_ORDER_DET.PO_EXT_AMOUNT), 0) " &
                                                                                         "FROM dbo.PURCHASE_ORDER_DET " &
                                                                                         "JOIN dbo.PURCHASE_ORDER ON PURCHASE_ORDER_DET.PO_NUMBER = PURCHASE_ORDER.PO_NUMBER " &
                                                                                         "WHERE (PURCHASE_ORDER.VOID_FLAG = 0 OR PURCHASE_ORDER.VOID_FLAG IS NULL) AND " &
                                                                                         "      PURCHASE_ORDER_DET.JOB_NUMBER = " & PurchaseOrderDetail.JobNumber & " AND " &
                                                                                         "      PURCHASE_ORDER_DET.JOB_COMPONENT_NBR = " & PurchaseOrderDetail.JobComponentNumber & " AND " &
                                                                                         "      PURCHASE_ORDER_DET.FNC_CODE = '" & PurchaseOrderDetail.FunctionCode & "' " &
                                                                                         If(IsInserting = False, "AND 1 = CASE WHEN PURCHASE_ORDER_DET.PO_NUMBER = " & PurchaseOrderDetail.PurchaseOrderNumber & " AND PURCHASE_ORDER_DET.LINE_NUMBER = " & PurchaseOrderDetail.LineNumber & " THEN 0 ELSE 1 END", "")).SingleOrDefault

                            Catch ex As Exception
                                UsedAmount = 0
                            End Try

                            Try

                                ApprovedAmount = DbContext.Database.SqlQuery(Of Decimal)("SELECT ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_EXT_AMT), 0) " &
                                                                                             "FROM dbo.V_ESTIMATEAPPR " &
                                                                                             "JOIN dbo.ESTIMATE_REV_DET ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = V_ESTIMATEAPPR.ESTIMATE_NUMBER AND " &
                                                                                             "                             ESTIMATE_REV_DET.EST_COMPONENT_NBR = V_ESTIMATEAPPR.EST_COMPONENT_NBR AND " &
                                                                                             "                             ESTIMATE_REV_DET.EST_QUOTE_NBR = V_ESTIMATEAPPR.EST_QUOTE_NBR AND " &
                                                                                             "                             ESTIMATE_REV_DET.EST_REV_NBR = V_ESTIMATEAPPR.EST_REVISION_NBR " &
                                                                                             "WHERE V_ESTIMATEAPPR.JOB_NUMBER = " & PurchaseOrderDetail.JobNumber & " AND " &
                                                                                             "      V_ESTIMATEAPPR.JOB_COMPONENT_NBR = " & PurchaseOrderDetail.JobComponentNumber & " AND " &
                                                                                             "      ESTIMATE_REV_DET.FNC_CODE = '" & PurchaseOrderDetail.FunctionCode & "'").SingleOrDefault

                            Catch ex As Exception
                                ApprovedAmount = 0
                            End Try

                            If ApprovedAmount < (UsedAmount + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)) AndAlso EstimateProcessingOption.ExceedOption <> AdvantageFramework.Database.Entities.ExceedEstimateOptions.Yes Then

                                ApprovalInfo = DbContext.Database.SqlQuery(Of String)("SELECT 'Estimate: ' + CAST(MAX(V_ESTIMATEAPPR.ESTIMATE_NUMBER) AS VARCHAR(10)) + " &
                                                                                          "       ', Component: ' + CAST(MAX(V_ESTIMATEAPPR.EST_COMPONENT_NBR) AS VARCHAR(10)) + " &
                                                                                          "       ', Quote Number: ' + CAST(MAX(V_ESTIMATEAPPR.EST_QUOTE_NBR) AS VARCHAR(10)) +  " &
                                                                                          "       ', Revision Number: ' + CAST(MAX(V_ESTIMATEAPPR.EST_REVISION_NBR) AS VARCHAR(10))  " &
                                                                                          "FROM dbo.V_ESTIMATEAPPR " &
                                                                                          "JOIN dbo.ESTIMATE_REV_DET ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = V_ESTIMATEAPPR.ESTIMATE_NUMBER AND " &
                                                                                          "                             ESTIMATE_REV_DET.EST_COMPONENT_NBR = V_ESTIMATEAPPR.EST_COMPONENT_NBR AND " &
                                                                                          "                             ESTIMATE_REV_DET.EST_QUOTE_NBR = V_ESTIMATEAPPR.EST_QUOTE_NBR AND " &
                                                                                          "                             ESTIMATE_REV_DET.EST_REV_NBR = V_ESTIMATEAPPR.EST_REVISION_NBR " &
                                                                                          "WHERE V_ESTIMATEAPPR.JOB_NUMBER = " & PurchaseOrderDetail.JobNumber & " AND " &
                                                                                          "      V_ESTIMATEAPPR.JOB_COMPONENT_NBR = " & PurchaseOrderDetail.JobComponentNumber & " AND " &
                                                                                          "      ESTIMATE_REV_DET.FNC_CODE = '" & PurchaseOrderDetail.FunctionCode & "'").SingleOrDefault

                                Message = EstimateProcessingOption.DisplayMessage
                                Message &= " ($" & String.Format("{0:#,##0.00}", ApprovedAmount) & ")" & vbNewLine
                                Message &= "* $" & String.Format("{0:#,##0.00}", UsedAmount) & " used on other purchase order lines." & vbNewLine
                                Message &= "* " & ApprovalInfo & vbNewLine

                                If ApprovalInfo Is Nothing And EstimateProcessingOption.DisplayMessage = "" Then
                                    Message = "Purchase Order amount is greater than the Estimate Approval amount."
                                End If

                                If EstimateProcessingOption.ExceedOption = AdvantageFramework.Database.Entities.ExceedEstimateOptions.No Then

                                    Message &= vbNewLine & "Cannot save P.O. line."
                                    IsValid = False

                                End If

                            End If

                        End If

                    End If

                Else

                    IsValid = True

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ValidatePODetailEstimateApproval = IsValid
            End Try

        End Function
        Public Sub LoadPODetailEstimateInformation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            LoadPODetailEstimateInformation(DbContext, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber, PurchaseOrderDetail.FunctionCode, PurchaseOrderDetail.POUsed, PurchaseOrderDetail.BalanceNet, PurchaseOrderDetail.EstimateBudgetNet)

        End Sub
        Public Sub LoadPODetailEstimateInformation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer?,
                                                   ByVal JobComponentNumber As Short?, ByVal FunctionCode As String, ByRef POUsed As Decimal?,
                                                   ByRef BalanceNet As Decimal?, ByRef EstimateBudgetNet As Decimal?)

            'objects
            Dim PurchaseOrderEstimates As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderEstimate) = Nothing

            Try

                EstimateBudgetNet = Nothing
                POUsed = Nothing
                BalanceNet = Nothing

                If JobNumber.HasValue AndAlso JobComponentNumber.HasValue Then

                    Try

                        PurchaseOrderEstimates = AdvantageFramework.Database.Procedures.PurchaseOrderEstimateComplex.Load(DbContext, 1, JobNumber, JobComponentNumber, FunctionCode).ToList

                    Catch ex As Exception
                        PurchaseOrderEstimates = Nothing
                    End Try

                    If PurchaseOrderEstimates IsNot Nothing AndAlso PurchaseOrderEstimates.Count > 0 Then

                        EstimateBudgetNet = PurchaseOrderEstimates.Sum(Function(PoEstimate) PoEstimate.EstimateRevisionExtendedAmount.GetValueOrDefault(0))
                        POUsed = PurchaseOrderEstimates.First.PurchaseOrderExistingAmount
                        BalanceNet = PurchaseOrderEstimates.First.Balance.GetValueOrDefault(0)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub LoadPOBudgetComparisons(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PODate As Date, ByRef PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            LoadPOBudgetComparisons(DbContext, PODate, PurchaseOrderDetail.GeneralLedgerCode, PurchaseOrderDetail.POUsed, PurchaseOrderDetail.BalanceNet, PurchaseOrderDetail.EstimateBudgetNet)

        End Sub
        Public Sub LoadPOBudgetComparisons(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PODate As Date, ByVal GeneralLedgerCode As String, ByRef POUsed As Decimal?, ByRef Balance As Decimal?, ByRef Budget As Decimal?)

            'objects
            Dim POBudgetComparison As AdvantageFramework.Database.Classes.POBudgetComparison = Nothing

            Try

                POBudgetComparison = AdvantageFramework.Database.Procedures.POBudgetComparisonComplex.Load(DbContext, GeneralLedgerCode, PODate).SingleOrDefault

            Catch ex As Exception
                POBudgetComparison = Nothing
            End Try

            If POBudgetComparison IsNot Nothing Then

                POUsed = POBudgetComparison.POUsed
                Balance = POBudgetComparison.Balance
                Budget = POBudgetComparison.Budget

            End If

        End Sub
        Public Function LoadBillingRate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String,
                                             Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                             Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber As String = Nothing,
                                             Optional ByVal JobComponentNumber As String = Nothing, Optional ByVal SalesClassCode As String = Nothing,
                                             Optional ByVal EmployeeCode As String = Nothing, Optional ByVal EffectiveDate As System.DateTime = Nothing) As AdvantageFramework.Database.Classes.BillingRate

            'objects
            Dim ExecuteStatement As String = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim FunctionType As String = Nothing
            Dim JobNum As Integer = 0

            Try

                FunctionType = (From [Function] In DbContext.Functions
                                Where [Function].Code = FunctionCode
                                Select [Function].Type).SingleOrDefault

            Catch ex As Exception
                FunctionType = Nothing
            End Try

            Try

                If Not String.IsNullOrWhiteSpace(JobNumber) AndAlso String.IsNullOrWhiteSpace(SalesClassCode) Then

                    JobNum = CInt(JobNumber)

                    SalesClassCode = (From Job In DbContext.Jobs
                                      Where Job.Number = JobNum
                                      Select [Sc] = Job.SalesClassCode).SingleOrDefault

                End If

            Catch ex As Exception
                SalesClassCode = Nothing
            End Try

            Try

                ExecuteStatement = String.Format("SELECT * FROM dbo.advtf_get_billing_rate({0},{1},{2},{3},{4},{5},{6},{7},{8},{9}, NULL)",
                                                 If(EmployeeCode IsNot Nothing, "'" & EmployeeCode & "'", "NULL"),
                                                 If(EffectiveDate <> Nothing, "'" & EffectiveDate & "'", "NULL"),
                                                 If(FunctionCode IsNot Nothing, "'" & FunctionCode & "'", "NULL"),
                                                 If(ClientCode IsNot Nothing, "'" & ClientCode & "'", "NULL"),
                                                 If(DivisionCode IsNot Nothing, "'" & DivisionCode & "'", "NULL"),
                                                 If(ProductCode IsNot Nothing, "'" & ProductCode & "'", "NULL"),
                                                 If(SalesClassCode IsNot Nothing, "'" & SalesClassCode & "'", "NULL"),
                                                 If(FunctionType IsNot Nothing, "'" & FunctionType & "'", "NULL"),
                                                 If(JobNumber <> Nothing, JobNumber, "NULL"),
                                                 If(JobComponentNumber <> Nothing, JobComponentNumber, "NULL"))

                BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)(ExecuteStatement).FirstOrDefault

            Catch ex As Exception
                BillingRate = Nothing
            End Try

            LoadBillingRate = BillingRate

        End Function
        Public Function LoadStandardFooterComments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCode As String, ByVal GetAgencyDefaultIfEmpty As Boolean, ByVal PONumber As Integer, Optional ByRef FontSize As Short? = Nothing) As String

            'objects
            Dim StandardComments As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim StandardFooterComments As String = Nothing
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobNumber As Integer = 0
            Dim OfficeCode As String = ""
            Dim POHeader As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim UsedFooterCommentIDs As Generic.List(Of Integer) = Nothing

            StandardComments = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

            POHeader = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)
            PurchaseOrderDetails = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(DbContext, PONumber).ToList
            UsedFooterCommentIDs = New List(Of Integer)

            If StandardComments IsNot Nothing AndAlso StandardComments.Count > 0 Then

                For Each PODetail In PurchaseOrderDetails
                    ClientCode = PODetail.ClientCode
                    DivisionCode = PODetail.DivisionCode
                    ProductCode = PODetail.ProductCode

                    If PODetail.JobNumber IsNot Nothing Then
                        JobNumber = PODetail.JobNumber
                    End If

                    If JobNumber > 0 Then
                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                        If Job IsNot Nothing Then
                            OfficeCode = Job.OfficeCode
                        End If
                    End If

                    StandardComment = Nothing

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If


                    'CDPV
                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If StandardComment IsNot Nothing Then

                        If UsedFooterCommentIDs.Contains(StandardComment.ID) = False Then

                            If StandardFooterComments = "" Then

                                StandardFooterComments &= StandardComment.Comment

                            Else

                                StandardFooterComments &= vbCrLf & StandardComment.Comment

                            End If

                            UsedFooterCommentIDs.Add(StandardComment.ID)

                        End If

                    End If

                Next

                If POHeader IsNot Nothing Then
                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.VendorCode = ClientComment.VendorCode Then
                                If UsedFooterCommentIDs.Contains(ClientComment.ID) = False Then

                                    StandardFooterComments &= vbCrLf & ClientComment.Comment
                                    UsedFooterCommentIDs.Add(ClientComment.ID)

                                End If
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If
                End If

                If StandardComment Is Nothing Then
                    For Each ClientComment In StandardComments
                        If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing And ClientComment.OfficeCode Is Nothing Then
                            If UsedFooterCommentIDs.Contains(ClientComment.ID) = False Then

                                StandardFooterComments &= vbCrLf & ClientComment.Comment
                                UsedFooterCommentIDs.Add(ClientComment.ID)

                            End If
                            StandardComment = ClientComment
                            Exit For
                        End If
                    Next
                End If

            End If

            If StandardComment Is Nothing AndAlso UsedFooterCommentIDs.Any = False Then

                If GetAgencyDefaultIfEmpty Then

                    StandardFooterComments = LoadAgencyDefaultFooterComments(DbContext)

                End If

            Else

                If StandardComment Is Nothing Then

                    StandardComment = StandardComments.Where(Function(cmt) cmt.ID = UsedFooterCommentIDs.First).SingleOrDefault

                End If

                FontSize = StandardComment.FontSize

            End If

            LoadStandardFooterComments = StandardFooterComments

        End Function
        Public Function LoadAgencyDefaultFooterComments(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim FooterComments As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                FooterComments = Agency.POFooterComments

            End If

            LoadAgencyDefaultFooterComments = FooterComments

        End Function
        Public Function SetFooterText(ByVal FooterType As FooterTypes, ByVal FooterText As String) As String

            'objects
            Dim TextToStore As String = ""

            Select Case FooterType

                Case FooterTypes.AgencyDefined, FooterTypes.StandardComment

                    TextToStore = AdvantageFramework.StringUtilities.GetNameAsWords(FooterType.ToString)

                Case FooterTypes.Custom

                    TextToStore = FooterText

            End Select

            SetFooterText = TextToStore

        End Function
        Public Function GetFooterType(ByVal FooterText As String) As FooterTypes

            'objects
            Dim FooterType As FooterTypes = FooterTypes.Custom

            If String.IsNullOrWhiteSpace(FooterText) Then

                FooterType = FooterTypes.AgencyDefined

            Else

                For Each EnumValue In [Enum].GetValues(GetType(FooterTypes))

                    If FooterText = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(FooterTypes), EnumValue)) Then

                        FooterType = CType(EnumValue, FooterTypes)
                        Exit For

                    End If

                Next

            End If

            GetFooterType = FooterType

        End Function
        Public Function GetDisplayFooterTextByFooterType(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FooterType As FooterTypes, ByVal PONumber As Integer, ByVal VendorCode As String) As String

            'objects
            Dim FooterText As String = ""
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Select Case FooterType

                Case FooterTypes.AgencyDefined

                    FooterText = LoadAgencyDefaultFooterComments(DbContext)

                Case FooterTypes.StandardComment

                    FooterText = LoadStandardFooterComments(DbContext, VendorCode, True, PONumber)

                Case FooterTypes.Custom

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)

                    If PurchaseOrder IsNot Nothing Then

                        If GetFooterType(PurchaseOrder.Footer) = FooterTypes.Custom Then

                            FooterText = PurchaseOrder.Footer

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(FooterText) Then

                        FooterText = LoadAgencyDefaultFooterComments(DbContext)

                    End If

            End Select

            GetDisplayFooterTextByFooterType = FooterText

        End Function
        Public Function GetFooterText(ByVal Session As AdvantageFramework.Security.Session, ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder, Optional ByRef FontSize As Short? = Nothing) As String

            'objects
            Dim FooterText As String = ""
            Dim FooterType As FooterTypes = FooterTypes.Custom

            FooterType = GetFooterType(PurchaseOrder.Footer)

            If FooterType = FooterTypes.Custom Then

                FooterText = PurchaseOrder.Footer

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If FooterType = FooterTypes.StandardComment Then

                        FooterText = LoadStandardFooterComments(DbContext, PurchaseOrder.VendorCode, True, PurchaseOrder.Number, FontSize)

                    Else

                        FooterText = LoadAgencyDefaultFooterComments(DbContext)

                    End If

                End Using

            End If

            GetFooterText = FooterText

        End Function
        Public Sub GetSingleClientDivisionProductJobAndComponentCodes(ByVal Session As AdvantageFramework.Security.Session, ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef JobNumber As Integer?, ByRef JobComponentNumber As Short?)

            'objects
            Dim JobView As AdvantageFramework.Database.Views.JobView = Nothing
            Dim ThisClientCode As String = Nothing
            Dim ThisDivisionCode As String = Nothing
            Dim ThisProductCode As String = Nothing
            Dim ThisJobNumber As Integer? = Nothing
            Dim ThisJobComponentNumber As Short? = Nothing

            ThisClientCode = ClientCode
            ThisDivisionCode = DivisionCode
            ThisProductCode = ProductCode
            ThisJobNumber = JobNumber
            ThisJobComponentNumber = JobComponentNumber

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If JobNumber.HasValue AndAlso JobNumber.Value > 0 Then

                            If String.IsNullOrEmpty(ClientCode) OrElse String.IsNullOrEmpty(DivisionCode) OrElse String.IsNullOrEmpty(ProductCode) Then

                                JobView = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, ThisJobNumber)

                                If JobView IsNot Nothing Then

                                    ClientCode = JobView.ClientCode
                                    DivisionCode = JobView.DivisionCode
                                    ProductCode = JobView.ProductCode

                                End If

                            End If

                            If JobComponentNumber.HasValue = False Then

                                Try

                                    JobComponentNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Session.UserCode, Nothing, Nothing, Nothing, ThisJobNumber, True, Nothing)
                                                          Select [JCN] = Entity.JobComponentNumber).SingleOrDefault

                                Catch ex As Exception
                                    JobComponentNumber = Nothing
                                End Try

                            End If

                        ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                            If String.IsNullOrEmpty(DivisionCode) Then

                                Try

                                    DivisionCode = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode)
                                                    Where Entity.ClientCode = ThisClientCode AndAlso
                                                          Entity.IsActive = 1
                                                    Select Entity.Code).SingleOrDefault

                                Catch ex As Exception
                                    DivisionCode = Nothing
                                End Try

                            End If

                            If String.IsNullOrEmpty(DivisionCode) = False Then

                                ThisDivisionCode = DivisionCode

                                If String.IsNullOrEmpty(ProductCode) Then

                                    Try

                                        ProductCode = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode, False, True)
                                                       Where Entity.ClientCode = ThisClientCode AndAlso
                                                             Entity.DivisionCode = ThisDivisionCode AndAlso
                                                             Entity.IsActive = 1
                                                       Select Entity.Code).SingleOrDefault

                                    Catch ex As Exception
                                        ProductCode = Nothing
                                    End Try

                                End If

                                If String.IsNullOrEmpty(ProductCode) = False Then

                                    ThisProductCode = ProductCode

                                    Try

                                        JobNumber = (From Entity In AdvantageFramework.Database.Procedures.JobView.LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode)
                                                     Where Entity.ClientCode = ThisClientCode AndAlso
                                                           Entity.DivisionCode = ThisDivisionCode AndAlso
                                                           Entity.ProductCode = ThisProductCode AndAlso
                                                           Entity.IsOpen = 1
                                                     Select [JN] = Entity.JobNumber).SingleOrDefault

                                    Catch ex As Exception
                                        JobNumber = Nothing
                                    End Try

                                    If JobNumber.HasValue AndAlso JobNumber.Value > 0 Then

                                        ThisJobNumber = JobNumber

                                        Try

                                            JobComponentNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Session.UserCode, Nothing, Nothing, Nothing, ThisJobNumber, True, Nothing)
                                                                  Select [JCN] = Entity.JobComponentNumber).SingleOrDefault

                                        Catch ex As Exception
                                            JobComponentNumber = Nothing
                                        End Try

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Public Sub CheckPOExceedFlag(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer)

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim POTotal As Decimal = Nothing

            Try

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)

                If PurchaseOrder IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                    If Employee IsNot Nothing Then

                        If Employee.PurchaseOrderLimit.HasValue Then

                            Try

                                POTotal = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, PONumber)
                                           Select Entity.ExtendedAmount).Sum

                            Catch ex As Exception
                                POTotal = 0
                            End Try

                            If Employee.PurchaseOrderLimit > POTotal Then

                                PurchaseOrder.ExceedFlag = 1

                            Else

                                PurchaseOrder.ExceedFlag = 0

                            End If

                            AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder)

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadJobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String,
                                          ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)

            'objects
            Dim JobComponentViewObjectQuery As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            Try

                If DbContext IsNot Nothing Then

                    JobComponentViewObjectQuery = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, False, _AllowedProcessControls)

                End If

                LoadJobComponents = JobComponentViewObjectQuery

            Catch ex As Exception
                LoadJobComponents = Nothing
            End Try

        End Function
        Public Function LoadJobComponentsByEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                    ByVal EmployeeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String,
                                                    ByVal ProductCode As String, ByVal JobNumber As Integer) As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)

            'objects
            Dim JobComponentViewList As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            Try

                If DbContext IsNot Nothing Then

                    JobComponentViewList = LoadJobComponents(DbContext, "", ClientCode, DivisionCode, ProductCode, JobNumber)

                End If

                LoadJobComponentsByEmployee = JobComponentViewList

            Catch ex As Exception
                LoadJobComponentsByEmployee = Nothing
            End Try

        End Function
        Public Function LoadJobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                 ByVal UserCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job)

            'objects
            Dim JobObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job) = Nothing

            Try

                If DbContext IsNot Nothing Then

                    JobObjectQuery = AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, UserCode)

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        JobObjectQuery = JobObjectQuery.Where(Function(Job) Job.ClientCode = ClientCode)

                    End If

                    If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                        JobObjectQuery = JobObjectQuery.Where(Function(Job) Job.DivisionCode = DivisionCode)

                    End If

                    If String.IsNullOrWhiteSpace(ProductCode) = False Then

                        JobObjectQuery = JobObjectQuery.Where(Function(Job) Job.ProductCode = ProductCode)

                    End If

                End If

                LoadJobs = JobObjectQuery

            Catch ex As Exception
                LoadJobs = Nothing
            End Try


        End Function
        Public Function LoadClients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                    ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            'objects
            Dim ClientObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client) = Nothing

            Try

                If DbContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                    ClientObjectQuery = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, UserCode)

                End If

                LoadClients = ClientObjectQuery

            Catch ex As Exception
                LoadClients = Nothing
            End Try

        End Function
        Public Function LoadDivisions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal UserCode As String, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            'objects
            Dim DivisionObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division) = Nothing

            Try

                If DbContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                    DivisionObjectQuery = AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, UserCode)

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        DivisionObjectQuery = DivisionObjectQuery.Where(Function(Division) Division.ClientCode = ClientCode)

                    End If

                End If

                LoadDivisions = DivisionObjectQuery

            Catch ex As Exception
                LoadDivisions = Nothing
            End Try

        End Function
        Public Function LoadProducts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal UserCode As String, ByVal ClientCode As String, ByVal DivisionCode As String) As IEnumerable(Of AdvantageFramework.Database.Entities.Product)

            'objects
            Dim ProductObjectQuery As IEnumerable(Of AdvantageFramework.Database.Entities.Product) = Nothing

            Try

                If DbContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                    ProductObjectQuery = AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, UserCode, False, True)

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        ProductObjectQuery = ProductObjectQuery.Where(Function(Product) Product.ClientCode = ClientCode)

                    End If

                    If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                        ProductObjectQuery = ProductObjectQuery.Where(Function(Product) Product.DivisionCode = DivisionCode)

                    End If

                End If

                LoadProducts = ProductObjectQuery.ToList

            Catch ex As Exception
                LoadProducts = Nothing
            End Try

        End Function
        Public Function LoadFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            Try

                LoadFunctions = From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                Where Item.Type = "V"
                                Select Item

            Catch ex As Exception
                LoadFunctions = Nothing
            End Try

        End Function
        Public Sub PreparePurchaseOrderListForCopy(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String,
                                                   ByRef PurchaseOrderDetailsToCopy As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail), ByVal ExcludeJobComponentData As Boolean)

            'objects
            Dim FormattedPurchaseOrderDetails As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
            Dim ClearJob As Boolean = False

            Try

                For Each PurchaseOrderDetail In PurchaseOrderDetailsToCopy

                    ClearJob = ExcludeJobComponentData

                    If ClearJob = False Then

                        If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                            If (From Item In AdvantageFramework.PurchaseOrders.LoadJobComponents(DbContext, UserCode, Nothing, Nothing, Nothing, PurchaseOrderDetail.JobNumber)
                                Where Item.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
                                Select Item).Any = False Then

                                ClearJob = True

                            End If

                        End If

                    End If

                    If ClearJob Then

                        With PurchaseOrderDetail

                            .ClientCode = Nothing
                            .ClientName = Nothing
                            .DivisionCode = Nothing
                            .DivisionName = Nothing
                            .ProductCode = Nothing
                            .ProductDescription = Nothing
                            .JobNumber = Nothing
                            .JobDescription = Nothing
                            .JobComponentNumber = Nothing
                            .JobComponentID = Nothing
                            .JobComponentDescription = Nothing

                        End With

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        Public Function CopyPurchaseOrderDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer, ByVal PurchaseOrderDetailToCopy As AdvantageFramework.Database.Classes.PurchaseOrderDetail) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            Try

                PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                With PurchaseOrderDetail

                    .DbContext = DbContext
                    .PurchaseOrderNumber = PONumber
                    .Description = PurchaseOrderDetailToCopy.DetailDescription
                    .LineDescription = PurchaseOrderDetailToCopy.LineDescription
                    .Instructions = PurchaseOrderDetailToCopy.Instructions
                    .Quantity = PurchaseOrderDetailToCopy.Quantity
                    .Rate = PurchaseOrderDetailToCopy.Rate
                    .ExtendedAmount = PurchaseOrderDetailToCopy.ExtendedAmount
                    .TaxPercent = PurchaseOrderDetailToCopy.TaxPercent
                    .JobNumber = PurchaseOrderDetailToCopy.JobNumber
                    .JobComponentNumber = PurchaseOrderDetailToCopy.JobComponentNumber
                    .FunctionCode = PurchaseOrderDetailToCopy.FunctionCode
                    .CommissionPercent = PurchaseOrderDetailToCopy.CommissionPercent
                    .ExtendedMarkupAmount = PurchaseOrderDetailToCopy.ExtendedMarkupAmount
                    .GLACode = PurchaseOrderDetailToCopy.GeneralLedgerCode

                End With

                Copied = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

            Catch ex As Exception
                Copied = False
            Finally
                CopyPurchaseOrderDetail = Copied
            End Try

        End Function
        Public Function LoadGeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

            LoadGeneralLedgerAccounts = LoadGeneralLedgerAccounts(DbContext, Session, Employee)

        End Function
        Public Function LoadGeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session, ByVal Employee As AdvantageFramework.Database.Views.Employee) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim GeneralLedgerAccountObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim CrossReferenceCode As String = Nothing

            If Employee IsNot Nothing Then

                If CBool(Employee.AllowPOGLSelection.GetValueOrDefault(0)) Then

                    GeneralLedgerAccountObjectQuery = From Item In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session)
                                                      Where Item.PurchaseOrder = 1
                                                      Select Item

                    If CBool(Employee.LimitPOGLSelectionOffice.GetValueOrDefault(0)) AndAlso Not [String].IsNullOrEmpty(Employee.OfficeCode) Then

                        CrossReferenceCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Employee.OfficeCode).Code

                        GeneralLedgerAccountObjectQuery = GeneralLedgerAccountObjectQuery.Where(Function(Gla) Gla.GeneralLedgerOfficeCrossReferenceCode = CrossReferenceCode)

                    End If

                End If

            End If

            LoadGeneralLedgerAccounts = GeneralLedgerAccountObjectQuery

        End Function
        Public Function LoadEmployeeAccess(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                           ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)

            Dim EmployeeUserCodes As String() = Nothing
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            Try

                EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
                                     Select Entity.UserCode).ToArray

            Catch ex As Exception
                EmployeeUserCodes = Nothing
            End Try

            If EmployeeUserCodes IsNot Nothing Then

                Try

                    UserClientDivisionProductAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext).ToList

                    UserClientDivisionProductAccessList = (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
                                                           Where EmployeeUserCodes.Contains(Entity.UserCode)
                                                           Select Entity).ToList

                Catch ex As Exception
                    UserClientDivisionProductAccessList = Nothing
                End Try

            End If

            LoadEmployeeAccess = UserClientDivisionProductAccessList

        End Function
        Public Sub LoadVendorPayToInformation(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal VendorCode As String, ByRef Name As String, ByRef PayToCode As String,
                                              ByRef PayToName As String, ByRef PayToAddress As String, ByRef PayToAddress2 As String,
                                              ByRef PayToAddress3 As String, ByRef PayToCity As String, ByRef PayToCounty As String,
                                              ByRef PayToState As String, ByRef PayToZip As String, ByRef PayToCountry As String,
                                              ByRef PayToPhone As String, ByRef PayToPhoneExt As String, ByRef PayToFax As String,
                                              ByRef PayToFaxExt As String)

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

            If Vendor IsNot Nothing Then

                LoadVendorPayToInformation(DbContext, Vendor, Name, PayToCode, PayToName, PayToAddress, PayToAddress2, PayToAddress3, PayToCity, PayToCounty,
                                           PayToState, PayToZip, PayToCountry, PayToPhone, PayToPhoneExt, PayToFax, PayToFaxExt)

            End If

        End Sub
        Public Sub LoadVendorPayToInformation(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal Vendor As AdvantageFramework.Database.Entities.Vendor,
                                              ByRef Name As String, ByRef PayToCode As String, ByRef PayToName As String,
                                              ByRef PayToAddress As String, ByRef PayToAddress2 As String, ByRef PayToAddress3 As String,
                                              ByRef PayToCity As String, ByRef PayToCounty As String, ByRef PayToState As String,
                                              ByRef PayToZip As String, ByRef PayToCountry As String, ByRef PayToPhone As String,
                                              ByRef PayToPhoneExt As String, ByRef PayToFax As String, ByRef PayToFaxExt As String)

            'objects
            Dim PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim UsePayTo As Boolean = False

            Name = ""
            PayToCode = ""
            PayToName = ""
            PayToAddress = ""
            PayToAddress2 = ""
            PayToCity = ""
            PayToCounty = ""
            PayToState = ""
            PayToZip = ""
            PayToCountry = ""

            If Vendor IsNot Nothing Then

                Name = Vendor.Name

                UsePayTo = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).APShowPayToInformation.GetValueOrDefault(0))

                If UsePayTo Then

                    If Vendor.PayToCode <> Vendor.Code Then

                        PayToVendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Vendor.PayToCode)

                    Else

                        PayToVendor = Vendor

                    End If

                    PayToCode = PayToVendor.Code
                    PayToName = PayToVendor.PayToName
                    PayToAddress = PayToVendor.PayToAddressLine1
                    PayToAddress2 = PayToVendor.PayToAddressLine2
                    PayToAddress3 = "" 'no PayToAddressLine3 in database
                    PayToCity = PayToVendor.PayToCity
                    PayToCounty = PayToVendor.PayToCounty
                    PayToState = PayToVendor.PayToState
                    PayToZip = PayToVendor.PayToZipCode
                    PayToCountry = PayToVendor.PayToCountry

                    ' phone & fax comes from vendor not from payToVendor!
                    PayToPhone = Vendor.PayToPhoneNumber
                    PayToPhoneExt = Vendor.PayToPhoneNumberExtension
                    PayToFax = Vendor.PayToFaxPhoneNumber
                    PayToFaxExt = Vendor.PayToFaxPhoneNumberExtension

                Else

                    PayToCode = Vendor.Code
                    PayToName = Vendor.Name
                    PayToAddress = Vendor.StreetAddressLine1
                    PayToAddress2 = Vendor.StreetAddressLine2
                    PayToAddress3 = Vendor.StreetAddressLine3
                    PayToCity = Vendor.City
                    PayToCounty = Vendor.County
                    PayToState = Vendor.State
                    PayToZip = Vendor.ZipCode
                    PayToCountry = Vendor.Country
                    PayToPhone = Vendor.PhoneNumber
                    PayToPhoneExt = Vendor.PhoneNumberExtension
                    PayToFax = Vendor.FaxPhoneNumber
                    PayToFaxExt = Vendor.FaxPhoneNumberExtension

                End If

            End If

        End Sub
        Public Function ValidatePurchaseOrderWithOfficeLimits(ByVal Session As AdvantageFramework.Security.Session,
                                                              ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder,
                                                              ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If Not String.IsNullOrWhiteSpace(PurchaseOrder.VendorCode) Then

                    If Not AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Session).Where(Function(v) v.Code = PurchaseOrder.VendorCode).Any Then

                        ErrorMessage &= AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.Methods.PropertyTypes.VendorCode)
                        IsValid = False

                    End If

                End If

                If Not String.IsNullOrWhiteSpace(PurchaseOrder.EmployeeCode) Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If Not LoadEmployees(Session, DbContext, SecurityDbContext).Where(Function(e) e.Code = PurchaseOrder.EmployeeCode).Any Then

                            ErrorMessage &= AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.Methods.PropertyTypes.EmployeeCode)
                            IsValid = False

                        End If

                    End Using

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ValidatePurchaseOrderWithOfficeLimits = IsValid
            End Try

        End Function
        Public Function ValidatePurchaseOrderDetailWithOfficeLimits(ByVal Session As AdvantageFramework.Security.Session,
                                                                    ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail,
                                                                    ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    If Not AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Session.UserCode, Nothing, Nothing, Nothing, PurchaseOrderDetail.JobNumber, Nothing, Nothing).Any(Function(jc) jc.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber) Then

                        IsValid = False
                        ErrorMessage = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.Methods.PropertyTypes.JobComponent)

                    End If

                End If

                If Not String.IsNullOrWhiteSpace(PurchaseOrderDetail.GeneralLedgerCode) Then

                    If Not LoadGeneralLedgerAccounts(DbContext, Session).Any(Function(gla) gla.Code = PurchaseOrderDetail.GeneralLedgerCode) Then

                        IsValid = False
                        ErrorMessage &= AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.PropertyTypes.GeneralLedgerAccountCode)

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ValidatePurchaseOrderDetailWithOfficeLimits = IsValid
            End Try

        End Function
        Public Function LoadEmployees(ByVal Session As AdvantageFramework.Security.Session,
                                      ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Views.Employee)

            Try

                LoadEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Session, DbContext, SecurityDbContext)

            Catch ex As Exception
                LoadEmployees = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
