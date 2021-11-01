Namespace WinForm.MVC.Presentation.Controls.Classes

	Public Class CustomGridViewInfo
		Inherits DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Overrides ReadOnly Property GroupFooterHeight As Integer
			Get
				GroupFooterHeight = 20
			End Get
		End Property
		Public Overrides ReadOnly Property GroupFooterCellHeight As Integer
			Get
				GroupFooterCellHeight = 20
			End Get
		End Property

#End Region

#Region " Methods "

		Public Sub New(GridView As DevExpress.XtraGrid.Views.Grid.GridView)

			MyBase.New(GridView)

		End Sub

#End Region

	End Class

	Public Class CustomBandedGridViewInfo
		Inherits DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridViewInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Protected Overrides Function CalcFooterCellHeight() As Integer
			Return 23
		End Function
		Public Overrides ReadOnly Property GroupFooterHeight As Integer
			Get
				GroupFooterHeight = 23
			End Get
		End Property
		Public Overrides ReadOnly Property GroupFooterCellHeight As Integer
			Get
				GroupFooterCellHeight = 23
			End Get
		End Property

#End Region

#Region " Methods "

		Public Sub New(GridView As DevExpress.XtraGrid.Views.Grid.GridView)

			MyBase.New(GridView)

		End Sub

#End Region

	End Class

    Public Class CustomAdvBandedGridViewInfo
        Inherits DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.AdvBandedGridViewInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Protected Overrides Function CalcFooterCellHeight() As Integer
            Return 23
        End Function
        Public Overrides ReadOnly Property GroupFooterHeight As Integer
            Get
                GroupFooterHeight = 23
            End Get
        End Property
        Public Overrides ReadOnly Property GroupFooterCellHeight As Integer
            Get
                GroupFooterCellHeight = 23
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(GridView As DevExpress.XtraGrid.Views.Grid.GridView)

            MyBase.New(GridView)

        End Sub

#End Region

    End Class

End Namespace