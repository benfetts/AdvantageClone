Namespace DTO.Media.RFP

    Public Class MediaRFPHeaderStatus
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorName
            StatusDescription
            CreatedDate
            By
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StatusDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g", CustomColumnCaption:="Date")>
        Public Property CreatedDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property By As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
