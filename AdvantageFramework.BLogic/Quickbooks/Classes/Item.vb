Namespace Quickbooks.Classes

    Public Class Item

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Id
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Id As String
        Public Property Name As String

#End Region

#Region " Methods "

        Public Sub New(Item As Intuit.Ipp.Data.Item)

            Me.Id = Item.Id
            Me.Name = Item.Name

        End Sub

#End Region

    End Class

End Namespace
