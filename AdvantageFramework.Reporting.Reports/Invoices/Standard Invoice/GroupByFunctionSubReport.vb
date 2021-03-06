Namespace Invoices.StandardInvoice

	Public Class GroupByFunctionSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _IsDraft As Boolean = False

		Private _Session As AdvantageFramework.Security.Session = Nothing
		Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
		Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing

		Private _BillingApprovalComments As String = ""
		Private _BillingDetailComments As String = ""

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

					If CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = Me.GetCurrentColumnValue("FunctionCode")).Sum(Function(Entity) Entity.TotalTax.GetValueOrDefault(0)) <> 0 Then

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

			If CanShowFunctionDetails = False Then

				If _InvoicePrintingSetting IsNot Nothing Then

					If _InvoicePrintingSetting.HideFunctionTotals Then

						e.Cancel = True

					Else

						If _InvoicePrintingSetting.ShowQuantity = False AndAlso _InvoicePrintingSetting.ShowEmployeeHours = False Then

							e.Cancel = True

						End If

					End If

				End If

			Else

				e.Cancel = True

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

				e.Cancel = True

			End If

		End Sub
		Public Sub SetParameterValues()

            'ShowEmployeeFunctionDetails.Value = _InvoicePrintingSetting.ShowEmployeeFunctionDetails
            'ShowVendorFunctionDetails.Value = _InvoicePrintingSetting.ShowVendorFunctionDetails
            'ShowIncomeOnlyFunctionDetails.Value = _InvoicePrintingSetting.ShowIncomeOnlyFunctionDetails
            EstimateFunctionComment.Value = _InvoicePrintingSetting.IncludeEstimateFunctionComment
			BillingApprovalFunctionComment.Value = _InvoicePrintingSetting.BackupReportCommentOptionBillingApprovalClientFunction.GetValueOrDefault(False)
			InvoiceComment.Value = _InvoicePrintingSetting.IncludeBillingComment.GetValueOrDefault(False)

		End Sub
        Private Sub XrSubreportFunctionDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportFunctionDetails.BeforePrint

            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
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
                    TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail AndAlso _InvoicePrintingSetting IsNot Nothing Then

                FunctionDetailSubReport = XrSubreportFunctionDetails.ReportSource
                StandardInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = FunctionCode).ToList

                FunctionDetailSubReport.Session = _Session
                FunctionDetailSubReport.AccountReceivableInvoice = _AccountReceivableInvoice

                FunctionDetailSubReport.HideFunctionTotals.Value = HideFunctionTotals.Value
                FunctionDetailSubReport.ShowQuantity.Value = ShowQuantity.Value
                FunctionDetailSubReport.ShowEmployeeHours.Value = ShowEmployeeHours.Value
                FunctionDetailSubReport.FunctionType.Value = FunctionType
                FunctionDetailSubReport.FunctionDescription.Value = FunctionDescription

                FunctionDetailSubReport.IsDraft = _IsDraft

                FunctionDetailSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                FunctionDetailSubReport.InvoiceDetails = StandardInvoiceDetails

            End If

        End Sub
        Private Sub XrTableCellBillingApprovalFunctionComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellBillingApprovalFunctionComment.BeforePrint

            'objects
            Dim Comment As String = Nothing

			Try

				For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionDescription = Me.GetCurrentColumnValue("FunctionDescription")).Select(Function(Entity) Entity.BillingApprovalFunctionComment).ToList

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

                For Each FunctionComment In CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionCode = Me.GetCurrentColumnValue("FunctionCode") AndAlso
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


#End Region

    End Class

End Namespace