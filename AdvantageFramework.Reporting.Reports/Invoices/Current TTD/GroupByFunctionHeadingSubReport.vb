Namespace Invoices.CurrentTTD

    Public Class GroupByFunctionHeadingSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsDraft As Boolean = False

        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _TTDCurrentAmount As Decimal = 0

#End Region

#Region " Properties "

        Public WriteOnly Property IsDraft As Boolean
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property
        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice
            Set(value As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
                _AccountReceivableInvoice = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

                _InvoicePrintingSetting = value

                If _InvoicePrintingSetting IsNot Nothing Then

                    SetParameterValues()

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub GroupFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter.BeforePrint

			If XrRichTextEstimateFunctionComment.DataBindings IsNot Nothing AndAlso XrRichTextEstimateFunctionComment.DataBindings.Count > 0 Then

                XrRichTextEstimateFunctionComment.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

            End If

        End Sub
		Private Sub XrLabelQuantity_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelQuantity.BeforePrint

			'objects
			Dim CanShowFunctionDetails As Boolean = True
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			CanShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

			If CanShowFunctionDetails Then

				If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideFunctionTotals Then

					e.Cancel = True

				ElseIf _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.ShowQuantity = False AndAlso _InvoicePrintingSetting.ShowEmployeeHours = False Then

					e.Cancel = True

				End If

			Else

				If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.ShowQuantity = False AndAlso _InvoicePrintingSetting.ShowEmployeeHours = False Then

					e.Cancel = True

				End If

			End If

		End Sub
		Private Sub XrLabelCurrentAmount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelCurrentAmount.BeforePrint

			'objects
			Dim CanShowFunctionDetails As Boolean = True
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			CanShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

			If CanShowFunctionDetails Then

				If (_InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideFunctionTotals) OrElse CheckForCurrentAmount() Then

					e.Cancel = True

				End If

			End If

		End Sub
		Private Sub XrLabelTTDCurrentAmount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelTTDCurrentAmount.BeforePrint

			'objects
			Dim CanShowFunctionDetails As Boolean = True
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			CanShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

			If CanShowFunctionDetails Then

				If (_InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideFunctionTotals) OrElse CheckForCurrentAmount() Then

					e.Cancel = True

				End If

			End If

		End Sub
		Public Sub SetParameterValues()

            'ShowEmployeeFunctionDetails.Value = _InvoicePrintingSetting.ShowEmployeeFunctionDetails
            'ShowVendorFunctionDetails.Value = _InvoicePrintingSetting.ShowVendorFunctionDetails
            'ShowIncomeOnlyFunctionDetails.Value = _InvoicePrintingSetting.ShowIncomeOnlyFunctionDetails
            EstimateFunctionComment.Value = _InvoicePrintingSetting.IncludeEstimateFunctionComment
            BillingApprovalFunctionComment.Value = _InvoicePrintingSetting.BackupReportCommentOptionBillingApprovalClientFunction
            InvoiceComment.Value = _InvoicePrintingSetting.IncludeBillingComment

        End Sub
        Private Sub XrSubreportFunctionDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportFunctionDetails.BeforePrint

            Dim CurrentTTDInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail) = Nothing
            Dim FunctionDetailSubReport As FunctionDetailSubReport = Nothing
            Dim FunctionType As String = ""
            Dim FunctionCode As String = ""
            Dim FunctionDescription As String = ""
            Dim FunctionHeading As String = ""

            Try

                FunctionType = Me.GetCurrentColumnValue("FunctionType")

            Catch ex As Exception
                FunctionType = ""
            End Try

            Try

                FunctionCode = Me.GetCurrentColumnValue("FunctionCode")

            Catch ex As Exception
                FunctionCode = ""
            End Try

            Try

                FunctionDescription = Me.GetCurrentColumnValue("FunctionDescription")

            Catch ex As Exception
                FunctionDescription = ""
            End Try

            Try

                FunctionHeading = Me.GetCurrentColumnValue("FunctionHeading")

            Catch ex As Exception
                FunctionHeading = ""
            End Try

            e.Cancel = Not AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

            If e.Cancel = False AndAlso TypeOf XrSubreportFunctionDetails.ReportSource Is FunctionDetailSubReport AndAlso
                    TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail AndAlso
                    CheckForCurrentAmount() Then

                FunctionDetailSubReport = XrSubreportFunctionDetails.ReportSource
                CurrentTTDInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionHeading = FunctionHeading).ToList

                FunctionDetailSubReport.Session = _Session
                FunctionDetailSubReport.AccountReceivableInvoice = _AccountReceivableInvoice

                FunctionDetailSubReport.HideFunctionTotals.Value = HideFunctionTotals.Value
                FunctionDetailSubReport.ShowQuantity.Value = ShowQuantity.Value
                FunctionDetailSubReport.ShowEmployeeHours.Value = ShowEmployeeHours.Value
                FunctionDetailSubReport.FunctionType.Value = FunctionType
                FunctionDetailSubReport.FunctionDescription.Value = FunctionDescription
                FunctionDetailSubReport.TTDTotalAmount.Value = GetTTDTotalAmount(FunctionCode)

                FunctionDetailSubReport.IsDraft = _IsDraft

                FunctionDetailSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                FunctionDetailSubReport.InvoiceDetails = CurrentTTDInvoiceDetails

            Else

                e.Cancel = True

            End If

        End Sub
        Private Function GetTTDTotalAmount(FunctionCode As String) As Decimal

            'objects
            Dim TTDTotalAmount As Decimal = 0

            Try

                TTDTotalAmount = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.TTDNetAmount.GetValueOrDefault(0)).Sum

            Catch ex As Exception
                TTDTotalAmount = 0
            End Try

            GetTTDTotalAmount = TTDTotalAmount

        End Function
        Private Function GetOriginalFunctionCodes(FunctionCode As String) As String

            'objects
            Dim OriginalFunctionCodes As String = ""

            Try

                OriginalFunctionCodes = String.Join(",", CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.OriginalFunctionCode).ToArray)

            Catch ex As Exception
                OriginalFunctionCodes = FunctionCode
            End Try

            GetOriginalFunctionCodes = OriginalFunctionCodes

        End Function
        Private Sub XrLabelTTDCurrentAmount_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabelTTDCurrentAmount.SummaryGetResult

            e.Result = _TTDCurrentAmount
            e.Handled = True

        End Sub
        Private Sub XrLabelTTDCurrentAmount_SummaryReset(sender As Object, e As EventArgs) Handles XrLabelTTDCurrentAmount.SummaryReset

            _TTDCurrentAmount = 0

        End Sub
        Private Sub XrLabelTTDCurrentAmount_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabelTTDCurrentAmount.SummaryRowChanged

            Dim CurrentTTDInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail = Nothing

            If TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail Then

                CurrentTTDInvoiceDetail = Me.GetCurrentRow

                _TTDCurrentAmount += CurrentTTDInvoiceDetail.TTDNetAmount.GetValueOrDefault(0)

            End If

        End Sub
        Private Sub XrTableCellBillingApprovalFunctionComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellBillingApprovalFunctionComment.BeforePrint

            'objects
            Dim Comment As String = Nothing

            Try

                For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionDescription = Me.GetCurrentColumnValue("FunctionDescription")).Select(Function(Entity) Entity.BillingApprovalFunctionComment).ToList

                    If String.IsNullOrWhiteSpace(Comment) Then

                        Comment = FunctionComment

                    Else

                        Comment &= System.Environment.NewLine & FunctionComment

                    End If

                Next

            Catch ex As Exception
                Comment = Nothing
            End Try

            XrTableCellBillingApprovalFunctionComment.Text = Comment

            'e.Cancel = String.IsNullOrWhiteSpace(Comment)

        End Sub
        Private Sub XrTableCellBillingDetailComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellBillingDetailComment.BeforePrint

            'objects
            Dim Comment As String = Nothing

            Try

                For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = Me.GetCurrentColumnValue("FunctionCode") AndAlso
                                                                                                                                                                             Entity.FunctionDescription = Me.GetCurrentColumnValue("FunctionDescription")).Select(Function(Entity) Entity.BillingDetailComment).ToList

                    If String.IsNullOrWhiteSpace(Comment) Then

                        Comment = FunctionComment

                    Else

                        Comment &= System.Environment.NewLine & FunctionComment

                    End If

                Next

            Catch ex As Exception
                Comment = Nothing
            End Try

            XrTableCellBillingDetailComment.Text = Comment

        End Sub
        Private Function CheckForCurrentAmount() As Boolean

            'objects
            Dim FunctionCode As String = ""
            Dim HasCurrentAmount As Boolean = False

            Try

                FunctionCode = Me.GetCurrentColumnValue("FunctionCode")

            Catch ex As Exception
                FunctionCode = ""
            End Try

            If CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)).Sum <> 0 Then

                HasCurrentAmount = True

            End If

            CheckForCurrentAmount = HasCurrentAmount

        End Function
        Private Sub XrRichTextEstimateFunctionComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrRichTextEstimateFunctionComment.BeforePrint

            'objects
            Dim Comment As String = String.Empty

            Try

                For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionHeading = Me.GetCurrentColumnValue("FunctionHeading")).Select(Function(Entity) Entity.EstimateFunctionComment).ToList

                    If String.IsNullOrWhiteSpace(Comment) Then

                        Comment = FunctionComment

                    Else

                        Comment &= "<br />" & FunctionComment

                    End If

                Next

            Catch ex As Exception
                Comment = String.Empty
            End Try

            CType(sender, DevExpress.XtraReports.UI.XRRichText).Html = String.Format("<div style=""font-family:Arial; font-size:9pt;"">{0}</div>", Comment)

        End Sub

#End Region

    End Class

End Namespace