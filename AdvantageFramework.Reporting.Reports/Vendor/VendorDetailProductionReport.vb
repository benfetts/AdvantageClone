Namespace Vendor

    Public Class VendorDetailProductionReport

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



#End Region

#Region "  Control Event Handlers "

        Private Sub VendorDetailProductionReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
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
        Private Sub SubReportVendorContacts_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReportVendorContacts.BeforePrint

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubReportVendorContacts.ReportSource.DataSource = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, LoadCurrentVendor.Code).ToList

                End Using

            Catch ex As Exception
                SubReportVendorContacts.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub Label_DefaultContact_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultContact.BeforePrint

            'objects
            Dim VendorContactName As String = ""
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.DefaultVendorContactCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, Vendor.Code, Vendor.DefaultVendorContactCode)

                    End Using

                End If

                If VendorContact IsNot Nothing Then

                    If String.IsNullOrEmpty(VendorContact.MiddleInitial) = False Then

                        VendorContactName = VendorContact.Code & " - " & VendorContact.FirstName & " " & VendorContact.MiddleInitial & " " & VendorContact.LastName

                    Else

                        VendorContactName = VendorContact.Code & " - " & VendorContact.FirstName & " " & VendorContact.LastName

                    End If

                Else

                    VendorContactName = ""

                End If

            Catch ex As Exception
                VendorContactName = ""
            Finally
                Label_DefaultContact.Text = VendorContactName
            End Try

        End Sub
        Private Sub SubReportVendorPricings_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReportVendorPricings.BeforePrint

            'objects
            Dim VendorPricings As Generic.List(Of AdvantageFramework.Database.Entities.VendorPricing) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorPricings = AdvantageFramework.Database.Procedures.VendorPricing.LoadByVendorCode(DbContext, LoadCurrentVendor.Code).ToList

                    If VendorPricings IsNot Nothing AndAlso VendorPricings.Count > 0 Then

                        SubReportVendorPricings.ReportSource.DataSource = VendorPricings
                        SubReportVendorPricings.Visible = True

                    Else

                        SubReportVendorPricings.ReportSource.DataSource = Nothing
                        SubReportVendorPricings.Visible = False
                    End If

                End Using

            Catch ex As Exception
                SubReportVendorPricings.Visible = False
                SubReportVendorPricings.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub LabelDetail_Pricings_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Pricings.BeforePrint

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LabelDetail_Pricings.Visible = (From Entity In AdvantageFramework.Database.Procedures.VendorPricing.LoadByVendorCode(DbContext, LoadCurrentVendor.Code)
                                                    Select Entity).Any

                End Using

            Catch ex As Exception
                LabelDetail_Pricings.Visible = False
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
