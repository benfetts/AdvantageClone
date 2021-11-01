Namespace GeneralLedger.Maintenance.Presentation

    Public Class CrossReferenceSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrids()

            'objects
            Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerOfficeCrossReferenceClass As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferenceClass As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing
            Dim GLAOffices As String() = Nothing
            Dim GLADepartments As String() = Nothing

            GeneralLedgerOfficeCrossReferences = New Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)
            GeneralLedgerDepartmentTeamCrossReferences = New Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    GLAOffices = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                  Select Entity.GeneralLedgerOfficeCrossReferenceCode Distinct).ToArray

                Catch ex As Exception
                    GLAOffices = Nothing
                End Try

                If GLAOffices IsNot Nothing Then

                    For Each GLAOffice In GLAOffices

                        GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GLAOffice)

                        If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                            GeneralLedgerOfficeCrossReferenceClass = New AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference(GeneralLedgerOfficeCrossReference)

                            GeneralLedgerOfficeCrossReferences.Add(GeneralLedgerOfficeCrossReferenceClass)

                        Else

                            GeneralLedgerOfficeCrossReferenceClass = New AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference With {.Code = GLAOffice,
                                                                                                                                                     .CrossReferenceExists = False}

                            GeneralLedgerOfficeCrossReferences.Add(GeneralLedgerOfficeCrossReferenceClass)

                        End If

                    Next

                End If

                DataGridViewOffice_CrossReferences.DataSource = GeneralLedgerOfficeCrossReferences

                If DataGridViewOffice_CrossReferences.Columns(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeName.ToString) IsNot Nothing Then

                    DataGridViewOffice_CrossReferences.Columns(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeName.ToString).OptionsColumn.AllowFocus = False

                End If

                Try

                    GLADepartments = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                      Select Entity.DepartmentCode Distinct).ToArray

                Catch ex As Exception
                    GLADepartments = Nothing
                End Try

                If GLADepartments IsNot Nothing Then

                    For Each GLADepartment In GLADepartments

                        GeneralLedgerDepartmentTeamCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.LoadByCode(DbContext, GLADepartment)

                        If GeneralLedgerDepartmentTeamCrossReference IsNot Nothing Then

                            GeneralLedgerDepartmentTeamCrossReferenceClass = New AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference(GeneralLedgerDepartmentTeamCrossReference)


                            GeneralLedgerDepartmentTeamCrossReferences.Add(GeneralLedgerDepartmentTeamCrossReferenceClass)
                        Else

                            GeneralLedgerDepartmentTeamCrossReferenceClass = New AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference With {.Code = GLADepartment,
                                                                                                                                                                     .CrossReferenceExists = False}

                            GeneralLedgerDepartmentTeamCrossReferences.Add(GeneralLedgerDepartmentTeamCrossReferenceClass)

                        End If

                    Next

                End If

                DataGridViewDepartment_CrossReferences.DataSource = GeneralLedgerDepartmentTeamCrossReferences

                If DataGridViewDepartment_CrossReferences.Columns(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentName.ToString) IsNot Nothing Then

                    DataGridViewDepartment_CrossReferences.Columns(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentName.ToString).OptionsColumn.AllowFocus = False

                End If

            End Using

            DataGridViewOffice_CrossReferences.CurrentView.BestFitColumns()
            DataGridViewDepartment_CrossReferences.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewOffice_CrossReferences.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewOffice_CrossReferences.HasASelectedRow

            End If

        End Sub
        Private Sub DeleteOffoceCrossReference()

            'objects
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GLOfficeCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Deleted As Boolean = True

            If DataGridViewOffice_CrossReferences.HasOnlyOneSelectedRow Then

                DataGridViewOffice_CrossReferences.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewOffice_CrossReferences.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    GLOfficeCrossReference = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    GLOfficeCrossReference = Nothing
                                End Try

                                If GLOfficeCrossReference IsNot Nothing Then

                                    If GLOfficeCrossReference.CrossReferenceExists Then

                                        GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GLOfficeCrossReference.Code)

                                        Deleted = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Delete(DbContext, GeneralLedgerOfficeCrossReference)

                                    End If

                                    If Deleted Then

                                        GLOfficeCrossReference.CrossReferenceExists = False
                                        GLOfficeCrossReference.OfficeCode = Nothing
                                        GLOfficeCrossReference.OfficeName = Nothing
                                        GLOfficeCrossReference.ModifiedDate = Nothing
                                        GLOfficeCrossReference.UserCode = Nothing

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewOffice_CrossReferences.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub DeleteDepartmentCrossReference()

            'objects
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing
            Dim GLDepartmentTeamCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Deleted As Boolean = True

            If DataGridViewDepartment_CrossReferences.HasOnlyOneSelectedRow Then

                DataGridViewDepartment_CrossReferences.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewDepartment_CrossReferences.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    GLDepartmentTeamCrossReference = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    GLDepartmentTeamCrossReference = Nothing
                                End Try

                                If GLDepartmentTeamCrossReference IsNot Nothing Then

                                    If GLDepartmentTeamCrossReference.CrossReferenceExists Then

                                        GeneralLedgerDepartmentTeamCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.LoadByCode(DbContext, GLDepartmentTeamCrossReference.Code)

                                        Deleted = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Delete(DbContext, GeneralLedgerDepartmentTeamCrossReference)

                                    End If

                                    If Deleted Then

                                        GLDepartmentTeamCrossReference.CrossReferenceExists = False
                                        GLDepartmentTeamCrossReference.DepartmentCode = Nothing
                                        GLDepartmentTeamCrossReference.DepartmentName = Nothing
                                        GLDepartmentTeamCrossReference.ModifiedDate = Nothing
                                        GLDepartmentTeamCrossReference.UserCode = Nothing

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewDepartment_CrossReferences.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CrossReferenceSetupForm As Presentation.CrossReferenceSetupForm = Nothing

            CrossReferenceSetupForm = New Presentation.CrossReferenceSetupForm()

            CrossReferenceSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CrossReferenceSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewOffice_CrossReferences.AutoFilterLookupColumns = True
            DataGridViewDepartment_CrossReferences.AutoFilterLookupColumns = True

            DataGridViewOffice_CrossReferences.MultiSelect = False
            DataGridViewDepartment_CrossReferences.MultiSelect = False

            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrids()

        End Sub
        Private Sub CrossReferenceSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CrossReferenceSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            Try

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.OfficeAndDepartmentCrossReference, Nothing, Nothing, Nothing, Nothing, Nothing)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim GeneralLedgerDepartmentTeamCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) = Nothing
            Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing

            If DataGridViewOffice_CrossReferences.HasRows OrElse DataGridViewDepartment_CrossReferences.HasRows Then

                DataGridViewOffice_CrossReferences.CurrentView.CloseEditorForUpdating()
                DataGridViewDepartment_CrossReferences.CurrentView.CloseEditorForUpdating()

                GeneralLedgerOfficeCrossReferences = DataGridViewOffice_CrossReferences.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)().ToList
                GeneralLedgerDepartmentTeamCrossReferences = DataGridViewDepartment_CrossReferences.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each GLOfficeCrossReference In GeneralLedgerOfficeCrossReferences

                            GeneralLedgerOfficeCrossReference = GLOfficeCrossReference.LoadEntity()

                            If GLOfficeCrossReference.CrossReferenceExists Then

                                AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Update(DbContext, GeneralLedgerOfficeCrossReference)

                            Else

                                If String.IsNullOrEmpty(GeneralLedgerOfficeCrossReference.OfficeCode) = False Then

                                    GeneralLedgerOfficeCrossReference.EnteredDate = System.DateTime.Today
                                    GeneralLedgerOfficeCrossReference.ModifiedDate = Nothing

                                    GLOfficeCrossReference.CrossReferenceExists = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Insert(DbContext, GeneralLedgerOfficeCrossReference)

                                End If

                            End If

                        Next

                        For Each GLDepartmentTeamCrossReference In GeneralLedgerDepartmentTeamCrossReferences

                            GeneralLedgerDepartmentTeamCrossReference = GLDepartmentTeamCrossReference.LoadEntity()

                            If GLDepartmentTeamCrossReference.CrossReferenceExists Then

                                AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Update(DbContext, GeneralLedgerDepartmentTeamCrossReference)

                            Else

                                If String.IsNullOrEmpty(GLDepartmentTeamCrossReference.DepartmentCode) = False Then

                                    GeneralLedgerDepartmentTeamCrossReference.EnteredDate = System.DateTime.Today
                                    GeneralLedgerDepartmentTeamCrossReference.ModifiedDate = Nothing

                                    GLDepartmentTeamCrossReference.CrossReferenceExists = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Insert(DbContext, GeneralLedgerDepartmentTeamCrossReference)

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                
                Try

                    DataGridViewOffice_CrossReferences.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If TabControlForm_CrossReference.SelectedTab Is TabItemCrossReference_OfficeTab Then

                DeleteOffoceCrossReference()

            ElseIf TabControlForm_CrossReference.SelectedTab Is TabItemCrossReference_Department Then

                DeleteDepartmentCrossReference()

            End If

        End Sub
        Private Sub DataGridViewOffice_CrossReferences_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOffice_CrossReferences.CellValueChangedEvent

            'objects
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString Then

                Try

                    GeneralLedgerOfficeCrossReference = DataGridViewOffice_CrossReferences.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    GeneralLedgerOfficeCrossReference = Nothing
                End Try

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    Try

                        If GeneralLedgerOfficeCrossReference.CrossReferenceExists = True Then

                            GeneralLedgerOfficeCrossReference.ModifiedDate = System.DateTime.Today

                        End If

                        GeneralLedgerOfficeCrossReference.UserCode = Me.Session.UserCode

                    Catch ex As Exception
                        GeneralLedgerOfficeCrossReference.ModifiedDate = Nothing
                        GeneralLedgerOfficeCrossReference.UserCode = GeneralLedgerOfficeCrossReference.UserCode
                    End Try

                    Try

                        If String.IsNullOrEmpty(e.Value) = False Then

                            For RowHandle = 0 To DataGridViewOffice_CrossReferences.CurrentView.RowCount - 1

                                If RowHandle <> e.RowHandle Then

                                    If DataGridViewOffice_CrossReferences.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString) = e.Value Then

                                        DataGridViewOffice_CrossReferences.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString, Nothing)
                                        DataGridViewOffice_CrossReferences.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeName.ToString, Nothing)

                                        AdvantageFramework.WinForm.MessageBox.Show("The office code you have selected is already associated with another GL Office Code. Please select again.", WinForm.MessageBox.MessageBoxButtons.OK)

                                        Exit For

                                    End If

                                End If

                            Next

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewOffice_CrossReferences_CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DataGridViewOffice_CrossReferences.CustomDrawRowIndicatorEvent

            'objects
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim X As Integer = Nothing
            Dim Y As Integer = Nothing

            If e.Info.IsRowIndicator Then

                Try

                    GeneralLedgerOfficeCrossReference = DirectCast(DataGridViewOffice_CrossReferences.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)

                    If GeneralLedgerOfficeCrossReference.CrossReferenceExists = False Then

                        e.Info.ImageIndex = -1
                        e.Painter.DrawObject(e.Info)
                        Rectangle = e.Bounds
                        Rectangle.Inflate(-1, -1)
                        X = Rectangle.X + (Rectangle.Width - AdvantageFramework.My.Resources.ArrowRight.Size.Width) / 2
                        Y = Rectangle.Y + (Rectangle.Height - AdvantageFramework.My.Resources.ArrowRight.Size.Height) / 2
                        e.Graphics.DrawImageUnscaled(AdvantageFramework.My.Resources.ArrowRight, X, Y)

                        e.Handled = True

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewOffice_CrossReferences_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewOffice_CrossReferences.ShownEditorEvent

            If DataGridViewOffice_CrossReferences.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString Then

                DataGridViewOffice_CrossReferences.CurrentView.CloseEditor()

            End If

        End Sub
        Private Sub DataGridViewDepartment_CrossReferences_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDepartment_CrossReferences.CellValueChangedEvent

            'objects
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString Then

                Try

                    GeneralLedgerDepartmentTeamCrossReference = DataGridViewDepartment_CrossReferences.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    GeneralLedgerDepartmentTeamCrossReference = Nothing
                End Try

                If GeneralLedgerDepartmentTeamCrossReference IsNot Nothing Then

                    Try

                        If GeneralLedgerDepartmentTeamCrossReference.CrossReferenceExists Then

                            GeneralLedgerDepartmentTeamCrossReference.ModifiedDate = System.DateTime.Today

                        End If

                        GeneralLedgerDepartmentTeamCrossReference.UserCode = Me.Session.UserCode

                    Catch ex As Exception
                        GeneralLedgerDepartmentTeamCrossReference.ModifiedDate = Nothing
                        GeneralLedgerDepartmentTeamCrossReference.UserCode = GeneralLedgerDepartmentTeamCrossReference.UserCode
                    End Try

                    Try

                        If String.IsNullOrEmpty(e.Value) = False Then

                            For RowHandle = 0 To DataGridViewDepartment_CrossReferences.CurrentView.RowCount - 1

                                If RowHandle <> e.RowHandle Then

                                    If DataGridViewDepartment_CrossReferences.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString) = e.Value Then

                                        DataGridViewDepartment_CrossReferences.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString, Nothing)
                                        DataGridViewDepartment_CrossReferences.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentName.ToString, Nothing)

                                        AdvantageFramework.WinForm.MessageBox.Show("The department code you have selected is already associated with another GL Department Code. Please select again.", WinForm.MessageBox.MessageBoxButtons.OK)

                                        Exit For

                                    End If

                                End If

                            Next

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewDepartment_CrossReferences_CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DataGridViewDepartment_CrossReferences.CustomDrawRowIndicatorEvent

            'objects
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim X As Integer = Nothing
            Dim Y As Integer = Nothing

            If e.Info.IsRowIndicator Then

                Try

                    GeneralLedgerDepartmentTeamCrossReference = DirectCast(DataGridViewDepartment_CrossReferences.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)

                    If GeneralLedgerDepartmentTeamCrossReference.CrossReferenceExists = False Then

                        e.Info.ImageIndex = -1
                        e.Painter.DrawObject(e.Info)
                        Rectangle = e.Bounds
                        Rectangle.Inflate(-1, -1)
                        X = Rectangle.X + (Rectangle.Width - AdvantageFramework.My.Resources.ArrowRight.Size.Width) / 2
                        Y = Rectangle.Y + (Rectangle.Height - AdvantageFramework.My.Resources.ArrowRight.Size.Height) / 2
                        e.Graphics.DrawImageUnscaled(AdvantageFramework.My.Resources.ArrowRight, X, Y)

                        e.Handled = True

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewDepartment_CrossReferences_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewDepartment_CrossReferences.ShownEditorEvent

            If DataGridViewDepartment_CrossReferences.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString Then

                DataGridViewDepartment_CrossReferences.CurrentView.CloseEditor()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace