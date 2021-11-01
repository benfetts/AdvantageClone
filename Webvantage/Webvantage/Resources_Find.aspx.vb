Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Public Class Resources_Find
    Inherits Webvantage.BaseChildPage

    Private EventIdList As String = ""
    Private MinDate As DateTime
    Private MaxDate As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'right now catching as session in case really long
            EventIdList = Session("SelectedEventsForResource")
        Catch ex As Exception
            EventIdList = ""
            Me.ShowMessage(ex.Message.ToString())
        End Try
        Try
            MinDate = Convert.ToDateTime(Request.QueryString("min"))
        Catch ex As Exception
            MinDate = Convert.ToDateTime(Now())
            Me.ShowMessage(ex.Message.ToString())
        End Try
        Try
            MaxDate = Convert.ToDateTime(Request.QueryString("max"))
        Catch ex As Exception
            MaxDate = Convert.ToDateTime(Now())
            Me.ShowMessage(ex.Message.ToString())
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                Me.LoadDropResourceTypes()
            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try
        Else
            ''hide windows
            'Me.RadWindowManagerResources.Windows(0).VisibleOnPageLoad = False

        End If
    End Sub

    Private Sub LoadDropResourceTypes()
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            With Me.DropResourceType
                .DataSource = d.GetResourceTypesList()
                .DataTextField = "display"
                .DataValueField = "code"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "-1"))
            End With
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadDropDistinctAdNumbers()
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            Me.DropAdNumbers.Items.Clear()
            With Me.DropAdNumbers
                .DataSource = d.GetDistinctAdNumbers(Me.EventIdList)
                .DataTextField = "AD_NBR_DESC"
                .DataValueField = "AD_NUMBER"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "-1"))
                '.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
            End With
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub DropResourceType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropResourceType.SelectedIndexChanged
        Try
            Me.LoadDropDistinctAdNumbers()
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub DropAdNumbers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropAdNumbers.SelectedIndexChanged
        Try
            Me.RadGridAvailableResources.Rebind()
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Dim DsData As New DataSet

    Private Sub RadGridAvailableResources_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAvailableResources.ItemCreated
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
                'set head checkbox for Events grid
                Dim headerItem As Telerik.Web.UI.GridHeaderItem = DirectCast(e.Item, Telerik.Web.UI.GridHeaderItem)
                Dim chkSelectAll As CheckBox = DirectCast(headerItem("ColumnClientSelect1").Controls(0), CheckBox)
                hf1.Value = chkSelectAll.ClientID
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
        'If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
        '    Try
        '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)
        '        Dim chk As CheckBox
        '        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
        '        chk.Checked = True
        '    Catch ex As Exception
        '    End Try
        'End If
    End Sub

    'This is the list of events...
    Private Sub RadGridAvailableResources_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvailableResources.NeedDataSource
        Try
            If Me.DropResourceType.SelectedIndex > 0 And Me.DropAdNumbers.SelectedIndex > 0 Then
                Dim rsc As New cResources()
                Me.DsData = rsc.FindAvailableResources(Me.EventIdList, Me.DropResourceType.SelectedValue, Me.DropAdNumbers.SelectedValue, False, False)
                Session("EventsResources") = DsData.Tables(1)
                Me.RadGridAvailableResources.DataSource = DsData.Tables(0)

                'Me.RadGridResourcesForApplySelected.DataSource = DsData.Tables(2)
                'Me.RadGridResourcesForApplySelected.DataBind()
                Me.RadGridResourcesForApplySelected.Rebind()
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
    Private Sub RadGridResourcesForApplySelected_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridResourcesForApplySelected.NeedDataSource
        Try
            Dim rsc As New cResources()
            Me.DsData = rsc.FindAvailableResources(Me.EventIdList, Me.DropResourceType.SelectedValue, Me.DropAdNumbers.SelectedValue, False, False)
            'Session("EventsResources") = DsData.Tables(1)
            'Me.RadGridAvailableResources.DataSource = DsData.Tables(0)
            Me.RadGridResourcesForApplySelected.DataSource = DsData.Tables(2)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub CloseAndRefresh()
        Try
            Try
                Session("SelectedEventsForResource") = Nothing
            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try
            Me.CloseThisWindowAndRefreshCaller("Event_View.aspx")
            'Me.LitScript.Text = "<script>CallFunctionOnParentPage('RefreshGrid');</" + "script>"
            'Dim str As String = "<script>CallFunctionOnParentPage('RefreshGrid');</" + "script>"
            'Me.RadScriptManager1.RegisterStartupScript(Me.Page, Me.GetType(), "CloseIt", str, False)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnApply.Click
        Try
            Dim StrSelectedResource As String = ""
            Dim chk As CheckBox
            Dim SomethingWasDone As Boolean = False
            Dim evt As New cEvents()

            'get selected resource
            For Each CurrentResourceGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridResourcesForApplySelected.MasterTableView.Items
                chk = CType(CurrentResourceGridRow("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked = True Then
                    StrSelectedResource = CurrentResourceGridRow.GetDataKeyValue("RESOURCE_CODE").ToString()
                    Exit For
                End If
            Next

            If StrSelectedResource <> "" Then 'use the override
                'get selected events
                'Dim SbEventIds As New System.Text.StringBuilder
                'Dim StrEventIds As String = ""
                'Dim DoUpdate As Boolean = False
                For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableResources.MasterTableView.Items
                    chk = CType(CurrentGridRow("ColumnClientSelect1").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        If IsNumeric(CurrentGridRow.GetDataKeyValue("EVENT_ID")) Then
                            'SbEventIds.Append(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer).ToString())
                            'SbEventIds.Append(",")
                            'DoUpdate = True
                            evt.EventUpdateResource(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer), StrSelectedResource, True, True, False)
                            SomethingWasDone = True
                        End If
                    End If
                Next
                'StrEventIds = SbEventIds.ToString()
                'StrEventIds = MiscFN.RemoveTrailingDelimiter(StrEventIds, ",")
                'If DoUpdate = True And StrSelectedResource.Trim() <> "" Then
                '    Try
                '        Dim StrSQL As String = "UPDATE EVENT WITH(ROWLOCK) SET RESOURCE_CODE = '" & StrSelectedResource & "' WHERE EVENT_ID IN (" & StrEventIds & ");"
                '        Using MyConn As New SqlConnection(Session("ConnString"))
                '            MyConn.Open()
                '            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                '            Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                '            Try
                '                MyCmd.ExecuteNonQuery()
                '                MyTrans.Commit()
                '                SomethingWasDone = True
                '            Catch ex As Exception
                '                MyTrans.Rollback()
                '            Finally
                '                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                '            End Try
                '        End Using
                '    Catch ex As Exception
                '    End Try
                'End If
            Else 'use the recommended (what's in the grid)
                Dim RowCount As Integer = Me.RadGridAvailableResources.MasterTableView.Items.Count
                If EventIdList <> "" And RowCount > 0 Then
                    Dim CurrResourceCode As String = ""
                    Dim CurrEventId As Integer = 0
                    Dim SbSQL As New System.Text.StringBuilder
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableResources.MasterTableView.Items
                        CurrResourceCode = CType(CurrentGridRow.FindControl("TxtRESOURCE_CODE"), TextBox).Text
                        CurrEventId = CType(CType(CurrentGridRow.FindControl("HfEVENT_ID"), HiddenField).Value, Integer)
                        If CurrResourceCode <> "" And CurrEventId > 0 Then
                            'With SbSQL
                            '    .Append("UPDATE EVENT WITH(ROWLOCK) SET RESOURCE_CODE = '")
                            '    .Append(CurrResourceCode)
                            '    .Append("' WHERE EVENT_ID = ")
                            '    .Append(CurrEventId.ToString())
                            '    .Append(";")
                            'End With
                            evt.EventUpdateResource(CurrEventId, CurrResourceCode, True, True, False)

                            SomethingWasDone = True
                        End If
                    Next
                    'Dim StrSQL As String = SbSQL.ToString()
                    'If StrSQL <> "" Then
                    '    Try
                    '        Using MyConn As New SqlConnection(Session("ConnString"))
                    '            MyConn.Open()
                    '            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    '            Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    '            Try
                    '                MyCmd.ExecuteNonQuery()
                    '                MyTrans.Commit()
                    '                SomethingWasDone = True
                    '            Catch ex As Exception
                    '                MyTrans.Rollback()
                    '            Finally
                    '                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    '            End Try
                    '        End Using
                    '    Catch ex As Exception
                    '    End Try
                    'End If
                End If
            End If
            If SomethingWasDone = True Then
                Me.CloseAndRefresh()
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub Resources_Find_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        ''Dim RowCount As Integer = Me.RadGridAvailableResources.MasterTableView.Items.Count
        ''If RowCount > 0 Then
        ''    For i As Integer = 0 To RowCount - 1
        ''        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAvailableResources.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
        ''        Dim chk As CheckBox
        ''        chk = CType(CurrentGridRow("ColumnClientSelect1").Controls(0), CheckBox)
        ''        chk.Checked = True
        ''    Next
        ''End If
    End Sub

End Class