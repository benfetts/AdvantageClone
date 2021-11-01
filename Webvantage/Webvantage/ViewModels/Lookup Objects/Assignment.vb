Namespace ViewModels.LookupObjects

    Public Class Assignment
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer?
        Public Property Description As String
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?

        Public Overrides ReadOnly Property SearchText As String
            Get
                'objects
                Dim AlertIDString As String = If(Me.AlertID.GetValueOrDefault(0) > 0, Me.AlertID.Value.ToString, [String].Empty)

                Return (AlertIDString + Space(1) + Description).ToLower

            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

