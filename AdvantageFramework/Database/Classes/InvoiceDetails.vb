Namespace Database.Classes

    <Serializable()>
    Public Class InvoiceDetails

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            APID
            APCHKNBR
            APCHKDATE
            CHKAMT
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property APID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Check Number")>
        Public Property APCHKNBR() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date")>
        Public Property APCHKDATE() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Amount")>
        Public Property CHKAMT() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.APID.ToString

        End Function

#End Region

    End Class

End Namespace
