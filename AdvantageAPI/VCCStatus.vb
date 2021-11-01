<DataContract>
Public Class VCCStatus

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID As Short
    <DataMember>
    Public Property Description As String

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(ByVal VCCStatus As AdvantageFramework.Database.Entities.VCCStatuses)

        Me.ID = AdvantageFramework.EnumUtilities.GetValue(VCCStatus)
        Me.Description = VCCStatus.ToString

    End Sub

#End Region

End Class
