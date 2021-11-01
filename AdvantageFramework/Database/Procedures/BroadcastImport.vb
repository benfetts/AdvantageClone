Namespace Database.Procedures.BroadcastImport

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

        Public Function LoadByLinkIDAndMediaTypeAndMediaInterface(ByVal DataContext As Database.DataContext, ByVal LinkID As Long, _
                                                                  ByVal MediaType As String, ByVal MediaInterface As String) As Database.Entities.BroadcastImport

			Try

				LoadByLinkIDAndMediaTypeAndMediaInterface = (From BroadcastImport In DataContext.BroadcastImports
															 Where BroadcastImport.LinkID = LinkID AndAlso
																   BroadcastImport.MediaType = MediaType AndAlso
																   BroadcastImport.MediaInterface = MediaInterface
															 Select BroadcastImport).FirstOrDefault

			Catch ex As Exception
				LoadByLinkIDAndMediaTypeAndMediaInterface = Nothing
			End Try

		End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.BroadcastImport)

            Load = From BroadcastImport In DataContext.BroadcastImports
                   Select BroadcastImport

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal BroadcastImport As AdvantageFramework.Database.Entities.BroadcastImport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                BroadcastImport.DataContext = DataContext

                Try

                    BroadcastImport.ID = (From Entity In Load(DataContext) _
                                          Select Entity.ID).Max + 1

                Catch ex As Exception
                    BroadcastImport.ID = 1
                End Try

                BroadcastImport.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.BroadcastImports.InsertOnSubmit(BroadcastImport)

                ErrorText = BroadcastImport.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal BroadcastImport As AdvantageFramework.Database.Entities.BroadcastImport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                BroadcastImport.DataContext = DataContext
                BroadcastImport.DbContext = DbContext

                BroadcastImport.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = BroadcastImport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal BroadcastImport As AdvantageFramework.Database.Entities.BroadcastImport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.BroadcastImports.DeleteOnSubmit(BroadcastImport)

                    DataContext.SubmitChanges()

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

