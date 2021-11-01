Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Public Class Security_Group
    Inherits Webvantage.BaseChildPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddGroups As Telerik.Web.UI.RadComboBox
    Protected WithEvents butSave As System.Web.UI.WebControls.Button
    Protected WithEvents listMember As Telerik.Web.UI.RadListBox
    Protected WithEvents listUsers As Telerik.Web.UI.RadListBox
    'Protected WithEvents butToMember As System.Web.UI.WebControls.Button
    'Protected WithEvents butToUser As System.Web.UI.WebControls.Button
    Protected WithEvents butNewGroup As System.Web.UI.WebControls.Button
    Protected WithEvents txtGroup As System.Web.UI.WebControls.TextBox
    Protected WithEvents butSaveGroup As System.Web.UI.WebControls.Button
    Protected WithEvents lblUsers As System.Web.UI.WebControls.Label
    Protected WithEvents lblMembers As System.Web.UI.WebControls.Label
    Protected WithEvents butDeleteGroup As System.Web.UI.WebControls.Button
    Protected WithEvents imgbtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnRemove As System.Web.UI.WebControls.ImageButton
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PageTitle = "User Group Security"
        If Session("admin") = False Then
            MiscFN.ResponseRedirect("error.aspx")
            Exit Sub
        End If
        If Not Page.IsPostBack Then
            'Me.CheckAppAccess("Group Security")
            LoadGroupDD()
            If Me.ddGroups.SelectedValue.Length > 0 Then
                LoadData(CInt(Me.ddGroups.SelectedValue.ToString()))
            End If
        End If
    End Sub
    Private Sub LoadGroupDD()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Dim ar As Array

        Me.ddGroups.DataSource = oDD.GetGroups
        Me.ddGroups.DataTextField = "description"
        Me.ddGroups.DataValueField = "code"
        Me.ddGroups.DataBind()

    End Sub
    Private Sub LoadData(ByVal GroupID As Integer)
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim drA As SqlDataReader
        Dim drN As SqlDataReader

        'drN = oSec.GetUserGroupSecurity(GroupID, True)

        Me.listMember.DataSource = drN
        Me.listMember.DataValueField() = "Code"
        Me.listMember.DataTextField() = "Description"
        Me.listMember.DataBind()

        'drA = oSec.GetUserGroupSecurity(GroupID, False)
        Me.listUsers.DataSource = drA
        Me.listUsers.DataValueField() = "Code"
        Me.listUsers.DataTextField() = "Description"
        Me.listUsers.DataBind()

    End Sub
    Private Sub SortMembers()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim arString() As String
        Dim ICount As Integer
        Dim Delimiter As Char = ":"

        ICount = Me.listMember.Items.Count - 1
        ReDim arString(ICount)
        For I = ICount To 0 Step -1
            arString(I) = Me.listMember.Items(I).Text & Delimiter & Me.listMember.Items(I).Value
            Me.listMember.Items.Remove(Me.listMember.Items(I))
        Next I

        arString.Sort(arString)

        For I = 0 To ICount
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            Dim ThisArray As String() = Nothing
            ThisArray = arString(I).Split(Delimiter)
            ThisItem.Text = ThisArray(0).ToString
            ThisItem.Value = ThisArray(1).ToString
            Me.listMember.Items.Add(ThisItem)
        Next I

    End Sub
    Private Sub SortUsers()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim arString() As String
        Dim ICount As Integer
        Dim Delimiter As Char = ":"

        ICount = Me.listUsers.Items.Count - 1
        ReDim arString(ICount)
        For I = ICount To 0 Step -1
            arString(I) = Me.listUsers.Items(I).Text & Delimiter & Me.listUsers.Items(I).Value
            Me.listUsers.Items.Remove(Me.listUsers.Items(I))
        Next I

        arString.Sort(arString)

        For I = 0 To ICount
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            Dim ThisArray As String() = Nothing
            ThisArray = arString(I).Split(Delimiter)
            ThisItem.Text = ThisArray(0).ToString
            ThisItem.Value = ThisArray(1).ToString
            Me.listUsers.Items.Add(ThisItem)
        Next I


    End Sub
    Private Sub ddGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddGroups.SelectedIndexChanged
        LoadData(CInt(Me.ddGroups.SelectedValue.ToString()))
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
            Dim ThisItem As Telerik.Web.UI.RadListBoxItem

        Catch ex As Exception
        End Try
    End Sub

    Private Sub saveMe()
        Try
            Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
            Dim ThisItem As Telerik.Web.UI.RadListBoxItem

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub butToMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butToMember.Click
    '    Dim ThisItem As Telerik.Web.UI.RadListBoxItem
    '    Dim I As Integer

    '    For I = Me.listUsers.Items.Count - 1 To 0 Step -1
    '        If Me.listUsers.Items(I).Selected Then
    '            ThisItem = Me.listUsers.Items(I)
    '            Me.listUsers.Items.Remove(ThisItem)
    '            Me.listMember.Items.Add(ThisItem)
    '        End If
    '    Next I

    '    SortMembers()
    'End Sub

    'Private Sub butToUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butToUser.Click
    '    Dim ThisItem As Telerik.Web.UI.RadListBoxItem
    '    Dim I As Integer

    '    For I = Me.listMember.Items.Count - 1 To 0 Step -1
    '        If Me.listMember.Items(I).Selected Then
    '            ThisItem = Me.listMember.Items(I)
    '            Me.listMember.Items.Remove(ThisItem)
    '            Me.listUsers.Items.Add(ThisItem)
    '        End If
    '    Next I
    '    SortUsers()
    'End Sub

    Private Sub butNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNewGroup.Click
        Me.butNewGroup.Visible = False
        Me.ddGroups.Visible = False
        Me.imgbtnRemove.Visible = False
        Me.imgbtnAdd.Visible = False
        Me.listMember.Visible = False
        Me.listUsers.Visible = False
        Me.butSave.Visible = False
        Me.butDeleteGroup.Visible = False
        Me.lblMembers.Visible = False
        Me.lblUsers.Visible = False
        Me.txtGroup.Visible = True
        Me.butSaveGroup.Visible = True
    End Sub

    Private Sub butSaveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveGroup.Click
        Try
            Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))

            If Me.txtGroup.Text.Length > 0 Then
                'oSec.InsertNewGroup(Me.txtGroup.Text.Trim)
                Me.txtGroup.Text = ""
                LoadGroupDD()
                LoadData(CInt(Me.ddGroups.SelectedValue.ToString()))

                Me.butNewGroup.Visible = True
                Me.ddGroups.Visible = True
                Me.imgbtnRemove.Visible = True
                Me.imgbtnAdd.Visible = True
                Me.listMember.Visible = True
                Me.listUsers.Visible = True
                'Me.butSave.Visible = True
                Me.butDeleteGroup.Visible = True
                Me.lblMembers.Visible = True
                Me.lblUsers.Visible = True
                Me.txtGroup.Visible = False
                Me.butSaveGroup.Visible = False

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub butDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteGroup.Click
        Try
            If Me.ddGroups.SelectedValue.Length > 0 Then
                Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
                'oSec.DeleteGroup(CInt(Me.ddGroups.SelectedValue))
                LoadGroupDD()
                If Me.ddGroups.SelectedValue.Length > 0 Then
                    LoadData(CInt(Me.ddGroups.SelectedValue.ToString()))
                Else
                    Me.listMember.Items.Clear()
                    Me.listUsers.Items.Clear()
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub imgbtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAdd.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listUsers.Items.Count - 1 To 0 Step -1
            If Me.listUsers.Items(I).Selected Then
                ThisItem = Me.listUsers.Items(I)
                Me.listUsers.Items.Remove(ThisItem)
                Me.listMember.Items.Add(ThisItem)
            End If
        Next I

        SortMembers()
        saveMe()

    End Sub

    Private Sub imgbtnRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnRemove.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listMember.Items.Count - 1 To 0 Step -1
            If Me.listMember.Items(I).Selected Then
                ThisItem = Me.listMember.Items(I)
                Me.listMember.Items.Remove(ThisItem)
                Me.listUsers.Items.Add(ThisItem)
            End If
        Next I
        SortUsers()
        saveMe()
    End Sub
End Class
