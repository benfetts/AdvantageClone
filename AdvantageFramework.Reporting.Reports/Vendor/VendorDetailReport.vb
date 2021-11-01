Namespace Vendor

    Public Class VendorDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty
        Private _ServiceTaxEnabled As Boolean = False

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

        Private Function LoadCurrentVendor() As AdvantageFramework.Database.Entities.Vendor

            Try

                LoadCurrentVendor = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Vendor)

            Catch ex As Exception
                LoadCurrentVendor = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub VendorDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

            Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                _ServiceTaxEnabled = AdvantageFramework.Agency.GetOptionServiceTaxEnabled(DataContext)

            End Using

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
        Private Sub SubreportVendorDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubreportVendorDetails.BeforePrint

            Try

                DirectCast(SubreportVendorDetails.ReportSource, AdvantageFramework.Reporting.Reports.Vendor.VendorDetailsSubReport).Session = _Session

                SubreportVendorDetails.ReportSource.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.Vendor)).Where(Function(Vendor) Vendor.Code = LoadCurrentVendor.Code).ToList

            Catch ex As Exception
                SubreportVendorDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub SubreportVendorServiceTaxDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles SubreportVendorServiceTaxDetails.BeforePrint

            If _ServiceTaxEnabled Then

                Try

                    DirectCast(SubreportVendorServiceTaxDetails.ReportSource, AdvantageFramework.Reporting.Reports.Vendor.VendorServiceTaxSubReport).Session = _Session

                    SubreportVendorServiceTaxDetails.ReportSource.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.Vendor)).Where(Function(Vendor) Vendor.Code = LoadCurrentVendor.Code).ToList

                Catch ex As Exception
                    SubreportVendorServiceTaxDetails.ReportSource.DataSource = Nothing
                End Try

            Else

                SubreportVendorServiceTaxDetails.Visible = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
