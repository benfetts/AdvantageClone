Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class CurrencyRate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CurrencyCode
            CurrencyCodes
            CurrencyRate
            CurrencyCodeComparison
            LastestUpdatedRate
            LastestUpdatedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CurrencyCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="Currency Codes")>
        Public Property CurrencyCodes() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n6")>
        Public Property CurrencyRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CurrencyCodeComparison() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n6", IsReadOnlyColumn:=True)>
        Public Property LastestUpdatedRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="G", IsReadOnlyColumn:=True)>
        Public Property LastestUpdatedDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate.Properties.CurrencyRate.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = True

                        ErrorText = "The currency rate cannot be zero."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace