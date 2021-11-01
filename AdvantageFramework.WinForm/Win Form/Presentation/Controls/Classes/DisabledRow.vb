Namespace WinForm.Presentation.Controls.Classes

    Public Class DisabledRow

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RowType
            Deleted = 0
            [Readonly] = 1
        End Enum

#End Region

#Region " Variables "

        Protected _DataSourceRowIndex As Integer = Nothing
        Protected _DisabledRowType As RowType = RowType.Deleted

#End Region

#Region " Properties "

        Public Property DataSourceRowIndex As Integer
            Get
                DataSourceRowIndex = _DataSourceRowIndex
            End Get
            Set(ByVal value As Integer)
                _DataSourceRowIndex = value
            End Set
        End Property
        Public Property DisabledRowType As RowType
            Get
                DisabledRowType = _DisabledRowType
            End Get
            Set(ByVal value As RowType)
                _DisabledRowType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal DataSourceRowIndex As Integer)

            Me.DataSourceRowIndex = DataSourceRowIndex
            Me.DisabledRowType = RowType.Deleted

        End Sub
        Public Sub New(ByVal DataSourceRowIndex As Integer, ByVal RowType As RowType)

            Me.DataSourceRowIndex = DataSourceRowIndex
            Me.DisabledRowType = RowType

        End Sub

#End Region

    End Class

End Namespace