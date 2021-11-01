Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.EMPLOYEE")> _
    Public Class Employee

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            LastName
            FirstName
            MiddleInitial
            Email
            EmailPassword
            MondayHours
            TuesdayHours
            WednesdayHours
            ThursdayHours
            FridayHours
            SaturdayHours
            SundayHours
            GoogleToken
            CalendarTimeType
            CalendarTimeEmail
            CalendarTimeEmailPassword
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = ""
        Private _LastName As String = ""
        Private _FirstName As String = ""
        Private _MiddleInitial As String = ""
        Private _Email As String = ""
        Private _EmailPassword As String = ""
        Private _MondayHours As System.Nullable(Of Decimal) = Nothing
        Private _TuesdayHours As System.Nullable(Of Decimal) = Nothing
        Private _WednesdayHours As System.Nullable(Of Decimal) = Nothing
        Private _ThursdayHours As System.Nullable(Of Decimal) = Nothing
        Private _FridayHours As System.Nullable(Of Decimal) = Nothing
        Private _SaturdayHours As System.Nullable(Of Decimal) = Nothing
        Private _SundayHours As System.Nullable(Of Decimal) = Nothing
        Private _GoogleToken As String = ""
        Private _CalendarTimeType As System.Nullable(Of Short) = Nothing
        Private _CalendarTimeEmail As String = ""
        Private _CalendarTimeEmailPassword As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DBType:="varchar"), _
        System.ComponentModel.DisplayName("EmployeeCode")> _
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_LNAME", Storage:="_LastName", DBType:="varchar"), _
        System.ComponentModel.DisplayName("LastName")> _
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_FNAME", Storage:="_FirstName", DBType:="varchar"), _
        System.ComponentModel.DisplayName("FirstName")> _
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_MI", Storage:="_MiddleInitial", DBType:="varchar"), _
        System.ComponentModel.DisplayName("MiddleInitial")> _
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(ByVal value As String)
                _MiddleInitial = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_EMAIL", Storage:="_Email", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Email")> _
        Public Property Email() As String
            Get
                Email = _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMAIL_PWD", Storage:="_EmailPassword", DBType:="varchar"), _
        System.ComponentModel.DisplayName("EmailPassword")> _
        Public Property EmailPassword() As String
            Get
                EmailPassword = _EmailPassword
            End Get
            Set(ByVal value As String)
                _EmailPassword = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MON_HRS", Storage:="_MondayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("MondayHours")> _
        Public Property MondayHours() As System.Nullable(Of Decimal)
            Get
                MondayHours = _MondayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _MondayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TUE_HRS", Storage:="_TuesdayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("TuesdayHours")> _
        Public Property TuesdayHours() As System.Nullable(Of Decimal)
            Get
                TuesdayHours = _TuesdayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _TuesdayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="WED_HRS", Storage:="_WednesdayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("WednesdayHours")> _
        Public Property WednesdayHours() As System.Nullable(Of Decimal)
            Get
                WednesdayHours = _WednesdayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _WednesdayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="THU_HRS", Storage:="_ThursdayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("ThursdayHours")> _
        Public Property ThursdayHours() As System.Nullable(Of Decimal)
            Get
                ThursdayHours = _ThursdayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ThursdayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FRI_HRS", Storage:="_FridayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("FridayHours")> _
        Public Property FridayHours() As System.Nullable(Of Decimal)
            Get
                FridayHours = _FridayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _FridayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SAT_HRS", Storage:="_SaturdayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("SaturdayHours")> _
        Public Property SaturdayHours() As System.Nullable(Of Decimal)
            Get
                SaturdayHours = _SaturdayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _SaturdayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUN_HRS", Storage:="_SundayHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("SundayHours")> _
        Public Property SundayHours() As System.Nullable(Of Decimal)
            Get
                SundayHours = _SundayHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _SundayHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GOOGLE_TOKEN", Storage:="_GoogleToken", DBType:="varchar"),
        System.ComponentModel.DisplayName("GoogleToken")>
        Public Property GoogleToken() As String
            Get
                GoogleToken = _GoogleToken
            End Get
            Set(ByVal value As String)
                _GoogleToken = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAL_TIME_TYPE", Storage:="_CalendarTimeType", DbType:="smallint"),
        System.ComponentModel.DisplayName("CalendarTimeType")>
        Public Property CalendarTimeType() As System.Nullable(Of Decimal)
            Get
                CalendarTimeType = _CalendarTimeType
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CalendarTimeType = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAL_TIME_EMAIL", Storage:="_CalendarTimeEmail", DbType:="varchar"),
        System.ComponentModel.DisplayName("CalendarTimeEmail")>
        Public Property CalendarTimeEmail() As String
            Get
                CalendarTimeEmail = _CalendarTimeEmail
            End Get
            Set(ByVal value As String)
                _CalendarTimeEmail = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAL_TIME_PASSWORD", Storage:="_CalendarTimeEmailPassword", DbType:="varchar"),
        System.ComponentModel.DisplayName("CalendarTimeEmailPassword")>
        Public Property CalendarTimeEmailPassword() As String
            Get
                CalendarTimeEmailPassword = _CalendarTimeEmailPassword
            End Get
            Set(ByVal value As String)
                _CalendarTimeEmailPassword = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function

#End Region

    End Class

End Namespace
