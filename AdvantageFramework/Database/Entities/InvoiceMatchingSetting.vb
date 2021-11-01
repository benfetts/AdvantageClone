Namespace Database.Entities

    <Table("BRDCAST_DTL_VERIFICATION_SETTING")>
    Public Class InvoiceMatchingSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTypeCode
            ClientCode
            VerifyRate
            VerifyNetwork
            VerifySchedule
            VerifyDay
            VerifyTime
            VerifyTimeSep
            VerifyAdNumber
            VerifyLength
            AdjacencyBefore
            AdjacencyAfter
            BookendMaxSeparation
            Client
            TimeSeparationSettings
        End Enum

#End Region

#Region " Variables "

        Private _Client As AdvantageFramework.Database.Entities.Client = Nothing
        Private _ClientName As String = Nothing

#End Region

#Region " Properties "

        <Key>
        <Required>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <Column("MEDIA_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.BroadcastMediaType, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaTypeCode() As String
        <Column("CL_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode, CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <Column("VERIFY_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Rate")>
        Public Property VerifyRate() As Boolean
        <Column("VERIFY_NETWORK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Network")>
        Public Property VerifyNetwork() As Boolean
        <Column("VERIFY_SCHEDULE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Schedule" & vbCrLf & "Dates")>
        Public Property VerifySchedule() As Boolean
        <Column("VERIFY_DAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Day of" & vbCrLf & "Week")>
        Public Property VerifyDay() As Boolean
        <Column("VERIFY_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Time" & vbCrLf & "of Day")>
        Public Property VerifyTime() As Boolean
        <Column("VERIFY_TIME_SEP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Time" & vbCrLf & "Separation")>
        Public Property VerifyTimeSep() As Boolean
        <Column("VERIFY_AD_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Ad" & vbCrLf & "Number")>
        Public Property VerifyAdNumber() As Boolean
        <Column("VERIFY_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Length")>
        Public Property VerifyLength() As Boolean
        <Required>
        <Column("ADJACENCY_BEFORE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Adjacency" & vbCrLf & "Before", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyBefore() As Short
        <Required>
        <Column("ADJACENCY_AFTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Adjacency" & vbCrLf & "After", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyAfter() As Short
        <Required>
        <Column("BOOKEND_MAX_SEPARATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bookend Max" & vbCrLf & "Separation", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=5)>
        Public Property BookendMaxSeparation() As Short

        Public Overridable Property Client As Database.Entities.Client
            Get
                Client = _Client
            End Get
            Set(value As Database.Entities.Client)

                _Client = value

                If value IsNot Nothing Then

                    Me.ClientName = value.Name

                Else

                    Me.ClientName = Nothing

                End If

            End Set
        End Property
        Public Overridable Property TimeSeparationSettings As ICollection(Of Database.Entities.TimeSeparationSetting)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.MediaTypeCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If Me.ClientCode Is Nothing AndAlso (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).InvoiceMatchingSettings
                                                             Where Entity.MediaTypeCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                                                   Entity.ClientCode Is Nothing
                                                             Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Only one setting allowed per media type / client."

                        ElseIf Me.ClientCode IsNot Nothing AndAlso (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).InvoiceMatchingSettings
                                                                    Where Entity.MediaTypeCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                                                          Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper
                                                                    Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Only one setting allowed per media type / client."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
