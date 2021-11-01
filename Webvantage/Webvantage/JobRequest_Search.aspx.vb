
Imports System.Data.SqlClient

Public Class JobRequest_Search
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private search As Boolean = False
    Private ClientCode As String = ""
    Private DivisionCode As String = ""
    Private ProductCode As String = ""

    Public dDateStart As Date
    Public dDateEnd As Date

#End Region

#Region " Properties "
    Private Property CurrentGridPageIndex As Integer = 0
#End Region

#Region " Methods "

    Private Sub ResetSearch()

        TextBox_Client.Text = ""
        TextBox_Division.Text = ""
        TextBox_Product.Text = ""

        dDateStart = cEmployee.TimeZoneToday
        RadDatePickerStart.SelectedDate = dDateStart
        RadDatePickerDue.SelectedDate = dDateStart.AddMonths(1)

        Me.CheckboxExclude.Checked = True

        SetPanelControls()

        RadGrid_JobRequestSearch.MasterTableView.CurrentPageIndex = 0
        RadGrid_JobRequestSearch.Rebind()

    End Sub
    Protected Sub SetPanelControls()

        Try

            If Me.IsClientPortal = True Then
                TextBox_Client.Text = Session("CL_CODE")
                TextBox_Client.ReadOnly = True
                HyperLink_Division.Attributes.Add("onclick", "ClearTB('" & Me.TextBox_Product.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobrequestsearch&type=division&control=" & Me.TextBox_Division.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
                HyperLink_Product.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequestsearch&type=product&control=" & Me.TextBox_Product.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
                TextBox_Division.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TextBox_Product.ClientID & "');")
            Else
                HyperLink_Client.Attributes.Add("onclick", "ClearTB('" & Me.TextBox_Division.ClientID & "');ClearTB('" & Me.TextBox_Product.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobrequestsearch&control=" & Me.TextBox_Client.ClientID & "&type=client&ddtype=client');return false;")
                HyperLink_Division.Attributes.Add("onclick", "ClearTB('" & Me.TextBox_Product.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobrequestsearch&type=division&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
                HyperLink_Product.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequestsearch&type=product&control=" & Me.TextBox_Product.ClientID & "&office=&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
                TextBox_Client.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TextBox_Division.ClientID & "');ClearTB('" & Me.TextBox_Product.ClientID & "');")
                TextBox_Division.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TextBox_Product.ClientID & "');")
            End If


        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString)
        End Try

    End Sub
    Protected Function ValidateSearch() As Boolean

        'objects
        Dim IsValid As Boolean = True
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrEmpty(TextBox_Client.Text) = False Then

                        If (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
                            Where Entity.Code = TextBox_Client.Text
                            Select Entity).Any = False Then

                            Me.ShowMessage("Invalid Client")
                            IsValid = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                Where Entity.Code = TextBox_Client.Text
                                Select Entity).Any = False Then

                            Me.ShowMessage("Access to this client is denied.")
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_Division.Text) = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, TextBox_Client.Text)
                                Where Entity.Code = TextBox_Division.Text
                                Select Entity).Any = False Then

                                Me.ShowMessage("Invalid Division")
                                IsValid = False

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                    Where Entity.ClientCode = TextBox_Client.Text AndAlso
                                          Entity.Code = TextBox_Division.Text
                                    Select Entity).Any = False Then

                                Me.ShowMessage("Access to this division is denied.")
                                IsValid = False

                            End If

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_Product.Text) = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, TextBox_Client.Text, TextBox_Division.Text)
                                Where Entity.Code = TextBox_Product.Text
                                Select Entity).Any = False Then

                                Me.ShowMessage("Invalid Product")
                                IsValid = False

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, False)
                                    Where Entity.ClientCode = TextBox_Client.Text AndAlso
                                          Entity.DivisionCode = TextBox_Division.Text AndAlso
                                          Entity.Code = TextBox_Product.Text
                                    Select Entity).Any = False Then

                                Me.ShowMessage("Access to this Product is denied.")
                                IsValid = False

                            End If

                        End If

                    End If

                End Using

            End Using

        Catch ex As Exception
            IsValid = False
        Finally
            ValidateSearch = IsValid
        End Try

    End Function
    Private Sub CheckUserRights()

        'objects
        Dim CanView As Boolean = False
        Dim CanEdit As Boolean = False
        Dim CanInsert As Boolean = False

        Try

            'CanView = Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
            'CanEdit = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
            'CanInsert = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            'If CanEdit = False AndAlso CanInsert = False Then

            '    RadToolBar_ATBSearch.FindItemByValue("New").Enabled = False

            'ElseIf CanEdit = True AndAlso CanInsert = False Then

            '    RadToolBar_ATBSearch.FindItemByValue("New").Enabled = False

            'ElseIf CanEdit = False AndAlso CanInsert = True Then


            'End If

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Me.PageTitle = "Find Job Request"

        SetPanelControls()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            dDateStart = cEmployee.TimeZoneToday
            RadDatePickerStart.SelectedDate = dDateStart
            RadDatePickerDue.SelectedDate = dDateStart.AddMonths(1)
            Me.CheckboxExclude.Checked = True

            CheckUserRights()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGrid_JobRequestSearch_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid_JobRequestSearch.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Reload As Boolean = True
        Dim jv As New JobVersion(Session("ConnString"))
        Dim dr As SqlDataReader

        Select Case e.CommandName

            Case "Detail"

                If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                    CurrentGridDataItem = RadGrid_JobRequestSearch.Items(e.Item.ItemIndex)

                End If

                If CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER") > 0 Then
                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Content.aspx"
                    qs.JobNumber = CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER")
                    qs.JobComponentNumber = CurrentGridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                    Me.OpenWindow("", qs.ToString(True))
                Else
                    dr = jv.GetJVRequestDescriptions(CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"))
                    If dr.HasRows Then
                        dr.Read()
                        If IsDBNull(dr("CL_CODE")) = True Then
                            Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=request&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"))
                        Else
                            Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=requesttoform&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"))
                        End If
                        dr.Close()
                    End If
                End If

                Reload = False

        End Select

        'If Reload Then

        '    RadGrid_ATBSearch.Rebind()

        'End If

    End Sub
    Private Sub RadToolBar_JobRequest_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar_JobRequestSearch.ButtonClick

        Select Case e.Item.Value

            Case "Search"

                If ValidateSearch() = True Then

                    search = True
                    RadGrid_JobRequestSearch.Rebind()

                End If

            Case "Clear"

                ResetSearch()

            Case "New"

                Me.OpenWindow("New Job Request", "jobVerNew.aspx?mode=request", 690, 950)

        End Select

    End Sub
    Private Sub RadGrid_JobRequestSearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_JobRequestSearch.NeedDataSource

        'objects
        Dim jv As New JobVersion(Session("ConnString"))
        Dim dr As SqlDataReader
        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing

        ClientCode = TextBox_Client.Text.Trim()
        DivisionCode = TextBox_Division.Text.Trim()
        ProductCode = TextBox_Product.Text.Trim()

        Dim dt As DataTable

        LoGlo.PageCultureSetDatabaseAndUser(Me.Page)

        If IsClientPortal = True Then
            dt = jv.GetJobRequests(ClientCode, DivisionCode, ProductCode, Me.RadDatePickerStart.SelectedDate, Me.RadDatePickerDue.SelectedDate, search, Me.CheckboxExclude.Checked, True, Session("UserID"))
        Else
            dt = jv.GetJobRequests(ClientCode, DivisionCode, ProductCode, Me.RadDatePickerStart.SelectedDate, Me.RadDatePickerDue.SelectedDate, search, Me.CheckboxExclude.Checked, False)
        End If

        RadGrid_JobRequestSearch.DataSource = dt

        Try

            If dt.Rows.Count = 1 Then
                'go

                If dt.Rows(0)("JOB_NUMBER") > 0 Then
                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Content.aspx"
                    qs.JobNumber = dt.Rows(0)("JOB_NUMBER")
                    qs.JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                    Me.OpenWindow("", qs.ToString(True))
                Else
                    dr = jv.GetJVRequestDescriptions(dt.Rows(0)("JOB_VER_HDR_ID"))
                    If dr.HasRows Then
                        dr.Read()
                        If IsDBNull(dr("CL_CODE")) = True Then
                            Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=request&JobVerHdrID=" & dt.Rows(0)("JOB_VER_HDR_ID"), 600, 1100)
                        Else
                            Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=requesttoform&JobVerHdrID=" & dt.Rows(0)("JOB_VER_HDR_ID"), 600, 1100)
                        End If
                        dr.Close()
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

        LoGlo.PageCultureSet(Me.Page)

        Me.RadGrid_JobRequestSearch.CurrentPageIndex = Me.CurrentGridPageIndex
        Me.RadGrid_JobRequestSearch.PageSize = MiscFN.LoadPageSize(Me.RadGrid_JobRequestSearch.ID)

    End Sub
    Private Sub RadGrid_JobRequestSearch_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid_JobRequestSearch.PageIndexChanged
        Try
            search = True
            ClientCode = TextBox_Client.Text.Trim()
            DivisionCode = TextBox_Division.Text.Trim()
            ProductCode = TextBox_Product.Text.Trim()
            Me.CurrentGridPageIndex = e.NewPageIndex
            Me.RadGrid_JobRequestSearch.Rebind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid_JobRequestSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGrid_JobRequestSearch.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGrid_JobRequestSearch.ID, e.NewPageSize)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            If ValidateSearch() = True Then

                search = True
                RadGrid_JobRequestSearch.Rebind()

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
