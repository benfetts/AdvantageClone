Namespace Maintenance.Billing.Presentation

    Public Class FeeFlagUpdateDialog

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


        End Sub
        Private Sub EnableOrDisableActions()

            ComboBoxForm_Division.Enabled = ComboBoxForm_Client.HasASelectedValue
            ComboBoxForm_Product.Enabled = If(ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue, True, False)

        End Sub
        Private Sub FilterDivisions()

            'objects
            Dim ClientCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue

                    ComboBoxForm_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode)
                                                       Where Entity.IsActive = 1
                                                       Select Entity

                    ComboBoxForm_Division.Enabled = True

                End Using

            Else

                Try

                    ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                    ComboBoxForm_Division.Enabled = False
                    ComboBoxForm_Division.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FilterProducts()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue
                    DivisionCode = ComboBoxForm_Division.GetSelectedValue

                    ComboBoxForm_Product.DataSource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                      Where Entity.IsActive = 1
                                                      Select Entity

                    ComboBoxForm_Product.Enabled = True

                End Using

            Else

                Try

                    ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
                    ComboBoxForm_Product.Enabled = False
                    ComboBoxForm_Product.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim FeeFlagUpdateDialog As AdvantageFramework.Maintenance.Billing.Presentation.FeeFlagUpdateDialog = Nothing

            FeeFlagUpdateDialog = New AdvantageFramework.Maintenance.Billing.Presentation.FeeFlagUpdateDialog()

            ShowFormDialog = FeeFlagUpdateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub FeeFlagUpdateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

            End Using

            ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
            ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            ComboBoxForm_Client.SetRequired(True)
            ComboBoxForm_Division.SetRequired(True)
            ComboBoxForm_Product.SetRequired(True)
            DateTimePickerForm_DateFrom.SetRequired(True)
            DateTimePickerForm_DateTo.SetRequired(True)

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Ok_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Ok.Click

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim DateFrom As System.DateTime = Nothing
            Dim DateTo As System.DateTime = Nothing
            Dim EmployeeTimeDetails As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeDetail) = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim ErrorMessage As String = Nothing
            Dim UpdatedCount As Integer = Nothing

            If Me.Validator Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue
                ProductCode = ComboBoxForm_Product.GetSelectedValue
                DateFrom = DateTimePickerForm_DateFrom.Value
                DateTo = DateTimePickerForm_DateTo.Value

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            EmployeeTimeDetails = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext).Include("JobComponent").Include("JobComponent.Job")
                                                   Where Entity.EnteredDate >= DateFrom AndAlso
                                                         Entity.EnteredDate <= DateTo AndAlso
                                                         Entity.JobComponent.Job.ClientCode = ClientCode AndAlso
                                                         Entity.JobComponent.Job.DivisionCode = DivisionCode AndAlso
                                                         Entity.JobComponent.Job.ProductCode = ProductCode AndAlso
                                                         Entity.ARInvoiceNumber Is Nothing AndAlso
                                                         Entity.BillingUserCode Is Nothing AndAlso
                                                         (Entity.FeeTimeType Is Nothing OrElse Entity.FeeTimeType = 0)
                                                   Select Entity).ToList

                        Catch ex As Exception

                        End Try

                        If EmployeeTimeDetails IsNot Nothing Then

                            For Each EmployeeTimeDetail In EmployeeTimeDetails

                                EmployeeTime = AdvantageFramework.Database.Procedures.EmployeeTime.LoadByID(DbContext, EmployeeTimeDetail.EmployeeTimeID)

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, EmployeeTimeDetail.FunctionCode)

                                Try

                                    BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)("exec [dbo].[sp_get_billing_rates_rs] " &
                                                                                                                                      "'" & EmployeeTime.EmployeeCode & "', " &
                                                                                                                                      "'" & EmployeeTime.Date & "', " &
                                                                                                                                      "'" & [Function].Code & "', " &
                                                                                                                                      "'" & EmployeeTimeDetail.JobComponent.Job.ClientCode & "', " &
                                                                                                                                      "'" & EmployeeTimeDetail.JobComponent.Job.DivisionCode & "', " &
                                                                                                                                      "'" & EmployeeTimeDetail.JobComponent.Job.ProductCode & "', " &
                                                                                                                                      "'" & EmployeeTimeDetail.JobComponent.Job.SalesClassCode & "', " &
                                                                                                                                      "'" & [Function].Type & "', " &
                                                                                                                                      " " & EmployeeTimeDetail.JobNumber & ", " &
                                                                                                                                      " " & EmployeeTimeDetail.JobComponentNumber & "").FirstOrDefault

                                Catch ex As Exception
                                    BillingRate = Nothing
                                End Try

                                If BillingRate IsNot Nothing Then

                                    EmployeeTimeDetail.FeeTimeType = BillingRate.FEE_TIME_FLAG
                                    EmployeeTimeDetail.IsNonBillable = BillingRate.NOBILL_FLAG

                                    If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Update(DbContext, EmployeeTimeDetail) Then

                                        UpdatedCount = UpdatedCount + 1

                                    End If

                                End If

                            Next

                        End If

                    End Using

                Catch ex As Exception
                    ErrorMessage = "There was a problem updating employee time records. Please contact software support."
                End Try

                If ErrorMessage <> "" Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(String.Format("{0} row(s) have been changed", UpdatedCount))

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectionChangeCommitted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ComboBoxForm_Division.SelectedIndex = 0
                ComboBoxForm_Product.SelectedIndex = 0

                FilterDivisions()

                If ComboBoxForm_Division.SelectSingleItemDataSource() Then

                    FilterProducts()

                    ComboBoxForm_Product.SelectSingleItemDataSource()

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.SelectionChangeCommitted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ComboBoxForm_Product.SelectedIndex = 0

                FilterProducts()

                ComboBoxForm_Product.SelectSingleItemDataSource()

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace