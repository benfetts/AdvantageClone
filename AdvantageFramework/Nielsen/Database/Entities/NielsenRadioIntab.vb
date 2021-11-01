Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_INTAB")>
    Public Class NielsenRadioIntab
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SegmentParentID
            Females6to11
            Females12to17
            Females18to20
            Females18to24
            Females21to24
            Females25to34
            Females35to44
            Females35to49
            Females45to49
            Females50to54
            Females55to64
            Females65Plus
            Males6to11
            Males12to17
            Males18to20
            Males18to24
            Males21to24
            Males25to34
            Males35to44
            Males35to49
            Males45to49
            Males50to54
            Males55to64
            Males65Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_INTAB_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NIELSEN_RADIO_SEGMENT_PARENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SegmentParentID() As Integer
        <Required>
        <Column("FEMALES_6TO11_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11() As Integer
        <Required>
        <Column("FEMALES_12TO17_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17() As Integer
        <Required>
        <Column("FEMALES_18TO20_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20() As Integer
        <Required>
        <Column("FEMALES_18TO24_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to24() As Integer
        <Required>
        <Column("FEMALES_21TO24_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24() As Integer
        <Required>
        <Column("FEMALES_25TO34_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34() As Integer
        <Required>
        <Column("FEMALES_35TO44_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44() As Integer
        <Required>
        <Column("FEMALES_35TO49_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49() As Integer
        <Required>
        <Column("FEMALES_45TO49_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49() As Integer
        <Required>
        <Column("FEMALES_50TO54_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54() As Integer
        <Required>
        <Column("FEMALES_55TO64_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64() As Integer
        <Required>
        <Column("FEMALES_65PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65Plus() As Integer
        <Required>
        <Column("MALES_6TO11_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11() As Integer
        <Required>
        <Column("MALES_12TO17_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17() As Integer
        <Required>
        <Column("MALES_18TO20_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20() As Integer
        <Required>
        <Column("MALES_18TO24_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to24() As Integer
        <Required>
        <Column("MALES_21TO24_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24() As Integer
        <Required>
        <Column("MALES_25TO34_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34() As Integer
        <Required>
        <Column("MALES_35TO44_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44() As Integer
        <Required>
        <Column("MALES_35TO49_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49() As Integer
        <Required>
        <Column("MALES_45TO49_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49() As Integer
        <Required>
        <Column("MALES_50TO54_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54() As Integer
        <Required>
        <Column("MALES_55TO64_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64() As Integer
        <Required>
        <Column("MALES_65PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65Plus() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub ZeroAllValues()

            Me.Males6to11 = 0
            Me.Males12to17 = 0
            Me.Males18to20 = 0
            Me.Males18to24 = 0
            Me.Males21to24 = 0
            Me.Males25to34 = 0
            Me.Males35to44 = 0
            Me.Males35to49 = 0
            Me.Males45to49 = 0
            Me.Males50to54 = 0
            Me.Males55to64 = 0
            Me.Males65Plus = 0

            Me.Females6to11 = 0
            Me.Females12to17 = 0
            Me.Females18to20 = 0
            Me.Females18to24 = 0
            Me.Females21to24 = 0
            Me.Females25to34 = 0
            Me.Females35to44 = 0
            Me.Females35to49 = 0
            Me.Females45to49 = 0
            Me.Females50to54 = 0
            Me.Females55to64 = 0
            Me.Females65Plus = 0

        End Sub

#End Region

    End Class

End Namespace
