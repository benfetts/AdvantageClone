Namespace MediaManager

    Public Class InternetOrderReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumbers As Generic.List(Of Integer) = Nothing
        Private _MediaFrom As String = Nothing
        Private _EmployeeEmail As String = Nothing
        Private _IsFirstPage As Boolean = True
        Private _AgencyList As Generic.List(Of AdvantageFramework.Database.Entities.Agency) = Nothing
        Private _PrintCardInfo As Boolean = False
        Private _MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Private _HasPackagePlacementNames As Boolean = False
        Private _PlacementName As String = Nothing
        Private _PlacementCancel As Boolean = False
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property OrderNumber As Integer
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        Public WriteOnly Property LineNumbers As Generic.List(Of Integer)
            Set(value As Generic.List(Of Integer))
                _LineNumbers = value
            End Set
        End Property
        Public WriteOnly Property MediaFrom As String
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function GetLineNumbers(DbContext As AdvantageFramework.Database.DbContext, InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport) As IEnumerable(Of Short)

            Dim LineNumbers As IEnumerable(Of Short) = Nothing

            LineNumbers = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                           Where Entity.InternetOrderOrderNumber = InternetOrderReport.OrderNumber AndAlso
                                 Entity.IsActiveRevision = 1 AndAlso
                                 _LineNumbers.Contains(Entity.LineNumber) AndAlso
                                 String.Concat(Entity.TargetAudience) = InternetOrderReport.Target AndAlso
                                 Entity.MarketCode = InternetOrderReport.LineMarketCode AndAlso
                                 String.Concat(Entity.CreativeSize) = InternetOrderReport.Dimensions AndAlso
                                 String.Concat(Entity.CostType) = InternetOrderReport.CostStructure AndAlso
                                 String.Concat(Entity.Placement2) = InternetOrderReport.Package AndAlso
                                 String.Concat(Entity.Url) = InternetOrderReport.URL AndAlso
                                 String.Concat(Entity.Placement1) = InternetOrderReport.Placement
                           Select Entity.LineNumber).ToArray

            GetLineNumbers = LineNumbers

        End Function
        Private Sub SetPlacementName()

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim AdSizeCodes As IEnumerable(Of String) = Nothing
            Dim InternetOrderReportAdSizes As Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize) = Nothing
            Dim InternetOrderReports As Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport) = Nothing
            Dim DimensionList As IEnumerable(Of String) = Nothing

            _PlacementName = Nothing
            _PlacementCancel = False

            If Not String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Package) Then

                _PlacementCancel = True

            Else

                If _MediaOrderPrintSetting.Placement1.GetValueOrDefault(0) = 0 Then

                    _PlacementCancel = True

                Else

                    InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

                    If String.IsNullOrWhiteSpace(InternetOrderReport.Placement) Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            LineNumbers = GetLineNumbers(DbContext, InternetOrderReport)

                            AdSizeCodes = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, InternetOrderReport.OrderNumber, LineNumbers)
                                           Select Entity.AdSizeCode).Distinct.ToArray

                            If AdSizeCodes IsNot Nothing AndAlso AdSizeCodes.Count > 0 Then

                                InternetOrderReportAdSizes = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)(String.Format("exec dbo.advsp_media_manager_load_internet_order_ad_sizes '{0}', {1}, {2}", AdSizeCodes.First, InternetOrderReport.OrderNumber, LineNumbers.First)).ToList

                                If InternetOrderReportAdSizes IsNot Nothing AndAlso InternetOrderReportAdSizes.Count > 0 Then

                                    _PlacementName = InternetOrderReportAdSizes.First.PlacementName

                                Else

                                    _PlacementCancel = True

                                End If

                            Else

                                InternetOrderReports = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport))

                                DimensionList = (From Entity In InternetOrderReports
                                                 Select Entity.Dimensions).Distinct.ToArray

                                AdSizeCodes = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadByMediaType(DbContext, "I")
                                               Where DimensionList.Contains(Entity.Description)
                                               Select Entity.Code).Distinct.ToArray

                                If AdSizeCodes IsNot Nothing AndAlso AdSizeCodes.Count > 0 Then

                                    InternetOrderReportAdSizes = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)(String.Format("exec dbo.advsp_media_manager_load_internet_order_ad_sizes '{0}', {1}, {2}", AdSizeCodes.First, InternetOrderReport.OrderNumber, LineNumbers.First)).ToList

                                    If InternetOrderReportAdSizes IsNot Nothing AndAlso InternetOrderReportAdSizes.Count > 0 Then

                                        _PlacementName = InternetOrderReportAdSizes.First.PlacementName

                                    Else

                                        _PlacementCancel = True

                                    End If

                                End If

                            End If

                        End Using

                    Else

                        _PlacementName = InternetOrderReport.Placement

                    End If

                End If

            End If

            If String.IsNullOrWhiteSpace(_PlacementName) Then

                _PlacementCancel = True

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub InternetOrderReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Buyer As String = Nothing
            Dim Names() As String = Nothing
            Dim FirstName As String = Nothing
            Dim LastName As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Buyer = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Buyer.ToString)

            If Buyer IsNot Nothing Then

                Names = Buyer.Split(" ")

                If Names.Length = 2 Then

                    FirstName = Names(0)
                    LastName = Names(1)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                    Where Entity.FirstName = FirstName AndAlso
                                          Entity.LastName = LastName
                                    Select Entity).FirstOrDefault

                    End Using

                    If Employee IsNot Nothing Then

                        _EmployeeEmail = Employee.Email

                    End If

                End If

            End If

        End Sub
        Private Sub InternetOrderReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim InternetOrderReports As Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport) = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing

            _AgencyList = New Generic.List(Of AdvantageFramework.Database.Entities.Agency)

            If _LineNumbers IsNot Nothing AndAlso _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    InternetOrderReports = AdvantageFramework.MediaManager.LoadEnhancedInternetOrderReport(DbContext, _OrderNumber, String.Join(",", _LineNumbers)).ToList

                    _AgencyList.Add(AdvantageFramework.Database.Procedures.Agency.Load(DbContext))

                    _PrintCardInfo = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

                    _MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, _Session.UserCode, Mid(_MediaFrom, 1, 1).ToUpper)

                    If _MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(Mid(_MediaFrom, 1, 1).ToUpper)

                        _MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                        _MediaOrderPrintSetting.UserCode = _Session.UserCode
                        _MediaOrderPrintSetting.MediaType = Mid(_MediaFrom, 1, 1).ToUpper

                        OrderPrintSetting.Save(_MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, _MediaOrderPrintSetting, Nothing)

                    End If

                    If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaOrderPrintSetting.LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

            Else

                InternetOrderReports = New Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport)

            End If

            For Each InternetOrderReport In InternetOrderReports

                If String.IsNullOrEmpty(InternetOrderReport.LocationHeader) = False Then

                    InternetOrderReport.LocationHeader = InternetOrderReport.LocationHeader.Trim

                End If

                If String.IsNullOrEmpty(InternetOrderReport.LocationFooter) = False Then

                    InternetOrderReport.LocationFooter = InternetOrderReport.LocationFooter.Trim

                End If

            Next

            Me.DataSource = InternetOrderReports

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            Dim MediaType As String = Nothing

            MediaType = _MediaFrom.Substring(0, 1)

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _IsFirstPage AndAlso _MediaOrderPrintSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)) = False Then

                        If My.Computer.FileSystem.FileExists(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.PageHeaderLogoPath.ToString)) Then

                            XrPictureBoxHeaderLogo.ImageUrl = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.PageHeaderLogoPath.ToString)

                            Cancel = False

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                            Cancel = False

                        End Using

                    End If

                End If

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_DiscountSum.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DiscountAmount.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_DiscountSum.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_DiscountSum.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DiscountAmount.ToString), 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_DiscountSumLabel.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DiscountAmount.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_DiscountSumLabel.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_DiscountSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DiscountDescription.ToString) & ":"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_NetChargeSum.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetCharge.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_NetChargeSum.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_NetChargeSum.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetCharge.ToString), 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSumLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_NetChargeSumLabel.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetChargeDescription.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_NetChargeSumLabel.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_NetChargeSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetChargeDescription.ToString) & ":"

            End If

        End Sub
        Private Sub GroupFooterOrderNumberSubreport_VendorShippingSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_VendorShippingSubReport.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ShippingAddressFlag.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorCode.ToString)

                Try

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Vendors = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                   Where Vendor.Code = VendorCode
                                   Select Vendor).ToList

                    End Using

                Catch ex As Exception
                    Vendors = Nothing
                End Try

                If Vendors IsNot Nothing AndAlso Vendors.Count > 0 AndAlso (
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToName) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress2) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress3) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToCity) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToState) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToZip) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToCounty) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToCountry) = False) Then

                    GroupFooterOrderNumberSubreport_VendorShippingSubReport.ReportSource.DataSource = Vendors

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

            If e.Cancel Then

                LabelGroupFooterOrderNumber_ShipToLabel.Visible = False

            End If

        End Sub
        Private Sub XrPictureBoxSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxSignature.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim BuyerEmployeeCode As String = Nothing
            Dim NameParts() As String = Nothing
            Dim FirstName As String = Nothing
            Dim LastName As String = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ExcludeEmployeeSignature.ToString) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.BuyerEmployeeCode.ToString)) = False Then

                        BuyerEmployeeCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.BuyerEmployeeCode.ToString)

                        Employee = (From EMP In DbContext.Employees
                                    Where EMP.Code = BuyerEmployeeCode AndAlso
                                          EMP.TerminationDate Is Nothing AndAlso
                                          EMP.SignatureImage IsNot Nothing
                                    Select EMP).FirstOrDefault

                    ElseIf String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Buyer.ToString)) = False Then

                        NameParts = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Buyer.ToString).ToString.Split(" ")

                        If NameParts.Length = 2 Then

                            FirstName = NameParts(0)
                            LastName = NameParts(1)

                            Employee = (From EMP In DbContext.Employees
                                        Where EMP.FirstName = FirstName AndAlso
                                              EMP.LastName = LastName AndAlso
                                              EMP.TerminationDate Is Nothing AndAlso
                                              EMP.SignatureImage IsNot Nothing
                                        Select EMP).FirstOrDefault

                        End If

                    End If

                    If Employee IsNot Nothing AndAlso Employee.SignatureImage IsNot Nothing Then

                        Try

                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                            XrPictureBoxSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                        Catch ex As Exception

                        End Try

                    End If

                End Using

            End If

        End Sub
        Private Sub GroupHeaderOrderNumberTopSubreportVendorAddress_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderOrderNumberTopSubreportVendorAddress.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            If _IsFirstPage Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorCode.ToString)

                Try

                    Vendors = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Vendors.Add(AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode))

                    End Using

                Catch ex As Exception
                    Vendors = Nothing
                End Try

                If Vendors IsNot Nothing AndAlso Vendors.Count > 0 Then

                    GroupHeaderOrderNumberTopSubreportVendorAddress.ReportSource.DataSource = Vendors

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderOrderNumberTopSubreportVendorRep1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderOrderNumberTopSubreportVendorRep1.BeforePrint

            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim VendorRepresentatives As IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing
            Dim RepresentativeLabel As String = Nothing

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.IncludeRep1.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorRepCode1.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DefaultRep1Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
                                VendorRepresentatives.First.ContactTypeID.HasValue Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentatives.First.ContactTypeID.Value)

                                If ContactType IsNot Nothing Then

                                    RepresentativeLabel = ContactType.Description

                                End If

                            End Using

                        End If

                    End Using

                Catch ex As Exception
                    VendorRepresentatives = Nothing
                End Try

                If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                    GroupHeaderOrderNumberTopSubreportVendorRep1.ReportSource.DataSource = VendorRepresentatives

                    If RepresentativeLabel Is Nothing Then

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.RepLabel1.ToString)

                    End If

                    DirectCast(GroupHeaderOrderNumberTopSubreportVendorRep1.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport).RepresentativeLabel = RepresentativeLabel

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderOrderNumberTopSubreportVendorRep2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderOrderNumberTopSubreportVendorRep2.BeforePrint

            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim VendorRepresentatives As IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing
            Dim RepresentativeLabel As String = Nothing

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.IncludeRep2.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorRepCode2.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DefaultRep2Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
                                VendorRepresentatives.First.ContactTypeID.HasValue Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentatives.First.ContactTypeID.Value)

                                If ContactType IsNot Nothing Then

                                    RepresentativeLabel = ContactType.Description

                                End If

                            End Using

                        End If

                    End Using

                Catch ex As Exception
                    VendorRepresentatives = Nothing
                End Try

                If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                    GroupHeaderOrderNumberTopSubreportVendorRep2.ReportSource.DataSource = VendorRepresentatives

                    If RepresentativeLabel Is Nothing Then

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.RepLabel2.ToString)

                    End If

                    DirectCast(GroupHeaderOrderNumberTopSubreportVendorRep2.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport).RepresentativeLabel = RepresentativeLabel

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelHeaderOrderNumber_Email_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeaderOrderNumber_Email.BeforePrint

            If String.IsNullOrWhiteSpace(_EmployeeEmail) Then

                LabelHeaderOrderNumber_Email.Text = Nothing

            Else

                LabelHeaderOrderNumber_Email.Text = _EmployeeEmail

            End If

        End Sub
        Private Sub LabelHeaderOrderNumber_EmailLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeaderOrderNumber_EmailLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_EmployeeEmail) Then

                LabelHeaderOrderNumber_EmailLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_VendorTaxSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_VendorTaxSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_VendorTaxSum.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorTax.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_VendorTaxSum.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_VendorTaxSum.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorTax.ToString), 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_VendorTaxLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_VendorTaxLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_VendorTaxLabel.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorTax.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_VendorTaxLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommissionSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommissionSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_AgencyCommissionSum.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CommissionActual.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_AgencyCommissionSum.Text = Nothing

            Else

                LabelGroupFooterOrderNumber_AgencyCommissionSum.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CommissionActual.ToString), 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommissionLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommissionLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_AgencyCommissionLabel.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CommissionActual.ToString) Is Nothing Then

                LabelGroupFooterOrderNumber_AgencyCommissionLabel.Text = Nothing

            End If

        End Sub
        Private Sub Detail_AfterPrint(sender As Object, e As EventArgs) Handles Detail.AfterPrint

            If _IsFirstPage Then

                _IsFirstPage = False

            End If

        End Sub
        'Private Sub DetailSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSubreport_ChargeToSubReport.BeforePrint

        '    If Me.DataSource.Count = 1 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

        '        e.Cancel = True

        '    Else

        '        DetailSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

        '        DirectCast(DetailSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ChargeTo.ToString)

        '    End If

        'End Sub
        'Private Sub GroupFooterOrderNumberSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_ChargeToSubReport.BeforePrint

        '    If Me.DataSource.Count = 1 Then

        '        If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

        '            e.Cancel = True

        '        Else

        '            GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

        '            DirectCast(GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ChargeTo.ToString)

        '        End If

        '    Else

        '        e.Cancel = True

        '    End If

        'End Sub
        Private Sub TableCellClient_Client_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Client.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ClientName.ToString) Is Nothing Then

                TableCellClient_Client.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Division_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Division.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DivisionName.ToString) Is Nothing Then

                TableCellClient_Division.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Product_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Product.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ProductionDescription.ToString) Is Nothing Then

                TableCellClient_Product.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyComment.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub GroupHeaderFirstPageOnly2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderFirstPageOnly2.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            ElseIf String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderComment.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderComment.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_Box_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_Box.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_LineTotalActual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_LineTotalActual.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                LabelGroupFooterOrderNumber_LineTotalActual.Text = FormatNumber(LabelFooterOrderNumber_AmountSubtotal.Summary.GetResult +
                    DirectCast(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.VendorTax.ToString), Nullable(Of Decimal)).GetValueOrDefault(0) +
                    DirectCast(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetCharge.ToString), Nullable(Of Decimal)).GetValueOrDefault(0) +
                    DirectCast(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.DiscountAmount.ToString), Nullable(Of Decimal)).GetValueOrDefault(0) +
                    DirectCast(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CommissionActual.ToString), Nullable(Of Decimal)).GetValueOrDefault(0), 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderTotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderTotalLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelFooterOrderNumber_SubtotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelFooterOrderNumber_SubtotalLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.NetGross.ToString) = 1 Then

                LabelFooterOrderNumber_SubtotalLabel.Text = "Total Gross:"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommentTop.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderNumber_AgencyCommentTop.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderNumber_OrderCommentTop.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentTop.Text = Nothing

            End If

        End Sub
        Private Sub SubBandSignatures_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandSignatures.BeforePrint

            If _MediaOrderPrintSetting.RemoveSignatureLines Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_MarketDetail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_MarketDetail.BeforePrint

            If Not _MediaOrderPrintSetting.IncludeLineMarket OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.LineMarketDescription.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_MarketDetailLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_MarketDetailLabel.BeforePrint

            If Not _MediaOrderPrintSetting.IncludeLineMarket OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.LineMarketDescription.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportFlightLines_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportFlightLines.BeforePrint

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing
            Dim InternetOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderDetail) = Nothing

            If Not _MediaOrderPrintSetting.IncludeFlighting Then

                e.Cancel = True

            Else

                Try

                    InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        InternetOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                                                Where Entity.InternetOrderOrderNumber = InternetOrderReport.OrderNumber AndAlso
                                                      Entity.IsActiveRevision = 1 AndAlso
                                                      _LineNumbers.Contains(Entity.LineNumber) AndAlso
                                                      String.Concat(Entity.TargetAudience) = InternetOrderReport.Target AndAlso
                                                      Entity.MarketCode = InternetOrderReport.LineMarketCode AndAlso
                                                      String.Concat(Entity.CreativeSize) = InternetOrderReport.Dimensions AndAlso
                                                      String.Concat(Entity.CostType) = InternetOrderReport.CostStructure AndAlso
                                                      String.Concat(Entity.Placement2) = InternetOrderReport.Package AndAlso
                                                      String.Concat(Entity.Url) = InternetOrderReport.URL AndAlso
                                                      String.Concat(Entity.Placement1) = InternetOrderReport.Placement
                                                Select Entity).OrderBy(Function(IOD) IOD.StartDate).ToList

                        BindingSourceFlightLines.DataSource = InternetOrderDetails

                    End Using

                Catch ex As Exception
                    BindingSourceFlightLines.DataSource = Nothing
                End Try

                If BindingSourceFlightLines.DataSource Is Nothing OrElse (InternetOrderDetails Is Nothing OrElse InternetOrderDetails.Count < 2) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DetailReportPackagePlacementNames_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportPackagePlacementNames.BeforePrint

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim PlacementNames As Generic.List(Of String) = Nothing
            Dim InternetOrderReportAdSizes As Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize) = Nothing

            If _MediaOrderPrintSetting.Placement1.GetValueOrDefault(0) = 0 Then

                e.Cancel = True

            Else

                Try

                    InternetOrderReportAdSizes = New Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)

                    InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LineNumbers = GetLineNumbers(DbContext, InternetOrderReport)

                        PlacementNames = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, InternetOrderReport.OrderNumber, LineNumbers)
                                          Where Entity.PlacementName IsNot Nothing
                                          Select Entity.PlacementName).Distinct.ToList

                        For Each PlacementName In PlacementNames

                            InternetOrderReportAdSizes.Add(New AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize(PlacementName, Nothing))

                        Next

                        BindingSourcePackageAdSizes.DataSource = InternetOrderReportAdSizes

                    End Using

                Catch ex As Exception
                    BindingSourcePackageAdSizes.DataSource = Nothing
                End Try

                If BindingSourcePackageAdSizes.DataSource Is Nothing OrElse InternetOrderReportAdSizes.Count = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DetailReportPackageAdSizes_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportPackageAdSizes.BeforePrint

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim AdSizeCodes As IEnumerable(Of String) = Nothing
            Dim InternetOrderReportAdSizes As Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize) = Nothing
            Dim AddlAdSizeCodes As Generic.List(Of String) = Nothing
            Dim AdSizes() As String = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            Try

                InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LineNumbers = GetLineNumbers(DbContext, InternetOrderReport)

                    AdSizeCodes = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, InternetOrderReport.OrderNumber, LineNumbers)
                                   Select Entity.AdSizeCode).Distinct.ToArray

                    If (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, InternetOrderReport.OrderNumber, LineNumbers)
                        Where Entity.PlacementName IsNot Nothing
                        Select Entity).Any Then

                        _HasPackagePlacementNames = True

                        InternetOrderReportAdSizes = New Generic.List(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)

                        For Each AdSizeCode In AdSizeCodes

                            AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, AdSizeCode, "I")

                            If AdSize IsNot Nothing Then

                                InternetOrderReportAdSizes.Add(New AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize(Nothing, AdSize.Description))

                            End If

                        Next

                        AddlAdSizeCodes = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, InternetOrderReport.OrderNumber, LineNumbers)
                                           Where Entity.PlacementName IsNot Nothing
                                           Select Entity.AdditionalAdSizeCodes).Distinct.ToList

                        For Each AddlAdSizeCode In AddlAdSizeCodes

                            AdSizes = AddlAdSizeCode.Split(",")

                            For Each AdSiz In AdSizes

                                AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, AdSiz, "I")

                                If AdSize IsNot Nothing Then

                                    InternetOrderReportAdSizes.Add(New AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize(Nothing, AdSize.Description))

                                End If

                            Next

                        Next

                    Else

                        InternetOrderReportAdSizes = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)(String.Format("exec dbo.advsp_media_manager_load_internet_order_ad_sizes '{0}', {1}, {2}", String.Join(",", AdSizeCodes), InternetOrderReport.OrderNumber, LineNumbers.First)).ToList

                    End If

                    BindingSourcePackageAdSizes.DataSource = InternetOrderReportAdSizes

                End Using

            Catch ex As Exception
                BindingSourcePackageAdSizes.DataSource = Nothing
            End Try

            If BindingSourcePackageAdSizes.DataSource Is Nothing OrElse InternetOrderReportAdSizes.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_TargetLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_TargetLabel.BeforePrint

            If _MediaOrderPrintSetting.TargetAudience.GetValueOrDefault(0) = 0 OrElse String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Target) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail_Target_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail_Target.BeforePrint

            If _MediaOrderPrintSetting.TargetAudience.GetValueOrDefault(0) = 0 OrElse String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Target) Then

                e.Cancel = True

            Else

                If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Package) Then

                    Detail_Target.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Target

                Else

                    Detail_Target.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Target & " (" &
                        DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).Package & ")"

                End If

            End If

        End Sub
        Private Sub LabelDetail_Rate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Rate.BeforePrint

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing

            InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LineNumbers = GetLineNumbers(DbContext, InternetOrderReport)

                If LineNumbers.Count = 1 Then

                    LabelDetail_Rate.Text = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                                             Where Entity.InternetOrderOrderNumber = InternetOrderReport.OrderNumber AndAlso
                                                   Entity.IsActiveRevision = 1 AndAlso
                                                   _LineNumbers.Contains(Entity.LineNumber) AndAlso
                                                   String.Concat(Entity.TargetAudience) = InternetOrderReport.Target AndAlso
                                                   Entity.MarketCode = InternetOrderReport.LineMarketCode AndAlso
                                                   String.Concat(Entity.CreativeSize) = InternetOrderReport.Dimensions AndAlso
                                                   String.Concat(Entity.CostType) = InternetOrderReport.CostStructure AndAlso
                                                   String.Concat(Entity.Placement2) = InternetOrderReport.Package AndAlso
                                                   String.Concat(Entity.Url) = InternetOrderReport.URL AndAlso
                                                   String.Concat(Entity.Placement1) = InternetOrderReport.Placement
                                             Select Entity).First.CostRate

                Else

                    e.Cancel = True

                End If

            End Using

        End Sub
        Private Sub LabelDetail_RateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_RateLabel.BeforePrint

            Dim InternetOrderReport As AdvantageFramework.MediaManager.Classes.InternetOrderReport = Nothing

            InternetOrderReport = DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                    Where Entity.InternetOrderOrderNumber = InternetOrderReport.OrderNumber AndAlso
                          Entity.IsActiveRevision = 1 AndAlso
                          _LineNumbers.Contains(Entity.LineNumber) AndAlso
                          Entity.TargetAudience = InternetOrderReport.Target AndAlso
                          Entity.MarketCode = InternetOrderReport.LineMarketCode AndAlso
                          Entity.CreativeSize = InternetOrderReport.Dimensions AndAlso
                          Entity.CostType = InternetOrderReport.CostStructure AndAlso
                          Entity.Placement2 = InternetOrderReport.Package AndAlso
                          Entity.Url = InternetOrderReport.URL
                    Select Entity).Count <> 1 Then

                    e.Cancel = True

                End If

            End Using

        End Sub
        Private Sub LabelDetail_InstructionsLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_InstructionsLabel.BeforePrint

            If _MediaOrderPrintSetting.Instructions.GetValueOrDefault(0) = 0 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Instructions.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetailReportPackageAdSizesHeader_Size_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailReportPackageAdSizesHeader_Size.BeforePrint

            If Not String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Package.ToString)) Then

                If _MediaOrderPrintSetting.Placement2.GetValueOrDefault(0) = 0 Then

                    e.Cancel = True

                Else

                    If _HasPackagePlacementNames Then

                        LabelDetailReportPackageAdSizesHeader_Size.Text = "Ad Size(s)"

                    Else

                        LabelDetailReportPackageAdSizesHeader_Size.Text = "Package Details"

                    End If

                End If

            Else

                LabelDetailReportPackageAdSizesHeader_Size.Text = "Ad Size(s)"

            End If

        End Sub
        Private Sub LabelDetailPackageAdSizesAdSize_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailPackageAdSizesAdSize.BeforePrint

            If Not String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Package.ToString)) Then

                If _MediaOrderPrintSetting.Placement2.GetValueOrDefault(0) = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelDetailReportPackageAdSizesHeader_PackagePlacements_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailReportPackageAdSizesHeader_PackagePlacements.BeforePrint

            If _MediaOrderPrintSetting.Placement2.GetValueOrDefault(0) = 0 OrElse _HasPackagePlacementNames Then

                e.Cancel = True

            Else

                If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Package.ToString)) Then

                    e.Cancel = True

                ElseIf _MediaOrderPrintSetting.Placement1.GetValueOrDefault(0) = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelDetailPackageAdSizesPlacementName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailPackageAdSizesPlacementName.BeforePrint

            If _MediaOrderPrintSetting.Placement2.GetValueOrDefault(0) = 0 OrElse _HasPackagePlacementNames Then

                e.Cancel = True

            Else

                If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.Package.ToString)) Then

                    e.Cancel = True

                ElseIf _MediaOrderPrintSetting.Placement1.GetValueOrDefault(0) = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrTableRowCampaignMarket_Campaign_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowCampaignMarket_Campaign.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CampaignName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowCampaignMarket_Market_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowCampaignMarket_Market.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.MarketName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Units_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Units.BeforePrint

            If Not String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.InternetQtyOverrideText) Then

                LabelDetail_Units.Text = _MediaOrderPrintSetting.InternetQtyOverrideText

            End If

        End Sub
        Private Sub LabelDetailReportFlightLinesHeader_Units_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailReportFlightLinesHeader_Units.BeforePrint

            If Not String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.InternetQtyOverrideText) Then

                LabelDetailReportFlightLinesHeader_Units.Text = _MediaOrderPrintSetting.InternetQtyOverrideText

            End If

        End Sub
        Private Sub LabelDetail_Instructions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Instructions.BeforePrint

            If _MediaOrderPrintSetting.Instructions.GetValueOrDefault(0) = 0 Then

                LabelDetail_Instructions.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterTarget_URLLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterTarget_URLLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.URL.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterTarget_Placement_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterTarget_Placement.BeforePrint

            SetPlacementName()

            If _PlacementCancel Then

                e.Cancel = True

            Else

                LabelGroupFooterTarget_Placement.Text = _PlacementName

            End If

        End Sub
        Private Sub LabelGroupFooterTarget_PlacementLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterTarget_PlacementLabel.BeforePrint

            SetPlacementName()

            If _PlacementCancel Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailLabel_Cancelled_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailLabel_Cancelled.BeforePrint

            If Not DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.InternetOrderReport).LineCancelled Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetailReportPackagePlacementNamesHeader_PackagePlacements_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.BeforePrint

            If _MediaOrderPrintSetting.Placement1.GetValueOrDefault(0) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Address1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address1.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ClientAddress1.ToString)) Then

                TableCellClient_Address1.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Address2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address2.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ClientAddress2.ToString)) Then

                TableCellClient_Address2.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_CityStateZip.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.ClientCSZ.ToString)) Then

                TableCellClient_CityStateZip.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Address1Value_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address1Value.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Address2Value_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address2Value.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_CityStateZipValue_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_CityStateZipValue.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
