Namespace WinForm.Presentation.Maintenance

    Public Class ClientOrderEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Connectionstring As String = Nothing
        Private _ClientID As Integer = 0
        Private _ClientName As String = 0
        Private _ClientOrderID As Integer = 0
        Private _OrderType As String = Nothing
        Private _ClientOrderIDCopy As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ClientOrderID As Integer
            Get
                ClientOrderID = _ClientOrderID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(Connectionstring As String, ClientID As Integer, ClientName As String, OrderType As String, ClientOrderID As Integer, Optional ByVal ClientOrderIDCopy As Nullable(Of Integer) = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            _Connectionstring = Connectionstring
            _ClientID = ClientID
            _ClientName = ClientName
            _OrderType = OrderType
            _ClientOrderID = ClientOrderID
            _ClientOrderIDCopy = ClientOrderIDCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Connectionstring As String, ClientID As Integer, ClientName As String, OrderType As String, ByRef ClientOrderID As Integer) As System.Windows.Forms.DialogResult

            Using ClientOrderEditDialog As New WinForm.Presentation.Maintenance.ClientOrderEditDialog(Connectionstring, ClientID, ClientName, OrderType, ClientOrderID)

                ShowFormDialog = ClientOrderEditDialog.ShowDialog()

                ClientOrderID = ClientOrderEditDialog.ClientOrderID

            End Using

        End Function
        Public Shared Function ShowFormDialog(Connectionstring As String, ClientID As Integer, ClientName As String, OrderType As String, ClientOrderIDCopy As Integer, ByRef ClientOrderID As Integer) As System.Windows.Forms.DialogResult

            Using ClientOrderEditDialog As New WinForm.Presentation.Maintenance.ClientOrderEditDialog(Connectionstring, ClientID, ClientName, OrderType, ClientOrderID, ClientOrderIDCopy)

                ShowFormDialog = ClientOrderEditDialog.ShowDialog()

                ClientOrderID = ClientOrderEditDialog.ClientOrderID

            End Using

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientOrderEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _ClientOrderID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If _ClientOrderIDCopy.HasValue Then

                If ClientOrderControl_Order.LoadControl(_Connectionstring, _ClientID, _OrderType, _ClientOrderIDCopy.Value, True) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("The client order you are trying to copy does not exist anymore.")
                    Me.Close()

                End If

            Else

                If ClientOrderControl_Order.LoadControl(_Connectionstring, _ClientID, _OrderType, _ClientOrderID) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("The client order you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ClientOrderEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.Text += ": " & _ClientName

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                If ClientOrderControl_Order.Save(ErrorMessage, _ClientOrderID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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

#End Region

#End Region

    End Class

End Namespace