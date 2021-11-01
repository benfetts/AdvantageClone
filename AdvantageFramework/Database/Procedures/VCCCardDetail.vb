Namespace Database.Procedures.VCCCardDetail

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

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VCCCardDetail)

            LoadByID = DbContext.Set(Of AdvantageFramework.Database.Entities.VCCCardDetail)().Where(Function(Entity) Entity.ID = ID)

        End Function
        Public Function LoadByIDAndReferenceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer, ByVal ReferenceNumber As String) As AdvantageFramework.Database.Entities.VCCCardDetail

            LoadByIDAndReferenceNumber = DbContext.Set(Of AdvantageFramework.Database.Entities.VCCCardDetail)().Where(Function(Entity) Entity.ID = ID AndAlso Entity.ReferenceNumber = ReferenceNumber).FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VCCCardDetail)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.VCCCardDetail)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.VCCCardDetails.Add(VCCCardDetail)

                ErrorMessage = VCCCardDetail.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        VCCCardDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.VCCCardDetail.Load(DbContext)
                                                        Where Entity.ID = VCCCardDetail.ID
                                                        Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        VCCCardDetail.SequenceNumber = 1
                    End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(VCCCardDetail).State = Entity.EntityState.Modified

                ErrorMessage = VCCCardDetail.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
