<Table("INTERNET_TYPE")>
Public Class InternetType

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <MaxLength(6)>
    <Column("OD_CODE", TypeName:="varchar")>
    Public Property Code() As String
    <Required>
    <MaxLength(30)>
    <Column("OD_DESC", TypeName:="varchar")>
    Public Property Description() As String
    <Required>
    <Column("INACTIVE_FLAG")>
    Public Property IsInactive() As Short

#End Region

#Region " Methods "



#End Region

End Class