
Public Class Document_Label_Tree_Page
    Inherits Webvantage.BaseChildPage


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    'Private Sub ImageButtonEditLabels_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonEditLabels.Click

    '    Me.OpenWindow("", "Maintenance_Documents.aspx?tabidx=1")

    'End Sub

#End Region
#Region " Page "

    Private Sub Document_Label_Tree_Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, True)

        Me.UserControlDocumentLabelTree.DocumentID = Me.CurrentQuerystring.DocumentID
        Me.UserControlDocumentLabelTree.LoadLabels()
        Me.UserControlDocumentLabelTree.LoadExistingLabelsForDocument()

    End Sub
    Private Sub Document_Label_Tree_Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.ImageButtonEditLabels.Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_Documents, False) = 1

        End If

    End Sub

#End Region

#End Region

End Class