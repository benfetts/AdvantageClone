Namespace Database.MasterDatabase.Procedures.Column

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function LoadByObjectID(DataContext As DataContext, ObjectID As Long) As IQueryable(Of Entities.Column)

            LoadByObjectID = From Column In DataContext.Columns
                             Where Column.ObjectID = ObjectID
                             Select Column

        End Function
        Public Function Load(DataContext As DataContext) As IQueryable(Of Entities.Column)

            Load = From Column In DataContext.Columns
                   Select Column

        End Function

#End Region

    End Module

End Namespace
