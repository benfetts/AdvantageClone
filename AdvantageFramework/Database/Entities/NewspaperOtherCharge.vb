Namespace Database.Entities

    Public Class NewspaperOtherCharge
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OrderNumber
            LineNumber
            ChargeType
            ChargeDescription
            Quantity
            Rate
            Amount
            RateType
            RevisedDate
            RevisedByUserCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        Public Property OrderNumber As Integer
        Public Property LineNumber As Short
        Public Property ChargeType As String
        Public Property ChargeDescription As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(11, 2)>
        Public Property Quantity As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 4)>
        Public Property Rate As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property Amount As Nullable(Of Decimal)
        Public Property RateType As String
        Public Property RevisedDate As Nullable(Of Date)
        Public Property RevisedByUserCode As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ChargeDescription As String, Amount As Nullable(Of Decimal), ExchangeRate As Decimal)

            Me.ChargeDescription = ChargeDescription
            Me.Amount = Amount.GetValueOrDefault(0) * ExchangeRate

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
