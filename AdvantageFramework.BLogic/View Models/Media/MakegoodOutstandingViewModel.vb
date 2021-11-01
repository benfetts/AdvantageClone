Namespace ViewModels.Media

    Public Class MakegoodOutstandingViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsValid
            AgencyName
            DatabaseName
            VendorCode
            VendorRepCode
            SalesRepEmail
            MediaManagerGeneratedReportID
            Email
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsValid As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AgencyName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property DatabaseName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property VendorCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property VendorRepCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property SalesRepEmail As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property OrderNumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property Email As String

        Public Property BroadcastOrdersForVendorRepList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)

#End Region

#Region " Methods "

        Public Sub New()

            BroadcastOrdersForVendorRepList = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)

        End Sub

#End Region

    End Class

End Namespace
