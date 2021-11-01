Public Class Importing_CreateOrder
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ShowOrderDescription As Boolean = Nothing

#End Region

#Region " Properties "

    'Private Property ImportOrders As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder)
    '    Get
    '        ImportOrders = ViewState("CurImportOrders")
    '    End Get
    '    Set(value As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder))
    '        ViewState("CurImportOrders") = value
    '    End Set
    'End Property
    Private Property WebImportOrders As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)
        Get
            WebImportOrders = Session("CurImportOrders")
        End Get
        Set(value As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder))
            Session("CurImportOrders") = value
        End Set
    End Property
    Private Property IsDirectPost As Boolean
        Get

            If ViewState("DirectPost") IsNot Nothing Then

                IsDirectPost = ViewState("DirectPost")

            Else

                IsDirectPost = True

            End If

        End Get
        Set(value As Boolean)
            ViewState("DirectPost") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub EnableOrDisableActions()

        RadToolBarButtonAssignID.Enabled = Not Me.IsDirectPost

    End Sub
    Private Sub ApplyGrouping()

        Dim GridGroupByExpression As Telerik.Web.UI.GridGroupByExpression = Nothing
        Dim GridGroupByField As Telerik.Web.UI.GridGroupByField = Nothing

        GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
        GridGroupByField = New Telerik.Web.UI.GridGroupByField

        GridGroupByField.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString
        GridGroupByField.HeaderText = "Media Type"

        GridGroupByExpression.SelectFields.Add(GridGroupByField)

        RadGridOrders.MasterTableView.GroupByExpressions.Add(GridGroupByExpression)

    End Sub
    Private Sub CreateOrders()

        'objects
        Dim WebImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder) = Nothing
        Dim ImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder) = Nothing
        Dim ExportPath As String = ""
        Dim ErrorMessage As String = ""
        Dim DirectPost As Boolean = True
        Dim Created As Boolean = False

        Try

            WebImportOrderList = LoadWebImportOrderList()

            If WebImportOrderList IsNot Nothing AndAlso WebImportOrderList.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        If ValidateImportOrders(DbContext, WebImportOrderList, ErrorMessage) Then

                            'AdvantageFramework.Media.LoadExportPath(DbContext, WebImportOrderList.First.Value.ImportSource, ExportPath, DirectPost)

                            ImportOrderList = New Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder)

                            For Each KeyValue In WebImportOrderList

                                ImportOrderList.Add(KeyValue.Key, KeyValue.Value.GetImportOrder)

                            Next

                            CreateOrderData(DbContext, DataContext, ImportOrderList)

                            If DirectPost Then

                                Created = AdvantageFramework.Media.DirectPostImportOrders(DbContext, DataContext, AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default, ImportOrderList.Values.ToList, _ShowOrderDescription, RadTextBoxDescription.Text)

                            Else

                                Created = CreateOrderFiles(DbContext, ImportOrderList, ExportPath)

                            End If

                        End If

                    End Using

                End Using

            End If

        Catch ex As Exception
            Created = False
        End Try

        If Created Then

            'not really an error
            Me.ShowMessage(String.Format("Order file(s) created{0}, use the Media Generic Import to finalize order creation.", If(DirectPost, " (Direct Post)", "")))
            Me.CloseThisWindow()

        Else

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                ErrorMessage = "There was a problem creating the order(s)."

            End If

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub CreateOrderData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                ByVal DataContext As AdvantageFramework.Database.DataContext,
                                ByVal ImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder))

        Select Case ImportOrderList.First.Value.ImportSource

            Case AdvantageFramework.Media.ImportSource.Default


            Case AdvantageFramework.Media.ImportSource.MediaPlanning


            Case AdvantageFramework.Media.ImportSource.AuthorizationToBuy

                AdvantageFramework.Media.CreateMediaATBRevisionDetailOrdersFromImportOrders(DbContext, DataContext, ImportOrderList.Values.ToList)

        End Select

    End Sub
    Private Sub AssignOrderIDs(ByVal WebImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder))

        'objects
        Dim FilteredImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder) = Nothing
        Dim FilteredImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.WebImportOrder) = Nothing
        Dim Key As Integer = Nothing

        If WebImportOrderList IsNot Nothing AndAlso WebImportOrderList.Count > 0 Then

            FilteredImportOrderList = New Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)

            For Each item In WebImportOrderList

                If item.Value.IsRevision = False Then

                    FilteredImportOrderList.Add(item.Key, item.Value)

                End If

            Next

            If FilteredImportOrderList.Count > 0 Then

                FilteredImportOrders = FilteredImportOrderList.Values.ToList

                If AdvantageFramework.Media.AssignOrderID(_Session, AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default, FilteredImportOrders) Then

                    For Each FilteredImportOrder In FilteredImportOrders

                        Key = -1

                        Try

                            Key = FilteredImportOrderList.Skip(FilteredImportOrders.IndexOf(FilteredImportOrder)).Take(1).FirstOrDefault().Key

                            If WebImportOrderList.ContainsKey(Key) Then

                                WebImportOrderList(Key) = FilteredImportOrder

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    Me.WebImportOrders = WebImportOrderList

                End If

            End If

        End If

    End Sub
    Private Sub LoadImportOrderEntity(ByVal GridItem As Telerik.Web.UI.GridItem, ByRef WebImportOrder As AdvantageFramework.Media.Classes.WebImportOrder)

        'objects
        Dim RadNumericTextBoxOrderID As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RadNumericTextBoxLineNumber As Telerik.Web.UI.RadNumericTextBox = Nothing

        If GridItem IsNot Nothing AndAlso WebImportOrder IsNot Nothing Then

            RadNumericTextBoxOrderID = GridItem.FindControl("RadNumericTextBoxOrderID")
            RadNumericTextBoxLineNumber = GridItem.FindControl("RadNumericTextBoxLineNumber")

            If RadNumericTextBoxOrderID IsNot Nothing AndAlso RadNumericTextBoxOrderID.Value.HasValue Then

                WebImportOrder.OrderID = CInt(RadNumericTextBoxOrderID.Value)

            Else

                WebImportOrder.OrderID = Nothing

            End If

            If RadNumericTextBoxLineNumber IsNot Nothing AndAlso RadNumericTextBoxLineNumber.Value.HasValue Then

                WebImportOrder.LineNumber = CInt(RadNumericTextBoxLineNumber.Value)

            Else

                WebImportOrder.LineNumber = Nothing

            End If

        End If

    End Sub
    Private Function GetGridItemKey(ByVal GridItem As Telerik.Web.UI.GridItem) As Integer

        'objects
        Dim Key As Integer = 0
        Dim HiddenFieldKey As System.Web.UI.WebControls.HiddenField = Nothing

        Try

            If GridItem IsNot Nothing Then

                HiddenFieldKey = GridItem.FindControl("HiddenFieldKey")

                If HiddenFieldKey IsNot Nothing Then

                    Key = CInt(HiddenFieldKey.Value)

                End If

            End If

        Catch ex As Exception
            Key = 0
        Finally
            GetGridItemKey = Key
        End Try

    End Function
    Private Function ConvertStringBuilderToStream(ByVal FileStringBuilder As System.Text.StringBuilder) As System.IO.MemoryStream

        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim UTF8Encoding As System.Text.UTF8Encoding = Nothing

        If FileStringBuilder IsNot Nothing AndAlso FileStringBuilder.Length > 0 Then

            MemoryStream = New System.IO.MemoryStream
            UTF8Encoding = New System.Text.UTF8Encoding

            MemoryStream.Write(UTF8Encoding.GetBytes(FileStringBuilder.ToString()), 0, FileStringBuilder.Length)

        End If

        ConvertStringBuilderToStream = MemoryStream

    End Function
    Private Function DownloadFile(ByVal MemoryStream As System.IO.MemoryStream, ByVal FullFileName As String, ByVal ContentType As String) As Boolean

        'objects
        Dim Downloaded As Boolean = False

        If MemoryStream IsNot Nothing Then

            System.Web.HttpContext.Current.Response.Clear()

            System.Web.HttpContext.Current.Response.Buffer = True
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", ContentType)
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FullFileName)
            System.Web.HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray)

            HttpContext.Current.ApplicationInstance.CompleteRequest()

            Try

                HttpContext.Current.Response.End()

            Catch ex As Exception

            End Try

            Downloaded = True

        Else

            Downloaded = False

        End If

        DownloadFile = Downloaded

    End Function
    Private Function IsReadOnlyColumn(ByVal FieldName As String, ByVal ImportOrder As AdvantageFramework.Media.Classes.WebImportOrder) As Boolean

        'objects
        Dim IsReadOnly As Boolean = False
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

        Try

            PropertyDescriptor = (From PropDesc In System.ComponentModel.TypeDescriptor.GetProperties(ImportOrder).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                  Where PropDesc.Name = FieldName
                                  Select PropDesc).SingleOrDefault

            If PropertyDescriptor IsNot Nothing Then

                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                If EntityAttribute IsNot Nothing Then

                    IsReadOnly = EntityAttribute.IsReadOnlyColumn

                End If

            End If

        Catch ex As Exception
            IsReadOnly = False
        Finally
            IsReadOnlyColumn = IsReadOnly
        End Try

    End Function
    Private Function CreateOrderFiles(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal ImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.ImportOrder),
                                      ByVal ExportPath As String) As Boolean

        'objects
        Dim BroadcastFullFileName As String = Nothing
        Dim BroadcastStringBuilder As System.Text.StringBuilder = Nothing
        Dim InternetFullFileName As String = Nothing
        Dim InternetStringBuilder As System.Text.StringBuilder = Nothing
        Dim NewspaperFullFileName As String = Nothing
        Dim NewspaperStringBuilder As System.Text.StringBuilder = Nothing
        Dim MagazineFullFileName As String = Nothing
        Dim MagazineStringBuilder As System.Text.StringBuilder = Nothing
        Dim OutOfHomeFullFileName As String = Nothing
        Dim OutOfHomeStringBuilder As System.Text.StringBuilder = Nothing
        Dim FileList As Generic.Dictionary(Of String, System.Text.StringBuilder) = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Saved As Boolean = False

        Try

            BroadcastStringBuilder = New System.Text.StringBuilder
            InternetStringBuilder = New System.Text.StringBuilder
            NewspaperStringBuilder = New System.Text.StringBuilder
            MagazineStringBuilder = New System.Text.StringBuilder
            OutOfHomeStringBuilder = New System.Text.StringBuilder

            AdvantageFramework.Media.CreateOrderFiles(DbContext, ImportOrderList.Values.ToList, _ShowOrderDescription, RadTextBoxDescription.Text, BroadcastFullFileName, BroadcastStringBuilder,
                                                      InternetFullFileName, InternetStringBuilder, NewspaperFullFileName, NewspaperStringBuilder, MagazineFullFileName, MagazineStringBuilder,
                                                      OutOfHomeFullFileName, OutOfHomeStringBuilder, ExportPath)

            FileList = New Generic.Dictionary(Of String, System.Text.StringBuilder)

            If BroadcastStringBuilder IsNot Nothing AndAlso BroadcastStringBuilder.Length > 0 Then

                FileList.Add(BroadcastFullFileName, BroadcastStringBuilder)

            End If

            If InternetStringBuilder IsNot Nothing AndAlso InternetStringBuilder.Length > 0 Then

                FileList.Add(InternetFullFileName, InternetStringBuilder)

            End If

            If NewspaperStringBuilder IsNot Nothing AndAlso NewspaperStringBuilder.Length > 0 Then

                FileList.Add(NewspaperFullFileName, NewspaperStringBuilder)

            End If

            If MagazineStringBuilder IsNot Nothing AndAlso MagazineStringBuilder.Length > 0 Then

                FileList.Add(MagazineFullFileName, MagazineStringBuilder)

            End If

            If OutOfHomeStringBuilder IsNot Nothing AndAlso OutOfHomeStringBuilder.Length > 0 Then

                FileList.Add(OutOfHomeFullFileName, OutOfHomeStringBuilder)

            End If

            If FileList.Count >= 1 Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                For Each File In FileList

                    If AdvantageFramework.Media.WriteFile(File.Value, File.Key, Agency.FileSystemUserName, Agency.FileSystemDomain, Agency.FileSystemPassword) Then

                        Saved = True

                    End If

                Next

            End If

        Catch ex As Exception

        End Try

        CreateOrderFiles = Saved

    End Function
    Private Function LoadWebImportOrderList() As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)

        'objects
        Dim WebImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)
        Dim WebImportOrder As AdvantageFramework.Media.Classes.WebImportOrder = Nothing
        Dim Key As Integer = Nothing

        WebImportOrderList = New Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)

        Try

            For Each GridItem In RadGridOrders.Items.OfType(Of Telerik.Web.UI.GridItem)()

                Key = GetGridItemKey(GridItem)

                If Key > 0 Then

                    WebImportOrder = Me.WebImportOrders(Key)

                    If WebImportOrder IsNot Nothing Then

                        LoadImportOrderEntity(GridItem, WebImportOrder)

                        If WebImportOrder IsNot Nothing Then

                            WebImportOrderList.Add(Key, WebImportOrder)

                        End If

                    End If

                End If

            Next

        Catch ex As Exception
            WebImportOrderList = Nothing
        Finally
            LoadWebImportOrderList = WebImportOrderList
        End Try

    End Function
    Private Function ValidateImportOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal WebImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder),
                                          ByRef ErrorMessage As String) As Boolean

        'objects
        Dim IsValid As Boolean = False
        Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing

        Try

            IsValid = True

            For Each WebImportOrder In WebImportOrderList.Values

                ImportOrder = WebImportOrder.GetImportOrder()

                ImportOrder.DbContext = DbContext

                ErrorMessage = ImportOrder.ValidateEntity(IsValid)

                If IsValid = False Then

                    Exit For

                End If

            Next

        Catch ex As Exception
            IsValid = False
        Finally
            ValidateImportOrders = IsValid
        End Try

    End Function

#Region " Show Form Methods "

    Public Shared Function GenerateBaseQueryString(ByVal WebImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.WebImportOrder), ByVal ShowOrderDescription As Boolean) As String

        'objects
        Dim VariableList As Generic.Dictionary(Of String, String) = Nothing
        Dim QueryString As String = ""
        Dim WebImportOrderList As Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder) = Nothing

        Try

            WebImportOrderList = New Generic.Dictionary(Of Integer, AdvantageFramework.Media.Classes.WebImportOrder)

            For I = 1 To WebImportOrders.Count

                WebImportOrderList.Add(I, WebImportOrders.Item(I - 1))

            Next

            HttpContext.Current.Session("CurImportOrders") = WebImportOrderList

            VariableList = New Generic.Dictionary(Of String, String)

            VariableList.Add("Desc", If(ShowOrderDescription, 1, 0).ToString)

            QueryString = "Importing_CreateOrder.aspx?"

            Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            For Each Variable In VariableList

                QueryString &= Variable.Key & "=" & Sanitizer.Sanitize(Variable.Value) & "&"

            Next

            QueryString = QueryString.Substring(0, QueryString.Length - 1)

        Catch ex As Exception
            QueryString = "Importing_CreateOrder.aspx"
        Finally
            GenerateBaseQueryString = QueryString
        End Try

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Request.QueryString("Desc") IsNot Nothing Then

                _ShowOrderDescription = CBool(CShort(Request.QueryString("Desc")))

            End If

        Catch ex As Exception
            _ShowOrderDescription = False
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim DirectPost As Boolean = True
        Dim ExportPath As String = ""

        Me.Title = "Create Order"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'AdvantageFramework.Media.LoadExportPath(DbContext, Me.WebImportOrders.First.Value.ImportSource, ExportPath, DirectPost)

                Me.IsDirectPost = DirectPost

                If DirectPost = True Then

                    AssignOrderIDs(Me.WebImportOrders)

                End If

            End Using

            If _ShowOrderDescription Then

                Me.TrDescription.Visible = True
                Me.RadTextBoxDescription.Text = MonthName(Now.Month) & " Media"

            Else

                Me.TrDescription.Visible = False

            End If

        End If

        EnableOrDisableActions()

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadToolbarOptions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarOptions.ButtonClick

        If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

            Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                Case RadToolBarButtonSave.CommandName

                    CreateOrders()

                Case RadToolBarButtonCancel.CommandName

                    Me.CloseThisWindow()

                Case RadToolBarButtonAssignID.CommandName

                    AssignOrderIDs(LoadWebImportOrderList())

                    RadGridOrders.Rebind()

            End Select

        End If

    End Sub
    Private Sub RadGridOrders_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridOrders.ItemCommand

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = False
        Dim Command As String = Nothing
        Dim CommandArgument As String = Nothing
        Dim ErrorText As String = Nothing

        Command = e.CommandName.ToString.ToUpper
        CommandArgument = e.CommandArgument.ToString

        Try

            GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

        Catch ex As Exception
            GridDataItem = Nothing
        End Try

        Select Case Command

            Case "DELETE"

                If IsNumeric(CommandArgument) Then

                    Try

                        If Me.WebImportOrders.Remove(CInt(CommandArgument)) = False Then

                            e.Canceled = True

                        End If

                    Catch ex As Exception
                        e.Canceled = True
                        ErrorText = "There was a problem deleting the item."
                    End Try

                End If

        End Select

        If ErrorText <> "" Then

            Me.ShowMessage(ErrorText)

        End If

    End Sub
    Private Sub RadGridOrders_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridOrders.ItemDataBound

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim WebImportOrder As AdvantageFramework.Media.Classes.WebImportOrder = Nothing
        Dim RadNumericTextBoxOrderID As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RadNumericTextBoxLineNumber As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim Key As Integer = Nothing
        Dim HiddenFieldKey As System.Web.UI.WebControls.HiddenField = Nothing
        Dim ImageError As System.Web.UI.WebControls.Image = Nothing
        Dim ErrorMessage As String = ""
        Dim IsValid As Boolean = True

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                Try

                    GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

                Catch ex As Exception
                    GridDataItem = Nothing
                End Try

                If GridDataItem IsNot Nothing Then

                    Try

                        WebImportOrder = DirectCast(GridDataItem.DataItem, AdvantageFramework.Media.Classes.WebImportOrder)

                    Catch ex As Exception
                        WebImportOrder = Nothing
                    End Try

                    If WebImportOrder IsNot Nothing Then

                        Try

                            Key = (From Entity In Me.WebImportOrders _
                                   Where Entity.Value Is WebImportOrder _
                                   Select [ThisKey] = Entity.Key).SingleOrDefault

                        Catch ex As Exception

                        End Try

                        RadNumericTextBoxOrderID = GridDataItem.FindControl("RadNumericTextBoxOrderID")
                        RadNumericTextBoxLineNumber = GridDataItem.FindControl("RadNumericTextBoxLineNumber")
                        HiddenFieldKey = GridDataItem.FindControl("HiddenFieldKey")

                        If RadNumericTextBoxOrderID IsNot Nothing Then

                            If WebImportOrder.OrderID.HasValue Then

                                RadNumericTextBoxOrderID.Text = WebImportOrder.OrderID

                                If WebImportOrder.ImportSource = AdvantageFramework.Media.ImportSource.AuthorizationToBuy Then

                                    RadNumericTextBoxOrderID.ReadOnly = IsReadOnlyColumn(AdvantageFramework.Media.Classes.WebImportOrder.Properties.OrderID.ToString, WebImportOrder)

                                End If

                            End If

                            If Me.IsDirectPost() Then

                                RadNumericTextBoxOrderID.ReadOnly = True

                            End If

                        End If

                        If RadNumericTextBoxLineNumber IsNot Nothing Then

                            If WebImportOrder.LineNumber.HasValue Then

                                RadNumericTextBoxLineNumber.Text = WebImportOrder.LineNumber

                                If WebImportOrder.ImportSource = AdvantageFramework.Media.ImportSource.AuthorizationToBuy Then

                                    RadNumericTextBoxLineNumber.ReadOnly = IsReadOnlyColumn(AdvantageFramework.Media.Classes.WebImportOrder.Properties.LineNumber.ToString, WebImportOrder)

                                End If

                            End If

                            If Me.IsDirectPost() Then

                                RadNumericTextBoxLineNumber.ReadOnly = True

                            End If

                        End If

                        If GridDataItem("GridButtonColumnDelete") IsNot Nothing Then

                            Try

                                DirectCast(GridDataItem("GridButtonColumnDelete").Controls(0), System.Web.UI.WebControls.ImageButton).CommandArgument = Key.ToString

                            Catch ex As Exception

                            End Try

                        End If

                        If GridDataItem("GridBoundColumnNetGross") IsNot Nothing Then

                            Try

                                GridDataItem("GridBoundColumnNetGross").Text = If(WebImportOrder.NetGross.GetValueOrDefault(0) = 0, "Net", "Gross")

                            Catch ex As Exception

                            End Try

                        End If

                        If HiddenFieldKey IsNot Nothing Then

                            HiddenFieldKey.Value = Key.ToString

                        End If

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub RadGridOrders_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridOrders.NeedDataSource

        If Me.WebImportOrders IsNot Nothing Then

            RadGridOrders.DataSource = Me.WebImportOrders.Values.ToList

        End If

    End Sub
    Private Sub RadGridOrders_PreRender(sender As Object, e As EventArgs) Handles RadGridOrders.PreRender

        'objects
        Dim FieldName As String = Nothing
        Dim WebImportOrder As AdvantageFramework.Media.Classes.WebImportOrder = Nothing
        Dim ImportSource As AdvantageFramework.Media.ImportSource = AdvantageFramework.Media.ImportSource.Default

        For Each GridColumn In RadGridOrders.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

            If GridColumn.UniqueName <> "GridButtonColumnDelete" Then

                Try

                    WebImportOrder = Me.WebImportOrders.Values.First

                Catch ex As Exception
                    WebImportOrder = Nothing
                End Try

                If WebImportOrder IsNot Nothing Then

                    ImportSource = WebImportOrder.ImportSource

                End If

                If TypeOf GridColumn Is Telerik.Web.UI.GridTemplateColumn Then

                    FieldName = DirectCast(GridColumn, Telerik.Web.UI.GridTemplateColumn).DataField

                ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                    FieldName = DirectCast(GridColumn, Telerik.Web.UI.GridBoundColumn).DataField

                Else

                    FieldName = ""

                End If

                GridColumn.Visible = AdvantageFramework.Media.IsMediaOrderColumnVisible(FieldName, _ShowOrderDescription, ImportSource)

            Else

                GridColumn.Visible = True

            End If

        Next

    End Sub

#End Region

#End Region

End Class