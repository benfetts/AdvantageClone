Imports System.Collections

Namespace ViewModels.Employee.ExpenseApproval

    <Serializable()>
    Public Class ExpenseReportViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties

			UserCode
			Header
			Items
			Documents
			Message
			StatusDisplay

		End Enum
		'Public Enum StatusTypes

		'	Pending
		'	Denied
		'	Approved
		'	Open

		'End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property UserCode As String = String.Empty
		Public Property Header As ExpenseHeaderViewModel = Nothing
		Public Property Items As Generic.List(Of ExpenseItemViewModel) = Nothing
		Public Property Documents As Generic.List(Of ExpenseItemDocumentViewModel) = Nothing
		Public Property Message As String = String.Empty
		Public Property ApproverEmployeeCode As String = String.Empty
		Public Property ApproverFullname As String = String.Empty
		Public Property ApprovedDate As Date? = Nothing
		Public Property SubmittedToEmployeeCode As String = String.Empty
		Public Property SubmittedToFullname As String = String.Empty
		Public Property ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus? = Nothing
		Public Property ExpenseReportStatusDisplay As String = String.Empty

#End Region

#Region " Methods "

		Sub New()

			Header = New ExpenseHeaderViewModel
			Items = New List(Of ExpenseItemViewModel)
			Documents = New List(Of ExpenseItemDocumentViewModel)

		End Sub
		Sub New(ByVal UserCode As String, ByVal ApproverEmployeeCode As String)

			Me.Header = New ExpenseHeaderViewModel
			Me.Items = New List(Of ExpenseItemViewModel)
			Me.UserCode = UserCode
			Me.ApproverEmployeeCode = ApproverEmployeeCode
			Me.Documents = New List(Of ExpenseItemDocumentViewModel)

		End Sub

#End Region

	End Class

    <Serializable()>
    Public Class ExpenseHeaderViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties

			InvoiceNumber
			InvoiceDateDisplay
			EmployeeCode
			VendorCode
			InvoiceDate
			Description
			Details
			DateFrom
			DateTo
			InvoiceAmount
			Status
			IsSubmitted
			IsApproved
			CreatedBy
			CreatedDate
			ModifiedBy
			ModifiedDate
			SubmittedTo
			BatchDate

			ApprovedByEmployeeCode
			ApproverFullname
			ApprovedDate
			ApproverNotes

			SubmittedToEmployeeCode
			SubmittedToFullname

			'Documents

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property InvoiceNumber As Integer = 0
		Public Property EmployeeCode As String = String.Empty
		Public Property EmployeeFullName As String = String.Empty
		Public Property VendorCode As String = String.Empty
		Public Property InvoiceDate As Nullable(Of Date) = Nothing
		Public Property Description As String = String.Empty
		Public Property Details As String = String.Empty
		Public Property DateFrom As Nullable(Of Date) = Nothing
		Public Property DateTo As Nullable(Of Date) = Nothing
		Public Property InvoiceAmount As Nullable(Of Decimal) = Nothing
		Public Property Status As Nullable(Of Integer) = Nothing
		Public Property IsSubmitted As Nullable(Of Short) = Nothing
		Public Property ApprovedFlag As Nullable(Of Short) = Nothing
		Public Property CreatedBy As String = String.Empty
		Public Property CreatedDate As Nullable(Of Date) = Nothing
		Public Property ModifiedBy As String = String.Empty
		Public Property ModifiedDate As Nullable(Of Date) = Nothing
		Public Property BatchDate As Nullable(Of Date) = Nothing

		Public Property ApprovedByEmployeeCode As String = String.Empty
		Public Property ApprovedByFullname As String = String.Empty
		Public Property ApprovedDate As Nullable(Of Date) = Nothing
		Public Property ApproverNotes As String = String.Empty

		Public Property SubmittedToEmployeeCode As String = String.Empty
		Public Property SubmittedToFullname As String = String.Empty

		'Public Property Documents As Generic.List(Of ExpenseItemDocumentViewModel)
		Public ReadOnly Property ApprovedDateDisplay As String
			Get
				If ApprovedDate IsNot Nothing AndAlso IsDate(ApprovedDate) = True Then
					Return CType(ApprovedDate, Date).ToShortDateString
				Else
					Return ""
				End If
			End Get
		End Property


		Public ReadOnly Property InvoiceDateDisplay As String
			Get
				If InvoiceDate IsNot Nothing AndAlso IsDate(InvoiceDate) = True Then
					Return CType(InvoiceDate, Date).ToShortDateString
				Else
					Return ""
				End If
			End Get
		End Property
		Public ReadOnly Property StatusDisplay As String
			Get
				Dim s As String = "Pending"

				If ApprovedFlag IsNot Nothing Then

					Select Case ApprovedFlag
						Case 1
							s = "Denied"
						Case 2
							s = "Approved"
						Case Else
					End Select


				End If

				Return s

			End Get
		End Property

#End Region

#Region " Methods "

		Sub New()

			'Documents = New List(Of ExpenseItemDocumentViewModel)

		End Sub

#End Region

	End Class
    <Serializable()>
    Public Class ExpenseItemViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties

			ID
			ExpenseDetailID
			LineNumber
			ItemDate
			ItemDateDisplay
			CDPDisplay
			JobDisplay
			FunctionDescription
			Quantity
			Rate
			Amount
			IsCcYN
			Payable
			Description
			FunctionCode
			JobNumber
			JobComponentNumber
			'Documents

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID As Integer = 0
		Public Property ExpenseDetailID As Integer = 0
		Public Property LineNumber As Integer = 0
		Public Property ItemDate As Nullable(Of Date) = Nothing
		Public Property CDPDisplay As String = String.Empty
		Public Property JobDisplay As String = String.Empty
		Public Property FunctionDescription As String = String.Empty
		Public Property Quantity As Nullable(Of Integer) = Nothing
		Public Property Rate As Nullable(Of Decimal) = Nothing
		Public Property Amount As Nullable(Of Decimal) = Nothing
		Public Property IsCcYN As String = String.Empty
		Public Property Payable As Nullable(Of Decimal) = Nothing
		Public Property Description As String = String.Empty
		Public Property FunctionCode As String = String.Empty
		Public Property JobNumber As Nullable(Of Integer) = Nothing
		Public Property JobComponentNumber As Nullable(Of Short) = Nothing
		'Public Property Documents As Generic.List(Of ExpenseItemDocumentViewModel)

		'Public Property CreditCardFlag As Nullable(Of Boolean) = Nothing
		'Public Property ClientCode As String = String.Empty
		'Public Property DivisionCode As String = String.Empty
		'Public Property ProductCode As String = String.Empty
		'Public Property CreditCardAmount As Nullable(Of Decimal) = Nothing
		'Public Property APComment As String = String.Empty
		'Public Property CreatedBy As String = String.Empty
		'Public Property ModifiedBy As String = String.Empty
		'Public Property ModifiedDate As Nullable(Of Date) = Nothing
		'Public Property PaymentType As Nullable(Of Short) = Nothing
		'Public Property IsImported As Boolean = False
		'Public Property NonBillableYN As String = String.Empty

		Public ReadOnly Property ItemDateDisplay As String
			Get

				If ItemDate IsNot Nothing AndAlso IsDate(ItemDate) Then

					Return CType(ItemDate, Date).ToShortDateString

				Else

					Return ""

				End If

			End Get
		End Property


#End Region

#Region " Methods "

		Sub New()

			'Documents = New List(Of ExpenseItemDocumentViewModel)

		End Sub

#End Region

    End Class
	<Serializable()>
	Public Class ExpenseItemDocumentViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties

			ExpenseDetailID
			DocumentID
			FileName
			RepositoryFileName
			MimeType
			Description
			UploadedDate
			FileSize
			Link

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ExpenseDetailID As Integer? = Nothing
		Public Property DocumentID As Integer? = Nothing
		Public Property FileName As String = String.Empty
		Public Property RepositoryFileName As String = String.Empty
		Public Property MimeType As String = String.Empty
		Public Property Description As String = String.Empty
		Public Property UploadedDate As Date? = Nothing
		Public Property FileSize As Integer? = Nothing
		Public Property Link As String = String.Empty

#End Region

#Region " Methods "

		Sub New()

		End Sub

#End Region

	End Class

End Namespace
