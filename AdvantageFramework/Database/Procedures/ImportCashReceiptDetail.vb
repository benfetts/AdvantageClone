Namespace Database.Procedures.ImportCashReceiptDetail

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail)

            Load = From ImportCashReceiptDetail In DataContext.ImportCashReceiptDetails
                   Select ImportCashReceiptDetail

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ImportCashReceiptDetail

            Try

                LoadByID = (From ImportCashReceiptDetail In DataContext.ImportCashReceiptDetails _
                            Where ImportCashReceiptDetail.ID = ID
                            Select ImportCashReceiptDetail).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportCashReceiptDetail.DataContext = DataContext

                ImportCashReceiptDetail.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportCashReceiptDetails.InsertOnSubmit(ImportCashReceiptDetail)

                ErrorText = ImportCashReceiptDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportCashReceiptDetail.DataContext = DataContext

                ImportCashReceiptDetail.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ImportCashReceiptDetail.ValidateEntity(IsValid)

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