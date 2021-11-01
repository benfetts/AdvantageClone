Namespace MediaPlanning.Classes

	Public Class MediaPlan

		Public Event MediaPlanChangedEvent()
		Public Event SavedMediaPlanEvent()

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			Comment
			ClientCode
			DivisionCode
			ProductCode
			ClientContactID
            'CampaignCode
            CampaignID
            StartDate
			EndDate
			GrossBudgetAmount
            SyncDetailSettings
            Product
            MediaPlanEstimate
			HasChanged
			HasMediaOrder
			BroadcastCalendarWeeks
			LastApprovalDateUser
			IsInactive
            SyncFieldWidths
            IsTemplate
        End Enum

#End Region

#Region " Variables "

		Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
		Private _MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
		Private _Product As AdvantageFramework.Database.Entities.Product = Nothing
		Public MediaPlanEstimates As Hashtable = Nothing
		Private _MediaPlanEstimate As MediaPlanEstimate = Nothing
		Private _HasChanged As Boolean = False
		Private _BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
		Private _ConnectionString As String = String.Empty
		Private _UserCode As String = String.Empty

#End Region

#Region " Properties "

		Public Property ID() As Integer
			Get
				ID = _MediaPlan.ID
			End Get
			Set(ByVal value As Integer)
				_MediaPlan.ID = value
			End Set
		End Property
		Public Property Description() As String
			Get
				Description = _MediaPlan.Description
			End Get
			Set(ByVal value As String)

				If value <> _MediaPlan.Description Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.Description = value

			End Set
		End Property
		Public ReadOnly Property HasUnapprovedEstimates As Boolean
			Get
				HasUnapprovedEstimates = _MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any()
			End Get
		End Property
		'Public Property IsApproved() As Boolean
		'    Get
		'        IsApproved = _MediaPlan.IsApproved
		'    End Get
		'    Set(ByVal value As Boolean)

		'        If value <> _MediaPlan.IsApproved Then

		'            RaiseEvent MediaPlanChangedEvent()

		'        End If

		'        _MediaPlan.IsApproved = value

		'    End Set
		'End Property
		'Public Property ApprovedBy() As String
		'    Get
		'        ApprovedBy = _MediaPlan.ApprovedBy
		'    End Get
		'    Set(ByVal value As String)

		'        If value <> _MediaPlan.ApprovedBy Then

		'            RaiseEvent MediaPlanChangedEvent()

		'        End If

		'        _MediaPlan.ApprovedBy = value

		'    End Set
		'End Property
		'Public Property ApprovedDate() As Nullable(Of Date)
		'    Get
		'        ApprovedDate = _MediaPlan.ApprovedDate
		'    End Get
		'    Set(ByVal value As Nullable(Of Date))

		'        If value <> _MediaPlan.ApprovedDate Then

		'            RaiseEvent MediaPlanChangedEvent()

		'        End If

		'        _MediaPlan.ApprovedDate = value

		'    End Set
		'End Property
		Public Property Comment() As String
			Get
				Comment = _MediaPlan.Comment
			End Get
			Set(ByVal value As String)

				If value <> _MediaPlan.Comment Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.Comment = value

			End Set
		End Property
		Public Property ClientCode() As String
			Get
				ClientCode = _MediaPlan.ClientCode
			End Get
			Set(ByVal value As String)
				_MediaPlan.ClientCode = value
			End Set
		End Property
		Public Property DivisionCode() As String
			Get
				DivisionCode = _MediaPlan.DivisionCode
			End Get
			Set(ByVal value As String)
				_MediaPlan.DivisionCode = value
			End Set
		End Property
		Public Property ProductCode() As String
			Get
				ProductCode = _MediaPlan.ProductCode
			End Get
			Set(ByVal value As String)
				_MediaPlan.ProductCode = value
			End Set
		End Property
		Public Property ClientContactID() As Nullable(Of Integer)
			Get
				ClientContactID = _MediaPlan.ClientContactID
			End Get
			Set(ByVal value As Nullable(Of Integer))

				If value <> _MediaPlan.ClientContactID Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.ClientContactID = value

			End Set
		End Property
        'Public Property CampaignCode() As String
        '    Get
        '        CampaignCode = _MediaPlan.CampaignCode
        '    End Get
        '    Set(ByVal value As String)

        '        If value <> _MediaPlan.CampaignCode Then

        '            RaiseEvent MediaPlanChangedEvent()

        '        End If

        '        _MediaPlan.CampaignCode = value

        '    End Set
        'End Property
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _MediaPlan.CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))

                If value <> _MediaPlan.CampaignID Then

                    RaiseEvent MediaPlanChangedEvent()

                End If

                _MediaPlan.CampaignID = value

            End Set
        End Property
        Public Property StartDate() As Date
			Get
				StartDate = _MediaPlan.StartDate
			End Get
			Set(ByVal value As Date)

				If value <> _MediaPlan.StartDate Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.StartDate = value

			End Set
		End Property
		Public Property EndDate() As Date
			Get
				EndDate = _MediaPlan.EndDate
			End Get
			Set(ByVal value As Date)

				If value <> _MediaPlan.EndDate Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.EndDate = value

			End Set
		End Property
		Public Property GrossBudgetAmount() As Nullable(Of Decimal)
			Get
				GrossBudgetAmount = _MediaPlan.GrossBudgetAmount
			End Get
			Set(ByVal value As Nullable(Of Decimal))

				If value <> _MediaPlan.GrossBudgetAmount Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.GrossBudgetAmount = value

			End Set
		End Property
		Public Property SyncDetailSettings() As Boolean
			Get
				SyncDetailSettings = _MediaPlan.SyncDetailSettings
			End Get
			Set(ByVal value As Boolean)

				If value <> _MediaPlan.SyncDetailSettings Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.SyncDetailSettings = value

			End Set
		End Property
		Public ReadOnly Property Product() As AdvantageFramework.Database.Entities.Product
			Get
				Product = _Product
			End Get
		End Property
		Public ReadOnly Property MediaPlanEstimate As MediaPlanEstimate
			Get
				MediaPlanEstimate = _MediaPlanEstimate
			End Get
		End Property
		Public ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
			Get
				DbContext = _DbContext
			End Get
		End Property
		Public ReadOnly Property HasChanged As Boolean
			Get
				HasChanged = _HasChanged
			End Get
		End Property
		Public ReadOnly Property HasMediaOrder As Boolean
			Get

				If MediaPlanEstimates IsNot Nothing Then

					HasMediaOrder = MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList.Any(Function(MPE) MPE.HasMediaOrder = True)

				Else

					HasMediaOrder = False

				End If

			End Get
		End Property
		Public ReadOnly Property BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)
			Get
				BroadcastCalendarWeeks = _BroadcastCalendarWeeks
			End Get
		End Property
		Public ReadOnly Property LastApprovalDateUser As String
			Get
				If _MediaPlan.MediaPlanDetails.Where(Function(MPD) MPD.IsApproved).Count = 0 Then

					LastApprovalDateUser = Nothing

				Else

					Try

						LastApprovalDateUser = (From MPD In _MediaPlan.MediaPlanDetails
												Where MPD.IsApproved = True
												Select New With {.ApprovedDate = MPD.ApprovedDate,
																 .LastApprovalDateUser = "Approved " & MPD.ApprovedDate.Value & " by " & MPD.ApprovedBy}).OrderByDescending(Function(MPD) MPD.ApprovedDate.Value).FirstOrDefault.LastApprovalDateUser

					Catch ex As Exception
						LastApprovalDateUser = Nothing
					End Try

				End If
			End Get
		End Property
		Public Property IsInactive() As Boolean
			Get
				IsInactive = _MediaPlan.IsInactive
			End Get
			Set(ByVal value As Boolean)

				If value <> _MediaPlan.IsInactive Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.IsInactive = value

			End Set
		End Property
		Public ReadOnly Property TotalDollars As Decimal
			Get

				If MediaPlanEstimates IsNot Nothing Then

					TotalDollars = 0

					For Each MPE In MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList

						TotalDollars += MPE.TotalDollars

					Next

				Else

					TotalDollars = 0

				End If

			End Get
		End Property
		Public ReadOnly Property TotalBillAmount As Decimal
			Get

				If MediaPlanEstimates IsNot Nothing Then

					TotalBillAmount = 0

					For Each MPE In MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList

						TotalBillAmount += MPE.TotalBillAmount

					Next

				Else

					TotalBillAmount = 0

				End If

			End Get
		End Property
		Public Property SyncFieldWidths() As Boolean
			Get
				SyncFieldWidths = _MediaPlan.SyncFieldWidths
			End Get
			Set(ByVal value As Boolean)

				If value <> _MediaPlan.SyncFieldWidths Then

					RaiseEvent MediaPlanChangedEvent()

				End If

				_MediaPlan.SyncFieldWidths = value

			End Set
		End Property
        Public Property IsTemplate() As Boolean
            Get
                IsTemplate = _MediaPlan.IsTemplate
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlan.IsTemplate Then

                    RaiseEvent MediaPlanChangedEvent()

                End If

                _MediaPlan.IsTemplate = value

            End Set
        End Property
        Public Property CountryID() As Integer
            Get
                CountryID = _MediaPlan.CountryID
            End Get
            Set(ByVal value As Integer)

                If value <> _MediaPlan.CountryID Then

                    RaiseEvent MediaPlanChangedEvent()

                End If

                _MediaPlan.CountryID = value

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ConnectionString As String, UserCode As String, ByVal MediaPlanID As Integer)

			'objects
			Dim MediaPlanEstimate As MediaPlanEstimate = Nothing

			_ConnectionString = ConnectionString
			_UserCode = UserCode

			RefreshDbContext()

			Try

                _MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.Load(_DbContext).Include("MediaPlanDetails") _
                                                                                              .Include("MediaPlanDetails.SalesClass") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevels") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLines") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLines.MediaPlanDetailLevel") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevels.MediaPlanDetailLevelLines") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLineDatas") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailFields") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLineTags") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailSettings") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailChangeLogs") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackageDetails") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackageDetails.AdSize") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackagePlacementNames").SingleOrDefault(Function(Entity) Entity.ID = MediaPlanID)

            Catch ex As Exception
				_MediaPlan = Nothing
			End Try

			Try

				_Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, _MediaPlan.ClientCode, _MediaPlan.DivisionCode, _MediaPlan.ProductCode)

			Catch ex As Exception
				_Product = Nothing
			End Try

            If _Product IsNot Nothing Then

                _DbContext.Products.Attach(_Product)

                _DbContext.Entry(_Product).Reference("Client").Load()
                _DbContext.Entry(_Product).Reference("Division").Load()

            End If

            Try

				_BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

			Catch ex As Exception
				_BroadcastCalendarWeeks = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)
			End Try

			Try

				MediaPlanEstimates = New Hashtable

				For Each MediaPlanDetail In _MediaPlan.MediaPlanDetails.OrderBy(Function(Entity) Entity.OrderNumber).ToList

					MediaPlanEstimate = New MediaPlanEstimate(Me, MediaPlanDetail, _BroadcastCalendarWeeks)

					AddHandler MediaPlanEstimate.EstimateChangedEvent, AddressOf EstimateChangedEvent

					If MediaPlanEstimate.OrderNumber <> MediaPlanEstimates.Count + 1 Then

						MediaPlanEstimate.OrderNumber = MediaPlanEstimates.Count + 1

						Try

							_DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET ORDER_NUMBER = {0} WHERE MEDIA_PLAN_DTL_ID = {1}", MediaPlanEstimate.OrderNumber, MediaPlanEstimate.ID))

						Catch ex As Exception

						End Try

					End If

					MediaPlanEstimates(MediaPlanEstimate.OrderNumber) = MediaPlanEstimate

				Next

			Catch ex As Exception
				MediaPlanEstimates = Nothing
			End Try

		End Sub
		Public Sub CloseDbContext()

			If _DbContext IsNot Nothing Then

				_DbContext.Dispose()

				_DbContext = Nothing

			End If

		End Sub
		Private Sub RefreshDbContext()

			CloseDbContext()

			_DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

			_DbContext.Configuration.AutoDetectChangesEnabled = False
			'_DbContext.Configuration.ProxyCreationEnabled = False
			'_DbContext.Configuration.LazyLoadingEnabled = False

		End Sub
		Public Function GetMediaPlanEstimate(ByVal OrderNumber As Integer) As MediaPlanEstimate

			Try

				GetMediaPlanEstimate = MediaPlanEstimates(OrderNumber)

			Catch ex As Exception
				GetMediaPlanEstimate = Nothing
			End Try

		End Function
		Public Function GetMediaPlanEstimateByMediaPlanDetailID(ByVal MediaPlanDetailID As Integer) As MediaPlanEstimate

			Try

				GetMediaPlanEstimateByMediaPlanDetailID = MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).Where(Function(MPE) MPE.ID = MediaPlanDetailID).SingleOrDefault

			Catch ex As Exception
				GetMediaPlanEstimateByMediaPlanDetailID = Nothing
			End Try

		End Function
		Public Sub SelectMediaPlanEstimate(ByVal OrderNumber As Integer)

			Try

                _MediaPlanEstimate = MediaPlanEstimates(OrderNumber)

            Catch ex As Exception
				_MediaPlanEstimate = Nothing
			End Try

			If _MediaPlanEstimate IsNot Nothing Then

				If _MediaPlanEstimate.IsDataLoaded = False Then

					_MediaPlanEstimate.CreateEstimateDataTable()

				End If

			End If

		End Sub
		Public Sub SelectMediaPlanEstimateByMediaPlanDetailID(ByVal MediaPlanDetailID As Integer)

			_MediaPlanEstimate = GetMediaPlanEstimateByMediaPlanDetailID(MediaPlanDetailID)

			If _MediaPlanEstimate IsNot Nothing Then

				If _MediaPlanEstimate.IsDataLoaded = False Then

					_MediaPlanEstimate.CreateEstimateDataTable()

				End If

			End If

		End Sub
		Public Sub EstimateChangedEvent()

			RaiseEvent MediaPlanChangedEvent()

			_HasChanged = True

		End Sub
        Private Sub AddNewFields(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.MediaPlanning.DataColumns), False)

                MediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                MediaPlanDetailField.MediaPlanID = Me.ID
                MediaPlanDetailField.MediaPlanDetailID = MediaPlanDetail.ID
                MediaPlanDetailField.FieldID = KeyValuePair.Value
                MediaPlanDetailField.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value)
                MediaPlanDetailField.Index = KeyValuePair.Key

                If KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                    MediaPlanDetailField.Area = 2
                    MediaPlanDetailField.AreaIndex = 0
                    MediaPlanDetailField.IsVisible = False

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID Then

                    MediaPlanDetailField.Area = 2
                    MediaPlanDetailField.AreaIndex = 1
                    MediaPlanDetailField.IsVisible = False

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.LevelLineID Then

                    MediaPlanDetailField.Area = 2
                    MediaPlanDetailField.AreaIndex = 3
                    MediaPlanDetailField.IsVisible = False

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 0
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 1
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Month Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 2
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 3
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 4
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Day Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 5
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.[Date] Then

                    MediaPlanDetailField.Area = 1
                    MediaPlanDetailField.AreaIndex = 6
                    MediaPlanDetailField.IsVisible = True

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.StartDate Then

                    MediaPlanDetailField.Area = 2
                    MediaPlanDetailField.AreaIndex = 2
                    MediaPlanDetailField.IsVisible = False

                    'ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.EndDate Then

                    '	MediaPlanDetailField.Area = 2
                    '	MediaPlanDetailField.AreaIndex = 4
                    '	MediaPlanDetailField.IsVisible = False

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.RowIndex Then

                    MediaPlanDetailField.Area = 0
                    MediaPlanDetailField.AreaIndex = 0
                    MediaPlanDetailField.IsVisible = False

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Demo1 Then

                    MediaPlanDetailField.Area = 3

                    If MediaPlanDetail.SalesClassType = "N" Then

                        MediaPlanDetailField.IsVisible = False

                    Else

                        MediaPlanDetailField.IsVisible = True

                    End If

                    MediaPlanDetailField.AreaIndex = 0

                    If MediaPlanDetail.MediaDemographicID.GetValueOrDefault(0) > 0 Then

                        Try

                            MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(_DbContext, MediaPlanDetail.MediaDemographicID.GetValueOrDefault(0))

                        Catch ex As Exception
                            MediaDemographic = Nothing
                        End Try

                        If MediaDemographic IsNot Nothing Then

                            MediaPlanDetailField.Caption = MediaDemographic.Description

                        End If

                    End If

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Demo2 Then

                    MediaPlanDetailField.Area = 3

                    If MediaPlanDetail.SalesClassType = "N" Then

                        MediaPlanDetailField.IsVisible = False

                    Else

                        MediaPlanDetailField.IsVisible = True

                    End If

                    MediaPlanDetailField.AreaIndex = 1

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Units Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 2

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Impressions Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 3

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Clicks Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 4

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Columns Then

                    MediaPlanDetailField.Area = 3

                    If MediaPlanDetail.SalesClassType = "N" Then

                        MediaPlanDetailField.IsVisible = True

                    Else

                        MediaPlanDetailField.IsVisible = False

                    End If

                    MediaPlanDetailField.AreaIndex = 5

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.InchesLines Then

                    MediaPlanDetailField.Area = 3

                    If MediaPlanDetail.SalesClassType = "N" Then

                        MediaPlanDetailField.IsVisible = True

                    Else

                        MediaPlanDetailField.IsVisible = False

                    End If

                    MediaPlanDetailField.Caption = "Inches/Lines"

                    MediaPlanDetailField.AreaIndex = 6

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Rate Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 7

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Dollars Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 8

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.NetCharge Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 9

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 10

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.BillAmount Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = True

                    MediaPlanDetailField.AreaIndex = 11

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Note Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.IsVisible = False
                    MediaPlanDetailField.AreaIndex = 12

                ElseIf KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataColumns.Color Then

                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.AreaIndex = 13
                    MediaPlanDetailField.IsVisible = False

                End If

                MediaPlanDetailField.SortOrder = 0
                MediaPlanDetailField.Width = 100
                MediaPlanDetailField.ShowInGrandTotals = True
                MediaPlanDetailField.ShowInTotals = True
                MediaPlanDetailField.ShowInValues = True

                If MediaPlanDetail.MediaPlanDetailFields Is Nothing Then

                    MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                End If

                MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)

            Next

        End Sub
        Private Sub CopyFieldsFromFirstMediaPlanDetail(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail)

			'objects
			Dim FirstMediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
			Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
			Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing

            Try

				FirstMediaPlanEstimate = Me.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).FirstOrDefault

			Catch ex As Exception
				FirstMediaPlanEstimate = Nothing
			End Try

			If FirstMediaPlanEstimate IsNot Nothing Then

				If MediaPlanDetail.MediaPlanDetailFields Is Nothing Then

					MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

				End If

				For Each FirstMediaPlanDetailField In FirstMediaPlanEstimate.MediaPlanDetailFields.ToList

					MediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

					MediaPlanDetailField.MediaPlanID = Me.ID
					MediaPlanDetailField.MediaPlanDetail = MediaPlanDetail
					MediaPlanDetailField.FieldID = FirstMediaPlanDetailField.FieldID
					MediaPlanDetailField.Caption = FirstMediaPlanDetailField.Caption
					MediaPlanDetailField.IsVisible = FirstMediaPlanDetailField.IsVisible
					MediaPlanDetailField.Index = FirstMediaPlanDetailField.Index
					MediaPlanDetailField.Area = FirstMediaPlanDetailField.Area
					MediaPlanDetailField.AreaIndex = FirstMediaPlanDetailField.AreaIndex
					MediaPlanDetailField.SortOrder = FirstMediaPlanDetailField.SortOrder
					MediaPlanDetailField.Width = FirstMediaPlanDetailField.Width
					MediaPlanDetailField.ShowInGrandTotals = FirstMediaPlanDetailField.ShowInGrandTotals
					MediaPlanDetailField.ShowInTotals = FirstMediaPlanDetailField.ShowInTotals
					MediaPlanDetailField.ShowInValues = FirstMediaPlanDetailField.ShowInValues

                    If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                        If MediaPlanDetail.MediaDemographicID.GetValueOrDefault(0) > 0 Then

                            Try

                                MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(_DbContext, MediaPlanDetail.MediaDemographicID.GetValueOrDefault(0))

                            Catch ex As Exception
                                MediaDemographic = Nothing
                            End Try

                            If MediaDemographic IsNot Nothing Then

                                MediaPlanDetailField.Caption = MediaDemographic.Description

                            End If

                        End If

                    End If

                    MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)

				Next

				For Each FirstMediaPlanDetailLevel In FirstMediaPlanEstimate.MediaPlanDetailLevels.ToList

					MediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

					MediaPlanDetailLevel.MediaPlanID = Me.ID
					MediaPlanDetailLevel.MediaPlanDetail = MediaPlanDetail
					MediaPlanDetailLevel.Description = FirstMediaPlanDetailLevel.Description
					MediaPlanDetailLevel.OrderNumber = FirstMediaPlanDetailLevel.OrderNumber
					MediaPlanDetailLevel.Width = FirstMediaPlanDetailLevel.Width
					MediaPlanDetailLevel.TagType = FirstMediaPlanDetailLevel.TagType
					MediaPlanDetailLevel.MappingType = FirstMediaPlanDetailLevel.MappingType
					MediaPlanDetailLevel.IsVisible = FirstMediaPlanDetailLevel.IsVisible

					MediaPlanDetail.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)

				Next

			End If

		End Sub
		Private Sub LoadInitialSettings(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

			'objects
			Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

			If Me.Product IsNot Nothing Then

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.DbContext.ConnectionString, Me.DbContext.UserCode)

					Try

						ProductMediaOverrides = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, Me.Product.ClientCode, Me.Product.DivisionCode, Me.Product.Code).SingleOrDefault(Function(Entity) Entity.MediaType = MediaPlanEstimate.SalesClassTypeEnumObject.Code AndAlso Entity.SalesClassCode = MediaPlanEstimate.SalesClassCode)

					Catch ex As Exception
						ProductMediaOverrides = Nothing
					End Try

				End Using

				If ProductMediaOverrides IsNot Nothing Then

					If MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" Then

						If Product.RadioBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

						If Product.TelevisionBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" Then

						If Product.MagazineBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

						If Product.OutOfHomeBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

						If Product.InternetBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

						If Product.NewspaperBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False

						End If

					End If

					MediaPlanEstimate.ProductRebateAmount = ProductMediaOverrides.RebatePercent.GetValueOrDefault(0)
					MediaPlanEstimate.ProductMarkupAmount = ProductMediaOverrides.MarkupPercent.GetValueOrDefault(0)

				Else

					If MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" Then

						If Product.RadioBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.RadioRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.RadioMarkup.GetValueOrDefault(0)

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

						If Product.TelevisionBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.TelevisionRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.TelevisionMarkup.GetValueOrDefault(0)

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" Then

						If Product.MagazineBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.MagazineRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.MagazineMarkup.GetValueOrDefault(0)

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

						If Product.OutOfHomeBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.OutOfHomeRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.OutOfHomeMarkup.GetValueOrDefault(0)

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

						If Product.InternetBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.InternetRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.InternetMarkup.GetValueOrDefault(0)

						End If

					ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

						If Product.NewspaperBillNet = 1 Then

							MediaPlanEstimate.ProductUsesNetAmount = True
							MediaPlanEstimate.ProductRebateAmount = 0
							MediaPlanEstimate.ProductMarkupAmount = 0

						Else

							MediaPlanEstimate.ProductUsesNetAmount = False
							MediaPlanEstimate.ProductRebateAmount = Product.NewspaperRebate.GetValueOrDefault(0)
							MediaPlanEstimate.ProductMarkupAmount = Product.NewspaperMarkup.GetValueOrDefault(0)

						End If

					End If

				End If

			Else

				MediaPlanEstimate.ProductUsesNetAmount = True
				MediaPlanEstimate.ProductRebateAmount = 0
				MediaPlanEstimate.ProductMarkupAmount = 0

			End If

		End Sub
		Public Function AddMediaPlanEstimate(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail, ByRef OrderNumber As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaPlanEstimate As MediaPlanEstimate = Nothing
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim ErrorMessage As String = Nothing

            Try

				_DbContext.UpdateObject(_MediaPlan)

                _MediaPlan.MediaPlanDetails.Add(MediaPlanDetail)

                MediaPlanDetail.MediaPlanID = _MediaPlan.ID
                MediaPlanDetail.OrderNumber = _MediaPlan.MediaPlanDetails.Count

                If Me.SyncDetailSettings Then

					If Me.MediaPlanEstimates.Count = 0 Then

                        AddNewFields(MediaPlanDetail)

                    Else

						CopyFieldsFromFirstMediaPlanDetail(MediaPlanDetail)

					End If

				Else

                    AddNewFields(MediaPlanDetail)

                End If

				For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.MediaPlanning.Settings), False)

					MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

					MediaPlanDetailSetting.MediaPlanID = Me.ID
					MediaPlanDetailSetting.MediaPlanDetail = MediaPlanDetail
					MediaPlanDetailSetting.Setting = KeyValuePair.Value

					If MediaPlanDetail.MediaPlanDetailSettings Is Nothing Then

						MediaPlanDetail.MediaPlanDetailSettings = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting)

					End If

					MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

				Next

                MediaPlanEstimate = New AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate(Me, MediaPlanDetail, _BroadcastCalendarWeeks)

                LoadInitialSettings(MediaPlanEstimate)

                If MediaPlanEstimate.Save(_DbContext, _MediaPlan, ErrorMessage) Then

                    _DbContext.SaveChanges()

                Else

                    Throw New Exception(ErrorMessage)

                End If

                AddHandler MediaPlanEstimate.EstimateChangedEvent, AddressOf EstimateChangedEvent

				MediaPlanEstimates(MediaPlanEstimate.OrderNumber) = MediaPlanEstimate

				Added = True

			Catch ex As Exception
				Added = False
			End Try

			AddMediaPlanEstimate = Added

			If Added Then

				RefreshOrderNumbers()

				OrderNumber = MediaPlanDetail.OrderNumber

            End If

		End Function
        Public Function Save(ByRef ErrorMessage As String, Optional IsApprovingOrUnapproving As Boolean = False) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim MediaPlanDetailLevelLineDataOrderDetailList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanDetailLevelLineDataOrderDetail) = Nothing
            Dim MediaPlanDetailLevelLineDataOrderDetail As AdvantageFramework.MediaPlanning.Classes.MediaPlanDetailLevelLineDataOrderDetail = Nothing

            _DbContext.Database.Connection.Open()

            _DbContext.ChangeTracker.DetectChanges()

            '_MediaPlan.ModifiedByUserCode = DbContext.UserCode
            '_MediaPlan.ModifiedDate = Now

            '_DbContext.UpdateObject(_MediaPlan)

            Try

                Try

                    MediaPlanDetailLevelLineDataOrderDetailList = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(_DbContext, _MediaPlan.ID).ToList
                                                                   Select New AdvantageFramework.MediaPlanning.Classes.MediaPlanDetailLevelLineDataOrderDetail(Entity)).ToList

                    If (_MediaPlan.SyncDetailSettings AndAlso _MediaPlanEstimate.MediaLevelLinesLocked) OrElse IsApprovingOrUnapproving Then

                        For Each MPE In MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList

                            If MPE IsNot Nothing AndAlso MPE.HasChanged Then

                                Saved = MPE.Save(_DbContext, _MediaPlan, ErrorMessage)

                                If Saved = False Then

                                    Throw New Exception(ErrorMessage)

                                End If

                                If Saved = False Then

                                    Exit For

                                Else

                                    If MPE.MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MPE.MediaPlanDetailLevelLineDatas.Count > 0 Then

                                        For Each MPDLLD In MPE.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.MediaPlanID = _MediaPlan.ID AndAlso Entity.MediaPlanDetailID = MPE.ID).ToList

                                            MediaPlanDetailLevelLineDataOrderDetail = MediaPlanDetailLevelLineDataOrderDetailList.FirstOrDefault(Function(Entity) Entity.MediaPlanDetailLevelLineDataID = MPDLLD.ID)

                                            If MediaPlanDetailLevelLineDataOrderDetail IsNot Nothing AndAlso MPDLLD.OrderLineChanged = False Then

                                                MPDLLD.OrderID = MediaPlanDetailLevelLineDataOrderDetail.OrderID
                                                MPDLLD.OrderLineID = MediaPlanDetailLevelLineDataOrderDetail.OrderLineID
                                                MPDLLD.OrderLineNumber = MediaPlanDetailLevelLineDataOrderDetail.OrderLineNumber
                                                MPDLLD.OrderNumber = MediaPlanDetailLevelLineDataOrderDetail.OrderNumber

                                            End If

                                        Next

                                    End If

                                End If

                            End If

                        Next

                        If Saved Then

                            _MediaPlanEstimate.MediaLevelLinesLocked = False

                        End If

                    Else

                        If Me.MediaPlanEstimate IsNot Nothing AndAlso Me.MediaPlanEstimate.HasChanged Then

                            Saved = Me.MediaPlanEstimate.Save(_DbContext, _MediaPlan, ErrorMessage)

                            If Saved = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            If Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count > 0 Then

                                For Each MPDLLD In Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.MediaPlanID = _MediaPlan.ID AndAlso Entity.MediaPlanDetailID = Me.MediaPlanEstimate.ID).ToList

                                    MediaPlanDetailLevelLineDataOrderDetail = MediaPlanDetailLevelLineDataOrderDetailList.FirstOrDefault(Function(Entity) Entity.MediaPlanDetailLevelLineDataID = MPDLLD.ID)

                                    If MediaPlanDetailLevelLineDataOrderDetail IsNot Nothing AndAlso MPDLLD.OrderLineChanged = False Then

                                        MPDLLD.OrderID = MediaPlanDetailLevelLineDataOrderDetail.OrderID
                                        MPDLLD.OrderLineID = MediaPlanDetailLevelLineDataOrderDetail.OrderLineID
                                        MPDLLD.OrderLineNumber = MediaPlanDetailLevelLineDataOrderDetail.OrderLineNumber
                                        MPDLLD.OrderNumber = MediaPlanDetailLevelLineDataOrderDetail.OrderNumber

                                    End If

                                Next

                            End If

                        End If

                    End If

                    If Saved Then

                        _DbContext.SaveChanges()

                    End If

                Catch ex As Exception

                    Saved = False

                    If TypeOf ex Is System.Data.Entity.Infrastructure.DbUpdateConcurrencyException Then

                        AdvantageFramework.Navigation.ShowMessageBox("Media Plan has failed to save because of order changes by another user.  Close the plan and redo your changes.")

                    Else

                        AdvantageFramework.Navigation.ShowError(ex)

                    End If

                End Try

            Catch ex As Exception
                Saved = False
                AdvantageFramework.Navigation.ShowError(ex)
            End Try

            _DbContext.Database.Connection.Close()

            If Saved Then

                _HasChanged = False

                RaiseEvent SavedMediaPlanEvent()

            End If

            Save = Saved

        End Function
        'Public Function DeleteMediaPlanEstimate(ByVal OrderNumber As Integer) As Boolean

        '	'objects
        '	Dim Deleted As Boolean = False
        '	Dim MediaPlanEstimate As MediaPlanEstimate = Nothing

        '	Try

        '		MediaPlanEstimate = MediaPlanEstimates(OrderNumber)

        '	Catch ex As Exception
        '		MediaPlanEstimate = Nothing
        '	End Try

        '	If MediaPlanEstimate IsNot Nothing Then

        '		Deleted = Me.DeleteMediaPlanEstimate(MediaPlanEstimate)

        '	End If

        '	DeleteMediaPlanEstimate = Deleted

        'End Function
        '      Public Function DeleteMediaPlanEstimate(ByVal MediaPlanEstimate As MediaPlanEstimate) As Boolean

        '	'objects
        '	Dim Deleted As Boolean = False
        '	Dim MediaPlanDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing

        '	Try

        '		MediaPlanDetailsList = _MediaPlan.MediaPlanDetails.ToList

        '		_DbContext.UpdateObject(_MediaPlan)

        '		For Each MediaPlanDetail In MediaPlanDetailsList

        '			If MediaPlanDetail.IsEntityBeingAdded() Then

        '				If _MediaPlan.MediaPlanDetails.Contains(MediaPlanDetail) = False Then

        '					_MediaPlan.MediaPlanDetails.Add(MediaPlanDetail)

        '				End If

        '			End If

        '		Next

        '		If MediaPlanEstimate.Delete(_DbContext, _MediaPlan) Then

        '			'Try

        '			'    _DbContext.SaveChanges()

        '			'Catch ex As Exception

        '			'End Try

        '			MediaPlanEstimates.Remove(MediaPlanEstimate.OrderNumber)

        '			Deleted = True

        '			RefreshOrderNumbers()

        '		End If

        '	Catch ex As Exception
        '		Deleted = False
        '	End Try

        '	DeleteMediaPlanEstimate = Deleted

        'End Function
        Public Function Copy(ByVal OrderNumber As Integer, ByRef NewOrderNumber As Integer, NewSalesClassCode As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim SelectedMediaPlanEstimate As MediaPlanEstimate = Nothing
            Dim NewMediaPlanEstimate As MediaPlanEstimate = Nothing
            Dim NewMediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetailID As Integer = 0
            Dim ErrorMessage As String = ""

            Try

                SelectedMediaPlanEstimate = MediaPlanEstimates(OrderNumber)

            Catch ex As Exception
                SelectedMediaPlanEstimate = Nothing
            End Try

            If SelectedMediaPlanEstimate IsNot Nothing Then

                Copied = AdvantageFramework.MediaPlanning.CopyMediaPlanDetail(_DbContext, Me.ID, SelectedMediaPlanEstimate.ID, NewMediaPlanDetailID, Me.MediaPlanEstimates.Count + 1, NewSalesClassCode)

                If Copied Then

                    Refresh(NewMediaPlanDetailID, True)

                    If Me.MediaPlanEstimates IsNot Nothing AndAlso NewMediaPlanDetailID > 0 Then

                        _MediaPlanEstimate = GetMediaPlanEstimateByMediaPlanDetailID(NewMediaPlanDetailID)

                        If _MediaPlanEstimate IsNot Nothing Then

                            LoadInitialSettings(_MediaPlanEstimate)

                            Try

                                Me.Save(ErrorMessage)

                            Catch ex As Exception

                            End Try

                            If _MediaPlanEstimate.IsDataLoaded = False Then

                                _MediaPlanEstimate.CreateEstimateDataTable()

                            End If

                            NewOrderNumber = _MediaPlanEstimate.OrderNumber

                        End If

                    End If

                End If

            End If

            Copy = Copied

        End Function
        Public Sub RefreshOrderNumbers()

			'objects
			Dim MediaPlanEstimatesList As Generic.List(Of MediaPlanEstimate) = Nothing

			MediaPlanEstimatesList = MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).OrderBy(Function(MPE) MPE.OrderNumber).ToList

			MediaPlanEstimates.Clear()

			For Each MPE In MediaPlanEstimatesList

				MPE.SetOrderNumber(MediaPlanEstimatesList.IndexOf(MPE) + 1)

				MediaPlanEstimates(MPE.OrderNumber) = MPE

			Next

		End Sub
		Public Function AddLevelLineColumn(ByVal Description As String, ByVal TagType As AdvantageFramework.MediaPlanning.TagTypes, ByVal MappingType As AdvantageFramework.MediaPlanning.MappingTypes) As Boolean

			'objects
			Dim ColumnAdded As Boolean = False
			Dim DataColumn As System.Data.DataColumn = Nothing
			Dim OrderNumber As Integer = 0

			Try

				If Me.SyncDetailSettings Then

					For Each MPE In Me.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

						If MPE.IsLevelAndLinesLoaded = False Then

							MPE.CreateLevelsAndLinesDataTable()

						End If

						If MPE.IsLevelAndLinesLoaded Then

							DataColumn = New System.Data.DataColumn(Description)

							DataColumn.DataType = GetType(String)
							DataColumn.DefaultValue = ""
							DataColumn.Caption = DataColumn.ColumnName

							SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

							MPE.LevelsAndLinesDataTable.Columns.Add(DataColumn)

                            OrderNumber = DataColumn.Ordinal - 6

                            SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

						End If

						If MPE.IsDataLoaded Then

							DataColumn = New System.Data.DataColumn(Description)

							DataColumn.DataType = GetType(String)
							DataColumn.DefaultValue = ""
							DataColumn.Caption = DataColumn.ColumnName

							SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

							MPE.EstimateDataTable.Columns.Add(DataColumn)

							SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

						End If

						MPE.RefreshLevelsOrderNumbers()

					Next

				Else

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

						Me.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

					End If

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded Then

						DataColumn = New System.Data.DataColumn(Description)

						DataColumn.DataType = GetType(String)
						DataColumn.DefaultValue = ""
						DataColumn.Caption = DataColumn.ColumnName

						SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

						Me.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.Add(DataColumn)

                        OrderNumber = DataColumn.Ordinal - 6

                        SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

					End If

					If Me.MediaPlanEstimate.IsDataLoaded Then

						DataColumn = New System.Data.DataColumn(Description)

						DataColumn.DataType = GetType(String)
						DataColumn.DefaultValue = ""
						DataColumn.Caption = DataColumn.ColumnName

						SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

						Me.MediaPlanEstimate.EstimateDataTable.Columns.Add(DataColumn)

						SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, OrderNumber, MappingType, True)

					End If

					Me.MediaPlanEstimate.RefreshLevelsOrderNumbers()

				End If

				ColumnAdded = True

			Catch ex As Exception
				ColumnAdded = False
			End Try

			AddLevelLineColumn = ColumnAdded

		End Function
		Public Function UpdateLevelLineColumn(ByVal FieldName As String, ByVal Description As String, ByVal TagType As Integer, ByVal MappingType As Integer) As Boolean

			'objects
			Dim ColumnUpdated As Boolean = False
			Dim DataColumn As System.Data.DataColumn = Nothing
			Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
			Dim IsVisible As Boolean = False

			Try

				If Me.SyncDetailSettings Then

					For Each MPE In Me.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

						If MPE.IsLevelAndLinesLoaded = False Then

							MPE.CreateLevelsAndLinesDataTable()

						End If

						If MPE.IsLevelAndLinesLoaded Then

							Try

								DataColumn = MPE.LevelsAndLinesDataTable.Columns(FieldName)

							Catch ex As Exception
								DataColumn = Nothing
							End Try

							If DataColumn IsNot Nothing Then

								DataColumn.ColumnName = Description
								DataColumn.Caption = DataColumn.ColumnName

								Try

									IsVisible = CBool(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString))

								Catch ex As Exception
									IsVisible = False
								End Try

                                SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, DataColumn.Ordinal - 6, MappingType, IsVisible)

                            End If

						End If

						Try

							MediaPlanDetailLevel = MPE.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = FieldName)

						Catch ex As Exception
							MediaPlanDetailLevel = Nothing
						End Try

						If MediaPlanDetailLevel IsNot Nothing Then

							MediaPlanDetailLevel.Description = Description
							MediaPlanDetailLevel.TagType = TagType
							MediaPlanDetailLevel.MappingType = MappingType

						End If

						If MPE.IsDataLoaded Then

							Try

								DataColumn = MPE.EstimateDataTable.Columns(FieldName)

							Catch ex As Exception
								DataColumn = Nothing
							End Try

							If DataColumn IsNot Nothing Then

								DataColumn.ColumnName = Description
								DataColumn.Caption = DataColumn.ColumnName

								Try

									IsVisible = CBool(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString))

								Catch ex As Exception
									IsVisible = False
								End Try

                                SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, DataColumn.Ordinal - 6, MappingType, IsVisible)

                            End If

						End If

						MPE.RefreshLevelsOrderNumbers()

						MPE.LevelAndLinesDataTableColumnDefinitionChanged()

					Next

				Else

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

						Me.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

					End If

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded Then

						Try

							DataColumn = Me.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(FieldName)

						Catch ex As Exception
							DataColumn = Nothing
						End Try

						If DataColumn IsNot Nothing Then

							DataColumn.ColumnName = Description
							DataColumn.Caption = DataColumn.ColumnName

							Try

								IsVisible = CBool(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString))

							Catch ex As Exception
								IsVisible = False
							End Try

                            SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, DataColumn.Ordinal - 6, MappingType, IsVisible)

                        End If

					End If

					Try

						MediaPlanDetailLevel = Me.MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = FieldName)

					Catch ex As Exception
						MediaPlanDetailLevel = Nothing
					End Try

					If MediaPlanDetailLevel IsNot Nothing Then

						MediaPlanDetailLevel.Description = Description
						MediaPlanDetailLevel.TagType = TagType
						MediaPlanDetailLevel.MappingType = MappingType

					End If

					If Me.MediaPlanEstimate.IsDataLoaded Then

						Try

							DataColumn = Me.MediaPlanEstimate.EstimateDataTable.Columns(FieldName)

						Catch ex As Exception
							DataColumn = Nothing
						End Try

						If DataColumn IsNot Nothing Then

							DataColumn.ColumnName = Description
							DataColumn.Caption = DataColumn.ColumnName

							Try

								IsVisible = CBool(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString))

							Catch ex As Exception
								IsVisible = False
							End Try

                            SetLevelLineColumnProperties(DataColumn, 0, TagType, 100, DataColumn.Ordinal - 6, MappingType, IsVisible)

                        End If

					End If

					Me.MediaPlanEstimate.RefreshLevelsOrderNumbers()

					Me.MediaPlanEstimate.LevelAndLinesDataTableColumnDefinitionChanged()

				End If

				ColumnUpdated = True

			Catch ex As Exception
				ColumnUpdated = False
			End Try

			UpdateLevelLineColumn = ColumnUpdated

		End Function
		Public Function RemoveLevelLineColumn(ByVal FieldName As String) As Boolean

			'objects
			Dim ColumnRemoved As Boolean = False

			Try

				If Me.SyncDetailSettings Then

					For Each MPE In Me.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

						If MPE.IsLevelAndLinesLoaded = False Then

							MPE.CreateLevelsAndLinesDataTable()

						End If

						If MPE.IsLevelAndLinesLoaded Then

							MPE.LevelsAndLinesDataTable.Columns.Remove(FieldName)

						End If

						If MPE.IsDataLoaded Then

							MPE.EstimateDataTable.Columns.Remove(FieldName)

						End If

						MPE.RefreshLevelsOrderNumbers()

					Next

				Else

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

						Me.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

					End If

					If Me.MediaPlanEstimate.IsLevelAndLinesLoaded Then

						Me.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.Remove(FieldName)

					End If

					If Me.MediaPlanEstimate.IsDataLoaded Then

						Me.MediaPlanEstimate.EstimateDataTable.Columns.Remove(FieldName)

					End If

					Me.MediaPlanEstimate.RefreshLevelsOrderNumbers()

				End If

				ColumnRemoved = True

			Catch ex As Exception
				ColumnRemoved = False
			End Try

			RemoveLevelLineColumn = ColumnRemoved

		End Function
		Public Sub ApproveAllEstimates(ByVal EmployeeCode As String)

			For Each MPE In MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList

				If Not MPE.IsApproved Then

					MPE.SetApproval(True, EmployeeCode)

				End If

			Next

		End Sub
		Public Sub UnapproveAllEstimates()

			For Each MPE In MediaPlanEstimates.Values.OfType(Of MediaPlanEstimate).ToList

				If MPE.IsApproved Then

					MPE.SetApproval(False, Nothing)

				End If

			Next

		End Sub
		Public Function ApproveMediaPlanEstimate(ByVal OrderNumber As Integer, ByVal EmployeeCode As String) As Boolean

			'objects
			Dim Approved As Boolean = False
			Dim MediaPlanEstimate As MediaPlanEstimate = Nothing

			Try

				MediaPlanEstimate = MediaPlanEstimates(OrderNumber)

			Catch ex As Exception
				MediaPlanEstimate = Nothing
			End Try

			If MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.IsApproved = False Then

				MediaPlanEstimate.SetApproval(True, EmployeeCode)

				Approved = True

			End If

			ApproveMediaPlanEstimate = Approved

		End Function
		Public Function UnapproveMediaPlanEstimate(ByVal OrderNumber As Integer) As Boolean

			'objects
			Dim Unapproved As Boolean = False
			Dim MediaPlanEstimate As MediaPlanEstimate = Nothing

			Try

				MediaPlanEstimate = MediaPlanEstimates(OrderNumber)

			Catch ex As Exception
				MediaPlanEstimate = Nothing
			End Try

			If MediaPlanEstimate IsNot Nothing Then

				MediaPlanEstimate.SetApproval(False, Nothing)

				Unapproved = True

			End If

			UnapproveMediaPlanEstimate = Unapproved

		End Function
		Public Sub Refresh(SelectEstimateID As Integer, IsCopyingEstimate As Boolean)

			'objects
			Dim MediaPlanEstimate As MediaPlanEstimate = Nothing
			Dim MediaPlanID As Integer = 0

			MediaPlanID = _MediaPlan.ID

			RefreshDbContext()

			Try

                _MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.Load(_DbContext).Include("MediaPlanDetails") _
                                                                                              .Include("MediaPlanDetails.SalesClass") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevels") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLines") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLines.MediaPlanDetailLevel") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevels.MediaPlanDetailLevelLines") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLineDatas") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailFields") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailLevelLineTags") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailSettings") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailChangeLogs") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackageDetails") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackageDetails.AdSize") _
                                                                                              .Include("MediaPlanDetails.MediaPlanDetailPackagePlacementNames").SingleOrDefault(Function(Entity) Entity.ID = MediaPlanID)

            Catch ex As Exception
				_MediaPlan = Nothing
			End Try

			_DbContext.TryAttach(_MediaPlan)

			Try

				_Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, _MediaPlan.ClientCode, _MediaPlan.DivisionCode, _MediaPlan.ProductCode)

			Catch ex As Exception
				_Product = Nothing
			End Try

			Try

				MediaPlanEstimates = New Hashtable

				For Each MediaPlanDetail In _MediaPlan.MediaPlanDetails.OrderBy(Function(Entity) Entity.OrderNumber).ToList

					MediaPlanEstimate = New MediaPlanEstimate(Me, MediaPlanDetail, _BroadcastCalendarWeeks)

					AddHandler MediaPlanEstimate.EstimateChangedEvent, AddressOf EstimateChangedEvent

					MediaPlanEstimates(MediaPlanEstimate.OrderNumber) = MediaPlanEstimate

				Next

			Catch ex As Exception
				MediaPlanEstimates = Nothing
			End Try

			If MediaPlanEstimates IsNot Nothing AndAlso SelectEstimateID > 0 AndAlso IsCopyingEstimate = False Then

				Me.SelectMediaPlanEstimateByMediaPlanDetailID(SelectEstimateID)

			End If

		End Sub
        Public Function GetCDPDescription() As String

            'objects
            Dim CDPDescription As String = String.Empty

            If _Product IsNot Nothing Then

                CDPDescription = _Product.Client.Name

                If _Product.ClientCode <> _Product.DivisionCode AndAlso _Product.ClientCode <> _Product.Code Then

                    CDPDescription &= " (" & _Product.DivisionCode & "/" & _Product.Code & ")"

                ElseIf _Product.ClientCode = _Product.DivisionCode AndAlso _Product.ClientCode <> _Product.Code Then

                    CDPDescription &= " (" & _Product.Code & ")"

                ElseIf _Product.ClientCode <> _Product.DivisionCode AndAlso _Product.ClientCode = _Product.Code Then

                    CDPDescription &= " (" & _Product.DivisionCode & ")"

                End If

            End If

            GetCDPDescription = CDPDescription

        End Function
        Public Function IsAttachedToBroadcastWorksheet() As Boolean

            Dim IsAttached As Boolean = False

            If (Me.MediaPlanEstimate.SalesClassType = "T" OrElse Me.MediaPlanEstimate.SalesClassType = "R") Then

                Me.DbContext.Database.Connection.Open()

                If AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.Load(Me.DbContext).Where(Function(Entity) Entity.MediaPlanID = Me.ID).Any Then

                    IsAttachedToBroadcastWorksheet = True

                End If

                Me.DbContext.Database.Connection.Close()

            End If

            IsAttachedToBroadcastWorksheet = IsAttached

        End Function
        Public Function HasPendingOrders() As Boolean

            Dim HasOrders As Boolean = False

            If Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count > 0 Then

                Me.DbContext.Database.Connection.Open()

                Try

                    HasPendingOrders = Me.DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_media_planning_has_pending_orders] '{0}'", Join(Me.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) CStr(Entity.ID)).ToArray, ","))).FirstOrDefault

                Catch ex As Exception

                End Try

                Me.DbContext.Database.Connection.Close()

            End If

            HasPendingOrders = HasOrders

        End Function

#End Region

    End Class

End Namespace

