Public Partial Class purchaseorder_memo_nav
    Inherits System.Web.UI.UserControl
    Public Event PO_Clicked()
    Public Event Main_Instruct_Clicked()
    Public Event PO_Delivery_Clicked()
    Public Event PO_Footer_Clicked()
    Public Event PO_Detail_Add_Clicked()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Public WriteOnly Property ControlCausesValidation() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPOMemo.CausesValidation = value
        End Set
    End Property
    Public Property Current_Tab() As String
        Get
            Return lbl_current_tab.Text.Trim
        End Get
        Set(ByVal value As String)
            lbl_current_tab.Text = value.Trim
            DisableCurrentTab(value.Trim)
        End Set
    End Property
    Public WriteOnly Property Show_Detail_Add_Button() As Boolean
        'add button is unrelated to memo sections, and is not visible by default.  Use to allow toolbar to function as detail toolbar.
        Set(ByVal value As Boolean)
            Me.RadToolbarPOMemo.FindItemByValue("SelAddRow").Visible = value
        End Set
    End Property
    Public WriteOnly Property Detail_Add_Button_Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPOMemo.FindItemByValue("SelAddRow").Enabled = value
        End Set
    End Property
    Sub DisableCurrentTab(ByVal sTabName As String)
        Select Case sTabName.Trim
            Case "PO"
                Me.RadToolbarPOMemo.FindItemByValue("SelPODetail").Enabled = False
                Me.RadToolbarPOMemo.FindItemByValue("SelMainInstruct").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelDelivery").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelFooter").Enabled = True
            Case "po_main_instruct"
                Me.RadToolbarPOMemo.FindItemByValue("SelPODetail").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelMainInstruct").Enabled = False
                Me.RadToolbarPOMemo.FindItemByValue("SelDelivery").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelFooter").Enabled = True

            Case "del_instruct"
                Me.RadToolbarPOMemo.FindItemByValue("SelPODetail").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelMainInstruct").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelDelivery").Enabled = False
                Me.RadToolbarPOMemo.FindItemByValue("SelFooter").Enabled = True
            Case "po_footer"
                Me.RadToolbarPOMemo.FindItemByValue("SelPODetail").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelMainInstruct").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelDelivery").Enabled = True
                Me.RadToolbarPOMemo.FindItemByValue("SelFooter").Enabled = False

        End Select
    End Sub
    Public Sub SetMainInstructSaveMessage(ByVal msg As String)
        '  lbtn_main_instruct.Attributes.Add("onclick", "return confirm('" + msg.Trim + "');")
    End Sub
    Public Sub SetDeliveryInstructSaveMessage(ByVal msg As String)
        '  lbtn_del_instruct.Attributes.Add("onclick", "return confirm('" + msg.Trim + "');")
    End Sub
    Public Sub SetFooterInstructSaveMessage(ByVal msg As String)
        ' lbtn_footer.Attributes.Add("onclick", "return confirm('" + msg.Trim + "');")
    End Sub
    Private Sub RadToolbarPOMemo_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarPOMemo.ButtonClick
        Select Case e.Item.Value
            Case "SelPODetail"
                RaiseEvent PO_Clicked()
            Case "SelMainInstruct"
                RaiseEvent Main_Instruct_Clicked()
            Case "SelDelivery"
                RaiseEvent PO_Delivery_Clicked()
            Case "SelFooter"
                RaiseEvent PO_Footer_Clicked()
            Case "SelAddRow"
                RaiseEvent PO_Detail_Add_Clicked()
        End Select
    End Sub
End Class