Namespace Database.Entities

    <Table("AGENCY")>
    Public Class Agency

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(40)>
        <Column("NAME", TypeName:="varchar")>
        Public Property Name() As String
        <MaxLength(100)>
        <Column("DOC_REPOSITORY_PATH", TypeName:="varchar")>
        Public Property FileSystemDirectory() As String
        <MaxLength(30)>
        <Column("DOC_REPOSITORY_USER_DOMAIN", TypeName:="varchar")>
        Public Property FileSystemDomain() As String
        <MaxLength(50)>
        <Column("DOC_REPOSITORY_USER_NAME", TypeName:="varchar")>
        Public Property FileSystemUserName() As String
        <Column("DOC_REPOSITORY_USER_PASSWORD", TypeName:="varchar(MAX)")>
        Public Property FileSystemPassword() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
