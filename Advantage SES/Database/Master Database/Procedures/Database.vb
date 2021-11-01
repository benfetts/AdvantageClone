Namespace Database.MasterDatabase.Procedures.Database

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function Load(DataContext As DataContext) As IQueryable(Of Entities.Database)

            Load = From Database In DataContext.Databases
                   Select Database

        End Function

#End Region

    End Module

End Namespace
