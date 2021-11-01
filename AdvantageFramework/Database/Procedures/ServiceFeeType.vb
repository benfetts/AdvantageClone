Namespace Database.Procedures.ServiceFeeType

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

        Public Function LoadByServiceFeeTypeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeTypeCode As String) As AdvantageFramework.Database.Entities.ServiceFeeType

            Try

                LoadByServiceFeeTypeCode = (From ServiceFeeType In DbContext.GetQuery(Of Database.Entities.ServiceFeeType)
                                            Where ServiceFeeType.Code = ServiceFeeTypeCode
                                            Select ServiceFeeType).SingleOrDefault

            Catch ex As Exception
                LoadByServiceFeeTypeCode = Nothing
            End Try

        End Function
        Public Function LoadByServiceFeeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeTypeID As Integer) As AdvantageFramework.Database.Entities.ServiceFeeType

            Try

                LoadByServiceFeeID = (From ServiceFeeType In DbContext.GetQuery(Of Database.Entities.ServiceFeeType)
                                      Where ServiceFeeType.ID = ServiceFeeTypeID
                                      Select ServiceFeeType).SingleOrDefault

            Catch ex As Exception
                LoadByServiceFeeID = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ServiceFeeType)

            LoadAllActive = From ServiceFeeType In DbContext.GetQuery(Of Database.Entities.ServiceFeeType)
                            Where ServiceFeeType.IsInactive = 0
                            Select ServiceFeeType

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ServiceFeeType)

            Load = From ServiceFeeType In DbContext.GetQuery(Of Database.Entities.ServiceFeeType)
                   Select ServiceFeeType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeTypes.Add(ServiceFeeType)

                ErrorText = ServiceFeeType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeType)

                ErrorText = ServiceFeeType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext).Any(Function(DepartmentTeam) DepartmentTeam.ServiceFeeTypeCode = ServiceFeeType.Code) Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                ElseIf AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Any(Function(Entity) Entity.ServiceFeeTypeID = ServiceFeeType.ID) Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                ElseIf AdvantageFramework.Database.Procedures.ContractFee.Load(DbContext).Any(Function(Entity) Entity.ServiceFeeTypeID = ServiceFeeType.ID) Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeType)

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
