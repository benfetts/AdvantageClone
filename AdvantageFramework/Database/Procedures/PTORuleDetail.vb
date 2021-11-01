Namespace Database.Procedures.PTORuleDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PTORuleDetail)

            Load = From PTORuleDetail In DbContext.GetQuery(Of Database.Entities.PTORuleDetail)
                   Select PTORuleDetail

        End Function
        Public Function LoadByPTORuleID(ByVal DbContext As Database.DbContext, ByVal PTORuleID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PTORuleDetail)

            LoadByPTORuleID = From PTORuleDetail In DbContext.GetQuery(Of Database.Entities.PTORuleDetail)
                              Where PTORuleDetail.PTORuleID = PTORuleID
                              Select PTORuleDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORuleDetail As AdvantageFramework.Database.Entities.PTORuleDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PTORuleDetails.Add(PTORuleDetail)

                ErrorText = PTORuleDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORuleDetail As AdvantageFramework.Database.Entities.PTORuleDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PTORuleDetail)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORuleDetail As AdvantageFramework.Database.Entities.PTORuleDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PTORuleDetail)

                ErrorText = PTORuleDetail.ValidateEntity(IsValid)

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
#End Region

    End Module

End Namespace
