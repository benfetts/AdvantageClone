Namespace MediaPlanning.FlowChart

    Public Class FlowChartMarketAndVendor

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MarketName As String
        Public Property VendorName As String

#End Region

#Region " Methods "

        Public Sub New(MarketName As String, VendorName As String)

            Me.MarketName = MarketName
            Me.VendorName = VendorName

        End Sub
        Public Overrides Function Equals([Object] As Object) As Boolean

            Dim IsEqual As Boolean = False

            If [Object] IsNot Nothing AndAlso Me.GetType().Equals([Object].GetType()) Then

                If CType([Object], FlowChartMarketAndVendor).MarketName = Me.MarketName AndAlso
                        CType([Object], FlowChartMarketAndVendor).VendorName = Me.VendorName Then

                    IsEqual = True

                End If

            End If

            Equals = IsEqual

        End Function

#End Region

    End Class

End Namespace