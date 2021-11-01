Namespace Maintenance

    Public Class PurchaseOrderApprovalRuleReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderApprovalRuleReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelGroupHeader_RuleDescription_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_RuleDescription.BeforePrint

            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim POApprovalRuleCode As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                POApprovalRuleCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).PurchaseOrderApprovalRuleCode

                PurchaseOrderApprovalRule = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, POApprovalRuleCode)

                If PurchaseOrderApprovalRule IsNot Nothing Then

                    LabelGroupHeader_RuleDescription.Text = PurchaseOrderApprovalRule.Description

                End If

            End Using

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub

#End Region

#End Region

    End Class

End Namespace
