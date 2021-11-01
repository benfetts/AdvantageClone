<Table("AD_SIZE")>
Public Class AdSize

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <MaxLength(1)>
    <Column("MEDIA_TYPE", Order:=0, TypeName:="varchar")>
    Public Property MediaType() As String
    <Key>
    <Required>
    <MaxLength(6)>
    <Column("SIZE_CODE", Order:=1, TypeName:="varchar")>
    Public Property Code() As String
    <MaxLength(30)>
    <Column("SIZE_DESC", TypeName:="varchar")>
    Public Property Description() As String
    <Column("INACTIVE_FLAG")>
    Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class