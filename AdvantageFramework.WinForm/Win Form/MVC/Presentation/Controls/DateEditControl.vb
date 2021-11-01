Namespace WinForm.MVC.Presentation.Controls

	Public Class DateEdit
		Inherits DevExpress.XtraEditors.DateEdit
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
			[Broadcast]
		End Enum

#End Region

#Region " Variables "

		Protected _ControlType As DateEdit.Type = DateEdit.Type.Default
		Protected _IsRequired As Boolean = False
		Protected _DisplayName As String = ""
		Protected _FormSettingsLoaded As Boolean = False
		Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
		Protected _UserEntryChanged As Boolean = False
		Protected _ByPassUserEntryChanged As Boolean = False
		Protected _ReadOnly As Boolean = False
		Protected _SuspendedForLoading As Boolean = False
		Protected _OriginalInputButtonSettings As Hashtable = Nothing
		Protected _ShowingButtons As Boolean = False
		Protected _TabOnEnter As Boolean = True
		Protected _BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
        Protected _SecurityEnabled As Boolean = True

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.UserEntryChanged
			Get
				UserEntryChanged = _UserEntryChanged
			End Get
		End Property
		Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
			Set(value As Boolean)
				_ByPassUserEntryChanged = value
			End Set
		End Property
		Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
			Set(value As Boolean)
				_SuspendedForLoading = value
			End Set
		End Property
		Public Property ControlType() As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type
			Get
				ControlType = _ControlType
			End Get
			Set(value As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type)
				_ControlType = value
				SetControlType()
			End Set
		End Property
		Public Property DisplayName As String
			Get
				DisplayName = _DisplayName
			End Get
			Set(value As String)
				_DisplayName = value
			End Set
		End Property
        Public Property TabOnEnter() As Boolean
            Get
                TabOnEnter = _TabOnEnter
            End Get
            Set(value As Boolean)
                _TabOnEnter = value
            End Set
        End Property
        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

                End If

            End Set
        End Property
        Public Property SecurityEnabled As Boolean
            Get
                SecurityEnabled = _SecurityEnabled
            End Get
            Set(ByVal value As Boolean)
                _SecurityEnabled = value
                Me.Enabled = value
            End Set
        End Property
        Public Shadows Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = MyBase.ReadOnly
            End Get
            Set(ByVal value As Boolean)

                MyBase.ReadOnly = value

                If MyBase.ReadOnly Then

                    Me.BackColor = System.Drawing.SystemColors.Control

                Else

                    SetRequired(_IsRequired)

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

			Me.Size = New System.Drawing.Size(75, 20)
			Me.Properties.MinValue = #1/1/1900#
			Me.Properties.MaxValue = #6/6/2079#

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False
			Me.DoubleBuffered = True

			_OriginalInputButtonSettings = New Hashtable

		End Sub
		Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

			_UserEntryChanged = False

		End Sub
		Protected Sub LoadFormSettings(Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

			If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
					Form.Controls.Find(Me.Name, True).Any Then

				If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

					If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

					End If

					Try

						Using DbContext = New AdvantageFramework.Database.DbContext(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session.ConnectionString, DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session.UserCode)

							_BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

						End Using

					Catch ex As Exception
						_BroadcastCalendarWeeks = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)
					End Try

				End If

				_FormSettingsLoaded = True

			End If

		End Sub
		Public Sub SetPropertySettings(PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), EnumProperty As [Enum], Optional CustomDisplayName As String = "")

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor, CustomDisplayName)

		End Sub
		Public Sub SetPropertySettings(PropertyDescriptor As System.ComponentModel.PropertyDescriptor, Optional CustomDisplayName As String = "")

			'objects
			Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

			If PropertyDescriptor IsNot Nothing Then

				_DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

				Try

					EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

				Catch ex As Exception
					EntityAttribute = Nothing
				Finally

					If EntityAttribute IsNot Nothing Then

						SetRequired(EntityAttribute.IsRequired)

					End If

				End Try

			End If

			If CustomDisplayName <> "" Then

				_DisplayName = CustomDisplayName

			End If

		End Sub
		Public Sub SetPropertySettings(EnumProperty As [Enum], Optional CustomDisplayName As String = "")

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor, CustomDisplayName)

		End Sub
		Public Sub SetRequired(IsRequired As Boolean)

			_IsRequired = IsRequired

			If _IsRequired Then

				Me.BackColor = Drawing.Color.Cyan

			Else

				Me.BackColor = Drawing.Color.White

			End If

		End Sub
		Protected Sub SetControlType()

			Select Case _ControlType

				Case DateEdit.Type.Default

					Me.Properties.FirstDayOfWeek = DayOfWeek.Sunday

					Me.Properties.DisplayFormat.FormatString = "d"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.EditFormat.FormatString = "d"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.Mask.EditMask = "d"

					Me.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

				Case DateEdit.Type.Broadcast

					Me.Properties.FirstDayOfWeek = DayOfWeek.Monday

					Me.Properties.DisplayFormat.FormatString = "d"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.EditFormat.FormatString = "d"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.Mask.EditMask = "d"

					Me.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

			End Select

		End Sub
		Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

			'objects
			Dim IsValid As Boolean = True
			Dim Name As String = ""

			Try

				If _IsRequired Then

					If Me.Text.Trim = "" OrElse Me.EditValue Is Nothing Then

						If _DisplayName <> "" Then

							ErrorMessage = _DisplayName & " is required."

						Else

							Try

								Name = AdvantageFramework.StringUtilities.GetNameAsWords(Me.Name.Substring(Me.Name.IndexOf("_") + 1))

							Catch ex As Exception
								Name = ""
							End Try

							ErrorMessage = Name & " is required."

						End If

						IsValid = False

					End If

				End If

			Catch ex As Exception
				IsValid = False
			Finally
				Validate = IsValid
			End Try

		End Function
		Public Function GetValue() As Object

			Dim Value As Object = Nothing

			If Me.EditValue <> Nothing Then

				Try

					Value = Convert.ToDateTime(Me.EditValue)

				Catch ex As Exception
					Value = Nothing
				End Try

			End If

			GetValue = Value

		End Function
		Public Shadows Sub Show()

			Me.Visible = True

		End Sub
		Public Shadows Sub Hide()

			Me.Visible = False

		End Sub
		Public Function GetLastDayOfQuarter(Day As Date) As Date

			'objects
			Dim LastDayOfQuarter As Date = Nothing

			If Me.ControlType = Type.Default Then

				Select Case Day.Month

					Case 1, 2, 3

						LastDayOfQuarter = New Date(Day.Year, 3, Date.DaysInMonth(Day.Year, 3))

					Case 4, 5, 6

						LastDayOfQuarter = New Date(Day.Year, 6, Date.DaysInMonth(Day.Year, 6))

					Case 7, 8, 9

						LastDayOfQuarter = New Date(Day.Year, 9, Date.DaysInMonth(Day.Year, 9))

					Case 10, 11, 12

						LastDayOfQuarter = New Date(Day.Year, 12, Date.DaysInMonth(Day.Year, 12))

				End Select

			Else

				LastDayOfQuarter = GetLastDayOfBroadcastQuarter(Day)

			End If

			GetLastDayOfQuarter = LastDayOfQuarter

		End Function
		Private Function GetLastDayOfBroadcastQuarter(Day As Date) As Date

			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
			Dim MaxWeekDate As Nullable(Of Date) = Nothing
			Dim Month As Integer = Nothing
			Dim LastDay As Date = Nothing

			MaxWeekDate = (From Dates In _BroadcastCalendarWeeks
						   Where Dates.WeekDate <= Day
						   Select Dates.WeekDate).Max

			If MaxWeekDate IsNot Nothing Then

				BroadcastCalendarWeek = (From Dates In _BroadcastCalendarWeeks
										 Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

				If BroadcastCalendarWeek IsNot Nothing Then

					Select Case BroadcastCalendarWeek.Month

						Case 1, 2, 3

							Month = 3

						Case 4, 5, 6

							Month = 6

						Case 7, 8, 9

							Month = 9

						Case 10, 11, 12

							Month = 12

					End Select

					LastDay = (From Dates In _BroadcastCalendarWeeks
							   Where Dates.Month = Month AndAlso
									 Dates.Year = BroadcastCalendarWeek.Year
							   Select Dates.WeekDate).Max.AddDays(6)

				End If

			End If

			GetLastDayOfBroadcastQuarter = LastDay

		End Function
		Public Function GetLastDayOfWeek(Day As Date) As Date

			'objects
			Dim LastDayOfWeek As Date = Date.MinValue

			If Me.ControlType = Type.Default Then

				For DayCounter As Integer = 0 To 6

					If Day.AddDays(DayCounter).DayOfWeek = DayOfWeek.Saturday Then

						LastDayOfWeek = Day.AddDays(DayCounter)

						Exit For

					End If

				Next

			Else

				LastDayOfWeek = GetLastDayOfBroadcastWeek(GetWeek(Day), Day.Year)

			End If

			GetLastDayOfWeek = LastDayOfWeek

		End Function
		Private Function GetLastDayOfBroadcastWeek(Week As Integer, Year As Integer) As Date

			'objects
			Dim LastDay As Date = Date.MinValue

			LastDay = (From Dates In _BroadcastCalendarWeeks
					   Where Dates.Week = Week AndAlso
							 Dates.Year = Year
					   Select Dates.WeekDate).FirstOrDefault.AddDays(6)

			GetLastDayOfBroadcastWeek = LastDay

		End Function
		Public Function GetWeek([Date] As Date) As Integer

			'objects
			Dim Week As Integer = 0
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

			If Me.ControlType = Type.Default Then

				Week = CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday))

			Else

				Try

					BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

				Catch ex As Exception
					BroadcastCalendarWeek = Nothing
				End Try

				If BroadcastCalendarWeek IsNot Nothing Then

					Week = BroadcastCalendarWeek.Week

				End If

			End If

			GetWeek = Week

		End Function
		Public Function GetMonth([Date] As Date) As Integer

			'objects
			Dim Month As Integer = 0
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

			If Me.ControlType = Type.Default Then

				Month = [Date].Month

			Else

				Try

					BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

				Catch ex As Exception
					BroadcastCalendarWeek = Nothing
				End Try

				If BroadcastCalendarWeek IsNot Nothing Then

					Month = BroadcastCalendarWeek.Month

				End If

			End If

			GetMonth = Month

		End Function
		Public Function GetLastDayOfMonth(Day As Date) As Date

			'objects
			Dim LastDayOfMonth As Date = Nothing

			If Me.ControlType = Type.Default Then

				LastDayOfMonth = New Date(Day.Year, Day.Month, Date.DaysInMonth(Day.Year, Day.Month))

			Else

				LastDayOfMonth = GetLastDayOfBroadcastMonth(Day)

			End If

			GetLastDayOfMonth = LastDayOfMonth

		End Function
		Private Function GetLastDayOfBroadcastMonth(Day As Date) As Date

			Dim MaxWeekDate As Nullable(Of Date) = Nothing
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
			Dim LastDay As Nullable(Of Date) = Nothing

			MaxWeekDate = (From Dates In _BroadcastCalendarWeeks
						   Where Dates.WeekDate <= Day
						   Select Dates.WeekDate).Max

			If MaxWeekDate IsNot Nothing Then

				BroadcastCalendarWeek = (From Dates In _BroadcastCalendarWeeks
										 Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

				If BroadcastCalendarWeek IsNot Nothing Then

					LastDay = (From Dates In _BroadcastCalendarWeeks
							   Where Dates.Month = BroadcastCalendarWeek.Month AndAlso
									 Dates.Year = BroadcastCalendarWeek.Year
							   Select Dates.WeekDate).Max.AddDays(6)

				End If

			End If

			GetLastDayOfBroadcastMonth = LastDay

		End Function
		Public Function GetMonthDates([Date] As Date) As Generic.List(Of Date)

			'objects
			Dim Month As Integer = 0
			Dim Year As Integer = 0
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
			Dim Dates As Generic.List(Of Date) = Nothing
			Dim StartDate As Date = Nothing
			Dim EndDate As Date = Nothing
			Dim DayCounter As Integer = 0

			Dates = New Generic.List(Of Date)

			If Me.ControlType = Type.Default Then

				Month = [Date].Month

				For Day As Integer = 1 To DateTime.DaysInMonth([Date].Year, Month) Step 1

					Dates.Add(New Date([Date].Year, Month, Day))

				Next

			Else

				Try

					BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

				Catch ex As Exception
					BroadcastCalendarWeek = Nothing
				End Try

				If BroadcastCalendarWeek IsNot Nothing Then

					Month = BroadcastCalendarWeek.Month
					Year = BroadcastCalendarWeek.Year

				End If

				For Each BroadcastCalendarWeek In _BroadcastCalendarWeeks.Where(Function(Entity) Entity.Month = Month AndAlso Entity.Year = Year).ToList

					DayCounter = 0

					For DayCounter = 0 To 6 Step 1

						Dates.Add(BroadcastCalendarWeek.WeekDate.AddDays(DayCounter))

					Next

				Next

			End If

			GetMonthDates = Dates

		End Function
		Public Function GetQuarter([Date] As Date) As Integer

			'objects
			Dim Quarter As Integer = 0
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

			If Me.ControlType = Type.Default Then

				Quarter = CInt(Math.Ceiling([Date].Month / 3))

			Else

				Try

					BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

				Catch ex As Exception
					BroadcastCalendarWeek = Nothing
				End Try

				If BroadcastCalendarWeek IsNot Nothing Then

					Quarter = CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3))

				End If

			End If

			GetQuarter = Quarter

		End Function
		Public Function GetYear([Date] As Date) As Integer

			'objects
			Dim Year As Integer = 0
			Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

			If Me.ControlType = Type.Default Then

				Year = [Date].Year

			Else

				Try

					BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

				Catch ex As Exception
					BroadcastCalendarWeek = Nothing
				End Try

				If BroadcastCalendarWeek IsNot Nothing Then

					Year = BroadcastCalendarWeek.Year

				End If

			End If

			GetYear = Year

		End Function
		Private Function IsInBroadcastMonth(EntryDate As Date, Month As Integer) As Boolean

			'objects
			Dim IsValid As Boolean = False
			Dim Year As Integer = 0
			Dim EntryDateMonth As Integer = 0

			EntryDateMonth = GetMonth(EntryDate)

			If EntryDateMonth = Month Then

				IsValid = True

			End If

			IsInBroadcastMonth = IsValid

		End Function

#Region "  Control Event Handlers "

		Private Sub DateEdit_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles Me.DrawItem

			'objects
			Dim Brush As System.Drawing.Brush = Nothing
			Dim StringFormat As System.Drawing.StringFormat = Nothing
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If e IsNot Nothing AndAlso e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

				If Me.ControlType = Type.Broadcast Then

					PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
					PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

					If PopupDateEditForm IsNot Nothing Then

						CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

						If CalendarControl IsNot Nothing Then

							If IsInBroadcastMonth(e.Date, CalendarControl.DateTime.Month) Then

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

							Else

								Brush = Drawing.Brushes.White

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

							End If

						End If

					End If

				End If

			End If

		End Sub
		Private Sub DateEdit_Popup(sender As Object, e As EventArgs) Handles Me.Popup

			'objects
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If Me.ControlType = Type.Broadcast Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

						DateTimeFormatInfo = CType(CalendarControl.DateFormat.Clone(), System.Globalization.DateTimeFormatInfo)
						DateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Monday
						CalendarControl.DateFormat = DateTimeFormatInfo

						Try

							If Me.EditValue <> Nothing Then

								If Me.DateTime.Day = 1 Then

									CalendarControl.DateTime = CDate(GetMonth(Me.EditValue) & "/01/" & GetYear(Me.EditValue))

								Else

									CalendarControl.DateTime = CDate(GetMonth(Me.EditValue) & "/02/" & GetYear(Me.EditValue))

								End If

							End If

						Catch ex As Exception

						End Try

					Next

				End If

			End If

		End Sub
		Private Sub DateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles Me.EditValueChanging

			If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

				_UserEntryChanged = True

				AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

			End If

		End Sub
		Private Sub DateEdit_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

			'objects
			Dim EnteredDate As String = Nothing
			Dim EnteredDateValue As Date = Nothing
			Dim MinDateValue As Date = Nothing
			Dim MaxDateValue As Date = Nothing

			If e.Value IsNot Nothing AndAlso e.Handled = False AndAlso e.Value.GetType IsNot GetType(Date) AndAlso IsDBNull(e.Value) = False Then

				EnteredDate = e.Value

				If String.IsNullOrWhiteSpace(EnteredDate) = False Then

					Try

						EnteredDateValue = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(EnteredDate)

					Catch ex As Exception
						EnteredDateValue = Nothing
					End Try

					If IsNothing(EnteredDateValue) = False Then

						Try

							MinDateValue = CDate(Me.Properties.MinValue.ToShortDateString)

						Catch ex As Exception
							MinDateValue = CDate(Date.MinValue.ToShortDateString)
						End Try

						Try

							MaxDateValue = CDate(Me.Properties.MaxValue.ToShortDateString)

						Catch ex As Exception
							MaxDateValue = CDate(Date.MaxValue.ToShortDateString)
						End Try

						If (EnteredDateValue >= MinDateValue OrElse MinDateValue = Nothing) AndAlso (EnteredDateValue <= MaxDateValue OrElse MaxDateValue = Nothing) Then

							e.Value = CDate(EnteredDateValue)

							e.Handled = True

						Else

							e.Handled = False

						End If

					Else

						e.Handled = False

					End If

				Else

					e.Value = Nothing

				End If

			Else

				e.Handled = False

			End If

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
