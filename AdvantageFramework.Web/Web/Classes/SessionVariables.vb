Imports System.Web

Namespace Web

    <Serializable()> _
    Public Class SessionVariables

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum SessionVariable
            SessionId
            ConnectionString
            IsAdmin
            AdminConnectionString
            ServerName
            DatabaseName
            EmpCode
            EmployeeName
            UserCode
            SecUserId
            AdvantageUserLicenseInUseId
            CultureCode
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Private Property _Context As Object
        Private Property _DbContext As AdvantageFramework.Database.DbContext
        Private Property _SecurityDbContext As AdvantageFramework.Security.Database.DbContext

#End Region

#Region " Methods "

        'large lists that don't change very often
        Public Function LoadAllClientsByUserCode(ByVal UserCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Client)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            Dim SessionKey As String = "LoadClientsByUserCode_" & UserCode

            If _Context.Session(SessionKey) Is Nothing Then

                Try

                    If Not _DbContext Is Nothing And Not _SecurityDbContext Is Nothing Then

                        list = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(_DbContext, _SecurityDbContext, UserCode).ToList()

                    End If

                Catch ex As Exception

                    list.Clear()

                End Try

                _Context.Session(SessionKey) = list

            Else

                list = CType(HttpContext.Current.Session(SessionKey), Generic.List(Of AdvantageFramework.Database.Entities.Client))

            End If

            Return list

        End Function
        Public Function LoadAllExpenseFunctions() As Generic.List(Of AdvantageFramework.Database.Entities.Function)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Function)
            Dim SessionKey As String = "LoadAllFunctions"

            If _Context.Session(SessionKey) Is Nothing Then

                Try

                    If Not _DbContext Is Nothing Then

                        list = (From Entity In AdvantageFramework.Database.Procedures.Function.LoadAllActive(_DbContext)
                                Where Entity.EmployeeExpenseFlag IsNot Nothing AndAlso
                                         Entity.EmployeeExpenseFlag = 1
                                Select Entity).ToList()

                    End If

                Catch ex As Exception

                    list.Clear()

                End Try

                _Context.Session(SessionKey) = list

            Else

                list = CType(HttpContext.Current.Session(SessionKey), Generic.List(Of AdvantageFramework.Database.Entities.Function))

            End If

            Return list

        End Function
        'Public Function LoadAllOpenJobsByUserCode(ByVal UserCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Job)
        '    Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Job)

        '    Dim SessionKey As String = "LoadAllOpenJobComponentsByUserCode_" & UserCode

        '    If _Context.Session(SessionKey) Is Nothing Then

        '        Try

        '            If Not _DbContext Is Nothing And Not _SecurityDbContext Is Nothing Then

        '                list = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(_DbContext, _SecurityDbContext, UserCode) _
        '                                  Where Entity.IsOpen = 1 _
        '                                  Select Entity).ToList()

        '            End If

        '        Catch ex As Exception

        '            list.Clear()

        '        End Try

        '        _Context.Session(SessionKey) = list

        '    Else

        '        list = CType(HttpContext.Current.Session(SessionKey), Generic.List(Of AdvantageFramework.Database.Entities.Job))

        '    End If

        '    Return list

        'End Function
        'Public Function LoadAllOpenJobComponentsByUserCode(ByVal UserCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)
        '    Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

        '    Dim SessionKey As String = "LoadAllOpenJobComponentsByUserCode_" & UserCode

        '    If _Context.Session(SessionKey) Is Nothing Then

        '        Try

        '            If Not _DbContext Is Nothing And Not _SecurityDbContext Is Nothing Then

        '                list = AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(_DbContext, _SecurityDbContext, UserCode, True).ToList()

        '            End If

        '        Catch ex As Exception

        '            list.Clear()

        '        End Try

        '        _Context.Session(SessionKey) = list

        '    Else

        '        list = CType(HttpContext.Current.Session(SessionKey), Generic.List(Of AdvantageFramework.Database.Entities.JobComponent))

        '    End If

        '    Return list

        'End Function

#End Region

        Public Sub New(HttpContextOrHttpContextBase As Object, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                   ByVal DbContext As AdvantageFramework.Database.DbContext)

            Me._Context = HttpContextOrHttpContextBase
            Me._SecurityDbContext = SecurityDbContext
            Me._DbContext = DbContext

        End Sub

    End Class

    'Public Sub [Set](ByVal key As SessionVariable, ByVal value As String)

    '    Me.Context.Session("_" & key) = value

    'End Sub
    'Public Function [Get](ByVal key As SessionVariable)

    '    Try

    '        Return Me.Context.Session("_" & key)

    '    Catch ex As Exception

    '        Return Nothing

    '    End Try

    'End Function
    'Public Sub Remove(ByVal key As SessionVariable)

    '    Me.Context.Session("_" & key) = Nothing

    'End Sub
    'Public Sub SetCustom(key As String, value As String)

    '    Me.Context.Session("_" & key) = value

    'End Sub
    'Public Function GetCustom(key As String)

    '    Try

    '        Return (Me.Context.session("_" & key))

    '    Catch ex As Exception

    '        Return Nothing

    '    End Try
    'End Function
    'Public Sub RemoveCustom(key As String)

    '    Me.Context.Session("_" & key) = Nothing

    'End Sub

End Namespace


