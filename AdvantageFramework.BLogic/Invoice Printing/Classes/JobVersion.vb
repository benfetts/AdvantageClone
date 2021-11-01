Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class JobVersion

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Label
            Value
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Label As String
        Public Property Value As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Label & Me.Value

        End Function

#End Region

    End Class

End Namespace
