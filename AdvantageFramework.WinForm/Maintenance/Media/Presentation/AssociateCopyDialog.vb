Namespace Maintenance.Media.Presentation

    Public Class AssociateCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByRef Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate))

            ' This call is required by the designer.
            InitializeComponent()

            _Associates = Associates

        End Sub
        Private Sub LoadDivisions()

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ComboBoxForm_Client.HasASelectedValue Then

                        ComboBoxForm_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ComboBoxForm_Client.GetSelectedValue)

                    Else

                        ComboBoxForm_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadProducts()

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Client.HasASelectedValue Then

                        ComboBoxForm_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue).ToList

                    Else

                        ComboBoxForm_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).ToList

                    End If

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ComboBoxForm_Product.SetRequired(ComboBoxForm_Division.HasASelectedValue)
            ComboBoxForm_Division.Enabled = ComboBoxForm_Client.HasASelectedValue
            ComboBoxForm_Product.Enabled = If(ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Division.Enabled, True, False)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate)) As System.Windows.Forms.DialogResult

            'objects
            Dim AssociateCopyDialog As AdvantageFramework.Maintenance.Media.Presentation.AssociateCopyDialog = Nothing

            AssociateCopyDialog = New AdvantageFramework.Maintenance.Media.Presentation.AssociateCopyDialog(Associates)

            ShowFormDialog = AssociateCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AssociateCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _Associates IsNot Nothing AndAlso _Associates.Count > 0 Then

                ButtonForm_Copy.Visible = True

            Else

                ButtonForm_Copy.Visible = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Associate.Properties.ClientCode)
                ComboBoxForm_Division.SetPropertySettings(AdvantageFramework.Database.Entities.Associate.Properties.DivisionCode)
                ComboBoxForm_Product.SetPropertySettings(AdvantageFramework.Database.Entities.Associate.Properties.ProductCode)
                ComboBoxForm_MediaType.SetPropertySettings(AdvantageFramework.Database.Entities.Associate.Properties.MediaType)

                ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList
                ComboBoxForm_MediaType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AssociateMediaType))

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Copy.Click

            Dim NewAssociate As AdvantageFramework.Database.Entities.Associate = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Copied As Boolean = False

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Associate In _Associates

                            NewAssociate = New AdvantageFramework.Database.Entities.Associate
                            NewAssociate.DbContext = DbContext
                            NewAssociate.ClientCode = ComboBoxForm_Client.GetSelectedValue
                            NewAssociate.DivisionCode = ComboBoxForm_Division.GetSelectedValue
                            NewAssociate.ProductCode = ComboBoxForm_Product.GetSelectedValue
                            NewAssociate.MediaType = ComboBoxForm_MediaType.GetSelectedValue
                            NewAssociate.VendorCode = Associate.VendorCode
                            NewAssociate.EmployeeCode = Associate.EmployeeCode
                            NewAssociate.Percent = Associate.Percent

                            If AdvantageFramework.Database.Procedures.Associate.Insert(DbContext, NewAssociate) Then

                                Copied = True

                            End If

                        Next

                        If Copied Then

                            AdvantageFramework.WinForm.MessageBox.Show("Successfully copied Associate(s).")

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            LoadDivisions()
            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxForm_Division_EnabledChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.EnabledChanged

            If ComboBoxForm_Division.Enabled = False Then

                Try

                    ComboBoxForm_Division.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            LoadProducts()
            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxForm_Product_EnabledChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Product.EnabledChanged

            If ComboBoxForm_Product.Enabled = False Then

                Try

                    ComboBoxForm_Product.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace