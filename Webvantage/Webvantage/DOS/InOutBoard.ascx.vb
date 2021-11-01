Public Class InOutBoard
    Inherits Webvantage.BaseUserControl

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum InOutBoardStatus
        [In] = 0
        [Out] = 1
    End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property Visible As Boolean = True
    Public Property AllowEmployeeSelect As Boolean = False

    Private Property ShowEntryPanel As Boolean = False
    Private Property CurrentInOutStatus() As InOutBoardStatus
        Get
            If ViewState("CurrentInOutStatus") Is Nothing Then
                Return InOutBoardStatus.In
            Else
                Return DirectCast(ViewState("CurrentInOutStatus"), InOutBoardStatus)
            End If
        End Get
        Set(ByVal value As InOutBoardStatus)
            ViewState("CurrentInOutStatus") = value
        End Set
    End Property
    Private Property SelectedEmployeeCode As String
        Get
            If ViewState("InOutBoardEmployeeCode") Is Nothing Then

                ViewState("InOutBoardEmployeeCode") = HttpContext.Current.Session("EmpCode")

            End If

            Return ViewState("InOutBoardEmployeeCode")

        End Get
        Set(value As String)

            ViewState("InOutBoardEmployeeCode") = value

        End Set
    End Property

    Public Event InsertStatusComplete()

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ImageButtonInOutBoardSave_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonInOutBoardSave.Click

        If Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate.HasValue = False OrElse CType(Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate, Date) < cEmployee.TimeZoneToday Then

            Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate = cEmployee.TimeZoneToday

        End If

        Me.CurrentInOutStatus = InOutBoardStatus.Out
        InsertStatus(CType(Me.CurrentInOutStatus, Integer), Now, Me.TextBoxInOutBoardReason.Text, Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate)

        LoadCurrentStatus()

    End Sub
    Private Sub LinkButtonCurrentStatus_Click(sender As Object, e As EventArgs) Handles LinkButtonCurrentStatus.Click

        Select Case Me.LinkButtonCurrentStatus.Text.Trim().ToUpper()

            Case "OUT" ' Checking IN

                Me.CurrentInOutStatus = InOutBoardStatus.In
                Me.InsertStatus(CType(Me.CurrentInOutStatus, Integer), DateTime.Now, "", DateTime.Now)
                Me.LoadCurrentStatus()
                '' FIX:  Me.RefreshInOutBoardObjects("DesktopAlerts")

            Case "IN" ' Checking OUT

                If Me.DivInOutBoardEntryForm.Visible = True Then

                    Me.LoadCurrentStatus()

                Else

                    Me.SetIcon(Me.DivCurrentStatusFlagColor, Me.LinkButtonCurrentStatus, Me.CurrentInOutStatus, False)
                    Me.LinkButtonCurrentStatus.ToolTip = "Click save icon to check out"
                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Me.DivCurrentStatusFlagColor, AdvantageFramework.Web.Presentation.Controls.StandardColor.Amber)

                    Me.DivInOutBoardEntryForm.Visible = True
                    Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate = cEmployee.TimeZoneToday

                End If

        End Select

    End Sub
    Private Sub RadComboBoxEmployees_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEmployees.SelectedIndexChanged

        Me.SelectedEmployeeCode = Me.RadComboBoxEmployees.SelectedItem.Value
        Me.LoadCurrentStatus()

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack OrElse Me.Page.IsCallback Then

            Me.SelectedEmployeeCode = HttpContext.Current.Session("EmpCode")

            If AllowEmployeeSelect = True Then

                Me.DivSelectEmployee.Visible = True

                Me.RadComboBoxEmployees.Items.Clear()

                Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
                With Me.RadComboBoxEmployees

                    .DataSource = oDO.GetInOutBoard()
                    .DataTextField = "EMP_CODE"
                    .DataValueField = "EMP"
                    .DataBind()

                End With

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxEmployees, Me.SelectedEmployeeCode, False)

            Else

                Me.DivSelectEmployee.Visible = False
                Me.RadComboBoxEmployees.Items.Clear()

            End If

            Me.LoadCurrentStatus()

        End If

    End Sub

#End Region

    Public Sub LoadCurrentStatus()

        Me.CurrentInOutStatus = InOutBoardStatus.In

        Dim InOutReason As String = ""
        Dim SQL_STRING As String = ""
        Dim dr As SqlClient.SqlDataReader
        Dim oSQL As SqlHelper

        SQL_STRING = "SELECT TOP 1 INOUT_STAT, COMMENT = CASE WHEN COMMENT IS NULL THEN '' ELSE COMMENT END, ISNULL(EXP_RETURN_TIME, GETDATE()) AS EXP_RETURN_TIME FROM EMP_INOUTBOARD WITH(NOLOCK) WHERE EMP_CODE = '" & _
                     Me.SelectedEmployeeCode & "' ORDER BY INOUT_REF DESC;"

        Try

            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

        Catch

            Err.Raise(Err.Number, "Class:dt_inoutboard.ascx Routine:LoadCurrentStatus", Err.Description)

        Finally

        End Try

        If dr.HasRows Then

            dr.Read()

            Try

                If dr.GetInt16(0) = 1 Then

                    Me.CurrentInOutStatus = InOutBoardStatus.Out

                End If

            Catch ex As Exception

                Me.CurrentInOutStatus = InOutBoardStatus.In

            End Try

            Try

                InOutReason = dr.GetString(1)

            Catch ex As Exception

            End Try

        End If

        Me.SetIcon(Me.DivCurrentStatusFlagColor, Me.LinkButtonCurrentStatus, Me.CurrentInOutStatus, False)

        If Me.CurrentInOutStatus = InOutBoardStatus.Out Then

            Me.DivInOutBoardEntryForm.Visible = True
            Me.TextBoxInOutBoardReason.ReadOnly = True
            Me.TextBoxInOutBoardReason.Text = InOutReason

            Me.RadDatePickerInOutBoardExpectedReturn.Enabled = False
            Me.ImageButtonInOutBoardSave.Visible = False
            Me.ImageButtonInOutBoardCancel.Visible = False

            Try

                Me.RadDatePickerInOutBoardExpectedReturn.SelectedDate = dr.GetDateTime(2)

            Catch ex As Exception

            End Try

        Else

            Me.TextBoxInOutBoardReason.ReadOnly = False
            Me.TextBoxInOutBoardReason.Text = ""
            Me.RadDatePickerInOutBoardExpectedReturn.Enabled = True
            Me.ImageButtonInOutBoardSave.Visible = True
            Me.ImageButtonInOutBoardCancel.Visible = True
            Me.DivInOutBoardEntryForm.Visible = False

        End If

        dr.Close()

    End Sub
    Private Sub InsertStatus(ByVal IOStatus As Int16, ByVal IOTime As DateTime, ByVal Comment As String, ByVal ReturnDate As DateTime)

        Dim IOBoard As New cInOutBoard(Session("ConnString"))
        IOBoard.Insert_Status(SelectedEmployeeCode, IOStatus, IOTime, Comment, ReturnDate)

        RaiseEvent InsertStatusComplete()

    End Sub

    Public Sub SetIcon(ByRef IconDiv As HtmlControls.HtmlControl, ByRef StatusLinkButton As LinkButton, ByRef Status As InOutBoard.InOutBoardStatus, ByVal IsGrid As Boolean)

        Select Case Status
            Case InOutBoardStatus.In

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Me.DivCurrentStatusFlagColor, AdvantageFramework.Web.Presentation.Controls.StandardColor.LightGreen)

                StatusLinkButton.ToolTip = "Click to check out"
                StatusLinkButton.Text = "IN"
                StatusLinkButton.CssClass = "icon-text-two"

                If IsGrid = False Then

                    StatusLinkButton.Attributes.Remove("style")
                    StatusLinkButton.Attributes.Add("style", "bottom: -1px !important;")

                End If

            Case InOutBoardStatus.Out

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Me.DivCurrentStatusFlagColor, AdvantageFramework.Web.Presentation.Controls.StandardColor.Red)

                StatusLinkButton.ToolTip = "Click to check in"
                StatusLinkButton.Text = "OUT"
                StatusLinkButton.CssClass = "icon-text-three"

                If IsGrid = False Then

                    Me.LinkButtonCurrentStatus.Attributes.Remove("style")

                End If

            Case Else

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Me.DivCurrentStatusFlagColor, AdvantageFramework.Web.Presentation.Controls.StandardColor.Amber)

        End Select

    End Sub

    Public Shared Function DisplayInOutTime(ByVal InOutTime As String) As String

        Try
            If String.IsNullOrWhiteSpace(InOutTime) = True Then

                Return ""

            Else

                InOutTime = InOutTime.Trim()

                If InOutTime = "1/1/1900 12:00:00 AM" Then

                    Return ""

                Else



                    If IsDate(InOutTime) = False Then

                        Return ""

                    Else

                        Dim InOutDateTime As DateTime

                        InOutDateTime = CType(InOutTime, DateTime)

                        If InOutDateTime.ToShortDateString = Now.Date.ToShortDateString Then

                            Return InOutDateTime.ToShortTimeString

                        Else

                            Return LoGlo.FormatDateTime(InOutDateTime)

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            Return InOutTime

        End Try

    End Function
    Public Shared Function DisplayReturnTime(ByVal InOutTime As String, ByVal ReturnTime As String) As String

        Try
            If String.IsNullOrWhiteSpace(ReturnTime) = True Then

                Return ""

            Else

                ReturnTime = ReturnTime.Trim()

                If ReturnTime = "1/1/1900 12:00:00 AM" Then

                    Return ""

                Else

                    If IsDate(ReturnTime) = False Then

                        Return ""

                    Else

                        'Dim InOutDateTime As DateTime = AdvantageFramework.AlertSystem.LocalDate(DBOffSet, AgencyEmployeeOffSet, InOutTime)
                        Dim ReturnDateTime As Nullable(Of DateTime)

                        If IsDate(ReturnTime) = True Then

                            ReturnDateTime = CType(ReturnTime, DateTime)

                        End If

                        If ReturnDateTime Is Nothing Then

                            Return ""

                        Else

                            'If ReturnDateTime < InOutDateTime Then

                            '    Return ""

                            'Else

                            If CType(ReturnDateTime, DateTime).ToShortDateString = Now.ToShortDateString Then

                                Return "Today"

                            Else

                                Return LoGlo.FormatDate(ReturnDateTime)

                            End If

                            'End If

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            Return InOutTime

        End Try

    End Function

#End Region

    Private Sub ImageButtonInOutBoardCancel_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonInOutBoardCancel.Click

        Me.LoadCurrentStatus()
        'Me.DivInOutBoardEntryForm.Visible = False

    End Sub

End Class