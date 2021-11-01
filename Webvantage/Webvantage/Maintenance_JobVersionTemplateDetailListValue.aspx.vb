Public Class Maintenance_JobVersionTemplateDetailListValue
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobVersionTemplateDetailID As Long = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function UpdateJobVersionTemplateDetailListValue(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing
        Dim JobVersionTemplateDetailListValueUpdated As Boolean = False

        Try

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                JobVersionTemplateDetailListValue = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailListValueID(DataContext, GridDataItem.GetDataKeyValue("ID"))

                If JobVersionTemplateDetailListValue IsNot Nothing Then

                    JobVersionTemplateDetailListValue.Value = CType(GridDataItem.FindControl("TextBoxJobVersionTemplateDetailListValueValue"), TextBox).Text.Trim

                    JobVersionTemplateDetailListValueUpdated = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Update(DataContext, JobVersionTemplateDetailListValue)

                End If

            End Using

        Catch ex As Exception
            JobVersionTemplateDetailListValueUpdated = False
        Finally
            UpdateJobVersionTemplateDetailListValue = JobVersionTemplateDetailListValueUpdated
        End Try

    End Function
    Private Sub LoadJobVersionTemplateDetailListValues()

        'objects
        Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, _JobVersionTemplateDetailID)

                If JobVersionTemplateDetail IsNot Nothing Then

                    LabelJobVersionTemplateDetailLabel.Text = JobVersionTemplateDetail.Label & " Values"

                    RadGridJobVersionTemplateDetailListValues.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailID(DataContext, _JobVersionTemplateDetailID).ToList

                    RadGridJobVersionTemplateDetailListValues.MasterTableView.IsItemInserted = True

                    RadGridJobVersionTemplateDetailListValues.DataBind()

                End If

            End Using

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub JobVersionTemplateDetailListValueMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If Not Request.QueryString("JobVersionTemplateDetailID") Is Nothing Then

                _JobVersionTemplateDetailID = CType(Request.QueryString("JobVersionTemplateDetailID"), Long)

            End If

        Catch ex As Exception
            _JobVersionTemplateDetailID = 0
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            LoadJobVersionTemplateDetailListValues()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarJobVersionTemplateDetailListValues_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobVersionTemplateDetailListValues.ButtonClick

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim JobVersionTemplateDetailListValues As IQueryable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) = Nothing

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

            Case "ExportToExcel"

                DataTable = New DataTable

                DataTable.Columns.Add("Value")

                RadGridJobVersionTemplateDetailListValues.AllowPaging = False

                LoadJobVersionTemplateDetailListValues()

                For Each GridDataItem In RadGridJobVersionTemplateDetailListValues.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.DataItem.Value

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("JobVersionTemplateDetailListValues.xls", GridView)  <--- This doesn' work
                Me.DeliverGrid(DataTable, "Job Version Template Detail List Values") '<--- This does, please don't change unless you test!!!!

                RadGridJobVersionTemplateDetailListValues.AllowPaging = True

                LoadJobVersionTemplateDetailListValues()

        End Select

    End Sub
    Private Sub RadGridJobVersionTemplateDetailListValues_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobVersionTemplateDetailListValues.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobVersionTemplateDetailListValues.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridJobVersionTemplateDetailListValues.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateJobVersionTemplateDetailListValue(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveNewRow"

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    JobVersionTemplateDetailListValue = New AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue

                    JobVersionTemplateDetailListValue.JobVersionTemplateDetailID = _JobVersionTemplateDetailID
                    JobVersionTemplateDetailListValue.Value = CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailListValueValueEditTextBox"), TextBox).Text.Trim

                    Reload = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Insert(DataContext, JobVersionTemplateDetailListValue)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateJobVersionTemplateDetailListValue(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailListValueValueEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        JobVersionTemplateDetailListValue = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailListValueID(DataContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If JobVersionTemplateDetailListValue IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Delete(DataContext, JobVersionTemplateDetailListValue)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadJobVersionTemplateDetailListValues()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailListValueValueEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridJobVersionTemplateDetailListValues_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobVersionTemplateDetailListValues.ItemDataBound

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

#End Region

#End Region

End Class