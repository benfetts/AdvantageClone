Namespace Importing.Classes

    Public Class Broadcast4A

#Region " Constants "


#End Region

#Region " Classes "

        Public Class StationRecord

            Public Enum Properties
                CallLetters
                MediaType
                Band
                Name
                AddressLine1
                AddressLine2
                AddressLine3
                AddressLine4
                ComputerSystem
                GSTRegistrationNumber
                QSTRegistrationNumber
            End Enum

            <MaxLength(4)>
            Public Property CallLetters As String
            <MaxLength(2)>
            Public Property MediaType As String
            <MaxLength(2)>
            Public Property Band As String
            <MaxLength(30)>
            Public Property Name As String
            <MaxLength(30)>
            Public Property AddressLine1 As String
            <MaxLength(30)>
            Public Property AddressLine2 As String
            <MaxLength(30)>
            Public Property AddressLine3 As String
            <MaxLength(30)>
            Public Property AddressLine4 As String
            <MaxLength(15)>
            Public Property ComputerSystem As String
            <MaxLength(20)>
            Public Property GSTRegistrationNumber As String
            <MaxLength(20)>
            Public Property QSTRegistrationNumber As String

            Public ReadOnly Property AdvantageMediaType As String
                Get

                    'objects
                    Dim AdvMediaType As String = ""

                    Select Case Me.MediaType

                        Case "TV", "LC", "NC", "N"

                            AdvMediaType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Television).Code

                        Case "R", "X"

                            AdvMediaType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Radio).Code

                    End Select

                    AdvantageMediaType = AdvMediaType

                End Get
            End Property

        End Class

        Public Class PayeeRecord

            Public Enum Properties
                Name
                AddressLine1
                AddressLine2
                AddressLine3
                AddressLine4
            End Enum

            <MaxLength(30)>
            Public Property Name As String
            <MaxLength(30)>
            Public Property AddressLine1 As String
            <MaxLength(30)>
            Public Property AddressLine2 As String
            <MaxLength(30)>
            Public Property AddressLine3 As String
            <MaxLength(30)>
            Public Property AddressLine4 As String

        End Class

        Public Class InvoiceHeaderRecord

            Public Enum Properties
                Representative
                Salesperson
                AdvertiserName
                ProductName
                InvoiceDate
                OrderType
                AgencyEstimateCode
                Number
                BroadcastMonth
                PeriodStartDate
                PeriodEndDate
                ScheduleStartDate
                ScheduleEndDate
                ContractStartDate
                ContractEndDate
                BillingInstructions
                RateCardNumber
                AgencyCommissionFlag
                SalesTaxPercent
                AudiencePercent
                RepOrderNumber
                StationOrderNumber
                StationAdvertiserCode
                AgencyAdvertiserCode
                StationProductCode
                AgencyProductCode
                StationContact
                AgencyContact
                DueDate
                NetworkForLocalCable
                TradingPartnerCode
                DealNumber
                RepID
                PackageCode
                ReferenceInvoiceNumber
                ReferenceInvoiceCode
                VersionCode
                NationalLocalCode
                SpecialPayingRepCode
            End Enum

            <MaxLength(25)>
            Public Property Representative As String
            <MaxLength(25)>
            Public Property Salesperson As String
            <MaxLength(25)>
            Public Property AdvertiserName As String
            <MaxLength(25)>
            Public Property ProductName As String
            <MaxLength(6)>
            Public Property InvoiceDate As Date?
            <MaxLength(15)>
            Public Property OrderType As String
            <MaxLength(10)>
            Public Property AgencyEstimateCode As String
            <MaxLength(10)>
            Public Property Number As String
            <MaxLength(4)>
            Public Property BroadcastMonth As String
            <MaxLength(6)>
            Public Property PeriodStartDate As Date?
            <MaxLength(6)>
            Public Property PeriodEndDate As Date?
            <MaxLength(6)>
            Public Property ScheduleStartDate As Date?
            <MaxLength(6)>
            Public Property ScheduleEndDate As Date?
            <MaxLength(6)>
            Public Property ContractStartDate As Date?
            <MaxLength(6)>
            Public Property ContractEndDate As Date?
            <MaxLength(25)>
            Public Property BillingInstructions As String
            <MaxLength(10)>
            Public Property RateCardNumber As String
            <MaxLength(1)>
            Public Property AgencyCommissionFlag As String
            <MaxLength(10)>
            Public Property SalesTaxPercent As Decimal?
            <MaxLength(10)>
            Public Property AudiencePercent As Decimal?
            <MaxLength(10)>
            Public Property RepOrderNumber As String
            <MaxLength(10)>
            Public Property StationOrderNumber As String
            <MaxLength(8)>
            Public Property StationAdvertiserCode As String
            <MaxLength(6)>
            Public Property AgencyAdvertiserCode As String
            <MaxLength(8)>
            Public Property StationProductCode As String
            <MaxLength(6)>
            Public Property AgencyProductCode As String
            <MaxLength(25)>
            Public Property StationContact As String
            <MaxLength(25)>
            Public Property AgencyContact As String
            <MaxLength(6)>
            Public Property DueDate As Date?
            <MaxLength(4)>
            Public Property NetworkForLocalCable As String
            <MaxLength(8)>
            Public Property TradingPartnerCode As String
            <MaxLength(10)>
            Public Property DealNumber As String
            <MaxLength(10)>
            Public Property RepID As String
            <MaxLength(3)>
            Public Property PackageCode As String
            <MaxLength(10)>
            Public Property ReferenceInvoiceNumber As String
            <MaxLength(2)>
            Public Property ReferenceInvoiceCode As String
            <MaxLength(2)>
            Public Property VersionCode As String
            <MaxLength(2)>
            Public Property NationalLocalCode As String
            <MaxLength(3)>
            Public Property SpecialPayingRepCode As String

        End Class

        Public Class InvoiceCommentTopRecord

            Public Enum Properties
                Comment
            End Enum

            <MaxLength(130)>
            Public Property Comment As String

        End Class

        Public Class StandardCommentTopRecord

            Public Enum Properties
                Comment
            End Enum

            <MaxLength(130)>
            Public Property Comment As String

        End Class

        Public Class StandardCommentBottomRecord

            Public Enum Properties
                Comment
            End Enum

            <MaxLength(130)>
            Public Property Comment As String

        End Class

        Public Class ScheduleLineRecord

            Public Enum Properties
                Number
                DaysOfWeek
                StartTime
                EndTime
                RateDetail
                RatePerSpot
                NumberOfSpotsScheduleForLine
                StartDate
                EndDate
                PlanCode
                PackageCode
            End Enum

            <MaxLength(3)>
            Public Property Number As String
            <MaxLength(7)>
            Public Property DaysOfWeek As String
            <MaxLength(4)>
            Public Property StartTime As TimeSpan?
            <MaxLength(4)>
            Public Property EndTime As TimeSpan?
            <MaxLength(3)>
            Public Property RateDetail As String
            <MaxLength(10)>
            Public Property RatePerSpot As Decimal?
            <MaxLength(3)>
            Public Property NumberOfSpotsScheduleForLine As Integer?
            <MaxLength(6)>
            Public Property StartDate As Date?
            <MaxLength(6)>
            Public Property EndDate As Date?
            <MaxLength(10)>
            Public Property PlanCode As String
            <MaxLength(10)>
            Public Property PackageCode As String

            Public Property BroadCastDetails As List(Of BroadcastDetailRecord)
            Public Property ReconciliationRemarks As ReconciliationRemarksRecord

            Public Sub New()

                Me.BroadCastDetails = New List(Of BroadcastDetailRecord)

            End Sub

        End Class

        Public Class ScheduleCommentRecord

            Public Enum Properties
                Comment
            End Enum

            <MaxLength(130)>
            Public Property Comment As String

        End Class

        Public Class BroadcastDetailRecord

            Public Enum Properties
                RunCode
                RunDate
                DayOfWeek
                TimeOfDay
                Type
                CopyID
                Rate
                [Class]
                Piggyback
                MakegoodDate1
                MakegoodDate2
                MakegoodTime1
                MakegoodTime2
                MakegoodLineNumber
                AdjustmentDr
                AdjustmentCr
                ProgramDescription
                BillboardIndicator
                Length
                VideoCopyID
                AudioCopyID
                SerialNumber
                NetworkForLocalCable
                NetworkIntegrationCost
                PackageForNetworkOnly
            End Enum

            <MaxLength(1)>
            Public Property RunCode As String
            <MaxLength(6)>
            Public Property RunDate As Date
            <MaxLength(1)>
            Public Property DayOfWeek As Short?
            <MaxLength(4)>
            Public Property TimeOfDay As TimeSpan
            <MaxLength(3)>
            Public Property Type As Short
            <MaxLength(30)>
            Public Property CopyID As String
            <MaxLength(10)>
            Public Property Rate As Decimal
            <MaxLength(3)>
            Public Property [Class] As String
            <MaxLength(6)>
            Public Property Piggyback As Integer?
            <MaxLength(6)>
            Public Property MakegoodDate1 As Date?
            <MaxLength(6)>
            Public Property MakegoodDate2 As Date?
            <MaxLength(4)>
            Public Property MakegoodTime1 As String
            <MaxLength(4)>
            Public Property MakegoodTime2 As String
            <MaxLength(3)>
            Public Property MakegoodLineNumber As String
            <MaxLength(10)>
            Public Property AdjustmentDr As String
            <MaxLength(10)>
            Public Property AdjustmentCr As String
            <MaxLength(40)>
            Public Property ProgramDescription As String
            <MaxLength(1)>
            Public Property BillboardIndicator As String
            <MaxLength(3)>
            Public Property Length As Integer?
            <MaxLength(30)>
            Public Property VideoCopyID As String
            <MaxLength(30)>
            Public Property AudioCopyID As String
            <MaxLength(12)>
            Public Property SerialNumber As String
            <MaxLength(4)>
            Public Property NetworkForLocalCable As String
            <MaxLength(10)>
            Public Property NetworkIntegrationCost As String
            <MaxLength(3)>
            Public Property PackageForNetworkOnly As Integer?

        End Class

        Public Class ReconciliationRemarksRecord

            Public Enum Properties
                Remarks
            End Enum

            <MaxLength(130)>
            Public Property Remarks As String

        End Class

        Public Class InvoiceCommentBottomRecord

            Public Enum Properties
                Comment
            End Enum

            <MaxLength(130)>
            Public Property Comment As String

        End Class

        Public Class InvoiceTotalRecord

            Public Enum Properties
                ConfirmedCost
                ActualGrossBilling
                AgencyCommission
                NetDue
                ReconciliationDr
                ReconciliationCr
                ReconciliationTotal
                StateTax
                LocalTax
                PriorGrossBalance
                PriorNetBalance
                NumberOfSpots
                GST
                PST
            End Enum

            <MaxLength(2)>
            Public Property ConfirmedCost As String
            <MaxLength(11)>
            Public Property ActualGrossBilling As Decimal?
            <MaxLength(11)>
            Public Property AgencyCommission As Decimal?
            <MaxLength(11)>
            Public Property NetDue As Decimal?
            <MaxLength(11)>
            Public Property ReconciliationDr As String
            <MaxLength(11)>
            Public Property ReconciliationCr As String
            <MaxLength(11)>
            Public Property ReconciliationTotal As String
            <MaxLength(11)>
            Public Property StateTax As Decimal?
            <MaxLength(11)>
            Public Property LocalTax As Decimal?
            <MaxLength(11)>
            Public Property PriorGrossBalance As String
            <MaxLength(11)>
            Public Property PriorNetBalance As String
            <MaxLength(11)>
            Public Property NumberOfSpots As String
            <MaxLength(11)>
            Public Property GST As String
            <MaxLength(11)>
            Public Property PST As String

        End Class

        Public Class TransmissionTotalRecord

            Public Enum Properties
                TransmissionTotalNumberOfInvoices
                TransmissionTotalGrossTotal
            End Enum

            <MaxLength(5)>
            Public Property TransmissionTotalNumberOfInvoices As String
            <MaxLength(11)>
            Public Property TransmissionTotalGrossTotal As String

        End Class

#End Region

#Region " Methods "


#End Region

    End Class

End Namespace

