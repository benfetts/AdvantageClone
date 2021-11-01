Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure


Partial Public Class AccountSetupForm_Print
    Inherits Webvantage.BasePrintSendPage

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0

    Public ReadOnly Property CurrentPageMode As PageMode
        Get

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If IsNumeric(qs.GetValue("mode")) = True Then

                Return CType(qs.GetValue("mode"), BasePrintSendPage.PageMode)

            Else

                Return PageMode.Options

            End If

        End Get
    End Property

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

        Dim job As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            job = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)
            If job IsNot Nothing Then
                Me.Label.Text = Me._JobNumber.ToString.PadLeft(6, "0") & "/" & Me._JobComponentNumber.ToString.PadLeft(2, "0") & " - " & job.Description
            End If

        End Using

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub AccountSetupRG_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles AccountSetupRG.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)



        End If
    End Sub

    Private Sub AccountSetupRG_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles AccountSetupRG.NeedDataSource
        Try
            Try
                Dim oA As cAgency = New cAgency(CStr(Session("ConnString")))
                Dim AccountSetupForm As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
                Dim Client As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
                Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
                Dim Product As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

                'Set the datasource:
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountSetupForm = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByJobandComponent(DbContext, _JobNumber, _JobComponentNumber).ToList
                    Client = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList
                    Division = AdvantageFramework.Database.Procedures.Division.Load(DbContext).ToList
                    Product = AdvantageFramework.Database.Procedures.Product.Load(DbContext).ToList

                    Me.AccountSetupRG.DataSource = (From a In AccountSetupForm
                                                    Join p In Product On a.ClientCode Equals p.ClientCode And a.DivisionCode Equals p.DivisionCode And a.ProductCode Equals p.Code
                                                    Join d In Division On d.ClientCode Equals p.ClientCode And d.Code Equals p.DivisionCode
                                                    Join c In Client On c.Code Equals d.ClientCode
                                                    Select New With {.ID = a.ID,
                                                                    .JobNumber = a.JobNumber,
                                                                    .JobComponentNumber = a.JobComponentNumber,
                                                                    .ClientCode = a.ClientCode,
                                                                    .ClientName = c.Name,
                                                                    .DivisionCode = a.DivisionCode,
                                                                    .DivisionName = d.Name,
                                                                    .ProductCode = a.ProductCode,
                                                                    .ProductName = p.Name,
                                                                    .AccountSetupCode1 = a.AccountSetupCode1,
                                                                    .AccountSetupCode2 = a.AccountSetupCode2,
                                                                    .AccountSetupCode3 = a.AccountSetupCode3,
                                                                    .AccountSetupCode4 = a.AccountSetupCode4,
                                                                    .PercentSplit = a.PercentSplit,
                                                                    .Balanced = a.Balanced}).ToList()
                End Using

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AccountSetupForm_Print_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Select Case Me.CurrentPageMode
                Case PageMode.Print

                    Dim cScript2 As String
                    cScript2 = "<script>window.print();</script>"
                    RegisterStartupScript("page55", cScript2)
                    Me.CloseThisWindow()

                Case PageMode.SendAlert

                    Me.SendAlert()
                    Me.CloseThisWindow()

                Case PageMode.SendAssignment

                    Me.SendAlert(False, True)
                    Me.CloseThisWindow()

                Case PageMode.SendEmail

                    Me.SendAlert(True, False)
                    Me.CloseThisWindow()

                Case Else

            End Select


            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "AccountSetup" & AdvantageFramework.StringUtilities.GUID_Date()
                Me.AccountSetupRG.MasterTableView.Caption = "Account Setup "
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.AccountSetupRG, str,, False)
                AccountSetupRG.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AccountSetupRG_PreRender(sender As Object, e As EventArgs) Handles AccountSetupRG.PreRender
        Try
            Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Dim header As GridHeaderItem = TryCast(AccountSetupRG.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
            If Not header Is Nothing Then

                header("GridBoundColumnAccountSetupCode1").Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_1, "")
                header("GridBoundColumnAccountSetupCode2").Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_2, "")
                header("GridBoundColumnAccountSetupCode3").Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_3, "")
                header("GridBoundColumnAccountSetupCode4").Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_4, "")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)
        Try

            Session("JobOrderFormJobNum") = Me._JobNumber
            Session("JobOrderFormJobCompNum") = Me._JobComponentNumber

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.JobNumber = Me._JobNumber
            qs.JobComponentNumber = Me._JobComponentNumber

            If IsAssignment = True Then 'assignment switch overrides email switch

                qs.Add("eml", "0")
                qs.Add("assn", "1")

            Else

                qs.Add("assn", "0")
                If AsEmail = True Then

                    qs.Add("eml", "1")

                Else

                    qs.Add("eml", "0")

                End If

            End If

            qs.Add("send", "1")
            qs.Add("caller", "JobTemplatePrint")
            qs.Add("pagetype", "jt")
            qs.Add("f", MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket).ToString())

            Me.OpenWindow(qs)

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub
End Class
