Namespace WinForm.Presentation.Controls

    Public Class RichEditControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event TextChangedEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecurityEnabled As Boolean = True
        Private _ShowEditButtons As Boolean = True
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _IsRequired As Boolean = False
        Protected _FormSettingsLoaded As Boolean = False
        Protected _RestrictFontNameSize As Boolean = False
        Protected _MasterRepositoryItemFontEdit As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit = Nothing
        Protected _MasterRepositoryItemRichEditFontSizeEdit As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit = Nothing

#End Region

#Region " Properties "

        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

                End If

            End Set
        End Property
        Public Property SecurityEnabled As Boolean
            Get
                SecurityEnabled = _SecurityEnabled
            End Get
            Set(ByVal value As Boolean)
                _SecurityEnabled = value
                Me.Enabled = value
            End Set
        End Property
        Public Overrides Property Text As String
            Get
                Text = RichEdit.Text
            End Get
            Set(value As String)
                RichEdit.Text = value
            End Set
        End Property
        Public Property HtmlText As String
            Get
                HtmlText = RichEdit.HtmlText
            End Get
            Set(value As String)
                RichEdit.HtmlText = value
            End Set
        End Property
        Public Property MhtText As String
            Get
                MhtText = RichEdit.MhtText
            End Get
            Set(value As String)
                RichEdit.MhtText = value
            End Set
        End Property
        Public Property RtfText As String
            Get
                RtfText = RichEdit.RtfText
            End Get
            Set(value As String)
                RichEdit.RtfText = value
            End Set
        End Property
        Public Property WordMLText As String
            Get
                WordMLText = RichEdit.WordMLText
            End Get
            Set(value As String)
                RichEdit.WordMLText = value
            End Set
        End Property
        Public Property ShowEditButtons As Boolean
            Get
                ShowEditButtons = _ShowEditButtons
            End Get
            Set(value As Boolean)
                barDockControlTop.Visible = value
                _ShowEditButtons = value
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = RichEdit.ReadOnly
            End Get
            Set(value As Boolean)
                RichEdit.ReadOnly = value
            End Set
        End Property
        Public ReadOnly Property RichEditControl As DevExpress.XtraRichEdit.RichEditControl
            Get
                RichEditControl = RichEdit
            End Get
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public ReadOnly Property HtmlBodyOnly As String
            Get
                HtmlBodyOnly = GetHtmlBodyOnly()
            End Get
        End Property
        Public WriteOnly Property RestrictFontNameSize As Boolean
            Set(value As Boolean)
                _RestrictFontNameSize = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Dim commandFactory As New CustomRichEditCommandFactoryService(Me.RichEdit, RichEdit.GetService(Of DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService)())

            Me.DoubleBuffered = True

            RichEdit.RemoveService(GetType(DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService))
            RichEdit.AddService(GetType(DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService), commandFactory)

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.RichEdit.ActiveView.BackColor = System.Drawing.Color.Cyan

            Else

                Me.RichEdit.ActiveView.BackColor = System.Drawing.Color.White

            End If

            SetDefaultFont()

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                _FormSettingsLoaded = True

                If _MasterRepositoryItemFontEdit Is Nothing Then

                    _MasterRepositoryItemFontEdit = RepositoryItemFontEdit1.Clone()

                End If

                If _MasterRepositoryItemRichEditFontSizeEdit Is Nothing Then

                    _MasterRepositoryItemRichEditFontSizeEdit = RepositoryItemRichEditFontSizeEdit1.Clone

                End If

            End If

        End Sub
        Protected Sub SetUserEntryChanged()

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Function GetHtmlBodyOnly() As String

            Dim BodyOnly As String = String.Empty
            Dim HtmlDocumentExporterOptions As DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions = Nothing
            Dim HtmlExporter As DevExpress.XtraRichEdit.Export.Html.HtmlExporter = Nothing

            HtmlDocumentExporterOptions = New DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions

            HtmlDocumentExporterOptions.ExportRootTag = DevExpress.XtraRichEdit.Export.Html.ExportRootTag.Body
            HtmlDocumentExporterOptions.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Inline

            HtmlDocumentExporterOptions.UseHtml5 = True

            HtmlExporter = New DevExpress.XtraRichEdit.Export.Html.HtmlExporter(Me.RichEdit.Model, HtmlDocumentExporterOptions)

            GetHtmlBodyOnly = HtmlExporter.Export

        End Function
        Private Sub SetDefaultFont()

            Dim CharacterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = Nothing

            If _RestrictFontNameSize Then

                RichEdit.BeginUpdate()

                RichEdit.SelectAll()

                CharacterProperties = RichEdit.Document.BeginUpdateCharacters(RichEdit.Document.Range)
                CharacterProperties.FontName = "Verdana"
                CharacterProperties.FontSize = 10

                RichEdit.Document.EndUpdateCharacters(CharacterProperties)

                RichEdit.DeselectAll()

                RichEdit.EndUpdate()

            End If

            If Me.ClipboardBar1.ItemLinks.Count = 4 Then 'remove paste special

                Me.ClipboardBar1.ItemLinks.RemoveAt(3)

            End If

            RepositoryItemFontEdit1.Items.Clear()

            RepositoryItemRichEditFontSizeEdit1.Items.Clear()

            If _RestrictFontNameSize Then

                RepositoryItemFontEdit1.Items.Add("Verdana")

                RepositoryItemRichEditFontSizeEdit1.Items.Add("10")

            Else

                For Each Item In _MasterRepositoryItemFontEdit.Items

                    RepositoryItemFontEdit1.Items.Add(Item)

                Next

                For Each Item In _MasterRepositoryItemRichEditFontSizeEdit.Items

                    RepositoryItemRichEditFontSizeEdit1.Items.Add(Item)

                Next

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub RichEditControl_Load(sender As Object, e As EventArgs) Handles Me.Load

            Me.SpellChecker1.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.SpellChecker1.LookAndFeel.UseDefaultLookAndFeel = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        'Private Sub barDockControlTop_VisibleChanged(sender As Object, e As EventArgs) Handles barDockControlTop.VisibleChanged

        'this was causing a stck overflow!
        'barDockControlTop.Visible = _ShowEditButtons

        'End Sub
        Private Sub RichEdit_DocumentLoaded(sender As Object, e As EventArgs) Handles RichEdit.DocumentLoaded

            Try 'leave this since the devenv crashes without it

                SetDefaultFont()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub RichEdit_EmptyDocumentCreated(sender As Object, e As EventArgs) Handles RichEdit.EmptyDocumentCreated

            SetDefaultFont()

        End Sub
        Private Sub RichEdit_TextChanged(sender As Object, e As EventArgs) Handles RichEdit.TextChanged

            If RichEdit.Modified Then

                SetUserEntryChanged()

                RaiseEvent TextChangedEvent(sender, e)

            End If

        End Sub
        Private Sub RichEdit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles RichEdit.KeyDown

            If e.KeyCode = System.Windows.Forms.Keys.Delete Then

                If RichEdit.Document.Length <= 1 OrElse RichEdit.Document.Selection.Length = RichEdit.Document.Length Then

                    e.SuppressKeyPress = True

                    e.Handled = True

                    System.Windows.Forms.SendKeys.Send("{BS}")

                End If

            ElseIf e.Alt AndAlso e.Control AndAlso e.KeyCode = Windows.Forms.Keys.V Then 'suppress paste special

                e.SuppressKeyPress = True
                e.Handled = True

            End If

        End Sub
        Private Sub RichEdit_PopupMenuShowing(sender As Object, e As DevExpress.XtraRichEdit.PopupMenuShowingEventArgs) Handles RichEdit.PopupMenuShowing

            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            DXMenuItem = DevExpress.XtraRichEdit.Menu.RichEditPopupMenu.GetDXMenuItemById(e.Menu, DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowFontForm, True)

            If DXMenuItem IsNot Nothing Then

                e.Menu.Items.Remove(DXMenuItem)

            End If

        End Sub

#End Region

#End Region

#Region " CustomRichEditCommandFactoryService "

        Public Class CustomRichEditCommandFactoryService
            Implements DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService

            Private ReadOnly service As DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService
            Private ReadOnly control As DevExpress.XtraRichEdit.RichEditControl

            Public Sub New(ByVal control As DevExpress.XtraRichEdit.RichEditControl, ByVal service As DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService)
                DevExpress.Utils.Guard.ArgumentNotNull(control, "control")
                DevExpress.Utils.Guard.ArgumentNotNull(service, "service")
                Me.control = control
                Me.service = service
            End Sub
            Public Function CreateCommand(ByVal RichEditCommandId As DevExpress.XtraRichEdit.Commands.RichEditCommandId) As DevExpress.XtraRichEdit.Commands.RichEditCommand Implements DevExpress.XtraRichEdit.Services.IRichEditCommandFactoryService.CreateCommand

                If RichEditCommandId = DevExpress.XtraRichEdit.Commands.RichEditCommandId.PasteSelection Then

                    Return New CustomPasteSelectionCommand(control)

                End If

                Return service.CreateCommand(RichEditCommandId)

            End Function

        End Class

        Public Class CustomPasteSelectionCommand
            Inherits DevExpress.XtraRichEdit.Commands.PasteSelectionCommand

            Public Sub New(ByVal control As DevExpress.XtraRichEdit.IRichEditControl)

                MyBase.New(control)

            End Sub
            Protected Overrides Function CreateInsertObjectCommand() As DevExpress.XtraRichEdit.Commands.RichEditCommand

                Return New CustomPasteSelectionCoreCommand(MyBase.Control, New DevExpress.Office.Commands.Internal.ClipboardPasteSource())

            End Function

        End Class

        Public Class CustomPasteSelectionCoreCommand
            Inherits DevExpress.XtraRichEdit.Commands.Internal.PasteSelectionCoreCommand

            Public Sub New(ByVal control As DevExpress.XtraRichEdit.IRichEditControl, ByVal pasteSource As DevExpress.Office.Commands.Internal.PasteSource)

                MyBase.New(control, pasteSource)

            End Sub
            Public Overrides Sub ForceExecute(ByVal state As DevExpress.Utils.Commands.ICommandUIState)

                Control.Document.InsertText(Control.Document.CaretPosition, System.Windows.Forms.Clipboard.GetText())

            End Sub

        End Class

#End Region

    End Class

End Namespace