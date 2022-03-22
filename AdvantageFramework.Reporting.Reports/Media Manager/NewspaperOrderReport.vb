﻿Namespace MediaManager

    Public Class NewspaperOrderReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumbers As Generic.List(Of Integer) = Nothing
        Private _MediaFrom As String = "N"
        Private _EmployeeEmail As String = Nothing
        Private _IsFirstPage As Boolean = True
        Private _AgencyList As Generic.List(Of AdvantageFramework.Database.Entities.Agency) = Nothing
        Private _PrintCardInfo As Boolean = False
        Private _MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Private _ExchangeRate As Decimal = 1
        Private _CurrencyCode As String = String.Empty
        Private _CurrencySymbol As String = String.Empty
        Private _PrintOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.PrintOrder) = Nothing
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

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub NewspaperOrderReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Buyer As String = Nothing
            Dim Names() As String = Nothing
            Dim FirstName As String = Nothing
            Dim LastName As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Buyer = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Buyer.ToString)

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
        Private Sub NewspaperOrderReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim MultiCurrencyOn As Boolean = False
            Dim HomeCurrencyCode As String = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            _AgencyList = New Generic.List(Of AdvantageFramework.Database.Entities.Agency)

            If _LineNumbers IsNot Nothing AndAlso _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _AgencyList.Add(AdvantageFramework.Database.Procedures.Agency.Load(DbContext))

                    If _AgencyList IsNot Nothing AndAlso _AgencyList.Count = 1 Then

                        If _AgencyList(0).UseMultipleCurrencies.GetValueOrDefault(0) = 1 Then

                            MultiCurrencyOn = True

                            HomeCurrencyCode = _AgencyList(0).HomeCurrency

                        End If

                    End If

                    _PrintCardInfo = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

                    _MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, _Session.UserCode, _MediaFrom)

                    If _MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(_MediaFrom)

                        _MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                        _MediaOrderPrintSetting.UserCode = _Session.UserCode.ToUpper
                        _MediaOrderPrintSetting.MediaType = _MediaFrom

                        OrderPrintSetting.Save(_MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, _MediaOrderPrintSetting, Nothing)

                    End If

                    If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaOrderPrintSetting.LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                    _CurrencyCode = NewspaperOrder.Vendor.CurrencyCode

                    If MultiCurrencyOn AndAlso Not String.IsNullOrWhiteSpace(_CurrencyCode) AndAlso _CurrencyCode <> HomeCurrencyCode Then

                        Try

                            _CurrencySymbol = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CURRENCY_SYMBOL, '') FROM dbo.CURRENCY_CODES WHERE CURRENCY_CODE = '{0}'", _CurrencyCode)).FirstOrDefault

                        Catch ex As Exception
                            _CurrencySymbol = String.Empty
                        End Try

                        CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, _CurrencyCode, HomeCurrencyCode)

                        If CurrencyDetail IsNot Nothing Then

                            _ExchangeRate = CurrencyDetail.ReciprocalExchangeRate

                        End If

                    End If

                    If MultiCurrencyOn Then

                        _PrintOrders = AdvantageFramework.MediaManager.LoadPrintOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom, _ExchangeRate).ToList

                    Else

                        If _MediaOrderPrintSetting.ApplyExchangeRate Then

                            _ExchangeRate = _MediaOrderPrintSetting.ExchangeRate.GetValueOrDefault(1)

                        End If

                        _PrintOrders = AdvantageFramework.MediaManager.LoadPrintOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom, _ExchangeRate).ToList

                    End If

                End Using

            Else

                _PrintOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.PrintOrder)

            End If

            For Each PrintOrder In _PrintOrders

                If String.IsNullOrEmpty(PrintOrder.LocationHeader) = False Then

                    PrintOrder.LocationHeader = PrintOrder.LocationHeader.Trim

                End If

                If String.IsNullOrEmpty(PrintOrder.LocationFooter) = False Then

                    PrintOrder.LocationFooter = PrintOrder.LocationFooter.Trim

                End If

            Next

            Me.DataSource = _PrintOrders

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupFooterOrderNumberSubreport_NewspaperCharges_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_NewspaperCharges.BeforePrint

            Dim OrderNumber As Integer = Nothing
            Dim NewspaperOtherCharges As IEnumerable(Of AdvantageFramework.Database.Entities.NewspaperOtherCharge) = Nothing

            OrderNumber = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderNumber.ToString)

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    NewspaperOtherCharges = (From Entity In DbContext.NewspaperOtherCharges
                                             Where Entity.OrderNumber = OrderNumber AndAlso
                                                   Entity.ChargeType <> "AF"
                                             Select Entity).ToList.Select(Function(NOC) New AdvantageFramework.Database.Entities.NewspaperOtherCharge(NOC.ChargeDescription, NOC.Amount, _ExchangeRate)).ToList

                End Using

            Catch ex As Exception
                NewspaperOtherCharges = Nothing
            End Try

            If NewspaperOtherCharges IsNot Nothing AndAlso NewspaperOtherCharges.Count > 0 Then

                GroupFooterOrderNumberSubreport_NewspaperCharges.ReportSource.DataSource = NewspaperOtherCharges

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.HeadlineFlag.ToString) = 1 Then

                Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Type/Headline"

            Else

                Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = ""

            End If

            Me.LabelHeaderOrderNumber_StartLabel1.Text = ""
            Me.LabelHeaderOrderNumber_StartLabel2.Text = "Date"
            Me.LabelHeaderOrderNumber_EndLabel1.Text = ""

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                LabelHeaderOrderNumber_AmountLabel1.Text = "Gross"

            Else

                LabelHeaderOrderNumber_AmountLabel1.Text = "Net"

            End If

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.CostType.ToString) = "CPM" Then

                Me.LabelHeaderOrderNumber_EndLabel2.Text = ""
                Me.LabelHeaderOrderNumber_SizeLabel.Text = "Circulation/Qty"
                Me.LabelDetail_Size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

                Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Rate"

            Else

                Me.LabelHeaderOrderNumber_EndLabel2.Text = "Day"
                Me.LabelHeaderOrderNumber_SizeLabel.Text = "Ad Size"
                Me.LabelDetail_Size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

                Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Type/Headline"

            End If

        End Sub
        Private Sub LabelDetail_InsertDay_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_InsertDay.BeforePrint

            If _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Size_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Size.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.CostType.ToString) = "CPM" Then

                LabelDetail_Size.Text = "QTY: " & Format(CDec(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Size.ToString)), "n0") & vbCrLf & Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AdSizeDescription.ToString)

            End If

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
        Private Sub LabelGroupFooterOrderNumber_ColorChargeSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_ColorChargeSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_ColorChargeSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_ColorChargeSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_BleedCostSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_BleedCostSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_BleedCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_BleedCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_BleedCostSum.Text = FormatNumber(LabelGroupFooterOrderNumber_BleedCostHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_BleedCostSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_BleedCostSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_BleedCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_BleedCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_BleedCostSumLabel.Text = "Bleed Cost:"

            Else

                LabelGroupFooterOrderNumber_BleedCostSumLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_PositionCostSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_PositionCostSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_PositionCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_PositionCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_PositionCostSum.Text = FormatNumber(LabelGroupFooterOrderNumber_PositionCostHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_PositionCostSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_PositionCostSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_PositionCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_PositionCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_PositionCostSumLabel.Text = "Position Cost:"

            Else

                LabelGroupFooterOrderNumber_PositionCostSumLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_PremiumCostSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_PremiumCostSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_PremiumCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_PremiumCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_PremiumCostSum.Text = FormatNumber(LabelGroupFooterOrderNumber_PremiumCostHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_PremiumCostSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_PremiumCostSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_PremiumCostHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_PremiumCostHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_PremiumCostSumLabel.Text = "Position Cost:"

            Else

                LabelGroupFooterOrderNumber_PremiumCostSumLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_DiscountSum.Text = FormatNumber(LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_DiscountSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.DiscountDescription.ToString) & ":"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSumLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterOrderNumberSubreport_VendorShippingSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_VendorShippingSubReport.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ShippingAddressFlag.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorCode.ToString)

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

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ExcludeEmployeeSignature.ToString) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.BuyerEmployeeCode.ToString)) = False Then

                        BuyerEmployeeCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.BuyerEmployeeCode.ToString)

                        Employee = (From EMP In DbContext.Employees
                                    Where EMP.Code = BuyerEmployeeCode AndAlso
                                          EMP.TerminationDate Is Nothing AndAlso
                                          EMP.SignatureImage IsNot Nothing
                                    Select EMP).FirstOrDefault

                    ElseIf String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Buyer.ToString)) = False Then

                        NameParts = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Buyer.ToString).ToString.Split(" ")

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

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorCode.ToString)

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

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.IncludeRep1.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorRepCode1.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.DefaultRep1Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
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

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.RepLabel1.ToString)

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

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.IncludeRep2.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.VendorRepCode2.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.DefaultRep2Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
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

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.RepLabel2.ToString)

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

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_VendorTaxHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_VendorTaxHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_VendorTaxSum.Text = FormatNumber(LabelGroupFooterOrderNumber_VendorTaxHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_VendorTaxLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_VendorTaxLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_VendorTaxHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_VendorTaxHidden.Summary.GetResult = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommissionSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommissionSum.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_AgencyCommissionHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_AgencyCommissionHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_AgencyCommissionSum.Text = FormatNumber(LabelGroupFooterOrderNumber_AgencyCommissionHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommissionLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommissionLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_AgencyCommissionHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_AgencyCommissionHidden.Summary.GetResult = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail_AfterPrint(sender As Object, e As EventArgs) Handles Detail.AfterPrint

            If _IsFirstPage Then

                _IsFirstPage = False

            End If

        End Sub
        Private Sub DetailSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSubreport_ChargeToSubReport.BeforePrint

            If Me.DataSource.Count = 1 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

                e.Cancel = True

            Else

                DetailSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                DirectCast(DetailSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)

            End If

        End Sub
        Private Sub GroupFooterOrderNumberSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_ChargeToSubReport.BeforePrint

            If Me.DataSource.Count = 1 Then

                If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

                    e.Cancel = True

                Else

                    GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                    DirectCast(GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Client_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Client.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ClientName.ToString) Is Nothing Then

                TableCellClient_Client.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Division_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Division.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.DivisionName.ToString) Is Nothing Then

                TableCellClient_Division.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Product_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Product.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ProductionDescription.ToString) Is Nothing Then

                TableCellClient_Product.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyComment.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub GroupHeaderFirstPageOnly2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderFirstPageOnly2.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            End If

        End Sub
        Private Sub RichTextGroupFooterOrderNumber_OrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextGroupFooterOrderNumber_OrderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderComment.ToString)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderComment.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_Box_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_Box.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_LineTotalActual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_LineTotalActual.BeforePrint

            Dim Total As Decimal? = Nothing

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                Total = _PrintOrders.Where(Function(PO) PO.OrderNumber = _OrderNumber).Sum(Function(PO) PO.LineTotalActual.GetValueOrDefault(0))

                If String.IsNullOrWhiteSpace(_CurrencySymbol) = False Then

                    LabelGroupFooterOrderNumber_LineTotalActual.Text = _CurrencySymbol & FormatNumber(Total, 2)

                Else

                    LabelGroupFooterOrderNumber_LineTotalActual.Text = FormatNumber(Total, 2)

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderTotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderTotalLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelFooterOrderNumber_SubtotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelFooterOrderNumber_SubtotalLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                LabelFooterOrderNumber_SubtotalLabel.Text = "Total Gross:"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommentTop.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderNumber_AgencyCommentTop.Text = Nothing

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub RichTextGroupFooterOrderNumber_OrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextGroupFooterOrderNumber_OrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                RichTextGroupFooterOrderNumber_OrderCommentTop.Text = Nothing

            ElseIf TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderComment.ToString)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentTop.Text = Nothing

            End If

        End Sub
        Private Sub LabelHeaderOrderNumber_StartLabel2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeaderOrderNumber_StartLabel2.BeforePrint

            If _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelHeaderOrderNumber_EndLabel2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeaderOrderNumber_EndLabel2.BeforePrint

            If _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_InsertDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_InsertDate.BeforePrint

            If _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandSignatures_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandSignatures.BeforePrint

            If _MediaOrderPrintSetting.RemoveSignatureLines Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Campaign_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Campaign.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.CampaignName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Market_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Market.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.InternetOrderReport.Properties.MarketName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderFirstPageOnly2_OrderCommentLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderFirstPageOnly2_OrderCommentLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            End If

        End Sub
        Private Sub RichTextGroupHeaderFirstPageOnly2_OrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextGroupHeaderFirstPageOnly2_OrderComment.BeforePrint

            If TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderComment.ToString)

            End If

        End Sub
        Private Sub TableCellClient_Address1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address1.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ClientAddress1.ToString)) Then

                TableCellClient_Address1.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Address2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address2.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ClientAddress2.ToString)) Then

                TableCellClient_Address2.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_CityStateZip.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ClientCSZ.ToString)) Then

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
        Private Sub XrTableCellCirculationQtyLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellCirculationQtyLabel.BeforePrint

            If _MediaOrderPrintSetting.NewspaperIncludeCirculationQTY = False OrElse Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NewspaperCirculationQty.ToString) Is Nothing Then

                XrTableCellCirculationQtyLabel.Text = Nothing

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
