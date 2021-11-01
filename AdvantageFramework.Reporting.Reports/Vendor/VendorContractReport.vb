Namespace Vendor

    Public Class VendorContractReport

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

        Private Function LoadCurrentContract() As AdvantageFramework.Database.Entities.VendorContract

            Try

                LoadCurrentContract = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.VendorContract)

            Catch ex As Exception
                LoadCurrentContract = Nothing
            End Try

        End Function
        Private Function LoadCurrentContractContact() As AdvantageFramework.Database.Entities.VendorContractContact

            Try

                LoadCurrentContractContact = DirectCast(DetailReportContractContacts.GetCurrentRow, AdvantageFramework.Database.Entities.VendorContractContact)

            Catch ex As Exception
                LoadCurrentContractContact = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub VendorContractReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

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
        Private Sub LabelGeneral_VendorCodeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_VendorCodeName.BeforePrint

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing

            VendorContract = LoadCurrentContract()

            If VendorContract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorContract.VendorCode)

                    LabelGeneral_VendorCodeName.Text = Vendor.ToString

                End Using

            End If

        End Sub
        Private Sub LabelInternalContacts_EmployeeName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelInternalContacts_EmployeeName.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact = Nothing

            VendorContractContact = LoadCurrentContractContact()

            If VendorContractContact IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, VendorContractContact.EmployeeCode)

                    LabelInternalContacts_EmployeeName.Text = Employee.ToString

                End Using

            End If

        End Sub
        Private Sub CheckBoxMisc_HasDocuments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxMisc_HasDocuments.BeforePrint

            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing

            VendorContract = LoadCurrentContract()

            If VendorContract IsNot Nothing Then

                CheckBoxMisc_HasDocuments.Checked = VendorContract.VendorContractDocuments.Any

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
