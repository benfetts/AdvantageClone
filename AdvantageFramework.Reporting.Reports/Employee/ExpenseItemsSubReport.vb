Namespace Employee

    Public Class ExpenseItemsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub PictureBoxCreditCard_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBoxCreditCard.BeforePrint

            PictureBoxCreditCard.Image = AdvantageFramework.My.Resources.SmallCheckMarkImage

        End Sub
        Private Sub PictureBoxNonBillable_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBoxNonBillable.BeforePrint

            PictureBoxNonBillable.Image = AdvantageFramework.My.Resources.SmallCheckMarkImage

        End Sub

#End Region

#End Region

    End Class

End Namespace
