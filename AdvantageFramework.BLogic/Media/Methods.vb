Namespace Media

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const NonAiringSpots As String = "Non-airing spots"
        Public Const NewRow As String = "New Row"

#End Region

#Region " Enum "

        Public Enum NonBroadcastMediaOrderFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "001 - STD FMT - Portrait")>
            Portrait = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "002 - Net Order with Gross Client Totals")>
            NetOrderWithGrossClientTotals = 2
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "002 - STD FMT - Charges Combined")>
            'ChargesCombined = 2
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "003 - STD FMT - Net/Gross Separate")>
            'NetGrossSeparate = 3
        End Enum

        Public Enum InternetOrderFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "001 - STD FMT - Portrait")>
            Portrait = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "002 - STD Detail")>
            Detail = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "003 - Net Order with Gross Client Totals")>
            NetOrderWithGrossClientTotals = 3
        End Enum

        Public Enum BroadcastMediaOrderFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "001 - STD FMT - Landscape")>
            Landscape = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "002 - STD FMT - Daily Broadcast by Week")>
            DailyBroadcastByWeek = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "003 - STD FMT - Daily Broadcast by Spot")>
            DailyBroadcastBySpot = 6
        End Enum

        Public Enum BroadcastMediaOrderFormatsWeekly
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "001 - STD FMT - Landscape")>
            Landscape = 4
        End Enum

        Public Enum MediaOrderTitleOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Order Type")>
            OrderType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("S", "Media Type (Sales Class) Description")>
            MediaType
        End Enum

        Public Enum MediaOrderDateOverrideSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Use Printed Date")>
            UsePrintedDate = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Use Order Date")>
            UseOrderDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Print ""Revised Date""")>
            PrintRevisedDate = 2
        End Enum

        Public Enum MediaTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Outdoor")>
            Outdoor = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            TV = 6
        End Enum

        Public Enum CostType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPM", "Cost Per Thousand")>
            CostPerThousand
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPC", "Cost Per Click")>
            CostPerClick
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPA", "Cost Per Acquisition")>
            CostPerAcquisition
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NA", "Not Applicable")>
            NotApplicable
        End Enum

        Public Enum ImportSource
            [Default]
            MediaPlanning
            AuthorizationToBuy
            BroadcastWorksheet
        End Enum

        Public Enum MediaLineStatus

            Order = 0
            Quote = 1

        End Enum

        Public Enum MediaOrderHeaderCommentOption
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Print in Header")>
            PrintInHeader = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Print in Footer")>
            PrintInFooter = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Do Not Print")>
            DoNotPrint = 2
        End Enum

        Public Enum PurchaseOrderDateOverrideSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Use Printed Date")>
            UsePrintedDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Use Order Date")>
            UseOrderDate = 0
        End Enum

        Public Enum MediaRFPIncludeCPPSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Show Total")>
            ShowTotal = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show by Daypart")>
            ShowByDaypart = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Do not Show")>
            DoNotShow = 2
        End Enum

        Public Enum MediaRFPIncludeGRPSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Show")>
            Show = 0
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show by Daypart")>
            'ShowByDaypart = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Do not Show")>
            DoNotShow = 2
        End Enum

#End Region

        Public Sub CreateOrderFiles(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
                                    ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                    ByRef BroadCastFullFileName As String, ByRef BroadcastStringBuilder As System.Text.StringBuilder,
                                    ByRef InternetFullFileName As String, ByRef InternetStringBuilder As System.Text.StringBuilder,
                                    ByRef NewspaperFullFileName As String, ByRef NewspaperStringBuilder As System.Text.StringBuilder,
                                    ByRef MagazineFullFileName As String, ByRef MagazineStringBuilder As System.Text.StringBuilder,
                                    ByRef OutOfHomeFullFileName As String, ByRef OutOfHomeStringBuilder As System.Text.StringBuilder,
                                    Optional ByVal OutputPath As String = "")

            'objects
            Dim BroadcastFileName As String = ""
            Dim InternetFileName As String = ""
            Dim NewspaperFileName As String = ""
            Dim MagazineFileName As String = ""
            Dim OutOfHomeFileName As String = ""
            Dim StringBuilderLine As System.Text.StringBuilder = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing

            BroadcastFileName = "BC_ORD_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")
            BroadCastFullFileName = FormatFileName(OutputPath, BroadcastFileName & ".csv")
            BroadcastStringBuilder = New System.Text.StringBuilder

            InternetFileName = "INTERNET_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")
            InternetFullFileName = FormatFileName(OutputPath, InternetFileName & ".csv")
            InternetStringBuilder = New System.Text.StringBuilder

            NewspaperFileName = "NEWSPAPER_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")
            NewspaperFullFileName = FormatFileName(OutputPath, NewspaperFileName & ".csv")
            NewspaperStringBuilder = New System.Text.StringBuilder

            MagazineFileName = "MAGAZINE_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")
            MagazineFullFileName = FormatFileName(OutputPath, MagazineFileName & ".csv")
            MagazineStringBuilder = New System.Text.StringBuilder

            OutOfHomeFileName = "OUTDOOR_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")
            OutOfHomeFullFileName = FormatFileName(OutputPath, OutOfHomeFileName & ".csv")
            OutOfHomeStringBuilder = New System.Text.StringBuilder

            StringBuilderLine = New System.Text.StringBuilder

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                For Each ImportOrder In ImportOrders

                    If ImportOrder.ImportAccountPayableMediaID IsNot Nothing Then

                        ImportAccountPayableMedia = AdvantageFramework.Database.Procedures.ImportAccountPayableMedia.LoadByID(DbContext, ImportOrder.ImportAccountPayableMediaID)

                        If ImportAccountPayableMedia IsNot Nothing Then

                            ImportAccountPayableMedia.OrderID = ImportOrder.OrderID

                            ImportAccountPayableMedia.OrderLineID = ImportOrder.LineNumber

                            DbContext.UpdateObject(ImportAccountPayableMedia)

                        End If

                    End If

                    StringBuilderLine.Clear()

                    If ImportOrder.MediaType = "T" OrElse ImportOrder.MediaType = "R" Then

                        CreateBroadcastLine(StringBuilderLine, ImportOrder, DbContext, ShowOrderDescription, OrderDescription, DataContext)
                        BroadcastStringBuilder.AppendLine(StringBuilderLine.ToString)

                    ElseIf ImportOrder.MediaType = "I" Then

                        CreateInternetLine(StringBuilderLine, ImportOrder, DbContext, ShowOrderDescription, OrderDescription, DataContext)
                        InternetStringBuilder.AppendLine(StringBuilderLine.ToString)

                    ElseIf ImportOrder.MediaType = "N" Then

                        CreateNewspaperLine(StringBuilderLine, ImportOrder, DbContext, ShowOrderDescription, OrderDescription, DataContext)
                        NewspaperStringBuilder.AppendLine(StringBuilderLine.ToString)

                    ElseIf ImportOrder.MediaType = "M" Then

                        CreateMagazineLine(StringBuilderLine, ImportOrder, DbContext, ShowOrderDescription, OrderDescription, DataContext)
                        MagazineStringBuilder.AppendLine(StringBuilderLine.ToString)

                    ElseIf ImportOrder.MediaType = "O" Then

                        CreateOutOfHomeLine(StringBuilderLine, ImportOrder, DbContext, ShowOrderDescription, OrderDescription, DataContext)
                        OutOfHomeStringBuilder.AppendLine(StringBuilderLine.ToString)

                    End If

                Next

            End Using

            DbContext.SaveChanges()

        End Sub
        Public Function WriteFile(ByVal FileStringBuilder As System.Text.StringBuilder, ByVal FullFileName As String,
                                  ByVal FileSystemUserName As String, ByVal FileSystemDomain As String, ByVal FileSystemPassword As String) As Boolean

            'objects
            Dim FileWritten As Boolean = False
            Dim ImpersonateUser As Boolean = False

            If FileStringBuilder.Length > 0 Then

                If String.IsNullOrWhiteSpace(FileSystemUserName) = False Then

                    ImpersonateUser = True

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(FileSystemUserName, FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(FileSystemPassword))

                End If

                Try

                    My.Computer.FileSystem.WriteAllText(FullFileName, FileStringBuilder.ToString, False)

                Catch ex As Exception

                End Try

                If ImpersonateUser Then

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

                FileWritten = My.Computer.FileSystem.FileExists(FullFileName)

            Else

                FileWritten = True

            End If

            WriteFile = FileWritten

        End Function
        Public Function AssignOrderID(Session As AdvantageFramework.Security.Session,
                                      CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                      ByRef ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)) As Boolean

            'objects
            Dim Assigned As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Assigned = AssignOrderID(DbContext, DataContext, CreateOrderOption, ImportOrderList)

                    End Using

                End Using

            Catch ex As Exception

            End Try

            AssignOrderID = Assigned

        End Function
        Public Function AssignOrderID(Session As AdvantageFramework.Security.Session,
                                      CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                      ByRef WebImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.WebImportOrder)) As Boolean

            'objects
            Dim Assigned As Boolean = False
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

            Try

                ImportOrderList = WebImportOrderList.Select(Function(WebImpOrd) WebImpOrd.GetImportOrder()).ToList

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Assigned = AssignOrderID(DbContext, DataContext, CreateOrderOption, ImportOrderList)

                    End Using

                End Using

                WebImportOrderList = ImportOrderList.Select(Function(ImpOrd) New AdvantageFramework.Media.Classes.WebImportOrder(ImpOrd)).ToList

            Catch ex As Exception

            End Try

            AssignOrderID = Assigned

        End Function
        Public Function AssignOrderID(DbContext As AdvantageFramework.Database.DbContext,
                                      DataContext As AdvantageFramework.Database.DataContext,
                                      CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                      ByRef ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)) As Boolean

            'objects
            Dim NewImportOrders As IEnumerable(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrderDistinctList As IEnumerable(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim OrderID As Integer = 0
            Dim NewOrderID As Integer = 0
            Dim NewLineNumber As Short = 0
            Dim Assigned As Boolean = False

            If CreateOrderOption = AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default Then

                Try

                    NewImportOrders = ImportOrderList.Where(Function(O) O.IsRevision = False).ToList

                    If NewImportOrders.Any(Function(O) O.SalesClassCode Is Nothing OrElse O.SalesClassCode = "") = False Then

                        ImportOrderDistinctList = (From Entity In NewImportOrders
                                                   Group By MediaType = Entity.MediaType,
                                                            SalesClassCode = Entity.SalesClassCode,
                                                            ClientCode = Entity.ClientCode,
                                                            DivisionCode = Entity.DivisionCode,
                                                            ProductCode = Entity.ProductCode,
                                                            VendorCode = Entity.VendorCode,
                                                            MediaPlanMarketCode = Entity.MediaPlanMarketCode,
                                                            CampaignCode = Entity.CampaignCode,
                                                            ImportSource = Entity.ImportSource
                                                            Into g = Group
                                                   Select New AdvantageFramework.Media.Classes.ImportOrder With {.MediaType = MediaType,
                                                                                                                 .SalesClassCode = SalesClassCode,
                                                                                                                 .ClientCode = ClientCode,
                                                                                                                 .DivisionCode = DivisionCode,
                                                                                                                 .ProductCode = ProductCode,
                                                                                                                 .VendorCode = VendorCode,
                                                                                                                 .MediaPlanMarketCode = MediaPlanMarketCode,
                                                                                                                 .CampaignCode = CampaignCode,
                                                                                                                 .ImportSource = ImportSource}).ToList

                        For Each ImportOrder In ImportOrderDistinctList.Where(Function(Order) Order.MediaType = "R" OrElse Order.MediaType = "T")

                            'If NewOrderID = 0 Then

                            NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                            'Else

                            '	NewOrderID += 1

                            'End If

                            NewLineNumber = 0

                            For Each IAP In NewImportOrders

                                If IAP.MediaType = ImportOrder.MediaType AndAlso IAP.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                        IAP.ClientCode = ImportOrder.ClientCode AndAlso IAP.DivisionCode = ImportOrder.DivisionCode AndAlso
                                        IAP.ProductCode = ImportOrder.ProductCode AndAlso IAP.VendorCode = ImportOrder.VendorCode AndAlso
                                        IAP.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso
                                        IAP.CampaignCode = ImportOrder.CampaignCode Then

                                    If IAP.OrderID.GetValueOrDefault(0) = 0 Then

                                        IAP.OrderID = NewOrderID

                                        NewLineNumber += 1

                                        IAP.LineNumber = NewLineNumber

                                    Else

                                        If IAP.LineNumber.GetValueOrDefault(0) = 0 Then

                                            If IAP.ImportSource = ImportSource.BroadcastWorksheet Then

                                                IAP.LineNumber = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Where(Function(Entity) Entity.LinkID = IAP.OrderID).Max(Function(Entity) Entity.LinkLineID.GetValueOrDefault(0)) + 1

                                                Do Until ImportOrderList.Any(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = IAP.OrderID AndAlso
                                                                                              Entity.LineNumber.GetValueOrDefault(0) = IAP.LineNumber.GetValueOrDefault(0) AndAlso
                                                                                              Entity.MediaPlanDetailLevelLineDataIDs <> IAP.MediaPlanDetailLevelLineDataIDs) = False

                                                    IAP.LineNumber += 1

                                                Loop

                                            Else

                                                If ImportOrderList.Any(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = IAP.OrderID) Then

                                                    IAP.LineNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = IAP.OrderID).Max(Function(Entity) Entity.LineNumber.GetValueOrDefault(0)) + 1

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        NewOrderID = 0
                        NewLineNumber = 0

                        For Each ImportOrder In ImportOrderDistinctList.Where(Function(Order) Order.MediaType <> "R" AndAlso Order.MediaType <> "T")

                            'If NewOrderID = 0 Then

                            NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                            'Else

                            '	NewOrderID += 1

                            'End If

                            NewLineNumber = 0

                            For Each IAP In NewImportOrders

                                If IAP.MediaType = ImportOrder.MediaType AndAlso IAP.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                        IAP.ClientCode = ImportOrder.ClientCode AndAlso IAP.DivisionCode = ImportOrder.DivisionCode AndAlso
                                        IAP.ProductCode = ImportOrder.ProductCode AndAlso IAP.VendorCode = ImportOrder.VendorCode AndAlso
                                        IAP.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso
                                        IAP.CampaignCode = ImportOrder.CampaignCode Then

                                    If IAP.OrderID.GetValueOrDefault(0) = 0 Then

                                        IAP.OrderID = NewOrderID

                                        NewLineNumber += 1

                                        IAP.LineNumber = NewLineNumber

                                    Else

                                        If IAP.LineNumber.GetValueOrDefault(0) = 0 Then

                                            If ImportOrderList.Any(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = IAP.OrderID) Then

                                                IAP.LineNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = IAP.OrderID).Max(Function(Entity) Entity.LineNumber.GetValueOrDefault(0)) + 1

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        Assigned = True

                    Else

                        Assigned = False

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter Sales Class Code for all rows.", WinForm.MessageBox.MessageBoxButtons.OK)

                    End If

                Catch ex As Exception

                End Try

            ElseIf CreateOrderOption = AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.AddToOrder Then

                Try

                    NewImportOrders = ImportOrderList.Where(Function(O) O.IsRevision = False).ToList

                    If NewImportOrders.Any(Function(O) O.SalesClassCode Is Nothing OrElse O.SalesClassCode = "") = False Then

                        ImportOrderDistinctList = (From Entity In NewImportOrders
                                                   Group By MediaType = Entity.MediaType,
                                                            SalesClassCode = Entity.SalesClassCode,
                                                            ClientCode = Entity.ClientCode,
                                                            DivisionCode = Entity.DivisionCode,
                                                            ProductCode = Entity.ProductCode,
                                                            VendorCode = Entity.VendorCode,
                                                            MediaPlanMarketCode = Entity.MediaPlanMarketCode,
                                                            CampaignCode = Entity.CampaignCode,
                                                            ImportSource = Entity.ImportSource Into MediaTypeGroup = Group
                                                   Select New AdvantageFramework.Media.Classes.ImportOrder With {.MediaType = MediaType,
                                                                                                                 .SalesClassCode = SalesClassCode,
                                                                                                                 .ClientCode = ClientCode,
                                                                                                                 .DivisionCode = DivisionCode,
                                                                                                                 .ProductCode = ProductCode,
                                                                                                                 .VendorCode = VendorCode,
                                                                                                                 .MediaPlanMarketCode = MediaPlanMarketCode,
                                                                                                                 .CampaignCode = CampaignCode,
                                                                                                                 .ImportSource = ImportSource}).ToList

                        For Each ImportOrder In ImportOrderDistinctList.Where(Function(Order) Order.MediaType = "R" OrElse Order.MediaType = "T")

                            If ImportOrderList.Any(Function(Entity) Entity.MediaType = ImportOrder.MediaType AndAlso Entity.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                                                    Entity.ClientCode = ImportOrder.ClientCode AndAlso Entity.DivisionCode = ImportOrder.DivisionCode AndAlso
                                                                    Entity.ProductCode = ImportOrder.ProductCode AndAlso Entity.VendorCode = ImportOrder.VendorCode AndAlso
                                                                    Entity.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso Entity.CampaignCode = ImportOrder.CampaignCode AndAlso
                                                                    Entity.OrderID.GetValueOrDefault(0) > 0) Then

                                OrderID = ImportOrderList.Where(Function(Entity) Entity.MediaType = ImportOrder.MediaType AndAlso Entity.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                                                                 Entity.ClientCode = ImportOrder.ClientCode AndAlso Entity.DivisionCode = ImportOrder.DivisionCode AndAlso
                                                                                 Entity.ProductCode = ImportOrder.ProductCode AndAlso Entity.VendorCode = ImportOrder.VendorCode AndAlso
                                                                                 Entity.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso Entity.CampaignCode = ImportOrder.CampaignCode AndAlso
                                                                                 Entity.OrderID.GetValueOrDefault(0) > 0).FirstOrDefault.OrderID

                            Else

                                'If NewOrderID = 0 Then

                                NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                                'Else

                                '	NewOrderID += 1

                                'End If

                                OrderID = NewOrderID

                            End If

                            If ImportOrderList.Any(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = OrderID) Then

                                NewLineNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = OrderID).Max(Function(Entity) Entity.LineNumber)

                            Else

                                NewLineNumber = 0

                            End If

                            For Each IAP In NewImportOrders

                                If IAP.MediaType = ImportOrder.MediaType AndAlso IAP.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                        IAP.ClientCode = ImportOrder.ClientCode AndAlso IAP.DivisionCode = ImportOrder.DivisionCode AndAlso
                                        IAP.ProductCode = ImportOrder.ProductCode AndAlso IAP.VendorCode = ImportOrder.VendorCode AndAlso
                                        IAP.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso
                                        IAP.CampaignCode = ImportOrder.CampaignCode Then

                                    IAP.OrderID = OrderID

                                    NewLineNumber += 1

                                    IAP.LineNumber = NewLineNumber

                                End If

                            Next

                        Next

                        OrderID = 0
                        NewOrderID = 0
                        NewLineNumber = 0

                        For Each ImportOrder In ImportOrderDistinctList.Where(Function(Order) Order.MediaType <> "R" AndAlso Order.MediaType <> "T")

                            If ImportOrderList.Any(Function(Entity) Entity.MediaType = ImportOrder.MediaType AndAlso Entity.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                                                    Entity.ClientCode = ImportOrder.ClientCode AndAlso Entity.DivisionCode = ImportOrder.DivisionCode AndAlso
                                                                    Entity.ProductCode = ImportOrder.ProductCode AndAlso Entity.VendorCode = ImportOrder.VendorCode AndAlso
                                                                    Entity.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso Entity.CampaignCode = ImportOrder.CampaignCode AndAlso
                                                                    Entity.OrderID.GetValueOrDefault(0) > 0) Then

                                OrderID = ImportOrderList.Where(Function(Entity) Entity.MediaType = ImportOrder.MediaType AndAlso Entity.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                                                                 Entity.ClientCode = ImportOrder.ClientCode AndAlso Entity.DivisionCode = ImportOrder.DivisionCode AndAlso
                                                                                 Entity.ProductCode = ImportOrder.ProductCode AndAlso Entity.VendorCode = ImportOrder.VendorCode AndAlso
                                                                                 Entity.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso Entity.CampaignCode = ImportOrder.CampaignCode AndAlso
                                                                                 Entity.OrderID.GetValueOrDefault(0) > 0).FirstOrDefault.OrderID

                            Else

                                'If NewOrderID = 0 Then

                                NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                                'Else

                                '	NewOrderID += 1

                                'End If

                                OrderID = NewOrderID

                            End If

                            If ImportOrderList.Any(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = OrderID) Then

                                NewLineNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.GetValueOrDefault(0) = OrderID).Max(Function(Entity) Entity.LineNumber)

                            Else

                                NewLineNumber = 0

                            End If

                            For Each IAP In NewImportOrders

                                If IAP.MediaType = ImportOrder.MediaType AndAlso IAP.SalesClassCode = ImportOrder.SalesClassCode AndAlso
                                        IAP.ClientCode = ImportOrder.ClientCode AndAlso IAP.DivisionCode = ImportOrder.DivisionCode AndAlso
                                        IAP.ProductCode = ImportOrder.ProductCode AndAlso IAP.VendorCode = ImportOrder.VendorCode AndAlso
                                        IAP.MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode AndAlso
                                        IAP.CampaignCode = ImportOrder.CampaignCode Then

                                    IAP.OrderID = OrderID

                                    NewLineNumber += 1

                                    IAP.LineNumber = NewLineNumber

                                End If

                            Next

                        Next

                        Assigned = True

                    Else

                        Assigned = False

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter Sales Class Code for all rows.", WinForm.MessageBox.MessageBoxButtons.OK)

                    End If

                Catch ex As Exception

                End Try

            ElseIf CreateOrderOption = AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.NewOrderLineForEveryPeriod Then

                Try

                    NewImportOrders = ImportOrderList.Where(Function(O) O.IsRevision = False).ToList

                    If NewImportOrders.Any(Function(O) O.SalesClassCode Is Nothing OrElse O.SalesClassCode = "") = False Then

                        For Each ImportOrder In NewImportOrders.Where(Function(Order) Order.MediaType = "R" OrElse Order.MediaType = "T")

                            'If NewOrderID = 0 Then

                            NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                            'Else

                            '	NewOrderID += 1

                            'End If

                            NewLineNumber = 1

                            ImportOrder.OrderID = NewOrderID
                            ImportOrder.LineNumber = NewLineNumber

                        Next

                        NewOrderID = 0
                        NewLineNumber = 0

                        For Each ImportOrder In NewImportOrders.Where(Function(Order) Order.MediaType <> "R" AndAlso Order.MediaType <> "T")

                            'If NewOrderID = 0 Then

                            NewOrderID = GetNextOrderID(DbContext, ImportOrder.ImportSource)

                            'Else

                            '	NewOrderID += 1

                            'End If

                            NewLineNumber = 1

                            ImportOrder.OrderID = NewOrderID
                            ImportOrder.LineNumber = NewLineNumber

                        Next

                        Assigned = True

                    Else

                        Assigned = False

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter Sales Class Code for all rows.", WinForm.MessageBox.MessageBoxButtons.OK)

                    End If

                Catch ex As Exception

                End Try

            End If

            AssignOrderID = Assigned

        End Function
        Private Function GetNextOrderID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportSource As AdvantageFramework.Media.ImportSource) As Integer

            Dim OrderID As Integer = 0
            Dim ImportedFrom As String = Nothing

            ImportedFrom = GetImportedFrom(ImportSource)

            OrderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_get_next_media_import_order_id] '{0}'", ImportedFrom)).SingleOrDefault

            GetNextOrderID = OrderID

        End Function
        'Private Function GetBroadcastOrderID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportSource As AdvantageFramework.Media.ImportSource) As Integer

        '    Dim OrderID As Integer = 0
        '    Dim BroadcastOrderID As Integer = 0
        '    Dim ImportedFrom As String = Nothing

        '    ImportedFrom = GetImportedFrom(ImportSource)

        '    Try

        '        OrderID = CInt((From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext) _
        '                        Where Entity.ImportedFrom = ImportedFrom _
        '                        Select Entity.ImportOrderNumber).Max + 1)

        '    Catch ex As Exception
        '        OrderID = 1
        '    End Try

        '    Try

        '        BroadcastOrderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(LINK_ID) FROM dbo.BRDCAST_IMPORT WHERE MEDIA_INTERFACE = '{0}'", ImportedFrom)).FirstOrDefault + 1

        '    Catch ex As Exception
        '        BroadcastOrderID = 1
        '    End Try

        '    If OrderID > BroadcastOrderID Then

        '        GetBroadcastOrderID = OrderID

        '    Else

        '        GetBroadcastOrderID = BroadcastOrderID

        '    End If

        'End Function
        'Private Function GetPrintOrderID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                 ByVal ImportSource As AdvantageFramework.Media.ImportSource) As Integer

        '    Dim OrderID As Integer = 0
        '    Dim PrintOrderID As Integer = 0
        '    Dim ImportedFrom As String = Nothing

        '    ImportedFrom = GetImportedFrom(ImportSource)

        '    Try

        '        OrderID = CInt((From Entity In AdvantageFramework.Database.Procedures.PrintImportCrossReference.Load(DataContext) _
        '                        Where Entity.ImportedFrom = ImportedFrom _
        '                        Select Entity.ImportOrderNumber).Max + 1)

        '    Catch ex As Exception
        '        OrderID = 1
        '    End Try

        '    Try

        '        PrintOrderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(ACCT_ORD_NBR) FROM dbo.PRINT_ORDER WHERE MEDIA_INTERFACE = '{0}'", ImportedFrom)).FirstOrDefault + 1

        '    Catch ex As Exception
        '        PrintOrderID = 1
        '    End Try

        '    If OrderID > PrintOrderID Then

        '        GetPrintOrderID = OrderID

        '    Else

        '        GetPrintOrderID = PrintOrderID

        '    End If

        'End Function
        Private Function FormatFileName(ByVal OutputPath As String, ByVal FileName As String) As String

            If String.IsNullOrEmpty(OutputPath) = False Then

                FormatFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(OutputPath, "\") & FileName

            Else

                FormatFileName = FileName

            End If

        End Function
        Private Function GetImportedFrom(ByVal ImportSource As AdvantageFramework.Media.ImportSource) As String

            Dim ImportedFrom As String = Nothing

            If ImportSource = ImportSource.Default Then

                ImportedFrom = "AP"

            ElseIf ImportSource = ImportSource.MediaPlanning Then

                ImportedFrom = "AM"

            ElseIf ImportSource = ImportSource.AuthorizationToBuy Then

                ImportedFrom = "AB"

            ElseIf ImportSource = ImportSource.BroadcastWorksheet Then

                ImportedFrom = "AW"

            End If

            GetImportedFrom = ImportedFrom

        End Function
        Private Function GetSourceCode(ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim SourceCode As String = Nothing
            Dim ImportedFrom As String = Nothing
            Dim BroadcastImportCrossReference As AdvantageFramework.Database.Entities.BroadcastImportCrossReference = Nothing
            Dim PrintImportCrossReference As AdvantageFramework.Database.Entities.PrintImportCrossReference = Nothing

            If ImportOrder.IsRevision Then

                ImportedFrom = GetImportedFrom(ImportOrder.ImportSource)

                SourceCode = ImportedFrom

                If ImportOrder.MediaType = "R" OrElse ImportOrder.MediaType = "T" Then

                    If ImportOrder.OrderID.HasValue AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.OrderNumber.HasValue AndAlso ImportOrder.OrderLineNumber.HasValue Then

                        BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber(DbContext, ImportOrder.OrderID, ImportOrder.LineNumber, ImportOrder.OrderNumber, ImportOrder.OrderLineNumber)

                        If BroadcastImportCrossReference IsNot Nothing Then

                            SourceCode = BroadcastImportCrossReference.ImportedFrom

                        End If

                    End If

                Else

                    If ImportOrder.OrderID.HasValue AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.OrderNumber.HasValue AndAlso ImportOrder.OrderLineNumber.HasValue Then

                        PrintImportCrossReference = AdvantageFramework.Database.Procedures.PrintImportCrossReference.LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber(DataContext, ImportOrder.OrderID, ImportOrder.LineNumber, ImportOrder.OrderNumber, ImportOrder.OrderLineNumber)

                        If PrintImportCrossReference IsNot Nothing Then

                            SourceCode = PrintImportCrossReference.ImportedFrom

                        End If

                    End If

                End If

            ElseIf ImportOrder.ImportSource = ImportSource.Default Then

                SourceCode = "AP"

            ElseIf ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                SourceCode = "AM"

            ElseIf ImportOrder.ImportSource = ImportSource.AuthorizationToBuy Then

                SourceCode = "AB"

            ElseIf ImportOrder.ImportSource = ImportSource.BroadcastWorksheet Then

                SourceCode = "AW"

            End If

            GetSourceCode = SourceCode

        End Function
        Private Sub CreateBroadcastLine(ByRef StringBuilderLine As System.Text.StringBuilder,
                                        ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                        ByVal DataContext As AdvantageFramework.Database.DataContext)

            Dim CommissionPercent As Decimal = 0

            StringBuilderLine.Append(ImportOrder.OrderID & ",")
            StringBuilderLine.Append(ImportOrder.RevNbr & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaType) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.SalesClassCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ClientCode) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(FormatData(ImportOrder.DivisionCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ProductCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.VendorCode) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketCode) & "," & FormatData(ImportOrder.MediaPlanMarketDescription) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.CampaignCode) & ",")
            StringBuilderLine.Append(If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(If(ImportOrder.EndDate.HasValue, ImportOrder.EndDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, "N", "G") & ",")

            If ImportOrder.GrossRate.GetValueOrDefault(0) = 0 Then

                CommissionPercent = 15

            Else

                CommissionPercent = FormatNumber(100 * (1 - (ImportOrder.NetRate.GetValueOrDefault(0) / ImportOrder.GrossRate.GetValueOrDefault(0))), 2)

            End If

            StringBuilderLine.Append(FormatData(FormatNumber(CommissionPercent, 2)) & ",") 'COMMISSION PERCENT

            If ShowOrderDescription Then

                If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                    StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

                Else

                    StringBuilderLine.Append(FormatData(OrderDescription.Trim) & ",")

                End If

            Else

                StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

            End If

            StringBuilderLine.Append(",") ' BUYER
            StringBuilderLine.Append(FormatData(ImportOrder.ClientPO) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderComment) & ",")
            StringBuilderLine.Append(ImportOrder.LineNumber & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetRate, 4)) & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.GrossRate, 4)) & ",")
            StringBuilderLine.Append("0.00,")
            StringBuilderLine.Append(ImportOrder.TotalSpots.ToString.PadLeft(3, " ") & "  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0,")
            StringBuilderLine.Append(ImportOrder.TotalSpots & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobNumber.HasValue, ImportOrder.MediaPlanJobNumber.Value, "") & ",") ' JOB_NUMBER
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobComponentNumber.HasValue, ImportOrder.MediaPlanJobComponentNumber.Value, "") & ",") ' COMPONENT_NUMBER
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanStartTime) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanEndTime) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanLength) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanProgramming) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanMonday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanTuesday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanWednesday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanThursday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanFriday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanSaturday, 1, 0) & ",")
            StringBuilderLine.Append(If(ImportOrder.MediaPlanSunday, 1, 0) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.LineDescription) & ",")
            StringBuilderLine.Append("0,") 'CANCEL_FLAG 44
            StringBuilderLine.Append(If(ImportOrder.MediaPlanAirDate.HasValue, ImportOrder.MediaPlanAirDate.Value.ToShortDateString, "") & ",,") 'AIR_DATE, REBATE_PCT
            StringBuilderLine.Append(",") 'REBATE_AMT

            'MARKUP_PCT
            If ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                StringBuilderLine.Append(",")

            Else

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            End If

            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.AddAmount.GetValueOrDefault(0), 2)) & ",") 'ADDITIONAL_AMT
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetCharge.GetValueOrDefault(0), 2)) & ",") 'OTHER_NET 50
            StringBuilderLine.Append(Chr(34) & If(ImportOrder.MediaPlanDetailLevelLineDataIDs Is Nothing, "", ImportOrder.MediaPlanDetailLevelLineDataIDs) & Chr(34) & ",") 'PLAN_IDS
            StringBuilderLine.Append(",") 'CAL_TYPE
            StringBuilderLine.Append(",") 'MONTH
            StringBuilderLine.Append(",") 'YEAR 54
            StringBuilderLine.Append(",,,,,,") 'WEEK1_START thru WEEK6_START
            StringBuilderLine.Append(",") 'NETWORK_ID 61
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanDaypart) & ",") 'DAYPART_CODE
            StringBuilderLine.Append(",") 'ESTIMATE_NBR
            StringBuilderLine.Append(",") 'PACKAGE_NAME
            StringBuilderLine.Append(GetSourceCode(ImportOrder, DataContext, DbContext)) 'SOURCE_CODE

        End Sub
        Private Sub CreateInternetLine(ByRef StringBuilderLine As System.Text.StringBuilder,
                                       ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                       ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                       ByVal DataContext As AdvantageFramework.Database.DataContext)

            StringBuilderLine.Append(ImportOrder.OrderID & ",") ' ORDER_ID

            If ShowOrderDescription Then ' ORDER_DESC

                If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                    StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

                Else

                    StringBuilderLine.Append(FormatData(OrderDescription.Trim) & ",")

                End If

            Else

                StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

            End If

            StringBuilderLine.Append(FormatData(ImportOrder.VendorCode) & ",") ' VN_CODE
            StringBuilderLine.Append(",") ' VN_NAME
            StringBuilderLine.Append(",") ' BUYER
            StringBuilderLine.Append(FormatData(ImportOrder.ClientCode) & ",") ' CLIENT
            StringBuilderLine.Append(",") ' CL_NAME
            StringBuilderLine.Append(FormatData(ImportOrder.DivisionCode) & ",") ' DIVISION
            StringBuilderLine.Append(FormatData(ImportOrder.ProductCode) & ",") ' PRODUCT
            StringBuilderLine.Append(FormatData(ImportOrder.SalesClassCode) & ",") ' SALES_CLASS
            StringBuilderLine.Append(FormatData(ImportOrder.CampaignCode) & ",") ' CAMPAIGN
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketCode) & ",") ' MARKET
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketDescription) & ",") ' MARKET_DESC
            StringBuilderLine.Append(FormatData(ImportOrder.ClientPO) & ",") ' CLIENT_PO
            StringBuilderLine.Append(",") ' REP_CODE1
            StringBuilderLine.Append(",") ' REP_CODE2
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, "NET", "GROSS") & ",") ' NET_GROSS
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderComment) & ",") ' ORDER_COMMENT
            StringBuilderLine.Append(ImportOrder.LineNumber & ",") ' LINE_NBR
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanHeadline) & ",") ' HEADLINE
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdNumber) & ",") ' AD_NUMBER
            StringBuilderLine.Append(",") ' AD_NBR_DESC
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanURL) & ",") ' URL
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeCode) & ",") ' CREATIVE_SIZE_CODE
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeDescription) & ",") ' CREATIVE_SIZE_DESC
            StringBuilderLine.Append(",") ' COPY
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanTargetAudience) & ",") ' TARGET_AUD
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanPlacement) & ",") ' PLACEMENT
            StringBuilderLine.Append(",") ' PLACEMENT_2
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanInternetType) & ",") ' INTERNET_TYPE_CODE
            StringBuilderLine.Append(FormatData(ImportOrder.LineDescription) & ",") ' LINE_COMMENT
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobNumber.HasValue, ImportOrder.MediaPlanJobNumber.Value, "") & ",") ' JOB_NUMBER
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobComponentNumber.HasValue, ImportOrder.MediaPlanJobComponentNumber.Value, "") & ",") ' COMPONENT_NUMBER
            StringBuilderLine.Append(If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "") & ",") ' START_DATE
            StringBuilderLine.Append(If(ImportOrder.EndDate.HasValue, ImportOrder.EndDate.Value.ToShortDateString, "") & ",") ' END_DATE
            StringBuilderLine.Append(",") ' SPACE_CLOSE
            StringBuilderLine.Append(",") ' MATERIAL_CLOSE
            StringBuilderLine.Append(FormatData(ImportOrder.CostType) & ",") ' COST_TYPE

            If ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then ' RATE

                StringBuilderLine.Append(",")

            Else

                StringBuilderLine.Append(If(ImportOrder.NetGross = 0, FormatData(FormatNumber(ImportOrder.NetRate, 4)), FormatData(FormatNumber(ImportOrder.GrossRate, 4))) & ",")

            End If

            StringBuilderLine.Append(",") ' PROJ_IMPRESSIONS
            StringBuilderLine.Append(If(ImportOrder.TotalSpots IsNot Nothing, ImportOrder.TotalSpots, "") & ",") ' GUAR_IMPRESSIONS

            StringBuilderLine.Append(",") ' ACTUAL_IMPRESSIONS
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.Cost, 2)) & ",") ' COST
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetCharge, 2)) & ",") ' OTHER_NET
            StringBuilderLine.Append("1,") ' REVISE_FLAG
            StringBuilderLine.Append("I,") ' INSERT_STATUS
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.AddAmount, 2)) & ",") ' ADD_AMT

            If ImportOrder.ImportSource = ImportSource.MediaPlanning Then ' MARKUP_PCT

                StringBuilderLine.Append(",")

            ElseIf ImportOrder.ImportSource = ImportSource.AuthorizationToBuy Then

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            Else

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            End If

            StringBuilderLine.Append(",") ' REBATE_PCT
            StringBuilderLine.Append(",") ' REBATE_AMT

            StringBuilderLine.Append(Chr(34) & If(ImportOrder.MediaPlanDetailLevelLineDataIDs Is Nothing, "", ImportOrder.MediaPlanDetailLevelLineDataIDs) & Chr(34) & ",") ' PLAN_IDS
            StringBuilderLine.Append(GetSourceCode(ImportOrder, DataContext, DbContext)) 'SOURCE_CODE

        End Sub
        Private Sub CreateNewspaperLine(ByRef StringBuilderLine As System.Text.StringBuilder,
                                        ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                        ByVal DataContext As AdvantageFramework.Database.DataContext)

            StringBuilderLine.Append(ImportOrder.OrderID & ",")

            If ShowOrderDescription Then

                If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                    StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

                Else

                    StringBuilderLine.Append(FormatData(OrderDescription.Trim) & ",")

                End If

            Else

                StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

            End If

            StringBuilderLine.Append(FormatData(ImportOrder.VendorCode) & ",,")
            StringBuilderLine.Append(",") ' BUYER
            StringBuilderLine.Append(FormatData(ImportOrder.ClientCode) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.DivisionCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ProductCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.SalesClassCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.CampaignCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketCode) & "," & FormatData(ImportOrder.MediaPlanMarketDescription) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ClientPO) & ",")
            StringBuilderLine.Append(",") ' REP_CODE1
            StringBuilderLine.Append(",") ' REP_CODE2
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, "NET", "GROSS") & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderComment) & ",")
            StringBuilderLine.Append(ImportOrder.LineNumber & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanHeadline) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanIssue) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanSection) & ",") ' SECTION
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMaterialNotes) & ",") ' MATERIAL
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeDescription) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdNumber) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.LineDescription) & ",") '29 LINE_COMMENT
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobNumber.HasValue, ImportOrder.MediaPlanJobNumber.Value, "") & ",") ' JOB_NUMBER
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobComponentNumber.HasValue, ImportOrder.MediaPlanJobComponentNumber.Value, "") & ",") ' COMPONENT_NUMBER
            StringBuilderLine.Append(If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(",,,," & If(ImportOrder.TotalSpots IsNot Nothing, ImportOrder.TotalSpots, "") & ",") '37
            StringBuilderLine.Append(FormatData(ImportOrder.RateType) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.CostType) & ",")
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, FormatData(FormatNumber(ImportOrder.NetRate, 4)), FormatData(FormatNumber(ImportOrder.GrossRate, 4))) & ",") '40
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetCharge, 2)) & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.Cost, 2)) & ",")
            StringBuilderLine.Append("1,I,")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.AddAmount, 2)) & ",") 'ADD_AMT

            'MARKUP_PCT
            If ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                StringBuilderLine.Append(",")

            Else

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            End If

            StringBuilderLine.Append(",") 'REBATE_PCT
            StringBuilderLine.Append(",") 'REBATE_AMT
            StringBuilderLine.Append(Chr(34) & If(ImportOrder.MediaPlanDetailLevelLineDataIDs Is Nothing, "", ImportOrder.MediaPlanDetailLevelLineDataIDs) & Chr(34) & ",")
            StringBuilderLine.Append(GetSourceCode(ImportOrder, DataContext, DbContext)) 'SOURCE_CODE

        End Sub
        Private Sub CreateMagazineLine(ByRef StringBuilderLine As System.Text.StringBuilder,
                                       ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                       ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                       ByVal DataContext As AdvantageFramework.Database.DataContext)

            StringBuilderLine.Append(ImportOrder.OrderID & ",")

            If ShowOrderDescription Then

                If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                    StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

                Else

                    StringBuilderLine.Append(FormatData(OrderDescription.Trim) & ",")

                End If

            Else

                StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

            End If

            StringBuilderLine.Append(FormatData(ImportOrder.VendorCode) & ",,")
            StringBuilderLine.Append(",") ' BUYER
            StringBuilderLine.Append(FormatData(ImportOrder.ClientCode) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.DivisionCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ProductCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.SalesClassCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.CampaignCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketCode) & "," & FormatData(ImportOrder.MediaPlanMarketDescription) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ClientPO) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, "NET", "GROSS") & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderComment) & ",")
            StringBuilderLine.Append(ImportOrder.LineNumber & ",") ' LINE_NUMBER
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanHeadline) & ",") ' HEADLINE
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanIssue) & ",") ' ISSUE
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMaterialNotes) & ",") ' MATERIAL
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeDescription) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdNumber) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.LineDescription) & ",") '27 LINE_COMMENT
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobNumber.HasValue, ImportOrder.MediaPlanJobNumber.Value, "") & ",") ' JOB_NUMBER
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobComponentNumber.HasValue, ImportOrder.MediaPlanJobComponentNumber.Value, "") & ",") ' COMPONENT_NUMBER
            StringBuilderLine.Append(If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(",,")
            'StringBuilderLine.Append(If(ImportOrder.NetGross = 0, FormatData(FormatNumber(ImportOrder.NetRate, 4)), FormatData(FormatNumber(ImportOrder.GrossRate, 4))) & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MediaNetAmount, 4)) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetCharge, 2)) & ",")
            StringBuilderLine.Append("1,I,")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.AddAmount, 2)) & ",") 'ADD_AMT

            'MARKUP_PCT
            If ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                StringBuilderLine.Append(",")

            Else

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            End If

            StringBuilderLine.Append(",") 'REBATE_PCT
            StringBuilderLine.Append(",") 'REBATE_AMT
            StringBuilderLine.Append(Chr(34) & If(ImportOrder.MediaPlanDetailLevelLineDataIDs Is Nothing, "", ImportOrder.MediaPlanDetailLevelLineDataIDs) & Chr(34) & ",")
            StringBuilderLine.Append(GetSourceCode(ImportOrder, DataContext, DbContext)) 'SOURCE_CODE

        End Sub
        Private Sub CreateOutOfHomeLine(ByRef StringBuilderLine As System.Text.StringBuilder,
                                        ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                        ByVal DataContext As AdvantageFramework.Database.DataContext)

            StringBuilderLine.Append(ImportOrder.OrderID & ",")

            If ShowOrderDescription Then

                If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                    StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

                Else

                    StringBuilderLine.Append(FormatData(OrderDescription.Trim) & ",")

                End If

            Else

                StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderDescription) & ",")

            End If

            StringBuilderLine.Append(FormatData(ImportOrder.VendorCode) & ",,")
            StringBuilderLine.Append(",") ' BUYER
            StringBuilderLine.Append(FormatData(ImportOrder.ClientCode) & ",,")
            StringBuilderLine.Append(FormatData(ImportOrder.DivisionCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ProductCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.SalesClassCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.CampaignCode) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanMarketCode) & "," & FormatData(ImportOrder.MediaPlanMarketDescription) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.ClientPO) & ",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(",")
            StringBuilderLine.Append(If(ImportOrder.NetGross = 0, "NET", "GROSS") & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOrderComment) & ",")
            StringBuilderLine.Append(ImportOrder.LineNumber & ",") ' LINE_NUMBER
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanHeadline) & ",") ' HEADLINE
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanLocation) & ",") ' LOCATION
            StringBuilderLine.Append(",") ' COPY_AREA
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdNumber) & ",") ' AD_NUMBER
            StringBuilderLine.Append(",") ' AD_NBR_DESC
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanOutOfHomeType) & ",")
            StringBuilderLine.Append(FormatData(ImportOrder.LineDescription) & ",") '26 LINE_COMMENT
            StringBuilderLine.Append(FormatData(ImportOrder.MediaPlanAdSizeCode) & ",") ' SIZE_CODE
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobNumber.HasValue, ImportOrder.MediaPlanJobNumber.Value, "") & ",") ' JOB_NUMBER
            StringBuilderLine.Append(If(ImportOrder.MediaPlanJobComponentNumber.HasValue, ImportOrder.MediaPlanJobComponentNumber.Value, "") & ",") ' COMPONENT_NUMBER
            StringBuilderLine.Append(If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(If(ImportOrder.EndDate.HasValue, ImportOrder.EndDate.Value.ToShortDateString, "") & ",")
            StringBuilderLine.Append(",,")
            'StringBuilderLine.Append(If(ImportOrder.NetGross = 0, FormatData(FormatNumber(ImportOrder.NetRate, 4)), FormatData(FormatNumber(ImportOrder.GrossRate, 4))) & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MediaNetAmount, 4)) & ",")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.NetCharge, 2)) & ",")
            StringBuilderLine.Append("1,I,")
            StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.AddAmount, 2)) & ",") 'ADD_AMT

            'MARKUP_PCT
            If ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                StringBuilderLine.Append(",")

            Else

                StringBuilderLine.Append(FormatData(FormatNumber(ImportOrder.MarkupPercent, 3)) & ",")

            End If

            StringBuilderLine.Append(",") 'REBATE_PCT
            StringBuilderLine.Append(",") 'REBATE_AMT
            StringBuilderLine.Append(Chr(34) & If(ImportOrder.MediaPlanDetailLevelLineDataIDs Is Nothing, "", ImportOrder.MediaPlanDetailLevelLineDataIDs) & Chr(34) & ",")
            StringBuilderLine.Append(GetSourceCode(ImportOrder, DataContext, DbContext)) 'SOURCE_CODE

        End Sub
        Private Function FormatData(ByVal Data As Object) As String

            Dim FormattedData As String = Nothing

            FormattedData = ""

            If Data Is Nothing Then

                FormattedData = ""

            ElseIf Data.Contains(",") Then 'OrElse Data.Contains("""") Then

                FormattedData = Data.Replace(",", "")

            Else

                FormattedData = Data

            End If

            FormatData = FormattedData

        End Function
        Public Function IsMediaOrderColumnVisible(ByVal FieldName As String, ByVal ShowOrderDescription As Boolean, ByVal ImportSource As AdvantageFramework.Media.ImportSource) As Boolean

            'objects
            Dim ColumnVisible As Boolean = False

            Select Case ImportSource

                Case Methods.ImportSource.Default

                    ColumnVisible = IsMediaOrderColumnVisible_Default(FieldName, ShowOrderDescription)

                Case Methods.ImportSource.MediaPlanning

                    ColumnVisible = IsMediaOrderColumnVisible_MediaPlanning(FieldName, ShowOrderDescription)

                Case Methods.ImportSource.AuthorizationToBuy

                    ColumnVisible = IsMediaOrderColumnVisible_AuthorizationToBuy(FieldName)

                Case Methods.ImportSource.BroadcastWorksheet

                    ColumnVisible = IsMediaOrderColumnVisible_BroadcastWorksheet(FieldName, ShowOrderDescription)

            End Select

            IsMediaOrderColumnVisible = ColumnVisible

        End Function
        Public Function DirectPostImportOrders(DbContext As AdvantageFramework.Database.DbContext,
                                               DataContext As AdvantageFramework.Database.DataContext,
                                               CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                               ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
                                               ShowDescription As Boolean, OrderDescription As String) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                If ImportOrderList IsNot Nothing AndAlso ImportOrderList.Count > 0 Then

                    Created = True

                    AssignOrderIDForDirectPost(DbContext, DataContext, CreateOrderOption, ImportOrderList)

                    For Each ImportOrder In ImportOrderList

                        If DirectPostImportOrder(DbContext, DataContext, ImportOrder, ShowDescription, OrderDescription) = False Then

                            Created = False

                        End If

                    Next

                End If

            Catch ex As Exception
                Created = False
            Finally
                DirectPostImportOrders = Created
            End Try

        End Function
        Public Function DirectPostImportOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                              ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                              ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                              Optional ByRef RevisionNumber As Integer = -1) As Boolean

            'objects
            Dim Posted As Boolean = False

            Select Case ImportOrder.MediaType

                Case "I", "M", "N", "O"

                    Posted = DirectPostPrintOrder(DbContext, DataContext, ImportOrder, ShowOrderDescription, OrderDescription, RevisionNumber)

                Case Else

                    Posted = False

            End Select

            DirectPostImportOrder = Posted

        End Function
        Private Function DirectPostPrintOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal DataContext As AdvantageFramework.Database.DataContext,
                                             ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                             ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                             Optional ByRef RevisionNumber As Integer = -1) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim PrintOrder As AdvantageFramework.Database.Entities.PrintOrder = Nothing

            Try

                PrintOrder = New AdvantageFramework.Database.Entities.PrintOrder

                With PrintOrder

                    .AccountOrderNumber = ImportOrder.OrderID
                    .MediaType = ImportOrder.MediaType

                    If ShowOrderDescription Then

                        If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                            .OrderDescription = ImportOrder.MediaPlanOrderDescription

                        Else

                            .OrderDescription = OrderDescription

                        End If

                    Else

                        .OrderDescription = ImportOrder.MediaPlanOrderDescription

                    End If

                    .UserCode = DbContext.UserCode
                    .Trade = Nothing
                    .AdvertiserName = Nothing
                    .CampaignDescription = Nothing
                    .VendorName = Nothing
                    .AdSize = Nothing
                    .PreviousRatePer = Nothing
                    .Caption = Nothing
                    .POSRequest = Nothing
                    .MaterialCloseDate = Nothing
                    .SpaceCloseDate = Nothing
                    .OrderComment = Nothing
                    .InterfaceSequenceNumber = Nothing
                    .ImportYear = Nothing
                    .FlatDiscountAmount = Nothing
                    .JobNumber = ImportOrder.MediaPlanJobNumber
                    .JobComponentNumber = ImportOrder.MediaPlanJobComponentNumber
                    .VendorRepresentativeCode = Nothing
                    .VendorRepresentativeCode2 = Nothing
                    .Buyer = Nothing
                    .SizeCode = Nothing
                    .AdNumber = Nothing
                    .InternetType = Nothing
                    .ProductionSize = Nothing
                    .Material = Nothing
                    .RateType = Nothing
                    .OutdoorType = Nothing
                    .PrintColumns = Nothing
                    .PrintInches = Nothing
                    .PrintLines = Nothing
                    .NetBaseRate = Nothing
                    .GrossBaseRate = Nothing
                    .NetRate = Nothing
                    .GrossRate = Nothing

                    .EstimateNumber = ImportOrder.OrderID
                    .VendorCode = GetVendorCode(DbContext, ImportOrder.VendorCode, .MediaType)
                    .VenderCodeCrossRefrence = ImportOrder.VendorCode

                    If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanBuyer) = False Then

                        .Buyer = ImportOrder.MediaPlanBuyer
                        .BuyerEmployeeCode = ImportOrder.MediaPlanBuyer
                        .BuyerName = GetEmployeeName(DbContext, ImportOrder.MediaPlanBuyer)

                    End If

                    .AdvertiserCode = ImportOrder.ClientCode
                    .BrandCode = ImportOrder.DivisionCode
                    .ProductCode = ImportOrder.ProductCode
                    .SalesClassCode = ImportOrder.SalesClassCode
                    .CampaignCode = ImportOrder.CampaignCode
                    .ClientPO = ImportOrder.ClientPO

                    If ImportOrder.NetGross = 0 Then ' net

                        .AgencyNetRate = 1

                    Else ' gross

                        .AgencyNetRate = 0.85

                    End If

                    .ItemNumber = AdvantageFramework.StringUtilities.PadWithCharacter(ImportOrder.LineNumber.ToString, 4, "0", True)
                    .InsertDate = If(ImportOrder.StartDate.HasValue, ImportOrder.StartDate.Value.ToShortDateString, "")
                    .EndDate = If(ImportOrder.EndDate.HasValue, ImportOrder.EndDate.Value.ToShortDateString, "")
                    .CostType = ImportOrder.CostType
                    .RatePer = ImportOrder.Cost
                    .RevisedFlag = 1
                    .PostFlag = 0
                    .InsertStatus = "I"
                    .MarkupPercent = ImportOrder.MarkupPercent
                    .PlanIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs
                    .MediaInterface = GetSourceCode(ImportOrder, DataContext, DbContext)

                    If RevisionNumber < 0 Then

                        RevisionNumber = GetNextRevisisionNumber(DataContext, .MediaInterface)

                    End If

                    .RevisionNumber = RevisionNumber
                    .FlatNetCharge = ImportOrder.NetCharge
                    .FlatAdditionalCharge = ImportOrder.AddAmount
                    .LineMarketCode = ImportOrder.MediaPlanOrderLineMarketCode

                    If ImportOrder.MediaType = "I" Then

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanHeadline) = False AndAlso ImportOrder.MediaPlanHeadline.Length > 60 Then

                            .Caption = ImportOrder.MediaPlanHeadline.Substring(0, 60)

                        Else

                            .Caption = ImportOrder.MediaPlanHeadline

                        End If

                        .OrderComment = ImportOrder.MediaPlanOrderComment
                        .SectionIssue = Nothing

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanPlacement) = False AndAlso ImportOrder.MediaPlanPlacement.Length > 254 Then

                            .Location = ImportOrder.MediaPlanPlacement.Substring(0, 254)

                        Else

                            .Location = ImportOrder.MediaPlanPlacement

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.LineDescription) = False AndAlso ImportOrder.LineDescription.Length > 254 Then

                            .LineComment = ImportOrder.LineDescription.Substring(0, 254)

                        Else

                            .LineComment = ImportOrder.LineDescription

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanTargetAudience) = False AndAlso ImportOrder.MediaPlanTargetAudience.Length > 60 Then

                            .Zone = ImportOrder.MediaPlanTargetAudience.Substring(0, 60)

                        Else

                            .Zone = ImportOrder.MediaPlanTargetAudience

                        End If

                        If ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                            .GuaranteedImpressions = ImportOrder.TotalSpots
                            .CostRate = 0

                        Else

                            .GuaranteedImpressions = ImportOrder.TotalSpots

                            If ImportOrder.NetGross = 0 Then ' net

                                .CostRate = ImportOrder.NetRate

                            Else ' gross

                                .CostRate = ImportOrder.GrossRate

                            End If

                        End If

                        .DeleteOrder = Nothing
                        .MarketCode = ImportOrder.MediaPlanMarketCode
                        .MarketDescription = ImportOrder.MediaPlanMarketDescription
                        .SizeCode = ImportOrder.MediaPlanAdSizeCode
                        .AdNumber = ImportOrder.MediaPlanAdNumber

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanAdSizeDescription) = False AndAlso ImportOrder.MediaPlanAdSizeDescription.Length > 60 Then

                            .CreativeSize = ImportOrder.MediaPlanAdSizeDescription.Substring(0, 60)

                        Else

                            .CreativeSize = ImportOrder.MediaPlanAdSizeDescription

                        End If

                        .InternetType = ImportOrder.MediaPlanInternetType

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanURL) = False AndAlso ImportOrder.MediaPlanURL.Length > 60 Then

                            .URL = ImportOrder.MediaPlanURL.Substring(0, 60)

                        Else

                            .URL = ImportOrder.MediaPlanURL

                        End If

                        .MaterialNotes = ImportOrder.MediaPlanMaterialNotes
                        .MiscInfo = ImportOrder.MediaPlanMiscInfo
                        .OrderCopy = ImportOrder.MediaPlanOrderCopy
                        .Units = "M"
                        .MediaChannelID = ImportOrder.MediaPlanMediaChannelID
                        .MediaTacticID = ImportOrder.MediaPlanMediaTacticID

                    ElseIf ImportOrder.MediaType = "O" Then

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanHeadline) = False AndAlso ImportOrder.MediaPlanHeadline.Length > 60 Then

                            .Caption = ImportOrder.MediaPlanHeadline.Substring(0, 60)

                        Else

                            .Caption = ImportOrder.MediaPlanHeadline

                        End If

                        .OrderComment = ImportOrder.MediaPlanOrderComment

                        If String.IsNullOrWhiteSpace(ImportOrder.LineDescription) = False AndAlso ImportOrder.LineDescription.Length > 254 Then

                            .LineComment = ImportOrder.LineDescription.Substring(0, 254)

                        Else

                            .LineComment = ImportOrder.LineDescription

                        End If

                        .SectionIssue = Nothing
                        .Zone = Nothing
                        .DeleteOrder = Nothing
                        .MarketCode = ImportOrder.MediaPlanMarketCode
                        .MarketDescription = ImportOrder.MediaPlanMarketDescription
                        .SizeCode = ImportOrder.MediaPlanAdSizeCode
                        .AdNumber = ImportOrder.MediaPlanAdNumber
                        .URL = Nothing
                        .CreativeSize = Nothing
                        .Placement2 = Nothing
                        .ProjectedImpressions = Nothing
                        .GuaranteedImpressions = ImportOrder.MediaPlanImpressions
                        .ActiveImpressions = Nothing
                        .CostRate = Nothing
                        .OutdoorType = ImportOrder.MediaPlanOutOfHomeType

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanLocation) = False AndAlso ImportOrder.MediaPlanLocation.Length > 254 Then

                            .Location = ImportOrder.MediaPlanLocation.Substring(0, 254)

                        Else

                            .Location = ImportOrder.MediaPlanLocation

                        End If

                        .MaterialNotes = ImportOrder.MediaPlanMaterialNotes
                        .MiscInfo = ImportOrder.MediaPlanMiscInfo
                        .OrderCopy = ImportOrder.MediaPlanOrderCopy
                        .Units = "M"

                    ElseIf ImportOrder.MediaType = "N" Then

                        .AdSize = ImportOrder.MediaPlanAdSizeDescription

                        If ImportOrder.NetGross = 0 Then ' net

                            .RatePer = ImportOrder.NetRate

                        Else ' gross

                            .RatePer = ImportOrder.GrossRate

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanHeadline) = False AndAlso ImportOrder.MediaPlanHeadline.Length > 60 Then

                            .Caption = ImportOrder.MediaPlanHeadline.Substring(0, 60)

                        Else

                            .Caption = ImportOrder.MediaPlanHeadline

                        End If

                        .OrderComment = ImportOrder.MediaPlanOrderComment

                        If String.IsNullOrWhiteSpace(ImportOrder.LineDescription) = False AndAlso ImportOrder.LineDescription.Length > 254 Then

                            .LineComment = ImportOrder.LineDescription.Substring(0, 254)

                        Else

                            .LineComment = ImportOrder.LineDescription

                        End If


                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanIssue) = False AndAlso ImportOrder.MediaPlanIssue.Length > 60 Then

                            .Zone = ImportOrder.MediaPlanIssue.Substring(0, 60)

                        Else

                            .Zone = ImportOrder.MediaPlanIssue

                        End If

                        .Location = Nothing
                        .DeleteOrder = Nothing
                        .MarketCode = ImportOrder.MediaPlanMarketCode
                        .MarketDescription = ImportOrder.MediaPlanMarketDescription
                        .EndDate = Nothing
                        .SizeCode = ImportOrder.MediaPlanAdSizeCode
                        .AdNumber = ImportOrder.MediaPlanAdNumber
                        .URL = Nothing
                        .CreativeSize = Nothing
                        .Placement2 = Nothing
                        .ProjectedImpressions = Nothing
                        .GuaranteedImpressions = Nothing
                        .ActiveImpressions = Nothing
                        .CostRate = ImportOrder.Cost
                        .RateType = ImportOrder.RateType

                        If ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPI.ToString Then

                            .PrintColumns = ImportOrder.MediaPlanColumns
                            .PrintInches = ImportOrder.MediaPlanInches
                            .PrintLines = 0

                        ElseIf ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPL.ToString Then

                            .PrintColumns = 0
                            .PrintInches = 0
                            .PrintLines = ImportOrder.TotalSpots

                        Else

                            .PrintColumns = 0
                            .PrintInches = 0
                            .PrintLines = ImportOrder.TotalSpots

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanSection) = False AndAlso ImportOrder.MediaPlanSection.Length > 50 Then

                            .SectionIssue = ImportOrder.MediaPlanSection.Substring(0, 50)

                        Else

                            .SectionIssue = ImportOrder.MediaPlanSection

                        End If

                        .Material = ImportOrder.MediaPlanMaterial
                        .OrderCopy = ImportOrder.MediaPlanOrderCopy
                        .MaterialNotes = ImportOrder.MediaPlanMaterialNotes
                        .PositionInfo = ImportOrder.MediaPlanPositionInfo
                        .CloseInfo = ImportOrder.MediaPlanCloseInfo
                        .RateInfo = ImportOrder.MediaPlanRateInfo
                        .MiscInfo = ImportOrder.MediaPlanMiscInfo

                        If ImportOrder.Units = "D" OrElse ImportOrder.Units = "W" Then

                            .Units = "W"

                        Else

                            .Units = "M"

                        End If

                        .Circulation = ImportOrder.MediaPlanCirculation

                    ElseIf ImportOrder.MediaType = "M" Then

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanAdSizeDescription) = False AndAlso ImportOrder.MediaPlanAdSizeDescription.Length > 66 Then

                            .AdSize = ImportOrder.MediaPlanAdSizeDescription.Substring(0, 66)

                        Else

                            .AdSize = ImportOrder.MediaPlanAdSizeDescription

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanHeadline) = False AndAlso ImportOrder.MediaPlanHeadline.Length > 60 Then

                            .Caption = ImportOrder.MediaPlanHeadline.Substring(0, 60)

                        Else

                            .Caption = ImportOrder.MediaPlanHeadline

                        End If

                        .OrderComment = ImportOrder.MediaPlanOrderComment

                        If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanIssue) = False AndAlso ImportOrder.MediaPlanIssue.Length > 50 Then

                            .SectionIssue = ImportOrder.MediaPlanIssue.Substring(0, 50)

                        Else

                            .SectionIssue = ImportOrder.MediaPlanIssue

                        End If

                        If String.IsNullOrWhiteSpace(ImportOrder.LineDescription) = False AndAlso ImportOrder.LineDescription.Length > 254 Then

                            .LineComment = ImportOrder.LineDescription.Substring(0, 254)

                        Else

                            .LineComment = ImportOrder.LineDescription

                        End If

                        .DeleteOrder = Nothing
                        .MarketCode = ImportOrder.MediaPlanMarketCode
                        .MarketDescription = ImportOrder.MediaPlanMarketDescription
                        .EndDate = Nothing
                        .SizeCode = ImportOrder.MediaPlanAdSizeCode
                        .AdNumber = ImportOrder.MediaPlanAdNumber
                        .URL = Nothing
                        .CreativeSize = Nothing
                        .Placement2 = Nothing
                        .ProjectedImpressions = Nothing
                        .GuaranteedImpressions = Nothing
                        .ActiveImpressions = Nothing
                        .CostRate = Nothing
                        .Material = ImportOrder.MediaPlanMaterial
                        .OrderCopy = ImportOrder.MediaPlanOrderCopy
                        .MaterialNotes = ImportOrder.MediaPlanMaterialNotes
                        .PositionInfo = ImportOrder.MediaPlanPositionInfo
                        .CloseInfo = ImportOrder.MediaPlanCloseInfo
                        .RateInfo = ImportOrder.MediaPlanRateInfo
                        .MiscInfo = ImportOrder.MediaPlanMiscInfo
                        .Units = "M"

                        .Circulation = ImportOrder.MediaPlanCirculation

                    End If

                    '.PremiumCharges = .FlatNetCharge
                    .RevisionNumber = GetNextPrintRevisionNumber(DataContext, .MediaInterface, .AccountOrderNumber, .ItemNumber)

                End With

                Created = AdvantageFramework.Database.Procedures.PrintOrder.Insert(DbContext, DataContext, PrintOrder)

            Catch ex As Exception
                Created = False
            Finally
                DirectPostPrintOrder = Created
            End Try

        End Function
        Private Sub AssignOrderIDForDirectPost(DbContext As AdvantageFramework.Database.DbContext,
                                               DataContext As AdvantageFramework.Database.DataContext,
                                               CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                               ByRef ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder))

            'objects
            Dim FilteredImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim AllImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

            FilteredImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)
            AllImportOrders = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            For Each ImportOrder In ImportOrderList

                If ImportOrder.IsRevision = False Then

                    FilteredImportOrderList.Add(ImportOrder)

                Else

                    AllImportOrders.Add(ImportOrder)

                End If

            Next

            If FilteredImportOrderList.Count > 0 Then

                AssignOrderID(DbContext, DataContext, CreateOrderOption, FilteredImportOrderList)

                AllImportOrders.AddRange(FilteredImportOrderList)

            End If

            ImportOrderList = AllImportOrders

        End Sub
        Public Function CheckForCancelledOrderLine(DbContext As AdvantageFramework.Database.DbContext,
                                                   ImportOrder As AdvantageFramework.Media.Classes.ImportOrder) As Boolean

            'objects
            Dim OrderLineIsCancelled As Boolean = False

            If ImportOrder.MediaType = "M" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext).Any(Function(Entity) Entity.MagazineOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                       Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                       Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                       Entity.IsLineCancelled = 1)

            ElseIf ImportOrder.MediaType = "N" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext).Any(Function(Entity) Entity.NewspaperOrderOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                        Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                        Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                        Entity.IsLineCancelled = 1)

            ElseIf ImportOrder.MediaType = "I" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext).Any(Function(Entity) Entity.InternetOrderOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                       Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                       Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                       Entity.IsLineCancelled = 1)

            ElseIf ImportOrder.MediaType = "O" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext).Any(Function(Entity) Entity.OutofHomeOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                        Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                        Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                        Entity.IsLineCancelled = 1)

            ElseIf ImportOrder.MediaType = "R" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext).Any(Function(Entity) Entity.RadioOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                    Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                    Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                    Entity.IsLineCancelled = 1)

            ElseIf ImportOrder.MediaType = "T" Then

                OrderLineIsCancelled = AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext).Any(Function(Entity) Entity.TVOrderNumber = ImportOrder.OrderNumber AndAlso
                                                                                                                                 Entity.LineNumber = ImportOrder.OrderLineNumber AndAlso
                                                                                                                                 Entity.IsActiveRevision = 1 AndAlso
                                                                                                                                 Entity.IsLineCancelled = 1)

            End If


            CheckForCancelledOrderLine = OrderLineIsCancelled

        End Function
        'Public Function CreateBroadcastImportFromImportOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '													 ByVal DataContext As AdvantageFramework.Database.DataContext,
        '													 ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
        '													 ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
        '													 Optional ByRef RevisionNumber As Integer = -1) As Boolean

        '	'objects
        '	Dim Created As Boolean = False
        '	Dim BroadcastImport As AdvantageFramework.Database.Entities.BroadcastImport = Nothing

        '	Try

        '		BroadcastImport = New AdvantageFramework.Database.Entities.BroadcastImport

        '		With BroadcastImport

        '			.LinkID = ImportOrder.OrderID
        '			.MediaType = ImportOrder.MediaType
        '			.AirDate = ImportOrder.MediaPlanAirDate
        '			.RebatePercent = Nothing
        '			.RebateAmount = Nothing
        '			.NetGross = ImportOrder.NetGross
        '			.VendorCode = GetVendorCode(DbContext, ImportOrder.VendorCode, .MediaType)
        '			.VendorCrossReferenceCode = ImportOrder.VendorCode
        '			.SalesClassCode = ImportOrder.SalesClassCode
        '			.ClientCode = ImportOrder.ClientCode
        '			.ClientName = Nothing
        '			.DivisionCode = ImportOrder.DivisionCode
        '			.ProductCode = ImportOrder.ProductCode
        '			.VendorName = Nothing
        '			.MarketCode = ImportOrder.MediaPlanMarketCode
        '			.MarketDescription = ImportOrder.MediaPlanMarketDescription
        '			.CampaignCode = ImportOrder.CampaignCode
        '			.HeaderFlightFrom = ImportOrder.StartDate
        '			.HeaderFlightTo = ImportOrder.EndDate
        '			.AdNumber = ImportOrder.MediaPlanAdNumber

        '			If ImportOrder.MediaPlanAirDate IsNot Nothing Then

        '				.LineFlightFrom = ImportOrder.MediaPlanAirDate
        '				.LineFlightTo = ImportOrder.MediaPlanAirDate

        '			Else

        '				.LineFlightFrom = ImportOrder.StartDate
        '				.LineFlightTo = ImportOrder.EndDate

        '			End If

        '			If ShowOrderDescription Then

        '				If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

        '					.OrderDescription = ImportOrder.MediaPlanOrderDescription

        '				Else

        '					.OrderDescription = OrderDescription

        '				End If

        '			Else

        '				.OrderDescription = ImportOrder.MediaPlanOrderDescription

        '			End If

        '			If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanBuyer) = False Then

        '				.BuyerEmployeeCode = ImportOrder.MediaPlanBuyer
        '				.Buyer = GetEmployeeName(DbContext, ImportOrder.MediaPlanBuyer)

        '			End If

        '			.ClientPO = ImportOrder.ClientPO
        '			.VendorRepCode = Nothing
        '                  .VendorRepCode2 = Nothing

        '                  .OrderComment = ImportOrder.MediaPlanOrderComment

        '                  .LineNumber = AdvantageFramework.StringUtilities.PadWithCharacter(ImportOrder.LineNumber.ToString, 5, "0", True)

        '			If ImportOrder.NetGross = 1 Then

        '                      .Rate = ImportOrder.GrossRate.GetValueOrDefault(0)

        '			Else

        '				.Rate = ImportOrder.NetRate.GetValueOrDefault(0)

        '			End If

        '			.NetRate = ImportOrder.NetRate.GetValueOrDefault(0)
        '			.GrossRate = ImportOrder.GrossRate.GetValueOrDefault(0)

        '			.CommissionPercent = Nothing
        '                  'If ImportOrder.GrossRate.GetValueOrDefault(0) = 0 Then

        '                  '    .CommissionPercent = 15

        '                  'Else

        '                  '    .CommissionPercent = FormatNumber(100 * (1 - (ImportOrder.NetRate.GetValueOrDefault(0) / ImportOrder.GrossRate.GetValueOrDefault(0))), 2)

        '                  'End If

        '                  If ImportOrder.Spots1.HasValue Then

        '                      .WeeklyNumber &= ImportOrder.Spots1.GetValueOrDefault(0).ToString.PadLeft(3, " ")
        '                      .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots2.GetValueOrDefault(0))
        '                      .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots3.GetValueOrDefault(0))
        '                      .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots4.GetValueOrDefault(0))
        '                      .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots5.GetValueOrDefault(0))
        '                      .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots6.GetValueOrDefault(0))

        '                      For WeekNumber As Integer = 1 To 46 Step 1

        '                          .WeeklyNumber &= "0".PadLeft(3, " ")

        '                      Next

        '                  Else

        '                      .WeeklyNumber = ImportOrder.TotalSpots.ToString.PadLeft(3, " ") & "  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0  0"

        '			End If

        '			.TotalSpots = ImportOrder.TotalSpots
        '			.JobNumber = ImportOrder.MediaPlanJobNumber
        '			.JobComponentNumber = ImportOrder.MediaPlanJobComponentNumber
        '			.StartTime = ImportOrder.MediaPlanStartTime
        '			.EndTime = ImportOrder.MediaPlanEndTime

        '			.Monday = If(ImportOrder.MediaPlanMonday, 1, 0)
        '			.Tuesday = If(ImportOrder.MediaPlanTuesday, 1, 0)
        '			.Wednesday = If(ImportOrder.MediaPlanWednesday, 1, 0)
        '			.Thrursday = If(ImportOrder.MediaPlanThursday, 1, 0)
        '			.Friday = If(ImportOrder.MediaPlanFriday, 1, 0)
        '			.Saturday = If(ImportOrder.MediaPlanSaturday, 1, 0)
        '			.Sunday = If(ImportOrder.MediaPlanSunday, 1, 0)

        '			If IsNumeric(ImportOrder.MediaPlanLength) Then

        '				.Length = ImportOrder.MediaPlanLength

        '			End If

        '                  .Programming = Mid(ImportOrder.MediaPlanProgramming, 1, 50)

        '                  .LineComment = ImportOrder.LineDescription
        '			.DeleteFlag = 0
        '			.MarkupPercent = ImportOrder.MarkupPercent
        '                  .AdditionalCharge = ImportOrder.AddAmount
        '                  .Netcharge = ImportOrder.NetCharge
        '                  .PlanIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs

        '			.CalendarType = ImportOrder.CalendarType
        '			.BuyMonth = Nothing
        '			.BuyYear = Nothing
        '			.Date1 = Nothing
        '			.Date2 = Nothing
        '			.Date3 = Nothing
        '			.Date4 = Nothing
        '			.Date5 = Nothing
        '			.Date6 = Nothing
        '			.NetworkID = Nothing
        '			.DaypartCode = ImportOrder.MediaPlanDaypart
        '			.EstimateNumber = Nothing
        '			.Netcharge = ImportOrder.NetCharge

        '			If .AirDate IsNot Nothing Then

        '				.FlightType = "S"

        '			Else

        '				.FlightType = "L"

        '			End If
        '			.PostFlag = 0
        '			.DeleteOrder = Nothing
        '			.ConvertImportLine = Nothing
        '			.IsPossibleDupe = Nothing
        '			.BroadcastWeeks = Nothing
        '			.BuyMonth = 0
        '			.BuyYear = 0
        '			.PackageName = Nothing

        '			.MediaInterface = GetSourceCode(ImportOrder, DataContext, DbContext)

        '			If RevisionNumber < 0 Then

        '				RevisionNumber = GetNextBroadcastRevisionNumber(DataContext, .MediaInterface, .LinkID, .LineNumber)

        '			End If

        '			.RevisionNumber = RevisionNumber

        '			.UserCode = ImportOrder.UserCode
        '			.MiscInfo = ImportOrder.MediaPlanMiscInfo
        '			.MaterialNotes = ImportOrder.MediaPlanMaterialNotes
        '			.PositionInfo = ImportOrder.MediaPlanPositionInfo
        '			.CloseInfo = ImportOrder.MediaPlanCloseInfo
        '			.RateInfo = ImportOrder.MediaPlanRateInfo
        '			.Remarks = ImportOrder.MediaPlanRemarks

        '			.CableNetworkStationCode = ImportOrder.CableNetworkStationCode
        '			.DaypartID = ImportOrder.DaypartID
        '			.ValueAdded = ImportOrder.ValueAdded
        '                  .Bookend = ImportOrder.Bookend
        '                  '.VendorOrderLine = ImportOrder.VendorOrderLine

        '              End With

        '		BroadcastImport.DataContext = DataContext

        '		Try

        '			BroadcastImport.ID = (From Entity In DataContext.BroadcastImports
        '								  Select Entity.ID).Max + 1

        '		Catch ex As Exception
        '			BroadcastImport.ID = 1
        '		End Try

        '		BroadcastImport.DatabaseAction = AdvantageFramework.Database.Action.Inserting

        '		DataContext.BroadcastImports.InsertOnSubmit(BroadcastImport)

        '              DataContext.SubmitChanges()

        '              Created = True

        '	Catch ex As Exception
        '		Created = False
        '	Finally
        '		CreateBroadcastImportFromImportOrder = Created
        '	End Try

        'End Function
        Public Function CreateBroadcastImportFromImportOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                             ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                             ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                                             ByVal ShowOrderDescription As Boolean, ByVal OrderDescription As String,
                                                             ByVal BroadcastImportID As Long,
                                                             ByRef BroadcastImports As Generic.List(Of AdvantageFramework.Database.Entities.BroadcastImport),
                                                             Optional ByRef RevisionNumber As Integer = -1, Optional ByVal MediaInterface As String = Nothing) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim BroadcastImport As AdvantageFramework.Database.Entities.BroadcastImport = Nothing

            Try

                BroadcastImport = New AdvantageFramework.Database.Entities.BroadcastImport

                With BroadcastImport

                    .LinkID = ImportOrder.OrderID
                    .MediaType = ImportOrder.MediaType
                    .AirDate = ImportOrder.MediaPlanAirDate
                    .RebatePercent = Nothing
                    .RebateAmount = Nothing
                    .NetGross = ImportOrder.NetGross
                    .VendorCode = GetVendorCode(DbContext, ImportOrder.VendorCode, .MediaType)
                    .VendorCrossReferenceCode = ImportOrder.VendorCode
                    .SalesClassCode = ImportOrder.SalesClassCode
                    .ClientCode = ImportOrder.ClientCode
                    .ClientName = Nothing
                    .DivisionCode = ImportOrder.DivisionCode
                    .ProductCode = ImportOrder.ProductCode
                    .VendorName = Nothing
                    .MarketCode = ImportOrder.MediaPlanMarketCode
                    .MarketDescription = ImportOrder.MediaPlanMarketDescription
                    .CampaignCode = ImportOrder.CampaignCode
                    .HeaderFlightFrom = ImportOrder.StartDate
                    .HeaderFlightTo = ImportOrder.EndDate
                    .AdNumber = ImportOrder.MediaPlanAdNumber

                    If ImportOrder.MediaPlanAirDate IsNot Nothing Then

                        .LineFlightFrom = ImportOrder.MediaPlanAirDate
                        .LineFlightTo = ImportOrder.MediaPlanAirDate

                    Else

                        .LineFlightFrom = ImportOrder.StartDate
                        .LineFlightTo = ImportOrder.EndDate

                    End If

                    If ShowOrderDescription Then

                        If ImportOrder.IsRevision AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) = False Then

                            .OrderDescription = ImportOrder.MediaPlanOrderDescription

                        Else

                            .OrderDescription = OrderDescription

                        End If

                    Else

                        .OrderDescription = ImportOrder.MediaPlanOrderDescription

                    End If

                    If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanBuyer) = False Then

                        .BuyerEmployeeCode = ImportOrder.MediaPlanBuyer
                        .Buyer = GetEmployeeName(DbContext, ImportOrder.MediaPlanBuyer)

                    End If

                    .ClientPO = ImportOrder.ClientPO
                    .VendorRepCode = Nothing
                    .VendorRepCode2 = Nothing

                    .OrderComment = ImportOrder.MediaPlanOrderComment

                    .LineNumber = AdvantageFramework.StringUtilities.PadWithCharacter(ImportOrder.LineNumber.ToString, 5, "0", True)

                    If ImportOrder.NetGross = 1 Then

                        .Rate = ImportOrder.GrossRate.GetValueOrDefault(0)

                    Else

                        .Rate = ImportOrder.NetRate.GetValueOrDefault(0)

                    End If

                    .NetRate = ImportOrder.NetRate.GetValueOrDefault(0)
                    .GrossRate = ImportOrder.GrossRate.GetValueOrDefault(0)

                    .CommissionPercent = Nothing
                    'If ImportOrder.GrossRate.GetValueOrDefault(0) = 0 Then

                    '    .CommissionPercent = 15

                    'Else

                    '    .CommissionPercent = FormatNumber(100 * (1 - (ImportOrder.NetRate.GetValueOrDefault(0) / ImportOrder.GrossRate.GetValueOrDefault(0))), 2)

                    'End If

                    If ImportOrder.Spots1.HasValue Then

                        .WeeklyNumber &= ImportOrder.Spots1.GetValueOrDefault(0).ToString & ", "
                        .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots2.GetValueOrDefault(0)) & ", "
                        .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots3.GetValueOrDefault(0)) & ", "
                        .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots4.GetValueOrDefault(0)) & ", "
                        .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots5.GetValueOrDefault(0)) & ", "
                        .WeeklyNumber &= AddToWeeklyNumber(.WeeklyNumber, ImportOrder.Spots6.GetValueOrDefault(0))

                    Else

                        .WeeklyNumber = ImportOrder.TotalSpots.ToString & ",  0,  0,  0,  0,  0"

                    End If

                    .TotalSpots = ImportOrder.TotalSpots
                    .JobNumber = ImportOrder.MediaPlanJobNumber
                    .JobComponentNumber = ImportOrder.MediaPlanJobComponentNumber
                    .StartTime = ImportOrder.MediaPlanStartTime
                    .EndTime = ImportOrder.MediaPlanEndTime

                    .Monday = If(ImportOrder.MediaPlanMonday, 1, 0)
                    .Tuesday = If(ImportOrder.MediaPlanTuesday, 1, 0)
                    .Wednesday = If(ImportOrder.MediaPlanWednesday, 1, 0)
                    .Thrursday = If(ImportOrder.MediaPlanThursday, 1, 0)
                    .Friday = If(ImportOrder.MediaPlanFriday, 1, 0)
                    .Saturday = If(ImportOrder.MediaPlanSaturday, 1, 0)
                    .Sunday = If(ImportOrder.MediaPlanSunday, 1, 0)

                    If IsNumeric(ImportOrder.MediaPlanLength) Then

                        .Length = ImportOrder.MediaPlanLength

                    End If

                    .Programming = Mid(ImportOrder.MediaPlanProgramming, 1, 50)

                    .LineComment = ImportOrder.LineDescription
                    .DeleteFlag = 0
                    .MarkupPercent = ImportOrder.MarkupPercent
                    .AdditionalCharge = ImportOrder.AddAmount
                    .Netcharge = ImportOrder.NetCharge
                    .PlanIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs

                    .CalendarType = ImportOrder.CalendarType
                    .BuyMonth = Nothing
                    .BuyYear = Nothing
                    .Date1 = Nothing
                    .Date2 = Nothing
                    .Date3 = Nothing
                    .Date4 = Nothing
                    .Date5 = Nothing
                    .Date6 = Nothing
                    .NetworkID = Nothing
                    .DaypartCode = ImportOrder.MediaPlanDaypart
                    .EstimateNumber = Nothing
                    .Netcharge = ImportOrder.NetCharge

                    If .AirDate IsNot Nothing Then

                        .FlightType = "S"

                    Else

                        .FlightType = "L"

                    End If
                    .PostFlag = 0
                    .DeleteOrder = Nothing
                    .ConvertImportLine = Nothing
                    .IsPossibleDupe = Nothing
                    .BroadcastWeeks = Nothing
                    .BuyMonth = 0
                    .BuyYear = 0
                    .PackageName = Nothing

                    If String.IsNullOrWhiteSpace(MediaInterface) = False Then

                        .MediaInterface = MediaInterface

                    Else

                        .MediaInterface = GetSourceCode(ImportOrder, DataContext, DbContext)

                    End If

                    If RevisionNumber < 0 Then

                        RevisionNumber = GetNextBroadcastRevisionNumber(DataContext, .MediaInterface, .LinkID, .LineNumber)

                    End If

                    .RevisionNumber = RevisionNumber

                    .UserCode = ImportOrder.UserCode
                    .MiscInfo = ImportOrder.MediaPlanMiscInfo
                    .MaterialNotes = ImportOrder.MediaPlanMaterialNotes
                    .PositionInfo = ImportOrder.MediaPlanPositionInfo
                    .CloseInfo = ImportOrder.MediaPlanCloseInfo
                    .RateInfo = ImportOrder.MediaPlanRateInfo
                    .Remarks = ImportOrder.MediaPlanRemarks

                    .CableNetworkStationCode = ImportOrder.CableNetworkStationCode
                    .DaypartID = ImportOrder.DaypartID
                    .ValueAdded = ImportOrder.ValueAdded
                    .Bookend = ImportOrder.Bookend
                    '.VendorOrderLine = ImportOrder.VendorOrderLine
                    .ID = BroadcastImportID

                End With

                'BroadcastImport.DataContext = DataContext

                'Try

                '    BroadcastImport.ID = (From Entity In DataContext.BroadcastImports
                '                          Select Entity.ID).Max + 1

                'Catch ex As Exception
                '    BroadcastImport.ID = 1
                'End Try

                BroadcastImports.Add(BroadcastImport)

                'BroadcastImport.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                'DataContext.BroadcastImports.InsertOnSubmit(BroadcastImport)

                'DataContext.SubmitChanges()

                Created = True

            Catch ex As Exception
                Created = False
            Finally
                CreateBroadcastImportFromImportOrder = Created
            End Try

        End Function
        Private Function AddToWeeklyNumber(WeeklyNumber As String, Spots As Integer) As String

            'objects
            Dim AdditionToWeeklyNumber As String = ""

            If String.IsNullOrWhiteSpace(WeeklyNumber) = False Then

                AdditionToWeeklyNumber = Spots.ToString

            Else

                If Spots <> 0 Then

                    AdditionToWeeklyNumber = Spots.ToString

                End If

            End If

            AddToWeeklyNumber = AdditionToWeeklyNumber

        End Function
        Public Sub LoadExportPath(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportSource As AdvantageFramework.Media.ImportSource, ByRef ExportPath As String, ByRef DirectPost As Boolean)

            If ImportSource = Media.ImportSource.MediaPlanning OrElse
               ImportSource = Methods.ImportSource.AuthorizationToBuy Then

                ExportPath = AdvantageFramework.Agency.GetOptionOrderExportFromMediaPlanPath(DbContext)

            Else

                ExportPath = AdvantageFramework.Agency.GetOptionOrderExportFromAPPath(DbContext)

            End If

            If String.IsNullOrWhiteSpace(ExportPath) OrElse System.IO.Directory.Exists(ExportPath) = False Then

                ExportPath = Nothing
                DirectPost = True

            Else

                DirectPost = False

            End If

        End Sub
        Public Function CheckForAlreadyOrderedNewOrder(ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                                       MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData),
                                                       MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate)) As Boolean

            'objects
            Dim AlreadyOrdered As Boolean = False
            Dim IDs() As Integer = Nothing
            'Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            'Dim MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing

            If ImportOrder.IsRevision = False AndAlso String.IsNullOrWhiteSpace(ImportOrder.MediaPlanDetailLevelLineDataIDs) = False AndAlso
                    ImportOrder.OrderNumber.HasValue = False AndAlso ImportOrder.OrderLineNumber.HasValue = False Then

                IDs = Split(ImportOrder.MediaPlanDetailLevelLineDataIDs, ",").ToList.Select(Function(ID) CInt(ID)).ToArray

                If ImportOrder.ImportSource = ImportSource.MediaPlanning Then

                    'MediaPlanDetailLevelLineDatas = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.Load(DbContext).Where(Function(Entity) IDs.Contains(Entity.ID) = True).ToList

                    'For Each MPDLLD In MediaPlanDetailLevelLineDatas

                    '    If MPDLLD.OrderID.HasValue Then

                    '        AlreadyOrdered = True
                    '        Exit For

                    '    End If

                    'Next

                    If MediaPlanDetailLevelLineDatas.Where(Function(Entity) IDs.Contains(Entity.ID) = True AndAlso Entity.OrderID.HasValue).Any Then

                        AlreadyOrdered = True

                    End If

                ElseIf ImportOrder.ImportSource = ImportSource.BroadcastWorksheet Then

                    'MediaBroadcastWorksheetMarketDetailDates = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Where(Function(Entity) IDs.Contains(Entity.ID) = True).ToList

                    'For Each MBWMDD In MediaBroadcastWorksheetMarketDetailDates

                    '    If MBWMDD.LinkID.HasValue Then

                    '        AlreadyOrdered = True
                    '        Exit For

                    '    End If

                    'Next

                    If MediaBroadcastWorksheetMarketDetailDates.Where(Function(Entity) IDs.Contains(Entity.ID) = True AndAlso Entity.LinkID.HasValue).Any Then

                        AlreadyOrdered = True

                    End If

                End If

            End If

            CheckForAlreadyOrderedNewOrder = AlreadyOrdered

        End Function
        Public Function GetRadioStationMetadata(RadioSource As Nielsen.Database.Entities.Methods.RadioSource, Vendor As AdvantageFramework.Database.Entities.Vendor, Session As AdvantageFramework.Security.Session,
                                                ByRef CallLetters As String, ByRef Band As String, ByRef Name As String, ByRef Frequency As String) As Boolean

            'objects
            Dim ReturnValue As Boolean = False
            Dim NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation = Nothing

            If RadioSource = Nielsen.Database.Entities.Methods.RadioSource.Nielsen AndAlso Vendor.NielsenRadioStationComboID.HasValue AndAlso Session.IsNielsenSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen)
                                           Where Entity.ComboID = Vendor.NielsenRadioStationComboID.Value
                                           Select Entity).FirstOrDefault

                    If NielsenRadioStation IsNot Nothing Then

                        CallLetters = NielsenRadioStation.CallLetters
                        Band = NielsenRadioStation.Band
                        Name = NielsenRadioStation.Name
                        Frequency = NielsenRadioStation.Frequency

                        ReturnValue = True

                    End If

                End Using

            ElseIf RadioSource = Nielsen.Database.Entities.Methods.RadioSource.Eastlan AndAlso Vendor.EastlanRadioStationComboID.HasValue AndAlso Session.IsEastlanSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Eastlan)
                                           Where Entity.ComboID = Vendor.EastlanRadioStationComboID.Value
                                           Select Entity).FirstOrDefault

                    If NielsenRadioStation IsNot Nothing Then

                        CallLetters = NielsenRadioStation.CallLetters
                        Band = NielsenRadioStation.Band
                        Name = NielsenRadioStation.Name
                        Frequency = NielsenRadioStation.Frequency

                        ReturnValue = True

                    End If

                End Using

                'ElseIf RadioSource = Nielsen.Database.Entities.Methods.RadioSource.NielsenCounty AndAlso Session.IsNielsenSetup Then

            End If

            GetRadioStationMetadata = ReturnValue

        End Function

#Region " Import Source Type Methods "

#Region "  Default "

        Public Function ImportOrdersFromDirectPost(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, Action As String, MediaType As String, ByRef ReturnMessage As String) As Boolean

            'objects
            Dim OrdersImported As Boolean = False
            Dim UserIDParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ActionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaTypeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ReturnValueParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ReturnMessageParameter As System.Data.SqlClient.SqlParameter = Nothing

            UserIDParameter = New System.Data.SqlClient.SqlParameter("@user_id", UserCode)
            ActionParameter = New System.Data.SqlClient.SqlParameter("@action", Action)
            MediaTypeParameter = New System.Data.SqlClient.SqlParameter("@order_type", MediaType)

            ReturnValueParameter = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            ReturnValueParameter.Direction = ParameterDirection.Output
            ReturnValueParameter.Value = -1

            ReturnMessageParameter = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
            ReturnMessageParameter.Direction = ParameterDirection.Output
            ReturnMessageParameter.Size = -1

            Try

                DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC [dbo].[advsp_revise_order_process] @user_id, @action, @order_type, @ret_val OUTPUT, @ret_val_s OUTPUT", UserIDParameter, ActionParameter, MediaTypeParameter, ReturnValueParameter, ReturnMessageParameter)
                'DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC usp_grant_execute_on_sp_to_public")

                If IsDBNull(ReturnValueParameter.Value) = False AndAlso ReturnValueParameter.Value = 0 Then

                    OrdersImported = True

                End If

                If IsDBNull(ReturnMessageParameter.Value) = False Then

                    ReturnMessage &= ReturnMessageParameter.Value

                End If

            Catch ex As Exception
                OrdersImported = False
                ReturnMessage &= "Error executing advsp_revise_order_process"
            End Try

            ImportOrdersFromDirectPost = OrdersImported

        End Function
        Public Function ImportOrdersFromDirectPostCleanup(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, Action As String, MediaType As String, ByRef ReturnMessage As String) As Boolean

            'objects
            Dim OrdersCleaned As Boolean = False
            Dim UserIDParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ActionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaTypeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ReturnValueParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ReturnMessageParameter As System.Data.SqlClient.SqlParameter = Nothing

            UserIDParameter = New System.Data.SqlClient.SqlParameter("@user_id", UserCode)
            ActionParameter = New System.Data.SqlClient.SqlParameter("@action", Action)
            MediaTypeParameter = New System.Data.SqlClient.SqlParameter("@order_type", MediaType)

            ReturnValueParameter = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            ReturnValueParameter.Direction = ParameterDirection.Output
            ReturnValueParameter.Value = -1

            ReturnMessageParameter = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
            ReturnMessageParameter.Direction = ParameterDirection.Output
            ReturnMessageParameter.Size = -1

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_revise_order_process_cleanup] @user_id, @action, @order_type, @ret_val OUTPUT, @ret_val_s OUTPUT", UserIDParameter, ActionParameter, MediaTypeParameter, ReturnValueParameter, ReturnMessageParameter)

                If IsDBNull(ReturnValueParameter.Value) = False AndAlso ReturnValueParameter.Value = 0 Then

                    OrdersCleaned = True

                End If

                If IsDBNull(ReturnMessageParameter.Value) = False Then

                    ReturnMessage &= ReturnMessageParameter.Value

                End If

            Catch ex As Exception
                ReturnMessage &= "Error running order process cleanup"
            End Try

            ImportOrdersFromDirectPostCleanup = OrdersCleaned

        End Function
        Private Function IsMediaOrderColumnVisible_Default(ByVal FieldName As String, ByVal ShowOrderDescription As Boolean) As Boolean

            'objects
            Dim ColumnVisible As Boolean = False

            If FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.RevNbr.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportAccountPayableMediaID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanDetailLevelLineDataIDs.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.IsRevision.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAirDate.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportSource.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CalendarType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.UserCode.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CableNetworkStationID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.DaypartID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ValueAdded.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.Bookend.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanParentPackage.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPackage.ToString Then

                ColumnVisible = False

            ElseIf FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaNetAmount.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.RateType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderComment.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanBuyer.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMarketCode.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMarketDescription.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeCode.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeDescription.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdNumber.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanHeadline.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanIssue.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanInternetType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPlacement.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOutOfHomeType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanDaypart.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanStartTime.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanEndTime.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanLength.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanProgramming.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanNetworkCode.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderDescription.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.LineDescription.ToString Then

                If Not ShowOrderDescription Then

                    ColumnVisible = True

                Else

                    ColumnVisible = False

                End If

            Else

                ColumnVisible = True

            End If

            IsMediaOrderColumnVisible_Default = ColumnVisible

        End Function

#End Region

#Region "  Media Planning "

        Private Function IsMediaOrderColumnVisible_MediaPlanning(ByVal FieldName As String, ByVal ShowOrderDescription As Boolean) As Boolean

            'objects
            Dim ColumnVisible As Boolean = False

            If FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.RevNbr.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportAccountPayableMediaID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanDetailLevelLineDataIDs.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.IsRevision.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAirDate.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportSource.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CalendarType.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.UserCode.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CableNetworkStationID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.DaypartID.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ValueAdded.ToString OrElse
                   FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.Bookend.ToString Then

                ColumnVisible = False

            ElseIf FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaNetAmount.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.RateType.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderComment.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanBuyer.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMarketCode.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMarketDescription.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeCode.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeDescription.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdNumber.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanHeadline.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanIssue.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanInternetType.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPlacement.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOutOfHomeType.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanDaypart.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanStartTime.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanEndTime.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanLength.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanProgramming.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanNetworkCode.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderDescription.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanParentPackage.ToString OrElse
                       FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPackage.ToString Then

                If Not ShowOrderDescription Then

                    ColumnVisible = True

                Else

                    ColumnVisible = False

                End If

            Else

                ColumnVisible = True

            End If

            IsMediaOrderColumnVisible_MediaPlanning = ColumnVisible

        End Function

#End Region

#Region "  Broadcast Worksheet "

        Private Function IsMediaOrderColumnVisible_BroadcastWorksheet(ByVal FieldName As String, ByVal ShowOrderDescription As Boolean) As Boolean

            'objects
            Dim ColumnVisible As Boolean = False

            If FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.RevNbr.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportAccountPayableMediaID.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanDetailLevelLineDataIDs.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.IsRevision.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAirDate.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportSource.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CalendarType.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.UserCode.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanNetworkCode.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeCode.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanAdSizeDescription.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanHeadline.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanIssue.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanInternetType.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPlacement.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOutOfHomeType.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanURL.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanTargetAudience.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanSection.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMaterial.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanLocation.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderCopy.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanParentPackage.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPackage.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanColumns.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanInches.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMediaChannelID.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanMediaTacticID.ToString OrElse
                    FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaBroadcastWorksheetStationID.ToString Then

                ColumnVisible = False

            Else

                ColumnVisible = True

            End If

            IsMediaOrderColumnVisible_BroadcastWorksheet = ColumnVisible

        End Function
        Private Function FormatSpotLength(Length As Integer) As String

            Dim Minutes As Integer = 0
            Dim Remainder As Integer = 0

            Minutes = Length / 60
            Remainder = Length Mod 60

            FormatSpotLength = "00:" & Minutes.ToString.PadLeft(2, "0") & ":" & Remainder.ToString.PadLeft(2, "0")

        End Function
        Private Function GetAgeFrom(AgeFrom As Short) As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom

            Dim ReturnVal As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom = Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item0

            Select Case AgeFrom

                Case 0

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item0

                Case 6

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item6

                Case 12

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item12

                Case 18

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item18

                Case 21

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item21

                Case 25

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item25

                Case 35

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item35

                Case 45

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item45

                Case 50

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item50

                Case 55

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item55

                Case 65

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom.Item65

            End Select

            GetAgeFrom = ReturnVal

        End Function
        Private Function GetAgeTo(AgeTo As Short) As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo

            Dim ReturnVal As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom = Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item99

            Select Case AgeTo

                Case 99

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item99

                Case 11

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item11

                Case 17

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item17

                Case 20

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item20

                Case 24

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item24

                Case 34

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item34

                Case 44

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item44

                Case 49

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item49

                Case 54

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item54

                Case 64

                    ReturnVal = AdvantageFramework.Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo.Item64

            End Select

            GetAgeTo = ReturnVal

        End Function
        Public Function BuildXMLProposalFile(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, WorksheetMarketID As Integer, SuppressRates As Boolean,
                                             VendorCode As String, ByRef VendorCodesNotSetup As Generic.List(Of String)) As System.IO.MemoryStream

            'objects
            Dim MediaBroadcastWorksheetMarketDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim XmlSerializerNamespaces As System.Xml.Serialization.XmlSerializerNamespaces = Nothing
            Dim aaaaMessageType As AdvantageFramework.Media.Classes.SpotTVCableProposal.aaaaMessageType = Nothing
            Dim radioStationType As AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType = Nothing
            Dim radioStationTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorCounter As Integer = 0
            Dim outletForListType As AdvantageFramework.Media.Classes.SpotTVCableProposal.outletForListType = Nothing
            Dim outletForListTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.outletForListType) = Nothing
            Dim availListTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.availListType) = Nothing
            Dim availListType As AdvantageFramework.Media.Classes.SpotTVCableProposal.availListType = Nothing
            Dim demoTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.demoType) = Nothing
            Dim demoType As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoType = Nothing
            Dim availLineWithDetailedPeriodsTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType) = Nothing
            Dim availLineWithDetailedPeriodsType As AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType = Nothing
            Dim dayTimeType As AdvantageFramework.Media.Classes.SpotTVCableProposal.dayTimeType = Nothing
            Dim detailedPeriodTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.detailedPeriodType) = Nothing
            Dim detailedPeriodType As AdvantageFramework.Media.Classes.SpotTVCableProposal.detailedPeriodType = Nothing
            Dim demoValueTypeList As Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.demoValueType) = Nothing
            Dim demoValueType As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoValueType = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim demoTypeImpressions As AdvantageFramework.Media.Classes.SpotTVCableProposal.demoType = Nothing

            MediaBroadcastWorksheetMarketDetails = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, WorksheetMarketID).
                                    Include("MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic").Include("Vendor").Include("MediaBroadcastWorksheetMarket.SecondaryMediaDemographic").Include("Daypart").ToList

            If VendorCode IsNot Nothing Then

                MediaBroadcastWorksheetMarketDetails = MediaBroadcastWorksheetMarketDetails.Where(Function(MBWMD) MBWMD.VendorCode = VendorCode).ToList

            End If

            XmlSerializerNamespaces = New Xml.Serialization.XmlSerializerNamespaces
            XmlSerializerNamespaces.Add("tvb", "http://www.AAAA.org/schemas/spotTV")
            XmlSerializerNamespaces.Add("tvb-tp", "http://www.AAAA.org/schemas/TVBGeneralTypes")

            aaaaMessageType = New Classes.SpotTVCableProposal.aaaaMessageType
            aaaaMessageType.AAAAValues = New Classes.SpotTVCableProposal.aaaaMessageTypeAAAAValues

            If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                aaaaMessageType.AAAAValues.SchemaName = "SpotTVCableProposal"
                aaaaMessageType.AAAAValues.SchemaVersion = "0.3.0.5" ' or 0.3.0.5A
                aaaaMessageType.AAAAValues.Media = "SpotCable" ' or SpotTV

            Else

                aaaaMessageType.AAAAValues.SchemaName = "SpotTVCableProposal"
                aaaaMessageType.AAAAValues.SchemaVersion = "0.3.0.5R"
                aaaaMessageType.AAAAValues.Media = "SpotRadio"

            End If

            aaaaMessageType.AAAAValues.BusinessObject = "Proposal"
            aaaaMessageType.AAAAValues.Action = "New" ' or Revised
            aaaaMessageType.AAAAValues.UniqueMessageID = Guid.NewGuid.ToString

            aaaaMessageType.Proposal = New Classes.SpotTVCableProposal.Proposal
            aaaaMessageType.Proposal.uniqueIdentifier = WorksheetMarketID
            aaaaMessageType.Proposal.version = "1"
            aaaaMessageType.Proposal.sendDateTime = Now
            aaaaMessageType.Proposal.weekStartDay = Classes.SpotTVCableProposal.dayOfWeekType.Mo
            aaaaMessageType.Proposal.startDate = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
            aaaaMessageType.Proposal.endDate = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate

            aaaaMessageType.Proposal.Seller = New Classes.SpotTVCableProposal.Seller
            aaaaMessageType.Proposal.Seller.companyName = "N/A"
            aaaaMessageType.Proposal.Seller.Salesperson = New Classes.SpotTVCableProposal.SellerSalesperson
            aaaaMessageType.Proposal.Seller.Salesperson.name = "N/A"

            aaaaMessageType.Proposal.Buyer = New Classes.SpotTVCableProposal.Buyer
            aaaaMessageType.Proposal.Buyer.buyingCompanyName = "N/A"

            aaaaMessageType.Proposal.Advertiser = New Classes.SpotTVCableProposal.Advertiser
            aaaaMessageType.Proposal.Advertiser.name = "N/A"
            aaaaMessageType.Proposal.Advertiser.Product = New Classes.SpotTVCableProposal.AdvertiserProduct
            aaaaMessageType.Proposal.Advertiser.Product.name = "N/A"

            aaaaMessageType.Proposal.Name = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name

            availLineWithDetailedPeriodsTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType)

            For Each VendorCode In MediaBroadcastWorksheetMarketDetails.Select(Function(MBWMD) MBWMD.VendorCode).Distinct.ToList

                Vendor = MediaBroadcastWorksheetMarketDetails.Where(Function(MBWMD) MBWMD.VendorCode = VendorCode).First.Vendor

                If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                    If radioStationTypeList Is Nothing Then

                        radioStationTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType)

                    End If

                    If outletForListTypeList Is Nothing Then

                        outletForListTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.outletForListType)

                    End If

                    radioStationType = New Classes.SpotTVCableProposal.radioStationType
                    outletForListType = New AdvantageFramework.Media.Classes.SpotTVCableProposal.outletForListType

                    If GetRadioStationMetadata(MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.ExternalRadioSource, Vendor, Session, radioStationType.callLetters, radioStationType.band, Nothing, Nothing) Then

                        radioStationType.outletId = "OUT" & VendorCounter.ToString
                        radioStationTypeList.Add(radioStationType)

                        outletForListType.outletFromProposalRef = radioStationType.outletId
                        outletForListType.outletForListId = "OUL" & VendorCounter.ToString
                        outletForListTypeList.Add(outletForListType)

                        For Each MBWMD In MediaBroadcastWorksheetMarketDetails.Where(Function(Entity) Entity.VendorCode = VendorCode).OrderBy(Function(Entity) Entity.ID)

                            availLineWithDetailedPeriodsType = New AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType

                            availLineWithDetailedPeriodsType.OutletReference = New Classes.SpotTVCableProposal.outletForAvailType
                            availLineWithDetailedPeriodsType.OutletReference.outletFromListRef = outletForListType.outletForListId

                            dayTimeType = New Classes.SpotTVCableProposal.dayTimeType
                            dayTimeType.StartTime = MBWMD.StartHour.ToString.PadLeft(4, "0").Substring(0, 2) & ":" & MBWMD.StartHour.ToString.PadLeft(4, "0").Substring(2)
                            dayTimeType.EndTime = MBWMD.EndHour.ToString.PadLeft(4, "0").Substring(0, 2) & ":" & MBWMD.EndHour.ToString.PadLeft(4, "0").Substring(2)

                            dayTimeType.Days = New Classes.SpotTVCableProposal.daysOfWeekType
                            dayTimeType.Days.Monday = If(MBWMD.Monday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Tuesday = If(MBWMD.Tuesday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Wednesday = If(MBWMD.Wednesday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Thursday = If(MBWMD.Thursday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Friday = If(MBWMD.Friday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Saturday = If(MBWMD.Saturday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)
                            dayTimeType.Days.Sunday = If(MBWMD.Sunday, Classes.SpotTVCableProposal.yesNoType.Y, Classes.SpotTVCableProposal.yesNoType.N)

                            availLineWithDetailedPeriodsType.DayTimes = {dayTimeType}

                            If MBWMD.Daypart IsNot Nothing Then

                                availLineWithDetailedPeriodsType.DaypartName = MBWMD.Daypart.Description

                            End If

                            availLineWithDetailedPeriodsType.AvailName = MBWMD.Days & " " & MBWMD.StartTime & "-" & MBWMD.EndTime
                            availLineWithDetailedPeriodsType.SpotLength = FormatSpotLength(MBWMD.Length)

                            MediaBroadcastWorksheetMarketDetailDates = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MBWMD.ID).ToList

                            detailedPeriodTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.detailedPeriodType)

                            For Each MediaBroadcastWorksheetMarketDetailDate In MediaBroadcastWorksheetMarketDetailDates

                                detailedPeriodType = New Classes.SpotTVCableProposal.detailedPeriodType
                                detailedPeriodType.startDate = MediaBroadcastWorksheetMarketDetailDate.Date

                                If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily Then

                                    detailedPeriodType.endDate = MediaBroadcastWorksheetMarketDetailDate.Date

                                Else

                                    detailedPeriodType.endDate = MediaBroadcastWorksheetMarketDetailDate.Date.AddDays(6)

                                End If

                                If SuppressRates Then

                                    detailedPeriodType.Rate = 0.00

                                Else

                                    detailedPeriodType.Rate = MediaBroadcastWorksheetMarketDetailDate.Rate

                                End If

                                detailedPeriodType.SpotsPerWeek = MediaBroadcastWorksheetMarketDetailDate.Spots

                                If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                                    demoValueTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.demoValueType)

                                    demoValueType = New Classes.SpotTVCableProposal.demoValueType
                                    demoValueType.demoRef = "DM0"
                                    demoValueType.Value = MBWMD.PrimaryAQHRating

                                    demoValueTypeList.Add(demoValueType)

                                    demoValueType = New Classes.SpotTVCableProposal.demoValueType
                                    demoValueType.demoRef = "DM2"
                                    demoValueType.Value = MBWMD.PrimaryAQH
                                    demoValueTypeList.Add(demoValueType)

                                    If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic IsNot Nothing Then

                                        demoValueType = New Classes.SpotTVCableProposal.demoValueType
                                        demoValueType.demoRef = "DM1"
                                        demoValueType.Value = MBWMD.SecondaryAQHRating

                                        demoValueTypeList.Add(demoValueType)

                                        demoValueType = New Classes.SpotTVCableProposal.demoValueType
                                        demoValueType.demoRef = "DM3"
                                        demoValueType.Value = MBWMD.SecondaryAQH
                                        demoValueTypeList.Add(demoValueType)

                                    End If

                                    detailedPeriodType.DemoValues = demoValueTypeList.ToArray

                                End If

                                detailedPeriodTypeList.Add(detailedPeriodType)

                            Next

                            availLineWithDetailedPeriodsType.Periods = New Classes.SpotTVCableProposal.availLineWithDetailedPeriodsTypePeriods
                            availLineWithDetailedPeriodsType.Periods.Items = detailedPeriodTypeList.ToArray

                            availLineWithDetailedPeriodsTypeList.Add(availLineWithDetailedPeriodsType)

                        Next

                        VendorCounter += 1

                    Else

                        If VendorCodesNotSetup Is Nothing Then

                            VendorCodesNotSetup = New Generic.List(Of String)

                        End If

                        VendorCodesNotSetup.Add(Vendor.Code)

                    End If

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                End If

            Next

            aaaaMessageType.Proposal.Outlets = New Classes.SpotTVCableProposal.outletsForProposalType

            If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                aaaaMessageType.Proposal.Outlets.Items = radioStationTypeList.ToArray

            End If

            availListTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.SpotTVCableProposal.availListType)

            availListType = New Classes.SpotTVCableProposal.availListType
            availListType.Name = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name
            availListType.OutletReferences = outletForListTypeList.ToArray

            demoTypeList = New List(Of Classes.SpotTVCableProposal.demoType)

            If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                demoType = New Classes.SpotTVCableProposal.demoType
                demoType.DemoId = "DM0"
                demoType.DemoType = Classes.SpotTVCableProposal.demoBaseTypeDemoType.Rating

                demoType.AgeFrom = GetAgeFrom(MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0))
                demoType.AgeTo = GetAgeTo(MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99))

                If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales AndAlso
                        MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Adults

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Men

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Women

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(0) = 17 Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Teens

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsBoys OrElse
                        MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsGirls Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Children

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.IsWorkingWomen Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.WWomen

                Else

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Persons

                End If

                demoTypeList.Add(demoType)

                demoTypeImpressions = New Classes.SpotTVCableProposal.demoType
                demoTypeImpressions.DemoId = "DM2"
                demoTypeImpressions.DemoType = Classes.SpotTVCableProposal.demoBaseTypeDemoType.Impression
                demoTypeImpressions.AgeFrom = demoType.AgeFrom
                demoTypeImpressions.AgeTo = demoType.AgeTo
                demoTypeImpressions.Group = demoType.Group
                demoTypeList.Add(demoTypeImpressions)

                availListType.TargetDemo = New Classes.SpotTVCableProposal.availListTypeTargetDemo
                availListType.TargetDemo.demoRef = demoType.DemoId

            End If

            If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic IsNot Nothing Then

                demoType = New Classes.SpotTVCableProposal.demoType
                demoType.DemoId = "DM1"
                demoType.DemoType = Classes.SpotTVCableProposal.demoBaseTypeDemoType.Rating

                demoType.AgeFrom = GetAgeFrom(MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.AgeFrom.GetValueOrDefault(0))
                demoType.AgeTo = GetAgeTo(MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.AgeTo.GetValueOrDefault(99))

                If MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsMales AndAlso
                        MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsFemales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Adults

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsMales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Men

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsFemales Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Women

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.AgeTo.GetValueOrDefault(0) = 17 Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Teens

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsBoys OrElse
                        MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsGirls Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Children

                ElseIf MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.IsWorkingWomen Then

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.WWomen

                Else

                    demoType.Group = Classes.SpotTVCableProposal.demoBaseTypeGroup.Persons

                End If

                demoTypeList.Add(demoType)

                demoTypeImpressions = New Classes.SpotTVCableProposal.demoType
                demoTypeImpressions.DemoId = "DM3"
                demoTypeImpressions.DemoType = Classes.SpotTVCableProposal.demoBaseTypeDemoType.Impression
                demoTypeImpressions.AgeFrom = demoType.AgeFrom
                demoTypeImpressions.AgeTo = demoType.AgeTo
                demoTypeImpressions.Group = demoType.Group
                demoTypeList.Add(demoTypeImpressions)

            End If

            availListType.DemoCategories = demoTypeList.ToArray

            availListType.startDate = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
            availListType.endDate = MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate
            availListType.identifier = "AL001"
            availListType.isPackage = Classes.SpotTVCableProposal.yesNoType.N

            availListType.Items = availLineWithDetailedPeriodsTypeList.ToArray

            availListTypeList.Add(availListType)

            aaaaMessageType.Proposal.AvailList = availListTypeList.ToArray

            XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.aaaaMessageType))

            MemoryStream = New System.IO.MemoryStream()

            XmlSerializer.Serialize(MemoryStream, aaaaMessageType, XmlSerializerNamespaces)

            'Try

            '    Dim FileStream As System.IO.FileStream = Nothing

            '    FileStream = New System.IO.FileStream("C:\Users\mikec\Desktop\Radio Proposal\AAAAMessage.xml", System.IO.FileMode.Create, System.IO.FileAccess.Write)
            '    MemoryStream.WriteTo(FileStream)
            '    FileStream.Close()

            'Catch ex As Exception

            'End Try

            BuildXMLProposalFile = MemoryStream

        End Function

#End Region

#Region "  Authorization to Buy "

        Private Function IsMediaOrderColumnVisible_AuthorizationToBuy(ByVal FieldName As String) As Boolean

            'objects
            Dim VisibleColumns As String() = Nothing

            VisibleColumns = {AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderDescription.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.VendorCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.ClientCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.DivisionCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.ProductCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.SalesClassCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.CampaignCode.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.ClientPO.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.NetGross.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.LineNumber.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.StartDate.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.EndDate.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.CostType.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.TotalSpots.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.NetRate.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.GrossRate.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.Cost.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.NetCharge.ToString,
                              AdvantageFramework.Media.Classes.ImportOrder.Properties.MarkupPercent.ToString}

            IsMediaOrderColumnVisible_AuthorizationToBuy = VisibleColumns.Contains(FieldName)

        End Function
        Public Function CreateOrdersFromATB(ByVal Session As AdvantageFramework.Security.Session, ByVal ATBNumber As Integer, ByVal RevisionNumber As Integer,
                                            ByVal MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions,
                                            ByVal AdServingVendorCode As String, ByVal IncludeMarkupPercentOnAdServing As Boolean,
                                            ByRef ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
                                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            If MediaATBOrderOption = Database.Entities.MediaATBOrderOptions.SeparateForAdServing Then

                If String.IsNullOrEmpty(AdServingVendorCode) Then

                    ErrorMessage = "Please select a vendor."

                End If

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, ATBNumber)

                        If MediaATB IsNot Nothing Then

                            MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, ATBNumber, RevisionNumber)

                            If MediaATBRevision IsNot Nothing Then

                                'TransferPreviousRevisionOrderInformation(DbContext, DataContext, MediaATBRevision.ATBNumber, MediaATBRevision.RevisionID)

                                Select Case MediaATBOrderOption

                                    Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge

                                        ImportOrderList = CreateImportOrdersWithAdServingAsNetCharge(DbContext, DataContext, MediaATB, MediaATBRevision)

                                    Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder

                                        ImportOrderList = CreateImportOrdersWithAdServingOnEachVendorOrder(DbContext, DataContext, MediaATB, MediaATBRevision, IncludeMarkupPercentOnAdServing)

                                    Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.SeparateForAdServing

                                        ImportOrderList = CreateImportOrdersWithSeparateAdServing(DbContext, DataContext, MediaATB, MediaATBRevision, AdServingVendorCode, IncludeMarkupPercentOnAdServing)

                                End Select

                                If MediaATBRevision.BillingMethod = AdvantageFramework.Database.Entities.MediaATBBillingMethod.ByMonth Then

                                    ImportOrderList = SplitImportOrderByMonth(ImportOrderList)

                                End If

                            End If

                        End If

                        If ImportOrderList IsNot Nothing AndAlso ImportOrderList.Count > 0 Then

                            Created = True

                            For Each ImportOrder In ImportOrderList

                                'LoadAssociatedMediaATBRevisionDetailOrder(DbContext, DataContext, MediaATB.Number, MediaATBRevision.RevisionID, ImportOrder)

                                ImportOrder.ImportSource = ImportSource.AuthorizationToBuy

                                If ImportOrder.OrderID.HasValue Then

                                    ImportOrder.IsRevision = True
                                    ImportOrder.SetReadOnly(AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString, True)

                                End If

                                If ImportOrder.LineNumber.HasValue Then

                                    ImportOrder.IsRevision = True
                                    ImportOrder.SetReadOnly(AdvantageFramework.Media.Classes.ImportOrder.Properties.LineNumber.ToString, True)

                                End If

                            Next

                            CheckOrderIDandLineNumbers(ImportOrderList)

                            ImportOrders = ImportOrderList

                        End If

                    End Using

                End Using

            End If

            CreateOrdersFromATB = Created

        End Function
        Private Sub CheckOrderIDandLineNumbers(ByRef ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder))

            'objects
            Dim Counter As Integer = 0

            If (From Entity In ImportOrderList
                Where Entity.OrderID.GetValueOrDefault(0) > 0
                Select Entity).Any Then

                For Each OrderID In (From Entity In ImportOrderList
                                     Where Entity.OrderID.GetValueOrDefault(0) > 0
                                     Select [OID] = Entity.OrderID).Distinct.ToList

                    Counter = 1

                    If (From Entity In ImportOrderList
                        Where Entity.OrderID = OrderID
                        Select Entity).Count <> (From Entity In ImportOrderList
                                                 Where Entity.OrderID = OrderID
                                                 Select [OID] = Entity.OrderID, Entity.LineNumber).Distinct.Count Then

                        For Each ImportOrder In ImportOrderList

                            If ImportOrder.OrderID.GetValueOrDefault(0) = OrderID Then

                                ImportOrder.LineNumber = Counter

                                Counter = Counter + 1

                            End If

                        Next

                    End If

                Next

            End If

        End Sub
        Private Sub TransferPreviousRevisionOrderInformation(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                             ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                             ByVal ATBNumber As Integer, ByVal CurrentRevisionID As Integer)

            'objects
            Dim MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim OrderedMediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim MaxRevisionIDWithOrders As Integer = 0
            Dim OrderedRevisionDetailID As Integer = Nothing
            Dim NotOrderedRevisionDetailID As Integer = Nothing

            Try

                Try

                    MaxRevisionIDWithOrders = DbContext.Database.SqlQuery(Of Integer)(String.Format(" SELECT ISNULL(MAX(ATB_REV.ATB_REV_ID), 0) FROM dbo.ATB_REV JOIN " &
                                                                                                        " dbo.ATB_REV_DTL ON ATB_REV.ATB_REV_ID = ATB_REV_DTL.ATB_REV_ID JOIN " &
                                                                                                        " dbo.ATB_REV_DTL_ORDER ON ATB_REV_DTL.ATB_REV_DTL_ID = ATB_REV_DTL_ORDER.ATB_REV_DTL_ID " &
                                                                                                        " WHERE ATB_REV.ATB_NUMBER = {0} ", ATBNumber)).SingleOrDefault

                Catch ex As Exception
                    MaxRevisionIDWithOrders = 0
                End Try

                If MaxRevisionIDWithOrders > 0 AndAlso MaxRevisionIDWithOrders <> CurrentRevisionID Then

                    For Each VendorCode In (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                            Select [VC] = Entity.VendorCode).Distinct.ToArray

                        OrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                                   Where Entity.VendorCode = VendorCode
                                                   Select Entity.DetailID).FirstOrDefault

                        If OrderedRevisionDetailID > 0 Then

                            NotOrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, CurrentRevisionID)
                                                          Where Entity.VendorCode = VendorCode
                                                          Select Entity.DetailID).FirstOrDefault

                            If NotOrderedRevisionDetailID > 0 Then

                                For Each OrderedMediaATBRevisionDetailOrder In (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                                                Where Entity.DetailID = OrderedRevisionDetailID
                                                                                Select Entity).ToList

                                    MediaATBRevisionDetailOrder = New AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder

                                    MediaATBRevisionDetailOrder.DetailID = NotOrderedRevisionDetailID
                                    MediaATBRevisionDetailOrder.OrderMonth = OrderedMediaATBRevisionDetailOrder.OrderMonth
                                    MediaATBRevisionDetailOrder.OrderYear = OrderedMediaATBRevisionDetailOrder.OrderYear
                                    MediaATBRevisionDetailOrder.OrderID = OrderedMediaATBRevisionDetailOrder.OrderID
                                    MediaATBRevisionDetailOrder.OrderLineID = OrderedMediaATBRevisionDetailOrder.OrderLineID
                                    MediaATBRevisionDetailOrder.OrderNumber = OrderedMediaATBRevisionDetailOrder.OrderNumber
                                    MediaATBRevisionDetailOrder.OrderLineNumber = OrderedMediaATBRevisionDetailOrder.OrderLineNumber

                                    AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Insert(DbContext, DataContext, MediaATBRevisionDetailOrder)

                                Next

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Function CreateImportOrdersWithAdServingAsNetCharge(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                    ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                                    ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

            Try

                MediaATBRevisionDetails = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).ToList

                ImportOrderList = CreateImportOrdersFromRevisionDetails(DbContext, DataContext, Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge, MediaATB, MediaATBRevision, MediaATBRevisionDetails, Nothing)

            Catch ex As Exception
                ImportOrderList = Nothing
            Finally
                CreateImportOrdersWithAdServingAsNetCharge = ImportOrderList
            End Try

        End Function
        Private Function CreateImportOrdersWithAdServingOnEachVendorOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                          ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                          ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                                          ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision,
                                                                          ByVal IncludeMarkupPercentOnAdServing As Boolean) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
            Dim AdServingMediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
            Dim VendorMediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim HandledDetailIDs As Generic.List(Of Integer) = Nothing
            Dim AdServingMediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim NonAdServingMediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing

            Try

                MediaATBRevisionDetails = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).ToList

                AdServingMediaATBRevisionDetails = (From Entity In MediaATBRevisionDetails
                                                    Where Entity.AdServingForDetailID.GetValueOrDefault(0) > 0
                                                    Select Entity).ToList

                NonAdServingMediaATBRevisionDetails = (From Entity In MediaATBRevisionDetails
                                                       Where Entity.AdServingForDetailID.GetValueOrDefault(0) = 0
                                                       Select Entity).ToList

                ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                For Each MediaATBRevisionDetail In NonAdServingMediaATBRevisionDetails

                    ImportOrders = CreateImportOrdersFromRevisionDetail(DbContext, DataContext, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder,
                                                                        MediaATB, MediaATBRevision, MediaATBRevisionDetail, Nothing)

                    If ImportOrders IsNot Nothing AndAlso ImportOrders.Count > 0 Then

                        ImportOrderList.AddRange(ImportOrders)

                    End If

                    Try

                        AdServingMediaATBRevisionDetail = (From Entity In AdServingMediaATBRevisionDetails
                                                           Where Entity.VendorCode = MediaATBRevisionDetail.VendorCode AndAlso
                                                                 Entity.AdServingForDetailID = MediaATBRevisionDetail.DetailID
                                                           Select Entity).SingleOrDefault

                    Catch ex As Exception

                    End Try

                    If AdServingMediaATBRevisionDetail IsNot Nothing Then

                        FillAdServingMediaATBRevisionDetail(DbContext, MediaATBRevision.RevisionID, MediaATBRevisionDetail.VendorCode, MediaATBRevisionDetail.NetChargeAmount.GetValueOrDefault(0), IncludeMarkupPercentOnAdServing, MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode, AdServingMediaATBRevisionDetail)

                        If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Update(DbContext, AdServingMediaATBRevisionDetail) Then

                            AdServingMediaATBRevisionDetails.Remove(AdServingMediaATBRevisionDetail)

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaType = "I"
                            FillImportOrderFromMediaATB(MediaATB, ImportOrder)
                            FillImportOrderFromMediaATBRevision(DbContext, MediaATBRevision, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder, True, ImportOrder)
                            FillImportOrderFromMediaATBRevisionDetail(DbContext, DataContext, MediaATB, AdServingMediaATBRevisionDetail, ImportOrder, False)

                            LoadAssociatedMediaATBRevisionDetailOrder(DbContext, DataContext, MediaATB.Number, AdServingMediaATBRevisionDetail, ImportOrder)

                            ImportOrderList.Add(ImportOrder)

                        End If

                    Else

                        AdServingMediaATBRevisionDetail = New AdvantageFramework.Database.Entities.MediaATBRevisionDetail

                        FillAdServingMediaATBRevisionDetail(DbContext, MediaATBRevision.RevisionID, MediaATBRevisionDetail.VendorCode, MediaATBRevisionDetail.NetChargeAmount.GetValueOrDefault(0), IncludeMarkupPercentOnAdServing, MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode, AdServingMediaATBRevisionDetail)

                        AdServingMediaATBRevisionDetail.AdServingForDetailID = MediaATBRevisionDetail.DetailID

                        If AdServingMediaATBRevisionDetail IsNot Nothing AndAlso AdServingMediaATBRevisionDetail.NetChargeAmount.GetValueOrDefault(0) <> 0 Then

                            If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Insert(DbContext, AdServingMediaATBRevisionDetail) Then

                                ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                                ImportOrder.MediaType = "I"
                                FillImportOrderFromMediaATB(MediaATB, ImportOrder)
                                FillImportOrderFromMediaATBRevision(DbContext, MediaATBRevision, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder, True, ImportOrder)
                                FillImportOrderFromMediaATBRevisionDetail(DbContext, DataContext, MediaATB, AdServingMediaATBRevisionDetail, ImportOrder, False)

                                LoadAssociatedMediaATBRevisionDetailOrder(DbContext, DataContext, MediaATB.Number, AdServingMediaATBRevisionDetail, ImportOrder)

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    End If

                Next

                For Each NotUsedAdServingMediaATBRevisionDetail In AdServingMediaATBRevisionDetails 'left on the order, not associated with anything

                    NotUsedAdServingMediaATBRevisionDetail.AdServingForDetailID = Nothing

                    If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Update(DbContext, NotUsedAdServingMediaATBRevisionDetail) Then

                        ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                        ImportOrder.MediaType = "I"
                        FillImportOrderFromMediaATB(MediaATB, ImportOrder)
                        FillImportOrderFromMediaATBRevision(DbContext, MediaATBRevision, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder, True, ImportOrder)
                        FillImportOrderFromMediaATBRevisionDetail(DbContext, DataContext, MediaATB, NotUsedAdServingMediaATBRevisionDetail, ImportOrder, False)

                        ImportOrderList.Add(ImportOrder)

                    End If

                Next

                'For Each VendorCode In (From Entity In MediaATBRevisionDetails _
                '                        Select [VC] = Entity.VendorCode).ToList

                '    VendorMediaATBRevisionDetails = (From Entity In MediaATBRevisionDetails _
                '                                     Where Entity.VendorCode = VendorCode _
                '                                     Select Entity).ToList

                '    ImportOrders = CreateImportOrdersFromRevisionDetails(DbContext, DataContext, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder, _
                '                                                         MediaATB, MediaATBRevision, VendorMediaATBRevisionDetails, Nothing)

                '    If ImportOrders IsNot Nothing AndAlso ImportOrders.Count > 0 Then

                '        ImportOrderList.AddRange(ImportOrders)

                '    End If

                '    MediaATBRevisionDetail = CreateAdServingMediaATBRevisionDetail(DbContext, MediaATBRevision.RevisionID, VendorCode, True, IncludeMarkupPercentOnAdServing, MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode)

                '    If MediaATBRevisionDetail IsNot Nothing Then

                '        ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                '        ImportOrder.MediaType = "I"
                '        FillImportOrderFromMediaATB(MediaATB, ImportOrder)
                '        FillImportOrderFromMediaATBRevision(DbContext, MediaATBRevision, Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder, True, ImportOrder)
                '        FillImportOrderFromMediaATBRevisionDetail(DbContext, DataContext, MediaATB, MediaATBRevisionDetail, ImportOrder, IncludeMarkupPercentOnAdServing)

                '        ImportOrderList.Add(ImportOrder)

                '    End If

                'Next

            Catch ex As Exception
                ImportOrderList = Nothing
            Finally
                CreateImportOrdersWithAdServingOnEachVendorOrder = ImportOrderList
            End Try

        End Function
        Private Function CreateImportOrdersWithSeparateAdServing(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                 ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                 ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                                 ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision,
                                                                 ByVal AdServingVendorCode As String,
                                                                 ByVal IncludeMarkupPercentOnAdServing As Boolean) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim AdServingMediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim Total As Decimal = Nothing

            Try

                MediaATBRevisionDetails = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).ToList

                ImportOrderList = CreateImportOrdersFromRevisionDetails(DbContext, DataContext, Database.Entities.MediaATBOrderOptions.SeparateForAdServing, MediaATB, MediaATBRevision, MediaATBRevisionDetails, AdServingVendorCode)

                Try

                    Total = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).ToList
                             Select Entity.NetChargeAmount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Total = 0
                End Try

                If Total > 0 Then

                    AdServingMediaATBRevisionDetail = New AdvantageFramework.Database.Entities.MediaATBRevisionDetail

                    FillAdServingMediaATBRevisionDetail(DbContext, MediaATBRevision.RevisionID, AdServingVendorCode, Total, IncludeMarkupPercentOnAdServing, MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode, AdServingMediaATBRevisionDetail)

                    If AdServingMediaATBRevisionDetail IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Insert(DbContext, AdServingMediaATBRevisionDetail) Then

                            ImportOrderList.AddRange(CreateImportOrdersFromRevisionDetail(DbContext, DataContext, Database.Entities.MediaATBOrderOptions.SeparateForAdServing, MediaATB, MediaATBRevision, AdServingMediaATBRevisionDetail, AdServingVendorCode))

                        End If

                    End If

                End If

            Catch ex As Exception
                ImportOrderList = Nothing
            Finally
                CreateImportOrdersWithSeparateAdServing = ImportOrderList
            End Try

        End Function
        Private Sub FillAdServingMediaATBRevisionDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal RevisionID As Integer, ByVal VendorCode As String,
                                                        ByVal Total As Decimal, ByVal IncludeMarkupPercentOnAdServing As Boolean,
                                                        ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                                        ByRef MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail)

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If MediaATBRevisionDetail IsNot Nothing Then

                MediaATBRevisionDetail.DbContext = DbContext
                MediaATBRevisionDetail.RevisionID = RevisionID
                MediaATBRevisionDetail.VendorCode = VendorCode
                MediaATBRevisionDetail.Amount = Total
                MediaATBRevisionDetail.NetChargeAmount = -Total

                If IncludeMarkupPercentOnAdServing Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                    If Product IsNot Nothing AndAlso Product.InternetMarkup.HasValue Then

                        MediaATBRevisionDetail.MarkupPercent = Product.InternetMarkup

                        MediaATBRevisionDetail.MarkupAmount = Math.Round(MediaATBRevisionDetail.Amount.GetValueOrDefault(0) * (MediaATBRevisionDetail.MarkupPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

                    End If

                Else

                    MediaATBRevisionDetail.MarkupPercent = 0

                End If

            End If

        End Sub
        'Private Function CreateAdServingMediaATBRevisionDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                                       ByVal RevisionID As Integer, ByVal VendorCode As String, _
        '                                                       ByVal Total As Decimal?, ByVal IncludeMarkupPercentOnAdServing As Boolean,
        '                                                       ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As AdvantageFramework.Database.Entities.MediaATBRevisionDetail

        '    'objects
        '    Dim MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail = Nothing
        '    Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        '    Try

        '        Try

        '            If Total.HasValue = False Then

        '                Total = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, RevisionID).ToList _
        '                         Select Entity.NetChargeAmount.GetValueOrDefault(0)).Sum

        '            End If

        '        Catch ex As Exception

        '        End Try

        '        If Total.GetValueOrDefault(0) <> 0 Then

        '            MediaATBRevisionDetail = New AdvantageFramework.Database.Entities.MediaATBRevisionDetail

        '            MediaATBRevisionDetail.DbContext = DbContext
        '            MediaATBRevisionDetail.RevisionID = RevisionID
        '            MediaATBRevisionDetail.VendorCode = VendorCode
        '            MediaATBRevisionDetail.Amount = Total
        '            MediaATBRevisionDetail.NetChargeAmount = -Total

        '            If IncludeMarkupPercentOnAdServing Then

        '                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

        '                If Product IsNot Nothing AndAlso Product.InternetMarkup.HasValue Then

        '                    MediaATBRevisionDetail.MarkupPercent = Product.InternetMarkup

        '                    MediaATBRevisionDetail.MarkupAmount = Math.Round(MediaATBRevisionDetail.Amount.GetValueOrDefault(0) * (MediaATBRevisionDetail.MarkupPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

        '                End If

        '            End If

        '            If AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.Insert(DbContext, MediaATBRevisionDetail) = False Then

        '                MediaATBRevisionDetail = Nothing

        '            End If

        '        End If

        '    Catch ex As Exception
        '        MediaATBRevisionDetail = Nothing
        '    Finally
        '        CreateAdServingMediaATBRevisionDetail = MediaATBRevisionDetail
        '    End Try

        'End Function
        Private Function CreateImportOrdersFromRevisionDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                               ByVal MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions,
                                                               ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                               ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision,
                                                               ByVal MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail),
                                                               ByVal AdServingVendorCode As String) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim VendorMediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim SeparateVendorMediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim Amount As Decimal? = 0
            Dim Quantity As Decimal? = 0
            Dim Rate As Decimal? = 0
            Dim CostType As String = Nothing
            Dim NetChargeAmount As Decimal? = 0
            Dim MarkupPercent As Decimal? = Nothing
            Dim CreateSeparateVendorLine As Boolean = False

            Try

                ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                For Each VendorCode In MediaATBRevisionDetails.Select(Function(RevDtl) RevDtl.VendorCode).Distinct

                    VendorMediaATBRevisionDetails = (From Entity In MediaATBRevisionDetails
                                                     Where Entity.VendorCode = VendorCode
                                                     Select Entity).ToList

                    If VendorMediaATBRevisionDetails.Count > 1 Then

                        If VendorMediaATBRevisionDetails.Select(Function(AtbRevDtl) AtbRevDtl.Rate.GetValueOrDefault(0)).Distinct.Count > 1 OrElse
                            VendorMediaATBRevisionDetails.Select(Function(AtbRevDtl) If(String.IsNullOrWhiteSpace(AtbRevDtl.CostType), AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code, AtbRevDtl.CostType)).Distinct.Count > 1 Then

                            CreateSeparateVendorLine = True

                        End If

                    End If

                    If CreateSeparateVendorLine = False Then

                        ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                        ImportOrder.ImportSource = AdvantageFramework.Media.ImportSource.AuthorizationToBuy
                        ImportOrder.MediaType = "I"

                        FillImportOrderFromMediaATB(MediaATB, ImportOrder)
                        FillImportOrderFromMediaATBRevision(DbContext, MediaATBRevision, MediaATBOrderOption, If(VendorCode = AdServingVendorCode, True, False), ImportOrder)

                        If MediaATBRevision.BuyGrossOrNetFlag.GetValueOrDefault(0) = 0 Then 'Net

                            MarkupPercent = VendorMediaATBRevisionDetails.First.MarkupPercent

                        Else

                            MarkupPercent = Nothing

                        End If

                        CostType = VendorMediaATBRevisionDetails.First.CostType

                        If String.IsNullOrWhiteSpace(CostType) Then

                            CostType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code

                        End If

                        Rate = VendorMediaATBRevisionDetails.First.Rate

                        Quantity = Nothing

                        Try

                            If (From Entity In VendorMediaATBRevisionDetails
                                Where Entity.Quantity.HasValue = True
                                Select Entity).Any Then

                                Quantity = (From Entity In VendorMediaATBRevisionDetails
                                            Select Entity.Quantity.GetValueOrDefault(0)).Sum

                            End If

                        Catch ex As Exception
                            Quantity = Nothing
                        End Try

                        Try

                            Amount = (From Entity In VendorMediaATBRevisionDetails
                                      Select Entity.Amount.GetValueOrDefault(0)).Sum

                        Catch ex As Exception
                            Amount = Nothing
                        End Try

                        Select Case MediaATBOrderOption

                            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.SeparateForAdServing

                                NetChargeAmount = Nothing

                            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder

                                NetChargeAmount = Nothing

                            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge

                                Try

                                    NetChargeAmount = (From Entity In VendorMediaATBRevisionDetails
                                                       Select Entity.NetChargeAmount.GetValueOrDefault(0)).Sum

                                Catch ex As Exception
                                    NetChargeAmount = Nothing
                                End Try

                        End Select

                        FillImportOrderFromMediaATBRevisionDetail(VendorCode, Quantity, Rate, CostType, Amount, NetChargeAmount, MarkupPercent, ImportOrder)

                        ImportOrder.MediaPlanDetailLevelLineDataIDs = FormatATBLineLevelIDs(VendorMediaATBRevisionDetails.Select(Function(RevDtl) RevDtl.DetailID).ToArray)

                        If ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.NetCharge.GetValueOrDefault(0) <> 0 Then

                            LoadAssociatedMediaATBRevisionDetailOrder(DbContext, DataContext, MediaATB.Number, MediaATBRevisionDetails.First, ImportOrder)

                            ImportOrderList.Add(ImportOrder)

                        End If

                    Else

                        SeparateVendorMediaATBRevisionDetails = New Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail)

                        For Each ATBRevisionDetail In VendorMediaATBRevisionDetails

                            SeparateVendorMediaATBRevisionDetails.Clear()

                            SeparateVendorMediaATBRevisionDetails.Add(ATBRevisionDetail)

                            ImportOrderList.AddRange(CreateImportOrdersFromRevisionDetails(DbContext, DataContext, MediaATBOrderOption, MediaATB, MediaATBRevision, SeparateVendorMediaATBRevisionDetails, AdServingVendorCode))

                        Next

                    End If

                Next

            Catch ex As Exception
                ImportOrderList = Nothing
            Finally
                CreateImportOrdersFromRevisionDetails = ImportOrderList
            End Try

        End Function
        Private Function CreateImportOrdersFromRevisionDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                              ByVal MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions,
                                                              ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                              ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision,
                                                              ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail,
                                                              ByVal AdServingVendorCode As String) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing

            MediaATBRevisionDetails = New Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail)

            MediaATBRevisionDetails.Add(MediaATBRevisionDetail)

            CreateImportOrdersFromRevisionDetail = CreateImportOrdersFromRevisionDetails(DbContext, DataContext, MediaATBOrderOption, MediaATB, MediaATBRevision, MediaATBRevisionDetails, AdServingVendorCode)

        End Function
        Private Sub FillImportOrderFromMediaATB(ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            If MediaATB IsNot Nothing AndAlso ImportOrder IsNot Nothing Then

                FillImportOrderFromMediaATB(MediaATB.ClientCode, MediaATB.DivisionCode, MediaATB.ProductCode, ImportOrder)

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATB(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            If ImportOrder IsNot Nothing Then

                ImportOrder.ClientCode = ClientCode
                ImportOrder.DivisionCode = DivisionCode
                ImportOrder.ProductCode = ProductCode

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATBRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision,
                                                        ByVal MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions, ByVal IsAdServing As Boolean, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim CampaignCode As String = Nothing

            If MediaATBRevision IsNot Nothing AndAlso ImportOrder IsNot Nothing Then

                If MediaATBRevision.Campaign IsNot Nothing Then

                    CampaignCode = MediaATBRevision.Campaign.Code

                ElseIf MediaATBRevision.CampaignID.HasValue Then

                    Try

                        CampaignCode = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaATBRevision.CampaignID).Code

                    Catch ex As Exception

                    End Try

                End If

                FillImportOrderFromMediaATBRevision(MediaATBRevision.Description, MediaATBRevision.SalesClassCode, MediaATBRevision.ClientPO, MediaATBRevision.BuyGrossOrNetFlag.GetValueOrDefault(0), CampaignCode, MediaATBRevision.CampaignStartDate, MediaATBRevision.CampaignEndDate, MediaATBOrderOption, IsAdServing, ImportOrder)

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATBRevision(ByVal Description As String, ByVal SalesClassCode As String, ByVal ClientPO As String, ByVal BuyGrossOrNet As Integer,
                                                        ByVal CampaignCode As String, ByVal StartDate As Date?, ByVal EndDate As Date?,
                                                        ByVal MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions, ByVal IsAdServing As Boolean, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim LineDescription As String = ""

            If ImportOrder IsNot Nothing Then

                If IsAdServing Then

                    If MediaATBOrderOption = Database.Entities.MediaATBOrderOptions.SeparateForAdServing Then

                        Description = "Ad Serving"

                    ElseIf MediaATBOrderOption = Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder Then

                        LineDescription = "Ad Serving"

                    End If

                End If

                FillImportOrderFromMediaATBRevision(Description, SalesClassCode, ClientPO, BuyGrossOrNet, CampaignCode, StartDate, EndDate, LineDescription, ImportOrder)

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATBRevision(ByVal Description As String, ByVal SalesClassCode As String, ByVal ClientPO As String, ByVal BuyGrossOrNet As Integer,
                                                        ByVal CampaignCode As String, ByVal StartDate As Date?, ByVal EndDate As Date?, ByVal LineDescription As String,
                                                        ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            If ImportOrder IsNot Nothing Then

                ImportOrder.MediaPlanOrderDescription = Description
                ImportOrder.LineDescription = LineDescription
                ImportOrder.SalesClassCode = SalesClassCode
                ImportOrder.ClientPO = ClientPO
                ImportOrder.NetGross = BuyGrossOrNet
                ImportOrder.CampaignCode = CampaignCode
                ImportOrder.StartDate = StartDate
                ImportOrder.EndDate = EndDate

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATBRevisionDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                              ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB,
                                                              ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail,
                                                              ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                                              ByVal IncludeNetChargeAmount As Boolean)

            'objects
            Dim NetChargeAmount As Decimal? = Nothing

            If MediaATBRevisionDetail IsNot Nothing AndAlso ImportOrder IsNot Nothing Then

                If IncludeNetChargeAmount Then

                    NetChargeAmount = MediaATBRevisionDetail.NetChargeAmount

                End If

                FillImportOrderFromMediaATBRevisionDetail(MediaATBRevisionDetail.VendorCode, MediaATBRevisionDetail.Quantity, MediaATBRevisionDetail.Rate, MediaATBRevisionDetail.CostType, MediaATBRevisionDetail.Amount, NetChargeAmount, MediaATBRevisionDetail.MarkupPercent, ImportOrder)

                ImportOrder.MediaPlanDetailLevelLineDataIDs = FormatATBLineLevelID(MediaATBRevisionDetail.DetailID)

            End If

        End Sub
        Private Sub FillImportOrderFromMediaATBRevisionDetail(ByVal VendorCode As String, ByVal Quantity As Integer?, ByVal Rate As Decimal?, ByVal CostType As String,
                                                              ByVal Amount As Decimal?, ByVal NetChargeAmount As Decimal?, ByVal MarkupPercent As Decimal?,
                                                              ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim RateOrAmount As Decimal? = Nothing

            If ImportOrder IsNot Nothing Then

                ImportOrder.VendorCode = VendorCode

                If String.IsNullOrWhiteSpace(CostType) Then

                    ImportOrder.CostType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).Code

                Else

                    ImportOrder.CostType = CostType

                End If

                If Quantity.HasValue AndAlso Quantity.GetValueOrDefault(0) > 0 Then

                    ImportOrder.TotalSpots = Quantity

                End If

                If Rate.HasValue AndAlso Rate.GetValueOrDefault(0) > 0 Then

                    RateOrAmount = Rate

                Else

                    RateOrAmount = Amount

                End If

                If ImportOrder.NetGross.GetValueOrDefault(0) = 0 Then

                    ImportOrder.NetRate = RateOrAmount
                    ImportOrder.GrossRate = RateOrAmount

                ElseIf ImportOrder.NetGross.GetValueOrDefault(0) = 1 Then

                    ImportOrder.NetRate = RateOrAmount
                    ImportOrder.GrossRate = RateOrAmount

                End If

                ImportOrder.MediaNetAmount = Amount
                ImportOrder.NetCharge = NetChargeAmount
                ImportOrder.MarkupPercent = MarkupPercent

            End If

        End Sub
        Private Function FormatATBLineLevelID(ByVal LineID As Integer) As String

            FormatATBLineLevelID = FormatATBLineLevelIDs({LineID})

        End Function
        Private Function FormatATBLineLevelIDs(ByVal LineIDs As Integer()) As String

            FormatATBLineLevelIDs = String.Join(",", LineIDs.Select(Function(ID) "A" & ID.ToString).ToArray)

        End Function
        Private Function SplitImportOrderByMonth(ByVal ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim SplitImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

            SplitImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            For Each ImportOrder In ImportOrders

                ImportOrderList = SplitImportOrderByMonth(ImportOrder)

                If ImportOrderList IsNot Nothing AndAlso ImportOrderList.Count > 0 Then

                    SplitImportOrderList.AddRange(ImportOrderList)

                End If

            Next

            SplitImportOrderByMonth = SplitImportOrderList

        End Function
        Private Function SplitImportOrderByMonth(ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim NewImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim SplitNetAmount As Decimal? = Nothing
            Dim SplitNetCharge As Decimal? = Nothing
            Dim MonthDifference As Integer = 0
            Dim ImportOrderStartDate As Date = Nothing
            Dim ImportOrderEndDate As Date = Nothing
            Dim SplitQuantity As Decimal? = Nothing
            Dim Rate As Decimal? = Nothing
            Dim CostType As String = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Try

                If ImportOrder.StartDate.HasValue AndAlso ImportOrder.EndDate.HasValue Then

                    StartDate = ImportOrder.StartDate.Value.AddDays(-ImportOrder.StartDate.Value.Day).AddDays(1) 'first day of start month
                    EndDate = ImportOrder.EndDate.Value.AddDays(-ImportOrder.EndDate.Value.Day).AddDays(1) 'first day of end month

                    If StartDate < EndDate Then

                        While StartDate <= EndDate

                            MonthDifference = MonthDifference + 1

                            StartDate = StartDate.AddMonths(1)

                        End While

                        StartDate = StartDate.AddMonths(-MonthDifference) 'reset start date

                    End If

                    If ImportOrder.NetCharge.HasValue Then

                        SplitNetCharge = Math.Round(ImportOrder.NetCharge.Value / MonthDifference, 2, MidpointRounding.AwayFromZero)

                    End If

                    If ImportOrder.MediaNetAmount.HasValue Then

                        SplitNetAmount = Math.Round(ImportOrder.MediaNetAmount.Value / MonthDifference, 2, MidpointRounding.AwayFromZero)

                    End If

                    If ImportOrder.TotalSpots.HasValue Then

                        SplitQuantity = CInt(Math.Round(ImportOrder.TotalSpots.Value / MonthDifference, 0, MidpointRounding.AwayFromZero))

                    End If

                    If String.IsNullOrWhiteSpace(ImportOrder.CostType) = False Then

                        CostType = ImportOrder.CostType

                    Else

                        CostType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Media.CostType.NotApplicable).ToString

                    End If

                    If ImportOrder.NetGross.GetValueOrDefault(0) = 0 Then

                        Rate = ImportOrder.NetRate

                    Else

                        Rate = ImportOrder.GrossRate

                    End If

                    While StartDate <= EndDate

                        If StartDate = EndDate Then

                            ImportOrderStartDate = EndDate 'end date holds first day of month
                            ImportOrderEndDate = ImportOrder.EndDate

                            'adjust final values in case of rounding error
                            If ImportOrder.NetCharge.HasValue Then

                                SplitNetCharge = ImportOrder.NetCharge - ((MonthDifference - 1) * SplitNetCharge)

                            End If

                            If ImportOrder.MediaNetAmount.HasValue Then

                                SplitNetAmount = ImportOrder.MediaNetAmount - ((MonthDifference - 1) * SplitNetAmount)

                            End If

                            If ImportOrder.TotalSpots.HasValue Then

                                SplitQuantity = ImportOrder.TotalSpots - ((MonthDifference - 1) * SplitQuantity)

                            End If

                        Else

                            If StartDate.Month = ImportOrder.StartDate.Value.Month Then

                                ImportOrderStartDate = ImportOrder.StartDate

                            Else

                                ImportOrderStartDate = StartDate

                            End If

                            ImportOrderEndDate = StartDate.AddMonths(1).AddDays(-1)

                        End If

                        NewImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                        NewImportOrder.ImportSource = ImportSource.AuthorizationToBuy
                        NewImportOrder.MediaType = "I"

                        FillImportOrderFromMediaATB(ImportOrder.ClientCode, ImportOrder.DivisionCode, ImportOrder.ProductCode, NewImportOrder)
                        FillImportOrderFromMediaATBRevision(ImportOrder.MediaPlanOrderDescription, ImportOrder.SalesClassCode, ImportOrder.ClientPO, ImportOrder.NetGross, ImportOrder.CampaignCode, ImportOrderStartDate, ImportOrderEndDate, ImportOrder.LineDescription, NewImportOrder)
                        FillImportOrderFromMediaATBRevisionDetail(ImportOrder.VendorCode, SplitQuantity, Rate, CostType, SplitNetAmount, SplitNetCharge, ImportOrder.MarkupPercent, NewImportOrder)

                        NewImportOrder.MediaPlanDetailLevelLineDataIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs

                        ImportOrderList.Add(NewImportOrder)

                        StartDate = StartDate.AddMonths(1)

                    End While

                Else

                    ImportOrderList.Add(ImportOrder)

                End If

            Catch ex As Exception
                ImportOrderList = Nothing
            Finally
                SplitImportOrderByMonth = ImportOrderList
            End Try

        End Function
        Private Sub LoadAssociatedMediaATBRevisionDetailOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                              ByVal ATBNumber As Integer, ByVal CurrentRevisionID As Integer,
                                                              ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim OrderedMediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim MaxRevisionIDWithOrders As Integer = 0
            Dim OrderedRevisionDetailID As Integer = Nothing
            Dim NotOrderedRevisionDetailID As Integer = Nothing
            Dim MediaATBRevisionDetailIDs As Integer() = Nothing
            Dim VendorCode As String = ""
            Dim OrderMonth As Integer = Nothing
            Dim OrderYear As Integer = Nothing

            Try

                VendorCode = ImportOrder.VendorCode
                OrderMonth = ImportOrder.StartDate.Value.Month
                OrderYear = ImportOrder.StartDate.Value.Year

                MediaATBRevisionDetailIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs.Replace("A", "").Split(",").Select(Function(ID) CInt(ID)).ToArray

                If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                    Where MediaATBRevisionDetailIDs.Contains(Entity.DetailID)
                    Select Entity).Any = True Then

                    'order has been placed for current detail
                    MediaATBRevisionDetailOrder = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                   Where MediaATBRevisionDetailIDs.Contains(Entity.DetailID) AndAlso
                                                         Entity.OrderMonth = OrderMonth AndAlso
                                                         Entity.OrderYear = OrderYear
                                                   Select Entity).FirstOrDefault

                Else

                    Try

                        MaxRevisionIDWithOrders = DbContext.Database.SqlQuery(Of Integer)(String.Format(" SELECT ISNULL(MAX(ATB_REV.ATB_REV_ID), 0) FROM dbo.ATB_REV JOIN " &
                                                                                                            " dbo.ATB_REV_DTL ON ATB_REV.ATB_REV_ID = ATB_REV_DTL.ATB_REV_ID JOIN " &
                                                                                                            " dbo.ATB_REV_DTL_ORDER ON ATB_REV_DTL.ATB_REV_DTL_ID = ATB_REV_DTL_ORDER.ATB_REV_DTL_ID " &
                                                                                                            " WHERE ATB_REV.ATB_NUMBER = {0} ", ATBNumber)).SingleOrDefault

                    Catch ex As Exception
                        MaxRevisionIDWithOrders = 0
                    End Try

                    If MaxRevisionIDWithOrders > 0 AndAlso MaxRevisionIDWithOrders <> CurrentRevisionID Then

                        If ImportOrder.LineDescription = "Ad Serving" Then

                            OrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                                       Where Entity.VendorCode = VendorCode AndAlso
                                                             Entity.AdServingForDetailID IsNot Nothing
                                                       Select Entity.DetailID).FirstOrDefault

                        Else

                            OrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                                       Where Entity.VendorCode = VendorCode
                                                       Select Entity.DetailID).FirstOrDefault

                        End If

                        If OrderedRevisionDetailID > 0 Then

                            MediaATBRevisionDetailOrder = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                           Where Entity.DetailID = OrderedRevisionDetailID AndAlso
                                                                 Entity.OrderMonth = OrderMonth AndAlso
                                                                 Entity.OrderYear = OrderYear
                                                           Select Entity).FirstOrDefault

                        End If

                    End If

                End If

                If MediaATBRevisionDetailOrder IsNot Nothing Then

                    ImportOrder.OrderID = MediaATBRevisionDetailOrder.OrderID
                    ImportOrder.LineNumber = MediaATBRevisionDetailOrder.OrderLineID

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadAssociatedMediaATBRevisionDetailOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                              ByVal ATBNumber As Integer,
                                                              ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail,
                                                              ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim OrderedMediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim MaxRevisionIDWithOrders As Integer = 0
            Dim OrderedRevisionDetailID As Integer = Nothing
            Dim NotOrderedRevisionDetailID As Integer = Nothing
            Dim MediaATBRevisionDetailIDs As Integer() = Nothing
            Dim VendorCode As String = ""
            Dim OrderMonth As Integer = Nothing
            Dim OrderYear As Integer = Nothing

            Try

                VendorCode = ImportOrder.VendorCode
                OrderMonth = ImportOrder.StartDate.Value.Month
                OrderYear = ImportOrder.StartDate.Value.Year

                MediaATBRevisionDetailIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs.Replace("A", "").Split(",").Select(Function(ID) CInt(ID)).ToArray

                If (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                    Where MediaATBRevisionDetailIDs.Contains(Entity.DetailID)
                    Select Entity).Any = True Then

                    'order has been placed for current detail
                    MediaATBRevisionDetailOrder = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                   Where MediaATBRevisionDetailIDs.Contains(Entity.DetailID) AndAlso
                                                         Entity.OrderMonth = OrderMonth AndAlso
                                                         Entity.OrderYear = OrderYear
                                                   Select Entity).FirstOrDefault

                Else

                    Try

                        MaxRevisionIDWithOrders = DbContext.Database.SqlQuery(Of Integer)(String.Format(" SELECT ISNULL(MAX(ATB_REV.ATB_REV_ID), 0) FROM dbo.ATB_REV JOIN " &
                                                                                                            " dbo.ATB_REV_DTL ON ATB_REV.ATB_REV_ID = ATB_REV_DTL.ATB_REV_ID JOIN " &
                                                                                                            " dbo.ATB_REV_DTL_ORDER ON ATB_REV_DTL.ATB_REV_DTL_ID = ATB_REV_DTL_ORDER.ATB_REV_DTL_ID " &
                                                                                                            " WHERE ATB_REV.ATB_NUMBER = {0} ", ATBNumber)).SingleOrDefault

                    Catch ex As Exception
                        MaxRevisionIDWithOrders = 0
                    End Try

                    If MaxRevisionIDWithOrders > 0 AndAlso MaxRevisionIDWithOrders <> MediaATBRevisionDetail.RevisionID Then

                        If MediaATBRevisionDetail.AdServingForDetailID.GetValueOrDefault(0) > 0 Then

                            OrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                                       Where Entity.VendorCode = VendorCode AndAlso
                                                             Entity.AdServingForDetailID IsNot Nothing
                                                       Select Entity.DetailID).FirstOrDefault

                        Else

                            OrderedRevisionDetailID = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MaxRevisionIDWithOrders)
                                                       Where Entity.VendorCode = VendorCode
                                                       Select Entity.DetailID).FirstOrDefault

                        End If

                        If OrderedRevisionDetailID > 0 Then

                            MediaATBRevisionDetailOrder = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                           Where Entity.DetailID = OrderedRevisionDetailID AndAlso
                                                                 Entity.OrderMonth = OrderMonth AndAlso
                                                                 Entity.OrderYear = OrderYear
                                                           Select Entity).FirstOrDefault

                        End If

                    End If

                End If

                If MediaATBRevisionDetailOrder IsNot Nothing Then

                    ImportOrder.OrderID = MediaATBRevisionDetailOrder.OrderID
                    ImportOrder.LineNumber = MediaATBRevisionDetailOrder.OrderLineID
                    ImportOrder.OrderNumber = MediaATBRevisionDetailOrder.OrderNumber
                    ImportOrder.OrderLineNumber = MediaATBRevisionDetailOrder.OrderLineNumber

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub CreateMediaATBRevisionDetailOrdersFromImportOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                      ByRef ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder))

            'objects
            Dim MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
            Dim MediaATBRevisionDetailOrderIDList As Generic.List(Of Integer) = Nothing
            Dim IsNew As Boolean = False
            Dim DetailID As Integer = Nothing
            Dim OrderMonth As Int16 = Nothing
            Dim OrderYear As Integer = Nothing

            MediaATBRevisionDetailOrderIDList = New Generic.List(Of Integer)

            For Each ImportOrder In ImportOrders

                MediaATBRevisionDetailOrderIDList.Clear()

                For Each ATBRevisionDetailID In ImportOrder.MediaPlanDetailLevelLineDataIDs.Split(",")

                    DetailID = CInt(ATBRevisionDetailID.Replace("A", ""))
                    OrderMonth = ImportOrder.StartDate.Value.Month
                    OrderYear = ImportOrder.StartDate.Value.Year

                    Try

                        MediaATBRevisionDetailOrder = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext)
                                                       Where Entity.DetailID = DetailID AndAlso
                                                             Entity.OrderMonth = OrderMonth AndAlso
                                                             Entity.OrderYear = OrderYear
                                                       Select Entity).SingleOrDefault

                    Catch ex As Exception
                        MediaATBRevisionDetailOrder = Nothing
                    End Try

                    If MediaATBRevisionDetailOrder Is Nothing Then

                        IsNew = True
                        MediaATBRevisionDetailOrder = New AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder

                    End If

                    MediaATBRevisionDetailOrder.DetailID = DetailID
                    MediaATBRevisionDetailOrder.OrderMonth = ImportOrder.StartDate.Value.Month
                    MediaATBRevisionDetailOrder.OrderYear = ImportOrder.StartDate.Value.Year
                    MediaATBRevisionDetailOrder.OrderID = ImportOrder.OrderID
                    MediaATBRevisionDetailOrder.OrderLineID = ImportOrder.LineNumber
                    MediaATBRevisionDetailOrder.OrderNumber = ImportOrder.OrderNumber
                    MediaATBRevisionDetailOrder.OrderLineNumber = ImportOrder.OrderLineNumber

                    If MediaATBRevisionDetailOrder.OrderNumber.GetValueOrDefault(0) = 0 Then

                        MediaATBRevisionDetailOrder.OrderNumber = Nothing

                    End If

                    If MediaATBRevisionDetailOrder.OrderLineNumber.GetValueOrDefault(0) = 0 Then

                        MediaATBRevisionDetailOrder.OrderLineNumber = Nothing

                    End If

                    If IsNew Then

                        AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Insert(DbContext, DataContext, MediaATBRevisionDetailOrder)

                    Else

                        AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Update(DbContext, DataContext, MediaATBRevisionDetailOrder)

                    End If

                    MediaATBRevisionDetailOrderIDList.Add(MediaATBRevisionDetailOrder.ID)

                Next

                ImportOrder.MediaPlanDetailLevelLineDataIDs = FormatATBLineLevelIDs(MediaATBRevisionDetailOrderIDList.ToArray)

            Next

        End Sub
        Private Function GetNextRevisisionNumber(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal MediaInterface As String) As Integer

            'objects
            Dim RevisionNumber As Integer = 0

            Try

                RevisionNumber = (From Entity In DataContext.PrintOrders
                                  Select [RN] = Entity.RevisionNumber).Max + 1

            Catch ex As Exception
                RevisionNumber = 0
            End Try

            GetNextRevisisionNumber = RevisionNumber

        End Function
        Private Function GetVendorCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCrossReferenceCode As String, ByVal VendorCategory As String) As String

            'objects
            Dim VendorCode As String = ""

            Try

                For Each Vendor In From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                   Where Entity.VendorCategory = VendorCategory
                                   Select Entity

                    If String.IsNullOrWhiteSpace(Vendor.VendorCodeCrossReference) = False Then

                        If Vendor.VendorCodeCrossReference.ToLower = VendorCrossReferenceCode.ToLower Then

                            VendorCode = Vendor.Code
                            Exit For

                        End If

                    End If

                Next

            Catch ex As Exception
                VendorCode = ""
            Finally

                If String.IsNullOrWhiteSpace(VendorCode) Then

                    VendorCode = VendorCrossReferenceCode

                End If

                GetVendorCode = VendorCode

            End Try

        End Function
        Private Function GetEmployeeName(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As String

            'objects
            Dim EmployeeName As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    EmployeeName = Employee.ToString

                End If

            Catch ex As Exception
                EmployeeName = Nothing
            End Try

            GetEmployeeName = EmployeeName

        End Function
        Private Function GetNextBroadcastRevisionNumber(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal MediaInterface As String, ByVal LinkID As Long, ByVal LineNumber As String) As Integer

            'objects
            Dim NextRevisionNumber As Integer = 0

            'Try

            If (From Entity In DataContext.BroadcastImports
                Where Entity.LinkID = LinkID AndAlso
                      Entity.LineNumber = LineNumber AndAlso
                      Entity.MediaInterface = MediaInterface
                Select Entity.RevisionNumber).Any Then

                NextRevisionNumber = (From Entity In DataContext.BroadcastImports
                                      Where Entity.LinkID = LinkID AndAlso
                                            Entity.LineNumber = LineNumber AndAlso
                                            Entity.MediaInterface = MediaInterface
                                      Select Entity.RevisionNumber).Max + 1

            Else

                NextRevisionNumber = 1

            End If

            'Catch ex As Exception
            '	NextRevisionNumber = 1
            'End Try

            GetNextBroadcastRevisionNumber = NextRevisionNumber

        End Function
        Private Function GetNextPrintRevisionNumber(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal MediaInterface As String, ByVal AccountOrderNumber As Long, ByVal ItemNumber As String) As Integer

            'objects
            Dim RevisionNumber As Integer = 1

            Try

                If (From Entity In DataContext.PrintOrders
                    Where Entity.AccountOrderNumber = AccountOrderNumber AndAlso
                              Entity.ItemNumber = ItemNumber AndAlso
                              Entity.MediaInterface = MediaInterface
                    Select Entity).Any Then

                    RevisionNumber = (From Entity In DataContext.PrintOrders
                                      Where Entity.AccountOrderNumber = AccountOrderNumber AndAlso
                                        Entity.ItemNumber = ItemNumber AndAlso
                                        Entity.MediaInterface = MediaInterface
                                      Select [RN] = Entity.RevisionNumber).Max + 1

                End If

            Catch ex As Exception
                RevisionNumber = 1
            End Try

            GetNextPrintRevisionNumber = RevisionNumber

        End Function

#End Region

#End Region

#Region " Media Order Line Methods "

        Public Function LoadByJobAndComponent(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByVal IncludeAvailableMedia As Boolean, ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            Dim MediaOrders As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)
            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            Dim SqlParameterClientCode As New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            Dim SqlParameterDivisionCode As New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            Dim SqlParameterProductCode As New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            Dim SqlParameterIncludeAvailableMedia As New System.Data.SqlClient.SqlParameter("@INCL_CDP_MEDIA", SqlDbType.Bit)

            SqlParameterUserCode.Value = Session.User.UserCode
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterClientCode.Value = System.DBNull.Value
            SqlParameterDivisionCode.Value = System.DBNull.Value
            SqlParameterProductCode.Value = System.DBNull.Value
            SqlParameterIncludeAvailableMedia.Value = IncludeAvailableMedia

            MediaOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.Media.Classes.MediaOrderLine)("EXEC advsp_media_order_lines @USER_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @CL_CODE, @DIV_CODE, @PRD_CODE, @INCL_CDP_MEDIA;",
                                                                             SqlParameterUserCode,
                                                                             SqlParameterJobNumber,
                                                                             SqlParameterJobComponentNumber,
                                                                             SqlParameterClientCode,
                                                                             SqlParameterDivisionCode,
                                                                             SqlParameterProductCode,
                                                                             SqlParameterIncludeAvailableMedia).ToList()

            If MediaOrders Is Nothing Then MediaOrders = New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            LoadByJobAndComponent = MediaOrders

        End Function
        Public Function LoadByAvailableByClientDivisionProduct(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            Dim MediaOrders As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)
            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            Dim SqlParameterClientCode As New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            Dim SqlParameterDivisionCode As New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            Dim SqlParameterProductCode As New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            Dim SqlParameterIncludeAvailableMedia As New System.Data.SqlClient.SqlParameter("@INCL_CDP_MEDIA", SqlDbType.Bit)

            SqlParameterUserCode.Value = System.DBNull.Value
            SqlParameterJobNumber.Value = System.DBNull.Value
            SqlParameterJobComponentNumber.Value = System.DBNull.Value
            SqlParameterClientCode.Value = ClientCode
            SqlParameterDivisionCode.Value = DivisionCode
            SqlParameterProductCode.Value = ProductCode
            SqlParameterIncludeAvailableMedia.Value = True

            MediaOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.Media.Classes.MediaOrderLine)("EXEC advsp_media_order_lines @USER_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @CL_CODE, @DIV_CODE, @PRD_CODE, @INCL_CDP_MEDIA;",
                                                                             SqlParameterUserCode,
                                                                             SqlParameterJobNumber,
                                                                             SqlParameterJobComponentNumber,
                                                                             SqlParameterClientCode,
                                                                             SqlParameterDivisionCode,
                                                                             SqlParameterProductCode,
                                                                             SqlParameterIncludeAvailableMedia).ToList()

            If MediaOrders Is Nothing Then MediaOrders = New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            LoadByAvailableByClientDivisionProduct = MediaOrders

        End Function
        Public Function LoadByAvailableByClientDivisionProduct(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            Dim MediaOrders As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)
            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            Dim SqlParameterClientCode As New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            Dim SqlParameterDivisionCode As New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            Dim SqlParameterProductCode As New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            Dim SqlParameterIncludeAvailableMedia As New System.Data.SqlClient.SqlParameter("@INCL_CDP_MEDIA", SqlDbType.Bit)

            SqlParameterUserCode.Value = System.DBNull.Value
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterClientCode.Value = System.DBNull.Value
            SqlParameterDivisionCode.Value = System.DBNull.Value
            SqlParameterProductCode.Value = System.DBNull.Value
            SqlParameterIncludeAvailableMedia.Value = True

            MediaOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.Media.Classes.MediaOrderLine)("EXEC advsp_media_order_lines @USER_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @CL_CODE, @DIV_CODE, @PRD_CODE, @INCL_CDP_MEDIA;",
                                                                             SqlParameterUserCode,
                                                                             SqlParameterJobNumber,
                                                                             SqlParameterJobComponentNumber,
                                                                             SqlParameterClientCode,
                                                                             SqlParameterDivisionCode,
                                                                             SqlParameterProductCode,
                                                                             SqlParameterIncludeAvailableMedia).ToList()

            If MediaOrders Is Nothing Then MediaOrders = New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

            LoadByAvailableByClientDivisionProduct = MediaOrders

        End Function
        Public Function LoadMediaProcessControls(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess)

            'Dim MediaProcess As Integer() = {1, 5, 6, 12, 13} 
            Dim MediaProcess As Integer() = {1, 6, 13}

            LoadMediaProcessControls = (From JobProcess In DataContext.JobProcesses
                                        Where MediaProcess.Contains(JobProcess.ID)
                                        Select JobProcess).ToList()

        End Function

#End Region

#Region " eOMG "

        Private Function GetPriorMonday(StartDate As Date) As Date

            Dim PriorMonday As Date = Nothing

            Select Case StartDate.DayOfWeek

                Case DayOfWeek.Monday
                    PriorMonday = StartDate

                Case DayOfWeek.Tuesday
                    PriorMonday = StartDate.AddDays(-1)

                Case DayOfWeek.Wednesday
                    PriorMonday = StartDate.AddDays(-2)

                Case DayOfWeek.Thursday
                    PriorMonday = StartDate.AddDays(-3)

                Case DayOfWeek.Friday
                    PriorMonday = StartDate.AddDays(-4)

                Case DayOfWeek.Saturday
                    PriorMonday = StartDate.AddDays(-5)

                Case DayOfWeek.Sunday
                    PriorMonday = StartDate.AddDays(-6)

            End Select

            GetPriorMonday = PriorMonday

        End Function
        Private Function GetTime(Time As String, Optional ByVal IncludeSeconds As Boolean = True) As String

            Dim TimeHour As Integer = 0
            Dim TimeMinutes As String = String.Empty
            Dim ReturnTime As String = String.Empty

            If Not String.IsNullOrWhiteSpace(Time) Then

                Try

                    TimeHour = Mid(Time, 1, 2)
                    TimeMinutes = Mid(Time, 4, 2)

                    If TimeHour = 12 AndAlso Mid(Time, 7, 2) = "AM" Then

                        TimeHour = 0

                    ElseIf TimeHour <> 12 AndAlso Mid(Time, 7, 2) = "PM" Then

                        TimeHour += 12

                    End If

                    If IncludeSeconds Then

                        ReturnTime = TimeHour.ToString.PadLeft(2, "0") & ":" & TimeMinutes.ToString & ":00"

                    Else

                        ReturnTime = TimeHour.ToString.PadLeft(2, "0") & ":" & TimeMinutes.ToString

                    End If

                Catch ex As Exception

                End Try

            End If

            GetTime = ReturnTime

        End Function
        Private Function CreateSpot(LineNumber As Short, WeekNumber As Integer, Spots As Nullable(Of Short)) As AdvantageFramework.Media.Classes.spot

            Dim spot As AdvantageFramework.Media.Classes.spot = Nothing

            spot = New AdvantageFramework.Media.Classes.spot
            spot.id = LineNumber.ToString & WeekNumber.ToString
            spot.quantity = Spots.GetValueOrDefault(0)
            spot.weekNumber = WeekNumber.ToString

            CreateSpot = spot

        End Function
        Private Function GetSpotArray(TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail, MaxWeekNumber As Integer, week() As AdvantageFramework.Media.Classes.week) As AdvantageFramework.Media.Classes.spot()

            Dim spotList As Generic.List(Of AdvantageFramework.Media.Classes.spot) = Nothing

            spotList = New Generic.List(Of AdvantageFramework.Media.Classes.spot)

            For MaxWeekCounter As Integer = 1 To MaxWeekNumber

                If TVOrderDetail.Date1.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date1.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots1))

                ElseIf TVOrderDetail.Date2.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date2.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots2))

                ElseIf TVOrderDetail.Date3.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date3.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots3))

                ElseIf TVOrderDetail.Date4.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date4.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots4))

                ElseIf TVOrderDetail.Date5.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date5.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots5))

                ElseIf TVOrderDetail.Date6.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date6.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots6))

                ElseIf TVOrderDetail.Date7.HasValue AndAlso week(MaxWeekCounter - 1).startDate = GetPriorMonday(TVOrderDetail.Date7.Value) Then

                    spotList.Add(CreateSpot(TVOrderDetail.LineNumber, MaxWeekCounter, TVOrderDetail.Spots7))

                End If

            Next

            GetSpotArray = spotList.ToArray

        End Function
        Public Function BuildXMLFile(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                     OrderNumber As Integer, VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep), VendorCode As String) As System.IO.MemoryStream

            Dim adx As AdvantageFramework.Media.Classes.adx = Nothing
            Dim campaignkey(4) As AdvantageFramework.Media.Classes.key
            Dim orderkey(3) As AdvantageFramework.Media.Classes.key
            Dim systemorderkey(1) As AdvantageFramework.Media.Classes.key
            Dim company(1) As AdvantageFramework.Media.Classes.company '1 for type=Rep (Vendor) and 1 for type=Agency (Agency)
            Dim repoffice(0) As AdvantageFramework.Media.Classes.office
            Dim agencyoffice(0) As AdvantageFramework.Media.Classes.office
            Dim state As AdvantageFramework.Media.Classes.state = Nothing
            Dim repofficephone() As AdvantageFramework.Media.Classes.phone = Nothing
            Dim RepPhones As Generic.List(Of AdvantageFramework.Media.Classes.phone) = Nothing
            Dim phone As AdvantageFramework.Media.Classes.phone = Nothing
            Dim contact() As AdvantageFramework.Media.Classes.contact = Nothing
            Dim advertisercodeComplexType(0) As AdvantageFramework.Media.Classes.codeComplexType
            Dim productcodeComplexType(0) As AdvantageFramework.Media.Classes.codeComplexType
            Dim estimatecodeComplexType As AdvantageFramework.Media.Classes.codeComplexType = Nothing
            Dim makegoodcodeComplexType(0) As AdvantageFramework.Media.Classes.codeComplexType
            Dim product As AdvantageFramework.Media.Classes.product = Nothing
            Dim demo(0) As AdvantageFramework.Media.Classes.demo
            Dim demoNameComplexTypeGroup As AdvantageFramework.Media.Classes.demoNameComplexTypeGroup = Nothing
            Dim populations(0) As AdvantageFramework.Media.Classes.populations
            Dim order(0) As AdvantageFramework.Media.Classes.order
            'Dim breakoutMonth() As AdvantageFramework.Media.Classes.breakoutMonth = Nothing
            Dim systemOrder(0) As AdvantageFramework.Media.Classes.systemOrder
            Dim system2(0) As AdvantageFramework.Media.Classes.system2
            Dim week() As AdvantageFramework.Media.Classes.week = Nothing
            Dim detailLine() As AdvantageFramework.Media.Classes.detailLine = Nothing
            Dim networkcodeComplexTypeList As Generic.List(Of AdvantageFramework.Media.Classes.codeComplexType) = Nothing
            Dim codeComplexType As AdvantageFramework.Media.Classes.codeComplexType = Nothing
            Dim networkList As Generic.List(Of AdvantageFramework.Media.Classes.network) = Nothing
            Dim network As AdvantageFramework.Media.Classes.network = Nothing
            Dim demoValue As AdvantageFramework.Media.Classes.demoValue = Nothing
            Dim demoValueValue As AdvantageFramework.Media.Classes.demoValueValue = Nothing
            Dim demoValueValueList As Generic.List(Of AdvantageFramework.Media.Classes.demoValueValue) = Nothing
            Dim surveyComment As AdvantageFramework.Media.Classes.surveyComment = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim BreakoutMonths As Generic.List(Of AdvantageFramework.Media.BreakoutMonth) = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim NCCTVCablenet As AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet = Nothing
            Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim StartDate As Date = Nothing
            Dim WeekNumber As Integer = 0

            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If VendorReps IsNot Nothing AndAlso VendorReps.Count > 0 Then

                ReDim contact(VendorReps.Count - 1)

            End If

            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

            MediaBroadcastWorksheetMarketDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic")
                                                       Where Entity.OrderNumber = OrderNumber
                                                       Select Entity).FirstOrDefault

            MediaBroadcastWorksheet = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet

            adx = New AdvantageFramework.Media.Classes.adx()

            adx.document = New AdvantageFramework.Media.Classes.document
            adx.document.schemaVersion = "1.0"
            adx.document.name = MediaBroadcastWorksheet.Name
            adx.document.date = Now.ToString("yyyy-MM-dd")
            adx.document.mediaType = AdvantageFramework.Media.Classes.documentMediaType.Spotcable
            adx.document.documentType = ""
            adx.document.documentCode = ""

            adx.campaign = New AdvantageFramework.Media.Classes.campaign

            campaignkey(0) = New AdvantageFramework.Media.Classes.key
            campaignkey(0).codeOwner = "NCC"
            campaignkey(0).codeDescription = "CampaignID"
            campaignkey(0).id = ""

            campaignkey(1) = New AdvantageFramework.Media.Classes.key
            campaignkey(1).codeOwner = "Strata"
            campaignkey(1).codeDescription = "DMA Override"
            campaignkey(1).id = "0"

            campaignkey(2) = New AdvantageFramework.Media.Classes.key
            campaignkey(2).codeOwner = "Strata"
            campaignkey(2).codeDescription = "Zone Pops"
            campaignkey(2).id = "sum"

            campaignkey(3) = New AdvantageFramework.Media.Classes.key
            campaignkey(3).codeOwner = "VIEW32"
            campaignkey(3).codeDescription = "CampaignName"
            campaignkey(3).id = MediaBroadcastWorksheet.Name

            campaignkey(4) = New AdvantageFramework.Media.Classes.key
            campaignkey(4).codeOwner = "Strata"
            campaignkey(4).codeDescription = "distro"
            campaignkey(4).id = "bc"

            adx.campaign.key = campaignkey

            adx.campaign.dateRange = New AdvantageFramework.Media.Classes.dateRange
            adx.campaign.dateRange.startDate = TVOrder.StartDate.Value.ToString("yyyy-MM-dd")
            adx.campaign.dateRange.endDate = TVOrder.EndDate.Value.ToString("yyyy-MM-dd")

            'start build company type ="Rep"
            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

            company(0) = New AdvantageFramework.Media.Classes.company
            company(0).type = AdvantageFramework.Media.Classes.companyType.Rep
            company(0).typeSpecified = True

            If IsNumeric(Vendor.Code) Then

                company(0).name = CInt(Vendor.Code).ToString.PadLeft(4, "0")

            Else

                company(0).name = Vendor.Code

            End If

            state = New AdvantageFramework.Media.Classes.state

            If String.IsNullOrWhiteSpace(Vendor.State) Then

                state.code = "__"

            Else

                state.code = Vendor.State

            End If

            repoffice(0) = New AdvantageFramework.Media.Classes.office
            repoffice(0).name = Vendor.Name

            repoffice(0).address = New AdvantageFramework.Media.Classes.address
            repoffice(0).address.type = "mailing"
            repoffice(0).address.country = If(Not String.IsNullOrWhiteSpace(Vendor.Country), Vendor.Country.ToUpper.Replace("USA", "US"), "")
            repoffice(0).address.street = Vendor.StreetAddressLine1
            repoffice(0).address.city = Vendor.City
            repoffice(0).address.state = state
            repoffice(0).address.postalCode = Vendor.ZipCode

            ReDim repofficephone(0)
            repofficephone(0) = New AdvantageFramework.Media.Classes.phone
            repofficephone(0).type = AdvantageFramework.Media.Classes.phoneType.voice

            If Not String.IsNullOrWhiteSpace(Vendor.PhoneNumber) Then

                repofficephone(0).Value = Vendor.PhoneNumber & Space(1) & Vendor.PhoneNumberExtension & ""

                If Not String.IsNullOrWhiteSpace(Vendor.Country) Then

                    repofficephone(0).country = Vendor.Country.ToUpper.Replace("USA", "US")

                End If

            End If

            If Not String.IsNullOrWhiteSpace(Vendor.FaxPhoneNumber) Then

                ReDim Preserve repofficephone(1)
                repofficephone(1) = New AdvantageFramework.Media.Classes.phone
                repofficephone(1).type = AdvantageFramework.Media.Classes.phoneType.fax
                repofficephone(1).Value = Vendor.FaxPhoneNumber & Space(1) & Vendor.FaxPhoneNumberExtension & ""

                If Not String.IsNullOrWhiteSpace(Vendor.Country) Then

                    repofficephone(1).country = Vendor.Country.ToUpper.Replace("USA", "US")

                End If

            End If

            repoffice(0).phone = repofficephone

            company(0).office = repoffice

            For VC As Integer = 0 To VendorReps.Count - 1

                RepPhones = New Generic.List(Of AdvantageFramework.Media.Classes.phone)

                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, VendorReps(VC).VendorRepCode, VendorReps(VC).VendorCode)

                contact(VC) = New AdvantageFramework.Media.Classes.contact
                contact(VC).role = "AE"
                contact(VC).firstName = VendorRepresentative.FirstName
                contact(VC).lastName = VendorRepresentative.LastName

                If Not String.IsNullOrWhiteSpace(VendorRepresentative.EmailAddress) Then

                    contact(VC).email = {VendorRepresentative.EmailAddress}

                End If

                phone = New AdvantageFramework.Media.Classes.phone
                phone.type = AdvantageFramework.Media.Classes.phoneType.voice

                If Not String.IsNullOrWhiteSpace(VendorRepresentative.Telephone) Then

                    phone.Value = VendorRepresentative.Telephone & Space(1) & VendorRepresentative.TelephoneExtension & ""

                    If Not String.IsNullOrWhiteSpace(VendorRepresentative.Country) Then

                        phone.country = VendorRepresentative.Country.ToUpper.Replace("USA", "US")

                    End If

                End If

                RepPhones.Add(phone)

                If Not String.IsNullOrWhiteSpace(VendorRepresentative.Fax) Then

                    phone = New AdvantageFramework.Media.Classes.phone
                    phone.type = AdvantageFramework.Media.Classes.phoneType.fax
                    phone.Value = VendorRepresentative.Fax & Space(1) & VendorRepresentative.FaxExtension & ""

                    If Not String.IsNullOrWhiteSpace(Vendor.Country) Then

                        phone.country = VendorRepresentative.Country.ToUpper.Replace("USA", "US")

                    End If

                    RepPhones.Add(phone)

                End If

                contact(VC).phone = RepPhones.ToArray

            Next

            company(0).contact = contact
            'end build company type ="Rep"

            'start build company type ="Agency"
            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            company(1) = New AdvantageFramework.Media.Classes.company
            company(1).type = AdvantageFramework.Media.Classes.companyType.Agency
            company(1).typeSpecified = True
            company(1).name = Agency.Name

            state = New AdvantageFramework.Media.Classes.state

            If String.IsNullOrWhiteSpace(Agency.State) Then

                state.code = "__"

            Else

                state.code = Agency.State

            End If

            agencyoffice(0) = New AdvantageFramework.Media.Classes.office
            agencyoffice(0).name = Agency.Name

            agencyoffice(0).address = New AdvantageFramework.Media.Classes.address
            agencyoffice(0).address.type = "mailing"
            agencyoffice(0).address.country = If(Not String.IsNullOrWhiteSpace(Agency.Country), Agency.Country.ToUpper.Replace("USA", "US"), "")
            agencyoffice(0).address.street = Agency.Address
            agencyoffice(0).address.city = Agency.City
            agencyoffice(0).address.state = state
            agencyoffice(0).address.postalCode = Agency.Zip

            If Not String.IsNullOrWhiteSpace(Agency.Phone) Then

                phone = New AdvantageFramework.Media.Classes.phone

                phone = New AdvantageFramework.Media.Classes.phone
                phone.type = AdvantageFramework.Media.Classes.phoneType.voice
                phone.Value = Agency.Phone

                If Not String.IsNullOrWhiteSpace(Agency.Country) Then

                    phone.country = Agency.Country.ToUpper.Replace("USA", "US")

                End If

                agencyoffice(0).phone = {phone}

            End If
            company(1).office = agencyoffice

            'end build company type ="Agency"

            adx.campaign.company = company

            advertisercodeComplexType(0) = New AdvantageFramework.Media.Classes.codeComplexType
            advertisercodeComplexType(0).code = New AdvantageFramework.Media.Classes.codeComplexTypeCode
            advertisercodeComplexType(0).code.codeOwner = "Agency"
            advertisercodeComplexType(0).code.Value = TVOrder.ClientCode

            adx.campaign.advertiser = New AdvantageFramework.Media.Classes.advertiser
            adx.campaign.advertiser.name = TVOrder.Product.Client.Name
            adx.campaign.advertiser.ID = advertisercodeComplexType

            productcodeComplexType(0) = New AdvantageFramework.Media.Classes.codeComplexType
            productcodeComplexType(0).code = New AdvantageFramework.Media.Classes.codeComplexTypeCode
            productcodeComplexType(0).code.codeOwner = "Agency"
            productcodeComplexType(0).code.Value = TVOrder.Product.DivisionCode & "_" & TVOrder.ProductCode

            adx.campaign.product = New AdvantageFramework.Media.Classes.product
            adx.campaign.product.name = TVOrder.Product.Name
            adx.campaign.product.ID = productcodeComplexType

            estimatecodeComplexType = New AdvantageFramework.Media.Classes.codeComplexType
            estimatecodeComplexType.code = New AdvantageFramework.Media.Classes.codeComplexTypeCode
            estimatecodeComplexType.code.codeOwner = "Agency"
            estimatecodeComplexType.code.Value = MediaBroadcastWorksheet.ID

            adx.campaign.estimate = New AdvantageFramework.Media.Classes.estimate
            adx.campaign.estimate.desc = MediaBroadcastWorksheet.Name
            adx.campaign.estimate.ID = estimatecodeComplexType

            makegoodcodeComplexType(0) = New AdvantageFramework.Media.Classes.codeComplexType
            makegoodcodeComplexType(0).code = New AdvantageFramework.Media.Classes.codeComplexTypeCode

            adx.campaign.makeGoodPolicy = makegoodcodeComplexType

            If MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                demo(0) = New AdvantageFramework.Media.Classes.demo
                demo(0).demoRank = 1

                If MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales AndAlso MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                    demo(0).group = AdvantageFramework.Media.Classes.demoNameComplexTypeGroup.Adults

                ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsBoys OrElse MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales Then

                    demo(0).group = AdvantageFramework.Media.Classes.demoNameComplexTypeGroup.Men

                ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsGirls OrElse MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                    demo(0).group = AdvantageFramework.Media.Classes.demoNameComplexTypeGroup.Women

                ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsWorkingWomen Then

                    demo(0).group = AdvantageFramework.Media.Classes.demoNameComplexTypeGroup.WWomen

                ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.Description.ToUpper.StartsWith("PERSONS") Then

                    demo(0).group = AdvantageFramework.Media.Classes.demoNameComplexTypeGroup.Persons

                End If

                If MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.HasValue Then

                    demo(0).ageFrom = MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.Value

                End If

                demo(0).ageTo = If(MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.HasValue, MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.Value, 99)

                adx.campaign.demo = demo

            End If

            If MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = 1 Then

                adx.campaign.buyType = AdvantageFramework.Media.Classes.buyType.daily

            ElseIf MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = 2 Then

                adx.campaign.buyType = AdvantageFramework.Media.Classes.buyType.weekly

            End If

            MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                   Where Entity.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetID = MediaBroadcastWorksheet.ID
                                                   Select Entity).OrderByDescending(Function(Entity) Entity.PrimaryUniverse).FirstOrDefault

            If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                If (Vendor.IsNielsenSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen) OrElse
                        (Vendor.IsComscoreSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore) Then

                    populations(0) = New AdvantageFramework.Media.Classes.populations
                    populations(0).demoRank = 1
                    populations(0).Value = MediaBroadcastWorksheetMarketDetail.PrimaryUniverse

                    adx.campaign.populations = populations

                End If

            End If

            order(0) = New AdvantageFramework.Media.Classes.order

            orderkey(0) = New AdvantageFramework.Media.Classes.key
            orderkey(0).codeOwner = "NCC"
            orderkey(0).codeDescription = "Market"
            orderkey(0).id = OrderNumber

            orderkey(1) = New AdvantageFramework.Media.Classes.key
            orderkey(1).codeOwner = ""
            orderkey(1).id = ""

            orderkey(2) = New AdvantageFramework.Media.Classes.key
            orderkey(2).codeOwner = "Strata"
            orderkey(2).codeDescription = "Pops"
            orderkey(2).id = "zone"

            orderkey(3) = New AdvantageFramework.Media.Classes.key
            orderkey(3).codeOwner = "Strata"
            orderkey(3).codeDescription = "UseBroadcastWeeks"
            orderkey(3).id = "1"

            order(0).key = orderkey

            order(0).totals = New AdvantageFramework.Media.Classes.totals
            order(0).totals.cost = New AdvantageFramework.Media.Classes.cost
            order(0).totals.cost.currency = "USD"
            order(0).totals.cost.Value = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                          Select Entity).Sum(Function(Entity) Entity.ExtendedGrossAmount)

            order(0).totals.spots = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                     Select Entity).Sum(Function(Entity) Entity.TotalSpots)

            order(0).market = New AdvantageFramework.Media.Classes.market

            MediaBroadcastWorksheetMarketDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market")
                                                       Where Entity.OrderNumber = OrderNumber
                                                       Select Entity).FirstOrDefault

            Market = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market

            If MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen AndAlso IsNumeric(Market.NielsenTVCode) Then

                order(0).market.nsi_id = Market.NielsenTVCode

            ElseIf MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                order(0).market.nsi_id = Market.ComscoreNewMarketNumber.Value

            End If

            order(0).market.name = Market.Description

            If (Vendor.IsNielsenSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen) OrElse
                    (Vendor.IsComscoreSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore) Then

                order(0).survey = New AdvantageFramework.Media.Classes.survey

                If MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                    order(0).survey.ratingService = "Nielsen"

                ElseIf MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    order(0).survey.ratingService = "Comscore"

                End If

                MediaBroadcastWorksheetMarket = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket

                order(0).survey.geography = If(MediaBroadcastWorksheetMarket.IsCable, "zone", "DMA")
                order(0).survey.shareBook = ""
                order(0).survey.PUTBook = ""
                order(0).survey.profile = ""
                surveyComment = New AdvantageFramework.Media.Classes.surveyComment
                surveyComment.Value = ""
                order(0).survey.comment = {surveyComment}

                If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

                    If Session.IsNielsenSetup Then

                        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value)

                        End Using

                        If NielsenTVBook IsNot Nothing Then

                            order(0).survey.shareBook = NielsenTVBook.Month.ToString & "/" & NielsenTVBook.Year.ToString

                        End If

                    End If

                    If Session.IsComscoreSetup AndAlso NielsenTVBook Is Nothing Then

                        ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value)

                        If ComscoreTVBook IsNot Nothing Then

                            order(0).survey.shareBook = ComscoreTVBook.Month.ToString & "/" & ComscoreTVBook.Year.ToString

                        End If

                    End If

                End If

                If MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.HasValue Then

                    If Session.IsNielsenSetup Then

                        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value)

                        End Using

                        If NielsenTVBook IsNot Nothing Then

                            order(0).survey.PUTBook = NielsenTVBook.Month.ToString & "/" & NielsenTVBook.Year.ToString

                        End If

                    End If

                    If Session.IsComscoreSetup AndAlso NielsenTVBook Is Nothing Then

                        ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value)

                        If ComscoreTVBook IsNot Nothing Then

                            order(0).survey.shareBook = ComscoreTVBook.Month.ToString & "/" & ComscoreTVBook.Year.ToString

                        End If

                    End If

                End If

                order(0).populations = populations

            End If

            order(0).comment = ""

            BreakoutMonths = DbContext.Database.SqlQuery(Of AdvantageFramework.Media.BreakoutMonth)(String.Format("exec dbo.advsp_makegood_xml_breakouts {0}", OrderNumber)).ToList

            'If BreakoutMonths IsNot Nothing AndAlso BreakoutMonths.Count > 0 Then

            '    ReDim breakoutMonth(BreakoutMonths.Count - 1)

            '    For BM As Integer = 0 To BreakoutMonths.Count - 1

            '        breakoutMonth(BM) = New AdvantageFramework.Media.Classes.breakoutMonth
            '        breakoutMonth(BM).yearMonth = BreakoutMonths(BM).Year.ToString & "-" & BreakoutMonths(BM).Month.ToString
            '        breakoutMonth(BM).totals = New AdvantageFramework.Media.Classes.totals
            '        breakoutMonth(BM).totals.spots = BreakoutMonths(BM).Spots

            '        breakoutMonth(BM).totals = New AdvantageFramework.Media.Classes.totals
            '        breakoutMonth(BM).totals.cost = New AdvantageFramework.Media.Classes.cost
            '        breakoutMonth(BM).totals.cost.currency = "USD"
            '        breakoutMonth(BM).totals.cost.Value = BreakoutMonths(BM).Cost

            '    Next

            '    order(0).breakoutMonth = breakoutMonth

            'End If

            systemOrder(0) = New AdvantageFramework.Media.Classes.systemOrder

            systemorderkey(0) = New AdvantageFramework.Media.Classes.key
            systemorderkey(0).codeOwner = ""
            systemorderkey(0).id = ""

            systemorderkey(1) = New AdvantageFramework.Media.Classes.key
            systemorderkey(1).codeOwner = "Strata"
            systemorderkey(1).codeDescription = "UseZonePop"
            systemorderkey(1).id = "true"

            systemOrder(0).key = systemorderkey
            systemOrder(0).comment = Mid(TVOrder.OrderComment, 1, 255)

            If Vendor.NCCTVSyscodeID.HasValue AndAlso Session.IsNielsenSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NCCTVSyscode = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.LoadByID(NielsenDbContext, Vendor.NCCTVSyscodeID.Value)

                End Using

                If NCCTVSyscode IsNot Nothing Then

                    system2(0) = New AdvantageFramework.Media.Classes.system2
                    system2(0).syscode = NCCTVSyscode.Syscode.ToString.PadLeft(4, "0")
                    system2(0).name = NCCTVSyscode.SystemName

                    systemOrder(0).system = system2

                End If

            End If

            systemOrder(0).affiliateSplit = Nothing

            systemOrder(0).populations = populations 'same as above!

            If BreakoutMonths IsNot Nothing AndAlso BreakoutMonths.Count > 0 Then

                systemOrder(0).totals = New AdvantageFramework.Media.Classes.totals
                systemOrder(0).totals.spots = BreakoutMonths.Sum(Function(BM) BM.Spots)

                systemOrder(0).totals.cost = New AdvantageFramework.Media.Classes.cost
                systemOrder(0).totals.cost.currency = "USD"
                systemOrder(0).totals.cost.Value = BreakoutMonths.Sum(Function(BM) BM.Cost)

            End If

            StartDate = GetPriorMonday(TVOrder.StartDate.Value)

            ReDim week(DateDiff(DateInterval.Day, StartDate, TVOrder.EndDate.Value) \ 7)

            While StartDate < TVOrder.EndDate.Value

                week(WeekNumber) = New AdvantageFramework.Media.Classes.week
                week(WeekNumber).number = WeekNumber + 1
                week(WeekNumber).startDate = StartDate.ToString("yyyy-MM-dd")

                WeekNumber += 1

                StartDate = DateAdd(DateInterval.Day, 7, StartDate)

            End While

            systemOrder(0).weeks = New AdvantageFramework.Media.Classes.weeks
            systemOrder(0).weeks.count = WeekNumber
            systemOrder(0).weeks.week = week

            'systemOrder(0).breakoutMonth = breakoutMonth 'same as above

            Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, 1).ToList

            TVOrderDetails = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

            ReDim detailLine(TVOrderDetails.Count - 1)

            For TVOD As Integer = 0 To TVOrderDetails.Count - 1

                Dim DayPartID As Integer? = TVOrderDetails(TVOD).DaypartID
                Dim NetworkID As String = TVOrderDetails(TVOD).NetworkID

                detailLine(TVOD) = New AdvantageFramework.Media.Classes.detailLine
                detailLine(TVOD).detailLineID = CInt(TVOrderDetails(TVOD).TVOrderNumber.ToString & TVOrderDetails(TVOD).LineNumber.ToString.PadLeft(3, "0"))

                If IsDate(GetTime(TVOrderDetails(TVOD).StartTime)) Then

                    detailLine(TVOD).startTime = GetTime(TVOrderDetails(TVOD).StartTime)

                End If

                If IsDate(GetTime(TVOrderDetails(TVOD).EndTime)) Then

                    detailLine(TVOD).endTime = GetTime(TVOrderDetails(TVOD).EndTime)

                End If

                detailLine(TVOD).startDay = AdvantageFramework.Media.Classes.detailLineStartDay.M

                detailLine(TVOD).dayOfWeek = New AdvantageFramework.Media.Classes.dayOfWeek
                detailLine(TVOD).dayOfWeek.Monday = If(TVOrderDetails(TVOD).Monday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Tuesday = If(TVOrderDetails(TVOD).Tuesday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Wednesday = If(TVOrderDetails(TVOD).Wednesday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Thursday = If(TVOrderDetails(TVOD).Thursday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Friday = If(TVOrderDetails(TVOD).Friday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Saturday = If(TVOrderDetails(TVOD).Saturday = 1, "Y", "N")
                detailLine(TVOD).dayOfWeek.Sunday = If(TVOrderDetails(TVOD).Sunday = 1, "Y", "N")

                detailLine(TVOD).length = "PT" & TVOrderDetails(TVOD).Length.GetValueOrDefault(0) & "S"

                If DayPartID.HasValue AndAlso Dayparts.Where(Function(DP) DP.ID = DayPartID.Value).Count = 1 Then

                    detailLine(TVOD).daypartCode = Dayparts.Where(Function(DP) DP.ID = DayPartID.Value).FirstOrDefault.Code

                End If

                detailLine(TVOD).program = TVOrderDetails(TVOD).Programming

                If TVOrderDetails(TVOD).IsBookend AndAlso TVOrderDetails(TVOD).IsAddedValue Then

                    detailLine(TVOD).comment = "Bookend + Added Value"

                ElseIf TVOrderDetails(TVOD).IsBookend Then

                    detailLine(TVOD).comment = "Bookend"

                ElseIf TVOrderDetails(TVOD).IsAddedValue Then

                    detailLine(TVOD).comment += "Added Value"

                End If

                If Not String.IsNullOrWhiteSpace(TVOrderDetails(TVOD).NetworkID) AndAlso (Session.IsNielsenSetup) Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        NCCTVCablenet = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext)
                                         Where Entity.NetworkCode = NetworkID
                                         Select Entity).FirstOrDefault

                        If NCCTVCablenet IsNot Nothing Then

                            networkcodeComplexTypeList = New Generic.List(Of AdvantageFramework.Media.Classes.codeComplexType)

                            codeComplexType = New AdvantageFramework.Media.Classes.codeComplexType
                            codeComplexType.code = New AdvantageFramework.Media.Classes.codeComplexTypeCode

                            If NCCTVCablenet.StationCode.HasValue Then

                                codeComplexType.code.codeDescription = NCCTVCablenet.StationCode.Value

                            Else

                                codeComplexType.code.codeDescription = "0"

                            End If

                            codeComplexType.code.codeOwner = "Spotcable"
                            codeComplexType.code.Value = NCCTVCablenet.NetworkCode
                            networkcodeComplexTypeList.Add(codeComplexType)

                            codeComplexType = New AdvantageFramework.Media.Classes.codeComplexType
                            codeComplexType.code = New AdvantageFramework.Media.Classes.codeComplexTypeCode
                            codeComplexType.code.codeDescription = "Station"
                            codeComplexType.code.codeOwner = "Strata"
                            codeComplexType.code.Value = NCCTVCablenet.NetworkName
                            networkcodeComplexTypeList.Add(codeComplexType)

                            codeComplexType = New AdvantageFramework.Media.Classes.codeComplexType
                            codeComplexType.code = New AdvantageFramework.Media.Classes.codeComplexTypeCode
                            codeComplexType.code.codeDescription = "Band"
                            codeComplexType.code.codeOwner = "Strata"
                            codeComplexType.code.Value = "TV"
                            networkcodeComplexTypeList.Add(codeComplexType)

                            networkList = New Generic.List(Of AdvantageFramework.Media.Classes.network)
                            network = New AdvantageFramework.Media.Classes.network
                            network.ID = networkcodeComplexTypeList.ToArray
                            network.name = NCCTVCablenet.NetworkName
                            networkList.Add(network)

                            detailLine(TVOD).network = networkList.ToArray

                        End If

                    End Using

                End If

                detailLine(TVOD).spotCost = New AdvantageFramework.Media.Classes.spotCost
                detailLine(TVOD).spotCost.currency = "USD"

                If TVOrderDetails(TVOD).Rate.HasValue Then

                    detailLine(TVOD).spotCost.Value = FormatNumber(TVOrderDetails(TVOD).Rate, 2)

                Else

                    detailLine(TVOD).spotCost.Value = 0

                End If

                MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID)
                                                       Where Entity.CableNetworkStationCode = NetworkID
                                                       Select Entity).FirstOrDefault

                If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                    If (Vendor.IsNielsenSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen) OrElse
                            (Vendor.IsComscoreSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore) Then

                        demoValueValueList = New Generic.List(Of AdvantageFramework.Media.Classes.demoValueValue)

                        demoValueValue = New AdvantageFramework.Media.Classes.demoValueValue
                        demoValueValue.type = AdvantageFramework.Media.Classes.demoValueValueType.Ratings
                        demoValueValue.typeSpecified = True
                        demoValueValue.Value = MediaBroadcastWorksheetMarketDetail.PrimaryRating

                        demoValueValueList.Add(demoValueValue)

                        demoValueValue = New AdvantageFramework.Media.Classes.demoValueValue
                        demoValueValue.type = AdvantageFramework.Media.Classes.demoValueValueType.Impressions
                        demoValueValue.typeSpecified = True
                        demoValueValue.Value = MediaBroadcastWorksheetMarketDetail.PrimaryImpressions

                        demoValueValueList.Add(demoValueValue)

                        demoValue = New AdvantageFramework.Media.Classes.demoValue
                        demoValue.demoRank = "1"
                        demoValue.value = demoValueValueList.ToArray

                        detailLine(TVOD).demoValue = {demoValue}

                    End If

                End If

                detailLine(TVOD).totals = New AdvantageFramework.Media.Classes.totals
                detailLine(TVOD).totals.cost = New AdvantageFramework.Media.Classes.cost
                detailLine(TVOD).totals.cost.currency = "USD"
                detailLine(TVOD).totals.cost.Value = TVOrderDetails(TVOD).ExtendedGrossAmount
                detailLine(TVOD).totals.spots = TVOrderDetails(TVOD).TotalSpots

                detailLine(TVOD).spot = GetSpotArray(TVOrderDetails(TVOD), WeekNumber, week)

            Next

            systemOrder(0).detailLine = detailLine

            'done
            order(0).systemOrder = systemOrder

            adx.campaign.order = order

            XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.Media.Classes.adx))

            MemoryStream = New System.IO.MemoryStream()

            XmlSerializer.Serialize(MemoryStream, adx)

            'Try

            '    Dim FileStream As System.IO.FileStream = Nothing

            '    FileStream = New System.IO.FileStream("C:\spotorder5.xml", System.IO.FileMode.Create, System.IO.FileAccess.Write)
            '    MemoryStream.WriteTo(FileStream)
            '    FileStream.Close()

            'Catch ex As Exception

            'End Try

            BuildXMLFile = MemoryStream

        End Function
        Public Function BuildBroadcastXMLFile(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                              OrderNumber As Integer, MediaFrom As String, VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep),
                                              Optional AsNew As Boolean = False) As System.IO.MemoryStream

            Dim CreateOrderRequest As AdvantageFramework.DTO.Media.BroadcastXML.CreateOrderRequest = Nothing
            Dim CreateOrderRequestOrder As AdvantageFramework.DTO.Media.BroadcastXML.CreateOrderRequestOrder = Nothing
            Dim DemoCategoryList As Generic.List(Of AdvantageFramework.DTO.Media.BroadcastXML.DemoCategory) = Nothing
            Dim DemoCategory As AdvantageFramework.DTO.Media.BroadcastXML.DemoCategory = Nothing
            Dim DemoCategory2 As AdvantageFramework.DTO.Media.BroadcastXML.DemoCategory = Nothing
            Dim Comment(0) As AdvantageFramework.DTO.Media.BroadcastXML.Comment
            Dim CreateOrderRequestOrderBuylinesSpotBuylines As Generic.List(Of DTO.Media.BroadcastXML.SpotBuyline) = Nothing
            Dim CreateOrderRequestOrderBuylinesSpotBuyline As DTO.Media.BroadcastXML.SpotBuyline = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim XmlSerializerNamespaces As System.Xml.Serialization.XmlSerializerNamespaces = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OrderLineNumber As Short = 0
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistributionList As Generic.List(Of DTO.Media.BroadcastXML.WeeklySpotDistribution) = Nothing
            Dim CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution As DTO.Media.BroadcastXML.WeeklySpotDistribution = Nothing
            Dim CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValueList As Generic.List(Of DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue) = Nothing
            Dim CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue As DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim OrderLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim InstrPosition As Integer = -1

            XmlSerializerNamespaces = New Xml.Serialization.XmlSerializerNamespaces
            XmlSerializerNamespaces.Add("tvb-c", "http://www.tvb.org/schema/TVB_Common")
            XmlSerializerNamespaces.Add("tvb-mc", "http://www.tvb.org/schema/TVB_MediaCommon")

            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)
            DbContext.Entry(TVOrder).Reference("Vendor")

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            MediaBroadcastWorksheetMarketDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic")
                                                       Where Entity.OrderNumber = OrderNumber
                                                       Select Entity).FirstOrDefault

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic")
                                                      Where Entity.OrderNumber = OrderNumber
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).ToArray

            MediaBroadcastWorksheet = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet

            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, TVOrder.OfficeCode)

            If String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.BuyerEmployeeCode) Then

                If String.IsNullOrWhiteSpace(TVOrder.BuyerEmployeeCode) Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                Else

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, TVOrder.BuyerEmployeeCode)

                End If

            Else

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.BuyerEmployeeCode)

            End If

            CreateOrderRequest = New AdvantageFramework.DTO.Media.BroadcastXML.CreateOrderRequest
            CreateOrderRequest.messageId = "00000000-0000-0000-0000-000000000000"
            CreateOrderRequest.timestamp = Now
            CreateOrderRequest.targetEnvironment = "PRODUCTION"
            CreateOrderRequest.originatingTradingPartner = "00000000-0000-0000-0000-000000000000"
            CreateOrderRequest.destinationTradingPartner = "00000000-0000-0000-0000-000000000000"
            CreateOrderRequest.mediaType = "SpotTV"
            CreateOrderRequest.serviceName = "CreateOrder"
            CreateOrderRequest.serviceVersion = "0.00"
            CreateOrderRequest.serviceInstanceId = "00000000-0000-0000-0000-000000000000"
            CreateOrderRequest.messageVersion = 3.2

            CreateOrderRequestOrder = New AdvantageFramework.DTO.Media.BroadcastXML.CreateOrderRequestOrder
            CreateOrderRequestOrder.orderId = TVOrder.OrderNumber

            If AsNew = True Then

                CreateOrderRequestOrder.orderVersion = "1"

            ElseIf (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumber(DbContext, OrderNumber)
                    Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted).Any = False Then

                CreateOrderRequestOrder.orderVersion = "1"

            ElseIf (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                    Select Entity.RevisionNumber).Max = 0 Then

                CreateOrderRequestOrder.orderVersion = "1"

            Else

                CreateOrderRequestOrder.orderVersion = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, TVOrder.OrderNumber).Max(Function(Entity) Entity.RevisionNumber) + 1

            End If

            If CreateOrderRequestOrder.orderVersion = "1" Then

                CreateOrderRequestOrder.orderStatus = "New"

            Else

                CreateOrderRequestOrder.orderStatus = "Revised"

            End If

            CreateOrderRequestOrder.OrderIdReferences = New DTO.Media.BroadcastXML.CreateOrderRequestOrderOrderIdReferences
            CreateOrderRequestOrder.OrderIdReferences.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.OrderIdReferences.SourceCode.source = "Agency"
            CreateOrderRequestOrder.OrderIdReferences.SourceCode.Value = TVOrder.OrderNumber.ToString.Replace(" ", "_")

            CreateOrderRequestOrder.OrderType = "Normal"
            CreateOrderRequestOrder.OrderCashTrade = "Cash"

            CreateOrderRequestOrder.Advertiser = New DTO.Media.BroadcastXML.Advertiser
            CreateOrderRequestOrder.Advertiser.CompanyName = TVOrder.Product.Client.Name
            CreateOrderRequestOrder.Advertiser.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Advertiser.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Advertiser.SourceCode.Value = TVOrder.ClientCode.Replace(" ", "_")

            CreateOrderRequestOrder.Product = New DTO.Media.BroadcastXML.Product
            CreateOrderRequestOrder.Product.ProductName = TVOrder.Product.Name
            CreateOrderRequestOrder.Product.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Product.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Product.SourceCode.Value = TVOrder.Product.Code.Replace(" ", "_")

            CreateOrderRequestOrder.Agency = New DTO.Media.BroadcastXML.Agency
            CreateOrderRequestOrder.Agency.CompanyName = Agency.Name
            CreateOrderRequestOrder.Agency.Contact = New DTO.Media.BroadcastXML.Contact
            CreateOrderRequestOrder.Agency.Contact.contactId = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.BuyerEmployeeCode
            CreateOrderRequestOrder.Agency.Contact.contactRole = "Buyer"

            If Employee IsNot Nothing Then

                CreateOrderRequestOrder.Agency.Contact.PersonFirstName = Employee.FirstName
                CreateOrderRequestOrder.Agency.Contact.PersonLastName = Employee.LastName
                CreateOrderRequestOrder.Agency.Contact.Email = Employee.Email

                CreateOrderRequestOrder.Agency.Contact.Phone = New DTO.Media.BroadcastXML.ContactPhone

                If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.PhoneNumber & "").Length = 10 Then

                    CreateOrderRequestOrder.Agency.Contact.Phone.AreaCityCode = Mid(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.PhoneNumber & ""), 1, 3)
                    CreateOrderRequestOrder.Agency.Contact.Phone.PhoneNumber = Mid(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.PhoneNumber & ""), 4, 7)

                ElseIf AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.PhoneNumber & "").Length = 7 Then

                    CreateOrderRequestOrder.Agency.Contact.Phone.PhoneNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.PhoneNumber & "")

                End If

            End If

            CreateOrderRequestOrder.Agency.Contact.SourceCode = New DTO.Media.BroadcastXML.ContactSourceCode
            CreateOrderRequestOrder.Agency.Contact.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Agency.Contact.SourceCode.Value = Agency.Name.Replace(" ", "_")

            CreateOrderRequestOrder.Agency.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Agency.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Agency.SourceCode.Value = Agency.Name.Replace(" ", "_")

            If Office IsNot Nothing Then

                CreateOrderRequestOrder.Agency.Office = New DTO.Media.BroadcastXML.Office
                CreateOrderRequestOrder.Agency.Office.OfficeName = Office.Name
                CreateOrderRequestOrder.Agency.Office.Address = New DTO.Media.BroadcastXML.OfficeAddress
                CreateOrderRequestOrder.Agency.Office.Address.addressRole = "Business"
                CreateOrderRequestOrder.Agency.Office.Address.AddressBlockLine = "123"

                CreateOrderRequestOrder.Agency.Office.SourceCode = New DTO.Media.BroadcastXML.OfficeSourceCode
                CreateOrderRequestOrder.Agency.Office.SourceCode.source = "Agency"
                CreateOrderRequestOrder.Agency.Office.SourceCode.Value = TVOrder.OfficeCode.Replace(" ", "_")

            End If

            CreateOrderRequestOrder.Estimate = New DTO.Media.BroadcastXML.Estimate
            CreateOrderRequestOrder.Estimate.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Estimate.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Estimate.SourceCode.Value = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.ID

            CreateOrderRequestOrder.Seller = New DTO.Media.BroadcastXML.Seller
            CreateOrderRequestOrder.Seller.StationSeller = New DTO.Media.BroadcastXML.SellerStationSeller
            CreateOrderRequestOrder.Seller.StationSeller.CompanyName = TVOrder.Vendor.Name
            CreateOrderRequestOrder.Seller.StationSeller.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Seller.StationSeller.SourceCode.source = "Agency"
            CreateOrderRequestOrder.Seller.StationSeller.SourceCode.Value = TVOrder.VendorCode.Replace(" ", "_")

            CreateOrderRequestOrder.LocalNational = "Local"

            CreateOrderRequestOrder.Station = New DTO.Media.BroadcastXML.Station
            CreateOrderRequestOrder.Station.SourceCode = New DTO.Media.BroadcastXML.SourceCode
            CreateOrderRequestOrder.Station.SourceCode.source = "Agency"

            If MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen AndAlso TVOrder.Vendor.NielsenTVStationCode.HasValue AndAlso Session.IsNielsenSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    If (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                        Where Entity.StationCode = TVOrder.Vendor.NielsenTVStationCode.Value
                        Select Entity).Count > 0 Then

                        CreateOrderRequestOrder.Station.FCCCallLetters = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                                                          Where Entity.StationCode = TVOrder.Vendor.NielsenTVStationCode.Value
                                                                          Select Entity).First.CallLetters

                    End If

                End Using

                CreateOrderRequestOrder.Station.SourceCode.Value = TVOrder.Vendor.NielsenTVStationCode.Value.ToString

            ElseIf MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso TVOrder.Vendor.ComscoreTVStation IsNot Nothing Then

                CreateOrderRequestOrder.Station.FCCCallLetters = TVOrder.Vendor.ComscoreTVStation.CallLetters
                CreateOrderRequestOrder.Station.SourceCode.Value = TVOrder.Vendor.ComscoreTVStation.ID

            Else

                CreateOrderRequestOrder.Station.FCCCallLetters = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT VN_CODE_XREF FROM dbo.VENDOR WHERE VN_CODE = '{0}'", TVOrder.VendorCode)).FirstOrDefault

                If String.IsNullOrWhiteSpace(CreateOrderRequestOrder.Station.FCCCallLetters) = False Then

                    CreateOrderRequestOrder.Station.SourceCode.Value = CreateOrderRequestOrder.Station.FCCCallLetters.Replace(" ", "_")

                End If

            End If

            If String.IsNullOrWhiteSpace(CreateOrderRequestOrder.Station.FCCCallLetters) = False Then

                InstrPosition = InStr(CreateOrderRequestOrder.Station.FCCCallLetters, "-")

                If InstrPosition > 0 Then

                    CreateOrderRequestOrder.Station.FCCCallLetters = Mid(CreateOrderRequestOrder.Station.FCCCallLetters, 1, InstrPosition - 1).Trim

                Else

                    InstrPosition = InStr(CreateOrderRequestOrder.Station.FCCCallLetters, " ")

                    If InstrPosition > 0 Then

                        CreateOrderRequestOrder.Station.FCCCallLetters = Mid(CreateOrderRequestOrder.Station.FCCCallLetters, 1, InstrPosition - 1).Trim

                    End If

                End If

            End If

            If String.IsNullOrWhiteSpace(CreateOrderRequestOrder.Station.FCCCallLetters) = False Then

                CreateOrderRequestOrder.Station.FCCCallLetters = CreateOrderRequestOrder.Station.FCCCallLetters.Replace("+", "")

            End If

            If TVOrder.StartDate.HasValue Then

                CreateOrderRequestOrder.StartDate = TVOrder.StartDate.Value

            End If

            If TVOrder.EndDate.HasValue Then

                CreateOrderRequestOrder.EndDate = TVOrder.EndDate.Value

            End If

            CreateOrderRequestOrder.OrderGrossAmount = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                                        Select Entity).Sum(Function(Entity) Entity.ExtendedGrossAmount)

            CreateOrderRequestOrder.BillingCalendar = "Broadcast"
            CreateOrderRequestOrder.BillingCycle = "Monthly"

            CreateOrderRequestOrder.PrimaryDemoCategory = New DTO.Media.BroadcastXML.PrimaryDemoCategory
            CreateOrderRequestOrder.PrimaryDemoCategory.demoId = "DM1"

            DemoCategoryList = New Generic.List(Of AdvantageFramework.DTO.Media.BroadcastXML.DemoCategory)

            DemoCategory = New DTO.Media.BroadcastXML.DemoCategory
            DemoCategory2 = New DTO.Media.BroadcastXML.DemoCategory

            DemoCategory.demoId = "DM1"
            DemoCategory2.demoId = "DM2"

            If MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                DemoCategory.DemoLowerAge = MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0)
                DemoCategory.DemoUpperAge = MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99)

                If InStr(MediaBroadcastWorksheet.PrimaryMediaDemographic.Description, " ") > 0 Then

                    DemoCategory.DemoGroup = Mid(MediaBroadcastWorksheet.PrimaryMediaDemographic.Description, 1, InStr(MediaBroadcastWorksheet.PrimaryMediaDemographic.Description, " ") - 1)

                Else

                    DemoCategory.DemoGroup = MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                End If

                DemoCategory2.DemoLowerAge = DemoCategory.DemoLowerAge
                DemoCategory2.DemoUpperAge = DemoCategory.DemoUpperAge
                DemoCategory2.DemoGroup = DemoCategory.DemoGroup

            Else

                DemoCategory.DemoGroup = String.Empty
                DemoCategory2.DemoGroup = String.Empty

            End If

            DemoCategoryList.Add(DemoCategory)
            DemoCategoryList.Add(DemoCategory2)

            CreateOrderRequestOrder.DemoCategory = DemoCategoryList.ToArray

            Comment(0) = New DTO.Media.BroadcastXML.Comment
            Comment(0).source = "Agency"
            Comment(0).Value = TVOrder.OrderComment

            CreateOrderRequestOrder.Comment = Comment

            CreateOrderRequestOrder.TermsOfSale = New DTO.Media.BroadcastXML.TermsOfSale
            CreateOrderRequestOrder.TermsOfSale.source = "Agency"
            CreateOrderRequestOrder.TermsOfSale.Value = AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.VEN_COST_COL_TERMS)

            'CreateOrderRequestOrder.Buylines = New DTO.Media.BroadcastXML.SpotBuyline()

            TVOrderDetails = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, TVOrder.OrderNumber).ToList

            CreateOrderRequestOrderBuylinesSpotBuylines = New Generic.List(Of DTO.Media.BroadcastXML.SpotBuyline)

            For Each MediaBroadcastWorksheetMarketDetail In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketDetailIDs(DbContext, MediaBroadcastWorksheetMarketDetailIDs).Include("MediaBroadcastWorksheetMarketDetailDates").Include("Daypart").ToList

                CreateOrderRequestOrderBuylinesSpotBuyline = New DTO.Media.BroadcastXML.SpotBuyline

                If CreateOrderRequestOrder.orderStatus = "New" Then

                    CreateOrderRequestOrderBuylinesSpotBuyline.buylineVersion = "1"
                    CreateOrderRequestOrderBuylinesSpotBuyline.buylineStatus = "New"

                Else

                    OrderLineNumbers = (From MBWMDD In MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketDetailDates
                                        Where MBWMDD.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetail.ID AndAlso
                                              MBWMDD.OrderLineNumber IsNot Nothing
                                        Select MBWMDD.OrderLineNumber.Value).Distinct.ToArray


                    CreateOrderRequestOrderBuylinesSpotBuyline.buylineVersion = (From TVD In TVOrderDetails
                                                                                 Where OrderLineNumbers.Contains(TVD.LineNumber)
                                                                                 Select TVD.RevisionNumber).Max + 1

                    If CreateOrderRequestOrderBuylinesSpotBuyline.buylineVersion = "1" Then

                        CreateOrderRequestOrderBuylinesSpotBuyline.buylineStatus = "New"

                    Else

                        CreateOrderRequestOrderBuylinesSpotBuyline.buylineStatus = "Revised"

                    End If

                End If

                CreateOrderRequestOrderBuylinesSpotBuyline.buylineNumber = (MediaBroadcastWorksheetMarketDetail.LineNumber * 1000) + MediaBroadcastWorksheetMarketDetail.MakegoodNumber

                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineIdReferences = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineBuylineIdReferences
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineIdReferences.SourceCode = New DTO.Media.BroadcastXML.SourceCode
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineIdReferences.SourceCode.source = "Agency"
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineIdReferences.SourceCode.Value = MediaBroadcastWorksheetMarketDetail.LineNumber * 1000 + MediaBroadcastWorksheetMarketDetail.MakegoodNumber

                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineCashTrade = "Cash"
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineDescription = If(MediaBroadcastWorksheetMarketDetail.ValueAdded, "VALUE_AD", "VIDEO")
                CreateOrderRequestOrderBuylinesSpotBuyline.StartDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                        Where Entity.OrderNumber IsNot Nothing
                                                                        Select Entity).Min(Function(Entity) Entity.Date)
                CreateOrderRequestOrderBuylinesSpotBuyline.EndDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                      Where Entity.OrderNumber IsNot Nothing
                                                                      Select Entity).Max(Function(Entity) Entity.Date)

                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineQuantity = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineBuylineQuantity
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineQuantity.unitType = "Spot"
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineQuantity.Value = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                                    Where Entity.OrderNumber IsNot Nothing
                                                                                    Select Entity).Sum(Function(Entity) Entity.Spots)

                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineUnitRate = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineBuylineUnitRate
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineUnitRate.costModel = "Unit"
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineUnitRate.Value = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID).First.Rate

                'CreateOrderRequestOrderBuylinesSpotBuyline.BuylineGrossAmount = (CreateOrderRequestOrderBuylinesSpotBuyline.BuylineQuantity.Value * CreateOrderRequestOrderBuylinesSpotBuyline.BuylineUnitRate.Value)
                CreateOrderRequestOrderBuylinesSpotBuyline.BuylineGrossAmount = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                                 Where Entity.OrderNumber IsNot Nothing
                                                                                 Select Entity).Sum(Function(Entity) Entity.Spots * Entity.Rate)

                CreateOrderRequestOrderBuylinesSpotBuyline.SpotBuylineType = "Normal"

                OrderLineNumber = (From Entity In MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketDetailDates
                                   Where Entity.OrderLineNumber IsNot Nothing
                                   Select Entity).First.OrderLineNumber

                TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, OrderLineNumber)

                CreateOrderRequestOrderBuylinesSpotBuyline.SpotLength = TVOrderDetail.Length

                If MediaBroadcastWorksheetMarketDetail.Daypart IsNot Nothing Then

                    CreateOrderRequestOrderBuylinesSpotBuyline.BuyerDaypart = MediaBroadcastWorksheetMarketDetail.Daypart.Code

                End If

                CreateOrderRequestOrderBuylinesSpotBuyline.StartDayOfWeek = "Mo"

                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineContractInterval
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.MondayValid = MediaBroadcastWorksheetMarketDetail.Monday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.TuesdayValid = MediaBroadcastWorksheetMarketDetail.Tuesday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.WednesdayValid = MediaBroadcastWorksheetMarketDetail.Wednesday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.ThursdayValid = MediaBroadcastWorksheetMarketDetail.Thursday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.FridayValid = MediaBroadcastWorksheetMarketDetail.Friday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.SaturdayValid = MediaBroadcastWorksheetMarketDetail.Saturday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.SundayValid = MediaBroadcastWorksheetMarketDetail.Sunday.ToString
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.StartTime = GetTime(TVOrderDetail.StartTime, False)
                CreateOrderRequestOrderBuylinesSpotBuyline.ContractInterval.EndTime = GetTime(TVOrderDetail.EndTime, False)

                CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistributionList = New Generic.List(Of DTO.Media.BroadcastXML.WeeklySpotDistribution)

                For Each MediaBroadcastWorksheetMarketDetailDate In (From DD In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                     Where DD.Date >= CreateOrderRequestOrder.StartDate AndAlso
                                                                           DD.Date <= CreateOrderRequestOrder.EndDate
                                                                     Select DD).ToList

                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution = New DTO.Media.BroadcastXML.WeeklySpotDistribution

                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.UnitRateAmount = MediaBroadcastWorksheetMarketDetailDate.Rate
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.StartDate = MediaBroadcastWorksheetMarketDetailDate.Date

                    If MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                        CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.EndDate = DateAdd(DateInterval.Day, 6, MediaBroadcastWorksheetMarketDetailDate.Date)

                    ElseIf MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily Then

                        CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.EndDate = MediaBroadcastWorksheetMarketDetailDate.Date

                    End If

                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.SpotPerWeekQuantity = MediaBroadcastWorksheetMarketDetailDate.Spots
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.MondayValid = MediaBroadcastWorksheetMarketDetail.Monday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.TuesdayValid = MediaBroadcastWorksheetMarketDetail.Tuesday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.WednesdayValid = MediaBroadcastWorksheetMarketDetail.Wednesday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.ThursdayValid = MediaBroadcastWorksheetMarketDetail.Thursday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.FridayValid = MediaBroadcastWorksheetMarketDetail.Friday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.SaturdayValid = MediaBroadcastWorksheetMarketDetail.Saturday.ToString
                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution.SundayValid = MediaBroadcastWorksheetMarketDetail.Sunday.ToString

                    CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistributionList.Add(CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistribution)

                Next

                CreateOrderRequestOrderBuylinesSpotBuyline.WeeklySpotDistribution = CreateOrderRequestOrderBuylinesSpotBuylineWeeklySpotDistributionList.ToArray
                '
                CreateOrderRequestOrderBuylinesSpotBuylines.Add(CreateOrderRequestOrderBuylinesSpotBuyline)

                If (TVOrder.Vendor.IsNielsenSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen) OrElse
                        (TVOrder.Vendor.IsComscoreSubsciber AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore) Then

                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValueList = New Generic.List(Of DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue)

                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue
                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.demoId = "DM1"

                    If Mid(MediaFrom, 1, 1) = "T" Then

                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.RatingPointValue = MediaBroadcastWorksheetMarketDetail.PrimaryRating
                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.RatingPointValueSpecified = True

                    Else

                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.RatingPointValue = MediaBroadcastWorksheetMarketDetail.PrimaryAQHRating
                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.RatingPointValueSpecified = True

                    End If

                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValueList.Add(CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue)

                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue = New DTO.Media.BroadcastXML.CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue
                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.demoId = "DM2"

                    If Mid(MediaFrom, 1, 1) = "T" Then

                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.ImpressionsValue = MediaBroadcastWorksheetMarketDetail.PrimaryImpressions
                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.ImpressionsValueSpecified = True

                    Else

                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.ImpressionsValue = MediaBroadcastWorksheetMarketDetail.PrimaryAQH
                        CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue.ImpressionsValueSpecified = True

                    End If

                    CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValueList.Add(CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue)

                    CreateOrderRequestOrderBuylinesSpotBuyline.TargetDemoValue = CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValueList.ToArray

                End If

            Next

            CreateOrderRequestOrder.Buylines = CreateOrderRequestOrderBuylinesSpotBuylines.ToArray

            CreateOrderRequest.Order = CreateOrderRequestOrder

            XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.DTO.Media.BroadcastXML.CreateOrderRequest))

            MemoryStream = New System.IO.MemoryStream()

            XmlSerializer.Serialize(MemoryStream, CreateOrderRequest, XmlSerializerNamespaces)

            'Try

            '    Dim FileStream As System.IO.FileStream = Nothing

            '    FileStream = New System.IO.FileStream("C:\Bcast.xml", System.IO.FileMode.Create, System.IO.FileAccess.Write)

            '    MemoryStream.WriteTo(FileStream)
            '    FileStream.Close()

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

            BuildBroadcastXMLFile = MemoryStream

        End Function
        Public Function BuildRadioBroadcastXMLFile(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                                   OrderNumber As Integer, MediaFrom As String, VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep),
                                                   Optional AsNew As Boolean = False) As System.IO.MemoryStream

            Dim XmlSerializerNamespaces As System.Xml.Serialization.XmlSerializerNamespaces = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Guid As Guid = Guid.NewGuid
            Dim Transmission As AdvantageFramework.DTO.Media.RadioBroadcastXML.Transmission = Nothing
            Dim CompanyList As Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Company) = Nothing
            Dim OfficeList As Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Office) = Nothing
            Dim AddressList As Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Address) = Nothing
            Dim ContactList As Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Contact) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim OrderNumberSearchResult As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim MBWMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim EmailList As Generic.List(Of DTO.Media.RadioBroadcastXML.Email) = Nothing
            Dim StateCode As String = Nothing
            Dim AdvertiserID As Generic.List(Of DTO.Media.RadioBroadcastXML.ID) = Nothing
            Dim ProductID As Generic.List(Of DTO.Media.RadioBroadcastXML.ID) = Nothing
            Dim Productlist As Generic.List(Of DTO.Media.RadioBroadcastXML.Product) = Nothing
            Dim EstimateID As Generic.List(Of DTO.Media.RadioBroadcastXML.ID) = Nothing
            Dim DemoNameComplexTypeList As Generic.List(Of DTO.Media.RadioBroadcastXML.DemoNameComplexType) = Nothing
            Dim OrderList As Generic.List(Of DTO.Media.RadioBroadcastXML.Order) = Nothing
            Dim CommentList As Generic.List(Of DTO.Media.RadioBroadcastXML.Comment) = Nothing
            Dim TermsOfSaleList As Generic.List(Of DTO.Media.RadioBroadcastXML.TermsOfSale) = Nothing
            Dim MarketID As Generic.List(Of DTO.Media.RadioBroadcastXML.ID) = Nothing
            Dim StationOrderList As Generic.List(Of DTO.Media.RadioBroadcastXML.StationOrder) = Nothing
            Dim StationID As Generic.List(Of DTO.Media.RadioBroadcastXML.ID) = Nothing
            Dim PopulationsList As Generic.List(Of DTO.Media.RadioBroadcastXML.Populations) = Nothing
            Dim BuyLineList As Generic.List(Of DTO.Media.RadioBroadcastXML.BuyLine) = Nothing
            Dim BuyLine As DTO.Media.RadioBroadcastXML.BuyLine = Nothing
            Dim DaypartDaypartCodeList As Generic.List(Of DTO.Media.RadioBroadcastXML.DaypartDaypartCode) = Nothing
            Dim DayTimeList As Generic.List(Of DTO.Media.RadioBroadcastXML.DayTime) = Nothing
            Dim AirPeriodList As Generic.List(Of DTO.Media.RadioBroadcastXML.AirPeriod) = Nothing
            Dim DemoValueTypeList As Generic.List(Of DTO.Media.RadioBroadcastXML.DemoValueType) = Nothing
            Dim BookNameComplexTypeList As Generic.List(Of DTO.Media.RadioBroadcastXML.BookNameComplexType) = Nothing

            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing

            XmlSerializerNamespaces = New Xml.Serialization.XmlSerializerNamespaces
            XmlSerializerNamespaces.Add("brd", "http://www.AAAA.org/schemas/broadcast")
            XmlSerializerNamespaces.Add("gbl", "http://www.AAAA.org/schemas/global")
            XmlSerializerNamespaces.Add("hdr", "http://www.AAAA.org/schemas/header")
            XmlSerializerNamespaces.Add("rdo", "http://www.AAAA.org/schemas/spotRadio")

            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

            RadioOrderDetails = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, RadioOrder.OrderNumber).ToList

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RadioOrder.ClientCode)

            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, RadioOrder.ClientCode, RadioOrder.DivisionCode, RadioOrder.ProductCode)

            If RadioOrder Is Nothing OrElse RadioOrder.StartDate.HasValue = False OrElse RadioOrder.EndDate.HasValue = False Then

                Throw New Exception("Radio order is not found or has invalid start/end dates.")

            End If

            Transmission = New AdvantageFramework.DTO.Media.RadioBroadcastXML.Transmission
            Transmission.TransmissionHeader = New AdvantageFramework.DTO.Media.RadioBroadcastXML.TransmissionHeader

            Transmission.TransmissionHeader.UniversalID = Guid.ToString
            Transmission.TransmissionHeader.TransmissionNumber = "1"
            Transmission.TransmissionHeader.TransmissionDateTime = Now
            Transmission.TransmissionHeader.ValidatingSchema = "spotRadioOrder-v.0.2j.2.xsd"
            Transmission.TransmissionHeader.ValidatingSchemaVersion = "0.2j.2"

            Transmission.TransmissionHeader.Sender = New AdvantageFramework.DTO.Media.RadioBroadcastXML.TransmissionHeaderSender
            Transmission.TransmissionHeader.Sender.companyIndex = "3"
            Transmission.TransmissionHeader.Sender.Value = ""

            Transmission.TransmissionHeader.Receiver = New AdvantageFramework.DTO.Media.RadioBroadcastXML.TransmissionHeaderReceiver
            Transmission.TransmissionHeader.Receiver.companyIndex = "3"
            Transmission.TransmissionHeader.Receiver.Value = ""

            Transmission.TransmissionHeader.MediaType = AdvantageFramework.DTO.Media.RadioBroadcastXML.MediaType.spotRadio
            Transmission.TransmissionHeader.TransactionType = AdvantageFramework.DTO.Media.RadioBroadcastXML.TransactionType.Order

            Transmission.Transaction = New AdvantageFramework.DTO.Media.RadioBroadcastXML.Transaction
            Transmission.Transaction.TransactionHeader = New AdvantageFramework.DTO.Media.RadioBroadcastXML.TransactionHeader
            Transmission.Transaction.TransactionHeader.FlightDates = New AdvantageFramework.DTO.Media.RadioBroadcastXML.FlightDates
            Transmission.Transaction.TransactionHeader.FlightDates.StartDate = RadioOrder.StartDate.Value
            Transmission.Transaction.TransactionHeader.FlightDates.EndDate = RadioOrder.EndDate.Value

            CompanyList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Company)

            'Agency / buyer company
            CompanyList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Company)
            CompanyList(0).typeSpecified = True
            CompanyList(0).type = AdvantageFramework.DTO.Media.RadioBroadcastXML.CompanyType.Agency
            CompanyList(0).roleSpecified = True
            CompanyList(0).role = AdvantageFramework.DTO.Media.RadioBroadcastXML.CompanyRoleType.Buyer
            CompanyList(0).indexKey = "1"
            CompanyList(0).Name = Agency.Name

            OfficeList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Office)
            OfficeList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Office)
            'OfficeList(0).mktCode = ""
            OfficeList(0).Name = Agency.Name

            AddressList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Address)
            AddressList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Address)
            AddressList(0).country = DTO.Media.RadioBroadcastXML.CountryType.USA
            AddressList(0).type = DTO.Media.RadioBroadcastXML.AddressType.Main
            AddressList(0).Street1 = Agency.Address
            AddressList(0).Street2 = Agency.Address2
            AddressList(0).City = Agency.City

            If String.IsNullOrWhiteSpace(Agency.State) = False AndAlso System.Enum.IsDefined(GetType(AdvantageFramework.DTO.Media.RadioBroadcastXML.State), Agency.State) Then

                StateCode = (From Entity In System.Enum.GetValues(GetType(AdvantageFramework.DTO.Media.RadioBroadcastXML.State))
                             Where Entity.ToString = Agency.State
                             Select Entity).FirstOrDefault

                AddressList(0).State = StateCode
                AddressList(0).StateSpecified = True

            End If

            AddressList(0).PostalCode = Agency.Zip

            OfficeList(0).Address = AddressList.ToArray

            CompanyList(0).Office = OfficeList.ToArray

            ContactList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Contact)

            If String.IsNullOrWhiteSpace(RadioOrder.BuyerEmployeeCode) = False Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, RadioOrder.BuyerEmployeeCode)

                If Employee IsNot Nothing Then

                    ContactList.Add(New DTO.Media.RadioBroadcastXML.Contact)
                    ContactList(0).officeIndex = "1"
                    ContactList(0).role = DTO.Media.RadioBroadcastXML.ContactRoleType.buyer
                    ContactList(0).FirstName = Employee.FirstName
                    ContactList(0).LastName = Employee.LastName

                    If String.IsNullOrWhiteSpace(Employee.Email) = False Then

                        EmailList = New Generic.List(Of DTO.Media.RadioBroadcastXML.Email)
                        EmailList.Add(New DTO.Media.RadioBroadcastXML.Email)
                        EmailList(0).type = DTO.Media.RadioBroadcastXML.EmailType.primary
                        EmailList(0).Value = Employee.Email

                        ContactList(0).Email = EmailList.ToArray

                    End If

                    ContactList(0).ID = New DTO.Media.RadioBroadcastXML.ID
                    ContactList(0).ID.Code = New DTO.Media.RadioBroadcastXML.IDCode
                    ContactList(0).ID.Code.description = "BuyerCode"
                    ContactList(0).ID.Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
                    ContactList(0).ID.Code.Value = Employee.Code

                End If

            End If

            CompanyList(0).Contact = ContactList.ToArray

            'Rep / Seller company
            CompanyList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Company)
            CompanyList(1).typeSpecified = True
            CompanyList(1).type = AdvantageFramework.DTO.Media.RadioBroadcastXML.CompanyType.Rep
            CompanyList(1).roleSpecified = True
            CompanyList(1).role = AdvantageFramework.DTO.Media.RadioBroadcastXML.CompanyRoleType.Seller
            CompanyList(1).indexKey = "2"
            CompanyList(1).Name = RadioOrder.Vendor.Name

            OfficeList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Office)
            OfficeList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Office)
            'OfficeList(0).mktCode = ""
            OfficeList(0).indexKey = "2"
            OfficeList(0).Name = RadioOrder.Market.Description

            AddressList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Address)
            AddressList.Add(New AdvantageFramework.DTO.Media.RadioBroadcastXML.Address)
            AddressList(0).country = DTO.Media.RadioBroadcastXML.CountryType.USA
            AddressList(0).type = DTO.Media.RadioBroadcastXML.AddressType.Main
            AddressList(0).Street1 = If(RadioOrder.Vendor.StreetAddressLine1 IsNot Nothing, RadioOrder.Vendor.StreetAddressLine1, "")
            AddressList(0).Street2 = If(RadioOrder.Vendor.StreetAddressLine2 IsNot Nothing, RadioOrder.Vendor.StreetAddressLine2, "")
            AddressList(0).City = If(RadioOrder.Vendor.City IsNot Nothing, RadioOrder.Vendor.City, "")

            If String.IsNullOrWhiteSpace(RadioOrder.Vendor.State) = False AndAlso System.Enum.IsDefined(GetType(AdvantageFramework.DTO.Media.RadioBroadcastXML.State), RadioOrder.Vendor.State) Then

                StateCode = (From Entity In System.Enum.GetValues(GetType(AdvantageFramework.DTO.Media.RadioBroadcastXML.State))
                             Where Entity.ToString = RadioOrder.Vendor.State
                             Select Entity).FirstOrDefault

                AddressList(0).State = StateCode
                AddressList(0).StateSpecified = True

            End If

            If String.IsNullOrWhiteSpace(RadioOrder.Vendor.ZipCode) = False Then

                AddressList(0).PostalCode = RadioOrder.Vendor.ZipCode

            End If

            OfficeList(0).Address = AddressList.ToArray

            CompanyList(1).Office = OfficeList.ToArray

            'ContactList = New Generic.List(Of AdvantageFramework.DTO.Media.RadioBroadcastXML.Contact)

            'If String.IsNullOrWhiteSpace(RadioOrder.BuyerEmployeeCode) = False Then

            '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, RadioOrder.BuyerEmployeeCode)

            '    If Employee IsNot Nothing Then

            '        ContactList.Add(New DTO.Media.RadioBroadcastXML.Contact)
            '        ContactList(0).officeIndex = "1"
            '        ContactList(0).role = DTO.Media.RadioBroadcastXML.ContactRoleType.buyer
            '        ContactList(0).FirstName = Employee.FirstName
            '        ContactList(0).LastName = Employee.LastName

            '        If String.IsNullOrWhiteSpace(Employee.Email) = False Then

            '            Dim EmailList As New Generic.List(Of DTO.Media.RadioBroadcastXML.Email)
            '            EmailList.Add(New DTO.Media.RadioBroadcastXML.Email)
            '            EmailList(0).type = DTO.Media.RadioBroadcastXML.EmailType.primary
            '            EmailList(0).Value = Employee.Email

            '            ContactList(0).Email = EmailList.ToArray

            '        End If

            '        ContactList(0).ID = New DTO.Media.RadioBroadcastXML.ID
            '        ContactList(0).ID.Code = New DTO.Media.RadioBroadcastXML.IDCode
            '        ContactList(0).ID.Code.description = "BuyerCode"
            '        ContactList(0).ID.Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            '        ContactList(0).ID.Code.Value = Employee.Code

            '    End If

            'End If

            'CompanyList(1).Contact = ContactList.ToArray

            Transmission.Transaction.TransactionHeader.Company = CompanyList.ToArray

            Transmission.Transaction.TransactionHeader.Advertiser = New DTO.Media.RadioBroadcastXML.Advertiser
            Transmission.Transaction.TransactionHeader.Advertiser.Name = Client.Name

            AdvertiserID = New Generic.List(Of DTO.Media.RadioBroadcastXML.ID)
            AdvertiserID.Add(New DTO.Media.RadioBroadcastXML.ID)
            AdvertiserID(0).Code = New DTO.Media.RadioBroadcastXML.IDCode
            AdvertiserID(0).Code.description = "ClientCode"
            AdvertiserID(0).Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            AdvertiserID(0).Code.ownerSpecified = True
            AdvertiserID(0).Code.Value = RadioOrder.ClientCode
            Transmission.Transaction.TransactionHeader.Advertiser.ID = AdvertiserID.ToArray

            ProductID = New Generic.List(Of DTO.Media.RadioBroadcastXML.ID)
            ProductID.Add(New DTO.Media.RadioBroadcastXML.ID)
            ProductID(0).Code = New DTO.Media.RadioBroadcastXML.IDCode
            ProductID(0).Code.description = "ProductCode"
            ProductID(0).Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            ProductID(0).Code.ownerSpecified = True
            ProductID(0).Code.Value = RadioOrder.ProductCode

            Productlist = New Generic.List(Of DTO.Media.RadioBroadcastXML.Product)
            Productlist.Add(New DTO.Media.RadioBroadcastXML.Product)
            Productlist(0).Name = Product.Name
            Productlist(0).ID = ProductID.ToArray

            Transmission.Transaction.TransactionHeader.Product = Productlist.ToArray

            Transmission.Transaction.TransactionHeader.Estimate = New DTO.Media.RadioBroadcastXML.Estimate
            Transmission.Transaction.TransactionHeader.Estimate.Description = RadioOrder.Description
            Transmission.Transaction.TransactionHeader.Estimate.StartDate = RadioOrder.StartDate.Value
            Transmission.Transaction.TransactionHeader.Estimate.StartDateSpecified = True
            Transmission.Transaction.TransactionHeader.Estimate.EndDate = RadioOrder.EndDate.Value
            Transmission.Transaction.TransactionHeader.Estimate.EndDateSpecified = True

            EstimateID = New Generic.List(Of DTO.Media.RadioBroadcastXML.ID)
            EstimateID.Add(New DTO.Media.RadioBroadcastXML.ID)
            EstimateID(0).Code = New DTO.Media.RadioBroadcastXML.IDCode
            EstimateID(0).Code.description = "EstimateCode"
            EstimateID(0).Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            EstimateID(0).Code.ownerSpecified = True
            EstimateID(0).Code.Value = RadioOrder.OrderNumber

            Transmission.Transaction.TransactionHeader.Estimate.ID = EstimateID.ToArray

            OrderNumberSearchResult = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult)(String.Format("EXEC [dbo].[advsp_media_broadcast_worksheet_search_by_order_number] {0}", OrderNumber)).FirstOrDefault

            If OrderNumberSearchResult IsNot Nothing Then

                MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, OrderNumberSearchResult.WorksheetID)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, OrderNumberSearchResult.WorksheetMarketID)

                If MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                    DemoNameComplexTypeList = New Generic.List(Of DTO.Media.RadioBroadcastXML.DemoNameComplexType)
                    DemoNameComplexTypeList.Add(New DTO.Media.RadioBroadcastXML.DemoNameComplexType)
                    DemoNameComplexTypeList(0).DemoName = MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                    If MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales AndAlso MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                        DemoNameComplexTypeList(0).Group = DTO.Media.RadioBroadcastXML.Group.Adults

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales Then

                        DemoNameComplexTypeList(0).Group = DTO.Media.RadioBroadcastXML.Group.Men

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales Then

                        DemoNameComplexTypeList(0).Group = DTO.Media.RadioBroadcastXML.Group.Women

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.IsBoys OrElse MediaBroadcastWorksheet.PrimaryMediaDemographic.IsGirls Then

                        DemoNameComplexTypeList(0).Group = DTO.Media.RadioBroadcastXML.Group.Children

                    Else

                        DemoNameComplexTypeList(0).Group = DTO.Media.RadioBroadcastXML.Group.Persons

                    End If

                    If MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 0 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item0

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 6 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item6

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 12 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item12

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 18 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item18

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 21 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item21

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 25 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item25

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 35 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item35

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 45 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item45

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 50 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item50

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 55 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item55

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom.GetValueOrDefault(0) = 65 Then

                        DemoNameComplexTypeList(0).AgeFrom = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeFrom.Item65

                    End If

                    If MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 99 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item99

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 11 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item11

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 17 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item17

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 20 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item20

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 24 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item24

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 34 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item34

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 44 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item44

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 49 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item49

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 54 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item54

                    ElseIf MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo.GetValueOrDefault(99) = 64 Then

                        DemoNameComplexTypeList(0).AgeTo = DTO.Media.RadioBroadcastXML.DemoNameComplexTypeAgeTo.Item64

                    End If

                    Transmission.Transaction.TransactionHeader.Demo = DemoNameComplexTypeList.ToArray

                End If

            End If

            If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue AndAlso ((Session.IsNielsenSetup AndAlso MediaBroadcastWorksheetMarket.ExternalRadioSource = Nielsen.Database.Entities.Methods.RadioSource.Nielsen) OrElse
                    (Session.IsEastlanSetup AndAlso MediaBroadcastWorksheetMarket.ExternalRadioSource = Nielsen.Database.Entities.Methods.RadioSource.Eastlan)) Then

                BookNameComplexTypeList = New Generic.List(Of DTO.Media.RadioBroadcastXML.BookNameComplexType)

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue Then

                        BookNameComplexTypeList.Add(GetBookNameComplexType(NielsenDbContext, "1", MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.Value))

                    End If

                    If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID2.HasValue Then

                        BookNameComplexTypeList.Add(GetBookNameComplexType(NielsenDbContext, "2", MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID2.Value))

                    End If

                    If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID3.HasValue Then

                        BookNameComplexTypeList.Add(GetBookNameComplexType(NielsenDbContext, "3", MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID3.Value))

                    End If

                    If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID4.HasValue Then

                        BookNameComplexTypeList.Add(GetBookNameComplexType(NielsenDbContext, "4", MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID4.Value))

                    End If

                    If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID5.HasValue Then

                        BookNameComplexTypeList.Add(GetBookNameComplexType(NielsenDbContext, "5", MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID5.Value))

                    End If

                End Using

                Transmission.Transaction.TransactionHeader.Book = BookNameComplexTypeList.ToArray

            End If

            Transmission.Transaction.Campaign = New DTO.Media.RadioBroadcastXML.Campaign
            Transmission.Transaction.Campaign.NationalLocalSpecified = False

            OrderList = New Generic.List(Of DTO.Media.RadioBroadcastXML.Order)
            OrderList.Add(New DTO.Media.RadioBroadcastXML.Order)

            If RadioOrderDetails.Max(Function(RD) RD.RevisionNumber) > 0 Then

                If AsNew Then

                    OrderList(0).OrderStatus = DTO.Media.RadioBroadcastXML.OrderStatus.New

                Else

                    OrderList(0).OrderStatus = DTO.Media.RadioBroadcastXML.OrderStatus.Revised

                End If

            Else

                OrderList(0).OrderStatus = DTO.Media.RadioBroadcastXML.OrderStatus.New

            End If

            OrderList(0).OrderStartDate = RadioOrder.StartDate.Value
            OrderList(0).OrderEndDate = RadioOrder.EndDate.Value
            OrderList(0).ExpirationDateSpecified = False
            OrderList(0).WeekStartDay = DTO.Media.RadioBroadcastXML.WeekStartDay.Item1
            OrderList(0).WeekStartDaySpecified = True

            If MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                OrderList(0).BuyType = DTO.Media.RadioBroadcastXML.BuyType.weekly

            ElseIf MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily Then

                OrderList(0).BuyType = DTO.Media.RadioBroadcastXML.BuyType.daily

            End If

            If String.IsNullOrWhiteSpace(RadioOrder.OrderComment) = False Then

                CommentList = New Generic.List(Of DTO.Media.RadioBroadcastXML.Comment)
                CommentList.Add(New DTO.Media.RadioBroadcastXML.Comment)
                CommentList(0).CommentLine = {RadioOrder.OrderComment}
                CommentList(0).owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency

                OrderList(0).Comment = CommentList.ToArray

            End If

            TermsOfSaleList = New Generic.List(Of DTO.Media.RadioBroadcastXML.TermsOfSale)
            TermsOfSaleList.Add(New DTO.Media.RadioBroadcastXML.TermsOfSale)
            TermsOfSaleList(0).ownerDescription = "String"
            TermsOfSaleList(0).owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            TermsOfSaleList(0).description = "String"
            TermsOfSaleList(0).Value = "Agency terms"

            OrderList(0).TermsOfSale = TermsOfSaleList.ToArray

            OrderList(0).Market = New DTO.Media.RadioBroadcastXML.Market
            OrderList(0).Market.MarketName = RadioOrder.Market.Description

            MarketID = New Generic.List(Of DTO.Media.RadioBroadcastXML.ID)
            MarketID.Add(New DTO.Media.RadioBroadcastXML.ID)
            MarketID(0).Code = New DTO.Media.RadioBroadcastXML.IDCode
            MarketID(0).Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            MarketID(0).Code.Value = RadioOrder.MarketCode

            OrderList(0).Market.ID = MarketID.ToArray

            StationOrderList = New Generic.List(Of DTO.Media.RadioBroadcastXML.StationOrder)
            StationOrderList.Add(New DTO.Media.RadioBroadcastXML.StationOrder)
            StationOrderList(0).stationOrderID = RadioOrder.OrderNumber

            If AsNew Then

                StationOrderList(0).version = "1"
                StationOrderList(0).revision = "0"

            Else

                StationOrderList(0).version = "1"
                StationOrderList(0).revision = RadioOrderDetails.Max(Function(RD) RD.RevisionNumber)

            End If

            StationOrderList(0).unwired = DTO.Media.RadioBroadcastXML.YesNo.N
            StationOrderList(0).Station = New DTO.Media.RadioBroadcastXML.Station

            StationID = New Generic.List(Of DTO.Media.RadioBroadcastXML.ID)
            StationID.Add(New DTO.Media.RadioBroadcastXML.ID)

            StationID(0).Comment = New DTO.Media.RadioBroadcastXML.Comment
            StationID(0).Comment.ownerDescription = "String"
            StationID(0).Comment.description = "String"
            StationID(0).Comment.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
            StationID(0).Comment.groupID = "1"

            StationID(0).Comment.CommentLine = {"String"}

            StationID(0).Code = New DTO.Media.RadioBroadcastXML.IDCode
            StationID(0).Code.ownerDescription = "String"
            StationID(0).Code.description = "String"
            StationID(0).Code.owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency

            If MediaBroadcastWorksheetMarket IsNot Nothing Then

                GetRadioStationMetadata(MediaBroadcastWorksheetMarket.ExternalRadioSource, RadioOrder.Vendor, Session, StationID(0).Code.Value, StationOrderList(0).Station.Band, StationOrderList(0).Station.StationName, StationOrderList(0).Station.Frequency)

            End If

            If String.IsNullOrWhiteSpace(StationOrderList(0).Station.StationName) Then

                StationOrderList(0).Station.StationName = RadioOrder.Vendor.Name

            End If

            StationOrderList(0).Station.ID = StationID.ToArray

            PopulationsList = New Generic.List(Of DTO.Media.RadioBroadcastXML.Populations)
            PopulationsList.Add(New DTO.Media.RadioBroadcastXML.Populations)
            PopulationsList(0).demoIndex = "1"

            If AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, OrderNumberSearchResult.WorksheetMarketID).Count > 0 Then

                PopulationsList(0).Value = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, OrderNumberSearchResult.WorksheetMarketID).First.PrimaryUniverse.ToString

            Else

                PopulationsList(0).Value = "0"

            End If

            StationOrderList(0).Populations = PopulationsList.ToArray

            BuyLineList = New Generic.List(Of DTO.Media.RadioBroadcastXML.BuyLine)

            For Each RadioOrderDetail In RadioOrderDetails

                BuyLine = New DTO.Media.RadioBroadcastXML.BuyLine

                BuyLine.tradeFlag = DTO.Media.RadioBroadcastXML.BuyLineTradeFlag.Cash
                BuyLine.action = DTO.Media.RadioBroadcastXML.BuyLineAction.Add
                BuyLine.acceptedFlag = DTO.Media.RadioBroadcastXML.YesNo.Y
                BuyLine.UniversalBuyLineID = RadioOrderDetail.LineNumber * 1000 + If(RadioOrderDetail.LinkLineNumber.GetValueOrDefault(0) > 0, RadioOrderDetail.LinkLineNumber.GetValueOrDefault(0) - 1, 0)

                If RadioOrderDetail.DaypartID.HasValue Then

                    Daypart = AdvantageFramework.Database.Procedures.Daypart.LoadByDaypartID(DbContext, RadioOrderDetail.DaypartID.Value)

                    If Daypart IsNot Nothing Then

                        DaypartDaypartCodeList = New Generic.List(Of DTO.Media.RadioBroadcastXML.DaypartDaypartCode)
                        DaypartDaypartCodeList.Add(New DTO.Media.RadioBroadcastXML.DaypartDaypartCode)
                        DaypartDaypartCodeList(0).owner = DTO.Media.RadioBroadcastXML.OwnerType.Agency
                        DaypartDaypartCodeList(0).Text = {Daypart.Description}

                        BuyLine.Daypart = DaypartDaypartCodeList.ToArray

                        BuyLine.Program = Daypart.Description

                    End If

                End If

                If RadioOrderDetail.Length.HasValue Then

                    BuyLine.SpotLength = RadioOrderDetail.Length.Value

                Else

                    BuyLine.SpotLength = 1

                End If

                BuyLine.StartDate = RadioOrderDetail.StartDate.Value
                BuyLine.EndDate = RadioOrderDetail.EndDate.Value

                DayTimeList = New Generic.List(Of DTO.Media.RadioBroadcastXML.DayTime)
                DayTimeList.Add(New DTO.Media.RadioBroadcastXML.DayTime)
                DayTimeList(0).StartTime = RadioOrderDetail.StartTime.Replace(" AM", "a").Replace(" PM", "p")
                DayTimeList(0).EndTime = RadioOrderDetail.EndTime.Replace(" AM", "a").Replace(" PM", "p")
                DayTimeList(0).DaysOfWeek = New DTO.Media.RadioBroadcastXML.DaysOfWeek
                DayTimeList(0).DaysOfWeek.Monday = If(RadioOrderDetail.Monday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Tuesday = If(RadioOrderDetail.Tuesday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Wednesday = If(RadioOrderDetail.Wednesday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Thursday = If(RadioOrderDetail.Thursday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Friday = If(RadioOrderDetail.Friday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Saturday = If(RadioOrderDetail.Saturday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)
                DayTimeList(0).DaysOfWeek.Sunday = If(RadioOrderDetail.Sunday.GetValueOrDefault(0) = 1, DTO.Media.RadioBroadcastXML.YesNo.Y, DTO.Media.RadioBroadcastXML.YesNo.N)

                BuyLine.DayTime = DayTimeList.ToArray

                BuyLine.WeekStartDay = DTO.Media.RadioBroadcastXML.WeekStartDay.Item1
                BuyLine.WeekStartDaySpecified = True

                AirPeriodList = New Generic.List(Of DTO.Media.RadioBroadcastXML.AirPeriod)

                If RadioOrderDetail.Date1.HasValue Then

                    AirPeriodList.Add(New DTO.Media.RadioBroadcastXML.AirPeriod)
                    AirPeriodList(AirPeriodList.Count - 1).StartDate = RadioOrderDetail.Date1.Value
                    If RadioOrderDetail.BuyType = "DB" Then
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date1.Value
                    Else
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date1.Value.AddDays(6)
                    End If
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity = New DTO.Media.RadioBroadcastXML.SpotQuantity
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity.Value = RadioOrderDetail.Spots1.GetValueOrDefault(0).ToString
                    AirPeriodList(AirPeriodList.Count - 1).UnitRate = RadioOrderDetail.GrossRate
                    AirPeriodList(AirPeriodList.Count - 1).UnitRateSpecified = True

                End If
                If RadioOrderDetail.Date2.HasValue Then

                    AirPeriodList.Add(New DTO.Media.RadioBroadcastXML.AirPeriod)
                    AirPeriodList(AirPeriodList.Count - 1).StartDate = RadioOrderDetail.Date2.Value
                    If RadioOrderDetail.BuyType = "DB" Then
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date2.Value
                    Else
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date2.Value.AddDays(6)
                    End If
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity = New DTO.Media.RadioBroadcastXML.SpotQuantity
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity.Value = RadioOrderDetail.Spots2.GetValueOrDefault(0).ToString
                    AirPeriodList(AirPeriodList.Count - 1).UnitRate = RadioOrderDetail.GrossRate
                    AirPeriodList(AirPeriodList.Count - 1).UnitRateSpecified = True

                End If
                If RadioOrderDetail.Date3.HasValue Then

                    AirPeriodList.Add(New DTO.Media.RadioBroadcastXML.AirPeriod)
                    AirPeriodList(AirPeriodList.Count - 1).StartDate = RadioOrderDetail.Date3.Value
                    If RadioOrderDetail.BuyType = "DB" Then
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date3.Value
                    Else
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date3.Value.AddDays(6)
                    End If
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity = New DTO.Media.RadioBroadcastXML.SpotQuantity
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity.Value = RadioOrderDetail.Spots3.GetValueOrDefault(0).ToString
                    AirPeriodList(AirPeriodList.Count - 1).UnitRate = RadioOrderDetail.GrossRate
                    AirPeriodList(AirPeriodList.Count - 1).UnitRateSpecified = True

                End If
                If RadioOrderDetail.Date4.HasValue Then

                    AirPeriodList.Add(New DTO.Media.RadioBroadcastXML.AirPeriod)
                    AirPeriodList(AirPeriodList.Count - 1).StartDate = RadioOrderDetail.Date4.Value
                    If RadioOrderDetail.BuyType = "DB" Then
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date4.Value
                    Else
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date4.Value.AddDays(6)
                    End If
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity = New DTO.Media.RadioBroadcastXML.SpotQuantity
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity.Value = RadioOrderDetail.Spots4.GetValueOrDefault(0).ToString
                    AirPeriodList(AirPeriodList.Count - 1).UnitRate = RadioOrderDetail.GrossRate
                    AirPeriodList(AirPeriodList.Count - 1).UnitRateSpecified = True

                End If
                If RadioOrderDetail.Date5.HasValue Then

                    AirPeriodList.Add(New DTO.Media.RadioBroadcastXML.AirPeriod)
                    AirPeriodList(AirPeriodList.Count - 1).StartDate = RadioOrderDetail.Date5.Value
                    If RadioOrderDetail.BuyType = "DB" Then
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date5.Value
                    Else
                        AirPeriodList(AirPeriodList.Count - 1).EndDate = RadioOrderDetail.Date5.Value.AddDays(6)
                    End If
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity = New DTO.Media.RadioBroadcastXML.SpotQuantity
                    AirPeriodList(AirPeriodList.Count - 1).SpotQuantity.Value = RadioOrderDetail.Spots5.GetValueOrDefault(0).ToString
                    AirPeriodList(AirPeriodList.Count - 1).UnitRate = RadioOrderDetail.GrossRate
                    AirPeriodList(AirPeriodList.Count - 1).UnitRateSpecified = True

                End If

                BuyLine.AirPeriod = AirPeriodList.ToArray

                If MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                    MBWMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                       Where Entity.OrderNumber = RadioOrder.OrderNumber AndAlso
                                             Entity.OrderLineNumber = RadioOrderDetail.LineNumber
                                       Select Entity.MediaBroadcastWorksheetMarketDetail).FirstOrDefault

                    If MBWMarketDetail IsNot Nothing Then

                        DemoValueTypeList = New Generic.List(Of DTO.Media.RadioBroadcastXML.DemoValueType)
                        DemoValueTypeList.Add(New DTO.Media.RadioBroadcastXML.DemoValueType)
                        DemoValueTypeList(0).demoIndex = "1"
                        DemoValueTypeList(0).Rating = FormatNumber(MBWMarketDetail.PrimaryAQHRating, 2)
                        DemoValueTypeList(0).RatingSpecified = True
                        DemoValueTypeList(0).Impressions = MBWMarketDetail.PrimaryGrossImpressions

                        If MBWMarketDetail.PrimaryAQHRating <> 0 Then

                            DemoValueTypeList(0).CPP = FormatNumber(RadioOrderDetail.GrossRate / MBWMarketDetail.PrimaryAQHRating, 2)
                            DemoValueTypeList(0).CPPSpecified = True

                        Else

                            DemoValueTypeList(0).CPP = 0
                            DemoValueTypeList(0).CPPSpecified = True

                        End If

                        BuyLine.DemoValues = DemoValueTypeList.ToArray

                    End If

                End If

                BuyLineList.Add(BuyLine)

            Next

            StationOrderList(0).BuyLine = BuyLineList.ToArray

            OrderList(0).StationOrder = StationOrderList.ToArray

            Transmission.Transaction.Campaign.Order = OrderList.ToArray

            ''
            XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.DTO.Media.RadioBroadcastXML.Transmission))

            MemoryStream = New System.IO.MemoryStream()

            XmlSerializer.Serialize(MemoryStream, Transmission, XmlSerializerNamespaces)

            'Try

            '    Dim FileStream As System.IO.FileStream = Nothing

            '    FileStream = New System.IO.FileStream("C:\Users\mikec\Desktop\Radio XML\RadioBcast.xml", System.IO.FileMode.Create, System.IO.FileAccess.Write)

            '    MemoryStream.WriteTo(FileStream)
            '    FileStream.Close()

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

            BuildRadioBroadcastXMLFile = MemoryStream

        End Function
        Private Function GetBookNameComplexType(NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext, IndexKey As String, NielsenRadioPeriodID As Integer) As DTO.Media.RadioBroadcastXML.BookNameComplexType

            'objects
            Dim BookNameComplexType As DTO.Media.RadioBroadcastXML.BookNameComplexType = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim NielsenRadioReportType As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioReportType = Nothing

            BookNameComplexType = New DTO.Media.RadioBroadcastXML.BookNameComplexType

            BookNameComplexType.indexKey = IndexKey

            NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, NielsenRadioPeriodID)

            If NielsenRadioPeriod IsNot Nothing Then

                If NielsenRadioPeriod.Source = Nielsen.Database.Entities.Methods.RadioSource.Nielsen Then

                    BookNameComplexType.RatingService = Nielsen.Database.Entities.Methods.RadioSource.Nielsen.ToString

                ElseIf NielsenRadioPeriod.Source = Nielsen.Database.Entities.Methods.RadioSource.Eastlan Then

                    BookNameComplexType.RatingService = Nielsen.Database.Entities.Methods.RadioSource.Eastlan.ToString

                End If

                NielsenRadioReportType = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioReportType.Load(NielsenDbContext)
                                          Where Entity.Code = NielsenRadioPeriod.NielsenRadioReportTypeCode
                                          Select Entity).SingleOrDefault

                If NielsenRadioReportType IsNot Nothing Then

                    BookNameComplexType.Geography = NielsenRadioReportType.Name

                End If

                BookNameComplexType.Items = {NielsenRadioPeriod.Name}

            End If

            GetBookNameComplexType = BookNameComplexType

        End Function

#End Region

    End Module

    Friend Class BreakoutMonth

        Public Property Cost As Decimal
        Public Property Spots As Integer
        Public Property Year As Short
        Public Property Month As Short

    End Class
End Namespace
