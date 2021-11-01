Imports System.Data.SqlClient
Public Class securityreportsbygroup
    Inherits Webvantage.BaseChildPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddGroups As Telerik.Web.UI.RadComboBox
    Protected WithEvents listAllow As Telerik.Web.UI.RadListBox
    Protected WithEvents butToNotAllowed As System.Web.UI.WebControls.Button
    Protected WithEvents butToAllow As System.Web.UI.WebControls.Button
    Protected WithEvents listNotAllowed As Telerik.Web.UI.RadListBox
    Protected WithEvents butSave As System.Web.UI.WebControls.Button
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
        Me.PageTitle = "Group Report Security"
        If Session("admin") = False Then
            MiscFN.ResponseRedirect("error.aspx")
        End If
        If Page.IsPostBack Then

        Else
            'Me.CheckAppAccess("Report Security")
            InitialLoad()
            If Me.ddGroups.SelectedValue.Length > 0 Then
                LoadData(CInt(Me.ddGroups.SelectedValue.ToString()))
            End If
        End If
    End Sub
    Private Sub InitialLoad()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        Me.ddGroups.DataSource = oDD.GetGroups
        Me.ddGroups.DataTextField = "description"
        Me.ddGroups.DataValueField = "code"
        Me.ddGroups.DataBind()

    End Sub
    Private Sub LoadData(ByVal GroupID As Integer)
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim drA As SqlDataReader
        Dim drN As SqlDataReader

        'drN = oSec.GetReportsByGroupForSecurity(GroupID, False)

        Me.listNotAllowed.DataSource = drN
        Me.listNotAllowed.DataValueField() = "Code"
        Me.listNotAllowed.DataTextField() = "Description"
        Me.listNotAllowed.DataBind()

        'drA = oSec.GetReportsByGroupForSecurity(GroupID, True)
        Me.listAllow.DataSource = drA
        Me.listAllow.DataValueField() = "Code"
        Me.listAllow.DataTextField() = "Description"
        Me.listAllow.DataBind()

    End Sub
    Private Sub butToNotAllowed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butToNotAllowed.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listAllow.Items.Count - 1 To 0 Step -1
            If Me.listAllow.Items(I).Selected Then
                ThisItem = Me.listAllow.Items(I)
                Me.listAllow.Items.Remove(ThisItem)
                Me.listNotAllowed.Items.Add(ThisItem)
            End If
        Next I
        SortNotAllowListBox()
    End Sub
    Private Sub butToAllow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butToAllow.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listNotAllowed.Items.Count - 1 To 0 Step -1
            If Me.listNotAllowed.Items(I).Selected Then
                ThisItem = Me.listNotAllowed.Items(I)
                Me.listNotAllowed.Items.Remove(ThisItem)
                Me.listAllow.Items.Add(ThisItem)
            End If
        Next I
        SortAllowListBox()
    End Sub
    Private Sub SortNotAllowListBox()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim sl As New System.Collections.SortedList
        Dim de As DictionaryEntry

        For I = Me.listNotAllowed.Items.Count - 1 To 0 Step -1
            sl.Add(Me.listNotAllowed.Items(I).Text, Me.listNotAllowed.Items(I).Value)
            Me.listNotAllowed.Items.Remove(Me.listNotAllowed.Items(I))
        Next I

        For Each de In sl
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            ThisItem.Value = de.Value
            ThisItem.Text = de.Key
            Me.listNotAllowed.Items.Add(ThisItem)
        Next

    End Sub
    Private Sub SortAllowListBox()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim sl As New System.Collections.SortedList
        Dim de As DictionaryEntry

        For I = Me.listAllow.Items.Count - 1 To 0 Step -1
            sl.Add(Me.listAllow.Items(I).Text, Me.listAllow.Items(I).Value)
            Me.listAllow.Items.Remove(Me.listAllow.Items(I))
        Next I

        For Each de In sl
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            ThisItem.Value = de.Value
            ThisItem.Text = de.Key
            Me.listAllow.Items.Add(ThisItem)
        Next

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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub imgbtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAdd.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listAllow.Items.Count - 1 To 0 Step -1
            If Me.listAllow.Items(I).Selected Then
                ThisItem = Me.listAllow.Items(I)
                Me.listAllow.Items.Remove(ThisItem)
                Me.listNotAllowed.Items.Add(ThisItem)
            End If
        Next I
        SortNotAllowListBox()
        saveMe()
    End Sub

    Private Sub imgbtnRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnRemove.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listNotAllowed.Items.Count - 1 To 0 Step -1
            If Me.listNotAllowed.Items(I).Selected Then
                ThisItem = Me.listNotAllowed.Items(I)
                Me.listNotAllowed.Items.Remove(ThisItem)
                Me.listAllow.Items.Add(ThisItem)
            End If
        Next I
        SortAllowListBox()
        saveMe()
    End Sub
End Class
