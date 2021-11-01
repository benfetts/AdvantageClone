<DataContract>
Public Class JobComponents

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID() As Integer
    <DataMember>
    Public Property JobNumber() As Integer
    <DataMember>
    Public Property JobComponentNumber As Nullable(Of Short)
    <DataMember>
    Public Property ClientCode() As String
    <DataMember>
    Public Property ClientName() As String
    <DataMember>
    Public Property DivisionCode() As String
    <DataMember>
    Public Property DivisionName() As String
    <DataMember>
    Public Property ProductCode() As String
    <DataMember>
    Public Property ProductDescription() As String
    <DataMember>
    Public Property JobDescription() As String
    <DataMember>
    Public Property JobComponentDescription() As String
    <DataMember>
    Public Property OfficeCode() As String
    <DataMember>
    Public Property OfficeName() As String
    <DataMember>
    Public Property IsOpen() As Integer
    <DataMember>
    Public Property JobProcessControl() As Nullable(Of Short)
    <DataMember>
    Public Property JobProcessDescription() As String
    <DataMember>
    Public Property CampaignID() As Nullable(Of Integer)
    <DataMember>
    Public Property CampaignName() As String
    <DataMember>
    Public Property CreateDate() As Nullable(Of DateTime)
    <DataMember>
    Public Property FiscalPeriod() As String
    <DataMember>
    Public Property FiscalPeriodDescription() As String
    <DataMember>
    Public Property JobType() As String
    <DataMember>
    Public Property JobTypeDescription() As String
    <DataMember>
    Public Property SalesClass() As String
    <DataMember>
    Public Property AccountExecutive() As String
    <DataMember>
    Public Property ClientPO() As String
    <DataMember>
    Public Property JobComponentBudget() As Nullable(Of Decimal)
    <DataMember>
    Public Property UdvLabel1() As String
    <DataMember>
    Public Property UdvDesc1() As String
    <DataMember>
    Public Property UdvLabel2() As String
    <DataMember>
    Public Property UdvDesc2() As String
    <DataMember>
    Public Property UdvLabel3() As String
    <DataMember>
    Public Property UdvDesc3() As String
    <DataMember>
    Public Property UdvLabel4() As String
    <DataMember>
    Public Property UdvDesc4() As String
    <DataMember>
    Public Property UdvLabel5() As String
    <DataMember>
    Public Property UdvDesc5() As String
    <DataMember>
    Public Property ProjectManager() As String
    <DataMember>
    Public Property JobComponentComments() As String
    <DataMember>
    Public Property ModifiedDate() As Nullable(Of DateTime)
    <DataMember>
    Public Property ModifiedBy() As String
    <DataMember>
    Public Property LastStatusDate() As Nullable(Of DateTime)
    <DataMember>
    Public Property JobCreateDate() As Nullable(Of DateTime)
    <DataMember>
    Public Property JobCreatedBy() As String

#End Region

#Region " Methods "



#End Region

End Class
