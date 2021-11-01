Namespace DTO.Maintenance.Accounting.Vendor

    Public Class VendorDCMMapping
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            DoubleClickProfileID
            DoubleClickSiteID
            IsAgencyProfile
            ClientCodes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DoubleClickProfileID() As Long
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DoubleClickSiteID() As Long
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsAgencyProfile() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCodes() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
