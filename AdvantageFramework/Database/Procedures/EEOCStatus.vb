Namespace Database.Procedures.EEOCStatus

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.EEOCStatus)

            Load = From EEOCStatus In DataContext.EEOCStatuses
                   Select EEOCStatus

        End Function
        Public Function LoadByVendorCode(ByVal DataContext As Database.DataContext, ByVal VendorCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.EEOCStatus)

            LoadByVendorCode = From EEOCStatus In DataContext.EEOCStatuses
                               Where EEOCStatus.VendorCode = VendorCode
                               Select EEOCStatus

        End Function
        Public Function LoadByVendorAndEEOCCode(ByVal DataContext As Database.DataContext, ByVal VendorCode As String, ByVal EEOCCode As String) As AdvantageFramework.Database.Entities.EEOCStatus

            Try

                LoadByVendorAndEEOCCode = (From EEOCStatus In DataContext.EEOCStatuses _
                                           Where EEOCStatus.VendorCode = VendorCode AndAlso _
                                                 EEOCStatus.EEOCCode = EEOCCode _
                                           Select EEOCStatus).SingleOrDefault

            Catch ex As Exception
                LoadByVendorAndEEOCCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EEOCStatus As AdvantageFramework.Database.Entities.EEOCStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                EEOCStatus.DataContext = DataContext

                EEOCStatus.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                ErrorText = EEOCStatus.ValidateEntity(IsValid)

                If IsValid Then

                    ErrorText = DataContext.ExecuteCommand(String.Format("INSERT INTO dbo.EEOC_STATUS ([VENDOR], [EEOC_CODE]) VALUES ('{0}', '{1}')", EEOCStatus.VendorCode, EEOCStatus.EEOCCode))

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EEOCStatus As AdvantageFramework.Database.Entities.EEOCStatus) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ErrorText = DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.EEOC_STATUS WHERE [VENDOR] = '{0}' AND [EEOC_CODE] = '{1}'", EEOCStatus.VendorCode, EEOCStatus.EEOCCode))

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