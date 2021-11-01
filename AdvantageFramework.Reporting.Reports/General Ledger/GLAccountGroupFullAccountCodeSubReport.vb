Namespace GeneralLedger

    Public Class GLAccountGroupFullAccountCodeSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AccountGroupType As AdvantageFramework.Database.Entities.AccountGroupTypes = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AccountGroupType As AdvantageFramework.Database.Entities.AccountGroupTypes
            Set(value As AdvantageFramework.Database.Entities.AccountGroupTypes)
                _AccountGroupType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentRow() As AdvantageFramework.Database.Entities.AccountGroupDetail

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing

            Try

                AccountGroupDetail = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.AccountGroupDetail)

            Catch ex As Exception
                AccountGroupDetail = Nothing
            Finally
                LoadCurrentRow = AccountGroupDetail
            End Try

        End Function
        Private Sub AddRow(ByVal XRTable As DevExpress.XtraReports.UI.XRTable, ByVal CellText As String)

            'Objects
            Dim RowIndex As Integer = Nothing

            Try

                RowIndex = XRTable.Rows.Add(New DevExpress.XtraReports.UI.XRTableRow)

                XRTable.Rows(RowIndex).Cells.Add(New DevExpress.XtraReports.UI.XRTableCell With {.Text = CellText})

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub Table_Accounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Table_Accounts.BeforePrint

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim CellText As String = ""

            Table_Accounts.Rows.Clear()

            Table_Accounts.BeginInit()

            AccountGroupDetail = LoadCurrentRow()

            If AccountGroupDetail IsNot Nothing Then

                If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _AccountGroupType = AdvantageFramework.Database.Entities.AccountGroupTypes.BaseAccountCode Then

                            Try

                                GeneralLedgerAccount = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                                        Where Entity.BaseCode = AccountGroupDetail.GLACode
                                                        Select Entity).FirstOrDefault

                            Catch ex As Exception
                                GeneralLedgerAccount = Nothing
                            End Try

                            CellText &= "Base Account:   "

                            If GeneralLedgerAccount IsNot Nothing Then

                                CellText &= GeneralLedgerAccount.BaseCode & " - " & GeneralLedgerAccount.Description

                            End If

                        Else

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, AccountGroupDetail.GLACode)

                            CellText &= "Account:   "

                            If GeneralLedgerAccount IsNot Nothing Then

                                CellText &= GeneralLedgerAccount.ToString

                            End If

                        End If

                    End Using

                End If

                If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                    If String.IsNullOrWhiteSpace(CellText) = False Then

                        CellText &= "  "

                    End If

                    If _AccountGroupType = AdvantageFramework.Database.Entities.AccountGroupTypes.BaseAccountCode Then

                        CellText &= "Base Range:   " & AccountGroupDetail.GLACodeFrom & ":" & AccountGroupDetail.GLACodeTo

                    Else

                        CellText &= "Range:   " & AccountGroupDetail.GLACodeFrom & ":" & AccountGroupDetail.GLACodeTo

                    End If

                End If

                AddRow(Table_Accounts, CellText)

            End If

            Table_Accounts.EndInit()

        End Sub
        Private Sub Table_AccountDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Table_AccountDetails.BeforePrint

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Table_AccountDetails.Rows.Clear()

            Table_AccountDetails.BeginInit()

            AccountGroupDetail = LoadCurrentRow()

            If AccountGroupDetail IsNot Nothing Then

                GeneralLedgerAccounts = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                            If _AccountGroupType = AdvantageFramework.Database.Entities.AccountGroupTypes.BaseAccountCode Then

                                GeneralLedgerAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(Entity) Entity.BaseCode = AccountGroupDetail.GLACode).OrderBy(Function(Entity) Entity.Code).ToList)

                            Else

                                GeneralLedgerAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(Entity) Entity.Code = AccountGroupDetail.GLACode).OrderBy(Function(Entity) Entity.Code).ToList)

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                            If _AccountGroupType = AdvantageFramework.Database.Entities.AccountGroupTypes.BaseAccountCode Then

                                GeneralLedgerAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(Entity) Entity.BaseCode >= AccountGroupDetail.GLACodeFrom AndAlso Entity.BaseCode <= AccountGroupDetail.GLACodeTo).OrderBy(Function(Entity) Entity.Code).ToList)

                            Else

                                GeneralLedgerAccounts.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo).OrderBy(Function(Entity) Entity.Code).ToList)

                            End If

            End If

                    Catch ex As Exception
                GeneralLedgerAccounts = Nothing
            End Try

            If GeneralLedgerAccounts IsNot Nothing AndAlso GeneralLedgerAccounts.Any Then

                For Each GeneralLedgerAccount In GeneralLedgerAccounts

                    AddRow(Table_AccountDetails, GeneralLedgerAccount.ToString)

                Next

            End If

                End Using

            End If

            Table_AccountDetails.EndInit()

        End Sub

#End Region

#End Region

    End Class

End Namespace
