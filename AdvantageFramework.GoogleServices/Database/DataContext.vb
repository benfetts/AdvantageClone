Namespace Database

    <System.Data.Linq.Mapping.DatabaseAttribute()> _
    Public Class DataContext
        Inherits System.Data.Linq.DataContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CurrentIdentity As System.Security.Principal.WindowsIdentity = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CurrentIdentity As System.Security.Principal.WindowsIdentity
            Get
                CurrentIdentity = _CurrentIdentity
            End Get
        End Property

#Region "  Tables "

        Public ReadOnly Property EmployeeNonTasks() As System.Data.Linq.Table(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask)
            Get
                EmployeeNonTasks = Me.GetTable(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask)()
            End Get
        End Property
        Public ReadOnly Property Employees() As System.Data.Linq.Table(Of AdvantageFramework.GoogleServices.Database.Entities.Employee)
            Get
                Employees = Me.GetTable(Of AdvantageFramework.GoogleServices.Database.Entities.Employee)()
            End Get
        End Property
        Public ReadOnly Property EmployeeTimeStagings() As System.Data.Linq.Table(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging)
            Get
                EmployeeTimeStagings = Me.GetTable(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging)()
            End Get
        End Property
        Public ReadOnly Property EmployeeTimeStagingsIDs() As System.Data.Linq.Table(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs)
            Get
                EmployeeTimeStagingsIDs = Me.GetTable(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs)()
            End Get
        End Property

#End Region

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UseWindowsAuthentication As Boolean)

            MyBase.New(ConnectionString)

            If UseWindowsAuthentication Then

                _CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

            End If

        End Sub

#End Region

    End Class

End Namespace


