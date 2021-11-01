Namespace Database.Procedures.ImportCashReceipt

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportCashReceipt)

            Load = From ImportCashReceipt In DataContext.ImportCashReceipts
                   Select ImportCashReceipt

        End Function
        Public Function LoadByBatchName(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BatchName As String) As IQueryable(Of AdvantageFramework.Database.Entities.ImportCashReceipt)

            LoadByBatchName = From ImportCashReceipt In DataContext.ImportCashReceipts
                              Where ImportCashReceipt.BatchName = BatchName
                              Select ImportCashReceipt

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ImportCashReceipt

            Try

                LoadByID = (From ImportCashReceipt In DataContext.ImportCashReceipts _
                            Where ImportCashReceipt.ID = ID _
                            Select ImportCashReceipt).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try
            
        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportCashReceipt.DataContext = DataContext

                ImportCashReceipt.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportCashReceipts.InsertOnSubmit(ImportCashReceipt)

                ErrorText = ImportCashReceipt.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportCashReceipt.DataContext = DataContext

                ImportCashReceipt.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ImportCashReceipt.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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

#End Region

    End Module

End Namespace