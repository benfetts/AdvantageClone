Partial Public Class Estimating_Setup
    Inherits Webvantage.BaseChildPage
    Public EstNum As Integer = 0
    Public EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Estimate Quote - Setup"
        If Not Me.IsPostBack Then
            'Me.RadGridEstimateItems.Skin = MiscFN.SetRadGridSkin()
        End If
    End Sub


    Public Sub ChkShowOnGrid_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)
        'Me.ShowMessage("Row datakey " & CurrentGridRow.GetDataKeyValue("ID"))
        Dim ColumnID As Integer = 0
        Try
            ColumnID = CurrentGridRow.GetDataKeyValue("ID")
        Catch ex As Exception
            ColumnID = 0
        End Try
        Dim bShowOnGrid As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnGrid"), CheckBox).Checked
        Dim bShowOnAddNew As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnAddNew"), CheckBox).Checked

        If ColumnID > 0 Then
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            est.UpdateUserColumn(Session("EmpCode"), ColumnID, bShowOnGrid, bShowOnAddNew)
        End If

        Me.RGEstimateItems.Rebind()
    End Sub

    Public Sub ChkShowOnAddNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)
        'Me.ShowMessage("Row datakey " & CurrentGridRow.GetDataKeyValue("ID"))
        Dim ColumnID As Integer = 0
        Try
            ColumnID = CurrentGridRow.GetDataKeyValue("ID")
        Catch ex As Exception
            ColumnID = 0
        End Try
        Dim bShowOnGrid As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnGrid"), CheckBox).Checked
        Dim bShowOnAddNew As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnAddNew"), CheckBox).Checked

        If ColumnID > 0 Then
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            est.UpdateUserColumn(Session("EmpCode"), ColumnID, bShowOnGrid, bShowOnAddNew)
        End If

        Me.RGEstimateItems.Rebind()
    End Sub

    Private Sub RGEstimateItems_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RGEstimateItems.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            DirectCast(e.Item.FindControl("ChkShowOnGrid"), CheckBox).Checked = CType(e.Item.DataItem("SHOW_ON_GRID"), Boolean)
            If DirectCast(e.Item.FindControl("HfACTIVE"), HiddenField).Value.Trim = "3" Then
                Dim chk As CheckBox = DirectCast(e.Item.FindControl("ChkShowOnAddNew"), CheckBox)
                chk.Checked = False
                chk.Enabled = False
            Else
                DirectCast(e.Item.FindControl("ChkShowOnAddNew"), CheckBox).Checked = CType(e.Item.DataItem("SHOW_ON_ADDNEW"), Boolean)
            End If

            'If e.Item.DataItem("SEQ") = "-1" Then
            '    DirectCast(e.Item.FindControl("ChkShowFull"), CheckBox).Enabled = False
            'Else
            '    DirectCast(e.Item.FindControl("ChkShowFull"), CheckBox).Checked = CType(e.Item.DataItem("SHOW_FULL"), Boolean)
            'End If
        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim str As String = e.Item.Cells(0).Text
            Dim str2 As String = e.Item.Cells(1).Text
            Dim str3 As String = e.Item.Cells(2).Text
            Dim str4 As String = e.Item.Cells(3).Text
            Try
                If e.Item.Cells(3).Text = "Supplied By Employee Code" Then
                    e.Item.Cells(3).Text = "Supplied By Code"
                End If
                If e.Item.Cells(3).Text = "Supplied By Employee Notes" Then
                    e.Item.Cells(3).Text = "Supplied By Notes"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RGEstimateItems_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RGEstimateItems.NeedDataSource
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Me.RGEstimateItems.DataSource = est.GetEstimateColumns(Session("EmpCode"), True, True, False)
    End Sub
End Class