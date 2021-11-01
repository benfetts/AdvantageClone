Namespace Database.Procedures.ChecklistDetail

    <HideModuleName()>
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

        Public Function LoadByChecklistID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ChecklistDetail)

            LoadByChecklistID = From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistDetail)
                                Where Entity.ChecklistID = ChecklistID
                                Select Entity

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ChecklistDetail

            LoadByID = (From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistDetail)
                        Where Entity.ID = ID
                        Select Entity).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ChecklistDetail)

            Load = (From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistDetail)
                    Select Entity)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ChecklistDetails.Add(ChecklistDetail)

                ErrorText = ChecklistDetail.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ChecklistDetail)

                ErrorText = ChecklistDetail.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function DeleteAllByChecklistID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistID As Integer) As Boolean

            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CHECKLIST_DTL WHERE CHECKLIST_HDR_ID = {0};", ChecklistID))
                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteAllByChecklistID = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ChecklistDetail)

                    DbContext.SaveChanges()

                    Deleted = True

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

