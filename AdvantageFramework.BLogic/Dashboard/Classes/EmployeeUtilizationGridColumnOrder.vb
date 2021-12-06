Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeUtilizationGridColumnSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ColumnName
            ColumnOrderID
            DefaultOrderID
            ColumnWidth
            IsVisible

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ColumnName As String = String.Empty
        Public Property ColumnOrderID As Integer?
        Public Property DefaultOrderID As Integer?
        Public Property ColumnWidth As Integer?
        Public Property IsVisible As Boolean?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

