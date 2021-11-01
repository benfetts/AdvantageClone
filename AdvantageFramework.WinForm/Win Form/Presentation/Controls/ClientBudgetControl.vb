Namespace WinForm.Presentation.Controls

    Public Class ClientBudgetControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ID As Integer = Nothing
        Private _IsLoading As Boolean = False

#End Region

#Region " Properties "

        

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.AccountPayableRecur)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            DbContext.Database.Connection.Open()

                            TextBoxControl_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Budget.Properties.Code)
                            TextBoxControl_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Budget.Properties.Description)

                            TextBoxControl_Reference.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Budget.Properties.Reference)

                            SearchableComboBoxControl_Employee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                            SearchableComboBoxControl_Employee.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxControl_Employee.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Budget.Properties.EmployeeCode)

                            DateTimePickerControl_BudgetDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Budget.Properties.BudgetDate)

                            DbContext.Database.Connection.Close()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = Nothing

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewBillingIncomeSummary_Details.UseEmbeddedNavigator = True
                DataGridViewBillingIncomeSummary_Details.CurrentView.EnableDisabledRows = False

            Else

                DataGridViewBillingIncomeSummary_Details.UseEmbeddedNavigator = False
                DataGridViewBillingIncomeSummary_Details.CurrentView.EnableDisabledRows = True

            End If

        End Sub

#Region "  Public "

        Public Sub ClearControl()

            Me.SuspendLayout()

            _ID = 0

            'header
            SearchableComboBoxControl_Employee.SelectedValue = Nothing
            TextBoxControl_Code.Text = Nothing
            TextBoxControl_Reference.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            Me.ResumeLayout(True)

        End Sub
        Public Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.AccountPayableRecur

            Try

                If IsNew Then

                Else

                End If

            Catch ex As Exception

            End Try

            FillObject = Nothing

        End Function
        Public Function LoadControl(ByVal VendorCode As String, ByVal ID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            
            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            Dim Saved As Boolean = False

            Save = Saved

        End Function
        Public Function Insert(ByRef AccountPayableRecurID As Integer) As Boolean

            Dim Inserted As Boolean = False

            Insert = Inserted

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub AccountsPayableControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxForm_Inactive.ByPassUserEntryChanged = True
            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

      

#End Region

#End Region

    End Class

End Namespace
