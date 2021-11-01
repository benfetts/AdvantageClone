Public Class Employee_Card
    Inherits Webvantage.BaseContentUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Nickname As String = ""
    Private _Firstname As String = ""
    Private _MiddleInitial As String = ""
    Private _Lastname As String = ""
    Private _Employee As AdvantageFramework.Database.Views.Employee

#End Region

#Region " Properties "


    Public Property EmployeeCode As String = ""
    Public Property EmployeeName As String
        Get
            Return Me.LabelEmployeeName.Text
        End Get
        Set(value As String)
            Me.LabelEmployeeName.Text = value
        End Set
    End Property
    Public Property EmployeePicture As Object
        Get
            Return Me.ASPxBinaryImageEmp.Value
        End Get
        Set(value As Object)
            Me.ASPxBinaryImageEmp.Value = value
        End Set
    End Property
    Public Property EmployeeTitle As String
        Get
            Return Me.LabelTitle.Text
        End Get
        Set(value As String)
            Me.LabelTitle.Text = value
        End Set
    End Property
    Public Property TaskCount As Integer
        Get
            If ViewState("TaskCount") Is Nothing Then
                ViewState("TaskCount") = 0
            End If
            Return CType(ViewState("TaskCount"), Integer)
        End Get
        Set(value As Integer)
            ViewState("TaskCount") = value
        End Set
    End Property
    Public Property TotalHours As Decimal
        Get
            If ViewState("TotalHours") Is Nothing Then
                ViewState("TotalHours") = 0
            End If
            Return CType(ViewState("TotalHours"), Decimal)
        End Get
        Set(value As Decimal)
            ViewState("TotalHours") = value
        End Set
    End Property
    Public Property ActualHours As Decimal
        Get
            If ViewState("ActualHours") Is Nothing Then
                ViewState("ActualHours") = 0
            End If
            Return CType(ViewState("ActualHours"), Decimal)
        End Get
        Set(value As Decimal)
            ViewState("ActualHours") = value
        End Set
    End Property
    Public Property ClientCode As String
        Get
            If ViewState("ClientCode") Is Nothing Then
                ViewState("ClientCode") = ""
            End If
            Return ViewState("ClientCode")
        End Get
        Set(value As String)
            ViewState("ClientCode") = value
        End Set
    End Property
    Public Property DivisionCode As String
        Get
            If ViewState("DivisionCode") Is Nothing Then
                ViewState("DivisionCode") = ""
            End If
            Return ViewState("DivisionCode")
        End Get
        Set(value As String)
            ViewState("DivisionCode") = value
        End Set
    End Property
    Public Property ProductCode As String
        Get
            If ViewState("ProductCode") Is Nothing Then
                ViewState("ProductCode") = ""
            End If
            Return ViewState("ProductCode")
        End Get
        Set(value As String)
            ViewState("ProductCode") = value
        End Set
    End Property
    Public Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then
                ViewState("JobNumber") = 0
            End If
            Return CType(ViewState("JobNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Public Property JobComponentNumber As Integer
        Get
            If ViewState("JobComponentNumber") Is Nothing Then
                ViewState("JobComponentNumber") = 0
            End If
            Return CType(ViewState("JobComponentNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("JobComponentNumber") = value
        End Set
    End Property

    Public Property ScheduleTitle As String
        Get
            If ViewState("ScheduleTitle") Is Nothing Then
                ViewState("ScheduleTitle") = ""
            End If
            Return ViewState("ScheduleTitle")
        End Get
        Set(value As String)
            ViewState("ScheduleTitle") = value
        End Set
    End Property
    Public Property TrafficColumnCode As String
        Get
            If ViewState("TrafficColumnCode") Is Nothing Then
                ViewState("TrafficColumnCode") = ""
            End If
            Return ViewState("TrafficColumnCode")
        End Get
        Set(value As String)
            ViewState("TrafficColumnCode") = value
        End Set
    End Property
    Public Property EmailGroupCode As String
        Get
            If ViewState("EmailGroupCode") Is Nothing Then
                ViewState("EmailGroupCode") = ""
            End If
            Return ViewState("EmailGroupCode")
        End Get
        Set(value As String)
            ViewState("EmailGroupCode") = value
        End Set
    End Property
    Public Property ManagerType As JobStatus_Team.ManagerType
        Get
            If ViewState("ManagerType") Is Nothing Then
                ViewState("ManagerType") = CType(JobStatus_Team.ManagerType.AccountExecutive, Integer)
            End If
            Return CType(ViewState("ManagerType"), JobStatus_Team.ManagerType)
        End Get
        Set(value As JobStatus_Team.ManagerType)
            ViewState("ManagerType") = CType(value, Integer).ToString()
        End Set
    End Property
    Public Property TeamType As JobStatus_Team.LoadType
        Get
            If ViewState("LoadType") Is Nothing Then
                ViewState("LoadType") = CType(JobStatus_Team.LoadType.AlertGroup, Integer)
            End If
            Return CType(ViewState("LoadType"), JobStatus_Team.LoadType)
        End Get
        Set(value As JobStatus_Team.LoadType)
            ViewState("LoadType") = CType(value, Integer).ToString()
        End Set
    End Property
    Public Property DisableAnimationAndBack As Boolean
        Get
            If ViewState("DisableAnimationAndBack") Is Nothing Then
                ViewState("DisableAnimationAndBack") = False
            End If
            Return CType(ViewState("DisableAnimationAndBack"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("DisableAnimationAndBack") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Event Saved()
    Public Event SaveClick()

#Region " Controls "


#End Region
#Region " Page "

    Private Sub Employee_Card_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request.Browser.Type.ToLower.Contains("safari") = True OrElse Me.DisableAnimationAndBack = True Then

            Me.DisableCardFlipAndBackOfCard()

        End If

    End Sub

#End Region

    Public Sub LoadDataFromEmployeeCode()

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            If MiscFN.IsClientPortal = False Then

                Dim ep As AdvantageFramework.Database.Entities.EmployeePicture
                ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, _EmployeeCode)
                If ep IsNot Nothing Then

                    If ep.Image IsNot Nothing Then

                        Me.ASPxBinaryImageEmp.Value = ep.Image

                    End If
                    If ep.Nickname IsNot Nothing Then

                        Me._Nickname = ep.Nickname

                    End If

                End If

                'Me._Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)
                Me._Employee = (From Employee In DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).Include("Role")
                                Where Employee.Code = EmployeeCode
                                Select Employee).SingleOrDefault()

                If Me._Employee IsNot Nothing Then

                    If Me._Employee.FirstName IsNot Nothing Then Me._Firstname = Me._Employee.FirstName
                    If Me._Employee.MiddleInitial IsNot Nothing Then Me._MiddleInitial = Me._Employee.MiddleInitial
                    If Me._Employee.LastName IsNot Nothing Then Me._Lastname = Me._Employee.LastName

                End If

                Dim sb As New System.Text.StringBuilder

                If Me._Firstname.Trim().Length > 0 Then
                    sb.Append(Me._Firstname.Trim())
                    sb.Append(" ")
                End If
                If Me._Nickname.Trim().Length > 0 AndAlso Me._Nickname <> Me._Firstname Then
                    sb.Append("""")
                    sb.Append(Me._Nickname.Trim())
                    sb.Append(""" ")
                End If
                'If Me._MiddleInitial.Length > 0 Then
                '    sb.Append(Me._MiddleInitial)
                '    sb.Append(". ")
                'End If
                If Me._Lastname.Trim().Length > 0 Then
                    sb.Append(Me._Lastname.Trim())
                End If

                Me.LabelEmployeeName.Text = sb.ToString()


                'Back of card
                If Request.Browser.Type.ToLower.Contains("safari") = True OrElse Me.DisableAnimationAndBack = True Then

                    Me.DisableCardFlipAndBackOfCard()

                Else

                    sb.Clear()

                    If Me._Firstname.Trim().Length > 0 Then
                        sb.Append(Me._Firstname.Trim())
                        sb.Append(" ")
                    End If
                    If Me._MiddleInitial.Trim().Length > 0 Then
                        sb.Append(Me._MiddleInitial.Trim())
                        sb.Append(". ")
                    End If
                    If Me._Lastname.Trim().Length > 0 Then
                        sb.Append(Me._Lastname.Trim())
                    End If

                    Me.LabelBackFullName.Text = sb.ToString()
                    sb = Nothing

                    If Me._Nickname.Length > 0 AndAlso Me._Nickname <> Me._Firstname Then

                        Me.LabelBackNickName.Text = "Nickname: " & Me._Nickname

                    End If
                    If Me._Employee IsNot Nothing Then

                        If Me._Employee.Email IsNot Nothing Then

                            Me.LabelBackEmail.Text = "Email: <a href=""mailto:" & Me._Employee.Email & """ target=""_top"">" & Me._Employee.Email & "</a>"

                        End If
                        If Me._Employee.CellPhoneNumber IsNot Nothing Then

                            Me.LabelBackCellPhone.Text = "Cell: " & Me._Employee.CellPhoneNumber

                        End If
                        If Me._Employee.RoleCode IsNot Nothing Then

                            Me.LabelBackDefaultRole.Text = "Role: " & Me._Employee.Role.Description

                        End If

                    End If

                End If

            Else
                'Client portal?


            End If

        End Using

    End Sub
    Public Sub LoadData()

        If Request.Browser.Type.ToLower.Contains("safari") = True Then

            'Me.DivEmployee.Attributes.Remove("ontouchstart")
            'Me.DivEmployee.Attributes.Remove("class")
            'Me.DivFlipper.Attributes.Remove("class")
            'Me.DivFront.Attributes.Remove("class")

            'Me.DivBack.Visible = False

        Else

            Me.DivEmployeeInfo.Visible = True

            Me.DivEmployee.Attributes.Remove("ontouchstart")
            Me.DivEmployee.Attributes.Add("ontouchstart", "this.classList.toggle('hover');")
            Me.DivEmployee.Attributes.Remove("class")
            Me.DivEmployee.Attributes.Add("class", "flip-container")

            Me.DivFlipper.Attributes.Remove("class")
            Me.DivFlipper.Attributes.Add("class", "flipper")

            Me.DivFront.Attributes.Remove("class")
            Me.DivFront.Attributes.Add("class", "front")

            If TaskCount > 0 Then

                Me.LabelTaskCount.Text = "Assignments: " & TaskCount.ToString()

            End If

            If TotalHours > 0 OrElse ActualHours > 0 Then

                Me.LabelTotalHours.Text = "Hours Allowed: " & String.Format("{0:n2}", TotalHours)
                Me.LabelActualHours.Text = "Hours Posted: " & String.Format("{0:n2}", ActualHours)

            End If

            If TotalHours > 0 Then

                Dim ProgressIndicator As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()

                ProgressIndicator.Value = (ActualHours / TotalHours) * 100

                If ActualHours > TotalHours Then

                    ProgressIndicator.Color = ProgressIndicator.Red
                    ProgressIndicator.Value = ProgressIndicator.Max

                Else

                    ProgressIndicator.Color = ProgressIndicator.Green

                End If

                ProgressIndicator.Max = 100
                ProgressIndicator.Width = 125
                ProgressIndicator.MarginTop = 0
                ProgressIndicator.ToolTip = ProgressIndicator.Value & "%"

                Me.LabelHoursGraph.Text = ProgressIndicator.DrawHTML()

            End If

        End If

        Me.LoadDataFromEmployeeCode()

    End Sub
    Private Sub DisableCardFlipAndBackOfCard()

        Me.DivEmployee.Attributes.Remove("ontouchstart")
        Me.DivEmployee.Attributes.Remove("class")
        Me.DivFlipper.Attributes.Remove("class")
        Me.DivFront.Attributes.Remove("class")

        Me.DivBack.Attributes.Remove("class")
        Me.DivBack.Attributes.Remove("style")
        Me.DivBack.Attributes.Add("style", "display: none !important;")
        Me.DivBack.Visible = False

    End Sub

#End Region

End Class

