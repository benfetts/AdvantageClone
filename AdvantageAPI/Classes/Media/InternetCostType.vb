<DataContract>
Public Class InternetCostType

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property Code As String
    <DataMember>
    Public Property Description As Boolean

#End Region

#Region " Methods "

    Friend Sub New()

        Me.Code = String.Empty
        Me.Description = String.Empty

    End Sub

#End Region

End Class
