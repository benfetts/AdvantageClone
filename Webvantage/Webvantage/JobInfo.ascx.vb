Public Class JobInfo_Tooltip
    Inherits BaseUserControl


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property JobNumber As Integer
        Get

            If ViewState("JobNumber") Is Nothing Then ViewState("JobNumber") = 0
            Return ViewState("JobNumber")

        End Get
        Set(value As Integer)

            ViewState("JobNumber") = value

        End Set
    End Property
    Public Property JobComponentNumber As Integer
        Get

            If ViewState("JobComponentNumber") Is Nothing Then ViewState("JobComponentNumber") = 0
            Return ViewState("JobComponentNumber")

        End Get
        Set(value As Integer)

            ViewState("JobComponentNumber") = value

        End Set
    End Property
    Public Property AlertID As Integer
        Get

            If ViewState("AlertID") Is Nothing Then ViewState("AlertID") = 0
            Return ViewState("AlertID")

        End Get
        Set(value As Integer)

            ViewState("AlertID") = value

        End Set
    End Property
    Public Property ConceptShareProjectID As Integer
        Get

            If ViewState("ConceptShareProjectID") Is Nothing Then ViewState("ConceptShareProjectID") = 0
            Return ViewState("ConceptShareProjectID")

        End Get
        Set(value As Integer)

            ViewState("ConceptShareProjectID") = value

        End Set
    End Property
    Public Property ConceptShareReviewID As Integer
        Get

            If ViewState("ConceptShareReviewID") Is Nothing Then ViewState("ConceptShareReviewID") = 0
            Return ViewState("ConceptShareReviewID")

        End Get
        Set(value As Integer)

            ViewState("ConceptShareReviewID") = value

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub JobInfo_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString

        qs = qs.FromCurrent

        If IsNumeric(qs.JobNumber) Then Me.JobNumber = qs.JobNumber
        If IsNumeric(qs.JobComponentNumber) Then Me.JobComponentNumber = qs.JobComponentNumber
        If IsNumeric(qs.AlertID) Then Me.AlertID = qs.AlertID
        If IsNumeric(qs.ConceptShareProjectID) Then Me.ConceptShareProjectID = qs.ConceptShareProjectID
        If IsNumeric(qs.ConceptShareReviewID) Then Me.ConceptShareReviewID = qs.ConceptShareReviewID

    End Sub
    Private Sub JobInfo_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

            Me.DivOffice.Visible = False
            Me.DivClient.Visible = False
            Me.DivDivision.Visible = False
            Me.DivProduct.Visible = False
            Me.DivCampaign.Visible = False
            Me.DivJob.Visible = False
            Me.DivJobComponent.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                Dim JobInfo As AdvantageFramework.ConceptShare.Classes.JobInfo

                JobInfo = Nothing
                JobInfo = DbContext.Database.SqlQuery(Of AdvantageFramework.ConceptShare.Classes.JobInfo)(String.Format("EXEC [dbo].[advsp_cs_load_basic_job_info] {0}, {1}, {2}, {3}, {4};",
                                                                                                                        Me.JobNumber, Me.JobComponentNumber,
                                                                                                                        Me.AlertID,
                                                                                                                        Me.ConceptShareProjectID, Me.ConceptShareReviewID)).FirstOrDefault

                If JobInfo IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(JobInfo.OfficeDisplay) = False Then

                        Me.DivOffice.Visible = True
                        Me.LabelOffice.Text = JobInfo.OfficeDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.ClientDisplay) = False Then

                        Me.DivClient.Visible = True
                        Me.LabelClient.Text = JobInfo.ClientDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.DivisionDisplay) = False Then

                        Me.DivDivision.Visible = True
                        Me.LabelDivision.Text = JobInfo.DivisionDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.ProductDisplay) = False Then

                        Me.DivProduct.Visible = True
                        Me.LabelProduct.Text = JobInfo.ProductDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.CampaignDisplay) = False Then

                        Me.DivCampaign.Visible = True
                        Me.LabelCampaign.Text = JobInfo.CampaignDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.JobDisplay) = False Then

                        Me.DivJob.Visible = True
                        Me.LinkButtonJob.Text = JobInfo.JobDisplay

                    End If
                    If String.IsNullOrWhiteSpace(JobInfo.JobComponentDisplay) = False Then

                        Me.DivJobComponent.Visible = True
                        Me.LinkButtonJobComponent.Text = JobInfo.JobComponentDisplay

                    End If

                End If

            End Using

        End If

    End Sub

#End Region

#End Region

End Class