Namespace Maintenance.Client.Presentation

    Public Class ClientMediaSalesClassOverrideCopyDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum CopyMode
            CopySalesClassOverrides
            CopyProductPercentages
        End Enum

#End Region

#Region " Variables "

        Private _ClientMediaPercentageCopyFrom As AdvantageFramework.Database.Classes.ClientMediaPercentage = Nothing
        Private _CopyMode As CopyMode = CopyMode.CopySalesClassOverrides

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ClientMediaPercentageCopyFrom As AdvantageFramework.Database.Classes.ClientMediaPercentage, CopyMode As CopyMode)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientMediaPercentageCopyFrom = ClientMediaPercentageCopyFrom
            _CopyMode = CopyMode

        End Sub
        Private Sub LoadGrid()

            Dim ClientMediaPercentageCopyToList As Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage) = Nothing
            Dim ClientMediaPercentageCopyFrom As AdvantageFramework.Database.Classes.ClientMediaPercentage = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientMediaPercentageCopyToList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)(String.Format("exec advsp_maintenance_media_percentages '{0}'", DbContext.UserCode)).ToList

            End Using

            ClientMediaPercentageCopyFrom = (From Entity In ClientMediaPercentageCopyToList
                                             Where Entity.ClientCode = _ClientMediaPercentageCopyFrom.ClientCode AndAlso
                                                   Entity.DivisionCode = _ClientMediaPercentageCopyFrom.DivisionCode AndAlso
                                                   Entity.ProductCode = _ClientMediaPercentageCopyFrom.ProductCode
                                             Select Entity).FirstOrDefault

            ClientMediaPercentageCopyToList.Remove(ClientMediaPercentageCopyFrom)

            DataGridViewForm_CopyTo.DataSource = ClientMediaPercentageCopyToList

            HideColumns(DataGridViewForm_CopyTo)

            DataGridViewForm_CopyTo.CurrentView.BestFitColumns()
            DataGridViewForm_CopyTo.CurrentView.ViewCaption = "Copy To"

        End Sub
        Private Sub HideColumns(DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridView.Columns

                If GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientCode.ToString AndAlso
                        GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ClientName.ToString AndAlso
                        GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionCode.ToString AndAlso
                        GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.DivisionName.ToString AndAlso
                        GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductCode.ToString AndAlso
                        GridColumn.FieldName <> AdvantageFramework.Database.Classes.ClientMediaPercentage.Properties.ProductDescription.ToString Then

                    GridColumn.Visible = False

                End If

            Next


        End Sub
        Private Sub CopySaleClassOverrides()

            'objects
            Dim ClientMediaPercentageCopyToList As Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage) = Nothing
            Dim ProductMediaOverridesList As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing
            Dim CreatedDate As Date = Nothing

            CreatedDate = Now

            ClientMediaPercentageCopyToList = DataGridViewForm_CopyTo.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)().ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ProductMediaOverridesList = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, _ClientMediaPercentageCopyFrom.ClientCode, _ClientMediaPercentageCopyFrom.DivisionCode, _ClientMediaPercentageCopyFrom.ProductCode).ToList

                For Each ClientMediaPercentageCopyTo In ClientMediaPercentageCopyToList

                    DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.PRODUCT_MEDIA_OVERRIDES WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'", ClientMediaPercentageCopyTo.ClientCode, ClientMediaPercentageCopyTo.DivisionCode, ClientMediaPercentageCopyTo.ProductCode))

                    For Each ProductMediaOverride In ProductMediaOverridesList

                        ProductMediaOverrides = New AdvantageFramework.Database.Entities.ProductMediaOverrides

                        ProductMediaOverrides.ClientCode = ClientMediaPercentageCopyTo.ClientCode
                        ProductMediaOverrides.DivisionCode = ClientMediaPercentageCopyTo.DivisionCode
                        ProductMediaOverrides.ProductCode = ClientMediaPercentageCopyTo.ProductCode
                        ProductMediaOverrides.MediaType = ProductMediaOverride.MediaType
                        ProductMediaOverrides.SalesClassCode = ProductMediaOverride.SalesClassCode
                        ProductMediaOverrides.RebatePercent = ProductMediaOverride.RebatePercent
                        ProductMediaOverrides.MarkupPercent = ProductMediaOverride.MarkupPercent
                        ProductMediaOverrides.CreatedByUserCode = Session.UserCode
                        ProductMediaOverrides.CreatedDate = CreatedDate

                        DbContext.ProductMediaOverrides.Add(ProductMediaOverrides)

                    Next

                Next

                Try

                    DbContext.SaveChanges()

                    AdvantageFramework.WinForm.MessageBox.Show("Copy was successful.")

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub CopyProductPercentages()

            'objects
            Dim ClientMediaPercentageCopyToList As Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage) = Nothing
            Dim ProductCopyFrom As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ProductCopyTo As AdvantageFramework.Database.Entities.Product = Nothing

            ClientMediaPercentageCopyToList = DataGridViewForm_CopyTo.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)().ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ProductCopyFrom = DbContext.Products.Find(_ClientMediaPercentageCopyFrom.ClientCode, _ClientMediaPercentageCopyFrom.DivisionCode, _ClientMediaPercentageCopyFrom.ProductCode)

                If ProductCopyFrom IsNot Nothing Then

                    For Each ClientMediaPercentageCopyTo In ClientMediaPercentageCopyToList

                        ProductCopyTo = DbContext.Products.Find(ClientMediaPercentageCopyTo.ClientCode, ClientMediaPercentageCopyTo.DivisionCode, ClientMediaPercentageCopyTo.ProductCode)

                        If ProductCopyTo IsNot Nothing Then

                            ProductCopyTo.InternetMarkup = ProductCopyFrom.InternetMarkup
                            ProductCopyTo.InternetRebate = ProductCopyFrom.InternetRebate
                            ProductCopyTo.MagazineMarkup = ProductCopyFrom.MagazineMarkup
                            ProductCopyTo.MagazineRebate = ProductCopyFrom.MagazineRebate
                            ProductCopyTo.NewspaperMarkup = ProductCopyFrom.NewspaperMarkup
                            ProductCopyTo.NewspaperRebate = ProductCopyFrom.NewspaperRebate
                            ProductCopyTo.OutOfHomeMarkup = ProductCopyFrom.OutOfHomeMarkup
                            ProductCopyTo.OutOfHomeRebate = ProductCopyFrom.OutOfHomeRebate
                            ProductCopyTo.RadioMarkup = ProductCopyFrom.RadioMarkup
                            ProductCopyTo.RadioRebate = ProductCopyFrom.RadioRebate
                            ProductCopyTo.TelevisionMarkup = ProductCopyFrom.TelevisionMarkup
                            ProductCopyTo.TelevisionRebate = ProductCopyFrom.TelevisionRebate

                        End If

                    Next

                    Try

                        DbContext.SaveChanges()

                        AdvantageFramework.WinForm.MessageBox.Show("Copy was successful.")

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Catch ex As Exception

                    End Try

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ClientMediaPercentageCopyFrom As AdvantageFramework.Database.Classes.ClientMediaPercentage, CopyMode As CopyMode) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientMediaSalesClassOverrideCopyDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientMediaSalesClassOverrideCopyDialog = Nothing

            ClientMediaSalesClassOverrideCopyDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientMediaSalesClassOverrideCopyDialog(ClientMediaPercentageCopyFrom, CopyMode)

            ShowFormDialog = ClientMediaSalesClassOverrideCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientMediaSalesClassOverrideCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim ClientMediaPercentageCopyFrom As Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage) = Nothing

            If _CopyMode = CopyMode.CopySalesClassOverrides Then

                Me.Text = "Copy Sales Class Override"

            ElseIf _CopyMode = CopyMode.CopyProductPercentages Then

                Me.Text = "Copy Product Percentages"

            End If

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ClientMediaPercentageCopyFrom = New Generic.List(Of AdvantageFramework.Database.Classes.ClientMediaPercentage)
            ClientMediaPercentageCopyFrom.Add(_ClientMediaPercentageCopyFrom)

            DataGridViewForm_CopyFrom.DataSource = ClientMediaPercentageCopyFrom

            DataGridViewForm_CopyFrom.CurrentView.BestFitColumns()
            DataGridViewForm_CopyFrom.CurrentView.ViewCaption = "Copy From"

            HideColumns(DataGridViewForm_CopyFrom)

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Copy.Click

            If DataGridViewForm_CopyTo.HasASelectedRow Then

                If _CopyMode = CopyMode.CopySalesClassOverrides Then

                    CopySaleClassOverrides()

                ElseIf _CopyMode = CopyMode.CopyProductPercentages Then

                    CopyProductPercentages()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one client/division/product to copy to.")

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
