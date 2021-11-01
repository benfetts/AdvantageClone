Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class TransferToJob

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _Description As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(ByVal value As Integer)
                _Number = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
