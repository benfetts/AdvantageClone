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

        Private Function GetRadioMarkets(NielsenDbContext As NielsenFramework.Database.NielsenDbContext, MarketNumbers As IEnumerable(Of Integer), Ethnicity As Nullable(Of Short)) As Generic.List(Of NielsenFramework.DTO.NielsenMarket)

            'objects
            Dim SqlParameterExcludeMarkets As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEthnicity As System.Data.SqlClient.SqlParameter = Nothing
            Dim NielsenMarketList As Generic.List(Of NielsenFramework.DTO.NielsenMarket) = Nothing

            SqlParameterExcludeMarkets = New SqlClient.SqlParameter("@ExcludeMarkets", SqlDbType.VarChar)
            SqlParameterEthnicity = New SqlClient.SqlParameter("@Ethnicity", SqlDbType.SmallInt)

            If MarketNumbers IsNot Nothing Then

                SqlParameterExcludeMarkets.Value = String.Join(",", MarketNumbers)

            Else

                SqlParameterExcludeMarkets.Value = System.DBNull.Value

            End If

            If Ethnicity.HasValue Then

                SqlParameterEthnicity.Value = Ethnicity.Value

            Else

                SqlParameterEthnicity.Value = System.DBNull.Value

            End If

            NielsenMarketList = NielsenDbContext.Database.SqlQuery(Of NielsenFramework.DTO.NielsenMarket)("EXEC dbo.advsp_nielsen_radio_markets @ExcludeMarkets, @Ethnicity", SqlParameterExcludeMarkets, SqlParameterEthnicity).ToList

            GetRadioMarkets = NielsenMarketList

        End Function

#Region " Public "

        Public Sub New(ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Public Function Add(ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                            ByRef ClientOrderID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientOrder As NielsenFramework.Database.Entities.ClientOrder = Nothing
            Dim ClientOrderMarket As NielsenFramework.Database.Entities.ClientOrderMarket = Nothing
            Dim ClientOrderState As NielsenFramework.Database.Entities.ClientOrderState = Nothing
            Dim IsValid As Boolean = True

            ClientOrder = New NielsenFramework.Database.Entities.ClientOrder

            ClientOrderDetailViewModel.ClientOrder.SaveToEntity(ClientOrder)

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                For Each ClientOrderMarketDTO In ClientOrderDetailViewModel.ClientOrderMarkets

                    ClientOrderMarket = New NielsenFramework.Database.Entities.ClientOrderMarket

                    ClientOrderMarketDTO.SaveToEntity(ClientOrderMarket)
                    ClientOrderMarket.DbContext = NielsenDbContext

                    ErrorMessage = ClientOrderMarket.ValidateEntity(IsValid)

                    ClientOrder.ClientOrderMarkets.Add(ClientOrderMarket)

                Next

                For Each ClientOrderStateDTO In ClientOrderDetailViewModel.ClientOrderStates

                    ClientOrderState = New NielsenFramework.Database.Entities.ClientOrderState

                    ClientOrderStateDTO.SaveToEntity(ClientOrderState)
                    ClientOrderState.DbContext = NielsenDbContext

                    ErrorMessage = ClientOrderState.ValidateEntity(IsValid)

                    ClientOrder.ClientOrderStates.Add(ClientOrderState)

                Next

                ClientOrder.DbContext = NielsenDbContext

                ErrorMessage = ClientOrder.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        NielsenDbContext.ClientOrders.Add(ClientOrder)

                        NielsenDbContext.SaveChanges()

                        Added = True

                        ClientOrderID = ClientOrder.ID

                    Catch ex As Exception
                        ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                    End Try

                End If

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                Deleted = NielsenFramework.Database.Procedures.ClientOrder.Delete(NielsenDbContext, ClientOrderDetailViewModel.ClientOrder.ID, ErrorMessage)

            End Using

            Delete = Deleted

        End Function
        Public Sub DeleteSelectedMarkets(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel)

            If ClientOrderDetailViewModel.SelectedClientOrderMarket IsNot Nothing Then

                ClientOrderDetailViewModel.ClientOrderMarkets.Remove(ClientOrderDetailViewModel.SelectedClientOrderMarket)

            End If

        End Sub
        Public Sub DeleteSelectedStates(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel)

            If ClientOrderDetailViewModel.SelectedClientOrderState IsNot Nothing Then

                ClientOrderDetailViewModel.ClientOrderStates.Remove(ClientOrderDetailViewModel.SelectedClientOrderState)

            End If

        End Sub
        Public Function GetAvailableMarkets(OrderType As String, ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                            Optional RadioEthnicity As Nullable(Of Short) = Nothing) As Generic.List(Of NielsenFramework.DTO.NielsenMarket)

            'objects
            Dim NielsenMarkets As Generic.List(Of NielsenFramework.DTO.NielsenMarket) = Nothing
            Dim MarketNumbers As IEnumerable(Of Integer) = Nothing

            NielsenMarkets = New Generic.List(Of NielsenFramework.DTO.NielsenMarket)

            MarketNumbers = (From Entity In ClientOrderDetailViewModel.ClientOrderMarkets
                             Select Entity.MarketNumber).ToArray

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                If OrderType = "T" Then

                    NielsenMarkets.AddRange(From Entity In NielsenFramework.Database.Procedures.NielsenMarket.LoadAllSpotTVMarketsExcludingMarketNumbers(NielsenDbContext, MarketNumbers).ToList
                                            Select New NielsenFramework.DTO.NielsenMarket(CInt(Entity.NielsenTVCode), Entity.Description))

                ElseIf OrderType = "R" Then

                    NielsenMarkets = GetRadioMarkets(NielsenDbContext, MarketNumbers, RadioEthnicity.Value)

                End If

            End Using

            GetAvailableMarkets = NielsenMarkets

        End Function
        Public Function GetAvailableStates(OrderType As String,
                                           ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel) As Generic.List(Of NielsenFramework.DTO.State)

            'objects
            Dim AvailableStates As Generic.List(Of NielsenFramework.DTO.State) = Nothing
            Dim States As IEnumerable(Of String) = Nothing

            AvailableStates = New Generic.List(Of NielsenFramework.DTO.State)

            States = (From Entity In ClientOrderDetailViewModel.ClientOrderStates
                      Select Entity.State).ToArray

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                AvailableStates.AddRange(From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(NielsenFramework.Database.Entities.States))
                                         Where States.Contains(Entity.Code) = False
                                         Select New NielsenFramework.DTO.State(Entity.Code, Entity.Description))

            End Using

            GetAvailableStates = AvailableStates

        End Function
        Public Function Load(ClientID As Integer, OrderType As String, ClientOrderID As Integer) As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel

            'objects
            Dim ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel = Nothing
            Dim SelectedMarketNumbers As IEnumerable(Of Integer) = Nothing

            ClientOrderDetailViewModel = New NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                If OrderType = "T" Then

                    ClientOrderDetailViewModel.RepositoryAvailableMarkets.AddRange(From Entity In NielsenFramework.Database.Procedures.NielsenMarket.LoadAllSpotTVMarkets(NielsenDbContext).ToList
                                                                                   Select New NielsenFramework.DTO.NielsenMarket(CInt(Entity.NielsenTVCode), Entity.Description))

                ElseIf OrderType = "R" Then

                    ClientOrderDetailViewModel.RepositoryAvailableMarkets = GetRadioMarkets(NielsenDbContext, Nothing, Nothing)

                ElseIf OrderType = "C" Then

                    ClientOrderDetailViewModel.RepositoryAvailableStates = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(NielsenFramework.Database.Entities.States))
                                                                            Select New NielsenFramework.DTO.State(Entity.Code, Entity.Description)).ToList

                End If

                If ClientOrderID <> 0 Then

                    ClientOrderDetailViewModel.ClientOrder = New NielsenFramework.DTO.ClientOrder(NielsenFramework.Database.Procedures.ClientOrder.LoadByID(NielsenDbContext, ClientOrderID))

                    ClientOrderDetailViewModel.ClientOrderMarkets = (From Entity In NielsenFramework.Database.Procedures.ClientOrderMarket.LoadByClientOrderID(NielsenDbContext, ClientOrderID).ToList
                                                                     Select New NielsenFramework.DTO.ClientOrderMarket(Entity)).ToList

                    ClientOrderDetailViewModel.ClientOrderStates = (From Entity In NielsenFramework.Database.Procedures.ClientOrderState.LoadByClientOrderID(NielsenDbContext, ClientOrderID).ToList
                                                                    Select New NielsenFramework.DTO.ClientOrderState(Entity)).ToList

                Else

                    ClientOrderDetailViewModel.ClientOrder = New NielsenFramework.DTO.ClientOrder(OrderType)

                    ClientOrderDetailViewModel.ClientOrderMarkets = New Generic.List(Of NielsenFramework.DTO.ClientOrderMarket)

                    ClientOrderDetailViewModel.ClientOrderStates = New Generic.List(Of NielsenFramework.DTO.ClientOrderState)

                End If

            End Using

            Load = ClientOrderDetailViewModel

        End Function
        Public Function ClientOrderMarketValidateEntity(ClientOrderMarketDTO As NielsenFramework.DTO.ClientOrderMarket, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim ClientOrderMarket As NielsenFramework.Database.Entities.ClientOrderMarket = Nothing

            Using NielsenDbContext As New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ClientOrderMarket = New NielsenFramework.Database.Entities.ClientOrderMarket

                ClientOrderMarketDTO.SaveToEntity(ClientOrderMarket)

                ClientOrderMarket.DbContext = NielsenDbContext

                ErrorText = ClientOrderMarket.ValidateEntity(IsValid)

                ClientOrderMarketDTO.SetEntityError(ErrorText)

            End Using

            ClientOrderMarketValidateEntity = ErrorText

        End Function
        Public Function ClientOrderStateValidateEntity(ClientOrderMarketDTO As NielsenFramework.DTO.ClientOrderState, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim ClientOrderState As NielsenFramework.Database.Entities.ClientOrderState = Nothing

            Using NielsenDbContext As New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ClientOrderState = New NielsenFramework.Database.Entities.ClientOrderState

                ClientOrderMarketDTO.SaveToEntity(ClientOrderState)

                ClientOrderState.DbContext = NielsenDbContext

                ErrorText = ClientOrderState.ValidateEntity(IsValid)

                ClientOrderMarketDTO.SetEntityError(ErrorText)

            End Using

            ClientOrderStateValidateEntity = ErrorText

        End Function
        Public Sub DeleteSelectedClientOrderMarket(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel)

            ClientOrderDetailViewModel.ClientOrderMarkets.Remove(ClientOrderDetailViewModel.SelectedClientOrderMarket)
            ClientOrderDetailViewModel.SelectedClientOrderMarket = Nothing

        End Sub
        Public Sub SetAllMarketsChecked(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                        Checked As Boolean)

            ClientOrderDetailViewModel.ClientOrder.AllMarkets = Checked

            If Checked Then

                ClientOrderDetailViewModel.ClientOrderMarkets.Clear()

            Else

                ClientOrderDetailViewModel.ClientOrder.Cume = False

            End If

        End Sub
        Public Sub SetAllMarketsCumeChecked(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                            Checked As Boolean)

            ClientOrderDetailViewModel.ClientOrder.Cume = Checked

        End Sub
        Public Sub SetAllStatesChecked(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                       Checked As Boolean)

            ClientOrderDetailViewModel.ClientOrder.AllStates = Checked

            If Checked Then

                ClientOrderDetailViewModel.ClientOrderStates.Clear()

            End If

        End Sub
        Public Sub SetIsSuspendedChecked(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                         Checked As Boolean)

            ClientOrderDetailViewModel.ClientOrder.IsSuspended = Checked

        End Sub
        Public Sub MarketSelectionChanged(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                          IsNewItemRow As Boolean, SelectedClientOrderMarket As NielsenFramework.DTO.ClientOrderMarket)

            ClientOrderDetailViewModel.SelectedClientOrderMarket = SelectedClientOrderMarket

            ClientOrderDetailViewModel.MarketIsNewRow = IsNewItemRow
            ClientOrderDetailViewModel.MarketCancelEnabled = IsNewItemRow
            ClientOrderDetailViewModel.MarketDeleteEnabled = Not IsNewItemRow AndAlso SelectedClientOrderMarket IsNot Nothing

        End Sub
        Public Sub StateSelectionChanged(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                         IsNewItemRow As Boolean, SelectedClientOrderState As NielsenFramework.DTO.ClientOrderState)

            ClientOrderDetailViewModel.SelectedClientOrderState = SelectedClientOrderState

            ClientOrderDetailViewModel.StateIsNewRow = IsNewItemRow
            ClientOrderDetailViewModel.StateCancelEnabled = IsNewItemRow
            ClientOrderDetailViewModel.StateDeleteEnabled = Not IsNewItemRow AndAlso SelectedClientOrderState IsNot Nothing

        End Sub
        Public Function Update(ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim ClientOrder As NielsenFramework.Database.Entities.ClientOrder = Nothing
            Dim ClientOrderMarket As NielsenFramework.Database.Entities.ClientOrderMarket = Nothing
            Dim ClientOrderMarketIDs As Generic.List(Of Integer) = Nothing
            Dim IsValid As Boolean = True
            Dim ClientOrderState As NielsenFramework.Database.Entities.ClientOrderState = Nothing
            Dim ClientOrderStateIDs As Generic.List(Of Integer) = Nothing

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ClientOrder = NielsenFramework.Database.Procedures.ClientOrder.LoadByID(NielsenDbContext, ClientOrderDetailViewModel.ClientOrder.ID)

                If ClientOrder IsNot Nothing Then

                    ClientOrderDetailViewModel.ClientOrder.SaveToEntity(ClientOrder)

                    ClientOrderMarketIDs = (From Entity In NielsenFramework.Database.Procedures.ClientOrderMarket.LoadByClientOrderID(NielsenDbContext, ClientOrder.ID)
                                            Select Entity.ID).ToList

                    For Each ClientOrderMarketDTO In ClientOrderDetailViewModel.ClientOrderMarkets

                        If ClientOrderMarketDTO.ClientOrderID = 0 Then

                            ClientOrderMarket = New NielsenFramework.Database.Entities.ClientOrderMarket

                            ClientOrderMarketDTO.SaveToEntity(ClientOrderMarket)

                            ClientOrderMarket.ClientOrderID = ClientOrder.ID
                            ClientOrderMarket.DbContext = NielsenDbContext

                            ClientOrder.ClientOrderMarkets.Add(ClientOrderMarket)

                            NielsenDbContext.Entry(ClientOrderMarket).State = Entity.EntityState.Added

                        Else

                            ClientOrderMarket = ClientOrder.ClientOrderMarkets.Where(Function(CO) CO.ID = ClientOrderMarketDTO.ID).FirstOrDefault

                            If ClientOrderMarket IsNot Nothing Then

                                ClientOrderMarketIDs.Remove(ClientOrderMarket.ID)

                                ClientOrderMarketDTO.SaveToEntity(ClientOrderMarket)

                                NielsenDbContext.Entry(ClientOrderMarket).State = Entity.EntityState.Modified

                            End If

                        End If

                    Next

                    For Each ClientOrderMarketID In ClientOrderMarketIDs

                        NielsenDbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CLIENT_ORDER_MARKET WHERE CLIENT_ORDER_MARKET_ID = {0}", ClientOrderMarketID))

                    Next

                    ClientOrderStateIDs = (From Entity In NielsenFramework.Database.Procedures.ClientOrderState.LoadByClientOrderID(NielsenDbContext, ClientOrder.ID)
                                           Select Entity.ID).ToList

                    For Each ClientOrderStateDTO In ClientOrderDetailViewModel.ClientOrderStates

                        If ClientOrderStateDTO.ClientOrderID = 0 Then

                            ClientOrderState = New NielsenFramework.Database.Entities.ClientOrderState

                            ClientOrderStateDTO.SaveToEntity(ClientOrderState)

                            ClientOrderState.ClientOrderID = ClientOrder.ID
                            ClientOrderState.DbContext = NielsenDbContext

                            ClientOrder.ClientOrderStates.Add(ClientOrderState)

                            NielsenDbContext.Entry(ClientOrderState).State = Entity.EntityState.Added

                        Else

                            ClientOrderState = ClientOrder.ClientOrderStates.Where(Function(CO) CO.ID = ClientOrderStateDTO.ID).FirstOrDefault

                            If ClientOrderState IsNot Nothing Then

                                ClientOrderStateIDs.Remove(ClientOrderState.ID)

                                ClientOrderStateDTO.SaveToEntity(ClientOrderState)

                                NielsenDbContext.Entry(ClientOrderState).State = Entity.EntityState.Modified

                            End If

                        End If

                    Next

                    For Each ClientOrderStateID In ClientOrderStateIDs

                        NielsenDbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CLIENT_ORDER_STATE WHERE CLIENT_ORDER_STATE_ID = {0}", ClientOrderStateID))

                    Next

                    ClientOrder.DbContext = NielsenDbContext

                    ErrorMessage = ClientOrder.ValidateEntity(IsValid)

                    If IsValid Then

                        Try

                            NielsenDbContext.Entry(ClientOrder).State = Entity.EntityState.Modified

                            NielsenDbContext.SaveChanges()

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
        Public Function ValidateProperty(ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                         ClientOrderMarket As NielsenFramework.DTO.ClientOrderMarket, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyValue As Object = Nothing

            Select Case FieldName

                'Case NielsenFramework.DTO.ClientOrderMarket.Properties.MarketNumber.ToString

                '    PropertyValue = Value

                '    If PropertyValue Is Nothing OrElse PropertyValue = 0 Then

                '        IsValid = False

                '        ErrorText = "Share book is invalid."

                '    ElseIf (From Entity In ShareHPUTBookViewModel.ShareHPUTBooks
                '            Where Entity.ShareBookID.GetValueOrDefault(0) = DirectCast(PropertyValue, Nullable(Of Integer)).GetValueOrDefault(0) AndAlso
                '                  Entity.HPUTBookID.GetValueOrDefault(0) = ShareHPUTBook.HPUTBookID.GetValueOrDefault(0) AndAlso
                '                  Entity.ID <> ShareHPUTBook.ID
                '            Select Entity.ID).Any Then

                '        IsValid = False

                '        If ShareHPUTBook.HPUTBookID.HasValue Then

                '            ErrorText = "Duplicate share h/put book."

                '        Else

                '            ErrorText = "Duplicate share book."

                '        End If

                '    End If

            End Select

            ClientOrderMarket.SetPropertyError(FieldName, ErrorText)

            ValidateProperty = ErrorText

        End Function
        Public Sub SetRadioEthnicity(ByRef ClientOrderDetailViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel,
                                     Ethnicity As Short)

            ClientOrderDetailViewModel.ClientOrder.Ethnicity = Ethnicity

            ClientOrderDetailViewModel.ClientOrderMarkets.Clear()

        End Sub
#End Region

#End Region

    End Class

End Namespace
