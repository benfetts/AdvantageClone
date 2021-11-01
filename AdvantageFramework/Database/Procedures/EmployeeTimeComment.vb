Namespace Database.Procedures.EmployeeTimeComment

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

        Public Function LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndSequenceNumberAndEmployeeTimeSource(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer,
                                                                                                          ByVal EmployeeTimeDetailID As Short, ByVal SequenceNumber As Short, ByVal EmployeeTimeSource As String) As Database.Entities.EmployeeTimeComment

            Try

                LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndSequenceNumberAndEmployeeTimeSource = (From Entity In DbContext.GetQuery(Of Database.Entities.EmployeeTimeComment)
                                                                                                     Where Entity.EmployeeTimeID = EmployeeTimeID AndAlso
                                                                                                           Entity.EmployeeTimeDetailID = EmployeeTimeDetailID AndAlso
                                                                                                           Entity.SequenceNumber = SequenceNumber AndAlso
                                                                                                           Entity.EmployeeTimeSource = EmployeeTimeSource
                                                                                                     Select Entity).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndSequenceNumberAndEmployeeTimeSource = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndEmployeeTimeSource(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer,
                                                                                                          ByVal EmployeeTimeDetailID As Short, ByVal EmployeeTimeSource As String) As Database.Entities.EmployeeTimeComment

            Try

                LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndEmployeeTimeSource = (From Entity In DbContext.GetQuery(Of Database.Entities.EmployeeTimeComment)
                                                                                    Where Entity.EmployeeTimeID = EmployeeTimeID And
                                                                                                           Entity.EmployeeTimeDetailID = EmployeeTimeDetailID And
                                                                                                           Entity.EmployeeTimeSource = EmployeeTimeSource
                                                                                    Select Entity).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndEmployeeTimeSource = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeComment)

            LoadByEmployeeTimeID = From EmployeeTimeComment In DbContext.GetQuery(Of Database.Entities.EmployeeTimeComment)
                                   Where EmployeeTimeComment.EmployeeTimeID = EmployeeTimeID
                                   Select EmployeeTimeComment

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeComment)

            Load = From EmployeeTimeComment In DbContext.GetQuery(Of Database.Entities.EmployeeTimeComment)
                   Select EmployeeTimeComment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeComment As Database.Entities.EmployeeTimeComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeComments.Add(EmployeeTimeComment)

                ErrorText = EmployeeTimeComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal Source As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_TIME_DTL_CMTS] WHERE [ET_ID] = {0} AND [ET_DTL_ID] = {1} AND [ET_SOURCE] = '{2}'", EmployeeTimeID, EmployeeTimeDetailID, Source))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeComment)

                ErrorText = EmployeeTimeComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeComment)

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
