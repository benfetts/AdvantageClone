Public Class Media_ATB_OrderDetails
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ATBNumber As Integer = Nothing
    Private _RevisionNumber As Short = Nothing
    Private _RevisionID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Show Form Methods "

    Public Shared Function GenerateBaseQueryString(ByVal ATBNumber As Integer, ByVal RevisionNumber As Integer) As String

        'objects
        Dim VariableList As Generic.Dictionary(Of String, String) = Nothing
        Dim QueryString As String = ""

        Try

            VariableList = New Generic.Dictionary(Of String, String)

            VariableList.Add("ATBNbr", ATBNumber.ToString)
            VariableList.Add("RevNbr", RevisionNumber.ToString)

            QueryString = "Media_ATB_OrderDetails.aspx?"

            Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            For Each Variable In VariableList

                QueryString &= Variable.Key & "=" & Sanitizer.Sanitize(Variable.Value) & "&"

            Next

            QueryString = QueryString.Substring(0, QueryString.Length - 1)

        Catch ex As Exception
            QueryString = "Media_ATB_OrderDetails.aspx"
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

        Me.Title = "ATB Order Details"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _RevisionID = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber).RevisionID

            End Using

        End If

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadGridOrderDetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridOrderDetails.NeedDataSource

        'objects
        Dim MediaATBRevisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing
        Dim MediaATBRevisionDetailOrders As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder) = Nothing
        Dim MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder = Nothing
        Dim DetailIDs As Integer() = Nothing
        Dim OrderList As Generic.List(Of Object) = Nothing
        Dim OrderID As Decimal? = Nothing
        Dim OrderLineID As Decimal? = Nothing
        Dim OrderNumber As Decimal? = Nothing
        Dim OrderLineNumber As Decimal? = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevisionDetails = AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, _RevisionID).Include("Vendor").ToList

                DetailIDs = MediaATBRevisionDetails.Select(Function(Dtl) Dtl.DetailID).ToArray

                MediaATBRevisionDetailOrders = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevisionDetailOrder.Load(DataContext) _
                                                Where DetailIDs.Contains(Entity.DetailID) _
                                                Select Entity).ToList

                OrderList = New Generic.List(Of Object)

                For Each MediaATBRevisionDetail In MediaATBRevisionDetails

                    For Each MediaATBRevisionDetailOrder In (From Entity In MediaATBRevisionDetailOrders _
                                                             Where Entity.DetailID = MediaATBRevisionDetail.DetailID _
                                                             Select Entity).ToList

                        OrderID = MediaATBRevisionDetailOrder.OrderID
                        OrderLineID = MediaATBRevisionDetailOrder.OrderLineID
                        OrderNumber = MediaATBRevisionDetailOrder.OrderNumber
                        OrderLineNumber = MediaATBRevisionDetailOrder.OrderLineNumber

                        OrderList.Add(New With {.Vendor = MediaATBRevisionDetail.VendorCode & " - " & MediaATBRevisionDetail.Vendor.Name, _
                                                .OrderID = OrderID, _
                                                .OrderLineID = OrderLineID,
                                                .OrderNumber = OrderNumber, _
                                                .OrderLineNumber = OrderLineNumber})

                    Next

                Next

                RadGridOrderDetails.DataSource = OrderList

            End Using

        End Using

    End Sub
    Private Sub RadToolbarOptions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarOptions.ButtonClick

        If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

            Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                Case RadToolBarButtonClose.CommandName

                    Me.CloseThisWindow()

            End Select

        End If

    End Sub

#End Region

#End Region
    
End Class