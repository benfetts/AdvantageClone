Namespace Maintenance.Client.Presentation

    Public Class ClientContactEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientContactID As Int32 = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property ClientContactID As Int32
            Get
                ClientContactID = _ClientContactID
            End Get
        End Property
        Private ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Private ReadOnly Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ClientCode As String, ByRef ClientContactID As Int32)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _ClientContactID = ClientContactID

        End Sub
        Private Sub New(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _ClientContactID = ClientContactID
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientCode As String, ByRef ClientContactID As Int32) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientContactEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog = Nothing

            ClientContactEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog(ClientCode, ClientContactID)

            ShowFormDialog = ClientContactEditDialog.ShowDialog()

            ClientCode = ClientContactEditDialog.ClientCode
            ClientContactID = ClientContactEditDialog.ClientContactID

        End Function
        Public Shared Function ShowFormDialog(Optional ByRef ClientCode As String = "", Optional ByRef DivisionCode As String = Nothing, Optional ByRef ProductCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientContactEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog = Nothing

            ClientContactEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog(ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = ClientContactEditDialog.ShowDialog()

            ClientCode = ClientContactEditDialog.ClientCode
            DivisionCode = ClientContactEditDialog.DivisionCode
            ProductCode = ClientContactEditDialog.ProductCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientContactEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _ClientContactID <> Nothing AndAlso _ClientContactID > 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            ElseIf _ClientCode <> "" Then

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If ClientContactControlForm_ClientContact.LoadControl(ClientCode:=_ClientCode, ClientContactID:=_ClientContactID, DivisionCode:=_DivisionCode, ProductCode:=_ProductCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The contact you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub ClientContactEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ClientContactControlForm_ClientContact.TextBoxSetup_Code.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ClientContactID As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If ClientContactControlForm_ClientContact.Insert(ClientContactID) Then

                        _ClientContactID = ClientContactID

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If ClientContactControlForm_ClientContact.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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

#End Region

#End Region

    End Class

End Namespace