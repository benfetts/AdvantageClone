Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketVendorDateCopy
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            VendorCode
            VendorName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Selected() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.VendorCode = String.Empty
            Me.VendorName = String.Empty

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.VendorName

        End Function

#End Region

    End Class

End Namespace
