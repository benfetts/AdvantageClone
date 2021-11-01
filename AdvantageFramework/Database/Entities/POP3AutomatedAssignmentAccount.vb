Namespace Database.Entities

    <Table("AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT")>
    Public Class POP3AutomatedAssignmentAccount
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            UserName
            Password
            DeleteProcessed
            JobNumber
            JobComponentNumber
            AlertTemplateID
            AlertStateID
            EmployeeCode
            SuccessMessage
            FailureMessage
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(30)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <MaxLength(100)>
        <Column("USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UserName() As String
        <Required>
        <Column("PASSWORD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Password() As String
        <Column("DELETE_PROCESSED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="Delete Processed E-Mail Messages")>
        Public Property DeleteProcessed() As Boolean
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.JobNumber, CustomColumnCaption:="Default Job")>
        Public Property JobNumber() As Nullable(Of Integer)
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.JobComponent, CustomColumnCaption:="Default Job\Comp")>
        Public Property JobComponentNumber() As Nullable(Of Short)
        <Column("ALRT_NOTIFY_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.AlertTemplate, CustomColumnCaption:="Default Template")>
        Public Property AlertTemplateID() As Nullable(Of Integer)
        <Column("ALERT_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.AlertState, CustomColumnCaption:="Default State")>
        Public Property AlertStateID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("EMP_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.EmployeeCode, CustomColumnCaption:="Default Assigned Employee")>
        Public Property EmployeeCode() As String
        <Column("INCLUDE_EMPLOYEE_CONTACTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeEmployeeContacts() As Boolean
        <Column("INCLUDE_CLIENT_CONTACTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeClientContacts() As Boolean
        <Column("SUCCESS_MESSAGE", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property SuccessMessage() As String
        <Column("FAILURE_MESSAGE", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property FailureMessage() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.UserName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).POP3AutomatedAssignmentAccounts
                            Where Entity.UserName.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique user name."

                        End If

                    Else

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).POP3AutomatedAssignmentAccounts
                            Where Entity.ID <> Me.ID AndAlso
                                  Entity.UserName.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique user name."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
