Namespace Database.Procedures.MediaPlan

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Function LoadByMediaPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer) As AdvantageFramework.Database.Entities.MediaPlan

			Try

				LoadByMediaPlanID = (From MediaPlan In DbContext.GetQuery(Of Database.Entities.MediaPlan)
									 Where MediaPlan.ID = MediaPlanID
									 Select MediaPlan).SingleOrDefault

			Catch ex As Exception
				LoadByMediaPlanID = Nothing
			End Try

		End Function
		Public Function LoadAllActive(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlan)

			LoadAllActive = From MediaPlan In DbContext.GetQuery(Of Database.Entities.MediaPlan)
							Where MediaPlan.IsInactive = False
							Select MediaPlan

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlan)

            Load = From MediaPlan In DbContext.GetQuery(Of Database.Entities.MediaPlan)
                   Select MediaPlan

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlans.Add(MediaPlan)

                ErrorText = MediaPlan.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlan.CreatedByUserCode = DbContext.UserCode
                    MediaPlan.CreatedDate = Now

                    DbContext.MediaPlans.Add(MediaPlan)

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlan)

                ErrorText = MediaPlan.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlan.ModifiedByUserCode = DbContext.UserCode
                    MediaPlan.ModifiedDate = Now

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.DeleteByMediaPlanID(DbContext, MediaPlan.ID) Then

                        DbContext.DeleteEntityObject(MediaPlan)

                        DbContext.SaveChanges()

                        Deleted = True

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
