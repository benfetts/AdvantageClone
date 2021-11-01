Namespace Estimating

    Public Class EstimateHeaderSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EstimatePrintDefault As AdvantageFramework.Database.Classes.EstimatePrintDetail = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property EstimatePrintDefault As AdvantageFramework.Database.Classes.EstimatePrintDetail
            Set(value As AdvantageFramework.Database.Classes.EstimatePrintDetail)
                _EstimatePrintDefault = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentEstimateHeader() As AdvantageFramework.Database.Classes.EstimatePrintDetail

            'objects
            Dim EstimateHeader As AdvantageFramework.Database.Classes.EstimatePrintDetail = Nothing

            Try

                EstimateHeader = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Classes.EstimatePrintDetail)

            Catch ex As Exception
                EstimateHeader = Nothing
            End Try

            LoadCurrentEstimateHeader = EstimateHeader

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderDetailsSubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint


        End Sub

#End Region

#Region "  Control Event Handlers "

       

#End Region

#End Region

    End Class

End Namespace
