Namespace WinForm.Presentation.Controls

    Public Class CreativeBriefTemplateControl

        Public Event SelectedTabChanged()
        Public Event InactiveChangedEvent(ByVal Inactive As Boolean, ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _CreativeBriefTemplateID As Integer = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasASelectedLevel() As Boolean
            Get
                HasASelectedLevel = TreeListControlDetail_Levels.HasASelectedNode
            End Get
        End Property
        Public ReadOnly Property DetailTabSelected() As Boolean
            Get
                DetailTabSelected = If(TabControlControl_CreativeBriefTemplateSetup.SelectedTab Is TabItemCreativeBriefTemplateSetup_DetailTab, True, False)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).IsFormModal = False Then

                        TreeListControlDetail_Levels.Size = New System.Drawing.Size(TreeListControlDetail_Levels.Size.Width, TreeListControlDetail_Levels.Size.Height + 26)

                        ButtonDetail_AddLevel.Visible = False
                        ButtonDetail_DeleteLevel.Visible = False

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TreeListControlDetail_Levels.BypassChangedOnAddAndDeleteNode = True

                            CheckBoxHeader_Inactive.ByPassUserEntryChanged = True

                            PanelForm_TopPanel.Visible = False

                            TextBoxHeader_Code.SetPropertySettings(AdvantageFramework.Database.Entities.CreativeBriefTemplate.Properties.Code)
                            TextBoxHeader_Name.SetPropertySettings(AdvantageFramework.Database.Entities.CreativeBriefTemplate.Properties.Description)

                            SetNumericInputProperties(NumericInputLevelOneStyle_Size)
                            SetNumericInputProperties(NumericInputLevelTwoStyle_Size)
                            SetNumericInputProperties(NumericInputLevelThreeStyle_Size)
                            SetNumericInputProperties(NumericInputDetailLevelStyle_Size)

                            CreateTreeListColumns()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub SetNumericInputProperties(ByVal NumericInput As AdvantageFramework.WinForm.Presentation.Controls.NumericInput)

            NumericInput.Properties.MinValue = CShort(8)
            NumericInput.Properties.MaxValue = CShort(12)
            NumericInput.Value = CShort(8)
            NumericInput.Properties.MaxLength = CInt(2)

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.CreativeBriefTemplate

            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing

            Try

                If IsNew Then

                    CreativeBriefTemplate = New AdvantageFramework.Database.Entities.CreativeBriefTemplate

                    LoadCreativeBriefTemplateEntity(CreativeBriefTemplate, True)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        CreativeBriefTemplate = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.LoadByID(DbContext, _CreativeBriefTemplateID)

                        If CreativeBriefTemplate IsNot Nothing Then

                            LoadCreativeBriefTemplateEntity(CreativeBriefTemplate, False)

                        End If

                    End Using

                End If

            Catch ex As Exception
                CreativeBriefTemplate = Nothing
            End Try

            FillObject = CreativeBriefTemplate

        End Function
        Private Sub LoadCreativeBriefTemplateEntity(ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate, ByVal IsNew As Boolean)

            If CreativeBriefTemplate IsNot Nothing Then

                SaveHeaderTab(CreativeBriefTemplate)

            End If

        End Sub
        Private Function LoadSelectedCreativeBriefTemplate() As AdvantageFramework.Database.Entities.CreativeBriefTemplate

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadSelectedCreativeBriefTemplate = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.LoadByID(DbContext, _CreativeBriefTemplateID)

                End Using

            Catch ex As Exception
                LoadSelectedCreativeBriefTemplate = Nothing
            End Try

        End Function
        Private Sub LoadCreativeBriefTemplateDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing

            If _CreativeBriefTemplateID <> Nothing Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_CreativeBriefTemplateSetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_CreativeBriefTemplateSetup.SelectedTab

                End If

                If TabItem.Tag = False Then

                    CreativeBriefTemplate = LoadSelectedCreativeBriefTemplate()

                    If CreativeBriefTemplate IsNot Nothing Then

                        LoadHeaderTab(CreativeBriefTemplate)

                        LoadDetailTab(CreativeBriefTemplate)

                    End If

                End If

            End If

        End Sub
        Private Sub LoadHeaderTab(ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate)

            If CreativeBriefTemplate IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TextBoxHeader_Name.Text = CreativeBriefTemplate.Description

                    CheckBoxHeader_Inactive.Checked = CBool(CreativeBriefTemplate.IsInactive.GetValueOrDefault(0))

                    CheckBoxColumn1_Client.Checked = CBool(CreativeBriefTemplate.ShowClient.GetValueOrDefault(0))
                    CheckBoxColumn1_Division.Checked = CBool(CreativeBriefTemplate.ShowDivision.GetValueOrDefault(0))
                    CheckBoxColumn1_Product.Checked = CBool(CreativeBriefTemplate.ShowProduct.GetValueOrDefault(0))

                    CheckBoxColumn2_ClientAddress.Checked = CBool(CreativeBriefTemplate.ShowClientAddress.GetValueOrDefault(0))
                    CheckBoxColumn2_DivisionAddress.Checked = CBool(CreativeBriefTemplate.ShowDivisionAddress.GetValueOrDefault(0))
                    CheckBoxColumn2_ProductAddress.Checked = CBool(CreativeBriefTemplate.ShowProductAddress.GetValueOrDefault(0))

                    CheckBoxColumn3_JobNumber.Checked = CBool(CreativeBriefTemplate.ShowJobNumber.GetValueOrDefault(0))
                    CheckBoxColumn3_ComponentNumber.Checked = CBool(CreativeBriefTemplate.ShowJobComponentNumber.GetValueOrDefault(0))
                    CheckBoxColumn3_AccountExecutive.Checked = CBool(CreativeBriefTemplate.ShowAccountExecutive.GetValueOrDefault(0))

                    CheckBoxColumn4_JobDescription.Checked = CBool(CreativeBriefTemplate.ShowJobDescription.GetValueOrDefault(0))
                    CheckBoxColumn4_ComponentDescription.Checked = CBool(CreativeBriefTemplate.ShowJobComponentDescription.GetValueOrDefault(0))
                    CheckBoxColumn4_ClientReference.Checked = CBool(CreativeBriefTemplate.ShowClientRef.GetValueOrDefault(0))

                    CheckBoxColumn1_DateOpened.Checked = CBool(CreativeBriefTemplate.ShowDateOpened.GetValueOrDefault(0))
                    CheckBoxColumn1_Campaign.Checked = CBool(CreativeBriefTemplate.ShowCampaign.GetValueOrDefault(0))

                    CheckBoxColumn2_Budget.Checked = CBool(CreativeBriefTemplate.ShowBudget.GetValueOrDefault(0))
                    CheckBoxColumn2_ApprovedEstimateRequired.Checked = CBool(CreativeBriefTemplate.ShowApprovedEstimateRequired.GetValueOrDefault(0))
                    CheckBoxColumn2_RushChargesApproved.Checked = CBool(CreativeBriefTemplate.ShowRushChargesApproved.GetValueOrDefault(0))

                    CheckBoxColumn3_DepartmentTeam.Checked = CBool(CreativeBriefTemplate.ShowTeam.GetValueOrDefault(0))
                    CheckBoxColumn3_DueDate.Checked = CBool(CreativeBriefTemplate.ShowDueDate.GetValueOrDefault(0))
                    CheckBoxColumn3_OpenedBy.Checked = CBool(CreativeBriefTemplate.ShowOpenedBy.GetValueOrDefault(0))

                    CheckBoxLevelOneStyle_Bold.Checked = IsLevelStyleBold(CreativeBriefTemplate.Level1Style)
                    CheckBoxLevelOneStyle_Italic.Checked = IsLevelStyleItalic(CreativeBriefTemplate.Level1Style)
                    CheckBoxLevelOneStyle_Underline.Checked = IsLevelStyleUnderline(CreativeBriefTemplate.Level1Style)
                    CheckBoxLevelOneStyle_Bullet.Checked = IsLevelStyleBullet(CreativeBriefTemplate.Level1Style)
                    NumericInputLevelOneStyle_Size.Value = LoadLevelSize(CreativeBriefTemplate.Level1Style)

                    CheckBoxLevelTwoStyle_Bold.Checked = IsLevelStyleBold(CreativeBriefTemplate.Level2Style)
                    CheckBoxLevelTwoStyle_Italic.Checked = IsLevelStyleItalic(CreativeBriefTemplate.Level2Style)
                    CheckBoxLevelTwoStyle_Underline.Checked = IsLevelStyleUnderline(CreativeBriefTemplate.Level2Style)
                    CheckBoxLevelTwoStyle_Bullet.Checked = IsLevelStyleBullet(CreativeBriefTemplate.Level2Style)
                    NumericInputLevelTwoStyle_Size.Value = LoadLevelSize(CreativeBriefTemplate.Level2Style)

                    CheckBoxLevelThreeStyle_Bold.Checked = IsLevelStyleBold(CreativeBriefTemplate.Level3Style)
                    CheckBoxLevelThreeStyle_Italic.Checked = IsLevelStyleItalic(CreativeBriefTemplate.Level3Style)
                    CheckBoxLevelThreeStyle_Underline.Checked = IsLevelStyleUnderline(CreativeBriefTemplate.Level3Style)
                    CheckBoxLevelThreeStyle_Bullet.Checked = IsLevelStyleBullet(CreativeBriefTemplate.Level3Style)
                    NumericInputLevelThreeStyle_Size.Value = LoadLevelSize(CreativeBriefTemplate.Level3Style)

                    CheckBoxDetailLevelStyle_Bold.Checked = IsLevelStyleBold(CreativeBriefTemplate.DetailLevelStyle)
                    CheckBoxDetailLevelStyle_Italic.Checked = IsLevelStyleItalic(CreativeBriefTemplate.DetailLevelStyle)
                    CheckBoxDetailLevelStyle_Underline.Checked = IsLevelStyleUnderline(CreativeBriefTemplate.DetailLevelStyle)
                    CheckBoxDetailLevelStyle_Bullet.Checked = IsLevelStyleBullet(CreativeBriefTemplate.DetailLevelStyle)
                    NumericInputDetailLevelStyle_Size.Value = LoadLevelSize(CreativeBriefTemplate.DetailLevelStyle)

                End Using

                TabItemCreativeBriefTemplateSetup_HeaderTab.Tag = True

            End If

        End Sub
        Private Sub LoadDetailTab(ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate)

            If CreativeBriefTemplate IsNot Nothing Then

                LoadTreeListItems()

                TabItemCreativeBriefTemplateSetup_DetailTab.Tag = True

            End If

        End Sub
        Private Sub SaveHeaderTab(ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate)

            If CreativeBriefTemplate IsNot Nothing Then

                CreativeBriefTemplate.Code = TextBoxHeader_Code.Text
                CreativeBriefTemplate.Description = TextBoxHeader_Name.Text
                CreativeBriefTemplate.IsInactive = Convert.ToInt16(CheckBoxHeader_Inactive.Checked)
                CreativeBriefTemplate.ShowClient = Convert.ToInt16(CheckBoxColumn1_Client.Checked)
                CreativeBriefTemplate.ShowDivision = Convert.ToInt16(CheckBoxColumn1_Division.Checked)
                CreativeBriefTemplate.ShowProduct = Convert.ToInt16(CheckBoxColumn1_Product.Checked)
                CreativeBriefTemplate.ShowClientAddress = Convert.ToInt16(CheckBoxColumn2_ClientAddress.Checked)
                CreativeBriefTemplate.ShowDivisionAddress = Convert.ToInt16(CheckBoxColumn2_DivisionAddress.Checked)
                CreativeBriefTemplate.ShowProductAddress = Convert.ToInt16(CheckBoxColumn2_ProductAddress.Checked)
                CreativeBriefTemplate.ShowJobNumber = Convert.ToInt16(CheckBoxColumn3_JobNumber.Checked)
                CreativeBriefTemplate.ShowJobComponentNumber = Convert.ToInt16(CheckBoxColumn3_ComponentNumber.Checked)
                CreativeBriefTemplate.ShowAccountExecutive = Convert.ToInt16(CheckBoxColumn3_AccountExecutive.Checked)
                CreativeBriefTemplate.ShowJobDescription = Convert.ToInt16(CheckBoxColumn4_JobDescription.Checked)
                CreativeBriefTemplate.ShowJobComponentDescription = Convert.ToInt16(CheckBoxColumn4_ComponentDescription.Checked)
                CreativeBriefTemplate.ShowClientRef = Convert.ToInt16(CheckBoxColumn4_ClientReference.Checked)
                CreativeBriefTemplate.ShowDateOpened = Convert.ToInt16(CheckBoxColumn1_DateOpened.Checked)
                CreativeBriefTemplate.ShowCampaign = Convert.ToInt16(CheckBoxColumn1_Campaign.Checked)
                CreativeBriefTemplate.ShowBudget = Convert.ToInt16(CheckBoxColumn2_Budget.Checked)
                CreativeBriefTemplate.ShowApprovedEstimateRequired = Convert.ToInt16(CheckBoxColumn2_ApprovedEstimateRequired.Checked)
                CreativeBriefTemplate.ShowRushChargesApproved = Convert.ToInt16(CheckBoxColumn2_RushChargesApproved.Checked)
                CreativeBriefTemplate.ShowTeam = Convert.ToInt16(CheckBoxColumn3_DepartmentTeam.Checked)
                CreativeBriefTemplate.ShowDueDate = Convert.ToInt16(CheckBoxColumn3_DueDate.Checked)
                CreativeBriefTemplate.ShowOpenedBy = Convert.ToInt16(CheckBoxColumn3_OpenedBy.Checked)

                CreativeBriefTemplate.Level1Style = BuildLevelString(CheckBoxLevelOneStyle_Italic.Checked, CheckBoxLevelOneStyle_Underline.Checked,
                                                                     CheckBoxLevelOneStyle_Bullet.Checked, CheckBoxLevelOneStyle_Bold.Checked,
                                                                     NumericInputLevelOneStyle_Size.Value)

                CreativeBriefTemplate.Level2Style = BuildLevelString(CheckBoxLevelTwoStyle_Italic.Checked, CheckBoxLevelTwoStyle_Underline.Checked,
                                                                     CheckBoxLevelTwoStyle_Bullet.Checked, CheckBoxLevelTwoStyle_Bold.Checked,
                                                                     NumericInputLevelTwoStyle_Size.Value)

                CreativeBriefTemplate.Level3Style = BuildLevelString(CheckBoxLevelThreeStyle_Italic.Checked, CheckBoxLevelThreeStyle_Underline.Checked,
                                                                     CheckBoxLevelThreeStyle_Bullet.Checked, CheckBoxLevelThreeStyle_Bold.Checked,
                                                                     NumericInputLevelThreeStyle_Size.Value)

                CreativeBriefTemplate.DetailLevelStyle = BuildLevelString(CheckBoxDetailLevelStyle_Italic.Checked, CheckBoxDetailLevelStyle_Underline.Checked,
                                                                          CheckBoxDetailLevelStyle_Bullet.Checked, CheckBoxDetailLevelStyle_Bold.Checked,
                                                                          NumericInputDetailLevelStyle_Size.Value)

            End If

        End Sub
        Private Sub LoadTreeListItems()

            'objects
            Dim Level1TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level2TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level3TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim ParentTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing

            TreeListControlDetail_Levels.BeginUnboundLoad()

            If _CreativeBriefTemplateID <> Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each CreativeBriefTemplateLevel1 In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.LoadByCreativeBriefTemplateID(DbContext, _CreativeBriefTemplateID)

                        Level1TreeListNode = AppendNode(CreativeBriefTemplateLevel1, ParentTreeListNode)

                        For Each CreativeBriefTemplateLevel2 In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.LoadByCreativeBriefTemplateLevel1ID(DbContext, CreativeBriefTemplateLevel1.ID)

                            Level2TreeListNode = AppendNode(CreativeBriefTemplateLevel2, Level1TreeListNode)

                            For Each CreativeBriefTemplateLevel3 In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.LoadByCreativeBriefTemplateLevel2ID(DbContext, CreativeBriefTemplateLevel2.ID)

                                Level3TreeListNode = AppendNode(CreativeBriefTemplateLevel3, Level2TreeListNode)

                            Next

                        Next

                    Next

                End Using

            Else

                CreativeBriefTemplateLevel1 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 With {.Description = "Level One Description", .OrderNumber = 1}

                Level1TreeListNode = AppendNode(CreativeBriefTemplateLevel1, ParentTreeListNode)

                CreativeBriefTemplateLevel2 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 With {.Description = "Level Two Description", .OrderNumber = 1}

                Level2TreeListNode = AppendNode(CreativeBriefTemplateLevel2, Level1TreeListNode)

                CreativeBriefTemplateLevel3 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 With {.Description = "Level Three Description", .OrderNumber = 1}

                Level3TreeListNode = AppendNode(CreativeBriefTemplateLevel3, Level2TreeListNode)

            End If

            TreeListControlDetail_Levels.EndUnboundLoad()

            TreeListControlDetail_Levels.SetColumnPropertySettings(GetType(AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1))

            TreeListControlDetail_Levels.ExpandAll()

        End Sub
        Private Sub CreateTreeListColumns()

            'objects
            Dim IDTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim DescriptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing

            TreeListControlDetail_Levels.BeginUpdate()

            TreeListControlDetail_Levels.Columns.Clear()
            TreeListControlDetail_Levels.OptionsView.ShowColumns = False

            IDTreeListColumn = TreeListControlDetail_Levels.Columns.Add()
            IDTreeListColumn.Caption = "ID"
            IDTreeListColumn.FieldName = "ID"
            IDTreeListColumn.VisibleIndex = 0
            IDTreeListColumn.Visible = False
            DescriptionTreeListColumn = TreeListControlDetail_Levels.Columns.Add()
            DescriptionTreeListColumn.Caption = "Description"
            DescriptionTreeListColumn.FieldName = "Description"
            DescriptionTreeListColumn.VisibleIndex = 0

            TreeListControlDetail_Levels.EndUpdate()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonDetail_DeleteLevel.Enabled = TreeListControlDetail_Levels.HasOnlyOneSelectedNode
            ButtonDetail_AddLevel.Enabled = TreeListControlDetail_Levels.HasASelectedNode

        End Sub
        Private Function IsLevelStyleBullet(ByVal StyleString As String) As Boolean

            Try

                IsLevelStyleBullet = StyleString.ToUpper.Contains("BULLIT")

            Catch ex As Exception
                IsLevelStyleBullet = False
            End Try

        End Function
        Private Function IsLevelStyleUnderline(ByVal StyleString As String) As Boolean

            Try

                IsLevelStyleUnderline = StyleString.ToUpper.Contains("UNDERLINE")

            Catch ex As Exception
                IsLevelStyleUnderline = False
            End Try

        End Function
        Private Function IsLevelStyleBold(ByVal StyleString As String) As Boolean

            Try

                IsLevelStyleBold = StyleString.ToUpper.Contains("BOLD")

            Catch ex As Exception
                IsLevelStyleBold = False
            End Try

        End Function
        Private Function IsLevelStyleItalic(ByVal StyleString As String) As Boolean

            Try

                IsLevelStyleItalic = StyleString.ToUpper.Contains("ITALIC")

            Catch ex As Exception
                IsLevelStyleItalic = False
            End Try

        End Function
        Private Function LoadLevelSize(ByVal StyleString As String) As Short

            'objects
            Dim LevelSize As Short = Nothing

            Try

                If StyleString.ToUpper.Contains("SIZE") Then

                    LevelSize = CShort(String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(StyleString, "[^\d]")))

                End If

            Catch ex As Exception
                LevelSize = Nothing
            End Try

            LoadLevelSize = LevelSize

        End Function
        Private Function BuildLevelString(ByVal Italic As Boolean, ByVal Underline As Boolean, ByVal Bullet As Boolean, ByVal Bold As Boolean, ByVal Size As Integer) As String

            'objects
            Dim LevelString As String = ""

            Try

                If Italic Then

                    LevelString &= "italic "

                End If

                If Underline Then

                    LevelString &= "underline "

                End If

                If Bullet Then

                    LevelString &= "bullit " ' LEAVE AS bull(i)t NOT bull(e)t !!!

                End If


                If Bold Then

                    LevelString &= "bold "

                End If

                If Size <> Nothing Then

                    LevelString &= "size" & Size.ToString

                End If

            Catch ex As Exception
                LevelString = ""
            End Try

            BuildLevelString = LevelString

        End Function
        Private Function AppendNode(ByVal CreativeBriefTemplateLevel As Object, ByVal ParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode) As DevExpress.XtraTreeList.Nodes.TreeListNode

            'objects
            Dim TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            TreeListNode = TreeListControlDetail_Levels.AppendNode(New Object() {CreativeBriefTemplateLevel.ID, CreativeBriefTemplateLevel.Description}, ParentNode)

            If _IsCopy = False Then

                TreeListNode.Tag = CreativeBriefTemplateLevel

            ElseIf TypeOf CreativeBriefTemplateLevel Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 Then

                TreeListNode.Tag = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1

            ElseIf TypeOf CreativeBriefTemplateLevel Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 Then

                TreeListNode.Tag = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2

            ElseIf TypeOf CreativeBriefTemplateLevel Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 Then

                TreeListNode.Tag = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3

            Else

                TreeListNode.Tag = Nothing

            End If

            AppendNode = TreeListNode

        End Function
        Private Sub SaveDetailLevels(ByVal DbContext As AdvantageFramework.Database.DbContext)

            TreeListControlDetail_Levels.CloseEditor()

            For Each TreeListNode In TreeListControlDetail_Levels.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                SaveDetailLevel(DbContext, TreeListNode)

            Next

        End Sub
        Private Sub SaveDetailLevel(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode)

            'objects
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing

            If TypeOf TreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 Then

                CreativeBriefTemplateLevel1 = DirectCast(TreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1)

                If CreativeBriefTemplateLevel1 IsNot Nothing Then

                    CreativeBriefTemplateLevel1.Description = TreeListNode.GetValue("Description")
                    CreativeBriefTemplateLevel1.OrderNumber = TreeListControlDetail_Levels.GetNodeIndex(TreeListNode) + 1

                    If CreativeBriefTemplateLevel1.IsEntityBeingAdded() = False Then

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.Update(DbContext, CreativeBriefTemplateLevel1)

                    Else

                        CreativeBriefTemplateLevel1.DbContext = DbContext
                        CreativeBriefTemplateLevel1.CreativeBriefTemplateID = _CreativeBriefTemplateID

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.Insert(DbContext, CreativeBriefTemplateLevel1)

                    End If

                    For Each Level2Node In TreeListNode.Nodes

                        SaveDetailLevel(DbContext, Level2Node)

                    Next

                    TreeListNode.Tag = CreativeBriefTemplateLevel1

                End If

            ElseIf TypeOf TreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 Then

                CreativeBriefTemplateLevel2 = DirectCast(TreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2)
                CreativeBriefTemplateLevel1 = DirectCast(TreeListNode.ParentNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1)

                If CreativeBriefTemplateLevel2 IsNot Nothing Then

                    CreativeBriefTemplateLevel2.Description = TreeListNode.GetValue("Description")
                    CreativeBriefTemplateLevel2.OrderNumber = TreeListControlDetail_Levels.GetNodeIndex(TreeListNode) + 1

                    If CreativeBriefTemplateLevel2.IsEntityBeingAdded() = False Then

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.Update(DbContext, CreativeBriefTemplateLevel2)

                    Else

                        CreativeBriefTemplateLevel2.DbContext = DbContext
                        CreativeBriefTemplateLevel2.CreativeBriefTemplateLevel1ID = CreativeBriefTemplateLevel1.ID

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.Insert(DbContext, CreativeBriefTemplateLevel2)

                    End If

                    For Each Level3Node In TreeListNode.Nodes

                        SaveDetailLevel(DbContext, Level3Node)

                    Next

                    TreeListNode.Tag = CreativeBriefTemplateLevel2

                End If

            ElseIf TypeOf TreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 Then

                CreativeBriefTemplateLevel3 = DirectCast(TreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3)
                CreativeBriefTemplateLevel2 = DirectCast(TreeListNode.ParentNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2)

                If CreativeBriefTemplateLevel3 IsNot Nothing Then

                    CreativeBriefTemplateLevel3.Description = TreeListNode.GetValue("Description")
                    CreativeBriefTemplateLevel3.OrderNumber = TreeListControlDetail_Levels.GetNodeIndex(TreeListNode) + 1

                    If CreativeBriefTemplateLevel3.IsEntityBeingAdded() = False Then

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Update(DbContext, CreativeBriefTemplateLevel3)

                    Else

                        CreativeBriefTemplateLevel3.DbContext = DbContext
                        CreativeBriefTemplateLevel3.CreativeBriefTemplateLevel2ID = CreativeBriefTemplateLevel2.ID

                        AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Insert(DbContext, CreativeBriefTemplateLevel3)

                    End If

                    TreeListNode.Tag = CreativeBriefTemplateLevel3

                End If

            End If

        End Sub
        Private Function IsTemplateInUse(ByVal CreativeBriefLevelOrTemplate As Object) As Boolean

            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim Level1IDs As Short() = Nothing
            Dim Level2IDs As Short() = Nothing
            Dim Level3IDs As Short() = Nothing
            Dim InUse As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If TypeOf CreativeBriefLevelOrTemplate Is AdvantageFramework.Database.Entities.CreativeBriefTemplate Then

                        CreativeBriefTemplate = DirectCast(CreativeBriefLevelOrTemplate, AdvantageFramework.Database.Entities.CreativeBriefTemplate)

                        Try

                            Level1IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.LoadByCreativeBriefTemplateID(DbContext, CreativeBriefTemplate.ID)
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level1IDs = Nothing
                        End Try

                        Try

                            Level2IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.Load(DbContext)
                                         Where Level1IDs.Contains(Entity.CreativeBriefTemplateLevel1ID)
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level2IDs = Nothing
                        End Try

                        Try

                            Level3IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Load(DbContext)
                                         Where Level2IDs.Contains(Entity.CreativeBriefTemplateLevel2ID)
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level3IDs = Nothing
                        End Try

                        Try

                            InUse = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefDetail.Load(DbContext)
                                     Where Level3IDs.Contains(Entity.CreativeBriefTemplateLevel3ID)
                                     Select Entity).Any

                        Catch ex As Exception
                            InUse = False
                        End Try

                    ElseIf TypeOf CreativeBriefLevelOrTemplate Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 Then

                        CreativeBriefTemplateLevel1 = DirectCast(CreativeBriefLevelOrTemplate, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1)

                        Try

                            Level2IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.Load(DbContext)
                                         Where Entity.CreativeBriefTemplateLevel1ID = CreativeBriefTemplateLevel1.ID
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level2IDs = Nothing
                        End Try

                        Try

                            Level3IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Load(DbContext)
                                         Where Level2IDs.Contains(Entity.CreativeBriefTemplateLevel2ID)
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level3IDs = Nothing
                        End Try

                        Try

                            InUse = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefDetail.Load(DbContext)
                                     Where Level3IDs.Contains(Entity.CreativeBriefTemplateLevel3ID)
                                     Select Entity).Any

                        Catch ex As Exception
                            InUse = False
                        End Try

                    ElseIf TypeOf CreativeBriefLevelOrTemplate Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 Then

                        CreativeBriefTemplateLevel2 = DirectCast(CreativeBriefLevelOrTemplate, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2)

                        Try

                            Level3IDs = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Load(DbContext)
                                         Where Entity.CreativeBriefTemplateLevel2ID = CreativeBriefTemplateLevel2.ID
                                         Select Entity.ID).ToArray

                        Catch ex As Exception
                            Level3IDs = Nothing
                        End Try

                        Try

                            InUse = (From Entity In AdvantageFramework.Database.Procedures.CreativeBriefDetail.Load(DbContext)
                                     Where Level3IDs.Contains(Entity.CreativeBriefTemplateLevel3ID)
                                     Select Entity).Any

                        Catch ex As Exception
                            InUse = False
                        End Try

                    ElseIf TypeOf CreativeBriefLevelOrTemplate Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 Then

                        CreativeBriefTemplateLevel3 = DirectCast(CreativeBriefLevelOrTemplate, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3)

                        InUse = AdvantageFramework.Database.Procedures.CreativeBriefDetail.LoadByCreativeBriefTemplateLevel3ID(DbContext, CreativeBriefTemplateLevel3.ID).Any

                    End If

                End Using

            Catch ex As Exception
                InUse = False
            End Try

            IsTemplateInUse = InUse

        End Function

#Region "  Public "

        Public Function LoadControl(ByVal CreativeBriefTemplateID As Integer, ByVal IsCopy As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim Level1IDs As Short() = Nothing
            Dim Level2IDs As Short() = Nothing
            Dim Level3IDs As Short() = Nothing

            _CreativeBriefTemplateID = CreativeBriefTemplateID
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _CreativeBriefTemplateID <> Nothing Then

                    CreativeBriefTemplate = LoadSelectedCreativeBriefTemplate()

                    If CreativeBriefTemplate IsNot Nothing Then

                        If IsCopy = False Then

                            TextBoxHeader_Code.Enabled = False
                            TextBoxHeader_Code.ReadOnly = True
                            TextBoxHeader_Code.Text = CreativeBriefTemplate.Code

                            Try

                                If IsTemplateInUse(CreativeBriefTemplate) Then

                                    PanelForm_TopPanel.Visible = True

                                Else

                                    PanelForm_TopPanel.Visible = False

                                End If

                            Catch ex As Exception
                                PanelForm_TopPanel.Visible = False
                            End Try

                        Else

                            PanelForm_TopPanel.Visible = False
                            TextBoxHeader_Code.Enabled = True
                            TextBoxHeader_Code.ReadOnly = False

                        End If

                        LoadCreativeBriefTemplateDetails(Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The creative brief template you are trying to edit does not exist anymore.")

                    End If

                Else

                    'TabItemCreativeBriefTemplateSetup_DetailTab.Visible = False
                    PanelForm_TopPanel.Visible = False
                    TextBoxHeader_Code.Enabled = True
                    TextBoxHeader_Code.ReadOnly = False

                    LoadTreeListItems()

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing
            Dim Level1TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level2TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level3TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CreativeBriefTemplate = Me.FillObject(False)

                    If CreativeBriefTemplate IsNot Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.Update(DbContext, CreativeBriefTemplate)

                        If Saved Then

                            SaveDetailLevels(DbContext)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CreativeBriefTemplate = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.LoadByID(DbContext, _CreativeBriefTemplateID)

                    If CreativeBriefTemplate IsNot Nothing Then

                        If IsTemplateInUse(CreativeBriefTemplate) = False Then

                            Deleted = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.Delete(DbContext, CreativeBriefTemplate)

                            If Deleted = False Then

                                ErrorMessage = "The Creative Brief Template is in use and cannot be deleted."

                            End If

                        Else

                            ErrorMessage = "The Creative Brief Template is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef CreativeBriefTemplateID As Integer) As Boolean

            'objects
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CreativeBriefTemplate = Me.FillObject(True)

                    If CreativeBriefTemplate IsNot Nothing Then

                        CreativeBriefTemplate.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.Insert(DbContext, CreativeBriefTemplate)

                        If Inserted Then

                            _CreativeBriefTemplateID = CreativeBriefTemplate.ID

                            CreativeBriefTemplateID = CreativeBriefTemplate.ID

                            SaveDetailLevels(DbContext)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub ClearControl()

            TextBoxHeader_Code.Text = Nothing
            TextBoxHeader_Name.Text = Nothing
            CheckBoxColumn1_Client.Checked = False
            CheckBoxColumn1_Division.Checked = False
            CheckBoxColumn1_Product.Checked = False
            CheckBoxColumn2_ClientAddress.Checked = False
            CheckBoxColumn2_DivisionAddress.Checked = False
            CheckBoxColumn2_ProductAddress.Checked = False
            CheckBoxColumn3_JobNumber.Checked = False
            CheckBoxColumn3_ComponentNumber.Checked = False
            CheckBoxColumn3_AccountExecutive.Checked = False
            CheckBoxColumn4_JobDescription.Checked = False
            CheckBoxColumn4_ComponentDescription.Checked = False
            CheckBoxColumn4_ClientReference.Checked = False
            CheckBoxColumn1_DateOpened.Checked = False
            CheckBoxColumn1_Campaign.Checked = False
            CheckBoxColumn2_Budget.Checked = False
            CheckBoxColumn2_ApprovedEstimateRequired.Checked = False
            CheckBoxColumn2_RushChargesApproved.Checked = False
            CheckBoxColumn3_DepartmentTeam.Checked = False
            CheckBoxColumn3_DueDate.Checked = False
            CheckBoxColumn3_OpenedBy.Checked = False
            CheckBoxLevelOneStyle_Bold.Checked = False
            CheckBoxLevelOneStyle_Italic.Checked = False
            CheckBoxLevelOneStyle_Underline.Checked = False
            CheckBoxLevelOneStyle_Bullet.Checked = False
            NumericInputLevelOneStyle_Size.Value = CShort(8)
            CheckBoxLevelTwoStyle_Bold.Checked = False
            CheckBoxLevelTwoStyle_Italic.Checked = False
            CheckBoxLevelTwoStyle_Underline.Checked = False
            CheckBoxLevelTwoStyle_Bullet.Checked = False
            NumericInputLevelTwoStyle_Size.Value = CShort(8)
            CheckBoxLevelThreeStyle_Bold.Checked = False
            CheckBoxLevelThreeStyle_Italic.Checked = False
            CheckBoxLevelThreeStyle_Underline.Checked = False
            CheckBoxLevelThreeStyle_Bullet.Checked = False
            NumericInputLevelThreeStyle_Size.Value = CShort(8)
            CheckBoxDetailLevelStyle_Bold.Checked = False
            CheckBoxDetailLevelStyle_Italic.Checked = False
            CheckBoxDetailLevelStyle_Underline.Checked = False
            CheckBoxDetailLevelStyle_Bullet.Checked = False
            NumericInputDetailLevelStyle_Size.Value = CShort(8)

            TreeListControlDetail_Levels.Nodes.Clear()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub AddLevel()

            'objects
            Dim SelectedTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level1TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level2TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level3TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing
            Dim NodeToSave As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            If TreeListControlDetail_Levels.HasOnlyOneSelectedNode Then

                SelectedTreeListNode = TreeListControlDetail_Levels.GetFirstSelectedNode

                If SelectedTreeListNode.Tag IsNot Nothing Then

                    If TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 Then

                        CreativeBriefTemplateLevel1 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 With {.Description = "New Level 1"}
                        Level1TreeListNode = AppendNode(CreativeBriefTemplateLevel1, SelectedTreeListNode.ParentNode)

                        CreativeBriefTemplateLevel2 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 With {.Description = "New Level 2"}
                        Level2TreeListNode = AppendNode(CreativeBriefTemplateLevel2, Level1TreeListNode)

                        CreativeBriefTemplateLevel3 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 With {.Description = "New Level 3"}
                        Level3TreeListNode = AppendNode(CreativeBriefTemplateLevel3, Level2TreeListNode)

                        Level1TreeListNode.ExpandAll()

                        NodeToSave = Level1TreeListNode

                    ElseIf TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 Then

                        CreativeBriefTemplateLevel2 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 With {.Description = "New Level 2"}
                        Level2TreeListNode = AppendNode(CreativeBriefTemplateLevel2, SelectedTreeListNode.ParentNode)

                        CreativeBriefTemplateLevel3 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 With {.Description = "New Level 3"}
                        Level3TreeListNode = AppendNode(CreativeBriefTemplateLevel3, Level2TreeListNode)

                        Level2TreeListNode.ExpandAll()

                        NodeToSave = Level2TreeListNode

                    ElseIf TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 Then

                        CreativeBriefTemplateLevel3 = New AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 With {.Description = "New Level 3"}
                        Level3TreeListNode = AppendNode(CreativeBriefTemplateLevel3, SelectedTreeListNode.ParentNode)

                        Level3TreeListNode.ExpandAll()

                        NodeToSave = Level3TreeListNode

                    End If

                    If _CreativeBriefTemplateID <> Nothing AndAlso _IsCopy = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            SaveDetailLevel(DbContext, NodeToSave)

                        End Using

                    End If

                End If

            End If

        End Sub
        Public Sub DeleteLevel()

            'Objects
            Dim Level1TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim Level2TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim SelectedTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 = Nothing
            Dim CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 = Nothing
            Dim CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 = Nothing
            Dim CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate = Nothing
            Dim CanDelete As Boolean = True
            Dim Deleted As Boolean = True

            If TreeListControlDetail_Levels.HasOnlyOneSelectedNode Then

                SelectedTreeListNode = TreeListControlDetail_Levels.GetFirstSelectedNode

                Try

                    If (SelectedTreeListNode.ParentNode Is Nothing AndAlso TreeListControlDetail_Levels.Nodes.Count = 1) OrElse
                        (SelectedTreeListNode.ParentNode IsNot Nothing AndAlso SelectedTreeListNode.ParentNode.Nodes.Count = 1) Then

                        CanDelete = False

                        AdvantageFramework.Navigation.ShowMessageBox("At least one level is required.")

                    ElseIf _IsCopy = False AndAlso IsTemplateInUse(SelectedTreeListNode.Tag) Then

                        CanDelete = False

                        AdvantageFramework.Navigation.ShowMessageBox("Item cannot be deleted because it is in use.")

                    End If

                Catch ex As Exception
                    CanDelete = True
                End Try

                If CanDelete Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            If TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1 Then

                                CreativeBriefTemplateLevel1 = DirectCast(SelectedTreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1)

                                If CreativeBriefTemplateLevel1 IsNot Nothing AndAlso CreativeBriefTemplateLevel1.IsEntityBeingAdded() = False Then

                                    Deleted = AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.Delete(DbContext, CreativeBriefTemplateLevel1)

                                End If

                            ElseIf TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2 Then

                                CreativeBriefTemplateLevel2 = DirectCast(SelectedTreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2)

                                If CreativeBriefTemplateLevel2 IsNot Nothing AndAlso CreativeBriefTemplateLevel2.IsEntityBeingAdded() = False Then

                                    Deleted = AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.Delete(DbContext, CreativeBriefTemplateLevel2)

                                End If

                            ElseIf TypeOf SelectedTreeListNode.Tag Is AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3 Then

                                CreativeBriefTemplateLevel3 = DirectCast(SelectedTreeListNode.Tag, AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3)

                                If CreativeBriefTemplateLevel3 IsNot Nothing AndAlso CreativeBriefTemplateLevel3.IsEntityBeingAdded() = False Then

                                    Deleted = AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.Delete(DbContext, CreativeBriefTemplateLevel3)

                                End If

                            End If

                        Catch ex As Exception
                            Deleted = False
                        End Try

                        If Deleted Then

                            TreeListControlDetail_Levels.DeleteNode(SelectedTreeListNode)

                        End If

                    End Using

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub CreativeBriefTemplateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_ProductSetup_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_CreativeBriefTemplateSetup.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub TabControlControl_ProductSetup_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_CreativeBriefTemplateSetup.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

            End If

            LoadCreativeBriefTemplateDetails(e.NewTab)

        End Sub
        Private Sub ButtonDetail_DeleteLevel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonDetail_DeleteLevel.Click

            DeleteLevel()

        End Sub
        Private Sub ButtonDetail_AddLevel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonDetail_AddLevel.Click

            AddLevel()

        End Sub
        Private Sub CheckBoxHeader_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxHeader_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxHeader_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxHeader_Inactive.Checked = Not CheckBoxHeader_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxColumn2_ClientAddress_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxColumn2_ClientAddress.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If CheckBoxColumn2_ClientAddress.Checked Then

                    CheckBoxColumn2_DivisionAddress.Checked = False
                    CheckBoxColumn2_ProductAddress.Checked = False

                End If

            End If

        End Sub
        Private Sub CheckBoxColumn2_DivisionAddress_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxColumn2_DivisionAddress.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If CheckBoxColumn2_DivisionAddress.Checked Then

                    CheckBoxColumn2_ClientAddress.Checked = False
                    CheckBoxColumn2_ProductAddress.Checked = False

                End If

            End If

        End Sub
        Private Sub CheckBoxColumn2_ProductAddress_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxColumn2_ProductAddress.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If CheckBoxColumn2_ProductAddress.Checked Then

                    CheckBoxColumn2_ClientAddress.Checked = False
                    CheckBoxColumn2_DivisionAddress.Checked = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
