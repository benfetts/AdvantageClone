Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetVendorOrderStatus
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            VendorName
            OrderNumber
            WorksheetLine
            LineNumber
            RevisionNumber
            Month
            Year
            StatusDescription
            [Date]
            By
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property WorksheetLine As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LineNumber As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RevisionNumber As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Month As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StatusDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="g")>
        Public Property [Date] As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property By As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
