Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Telerik.Web.UI

Partial Public Class BillingApproval
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _GoToPage As String = ""
    Private _AccessOK As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        Session("BA_EMP_CODE") = Nothing

        If Me.TxtEmployeeCode.Text = "" Then

            Me.ShowMessage("Please enter an employee code.")
            Me.FocusControl(Me.TxtEmployeeCode)
            Exit Sub

        End If
        If Me.TxtPassword.Text = "" Then

            Me.ShowMessage("Please enter a password.")
            Me.FocusControl(Me.TxtPassword)
            Exit Sub

        End If

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If myVal.ValidateEmpCode(Me.TxtEmployeeCode.Text) = False Then

            Me.ShowMessage("Invalid Employee Code.")
            Me.FocusControl(Me.TxtEmployeeCode)
            Exit Sub

        End If

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        _AccessOK = b.AllowAccess(Me.TxtEmployeeCode.Text, Me.TxtPassword.Text, Session("UserCode"))

        If _AccessOK = False Then

            'maintain a session count for login attempts?
            Me.ShowMessage("Invalid Password entered.")
            Me.FocusControl(Me.TxtPassword)
            Exit Sub

        Else

            Dim AppVars As New cAppVars(cAppVars.Application.BILLING_APPROVAL)
            AppVars.getAllAppVars()

            AppVars.setAppVar("CHK_LAST_EMP", Me.CheckBoxRemember.Checked.ToString().ToLower())
            If Me.CheckBoxRemember.Checked = True Then

                AppVars.setAppVar("LAST_EMP", Me.TxtEmployeeCode.Text.Trim())

            Else

                AppVars.setAppVar("LAST_EMP", "")

            End If

            AppVars.SaveAllAppVars()

            'This is for billing approval! (not batch)
            Session("BA_EMP_CODE") = AdvantageFramework.Security.Encryption.ASCIIEncoding(Me.TxtEmployeeCode.Text.Trim())
            _GoToPage = "BillingApproval_View_Approvals.aspx"
            'Me.RedirectParentPage(GoToPage)
            Me.CloseThisWindowAndOpenNewWindow(_GoToPage)

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init
        Me.AllowFloat = False

        Me.HlEmployee.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtEmployeeCode.ClientID & "&type=empcode');return false;")
        Me.TxtPassword.Attributes.Add("onkeypress", "capLock(event);")
        Me.TxtPassword.Attributes.Add("onfocus", "capLock(event);")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApproval)

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Dim AppVars As New cAppVars(cAppVars.Application.BILLING_APPROVAL)
            AppVars.getAllAppVars()

            If AppVars.HasAppVar("CHK_LAST_EMP") = True Then

                Me.CheckBoxRemember.Checked = AppVars.getAppVar("CHK_LAST_EMP").ToLower = "true"

            End If

            If Me.CheckBoxRemember.Checked = True Then

                If AppVars.HasAppVar("LAST_EMP") = True Then

                    Me.TxtEmployeeCode.Text = AppVars.getAppVar("LAST_EMP")
                    Me.TxtPassword.Text = ""
                    Me.FocusControl(Me.TxtPassword)

                End If

            Else

                Me.FocusControl(Me.TxtEmployeeCode)

            End If

            Session("BA_EMP_CODE") = Nothing

        End If

    End Sub

#End Region

#End Region

End Class