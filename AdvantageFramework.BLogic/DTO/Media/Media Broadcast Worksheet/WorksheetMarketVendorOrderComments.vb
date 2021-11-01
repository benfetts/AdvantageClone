Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketVendorOrderComments
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            VendorName
            OrderComments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property OrderComments() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.VendorCode = String.Empty
            Me.VendorName = String.Empty
            Me.OrderComments = String.Empty

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.VendorName

        End Function

#End Region

    End Class

End Namespace
