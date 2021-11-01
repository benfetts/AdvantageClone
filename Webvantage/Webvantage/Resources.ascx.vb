Partial Public Class ResourcesUC
    Inherits System.Web.UI.UserControl

    Private mEventId As Integer = 0
    Private mResourceCode As String = ""
    Private mResourceCodeType As String = ""
    Private mFormEnabled As Boolean = True
    Private mHideLastUseRows As Boolean = False
    Private mSaveOnResourceChange As Boolean = False
    Private mNeedsParentRefresh As Boolean = False
    Private mShowRefreshTaskGridButton As Boolean = False

    Public Property ShowRefreshTaskGridButton As Boolean
        Get
            Return mShowRefreshTaskGridButton
        End Get
        Set(ByVal Value As Boolean)
            mShowRefreshTaskGridButton = Value
        End Set
    End Property

    'Public Property NeedsParentRefresh As Boolean
    '    Get
    '        Return mNeedsParentRefresh
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        mNeedsParentRefresh = Value
    '    End Set
    'End Property

    Public Property NeedsParentRefresh() As Boolean
        Get
            If Not ViewState("NeedsParentRefresh") = Nothing Then
                mNeedsParentRefresh = CType(ViewState("NeedsParentRefresh"), Boolean)
            Else
                mNeedsParentRefresh = False
            End If
            Return mNeedsParentRefresh
        End Get
        Set(ByVal value As Boolean)
            ViewState("NeedsParentRefresh") = value.ToString()
            mNeedsParentRefresh = value
        End Set
    End Property

    Public Property SaveOnResourceChange() As Boolean
        Get
            If Not ViewState("SaveOnResourceChange") = Nothing Then
                mSaveOnResourceChange = CType(ViewState("SaveOnResourceChange"), Boolean)
            Else
                mSaveOnResourceChange = False
            End If
            Return mSaveOnResourceChange
        End Get
        Set(ByVal value As Boolean)
            ViewState("SaveOnResourceChange") = value.ToString()
            mSaveOnResourceChange = value
        End Set
    End Property

    Public WriteOnly Property Rebind() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then
                Me.InitControl()
            End If
        End Set
    End Property

    Public Property EventId() As Integer
        Get
            If Not ViewState("EventId") = Nothing Then
                mEventId = ViewState("EventId")
            Else
                mEventId = 0
            End If
            Return mEventId
        End Get
        Set(ByVal value As Integer)
            ViewState("EventId") = value
            mEventId = value
        End Set
    End Property

    Public Property EnableForm() As Boolean
        Get
            Return mFormEnabled
        End Get
        Set(ByVal value As Boolean)
            mFormEnabled = value
        End Set
    End Property

    Public Property HideLastUseRows() As Boolean
        Get
            If Not ViewState("HideLastUseRows") = Nothing Then
                mHideLastUseRows = CType(ViewState("HideLastUseRows"), Boolean)
            Else
                mHideLastUseRows = False
            End If
            Return mHideLastUseRows
        End Get
        Set(ByVal value As Boolean)
            ViewState("HideLastUseRows") = value.ToString()
            mHideLastUseRows = value
        End Set
    End Property

    Public Property CheckDelAutoTasks() As CheckBox
        Get
            Return Me.ChkDeleteAutoTasks
        End Get
        Set(ByVal value As CheckBox)
            Me.ChkDeleteAutoTasks = value
        End Set
    End Property

    Public Property DropDownListResourceType() As Telerik.Web.UI.RadComboBox
        Get
            Return Me.DropResourceType
        End Get
        Set(ByVal value As Telerik.Web.UI.RadComboBox)
            Me.DropResourceType = value
        End Set
    End Property

    Public Property DropDownListResource() As Telerik.Web.UI.RadComboBox
        Get
            Return Me.DropResources
        End Get
        Set(ByVal value As Telerik.Web.UI.RadComboBox)
            Me.DropResources = value
        End Set
    End Property

    Public Property ResourceCode() As String
        Get
            If Me.mSaveOnResourceChange = True Then
                If Not ViewState("ResourceCode") = Nothing Then
                    mResourceCode = ViewState("ResourceCode")
                    MiscFN.RadComboBoxSetIndex(Me.DropResources, mResourceCode, False)
                Else
                    mResourceCode = ""
                    Me.DropResources.SelectedIndex = 0
                End If
            End If
            Return Me.DropResources.SelectedValue
        End Get
        Set(ByVal value As String)
            ViewState("ResourceCode") = value
            mResourceCode = value
        End Set
    End Property

    Public ReadOnly Property DeleteAutoTasks() As Boolean
        Get
            Try
                Return Me.ChkDeleteAutoTasks.Checked
            Catch ex As Exception
                Return True
            End Try
        End Get
    End Property

    Public Event DropResourcesSelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me.mEventId = 0 Then
                Me.mEventId = CType(Request.QueryString("evt"), Integer)
            End If
        Catch ex As Exception
        End Try
        If Me.mHideLastUseRows = True Then
            Me.TrLastDate.Visible = False
            Me.TrLastJobComp.Visible = False
            Me.TrLastTime.Visible = False
            Me.TrLastAdNumber.Visible = False
        End If
        'Me.ImageButtonRefreshTaskGrid.Visible = Me.mShowRefreshTaskGridButton
        If (Not Page.IsPostBack And Not Page.IsCallback) Then
            Me.InitControl()
        Else

        End If
    End Sub

    Private Sub InitControl()
        Me.LoadDropResourceTypes()
        If mResourceCode <> "" Then
            Dim r As New cResources()
            mResourceCodeType = r.GetResourceType(mResourceCode)
            MiscFN.RadComboBoxSetIndex(Me.DropResourceType, mResourceCodeType, False)
            Me.LoadDropResources()
            MiscFN.RadComboBoxSetIndex(Me.DropResources, mResourceCode, False)
            Me.LoadDetails()
        End If

    End Sub

    Private Sub LoadDropResources()
        Dim rsc As New cResources()
        With Me.DropResources
            .DataSource = rsc.GetResourcesList(Me.DropResourceType.SelectedValue)
            .DataValueField = "RESOURCE_CODE"
            .DataTextField = "RES_DISPLAY"
            .DataBind()
            '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        End With
    End Sub

    Private Sub LoadDropResourceTypes()
        Dim d As New cDropDowns(Session("ConnString"))
        With Me.DropResourceType
            .DataSource = d.GetResourceTypesList()
            .DataTextField = "display"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "-1"))
        End With
    End Sub

    Protected Sub DropResources_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropResources.SelectedIndexChanged
        Me.LblOverbooked.Visible = False
        If DropResources.SelectedIndex = 0 Then 'clear
            Me.ClearLabels()
        Else
            mResourceCode = Me.DropResources.SelectedValue()
            Me.LoadDetails()
        End If
        If Me.mSaveOnResourceChange = True Then
            If Me.mEventId = 0 Then
                If Not ViewState("EventId") = Nothing Then
                    Me.mEventId = ViewState("EventId")
                Else
                    Me.mEventId = 0
                End If
            End If
            If Me.mEventId > 0 Then
                Dim evt As New cEvents()
                Dim rscc As String = ""
                If Me.DropResources.SelectedIndex > 0 Then
                    rscc = Me.DropResources.SelectedValue
                End If
                If rscc.Trim() <> "" Then
                    Dim rsc As New cResources()
                    If rsc.ResourceIsBooked(rscc, Me.mEventId) = True Then
                        Me.LblOverbooked.Visible = True
                        Exit Sub
                    End If
                End If
                evt.EventUpdateResource(Me.mEventId, rscc, True, False, Me.ChkDeleteAutoTasks.Checked)
                Me.mNeedsParentRefresh = True
                Me.ImageButtonRefreshTaskGrid.Visible = True
                RaiseEvent DropResourcesSelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub LoadDetails()
        If mResourceCode <> "" Then
            Me.ClearLabels()
            Dim rsc As New cResources()
            rsc.GetResourceEventDetail(mResourceCode, Nothing, Me.LblPriority.Text, Me.LblLastDate.Text, Me.LblLastTime.Text, Me.LblLastAdNumber.Text, Me.LblLastJobComp.Text, Me.mEventId)
        End If
    End Sub

    Private Sub ClearLabels()
        'Me.LblType.Text = "N/A"
        Me.LblPriority.Text = "N/A"
        Me.LblLastDate.Text = "N/A"
        Me.LblLastTime.Text = "N/A"
        Me.LblLastAdNumber.Text = "N/A"
        Me.LblLastJobComp.Text = "N/A"
        Me.LblOverbooked.Visible = False
        Me.ImageButtonRefreshTaskGrid.Visible = False
    End Sub

    Private Sub DropResourceType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropResourceType.SelectedIndexChanged
        Me.ClearLabels()
        If DropResourceType.SelectedIndex = 0 Then 'clear
            Me.DropResources.Items.Clear()
        Else
            Me.LoadDropResources()
        End If
        If Me.mSaveOnResourceChange = True And Me.DropDownListResourceType.SelectedIndex = 0 Then
            If Me.mEventId = 0 Then
                If Not ViewState("EventId") = Nothing Then
                    Me.mEventId = ViewState("EventId")
                Else
                    Me.mEventId = 0
                End If
            End If
            If Me.mEventId > 0 Then
                Dim evt As New cEvents()
                evt.EventUpdateResource(Me.mEventId, "", True, False, Me.ChkDeleteAutoTasks.Checked)
            End If
        End If
    End Sub

End Class