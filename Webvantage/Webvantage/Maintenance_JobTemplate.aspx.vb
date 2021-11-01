Public Class Maintenance_JobTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

#Region "  Form Event Handlers "

    Private Sub Maintenance_JobVersionTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Job Version Template Maintenance"
        'objects
        Dim TabIndex As Integer = 0



        If Not Me.IsPostBack And Not Me.IsCallback Then

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

            Catch ex As Exception
                TabIndex = 0
            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class