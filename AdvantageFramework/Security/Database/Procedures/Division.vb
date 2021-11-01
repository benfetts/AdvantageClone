Namespace Security.Database.Procedures.Division

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

        Public Function LoadByClientAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As Security.Database.Entities.Division

            Try

                LoadByClientAndDivisionCode = (From Division In DbContext.GetQuery(Of Database.Entities.Division)
                                               Where Division.ClientCode = ClientCode AndAlso
                                                     Division.Code = DivisionCode
                                               Select Division).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Division)

            LoadAllActive = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                            Where Division.IsActive = 1
                            Select Division

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Division)

            Load = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                   Select Division

        End Function

#End Region

    End Module

End Namespace
