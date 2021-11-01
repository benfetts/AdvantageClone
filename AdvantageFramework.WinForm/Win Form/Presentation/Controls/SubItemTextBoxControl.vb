Namespace WinForm.Presentation.Controls

    Public Class SubItemTextBox
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        'Public Event CustomPopupClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Public Event ButtonItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            [ReadOnly]
            Office
            Employee
            [Function]
            DepartmentTeam
            [Role]
            PurchaseOrderApprovalRule
            EmployeeFunction
            EmployeeTitle
            ServiceFeeType
            VendorTerm
            VendorCategory
            GeneralLedgerAccount
            ExceedOption
            PostPeriod
            CampaignDetailType
            SalesClass
            EmployeeCategory
            EstimateTemplate
            AddressLookup
            JobType
            BlackplateCode
            Client
            Task
            SalesTax
            TimesheetHourEntry
            Folder
            ClientPO
            AdNumber
            AdSizeCode
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As SubItemTextBox.Type = SubItemTextBox.Type.Default
        Protected _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property ControlType() As SubItemTextBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemTextBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case SubItemTextBox.Type.Default



                Case SubItemTextBox.Type.ReadOnly



                Case SubItemTextBox.Type.Office



                Case SubItemTextBox.Type.Employee



                Case SubItemTextBox.Type.[Function]



                Case SubItemTextBox.Type.DepartmentTeam



                Case SubItemTextBox.Type.Role



                Case SubItemTextBox.Type.PurchaseOrderApprovalRule



                Case SubItemTextBox.Type.EmployeeFunction



                Case SubItemTextBox.Type.EmployeeTitle



                Case SubItemTextBox.Type.ServiceFeeType



                Case SubItemTextBox.Type.VendorTerm



                Case SubItemTextBox.Type.VendorCategory



                Case SubItemTextBox.Type.GeneralLedgerAccount



                Case SubItemTextBox.Type.ExceedOption



                Case SubItemTextBox.Type.PostPeriod



                Case SubItemTextBox.Type.CampaignDetailType



                Case SubItemTextBox.Type.SalesClass



                Case SubItemTextBox.Type.EmployeeCategory



                Case SubItemTextBox.Type.EstimateTemplate


                Case SubItemTextBox.Type.AddressLookup

                    Me.ReadOnly = True

                Case SubItemTextBox.Type.JobType


                Case SubItemTextBox.Type.BlackplateCode


                Case SubItemTextBox.Type.Client


                Case SubItemTextBox.Type.Task


                Case SubItemTextBox.Type.SalesTax


                Case SubItemTextBox.Type.TimesheetHourEntry

                    Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                    Me.DisplayFormat.FormatString = "F2"
                    Me.EditFormat.FormatString = "F2"

                Case SubItemTextBox.Type.Folder


                Case SubItemTextBox.Type.ClientPO


                Case SubItemTextBox.Type.AdNumber


                Case SubItemTextBox.Type.AdSizeCode


            End Select

            AddButtons()

        End Sub
        Protected Sub AddButtons()

            Me.Buttons.Clear()

            Select Case _ControlType

                Case SubItemTextBox.Type.Office

                    AddEllipsisButton()

                Case SubItemTextBox.Type.Employee

                    AddEllipsisButton()

                Case SubItemTextBox.Type.[Function]

                    AddEllipsisButton()

                Case SubItemTextBox.Type.DepartmentTeam

                    AddEllipsisButton()

                Case SubItemTextBox.Type.Role

                    AddEllipsisButton()

                Case SubItemTextBox.Type.PurchaseOrderApprovalRule

                    AddEllipsisButton()

                Case SubItemTextBox.Type.EmployeeFunction

                    AddEllipsisButton()

                Case SubItemTextBox.Type.EmployeeTitle

                    AddEllipsisButton()

                Case SubItemTextBox.Type.ServiceFeeType

                    AddEllipsisButton()

                Case SubItemTextBox.Type.VendorTerm

                    AddEllipsisButton()

                Case SubItemTextBox.Type.VendorCategory

                    AddEllipsisButton()

                Case SubItemTextBox.Type.GeneralLedgerAccount

                    AddEllipsisButton()

                Case SubItemTextBox.Type.ExceedOption

                    AddEllipsisButton()

                Case SubItemTextBox.Type.PostPeriod

                    AddEllipsisButton()

                Case SubItemTextBox.Type.CampaignDetailType

                    AddEllipsisButton()

                Case SubItemTextBox.Type.SalesClass

                    AddEllipsisButton()

                Case SubItemTextBox.Type.EmployeeCategory

                    AddEllipsisButton()

                Case SubItemTextBox.Type.EstimateTemplate

                    AddEllipsisButton()

                Case SubItemTextBox.Type.AddressLookup

                    AddEllipsisButton()

                Case SubItemTextBox.Type.JobType

                    AddEllipsisButton()

                Case SubItemTextBox.Type.BlackplateCode

                    AddEllipsisButton()

                Case SubItemTextBox.Type.Client

                    AddEllipsisButton()

                Case SubItemTextBox.Type.Task

                    AddEllipsisButton()

                Case SubItemTextBox.Type.SalesTax

                    AddEllipsisButton()

                Case SubItemTextBox.Type.TimesheetHourEntry

                    AddImageButton()

                Case SubItemTextBox.Type.Folder

                    AddEllipsisButton()

                Case SubItemTextBox.Type.ClientPO

                    AddEllipsisButton()

                Case SubItemTextBox.Type.AdNumber

                    AddEllipsisButton()

                Case SubItemTextBox.Type.AdSizeCode

                    AddEllipsisButton()

            End Select

        End Sub
        Private Sub AddEllipsisButton()

            If CheckForExistingButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                Me.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

            End If

        End Sub
        Private Sub AddImageButton()

            If CheckForExistingButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) = False Then

                Select Case _ControlType

                    Case Type.TimesheetHourEntry

                        Me.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Add Comment") With {.Image = AdvantageFramework.My.Resources.DocumentTimeImage})

                End Select

            End If

        End Sub
        Private Function CheckForExistingButton(ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

            'objects
            Dim ButtonExists As Boolean = False

            For Each EditorButton In Me.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = ButtonPredefines Then

                    ButtonExists = True
                    Exit For

                End If

            Next

            CheckForExistingButton = ButtonExists

        End Function
        Protected Sub SetValue(ByVal Value As Object)

            'objects
            Dim DictionaryEntry As System.Collections.DictionaryEntry = Nothing

            Try

                For Each DictionaryEntry In Me.Links

                    If DictionaryEntry.Key IsNot Nothing Then

                        If TypeOf DictionaryEntry.Key Is DevExpress.XtraGrid.Columns.GridColumn Then

                            DirectCast(DictionaryEntry.Key, DevExpress.XtraGrid.Columns.GridColumn).View.ActiveEditor.EditValue = Value

                        End If

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#Region "  Control Event Handlers "

        Private Sub SubItemTextBox_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Me.ButtonClick

            Select Case _ControlType

                Case SubItemTextBox.Type.Default



                Case SubItemTextBox.Type.ReadOnly



                Case SubItemTextBox.Type.Office

                    ControlType_Office_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Employee

                    ControlType_Employee_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Function

                    ControlType_Function_ButtonClick(sender, e)

                Case SubItemTextBox.Type.DepartmentTeam

                    ControlType_Department_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Role

                    ControlType_Role_ButtonClick(sender, e)

                Case SubItemTextBox.Type.PurchaseOrderApprovalRule

                    ControlType_PurchaseOrderApprovalRule_ButtonClick(sender, e)

                Case SubItemTextBox.Type.EmployeeFunction

                    ControlType_EmployeeFunction_ButtonClick(sender, e)

                Case SubItemTextBox.Type.EmployeeTitle

                    ControlType_EmployeeTitle_ButtonClick(sender, e)

                Case SubItemTextBox.Type.ServiceFeeType

                    ControlType_ServiceFeeType_ButtonClick(sender, e)

                Case SubItemTextBox.Type.VendorTerm

                    ControlType_VendorTerm_ButtonClick(sender, e)

                Case SubItemTextBox.Type.VendorCategory

                    ControlType_VendorCategory_ButtonClick(sender, e)

                Case SubItemTextBox.Type.GeneralLedgerAccount

                    ControlType_GeneralLedgerAccount_ButtonClick(sender, e)

                Case SubItemTextBox.Type.ExceedOption

                    ControlType_ExceedOption_ButtonClick(sender, e)

                Case SubItemTextBox.Type.PostPeriod

                    ControlType_PostPeriod_ButtonClick(sender, e)

                Case SubItemTextBox.Type.CampaignDetailType

                    ControlType_CampaignDetailType_ButtonClick(sender, e)

                Case SubItemTextBox.Type.SalesClass

                    ControlType_SalesClass_ButtonClick(sender, e)

                Case SubItemTextBox.Type.EmployeeCategory

                    ControlType_EmployeeCategory_ButtonClick(sender, e)

                Case SubItemTextBox.Type.EstimateTemplate

                    ControlType_EstimateTemplate_ButtonClick(sender, e)

                Case SubItemTextBox.Type.AddressLookup

                    RaiseEvent ButtonItemClick(sender, e)

                Case SubItemTextBox.Type.JobType

                    ControlType_JobType_ButtonClick(sender, e)

                Case SubItemTextBox.Type.BlackplateCode

                    ControlType_BlackplateCode_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Client

                    ControlType_Client_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Task

                    ControlType_Task_ButtonClick(sender, e)

                Case SubItemTextBox.Type.SalesTax

                    ControlType_SalesTax_ButtonClick(sender, e)

                Case SubItemTextBox.Type.TimesheetHourEntry

                    ControlType_TimesheetHourEntry_ButtonClick(sender, e)

                Case SubItemTextBox.Type.Folder

                    ControlType_Folder_ButtonClick(sender, e)

                Case SubItemTextBox.Type.ClientPO

                    RaiseEvent ButtonItemClick(sender, e)

                Case SubItemTextBox.Type.AdNumber

                    RaiseEvent ButtonItemClick(sender, e)

                Case SubItemTextBox.Type.AdSizeCode

                    RaiseEvent ButtonItemClick(sender, e)

            End Select

        End Sub
        Private Sub SubItemTextBox_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Validating

            Dim ButtonEdit As DevExpress.XtraEditors.ButtonEdit = Nothing

            ButtonEdit = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit)

            If _ControlType = Type.Folder Then

                If String.IsNullOrWhiteSpace(ButtonEdit.Text) = False AndAlso My.Computer.FileSystem.DirectoryExists(ButtonEdit.Text) = False Then

                    ButtonEdit.Text = Nothing

                End If

            End If

        End Sub
        Public Function GetFocusedRow(ByVal sender As Object) As Object

            'objects
            Dim FocusedRow As Object = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            Try

                DataGridView = GetDataGridView(sender)

                If DataGridView IsNot Nothing Then

                    FocusedRow = DataGridView.CurrentView.GetRow(DataGridView.CurrentView.FocusedRowHandle)

                End If

            Catch ex As Exception
                FocusedRow = Nothing
            End Try

            GetFocusedRow = FocusedRow

        End Function
        Public Function GetDataGridView(ByVal sender As Object) As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

            'objects
            Dim ButtonEdit As DevExpress.XtraEditors.ButtonEdit = Nothing
            Dim GridViewControl As AdvantageFramework.WinForm.Presentation.Controls.GridControl = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim TypeOfSender As Object = Nothing


            Try

                TypeOfSender = sender.GetType

                If TypeOf sender Is DevExpress.XtraEditors.ButtonEdit Then

                    ButtonEdit = sender

                    Try
                        GridViewControl = ButtonEdit.Parent
                    Catch ex As Exception
                        GridViewControl = Nothing
                    End Try

                    If GridViewControl IsNot Nothing Then

                        Try
                            DataGridView = GridViewControl.Parent
                        Catch ex As Exception
                            DataGridView = Nothing
                        End Try

                    End If

                End If

            Catch ex As Exception
                DataGridView = Nothing
            End Try

            GetDataGridView = DataGridView

        End Function

#End Region

#Region "  Custom Control Event Handlers "

#Region "   Sales Class "

        Private Sub ControlType_SalesClass_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedSalesClasss As IEnumerable = Nothing
            Dim SalesClassCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.SalesClass, True, True, SelectedSalesClasss, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedSalesClasss IsNot Nothing Then

                        Try

                            SalesClassCode = (From Entity In SelectedSalesClasss _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            SalesClassCode = Nothing
                        Finally

                            Try

                                If SalesClassCode <> Nothing Then

                                    SetValue(SalesClassCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Campaign Detail Type "

        Private Sub ControlType_CampaignDetailType_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedCampaignDetailTypes As IEnumerable = Nothing
            Dim CampaignDetailTypeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.CampaignDetailType, True, True, SelectedCampaignDetailTypes, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedCampaignDetailTypes IsNot Nothing Then

                        Try

                            CampaignDetailTypeCode = (From Entity In SelectedCampaignDetailTypes _
                                                  Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            CampaignDetailTypeCode = Nothing
                        Finally

                            Try

                                If CampaignDetailTypeCode <> Nothing Then

                                    SetValue(CampaignDetailTypeCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Post Period "

        Private Sub ControlType_PostPeriod_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim PostPeriodCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.PostPeriod, True, True, SelectedPostPeriods, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedPostPeriods IsNot Nothing Then

                        Try

                            PostPeriodCode = (From Entity In SelectedPostPeriods
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            PostPeriodCode = Nothing
                        Finally

                            Try

                                If PostPeriodCode <> Nothing Then

                                    SetValue(PostPeriodCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   General Ledger Account "

        Private Sub ControlType_GeneralLedgerAccount_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedGeneralLedgerAccounts As IEnumerable = Nothing
            Dim GeneralLedgerAccountCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.GeneralLedgerAccount, True, True, SelectedGeneralLedgerAccounts, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedGeneralLedgerAccounts IsNot Nothing Then

                        Try

                            GeneralLedgerAccountCode = (From Entity In SelectedGeneralLedgerAccounts _
                                                        Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            GeneralLedgerAccountCode = Nothing
                        Finally

                            Try

                                If GeneralLedgerAccountCode <> Nothing Then

                                    SetValue(GeneralLedgerAccountCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Vendor Category "

        Private Sub ControlType_VendorCategory_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedVendorCategorys As IEnumerable = Nothing
            Dim VendorCategoryCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.ImportVendorCategory, True, True, SelectedVendorCategorys, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedVendorCategorys IsNot Nothing Then

                        Try

                            VendorCategoryCode = (From Entity In SelectedVendorCategorys _
                                                  Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            VendorCategoryCode = Nothing
                        Finally

                            Try

                                If VendorCategoryCode <> Nothing Then

                                    SetValue(VendorCategoryCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Vendor Term "

        Private Sub ControlType_VendorTerm_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedVendorTerms As IEnumerable = Nothing
            Dim VendorTermCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.VendorTerm, True, True, SelectedVendorTerms, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedVendorTerms IsNot Nothing Then

                        Try

                            VendorTermCode = (From Entity In SelectedVendorTerms _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            VendorTermCode = Nothing
                        Finally

                            Try

                                If VendorTermCode <> Nothing Then

                                    SetValue(VendorTermCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Service Fee Type "

        Private Sub ControlType_ServiceFeeType_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedServiceFeeTypes As IEnumerable = Nothing
            Dim ServiceFeeTypeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.ServiceFeeType, True, True, SelectedServiceFeeTypes, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedServiceFeeTypes IsNot Nothing Then

                        Try

                            ServiceFeeTypeCode = (From Entity In SelectedServiceFeeTypes _
                                                  Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            ServiceFeeTypeCode = Nothing
                        Finally

                            Try

                                If ServiceFeeTypeCode IsNot Nothing Then

                                    SetValue(ServiceFeeTypeCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Employee Title "

        Private Sub ControlType_EmployeeTitle_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedEmployeeTitles As IEnumerable = Nothing
            Dim EmployeeTitleDescription As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.EmployeeTitle, True, True, SelectedEmployeeTitles, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedEmployeeTitles IsNot Nothing Then

                        Try

                            EmployeeTitleDescription = (From Entity In SelectedEmployeeTitles _
                                                        Select Entity.Description).FirstOrDefault

                        Catch ex As Exception
                            EmployeeTitleDescription = Nothing
                        Finally

                            Try

                                If EmployeeTitleDescription IsNot Nothing Then

                                    SetValue(EmployeeTitleDescription)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Employee Function "

        Private Sub ControlType_EmployeeFunction_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedEmployeeFunctions As IEnumerable = Nothing
            Dim EmployeeFunctionCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.EmployeeFunction, True, True, SelectedEmployeeFunctions, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedEmployeeFunctions IsNot Nothing Then

                        Try

                            EmployeeFunctionCode = (From Entity In SelectedEmployeeFunctions _
                                                    Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            EmployeeFunctionCode = Nothing
                        Finally

                            Try

                                If EmployeeFunctionCode IsNot Nothing Then

                                    SetValue(EmployeeFunctionCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Purchase Order Approval Rule "

        Private Sub ControlType_PurchaseOrderApprovalRule_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedPurchaseOrderApprovalRules As IEnumerable = Nothing
            Dim PurchaseOrderApprovalRuleCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.PurchaseOrderApprovalRule, True, True, SelectedPurchaseOrderApprovalRules, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedPurchaseOrderApprovalRules IsNot Nothing Then

                        Try

                            PurchaseOrderApprovalRuleCode = (From Entity In SelectedPurchaseOrderApprovalRules _
                                        Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            PurchaseOrderApprovalRuleCode = Nothing
                        Finally

                            Try

                                If PurchaseOrderApprovalRuleCode IsNot Nothing Then

                                    SetValue(PurchaseOrderApprovalRuleCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Role "

        Private Sub ControlType_Role_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedRoles As IEnumerable = Nothing
            Dim RoleCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Role, True, True, SelectedRoles, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedRoles IsNot Nothing Then

                        Try

                            RoleCode = (From Entity In SelectedRoles _
                                        Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            RoleCode = Nothing
                        Finally

                            Try

                                If RoleCode IsNot Nothing Then

                                    SetValue(RoleCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Department "

        Private Sub ControlType_Department_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedDepartmentTeams As IEnumerable = Nothing
            Dim DepartmentTeamCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Department, True, True, SelectedDepartmentTeams, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedDepartmentTeams IsNot Nothing Then

                        Try

                            DepartmentTeamCode = (From Entity In SelectedDepartmentTeams _
                                                  Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            DepartmentTeamCode = Nothing
                        Finally

                            If DepartmentTeamCode IsNot Nothing Then

                                SetValue(DepartmentTeamCode)

                            End If

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Function "

        Private Sub ControlType_Function_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedFunctions As IEnumerable = Nothing
            Dim FunctionCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Function, True, True, SelectedFunctions, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedFunctions IsNot Nothing Then

                        Try

                            FunctionCode = (From Entity In SelectedFunctions _
                                            Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            FunctionCode = Nothing
                        Finally

                            If FunctionCode IsNot Nothing Then

                                SetValue(FunctionCode)

                            End If

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Employee "

        Private Sub ControlType_Employee_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedEmployees As IEnumerable = Nothing
            Dim EmployeeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Employee, True, True, SelectedEmployees, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedEmployees IsNot Nothing Then

                        Try

                            EmployeeCode = (From Entity In SelectedEmployees _
                                            Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            EmployeeCode = Nothing
                        Finally

                            If EmployeeCode IsNot Nothing Then

                                SetValue(EmployeeCode)

                            End If

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Office "

        Private Sub ControlType_Office_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedOffices As IEnumerable = Nothing
            Dim OfficeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Office, True, True, SelectedOffices, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedOffices IsNot Nothing Then

                        Try

                            OfficeCode = (From Entity In SelectedOffices _
                                          Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            OfficeCode = Nothing
                        Finally

                            If OfficeCode IsNot Nothing Then

                                SetValue(OfficeCode)

                            End If

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Exceed Option "

        Private Sub ControlType_ExceedOption_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedExceedOptions As IEnumerable = Nothing
            Dim ExceedOptionID As Integer = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.ExceedOption, True, True, SelectedExceedOptions, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedExceedOptions IsNot Nothing Then

                        Try

                            ExceedOptionID = (From Entity In SelectedExceedOptions _
                                                      Select Entity.ID).FirstOrDefault

                        Catch ex As Exception
                            ExceedOptionID = Nothing
                        Finally

                            Try

                                If ExceedOptionID <> Nothing Then

                                    SetValue(ExceedOptionID)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Employee Category "

        Private Sub ControlType_EmployeeCategory_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedEmployeeCategories As IEnumerable = Nothing
            Dim EmployeeCategoryID As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.EmployeeCategory, True, False, SelectedEmployeeCategories, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedEmployeeCategories IsNot Nothing Then

                        Try

                            EmployeeCategoryID = (From Entity In SelectedEmployeeCategories _
                                                  Select Entity.ID).FirstOrDefault

                        Catch ex As Exception
                            EmployeeCategoryID = Nothing
                        Finally

                            Try

                                If EmployeeCategoryID IsNot Nothing Then

                                    SetValue(EmployeeCategoryID)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Estimate Template "

        Private Sub ControlType_EstimateTemplate_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim FocusedRow As Object = Nothing
            Dim FunctionCode As String = Nothing
            Dim FunctionType As String = Nothing
            Dim ButtonEdit As DevExpress.XtraEditors.ButtonEdit = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim Value As String = Nothing
            Dim Entity As Object = Nothing
            Dim SelectedObjects As IEnumerable = Nothing

            If TypeOf sender Is DevExpress.XtraEditors.ButtonEdit Then

                Try

                    DataGridView = DirectCast(sender.Parent.Parent, AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

                Catch ex As Exception
                    DataGridView = Nothing
                End Try

                If DataGridView IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            FunctionCode = DataGridView.CurrentView.GetRowCellValue(DataGridView.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.FunctionCode.ToString)

                            FunctionType = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode).Type

                        Catch ex As Exception
                            FunctionCode = Nothing
                            FunctionType = Nothing
                        End Try

                        Select Case FunctionType

                            Case "V"

                                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Vendor, True, True, SelectedObjects, False) = Windows.Forms.DialogResult.OK Then

                                    If SelectedObjects IsNot Nothing Then

                                        Try

                                            Value = (From SelectedEntity In SelectedObjects
                                                     Select SelectedEntity.Code).FirstOrDefault

                                        Catch ex As Exception
                                            Value = Nothing
                                        Finally

                                            Try

                                                If Value IsNot Nothing Then

                                                    SetValue(Value)

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        End Try

                                    End If

                                End If

                            Case "E"

                                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Employee, True, True, SelectedObjects, False) = Windows.Forms.DialogResult.OK Then

                                    If SelectedObjects IsNot Nothing Then

                                        Try

                                            Value = (From SelectedEntity In SelectedObjects
                                                     Select SelectedEntity.Code).FirstOrDefault

                                        Catch ex As Exception
                                            Value = Nothing
                                        Finally

                                            Try

                                                If Value IsNot Nothing Then

                                                    SetValue(Value)

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        End Try

                                    End If

                                End If

                            Case "I"

                                AdvantageFramework.WinForm.MessageBox.Show("'Supplied By' can only be specified for employee time or vendor functions.")

                        End Select

                    End Using

                End If

            End If

        End Sub

#End Region

#Region "   JobType "

        Private Sub ControlType_JobType_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedJobType As IEnumerable = Nothing
            Dim JobTypeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.JobType, True, True, SelectedJobType, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedJobType IsNot Nothing Then

                        Try

                            JobTypeCode = (From Entity In SelectedJobType _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            JobTypeCode = Nothing
                        Finally

                            Try

                                If JobTypeCode <> Nothing Then

                                    SetValue(JobTypeCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   BlackplateCode "

        Private Sub ControlType_BlackplateCode_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedBlackplateCode As IEnumerable = Nothing
            Dim BlackplateCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Blackplate, True, True, SelectedBlackplateCode, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedBlackplateCode IsNot Nothing Then

                        Try

                            BlackplateCode = (From Entity In SelectedBlackplateCode _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            BlackplateCode = Nothing
                        Finally

                            Try

                                If BlackplateCode <> Nothing Then

                                    SetValue(BlackplateCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Client "

        Private Sub ControlType_Client_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedClientCode As IEnumerable = Nothing
            Dim ClientCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Client, True, True, SelectedClientCode, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedClientCode IsNot Nothing Then

                        Try

                            ClientCode = (From Entity In SelectedClientCode _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            ClientCode = Nothing
                        Finally

                            Try

                                If ClientCode <> Nothing Then

                                    SetValue(ClientCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Task "

        Private Sub ControlType_Task_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedTaskCode As IEnumerable = Nothing
            Dim TaskCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Task, True, True, SelectedTaskCode, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedTaskCode IsNot Nothing Then

                        Try

                            TaskCode = (From Entity In SelectedTaskCode _
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            TaskCode = Nothing
                        Finally

                            Try

                                If TaskCode <> Nothing Then

                                    SetValue(TaskCode)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   SalesTax"

        Private Sub ControlType_SalesTax_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedSalesTaxCode As IEnumerable = Nothing
            Dim SalesTax As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.SalesTax, True, False, SelectedSalesTaxCode, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedSalesTaxCode IsNot Nothing Then

                        Try

                            SalesTax = (From Entity In SelectedSalesTaxCode _
                                              Select Entity.TaxCode).FirstOrDefault

                        Catch ex As Exception
                            SalesTax = Nothing
                        Finally

                            Try

                                If SalesTax <> Nothing Then

                                    SetValue(SalesTax)

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Timesheet Hour Entry "

        Private Sub ControlType_TimesheetHourEntry_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim Comments As String = Nothing
            Dim FieldName As String = Nothing
            Dim NewComments As String = Nothing
            Dim Editable As Boolean = True

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph OrElse e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK Then

                DataGridView = GetDataGridView(sender)

                If DataGridView IsNot Nothing Then

                    DataGridView.CurrentView.PostEditor()

                    If DataGridView.CurrentView.GetFocusedRowCellDisplayText(DataGridView.CurrentView.FocusedColumn.FieldName) <> "" Then

                        Select Case DataGridView.CurrentView.FocusedColumn.FieldName

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString()

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString()

                            Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString

                                FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString()

                        End Select

                        If Me.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard Then

                            Editable = True

                        Else

                            Editable = False

                        End If

                        Comments = DataGridView.CurrentView.GetFocusedRowCellValue(FieldName)

                        If AdvantageFramework.WinForm.Presentation.TextBoxInputDialog.ShowFormDialog("Time Comments", "Enter Comments", Comments, NewComments, AdvantageFramework.Database.Entities.EmployeeTimeComment.Properties.EmployeeComments, Editable:=Editable) = Windows.Forms.DialogResult.OK Then

                            DataGridView.CurrentView.SetFocusedRowCellValue(FieldName, NewComments)

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Folder "

        Private Sub ControlType_Folder_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            Dim ButtonEdit As DevExpress.XtraEditors.ButtonEdit = Nothing

            ButtonEdit = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit)

            AdvantageFramework.WinForm.Presentation.BrowseForFolder(ButtonEdit.Text, ButtonEdit.Text)

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace