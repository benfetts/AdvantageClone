Namespace Database.Procedures.FunctionView

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

        Public Function LoadForComboBox(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForComboBox = (From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                   Select FunctionView.Code,
                                          FunctionView.Type,
                                          [Description] = FunctionView.ToString).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                        .Type = Func.Type,
                                                                                                                        .Description = Func.Description}).ToList

            Catch ex As Exception
                LoadForComboBox = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEdit(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForSubItemGridLookupEdit = (From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                                Select FunctionView.Code,
                                                       [Description] = FunctionView.Description).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                        .Description = Func.Description}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEdit = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEditActiveByType(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As String) As IEnumerable

            Try

                LoadForSubItemGridLookupEditActiveByType = (From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                                            Where FunctionView.Type = Type AndAlso
                                                                  (FunctionView.IsInactive Is Nothing OrElse FunctionView.IsInactive = 0)
                                                            Select FunctionView.Code,
                                                                   [Description] = FunctionView.Description).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                                    .Description = Func.Description}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEditActiveByType = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupByType(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As String) As IEnumerable

            Try

                LoadForSubItemGridLookupByType = (From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                                  Where FunctionView.Type = Type
                                                  Select FunctionView.Code,
                                                         [Description] = FunctionView.Description).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                          .Description = Func.Description}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupByType = Nothing
            End Try

        End Function
        Public Function LoadAllVendorFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            LoadAllVendorFunctions = From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                     Where FunctionView.Type = "V"
                                     Select FunctionView

        End Function
        Public Function LoadAllActiveVendorFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            LoadAllActiveVendorFunctions = From FunctionView In LoadAllVendorFunctions(DbContext)
                                           Where FunctionView.IsInactive Is Nothing OrElse
                                                 FunctionView.IsInactive = 0
                                           Select FunctionView

        End Function
        Public Function LoadAllEmployeeFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            LoadAllEmployeeFunctions = From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                       Where FunctionView.Type = "E"
                                       Select FunctionView

        End Function
        Public Function LoadAllActiveEmployeeFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            LoadAllActiveEmployeeFunctions = From FunctionView In LoadAllEmployeeFunctions(DbContext)
                                             Where FunctionView.IsInactive Is Nothing OrElse
                                                   FunctionView.IsInactive = 0
                                             Select FunctionView

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            LoadAllActive = From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                            Where FunctionView.IsInactive Is Nothing OrElse
                                  FunctionView.IsInactive = 0
                            Select FunctionView

        End Function
        Public Function LoadByFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String) As AdvantageFramework.Database.Views.FunctionView

            Try

                LoadByFunctionCode = (From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                                      Where FunctionView.Code = FunctionCode
                                      Select FunctionView).SingleOrDefault

            Catch ex As Exception
                LoadByFunctionCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.FunctionView)

            Load = From FunctionView In DbContext.GetQuery(Of Database.Views.FunctionView)
                   Select FunctionView

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim Initialized As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If Initialize(DbContext, FunctionView) Then

                    Initialized = True

                    If Save(DbContext, FunctionView) Then

                        Inserted = True

                    End If

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = "Failed trying to insert into the database. Please contact software support."
            Finally

                If Initialized AndAlso Inserted = False Then

                    Delete(DbContext, FunctionView.Code)

                End If

                If ErrorText <> "" Then

                    Throw New System.Exception(ErrorText)

                End If

                Insert = Inserted

            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
           
            Try

                ErrorText = FunctionView.ValidateEntity(IsValid)

                If IsValid Then

                    Updated = Save(DbContext, FunctionView)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[FUNCTIONS] WHERE [FNC_CODE] = '{0}'", FunctionCode))

                    Deleted = True

                Catch ex As Exception
                    Deleted = False
                End Try

                If Deleted Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsFunctionInUse(DbContext, FunctionView) = False Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[FUNCTIONS] WHERE [FNC_CODE] = '{0}'", FunctionView.Code))

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()
                        AdvantageFramework.Navigation.ShowMessageBox("This function is in use and cannot be deleted.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("This function is in use and cannot be deleted.")

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function IsFunctionInUse(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            'objects
            Dim InUse As Boolean = True

            Try

                InUse = AdvantageFramework.Database.Procedures.Function.IsFunctionInUse(DbContext, FunctionView.Code, FunctionView.Type)

            Catch ex As Exception
                InUse = False
            Finally
                IsFunctionInUse = InUse
            End Try

        End Function
        Private Function Initialize(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            Dim Initialized As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim InsertStatement As String = Nothing

            Try

                InsertStatement = String.Format("INSERT INTO [dbo].[FUNCTIONS] (FNC_CODE, FNC_DESCRIPTION, FNC_TYPE) VALUES ('{0}', '{1}', '{2}')",
                                                FunctionView.Code, FunctionView.Description.Replace("'", "''"), FunctionView.Type)

                ErrorText = FunctionView.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(InsertStatement)

                    Initialized = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Initialized = False
            Finally
                Initialize = Initialized
            End Try

        End Function
        Private Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView) As Boolean

            'objects
            Dim ErrorText As String = Nothing
            Dim Saved As Boolean = False
            Dim UpdateStatement As String = Nothing

            UpdateStatement = String.Format(" UPDATE [dbo].[V_FUNCTION] SET " &
                                            "   [FNC_FEE_FLAG] = {0}, " &
                                            "   [OVERHEAD_GLACCT] = {1}, " &
                                            "   [NONBILL_CLI_GLACCT] = {2}, " &
                                            "   [EX_FLAG] = {3}, " &
                                            "   [FNC_HEADING_ID] = {4}, " &
                                            "   [FNC_FEE_RECONCILE] = {5}, " &
                                            "   [FNC_INACTIVE] = {6}, " &
                                            "   [FNC_ORDER] = {7}, " &
                                            "   [FNC_CPM_FLAG] = {8}, " &
                                            "   [FNC_CONSOLIDATION] = {9}, " &
                                            "   [DP_TM_CODE] = {10}, " &
                                            "   [FNC_TYPE] = '{11}', " &
                                            "   [FNC_DESCRIPTION] = {12}, " &
                                            "   [VAT_TAX_CODE] = {13} " &
                                            " WHERE " &
                                            "   [FNC_CODE] = '{14}' ",
                                            If(FunctionView.FeeFlag.HasValue, FunctionView.FeeFlag, "NULL"),
                                            If(FunctionView.OverheadGLACode <> "", "'" & FunctionView.OverheadGLACode & "'", "NULL"),
                                            If(FunctionView.NonBillableClientGLACode <> "", "'" & FunctionView.NonBillableClientGLACode & "'", "NULL"),
                                            FunctionView.EmployeeExpenseFlag.GetValueOrDefault(0),
                                            If(FunctionView.FunctionHeadingID.HasValue, FunctionView.FunctionHeadingID, "NULL"),
                                            If(FunctionView.FeeReconcile.HasValue, FunctionView.FeeReconcile, "NULL"),
                                            If(FunctionView.IsInactive.HasValue, FunctionView.IsInactive, "NULL"),
                                            If(FunctionView.FunctionOrder.HasValue, FunctionView.FunctionOrder, "NULL"),
                                            If(FunctionView.CPMFlag.HasValue, FunctionView.CPMFlag, "NULL"),
                                            If(FunctionView.LineConsolidation <> "", "'" & FunctionView.LineConsolidation & "'", "NULL"),
                                            If(FunctionView.DepartmentTeamCode <> "", "'" & FunctionView.DepartmentTeamCode & "'", "NULL"),
                                            FunctionView.Type,
                                            If(FunctionView.Description <> "", "'" & FunctionView.Description.Replace("'", "''") & "'", "NULL"),
                                            If(FunctionView.VATTaxCode <> "", "'" & FunctionView.VATTaxCode.Replace("'", "''") & "'", "NULL"),
                                            FunctionView.Code)

            Try

                DbContext.Database.ExecuteSqlCommand(UpdateStatement)

                Saved = True

            Catch ex As Exception
                Saved = False
            Finally
                Save = Saved
            End Try

        End Function
       
#End Region

    End Module

End Namespace
