Namespace Maintenance.Media.Presentation

    Public Class MediaMarketSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim SubItemGridLookUpEditControlCountry As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Markets = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList

                For Each Market In Markets

                    If Market.IsInactive Is Nothing Then

                        Market.IsInactive = 0

                    End If

                Next

                DataGridViewForm_Market.DataSource = Markets

            End Using

            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.Code.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.Description.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenTVCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenTVDMACode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenBlackRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenHispanicRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.IsCable.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanBlackRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanHispanicRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.ComscoreMarketNumber.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.ComscoreNewMarketNumber.ToString)
            DataGridViewForm_Market.MakeColumnNotVisible(AdvantageFramework.Database.Entities.Market.Properties.IsPuertoRico.ToString)

            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.Code.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.Description.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.IsPuertoRico.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenTVCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenTVDMACode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenBlackRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.NielsenHispanicRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanBlackRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.EastlanHispanicRadioCode.ToString)
            DataGridViewForm_Market.MakeColumnVisible(AdvantageFramework.Database.Entities.Market.Properties.ComscoreNewMarketNumber.ToString)

            If DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString) IsNot Nothing AndAlso
                    TypeOf DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString).ColumnEdit IsNot AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "ID"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                BindingSource = New System.Windows.Forms.BindingSource

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BindingSource.DataSource = DbContext.States.ToList.Select(Function(Entity) New With {.ID = Entity.ID, .Name = Entity.StateName}).ToList

                End Using

                SubItemGridLookUpEditControl.DataSource = BindingSource

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Name", "ID", "[None]", Nothing, True, False, Nothing)

                DataGridViewForm_Market.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString).ColumnEdit = SubItemGridLookUpEditControl

                AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControlQueryPopUp

            End If

            If DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString) IsNot Nothing AndAlso
                    TypeOf DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString).ColumnEdit IsNot AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                SubItemGridLookUpEditControlCountry = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControlCountry.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControlCountry.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControlCountry.NullText = ""
                SubItemGridLookUpEditControlCountry.DisplayMember = "Name"
                SubItemGridLookUpEditControlCountry.ValueMember = "ID"

                SubItemGridLookUpEditControlCountry.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                SubItemGridLookUpEditControlCountry.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                BindingSource = New System.Windows.Forms.BindingSource

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BindingSource.DataSource = DbContext.Countries.ToList.Select(Function(Entity) New With {.ID = Entity.ID, .Name = Entity.Name}).ToList

                End Using

                SubItemGridLookUpEditControlCountry.DataSource = BindingSource

                'AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Name", "ID", "[None]", Nothing, True, False, Nothing)

                DataGridViewForm_Market.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControlCountry)

                DataGridViewForm_Market.Columns(AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString).ColumnEdit = SubItemGridLookUpEditControlCountry

            End If

            DataGridViewForm_Market.CurrentView.RefreshData()
            DataGridViewForm_Market.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Market.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

                ButtonItemMarkets_AddUpdate.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Market.HasASelectedRow

                ButtonItemMarkets_AddUpdate.Enabled = (Not Me.UserEntryChanged)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MarketSetupForm As Presentation.MediaMarketSetupForm = Nothing

            MarketSetupForm = New Presentation.MediaMarketSetupForm()

            MarketSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MarketSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemMarkets_AddUpdate.Image = AdvantageFramework.My.Resources.ProcessImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = (From Country In DbContext.Countries
                                            Where Country.ID <> DTO.Countries.PuertoRico
                                            Select [Name] = Country.Name,
                                                   [ID] = Country.ID).ToList

            End Using

            LoadGrid()

        End Sub
        Private Sub MarketSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub MarketSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub MediaMarketSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_Market.CurrentView.RefreshData()

            DataGridViewForm_Market.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Market.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing

            If DataGridViewForm_Market.HasRows Then

                DataGridViewForm_Market.CurrentView.CloseEditorForUpdating()

                Markets = DataGridViewForm_Market.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Market)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Market In Markets

                            AdvantageFramework.Database.Procedures.Market.Update(DbContext, Market)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_Market.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                DataGridViewForm_Market.CurrentView.RefreshData()

                DataGridViewForm_Market.CurrentView.AFActiveFilterString = ""

                DataGridViewForm_Market.CurrentView.RefreshData()

                DataGridViewForm_Market.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Market.HasASelectedRow Then

                DataGridViewForm_Market.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Market.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    Market = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Market = Nothing
                                End Try

                                If Market IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Market.Delete(DbContext, Market) Then

                                        DataGridViewForm_Market.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Market '" & Market.Description & "' is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Market.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Market.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMarkets_AddUpdate_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_AddUpdate.Click

            Dim NielsenMarketList As Generic.List(Of AdvantageFramework.Database.Entities.NielsenMarket) = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = ""
            Dim MarketList As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim NielsenMarket As AdvantageFramework.Database.Entities.NielsenMarket = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Adding codes will update and overwrite data for codes that match.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm", MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    NielsenMarketList = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.NielsenMarket).ToList

                    Try

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        Me.ShowWaitForm()

                        For Each NielsenMarket In NielsenMarketList

                            Market = (From Entity In DbContext.GetQuery(Of Database.Entities.Market)
                                      Where Entity.Code.ToUpper = NielsenMarket.Code.ToUpper
                                      Select Entity).SingleOrDefault

                            If Market IsNot Nothing Then

                                Market.Description = NielsenMarket.Description
                                Market.NielsenTVCode = NielsenMarket.NielsenTVCode
                                Market.NielsenTVDMACode = NielsenMarket.NielsenTVDMACode

                                If Market.IsCable Then

                                    Market.NielsenRadioCode = Nothing
                                    Market.NielsenBlackRadioCode = Nothing
                                    Market.NielsenHispanicRadioCode = Nothing

                                Else

                                    Market.NielsenRadioCode = NielsenMarket.NielsenRadioCode
                                    Market.NielsenBlackRadioCode = NielsenMarket.NielsenBlackRadioCode
                                    Market.NielsenHispanicRadioCode = NielsenMarket.NielsenHispanicRadioCode

                                End If

                                If AdvantageFramework.Database.Procedures.Market.Update(DbContext, Market, ErrorMessage) = False Then

                                    Throw New Exception(ErrorMessage)

                                End If

                            Else

                                Markets = (From Entity In DbContext.GetQuery(Of Database.Entities.Market)
                                           Where Entity.Description.ToUpper = NielsenMarket.Description.ToUpper
                                           Select Entity).ToList

                                If Markets IsNot Nothing AndAlso Markets.Count > 0 Then

                                    For Each Market In Markets

                                        Market.NielsenTVCode = NielsenMarket.NielsenTVCode
                                        Market.NielsenTVDMACode = NielsenMarket.NielsenTVDMACode

                                        If Market.IsCable Then

                                            Market.NielsenRadioCode = Nothing
                                            Market.NielsenBlackRadioCode = Nothing
                                            Market.NielsenHispanicRadioCode = Nothing

                                        Else

                                            Market.NielsenRadioCode = NielsenMarket.NielsenRadioCode
                                            Market.NielsenBlackRadioCode = NielsenMarket.NielsenBlackRadioCode
                                            Market.NielsenHispanicRadioCode = NielsenMarket.NielsenHispanicRadioCode

                                        End If

                                        If AdvantageFramework.Database.Procedures.Market.Update(DbContext, Market, ErrorMessage) = False Then

                                            Throw New Exception(ErrorMessage)

                                        End If

                                        Exit For 'only match the first one!

                                    Next

                                Else

                                    Market = New AdvantageFramework.Database.Entities.Market
                                    Market.DbContext = DbContext

                                    Market.Code = NielsenMarket.Code
                                    Market.Description = NielsenMarket.Description
                                    Market.NielsenTVCode = NielsenMarket.NielsenTVCode
                                    Market.NielsenTVDMACode = NielsenMarket.NielsenTVDMACode
                                    Market.NielsenRadioCode = NielsenMarket.NielsenRadioCode
                                    Market.NielsenBlackRadioCode = NielsenMarket.NielsenBlackRadioCode
                                    Market.NielsenHispanicRadioCode = NielsenMarket.NielsenHispanicRadioCode
                                    Market.CountryID = AdvantageFramework.DTO.Countries.UnitedStates

                                    If AdvantageFramework.Database.Procedures.Market.Insert(DbContext, Market, ErrorMessage) = False Then

                                        Throw New Exception(ErrorMessage)

                                    End If

                                End If

                            End If

                        Next

                        DbContext.Database.ExecuteSqlCommand("UPDATE MARKET SET COMSCORE_MARKET_NUMBER = NIELSEN_TV_CODE + 400 WHERE NULLIF(NIELSEN_TV_CODE,'') IS NOT NULL")
                        DbContext.Database.ExecuteSqlCommand("exec dbo.advsp_comscore_update_new_market_number")

                        DbTransaction.Commit()

                        MarketList = (From Entity In AdvantageFramework.Database.Procedures.Market.Load(DbContext)
                                      Where Entity.Description.TrimEnd.ToUpper.EndsWith(" CABLE")
                                      Select Entity).ToList

                        For Each Market In MarketList

                            NielsenMarket = (From Entity In NielsenMarketList
                                             Where Entity.Description.ToUpper = Replace(Market.Description.TrimEnd.ToUpper, " CABLE", "")
                                             Select Entity).SingleOrDefault

                            If NielsenMarket IsNot Nothing Then

                                Market.NielsenTVCode = NielsenMarket.NielsenTVCode
                                Market.NielsenTVDMACode = NielsenMarket.NielsenTVDMACode
                                Market.NielsenRadioCode = Nothing
                                Market.NielsenBlackRadioCode = Nothing
                                Market.NielsenHispanicRadioCode = Nothing
                                Market.IsCable = True

                                AdvantageFramework.Database.Procedures.Market.Update(DbContext, Market, ErrorMessage)

                            End If

                        Next


                        LoadGrid()

                    Catch ex As Exception
                        DbTransaction.Rollback()
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message
                    Finally

                        If DbContext.Database.Connection.State = ConnectionState.Open Then

                            DbContext.Database.Connection.Close()

                        End If

                        Me.CloseWaitForm()

                    End Try

                End Using

                If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Market_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Market.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Market_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Market.AddNewRowEvent

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Market Then

                Me.ShowWaitForm("Processing...")

                Market = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Market.IsEntityBeingAdded() Then

                        Market.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Market.Insert(DbContext, Market)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Market_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Market.CellValueChangingEvent

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Entities.Market.Properties.IsPuertoRico.ToString Then

                    Try

                        Market = DataGridViewForm_Market.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        Market = Nothing
                    End Try

                    If Market IsNot Nothing Then

                        If e.Column.FieldName = AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString Then

                            Try

                                Market.IsInactive = Convert.ToInt16(e.Value)

                            Catch ex As Exception
                                Market.IsInactive = Market.IsInactive
                            End Try

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    Saved = AdvantageFramework.Database.Procedures.Market.Update(DbContext, Market)

                                End Using

                            Catch ex As Exception

                            End Try

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.Market.Properties.IsPuertoRico.ToString Then

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    For Each DataBoundItem In DataGridViewForm_Market.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Market).ToList

                                        DataBoundItem.IsPuertoRico = False

                                    Next

                                    Market.IsPuertoRico = False

                                    Try

                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.MARKET SET IS_PUERTO_RICO = 0")

                                    Catch ex As Exception

                                    End Try

                                    If e.Value Then

                                        Try

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MARKET SET IS_PUERTO_RICO = 1 WHERE MARKET_CODE = '{0}'", Market.Code))
                                            Market.IsPuertoRico = True

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End Using

                            Catch ex As Exception

                            End Try

                            DataGridViewForm_Market.CurrentView.RefreshData()

                        End If

                        Saved = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Market_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Market.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Market_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Market.ShowingEditorEvent

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If DataGridViewForm_Market.HasOnlyOneSelectedRow OrElse DataGridViewForm_Market.IsNewItemRow(DataGridViewForm_Market.CurrentView.FocusedRowHandle) Then

                If DataGridViewForm_Market.IsNewItemRow(DataGridViewForm_Market.CurrentView.FocusedRowHandle) Then

                    Market = DataGridViewForm_Market.CurrentView.GetRow(DataGridViewForm_Market.CurrentView.FocusedRowHandle)

                Else

                    Market = DataGridViewForm_Market.GetFirstSelectedRowDataBoundItem

                End If

                If Market Is Nothing Then

                    If DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Code.ToString AndAlso
                            DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Description.ToString AndAlso
                            DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString AndAlso
                            DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString Then

                        e.Cancel = True

                    End If

                ElseIf Market.CountryID = DTO.Countries.UnitedStates Then

                    If DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Code.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Description.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.NielsenTVCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.NielsenTVDMACode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.NielsenRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.NielsenBlackRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.NielsenHispanicRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.EastlanRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.EastlanBlackRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.EastlanHispanicRadioCode.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.ComscoreMarketNumber.ToString Then

                        e.Cancel = True

                    End If

                ElseIf Market.CountryID = DTO.Countries.Canada Then

                    If DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Code.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.Description.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.IsInactive.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString AndAlso
                        DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString Then

                        e.Cancel = True

                    End If

                ElseIf Market.CountryID.HasValue = False AndAlso DataGridViewForm_Market.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.Market.Properties.StateID.ToString Then

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControlQueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) '(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Market.QueryPopupNeedDatasourceEvent

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Market = DirectCast(DataGridViewForm_Market.CurrentView.GetRow(DataGridViewForm_Market.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.Market)

            If Market IsNot Nothing AndAlso Market.CountryID.HasValue AndAlso TypeOf DataGridViewForm_Market.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Market.CurrentView.ActiveEditor

                BindingSource = New System.Windows.Forms.BindingSource

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BindingSource.DataSource = DbContext.States.Where(Function(State) State.CountryID = Market.CountryID.Value).ToList.Select(Function(Entity) New With {.ID = Entity.ID, .Name = Entity.StateName}).ToList

                End Using

                GridLookUpEdit.Properties.DataSource = BindingSource

            End If

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim SelectedItems As IEnumerable = Nothing
            Dim ModifiedDictonary As Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewForm_Market.CurrentView.CloseEditorForUpdating()

            SelectedItems = DataGridViewForm_Market.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Market).ToList

            ModifiedDictonary = DataGridViewForm_Market.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems, Nothing) = Windows.Forms.DialogResult.OK Then

                For Each KeyValuePair In ModifiedDictonary

                    DirectCast(KeyValuePair.Value, AdvantageFramework.Database.Entities.Market).StateID = Nothing

                Next

                DataGridViewForm_Market.CurrentView.RefreshData()

                DataGridViewForm_Market.SetUserEntryChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
