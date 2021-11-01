Namespace Database.Entities

    Public Class OrderProcessLog
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OrderNumber
            OriginalProcessControl
            NewProcessControl
            ProcessedDate
            ProcessedByUserCode
            Comments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        Public Property OrderNumber As Integer
        Public Property OriginalProcessControl As Nullable(Of Short)
        Public Property NewProcessControl As Nullable(Of Short)
        Public Property ProcessedDate As Nullable(Of Date) = Nothing
        Public Property ProcessedByUserCode As String = Nothing
        Public Property Comments As String = Nothing

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
