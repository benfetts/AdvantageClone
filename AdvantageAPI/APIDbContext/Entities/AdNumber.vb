<Table("AD_NUMBER")>
Public Class AdNumber

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <MaxLength(30)>
    <Column("AD_NBR", TypeName:="varchar")>
    Public Property Number() As String
    <Required>
    <MaxLength(60)>
    <Column("AD_NBR_DESC", TypeName:="varchar")>
    Public Property Description() As String
    <Column("CL_CODE")>
    Public Property ClientCode() As String
    <Column("ACTIVE")>
    Public Property IsActive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
