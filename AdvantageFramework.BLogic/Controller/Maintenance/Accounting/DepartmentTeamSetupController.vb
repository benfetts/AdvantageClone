Namespace Controller.Maintenance.Accounting

    Public Class DepartmentTeamSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

		Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "


#Region " Public "

		Public Sub New(Session As AdvantageFramework.Security.Session)

			_Session = Session

		End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel

            Dim DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel = Nothing

            DepartmentTeamSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DepartmentTeamSetupViewModel.DepartmentTeams = GetDepartmentTeams(DbContext)

            End Using

            Load = DepartmentTeamSetupViewModel

        End Function
        Public Function GetDepartmentTeams(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

            Return AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext).ToList

        End Function
        Public Function GetDepartmentTeams() As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                GetDepartmentTeams = GetDepartmentTeams(DbContext)

            End Using

        End Function
        Public Function GetDepartmentTeamsDTO() As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                GetDepartmentTeamsDTO = GetDepartmentTeams(DbContext).Select(Function(d) New AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam(d)).ToList

            End Using

        End Function
        Public Function Add(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel, DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam) As Boolean

			'objects
			Dim Added As Boolean = False

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, {DepartmentTeam}.ToList)

            End Using

        End Function
        Public Function Delete(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each DepartmentTeam In DepartmentTeamSetupViewModel.SelectedDepartmentTeams

                    If Delete(DbContext, DepartmentTeam) Then

                        Deleted = True

                        If DepartmentTeamSetupViewModel.DepartmentTeams.Remove(DepartmentTeam) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each DepartmentTeam In DepartmentTeams

                If Delete(DbContext, DepartmentTeam) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each DepartmentTeam In DepartmentTeams.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, DepartmentTeam) Then

                        Deleted = True

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam) As Boolean

            Return AdvantageFramework.Database.Procedures.DepartmentTeam.Delete(DbContext, DepartmentTeam)

        End Function
        Public Function Save(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, DepartmentTeamSetupViewModel.DepartmentTeams)

            End Using

        End Function
        Public Function Save(ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, DepartmentTeams.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Boolean

            'objects
            Dim Saved As Boolean = False

            For Each DepartmentTeam In DepartmentTeams

                If AdvantageFramework.Database.Procedures.DepartmentTeam.Update(DbContext, DepartmentTeam) = False Then

                    Saved = False

                End If

            Next

            Save = saved

        End Function
        Public Function Add(ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, DepartmentTeams.Select(Function(d) d.ToEntity(Nothing)).ToList)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Boolean

            'objects
            Dim Added As Boolean = False

            For Each DepartmentTeam In DepartmentTeams

                If DepartmentTeam.IsEntityBeingAdded() Then

                    DepartmentTeam.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.DepartmentTeam.Insert(DbContext, DepartmentTeam) Then

                        Added = True

                    End If

                End If

            Next

            Return Added

        End Function
        Public Function UpdateInactiveFlag(DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam, Value As Short) As Boolean

			'objects
			Dim Saved As Boolean = False

			If DepartmentTeam IsNot Nothing Then

				Try

					DepartmentTeam.IsInactive = Convert.ToInt16(Value)

				Catch ex As Exception
					DepartmentTeam.IsInactive = DepartmentTeam.IsInactive
				End Try

				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

				Try

					Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

						Saved = AdvantageFramework.Database.Procedures.DepartmentTeam.Update(DbContext, DepartmentTeam)

					End Using

				Catch ex As Exception

				End Try

				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

			End If

			UpdateInactiveFlag = Saved

		End Function
		Public Sub CancelNewItemRow(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel)

			DepartmentTeamSetupViewModel.IsNewRow = False
			DepartmentTeamSetupViewModel.CancelEnabled = False
			DepartmentTeamSetupViewModel.DeleteEnabled = DepartmentTeamSetupViewModel.HasASelectedDepartmentTeam

		End Sub
		Public Sub InitNewRowEvent(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel)

			DepartmentTeamSetupViewModel.IsNewRow = True
			DepartmentTeamSetupViewModel.CancelEnabled = True
			DepartmentTeamSetupViewModel.DeleteEnabled = False

		End Sub
		Public Sub DepartmentTeamSelectionChanged(DepartmentTeamSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel,
												  IsNewItemRow As Boolean,
												  SelectedDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam))

			DepartmentTeamSetupViewModel.IsNewRow = IsNewItemRow
			DepartmentTeamSetupViewModel.CancelEnabled = IsNewItemRow
			DepartmentTeamSetupViewModel.DeleteEnabled = Not IsNewItemRow

			DepartmentTeamSetupViewModel.SelectedDepartmentTeams = SelectedDepartmentTeams

		End Sub
        Public Function LoadPurchaseOrderApprovalRules() As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadAllActive(DbContext).ToList

            End Using

        End Function
        Public Function LoadServiceFeeTypes() As Generic.List(Of AdvantageFramework.Database.Entities.ServiceFeeType)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList

            End Using

        End Function

#End Region

#End Region

    End Class

End Namespace
