<Table("INTERNET_COMMENTS")>
Public Class InternetOrderDetailComment

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <Column("ORDER_NBR", Order:=0)>
    Public Property OrderNumber() As Integer
    <Key>
    <Required>
    <Column("LINE_NBR", Order:=1)>
    Public Property LineNumber() As Short
    <Column("INSTRUCTIONS", TypeName:="varchar")>
    Public Property Instructions() As String
    <Column("MISC_INFO", TypeName:="varchar")>
    Public Property MiscInfo() As String
    <Column("ORDER_COPY", TypeName:="varchar")>
    Public Property OrderCopy() As String
    <Column("MATL_NOTES", TypeName:="varchar")>
    Public Property MaterialNotes() As String

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.OrderNumber.ToString

    End Function

#End Region

End Class
