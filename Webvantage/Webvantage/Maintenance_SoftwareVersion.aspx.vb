Imports Telerik.Web.UI
Imports System.Data.SqlClient

Public Class Maintenance_SoftwareVersion
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
    Private tab As Integer = 0
    Private CurrentVersionId As Integer = 0
    Private CurrentSoftwareProductId As Integer = 0


    Private Sub Maintenance_SoftwareVersion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_SoftwareVersion)
            Me.BindDropDownListVersions()
            Try
                If Not Request.QueryString("t") Is Nothing Then
                    tab = CType(Request.QueryString("t"), Integer)
                End If
            Catch ex As Exception
                Me.tab = 0
            End Try

            Try
                If Request.QueryString("sftwv") IsNot Nothing Then
                    CurrentVersionId = Request.QueryString("sftwv")
                End If
            Catch ex As Exception
                CurrentVersionId = 0
            End Try

            Me.RadTabStrip1.SelectedIndex = tab
            Me.RadMultiPage1.SelectedIndex = tab

            Select Case Me.tab
                Case 0 'Versions
                    Me.RadGridVersions.Rebind()
                Case 1 'Version Detail
                    Me.LoadVersionDetailTab()
                Case 2
                    Me.FieldsetSoftwareProductVersions.Visible = False
            End Select

        End If
    End Sub

    Private Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick

        Me.ImageButtonExport.Visible = Me.RadTabStrip1.SelectedIndex = 0
        Me.CheckBoxShowInactive.Visible = Me.RadTabStrip1.SelectedIndex = 0

        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0 'Versions
                Me.RadGridVersions.Rebind()
            Case 1 'Version Detail
                Me.CurrentVersionId = 0
                Me.LoadVersionDetailTab()
            Case 2
                Me.FieldsetSoftwareProductVersions.Visible = False
                Me.CurrentSoftwareProductId = 0
                Me.RadGridSoftwareProduct.Rebind()
        End Select
    End Sub

    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is Me.RadGridVersions AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then
            GridDataItem = RadGridVersions.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
            If GridDataItem IsNot Nothing Then
                Response.Redirect([String].Format("Maintenance_SoftwareVersion.aspx?t={0}&sftwv={1}", 1, GridDataItem.GetDataKeyValue("VERSION_ID")))
            End If
        End If

    End Sub

#Region " Versions Tab "

    Private Sub RadGridVersions_CancelCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVersions.CancelCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            CType(EditItem.FindControl("TxtVERSION"), TextBox).Text = ""
            CType(EditItem.FindControl("TxtVERSION_DESC"), TextBox).Text = ""
            CType(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = True
        End If
    End Sub

    Private Sub RadGridVersions_InsertCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVersions.InsertCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            Dim Version As String = ""
            Dim VersionDescription As String = ""
            Dim IsInactive As Boolean = True
            Version = DirectCast(EditItem.FindControl("TxtVERSION"), TextBox).Text.Trim()
            VersionDescription = DirectCast(EditItem.FindControl("TxtVERSION_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked
            If Version = "" Then
                Me.ShowMessage("Please enter a Version")
                Exit Sub
            End If
            If Me.VersionExists(Version, 0) Then
                Me.ShowMessage("Please enter a unique Version name")
                Exit Sub
            End If

            Dim arP(3) As SqlParameter
            Dim pVERSION As New SqlParameter("@VERSION", SqlDbType.VarChar, 10)
            pVERSION.Value = Version
            arP(0) = pVERSION

            Dim pVERSION_DESC As New SqlParameter("@VERSION_DESC", SqlDbType.VarChar, 100)
            If VersionDescription.Trim() = "" Then
                pVERSION_DESC.Value = System.DBNull.Value
            Else
                pVERSION_DESC.Value = VersionDescription.Trim()
            End If
            arP(1) = pVERSION_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(2) = pACTIVE_FLAG

            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("  INSERT INTO SOFTWARE_VERSION WITH(ROWLOCK) ")
                .Append("  ( ")
                .Append("  	[VERSION], ")
                .Append("  	VERSION_DESC, ")
                .Append("  	ACTIVE_FLAG ")
                .Append("  ) ")
                .Append("  VALUES ")
                .Append("  ( ")
                .Append("  	@VERSION, ")
                .Append("  	@VERSION_DESC, ")
                .Append("  	@ACTIVE_FLAG ")
                .Append("  );")
            End With

            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

            'Me.RadGridVersions.Rebind()
            MiscFN.ResponseRedirect("Maintenance_SoftwareVersion.aspx?t=0")

        End If
    End Sub

    Private Sub RadGridVersions_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVersions.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim ThisVersionId As Integer = 0
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        If index > -1 Then
            CurrentGridRow = DirectCast(RadGridVersions.Items(index), Telerik.Web.UI.GridDataItem)
        End If
        Select Case e.CommandName
            Case "SaveAll"
                For Each gdi As GridDataItem In Me.RadGridVersions.MasterTableView.Items
                    Me.UpdateVersionRow(gdi)
                Next
                Me.RadGridVersions.Rebind()
                Me.BindDropDownListVersions()
            Case "SaveNewRow"
                e.Item.FireCommandEvent("PerformInsert", e)
            Case "SaveRow"
                If Not CurrentGridRow Is Nothing Then
                    Try
                        ThisVersionId = CType(CurrentGridRow.GetDataKeyValue("VERSION_ID"), Integer)
                    Catch ex As Exception
                        ThisVersionId = 0
                    End Try
                    Try
                        If ThisVersionId = 0 And IsNumeric(e.CommandArgument) = True Then
                            ThisVersionId = CType(e.CommandArgument, Integer)
                        End If
                    Catch ex As Exception
                        ThisVersionId = 0
                    End Try
                    Me.UpdateVersionRow(CurrentGridRow)
                    Me.RadGridVersions.Rebind()
                    Me.BindDropDownListVersions()
                End If
            Case "DeleteRow"
                If Not CurrentGridRow Is Nothing Then
                    Try
                        ThisVersionId = CType(CurrentGridRow.GetDataKeyValue("VERSION_ID"), Integer)
                    Catch ex As Exception
                        ThisVersionId = 0
                    End Try
                    Try
                        If ThisVersionId = 0 And IsNumeric(e.CommandArgument) = True Then
                            ThisVersionId = CType(e.CommandArgument, Integer)
                        End If
                    Catch ex As Exception
                        ThisVersionId = 0
                    End Try
                    If ThisVersionId > 0 Then
                        Dim SQL As New System.Text.StringBuilder
                        With SQL
                            .Append("UPDATE ALERT WITH(ROWLOCK) SET VER = NULL, BUILD = NULL WHERE VER = @VERSION_ID;")
                            .Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE VERSION_ID = @VERSION_ID;")
                            .Append("DELETE FROM SOFTWARE_BUILD WITH(ROWLOCK) WHERE VERSION_ID = @VERSION_ID;")
                            .Append("DELETE FROM SOFTWARE_VERSION WITH(ROWLOCK) WHERE VERSION_ID = @VERSION_ID;")
                        End With
                        Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
                        pVERSION_ID.Value = ThisVersionId
                        Try
                            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), pVERSION_ID)
                        Catch ex As Exception
                            Me.ShowMessage(ex.Message.ToString())
                            Exit Sub
                        End Try
                        Me.RadGridVersions.Rebind()
                        Me.BindDropDownListVersions()
                    End If
                End If
            Case "CancelNewRow"
                e.Item.FireCommandEvent("Cancel", e)
        End Select
    End Sub

    Private Sub RadGridVersions_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVersions.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then
            Try
                DirectCast(e.Item.FindControl("TxtVERSION"), TextBox).Focus()
            Catch ex As Exception
            End Try

        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            If e.Item.IsInEditMode = False Then
                Try
                    Dim index As Integer = e.Item.ItemIndex
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
                    Dim attr As String = "RadGridVersions_RowDoubleClick(" & e.Item.ItemIndexHierarchical & ");"
                    If index > -1 Then
                        CurrentGridRow = DirectCast(RadGridVersions.Items(index), Telerik.Web.UI.GridDataItem)
                    End If
                    CurrentGridRow.Attributes.Add("ondblclick", attr)
                    Try
                        CType(CurrentGridRow.FindControl("TxtVERSION"), TextBox).Attributes.Add("ondblclick", attr)
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("TxtVERSION_DESC"), TextBox).Attributes.Add("ondblclick", attr)
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                End Try
            End If

            Try
                If CType(e.Item.DataItem("ACTIVE_FLAG"), Boolean) = False Then
                    Dim chk As CheckBox = DirectCast(e.Item.FindControl("ChkACTIVE_FLAG"), CheckBox)
                    chk.Checked = True
                End If
            Catch ex As Exception
            End Try

            Try
                Dim ib As System.Web.UI.WebControls.ImageButton = DirectCast(e.Item.FindControl("ImgBtnDelete"), ImageButton)
                With ib
                    .Enabled = True
                    If CType(e.Item.DataItem("ASSOCIATED_LEVEL_COUNT"), Integer) > 0 Or CType(e.Item.DataItem("ASSOCIATED_ALERT_COUNT"), Integer) > 0 Then

                        Dim DeleteDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDelete")
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

                    Else
                        .Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                        .ToolTip = "Click to delete this row"
                    End If
                End With
            Catch ex As Exception
            End Try

        End If

    End Sub

    Private Sub RadGridVersions_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVersions.NeedDataSource
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT VERSION_ID,")
            .Append("         VERSION,")
            .Append("        VERSION_DESC,")
            .Append("        ACTIVE_FLAG,")
            .Append("        (")
            .Append("            SELECT COUNT(1)")
            .Append("           FROM   SOFTWARE_LEVEL WITH (NOLOCK)")
            .Append("           WHERE  (VERSION_ID = SV.VERSION_ID)")
            .Append("        ) AS ASSOCIATED_LEVEL_COUNT,")
            .Append("        (")
            .Append("            SELECT COUNT(1)")
            .Append("            FROM   ALERT WITH (NOLOCK)")
            .Append("            WHERE  (VER = CAST(SV.VERSION_ID AS VARCHAR))")
            .Append("        ) AS ASSOCIATED_ALERT_COUNT")
            .Append(" FROM   SOFTWARE_VERSION AS SV WITH (NOLOCK)")
            If Me.CheckBoxShowInactive.Checked = False Then

                .Append(" WHERE  (ACTIVE_FLAG IS NULL)")
                .Append("        OR  (ACTIVE_FLAG = 1)")

            End If
            .Append(";")
        End With

        Me.RadGridVersions.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL.ToString(), "DtVersions")
        Me.RadGridVersions.MasterTableView.IsItemInserted = True

        Me.RadGridVersions.PageSize = MiscFN.LoadPageSize(Me.RadGridVersions.ID)

    End Sub

    Private Function UpdateVersionRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        Try
            Dim i As Integer
            i = TheGridRow.RowIndex
        Catch ex As Exception
        End Try
        Dim SoftwareVersionId As Integer = 0
        Dim StrSQL As String = ""
        Try
            SoftwareVersionId = TheGridRow.GetDataKeyValue("VERSION_ID")
        Catch ex As Exception
            SoftwareVersionId = 0
        End Try
        If SoftwareVersionId > 0 Then 'we are updating a rec
            Dim Version As String = ""
            Dim VersionDescription As String = ""
            Dim IsInactive As Boolean = True

            Version = DirectCast(TheGridRow.FindControl("TxtVERSION"), TextBox).Text.Trim()
            If Version = "" Then
                Me.ShowMessage("Please enter a Version")
                Exit Function
            End If
            If Me.VersionExists(Version, SoftwareVersionId) Then
                Me.ShowMessage("Please enter a unique Version name")
                Exit Function
            End If
            VersionDescription = DirectCast(TheGridRow.FindControl("TxtVERSION_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(TheGridRow.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            Dim arP(4) As SqlParameter

            Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
            pVERSION_ID.Value = SoftwareVersionId
            arP(0) = pVERSION_ID

            Dim pVERSION As New SqlParameter("@VERSION", SqlDbType.VarChar, 10)
            pVERSION.Value = Version
            arP(1) = pVERSION

            Dim pVERSION_DESC As New SqlParameter("@VERSION_DESC", SqlDbType.VarChar, 100)
            If VersionDescription.Trim() = "" Then
                pVERSION_DESC.Value = System.DBNull.Value
            Else
                pVERSION_DESC.Value = VersionDescription
            End If
            arP(2) = pVERSION_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(3) = pACTIVE_FLAG

            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append(" UPDATE SOFTWARE_VERSION WITH(ROWLOCK) ")
                .Append(" SET ")
                .Append(" 	[VERSION] = @VERSION, ")
                .Append(" 	VERSION_DESC = @VERSION_DESC, ")
                .Append(" 	ACTIVE_FLAG = @ACTIVE_FLAG ")
                .Append(" WHERE VERSION_ID = @VERSION_ID; ")
            End With

            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

        End If
    End Function

    Private Function VersionExists(ByVal Version As String, ByVal VersionId As Integer) As Boolean
        Dim pVERSION As New SqlParameter("@VERSION", SqlDbType.VarChar, 10)
        pVERSION.Value = Version

        Dim SQL As New System.Text.StringBuilder
        If VersionId = 0 Then
            SQL.Append("SELECT COUNT(1) FROM SOFTWARE_VERSION WHERE [VERSION] = @VERSION;")
        Else
            SQL.Append("SELECT COUNT(1) FROM SOFTWARE_VERSION WHERE [VERSION] = @VERSION AND VERSION_ID <> " & VersionId.ToString() & " ;")
        End If

        If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, SQL.ToString(), pVERSION), Integer) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

#Region " Version Detail Tab "

    Private Sub LoadVersionDetailTab()
        Me.BindDropDownListVersions()
        MiscFN.RadComboBoxSetIndex(Me.DropDownListVersions, Me.CurrentVersionId, False)
        Me.RadGridBuilds.Rebind()
        Me.LoadSoftwareLevel(True)
        Me.RadGridSoftwareLevel.Rebind()
    End Sub

    Private Sub BindDropDownListVersions()
        With Me.DropDownListVersions
            .Items.Clear()
            .DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, "SELECT VERSION_ID, [VERSION] + ISNULL(' - '+VERSION_DESC,'') AS VERSION_DISPLAY FROM SOFTWARE_VERSION WITH(NOLOCK);", "DtVersions")
            .DataValueField = "VERSION_ID"
            .DataTextField = "VERSION_DISPLAY"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
        End With

    End Sub

    Private Function UpdateBuildRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try
        If Me.CurrentVersionId = 0 Then
            Me.ShowMessage("Invalid Version")
            Exit Function
        End If
        Try
            Dim i As Integer
            i = TheGridRow.RowIndex
        Catch ex As Exception
        End Try
        Dim BuildId As Integer = 0
        Dim StrSQL As String = ""
        Try
            BuildId = TheGridRow.GetDataKeyValue("BUILD_ID")
        Catch ex As Exception
            BuildId = 0
        End Try

        If BuildId > 0 Then 'we are updating a rec
            Dim Build As String = ""
            Dim BuildDescription As String = ""
            Dim IsInactive As Boolean = True

            Build = DirectCast(TheGridRow.FindControl("TxtBUILD"), TextBox).Text.Trim()
            If Build = "" Then
                Me.ShowMessage("Please enter a Build")
                Exit Function
            End If
            'If Me.BuildNameExists(Me.CurrentVersionId, Build) Then
            '    Me.ShowMessage("Please enter a unique Version name")
            '    Exit Function
            'End If
            BuildDescription = DirectCast(TheGridRow.FindControl("TxtBUILD_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(TheGridRow.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            Dim arP(4) As SqlParameter

            Dim pBUILD_ID As New SqlParameter("@BUILD_ID", SqlDbType.Int)
            pBUILD_ID.Value = BuildId
            arP(0) = pBUILD_ID

            Dim pBUILD As New SqlParameter("@BUILD", SqlDbType.VarChar, 10)
            pBUILD.Value = Build
            arP(1) = pBUILD

            Dim pBUILD_DESC As New SqlParameter("@BUILD_DESC", SqlDbType.VarChar, 100)
            pBUILD_DESC.Value = BuildDescription
            arP(2) = pBUILD_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(3) = pACTIVE_FLAG

            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append(" UPDATE SOFTWARE_BUILD WITH(ROWLOCK) ")
                .Append(" SET ")
                .Append(" 	[BUILD] = @BUILD, ")
                .Append(" 	BUILD_DESC = @BUILD_DESC, ")
                .Append(" 	ACTIVE_FLAG = @ACTIVE_FLAG ")
                .Append(" WHERE BUILD_ID = @BUILD_ID; ")
            End With

            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

        End If
    End Function

    Private Function BuildNameExists(ByVal VersionId As Integer, ByVal Build As String) As Boolean
        Dim arP(2) As SqlParameter

        Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
        pVERSION_ID.Value = VersionId
        arP(0) = pVERSION_ID

        Dim pBUILD As New SqlParameter("@BUILD", SqlDbType.VarChar, 10)
        pBUILD.Value = Build
        arP(1) = pBUILD

        Dim SQL As New System.Text.StringBuilder
        SQL.Append("SELECT COUNT(1) FROM SOFTWARE_BUILD WITH(NOLOCK) WHERE VERSION_ID = @VERSION_ID AND BUILD = @BUILD;")

        If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, SQL.ToString(), arP), Integer) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Property SoftwareLevelCode() As String
        Get
            If Me.CheckBoxVersionAppliesToJobLevel.Checked = True And Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = False Then
                Return "j"
            ElseIf Me.CheckBoxVersionAppliesToJobLevel.Checked = False And Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = True Then
                Return "jc"
            Else
                Me.CheckBoxVersionAppliesToJobLevel.Checked = True
                Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = False
                Return "j"
            End If
        End Get
        Set(value As String)
            Me.CheckBoxVersionAppliesToJobLevel.Checked = False
            Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = False
            If value = "j" Then
                Me.CheckBoxVersionAppliesToJobLevel.Checked = True
                Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = False
            ElseIf value = "jc" Then
                Me.CheckBoxVersionAppliesToJobLevel.Checked = False
                Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = True
            End If
        End Set
    End Property

    Private Sub LoadSoftwareLevel(ByVal UseDBValue As Boolean)
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try
        If UseDBValue = True Then
            Dim JobCount As Integer = 0
            Dim JobComponentCount As Integer = 0
            Try
                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append(" SELECT COUNT(JOB_NUMBER) AS JOB_COUNT, ")
                    .Append("        COUNT(JOB_COMPONENT_NBR) AS COMPONENT_COUNT ")
                    .Append(" FROM   SOFTWARE_LEVEL WITH(NOLOCK) ")
                    .Append(" WHERE  VERSION_ID = ")
                    .Append(Me.CurrentVersionId.ToString())
                    .Append(";")
                End With
                Dim dt1 As New DataTable
                dt1 = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL.ToString(), "DtJobcAndJobCompCount")
                If dt1.Rows.Count > 0 Then
                    JobCount = CType(dt1.Rows(0)("JOB_COUNT"), Integer)
                    JobComponentCount = CType(dt1.Rows(0)("COMPONENT_COUNT"), Integer)
                End If
            Catch ex As Exception
                JobCount = 0
                JobComponentCount = 0
            End Try

            If JobComponentCount > 0 Then
                Me.SoftwareLevelCode = "jc"
            Else
                Me.SoftwareLevelCode = "j"
            End If

        End If

    End Sub

    Private Sub DropDownListVersions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListVersions.SelectedIndexChanged
        If Me.DropDownListVersions.SelectedIndex > 0 Then
            Me.CurrentVersionId = Me.DropDownListVersions.SelectedValue
        Else
            Me.CurrentVersionId = 0
        End If
        Me.RadGridBuilds.Rebind()
        Me.LoadSoftwareLevel(True)
        Me.RadGridSoftwareLevel.Rebind()
    End Sub

    Private Sub ButtonSaveSoftwareLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveSoftwareLevel.Click
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try

        If Me.CurrentVersionId = 0 Then Exit Sub

        Dim DoUpdate As Boolean = False

        'this will clear the version's relation to job/comps
        Try
            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE VERSION_ID = " & Me.CurrentVersionId.ToString() & ";")
        Catch ex As Exception
        End Try

        For Each gdi As GridDataItem In Me.RadGridSoftwareLevel.MasterTableView.Items
            Dim SQL As New System.Text.StringBuilder
            Dim chk As CheckBox
            Dim code As String = ""
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim OnThisVersion As Boolean = False
            Dim RunSQL As Boolean = False

            chk = CType(gdi("ColumnClientSelect").Controls(0), CheckBox)
            code = gdi.GetDataKeyValue("code").ToString()
            JobNumber = CType(gdi.GetDataKeyValue("JOB_NUMBER"), Integer)
            JobComponentNbr = CType(gdi.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
            If CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer) > 0 Then
                OnThisVersion = True
            End If

            'OnThisVersion = MiscFN.IntToBool(CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer))

            If Me.CurrentVersionId > 0 Then

                ''If OnThisVersion = False And chk.Checked = True Then 'need to add
                ''    If Me.SoftwareLevelCode = "j" Then
                ''        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0);") 'this will clear an relations to other versions the job/comp might have 
                ''        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,VERSION_ID) VALUES (@JOB_NUMBER,@VERSION_ID);")
                ''    ElseIf Me.SoftwareLevelCode = "jc" Then
                ''        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;") 'this will clear an relations to other versions the job/comp might have 
                ''        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,JOB_COMPONENT_NBR,VERSION_ID) VALUES (@JOB_NUMBER,@JOB_COMPONENT_NBR,@VERSION_ID);")
                ''    End If
                ''    RunSQL = True
                ''ElseIf OnThisVersion = True And chk.Checked = False Then 'need to remove
                ''    If Me.SoftwareLevelCode = "j" Then
                ''        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
                ''    ElseIf Me.SoftwareLevelCode = "jc" Then
                ''        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
                ''    End If
                ''    RunSQL = True
                ''ElseIf OnThisVersion = True And chk.Checked = True Then 'need to re-insert
                ''    If Me.SoftwareLevelCode = "j" Then
                ''        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,VERSION_ID) VALUES (@JOB_NUMBER,@VERSION_ID);")
                ''    ElseIf Me.SoftwareLevelCode = "jc" Then
                ''        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,JOB_COMPONENT_NBR,VERSION_ID) VALUES (@JOB_NUMBER,@JOB_COMPONENT_NBR,@VERSION_ID);")
                ''    End If
                ''    RunSQL = True
                ''End If

                If chk.Checked = True Then 'need to add
                    If Me.SoftwareLevelCode = "j" Then
                        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
                        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,VERSION_ID) VALUES (@JOB_NUMBER,@VERSION_ID);")
                    ElseIf Me.SoftwareLevelCode = "jc" Then
                        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
                        SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,JOB_COMPONENT_NBR,VERSION_ID) VALUES (@JOB_NUMBER,@JOB_COMPONENT_NBR,@VERSION_ID);")
                    End If
                    RunSQL = True
                ElseIf chk.Checked = False Then 'need to remove
                    If Me.SoftwareLevelCode = "j" Then
                        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
                    ElseIf Me.SoftwareLevelCode = "jc" Then
                        SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
                    End If
                    RunSQL = True
                End If

                If RunSQL = True Then
                    Try
                        Dim arP(3) As SqlParameter

                        Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
                        pVERSION_ID.Value = Me.CurrentVersionId
                        arP(0) = pVERSION_ID

                        Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJOB_NUMBER.Value = JobNumber
                        arP(1) = pJOB_NUMBER

                        Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
                        If JobComponentNbr = 0 Then
                            pJOB_COMPONENT_NBR.Value = System.DBNull.Value
                        Else
                            pJOB_COMPONENT_NBR.Value = JobComponentNbr
                        End If
                        arP(2) = pJOB_COMPONENT_NBR

                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

                    Catch ex As Exception
                        Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
                    End Try
                End If

            End If

        Next

        Me.RadGridSoftwareLevel.Rebind()

    End Sub

    Private Sub RadGridBuilds_CancelCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBuilds.CancelCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            CType(EditItem.FindControl("TxtBUILD"), TextBox).Text = ""
            CType(EditItem.FindControl("TxtBUILD_DESC"), TextBox).Text = ""
            CType(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = True
        End If
    End Sub

    Private Sub RadGridBuilds_InsertCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBuilds.InsertCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            Try
                If Me.CurrentVersionId = 0 Then
                    Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
                End If
            Catch ex As Exception
                Me.CurrentVersionId = 0
            End Try
            Dim Build As String = ""
            Dim BuildDescription As String = ""
            Dim IsInactive As Boolean = True
            Build = DirectCast(EditItem.FindControl("TxtBUILD"), TextBox).Text.Trim()
            BuildDescription = DirectCast(EditItem.FindControl("TxtBUILD_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked
            If Build = "" Then
                Me.ShowMessage("Please enter a Build")
                Exit Sub
            End If
            If Me.BuildNameExists(Me.CurrentVersionId, Build) Then
                Me.ShowMessage("Please enter a unique Build name for this Version")
                Exit Sub
            End If

            Dim arP(4) As SqlParameter

            Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
            pVERSION_ID.Value = Me.CurrentVersionId
            arP(0) = pVERSION_ID

            Dim pBUILD As New SqlParameter("@BUILD", SqlDbType.VarChar, 10)
            pBUILD.Value = Build
            arP(1) = pBUILD

            Dim pBUILD_DESC As New SqlParameter("@BUILD_DESC", SqlDbType.VarChar, 100)
            pBUILD_DESC.Value = BuildDescription
            arP(2) = pBUILD_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(3) = pACTIVE_FLAG

            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("  INSERT INTO SOFTWARE_BUILD WITH(ROWLOCK) ")
                .Append("  ( ")
                .Append("  	VERSION_ID, ")
                .Append("  	[BUILD], ")
                .Append("  	BUILD_DESC, ")
                .Append("  	ACTIVE_FLAG ")
                .Append("  ) ")
                .Append("  VALUES ")
                .Append("  ( ")
                .Append("  	@VERSION_ID, ")
                .Append("  	@BUILD, ")
                .Append("  	@BUILD_DESC, ")
                .Append("  	@ACTIVE_FLAG ")
                .Append("  );")
            End With

            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

        End If

    End Sub

    Private Sub RadGridBuilds_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBuilds.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try
        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        If index > -1 Then
            CurrentGridRow = DirectCast(RadGridBuilds.Items(index), Telerik.Web.UI.GridDataItem)
        End If
        Select Case e.CommandName
            Case "SaveAll"
                For Each gdi As GridDataItem In Me.RadGridBuilds.MasterTableView.Items
                    Me.UpdateBuildRow(gdi)
                Next
                Me.RadGridBuilds.Rebind()
            Case "SaveNewRow"
                e.Item.FireCommandEvent("PerformInsert", e)
            Case "SaveRow"
                If Not CurrentGridRow Is Nothing Then
                    Me.UpdateBuildRow(CurrentGridRow)
                    'Me.RadGridBuilds.Rebind()
                End If
            Case "DeleteRow"
                If Not CurrentGridRow Is Nothing Then
                    Dim ThisBuildId As Integer = 0
                    Try
                        ThisBuildId = CType(CurrentGridRow.GetDataKeyValue("BUILD_ID"), Integer)
                    Catch ex As Exception
                        ThisBuildId = 0
                    End Try
                    If ThisBuildId > 0 Then
                        Dim SQL As New System.Text.StringBuilder
                        With SQL
                            .Append("DELETE FROM SOFTWARE_BUILD WHERE BUILD_ID = @BUILD_ID;")
                        End With
                        Dim pBUILD_ID As New SqlParameter("@BUILD_ID", SqlDbType.Int)
                        pBUILD_ID.Value = ThisBuildId
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), pBUILD_ID)
                        Me.RadGridBuilds.Rebind()
                    End If
                End If
            Case "CancelNewRow"
                e.Item.FireCommandEvent("Cancel", e)
        End Select

    End Sub

    Private Sub RadGridBuilds_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridBuilds.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Try
                CType(e.Item.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = Not CType(e.Item.DataItem("ACTIVE_FLAG"), Boolean)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("ImgBtnDelete"), ImageButton).Attributes.Add("onclick", "return confirm('Are you sure you want to delete this row?')")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadGridBuilds_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBuilds.NeedDataSource
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try
        Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
        pVERSION_ID.Value = Me.CurrentVersionId
        Me.RadGridBuilds.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, "SELECT * FROM SOFTWARE_BUILD WITH(NOLOCK) WHERE VERSION_ID = @VERSION_ID;", "DtVersions", pVERSION_ID)
        Me.RadGridBuilds.MasterTableView.IsItemInserted = True
        Me.RadGridBuilds.PageSize = MiscFN.LoadPageSize(Me.RadGridBuilds.ID)
    End Sub

    Private Sub RadGridSoftwareLevel_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSoftwareLevel.ItemCommand
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try

        If Me.CurrentVersionId = 0 Then Exit Sub

        Select Case e.CommandName
            Case "Select", "RowClick"
                Try
                    Dim gdi As GridDataItem = CType(e.Item, GridDataItem)
                    If Not gdi Is Nothing Then
                        Dim SQL As New System.Text.StringBuilder
                        Dim chk As CheckBox
                        Dim code As String = ""
                        Dim JobNumber As Integer = 0
                        Dim JobComponentNbr As Integer = 0
                        Dim OnThisVersion As Boolean = False
                        Dim RunSQL As Boolean = False

                        chk = CType(gdi("ColumnClientSelect").Controls(0), CheckBox)
                        code = gdi.GetDataKeyValue("code").ToString()
                        JobNumber = CType(gdi.GetDataKeyValue("JOB_NUMBER"), Integer)
                        JobComponentNbr = CType(gdi.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                        If CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer) > 0 Then
                            OnThisVersion = True
                        End If

                        'OnThisVersion = MiscFN.IntToBool(CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer))

                        If Me.CurrentVersionId > 0 Then

                            If chk.Checked = True Then 'need to add
                                If Me.SoftwareLevelCode = "j" Then
                                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
                                    SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,VERSION_ID) VALUES (@JOB_NUMBER,@VERSION_ID);")
                                ElseIf Me.SoftwareLevelCode = "jc" Then
                                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
                                    SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,JOB_COMPONENT_NBR,VERSION_ID) VALUES (@JOB_NUMBER,@JOB_COMPONENT_NBR,@VERSION_ID);")
                                End If
                                RunSQL = True
                            ElseIf chk.Checked = False Then 'need to remove
                                If Me.SoftwareLevelCode = "j" Then
                                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
                                ElseIf Me.SoftwareLevelCode = "jc" Then
                                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
                                End If
                                RunSQL = True
                            End If

                            If RunSQL = True Then
                                Try
                                    Dim arP(3) As SqlParameter

                                    Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
                                    pVERSION_ID.Value = Me.CurrentVersionId
                                    arP(0) = pVERSION_ID

                                    Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                                    pJOB_NUMBER.Value = JobNumber
                                    arP(1) = pJOB_NUMBER

                                    Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
                                    If JobComponentNbr = 0 Then
                                        pJOB_COMPONENT_NBR.Value = System.DBNull.Value
                                    Else
                                        pJOB_COMPONENT_NBR.Value = JobComponentNbr
                                    End If
                                    arP(2) = pJOB_COMPONENT_NBR

                                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

                                Catch ex As Exception
                                    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
                                End Try
                            End If

                        End If

                    End If
                Catch ex As Exception
                    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
                End Try

        End Select
    End Sub

    Private Sub RadGridSoftwareLevel_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSoftwareLevel.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
            If IsNumeric(e.Item.DataItem("ACTIVE_ON_THIS_VERSION")) = True Then
                If CType(e.Item.DataItem("ACTIVE_ON_THIS_VERSION"), Integer) > 0 Then
                    e.Item.Selected = True
                    Dim chk As CheckBox
                    chk = CType(dataItem("ColumnClientSelect").Controls(0), CheckBox)
                End If
            End If
        End If
    End Sub

    Private Sub RadGridSoftwareLevel_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSoftwareLevel.NeedDataSource
        Try
            If Me.CurrentVersionId = 0 Then
                Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
            End If
        Catch ex As Exception
            Me.CurrentVersionId = 0
        End Try

        Dim dt As New DataTable()
        If Me.CurrentVersionId > 0 Then
            If Me.SoftwareLevelCode <> "" Then
                Dim arP(2) As SqlParameter
                Dim pUserId As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                pUserId.Value = Session("UserCode")
                arP(0) = pUserId
                Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
                pVERSION_ID.Value = Me.CurrentVersionId
                arP(1) = pVERSION_ID
                Select Case Me.SoftwareLevelCode
                    Case "j"
                        Me.RadGridSoftwareLevel.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsSoftwareVersion", "DtVersionJobs", arP)
                    Case "jc"
                        Me.RadGridSoftwareLevel.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsSoftwareVersion", "DtVersionJobs", arP)
                End Select
            End If
        End If

    End Sub

    Private Sub CheckBoxVersionAppliesToJobLevel_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxVersionAppliesToJobLevel.CheckedChanged
        If Me.CheckBoxVersionAppliesToJobLevel.Checked = True Then
            Me.SoftwareLevelCode = "j"
        Else
            Me.SoftwareLevelCode = "jc"
        End If
        Me.LoadSoftwareLevel(False)
        Me.RadGridSoftwareLevel.Rebind()
    End Sub

    Private Sub CheckBoxVersionAppliesToJobComponentLevel_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxVersionAppliesToJobComponentLevel.CheckedChanged
        If Me.CheckBoxVersionAppliesToJobComponentLevel.Checked = True Then
            Me.SoftwareLevelCode = "jc"
        Else
            Me.SoftwareLevelCode = "j"
        End If
        Me.LoadSoftwareLevel(False)
        Me.RadGridSoftwareLevel.Rebind()
    End Sub

#End Region

#Region " Software Product Tab "

    Private Sub RadGridSoftwareProduct_CancelCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSoftwareProduct.CancelCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            CType(EditItem.FindControl("TxtPRODUCT_DESC"), TextBox).Text = ""
            CType(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = True
        End If
    End Sub

    Private Sub RadGridSoftwareProduct_InsertCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSoftwareProduct.InsertCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            Dim ProductName As String = ""
            Dim IsInactive As Boolean = True

            ProductName = DirectCast(EditItem.FindControl("TxtPRODUCT_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            If ProductName = "" Then
                Me.ShowMessage("Please enter a Software Product name")
                Exit Sub
            End If

            Dim arP(2) As SqlParameter

            Dim pPRODUCT_DESC As New SqlParameter("@PRODUCT_DESC", SqlDbType.VarChar, 100)
            pPRODUCT_DESC.Value = ProductName
            arP(0) = pPRODUCT_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(1) = pACTIVE_FLAG

            If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT COUNT(1) FROM SOFTWARE_PRODUCT WITH(NOLOCK) WHERE PRODUCT_DESC = @PRODUCT_DESC", pPRODUCT_DESC), Integer) > 0 Then
                Me.ShowMessage("Please enter a unique Software Product name")
                Exit Sub
            Else
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "INSERT INTO SOFTWARE_PRODUCT (PRODUCT_DESC, ACTIVE_FLAG) VALUES (@PRODUCT_DESC, @ACTIVE_FLAG)", arP)
                Catch ex As Exception
                    Me.ShowMessage(ex.Message.ToString())
                End Try
            End If


        End If
    End Sub

    Private Sub RadGridSoftwareProduct_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSoftwareProduct.ItemCommand
        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        If index > -1 Then
            CurrentGridRow = DirectCast(RadGridSoftwareProduct.Items(index), Telerik.Web.UI.GridDataItem)
        End If
        Select Case e.CommandName
            Case "SaveAll"
                For Each gdi As GridDataItem In Me.RadGridSoftwareProduct.MasterTableView.Items
                    Me.UpdateSoftwareProductRow(gdi)
                Next
                Me.RadGridSoftwareProduct.Rebind()
            Case "SaveNewRow"
                e.Item.FireCommandEvent("PerformInsert", e)
            Case "SaveRow"
                If Not CurrentGridRow Is Nothing Then
                    Me.UpdateSoftwareProductRow(CurrentGridRow)
                    Me.RadGridSoftwareProduct.Rebind()
                End If
            Case "DeleteRow"
                If Not CurrentGridRow Is Nothing Then
                    Dim ThisProductId As Integer = 0
                    Try
                        ThisProductId = CType(CurrentGridRow.GetDataKeyValue("PRODUCT_ID"), Integer)
                    Catch ex As Exception
                        ThisProductId = 0
                    End Try
                    If ThisProductId > 0 Then
                        Try
                            Dim SQL As New System.Text.StringBuilder
                            With SQL
                                '.Append("UPDATE SOFTWARE_LEVEL WITH(ROWLOCK) SET PRODUCT_ID = NULL WHERE PRODUCT_ID = ")
                                '.Append(ThisProductId.ToString())
                                '.Append(";")
                                .Append("DELETE FROM SOFTWARE_PRODUCT_VERSION WITH(ROWLOCK) WHERE PRODUCT_ID = ")
                                .Append(ThisProductId.ToString())
                                .Append(";")
                                .Append("DELETE FROM SOFTWARE_PRODUCT WITH(ROWLOCK) WHERE PRODUCT_ID = ")
                                .Append(ThisProductId.ToString())
                                .Append(";")
                            End With
                            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
                            Me.RadGridSoftwareProduct.Rebind()
                        Catch ex As Exception
                            Me.ShowMessage(ex.Message.ToString())
                        End Try
                    End If
                End If
            Case "CancelNewRow"
                e.Item.FireCommandEvent("Cancel", e)
            Case "RowClick"
                If Not CurrentGridRow Is Nothing Then
                    Dim ThisProductId As Integer = 0
                    Try
                        ThisProductId = CType(CurrentGridRow.GetDataKeyValue("PRODUCT_ID"), Integer)
                    Catch ex As Exception
                        ThisProductId = 0
                    End Try
                    If ThisProductId > 0 Then
                        Me.FieldsetSoftwareProductVersions.Visible = True
                        Me.RadListBoxSoftwareProductVersions.Items.Clear()

                        Dim pSOFTWARE_PRODUCT_ID As New SqlParameter("@SOFTWARE_PRODUCT_ID", SqlDbType.Int)
                        pSOFTWARE_PRODUCT_ID.Value = ThisProductId

                        Dim dt As New DataTable
                        dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_SOFTWARE_VERSION_GET_BY_SOFTWARE_PRODUCT", "DtData", pSOFTWARE_PRODUCT_ID)
                        If dt.Rows.Count > 0 Then

                        End If
                        With Me.RadListBoxSoftwareProductVersions
                            .DataSource = dt
                            .DataTextField = "VERSION"
                            .DataValueField = "VERSION_ID" '"DATAKEY"
                            .DataBind()
                        End With
                    End If
                End If
        End Select
    End Sub

    Private Sub RadGridSoftwareProduct_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSoftwareProduct.ItemDataBound
        Dim tb As New System.Web.UI.WebControls.TextBox
        Dim chk As New CheckBox
        Dim ImgBtnDelete As New System.Web.UI.WebControls.ImageButton
        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then
            Try
                tb = DirectCast(e.Item.FindControl("TxtPRODUCT_DESC"), TextBox)
                tb.Focus()
            Catch ex As Exception
            End Try
        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                chk = DirectCast(e.Item.FindControl("ChkACTIVE_FLAG"), CheckBox)
            Catch ex As Exception
            End Try
            Try
                ImgBtnDelete = DirectCast(e.Item.FindControl("ImgBtnDelete"), ImageButton)
            Catch ex As Exception
            End Try
            Try
                If CType(e.Item.DataItem("ACTIVE_FLAG"), Boolean) = False Then
                    chk.Checked = True
                End If
            Catch ex As Exception
            End Try
            Try
                With ImgBtnDelete
                    .Enabled = True
                    .ToolTip = "Click to delete this row"
                    .Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadGridSoftwareProduct_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSoftwareProduct.NeedDataSource
        Me.RadGridSoftwareProduct.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, "SELECT * FROM SOFTWARE_PRODUCT WITH(NOLOCK) WHERE ACTIVE_FLAG = 1 OR ACTIVE_FLAG IS NULL;", "DtData")
        Me.RadGridSoftwareProduct.MasterTableView.IsItemInserted = True
    End Sub

    Private Sub RadListBoxSoftwareProductVersions_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxSoftwareProductVersions.ItemDataBound
        If CType(e.Item.DataItem("ON_THIS_PRODUCT"), Integer) = 1 Then
            e.Item.Selected = True
        End If
    End Sub

    Private Sub ButtonSoftwareProductVersionsSave_Click(sender As Object, e As System.EventArgs) Handles ButtonSoftwareProductVersionsSave.Click
        If Me.CurrentSoftwareProductId = 0 Then
            Try
                If Not Me.RadGridSoftwareProduct.SelectedValue Is Nothing Then
                    Me.CurrentSoftwareProductId = Me.RadGridSoftwareProduct.SelectedValue
                End If
            Catch ex As Exception
                Me.CurrentSoftwareProductId = 0
            End Try
        End If
        If Me.CurrentSoftwareProductId > 0 Then
            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("DELETE FROM SOFTWARE_PRODUCT_VERSION WHERE PRODUCT_ID = ")
                .Append(Me.CurrentSoftwareProductId)
                .Append(";")
                For Each item As RadListBoxItem In Me.RadListBoxSoftwareProductVersions.SelectedItems
                    .Append("INSERT INTO SOFTWARE_PRODUCT_VERSION (PRODUCT_ID, VERSION_ID) VALUES (")
                    .Append(Me.CurrentSoftwareProductId)
                    .Append(", ")
                    .Append(item.Value.ToString())
                    .Append(");")
                Next
            End With
            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
        End If
    End Sub

    Private Function UpdateSoftwareProductRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        Dim SoftwareProductId As Integer = 0
        Dim StrSQL As String = ""
        Try
            SoftwareProductId = CType(TheGridRow.GetDataKeyValue("PRODUCT_ID"), Integer)
        Catch ex As Exception
            SoftwareProductId = 0
        End Try

        If SoftwareProductId > 0 Then 'we are updating a rec
            Dim ProductName As String = ""
            Dim IsInactive As Boolean = True

            ProductName = DirectCast(TheGridRow.FindControl("TxtPRODUCT_DESC"), TextBox).Text.Trim()
            IsInactive = DirectCast(TheGridRow.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            Dim arP(2) As SqlParameter

            Dim pPRODUCT_DESC As New SqlParameter("@PRODUCT_DESC", SqlDbType.VarChar, 100)
            pPRODUCT_DESC.Value = ProductName
            arP(0) = pPRODUCT_DESC

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = Not IsInactive
            arP(1) = pACTIVE_FLAG

            If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT COUNT(1) FROM SOFTWARE_PRODUCT WITH(NOLOCK) WHERE PRODUCT_DESC = @PRODUCT_DESC", pPRODUCT_DESC), Integer) > 0 Then
                Me.ShowMessage("Please enter a unique state name")
                Exit Function
            Else
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "INSERT INTO SOFTWARE_PRODUCT (PRODUCT_DESC, ACTIVE_FLAG) VALUES (@PRODUCT_DESC, @ACTIVE_FLAG)", arP)
                Catch ex As Exception
                    Me.ShowMessage(ex.Message.ToString())
                End Try
            End If

        End If
    End Function

#End Region

    Private Sub RadGridSoftwareLevel_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadGridSoftwareLevel.SelectedIndexChanged
        'Try
        '    If Me.CurrentVersionId = 0 Then
        '        Me.CurrentVersionId = CType(Me.DropDownListVersions.SelectedValue, Integer)
        '    End If
        'Catch ex As Exception
        '    Me.CurrentVersionId = 0
        'End Try

        'If Me.CurrentVersionId = 0 Then Exit Sub

        'Try
        '    Dim gdi As GridDataItem = Me.RadGridSoftwareLevel.SelectedItems(0)
        '    If Not gdi Is Nothing Then
        '        Dim SQL As New System.Text.StringBuilder
        '        Dim chk As CheckBox
        '        Dim code As String = ""
        '        Dim JobNumber As Integer = 0
        '        Dim JobComponentNbr As Integer = 0
        '        Dim OnThisVersion As Boolean = False
        '        Dim RunSQL As Boolean = False

        '        chk = CType(gdi("ColumnClientSelect").Controls(0), CheckBox)
        '        code = gdi.GetDataKeyValue("code").ToString()
        '        JobNumber = CType(gdi.GetDataKeyValue("JOB_NUMBER"), Integer)
        '        JobComponentNbr = CType(gdi.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
        '        If CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer) > 0 Then
        '            OnThisVersion = True
        '        End If

        '        'OnThisVersion = MiscFN.IntToBool(CType(gdi.GetDataKeyValue("ACTIVE_ON_THIS_VERSION"), Integer))

        '        If Me.CurrentVersionId > 0 Then

        '            If chk.Checked = True Then 'need to add
        '                If Me.SoftwareLevelCode = "j" Then
        '                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
        '                    SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,VERSION_ID) VALUES (@JOB_NUMBER,@VERSION_ID);")
        '                ElseIf Me.SoftwareLevelCode = "jc" Then
        '                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
        '                    SQL.Append("INSERT INTO SOFTWARE_LEVEL (JOB_NUMBER,JOB_COMPONENT_NBR,VERSION_ID) VALUES (@JOB_NUMBER,@JOB_COMPONENT_NBR,@VERSION_ID);")
        '                End If
        '                RunSQL = True
        '            ElseIf chk.Checked = False Then 'need to remove
        '                If Me.SoftwareLevelCode = "j" Then
        '                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND (JOB_COMPONENT_NBR IS NULL OR JOB_COMPONENT_NBR = 0) AND VERSION_ID = @VERSION_ID;")
        '                ElseIf Me.SoftwareLevelCode = "jc" Then
        '                    SQL.Append("DELETE FROM SOFTWARE_LEVEL WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID;")
        '                End If
        '                RunSQL = True
        '            End If

        '            If RunSQL = True Then
        '                Try
        '                    Dim arP(3) As SqlParameter

        '                    Dim pVERSION_ID As New SqlParameter("@VERSION_ID", SqlDbType.Int)
        '                    pVERSION_ID.Value = Me.CurrentVersionId
        '                    arP(0) = pVERSION_ID

        '                    Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        '                    pJOB_NUMBER.Value = JobNumber
        '                    arP(1) = pJOB_NUMBER

        '                    Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        '                    If JobComponentNbr = 0 Then
        '                        pJOB_COMPONENT_NBR.Value = System.DBNull.Value
        '                    Else
        '                        pJOB_COMPONENT_NBR.Value = JobComponentNbr
        '                    End If
        '                    arP(2) = pJOB_COMPONENT_NBR

        '                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString(), arP)

        '                Catch ex As Exception
        '                    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        '                End Try
        '            End If

        '        End If

        '    End If
        'Catch ex As Exception
        '    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        'End Try

    End Sub

    Private Sub CheckBoxShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridVersions.Rebind()

    End Sub

    Private Sub ImageButtonExport_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExport.Click

        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        Select Case Me.RadMultiPage1.SelectedIndex
            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Version Code")
                DataTable.Columns.Add("Description")
                DataTable.Columns.Add("Active")

                RadGridVersions.AllowPaging = False

                RadGridVersions.Rebind()

                For Each GridDataItem In RadGridVersions.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.DataItem("VERSION")
                    NewDataRow(1) = GridDataItem.DataItem("VERSION_DESC")

                    Try

                        If IsDBNull(GridDataItem.DataItem("ACTIVE_FLAG")) OrElse CType(GridDataItem.DataItem("ACTIVE_FLAG"), Boolean) = True Then

                            NewDataRow(2) = "YES"

                        Else

                            NewDataRow(2) = "NO"

                        End If

                    Catch ex As Exception

                        NewDataRow(2) = "YES"

                    End Try

                Next

                Me.DeliverGrid(DataTable, "Software Versions") '<--- This does, please don't change unless you test!!!!

                RadGridVersions.AllowPaging = True

                RadGridVersions.Rebind()


            Case 1

        End Select
    End Sub

    Private Sub RadGridVersions_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridVersions.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridVersions.ID, e.NewPageSize)

    End Sub

    Private Sub RadGridBuilds_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridBuilds.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridBuilds.ID, e.NewPageSize)

    End Sub
End Class