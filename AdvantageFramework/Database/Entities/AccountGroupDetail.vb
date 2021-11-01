Namespace Database.Entities

	<Table("ACCOUNT_GROUP_DTL")>
	Public Class AccountGroupDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AccountGroupCode
			SequenceNumber
			GLACode
			GLACodeFrom
			GLACodeTo
			IncludedAccountGroupCode

		End Enum

#End Region

#Region " Variables "

        Private _IsBaseCode As Boolean = Nothing

#End Region

#Region " Properties "

		<Key>
		<MaxLength(30)>
		<Column("GROUP_CODE", Order:=0, TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property AccountGroupCode() As String
		<Key>
		<Column("GROUP_SEQ", Order:=1)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property SequenceNumber() As Short
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property GLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_FROM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property GLACodeFrom() As String
		<MaxLength(30)>
		<Column("GLACODE_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property GLACodeTo() As String
		<MaxLength(30)>
		<Column("GROUP_INCLUDED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property IncludedAccountGroupCode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountGroupCode.ToString

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.PropertyTypes)

            'objects
            Dim AccoungGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim GLACode As String = Nothing
            Dim IsBaseCode As Boolean = Nothing

            If PropertyName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeFrom.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeTo.ToString Then

                If Value IsNot Nothing Then

                    GLACode = DirectCast(Value, String)

                    Try

                        AccoungGroup = (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).AccountGroups _
                                        Where Entity.Code = _AccountGroupCode _
                                        Select Entity).SingleOrDefault

                    Catch ex As Exception
                        AccoungGroup = Nothing
                    End Try

                    If AccoungGroup IsNot Nothing Then

                        If AccoungGroup.Type.HasValue AndAlso AccoungGroup.Type = AdvantageFramework.Database.Entities.AccountGroupTypes.BaseAccountCode Then

                            IsBaseCode = True

                        End If

                    Else

                        IsBaseCode = _IsBaseCode

                    End If

                    If IsBaseCode Then

                        IsValid = (From GeneralLedgerAccount In DirectCast(DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerAccounts _
                                   Where GeneralLedgerAccount.BaseCode = GLACode _
                                   Select GeneralLedgerAccount).Any

                        If IsValid Then

                            ErrorText = ""

                        End If

                    End If

                    If PropertyName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeFrom.ToString Then

                        If _GLACodeTo <> "" Then

                            If CLng(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GLACodeFrom)) > CLng(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GLACodeTo)) Then

                                IsValid = False
                                ErrorText &= "The ""Range From"" Account must be less than the ""Range To"" Account. "

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Public Overrides Sub SetRequiredFields()

            'objects
            Dim GLACodeRequired As Boolean = False
            Dim GLACodeFromRequired As Boolean = False
            Dim GLACodeToRequired As Boolean = False

            If String.IsNullOrWhiteSpace(_GLACode) AndAlso String.IsNullOrWhiteSpace(_GLACodeFrom) AndAlso String.IsNullOrWhiteSpace(_GLACodeTo) Then

                GLACodeRequired = True
                GLACodeFromRequired = True
                GLACodeToRequired = True

            ElseIf String.IsNullOrWhiteSpace(_GLACodeFrom) = False OrElse String.IsNullOrWhiteSpace(_GLACodeTo) = False Then

                GLACodeFromRequired = True
                GLACodeToRequired = True

            End If

            SetRequired(AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACode.ToString, GLACodeRequired)
            SetRequired(AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeFrom.ToString, GLACodeFromRequired)
            SetRequired(AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeTo.ToString, GLACodeToRequired)

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            SetRequiredFields()

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Public Sub SetGLAType(ByVal IsBaseCode As Boolean)

            _IsBaseCode = IsBaseCode

        End Sub

#End Region

	End Class

End Namespace
