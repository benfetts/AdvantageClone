Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class BillingApproval_Approval_Summary
    Inherits Webvantage.BaseChildPage

    Public Enum RollupType
        ByJob = 0
        ByCampaign = 1
    End Enum

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _CampaignIdentifier As Integer = 0
    Private _RollupType As RollupType = RollupType.ByJob

    Private _BillingApprovalId As Integer = 0
    Private _BillingApprovalBatchId As Integer = 0

    Private _TempCutoff As Date = Nothing
    Private _TempCutoffFunctionType As String = ""

    Private _LiteralDescription As Literal
    Private _RadioButtonListRollupType As System.Web.UI.WebControls.RadioButtonList
    Private _RadComboBoxGroupBy As RadComboBox

    Private _RollupId As String = ""
    Private _CampaignCode As String = ""
    Private _Description As String = ""

    Private _Counter As Integer = 0

    Private Sub BillingApproval_Approval_Summary_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            'Me.RadToolBarBillingApprovalSummary.FindItemByValue("bookmark").Visible = Me.EnableBookmarks

        End If

    End Sub

    Private Sub BillingApproval_Approval_Summary_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNumber = qs.JobComponentNumber
        Me._CampaignIdentifier = qs.CampaignIdentifier
        Me._BillingApprovalId = qs.BillingApprovalId
        Me._BillingApprovalBatchId = qs.BillingApprovalBatchID
        If IsDate(qs.CutOffDate) = True Then Me._TempCutoff = CType(qs.CutOffDate, Date)
        Me._TempCutoffFunctionType = qs.GetValue("fntype")

        Me._LiteralDescription = CType(Me.RadToolBarBillingApprovalSummary.FindItemByValue("RadToolBarButtonLiteralDescription").FindControl("LiteralDescription"), Literal)
        Me._RadioButtonListRollupType = CType(Me.RadToolBarBillingApprovalSummary.FindItemByValue("RadToolBarButtonRadioButtonListRollupType").FindControl("RadioButtonListRollupType"), RadioButtonList)
        Me._RadComboBoxGroupBy = CType(Me.RadToolBarBillingApprovalSummary.FindItemByValue("RadToolBarButtonRadComboBoxGroupBy").FindControl("RadComboBoxGroupBy"), RadComboBox)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            'If IsNumeric(qs.GetValue("PreCmp")) = True Then

            '    Me._RadioButtonListRollupType.SelectedValue = qs.GetValue("PreCmp")

            'End If

        End If

    End Sub

    Protected Sub RadComboBoxGroupBy_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)
        Try

            With Me.RadGridBillingApprovalSummary

                .MasterTableView.GroupByExpressions.Clear()

                Select Case Me._RadComboBoxGroupBy.SelectedIndex

                    Case 1

                        Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FunctionTypeDescription Type Group By FunctionTypeDescription")
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True

                    Case 2

                        Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FunctionHeadingDescription Description Group By FunctionHeadingDescription")
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True

                End Select

            End With

            Me.RadGridBillingApprovalSummary.Rebind()

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
            With Me.RadGridBillingApprovalSummary

                .MasterTableView.GroupByExpressions.Clear()
                .Rebind()

            End With

        End Try

    End Sub
    Private Sub RadGridBillingApprovalSummary_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridBillingApprovalSummary.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header

            Case GridItemType.Item, GridItemType.AlternatingItem

                If Me._Counter = 0 Then

                    Dim babar As New AdvantageFramework.Database.Classes.BillingApprovalBatchApprovalRollup

                    babar = e.Item.DataItem

                    If Not babar Is Nothing Then

                        Me._RollupId = babar.RollupID.ToString()
                        If Me._RollupType = RollupType.ByJob Then Me._RollupId = Me._RollupId.PadLeft(6, "0")
                        If Me._RollupType = RollupType.ByCampaign Then Me._CampaignCode = babar.CampaignCode
                        Me._Description = babar.Description

                    End If

                    Dim sb As New System.Text.StringBuilder

                    With sb

                        .Append(Me._RollupType.ToString().Replace("By", ""))
                        .Append(":&nbsp;&nbsp;")

                        Select Case Me._RollupType
                            Case RollupType.ByJob

                                .Append(Me._RollupId)

                            Case RollupType.ByCampaign

                                .Append(Me._CampaignCode)

                        End Select

                        .Append("&nbsp;-&nbsp;")
                        .Append(Me._Description)

                    End With

                    Me._LiteralDescription.Text = sb.ToString()
                    Me.HiddenFieldTitle.Value = Me._LiteralDescription.Text

                    Me._Counter += 1

                End If

            Case GridItemType.Footer

        End Select

    End Sub
    Private Sub RadGridBillingApprovalSummary_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBillingApprovalSummary.NeedDataSource

        Me._RollupType = CType(CType(Me._RadioButtonListRollupType.SelectedValue, Integer), RollupType)

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Classes.BillingApprovalBatchApprovalRollup)

            list = AdvantageFramework.Database.Procedures.BillingApprovalBatchApprovalRollup.Load(DbContext, Me._JobNumber, Me._JobComponentNumber,
                                                                                                  Me._CampaignIdentifier, Me._RollupType, Me._BillingApprovalId,
                                                                                                  Me._BillingApprovalBatchId,
                                                                                                  Me._TempCutoff, Me._TempCutoffFunctionType)


            If Not list Is Nothing Then Me.RadGridBillingApprovalSummary.DataSource = list

        End Using

    End Sub
    Protected Sub RadioButtonListRollupType_SelectedIndexChanged(sender As Object, e As EventArgs)

        Me.RadGridBillingApprovalSummary.Rebind()

    End Sub
    Private Sub RadToolBarBillingApprovalSummary_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarBillingApprovalSummary.ButtonClick

        Select Case e.Item.Value
            Case "Refresh"

                Me.RadGridBillingApprovalSummary.Rebind()

            Case "ExportToExcel"
                Try

                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridBillingApprovalSummary, Me.Filename())

                    RadGridBillingApprovalSummary.MasterTableView.ExportToExcel()

                Catch ex As Exception
                    Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
                End Try

                'Case "bookmark"

                '    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                '    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                '    Dim qs As New AdvantageFramework.Web.QueryString()
                '    Dim s As String = ""

                '    b.Name = "Approval Rollup for " & Me.HiddenFieldTitle.Value.Replace("&nbsp;", " ")

                '    qs.Add("PreCmp", Me._RadioButtonListRollupType.SelectedValue)

                '    With b

                '        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.BillingApprovalApprovalRollup
                '        .UserCode = Me._Session.UserCode
                '        .PageURL = "BillingApproval_Approval_Summary.aspx"

                '    End With
                '    If BmMethods.SaveBookmark(b, s) = False Then

                '        Me.ShowMessage(s)

                '    Else

                '        Me.RefreshBookmarksDesktopObject()

                '    End If

        End Select

    End Sub

    Private Function Filename() As String

        Return "ApprovalRollup__" & Me.HiddenFieldTitle.Value.Replace("&nbsp;", "").Replace(":", "_").Replace("-", "_") & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)

    End Function

End Class
