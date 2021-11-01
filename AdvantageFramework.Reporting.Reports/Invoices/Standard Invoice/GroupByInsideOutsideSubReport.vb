Namespace Invoices.StandardInvoice

	Public Class GroupByInsideOutsideSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _IsDraft As Boolean = False

		Private _Session As AdvantageFramework.Security.Session = Nothing
		Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
		Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing

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

		Private Function CanShowFunctionDetails(FunctionType As String) As Boolean

			'objects
			Dim ShowFunctionDetails As Boolean = False
			Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing

			If String.IsNullOrWhiteSpace(FunctionType) = False Then

				If FunctionType = "E" Then

					ShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, FunctionType)

				Else

					StandardInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionType <> "E").ToList

					For Each OutsideFunctionType In StandardInvoiceDetails.Select(Function(Entity) Entity.FunctionType).Distinct

						ShowFunctionDetails = AdvantageFramework.InvoicePrinting.ShowFunctionDetails(_InvoicePrintingSetting, OutsideFunctionType)

						If ShowFunctionDetails Then

							Exit For

						End If

					Next

				End If

			End If

			CanShowFunctionDetails = ShowFunctionDetails

		End Function
		Private Sub GroupFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter.BeforePrint

			If XrRichTextEstimateFunctionComment.DataBindings IsNot Nothing AndAlso XrRichTextEstimateFunctionComment.DataBindings.Count > 0 Then

				XrRichTextEstimateFunctionComment.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

			End If

		End Sub
		Private Sub XrLabelQuantity_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelQuantity.BeforePrint

			'objects
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			If CanShowFunctionDetails(FunctionType) Then

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
			Dim FunctionType As String = ""

			Try

				FunctionType = Me.GetCurrentColumnValue("FunctionType")

			Catch ex As Exception
				FunctionType = ""
			End Try

			If CanShowFunctionDetails(FunctionType) Then

				If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideFunctionTotals Then

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

			'objects
			Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
            Dim FunctionDetailSubReport As FunctionDetailSubReport = Nothing
			Dim FunctionType As String = ""

			Try

                FunctionType = Me.GetCurrentColumnValue("FunctionType")

            Catch ex As Exception
                FunctionType = ""
            End Try

			e.Cancel = Not CanShowFunctionDetails(FunctionType)

			If e.Cancel = False AndAlso TypeOf XrSubreportFunctionDetails.ReportSource Is FunctionDetailSubReport AndAlso
                    TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail AndAlso _InvoicePrintingSetting IsNot Nothing Then

				FunctionDetailSubReport = XrSubreportFunctionDetails.ReportSource

				If FunctionType = "E" Then

					StandardInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionType = "E").ToList

				Else

					StandardInvoiceDetails = CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FunctionType <> "E").ToList

				End If

				FunctionDetailSubReport.Session = _Session
                FunctionDetailSubReport.AccountReceivableInvoice = _AccountReceivableInvoice

                FunctionDetailSubReport.HideFunctionTotals.Value = HideFunctionTotals.Value
                FunctionDetailSubReport.ShowQuantity.Value = ShowQuantity.Value
                FunctionDetailSubReport.ShowEmployeeHours.Value = ShowEmployeeHours.Value
                FunctionDetailSubReport.FunctionType.Value = FunctionType
				FunctionDetailSubReport.FunctionDescription.Value = Me.GetCurrentColumnValue("InsideOutsideFunction")

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