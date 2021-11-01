Namespace ViewModels.LookupObjects

    Public Class Estimate
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateDescription
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateQuoteNumber
            EstimateOuoteDescription
            EstimateRevisionNumber
            EstimateSequenceNumber
            EstimateQuantity
            EstimateCommissionPercent
            EstimateCommissionAmount
            EstimateContingencyPct
            EstimateAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EstimateNumber As Integer?
        Public Property EstimateDescription As String
        Public Property EstimateComponentNumber As Short?
        Public Property EstimateComponentDescription As String
        Public Property EstimateQuoteNumber As Short?
        Public Property EstimateOuoteDescription As String
        Public Property EstimateRevisionNumber As Short?
        Public Property EstimateSequenceNumber As Integer?
        Public Property EstimateQuantity As Decimal
        Public Property EstimateCommissionPercent As Decimal
        Public Property EstimateCommissionAmount As Decimal
        Public Property EstimateContingencyPct As Decimal
        Public Property EstimateAmount As Decimal
        Public Overrides ReadOnly Property SearchText As String
            Get
                Dim EstimateNumberString As String = If(Me.EstimateNumber.GetValueOrDefault(0) > 0, Me.EstimateNumber.Value.ToString, [String].Empty)
                Dim EstimateComponentNumberString As String = If(Me.EstimateComponentNumber.GetValueOrDefault(0) > 0, Me.EstimateComponentNumber.Value.ToString, [String].Empty)

                Return (EstimateNumberString + Space(1) + EstimateDescription + Space(1) + EstimateComponentNumberString + Space(1) + EstimateComponentDescription).ToLower

            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


