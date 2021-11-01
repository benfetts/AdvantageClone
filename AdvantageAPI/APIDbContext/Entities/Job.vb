<Table("V_JOB_LOG_API")>
Public Class Job

#Region " Constants "



#End Region

#Region " Enum "

#Region " Enum "



#End Region

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Required>
    <MaxLength(6)>
    <Column("CL_CODE", TypeName:="varchar")>
    Public Property ClientCode() As String
    <MaxLength(40)>
    <Column("CL_NAME", TypeName:="varchar")>
    Public Property ClientName() As String
    <Required>
    <MaxLength(6)>
    <Column("DIV_CODE", TypeName:="varchar")>
    Public Property DivisionCode() As String
    <MaxLength(40)>
    <Column("DIV_NAME", TypeName:="varchar")>
    Public Property DivisionName() As String
    <Required>
    <MaxLength(6)>
    <Column("PRD_CODE", TypeName:="varchar")>
    Public Property ProductCode() As String
    <MaxLength(40)>
    <Column("PRD_DESCRIPTION", TypeName:="varchar")>
    Public Property ProductDescription() As String
    <Key>
    <Required>
    <Column("JOB_NUMBER", Order:=0)>
    Public Property JobNumber() As Integer
    <MaxLength(60)>
    <Column("JOB_DESC", TypeName:="varchar")>
    Public Property JobDescription() As String
    <MaxLength(4)>
    <Column("OFFICE_CODE", TypeName:="varchar")>
    Public Property OfficeCode() As String
    <MaxLength(30)>
    <Column("OFFICE_NAME", TypeName:="varchar")>
    Public Property OfficeName() As String
    <Required>
    <Column("COMP_OPEN")>
    Public Property IsOpen() As Integer
    <Column("CMP_IDENTIFIER")>
    Public Property CampaignID() As Nullable(Of Integer)
    <MaxLength(60)>
    <Column("CMP_NAME", TypeName:="varchar")>
    Public Property CampaignName() As String
    <Column("CREATE_DATE")>
    Public Property CreateDate() As DateTime

#End Region

#Region " Methods "



#End Region

End Class

