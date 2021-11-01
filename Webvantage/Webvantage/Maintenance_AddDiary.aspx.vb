Public Class Maintenance_AddDiary
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


#Region "  Form Event Handlers "

    Private Sub Maintenance_AddDiary_Init(sender As Object, e As EventArgs) Handles Me.Init



    End Sub
    Private Sub Maintenance_AddDiary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Add Diary"

        If Not Me.IsPostBack And Not Me.IsCallback Then



        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class