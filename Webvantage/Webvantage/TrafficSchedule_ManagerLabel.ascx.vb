Public Class TrafficSchedule_ManagerLabel
    Inherits System.Web.UI.UserControl

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum DisplayType
        Label
        Hyperlink
    End Enum

#End Region

#Region " Variables "

    Public TextBoxClientId As String = ""
    Private _Text As String = "Manager"

#End Region

#Region " Properties "

    Public Property DisplayAs As DisplayType
    Public Property IncludeColon As Boolean = False

#End Region

#Region " Page Events "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Dim s As New cSchedule()
            Me._Text = s.GetManagerLabel()

            If Me.IncludeColon = True Then

                Me._Text = Me._Text & ":"

            End If

            If DisplayAs = DisplayType.Hyperlink And Me.TextBoxClientId.Trim() <> "" Then

                Me.LabelManager.Visible = False
                Me.HyperLinkManager.Visible = True
                Me.HyperLinkManager.Text = Me._Text
                Me.HyperLinkManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & TextBoxClientId & "&type=managers');return false;")

            Else

                Me.HyperLinkManager.Visible = False
                Me.LabelManager.Visible = True
                Me.LabelManager.Text = Me._Text

            End If

        End If
    End Sub

#End Region

#Region " Controls Events "



#End Region

#Region " Methods "



#End Region

End Class