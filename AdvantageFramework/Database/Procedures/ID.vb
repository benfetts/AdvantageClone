Namespace Database.Procedures.ID

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ID)

            Load = From ID In DbContext.GetQuery(Of Database.Entities.ID)
                   Select ID

        End Function
        Public Function GetNextTransaction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TableName As String) As Integer

            Dim CurrentNumber As Integer = 0

            CurrentNumber = (From Entity In Load(DbContext) _
                             Where Entity.TableName = TableName
                             Select Entity.Transaction).Max + 1

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IDS set IDSXACT = {0} WHERE IDSTABLE='{1}'", CurrentNumber, TableName))

            GetNextTransaction = CurrentNumber

        End Function

#End Region

    End Module

End Namespace
