Namespace Security.Database.Entities

    <Table("SEC_PWD_HIST")>
    Public Class PasswordHistory
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            EmployeeCode
            Password
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode() As String
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required(AllowEmptyStrings:=True)>
        <Column("PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Password() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        'Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    ''objects
        '    'Dim ErrorText As String = ""
        '    'Dim PropertyValue As Object = Nothing

        '    'Select Case PropertyName

        '    '    Case AdvantageFramework.Security.Database.Entities.User.Properties.UserCode

        '    '        If Me.IsEntityBeingAdded() Then

        '    '            If AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Value) IsNot Nothing Then

        '    '                IsValid = False
        '    '                ErrorText = "User Code already exists in the system"

        '    '            End If

        '    '        End If

        '    'End Select

        '    'ValidateCustomProperties = ErrorText

        'End Function

#End Region

    End Class

End Namespace
