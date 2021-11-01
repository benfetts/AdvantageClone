Namespace WinForm.Presentation.Controls

    Public Class EstimateTemplateControl

        Public Event EstimateTemplateDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event EstimateTemplateDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event SelectedTabChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _EstimateTemplateCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property EstimateTemplateDetailHasRows() As Boolean
            Get
                EstimateTemplateDetailHasRows = DataGridViewForm_TemplateFunction.HasRows
            End Get
        End Property
        Public ReadOnly Property EstimateTemplateDetailHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                EstimateTemplateDetailHasOnlyOneSelectedRow = DataGridViewForm_TemplateFunction.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property EstimateTemplateDetailIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                EstimateTemplateDetailIsNewItemRow = DataGridViewForm_TemplateFunction.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property EstimateTemplateDetailFocusedRowHandle() As Integer
            Get
                EstimateTemplateDetailFocusedRowHandle = DataGridViewForm_TemplateFunction.CurrentView.FocusedRowHandle
            End Get
        End Property
        Public ReadOnly Property DetailsTabSelected As Boolean
            Get
                DetailsTabSelected = (TabControlEstimateTemplate_EstimateTemplate.SelectedTab Is TabItemEstimateTemplate_DetailsTab)
            End Get
        End Property
        Public ReadOnly Property DefaultCommentsTabSelected As Boolean
            Get
                DefaultCommentsTabSelected = (TabControlEstimateTemplate_EstimateTemplate.SelectedTab Is TabItemEstimateTemplate_CommentsTab)
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

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            CheckBoxForm_Inactive.ByPassUserEntryChanged = True

                            TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.EstimateTemplate.Properties.Code)
                            TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.EstimateTemplate.Properties.Description)
                            TextBoxDefaultComment_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.EstimateTemplate.Properties.DefaultComment)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function LoadEstimateTemplate() As AdvantageFramework.Database.Entities.EstimateTemplate

            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, _EstimateTemplateCode)

                End Using

            Catch ex As Exception
                EstimateTemplate = Nothing
            End Try

            LoadEstimateTemplate = EstimateTemplate

        End Function
        Private Sub LoadSelectedTemplateFunctions()

            Dim EstimateTemplateCode As String = Nothing
            Dim EstimateTemplateDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
            Dim FunctionList As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing

            If _EstimateTemplateCode IsNot Nothing Then

                EstimateTemplateCode = _EstimateTemplateCode

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateTemplateDetailList = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateCode(DataContext, EstimateTemplateCode).ToList

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        FunctionList = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).ToList

                        For Each EstimateTemplateDetail In EstimateTemplateDetailList

                            EstimateTemplateDetail.DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            EstimateTemplateDetail.FunctionDescription = FunctionList.Where(Function(FC) FC.Code = EstimateTemplateDetail.FunctionCode).FirstOrDefault.Description

                        Next

                    End Using

                    DataGridViewForm_TemplateFunction.DataSource = EstimateTemplateDetailList

                    DataGridViewForm_TemplateFunction.CurrentView.BestFitColumns()

                End Using

            End If

            DataGridViewForm_TemplateFunction.HideOrShowColumn("ID", False)

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean, ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.EstimateTemplate

            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

            Try

                If IsNew Then

                    EstimateTemplate = New AdvantageFramework.Database.Entities.EstimateTemplate

                    LoadEstimateTemplateEntity(EstimateTemplate)

                Else

                    EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, _EstimateTemplateCode)

                    If EstimateTemplate IsNot Nothing Then

                        LoadEstimateTemplateEntity(EstimateTemplate)

                    End If

                End If

            Catch ex As Exception
                EstimateTemplate = Nothing
            End Try

            FillObject = EstimateTemplate

        End Function
        Private Function FillEstimateTemplateDetailsObject() As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)

            Dim EstimateTemplateDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
            Dim Row As Object = Nothing

            Try

                EstimateTemplateDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)

                For RowHandle = 0 To DataGridViewForm_TemplateFunction.CurrentView.RowCount

                    Row = DataGridViewForm_TemplateFunction.CurrentView.GetRow(RowHandle)

                    If Row IsNot Nothing AndAlso DataGridViewForm_TemplateFunction.CurrentView.IsNewItemRow(RowHandle) = False Then

                        EstimateTemplateDetailList.Add(Row)

                    End If

                Next

            Catch ex As Exception
                EstimateTemplateDetailList = Nothing
            End Try

            FillEstimateTemplateDetailsObject = EstimateTemplateDetailList

        End Function
        Private Sub LoadEstimateTemplateEntity(ByVal EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate)

            If EstimateTemplate IsNot Nothing Then

                EstimateTemplate.Code = TextBoxForm_Code.Text
                EstimateTemplate.Description = TextBoxForm_Description.Text
                EstimateTemplate.DefaultComment = TextBoxDefaultComment_Comment.Text
                EstimateTemplate.IsInactive = Convert.ToInt16(CheckBoxForm_Inactive.Checked)

            End If

        End Sub

#Region "   Public "

        Public Function LoadControl(ByVal EstimateTemplateCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

            _EstimateTemplateCode = EstimateTemplateCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EstimateTemplateCode <> "" Then

                    TextBoxForm_Code.Enabled = False

                    EstimateTemplate = LoadEstimateTemplate()

                    If EstimateTemplate IsNot Nothing Then

                        TextBoxForm_Code.Text = EstimateTemplate.Code
                        TextBoxForm_Description.Text = EstimateTemplate.Description
                        TextBoxDefaultComment_Comment.Text = EstimateTemplate.DefaultComment
                        CheckBoxForm_Inactive.Checked = Convert.ToBoolean(EstimateTemplate.IsInactive.GetValueOrDefault(0))

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxForm_Code.Enabled = True

                    DataGridViewForm_TemplateFunction.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)

                End If

            End Using

            LoadSelectedTemplateFunctions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub CopyDetails()

            'objects
            Dim SelectedEstimateTemplates As IEnumerable = Nothing

            Dim EstimateTemplateToCopy As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim EstimateTemplateCode As String = Nothing
            Dim NewEstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
            Dim EstimateTemplateDetailsToCopy As IEnumerable(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
            Dim Copy As Boolean = False
            Dim CurrentEstimateTemplateDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.EstimateTemplate, True, True, SelectedEstimateTemplates) = Windows.Forms.DialogResult.OK Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        EstimateTemplateCode = (From Entity In SelectedEstimateTemplates
                                                Select Entity.Code).FirstOrDefault

                        If EstimateTemplateCode IsNot Nothing Then

                            EstimateTemplateDetailsToCopy = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateCode(DataContext, EstimateTemplateCode).ToList

                            If EstimateTemplateDetailsToCopy IsNot Nothing Then

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                For Each EstimateTemplateDetail In EstimateTemplateDetailsToCopy

                                    NewEstimateTemplateDetail = New AdvantageFramework.Database.Entities.EstimateTemplateDetail

                                    NewEstimateTemplateDetail.DataContext = DataContext
                                    NewEstimateTemplateDetail.EstimateTemplateCode = _EstimateTemplateCode
                                    NewEstimateTemplateDetail.FunctionCode = EstimateTemplateDetail.FunctionCode
                                    NewEstimateTemplateDetail.Hours = EstimateTemplateDetail.Hours
                                    NewEstimateTemplateDetail.SuppliedBy = EstimateTemplateDetail.SuppliedBy

                                    If String.IsNullOrWhiteSpace(_EstimateTemplateCode) = False Then

                                        AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Insert(DbContext, DataContext, NewEstimateTemplateDetail)

                                    Else

                                        If CurrentEstimateTemplateDetailList Is Nothing Then

                                            CurrentEstimateTemplateDetailList = FillEstimateTemplateDetailsObject()

                                            If CurrentEstimateTemplateDetailList Is Nothing Then

                                                CurrentEstimateTemplateDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)

                                            End If

                                        End If

                                        CurrentEstimateTemplateDetailList.Add(NewEstimateTemplateDetail)

                                    End If

                                Next

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                            End If

                        End If

                    End Using

                End Using

                If String.IsNullOrWhiteSpace(_EstimateTemplateCode) = False Then

                    LoadSelectedTemplateFunctions()

                ElseIf CurrentEstimateTemplateDetailList IsNot Nothing Then

                    DataGridViewForm_TemplateFunction.DataSource = CurrentEstimateTemplateDetailList

                End If

            End If

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim EstimateTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
            Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewForm_TemplateFunction.CurrentView.CloseEditorForUpdating()

                    EstimateTemplate = Me.FillObject(False, DbContext)

                    If EstimateTemplate IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.EstimateTemplate.Update(DbContext, EstimateTemplate) Then

                            Saved = True

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                EstimateTemplateDetails = Me.FillEstimateTemplateDetailsObject

                                For Each ETD In EstimateTemplateDetails

                                    EstimateTemplateDetail = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateDetailID(DataContext, ETD.ID)

                                    EstimateTemplateDetail.FunctionCode = ETD.FunctionCode
                                    EstimateTemplateDetail.SuppliedBy = ETD.SuppliedBy
                                    EstimateTemplateDetail.Hours = ETD.Hours

                                    If AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Update(DbContext, DataContext, EstimateTemplateDetail) = False Then

                                        Try

                                            EstimateTemplateDetail = DataContext.EstimateTemplateDetails.GetOriginalEntityState(EstimateTemplateDetail)

                                        Catch ex As Exception

                                        End Try

                                    End If

                                Next

                            End Using

                        End If

                    End If

                End Using

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

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
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateTemplate = Me.FillObject(False, DbContext)

                    If EstimateTemplate IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.EstimateTemplate.Delete(DbContext, EstimateTemplate)

                        If Deleted = False Then

                            ErrorMessage = "The estimate template is in use and cannot be deleted."

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
        Public Function Insert(ByRef EstimateTemplateCode As String) As Boolean

            'objects
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim EstimateTemplateDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewForm_TemplateFunction.CurrentView.CloseEditorForUpdating()

                    EstimateTemplate = Me.FillObject(True, DbContext)

                    EstimateTemplateDetailList = Me.FillEstimateTemplateDetailsObject

                    If EstimateTemplate IsNot Nothing AndAlso EstimateTemplateDetailList IsNot Nothing AndAlso EstimateTemplateDetailList.Count > 0 Then

                        EstimateTemplate.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.EstimateTemplate.Insert(DbContext, EstimateTemplate) Then

                            Inserted = True

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                For Each EstimateTemplateDetail In EstimateTemplateDetailList

                                    Try

                                        EstimateTemplateDetail.EstimateTemplateCode = EstimateTemplate.Code
                                        EstimateTemplateDetail.ID = Nothing
                                        AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Insert(DbContext, DataContext, EstimateTemplateDetail)

                                    Catch ex As Exception

                                    End Try

                                Next

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                            End Using

                            EstimateTemplateCode = EstimateTemplate.Code

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Estimate Templates must contain at least one template function.")

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
        Public Sub CancelNewItemRowEstimateTemplateDetail()

            DataGridViewForm_TemplateFunction.CancelNewItemRow()

        End Sub
        Public Sub DeleteEstimateTemplateDetail()

            Dim EstimateTemplateDetailID As String = Nothing
            Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
            Dim SelectedRows As Integer() = Nothing

            If DataGridViewForm_TemplateFunction.HasASelectedRow Then

                If _EstimateTemplateCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            SelectedRows = DataGridViewForm_TemplateFunction.CurrentView.GetSelectedRows

                            For Each Row In SelectedRows

                                EstimateTemplateDetailID = DataGridViewForm_TemplateFunction.CurrentView.GetRowCellValue(Row, AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.ID.ToString)

                                EstimateTemplateDetail = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateDetailID(DataContext, EstimateTemplateDetailID)

                                If EstimateTemplateDetail IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Delete(DbContext, DataContext, EstimateTemplateDetail)

                                End If

                            Next

                        End Using

                    End Using

                    LoadSelectedTemplateFunctions()

                Else

                    DataGridViewForm_TemplateFunction.CurrentView.DeleteSelectedRows()

                End If

            End If

        End Sub
        Public Sub AddNewTemplateFunction(ByVal EstimateTemplateDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail))

            For Each EstimateTemplateDetail In EstimateTemplateDetailList

                Try

                    CType(DataGridViewForm_TemplateFunction.DataSource, System.Windows.Forms.BindingSource).Add(EstimateTemplateDetail)

                Catch ex As Exception

                End Try

            Next

        End Sub
        Public Sub AddNewTemplateFunction(ByVal EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail)

            Try

                CType(DataGridViewForm_TemplateFunction.DataSource, System.Windows.Forms.BindingSource).Add(EstimateTemplateDetail)

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearControl()

            TextBoxForm_Code.Text = ""
            TextBoxForm_Description.Text = ""
            CheckBoxForm_Inactive.Checked = False
            TextBoxDefaultComment_Comment.Text = ""

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CheckSpelling()

            TextBoxDefaultComment_Comment.CheckSpelling()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub EstimateTemplateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_TemplateFunction_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_TemplateFunction.AddNewRowEvent

            Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
            Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
            Dim EstimateTemplateCode As String = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.EstimateTemplateDetail Then

                Me.ShowWaitForm("Processing...")

                Try

                    If _EstimateTemplateCode IsNot Nothing Then

                        EstimateTemplateDetail = RowObject

                        If EstimateTemplateDetail IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                EstimateTemplateCode = _EstimateTemplateCode

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    EstimateTemplateDetail.EstimateTemplateCode = EstimateTemplateCode

                                    If AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Insert(DbContext, DataContext, EstimateTemplateDetail) Then

                                        LoadSelectedTemplateFunctions()

                                    End If

                                End Using

                            End Using

                        End If

                    End If

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_TemplateFunction_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_TemplateFunction.InitNewRowEvent

            RaiseEvent EstimateTemplateDetailInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewForm_TemplateFunction_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_TemplateFunction.EmbeddedNavigatorButtonClick

            Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                    CancelNewItemRowEstimateTemplateDetail()

                    e.Handled = True

                Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                    DeleteEstimateTemplateDetail()

                    e.Handled = True

            End Select

        End Sub
        Private Sub DataGridViewForm_TemplateFunction_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_TemplateFunction.SelectionChangedEvent

            RaiseEvent EstimateTemplateDetailSelectionChangedEvent(sender, e)

        End Sub
        Private Sub CheckBoxForm_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxForm_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxForm_Inactive.Checked = Not CheckBoxForm_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub TabControlEstimateTemplate_EstimateTemplate_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlEstimateTemplate_EstimateTemplate.SelectedTabChanged

            RaiseEvent SelectedTabChangedEvent()

        End Sub
        Private Sub DataGridViewForm_TemplateFunction_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TemplateFunction.DataSourceChangedEvent

            DataGridViewForm_TemplateFunction.CurrentView.OptionsView.ShowFooter = True

            If DataGridViewForm_TemplateFunction.Columns(AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString) IsNot Nothing Then

                If DataGridViewForm_TemplateFunction.Columns(AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewForm_TemplateFunction.Columns(AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewForm_TemplateFunction.Columns(AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
