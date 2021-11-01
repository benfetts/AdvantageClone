Namespace WinForm.Presentation.Controls.Classes

    Public Class MenuInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.None
        Protected _GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

#End Region

#Region " Properties "

        Public Property FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle
            Get
                FixedStyle = _FixedStyle
            End Get
            Set(ByVal value As DevExpress.XtraGrid.Columns.FixedStyle)
                _FixedStyle = value
            End Set
        End Property
        Public Property GridColumn As DevExpress.XtraGrid.Columns.GridColumn
            Get
                GridColumn = _GridColumn
            End Get
            Set(ByVal value As DevExpress.XtraGrid.Columns.GridColumn)
                _GridColumn = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle)

            Me.GridColumn = GridColumn
            Me.FixedStyle = FixedStyle

        End Sub

#End Region

    End Class

End Namespace