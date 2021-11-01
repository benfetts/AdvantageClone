Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class BillingStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsAssigned
            IsPrinted
            IsProcessed
            IsCoopSaved
            HasCoopJobs
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property IsAssigned() As Nullable(Of Integer)

        Public Property IsPrinted() As Nullable(Of Integer)

        Public Property IsProcessed() As Boolean

        Public Property IsCoopSaved() As Boolean

        Public Property HasCoopJobs() As Nullable(Of Boolean)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.IsAssigned.ToString

        End Function

#End Region

    End Class

End Namespace
