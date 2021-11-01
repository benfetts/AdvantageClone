Public Class Media_ATB_CreateOrder
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ATBNumber As Integer = Nothing
    Private _RevisionNumber As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub CreateOrders()

        'objects
        Dim ErrorMessage As String = Nothing
        Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
        Dim WebImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.WebImportOrder) = Nothing
        Dim MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions = Nothing

        MediaATBOrderOption = GetSelectedMediaATBOrderOption()

        ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

        If AdvantageFramework.Media.CreateOrdersFromATB(_Session, _ATBNumber, _RevisionNumber, MediaATBOrderOption, RadComboBox_Vendor.SelectedValue, RadButtonIncludeMarkup.Checked, ImportOrderList, ErrorMessage) Then

            Session("ATBImportOrders") = ImportOrderList.Select(Function(ImpOrd) New AdvantageFramework.Media.Classes.WebImportOrder(ImpOrd)).ToList

            Me.CloseThisWindowAndRefreshCaller(Webvantage.Media_ATB.GenerateBaseQueryString(_ATBNumber, _RevisionNumber, True), True, True)

        ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Function CheckIfRevisionIsApproved() As Boolean

        'objects
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim IsApproved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber)

                If MediaATBRevision IsNot Nothing Then

                    If MediaATBRevision.ApprovalFlag.GetValueOrDefault(0) = 1 Then

                        IsApproved = True

                    End If

                End If

            End Using

        Catch ex As Exception
            IsApproved = False
        Finally
            CheckIfRevisionIsApproved = IsApproved
        End Try

    End Function
    Private Sub EnableOrDisableActions()

        Select Case GetSelectedMediaATBOrderOption()

            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.SeparateForAdServing

                TrVendor.Visible = True
                TrIncludeMarkup.Visible = True

            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder

                TrVendor.Visible = False
                TrIncludeMarkup.Visible = True

            Case AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge

                TrVendor.Visible = False
                TrIncludeMarkup.Visible = False

        End Select

    End Sub
    Private Function GetSelectedMediaATBOrderOption() As AdvantageFramework.Database.Entities.MediaATBOrderOptions

        'objects
        Dim MediaATBOrderOption As AdvantageFramework.Database.Entities.MediaATBOrderOptions = Nothing

        Select Case RadioButtonList_Options.SelectedValue

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.MediaATBOrderOptions.SeparateForAdServing).Code

                MediaATBOrderOption = AdvantageFramework.Database.Entities.MediaATBOrderOptions.SeparateForAdServing

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder).Code

                MediaATBOrderOption = AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingOnEachVendorOrder

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge).Code

                MediaATBOrderOption = AdvantageFramework.Database.Entities.MediaATBOrderOptions.AdServingAsNetCharge

        End Select

        GetSelectedMediaATBOrderOption = MediaATBOrderOption

    End Function
    Private Function LoadVendors() As Generic.List(Of AdvantageFramework.Database.Core.Vendor)

        'objects
        Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
        Dim VendorObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor)

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                VendorObjectQuery = From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                    Where Vendor.InternetCategory = 1 OrElse
                                          Vendor.VendorCategory = "I"
                                    Select Vendor

                If String.IsNullOrEmpty(RadComboBox_Vendor.Text) Then

                    VendorList = AdvantageFramework.Database.Procedures.Vendor.LoadCore(VendorObjectQuery)

                Else

                    VendorList = From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadCore(VendorObjectQuery) _
                                 Where Entity.ToString.Contains(RadComboBox_Vendor.Text) _
                                 Select Entity

                End If

            End Using

        Catch ex As Exception
            VendorList = Nothing
        Finally
            LoadVendors = VendorList
        End Try

    End Function

#Region " Show Form Methods "

    Public Shared Function GenerateBaseQueryString(ByVal ATBNumber As Integer, ByVal RevisionNumber As Integer) As String

        'objects
        Dim VariableList As Generic.Dictionary(Of String, String) = Nothing
        Dim QueryString As String = ""

        Try

            VariableList = New Generic.Dictionary(Of String, String)

            VariableList.Add("ATBNbr", ATBNumber.ToString)
            VariableList.Add("RevNbr", RevisionNumber.ToString)

            QueryString = "Media_ATB_CreateOrder.aspx?"

            Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            For Each Variable In VariableList

                QueryString &= Variable.Key & "=" & Sanitizer.Sanitize(Variable.Value) & "&"

            Next

            QueryString = QueryString.Substring(0, QueryString.Length - 1)

        Catch ex As Exception
            QueryString = "Media_ATB_CreateOrder.aspx"
        Finally
            GenerateBaseQueryString = QueryString
        End Try

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Request.QueryString("RevNbr") IsNot Nothing Then

                _RevisionNumber = CShort(Request.QueryString("RevNbr"))

            End If

        Catch ex As Exception
            _RevisionNumber = -1
        End Try

        Try

            If Request.QueryString("ATBNbr") IsNot Nothing Then

                _ATBNumber = CInt(Request.QueryString("ATBNbr"))

            End If

        Catch ex As Exception
            _ATBNumber = 0
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "ATB Order Options"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            If CheckIfRevisionIsApproved() Then

                RadioButtonList_Options.Items.Clear()

                For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaATBOrderOptions))

                    RadioButtonList_Options.Items.Add(New System.Web.UI.WebControls.ListItem With {.Text = EnumObject.Description, _
                                                                                                   .Value = EnumObject.Code})

                Next

                RadioButtonList_Options.SelectedIndex = 0

                EnableOrDisableActions()

            Else

                Me.ShowMessage("Orders can only be created from an approved revision.")
                Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadToolbarOptions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarOptions.ButtonClick

        If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

            Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                Case RadToolBarButtonCreate.CommandName

                    CreateOrders()

            End Select

        End If

    End Sub
    Private Sub RadButton_SummaryRecord_CheckedChanged(sender As Object, e As EventArgs) Handles RadButton_SummaryRecord.CheckedChanged

        EnableOrDisableActions()

    End Sub
    Private Sub RadComboBox_Vendor_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboBox_Vendor.ItemsRequested

        'objects
        Dim Offset As Integer = Nothing
        Dim EndOffset As Integer = Nothing
        Dim ItemsPerRequest As Integer = 20
        Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
        Dim Vendor As AdvantageFramework.Database.Core.Vendor = Nothing

        VendorList = LoadVendors()

        If VendorList IsNot Nothing AndAlso VendorList.Count > 0 Then

            Offset = e.NumberOfItems
            EndOffset = Math.Min(Offset + ItemsPerRequest, VendorList.Count)

            For I = Offset To EndOffset - 1

                Try

                    Vendor = VendorList(I)

                Catch ex As Exception
                    Vendor = Nothing
                End Try

                If Vendor IsNot Nothing Then

                    RadComboBox_Vendor.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Vendor.ToString, Vendor.Code))

                End If

            Next

        End If

    End Sub
    Private Sub RadioButtonList_Options_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList_Options.SelectedIndexChanged

        EnableOrDisableActions()

    End Sub

#End Region

#End Region

End Class
