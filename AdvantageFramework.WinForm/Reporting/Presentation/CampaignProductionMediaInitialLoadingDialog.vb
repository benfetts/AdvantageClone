Namespace Reporting.Presentation

    Public Class CampaignProductionMediaInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub
        Private Sub LoadCampaigns()

            Dim ClientCode As String

            ClientCode = ComboBox_Clients.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If CheckBoxForm_Closed.Checked = False Then


                    ComboBoxForm_CampaignFrom.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCodeActive(DbContext, ClientCode).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                            Select New With {.ID = Entity.ID,
                                                                             .Name = Entity.Code & " - " & Entity.Name}).ToList

                    ComboBoxForm_CampaignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCodeActive(DbContext, ClientCode).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                          Select New With {.ID = Entity.ID,
                                                                           .Name = Entity.Code & " - " & Entity.Name}).ToList

                Else

                    ComboBoxForm_CampaignFrom.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, ClientCode).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                            Select New With {.ID = Entity.ID,
                                                                             .Name = Entity.Code & " - " & Entity.Name}).ToList

                    ComboBoxForm_CampaignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, ClientCode).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                          Select New With {.ID = Entity.ID,
                                                                           .Name = Entity.Code & " - " & Entity.Name}).ToList

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim CampaignProductionMediaInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.CampaignProductionMediaInitialLoadingDialog = Nothing

            CampaignProductionMediaInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.CampaignProductionMediaInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = CampaignProductionMediaInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = CampaignProductionMediaInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CampaignProductionMediaInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_CampaignFrom.DisplayMember = "Name"
            ComboBoxForm_CampaignFrom.ValueMember = "ID"

            ComboBoxForm_CampaignTo.DisplayMember = "Name"
            ComboBoxForm_CampaignTo.ValueMember = "ID"

            ComboBox_Clients.DisplayMember = "Name"
            ComboBox_Clients.ValueMember = "Code"

            ComboBoxForm_CampaignFrom.SetRequired(True)
            ComboBoxForm_CampaignTo.SetRequired(True)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            If _ParameterDictionary IsNot Nothing Then

                CheckBoxForm_Closed.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString) = 1, True, False)

            Else

                CheckBoxForm_Closed.Checked = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBox_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)

                End Using

            End Using

            LoadCampaigns()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                Dim campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.ClientCode.ToString) = ComboBox_Clients.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDFrom.ToString) = ComboBoxForm_CampaignFrom.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDTo.ToString) = ComboBoxForm_CampaignTo.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.IncludeClosed.ToString) = IIf(CheckBoxForm_Closed.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.UseCampaignMasterJobEstimate.ToString) = IIf(CheckBox_CampaignMasterJob.Checked, 1, 0)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxForm_Closed_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_Closed.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadCampaigns()

            End If

        End Sub

        Private Sub ComboBox_Clients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Clients.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadCampaigns()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace