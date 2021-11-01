Namespace ProjectManagement.Presentation

    Public Class CreateBudgetDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CampaignID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef CampaignID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _CampaignID = CampaignID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef CampaignID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim CreateBudgetDialog As AdvantageFramework.ProjectManagement.Presentation.CreateBudgetDialog = Nothing

            CreateBudgetDialog = New AdvantageFramework.ProjectManagement.Presentation.CreateBudgetDialog(CampaignID)

            ShowFormDialog = CreateBudgetDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CreateBudgetDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                If Campaign Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("The campaign you are trying to create a budget for does not exits anymore.")

                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Create.Click

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim BeginPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim BillingBudgetAmount As Decimal = 0
            Dim IncomeBudgetAmount As Decimal = 0
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim PostPeriodCount As Integer = 0

            If TextBoxForm_BeginPostPeriod.Text <> "" Then

                If Me.Validator Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Try

                                BeginPostPeriod = TextBoxForm_BeginPostPeriod.Tag

                            Catch ex As Exception
                                BeginPostPeriod = Nothing
                            End Try

                            If BeginPostPeriod IsNot Nothing Then

                                Try

                                    Campaign = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Include("CampaignDetails")
                                                Where Entity.ID = _CampaignID
                                                Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    If AdvantageFramework.Navigation.ShowMessageBox("The current budget detail will be cleared prior to creating new budget rows." & vbCrLf & "Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                        For Each CampDetail In Campaign.CampaignDetails.ToList

                                            AdvantageFramework.Database.Procedures.CampaignDetail.Delete(DbContext, CampDetail)

                                        Next

                                        PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).Where(Function(PostPrd) PostPrd.StartDate >= BeginPostPeriod.StartDate).ToList

                                        If Campaign.BillingBudgetAmount.GetValueOrDefault(0) > 0 Then

                                            Try

                                                BillingBudgetAmount = CDec(FormatNumber(Campaign.BillingBudgetAmount.GetValueOrDefault(0) / PostPeriods.Count, 2))

                                            Catch ex As Exception
                                                BillingBudgetAmount = 0
                                            End Try

                                        End If

                                        If Campaign.IncomeBudgetAmount.GetValueOrDefault(0) > 0 Then

                                            Try

                                                IncomeBudgetAmount = CDec(FormatNumber(Campaign.IncomeBudgetAmount.GetValueOrDefault(0) / PostPeriods.Count, 2))

                                            Catch ex As Exception
                                                IncomeBudgetAmount = 0
                                            End Try

                                        End If

                                        For Each PostPeriod In PostPeriods.ToList

                                            If PostPeriodCount < NumericInputForm_MaxPeriods.Value Then

                                                CampaignDetail = New AdvantageFramework.Database.Entities.CampaignDetail

                                                CampaignDetail.DbContext = DbContext

                                                CampaignDetail.CampaignID = _CampaignID
                                                CampaignDetail.PostPeriodCode = PostPeriod.Code
                                                CampaignDetail.BillingBudgetAmount = BillingBudgetAmount
                                                CampaignDetail.IncomeBudgetAmount = IncomeBudgetAmount

                                                AdvantageFramework.Database.Procedures.CampaignDetail.Insert(DbContext, CampaignDetail)

                                                PostPeriodCount += 1

                                            End If

                                        Next

                                        Me.DialogResult = Windows.Forms.DialogResult.OK
                                        Me.Close()

                                    Else

                                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                                        Me.Close()

                                    End If

                                Else

                                    Me.CloseWaitForm()

                                    AdvantageFramework.WinForm.MessageBox.Show("The campaign you are trying to create a budget for does not exits anymore.")

                                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                                    Me.Close()

                                End If

                            Else

                                Me.CloseWaitForm()

                                AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid post period code.")

                                TextBoxForm_BeginPostPeriod.Focus()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid post period code.")

                TextBoxForm_BeginPostPeriod.Focus()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace