Namespace Security.Setup.Presentation

    Public Class GroupEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GroupID As Integer = 0

#End Region

#Region " Properties "

        Private Property GroupID As Integer
            Get
                GroupID = _GroupID
            End Get
            Set(ByVal value As Integer)
                _GroupID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef GroupID As Integer, ByVal DefaultGroupName As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GroupID = GroupID

            If GroupID = 0 AndAlso DefaultGroupName <> "" Then

                TextBoxForm_Name.Text = "Copy of " & DefaultGroupName

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef GroupID As Integer = 0, Optional ByVal DefaultGroupName As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim GroupEditDialog As AdvantageFramework.Security.Setup.Presentation.GroupEditDialog = Nothing

            GroupEditDialog = New AdvantageFramework.Security.Setup.Presentation.GroupEditDialog(GroupID, DefaultGroupName)

            ShowFormDialog = GroupEditDialog.ShowDialog()

            GroupID = GroupEditDialog.GroupID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GroupEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Security.Database.Entities.Group.Properties.Name)
                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Security.Database.Entities.Group.Properties.Description)

                If _GroupID = 0 Then

                    ButtonForm_Update.Visible = False
                    ButtonForm_Add.Visible = True
                    Me.Text = "Add Group"

                Else

                    Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(SecurityDbContext, _GroupID)

                    If Group IsNot Nothing Then

                        ButtonForm_Update.Visible = True
                        ButtonForm_Add.Visible = False
                        Me.Text = "Edit Group"

                        TextBoxForm_Name.Text = Group.Name
                        TextBoxForm_Description.Text = Group.Description

                    Else

                        ButtonForm_Update.Visible = False
                        ButtonForm_Add.Visible = True
                        Me.Text = "Add Group"

                    End If

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Me.ShowWaitForm("Processing...")

                If AdvantageFramework.Security.Database.Procedures.Group.Insert(SecurityDbContext, TextBoxForm_Name.Text, TextBoxForm_Description.Text, Group) Then

                    _GroupID = Group.ID

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

                Me.CloseWaitForm()

            End Using

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Me.ShowWaitForm("Processing...")

                Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(SecurityDbContext, _GroupID)

                If Group IsNot Nothing Then

                    Group.Name = TextBoxForm_Name.Text
                    Group.Description = TextBoxForm_Description.Text

                    If AdvantageFramework.Security.Database.Procedures.Group.Update(SecurityDbContext, Group) Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End If

                Me.CloseWaitForm()

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace