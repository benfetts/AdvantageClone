Public Class Document_Label
    Inherits Webvantage.BaseUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property Text As String
        Get
            Return LabelLabelName.Text
        End Get
        Set(value As String)
            LabelLabelName.Text = value
        End Set
    End Property
    Public Property LabelID As Integer
        Get
            If ViewState("LabelID") Is Nothing Then
                ViewState("LabelID") = 0
            End If
            Return CType(ViewState("LabelID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("LabelID") = value
        End Set
    End Property
    Public Property DocumentID As Integer
        Get
            If ViewState("DocumentID") Is Nothing Then
                ViewState("DocumentID") = 0
            End If
            Return CType(ViewState("DocumentID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("DocumentID") = value
        End Set
    End Property
    Public Property Style As String
        Get
            Return Me.DivLabel.Attributes("style")
        End Get
        Set(value As String)
            Me.DivLabel.Attributes.Remove("style")
            Me.DivLabel.Attributes.Add("style", value)
        End Set
    End Property

    Public Property Session() As AdvantageFramework.Security.Session

    'Public Event RemoveLabel(sender As Object, e As EventArgs)
    'Public Event LabelRemoved()

#End Region

#Region " Methods "

#Region " Controls "

    Public Event LinkButtonRemoveLabelClick(sender As Object, e As EventArgs)
    Private Sub LinkButtonRemoveLabel_Click(sender As Object, e As EventArgs) Handles LinkButtonRemoveLabel.Click

        RaiseEvent LinkButtonRemoveLabelClick(sender, e)
        Using dc = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            Dim ld As AdvantageFramework.Database.Entities.LabelDocument = Nothing

            ld = AdvantageFramework.Database.Procedures.LabelDocument.LoadByLabelIDAndDocumentID(dc, Me.LabelID, Me.DocumentID)

            If ld IsNot Nothing Then

                If AdvantageFramework.Database.Procedures.LabelDocument.Delete(dc, ld) = True Then

                End If

            End If

        End Using

    End Sub

    Private Sub Document_Label_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.LinkButtonRemoveLabel.CommandName = "RemoveLabel"
        Me.LinkButtonRemoveLabel.CommandArgument = Me.DocumentID & "|" & Me.LabelID

    End Sub

#End Region
#Region " Page "



#End Region

    Public Sub SetPostBack()

        Me.LinkButtonRemoveLabel.Attributes.Add("onclick", String.Format("__doPostBack('{0}','{1}|{2}');return false;", "RemoveLabel", Me.DocumentID, Me.LabelID))

    End Sub

    Private Sub Document_Label_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender


    End Sub

#End Region

End Class