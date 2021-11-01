Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AdvanceBillRevenueRecognition
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IncomeMethod
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.ProductionAdvancedBillingIncome)>
        Public Property IncomeMethod() As Short

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ProductionAdvancedBillingIncome As AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome)

            Me.IncomeMethod = ProductionAdvancedBillingIncome

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition.Properties.IncomeMethod.ToString

                    PropertyValue = Value

                    If PropertyValue Is Nothing OrElse (DirectCast(PropertyValue, Short) < AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation OrElse
                            DirectCast(PropertyValue, Short) > AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling) Then

                        IsValid = False

                        ErrorText = "Please select a valid income method."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace