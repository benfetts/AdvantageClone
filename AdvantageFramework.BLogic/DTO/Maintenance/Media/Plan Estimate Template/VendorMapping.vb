Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class VendorMapping
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SuggestedVendorName
            VendorCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Suggested Vendor")>
        Public Property SuggestedVendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.VendorCode)>
        Public Property VendorCode() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(VendorCode As String, Name As String)

            Me.SuggestedVendorName = Name
            Me.VendorCode = VendorCode

        End Sub

#End Region

    End Class

End Namespace
