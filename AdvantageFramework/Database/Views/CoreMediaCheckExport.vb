Namespace Database.Views

    <Table("V_CORE_MEDIA_CHECK_EXPORT")>
    Public Class CoreMediaCheckExport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CheckNumber
            PayToVendorCode
            LinkID
            CheckDate
            CheckAmount
            InvoiceNumber
            InvoiceDate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Long
        <Required>
        <Column("CheckNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckNumber() As Integer
        <MaxLength(6)>
        <Column("PayToVendorCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToVendorCode() As String
        <Column("LinkID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LinkID() As Nullable(Of Integer)
        <Required>
        <Column("CheckDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Date
        <Column("CheckAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckAmount() As Nullable(Of Decimal)
        <Required>
        <MaxLength(20)>
        <Column("InvoiceNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
        <Required>
        <Column("InvoiceDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Date


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
