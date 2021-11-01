Public Class Campaign_ChangeCode
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _CampaignID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Private Sub Campaign_ChangeCode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Try

            If Request.QueryString("CampaignID") IsNot Nothing Then

                _CampaignID = CType(Request.QueryString("CampaignID"), Integer)

            End If

        Catch ex As Exception
            _CampaignID = 0
        End Try

        Me.Title = "Update Campaign Code"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                If Campaign IsNot Nothing Then

                    TextBoxCode.Text = Campaign.Code

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarCampaign_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCampaign.ButtonClick

        'objects
        Dim CampaignCode As String = ""
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                    If Campaign IsNot Nothing Then

                        CampaignCode = TextBoxCode.Text

                        If CampaignCode <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(CampaignCode) Then

                            AdvantageFramework.Navigation.ShowMessageBox("Please enter a valid code.")

                        ElseIf CampaignCode = "" Then

                            AdvantageFramework.Navigation.ShowMessageBox("Please enter a code.")

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext)
                                Where Entity.ID <> Campaign.ID AndAlso
                                        Entity.Code.ToUpper = CampaignCode.ToUpper AndAlso
                                        Entity.ClientCode = Campaign.ClientCode AndAlso
                                        Entity.DivisionCode = Campaign.DivisionCode AndAlso
                                        Entity.ProductCode = Campaign.ProductCode
                                Select Entity).Any Then

                            AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique campaign code.")

                        Else

                            Campaign.Code = CampaignCode

                            If AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign) Then

                                Me.CloseThisWindowAndRefreshCaller("Campaign.aspx?cmp=" & _CampaignID, True, True)

                            End If

                        End If

                    End If

                End Using

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class