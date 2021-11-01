Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioDaypart

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioReportTypeCode
            NielsenDaypartID
            Name
            NumberOfQuarterhours
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenDaypartID() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfQuarterhours() As Short

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart)

            Me.ID = NielsenRadioDaypart.ID
            Me.NielsenDaypartID = NielsenRadioDaypart.NielsenDaypartID
            Me.Name = NielsenRadioDaypart.Name
            Me.NumberOfQuarterhours = NielsenRadioDaypart.NumberOfQuarterhours

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
