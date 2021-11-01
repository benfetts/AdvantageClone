<DataContract>
Public Class CampaignWithDates

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID As Integer
    <DataMember>
    Public Property ClientCode As String
    <DataMember>
    Public Property DivisionCode As String
	<DataMember>
    Public Property ProductCode As String
    <DataMember>
    Public Property Code As String	
    <DataMember>
    Public Property Name As String
    <DataMember>
    Public Property IsClosed As Nullable(Of Short)
    <DataMember>
    Public Property IsActive As Nullable(Of Short)
    <DataMember>
    Public Property BeginDate As Nullable(Of Date)
    <DataMember>
    Public Property EndDate As Nullable(Of Date)


#End Region

#Region " Methods "

#End Region

End Class
