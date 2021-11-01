Namespace EmployeeTimesheet.Classes

	<Serializable()>
	Public Class SaveTimeEntryResult
		Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property FullText As String = ""
		Public Property Message As String = ""
		Public Property EmployeeTimeID As Integer = 0
		Public Property EmployeeTimeDetailID As Short = 0
		Public Property EmployeeHours As Decimal = 0.0
		Public Property ErrorCode As Nullable(Of Integer) = 0
		Public Property WarningMessage As String = ""
		Public Property BillingRate As Nullable(Of Decimal) = 0
		Public Property NoBillFlag As Nullable(Of Short) = 0

#End Region

#Region " Methods "

		Sub New()

		End Sub

		Sub New(ByVal FullReturnMessage As String)

			Me.FullText = FullReturnMessage

			If FullReturnMessage.Contains("|") = True Then

				Dim ar() As String
				ar = FullReturnMessage.Split(CType("|", Char))

				Me.Message = ar(0).ToString()
				Me.EmployeeTimeID = CType(ar(1), Integer)
				Me.EmployeeTimeDetailID = CType(ar(2), Short)
				Me.EmployeeHours = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

				If ar.Length = 8 Then

					Me.BillingRate = ar(4)
					Me.NoBillFlag = ar(5)
					Me.ErrorCode = ar(6)
					Me.WarningMessage = ar(7)

				End If

			Else

				Me.Message = FullReturnMessage

			End If

		End Sub

#End Region

	End Class

End Namespace

