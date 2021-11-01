Imports System.Data.SqlClient

Public Class Event_Type
    Inherits System.Web.UI.UserControl

    Private mEventId As Integer = 0
    Private mEventTypeId As Integer = 0
    Private mBackgroundColor As String = ""
    Private mSaveOnChange As Boolean = False

    Public Property EventTypeId() As Integer
        Get
            If Me.mSaveOnChange = True Then
                If Not ViewState("EventTypeId") = Nothing Then
                    Me.mEventTypeId = CType(ViewState("EventTypeId"), Integer)
                    Me.RadComboBoxEventType.FindItemByValue(Me.mEventTypeId).Selected = True
                Else
                    Me.mEventTypeId = 0
                    Me.RadComboBoxEventType.FindItemByValue("0").Selected = True
                End If
            End If
            Return CType(Me.RadComboBoxEventType.SelectedValue, Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("EventTypeId") = value.ToString()
            Me.mEventTypeId = value
            Me.RadComboBoxEventType.FindItemByValue(value.ToString()).Selected = True
        End Set
    End Property

    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return Me.RadComboBoxEventType.SelectedIndex
        End Get
    End Property

    Public WriteOnly Property TabIndex() As Short
        Set(ByVal value As Short)
            Me.RadComboBoxEventType.TabIndex = value
        End Set
    End Property

    Public Property AutoPostBack() As Boolean
        Get
            Return Me.RadComboBoxEventType.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            Me.RadComboBoxEventType.AutoPostBack = value
        End Set
    End Property

    Public Property SaveOnChange() As Boolean
        Get
            If Not ViewState("SaveOnChange") = Nothing Then
                mSaveOnChange = CType(ViewState("SaveOnChange"), Boolean)
            Else
                mSaveOnChange = False
            End If
            Return mSaveOnChange
        End Get
        Set(ByVal value As Boolean)
            ViewState("SaveOnChange") = value.ToString()
            mSaveOnChange = value
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

    Private Sub RadComboBoxEventType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEventType.SelectedIndexChanged
        If Me.AutoPostBack = True And Me.mSaveOnChange = True Then
            If Me.mEventId = 0 Then
                If Not ViewState("EventId") = Nothing Then
                    Me.mEventId = ViewState("EventId")
                Else
                    Me.mEventId = 0
                End If
            End If
            If Me.mEventTypeId = 0 Then
                Me.mEventTypeId = CType(Me.RadComboBoxEventType.SelectedValue, Integer)
            End If
            If Me.mEventTypeId = 0 Then
                Me.mEventTypeId = 1
                Me.RadComboBoxEventType.FindItemByValue("1").Selected = True
            End If
            If Me.mEventId > 0 And Me.RadComboBoxEventType.SelectedIndex > 0 Then
                Dim SQL As String = "UPDATE EVENT WITH(ROWLOCK) SET EVENT_TYPE_ID = @EVENT_TYPE_ID WHERE EVENT_ID = @EVENT_ID"
                Dim arP(2) As SqlParameter

                Dim pEventId As New SqlParameter("@EVENT_ID", SqlDbType.Int)
                pEventId.Value = Me.mEventId
                arP(0) = pEventId

                Dim pEventTypeId As New SqlParameter("@EVENT_TYPE_ID", SqlDbType.SmallInt)
                pEventTypeId.Value = Me.mEventTypeId
                arP(1) = pEventTypeId

                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.Text, SQL, arP)

            End If
        End If
    End Sub

End Class