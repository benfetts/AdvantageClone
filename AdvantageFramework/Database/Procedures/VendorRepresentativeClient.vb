Namespace Database.Procedures.VendorRepresentativeClient

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.VendorRepresentativeClient)

            Load = From VendorRepresentativeClient In DataContext.VendorRepresentativeClients
                   Select VendorRepresentativeClient

        End Function
        Public Function LoadByVendorRepAndVendorCode(ByVal DataContext As Database.DataContext, ByVal VendorRepCode As String, ByVal VendorCode As String) As IQueryable(Of Database.Entities.VendorRepresentativeClient)

            LoadByVendorRepAndVendorCode = From VendorRepresentativeClient In DataContext.VendorRepresentativeClients
                                           Where VendorRepresentativeClient.VendorRepCode = VendorRepCode AndAlso
                                                 VendorRepresentativeClient.VendorCode = VendorCode
                                           Select VendorRepresentativeClient

        End Function
        Public Function LoadByVendorRepVendorAndClientCode(ByVal DataContext As Database.DataContext, ByVal VendorRepCode As String, ByVal VendorCode As String, ByVal ClientCode As String) As Database.Entities.VendorRepresentativeClient

            Try

                LoadByVendorRepVendorAndClientCode = (From VendorRepresentativeClient In DataContext.VendorRepresentativeClients _
                                                      Where VendorRepresentativeClient.VendorRepCode = VendorRepCode AndAlso _
                                                            VendorRepresentativeClient.VendorCode = VendorCode AndAlso _
                                                            VendorRepresentativeClient.ClientCode = ClientCode _
                                                      Select VendorRepresentativeClient).SingleOrDefault

            Catch ex As Exception
                LoadByVendorRepVendorAndClientCode = Nothing
            End Try


        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorRepresentativeClient.DataContext = DataContext

                VendorRepresentativeClient.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.VendorRepresentativeClients.InsertOnSubmit(VendorRepresentativeClient)

                ErrorText = VendorRepresentativeClient.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorRepresentativeClient.DataContext = DataContext

                VendorRepresentativeClient.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = VendorRepresentativeClient.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.VendorRepresentativeClients.DeleteOnSubmit(VendorRepresentativeClient)

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