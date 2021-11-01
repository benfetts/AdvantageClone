Namespace WinForm.Presentation.Controls

    Public Class SubItemTimeInput
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            HourAndMinute
        End Enum

#End Region

#Region " Variables "

        Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _AllowClose As Boolean = False
        Protected _ControlType As SubItemTimeInput.Type = SubItemTimeInput.Type.Default

#End Region

#Region " Properties "

        Public Property DbContext() As AdvantageFramework.Database.DbContext
            Get
                DbContext = _DbContext
            End Get
            Set(ByVal value As AdvantageFramework.Database.DbContext)
                _DbContext = value
            End Set
        End Property
        Public Property ControlType() As SubItemTimeInput.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemTimeInput.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property

#End Region

#Region " Methods "

        Protected Sub SetControlType()

            Select Case _ControlType

                Case Type.Default

                Case Type.HourAndMinute

                    Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    Me.DisplayFormat.FormatString = "t"

                    Me.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    Me.EditFormat.FormatString = "t"

                    Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None

                    Me.Buttons.Clear()

            End Select

        End Sub
        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

            Me.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False

            Me.AllowMouseWheel = False

        End Sub


#Region "  Control Event Handlers "


        Private Sub SubItemTimeInput_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

            'objects
            Dim EnteredTime As String = Nothing
            Dim ParsedTimeValue As Nullable(Of Date) = Nothing
            Dim EnteredTimeValue As Date = Nothing
            Dim EnteredTimeSuffix As String = ""
            Dim EnteredTimeArray As String() = Nothing
            Dim Is24HourTime As Boolean = False

            If e.Value IsNot Nothing AndAlso e.Handled = False AndAlso e.Value.GetType IsNot GetType(Date) AndAlso IsDBNull(e.Value) = False Then

                EnteredTime = e.Value

                If String.IsNullOrWhiteSpace(EnteredTime) = False Then

                    If Not DateTime.TryParse(EnteredTime, EnteredTimeValue) Then

                        Select Case Me.ControlType

                            Case Type.HourAndMinute

                                If EnteredTime.ToUpper.Contains("A") OrElse EnteredTime.ToUpper.Contains("P") Then

                                    If EnteredTime.ToUpper.Contains("A") Then

                                        EnteredTimeArray = EnteredTime.ToUpper().Split("A")
                                        EnteredTimeSuffix = "AM"

                                    Else

                                        EnteredTimeArray = EnteredTime.ToUpper().Split("P")
                                        EnteredTimeSuffix = "PM"

                                    End If

                                    If EnteredTimeArray.Length = 2 Then

                                        EnteredTime = Trim(EnteredTimeArray(0))

                                    End If

                                End If

                                If EnteredTime.Contains(":") Then

                                    EnteredTime = EnteredTime.Replace(":", "")

                                End If

                                If EnteredTime.Length <= 2 Then

                                    EnteredTime = EnteredTime & "00"

                                End If

                                If EnteredTime.Length <= 3 Then

                                    EnteredTime = "0" & EnteredTime

                                End If

                                If EnteredTime.Length <= 4 Then

                                    EnteredTime = EnteredTime.Substring(0, 2) & ":" & EnteredTime.Substring(2, 2)

                                End If

                                If CInt(EnteredTime.Split(":")(0)) = 24 Then

                                    EnteredTime = "00:" & EnteredTime.Split(":")(1)

                                End If

                                If Not String.IsNullOrWhiteSpace(EnteredTimeSuffix) Then

                                    EnteredTime = EnteredTime & " " & EnteredTimeSuffix

                                    If DateTime.TryParse(EnteredTime, EnteredTimeValue) Then

                                        ParsedTimeValue = EnteredTimeValue

                                    End If

                                Else

                                    Try

                                        Is24HourTime = If(CInt(EnteredTime.Split(":")(0)) >= 12, True, False)

                                    Catch ex As Exception
                                        Is24HourTime = False
                                    End Try

                                    Try

                                        ParsedTimeValue = DateTime.ParseExact(EnteredTime, If(Is24HourTime, "HH:mm", "hh:mm"), System.Globalization.CultureInfo.InvariantCulture)

                                    Catch ex As Exception
                                        ParsedTimeValue = Nothing
                                    End Try

                                End If

                        End Select

                    Else

                        ParsedTimeValue = EnteredTimeValue

                    End If

                    If IsNothing(ParsedTimeValue) = False Then

                        e.Value = CDate(ParsedTimeValue)

                        e.Handled = True

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

#End Region

#Region "  Custom Control Event Handlers "

#End Region

#End Region

    End Class

End Namespace