Partial Public Class purchaseordernav
    Inherits Webvantage.BaseUserControl

    Public Event PO_List_Clicked()
    'Public Event PO_Estimate_Clicked()
    Public Event PO_Copy_Clicked()
    Public Event PO_Void_Clicked()
    Public Event PO_Revision_Clicked()
    ''Public Event PO_Print_Clicked()

    ''Public Event PO_Print_Options_Clicked()
    Public Event PO_Send_Clicked()

    Public Event PO_Save_Clicked()
    Public Event PO_New_Clicked()
    Public Event PO_Back_Clicked()
    'Public Event PO_Comments_Clicked()
    Public Event PO_Refresh_Clicked()
    Public Event PO_CancelApproval_Clicked()
    Public Event PO_Bookmark_Clicked()

    Public Event PrintClicked()
    Public Event SendAlertClicked()
    Public Event SendAssignmentClicked()
    Public Event SendEmailClicked()
    Public Event PrintSendOptionsClicked()

    Public Event AlertsClicked()
    Public Event MarkCompleteClicked()
    Public Event MarkNotCompleteClicked()
    Public Property WebvantageLink As String
        Get
            If ViewState("WebvantageLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("WebvantageLink")
            End If
        End Get
        Set(value As String)
            ViewState("WebvantageLink") = value
        End Set
    End Property
    Public Property ClientPortalLink As String
        Get
            If ViewState("ClientPortalLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ClientPortalLink")
            End If
        End Get
        Set(value As String)
            ViewState("ClientPortalLink") = value
        End Set
    End Property

#Region "Declarations"


#End Region

    Protected WithEvents _ReportType1 As Webvantage.ReportTypeUC
    Public Property EnableBookmarks As Boolean = False

    Public WriteOnly Property ControlCausesValidation() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.CausesValidation = value
        End Set
    End Property
    Public WriteOnly Property Allow_Copy() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelCopy").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_List() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelPOList").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_Void() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelVoid").Enabled = value
        End Set
    End Property
    'Public WriteOnly Property Allow_Estimate_View() As Boolean
    '    Set(ByVal value As Boolean)
    '        Me.RadToolbarPurchseOrderNav.FindItemByValue("SelEstimate").Enabled = value
    '    End Set
    'End Property
    Public WriteOnly Property Allow_Revision_Increment() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelRevision").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_Print() As Boolean
        Set(ByVal value As Boolean)
            PrintSendDropDown.Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("Print").Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SendAlert").Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SendAssignment").Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SendEmail").Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("PrintSendOptions").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_Send() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelSend").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_New() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelNew").Enabled = value
            Me.Allow_Copy = value
        End Set
    End Property
    Public WriteOnly Property Allow_Save() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelSave").Enabled = value
        End Set
    End Property
    'Public WriteOnly Property Allow_Comments() As Boolean
    '    Set(ByVal value As Boolean)
    '        Me.RadToolbarPurchseOrderNav.FindItemByValue("SelComments").Enabled = value
    '    End Set
    'End Property
    Public WriteOnly Property Allow_CancelApproval() As Boolean
        Set(ByVal value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("CancelApproval").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_Refresh As Boolean
        Set(value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("SelRefresh").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_Bookmark As Boolean
        Set(value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("Bookmark").Enabled = value
        End Set
    End Property
    Public WriteOnly Property Allow_MarkComplete As Boolean
        Set(value As Boolean)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkComplete").Enabled = value
            Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkNotComplete").Enabled = value
        End Set
    End Property
    Public WriteOnly Property MarkComplete As Boolean
        Set(value As Boolean)
            If value Then
                Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkComplete").Visible = False
                Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkNotComplete").Visible = True
            Else
                Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkComplete").Visible = True
                Me.RadToolbarPurchseOrderNav.FindItemByValue("MarkNotComplete").Visible = False
            End If

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'Me.RadToolbarPurchseOrderNav.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks()

            If MiscFN.IsClientPortal = True Then

                Me.RadToolbarPurchseOrderNav.FindItemByValue("SendAssignment").Visible = False

            End If

        End If

        If RadToolbarPurchseOrderNav.FindItemByValue("SelSend").Visible = False AndAlso RadToolbarPurchseOrderNav.FindItemByValue("SelBack2").Visible = False Then

            RadToolbarPurchseOrderNav.Items(RadToolbarPurchseOrderNav.FindItemByValue("SelBack2").Index + 1).Visible = False ' separator

        End If

        Try

            Dim PermalinkQuerystring As AdvantageFramework.Web.QueryString = Nothing

            PermalinkQuerystring = New AdvantageFramework.Web.QueryString()

            PermalinkQuerystring = PermalinkQuerystring.FromCurrent()
            Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)

            Deep.BuildJavascriptFromQueryString(PermalinkQuerystring, WebvantageLink, ClientPortalLink)
            Me.RadToolbarPurchseOrderNav.FindItemByValue("CpPermaLink").Visible = False ' Deep.ClientPortalVisible
            If MiscFN.IsClientPortal = True Then

                Me.RadToolbarPurchseOrderNav.FindItemByValue("WvPermaLink").Visible = False
                Me.RadToolbarPurchseOrderNav.FindItemByValue("CpPermaLink").Visible = False

            End If

        Catch ex As Exception
        End Try


    End Sub


    Private Sub RadToolbarPurchseOrderNav_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarPurchseOrderNav.ButtonClick
        Select Case e.Item.Value
            Case "SelPOList"
                RaiseEvent PO_List_Clicked()
            Case "SelCopy"
                RaiseEvent PO_Copy_Clicked()
            Case "SelVoid"
                RaiseEvent PO_Void_Clicked()
            Case "SelRevision"
                RaiseEvent PO_Revision_Clicked()


                ' ''Case "SelPrint"
                ' ''    RaiseEvent PO_Print_Clicked()

            Case "SelSend"
                RaiseEvent PO_Send_Clicked()

            Case "SelSave"
                RaiseEvent PO_Save_Clicked()
            Case "SelNew"
                RaiseEvent PO_New_Clicked()
                'Case "SelComments"
                '    RaiseEvent PO_Comments_Clicked()
            Case "SelRefresh"
                RaiseEvent PO_Refresh_Clicked()
                'Case "SelEstimate"
                '    RaiseEvent PO_Estimate_Clicked()
            Case "CancelApproval"
                RaiseEvent PO_CancelApproval_Clicked()
            Case "Bookmark"
                RaiseEvent PO_Bookmark_Clicked()

            Case "Print"
                RaiseEvent PrintClicked()
            Case "SendAlert"
                RaiseEvent SendAlertClicked()
            Case "SendAssignment"
                RaiseEvent SendAssignmentClicked()
            Case "SendEmail"
                RaiseEvent SendEmailClicked()
            Case "PrintSendOptions"
                RaiseEvent PrintSendOptionsClicked()
            Case "Alerts"
                RaiseEvent AlertsClicked()
            Case "MarkComplete"
                RaiseEvent MarkCompleteClicked()
            Case "MarkNotComplete"
                RaiseEvent MarkNotCompleteClicked()

        End Select

    End Sub

    Public Sub SetEstimatePopupWindow(ByVal ponumber As String)

        Me.txtPONumber.Value = ponumber.Trim

    End Sub

End Class
