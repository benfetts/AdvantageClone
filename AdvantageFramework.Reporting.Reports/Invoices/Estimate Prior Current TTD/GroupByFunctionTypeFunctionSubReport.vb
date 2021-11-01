Namespace Invoices.EstimatePriorCurrentTTD

	Public Class GroupByFunctionTypeFunctionSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _IsDraft As Boolean = False

		Private _Session As AdvantageFramework.Security.Session = Nothing
		Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
		Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
		Private _TTDCurrentAmount As Decimal = 0
		Private _PriorCurrentAmount As Decimal = 0
		Private _EstimateCurrentAmount As Decimal = 0

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

		Private Sub GroupHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader.BeforePrint

			If _InvoicePrintingSetting IsNot Nothing Then

				If _InvoicePrintingSetting.IndicateTaxableFunctions.GetValueOrDefault(False) Then

					XrLabelIsTaxable.Visible = True

				Else

					XrLabelIsTaxable.Visible = False

				End If

			Else

				XrLabelIsTaxable.Visible = False

			End If

		End Sub
		Private Sub XrLabelIsTaxable_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelIsTaxable.BeforePrint

			If _InvoicePrintingSetting IsNot Nothing Then

				If _InvoicePrintingSetting.IndicateTaxableFunctions.GetValueOrDefault(False) Then

					If CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = Me.GetCurrentColumnValue("FunctionCode")).Sum(Function(Entity) Entity.TotalTax.GetValueOrDefault(0)) <> 0 Then

                        XrLabelIsTaxable.Text = "*"

                    Else

                        XrLabelIsTaxable.Text = ""

                    End If

                End If

			End If

		End Sub
        Private Sub GroupFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter.BeforePrint


            If XrRichTextEstimateFunctionComment.DataBindings IsNot Nothing AndAlso XrRichTextEstimateFunctionComment.DataBindings.Count > 0 Then

                XrRichTextEstimateFunctionComment.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

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

			If CanShowFunctionDetails = False Then

				If _InvoicePrintingSetting IsNot Nothing Then

					If _InvoicePrintingSetting.HideFunctionTotals Then

						e.Cancel = True

					End If

				End If

			Else

				If CheckForCurrentAmount() Then

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

			If CanShowFunctionDetails = False Then

				If _InvoicePrintingSetting IsNot Nothing Then

					If _InvoicePrintingSetting.HideFunctionTotals Then

						e.Cancel = True

					End If

				End If

			Else

				If CheckForCurrentAmount() Then

					e.Cancel = True

				End If

			End If

		End Sub
		Private Sub XrLabelPriorCurrentAmount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelPriorCurrentAmount.BeforePrint

            'objects
            Dim CanShowFunctionDetails As Boolean = True
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			CanShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

			If CanShowFunctionDetails = False Then

				If _InvoicePrintingSetting IsNot Nothing Then

					If _InvoicePrintingSetting.HideFunctionTotals Then

						e.Cancel = True

					End If

				End If

			Else

				If CheckForCurrentAmount() Then

					e.Cancel = True

				End If

			End If

		End Sub
		Private Sub XrLabelEstimateCurrentAmount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelEstimateCurrentAmount.BeforePrint

            'objects
            Dim CanShowFunctionDetails As Boolean = True
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			CanShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

			If CanShowFunctionDetails = False Then

				If _InvoicePrintingSetting IsNot Nothing Then

					If _InvoicePrintingSetting.HideFunctionTotals Then

						e.Cancel = True

					End If

				End If

			Else

				If CheckForCurrentAmount() Then

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
        Private Sub GroupFooterFunctionType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterFunctionType.BeforePrint

			e.Cancel = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).All(Function(Entity) Entity.FunctionType = Me.GetCurrentColumnValue("FunctionType"))

		End Sub
        Private Sub XrSubreportFunctionDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportFunctionDetails.BeforePrint

            Dim EstimatePriorCurrentTTDInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail) = Nothing
            Dim FunctionDetailSubReport As FunctionDetailSubReport = Nothing
            Dim FunctionType As String = ""
            Dim FunctionCode As String = ""
            Dim FunctionDescription As String = ""

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

            e.Cancel = Not AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

            If e.Cancel = False AndAlso TypeOf XrSubreportFunctionDetails.ReportSource Is FunctionDetailSubReport AndAlso
                    TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail AndAlso _InvoicePrintingSetting IsNot Nothing AndAlso
                    CheckForCurrentAmount() Then

                FunctionDetailSubReport = XrSubreportFunctionDetails.ReportSource
                EstimatePriorCurrentTTDInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).ToList

                FunctionDetailSubReport.Session = _Session
                FunctionDetailSubReport.AccountReceivableInvoice = _AccountReceivableInvoice

                FunctionDetailSubReport.HideFunctionTotals.Value = HideFunctionTotals.Value
                FunctionDetailSubReport.ShowQuantity.Value = ShowQuantity.Value
                FunctionDetailSubReport.ShowEmployeeHours.Value = ShowEmployeeHours.Value
                FunctionDetailSubReport.FunctionType.Value = FunctionType
                FunctionDetailSubReport.FunctionDescription.Value = FunctionDescription
                FunctionDetailSubReport.TTDTotalAmount.Value = GetTTDTotalAmount(FunctionCode)
                FunctionDetailSubReport.PriorTotalAmount.Value = GetPriorTotalAmount(FunctionCode)
                FunctionDetailSubReport.EstimateTotalAmount.Value = GetEstimateTotalAmount(FunctionCode)

                FunctionDetailSubReport.IsDraft = _IsDraft

                FunctionDetailSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                FunctionDetailSubReport.InvoiceDetails = EstimatePriorCurrentTTDInvoiceDetails

            Else

                e.Cancel = True

            End If

        End Sub
        Private Function GetPriorTotalAmount(FunctionCode As String) As Decimal

            'objects
            Dim PriorTotalAmount As Decimal = 0

            Try

                PriorTotalAmount = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.PriorNetAmount.GetValueOrDefault(0)).Sum

            Catch ex As Exception
                PriorTotalAmount = 0
            End Try

            GetPriorTotalAmount = PriorTotalAmount

        End Function
        Private Function GetTTDTotalAmount(FunctionCode As String) As Decimal

            'objects
            Dim TTDTotalAmount As Decimal = 0

            Try

                TTDTotalAmount = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.TTDNetAmount.GetValueOrDefault(0)).Sum

            Catch ex As Exception
                TTDTotalAmount = 0
            End Try

            GetTTDTotalAmount = TTDTotalAmount

        End Function
        Private Function GetEstimateTotalAmount(FunctionCode As String) As Decimal

            'objects
            Dim EstimateTotalAmount As Decimal = 0

            Try

                EstimateTotalAmount = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.EstimateNetAmount.GetValueOrDefault(0)).Sum

            Catch ex As Exception
                EstimateTotalAmount = 0
            End Try

            GetEstimateTotalAmount = EstimateTotalAmount

        End Function
        Private Sub XrLabelTTDCurrentAmount_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabelTTDCurrentAmount.SummaryGetResult

			e.Result = _TTDCurrentAmount
			e.Handled = True

		End Sub
		Private Sub XrLabelTTDCurrentAmount_SummaryReset(sender As Object, e As EventArgs) Handles XrLabelTTDCurrentAmount.SummaryReset

			_TTDCurrentAmount = 0

		End Sub
		Private Sub XrLabelTTDCurrentAmount_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabelTTDCurrentAmount.SummaryRowChanged

			Dim EstimatePriorCurrentTTDInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail = Nothing

			If TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail Then

				EstimatePriorCurrentTTDInvoiceDetail = Me.GetCurrentRow

				_TTDCurrentAmount += EstimatePriorCurrentTTDInvoiceDetail.TTDNetAmount.GetValueOrDefault(0)

			End If

		End Sub
		Private Sub XrLabelEstimateCurrentAmount_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabelEstimateCurrentAmount.SummaryGetResult

			e.Result = _EstimateCurrentAmount
			e.Handled = True

		End Sub
		Private Sub XrLabelEstimateCurrentAmount_SummaryReset(sender As Object, e As EventArgs) Handles XrLabelEstimateCurrentAmount.SummaryReset

			_EstimateCurrentAmount = 0

		End Sub
		Private Sub XrLabelEstimateCurrentAmount_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabelEstimateCurrentAmount.SummaryRowChanged

			Dim EstimatePriorCurrentTTDInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail = Nothing

			If TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail Then

				EstimatePriorCurrentTTDInvoiceDetail = Me.GetCurrentRow

				_EstimateCurrentAmount += EstimatePriorCurrentTTDInvoiceDetail.EstimateNetAmount.GetValueOrDefault(0)

			End If

		End Sub
		Private Sub XrLabelPriorCurrentAmount_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabelPriorCurrentAmount.SummaryGetResult

			e.Result = _PriorCurrentAmount
			e.Handled = True

		End Sub
		Private Sub XrLabelPriorCurrentAmount_SummaryReset(sender As Object, e As EventArgs) Handles XrLabelPriorCurrentAmount.SummaryReset

			_PriorCurrentAmount = 0

		End Sub
		Private Sub XrLabelPriorCurrentAmount_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabelPriorCurrentAmount.SummaryRowChanged

			Dim EstimatePriorCurrentTTDInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail = Nothing

			If TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail Then

				EstimatePriorCurrentTTDInvoiceDetail = Me.GetCurrentRow

				_PriorCurrentAmount += EstimatePriorCurrentTTDInvoiceDetail.PriorNetAmount.GetValueOrDefault(0)

			End If

		End Sub
		Private Sub XrTableCellBillingApprovalFunctionComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellBillingApprovalFunctionComment.BeforePrint

            'objects
            Dim Comment As String = Nothing

			Try

				For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionDescription = Me.GetCurrentColumnValue("FunctionDescription")).Select(Function(Entity) Entity.BillingApprovalFunctionComment).ToList

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

                For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = Me.GetCurrentColumnValue("FunctionCode") AndAlso
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

            If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.ShowZeroFunctionAmounts = False Then

                If CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).Select(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)).Sum <> 0 Then

                    HasCurrentAmount = True

                End If

            Else

                HasCurrentAmount = True

            End If

            CheckForCurrentAmount = HasCurrentAmount

        End Function

#End Region

    End Class

End Namespace