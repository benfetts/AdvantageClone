Namespace Database.Procedures.ChecklistHeader

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

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ChecklistHeader)

            LoadByAlertID = From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistHeader)
                            Where Entity.AlertID = AlertID
                            Select Entity

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ChecklistHeader

            LoadByID = (From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistHeader)
                        Where Entity.ID = ID
                        Select Entity).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ChecklistHeader)

            Load = (From Entity In DbContext.GetQuery(Of Database.Entities.ChecklistHeader)
                    Select Entity)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ChecklistHeaders.Add(ChecklistHeader)

                ErrorText = ChecklistHeader.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ChecklistHeader)

                ErrorText = ChecklistHeader.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    AdvantageFramework.Database.Procedures.ChecklistDetail.DeleteAllByChecklistID(DbContext, ChecklistHeader.ID)

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ChecklistHeader)

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

