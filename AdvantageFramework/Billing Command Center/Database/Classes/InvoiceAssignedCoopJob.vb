Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class InvoiceAssignedCoopJob

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeName
            CampaignCode
            CampaignName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property ClientCode() As String

        Public Property ClientName() As String

        Public Property DivisionCode() As String

        Public Property DivisionName() As String

        Public Property ProductCode() As String

        Public Property ProductName() As String

        Public Property OfficeName() As String

        Public Property CampaignCode() As String

        Public Property CampaignName() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
