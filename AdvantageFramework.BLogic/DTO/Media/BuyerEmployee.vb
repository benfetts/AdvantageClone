Namespace DTO.Media

	Public Class BuyerEmployee
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property Code() As String
		Public Property Name() As String
		Public Property IsInactive() As Boolean
		Public Property IsEmployeeTerminated() As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.Code = String.Empty
			Me.Name = String.Empty
			Me.IsInactive = False
			Me.IsEmployeeTerminated = False

		End Sub
        Public Sub New(MediaBuyer As AdvantageFramework.Database.Entities.MediaBuyer)

            Me.Code = MediaBuyer.EmployeeCode
            Me.Name = MediaBuyer.Employee.ToString
            Me.IsInactive = MediaBuyer.IsInactive
            Me.IsEmployeeTerminated = MediaBuyer.Employee.TerminationDate.HasValue

        End Sub
        Public Sub New(Employee As AdvantageFramework.Database.Views.Employee)

            Me.Code = Employee.Code
            Me.Name = Employee.ToString
            Me.IsInactive = True
            Me.IsEmployeeTerminated = Employee.TerminationDate.HasValue

        End Sub
        Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Name

		End Function

#End Region

	End Class

End Namespace
