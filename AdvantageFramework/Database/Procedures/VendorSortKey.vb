Namespace Database.Procedures.VendorSortKey

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

        Public Function LoadByVendorCodeAndSortKey(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCode As String, ByVal SortKey As String) As AdvantageFramework.Database.Entities.VendorSortKey

            Try

                LoadByVendorCodeAndSortKey = (From VendorSortKey In DbContext.GetQuery(Of Database.Entities.VendorSortKey)
                                              Where VendorSortKey.VendorCode = VendorCode AndAlso
                                                    VendorSortKey.SortKey = SortKey
                                              Select VendorSortKey).SingleOrDefault

            Catch ex As Exception
                LoadByVendorCodeAndSortKey = Nothing
            End Try

        End Function
        Public Function LoadByVendorCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorSortKey)

            LoadByVendorCode = From VendorSortKey In DbContext.GetQuery(Of Database.Entities.VendorSortKey)
                               Where VendorSortKey.VendorCode = VendorCode
                               Select VendorSortKey

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorSortKey)

            Load = From VendorSortKey In DbContext.GetQuery(Of Database.Entities.VendorSortKey)
                   Select VendorSortKey

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                ByVal VendorCode As String, ByVal SortKey As String, _
                                ByRef VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                VendorSortKey = New AdvantageFramework.Database.Entities.VendorSortKey

                VendorSortKey.DbContext = DbContext
                VendorSortKey.VendorCode = VendorCode
                VendorSortKey.SortKey = SortKey

                Inserted = Insert(DbContext, VendorSortKey)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorSortKeys.Add(VendorSortKey)

                ErrorText = VendorSortKey.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.VendorSortKeys.Any(Function(VendSortKey) VendSortKey.VendorCode = VendorSortKey.VendorCode AndAlso _
                                                                            VendSortKey.SortKey = VendorSortKey.SortKey) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique vendor sort key.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(VendorSortKey)

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
