Namespace Reporting.Database.Classes

    <Serializable>
    Public Class VendorSpendWithEEOCAndMinorityStatusSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            Address
            City
            County
            State
            ZipCode
            Country

            HUBZ
            IO
            LGBT
            MBE
            MISC1
            MISC2
            MISC3
            NA
            OT
            OTS
            SB
            SDB
            VET
            WBE
            WBS

            Ethnicity
            NMSDC
            NMSDCCertificationNumber
            NMSDCExpirationDate
            WBENC
            WBENCCertificationNumber
            WBENCExpirationDate
            TotalSpend
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ZipCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String

        Public Property HUBZ() As String
        Public Property IO() As String
        Public Property LGBT() As String
        Public Property MBE() As String
        Public Property MISC1() As String
        Public Property MISC2() As String
        Public Property MISC3() As String
        Public Property NA() As String
        Public Property OT() As String
        Public Property OTS() As String
        Public Property SB() As String
        Public Property SDB() As String
        Public Property VET() As String
        Public Property WBE() As String
        Public Property WBS() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Ethnicity() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NMSDC() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="NMSDC Certification Number")>
        Public Property NMSDCCertificationNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="NMSDC Expiration Date")>
        Public Property NMSDCExpirationDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WBENC() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="WBENC Certification Number")>
        Public Property WBENCCertificationNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="WBENC Expiration Date")>
        Public Property WBENCExpirationDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalSpend() As Decimal

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
