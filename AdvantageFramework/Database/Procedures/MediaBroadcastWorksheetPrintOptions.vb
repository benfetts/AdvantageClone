Namespace Database.Procedures.MediaBroadcastWorksheetPrintOptions

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

        Public Function LoadByUserCode(DbContext As Database.DbContext, UserCode As String) As Database.Entities.MediaBroadcastWorksheetPrintOptions

            LoadByUserCode = (From MediaBroadcastWorksheetPrintOptions In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetPrintOptions)
                              Where MediaBroadcastWorksheetPrintOptions.UserCode = UserCode
                              Select MediaBroadcastWorksheetPrintOptions).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetPrintOptions)

            Load = From MediaBroadcastWorksheetPrintOptions In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetPrintOptions)
                   Select MediaBroadcastWorksheetPrintOptions

        End Function

#End Region

    End Module

End Namespace
