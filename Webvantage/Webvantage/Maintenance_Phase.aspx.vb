Public Class Maintenance_Phase
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Function UpdatePhase(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim Phase As AdvantageFramework.Database.Entities.Phase = Nothing
        Dim PhaseUpdated As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Phase = AdvantageFramework.Database.Procedures.Phase.LoadByPhaseID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                If Phase IsNot Nothing Then

                    Phase.Description = CType(GridDataItem.FindControl("TextBoxPhaseDescription"), TextBox).Text.Trim
                    Phase.OrderNumber = CType(GridDataItem.FindControl("TextBoxPhaseOrderNumber"), Telerik.Web.UI.RadNumericTextBox).Value

                    If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                        Phase.IsInactive = 1

                    Else

                        Phase.IsInactive = 0

                    End If

                    PhaseUpdated = AdvantageFramework.Database.Procedures.Phase.Update(DbContext, Phase)

                End If

            End Using

        Catch ex As Exception
            PhaseUpdated = False
        Finally
            UpdatePhase = PhaseUpdated
        End Try

    End Function

#Region "  Form Event Handlers "

    Private Sub PhaseMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Phase Maintenance"

        If Not Me.IsPostBack And Not Me.IsCallback Then

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridPhases.Rebind()

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Phases As IQueryable(Of AdvantageFramework.Database.Entities.Phase) = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Description")
        DataTable.Columns.Add("Order Number")
        DataTable.Columns.Add("Is Inactive")

        RadGridPhases.AllowPaging = False

        Me.RadGridPhases.Rebind()

        For Each GridDataItem In RadGridPhases.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Description
            NewDataRow(1) = GridDataItem.DataItem.OrderNumber

            If GridDataItem.DataItem.IsInactive Then

                NewDataRow(2) = "YES"

            Else

                NewDataRow(2) = "NO"

            End If

        Next

        'DataView = New DataView(DataTable)

        'GridView = New GridView

        'GridView.DataSource = DataView
        'GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("Phases.xls", GridView) <--- This doesn' work
        Me.DeliverGrid(DataTable, "Phases") '<--- This does, please don't change unless you test!!!!

        RadGridPhases.AllowPaging = True

        Me.RadGridPhases.Rebind()

    End Sub

    Private Sub RadGridPhases_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridPhases.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Phase As AdvantageFramework.Database.Entities.Phase = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridPhases.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridPhases.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdatePhase(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Phase = New AdvantageFramework.Database.Entities.Phase

                    Phase.DbContext = DbContext

                    Phase.Description = CType(e.Item.FindControl("TextBoxPhaseDescriptionEditTextBox"), TextBox).Text.Trim
                    Phase.OrderNumber = CType(e.Item.FindControl("TextBoxPhaseOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value

                    If CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked Then

                        Phase.IsInactive = 1

                    Else

                        Phase.IsInactive = 0

                    End If

                    Reload = AdvantageFramework.Database.Procedures.Phase.Insert(DbContext, Phase)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdatePhase(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxPhaseDescriptionEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxPhaseOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            Phase = AdvantageFramework.Database.Procedures.Phase.LoadByPhaseID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If Phase IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.Phase.Delete(DbContext, DataContext, Phase)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect("Maintenance_Phase.aspx")

            Else

                Me.RadGridPhases.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxPhaseDescriptionEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridPhases_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridPhases.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridPhases_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridPhases.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CheckBoxShowInactive.Checked Then

                RadGridPhases.DataSource = (From Phase In AdvantageFramework.Database.Procedures.Phase.Load(DbContext)
                                            Select Phase.ID,
                                                    Phase.Description,
                                                    Phase.OrderNumber,
                                                    [IsInactive] = CBool(Phase.IsInactive)
                                            Order By OrderNumber,
                                                    Description).ToList

            Else

                RadGridPhases.DataSource = (From Phase In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                            Select Phase.ID,
                                                    Phase.Description,
                                                    Phase.OrderNumber,
                                                    [IsInactive] = CBool(Phase.IsInactive)
                                            Order By OrderNumber,
                                                    Description).ToList

            End If

            RadGridPhases.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridPhases.PageSize = MiscFN.LoadPageSize(Me.RadGridPhases.ID)

    End Sub
    Private Sub RadGridPhases_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridPhases.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridPhases.Rebind()

    End Sub
    Private Sub RadGridPhases_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridPhases.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridPhases.ID, e.NewPageSize)

    End Sub

#End Region

#End Region

End Class