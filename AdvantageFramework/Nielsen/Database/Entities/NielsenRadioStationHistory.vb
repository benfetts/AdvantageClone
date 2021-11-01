Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_STATION_HISTORY")>
    Public Class NielsenRadioStationHistory
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioMarketNumber
            ComboID
            Name
            CallLetters
            Band
            Frequency
            ComboType
            IsSpillin
            NielsenRadioFormatCode
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_STATION_HISTORY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioMarketNumber() As Integer
        <Required>
        <Column("COMBO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ComboID() As Integer
        <Required>
        <MaxLength(30)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String
        <Required>
        <MaxLength(4)>
        <Column("CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CallLetters() As String
        <Required>
        <MaxLength(2)>
        <Column("BAND", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Band() As String
        <Required>
        <MaxLength(5)>
        <Column("FREQUENCY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Frequency() As String
        <Required>
        <Column("COMBO_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ComboType() As Short
        <Column("IS_SPILLIN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSpillin() As Boolean
        <Required>
        <MaxLength(4)>
        <Column("NIELSEN_RADIO_FORMAT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioFormatCode() As String
        <Required>
        <Column("SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
