Namespace WinForm.MVC.Presentation.Controls.Classes

	Public Class CustomGridViewInfoRegistrator
		Inherits DevExpress.XtraGrid.Registrator.GridInfoRegistrator

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Overrides ReadOnly Property ViewName As String
			Get
				ViewName = "GridViewControl"
			End Get
		End Property

#End Region

#Region " Methods "

		Public Overrides Function CreateView(grid As DevExpress.XtraGrid.GridControl) As DevExpress.XtraGrid.Views.Base.BaseView

			'Return New GridView(CType(grid, DevExpress.XtraGrid.GridControl))
			Return New GridView()

		End Function
		Public Overrides Function CreateViewInfo(view As DevExpress.XtraGrid.Views.Base.BaseView) As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo

			If TypeOf view Is GridView AndAlso CType(view, GridView).ModifyGridRowHeight Then

				Return New CustomGridViewInfo(CType(view, GridView))

			Else

				Return New DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo(view)

			End If

		End Function

#End Region

	End Class

	Public Class CustomBandedGridViewInfoRegistrator
		Inherits DevExpress.XtraGrid.Registrator.BandedGridInfoRegistrator

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Overrides ReadOnly Property ViewName As String
			Get
				ViewName = "BandedGridViewControl"
			End Get
		End Property

#End Region

#Region " Methods "

        Public Overrides Function CreateView(grid As DevExpress.XtraGrid.GridControl) As DevExpress.XtraGrid.Views.Base.BaseView

			'Return New GridView(CType(grid, DevExpress.XtraGrid.GridControl))
			Return New BandedGridView()

		End Function
		Public Overrides Function CreateViewInfo(view As DevExpress.XtraGrid.Views.Base.BaseView) As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo

			If TypeOf view Is BandedGridView AndAlso CType(view, BandedGridView).ModifyGridRowHeight Then

				Return New CustomBandedGridViewInfo(view)

			Else

				Return New DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo(view)

			End If

		End Function

#End Region

	End Class

    Public Class CustomAdvBandedGridViewInfoRegistrator
        Inherits DevExpress.XtraGrid.Registrator.AdvBandedGridInfoRegistrator

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overrides ReadOnly Property ViewName As String
            Get
                ViewName = "BandedGridViewControl"
            End Get
        End Property

#End Region

#Region " Methods "

        Public Overrides Function CreateView(grid As DevExpress.XtraGrid.GridControl) As DevExpress.XtraGrid.Views.Base.BaseView

            'Return New GridView(CType(grid, DevExpress.XtraGrid.GridControl))
            Return New BandedGridView()

        End Function
        Public Overrides Function CreateViewInfo(view As DevExpress.XtraGrid.Views.Base.BaseView) As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo

            If TypeOf view Is BandedGridView AndAlso CType(view, BandedGridView).ModifyGridRowHeight Then

                Return New CustomAdvBandedGridViewInfo(view)

            Else

                Return New DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo(view)

            End If

        End Function

#End Region

    End Class

End Namespace
