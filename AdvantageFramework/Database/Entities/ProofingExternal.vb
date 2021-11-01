Namespace Database.Entities

    <Table("PROOFING_X_REVIEWER")>
    Public Class ProofingExternalReviewer
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            ID
            Email
            Name
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            AddedByUserCode
            AddedDate
            IsActive

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <Column("ID")>
        Public Property ID As Integer
        <MaxLength(1000)>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <Column("EMAIL", TypeName:="varchar")>
        Public Property Email As String
        <MaxLength(300)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("NAME", TypeName:="varchar")>
        Public Property Name As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("CL_CODE", TypeName:="varchar")>
        Public Property ClientCode As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("DIV_CODE", TypeName:="varchar")>
        Public Property DivisionCode As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("PRD_CODE", TypeName:="varchar")>
        Public Property ProductCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("JOB_NUMBER", TypeName:="int")>
        Public Property JobNumber As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("JOB_COMPONENT_NBR", TypeName:="smallint")>
        Public Property JobComponentNumber As Short
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("ADDED_BY_USER_CODE", TypeName:="varchar")>
        Public Property AddedByUserCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("ADDED_DATE", TypeName:="smalldatetime")>
        Public Property AddedDate As DateTime?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("IS_ACTIVE", TypeName:="bit")>
        Public Property IsActive As Boolean?

#End Region

#Region " Methods "
        Public Function ValidateUpdate(ByRef IsValid As Boolean) As String

            Dim ErrorText As String = String.Empty
            Dim InternalError As String = String.Empty

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid = True Then

                If String.IsNullOrEmpty(Me.Name) = True Then

                    ErrorText = "Name required."
                    IsValid = False

                End If
                If IsValid = True Then

                    If String.IsNullOrEmpty(Me.Email) = True Then

                        ErrorText = "Email required."
                        IsValid = False

                    End If

                End If
                If IsValid = True Then

                    If AdvantageFramework.StringUtilities.IsValidEmailAddress(Me.Email) = False Then

                        ErrorText = "Invalid email address."
                        IsValid = False

                    End If

                End If
                If IsValid = True Then

                    'Dim ExistingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing

                    'Try

                    '    ExistingExternalReviewer = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(Me.DbContext, Me.Email)

                    'Catch ex As Exception
                    '    ExistingExternalReviewer = Nothing
                    '    InternalError = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                    '    If InternalError.Contains("Sequence contains") = True Then
                    '        '   More than one record with same email address
                    '        'block? allow?

                    '    End If
                    'End Try

                    'If ExistingExternalReviewer IsNot Nothing AndAlso ExistingExternalReviewer.ID <> Me.ID Then

                    '    ErrorText = "Email address already assigned to external reviewer."
                    '    IsValid = False

                    'End If

                End If
                'If IsValid = True Then

                '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, Me.Email)

                '    If Employee IsNot Nothing Then

                '        If Employee.Email.ToUpper() = Me.Email.ToUpper() OrElse Employee.ReplyToEmail.ToUpper() = Me.Email.ToUpper() Then

                '            IsValid = False
                '            ErrorText = "Email address belongs to an employee."

                '        End If

                '    End If

                'End If
                If IsValid = True Then

                    If Me.DatabaseAction = Action.Inserting Then

                        If AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(DbContext, Me.Email) IsNot Nothing Then

                            'Trying to ADD email to one that already exists
                            IsValid = False
                            ErrorText = "Email already exists."

                        End If

                    ElseIf Me.DatabaseAction = Action.Updating Then

                        Dim p0 As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing

                        Try

                            p0 = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(DbContext, Me.Email)

                        Catch ex As Exception
                            p0 = Nothing
                        End Try
                        If p0 IsNot Nothing AndAlso p0.ID <> Me.ID Then

                            'Trying to CHANGE email to one that already exists
                            IsValid = False
                            ErrorText = "Email already exists."

                        End If

                    End If

                End If

            End If

            ValidateUpdate = ErrorText

        End Function
        Public Function ValidateInsert(ByRef IsValid As Boolean) As String

            Dim ErrorText As String = String.Empty

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid = True Then

                If String.IsNullOrEmpty(Me.Name) = True Then

                    ErrorText = "Name required."
                    IsValid = False

                End If
                If IsValid = True Then

                    If String.IsNullOrEmpty(Me.Email) = True Then

                        ErrorText = "Email required."
                        IsValid = False

                    End If

                End If
                If IsValid = True Then

                    If AdvantageFramework.StringUtilities.IsValidEmailAddress(Me.Email) = False Then

                        ErrorText = "Invalid email address."
                        IsValid = False

                    End If

                End If
                If IsValid = True Then

                    Dim ExistingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing

                    ExistingExternalReviewer = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(Me.DbContext, Me.Email)

                    If ExistingExternalReviewer IsNot Nothing Then

                        ErrorText = "Email address already assigned to external reviewer."
                        IsValid = False

                    End If

                End If
                If IsValid = True Then

                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, Me.Email)

                    If Employee IsNot Nothing Then

                        If Employee.Email.ToUpper() = Me.Email.ToUpper() OrElse Employee.ReplyToEmail.ToUpper() = Me.Email.ToUpper() Then

                            IsValid = False
                            ErrorText = "Email address belongs to an employee."

                        End If

                    End If

                End If
                If IsValid = True Then

                    If Me.DatabaseAction = Action.Inserting Then

                        If AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(DbContext, Me.Email) IsNot Nothing Then

                            'Trying to ADD email to one that already exists
                            IsValid = False
                            ErrorText = "Email already exists."

                        End If

                    ElseIf Me.DatabaseAction = Action.Updating Then

                        Dim p0 As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing

                        Try

                            p0 = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(DbContext, Me.Email)

                        Catch ex As Exception
                            p0 = Nothing
                        End Try
                        If p0 IsNot Nothing AndAlso p0.ID <> Me.ID Then

                            'Trying to CHANGE email to one that already exists
                            IsValid = False
                            ErrorText = "Email already exists."

                        End If

                    End If

                End If

            End If

            ValidateInsert = ErrorText

        End Function

#End Region

    End Class

End Namespace
