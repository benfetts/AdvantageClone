Imports System.Drawing.Printing

Namespace Client

    Public Class ClientContractOpportunityDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentContract() As AdvantageFramework.Database.Entities.Contract

            Try

                LoadCurrentContract = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Contract)

            Catch ex As Exception
                LoadCurrentContract = Nothing
            End Try

        End Function
        Private Function LoadCurrentContractValueAdded() As AdvantageFramework.Database.Entities.ContractValueAdded

            Try

                LoadCurrentContractValueAdded = DirectCast(DetailReportContractValuesAddeds.GetCurrentRow, AdvantageFramework.Database.Entities.ContractValueAdded)

            Catch ex As Exception
                LoadCurrentContractValueAdded = Nothing
            End Try

        End Function
        Private Function LoadCurrentContractReport() As AdvantageFramework.Database.Entities.ContractReport

            Try

                LoadCurrentContractReport = DirectCast(DetailReportContractReports.GetCurrentRow, AdvantageFramework.Database.Entities.ContractReport)

            Catch ex As Exception
                LoadCurrentContractReport = Nothing
            End Try

        End Function
        Private Function LoadCurrentContractContact() As AdvantageFramework.Database.Entities.ContractContact

            Try

                LoadCurrentContractContact = DirectCast(DetailReportContractContacts.GetCurrentRow, AdvantageFramework.Database.Entities.ContractContact)

            Catch ex As Exception
                LoadCurrentContractContact = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub LabelGeneral_ClientCodeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ClientCodeName.BeforePrint

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)

                    LabelGeneral_ClientCodeName.Text = Client.ToString

                End Using

            End If

        End Sub
        Private Sub LabelGeneral_DivisionCodeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_DivisionCodeName.BeforePrint

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)

                    LabelGeneral_DivisionCodeName.Text = Division.ToString

                End Using

            End If

        End Sub
        Private Sub LabelGeneral_ProductCodeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ProductCodeName.BeforePrint

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)

                    LabelGeneral_ProductCodeName.Text = Division.ToString

                End Using

            End If

        End Sub
        Private Sub CheckBoxGeneral_Contract_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxGeneral_Contract.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                CheckBoxGeneral_Contract.Checked = Contract.IsContract

            End If

        End Sub
        Private Sub CheckBoxGeneral_Opportunity_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxGeneral_Opportunity.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                CheckBoxGeneral_Opportunity.Checked = Not Contract.IsContract

            End If

        End Sub
        Private Sub LabelGeneral_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_CityStateZip.BeforePrint

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim CityStateZip As String = ""

            Try

                Contract = LoadCurrentContract()

                If Contract IsNot Nothing AndAlso Contract.Product IsNot Nothing Then

                    CityStateZip = Contract.Product.BillingCity & ", " & Contract.Product.BillingState & "  " & Contract.Product.BillingZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelGeneral_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub LabelGeneral_ContractStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ContractStatus.BeforePrint

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim Status As String = ""

            Try

                Contract = LoadCurrentContract()

                If Contract IsNot Nothing Then

                    Status = If(Contract.IsInactive, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                LabelGeneral_ContractStatus.Text = Status
            End Try

        End Sub
        Private Sub LabelGeneral_ContractStartDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ContractStartDate.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelGeneral_ContractStartDate.Text = If(IsDate(Contract.StartDate), CDate(Contract.StartDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelGeneral_ContractEndDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ContractEndDate.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelGeneral_ContractEndDate.Text = If(IsDate(Contract.EndDate), CDate(Contract.EndDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelContractReports_LastCompletedDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelContractReports_LastCompletedDate.BeforePrint

            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing

            ContractReport = TryCast(Me.DetailReportContractReports.GetCurrentRow(), AdvantageFramework.Database.Entities.ContractReport)

            If ContractReport IsNot Nothing Then

                LabelContractReports_LastCompletedDate.Text = If(IsDate(ContractReport.LastCompletedDate), CDate(ContractReport.LastCompletedDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelContractReports_NextStartDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelContractReports_NextStartDate.BeforePrint

            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing

            ContractReport = TryCast(Me.DetailReportContractReports.GetCurrentRow(), AdvantageFramework.Database.Entities.ContractReport)

            If ContractReport IsNot Nothing Then

                LabelContractReports_NextStartDate.Text = If(IsDate(ContractReport.NextStartDate), CDate(ContractReport.NextStartDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelInternalContacts_EmployeeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelInternalContacts_EmployeeName.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing

            ContractContact = LoadCurrentContractContact()

            If ContractContact IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ContractContact.EmployeeCode)

                    LabelInternalContacts_EmployeeName.Text = Employee.ToString

                End Using

            End If

        End Sub
        Private Sub CheckBoxReports_HasDocuments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxReports_HasDocuments.BeforePrint

            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing

            ContractReport = LoadCurrentContractReport()

            If ContractReport IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    CheckBoxReports_HasDocuments.Checked = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadByContractReportID(DataContext, ContractReport.ID).Any()

                End Using

            End If

        End Sub
        Private Sub LabelReports_EmployeeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelReports_EmployeeName.BeforePrint

            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            ContractReport = LoadCurrentContractReport()

            If ContractReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ContractReport.EmployeeCode)

                    LabelReports_EmployeeName.Text = Employee.ToString

                End Using

            End If

        End Sub
        Private Sub CheckBoxValueAdded_HasDocuments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxValueAdded_HasDocuments.BeforePrint

            Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

            ContractValueAdded = LoadCurrentContractValueAdded()

            If ContractValueAdded IsNot Nothing Then

                CheckBoxValueAdded_HasDocuments.Checked = ContractValueAdded.DocumentID.HasValue

            End If

        End Sub

        Private Sub LabelComments_BillingRateComments_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelComments_BillingRateComments.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelComments_BillingRateComments.Text = Contract.BillingRateComment

            End If

        End Sub

        Private Sub LabelComments_BillingTerms_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelComments_BillingTerms.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelComments_BillingTerms.Text = Contract.BillingTerms

            End If

        End Sub

        Private Sub LabelComments_ContractComments_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelComments_ContractComments.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelComments_ContractComments.Text = Contract.ContractComments

            End If

        End Sub

        Private Sub LabelComments_EstimatingTerms_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelComments_EstimatingTerms.BeforePrint

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            If Contract IsNot Nothing Then

                LabelComments_EstimatingTerms.Text = Contract.EstimatingTerms

            End If

        End Sub

        Private Sub DetailReport1_DataSourceDemanded(sender As Object, e As EventArgs) Handles DetailReport1.DataSourceDemanded

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadCurrentContract()

            DetailReport1.FilterString = String.Format("CONTRACT_ID = {0}", Contract.ID)

        End Sub



#End Region

#End Region

    End Class

End Namespace
