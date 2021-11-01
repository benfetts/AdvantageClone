Namespace DTO.Media.Traffic

    Public Class MissingInstruction

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorksheetID
            WorksheetName
            WorksheetMarketID
            VendorCode
            VendorName
            SpotDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property WorksheetID As Integer
        Public Property WorksheetName As String
        Public Property WorksheetMarketID As Integer
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property SpotDate As Date

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
