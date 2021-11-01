Namespace WinForm.MVC.Presentation.Controls

    Public Class SubItemDateInput
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            ShortDateAndTime
            Broadcast
        End Enum

#End Region

#Region " Variables "

        Private _AllowClose As Boolean = False
        Protected _ControlType As SubItemDateInput.Type = SubItemDateInput.Type.Default
        Protected _BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing

#End Region

#Region " Properties "

        Public Property ControlType() As SubItemDateInput.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemDateInput.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public WriteOnly Property BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)
            Set(value As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek))
                _BroadcastCalendarWeeks = value
            End Set
        End Property

#End Region

#Region " Methods "

        Protected Sub SetControlType()

            Select Case _ControlType

                Case SubItemDateInput.Type.Default

                    Me.DisplayFormat.FormatString = "d"
                    Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.EditFormat.FormatString = "d"
                    Me.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None

                Case SubItemDateInput.Type.ShortDateAndTime

                    Me.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True
                    Me.CalendarTimeProperties.EditMask = "hh:mm tt"

                    Me.DisplayFormat.FormatString = "g"
                    Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.EditFormat.FormatString = "g"
                    Me.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.EditMask = "g"

                    Me.Mask.UseMaskAsDisplayFormat = True

                    _AllowClose = True

                Case SubItemDateInput.Type.Broadcast

                    Me.FirstDayOfWeek = DayOfWeek.Monday

                    Me.DisplayFormat.FormatString = "d"
                    Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.EditFormat.FormatString = "d"
                    Me.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.Mask.EditMask = "d"

                    Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

                    _AllowClose = True

            End Select

        End Sub
        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

            'Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
            'Me.Mask.UseMaskAsDisplayFormat = False

            Me.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
            Me.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False

            Me.MinValue = #1/1/1900#
            Me.MaxValue = #6/6/2079#

            Me.AllowMouseWheel = False

        End Sub
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

        Private Sub SubItemDateInput_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Me.ButtonPressed

            If _ControlType = Type.Default Then

                If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo AndAlso CBool(e.Button.Tag) = True Then

                    _AllowClose = True
                    DirectCast(sender, DevExpress.XtraEditors.DateEdit).ClosePopup()

                Else

                    e.Button.Tag = True

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

            'objects
            Dim EnteredDate As String = Nothing
            Dim EnteredDateValue As Nullable(Of Date) = Nothing
            Dim MinDateValue As Date = Nothing
            Dim MaxDateValue As Date = Nothing

            If e.Value IsNot Nothing AndAlso e.Handled = False AndAlso e.Value.GetType IsNot GetType(Date) AndAlso IsDBNull(e.Value) = False Then

                EnteredDate = e.Value

                If String.IsNullOrWhiteSpace(EnteredDate) = False Then

                    Try

                        EnteredDate = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(EnteredDate)

                        If Not String.IsNullOrWhiteSpace(EnteredDate) Then

                            EnteredDateValue = EnteredDate

                        End If

                    Catch ex As Exception
                        EnteredDateValue = Nothing
                    End Try

                    If IsNothing(EnteredDateValue) = False Then

                        Try

                            MinDateValue = CDate(Me.MinValue.ToShortDateString)

                        Catch ex As Exception
                            MinDateValue = CDate(Date.MinValue.ToShortDateString)
                        End Try

                        Try

                            MaxDateValue = CDate(Me.MaxValue.ToShortDateString)

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

                        _AllowClose = False
                        e.Handled = True

                    End If

                Else

                    e.Value = Nothing

                End If

            Else

                e.Handled = False

            End If

        End Sub
        Private Sub SubItemDateInput_Popup(sender As Object, e As EventArgs) Handles Me.Popup

            If _ControlType = Type.Default Then

                If TypeOf DirectCast(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow Is DevExpress.XtraEditors.Popup.VistaPopupDateEditForm Then

                    AddHandler DirectCast(DirectCast(DirectCast(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow, DevExpress.XtraEditors.Popup.VistaPopupDateEditForm).Controls(0), DevExpress.XtraEditors.Controls.CalendarControl).MouseDoubleClick, AddressOf Calendar_MouseDoubleClick

                ElseIf TypeOf DirectCast(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow Is DevExpress.XtraEditors.Popup.PopupDateEditForm Then

                    AddHandler DirectCast(DirectCast(DirectCast(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm).Controls(0), DevExpress.XtraEditors.Controls.CalendarControl).MouseDoubleClick, AddressOf Calendar_MouseDoubleClick

                End If

                For Each Button As DevExpress.XtraEditors.Controls.EditorButton In DirectCast(sender, DevExpress.XtraEditors.DateEdit).Properties.Buttons

                    If Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo Then

                        Button.Tag = False
                        Exit For

                    End If

                Next

                _AllowClose = False

            End If

        End Sub
        Private Sub SubItemDateInput_QueryCloseUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.QueryCloseUp

            e.Cancel = Not _AllowClose

        End Sub
        Private Sub SubItemDateInput_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles Me.DrawItem

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

                                If e.Disabled = False Then

                                    Brush = Drawing.Brushes.Black

                                    StringFormat = New System.Drawing.StringFormat
                                    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                    e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                    e.Handled = True

                                Else

                                    Brush = Drawing.Brushes.Gray

                                    StringFormat = New System.Drawing.StringFormat
                                    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                    e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                    e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

                                    e.Handled = True

                                End If

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

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub Calendar_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)

            If sender IsNot Nothing Then

                _AllowClose = True

            End If

        End Sub

        Private Sub SubItemDateInput_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles Me.DisableCalendarDate

        End Sub

#End Region

#End Region

    End Class

End Namespace