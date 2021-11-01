Namespace Database.Procedures.IRS1099FederalStateCode

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.IRS1099FederalStateCode)

            Load = DbContext.GetQuery(Of Database.Entities.IRS1099FederalStateCode)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.IRS1099FederalStateCodes.Add(IRS1099FederalStateCode)

                ErrorMessage = IRS1099FederalStateCode.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(IRS1099FederalStateCode).State = Entity.EntityState.Modified

                ErrorMessage = IRS1099FederalStateCode.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode, ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Entry(IRS1099FederalStateCode).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception

                Deleted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
