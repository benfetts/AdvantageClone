Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class GeneralLedgerDetail
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FromPostPeriod
            ToPostPeriod
            UseBaseAccountCodes
            FromAccount
            ToAccount
            IncludeInactiveAccounts
        End Enum

#End Region

#Region " Variables "

        Private _FromPostPeriod As String = ""
        Private _ToPostPeriod As String = ""
        Private _UseBaseAccountCodes As Boolean = False
        Private _FromAccount As String = ""
        Private _ToAccount As String = ""
		Private _IncludeInactiveAccounts As Boolean = False
		Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property FromPostPeriod() As String
            Get
                FromPostPeriod = _FromPostPeriod
            End Get
            Set(value As String)
                _FromPostPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property ToPostPeriod() As String
            Get
                ToPostPeriod = _ToPostPeriod
            End Get
            Set(value As String)
                _ToPostPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.Default)>
        Public Property UseBaseAccountCodes As Boolean
            Get
                UseBaseAccountCodes = _UseBaseAccountCodes
            End Get
            Set(value As Boolean)
                _UseBaseAccountCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property FromAccount() As String
            Get
                FromAccount = _FromAccount
            End Get
            Set(value As String)
                _FromAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property ToAccount() As String
            Get
                ToAccount = _ToAccount
            End Get
            Set(value As String)
                _ToAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.Default)>
        Public Property IncludeInactiveAccounts As Boolean
            Get
                IncludeInactiveAccounts = _IncludeInactiveAccounts
            End Get
            Set(value As Boolean)
                _IncludeInactiveAccounts = value
            End Set
        End Property

#End Region

#Region " Methods "

		Public Sub New(Session As AdvantageFramework.Security.Session)

			_Session = Session

			If Debugger.IsAttached Then

				_FromPostPeriod = "200401"
				_ToPostPeriod = "201312"
				_UseBaseAccountCodes = True
				_FromAccount = "1000"
				_ToAccount = "9999"
				_IncludeInactiveAccounts = False

			Else
				_FromPostPeriod = ""
				_ToPostPeriod = ""
				_UseBaseAccountCodes = False
				_FromAccount = ""
				_ToAccount = ""
				_IncludeInactiveAccounts = False

			End If

		End Sub
		Public Sub New(Session As AdvantageFramework.Security.Session, ByVal FromPostPeriod As String, ByVal ToPostPeriod As String, ByVal UseBaseAccountCodes As Boolean, ByVal FromAccount As String, ByVal ToAccount As String, ByVal IncludeInactiveAccounts As Boolean)

			_Session = Session

			_FromPostPeriod = FromPostPeriod
			_ToPostPeriod = ToPostPeriod
			_UseBaseAccountCodes = UseBaseAccountCodes
			_FromAccount = FromAccount
			_ToAccount = ToAccount
			_IncludeInactiveAccounts = IncludeInactiveAccounts

		End Sub
		Public Overrides Function ToString() As String

            ToString = Me.FromPostPeriod & " - " & Me.ToPostPeriod & " | " & Me.FromAccount & " - " & Me.ToAccount

        End Function
		Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

			'objects
			Dim FilterString As String = ""

			FilterString = String.Format("EXEC dbo.advsp_gl_detail_report '{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6}", _Session.UserCode, _FromPostPeriod, _ToPostPeriod, If(_UseBaseAccountCodes, 1, 0), _FromAccount, _ToAccount, If(_IncludeInactiveAccounts, 1, 0))

			EntityFilterString = FilterString

		End Function
		Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            If String.IsNullOrEmpty(_FromPostPeriod) Then

                ErrorMessage = "Please select a starting post period."

            ElseIf String.IsNullOrEmpty(_ToPostPeriod) Then

                ErrorMessage = "Please select an ending post period."

            ElseIf _FromPostPeriod > _ToPostPeriod Then

                ErrorMessage = "Please select a starting post period that is before the ending post period."

            ElseIf String.IsNullOrEmpty(_FromAccount) Then

                ErrorMessage = "Please select a starting account."

            ElseIf String.IsNullOrEmpty(_ToAccount) Then

                ErrorMessage = "Please select an ending account."

            ElseIf _FromAccount > _ToAccount Then

                ErrorMessage = "Please select a starting account that is before the ending account."

            Else

                IsValid = True

            End If

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
