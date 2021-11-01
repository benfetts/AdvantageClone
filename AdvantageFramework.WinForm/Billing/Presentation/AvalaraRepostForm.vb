Namespace Billing.Presentation

    Public Class AvalaraRepostForm

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
        Private Sub LoadGrid()

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_AvalaraInvoices.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice) _
                        (String.Format("exec advsp_bcc_process_avatax '', 1, 'ALL'")).ToList

                DataGridViewForm_AvalaraInvoices.CurrentView.BestFitColumns()

            End Using

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Post.Enabled = DataGridViewForm_AvalaraInvoices.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AvalaraRepostForm As AdvantageFramework.Billing.Presentation.AvalaraRepostForm = Nothing

            AvalaraRepostForm = New AdvantageFramework.Billing.Presentation.AvalaraRepostForm()

            AvalaraRepostForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AvalaraRepostForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Post.Image = AdvantageFramework.My.Resources.SaveImage

            DataGridViewForm_AvalaraInvoices.MultiSelect = True

            Me.ByPassUserEntryChanged = True

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Post.Click

            Dim AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice) = Nothing
            Dim InvoiceNumbers As IEnumerable(Of String) = Nothing

            If DataGridViewForm_AvalaraInvoices.HasASelectedRow Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ButtonItemActions_Post.Enabled = False

                    Me.ShowWaitForm("Please wait...")

                    InvoiceNumbers = (From Entity In DataGridViewForm_AvalaraInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice)().ToList
                                      Select Entity.InvoiceNumber).Distinct.ToList

                    AvaTaxInvoiceList = DataGridViewForm_AvalaraInvoices.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice)().Where(Function(Entity) InvoiceNumbers.Contains(Entity.InvoiceNumber)).ToList

                    If AdvantageFramework.AvaTax.PostFailedARSummaryToAvaTax(Me.Session, AvaTaxInvoiceList) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("One or more invoices failed to post to AvaTax.")

                    End If

                    LoadGrid()

                    Me.CloseWaitForm()

                    ButtonItemActions_Post.Enabled = True

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraInvoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AvalaraInvoices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace