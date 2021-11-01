Namespace Controller.GeneralLedger.Maintenance

    Public Class GeneralLedgerMappingExportController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function LoadExportTemplate(DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.ExportTemplate

            Return (From Item In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.GeneralLedgerMappingExport)
                    Where Item.IsSystemTemplate = True AndAlso
                              Item.Name = "GeneralLedgerMappingExport"
                    Select Item).SingleOrDefault

        End Function
        Private Sub LoadGeneralLedgerMappingExportGLAccounts(DbContext As AdvantageFramework.Database.DbContext, ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            If ViewModel.GeneralLedgerMappingExportGLAccounts Is Nothing Then

                ViewModel.GeneralLedgerMappingExportGLAccounts = New Generic.List(Of Database.Entities.GeneralLedgerMappingExportGLAccount)

            End If

            ViewModel.GeneralLedgerMappingExportGLAccounts.Clear()

            If ViewModel.SelectedGeneralLedgerMappingExportTargetAccount IsNot Nothing Then

                ViewModel.GeneralLedgerMappingExportGLAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.LoadByTargetAccountID(DbContext, ViewModel.SelectedGeneralLedgerMappingExportTargetAccount.ID).ToList)

            End If

        End Sub
        Private Sub LoadGeneralLedgerMappingExportTargetAccounts(DbContext As AdvantageFramework.Database.DbContext, ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            If ViewModel.GeneralLedgerMappingExportTargetAccounts Is Nothing Then

                ViewModel.GeneralLedgerMappingExportTargetAccounts = New Generic.List(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)

            End If

            ViewModel.GeneralLedgerMappingExportTargetAccounts.Clear()

            If ViewModel.SelectedRecordSource IsNot Nothing Then

                ViewModel.GeneralLedgerMappingExportTargetAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportTargetAccount.LoadByRecordSourceID(DbContext, ViewModel.SelectedRecordSource.ID).ToList)

            End If

        End Sub
        Private Sub LoadRecordSources(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            If ViewModel.RecordSources Is Nothing Then

				ViewModel.RecordSources = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

			End If

            ViewModel.RecordSources.Clear()

			ViewModel.RecordSources.AddRange(AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList)

		End Sub
        Private Sub LoadAllMappedGeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            ViewModel.AllMappedGeneralLedgerAccounts = (From Item In AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.Load(DbContext).ToList
                                                        Select Item.GeneralLedgerAccountCode).ToList

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Add(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                            ByVal GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    GeneralLedgerMappingExportTargetAccount.DbContext = DbContext
                    GeneralLedgerMappingExportTargetAccount.RecordSourceID = ViewModel.SelectedRecordSource.ID

                    If AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportTargetAccount.Insert(DbContext, GeneralLedgerMappingExportTargetAccount) = False Then

                        Throw New Exception("Failed to insert source account.")

                    Else

                        Added = True

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function AddDetail(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                                  ByVal GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount,
                                  ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If GeneralLedgerMappingExportGLAccount.IsEntityBeingAdded() Then

                        GeneralLedgerMappingExportGLAccount.DbContext = DbContext
                        GeneralLedgerMappingExportGLAccount.TargetAccountID = ViewModel.SelectedGeneralLedgerMappingExportTargetAccount.ID

                        If AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.Insert(DbContext, GeneralLedgerMappingExportGLAccount) Then

                            Added = True
                            ViewModel.AllMappedGeneralLedgerAccounts.Add(GeneralLedgerMappingExportGLAccount.GeneralLedgerAccountCode)

                        Else

                            Throw New Exception("Failed to insert general ledger mapping account.")

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                End Try

            End Using

            AddDetail = Added

        End Function
        Public Function Delete(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    If AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportTargetAccount.Delete(DbContext, ViewModel.SelectedGeneralLedgerMappingExportTargetAccount) = False Then

                        Throw New Exception("Failed to delete source account.")

                    Else

                        ViewModel.GeneralLedgerMappingExportTargetAccounts.Remove(ViewModel.SelectedGeneralLedgerMappingExportTargetAccount)

                        For Each GeneralLedgerMappingExportGLAccount In ViewModel.GeneralLedgerMappingExportGLAccounts

                            ViewModel.AllMappedGeneralLedgerAccounts.Remove(GeneralLedgerMappingExportGLAccount.GeneralLedgerAccountCode)

                        Next

                        ViewModel.GeneralLedgerMappingExportGLAccounts.Clear()

                        If ViewModel.SelectedGeneralLedgerMappingExportGLAccounts IsNot Nothing Then

                            ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Clear()

                        End If

                    End If

                    Deleted = True

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                End Try

            End Using

            ViewModel.IsNewItemRow = False
            ViewModel.CancelEnabled = False
            ViewModel.DeleteEnabled = ViewModel.HasASelectedSourceAccount

            Delete = Deleted

        End Function
        Public Function DeleteDetail(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                                     ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    For Each SelectedGeneralLedgerMappingExportGLAccount In ViewModel.SelectedGeneralLedgerMappingExportGLAccounts

                        If AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.Delete(DbContext, SelectedGeneralLedgerMappingExportGLAccount) = False Then

                            Throw New Exception("Failed to delete general ledger mapping account.")

                        Else

                            ViewModel.GeneralLedgerMappingExportGLAccounts.Remove(SelectedGeneralLedgerMappingExportGLAccount)
                            ViewModel.AllMappedGeneralLedgerAccounts.Remove(SelectedGeneralLedgerMappingExportGLAccount.GeneralLedgerAccountCode)

                        End If

                    Next

                    ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Clear()
                    Deleted = True

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                End Try

            End Using

            ViewModel.DetailIsNewItemRow = False
            ViewModel.DetailCancelEnabled = False
            ViewModel.DetailDeleteEnabled = ViewModel.HasASelectedGLAccount

            DeleteDetail = Deleted

        End Function
        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel = Nothing

            ViewModel = New AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel()

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadRecordSources(DbContext, ViewModel)
                ViewModel.RepositoryGeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).ToList
                LoadAllMappedGeneralLedgerAccounts(DbContext, ViewModel)

                ViewModel.GeneralLedgerMappingExportTargetAccounts = New Generic.List(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)
                ViewModel.GeneralLedgerMappingExportGLAccounts = New Generic.List(Of Database.Entities.GeneralLedgerMappingExportGLAccount)

                ViewModel.ExportTemplate = LoadExportTemplate(DbContext)
                ViewModel.ExportType = Exporting.Methods.ExportTypes.GeneralLedgerMappingExport

            End Using

            Load = ViewModel

        End Function
        Public Sub LoadRecordSources(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadRecordSources(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub LoadGeneralLedgerMappingExportTargetAccounts(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadGeneralLedgerMappingExportTargetAccounts(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub GeneralLedgerMappingExportTargetAccountSelectionChanged(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                                                                           ByVal IsNewItemRow As Boolean,
                                                                           ByVal GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ViewModel.GeneralLedgerMappingExportGLAccounts IsNot Nothing Then

                    ViewModel.GeneralLedgerMappingExportGLAccounts.Clear()

                End If

                If ViewModel.SelectedGeneralLedgerMappingExportGLAccounts IsNot Nothing Then

                    ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Clear()

                End If

                If Not IsNewItemRow Then

                    ViewModel.SelectedGeneralLedgerMappingExportTargetAccount = GeneralLedgerMappingExportTargetAccount

                    LoadGeneralLedgerMappingExportGLAccounts(DbContext, ViewModel)

                Else

                    ViewModel.SelectedGeneralLedgerMappingExportTargetAccount = Nothing

                End If

            End Using

            ViewModel.IsNewItemRow = IsNewItemRow
            ViewModel.CancelEnabled = IsNewItemRow
            ViewModel.DeleteEnabled = Not IsNewItemRow AndAlso ViewModel.HasASelectedSourceAccount

            ViewModel.DetailIsNewItemRow = False
            ViewModel.DetailCancelEnabled = False
            ViewModel.DetailDeleteEnabled = ViewModel.HasASelectedGLAccount

        End Sub
        Public Sub InitNewRowEvent(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel, IsDetailTable As Boolean)

            ViewModel.IsNewItemRow = Not IsDetailTable
            ViewModel.CancelEnabled = Not IsDetailTable
            ViewModel.DeleteEnabled = False
            ViewModel.DetailIsNewItemRow = IsDetailTable
            ViewModel.DetailCancelEnabled = IsDetailTable
            ViewModel.DetailDeleteEnabled = False

        End Sub
        Public Sub CancelNewItemRow(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel)

            ViewModel.IsNewItemRow = False
            ViewModel.CancelEnabled = False
            ViewModel.DeleteEnabled = ViewModel.HasASelectedSourceAccount
            ViewModel.DetailIsNewItemRow = False
            ViewModel.DetailCancelEnabled = False
            ViewModel.DetailDeleteEnabled = ViewModel.HasASelectedGLAccount

        End Sub
        Public Sub GeneralLedgerAccountSelectionChanged(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel,
                                                        ByVal IsNewItemRow As Boolean,
                                                        ByVal SelectedGeneralLedgerMappingExportGLAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount))

            ViewModel.IsNewItemRow = If(IsNewItemRow, False, ViewModel.IsNewItemRow)
            ViewModel.CancelEnabled = If(IsNewItemRow, False, ViewModel.CancelEnabled)
            ViewModel.DeleteEnabled = If(IsNewItemRow, False, ViewModel.DeleteEnabled)

            ViewModel.DetailIsNewItemRow = IsNewItemRow
            ViewModel.DetailCancelEnabled = IsNewItemRow
            ViewModel.DetailDeleteEnabled = Not IsNewItemRow

            ViewModel.SelectedGeneralLedgerMappingExportGLAccounts = SelectedGeneralLedgerMappingExportGLAccounts

        End Sub
        Public Sub SelectedRecordSourceChanged(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel, ByVal RecordSourceID As Integer)

            ViewModel.SelectedGeneralLedgerMappingExportTargetAccount = Nothing
            ViewModel.SelectedGeneralLedgerMappingExportGLAccounts = Nothing
            ViewModel.GeneralLedgerMappingExportTargetAccounts.Clear()
            ViewModel.GeneralLedgerMappingExportGLAccounts.Clear()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ViewModel.SelectedRecordSource = AdvantageFramework.Database.Procedures.RecordSource.LoadByRecordSourceID(DbContext, RecordSourceID)

                If ViewModel.SelectedRecordSource IsNot Nothing Then

                    LoadGeneralLedgerMappingExportTargetAccounts(DbContext, ViewModel)

                    If ViewModel.GeneralLedgerMappingExportTargetAccounts IsNot Nothing AndAlso ViewModel.GeneralLedgerMappingExportTargetAccounts.Count > 0 Then

                        ViewModel.SelectedGeneralLedgerMappingExportTargetAccount = ViewModel.GeneralLedgerMappingExportTargetAccounts.FirstOrDefault

                        LoadGeneralLedgerMappingExportGLAccounts(DbContext, ViewModel)

                        If ViewModel.GeneralLedgerMappingExportGLAccounts IsNot Nothing AndAlso ViewModel.GeneralLedgerMappingExportGLAccounts.Count > 0 Then

                            ViewModel.SelectedGeneralLedgerMappingExportGLAccounts = ViewModel.GeneralLedgerMappingExportGLAccounts.Take(1).ToList

                        End If

                    End If

                End If

            End Using

            ViewModel.IsNewItemRow = False
            ViewModel.CancelEnabled = False
            ViewModel.DeleteEnabled = ViewModel.HasASelectedSourceAccount

            ViewModel.DetailIsNewItemRow = False
            ViewModel.DetailCancelEnabled = False
            ViewModel.DetailDeleteEnabled = ViewModel.HasASelectedGLAccount

        End Sub
        Public Function ValidateEntity(GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerMappingExportGLAccount.DbContext = DbContext

                ErrorText = GeneralLedgerMappingExportGLAccount.ValidateEntity(IsValid)

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateEntity(GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerMappingExportTargetAccount.DbContext = DbContext

                ErrorText = GeneralLedgerMappingExportTargetAccount.ValidateEntity(IsValid)

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerMappingExportGLAccount.DbContext = DbContext

                ErrorText = GeneralLedgerMappingExportGLAccount.ValidateEntityProperty(FieldName, IsValid, Value)

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Function ValidateProperty(GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerMappingExportTargetAccount.DbContext = DbContext

                ErrorText = GeneralLedgerMappingExportTargetAccount.ValidateEntityProperty(FieldName, IsValid, Value)

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Function SyncMappingExportAccounts(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel) As Boolean

            'objects
            Dim Synced As Boolean = False

            If ViewModel.SelectedRecordSource IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Synced = AdvantageFramework.GeneralLedger.SyncMappingExportAccounts(DbContext, ViewModel.SelectedRecordSource.ID)

                    If Synced Then

                        LoadGeneralLedgerMappingExportTargetAccounts(DbContext, ViewModel)
                        LoadGeneralLedgerMappingExportGLAccounts(DbContext, ViewModel)
                        LoadAllMappedGeneralLedgerAccounts(DbContext, ViewModel)

                    End If

                End Using

            End If

            SyncMappingExportAccounts = Synced

        End Function
        Public Function Export(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel) As DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataFilter As AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerMappingExport = Nothing

            DataFilter = New Exporting.DataFilterClasses.GeneralLedgerMappingExport
            DataFilter.RecordSourceID = ViewModel.SelectedRecordSource.ID

            AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(Me.Session, ViewModel.ExportType, ViewModel.ExportTemplate.ID, DataFilter, DataTable)

            Return DataTable

        End Function
        Public Sub GeneralLedgerAccountValueChanged(ByVal ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel, ByVal GeneralLedgerAccountCode As String)

            'objects
            Dim GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount = Nothing
            Dim OriginalGLACode As String = Nothing

            If ViewModel.SelectedGeneralLedgerMappingExportGLAccounts IsNot Nothing AndAlso ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Count = 1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    GeneralLedgerMappingExportGLAccount = AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.LoadByID(DbContext, ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Single.ID)

                    OriginalGLACode = GeneralLedgerMappingExportGLAccount.GeneralLedgerAccountCode

                    GeneralLedgerMappingExportGLAccount.GeneralLedgerAccountCode = GeneralLedgerAccountCode

                    If AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportGLAccount.Update(DbContext, GeneralLedgerMappingExportGLAccount) Then

                        ViewModel.AllMappedGeneralLedgerAccounts.Remove(OriginalGLACode)
                        ViewModel.AllMappedGeneralLedgerAccounts.Add(GeneralLedgerAccountCode)

                    End If

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
