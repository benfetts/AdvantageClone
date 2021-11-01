Namespace BaseClasses

    <NotMapped>
    Public MustInherit Class DbContext
        Inherits System.Data.Entity.DbContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserCode As String = ""
        Protected _ConnectionString As String = ""
        Protected _IsDisposed As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ConnectionString As String
            Get
                ConnectionString = _ConnectionString
            End Get
        End Property
        Public ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Public ReadOnly Property IsDisposed As Boolean
            Get
                IsDisposed = _IsDisposed
            End Get
        End Property
        Public ReadOnly Property ObjectContext As System.Data.Entity.Core.Objects.ObjectContext
            Get
                ObjectContext = CType(Me, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext
            End Get
        End Property

#End Region

#Region " Methods "

        Public Function GetQuery(Of TEntity As Class)() As System.Data.Entity.Infrastructure.DbQuery(Of TEntity)

            GetQuery = Me.Set(Of TEntity).AsNoTracking

        End Function
        '<System.Obsolete>
        'Public Sub New()

        '    MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        'End Sub
        '<System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        'Public Sub New(ConnectionString As String, UserCode As String, DatabaseType As AdvantageFramework.Database.DatabaseTypes)

        '    MyBase.New(CreateEntityConnectionString(ConnectionString, DatabaseType))

        '    MyBase.Database.CommandTimeout = 0
        '    MyBase.Configuration.LazyLoadingEnabled = True
        '    MyBase.Configuration.ValidateOnSaveEnabled = False

        '    _UserCode = UserCode
        '    _ConnectionString = ConnectionString

        'End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            modelBuilder.Conventions.Add(New AdvantageFramework.BaseClasses.Conventions.DecimalPrecisionAttributeConvention())

            MyBase.OnModelCreating(modelBuilder)

        End Sub
        'Public Shared Function CreateEntityConnectionString(ConnectionString As String, DatabaseType As AdvantageFramework.Database.DatabaseTypes) As String

        '    'objects
        '    Dim EntityConnectionStringBuilder As System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder = Nothing
        '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

        '    SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
        '    SqlConnectionStringBuilder.MultipleActiveResultSets = True

        '    EntityConnectionStringBuilder = New System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder

        '    EntityConnectionStringBuilder.Provider = "System.Data.SqlClient"
        '    EntityConnectionStringBuilder.ProviderConnectionString = SqlConnectionStringBuilder.ToString

        '    If DatabaseType = AdvantageFramework.Database.Methods.DatabaseTypes.Default Then

        '        EntityConnectionStringBuilder.Metadata = "res://*/Database.DbContext.csdl|res://*/Database.DbContext.ssdl|res://*/Database.DbContext.msl"

        '    ElseIf DatabaseType = AdvantageFramework.Database.Methods.DatabaseTypes.Reporting Then

        '        EntityConnectionStringBuilder.Metadata = "res://*/Reporting.Database.DbContext.csdl|res://*/Reporting.Database.DbContext.ssdl|res://*/Reporting.Database.DbContext.msl"

        '    ElseIf DatabaseType = AdvantageFramework.Database.Methods.DatabaseTypes.Security Then

        '        EntityConnectionStringBuilder.Metadata = "res://*/Security.Database.DbContext.csdl|res://*/Security.Database.DbContext.ssdl|res://*/Security.Database.DbContext.msl"

        '    ElseIf DatabaseType = AdvantageFramework.Database.Methods.DatabaseTypes.BillingCommandCenter Then

        '        EntityConnectionStringBuilder.Metadata = "res://*/Billing Command Center.Database.DbContext.csdl|res://*/Billing Command Center.Database.DbContext.ssdl|res://*/Billing Command Center.Database.DbContext.msl"

        '    ElseIf DatabaseType = AdvantageFramework.Database.Methods.DatabaseTypes.Nielsen Then

        '        EntityConnectionStringBuilder.Metadata = "res://*/Nielsen.Database.DbContext.csdl|res://*/Nielsen.Database.DbContext.ssdl|res://*/Nielsen.Database.DbContext.msl"

        '    End If

        '    CreateEntityConnectionString = EntityConnectionStringBuilder.ToString

        'End Function
        'Public Shared Function CreateConnectionString(ByVal ConnectionString As String) As String

        '    'objects
        '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

        '    SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
        '    SqlConnectionStringBuilder.MultipleActiveResultSets = True

        '    CreateConnectionString = SqlConnectionStringBuilder.ToString

        'End Function
        Protected Overrides Sub Dispose(disposing As Boolean)

            MyBase.Dispose(disposing)

            _IsDisposed = True

        End Sub
        Public Function TryAttach(ByRef Entity As BaseClasses.Entity) As Boolean

            'objects
            Dim Attached As Boolean = False
            Dim CacheEntity As BaseClasses.Entity = Nothing

            Try

                If Entity IsNot Nothing Then

                    If Entity.EntityKey IsNot Nothing Then

                        If Me.ObjectContext.TryGetObjectByKey(Entity.EntityKey, CacheEntity) Then

                            If Me.Entry(Entity).State <> System.Data.Entity.EntityState.Added Then

                                Entity = Me.ObjectContext.ApplyCurrentValues(Entity.EntityKey.EntitySetName, Entity)

                            End If

                            If Entity.DbContext Is Nothing Then

                                Entity.DbContext = Me

                            End If

                            Attached = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Attached = False
            End Try

            TryAttach = Attached

        End Function
        'Public Function Attach(Of TEntity As Class)(EntityObject As TEntity) As TEntity

        '    Dim TEntityObject As TEntity = Nothing
        '    Dim ReturnObject As TEntity = Nothing

        '    TEntityObject = Me.[Set](EntityObject.GetType).Find(Me.KeyValuesFor(EntityObject))

        '    If TEntityObject IsNot Nothing Then

        '        Me.Entry(TEntityObject).CurrentValues.SetValues(EntityObject)
        '        ReturnObject = TEntityObject

        '    Else

        '        Me.[Set](EntityObject.GetType).Add(EntityObject)
        '        ReturnObject = EntityObject

        '    End If

        '    Attach = ReturnObject

        'End Function
        Public Sub Detach(ByRef EntityObject As BaseClasses.Entity)

            Try

                Me.ChangeTracker.DetectChanges()

                If Me.Entry(EntityObject) IsNot Nothing Then

                    If Me.Entry(EntityObject).State <> System.Data.Entity.EntityState.Detached Then

                        Me.Entry(EntityObject).State = System.Data.Entity.EntityState.Detached

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        'Public Sub DeleteEntityObject(ByRef EntityObject As AdvantageFramework.BaseClasses.Entity)

        '    Me.TryAttach(EntityObject)

        '    If Me.Entry(EntityObject) IsNot Nothing Then

        '        If Me.Entry(EntityObject).State <> System.Data.Entity.EntityState.Detached Then

        '            Me.Entry(EntityObject).State = System.Data.Entity.EntityState.Deleted

        '        End If

        '    End If

        'End Sub
        'Public Sub UpdateObject(ByRef EntityObject As AdvantageFramework.BaseClasses.Entity)

        '    Me.TryAttach(EntityObject)

        '    If Me.Entry(EntityObject) IsNot Nothing Then

        '        If Me.Entry(EntityObject).State <> System.Data.Entity.EntityState.Detached Then

        '            Me.Entry(EntityObject).State = System.Data.Entity.EntityState.Modified

        '        End If

        '    End If

        'End Sub
        'Public Sub UndoChanges(ByRef EntityObject As AdvantageFramework.BaseClasses.Entity)

        '    Me.TryAttach(EntityObject)

        '    If Me.Entry(EntityObject) IsNot Nothing Then

        '        If Me.Entry(EntityObject).State <> System.Data.Entity.EntityState.Detached Then

        '            Me.Entry(EntityObject).State = System.Data.Entity.EntityState.Unchanged

        '        End If

        '    End If

        'End Sub
        Public Sub AddEntityObject(ByRef Entity As Object)

			Me.Set(Entity.GetType).Add(Entity)

		End Sub
        Public Sub DeleteEntityObject(ByRef Entity As BaseClasses.Entity)

            Try

                Me.TryAttach(Entity)

            Catch ex As Exception

            End Try

            Me.ObjectContext.DeleteObject(Entity)

        End Sub
        Public Sub UpdateObject(ByRef Entity As BaseClasses.Entity)

            'objects
            Dim ObjectStateEntry As System.Data.Entity.Core.Objects.ObjectStateEntry = Nothing
            Dim Computed As Boolean = False

            Try

                Me.TryAttach(Entity)

                If Me.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(Entity, ObjectStateEntry) Then

                    If ObjectStateEntry.State <> System.Data.Entity.EntityState.Deleted AndAlso
                            ObjectStateEntry.State <> System.Data.Entity.EntityState.Detached Then

                        For Each FieldMetaData In ObjectStateEntry.CurrentValues.DataRecordInfo.FieldMetadata

                            Computed = False

                            For Each MetadataProperty In DirectCast(FieldMetaData.FieldType, System.Data.Entity.Core.Metadata.Edm.EdmProperty).MetadataProperties

                                If TypeOf MetadataProperty.Value Is String AndAlso CStr(MetadataProperty.Value) = "Computed" Then

                                    Computed = True
                                    Exit For

                                End If

                            Next

                            If Computed = False AndAlso ObjectStateEntry.IsPropertyChanged(FieldMetaData.FieldType.Name) Then

                                ObjectStateEntry.SetModifiedProperty(FieldMetaData.FieldType.Name)

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                ObjectStateEntry = Nothing
            End Try

        End Sub
        Public Sub UndoChanges(ByRef Entity As BaseClasses.Entity)

            Try

                Me.TryAttach(Entity)

                Me.ObjectContext.ObjectStateManager.ChangeObjectState(Entity, System.Data.Entity.EntityState.Unchanged)

            Catch ex As Exception

            End Try

        End Sub
        Public Function CreateCommand() As System.Data.SqlClient.SqlCommand

            'objects
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing

            If TypeOf Me.Database.Connection Is System.Data.SqlClient.SqlConnection Then

                SqlCommand = DirectCast(Me.Database.Connection, System.Data.SqlClient.SqlConnection).CreateCommand

            End If

            CreateCommand = SqlCommand

        End Function

#End Region

    End Class

End Namespace