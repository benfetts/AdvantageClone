Namespace Database.Procedures.ImportAccountPayableBroadcastDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayableBroadcastDetail)

            Load = From ImportAccountPayableBroadcastDetail In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableBroadcastDetail)
                   Select ImportAccountPayableBroadcastDetail

        End Function

#End Region

    End Module

End Namespace
