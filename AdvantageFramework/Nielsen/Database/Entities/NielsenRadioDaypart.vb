Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_DAYPART")>
    Public Class NielsenRadioDaypart
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenDaypartID
            Name
            NumberOfQuarterhours
            AQH
            Cume
            ExclusiveCume
            Qualitative
            DiaryAtWorkInCar
            PPMinHomeOutofHome
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenDaypartID() As Short
        <Required>
        <MaxLength(30)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <Column("NUMBER_QUARTER_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NumberOfQuarterhours() As Short
        <Required>
        <Column("AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AQH() As Boolean
        <Required>
        <Column("CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Cume() As Boolean
        <Required>
        <Column("EXCLUSIVE_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ExclusiveCume() As Boolean
        <Required>
        <Column("QUALITATIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Qualitative() As Boolean
        <Required>
        <Column("DIARY_AT_WORK_IN_CAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DiaryAtWorkInCar() As Boolean
        <Required>
        <Column("PPM_IN_HOME_OUT_OF_HOME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PPMinHomeOutofHome() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
