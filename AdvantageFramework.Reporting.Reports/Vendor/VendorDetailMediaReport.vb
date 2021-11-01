Namespace Vendor

    Public Class VendorDetailMediaReport

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

        Private Sub VendorDetailMediaReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

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
        Private Sub Label_VendorCategory_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_VendorCategory.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Category As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Category = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorCategory)).ToList
                                Where EnumObject.Code.ToUpper = Vendor.VendorCategory.ToUpper
                                Select EnumObject.Description).SingleOrDefault

                End If

            Catch ex As Exception
                Category = ""
            Finally
                Label_VendorCategory.Text = Category
            End Try

        End Sub
        Private Sub Label_AllowedVendorCategories_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_AllowedVendorCategories.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim AllowedCategories As Generic.List(Of String) = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    AllowedCategories = New Generic.List(Of String)

                    If Vendor.InternetCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Internet.ToString))

                    End If

                    If Vendor.MagazineCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Magazine.ToString))

                    End If

                    If Vendor.NewspaperCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Newspaper.ToString))

                    End If

                    If Vendor.OutOfHomeCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome.ToString))

                    End If

                    If Vendor.RadioCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Radio.ToString))

                    End If

                    If Vendor.TVCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Television.ToString))

                    End If

                End If

            Catch ex As Exception
                AllowedCategories = Nothing
            Finally

                If AllowedCategories IsNot Nothing Then

                    Label_AllowedVendorCategories.Lines = AllowedCategories.ToArray

                Else

                    Label_AllowedVendorCategories.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_CityStateZip.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim CityStateZip As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    CityStateZip = Vendor.City & ", " & Vendor.State & "  " & Vendor.ZipCode

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                Label_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub Label_DefaultOffice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultOffice.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OfficeName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.OfficeCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Vendor.OfficeCode)

                    End Using

                End If

                If Office IsNot Nothing Then

                    OfficeName = Office.ToString

                Else

                    OfficeName = ""

                End If

            Catch ex As Exception
                OfficeName = ""
            Finally
                Label_DefaultOffice.Text = OfficeName
            End Try

        End Sub
        Private Sub Label_Status_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Status.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Status As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Status = If(Vendor.ActiveFlag.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_Status.Text = Status
            End Try

        End Sub
        Private Sub Label_Market_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Market.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim MarketName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, Vendor.MarketCode)

                    End Using

                End If

                If Market IsNot Nothing Then

                    MarketName = Market.ToString

                Else

                    MarketName = ""

                End If

            Catch ex As Exception
                MarketName = ""
            Finally
                Label_Market.Text = MarketName
            End Try

        End Sub
        Private Sub Label_TaxCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_TaxCode.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim SalesTaxDescription As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Vendor.DefaultSalesTax)

                    End Using

                End If

                If SalesTax IsNot Nothing Then

                    SalesTaxDescription = SalesTax.ToString

                Else

                    SalesTaxDescription = ""

                End If

            Catch ex As Exception
                SalesTaxDescription = ""
            Finally
                Label_TaxCode.Text = SalesTaxDescription
            End Try

        End Sub
        Private Sub Label_UnitType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_UnitType.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Units As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Units = AdvantageFramework.StringUtilities.GetNameAsWords((From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorMediaDefaultUnits)).ToList
                                                                               Where EnumObject.Code = Vendor.DefaultUnits
                                                                               Select EnumObject.Description).SingleOrDefault)

                End If

            Catch ex As Exception
                Units = ""
            Finally
                Label_UnitType.Text = Units
            End Try

        End Sub
        Private Sub Label_Rate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Rate.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Rate As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                        Rate = "Net"

                    Else

                        Rate = "Gross"

                    End If

                End If

            Catch ex As Exception
                Rate = ""
            Finally
                Label_Rate.Text = Rate
            End Try

        End Sub
        Private Sub Label_ShipToCityStateAndZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_ShipToCityStateAndZip.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim CityStateZip As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    CityStateZip = Vendor.ShipToCity & ", " & Vendor.ShipToState & "  " & Vendor.ShipToZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                Label_ShipToCityStateAndZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub CheckBox_ApplyTo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_ApplyTo.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.UseTaxFlags.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_ApplyTo.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_LineNet_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_LineNet.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxLineNet.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_LineNet.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_NetCharge_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_NetCharge.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxNetCharge.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_NetCharge.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_AddlCharge_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_AddlCharge.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxAdditionalCharge.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_AddlCharge.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_Commission_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_Commission.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxCommission.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Commission.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_Rebate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_Rebate.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxRebate.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Rebate.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_NetDiscount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_NetDiscount.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.TaxNetDiscount.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_NetDiscount.Checked = Checked
            End Try

        End Sub
        Private Sub SubreportVendorRepresentatives_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubreportVendorRepresentatives.BeforePrint

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    SubreportVendorRepresentatives.ReportSource.DataSource = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByVendorCode(DataContext, LoadCurrentVendor.Code).ToList

                End Using

            Catch ex As Exception
                SubreportVendorRepresentatives.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub SubreportVendorPricings_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubreportVendorPricings.BeforePrint

            'objects
            Dim VendorPricings As Generic.List(Of AdvantageFramework.Database.Entities.VendorPricing) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorPricings = AdvantageFramework.Database.Procedures.VendorPricing.LoadByVendorCode(DbContext, LoadCurrentVendor.Code).ToList

                    If VendorPricings IsNot Nothing AndAlso VendorPricings.Count > 0 Then

                        SubreportVendorPricings.ReportSource.DataSource = VendorPricings
                        SubreportVendorPricings.Visible = True

                    Else

                        SubreportVendorPricings.ReportSource.DataSource = Nothing
                        SubreportVendorPricings.Visible = False
                    End If

                End Using

            Catch ex As Exception
                SubreportVendorPricings.Visible = False
                SubreportVendorPricings.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub Table_MediaSpecs_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Table_MediaSpecs.BeforePrint

            'objects
            Dim AdSizeLabels As Generic.List(Of AdvantageFramework.Database.Entities.AdSizeLabel) = Nothing
            Dim MediaSpecHeaders As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpecsHeader) = Nothing
            Dim MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim XRTableRowDetail As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim XRTableCell As DevExpress.XtraReports.UI.XRTableCell = Nothing
            Dim XRTableCellDetail As DevExpress.XtraReports.UI.XRTableCell = Nothing

            Try

                Table_MediaSpecs.Rows.Clear()

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            AdSizeLabels = (From Entity In AdvantageFramework.Database.Procedures.AdSizeLabel.LoadByMediaType(DbContext, Vendor.VendorCategory)
                                            Where Entity.IsInactive Is Nothing OrElse
                                                  Entity.IsInactive = 0
                                            Select Entity).ToList

                        Catch ex As Exception
                            AdSizeLabels = Nothing
                        End Try

                        Table_MediaSpecs.Font = New System.Drawing.Font("Arial", 8.25)

                        XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

                        XRTableRow.BackColor = Drawing.Color.LightGray
                        XRTableRow.Font = New System.Drawing.Font("Arial", 8.25, Drawing.FontStyle.Bold)

                        XRTableRow.Cells.Add(New DevExpress.XtraReports.UI.XRTableCell With {.Name = "ADSIZE", .Text = "Ad Size"})

                        For Each AdSizeLabel In AdSizeLabels.OrderBy(Function(AdSizeLbl) AdSizeLbl.OrderNumber).ToList

                            XRTableRow.Cells.Add(New DevExpress.XtraReports.UI.XRTableCell With {.Name = AdSizeLabel.ID, .Text = AdSizeLabel.Description, .BorderWidth = 1, .BorderColor = Drawing.Color.LightGray})

                        Next

                        Table_MediaSpecs.Rows.Add(XRTableRow)

                        Try

                            MediaSpecHeaders = (From Entity In AdvantageFramework.Database.Procedures.MediaSpecsHeader.Load(DbContext).Include("MediaSpecsDetails").ToList
                                                Where Entity.VendorCode = Vendor.Code AndAlso
                                                      Entity.MediaSpecsDetails IsNot Nothing AndAlso
                                                      Entity.MediaSpecsDetails.Where(Function(MediaSpecDtl) MediaSpecDtl.MediaType = Vendor.VendorCategory).Any
                                                Select Entity).ToList

                        Catch ex As Exception
                            MediaSpecHeaders = Nothing
                        End Try

                        For Each MediaSpecHeader In MediaSpecHeaders

                            XRTableRowDetail = New DevExpress.XtraReports.UI.XRTableRow

                            XRTableRowDetail.BorderColor = Drawing.Color.Gray
                            XRTableRowDetail.BorderWidth = 1
                            XRTableRowDetail.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

                            For Each XRTableCell In XRTableRow.Cells.OfType(Of DevExpress.XtraReports.UI.XRTableCell)()

                                XRTableCellDetail = New DevExpress.XtraReports.UI.XRTableCell
                                XRTableCellDetail.BorderColor = Drawing.Color.LightGray
                                XRTableCellDetail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2)
                                XRTableCellDetail.Borders = DevExpress.XtraPrinting.BorderSide.All

                                If XRTableCell.Name = "ADSIZE" Then

                                    XRTableCellDetail.Text = MediaSpecHeader.AdSize

                                Else

                                    Try

                                        MediaSpecsDetail = (From Entity In MediaSpecHeader.MediaSpecsDetails
                                                            Where Entity.LabelID = XRTableCell.Name
                                                            Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        MediaSpecsDetail = Nothing
                                    End Try

                                    If MediaSpecsDetail IsNot Nothing Then

                                        XRTableCellDetail.Text = MediaSpecsDetail.SpecData

                                    Else

                                        XRTableCellDetail.Text = ""

                                    End If

                                End If

                                XRTableRowDetail.Cells.Add(XRTableCellDetail)

                            Next

                            Table_MediaSpecs.Rows.Add(XRTableRowDetail)

                        Next

                    End Using

                End If

            Catch ex As Exception

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
        Private Sub XrLabelDefaultCorrespondenceMethod_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelDefaultCorrespondenceMethod.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim DefaultCorrespondenceMethod As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    If Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0 Then

                        DefaultCorrespondenceMethod = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods), Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(0))

                    End If

                End If

            Catch ex As Exception
                DefaultCorrespondenceMethod = ""
            Finally
                XrLabelDefaultCorrespondenceMethod.Text = DefaultCorrespondenceMethod
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
