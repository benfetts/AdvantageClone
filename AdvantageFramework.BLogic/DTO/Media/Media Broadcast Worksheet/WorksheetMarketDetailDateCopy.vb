Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetailDateCopy
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            DateColumnName
            DateColumnCaption
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property DateColumnName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, IsRequired:=True)>
        Public Property DateColumnCaption() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.DateColumnName = String.Empty
            Me.DateColumnCaption = String.Empty

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.DateColumnName & " - " & Me.DateColumnCaption

        End Function

#End Region

    End Class

End Namespace
