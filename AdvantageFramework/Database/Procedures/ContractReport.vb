Namespace Database.Procedures.ContractReport

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

        Public Function LoadByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractReport)

            LoadByContractID = From ContractReport In DbContext.GetQuery(Of Database.Entities.ContractReport)
                               Where ContractReport.ContractID = ContractID
                               Select ContractReport

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ContractReport

            Try

                LoadByID = (From ContractReport In DbContext.GetQuery(Of Database.Entities.ContractReport)
                            Where ContractReport.ID = ID
                            Select ContractReport).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractReport)

            Load = From ContractReport In DbContext.GetQuery(Of Database.Entities.ContractReport)
                   Select ContractReport

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContractReports.Add(ContractReport)

                ErrorText = ContractReport.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ContractReport)

                ErrorText = ContractReport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ContractReportDocuments As IEnumerable(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing

            Try

                If IsValid Then

                    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                        ContractReportDocuments = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadByContractReportID(DataContext, ContractReport.ID)

                        AdvantageFramework.Database.Procedures.ContractReportDocument.Delete(DataContext, ContractReportDocuments)

                    End Using

                    DbContext.DeleteEntityObject(ContractReport)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
