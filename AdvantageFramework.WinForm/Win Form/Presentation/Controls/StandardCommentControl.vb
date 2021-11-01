Namespace WinForm.Presentation.Controls

    Public Class StandardCommentControl

        Public Event CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _CommentID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim FontSizeList As Generic.List(Of Short) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxRightSection_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.StandardComment.Properties.Comment)

                            TextBoxRightSection_Comment.MaxLength = 0

                            SearchableComboBoxSettings_Office.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxSettings_Vendor.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxSettings_Clients.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxSettings_Divisions.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxSettings_Products.AddInactiveItemsOnSelectedValue = True

                            ComboBoxRightSection_Type.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.StandardCommentTypes))

                            ' Font size list
                            FontSizeList = New Generic.List(Of Short)

                            For I = 3 To 72

                                If I < 12 Then

                                    FontSizeList.Add(I)

                                ElseIf I >= 12 AndAlso I <= 28 AndAlso I Mod 2 = 0 Then

                                    FontSizeList.Add(I)

                                ElseIf I = 36 OrElse I = 48 OrElse I = 72 Then

                                    FontSizeList.Add(I)

                                End If

                            Next

                            ComboBoxRightSection_FontSize.DataSource = FontSizeList.Select(Function(Size) New With {.FontSize = Size}).ToList

                            ComboBoxRightSection_Application.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.StandardCommentApplications))

                            LoadDropDownDataSources()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadDivisions()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadDivisions(DbContext)

            End Using

        End Sub
        Private Sub LoadDivisions(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim ClientCode As String = Nothing

            If SearchableComboBoxSettings_Clients.HasASelectedValue Then

                SearchableComboBoxSettings_Divisions.Enabled = True

                If SearchableComboBoxSettings_Divisions.Enabled Then

                    ClientCode = SearchableComboBoxSettings_Clients.GetSelectedValue

                    SearchableComboBoxSettings_Divisions.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)
                                                                      Where Division.ClientCode = ClientCode
                                                                      Select Division

                End If

            Else

                SearchableComboBoxSettings_Divisions.Enabled = False
                SearchableComboBoxSettings_Divisions.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

            End If

        End Sub
        Private Sub LoadProducts()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadProducts(DbContext)

            End Using

        End Sub
        Private Sub LoadProducts(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If SearchableComboBoxSettings_Clients.HasASelectedValue AndAlso SearchableComboBoxSettings_Divisions.HasASelectedValue Then

                SearchableComboBoxSettings_Products.Enabled = True

                If SearchableComboBoxSettings_Products.Enabled = True Then

                    ClientCode = SearchableComboBoxSettings_Clients.GetSelectedValue
                    DivisionCode = SearchableComboBoxSettings_Divisions.GetSelectedValue

                    SearchableComboBoxSettings_Products.DataSource = AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode)

                End If

            Else

                SearchableComboBoxSettings_Products.Enabled = False
                SearchableComboBoxSettings_Products.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            End If

        End Sub
        Private Sub LoadCommentEntity(ByVal StandardComment As AdvantageFramework.Database.Entities.StandardComment)

            If StandardComment IsNot Nothing Then

                StandardComment.ApplicationCode = ComboBoxRightSection_Application.GetSelectedValue
                StandardComment.CommentType = ComboBoxRightSection_Type.GetSelectedValue
                StandardComment.FontSize = ComboBoxRightSection_FontSize.GetSelectedValue

                If ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaRFP.ToString) OrElse
                        ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.InvoicesCoversheet.ToString) OrElse
                        ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaTraffic.ToString) Then

                    StandardComment.HtmlComment = RichEditControl_Comment.HtmlBodyOnly
                    StandardComment.Comment = RichEditControl_Comment.Text

                Else

                    StandardComment.Comment = TextBoxRightSection_Comment.Text

                End If

                StandardComment.OfficeCode = If(SearchableComboBoxSettings_Office.HasASelectedValue AndAlso SearchableComboBoxSettings_Office.Enabled, SearchableComboBoxSettings_Office.GetSelectedValue, Nothing)
                StandardComment.ClientCode = If(SearchableComboBoxSettings_Clients.HasASelectedValue AndAlso SearchableComboBoxSettings_Clients.Enabled, SearchableComboBoxSettings_Clients.GetSelectedValue, Nothing)
                StandardComment.DivisionCode = If(SearchableComboBoxSettings_Divisions.HasASelectedValue AndAlso SearchableComboBoxSettings_Divisions.Enabled, SearchableComboBoxSettings_Divisions.GetSelectedValue, Nothing)
                StandardComment.ProductCode = If(SearchableComboBoxSettings_Products.HasASelectedValue AndAlso SearchableComboBoxSettings_Products.Enabled, SearchableComboBoxSettings_Products.GetSelectedValue, Nothing)
                StandardComment.VendorCode = If(SearchableComboBoxSettings_Vendor.HasASelectedValue AndAlso SearchableComboBoxSettings_Vendor.Enabled, SearchableComboBoxSettings_Vendor.GetSelectedValue, Nothing)
                StandardComment.MediaType = If(SearchableComboBoxSettings_MediaType.HasASelectedValue AndAlso SearchableComboBoxSettings_MediaType.Enabled, SearchableComboBoxSettings_MediaType.GetSelectedValue, Nothing)

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxSettings_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext)
                SearchableComboBoxSettings_Vendor.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                SearchableComboBoxSettings_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                LoadDivisions(DbContext)
                LoadProducts(DbContext)
                SearchableComboBoxSettings_MediaType.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountPayableImportMediaType))
                                                                   Select New With {.Code = Entity.Code,
                                                                                    .Description = Entity.Description})

            End Using

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    StandardComment = Me.FillObject(False)

                    If StandardComment IsNot Nothing Then

                        StandardComment.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.StandardComment.Update(DbContext, StandardComment) Then

                            Saved = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    StandardComment = Me.FillObject(False)

                    If StandardComment IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.StandardComment.Delete(DbContext, StandardComment) = False Then

                            ErrorMessage = "The standard comment is in use and cannot be deleted."

                        Else

                            Deleted = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef StandardCommentID As Integer) As Boolean

            'objects
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    StandardComment = Me.FillObject(True)

                    If StandardComment IsNot Nothing Then

                        StandardComment.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.StandardComment.Insert(DbContext, StandardComment) Then

                            StandardCommentID = StandardComment.ID
                            Inserted = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal CommentID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing

            _CommentID = CommentID

            Me.ClearControl()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _CommentID <> 0 Then

                    StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByCommentID(DbContext, _CommentID)

                    If StandardComment IsNot Nothing Then

                        ComboBoxRightSection_Application.SelectedValue = StandardComment.ApplicationCode
                        ComboBoxRightSection_Type.SelectedValue = StandardComment.CommentType
                        ComboBoxRightSection_FontSize.SelectedValue = StandardComment.FontSize

                        If ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaRFP.ToString) OrElse
                                ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.InvoicesCoversheet.ToString) OrElse
                                ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaTraffic.ToString) Then

                            RichEditControl_Comment.HtmlText = StandardComment.HtmlComment

                        Else

                            TextBoxRightSection_Comment.Text = StandardComment.Comment

                        End If

                        If StandardComment.OfficeCode IsNot Nothing AndAlso StandardComment.OfficeCode <> "" Then

                            SearchableComboBoxSettings_Office.SelectedValue = StandardComment.OfficeCode

                        Else

                            SearchableComboBoxSettings_Office.SelectedValue = Nothing

                        End If

                        If StandardComment.ClientCode IsNot Nothing AndAlso StandardComment.ClientCode <> "" Then

                            SearchableComboBoxSettings_Clients.SelectedValue = StandardComment.ClientCode

                        Else

                            SearchableComboBoxSettings_Clients.SelectedValue = Nothing

                        End If

                        If StandardComment.DivisionCode IsNot Nothing AndAlso StandardComment.DivisionCode <> "" Then

                            SearchableComboBoxSettings_Divisions.SelectedValue = StandardComment.DivisionCode

                        Else

                            SearchableComboBoxSettings_Divisions.SelectedValue = Nothing

                        End If

                        If StandardComment.ProductCode IsNot Nothing AndAlso StandardComment.ProductCode <> "" Then

                            SearchableComboBoxSettings_Products.SelectedValue = StandardComment.ProductCode

                        Else

                            SearchableComboBoxSettings_Products.SelectedValue = Nothing

                        End If

                        If StandardComment.VendorCode IsNot Nothing AndAlso StandardComment.VendorCode <> "" Then

                            SearchableComboBoxSettings_Vendor.SelectedValue = StandardComment.VendorCode

                        Else

                            SearchableComboBoxSettings_Vendor.SelectedValue = Nothing

                        End If

                        If Not String.IsNullOrWhiteSpace(StandardComment.MediaType) Then

                            SearchableComboBoxSettings_MediaType.SelectedValue = StandardComment.MediaType

                        Else

                            SearchableComboBoxSettings_MediaType.SelectedValue = Nothing

                        End If

                        ComboBoxRightSection_Application.Enabled = False

                    Else

                        Loaded = False

                    End If

                Else

                    ComboBoxRightSection_Application.Enabled = True

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.StandardComment

            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing

            Try

                If IsNew Then

                    StandardComment = New AdvantageFramework.Database.Entities.StandardComment

                    LoadCommentEntity(StandardComment)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByCommentID(DbContext, _CommentID)

                        If StandardComment IsNot Nothing Then

                            LoadCommentEntity(StandardComment)

                        End If

                    End Using

                End If

            Catch ex As Exception
                StandardComment = Nothing
            End Try

            FillObject = StandardComment

        End Function
        Public Sub ClearControl(Optional ByVal ExcludeCommentBox As Boolean = False)

            If Me.ParentForm IsNot Nothing AndAlso TypeOf Me.ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                DirectCast(Me.ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ClearValidations()

            End If

            If ExcludeCommentBox = False Then

                TextBoxRightSection_Comment.Text = ""

            End If

            ComboBoxRightSection_Type.SelectedValue = "Standard Footer"

            TextBoxRightSection_Comment.Visible = True
            ComboBoxRightSection_FontSize.Enabled = True
            RichEditControl_Comment.Visible = False
            RichEditControl_Comment.RestrictFontNameSize = False
            SearchableComboBoxSettings_MediaType.SecurityEnabled = False

            If ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.Database.Entities.StandardCommentApplications.Estimates.ToString Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.SecurityEnabled = True
                SearchableComboBoxSettings_Divisions.SecurityEnabled = False
                SearchableComboBoxSettings_Products.SecurityEnabled = False
                SearchableComboBoxSettings_Vendor.SecurityEnabled = False

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.Database.Entities.StandardCommentApplications.Invoices.ToString Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.SecurityEnabled = True
                SearchableComboBoxSettings_Divisions.SecurityEnabled = True
                SearchableComboBoxSettings_Products.SecurityEnabled = True
                SearchableComboBoxSettings_Vendor.SecurityEnabled = False

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.PurchaseOrder.ToString) Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.SecurityEnabled = True
                SearchableComboBoxSettings_Divisions.SecurityEnabled = True
                SearchableComboBoxSettings_Products.SecurityEnabled = True
                SearchableComboBoxSettings_Vendor.SecurityEnabled = True

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaManagerOrders.ToString) Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.SecurityEnabled = True
                SearchableComboBoxSettings_Divisions.SecurityEnabled = True
                SearchableComboBoxSettings_Products.SecurityEnabled = True
                SearchableComboBoxSettings_Vendor.SecurityEnabled = True
                SearchableComboBoxSettings_MediaType.SecurityEnabled = True

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaRFP.ToString) Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.Enabled = False
                SearchableComboBoxSettings_Divisions.Enabled = False
                SearchableComboBoxSettings_Products.Enabled = False
                SearchableComboBoxSettings_Vendor.Enabled = False

                ComboBoxRightSection_Type.SelectedValue = "Standard Guidelines"

                TextBoxRightSection_Comment.Visible = False
                ComboBoxRightSection_FontSize.Enabled = False
                RichEditControl_Comment.Visible = True
                RichEditControl_Comment.RestrictFontNameSize = True

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.InvoicesCoversheet.ToString) Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.SecurityEnabled = True
                SearchableComboBoxSettings_Divisions.SecurityEnabled = True
                SearchableComboBoxSettings_Products.SecurityEnabled = True
                SearchableComboBoxSettings_Vendor.SecurityEnabled = False

                TextBoxRightSection_Comment.Visible = False
                ComboBoxRightSection_FontSize.Enabled = False
                RichEditControl_Comment.Visible = True

                'RichEditControl_Comment.RichEditControl.Document.DefaultCharacterProperties.FontName = "Arial"
                'RichEditControl_Comment.RichEditControl.Document.DefaultCharacterProperties.FontSize = 9

            ElseIf ComboBoxRightSection_Application.GetSelectedValue = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.StandardCommentApplications.MediaTraffic.ToString) Then

                SearchableComboBoxSettings_Office.SecurityEnabled = True
                SearchableComboBoxSettings_Clients.Enabled = False
                SearchableComboBoxSettings_Divisions.Enabled = False
                SearchableComboBoxSettings_Products.Enabled = False
                SearchableComboBoxSettings_Vendor.Enabled = False
                SearchableComboBoxSettings_MediaType.SecurityEnabled = True

                ComboBoxRightSection_Type.SelectedValue = "Standard Guidelines"

                TextBoxRightSection_Comment.Visible = False
                ComboBoxRightSection_FontSize.Enabled = False
                RichEditControl_Comment.Visible = True
                RichEditControl_Comment.RestrictFontNameSize = True

            End If

            TextBoxRightSection_Comment.SetRequired(TextBoxRightSection_Comment.Visible)
            RichEditControl_Comment.SetRequired(RichEditControl_Comment.Visible)

            ComboBoxRightSection_Type.Enabled = False

            SearchableComboBoxSettings_Divisions.Enabled = SearchableComboBoxSettings_Clients.HasASelectedValue
            SearchableComboBoxSettings_Products.Enabled = SearchableComboBoxSettings_Clients.HasASelectedValue AndAlso SearchableComboBoxSettings_Divisions.HasASelectedValue

        End Sub
        Public Sub DeselectComboBoxText()

            ComboBoxRightSection_Application.SelectionLength = 0
            ComboBoxRightSection_FontSize.SelectionLength = 0
            ComboBoxRightSection_Type.SelectionLength = 0

            SearchableComboBoxSettings_Clients.SelectionLength = 0
            SearchableComboBoxSettings_Divisions.SelectionLength = 0
            SearchableComboBoxSettings_Office.SelectionLength = 0
            SearchableComboBoxSettings_Products.SelectionLength = 0
            SearchableComboBoxSettings_Vendor.SelectionLength = 0
            SearchableComboBoxSettings_MediaType.SelectionLength = 0

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub StandardCommentControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxRightSection_Comment.TabOnEnter = False
            TextBoxRightSection_Comment.WordWrap = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub SearchableComboBoxSettings_Clients_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSettings_Clients.EditValueChanged

            SearchableComboBoxSettings_Divisions.SelectedValue = Nothing
            SearchableComboBoxSettings_Products.SelectedValue = Nothing
            LoadDivisions()

        End Sub
        Private Sub SearchableComboBoxSettings_Divisions_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSettings_Divisions.EditValueChanged

            SearchableComboBoxSettings_Products.SelectedValue = Nothing
            LoadProducts()

        End Sub
        Private Sub ComboBoxRightSection_Application_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRightSection_Application.SelectedValueChanged

            If ComboBoxRightSection_Application.HasASelectedValue Then

                Me.ClearControl(True)

            End If

        End Sub
        Private Sub ComboBoxSettings_All_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSettings_Clients.EnabledChanged, SearchableComboBoxSettings_Divisions.EnabledChanged, SearchableComboBoxSettings_Products.EnabledChanged, SearchableComboBoxSettings_Vendor.EnabledChanged, SearchableComboBoxSettings_Office.EnabledChanged, SearchableComboBoxSettings_MediaType.EnabledChanged

            If Not sender.Enabled Then

                DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).SelectedValue = Nothing

            End If

        End Sub
        Private Sub TextBoxRightSection_Comment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxRightSection_Comment.GotFocus

            RaiseEvent CommentGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxRightSection_Comment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxRightSection_Comment.LostFocus

            RaiseEvent CommentLostFocusEvent(sender, e)

        End Sub
        Private Sub RichEditControl_Comment_GotFocus(sender As Object, e As EventArgs) Handles RichEditControl_Comment.GotFocus

            RaiseEvent CommentGotFocusEvent(sender, e)

        End Sub
        Private Sub RichEditControl_Comment_LostFocus(sender As Object, e As EventArgs) Handles RichEditControl_Comment.LostFocus

            RaiseEvent CommentLostFocusEvent(sender, e)

        End Sub
        Private Sub SearchableComboBoxSettings_MediaType_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxSettings_MediaType.QueryPopupNeedDataSource

        End Sub

#End Region

#End Region

    End Class

End Namespace
