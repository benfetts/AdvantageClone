Namespace Database.Classes

    <Serializable()>
    Public Class MediaATBComplex

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ATBNumber
            Description
            RevisionNumber
            CampaignID
            CampaignCode
            CampaignName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            IsClosed
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ATBNumber() As Integer

        Public Property Description() As String

        Public Property RevisionNumber() As Nullable(Of Integer)

        Public Property CampaignID() As Nullable(Of Integer)

        Public Property CampaignCode() As String

        Public Property CampaignName() As String

        Public Property ClientCode() As String

        Public Property ClientName() As String

        Public Property DivisionCode() As String

        Public Property DivisionName() As String

        Public Property ProductCode() As String

        Public Property ProductDescription() As String

        Public Property IsClosed() As Nullable(Of Boolean)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ATBNumber.ToString

        End Function

#End Region

    End Class

End Namespace
