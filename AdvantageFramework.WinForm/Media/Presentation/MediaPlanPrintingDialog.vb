Namespace Media.Presentation

	Public Class MediaPlanPrintingDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

		Private _CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
		Private _IsMasterPlan As Boolean = False
		Private _MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) = Nothing
        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, IsMasterPlan As Boolean, MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate), DbContext As AdvantageFramework.Database.DbContext)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _CompositeLink = CompositeLink
            _IsMasterPlan = IsMasterPlan
            _MediaPlanEstimates = MediaPlanEstimates
            _DbContext = DbContext

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, IsMasterPlan As Boolean,
                                              MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate),
                                              DbContext As AdvantageFramework.Database.DbContext) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanPrintingDialog As AdvantageFramework.Media.Presentation.MediaPlanPrintingDialog = Nothing

            MediaPlanPrintingDialog = New AdvantageFramework.Media.Presentation.MediaPlanPrintingDialog(CompositeLink, IsMasterPlan, MediaPlanEstimates, DbContext)

            ShowFormDialog = MediaPlanPrintingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanPrintingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim PageMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim HeaderAndFooterMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim AutoFitPagesToWidthMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim ScaleFactorMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim PageSetting As String = ""
			Dim HeaderAndFooterSetting As String = ""
			Dim AutoFitPagesToWidth As Integer = 0
			Dim ScaleFactor As Single = 0
			Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

			Try

				MediaPlanEstimate = _MediaPlanEstimates.FirstOrDefault

			Catch ex As Exception
				MediaPlanEstimate = Nothing
			End Try

			If MediaPlanEstimate IsNot Nothing Then

				Try

					PageMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageSettings.ToString)

				Catch ex As Exception
					PageMediaPlanDetailSetting = Nothing
				End Try

				If PageMediaPlanDetailSetting IsNot Nothing Then

					PageSetting = PageMediaPlanDetailSetting.StringValue

					If String.IsNullOrWhiteSpace(PageSetting) = False Then

						If PageSetting.StartsWith("?") Then

							PageSetting = PageSetting.Substring(1)

						End If

						Using MemoryStream = New System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(PageSetting))

							MemoryStream.Seek(0, IO.SeekOrigin.Begin)

							_CompositeLink.PrintingSystem.PageSettings.RestoreFromStream(MemoryStream)

						End Using

					End If

				End If

				Try

					HeaderAndFooterMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageHeaderAndFooterSettings.ToString)

				Catch ex As Exception
					HeaderAndFooterMediaPlanDetailSetting = Nothing
				End Try

				If HeaderAndFooterMediaPlanDetailSetting IsNot Nothing Then

					HeaderAndFooterSetting = HeaderAndFooterMediaPlanDetailSetting.StringValue

					If String.IsNullOrWhiteSpace(HeaderAndFooterSetting) = False Then

						If HeaderAndFooterSetting.StartsWith("?") Then

							HeaderAndFooterSetting = HeaderAndFooterSetting.Substring(1)

						End If

						Using MemoryStream = New System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(HeaderAndFooterSetting))

							MemoryStream.Seek(0, IO.SeekOrigin.Begin)

							_CompositeLink.RestorePageHeaderFooterFromStream(MemoryStream)

						End Using

					End If

				End If

				Try

					AutoFitPagesToWidthMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_AutoFitPagesToWidth.ToString)

				Catch ex As Exception
					AutoFitPagesToWidthMediaPlanDetailSetting = Nothing
				End Try

				If AutoFitPagesToWidthMediaPlanDetailSetting IsNot Nothing Then

					AutoFitPagesToWidth = AutoFitPagesToWidthMediaPlanDetailSetting.NumericValue.GetValueOrDefault(0)

				End If

				Try

					ScaleFactorMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_ScaleFactor.ToString)

				Catch ex As Exception
					ScaleFactorMediaPlanDetailSetting = Nothing
				End Try

				If ScaleFactorMediaPlanDetailSetting IsNot Nothing Then

					ScaleFactor = ScaleFactorMediaPlanDetailSetting.NumericValue.GetValueOrDefault(0)

				End If

			End If

			DocumentViewer1.PrintingSystem = _CompositeLink.PrintingSystem

			_CompositeLink.CreateDocument()

            If AutoFitPagesToWidth = 0 AndAlso ScaleFactor <> 0 Then

                _CompositeLink.PrintingSystemBase.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Scale, New Object() {ScaleFactor})

            ElseIf AutoFitPagesToWidth >= 1 Then

                _CompositeLink.PrintingSystem.Document.AutoFitToPagesWidth = AutoFitPagesToWidth

			End If

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub BarButtonItemSaveSettings_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSaveSettings.ItemClick

            'objects
            Dim PageMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim HeaderAndFooterMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim AutoFitPagesToWidthMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim ScaleFactorMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
			Dim PageSetting As String = ""
			Dim HeaderAndFooterSetting As String = ""
			Dim AutoFitPagesToWidth As Integer = 0
			Dim ScaleFactor As Single = 0

			Using MemoryStream = New System.IO.MemoryStream

				_CompositeLink.PrintingSystem.PageSettings.SaveToStream(MemoryStream)

				Try

					PageSetting = System.Text.Encoding.UTF8.GetString(MemoryStream.ToArray)

				Catch ex As Exception
					PageSetting = ""
				End Try

			End Using

			Using MemoryStream = New System.IO.MemoryStream

				_CompositeLink.SavePageHeaderFooterToStream(MemoryStream)

				Try

					HeaderAndFooterSetting = System.Text.Encoding.UTF8.GetString(MemoryStream.ToArray)

				Catch ex As Exception
					HeaderAndFooterSetting = ""
				End Try

			End Using

			AutoFitPagesToWidth = _CompositeLink.PrintingSystem.Document.AutoFitToPagesWidth
			ScaleFactor = _CompositeLink.PrintingSystem.Document.ScaleFactor

			If _IsMasterPlan Then

				For Each MediaPlanEstimate In _MediaPlanEstimates

					Try

						PageMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageSettings.ToString)

					Catch ex As Exception
						PageMediaPlanDetailSetting = Nothing
					End Try

					If PageMediaPlanDetailSetting Is Nothing Then

						PageMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						PageMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						PageMediaPlanDetailSetting.MediaPlanDetailID = MediaPlanEstimate.GetEntity.ID
						PageMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageSettings.ToString

						PageMediaPlanDetailSetting.CreatedByUserCode = _DbContext.UserCode
						PageMediaPlanDetailSetting.CreatedDate = Now

                        _DbContext.MediaPlanDetailSettings.Add(PageMediaPlanDetailSetting)

                    Else

						PageMediaPlanDetailSetting.ModifiedByUserCode = _DbContext.UserCode
						PageMediaPlanDetailSetting.ModifiedDate = Now

						_DbContext.UpdateObject(PageMediaPlanDetailSetting)

					End If

					If PageMediaPlanDetailSetting IsNot Nothing Then

						PageMediaPlanDetailSetting.StringValue = PageSetting

					End If

					Try

						HeaderAndFooterMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageHeaderAndFooterSettings.ToString)

					Catch ex As Exception
						HeaderAndFooterMediaPlanDetailSetting = Nothing
					End Try

					If HeaderAndFooterMediaPlanDetailSetting Is Nothing Then

						HeaderAndFooterMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						HeaderAndFooterMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						HeaderAndFooterMediaPlanDetailSetting.MediaPlanDetailID = MediaPlanEstimate.GetEntity.ID
						HeaderAndFooterMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageHeaderAndFooterSettings.ToString

						HeaderAndFooterMediaPlanDetailSetting.CreatedByUserCode = _DbContext.UserCode
						HeaderAndFooterMediaPlanDetailSetting.CreatedDate = Now

                        _DbContext.MediaPlanDetailSettings.Add(HeaderAndFooterMediaPlanDetailSetting)

                    Else

						HeaderAndFooterMediaPlanDetailSetting.ModifiedByUserCode = _DbContext.UserCode
						HeaderAndFooterMediaPlanDetailSetting.ModifiedDate = Now

						_DbContext.UpdateObject(HeaderAndFooterMediaPlanDetailSetting)

					End If

					If HeaderAndFooterMediaPlanDetailSetting IsNot Nothing Then

						HeaderAndFooterMediaPlanDetailSetting.StringValue = HeaderAndFooterSetting

					End If

					Try

						AutoFitPagesToWidthMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_AutoFitPagesToWidth.ToString)

					Catch ex As Exception
						AutoFitPagesToWidthMediaPlanDetailSetting = Nothing
					End Try

					If AutoFitPagesToWidthMediaPlanDetailSetting Is Nothing Then

						AutoFitPagesToWidthMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						AutoFitPagesToWidthMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						AutoFitPagesToWidthMediaPlanDetailSetting.MediaPlanDetailID = MediaPlanEstimate.GetEntity.ID
						AutoFitPagesToWidthMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_AutoFitPagesToWidth.ToString

						AutoFitPagesToWidthMediaPlanDetailSetting.CreatedByUserCode = _DbContext.UserCode
						AutoFitPagesToWidthMediaPlanDetailSetting.CreatedDate = Now

                        _DbContext.MediaPlanDetailSettings.Add(AutoFitPagesToWidthMediaPlanDetailSetting)

                    Else

						AutoFitPagesToWidthMediaPlanDetailSetting.ModifiedByUserCode = _DbContext.UserCode
						AutoFitPagesToWidthMediaPlanDetailSetting.ModifiedDate = Now

						_DbContext.UpdateObject(PageMediaPlanDetailSetting)

					End If

					If AutoFitPagesToWidthMediaPlanDetailSetting IsNot Nothing Then

						AutoFitPagesToWidthMediaPlanDetailSetting.NumericValue = AutoFitPagesToWidth

					End If

					Try

						ScaleFactorMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_ScaleFactor.ToString)

					Catch ex As Exception
						ScaleFactorMediaPlanDetailSetting = Nothing
					End Try

					If ScaleFactorMediaPlanDetailSetting Is Nothing Then

						ScaleFactorMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						ScaleFactorMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						ScaleFactorMediaPlanDetailSetting.MediaPlanDetailID = MediaPlanEstimate.GetEntity.ID
						ScaleFactorMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_ScaleFactor.ToString

						ScaleFactorMediaPlanDetailSetting.CreatedByUserCode = _DbContext.UserCode
						ScaleFactorMediaPlanDetailSetting.CreatedDate = Now

                        _DbContext.MediaPlanDetailSettings.Add(ScaleFactorMediaPlanDetailSetting)

                    Else

						ScaleFactorMediaPlanDetailSetting.ModifiedByUserCode = _DbContext.UserCode
						ScaleFactorMediaPlanDetailSetting.ModifiedDate = Now

						_DbContext.UpdateObject(PageMediaPlanDetailSetting)

					End If

					If ScaleFactorMediaPlanDetailSetting IsNot Nothing Then

						ScaleFactorMediaPlanDetailSetting.NumericValue = ScaleFactor

					End If

				Next

				Try

					_DbContext.SaveChanges()

				Catch ex As Exception

				End Try

			Else

				For Each MediaPlanEstimate In _MediaPlanEstimates

					Try

						PageMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageSettings.ToString)

					Catch ex As Exception
						PageMediaPlanDetailSetting = Nothing
					End Try

					If PageMediaPlanDetailSetting Is Nothing Then

						PageMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						PageMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						PageMediaPlanDetailSetting.MediaPlanDetail = MediaPlanEstimate.GetEntity
						PageMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageSettings.ToString

						MediaPlanEstimate.GetEntity.MediaPlanDetailSettings.Add(PageMediaPlanDetailSetting)

					End If

					If PageMediaPlanDetailSetting IsNot Nothing Then

						PageMediaPlanDetailSetting.StringValue = PageSetting

					End If

					Try

						HeaderAndFooterMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageHeaderAndFooterSettings.ToString)

					Catch ex As Exception
						HeaderAndFooterMediaPlanDetailSetting = Nothing
					End Try

					If HeaderAndFooterMediaPlanDetailSetting Is Nothing Then

						HeaderAndFooterMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						HeaderAndFooterMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						HeaderAndFooterMediaPlanDetailSetting.MediaPlanDetail = MediaPlanEstimate.GetEntity
						HeaderAndFooterMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_PageHeaderAndFooterSettings.ToString

						MediaPlanEstimate.GetEntity.MediaPlanDetailSettings.Add(HeaderAndFooterMediaPlanDetailSetting)

					End If

					If HeaderAndFooterMediaPlanDetailSetting IsNot Nothing Then

						HeaderAndFooterMediaPlanDetailSetting.StringValue = HeaderAndFooterSetting

					End If

					Try

						AutoFitPagesToWidthMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_AutoFitPagesToWidth.ToString)

					Catch ex As Exception
						AutoFitPagesToWidthMediaPlanDetailSetting = Nothing
					End Try

					If AutoFitPagesToWidthMediaPlanDetailSetting Is Nothing Then

						AutoFitPagesToWidthMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						AutoFitPagesToWidthMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						AutoFitPagesToWidthMediaPlanDetailSetting.MediaPlanDetail = MediaPlanEstimate.GetEntity
						AutoFitPagesToWidthMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_AutoFitPagesToWidth.ToString

						MediaPlanEstimate.GetEntity.MediaPlanDetailSettings.Add(AutoFitPagesToWidthMediaPlanDetailSetting)

					End If

					If AutoFitPagesToWidthMediaPlanDetailSetting IsNot Nothing Then

						AutoFitPagesToWidthMediaPlanDetailSetting.NumericValue = AutoFitPagesToWidth

					End If

					Try

						ScaleFactorMediaPlanDetailSetting = MediaPlanEstimate.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Print_ScaleFactor.ToString)

					Catch ex As Exception
						ScaleFactorMediaPlanDetailSetting = Nothing
					End Try

					If ScaleFactorMediaPlanDetailSetting Is Nothing Then

						ScaleFactorMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

						ScaleFactorMediaPlanDetailSetting.MediaPlanID = MediaPlanEstimate.GetEntity.MediaPlanID
						ScaleFactorMediaPlanDetailSetting.MediaPlanDetail = MediaPlanEstimate.GetEntity
						ScaleFactorMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Print_ScaleFactor.ToString

						MediaPlanEstimate.GetEntity.MediaPlanDetailSettings.Add(ScaleFactorMediaPlanDetailSetting)

					End If

					If ScaleFactorMediaPlanDetailSetting IsNot Nothing Then

						ScaleFactorMediaPlanDetailSetting.NumericValue = ScaleFactor

					End If

					MediaPlanEstimate.FieldsChanged()

				Next

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
