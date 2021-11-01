Namespace Database.Entities

    <Table("AGY_POP3_ACCOUNT")>
    Public Class POP3EmailListenerAccount
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            UserName
            Password
            ReplyTo
            DeleteProcessed
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("POP3_ACCOUNT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("POP3_ACCOUNT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountType() As Short
        <Required>
        <MaxLength(30)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Description() As String
        <MaxLength(100)>
        <Column("USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UserName() As String
        <Column("PASSWORD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Password() As String
        <MaxLength(50)>
        <Column("REPLY_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.Email)>
        Public Property ReplyTo() As String
        <Column("DELETE_PROCESSED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="Delete Processed E-Mail Messages")>
        Public Property DeleteProcessed() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub ValidateUserName(ByVal IsValid As Boolean)

            'objects
            Dim ErrorText As String = Nothing

            If Not IsValid Then

                ErrorText = "Please enter a unique POP3 E-Mail Listener Account."

            End If

            _ErrorHashtable("UserName") = ErrorText

            _EntityError = ErrorText

        End Sub

#End Region

    End Class

End Namespace
