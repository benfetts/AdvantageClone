Public Class Chat_Test
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub Chat_Test_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

    End Sub

    Private Sub Chat_Test_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim JC As AdvantageFramework.Database.Entities.JobComponent

                    JC = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

                    If JC IsNot Nothing Then

                        Me.LabelTitle.Text = String.Format("{0}/{1} - {2}", Me._JobNumber.ToString().PadLeft(6, "0"), Me._JobComponentNumber.ToString().PadLeft(2, "0"), JC.Description)

                    End If

                End Using

            End If

        End If

    End Sub

#End Region

#End Region

End Class