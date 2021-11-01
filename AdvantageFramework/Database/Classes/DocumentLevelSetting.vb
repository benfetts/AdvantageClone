Namespace Database.Classes

    <Serializable()>
    Public Class DocumentLevelSetting
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            CampaignID
            JobNumber
            JobComponentNumber
            VendorCode
            AccountPayableID
            AdNumber
            EmployeeCode
            ExpenseReportInvoiceNumber
            ExpenseDetailID
            ContractID
            ValueAddedID
            ContractReportID
            AccountReceivableInvoiceNumber
            AccountReceivableSequenceNumber
            AccountReceivableType
			DepartmentCode
			VendorContractID
			OrderNumber
            MediaType
            MediaTrafficDetailID
            AlertID
            GLTransaction
            MediaPlanID
            DocumentLevel
            DocumentSubLevel
        End Enum

#End Region

#Region " Variables "

        Private _OfficeCode As String = ""
        Private _ClientCode As String = ""
        Private _DivisionCode As String = ""
        Private _ProductCode As String = ""
        Private _CampaignID As String = ""
        Private _JobNumber As String = ""
        Private _JobComponentNumber As String = ""
        Private _VendorCode As String = ""
        Private _AccountPayableID As String = ""
        Private _AdNumber As String = ""
        Private _EmployeeCode As String = ""
        Private _ExpenseReportInvoiceNumber As String = ""
        Private _ExpenseDetailID As String = ""
        Private _ContractID As String = ""
        Private _ValueAddedID As String = ""
        Private _ContractReportID As String = ""
        Private _AccountReceivableInvoiceNumber As Integer = Nothing
        Private _AccountReceivableSequenceNumber As Short = Nothing
        Private _AccountReceivableType As String = Nothing
		Private _DepartmentCode As String = ""
		Private _VendorContractID As String = ""
		Private _OrderNumber As String = ""
		Private _MediaType As String = ""
		Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As String
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As String)
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As String
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As String)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As String
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As String)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableID() As String
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As String)
                _AccountPayableID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportInvoiceNumber() As String
            Get
                ExpenseReportInvoiceNumber = _ExpenseReportInvoiceNumber
            End Get
            Set(value As String)
                _ExpenseReportInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseDetailID() As String
            Get
                ExpenseDetailID = _ExpenseDetailID
            End Get
            Set(value As String)
                _ExpenseDetailID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractID() As String
            Get
                ContractID = _ContractID
            End Get
            Set(value As String)
                _ContractID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ValueAddedID() As String
            Get
                ValueAddedID = _ValueAddedID
            End Get
            Set(value As String)
                _ValueAddedID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractReportID() As String
            Get
                ContractReportID = _ContractReportID
            End Get
            Set(value As String)
                _ContractReportID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableInvoiceNumber() As Integer
            Get
                AccountReceivableInvoiceNumber = _AccountReceivableInvoiceNumber
            End Get
            Set(value As Integer)
                _AccountReceivableInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableSequenceNumber() As Short
            Get
                AccountReceivableSequenceNumber = _AccountReceivableSequenceNumber
            End Get
            Set(value As Short)
                _AccountReceivableSequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableType() As String
            Get
                AccountReceivableType = _AccountReceivableType
            End Get
            Set(value As String)
                _AccountReceivableType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(value As String)
                _DepartmentCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorContractID() As String
            Get
                VendorContractID = _VendorContractID
            End Get
            Set(value As String)
                _VendorContractID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderNumber() As String
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As String)
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaTrafficDetailID() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanID() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentLevel() As AdvantageFramework.Database.Entities.DocumentLevel
            Get
                DocumentLevel = _DocumentLevel
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentSubLevel() As AdvantageFramework.Database.Entities.DocumentSubLevel
            Get
                DocumentSubLevel = _DocumentSubLevel
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, Optional DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Entities.DocumentSubLevel.Default)

            _DocumentLevel = DocumentLevel
            _DocumentSubLevel = DocumentSubLevel

        End Sub
        Public Function LoadDocumentLevelSettingASPString() As String

			'objects
			Dim ASPString As String = String.Empty

			ASPString = "&DocumentLevel=" & _DocumentLevel.ToString & "&DocumentSubLevel=" & _DocumentSubLevel.ToString

			Select Case _DocumentLevel

				Case Database.Entities.DocumentLevel.Office

					ASPString &= "&OfficeCode=" & Me.OfficeCode

				Case Database.Entities.DocumentLevel.Client

					ASPString &= "&ClientCode=" & Me.ClientCode

				Case Database.Entities.DocumentLevel.Division

					ASPString &= "&ClientCode=" & Me.ClientCode & "&DivisionCode=" & Me.DivisionCode

				Case Database.Entities.DocumentLevel.Product

					ASPString &= "&OfficeCode=" & Me.OfficeCode & "&ClientCode=" & Me.ClientCode & "&DivisionCode=" & Me.DivisionCode & "&ProductCode=" & Me.ProductCode

				Case Database.Entities.DocumentLevel.Campaign

					ASPString &= "&CampaignID=" & Me.CampaignID

				Case Database.Entities.DocumentLevel.Job

					ASPString &= "&OfficeCode=" & Me.OfficeCode & "&ClientCode=" & Me.ClientCode & "&DivisionCode=" & Me.DivisionCode & "&ProductCode=" & Me.ProductCode & "&JobNumber=" & Me.JobNumber

				Case Database.Entities.DocumentLevel.JobComponent

					ASPString &= "&OfficeCode=" & Me.OfficeCode & "&ClientCode=" & Me.ClientCode & "&DivisionCode=" & Me.DivisionCode & "&ProductCode=" & Me.ProductCode & "&JobNumber=" & Me.JobNumber & "&JobComponentNumber=" & Me.JobComponentNumber

				Case Database.Entities.DocumentLevel.AccountPayableInvoice

					ASPString &= "&AccountPayableID=" & Me.AccountPayableID

				Case Database.Entities.DocumentLevel.AdNumber

					ASPString &= "&AdNumber=" & Me.AdNumber & "&ClientCode=" & Me.ClientCode

				Case Database.Entities.DocumentLevel.ExpenseReceipts

					ASPString &= "&ExpenseReportInvoiceNumber=" & Me.ExpenseReportInvoiceNumber & "&EmployeeCode=" & Me.EmployeeCode

				Case Database.Entities.DocumentLevel.Employee

					ASPString &= "&EmployeeCode=" & Me.EmployeeCode

				Case Database.Entities.DocumentLevel.Vendor

					ASPString &= "&VendorCode=" & Me.VendorCode

				Case Database.Entities.DocumentLevel.Contract

					ASPString &= "&ContractID=" & Me.ContractID

				Case Database.Entities.DocumentLevel.ContractValueAdded

					ASPString &= "&ValueAddedID=" & Me.ValueAddedID

				Case Database.Entities.DocumentLevel.ContractReport

					ASPString &= "&ContractReportID=" & Me.ContractReportID

				Case Database.Entities.DocumentLevel.AccountReceivableInvoice

					ASPString &= "&AccountReceivableInvoiceNumber=" & Me.AccountReceivableInvoiceNumber & "&AccountReceivableSequenceNumber=" & Me.AccountReceivableSequenceNumber & "&AccountReceivableType=" & Me.AccountReceivableType

				Case Database.Entities.DocumentLevel.AgencyDesktop

					ASPString &= "&OfficeCode=" & Me.OfficeCode & "&DepartmentCode=" & Me.DepartmentCode

				Case Database.Entities.DocumentLevel.ExecutiveDesktop

					ASPString &= "&OfficeCode=" & Me.OfficeCode & "&EmployeeCode=" & Me.EmployeeCode

				Case Database.Entities.DocumentLevel.VendorContract

					ASPString &= "&VendorContractID=" & Me.VendorContractID

				Case Database.Entities.DocumentLevel.MediaOrder

					ASPString &= "&OrderNumber=" & Me.OrderNumber & "&MediaType=" & Me.MediaType

                Case Database.Entities.DocumentLevel.MediaTrafficDetail

                    ASPString &= "&MediaTrafficDetailID=" & Me.MediaTrafficDetailID

                Case Database.Entities.DocumentLevel.JournalEntry

                    ASPString &= "&GLTransaction=" & Me.GLTransaction

                Case Database.Entities.DocumentLevel.MediaPlan

                    ASPString &= "&MediaPlanID=" & Me.MediaPlanID

            End Select

            LoadDocumentLevelSettingASPString = ASPString

		End Function
		Public Function LoadDocumentLevelSettingASPDescriptionString(DbContext As AdvantageFramework.Database.DbContext) As String

			'objects
			Dim DescriptionString As String = String.Empty
			Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
			Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
			Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
			Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
			Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
			Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
			Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
			Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
			Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
			Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
			Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
			Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
			Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
			Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing
			Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
			Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
			Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
			Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
			Dim Order As AdvantageFramework.Database.Views.Order = Nothing

			Select Case _DocumentLevel

				Case Database.Entities.DocumentLevel.MediaOrder

					Order = AdvantageFramework.Database.Procedures.Order.Load(DbContext).FirstOrDefault(Function(Entity) Entity.OrderNumber = Me.OrderNumber)

					If Order IsNot Nothing Then

						DescriptionString &= "Media Order: " & Order.ToString

					Else

						DescriptionString &= "Media Order: " & Me.OrderNumber

					End If

				Case Database.Entities.DocumentLevel.Office

					Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)

					If Office IsNot Nothing Then

						DescriptionString &= "Office: " & Office.ToString

					Else

						DescriptionString &= "Office: " & Me.OfficeCode

					End If

				Case Database.Entities.DocumentLevel.Client

					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString

					Else

						DescriptionString &= "Client: " & Me.ClientCode

					End If

				Case Database.Entities.DocumentLevel.Division

					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)
					Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Me.ClientCode, Me.DivisionCode)

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Client: " & Me.ClientCode & System.Environment.NewLine

					End If

					If Division IsNot Nothing Then

						DescriptionString &= "Division: " & Division.ToString

					Else

						DescriptionString &= "Division: " & Me.DivisionCode

					End If

				Case Database.Entities.DocumentLevel.Product

					Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)
					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)
					Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Me.ClientCode, Me.DivisionCode)
					Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.ClientCode, Me.DivisionCode, Me.ProductCode)

					If Office IsNot Nothing Then

						DescriptionString &= "Office: " & Office.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Office: " & Me.OfficeCode & System.Environment.NewLine

					End If

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Client: " & Me.ClientCode & System.Environment.NewLine

					End If

					If Division IsNot Nothing Then

						DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Division: " & Me.DivisionCode & System.Environment.NewLine

					End If

					If Product IsNot Nothing Then

						DescriptionString &= "Product: " & Product.ToString

					Else

						DescriptionString &= "Product: " & Me.ProductCode

					End If

				Case Database.Entities.DocumentLevel.Campaign

					Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CampaignID)

					If Campaign IsNot Nothing Then

						If String.IsNullOrWhiteSpace(Campaign.ClientCode) = False Then

							Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Campaign.ClientCode)

							If Client IsNot Nothing Then

								DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Client: " & Campaign.ClientCode & System.Environment.NewLine

							End If

						End If

						If String.IsNullOrWhiteSpace(Campaign.ClientCode) = False AndAlso
								String.IsNullOrWhiteSpace(Campaign.DivisionCode) = False Then

							Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode)

							If Division IsNot Nothing Then

								DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Division: " & Campaign.DivisionCode & System.Environment.NewLine

							End If

						End If

						If String.IsNullOrWhiteSpace(Campaign.ClientCode) = False AndAlso
								String.IsNullOrWhiteSpace(Campaign.DivisionCode) = False AndAlso
								String.IsNullOrWhiteSpace(Campaign.ProductCode) = False Then

							Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode)

							If Product IsNot Nothing Then

								DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Product: " & Campaign.ProductCode & System.Environment.NewLine

							End If

						End If

						DescriptionString &= "Campaign: " & Campaign.ToString

					Else

						DescriptionString &= "Campaign: " & Me.CampaignID

					End If

				Case Database.Entities.DocumentLevel.Job

					Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)
					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)
					Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Me.ClientCode, Me.DivisionCode)
					Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.ClientCode, Me.DivisionCode, Me.ProductCode)
					Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

					If Office IsNot Nothing Then

						DescriptionString &= "Office: " & Office.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Office: " & Me.OfficeCode & System.Environment.NewLine

					End If

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Client: " & Me.ClientCode & System.Environment.NewLine

					End If

					If Division IsNot Nothing Then

						DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Division: " & Me.DivisionCode & System.Environment.NewLine

					End If

					If Product IsNot Nothing Then

						DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Product: " & Me.ProductCode & System.Environment.NewLine

					End If

					If Job IsNot Nothing Then

						DescriptionString &= "Job: " & Job.ToString(True)

					Else

						DescriptionString &= "Job: " & Me.JobNumber

					End If

				Case Database.Entities.DocumentLevel.JobComponent

					Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)
					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)
					Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Me.ClientCode, Me.DivisionCode)
					Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.ClientCode, Me.DivisionCode, Me.ProductCode)
					Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)
					JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

					If Office IsNot Nothing Then

						DescriptionString &= "Office: " & Office.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Office: " & Me.OfficeCode & System.Environment.NewLine

					End If

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Client: " & Me.ClientCode & System.Environment.NewLine

					End If

					If Division IsNot Nothing Then

						DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Division: " & Me.DivisionCode & System.Environment.NewLine

					End If

					If Product IsNot Nothing Then

						DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Product: " & Me.ProductCode & System.Environment.NewLine

					End If

					If Job IsNot Nothing Then

						DescriptionString &= "Job: " & Job.ToString(True) & System.Environment.NewLine

					Else

						DescriptionString &= "Job: " & Me.JobNumber & System.Environment.NewLine

					End If

					If JobComponent IsNot Nothing Then

						DescriptionString &= "Job Component: " & JobComponent.ToString(True, True)

					Else

						DescriptionString &= "Job Component: " & Me.JobComponentNumber

					End If

				Case Database.Entities.DocumentLevel.AccountPayableInvoice

					AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, Me.AccountPayableID).FirstOrDefault()

					If AccountPayable IsNot Nothing Then

						Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayable.VendorCode)

					End If

					If Vendor IsNot Nothing Then

						DescriptionString &= "Vendor: " & Vendor.ToString & System.Environment.NewLine
						DescriptionString &= "Invoice: " & AccountPayable.InvoiceNumber & System.Environment.NewLine
						DescriptionString &= "Invoice Date: " & AccountPayable.InvoiceDate.ToShortDateString & System.Environment.NewLine
						DescriptionString &= "Invoice Desc: " & AccountPayable.InvoiceDescription

					Else

						DescriptionString &= "Account Payable: " & Me.AccountPayableID

					End If

				Case Database.Entities.DocumentLevel.AdNumber

					Ad = AdvantageFramework.Database.Procedures.Ad.LoadByAdNumber(DbContext, Me.AdNumber)
					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.ClientCode)

					If Ad IsNot Nothing Then

						DescriptionString &= "Ad: " & Ad.ToString & System.Environment.NewLine

					Else

						DescriptionString &= "Ad: " & Me.AdNumber & System.Environment.NewLine

					End If

					If Client IsNot Nothing Then

						DescriptionString &= "Client: " & Client.ToString

					Else

						DescriptionString &= "Client: " & Me.ClientCode

					End If

				Case Database.Entities.DocumentLevel.ExpenseReceipts

					ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, Me.ExpenseReportInvoiceNumber)

					If ExpenseReport IsNot Nothing Then

						Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

						If Employee IsNot Nothing Then

							DescriptionString &= "Expense Report Invoice Number: " & ExpenseReport.ToString & System.Environment.NewLine
							DescriptionString &= "Employee: " & Employee.ToString

						Else

							DescriptionString &= "Expense Report Invoice Number: " & ExpenseReport.ToString & System.Environment.NewLine
							DescriptionString &= "Employee: " & Me.EmployeeCode

						End If

					Else

						DescriptionString &= "Expense Report Invoice Number: " & Me.ExpenseReportInvoiceNumber & System.Environment.NewLine

					End If

				Case Database.Entities.DocumentLevel.Employee

					Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.ClientCode)

					If Employee IsNot Nothing Then

						DescriptionString &= "Employee: " & Employee.ToString

					Else

						DescriptionString &= "Employee: " & Me.EmployeeCode

					End If

				Case Database.Entities.DocumentLevel.Vendor

					Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Me.VendorCode)

					If Vendor IsNot Nothing Then

						DescriptionString &= "Vendor: " & Vendor.ToString

					Else

						DescriptionString &= "Vendor: " & Me.VendorCode

					End If

				Case Database.Entities.DocumentLevel.Contract

					Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, Me.ContractID)

					If Contract IsNot Nothing Then

						Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)
						Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)
						Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Contract.ClientCode, Contract.DivisionCode, Contract.ProductCode)

						DescriptionString &= "Contract: " & Contract.Code & " - " & Contract.Description

						If Client IsNot Nothing Then

							DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

						Else

							DescriptionString &= "Client: " & Contract.ClientCode & System.Environment.NewLine

						End If

						If Division IsNot Nothing Then

							DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

						Else

							DescriptionString &= "Division: " & Contract.DivisionCode & System.Environment.NewLine

						End If

						If Product IsNot Nothing Then

							DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

						Else

							DescriptionString &= "Product: " & Contract.ProductCode & System.Environment.NewLine

						End If

					Else

						DescriptionString &= "Contract: " & Me.ContractID

					End If

				Case Database.Entities.DocumentLevel.ContractValueAdded

					ContractValueAdded = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, Me.ValueAddedID)

					If ContractValueAdded IsNot Nothing Then

						Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, ContractValueAdded.ContractID)

						If Contract IsNot Nothing Then

							Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)
							Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)
							Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Contract.ClientCode, Contract.DivisionCode, Contract.ProductCode)

							If Client IsNot Nothing Then

								DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Client: " & Contract.ClientCode & System.Environment.NewLine

							End If

							If Division IsNot Nothing Then

								DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Division: " & Contract.DivisionCode & System.Environment.NewLine

							End If

							If Product IsNot Nothing Then

								DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Product: " & Contract.ProductCode & System.Environment.NewLine

							End If

							DescriptionString &= "Contract: " & Contract.Code & " - " & Contract.Description

						End If

						DescriptionString &= "Contract Value Added: " & ContractValueAdded.Description

					Else

						DescriptionString &= "Contract Value Added: " & Me.ValueAddedID

					End If

				Case Database.Entities.DocumentLevel.ContractReport

					ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, Me.ContractReportID)

					If ContractReport IsNot Nothing Then

						Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, ContractReport.ContractID)

						If Contract IsNot Nothing Then

							Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)
							Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)
							Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Contract.ClientCode, Contract.DivisionCode, Contract.ProductCode)

							If Client IsNot Nothing Then

								DescriptionString &= "Client: " & Client.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Client: " & Contract.ClientCode & System.Environment.NewLine

							End If

							If Division IsNot Nothing Then

								DescriptionString &= "Division: " & Division.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Division: " & Contract.DivisionCode & System.Environment.NewLine

							End If

							If Product IsNot Nothing Then

								DescriptionString &= "Product: " & Product.ToString & System.Environment.NewLine

							Else

								DescriptionString &= "Product: " & Contract.ProductCode & System.Environment.NewLine

							End If

							DescriptionString &= "Contract: " & Contract.Code & " - " & Contract.Description

						End If

						DescriptionString &= "Contract Report: " & ContractReport.Description

					Else

						DescriptionString &= "Contract Report: " & Me.ContractReportID

					End If

				Case Database.Entities.DocumentLevel.AccountReceivableInvoice

					DescriptionString &= "AR Invoice Number: " & Me.AccountReceivableInvoiceNumber & System.Environment.NewLine &
										 "AR Seq Number: " & Me.AccountReceivableSequenceNumber & System.Environment.NewLine &
										 "AR Type: " & Me.AccountReceivableType

				Case Database.Entities.DocumentLevel.AgencyDesktop

					If String.IsNullOrWhiteSpace(Me.OfficeCode) = False Then

						Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)

						If Office IsNot Nothing Then

							DescriptionString &= "Office: " & Office.ToString & System.Environment.NewLine

						Else

							DescriptionString &= "Office: " & Me.OfficeCode & System.Environment.NewLine

						End If

					End If

					If String.IsNullOrWhiteSpace(Me.DepartmentCode) = False Then

						DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, Me.DepartmentCode)

						If DepartmentTeam IsNot Nothing Then

							DescriptionString &= "Department\Team: " & DepartmentTeam.ToString

						Else

							DescriptionString &= "Department\Team: " & Me.DepartmentCode

						End If

					End If

				Case Database.Entities.DocumentLevel.ExecutiveDesktop

					If String.IsNullOrWhiteSpace(Me.OfficeCode) = False Then

						Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.OfficeCode)

						If Office IsNot Nothing Then

							DescriptionString &= "Office: " & Office.ToString & System.Environment.NewLine

						Else

							DescriptionString &= "Office: " & Me.OfficeCode & System.Environment.NewLine

						End If

					End If

					If String.IsNullOrWhiteSpace(Me.EmployeeCode) = False Then

						Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.EmployeeCode)

						If Employee IsNot Nothing Then

							DescriptionString &= "Employee: " & Employee.ToString

						Else

							DescriptionString &= "Employee: " & Me.EmployeeCode

						End If

					End If

				Case Database.Entities.DocumentLevel.VendorContract

					VendorContract = AdvantageFramework.Database.Procedures.VendorContract.LoadByID(DbContext, Me.VendorContractID)

					If VendorContract IsNot Nothing Then

						Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorContract.VendorCode)

					End If

					If Vendor IsNot Nothing Then

						DescriptionString &= "Vendor: " & Vendor.ToString & System.Environment.NewLine &
											 "Vendor Contract: " & VendorContract.Description

					Else

						DescriptionString &= "Vendor Contract: " & Me.VendorContractID

					End If

                Case Database.Entities.DocumentLevel.JournalEntry

                    DescriptionString &= "Transaction: " & Me.GLTransaction

                Case Database.Entities.DocumentLevel.MediaPlan

                    DescriptionString &= "MediaPlan: " & Me.MediaPlanID

            End Select

			LoadDocumentLevelSettingASPDescriptionString = DescriptionString

		End Function
		Public Function ValidateDocumentLevelProperties() As Boolean

			'objects
			Dim IsValid As Boolean = True

			Select Case _DocumentLevel

				Case Database.Entities.DocumentLevel.MediaOrder

					IsValid = (String.IsNullOrWhiteSpace(Me.OrderNumber) = False)

				Case Database.Entities.DocumentLevel.Office

					IsValid = (String.IsNullOrWhiteSpace(Me.OfficeCode) = False)

				Case Database.Entities.DocumentLevel.Client

					IsValid = (String.IsNullOrWhiteSpace(Me.ClientCode) = False)

				Case Database.Entities.DocumentLevel.Division

					IsValid = (String.IsNullOrWhiteSpace(Me.ClientCode) = False)

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.DivisionCode) = False)

					End If

				Case Database.Entities.DocumentLevel.Product

					IsValid = (String.IsNullOrWhiteSpace(Me.ClientCode) = False)

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.DivisionCode) = False)

					End If

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.ProductCode) = False)

					End If

				Case Database.Entities.DocumentLevel.Campaign

					IsValid = (String.IsNullOrWhiteSpace(Me.CampaignID) = False)

				Case Database.Entities.DocumentLevel.Job

					IsValid = (String.IsNullOrWhiteSpace(Me.JobNumber) = False)

				Case Database.Entities.DocumentLevel.JobComponent

					IsValid = (String.IsNullOrWhiteSpace(Me.JobNumber) = False)

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.JobComponentNumber) = False)

					End If

				Case Database.Entities.DocumentLevel.AccountPayableInvoice

					IsValid = (String.IsNullOrWhiteSpace(Me.AccountPayableID) = False)

				Case Database.Entities.DocumentLevel.AdNumber

					IsValid = (String.IsNullOrWhiteSpace(Me.AdNumber) = False)

                    'AdNumber is PK, client not needed
                    'If IsValid Then

                    '	IsValid = (String.IsNullOrWhiteSpace(Me.ClientCode) = False)

                    'End If

                Case Database.Entities.DocumentLevel.ExpenseReceipts

					IsValid = (String.IsNullOrWhiteSpace(Me.ExpenseReportInvoiceNumber) = False)

				Case Database.Entities.DocumentLevel.Employee

					IsValid = (String.IsNullOrWhiteSpace(Me.EmployeeCode) = False)

				Case Database.Entities.DocumentLevel.Vendor

					IsValid = (String.IsNullOrWhiteSpace(Me.VendorCode) = False)

				Case Database.Entities.DocumentLevel.Contract

					IsValid = (String.IsNullOrWhiteSpace(Me.ContractID) = False)

				Case Database.Entities.DocumentLevel.ContractValueAdded

					IsValid = (String.IsNullOrWhiteSpace(Me.ValueAddedID) = False)

				Case Database.Entities.DocumentLevel.ContractReport

					IsValid = (String.IsNullOrWhiteSpace(Me.ContractReportID) = False)

				Case Database.Entities.DocumentLevel.AccountReceivableInvoice

					IsValid = (String.IsNullOrWhiteSpace(Me.AccountReceivableInvoiceNumber) = False)

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.AccountReceivableSequenceNumber) = False)

					End If

					If IsValid Then

						IsValid = (String.IsNullOrWhiteSpace(Me.AccountReceivableType) = False)

					End If

				Case Database.Entities.DocumentLevel.AgencyDesktop

					'IsValid = (String.IsNullOrWhiteSpace(Me.OfficeCode) = False)

				Case Database.Entities.DocumentLevel.ExecutiveDesktop

					'IsValid = (String.IsNullOrWhiteSpace(Me.OfficeCode) = False)

				Case Database.Entities.DocumentLevel.VendorContract

					IsValid = (String.IsNullOrWhiteSpace(Me.VendorContractID) = False)

                Case Database.Entities.DocumentLevel.JournalEntry

                    IsValid = (String.IsNullOrWhiteSpace(Me.GLTransaction) = False)

                Case Database.Entities.DocumentLevel.MediaPlan

                    IsValid = (String.IsNullOrWhiteSpace(Me.MediaPlanID) = False)

            End Select

			ValidateDocumentLevelProperties = IsValid

		End Function

#End Region

	End Class

End Namespace
