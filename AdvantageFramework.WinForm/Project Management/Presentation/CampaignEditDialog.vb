Namespace ProjectManagement.Presentation

    Public Class CampaignEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CampaignID As Integer = Nothing
        Private _CDPRequired As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property CampaignID As String
            Get
                CampaignID = _CampaignID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef CampaignID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _CampaignID = CampaignID

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                           Where Division.ClientCode = ClientCode
                                                           Select Division

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Product.DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                          Where Product.ClientCode = ClientCode AndAlso
                                                                Product.DivisionCode = DivisionCode
                                                          Select Product

                    End Using

                End Using

            End If

        End Sub
        Private Sub SetProduct()

            If _CDPRequired = False Then

                ComboBoxForm_Product.Enabled = ComboBoxForm_Division.HasASelectedValue

            End If

            If ComboBoxForm_Product.Items.Count > 0 Then

                ComboBoxForm_Product.SelectedIndex = 0

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef CampaignID As Integer = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim CampaignEditDialog As AdvantageFramework.ProjectManagement.Presentation.CampaignEditDialog = Nothing

            CampaignEditDialog = New AdvantageFramework.ProjectManagement.Presentation.CampaignEditDialog(CampaignID)

            ShowFormDialog = CampaignEditDialog.ShowDialog()

            CampaignID = CampaignEditDialog.CampaignID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CampaignEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.Code)
                    TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.Name)

                    ComboBoxForm_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.ClientCode)

                    If _CampaignID <> 0 Then

                        Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                        If Campaign IsNot Nothing Then

                            ComboBoxForm_Office.Enabled = False
                            ComboBoxForm_Client.Enabled = False
                            ComboBoxForm_Division.Enabled = False
                            ComboBoxForm_Product.Enabled = False

                            ComboBoxForm_Office.Text = Campaign.Office.ToString
                            ComboBoxForm_Client.Text = Campaign.Client.ToString
                            ComboBoxForm_Division.Text = Campaign.Division.ToString
                            ComboBoxForm_Product.Text = Campaign.Product.ToString

                            TextBoxForm_Code.Enabled = False

                            TextBoxForm_Code.Text = Campaign.Code
                            TextBoxForm_Name.Text = Campaign.Name

                            ComboBoxForm_AlertGroup.Enabled = False

                            ComboBoxForm_AlertGroup.Text = Campaign.AlertGroupCode

                            RadioButtonForm_AssignedToJobsAndOrders.Enabled = False
                            RadioButtonForm_Overall.Enabled = False

                            ButtonForm_Add.Visible = False
                            ButtonForm_Update.Visible = True
                            Me.Text = "Edit Campaign"

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The campaign you are trying to edit does not exist anymore.")

                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                            Me.Close()

                        End If

                    Else

                        ButtonForm_Add.Visible = True
                        ButtonForm_Update.Visible = False
                        Me.Text = "Add Campaign"

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CAMP_AUTO_GEN_CODE.ToString)

                        If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                            If AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Any = False Then

                                TextBoxForm_Code.Text = "1"

                            Else

                                TextBoxForm_Code.Text = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Select(Function(Entity) Entity.ID).Max + 1

                            End If

                        End If

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CAMP_REQUIRE_DIV_PRD.ToString)

                        If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                            _CDPRequired = True

                            ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                            ComboBoxForm_Division.SetRequired(True)
                            ComboBoxForm_Division.Enabled = True

                            ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
                            ComboBoxForm_Product.SetRequired(True)
                            ComboBoxForm_Product.Enabled = True

                        End If

                        ComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)

                        ComboBoxForm_AlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)

                        End Using

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Campaign = New AdvantageFramework.Database.Entities.Campaign

                    Campaign.DbContext = DbContext

                    Campaign.Code = TextBoxForm_Code.Text
                    Campaign.Name = TextBoxForm_Name.Text

                    Campaign.OfficeCode = ComboBoxForm_Office.GetSelectedValue
                    Campaign.ClientCode = ComboBoxForm_Client.GetSelectedValue
                    Campaign.DivisionCode = ComboBoxForm_Division.GetSelectedValue
                    Campaign.ProductCode = ComboBoxForm_Product.GetSelectedValue

                    Campaign.AlertGroupCode = ComboBoxForm_AlertGroup.GetSelectedValue

                    Campaign.CampaignType = If(RadioButtonForm_AssignedToJobsAndOrders.Checked, AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders, AdvantageFramework.Database.Entities.CampaignTypes.Overall)

                    Campaign.IsClosed = 0

                    If AdvantageFramework.Database.Procedures.Campaign.Insert(DbContext, Campaign) Then

                        _CampaignID = Campaign.ID

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)



                End Using

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Client.HasASelectedValue Then

                LoadDivisions()

            End If

            If _CDPRequired = False Then

                ComboBoxForm_Division.Enabled = ComboBoxForm_Client.HasASelectedValue

            End If

            If ComboBoxForm_Division.Items.Count > 0 Then

                ComboBoxForm_Division.SelectedIndex = 0

            End If

            SetProduct()

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Division.HasASelectedValue Then

                LoadProducts()

            End If

            SetProduct()

        End Sub

#End Region

#End Region

    End Class

End Namespace