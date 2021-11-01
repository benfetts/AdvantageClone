Namespace ViewModels.Maintenance.Accounting

	Public Class DepartmentTeamSetupViewModel

		'Public Event SelectionChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property CancelEnabled As Boolean
		Public Property DeleteEnabled As Boolean
		Public Property DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)
		Public ReadOnly Property HasASelectedDepartmentTeam As Boolean
			Get
				HasASelectedDepartmentTeam = SelectedDepartmentTeams IsNot Nothing AndAlso SelectedDepartmentTeams.Count > 0
			End Get
		End Property
		Public Property IsNewRow As Boolean
		Public Property SelectedDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

#End Region

#Region " Methods "



#End Region

	End Class

End Namespace

