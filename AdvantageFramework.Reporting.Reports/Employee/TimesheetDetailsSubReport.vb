Namespace Employee

    Public Class TimesheetDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UseProductCategory As Boolean

#End Region

#Region " Properties "

        Public WriteOnly Property UseProductCategory As Boolean
            Set(value As Boolean)
                _UseProductCategory = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub Label_ProductCat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductCat.BeforePrint

            If _UseProductCategory = False Then

                Label_ProductCat.Text = ""

            End If

        End Sub
        Private Sub LabelHeader_ProductCategory_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_ProductCategory.BeforePrint

            If _UseProductCategory = False Then

                LabelHeader_ProductCategory.Text = ""

            End If

        End Sub

#End Region

#End Region

        
    End Class

End Namespace
