Namespace Database.Procedures.VCCCardPODetail

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

        Public Function LoadByVCCCardPOID(DbContext As AdvantageFramework.Database.DbContext, VCCCardPOID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VCCCardPODetail)

            LoadByVCCCardPOID = DbContext.Set(Of AdvantageFramework.Database.Entities.VCCCardPODetail)().Where(Function(Entity) Entity.VCCCardPOID = VCCCardPOID)

        End Function
        Public Function Load(DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VCCCardPODetail)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.VCCCardPODetail)()

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.VCCCardPODetails.Add(VCCCardPODetail)

                ErrorMessage = VCCCardPODetail.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
