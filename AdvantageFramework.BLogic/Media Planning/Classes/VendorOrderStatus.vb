Namespace MediaPlanning.Classes

    Public Class VendorOrderStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanEstimateID
            VendorCode
            VendorName
            OrderNumber
            CreateDate
            LastStatusDate
            Status
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanEstimateID As Integer
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property CreateDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastStatusDate As Nullable(Of Date)
        Public Property Status As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
