Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI

Partial Public Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _WizardViewModel As IWizardViewModel = Nothing
    Private _ProgramController As ProgramController = Nothing
    Private _AddedDocuments As Boolean = False
    Private _SetActive As Boolean = False
    'Private _BackupDatabase As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

        Dim Pages As Generic.List(Of IWizardPageViewModel) = Nothing
        Dim ServerName As String = String.Empty
        Dim Database As String = String.Empty
        Dim UserName As String = String.Empty
        Dim Password As String = String.Empty
        Dim WebvantageURL As String = String.Empty
        Dim AdvantageUserName As String = String.Empty
        Dim AdvantagePassword As String = String.Empty
        Dim AdvantageConnectionFolder As String = String.Empty
        Dim BackupFolder As String = String.Empty
        Dim HandsFreeMode As Boolean = False
        Dim BackupDatabase As Nullable(Of Boolean) = Nothing
        Dim CreateAdvantageUser As Nullable(Of Boolean) = Nothing
        Dim CreateAdvantageConnection As Boolean = False
        Dim CreateWebvantageConnection As Boolean = False
        Dim ModifyServicesConnection As Boolean = False

        Pages = New Generic.List(Of IWizardPageViewModel)

        Pages.Add(New StartPageViewModel)
        Pages.Add(New SignInPageViewModel)
        Pages.Add(New WebvantageURLViewModel)
        Pages.Add(New BackupDatabasePageViewModel)
        Pages.Add(New CreateAdvantageUserPageViewModel)
        Pages.Add(New CreateAdvantageConnectionPageViewModel)
        Pages.Add(New CreateWebvantageConnectionPageViewModel)
        'Pages.Add(New CreateAPIConnectionPageViewModel)
        Pages.Add(New ModifyAdvantageServicesConnectionPageViewModel)
        Pages.Add(New PasswordPolicyPageViewModel)
        Pages.Add(New ConversionPageViewModel)
        Pages.Add(New FinishPageViewModel)

        _WizardViewModel = New WizardViewModel(Pages.ToArray, WindowsUIViewForm_View, Me)

        If My.Application.CommandLineArgs.Count > 0 Then

            For Each CommandLine In My.Application.CommandLineArgs

                If CommandLine.StartsWith("-s") Then

                    ServerName = CommandLine.Replace("-s", "")

                ElseIf CommandLine.StartsWith("-d") Then

                    Database = CommandLine.Replace("-d", "")

                ElseIf CommandLine.StartsWith("-u") Then

                    UserName = CommandLine.Replace("-u", "")

                ElseIf CommandLine.StartsWith("-p") Then

                    Password = CommandLine.Replace("-p", "")

                ElseIf CommandLine.StartsWith("-wv") Then

                    WebvantageURL = CommandLine.Replace("-wv", "")

                ElseIf CommandLine.StartsWith("-au") Then

                    AdvantageUserName = CommandLine.Replace("-au", "")

                ElseIf CommandLine.StartsWith("-ap") Then

                    AdvantagePassword = CommandLine.Replace("-ap", "")

                ElseIf CommandLine.StartsWith("-asc") Then

                    If CommandLine.Replace("-asc", "").ToUpper = "S" Then

                        CreateAdvantageUser = False

                    ElseIf CommandLine.Replace("-asc", "").ToUpper = "C" Then

                        CreateAdvantageUser = True

                    End If

                ElseIf CommandLine.StartsWith("-cad") Then

                    AdvantageConnectionFolder = CommandLine.Replace("-cad", "")

                ElseIf CommandLine.StartsWith("-bd") Then

                    BackupFolder = CommandLine.Replace("-bd", "")

                ElseIf CommandLine.StartsWith("-x") Then

                    HandsFreeMode = True

                ElseIf CommandLine.StartsWith("-b") Then

                    If CommandLine.Replace("-b", "").ToUpper = "Y" Then

                        BackupDatabase = True

                    ElseIf CommandLine.Replace("-b", "").ToUpper = "N" Then

                        BackupDatabase = False

                    End If

                ElseIf CommandLine.StartsWith("-ca") Then

                    CreateAdvantageConnection = True

                ElseIf CommandLine.StartsWith("-cw") Then

                    CreateWebvantageConnection = True

                ElseIf CommandLine.StartsWith("-ms") Then

                    ModifyServicesConnection = True

                End If

            Next

        End If

        If String.IsNullOrWhiteSpace(AdvantageUserName) Then

            AdvantageUserName = "ADVANTAGE"

        End If

        CType(_WizardViewModel, WizardViewModel).HandsFreeMode = HandsFreeMode
        CType(_WizardViewModel, WizardViewModel).BackupDatabase = BackupDatabase
        CType(_WizardViewModel, WizardViewModel).CreateAdvantageUser = CreateAdvantageUser
        CType(_WizardViewModel, WizardViewModel).CreateAdvantageConnection = CreateAdvantageConnection
        CType(_WizardViewModel, WizardViewModel).CreateWebvantageConnection = CreateWebvantageConnection
        CType(_WizardViewModel, WizardViewModel).ModifyServicesConnection = ModifyServicesConnection

        WindowsUIViewForm_View.AddDocument(New StartPage() With {.Text = "Start"})
        WindowsUIViewForm_View.AddDocument(New SignInPage() With {.Text = "Sign In", .ServerName = ServerName, .Database = Database, .UserName = UserName, .Password = Password})
        WindowsUIViewForm_View.AddDocument(New WebvantageURLPage() With {.Text = "Webvantage URL", .WebvantageURL = WebvantageURL})
        WindowsUIViewForm_View.AddDocument(New BackupDatabasePage() With {.Text = "Backup Database", .BackupFolder = BackupFolder})
        WindowsUIViewForm_View.AddDocument(New CreateAdvantageUserPage() With {.Text = "Create Advantage User", .AdvantageUserName = AdvantageUserName, .AdvantagePassword = AdvantagePassword})
        WindowsUIViewForm_View.AddDocument(New CreateAdvantageConnectionPage() With {.Text = "Create Advantage Connection", .AdvantageConnectionFolder = AdvantageConnectionFolder})
        WindowsUIViewForm_View.AddDocument(New CreateWebvantageConnectionPage() With {.Text = "Create Webvantage Connection"})
        'WindowsUIViewForm_View.AddDocument(New CreateAPIConnectionPage() With {.Text = "Create API Connection"})
        WindowsUIViewForm_View.AddDocument(New ModifyAdvantageServicesConnectionPage() With {.Text = "Modify Advantage Services Connection"})
        WindowsUIViewForm_View.AddDocument(New PasswordPolicyPage() With {.Text = "Password Policy Options"})
        WindowsUIViewForm_View.AddDocument(New ConversionPage() With {.Text = "Conversion"})
        WindowsUIViewForm_View.AddDocument(New FinishPage() With {.Text = "Finish"})

        For Each Document As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document In WindowsUIViewForm_View.Documents

            PageGroupForm_PageGroup.Items.Add(Document)

        Next Document

        'If HandsFreeMode Then

        '    Me.WindowsUIViewForm_View.UseTransitionAnimation = DevExpress.Utils.DefaultBoolean.False

        'End If

        _AddedDocuments = True

    End Sub

#Region "  Show Form Methods "

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If CType(_WizardViewModel, WizardViewModel).HandsFreeMode Then

            If Me.WindowsUIViewForm_View.ActiveDocument IsNot Nothing Then

                If TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is StartPage Then

                    _SetActive = True

                    If CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, BaseWizardPage).WizardViewModel Is Nothing Then

                        CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, BaseWizardPage).WizardViewModel = _WizardViewModel

                    End If
                    '
                    CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, StartPage).Next()
                    '
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.SpinWait(1000)
                    '
                    CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, SignInPage).SignIn()
                    '
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is WebvantageURLPage Then

                        CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, WebvantageURLPage).Save()

                    End If
                    '
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            CType(_WizardViewModel, WizardViewModel).BackupDatabase.HasValue AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is BackupDatabasePage Then

                        If CType(_WizardViewModel, WizardViewModel).BackupDatabase Then

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, BackupDatabasePage).BackupDatabase()

                        Else

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, BackupDatabasePage).DoNotBackupDatabase()

                        End If

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is CreateAdvantageUserPage Then

                        If CType(_WizardViewModel, WizardViewModel).CreateAdvantageUser.HasValue Then

                            If CType(_WizardViewModel, WizardViewModel).CreateAdvantageUser.Value = True Then

                                CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateAdvantageUserPage).Create()

                            Else

                                CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateAdvantageUserPage).SelectUser()

                            End If

                        Else

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateAdvantageUserPage).Skip()

                        End If

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is CreateAdvantageConnectionPage Then

                        If CType(_WizardViewModel, WizardViewModel).CreateAdvantageConnection Then

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateAdvantageConnectionPage).Create()

                        Else

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateAdvantageConnectionPage).Skip()

                        End If

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is CreateWebvantageConnectionPage Then

                        If CType(_WizardViewModel, WizardViewModel).CreateWebvantageConnection Then

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateWebvantageConnectionPage).Create()

                        Else

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, CreateWebvantageConnectionPage).Skip()

                        End If

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is ModifyAdvantageServicesConnectionPage Then

                        If CType(_WizardViewModel, WizardViewModel).ModifyServicesConnection Then

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, ModifyAdvantageServicesConnectionPage).Modify()

                        Else

                            CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, ModifyAdvantageServicesConnectionPage).Skip()

                        End If

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is PasswordPolicyPage Then

                        CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, PasswordPolicyPage).Save()

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If CType(_WizardViewModel, WizardViewModel).HasErrors = False AndAlso
                            TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is ConversionPage Then

                        CType(Me.WindowsUIViewForm_View.ActiveDocument.Control, ConversionPage).Convert()

                    End If
                    '
                    System.Threading.Thread.SpinWait(1000)
                    System.Windows.Forms.Application.DoEvents()
                    '
                    If TypeOf Me.WindowsUIViewForm_View.ActiveDocument.Control Is FinishPage Then

                        CType(_WizardViewModel, WizardViewModel).WriteAllErrorsToTextFile()

                        System.Windows.Forms.Application.Exit()

                    End If

                End If

            End If

        End If

    End Sub


#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub WindowsUIViewForm_View_NavigationBarsShowing(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.WindowsUI.NavigationBarsCancelEventArgs) Handles WindowsUIViewForm_View.NavigationBarsShowing

        e.Cancel = True

    End Sub
    Private Sub WindowsUIViewForm_View_DocumentActivated(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs) Handles WindowsUIViewForm_View.DocumentActivated

        'If _HandsFreeMode Then

        'End If
        'WindowsUIViewForm_View.ActiveDocument.
    End Sub
    Private Sub WindowsUIViewForm_View_NavigatedTo(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.WindowsUI.NavigationEventArgs) Handles WindowsUIViewForm_View.NavigatedTo

        e.Parameter = _WizardViewModel

        'If CType(_WizardViewModel, WizardViewModel).HandsFreeMode Then

        '    If _AddedDocuments AndAlso _SetActive Then

        '        If CType(e.Document.Control, BaseWizardPage).WizardViewModel Is Nothing Then

        '            CType(e.Document.Control, BaseWizardPage).WizardViewModel = _WizardViewModel

        '        End If

        '        If TypeOf e.Document.Control Is SignInPage Then

        '            CType(e.Document.Control, SignInPage).SignIn()


        '        End If

        '    End If

        'End If

    End Sub
    Private Sub WindowsUIViewForm_View_QueryDocumentActions(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.WindowsUI.QueryDocumentActionsEventArgs) Handles WindowsUIViewForm_View.QueryDocumentActions

        e.DocumentActions.Add(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.DocumentAction(Function(Document) _WizardViewModel.CanPrev(), Sub(Document) _WizardViewModel.Prev()) With {.Caption = "Back", .Image = ImageListForm_Image.Images(0)})
        e.DocumentActions.Add(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.DocumentAction(Function(Document) _WizardViewModel.CanNext(), Sub(Document) _WizardViewModel.Next()) With {.Caption = "Next", .Image = ImageListForm_Image.Images(1)})
        e.DocumentActions.Add(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.DocumentAction(Function(Document) _WizardViewModel.CanClose(), Sub(Document) _WizardViewModel.Close(True)) With {.Caption = "Exit", .Image = ImageListForm_Image.Images(2)})

    End Sub
    Private Sub DocumentManagerForm_DocumentManager_DocumentActivate(sender As Object, e As DocumentEventArgs) Handles DocumentManagerForm_DocumentManager.DocumentActivate

        If _AddedDocuments Then

            If e.Document IsNot Nothing Then

                If CType(e.Document.Control, BaseWizardPage).WizardViewModel Is Nothing Then

                    CType(e.Document.Control, BaseWizardPage).WizardViewModel = _WizardViewModel

                End If

            End If

        End If

    End Sub

#End Region

#End Region

End Class
