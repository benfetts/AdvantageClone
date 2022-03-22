Namespace Reporting.Database.Classes

    <Serializable>
    Public Class GLCrossOffice

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLYear
            GLPeriod
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            GLXact
            GLSeq
            GLAccountCode
            GLAccountDescription
            GLSource
            GLRemark
            GLAmount

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property GLYear As String
        Public Property GLPeriod As String
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeName() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property GLXact As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property GLSeq As Nullable(Of Short)
        Public Property GLAccountCode As String
        Public Property GLAccountDescription As String
        Public Property GLSource As String
        Public Property GLRemark As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GLAmount As Nullable(Of Decimal)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode.ToString

        End Function

#End Region

    End Class

End Namespace
