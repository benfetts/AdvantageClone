Namespace Database.MasterDatabase

    <System.Data.Linq.Mapping.DatabaseAttribute()> _
    Public Class DataContext
        Inherits AdvantageFramework.BaseClasses.DataContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

#Region "  Tables "

        Public ReadOnly Property Databases() As System.Data.Linq.Table(Of AdvantageFramework.Database.MasterDatabase.Entities.Database)
            Get
                Databases = Me.GetTable(Of AdvantageFramework.Database.MasterDatabase.Entities.Database)()
            End Get
        End Property
        Public ReadOnly Property DatabaseDetails() As System.Data.Linq.Table(Of AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail)
            Get
                DatabaseDetails = Me.GetTable(Of AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail)()
            End Get
        End Property
        Public ReadOnly Property Tables() As System.Data.Linq.Table(Of AdvantageFramework.Database.MasterDatabase.Entities.Table)
            Get
                Tables = Me.GetTable(Of AdvantageFramework.Database.MasterDatabase.Entities.Table)()
            End Get
        End Property
        Public ReadOnly Property Columns() As System.Data.Linq.Table(Of AdvantageFramework.Database.MasterDatabase.Entities.Column)
            Get
                Columns = Me.GetTable(Of AdvantageFramework.Database.MasterDatabase.Entities.Column)()
            End Get
        End Property

#End Region

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode)

        End Sub

#End Region

    End Class

End Namespace