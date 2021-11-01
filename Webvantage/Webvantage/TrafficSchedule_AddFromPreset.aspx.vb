Public Partial Class TrafficSchedule_AddFromPreset
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Request.QueryString("JobNum")) = True Then
                JobNum = CType(Request.QueryString("JobNum"), Integer)
            Else
                JobNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) = True Then
                JobCompNum = CType(Request.QueryString("JobComp"), Integer)
            Else
                JobCompNum = 0
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try
        If Not Me.IsPostBack Then
            
            BindDropPresets()
        End If
    End Sub

    Private Sub BindDropPresets()
        Dim d As cDropDowns = New cDropDowns(Session("ConnString"))
        With Me.DropPreset
            .DataSource = d.GetTrafficPresets()
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
        End With
    End Sub

    Private Sub BtnAddPresets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddPresets.Click
        If Me.DropPreset.SelectedIndex > 0 And JobNum > 0 And JobCompNum > 0 Then
            Try
                Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
                s.AddPresetToSchedule(JobNum, JobCompNum, Me.DropPreset.SelectedValue)
                CloseAndRefresh()
            Catch ex As Exception
                Me.LblMSG.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String = "RefreshGrid"
        Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

End Class