Namespace BillingCommandCenter.Database.Entities

    <Table("BILLING_CMD_CENTER")>
    Public Class BillingCommandCenter
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BillingUser
            CreateDate
            ProductionSelectBy
            IsProduction
            EmployeeTimeDateCutoff
            IncomeOnlyDateCutoff
            AdvanceBillingDateCutoff
            APPostPeriodCodeCutoff
            BillingApprovalBatchID
            IsMedia
            MediaSelectBy
            MediaEndDate
            IsNewspaper
            IsMagazine
            IsRadio
            IsTelevision
            IsOutOfHome
            IsInternet
            MediaBroadcastMonthStart
            MediaBroadcastMonthEnd
            IncludeZeroSpots
            MediaStartDate
            DateCuttoffToUseFlag
            IncludeUnbilledOrdersOnly
            ProductionSelectionOption
            IsRadioDaily
            IsTelevisionDaily
            IsRadioMonthly
            IsTelevisionMonthly
            BatchName
            SequenceNumber
            ProductionJobType
            IsProductionSelectionLocked
            IncludeLegacy
            JobMediaBillDateFrom
            JobMediaBillDateTo
            BillingApprovalBatch
            ProductionIncludeJobMediaBillDates
            ProductionJobMediaBillDateFrom
            ProductionJobMediaBillDateTo
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("BILLING_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUser() As String
        <Required>
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Date
        <Column("P_SELECT_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionSelectBy() As Nullable(Of Short)
        <Column("PROD_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsProduction() As Nullable(Of Boolean)
        <Column("P_ET_CUTOFF_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeDateCutoff() As Nullable(Of Date)
        <Column("P_IO_CUTOFF_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncomeOnlyDateCutoff() As Nullable(Of Date)
        <Column("P_AB_CUTOFF_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingDateCutoff() As Nullable(Of Date)
        <MaxLength(6)>
        <Column("P_AP_CUTOFF_PPD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APPostPeriodCodeCutoff() As String
        <Column("BA_BATCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalBatchID() As Nullable(Of Integer)
        <Column("MEDIA_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMedia() As Nullable(Of Boolean)
        <Column("M_SELECT_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaSelectBy() As Nullable(Of Short)
        <Column("M_CUTOFF_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaEndDate() As Nullable(Of Date)
        <Column("NEWSPAPER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNewspaper() As Nullable(Of Boolean)
        <Column("MAGAZINE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMagazine() As Nullable(Of Boolean)
        <Column("RADIO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsRadio() As Nullable(Of Boolean)
        <Column("TELEVISION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsTelevision() As Nullable(Of Boolean)
        <Column("OUT_OF_HOME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOutOfHome() As Nullable(Of Boolean)
        <Column("INTERNET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsInternet() As Nullable(Of Boolean)
        <Column("M_BRDCAST_MTH1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaBroadcastMonthStart() As Nullable(Of Date)
        <Column("M_BRDCAST_MTH2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaBroadcastMonthEnd() As Nullable(Of Date)
        <Column("INCL_ZERO_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeZeroSpots() As Nullable(Of Boolean)
        <Column("M_START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaStartDate() As Nullable(Of Date)
        <Column("DATE_CUTOFF_TO_USE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateCuttoffToUseFlag() As Nullable(Of Short)
        <Column("INCL_UNBILLED_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeUnbilledOrdersOnly() As Nullable(Of Short)
        <Column("SEL_OPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionSelectionOption() As Nullable(Of Short)
        <Column("RADIO_DAILY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsRadioDaily() As Nullable(Of Boolean)
        <Column("TV_DAILY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsTelevisionDaily() As Nullable(Of Boolean)
        <Column("RADIO_MONTHLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsRadioMonthly() As Nullable(Of Boolean)
        <Column("TV_MONTHLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsTelevisionMonthly() As Nullable(Of Boolean)
        <MaxLength(25)>
        <Column("BATCH_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BatchName() As String
        <Column("SEQ_NO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Short)
        <Column("PROD_JOB_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionJobType() As Nullable(Of Short)
        <Required>
        <Column("PROD_LOCK_SELECTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsProductionSelectionLocked() As Boolean
        <Required>
        <Column("INCLUDE_LEGACY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeLegacy() As Boolean
        <Column("JOB_MEDIA_BILL_DATE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobMediaBillDateFrom() As Nullable(Of Date)
        <Column("JOB_MEDIA_BILL_DATE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobMediaBillDateTo() As Nullable(Of Date)
        <Column("PRODUCTION_INCLUDE_MEDIA_BILL_DATES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionIncludeJobMediaBillDates() As Boolean
        <Column("PRODUCTION_MEDIA_BILL_DATE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionJobMediaBillDateFrom() As Nullable(Of Date)
        <Column("PRODUCTION_MEDIA_BILL_DATE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionJobMediaBillDateTo() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.EmployeeTimeDateCutoff.ToString,
                            AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.IncomeOnlyDateCutoff.ToString,
                            AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.APPostPeriodCodeCutoff.ToString

                        SetRequired(PropertyDescriptor, Me.IsProduction.GetValueOrDefault(False))

                    Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaStartDate.ToString,
                            AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaEndDate.ToString

                        If Me.IsNewspaper.GetValueOrDefault(False) OrElse Me.IsMagazine.GetValueOrDefault(False) OrElse Me.IsOutOfHome.GetValueOrDefault(False) OrElse
                                Me.IsInternet.GetValueOrDefault(False) OrElse Me.IsRadioDaily.GetValueOrDefault(False) OrElse Me.IsTelevisionDaily.GetValueOrDefault(False) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaBroadcastMonthStart.ToString,
                            AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaBroadcastMonthEnd.ToString

                        If Me.IsRadioMonthly.GetValueOrDefault(False) OrElse Me.IsTelevisionMonthly.GetValueOrDefault(False) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.BatchName.ToString

                    PropertyValue = Value

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.BillingCommandCenter.Database.DbContext).BillingCommandCenters
                        Where Mid(Entity.BillingUser, 1, Entity.BillingUser.Length - 2).ToUpper = Mid(Me.BillingUser, 1, Me.BillingUser.Length - 2).ToUpper AndAlso
                              Entity.BatchName.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                              Entity.ID <> Me.ID
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Please enter a unique batch name."

                    End If


                Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaStartDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.MediaEndDate IsNot Nothing Then

                        If DirectCast(PropertyValue, Date) > Me.MediaEndDate Then

                            IsValid = False

                            ErrorText = "The date from is greater than the date to."

                        End If

                    End If

                Case AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.MediaBroadcastMonthStart.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.MediaBroadcastMonthEnd IsNot Nothing Then

                        If DirectCast(PropertyValue, Date) > Me.MediaBroadcastMonthEnd Then

                            IsValid = False

                            ErrorText = "The broadcast start date is greater than the broadcast end date."

                        End If

                        If Me.IncludeLegacy Then

                            If DateDiff(DateInterval.Month, DirectCast(PropertyValue, Date), Me.MediaBroadcastMonthEnd.Value) > 12 Then

                                IsValid = False

                                ErrorText = "Broadcast date range must be one year in length max."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
