Namespace MediaManager

    Public Class ClientBillingAuthReport

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
        Private _ExchangeRate As Decimal = 1
        Private _CurrencyCode As String = String.Empty
        Private _CurrencySymbol As String = String.Empty
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



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientBillingAuthReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

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
        Private Sub ClientBillingAuthReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim PrintOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.PrintOrder) = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim MultiCurrencyOn As Boolean = False
            Dim HomeCurrencyCode As String = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
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

                    _MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, _Session.UserCode, Mid(_MediaFrom, 1, 1).ToUpper)

                    If _MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(Mid(_MediaFrom, 1, 1).ToUpper)

                        _MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                        _MediaOrderPrintSetting.UserCode = _Session.UserCode.ToUpper
                        _MediaOrderPrintSetting.MediaType = Mid(_MediaFrom, 1, 1).ToUpper

                        OrderPrintSetting.Save(_MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, _MediaOrderPrintSetting, Nothing)

                    End If

                    If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaOrderPrintSetting.LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    If Mid(_MediaFrom, 1, 1).ToUpper = "I" Then

                        InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        _CurrencyCode = InternetOrder.Vendor.CurrencyCode

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "M" Then

                        MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        _CurrencyCode = MagazineOrder.Vendor.CurrencyCode

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "N" Then

                        NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        _CurrencyCode = NewspaperOrder.Vendor.CurrencyCode

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "O" Then

                        OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        _CurrencyCode = OutOfHomeOrder.Vendor.CurrencyCode

                    End If

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

                        PrintOrders = AdvantageFramework.MediaManager.LoadPrintOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom.Substring(0, 1), _ExchangeRate).ToList

                    Else

                        If _MediaOrderPrintSetting.ApplyExchangeRate Then

                            _ExchangeRate = _MediaOrderPrintSetting.ExchangeRate.GetValueOrDefault(1)

                        End If

                        PrintOrders = AdvantageFramework.MediaManager.LoadPrintOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom.Substring(0, 1), _ExchangeRate).ToList

                    End If

                End Using

            Else

                PrintOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.PrintOrder)

            End If

            For Each PrintOrder In PrintOrders

                If String.IsNullOrEmpty(PrintOrder.LocationHeader) = False Then

                    PrintOrder.LocationHeader = PrintOrder.LocationHeader.Trim

                End If

                If String.IsNullOrEmpty(PrintOrder.LocationFooter) = False Then

                    PrintOrder.LocationFooter = PrintOrder.LocationFooter.Trim

                End If

            Next

            Me.DataSource = PrintOrders

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            Dim MediaType As String = Nothing

            MediaType = _MediaFrom.Substring(0, 1)

            If MediaType = "N" OrElse MediaType = "M" Then

                Me.LabelDetail_EndDate.Visible = False
                Me.LabelDetail_SubTypeDescription.Visible = False
                Me.LabelDetail_Impressions.Visible = False

            ElseIf MediaType = "I" Then

                Me.LabelDetail_InsertDay.Visible = False

                Me.LabelDetail_Headline.Visible = False

                XrTableCellCopyAreaLabel.Text = "File Size"

            ElseIf MediaType = "O" Then

                Me.LabelDetail_InsertDay.Visible = False

                Me.LabelDetail_SubTypeDescription.Visible = False
                Me.LabelDetail_Impressions.Visible = False

            End If

        End Sub
        Private Sub GroupFooterOrderNumberSubreport_NewspaperCharges_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_NewspaperCharges.BeforePrint

            Dim OrderNumber As Integer = Nothing
            Dim NewspaperOtherCharges As IEnumerable(Of AdvantageFramework.Database.Entities.NewspaperOtherCharge) = Nothing

            If _MediaFrom.Substring(0, 1) = "N" Then

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

            End If

            If NewspaperOtherCharges IsNot Nothing AndAlso NewspaperOtherCharges.Count > 0 Then

                GroupFooterOrderNumberSubreport_NewspaperCharges.ReportSource.DataSource = NewspaperOtherCharges

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderEveryPage2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderEveryPage2.BeforePrint

            Select Case _MediaFrom.Substring(0, 1)

                Case "M"

                    Me.LabelHeaderOrderNumber_StartLabel1.Text = "Insert"
                    Me.LabelHeaderOrderNumber_StartLabel2.Text = "Date"
                    Me.LabelHeaderOrderNumber_EndLabel1.Text = ""
                    Me.LabelHeaderOrderNumber_EndLabel2.Text = ""
                    Me.LabelHeaderOrderNumber_SizeLabel.Text = "Ad Size"

                    If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.HeadlineFlag.ToString) = 1 Then

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Headline"

                    Else

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = ""

                    End If

                Case "N"

                    If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.HeadlineFlag.ToString) = 1 Then

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Type/Headline"

                    Else

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = ""

                    End If

                    Me.LabelHeaderOrderNumber_StartLabel1.Text = ""
                    Me.LabelHeaderOrderNumber_StartLabel2.Text = "Date"
                    Me.LabelHeaderOrderNumber_EndLabel1.Text = ""

                    If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.CostType.ToString) = "CPM" Then

                        Me.LabelHeaderOrderNumber_EndLabel2.Text = ""
                        Me.LabelHeaderOrderNumber_SizeLabel.Text = "Circulation/Qty"
                        Me.LabelDetail_Size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

                    Else

                        Me.LabelHeaderOrderNumber_EndLabel2.Text = "Day"
                        Me.LabelHeaderOrderNumber_SizeLabel.Text = "Ad Size"
                        Me.LabelDetail_Size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

                    End If

                Case "I"

                    Me.LabelHeaderOrderNumber_StartLabel1.Text = "Start"
                    Me.LabelHeaderOrderNumber_StartLabel2.Text = "Date"
                    Me.LabelHeaderOrderNumber_EndLabel1.Text = "End"
                    Me.LabelHeaderOrderNumber_EndLabel2.Text = "Date"
                    Me.LabelHeaderOrderNumber_SizeLabel.Text = "Creative Size"

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.SubTypeDescription.ToString)) Then

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = ""

                    Else

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Type"

                    End If

                    XrTableCellCopyAreaLabel.Text = "File Size"

                Case "O"

                    Me.LabelHeaderOrderNumber_StartLabel1.Text = "Post"
                    Me.LabelHeaderOrderNumber_StartLabel2.Text = "Date"
                    Me.LabelHeaderOrderNumber_EndLabel1.Text = "End"
                    Me.LabelHeaderOrderNumber_EndLabel2.Text = "Date"

                    If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.HeadlineFlag.ToString) = 1 Then

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Headline"

                    Else

                        Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = ""

                    End If

                    If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.BillTypeFlag.ToString) = 1 Then

                        Me.LabelHeaderOrderNumber_SizeLabel.Text = "Size/Type"

                    Else

                        Me.LabelHeaderOrderNumber_SizeLabel.Text = "Size"

                    End If

            End Select

        End Sub
        Private Sub LabelDetail_EndDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_EndDate.BeforePrint

            If _MediaFrom.Substring(0, 1) = "M" OrElse _MediaFrom.Substring(0, 1) = "N" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Impressions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Impressions.BeforePrint

            If _MediaFrom.Substring(0, 1) <> "I" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_InsertDay_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_InsertDay.BeforePrint

            If _MediaFrom.Substring(0, 1) <> "N" Then

                e.Cancel = True

            ElseIf _MediaFrom.Substring(0, 1) = "N" AndAlso _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Size_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Size.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.CostType.ToString) = "CPM" Then

                If _MediaFrom.Substring(0, 1) = "N" Then

                    LabelDetail_Size.Text = "QTY: " & Format(CDec(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Size.ToString)), "n0") & vbCrLf & Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.AdSizeDescription.ToString)

                ElseIf IsNumeric(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Size.ToString)) Then

                    LabelDetail_Size.Text = Format(CDec(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.Size.ToString)), "n0")

                End If

            End If

        End Sub
        Private Sub LabelDetail_SubTypeDescription_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_SubTypeDescription.BeforePrint

            If _MediaFrom.Substring(0, 1) <> "I" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.PageHeaderLogoPath.ToString) IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.PageHeaderLogoPath.ToString)) = False Then

                        If My.Computer.FileSystem.FileExists(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.PageHeaderLogoPath.ToString)) Then

                            XrPictureBoxHeaderLogo.ImageUrl = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.PageHeaderLogoPath.ToString)

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

            ElseIf LabelGroupFooterOrderNumber_ColorChargeHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_ColorChargeHidden.Summary.GetResult <> 0 AndAlso
                   _MediaFrom.Substring(0, 1) <> "N" Then

                LabelGroupFooterOrderNumber_ColorChargeSum.Text = FormatNumber(LabelGroupFooterOrderNumber_ColorChargeHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_ColorChargeSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_ColorChargeSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_ColorChargeHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_ColorChargeHidden.Summary.GetResult <> 0 AndAlso
                   _MediaFrom.Substring(0, 1) <> "N" Then

                LabelGroupFooterOrderNumber_ColorChargeSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ColorDescription.ToString) & ":"

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
        Private Sub LabelGroupFooterOrderNumber_DiscountSum_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSum.BeforePrint, LabelGroupFooterOrderNumber_DiscountSum2.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_DiscountSum.Text = FormatNumber(LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult, 2)
                LabelGroupFooterOrderNumber_DiscountSum2.Text = FormatNumber(LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountSumLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_DiscountAmountHidden.Summary.GetResult <> 0 Then

                LabelGroupFooterOrderNumber_DiscountSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.DiscountDescription.ToString) & ":"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSum_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSum.BeforePrint, LabelGroupFooterOrderNumber_NetChargeSum2.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult <> 0 AndAlso
                   _MediaFrom.Substring(0, 1) <> "N" Then

                LabelGroupFooterOrderNumber_NetChargeSum.Text = FormatNumber(LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult, 2)
                LabelGroupFooterOrderNumber_NetChargeSum2.Text = FormatNumber(LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeSumLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeSumLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            ElseIf LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult IsNot Nothing AndAlso LabelGroupFooterOrderNumber_NetChargeHidden.Summary.GetResult <> 0 AndAlso
                    _MediaFrom.Substring(0, 1) <> "N" Then

                LabelGroupFooterOrderNumber_NetChargeSumLabel.Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetChargeDescription.ToString) & ":"

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

                'DirectCast(DetailSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).Session = _Session
                DirectCast(DetailSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)

            End If

        End Sub
        Private Sub GroupFooterOrderNumberSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_ChargeToSubReport.BeforePrint

            If Me.DataSource.Count = 1 Then

                If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

                    e.Cancel = True

                Else

                    GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                    'DirectCast(GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).Session = _Session
                    DirectCast(GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.ChargeTo.ToString)

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        'Private Sub GroupFooterOrderNumber_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumber.BeforePrint

        '    _EndOfReportReached = True

        'End Sub
        'Private Sub GroupHeaderEveryPage_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderEveryPage.BeforePrint

        '    If _EndOfReportReached Then

        '        e.Cancel = True

        '    End If

        'End Sub
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

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

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

            If _MediaFrom.Substring(0, 1) = "N" AndAlso _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelHeaderOrderNumber_EndLabel2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeaderOrderNumber_EndLabel2.BeforePrint

            If _MediaFrom.Substring(0, 1) = "N" AndAlso _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_InsertDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_InsertDate.BeforePrint

            If _MediaFrom.Substring(0, 1) = "N" AndAlso _MediaOrderPrintSetting.PrintDayDate = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandSignatures_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandSignatures.BeforePrint

            If _MediaOrderPrintSetting.RemoveSignatureLines Then

                e.Cancel = True

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
        Private Sub DetailSubreport_AdditionalAdSizes_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSubreport_AdditionalAdSizes.BeforePrint

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim LineNumber As Short = Nothing
            Dim AdSizeCodes As IEnumerable(Of String) = Nothing
            Dim AdSizes As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) = Nothing

            If _MediaFrom.Substring(0, 1) = "I" Then

                OrderNumber = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.OrderNumber.ToString)
                LineNumber = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.PrintOrder.Properties.LineNumber.ToString)

                Try

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdSizeCodes = (From Entity In DbContext.InternetPackageDetails
                                       Where Entity.OrderNumber = OrderNumber AndAlso
                                             Entity.LineNumber = LineNumber AndAlso
                                             Entity.IsActiveRevision = True
                                       Select Entity.AdSizeCode).ToArray

                        AdSizes = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadByMediaType(DbContext, "I")
                                   Where AdSizeCodes.Contains(Entity.Code)
                                   Select Entity).ToList
                    End Using

                Catch ex As Exception
                    AdSizes = Nothing
                End Try

            End If

            If AdSizes IsNot Nothing AndAlso AdSizes.Count > 0 Then

                DirectCast(DetailSubreport_AdditionalAdSizes.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.AdditionalAdSizesSubReport).PrintedFlag = False

                DetailSubreport_AdditionalAdSizes.ReportSource.DataSource = AdSizes

            Else

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
