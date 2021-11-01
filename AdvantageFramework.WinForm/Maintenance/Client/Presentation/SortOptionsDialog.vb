Namespace Maintenance.Client.Presentation

    Public Class SortOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum NewEntityType
            Client
            Division
            Product
            Vendor
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _SortKey As String = Nothing
        Private _IsNewEntity As Boolean = Nothing
        Private _EntityType As NewEntityType = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property SortKey As String
            Get
                SortKey = _SortKey
            End Get
        End Property
        Private ReadOnly Property EntityType As NewEntityType
            Get
                EntityType = _EntityType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef IsNewEntity As Boolean, ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef VendorCode As String, ByRef EntityType As NewEntityType)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _IsNewEntity = IsNewEntity
            _EntityType = EntityType
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _VendorCode = VendorCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef SortKey As String, ByVal IsNewEntity As Boolean, Optional ByRef ClientCode As String = "", Optional ByRef DivisionCode As String = "", Optional ByRef ProductCode As String = "", Optional ByRef VendorCode As String = "", Optional ByVal EntityType As NewEntityType = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim SortOptionsDialog As AdvantageFramework.Maintenance.Client.Presentation.SortOptionsDialog = Nothing

            SortOptionsDialog = New AdvantageFramework.Maintenance.Client.Presentation.SortOptionsDialog(IsNewEntity, ClientCode, DivisionCode, ProductCode, VendorCode, EntityType)

            ShowFormDialog = SortOptionsDialog.ShowDialog()

            SortKey = SortOptionsDialog.SortKey
            EntityType = SortOptionsDialog.EntityType

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SortOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If Product IsNot Nothing Then

                        Me.Text = "Add Product Sort Key"

                        TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.ProductSortKey.Properties.SortKey)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("You have selected an invalid product for adding a sort key.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Me.Close()

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    If Division IsNot Nothing Then

                        Me.Text = "Add Division Sort Key"

                        TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.DivisionSortKey.Properties.SortKey)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("You have selected an invalid division for adding a sort key.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Me.Close()

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    If Client IsNot Nothing Then

                        Me.Text = "Add Client Sort Key"

                        TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.ClientSortKey.Properties.SortKey)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("You have selected an invalid client for adding a sort key.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Me.Close()

                    End If

                ElseIf _VendorCode <> "" Then

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        Me.Text = "Add Vendor Sort Key"

                        TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.Vendor.Properties.Code)

                    End If

                ElseIf _IsNewEntity Then

                    Select Case Me.EntityType

                        Case NewEntityType.Client

                            Me.Text = "Add Client Sort Key"
                            TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.ClientSortKey.Properties.SortKey)

                        Case NewEntityType.Division

                            Me.Text = "Add Division Sort Key"
                            TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.DivisionSortKey.Properties.SortKey)

                        Case NewEntityType.Product

                            Me.Text = "Add Product Sort Key"
                            TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.ProductSortKey.Properties.SortKey)

                        Case NewEntityType.Vendor

                            Me.Text = "Add Vendor Sort Key"
                            TextBoxForm_SortOption.SetPropertySettings(AdvantageFramework.Database.Entities.Vendor.Properties.Code)

                    End Select

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Sort options are only for Client, Division, Products, Vendors. Please select one and try again.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            If Me.Validator Then

                If _IsNewEntity Then

                    _SortKey = TextBoxForm_SortOption.Text

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                            If AdvantageFramework.Database.Procedures.ProductSortKey.Insert(DbContext, _ClientCode, _DivisionCode, _ProductCode, TextBoxForm_SortOption.Text, Nothing) Then

                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                            If AdvantageFramework.Database.Procedures.DivisionSortKey.Insert(DbContext, _ClientCode, _DivisionCode, TextBoxForm_SortOption.Text, Nothing) Then

                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                            If AdvantageFramework.Database.Procedures.ClientSortKey.Insert(DbContext, _ClientCode, TextBoxForm_SortOption.Text, Nothing) Then

                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        ElseIf _VendorCode <> "" Then

                            If AdvantageFramework.Database.Procedures.VendorSortKey.Insert(DbContext, _VendorCode, TextBoxForm_SortOption.Text, Nothing) Then

                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        End If

                    End Using

                End If

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