Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioCountyUniverse

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioCountyPeriodID
            Persons12Plus
            Persons12to34
            Persons18Plus
            Persons18to34
            Persons25to54
            Persons35Plus
            Persons35to64
            Males18Plus
            Females18Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons12Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons12to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons18Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons18to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons25to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons35Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Persons35to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18Plus() As Integer

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenRadioCountyUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyUniverse)

            Me.ID = NielsenRadioCountyUniverse.ID
            Me.NielsenRadioCountyPeriodID = NielsenRadioCountyUniverse.NielsenRadioCountyPeriodID
            Me.Persons12Plus = NielsenRadioCountyUniverse.Persons12Plus
            Me.Persons12to34 = NielsenRadioCountyUniverse.Persons12to34
            Me.Persons18Plus = NielsenRadioCountyUniverse.Persons18Plus
            Me.Persons18to34 = NielsenRadioCountyUniverse.Persons18to34
            Me.Persons25to54 = NielsenRadioCountyUniverse.Persons25to54
            Me.Persons35Plus = NielsenRadioCountyUniverse.Persons35Plus
            Me.Persons35to64 = NielsenRadioCountyUniverse.Persons35to64
            Me.Males18Plus = NielsenRadioCountyUniverse.Males18Plus
            Me.Females18Plus = NielsenRadioCountyUniverse.Females18Plus

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
