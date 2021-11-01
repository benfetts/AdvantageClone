Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketVendorOrderedLine
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
            VendorCode
            LineNumber
            MakegoodNumber
            MadegoodNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Integer
		<Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MakegoodNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MadegoodNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.VendorCode = String.Empty
            Me.LineNumber = -1
            Me.MakegoodNumber = -1
            Me.MadegoodNumber = -1

        End Sub
		Public Overrides Function ToString() As String

            ToString = Me.VendorCode & " - " & Me.LineNumber & " - " & Me.MakegoodNumber & " - " & Me.MadegoodNumber

        End Function

#End Region

	End Class

End Namespace
