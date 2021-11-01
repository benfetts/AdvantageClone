Namespace Controller.Maintenance

    Public Class ClientOrderController

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
        Public Function Add(ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                            ByRef ClientOrderID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientOrder As NationalFramework.Database.Entities.ClientOrder = Nothing
            Dim ClientOrderDetail As NationalFramework.Database.Entities.ClientOrderDetail = Nothing
            Dim IsValid As Boolean = True

            ClientOrder = New NationalFramework.Database.Entities.ClientOrder

            ClientOrderDetailViewModel.ClientOrder.SaveToEntity(ClientOrder)

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                For Each ClientOrderDetailDTO In ClientOrderDetailViewModel.ClientOrderDetails

                    ClientOrderDetail = New NationalFramework.Database.Entities.ClientOrderDetail

                    ClientOrderDetailDTO.SaveToEntity(ClientOrderDetail)
                    ClientOrderDetail.DbContext = DbContext

                    ErrorMessage = ClientOrderDetail.ValidateEntity(IsValid)

                    ClientOrder.ClientOrderDetails.Add(ClientOrderDetail)

                Next

                ClientOrder.DbContext = DbContext

                ErrorMessage = ClientOrder.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        DbContext.ClientOrders.Add(ClientOrder)

                        DbContext.SaveChanges()

                        Added = True

                        ClientOrderID = ClientOrder.ID

                    Catch ex As Exception
                        ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                    End Try

                End If

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                Deleted = NationalFramework.Database.Procedures.ClientOrder.Delete(DbContext, ClientOrderDetailViewModel.ClientOrder.ID, ErrorMessage)

            End Using

            Delete = Deleted

        End Function
        'Public Sub DeleteSelectedDetails(ByRef ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel)

        '    If ClientOrderDetailViewModel.SelectedClientOrderDetail IsNot Nothing Then

        '        ClientOrderDetailViewModel.ClientOrderDetails.Remove(ClientOrderDetailViewModel.SelectedClientOrderDetail)

        '    End If

        'End Sub
        Public Function Load(ClientID As Integer, ClientOrderID As Integer) As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel

            'objects
            Dim ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel = Nothing
            Dim ClientOrderDetail As NationalFramework.DTO.ClientOrderDetail = Nothing

            ClientOrderDetailViewModel = New NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                If ClientOrderID <> 0 Then

                    ClientOrderDetailViewModel.ClientOrder = New NationalFramework.DTO.ClientOrder(NationalFramework.Database.Procedures.ClientOrder.LoadByID(DbContext, ClientOrderID))
                    ClientOrderDetailViewModel.ClientOrderDetails.AddRange((From Entity In NationalFramework.Database.Procedures.ClientOrderDetail.LoadByClientOrderID(DbContext, ClientOrderID).ToList
                                                                            Select New NationalFramework.DTO.ClientOrderDetail(Entity)))

                Else

                    ClientOrderDetailViewModel.ClientOrder = New NationalFramework.DTO.ClientOrder()

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NTI", "P", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NSS", "P", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NHI", "P", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NTI", "C", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NSS", "C", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NHI", "C", False)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NTIH", "P", True)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    'ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NSSH", "P", True)
                    'ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NHIH", "P", True)
                    ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    'ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NTIH", "C", True)
                    'ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    'ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NSSH", "C", True)
                    'ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                    'ClientOrderDetail = New NationalFramework.DTO.ClientOrderDetail("NHIH", "C", True)
                    'ClientOrderDetailViewModel.ClientOrderDetails.Add(ClientOrderDetail)

                End If

            End Using

            Load = ClientOrderDetailViewModel

        End Function
        'Public Function ClientOrderDetailValidateEntity(ClientOrderDetailDTO As NationalFramework.DTO.ClientOrderDetail, ByRef IsValid As Boolean) As String

        '    'objects
        '    Dim ErrorText As String = Nothing
        '    Dim ClientOrderDetail As NationalFramework.Database.Entities.ClientOrderDetail = Nothing

        '    Using DbContext As New NationalFramework.Database.DbContext(_ConnectionString)

        '        ClientOrderDetail = New NationalFramework.Database.Entities.ClientOrderDetail

        '        ClientOrderDetailDTO.SaveToEntity(ClientOrderDetail)

        '        ClientOrderDetail.DbContext = DbContext

        '        ErrorText = ClientOrderDetail.ValidateEntity(IsValid)

        '        ClientOrderDetailDTO.SetEntityError(ErrorText)

        '    End Using

        '    ClientOrderDetailValidateEntity = ErrorText

        'End Function
        'Public Sub DeleteSelectedClientOrderDetail(ByRef ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel)

        '    ClientOrderDetailViewModel.ClientOrderDetails.Remove(ClientOrderDetailViewModel.SelectedClientOrderDetail)
        '    ClientOrderDetailViewModel.SelectedClientOrderDetail = Nothing

        'End Sub
        Public Sub SetIsSuspendedChecked(ByRef ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                         Checked As Boolean)

            ClientOrderDetailViewModel.ClientOrder.IsSuspended = Checked

        End Sub
        'Public Sub DetailSelectionChanged(ByRef ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
        '                                  IsNewItemRow As Boolean, SelectedClientOrderDetail As NationalFramework.DTO.ClientOrderDetail)

        '    ClientOrderDetailViewModel.SelectedClientOrderDetail = SelectedClientOrderDetail

        '    ClientOrderDetailViewModel.DetailIsNewRow = IsNewItemRow
        '    ClientOrderDetailViewModel.DetailCancelEnabled = IsNewItemRow
        '    ClientOrderDetailViewModel.DetailDeleteEnabled = Not IsNewItemRow AndAlso SelectedClientOrderDetail IsNot Nothing

        'End Sub
        Public Function Update(ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim ClientOrder As NationalFramework.Database.Entities.ClientOrder = Nothing
            Dim ClientOrderDetail As NationalFramework.Database.Entities.ClientOrderDetail = Nothing
            Dim ClientOrderDetailIDs As Generic.List(Of Integer) = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                ClientOrder = NationalFramework.Database.Procedures.ClientOrder.LoadByID(DbContext, ClientOrderDetailViewModel.ClientOrder.ID)

                If ClientOrder IsNot Nothing Then

                    ClientOrderDetailViewModel.ClientOrder.SaveToEntity(ClientOrder)

                    ClientOrderDetailIDs = (From Entity In NationalFramework.Database.Procedures.ClientOrderDetail.LoadByClientOrderID(DbContext, ClientOrder.ID)
                                            Select Entity.ID).ToList

                    For Each ClientOrderDetailDTO In ClientOrderDetailViewModel.ClientOrderDetails

                        If ClientOrderDetailDTO.ClientOrderID = 0 Then

                            ClientOrderDetail = New NationalFramework.Database.Entities.ClientOrderDetail

                            ClientOrderDetailDTO.SaveToEntity(ClientOrderDetail)

                            ClientOrderDetail.ClientOrderID = ClientOrder.ID
                            ClientOrderDetail.DbContext = DbContext

                            ClientOrder.ClientOrderDetails.Add(ClientOrderDetail)

                            DbContext.Entry(ClientOrderDetail).State = Entity.EntityState.Added

                        Else

                            ClientOrderDetail = ClientOrder.ClientOrderDetails.Where(Function(CO) CO.ID = ClientOrderDetailDTO.ID).FirstOrDefault

                            If ClientOrderDetail IsNot Nothing Then

                                ClientOrderDetailIDs.Remove(ClientOrderDetail.ID)

                                ClientOrderDetailDTO.SaveToEntity(ClientOrderDetail)

                                DbContext.Entry(ClientOrderDetail).State = Entity.EntityState.Modified

                            End If

                        End If

                    Next

                    For Each ClientOrderDetailID In ClientOrderDetailIDs

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CLIENT_ORDER_Detail WHERE CLIENT_ORDER_Detail_ID = {0}", ClientOrderDetailID))

                    Next

                    ClientOrder.DbContext = DbContext

                    ErrorMessage = ClientOrder.ValidateEntity(IsValid)

                    If IsValid Then

                        Try

                            DbContext.Entry(ClientOrder).State = Entity.EntityState.Modified

                            DbContext.SaveChanges()

                            Updated = True

                        Catch ex As Exception
                            ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                        End Try

                    End If

                Else

                    ErrorMessage = "The client order could not be found."

                End If

            End Using

            Update = Updated

        End Function
        'Public Function ValidateProperty(ClientOrderDetailViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
        '                                 ClientOrderDetail As NationalFramework.DTO.ClientOrderDetail, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    'objects
        '    Dim ErrorText As String = String.Empty
        '    Dim PropertyValue As Object = Nothing

        '    Select Case FieldName

        '        'Case NationalFramework.DTO.ClientOrderDetail.Properties.DetailNumber.ToString

        '        '    PropertyValue = Value

        '        '    If PropertyValue Is Nothing OrElse PropertyValue = 0 Then

        '        '        IsValid = False

        '        '        ErrorText = "Share book is invalid."

        '        '    ElseIf (From Entity In ShareHPUTBookViewModel.ShareHPUTBooks
        '        '            Where Entity.ShareBookID.GetValueOrDefault(0) = DirectCast(PropertyValue, Nullable(Of Integer)).GetValueOrDefault(0) AndAlso
        '        '                  Entity.HPUTBookID.GetValueOrDefault(0) = ShareHPUTBook.HPUTBookID.GetValueOrDefault(0) AndAlso
        '        '                  Entity.ID <> ShareHPUTBook.ID
        '        '            Select Entity.ID).Any Then

        '        '        IsValid = False

        '        '        If ShareHPUTBook.HPUTBookID.HasValue Then

        '        '            ErrorText = "Duplicate share h/put book."

        '        '        Else

        '        '            ErrorText = "Duplicate share book."

        '        '        End If

        '        '    End If

        '    End Select

        '    ClientOrderDetail.SetPropertyError(FieldName, ErrorText)

        '    ValidateProperty = ErrorText

        'End Function

#End Region

#End Region

    End Class

End Namespace
