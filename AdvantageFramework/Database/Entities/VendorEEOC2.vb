Namespace Database.Entities

    <Table("VENDOR_EEOC2")>
    Public Class VendorEEOC2
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            Ethnicity
            MinorityCertificateNumber
            MinorityCertificateNumberExpirationDate
            IsNMSDC
            IsWBENC
            WBENCCertificateNumber
            WBENCCertificateNumberExpirationDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("VENDOR_EEOC2_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorCode() As String
        <Column("ETHNICITY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Ethnicity() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("MINORITY_CERTIFICATE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MinorityCertificateNumber() As String
        <Column("MINORITY_CERTIFICATE_NUMBER_EXP_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MinorityCertificateNumberExpirationDate() As Nullable(Of Date)
        <Required>
        <Column("IS_NMSDC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsNMSDC() As Boolean
        <Required>
        <Column("IS_WBENC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsWBENC() As Boolean
        <MaxLength(30)>
        <Column("WBENC_CERTIFICATE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property WBENCCertificateNumber() As String
        <Column("WBENC_CERTIFICATE_NUMBER_EXP_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property WBENCCertificateNumberExpirationDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
