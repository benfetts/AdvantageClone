Namespace Database.Procedures.CollectedCostInformation

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

        Public Function LoadByOrderNumberLineNumberRevisionNumberIsQuote(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                         OrderNumber As Integer, LineNumber As Short, RevisionNumber As Short, IsQuote As Boolean) As AdvantageFramework.Database.Entities.CollectedCostInformation

            LoadByOrderNumberLineNumberRevisionNumberIsQuote = (From Entity In DbContext.GetQuery(Of Database.Entities.CollectedCostInformation)
                                                                Where Entity.OrderNumber = OrderNumber AndAlso
                                                                      Entity.LineNumber = LineNumber AndAlso
                                                                      Entity.RevisionNumber = RevisionNumber AndAlso
                                                                      Entity.IsQuote = IsQuote
                                                                Select Entity).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.CollectedCostInformation)

            Load = DbContext.GetQuery(Of Database.Entities.CollectedCostInformation)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.CollectedCostInformations.Add(CollectedCostInformation)

                ErrorMessage = CollectedCostInformation.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(CollectedCostInformation).State = Entity.EntityState.Modified

                ErrorMessage = CollectedCostInformation.ValidateEntity(IsValid)

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
