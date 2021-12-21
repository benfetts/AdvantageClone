Namespace Media.Classes

    <Serializable()>
    Public Class OrderPrintSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            MediaType
            LocationID
            LogoPath
            ReportLevel
            DateOverride
            Rep1Label
            Rep2Label
            IncludeRep1
            IncludeRep2
            ReportFormat
            Headline
            Location
            Edition
            Material
            ProductionSize
            SpaceCloseDate
            AdNumber
            JobNumber
            MaterialNotes
            PositionInfo
            CloseInfo
            RateInfo
            MiscInfo
            Instructions
            OrderCopy
            MaterialDueDate
            Issue
            Type
            CopyArea
            Placement1
            Placement2
            URL
            TargetAudience
            Section
            DefaultLabelFromVendor1
            DefaultLabelFromVendor2
            Market
            Guaranteed
            Projected
            Actual
            CostPer
            MediaTitleOption
            Campaign
            ShippingAddress
            ExcludeEmployeeSignature
            Programming
            StartTime
            EndTime
            Length
            Remarks
            PrintRevision
            PrintClientName
            PrintDivisionName
            PrintProductDescription
            OrderHeaderCommentOption
            Days
            Daypart
            AddedValue
            Bookends
            PrimaryRatings
            PrimaryCPP
            SeparationPolicy
            AgencyCommission
            PutSignatureBelowAllComments
            PrintDayDate
            PrimaryCPM
            PrimaryImpressions
            PrimaryAQH
            RemoveSignatureLines
            ShowLineNumbers
            IncludeFlighting
            IncludeLineMarket
            IsDaily
            InternetQtyOverrideText
            BroadcastShowEmptyWeeks
            ApplyExchangeRate
            ExchangeRate
            MediaTitleOverride
            IncludeClientAddress
            IncludeImpressions
        End Enum

#End Region

#Region " Variables "

        Private _MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing

#End Region

#Region " Properties "

        Public Property UserCode As String
        Public Property MediaType As String
        Public Property LocationID As String
        Public Property LogoPath As String
        Public Property ReportLevel As String
        Public Property DateOverride As Integer
        Public Property Rep1Label As String
        Public Property Rep2Label As String
        Public Property IncludeRep1 As Boolean
        Public Property IncludeRep2 As Boolean
        Public Property ReportFormat As String
        Public Property Headline As Boolean
        Public Property Location As Boolean
        Public Property Edition As Boolean
        Public Property Material As Boolean
        Public Property ProductionSize As Boolean
        Public Property SpaceCloseDate As Boolean
        Public Property AdNumber As Boolean
        Public Property JobNumber As Boolean
        Public Property MaterialNotes As Boolean
        Public Property PositionInfo As Boolean
        Public Property CloseInfo As Boolean
        Public Property RateInfo As Boolean
        Public Property MiscInfo As Boolean
        Public Property Instructions As Boolean
        Public Property OrderCopy As Boolean
        Public Property MaterialDueDate As Boolean
        Public Property Issue As Boolean
        Public Property Type As Boolean
        Public Property CopyArea As Boolean
        Public Property Placement1 As Boolean
        Public Property Placement2 As Boolean
        Public Property URL As Boolean
        Public Property TargetAudience As Boolean
        Public Property Section As Boolean
        Public Property DefaultLabelFromVendor1 As Boolean
        Public Property DefaultLabelFromVendor2 As Boolean
        Public Property Market As Boolean
        Public Property Guaranteed As Boolean
        Public Property Projected As Boolean
        Public Property Actual As Boolean
        Public Property CostPer As Boolean
        Public Property MediaTitleOption As String
        Public Property Campaign As Boolean
        Public Property ShippingAddress As Boolean
        Public Property ExcludeEmployeeSignature As Boolean
        Public Property Programming As Boolean
        Public Property StartTime As Boolean
        Public Property EndTime As Boolean
        Public Property Length As Boolean
        Public Property Remarks As Boolean
        Public Property PrintRevision As Boolean
        Public Property PrintClientName As Boolean
        Public Property PrintDivisionName As Boolean
        Public Property PrintProductDescription As Boolean
        Public Property OrderHeaderCommentOption As Short
        Public Property Days As Boolean
        Public Property Daypart As Boolean
        Public Property AddedValue As Boolean
        Public Property Bookends As Boolean
        Public Property PrimaryRatings As Boolean
        Public Property PrimaryCPP As Boolean
        Public Property SeparationPolicy As Boolean
        Public Property AgencyCommission As Boolean
        Public Property PutSignatureBelowAllComments As Boolean
        Public Property PrintDayDate As Boolean
        Public Property PrimaryCPM As Boolean
        Public Property PrimaryImpressions As Boolean
        Public Property PrimaryAQH As Boolean
        Public Property RemoveSignatureLines As Boolean
        Public Property ShowLineNumbers As Boolean
        Public Property IncludeFlighting As Boolean
        Public Property IncludeLineMarket As Boolean
        Public Property IsDaily As Boolean
        Public Property InternetQtyOverrideText As String
        Public Property BroadcastShowEmptyWeeks As Boolean
        Public Property ApplyExchangeRate As Boolean
        Public Property ExchangeRate As Nullable(Of Decimal)
        Public Property MediaTitleOverride As String
        Public Property IncludeClientAddress As Boolean
        Public Property IncludeImpressions As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaTitleOverride = ""

        End Sub
        Public Sub New(MediaType As String)

            Me.MediaType = MediaType

            Me.IncludeImpressions = False

            If Me.MediaType = "R" OrElse Me.MediaType = "T" Then

                Me.ReportFormat = "4"

                Me.Days = True
                Me.Daypart = True
                Me.AddedValue = True
                Me.Bookends = True
                Me.PrimaryRatings = True
                Me.PrimaryCPP = True
                Me.SeparationPolicy = True
                Me.AgencyCommission = True

                Me.PrimaryCPM = False
                Me.PrimaryImpressions = False
                Me.PrimaryAQH = False

            ElseIf Me.MediaType = "I" Then

                Me.ReportFormat = CStr(AdvantageFramework.Media.InternetOrderFormats.Portrait)
                Me.PrintDayDate = True

            Else

                Me.ReportFormat = CStr(AdvantageFramework.Media.NonBroadcastMediaOrderFormats.Portrait)
                Me.PrintDayDate = True

            End If

            Me.DateOverride = 0
            Me.OrderHeaderCommentOption = 0

            Me.MediaTitleOption = "O"

            If ((Me.ReportFormat = "4") OrElse (Me.ReportFormat = "5") OrElse (Me.ReportFormat = "6")) Then

                Me.Programming = True
                Me.StartTime = True
                Me.EndTime = True
                Me.Length = True
                Me.Remarks = True

            End If

            Me.MediaTitleOverride = ""
            Me.IncludeClientAddress = False

        End Sub
        Public Sub New(MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting, IsDaily As Boolean)

            Me.UserCode = MediaOrderPrintSetting.UserCode
            Me.MediaType = MediaOrderPrintSetting.MediaType
            Me.LocationID = MediaOrderPrintSetting.LocationID
            Me.LogoPath = MediaOrderPrintSetting.LogoPath
            Me.ReportLevel = MediaOrderPrintSetting.ReportLevel
            Me.DateOverride = MediaOrderPrintSetting.DateOverride.GetValueOrDefault(0)
            Me.Rep1Label = MediaOrderPrintSetting.Rep1Label
            Me.Rep2Label = MediaOrderPrintSetting.Rep2Label
            Me.IncludeRep1 = Convert.ToBoolean(MediaOrderPrintSetting.IncludeRep1.GetValueOrDefault(0))
            Me.IncludeRep2 = Convert.ToBoolean(MediaOrderPrintSetting.IncludeRep2.GetValueOrDefault(0))
            Me.IsDaily = IsDaily

            If String.IsNullOrWhiteSpace(MediaOrderPrintSetting.ReportFormat) Then

                If String.IsNullOrWhiteSpace(MediaOrderPrintSetting.MediaType) = False Then

                    If MediaOrderPrintSetting.MediaType = "R" OrElse MediaOrderPrintSetting.MediaType = "T" Then

                        If (IsDaily) Then

                            Me.ReportFormat = "5"

                        Else

                            Me.ReportFormat = "4"

                        End If

                    Else

                        Me.ReportFormat = "1"

                    End If

                End If

            Else

                If String.IsNullOrWhiteSpace(MediaOrderPrintSetting.MediaType) = False Then

                    If MediaOrderPrintSetting.MediaType = "R" OrElse MediaOrderPrintSetting.MediaType = "T" Then

                        If ((Not IsDaily) AndAlso Not (MediaOrderPrintSetting.ReportFormat = "4")) Then

                            MediaOrderPrintSetting.ReportFormat = "4"

                        End If

                    End If

                End If

                Me.ReportFormat = MediaOrderPrintSetting.ReportFormat

            End If

            Me.Headline = Convert.ToBoolean(MediaOrderPrintSetting.Headline.GetValueOrDefault(0))
            Me.Location = Convert.ToBoolean(MediaOrderPrintSetting.Location.GetValueOrDefault(0))
            Me.Edition = Convert.ToBoolean(MediaOrderPrintSetting.Edition.GetValueOrDefault(0))
            Me.Material = Convert.ToBoolean(MediaOrderPrintSetting.Material.GetValueOrDefault(0))
            Me.ProductionSize = Convert.ToBoolean(MediaOrderPrintSetting.ProductionSize.GetValueOrDefault(0))
            Me.SpaceCloseDate = Convert.ToBoolean(MediaOrderPrintSetting.SpaceCloseDate.GetValueOrDefault(0))
            Me.AdNumber = Convert.ToBoolean(MediaOrderPrintSetting.AdNumber.GetValueOrDefault(0))
            Me.JobNumber = Convert.ToBoolean(MediaOrderPrintSetting.JobNumber.GetValueOrDefault(0))
            Me.MaterialNotes = Convert.ToBoolean(MediaOrderPrintSetting.MaterialNotes.GetValueOrDefault(0))
            Me.PositionInfo = Convert.ToBoolean(MediaOrderPrintSetting.PositionInfo.GetValueOrDefault(0))
            Me.CloseInfo = Convert.ToBoolean(MediaOrderPrintSetting.CloseInfo.GetValueOrDefault(0))
            Me.RateInfo = Convert.ToBoolean(MediaOrderPrintSetting.RateInfo.GetValueOrDefault(0))
            Me.MiscInfo = Convert.ToBoolean(MediaOrderPrintSetting.MiscInfo.GetValueOrDefault(0))
            Me.Instructions = Convert.ToBoolean(MediaOrderPrintSetting.Instructions.GetValueOrDefault(0))
            Me.OrderCopy = Convert.ToBoolean(MediaOrderPrintSetting.OrderCopy.GetValueOrDefault(0))
            Me.MaterialDueDate = Convert.ToBoolean(MediaOrderPrintSetting.MaterialDueDate.GetValueOrDefault(0))
            Me.Issue = Convert.ToBoolean(MediaOrderPrintSetting.Issue.GetValueOrDefault(0))
            Me.Type = Convert.ToBoolean(MediaOrderPrintSetting.Type.GetValueOrDefault(0))
            Me.CopyArea = Convert.ToBoolean(MediaOrderPrintSetting.CopyArea.GetValueOrDefault(0))
            Me.Placement1 = Convert.ToBoolean(MediaOrderPrintSetting.Placement1.GetValueOrDefault(0))
            Me.Placement2 = Convert.ToBoolean(MediaOrderPrintSetting.Placement2.GetValueOrDefault(0))
            Me.URL = Convert.ToBoolean(MediaOrderPrintSetting.URL.GetValueOrDefault(0))
            Me.TargetAudience = Convert.ToBoolean(MediaOrderPrintSetting.TargetAudience.GetValueOrDefault(0))
            Me.Section = Convert.ToBoolean(MediaOrderPrintSetting.Section.GetValueOrDefault(0))
            Me.DefaultLabelFromVendor1 = Convert.ToBoolean(MediaOrderPrintSetting.DefaultLabelFromVendor1.GetValueOrDefault(0))
            Me.DefaultLabelFromVendor2 = Convert.ToBoolean(MediaOrderPrintSetting.DefaultLabelFromVendor2.GetValueOrDefault(0))
            Me.Market = Convert.ToBoolean(MediaOrderPrintSetting.Market.GetValueOrDefault(0))
            Me.Guaranteed = Convert.ToBoolean(MediaOrderPrintSetting.Guaranteed.GetValueOrDefault(0))
            Me.Projected = Convert.ToBoolean(MediaOrderPrintSetting.Projected.GetValueOrDefault(0))
            Me.Actual = Convert.ToBoolean(MediaOrderPrintSetting.Actual.GetValueOrDefault(0))
            Me.CostPer = Convert.ToBoolean(MediaOrderPrintSetting.CostPer.GetValueOrDefault(0))

            If String.IsNullOrWhiteSpace(MediaOrderPrintSetting.MediaTitleOption) Then

                Me.MediaTitleOption = "O"

            Else

                Me.MediaTitleOption = MediaOrderPrintSetting.MediaTitleOption

            End If

            Me.Campaign = Convert.ToBoolean(MediaOrderPrintSetting.Campaign.GetValueOrDefault(0))
            Me.ShippingAddress = Convert.ToBoolean(MediaOrderPrintSetting.ShippingAddress.GetValueOrDefault(0))
            Me.ExcludeEmployeeSignature = Convert.ToBoolean(MediaOrderPrintSetting.ExcludeEmployeeSignature.GetValueOrDefault(0))

            If ((Me.ReportFormat = "4") OrElse (Me.ReportFormat = "5") OrElse (Me.ReportFormat = "6")) Then

                Me.Programming = True
                Me.StartTime = True
                Me.EndTime = True
                Me.Length = True
                Me.Remarks = Convert.ToBoolean(MediaOrderPrintSetting.Remarks.GetValueOrDefault(0))

            Else

                Me.Programming = Convert.ToBoolean(MediaOrderPrintSetting.Programming.GetValueOrDefault(0))
                Me.StartTime = Convert.ToBoolean(MediaOrderPrintSetting.StartTime.GetValueOrDefault(0))
                Me.EndTime = Convert.ToBoolean(MediaOrderPrintSetting.EndTime.GetValueOrDefault(0))
                Me.Length = Convert.ToBoolean(MediaOrderPrintSetting.Length.GetValueOrDefault(0))
                Me.Remarks = Convert.ToBoolean(MediaOrderPrintSetting.Remarks.GetValueOrDefault(0))

            End If

            Me.PrintRevision = MediaOrderPrintSetting.PrintRevision.GetValueOrDefault(False)
            Me.PrintClientName = MediaOrderPrintSetting.PrintClientName.GetValueOrDefault(False)
            Me.PrintDivisionName = MediaOrderPrintSetting.PrintDivisionName.GetValueOrDefault(False)
            Me.PrintProductDescription = MediaOrderPrintSetting.PrintProductDescription.GetValueOrDefault(False)
            Me.OrderHeaderCommentOption = MediaOrderPrintSetting.OrderHeaderCommentOption.GetValueOrDefault(0)
            Me.Days = MediaOrderPrintSetting.Days.GetValueOrDefault(False)
            Me.Daypart = MediaOrderPrintSetting.Daypart.GetValueOrDefault(False)
            Me.AddedValue = MediaOrderPrintSetting.AddedValue.GetValueOrDefault(False)
            Me.Bookends = MediaOrderPrintSetting.Bookends.GetValueOrDefault(False)
            Me.PrimaryRatings = MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False)
            Me.PrimaryCPP = MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False)
            Me.SeparationPolicy = MediaOrderPrintSetting.SeparationPolicy.GetValueOrDefault(False)
            Me.AgencyCommission = MediaOrderPrintSetting.AgencyCommission
            Me.PutSignatureBelowAllComments = MediaOrderPrintSetting.PutSignatureBelowAllComments
            Me.PrintDayDate = MediaOrderPrintSetting.PrintDayDate
            Me.PrimaryCPM = MediaOrderPrintSetting.PrimaryCPM
            Me.PrimaryImpressions = MediaOrderPrintSetting.PrimaryImpressions
            Me.PrimaryAQH = MediaOrderPrintSetting.PrimaryAQH
            Me.RemoveSignatureLines = MediaOrderPrintSetting.RemoveSignatureLines
            Me.ShowLineNumbers = MediaOrderPrintSetting.ShowLineNumbers
            Me.IncludeFlighting = MediaOrderPrintSetting.IncludeFlighting
            Me.IncludeLineMarket = MediaOrderPrintSetting.IncludeLineMarket
            Me.InternetQtyOverrideText = MediaOrderPrintSetting.InternetQtyOverrideText
            Me.BroadcastShowEmptyWeeks = MediaOrderPrintSetting.BroadcastShowEmptyWeeks
            Me.ApplyExchangeRate = MediaOrderPrintSetting.ApplyExchangeRate
            Me.ExchangeRate = MediaOrderPrintSetting.ExchangeRate
            Me.MediaTitleOverride = MediaOrderPrintSetting.MediaTitleOverride
            Me.IncludeClientAddress = MediaOrderPrintSetting.IncludeClientAddress
            Me.IncludeImpressions = CBool(MediaOrderPrintSetting.IncludeImpressions.GetValueOrDefault(0))

            _MediaOrderPrintSetting = MediaOrderPrintSetting

        End Sub
        Public Function GetEntity() As AdvantageFramework.Database.Entities.MediaOrderPrintSetting

            If _MediaOrderPrintSetting IsNot Nothing Then

                GetEntity = _MediaOrderPrintSetting

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As AdvantageFramework.Database.Entities.MediaOrderPrintSetting

            Save()

            If _MediaOrderPrintSetting IsNot Nothing Then

                SaveAndGetEntity = _MediaOrderPrintSetting

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _MediaOrderPrintSetting IsNot Nothing Then

                Save(_MediaOrderPrintSetting)

            End If

        End Sub
        Public Sub Save(MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting)

            'MediaOrderPrintSetting.UserCode = Me.UserCode
            'MediaOrderPrintSetting.MediaType = Me.MediaType
            MediaOrderPrintSetting.LocationID = Me.LocationID
            MediaOrderPrintSetting.LogoPath = Me.LogoPath
            MediaOrderPrintSetting.ReportLevel = Me.ReportLevel
            MediaOrderPrintSetting.DateOverride = Convert.ToInt16(Me.DateOverride)
            MediaOrderPrintSetting.Rep1Label = Me.Rep1Label
            MediaOrderPrintSetting.Rep2Label = Me.Rep2Label
            MediaOrderPrintSetting.IncludeRep1 = Convert.ToInt16(Me.IncludeRep1)
            MediaOrderPrintSetting.IncludeRep2 = Convert.ToInt16(Me.IncludeRep2)
            MediaOrderPrintSetting.ReportFormat = Convert.ToInt16(Me.ReportFormat)
            MediaOrderPrintSetting.Headline = Convert.ToInt16(Me.Headline)
            MediaOrderPrintSetting.Location = Convert.ToInt16(Me.Location)
            MediaOrderPrintSetting.Edition = Convert.ToInt16(Me.Edition)
            MediaOrderPrintSetting.Material = Convert.ToInt16(Me.Material)
            MediaOrderPrintSetting.ProductionSize = Convert.ToInt16(Me.ProductionSize)
            MediaOrderPrintSetting.SpaceCloseDate = Convert.ToInt16(Me.SpaceCloseDate)
            MediaOrderPrintSetting.AdNumber = Convert.ToInt16(Me.AdNumber)
            MediaOrderPrintSetting.JobNumber = Convert.ToInt16(Me.JobNumber)
            MediaOrderPrintSetting.MaterialNotes = Convert.ToInt16(Me.MaterialNotes)
            MediaOrderPrintSetting.PositionInfo = Convert.ToInt16(Me.PositionInfo)
            MediaOrderPrintSetting.CloseInfo = Convert.ToInt16(Me.CloseInfo)
            MediaOrderPrintSetting.RateInfo = Convert.ToInt16(Me.RateInfo)
            MediaOrderPrintSetting.MiscInfo = Convert.ToInt16(Me.MiscInfo)
            MediaOrderPrintSetting.Instructions = Convert.ToInt16(Me.Instructions)
            MediaOrderPrintSetting.OrderCopy = Convert.ToInt16(Me.OrderCopy)
            MediaOrderPrintSetting.MaterialDueDate = Convert.ToInt16(Me.MaterialDueDate)
            MediaOrderPrintSetting.Issue = Convert.ToInt16(Me.Issue)
            MediaOrderPrintSetting.Type = Convert.ToInt16(Me.Type)
            MediaOrderPrintSetting.CopyArea = Convert.ToInt16(Me.CopyArea)
            MediaOrderPrintSetting.Placement1 = Convert.ToInt16(Me.Placement1)
            MediaOrderPrintSetting.Placement2 = Convert.ToInt16(Me.Placement2)
            MediaOrderPrintSetting.URL = Convert.ToInt16(Me.URL)
            MediaOrderPrintSetting.TargetAudience = Convert.ToInt16(Me.TargetAudience)
            MediaOrderPrintSetting.Section = Convert.ToInt16(Me.Section)
            MediaOrderPrintSetting.DefaultLabelFromVendor1 = Convert.ToInt16(Me.DefaultLabelFromVendor1)
            MediaOrderPrintSetting.DefaultLabelFromVendor2 = Convert.ToInt16(Me.DefaultLabelFromVendor2)
            MediaOrderPrintSetting.Market = Convert.ToInt16(Me.Market)
            MediaOrderPrintSetting.Guaranteed = Convert.ToInt16(Me.Guaranteed)
            MediaOrderPrintSetting.Projected = Convert.ToInt16(Me.Projected)
            MediaOrderPrintSetting.Actual = Convert.ToInt16(Me.Actual)
            MediaOrderPrintSetting.CostPer = Convert.ToInt16(Me.CostPer)
            MediaOrderPrintSetting.MediaTitleOption = Me.MediaTitleOption
            MediaOrderPrintSetting.Campaign = Convert.ToInt16(Me.Campaign)
            MediaOrderPrintSetting.ShippingAddress = Convert.ToInt16(Me.ShippingAddress)
            MediaOrderPrintSetting.ExcludeEmployeeSignature = Convert.ToInt16(Me.ExcludeEmployeeSignature)
            MediaOrderPrintSetting.Programming = Convert.ToInt16(Me.Programming)
            MediaOrderPrintSetting.StartTime = Convert.ToInt16(Me.StartTime)
            MediaOrderPrintSetting.EndTime = Convert.ToInt16(Me.EndTime)
            MediaOrderPrintSetting.Length = Convert.ToInt16(Me.Length)
            MediaOrderPrintSetting.Remarks = Convert.ToInt16(Me.Remarks)
            MediaOrderPrintSetting.PrintRevision = Me.PrintRevision
            MediaOrderPrintSetting.PrintClientName = Me.PrintClientName
            MediaOrderPrintSetting.PrintDivisionName = Me.PrintDivisionName
            MediaOrderPrintSetting.PrintProductDescription = Me.PrintProductDescription
            MediaOrderPrintSetting.OrderHeaderCommentOption = Me.OrderHeaderCommentOption
            MediaOrderPrintSetting.Days = Me.Days
            MediaOrderPrintSetting.Daypart = Me.Daypart
            MediaOrderPrintSetting.AddedValue = Me.AddedValue
            MediaOrderPrintSetting.Bookends = Me.Bookends
            MediaOrderPrintSetting.PrimaryRatings = Me.PrimaryRatings
            MediaOrderPrintSetting.PrimaryCPP = Me.PrimaryCPP
            MediaOrderPrintSetting.SeparationPolicy = Me.SeparationPolicy
            MediaOrderPrintSetting.AgencyCommission = Me.AgencyCommission
            MediaOrderPrintSetting.PutSignatureBelowAllComments = Me.PutSignatureBelowAllComments
            MediaOrderPrintSetting.PrintDayDate = Me.PrintDayDate
            MediaOrderPrintSetting.PrimaryCPM = Me.PrimaryCPM
            MediaOrderPrintSetting.PrimaryImpressions = Me.PrimaryImpressions
            MediaOrderPrintSetting.PrimaryAQH = Me.PrimaryAQH
            MediaOrderPrintSetting.RemoveSignatureLines = Me.RemoveSignatureLines
            MediaOrderPrintSetting.ShowLineNumbers = Me.ShowLineNumbers
            MediaOrderPrintSetting.IncludeFlighting = Me.IncludeFlighting
            MediaOrderPrintSetting.IncludeLineMarket = Me.IncludeLineMarket
            MediaOrderPrintSetting.InternetQtyOverrideText = Me.InternetQtyOverrideText
            MediaOrderPrintSetting.BroadcastShowEmptyWeeks = Me.BroadcastShowEmptyWeeks
            MediaOrderPrintSetting.ApplyExchangeRate = Me.ApplyExchangeRate
            MediaOrderPrintSetting.ExchangeRate = Me.ExchangeRate.GetValueOrDefault(1)
            MediaOrderPrintSetting.MediaTitleOverride = Me.MediaTitleOverride
            MediaOrderPrintSetting.IncludeClientAddress = Me.IncludeClientAddress
            MediaOrderPrintSetting.IncludeImpressions = If(Me.IncludeImpressions, 1, 0)

        End Sub

#End Region

    End Class

End Namespace
