Namespace Database.MasterTable.Procedures.Table

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function Load(DataContext As Database.MasterDatabase.DataContext) As IQueryable(Of Database.MasterDatabase.Entities.Table)

            Load = From Table In DataContext.Tables
                   Select Table

        End Function

#End Region

    End Module

End Namespace
