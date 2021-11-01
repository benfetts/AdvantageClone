Namespace Controller

    Public Class LicenseKeyController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Public Function Load(ClientCode As String) As NielsenFramework.ViewModels.LicenseKeyViewModel

            'objects
            Dim LicenseKeyViewModel As NielsenFramework.ViewModels.LicenseKeyViewModel = Nothing

            LicenseKeyViewModel = New NielsenFramework.ViewModels.LicenseKeyViewModel

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                LicenseKeyViewModel.LicenseKeys = NielsenDbContext.Database.SqlQuery(Of NielsenFramework.DTO.LicenseKey)(String.Format("exec advsp_get_license_keys_by_clientcode '{0}'", ClientCode)).ToList

            End Using

            Load = LicenseKeyViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
