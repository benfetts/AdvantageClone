<DataContract>
Public Class BasicIDName

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID As Integer
    <DataMember>
    Public Property Name As String

#End Region

#Region " Methods "

    Friend Sub New()

        Me.Name = String.Empty
        Me.ID = 0

    End Sub

#End Region

End Class
