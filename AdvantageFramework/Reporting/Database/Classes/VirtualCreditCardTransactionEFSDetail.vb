Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class VirtualCreditCardTransactionEFSDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CardCTS
            MerchantName
            Action
            Amount
            Reference
            ProcessedDateTime
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CardCTS As String = Nothing

        Public Property MerchantName As String = Nothing
        Public Property Action As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount As Nullable(Of Decimal) = Nothing

        Public Property Reference As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property ProcessedDateTime As Nullable(Of Date) = Nothing

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.CardCTS.ToString

        End Function

#End Region

    End Class

End Namespace
