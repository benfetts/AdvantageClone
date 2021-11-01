Namespace FinanceAndAccounting

    Public Class Summary1099AllVendors

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _ReportCriteria As String = Nothing
        Private _AgencyName As String = Nothing
        Private _IRS1099AllVendorsSummaryReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport) = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ReportCriteria As String
            Set(value As String)
                _ReportCriteria = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub AccountPayableBatchDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")
            _IRS1099AllVendorsSummaryReportList = Me.DataSource

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_ReportCriteria.Text = "For Check Date(s) From: " & _ReportCriteria
            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub CheckBoxDetail_1099Form_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBoxDetail_1099Form.BeforePrint

            Dim Is1099 As Boolean = False
            Dim VendorPayToCode As String = Nothing
            Dim Vendor1099Category As Integer = Nothing
            Dim TotalAmountPaid As Decimal = Nothing

            Is1099 = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport).Is1099

            If Is1099 Then

                VendorPayToCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport).VendorPayToCode
                Vendor1099Category = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport).Vendor1099Category

                TotalAmountPaid = (From Entity In _IRS1099AllVendorsSummaryReportList
                                   Where Entity.VendorPayToCode = VendorPayToCode AndAlso _
                                         Entity.Is1099 = True).Sum(Function(Entity) Entity.TotalAmountPaid)

                If Vendor1099Category = 3 AndAlso TotalAmountPaid >= 10 Then

                    CheckBoxDetail_1099Form.Checked = True

                ElseIf Vendor1099Category <> 3 AndAlso TotalAmountPaid >= 600 Then

                    CheckBoxDetail_1099Form.Checked = True

                Else

                    CheckBoxDetail_1099Form.Checked = False

                End If

            Else

                CheckBoxDetail_1099Form.Checked = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
