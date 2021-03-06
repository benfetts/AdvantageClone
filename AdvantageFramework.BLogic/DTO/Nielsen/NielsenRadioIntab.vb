Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioIntab

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

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SegmentParentID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females6to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females12to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females25to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to44() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females45to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females65Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males6to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males25to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to44() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males45to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males65Plus() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab)

            Me.ID = NielsenRadioIntab.ID
            Me.SegmentParentID = NielsenRadioIntab.SegmentParentID
            Me.Females6to11 = NielsenRadioIntab.Females6to11
            Me.Females12to17 = NielsenRadioIntab.Females12to17
            Me.Females18to20 = NielsenRadioIntab.Females18to20
            Me.Females18to24 = NielsenRadioIntab.Females18to24
            Me.Females21to24 = NielsenRadioIntab.Females21to24
            Me.Females25to34 = NielsenRadioIntab.Females25to34
            Me.Females35to44 = NielsenRadioIntab.Females35to44
            Me.Females35to49 = NielsenRadioIntab.Females35to49
            Me.Females45to49 = NielsenRadioIntab.Females45to49
            Me.Females50to54 = NielsenRadioIntab.Females50to54
            Me.Females55to64 = NielsenRadioIntab.Females55to64
            Me.Females65Plus = NielsenRadioIntab.Females65Plus
            Me.Males6to11 = NielsenRadioIntab.Males6to11
            Me.Males12to17 = NielsenRadioIntab.Males12to17
            Me.Males18to20 = NielsenRadioIntab.Males18to20
            Me.Males18to24 = NielsenRadioIntab.Males18to24
            Me.Males21to24 = NielsenRadioIntab.Males21to24
            Me.Males25to34 = NielsenRadioIntab.Males25to34
            Me.Males35to44 = NielsenRadioIntab.Males35to44
            Me.Males35to49 = NielsenRadioIntab.Males35to49
            Me.Males45to49 = NielsenRadioIntab.Males45to49
            Me.Males50to54 = NielsenRadioIntab.Males50to54
            Me.Males55to64 = NielsenRadioIntab.Males55to64
            Me.Males65Plus = NielsenRadioIntab.Males65Plus

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
