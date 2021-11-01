Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class BillingCommandCenterAgencySetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Value
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Code() As String

        Public Property Value() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
