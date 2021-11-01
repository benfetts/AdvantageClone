Namespace Database.Classes

    <Serializable()>
    Public Class ComboBoxData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Number() As Nullable(Of Short)

        Public Property Description() As String

#End Region

#Region " Methods "

        Public Sub New(Number As Nullable(Of Short), Description As String)

            _Number = Number
            _Description = Description

        End Sub

#End Region

    End Class

End Namespace
