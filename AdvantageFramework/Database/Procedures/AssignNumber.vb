Namespace Database.Procedures.AssignNumber

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AssignNumber)

            Load = From AssignNumber In DbContext.GetQuery(Of Database.Entities.AssignNumber)
                   Select AssignNumber

        End Function
        Public Function GetNextNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ColumnName As String) As Integer

            Dim CurrentNumber As Integer = 0

            CurrentNumber = (From Entity In Load(DbContext) _
                             Where Entity.ColumnName = ColumnName
                             Select Entity.LastNumber).Max + 1

            SetNextNumber(DbContext, ColumnName, CurrentNumber)
            
            GetNextNumber = CurrentNumber

        End Function
        Public Function GetNextNumber(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal ColumnName As String) As Integer

            Dim CurrentNumber As Integer = 0

            CurrentNumber = BCCDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(COALESCE(LAST_NBR,0)) + 1 FROM dbo.ASSIGN_NBR WHERE COLUMNNAME='{0}'", ColumnName)).FirstOrDefault

            SetNextNumber(BCCDbContext, ColumnName, CurrentNumber)

            GetNextNumber = CurrentNumber

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AssignNumber As AdvantageFramework.Database.Entities.AssignNumber) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AssignNumber)

                ErrorText = AssignNumber.ValidateEntity(IsValid)

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
        Public Sub SetNextNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ColumnName As String, ByVal LastNumber As Integer)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ASSIGN_NBR set LAST_NBR = {0} WHERE COLUMNNAME='{1}'", LastNumber, ColumnName))

            Catch ex As Exception

            End Try

        End Sub
        Public Sub SetNextNumber(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal ColumnName As String, ByVal LastNumber As Integer)

            Try

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ASSIGN_NBR set LAST_NBR = {0} WHERE COLUMNNAME='{1}'", LastNumber, ColumnName))

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace
