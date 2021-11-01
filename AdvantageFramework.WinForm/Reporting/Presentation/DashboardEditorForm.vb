Imports DevExpress.DashboardCommon

Namespace Reporting.Presentation

    Public Class DashboardEditorForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _IsAgencyASP As Boolean = False
        Private _DataSource As Object = Nothing
        Private _DashboardLayout() As Byte = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property DashboardLayout() As Byte()
            Get
                DashboardLayout = _DashboardLayout
            End Get
        End Property
        Private ReadOnly Property DashboardChanged As Boolean
            Get
                DashboardChanged = DashboardDesigner.IsDashboardModified
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal DataSource As Object, ByVal DashboardLayout() As Byte)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _DataSource = DataSource
            _DashboardLayout = DashboardLayout

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal DataSource As Object, ByRef DashboardLayout() As Byte, ByRef DashboardChanged As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim DashboardEditorForm As DashboardEditorForm = Nothing

            DashboardEditorForm = New DashboardEditorForm(Session, DataSource, DashboardLayout)

            ShowFormDialog = DashboardEditorForm.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                DashboardLayout = DashboardEditorForm.DashboardLayout
                DashboardChanged = DashboardEditorForm.DashboardChanged

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DashboardEditorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            DashboardDesigner.ActionOnClose = DevExpress.DashboardWin.DashboardActionOnClose.Discard

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            DashboardDesigner.DataSourceOptions.ObjectDataSourceLoadingBehavior = DevExpress.DataAccess.DocumentLoadingBehavior.LoadAsIs

            If _DashboardLayout IsNot Nothing AndAlso _DashboardLayout.Length > 0 Then

                MemoryStream = New System.IO.MemoryStream

                MemoryStream.Write(_DashboardLayout, 0, _DashboardLayout.Length)
                MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                Try

                    DashboardDesigner.LoadDashboard(MemoryStream)

                Catch ex As Exception

                End Try

                MemoryStream.Flush()
                MemoryStream.Close()

            End If

            If DashboardDesigner.Dashboard IsNot Nothing Then

                If DashboardDesigner.Dashboard.DataSources.Count = 0 Then

                    DashboardDesigner.Dashboard.DataSources.Add(New DevExpress.DashboardCommon.DashboardObjectDataSource(_DataSource))

                Else

                    DashboardDesigner.Dashboard.DataSources(0).Data = _DataSource

                End If

                DashboardDesigner.Refresh()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub FileSaveBarItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            DashboardDesigner.Dashboard.SaveToXml(MemoryStream)

            _DashboardLayout = MemoryStream.ToArray
            MemoryStream.Flush()
            MemoryStream.Close()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub DashboardDesigner_PopupMenuShowing(sender As Object, e As DevExpress.DashboardWin.DashboardPopupMenuShowingEventArgs) Handles DashboardDesigner.PopupMenuShowing

            'objects
            Dim BarButtonItem As DevExpress.XtraBars.BarButtonItem = Nothing

            If e.ButtonType = DevExpress.DashboardWin.DashboardButtonType.Export Then

                e.Allow = False

            ElseIf e.ButtonType = DevExpress.DashboardWin.DashboardButtonType.None Then

                If _IsAgencyASP Then

                    For Each MenuItem In e.Menu.ItemLinks.OfType(Of DevExpress.XtraBars.BarItemLink).ToList

                        If MenuItem.Caption = "Export To PDF" OrElse
                                MenuItem.Caption = "Export To Image" OrElse
                                MenuItem.Caption = "Export To Excel" OrElse
                                MenuItem.Caption = "Export Dashboard" OrElse
                                MenuItem.Caption = "Print Preview..." Then

                            e.Menu.RemoveLink(MenuItem)

                        End If

                    Next

                End If

            End If

        End Sub

        Private Sub DashboardDesigner_DataLoading(sender As Object, e As DataLoadingEventArgs) Handles DashboardDesigner.DataLoading
            e.Data = _DataSource
        End Sub

#End Region

#End Region

    End Class

End Namespace
