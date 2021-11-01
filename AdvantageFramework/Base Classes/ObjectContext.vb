Namespace BaseClasses

    <Serializable()> Public MustInherit Class ObjectContext
        Inherits System.Data.Objects.ObjectContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ObjectContextType
            [Default]
            Security
            BillingCommandCenter
            Reporting
        End Enum

#End Region

#Region " Variables "

        Protected _UserCode As String = ""
        Protected _ConnectionString As String = ""
        Protected _AllowChangeTracking As Boolean = False
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
        Public Property AllowChangeTracking As Boolean
            Get
                AllowChangeTracking = _AllowChangeTracking
            End Get
            Set(value As Boolean)
                _AllowChangeTracking = value
            End Set
        End Property
        Public ReadOnly Property IsDisposed As Boolean
            Get
                IsDisposed = _IsDisposed
            End Get
        End Property

#End Region

#Region " Methods "

        Friend Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal ObjectContextType As ObjectContextType)
            
            MyBase.New(AdvantageFramework.Database.CreateEntityConnectionString(ConnectionString, ObjectContextType))

            MyBase.MetadataWorkspace.LoadFromAssembly(System.Reflection.Assembly.GetExecutingAssembly)
            MyBase.CommandTimeout = 0
            MyBase.ContextOptions.LazyLoadingEnabled = True
            MyBase.ContextOptions.ProxyCreationEnabled = False

            If ObjectContextType = ObjectContext.ObjectContextType.Security Then

                MyBase.DefaultContainerName = "SecurityObjectContextConnection"

            ElseIf ObjectContextType = ObjectContext.ObjectContextType.BillingCommandCenter Then

                MyBase.DefaultContainerName = "BCCObjectContextConnection"

            ElseIf ObjectContextType = ObjectContext.ObjectContextType.Reporting Then

                MyBase.DefaultContainerName = "ReportingObjectContextConnection"

            Else

                MyBase.DefaultContainerName = "ObjectContextConnection"

            End If

            _UserCode = UserCode
            _ConnectionString = ConnectionString

        End Sub
        Public Shadows Function CreateObjectSet(Of TEntity As Class)(ByVal entitySetName As String) As System.Data.Objects.ObjectSet(Of TEntity)

            CreateObjectSet = MyBase.CreateObjectSet(Of TEntity)(entitySetName)

            If CreateObjectSet IsNot Nothing Then

                If _AllowChangeTracking = False Then

                    CreateObjectSet.MergeOption = System.Data.Objects.MergeOption.NoTracking

                End If

            End If

        End Function
        Public Sub DeleteEntityObject(ByRef Entity As AdvantageFramework.BaseClasses.Entity)

            Try

                Me.TryAttach(Entity)

            Catch ex As Exception

            End Try

            MyBase.DeleteObject(Entity)

        End Sub
        Public Sub AttachToOrGet(Of T As AdvantageFramework.BaseClasses.Entity)(ByVal EntitySetName As String, ByRef Entity As T)

            'objects
            Dim ObjectStateEntry As System.Data.Objects.ObjectStateEntry = Nothing
            Dim Attach As Boolean = False

            If Me.ObjectStateManager.TryGetObjectStateEntry(Me.CreateEntityKey(EntitySetName, Entity), ObjectStateEntry) Then

                Attach = (ObjectStateEntry.State = EntityState.Detached)

                Entity = DirectCast(ObjectStateEntry.Entity, T)

            Else

                Attach = True

            End If

            If Attach Then

                Me.AttachTo(EntitySetName, Entity)

            End If

        End Sub
        Public Sub UpdateObject(ByRef Entity As AdvantageFramework.BaseClasses.Entity)

            'objects
            Dim ObjectStateEntry As System.Data.Objects.ObjectStateEntry = Nothing
            Dim Computed As Boolean = False

            Try

                Me.TryAttach(Entity)

                If Me.ObjectStateManager.TryGetObjectStateEntry(Entity, ObjectStateEntry) Then

                    For Each FieldMetaData In ObjectStateEntry.CurrentValues.DataRecordInfo.FieldMetadata

                        Computed = False

                        For Each MetadataProperty In DirectCast(FieldMetaData.FieldType, System.Data.Metadata.Edm.EdmProperty).MetadataProperties

                            If TypeOf MetadataProperty.Value Is String AndAlso CStr(MetadataProperty.Value) = "Computed" Then

                                Computed = True
                                Exit For

                            End If

                        Next

                        If Computed = False Then

                            ObjectStateEntry.SetModifiedProperty(FieldMetaData.FieldType.Name)

                        End If

                    Next

                End If

            Catch ex As Exception
                ObjectStateEntry = Nothing
            End Try

        End Sub
        Public Function TryAttach(ByRef Entity As AdvantageFramework.BaseClasses.Entity) As Boolean

            'objects
            Dim Attached As Boolean = False
            Dim CacheEntity As AdvantageFramework.BaseClasses.Entity = Nothing
            Dim ObjectContext As AdvantageFramework.BaseClasses.ObjectContext = Nothing

            Try

                If Entity IsNot Nothing Then

                    ObjectContext = Entity.ObjectContext

                    If Entity.EntityKey IsNot Nothing Then

                        If Me.TryGetObjectByKey(Entity.EntityKey, CacheEntity) Then

                            If Entity.EntityState <> EntityState.Added Then

                                Entity = Me.ApplyCurrentValues(Entity.EntityKey.EntitySetName, Entity)

                            End If

                            If Entity.ObjectContext Is Nothing Then

                                If ObjectContext IsNot Nothing AndAlso ObjectContext.IsDisposed = False Then

                                    Entity.ObjectContext = ObjectContext

                                Else

                                    Entity.ObjectContext = Me

                                End If

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
        Public Sub UndoChanges(ByRef Entity As AdvantageFramework.BaseClasses.Entity)

            Try

                Me.TryAttach(Entity)

                Me.ObjectStateManager.ChangeObjectState(Entity, EntityState.Unchanged)

            Catch ex As Exception

            End Try

        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)

            MyBase.Dispose(True)

            _IsDisposed = True

        End Sub
        Public Function CreateCommand() As System.Data.SqlClient.SqlCommand

            'objects
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing

            If TypeOf Me.Connection Is System.Data.EntityClient.EntityConnection Then

                If TypeOf DirectCast(Me.Connection, System.Data.EntityClient.EntityConnection).StoreConnection Is System.Data.SqlClient.SqlConnection Then

                    SqlCommand = DirectCast(DirectCast(Me.Connection, System.Data.EntityClient.EntityConnection).StoreConnection, System.Data.SqlClient.SqlConnection).CreateCommand()

                End If

            End If

            CreateCommand = SqlCommand

        End Function

#End Region

    End Class

End Namespace