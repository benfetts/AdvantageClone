Namespace Database.Procedures.Function

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

#Region "  Core Entities "

        Public Function LoadCore(ByVal Functions As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)) As IEnumerable(Of AdvantageFramework.Database.Core.Function)

            Try

                LoadCore = Functions _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Type,
                                                              Entity.Description,
                                                              Entity.IsInactive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Function With {.Code = Entity.Code,
                                                                                                        .Type = Entity.Type,
                                                                                                        .Description = Entity.Description,
                                                                                                        .IsInactive = Entity.IsInactive}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Function)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadForComboBox(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForComboBox = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                   Select [Function].Code,
                                          [Function].Type,
                                          [Description] = [Function].ToString).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                      .Type = Func.Type,
                                                                                                                      .Description = Func.Description}).ToList

            Catch ex As Exception
                LoadForComboBox = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEdit(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForSubItemGridLookupEdit = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                                Select [Function].Code,
                                                       [Description] = [Function].Description,
                                                       [Function].Type).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                               .Description = Func.Description,
                                                                                                               .Type = Func.Type}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEdit = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEditAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForSubItemGridLookupEditAllActive = (From [Function] In LoadAllActive(DbContext)
                                                         Select [Function].Code,
                                                                [Description] = [Function].Description,
                                                                [Function].Type).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                        .Description = Func.Description,
                                                                                                                        .Type = Func.Type}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEditAllActive = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEditAllActiveBillableTypes(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable

            Try

                LoadForSubItemGridLookupEditAllActiveBillableTypes = (From [Function] In LoadAllActive(DbContext)
                                                                      Where [Function].Type = "E" OrElse
                                                                            [Function].Type = "V" OrElse
                                                                            [Function].Type = "I"
                                                                      Select [Function].Code,
                                                                             [Description] = [Function].Description,
                                                                             [Function].Type).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                     .Description = Func.Description,
                                                                                                                                     .Type = Func.Type}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEditAllActiveBillableTypes = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupEditActiveByType(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As String) As IEnumerable

            Try

                LoadForSubItemGridLookupEditActiveByType = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                                            Where [Function].Type = Type AndAlso
                                                                  ([Function].IsInactive Is Nothing OrElse [Function].IsInactive = 0)
                                                            Select [Function].Code,
                                                                   [Description] = [Function].Description,
                                                                   [CPMFlag] = [Function].CPMFlag).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                          .Description = Func.Description,
                                                                                                                                          .CPMFlag = CBool(Func.CPMFlag.GetValueOrDefault(0))}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupEditActiveByType = Nothing
            End Try

        End Function
        Public Function LoadForSubItemGridLookupByType(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As String) As IEnumerable

            Try

                LoadForSubItemGridLookupByType = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                                  Where [Function].Type = Type
                                                  Select [Function].Code,
                                                         [Description] = [Function].Description,
                                                         [CPMFlag] = [Function].CPMFlag).ToList.Select(Function(Func) New With {.Code = Func.Code,
                                                                                                                                .Description = Func.Description,
                                                                                                                                .CPMFlag = CBool(Func.CPMFlag.GetValueOrDefault(0))}).ToList

            Catch ex As Exception
                LoadForSubItemGridLookupByType = Nothing
            End Try

        End Function
        'Public Function LoadForEmployeeDirectTime(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal JobNumber As Integer) As IEnumerable

        '    LoadForEmployeeDirectTime = (From Entity In DbContext.Database.SqlQuery(Of DirectTimeFunction)(String.Format("EXEC [dbo].[usp_wv_dd_GetFunctions_ByEmpCode] '{0}', {1};", EmployeeCode, JobNumber))
        '                                 Select New With {.Code = Entity.Code,
        '                                                  .Description = Entity.DescriptionOnly}).ToList

        'End Function
        Public Function LoadForEmployeeDirectTime(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As IEnumerable

            LoadForEmployeeDirectTime = (From Entity In DbContext.Database.SqlQuery(Of DirectTimeFunction)(String.Format("EXEC [dbo].[usp_wv_dd_GetFunctions_ByEmpCode] '{0}', 0, NULL;", EmployeeCode))
                                         Select New With {.Code = Entity.Code,
                                                          .Description = Entity.DescriptionOnly}).ToList

        End Function
        Public Function LoadAllVendorFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllVendorFunctions = From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                     Where [Function].Type = "V"
                                     Select [Function]

        End Function
        Public Function LoadAllActiveVendorFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllActiveVendorFunctions = From [Function] In AdvantageFramework.Database.Procedures.Function.LoadAllVendorFunctions(DbContext)
                                           Where [Function].IsInactive Is Nothing OrElse
                                                 [Function].IsInactive = 0
                                           Select [Function]

        End Function
        Public Function LoadAllEmployeeFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllEmployeeFunctions = From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                       Where [Function].Type = "E"
                                       Select [Function]

        End Function
        Public Function LoadAllActiveEmployeeFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllActiveEmployeeFunctions = From [Function] In AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeFunctions(DbContext)
                                             Where [Function].IsInactive Is Nothing OrElse
                                                   [Function].IsInactive = 0
                                             Select [Function]

        End Function
        Public Function LoadAllActiveEmployeeExpenseVendorFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllActiveEmployeeExpenseVendorFunctions = From [Function] In LoadAllActive(DbContext)
                                                          Where [Function].EmployeeExpenseFlag = CShort(1) AndAlso
                                                                [Function].Type = "V"
                                                          Select [Function]

        End Function
        Public Function LoadAllEmployeeExpenseFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllEmployeeExpenseFunctions = From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                              Where [Function].EmployeeExpenseFlag = CShort(1)
                                              Select [Function]

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            LoadAllActive = From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                            Where [Function].IsInactive Is Nothing OrElse
                                  [Function].IsInactive = 0
                            Select [Function]

        End Function
        Public Function LoadByFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String) As AdvantageFramework.Database.Entities.Function

            Try

                LoadByFunctionCode = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                      Where [Function].Code = FunctionCode
                                      Select [Function]).SingleOrDefault

            Catch ex As Exception
                LoadByFunctionCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            Load = From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                   Select [Function]

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Function] As AdvantageFramework.Database.Entities.Function) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Functions.Add([Function])

                ErrorText = [Function].ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Function] As AdvantageFramework.Database.Entities.Function) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject([Function])

                ErrorText = [Function].ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Function] As AdvantageFramework.Database.Entities.Function) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If IsFunctionInUse(DbContext, [Function]) = False Then

                        DbContext.DeleteEntityObject([Function])

                        DbContext.SaveChanges()

                        Deleted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("This function is in use and cannot be deleted.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function IsFunctionInUse(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Function] As AdvantageFramework.Database.Entities.Function) As Boolean

            IsFunctionInUse = IsFunctionInUse(DbContext, [Function].Code, [Function].Type)

        End Function
        Public Function IsFunctionInUse(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String, ByVal FunctionType As String) As Boolean

            'objects
            Dim InUse As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM AP_PRODUCTION WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM CLIENT_OOP WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM EMP_TIME_DTL WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM INCOME_ONLY WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM ADVANCE_BILLING WHERE FNC_CODE = '{0}' AND FNC_TYPE = '{1}'", FunctionCode, FunctionType)).FirstOrDefault = 0 Then

                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM ESTIMATE_REV_DET A, FUNCTIONS B WHERE A.FNC_CODE = B.FNC_CODE AND A.FNC_CODE = '{0}' AND B.FNC_TYPE = '{1}'", FunctionCode, FunctionType)).FirstOrDefault = 0 Then

                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM PURCHASE_ORDER_DET WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                            'If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) PRESET_FUNC WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM TRAFFIC_FNC WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM EXPENSE_DETAIL WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM EMPLOYEE WHERE DEF_FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM EMP_TIME_BATCH WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM BILLING_RATE WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then
                                                                
                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM EMP_TS_FNC WHERE FNC_CODE = '{0}'", FunctionCode)).FirstOrDefault = 0 Then

                                                                    InUse = False

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                            'End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                InUse = False
            Finally
                IsFunctionInUse = InUse
            End Try

        End Function

#End Region

        <Serializable>
        Public Class DirectTimeFunction
            Public Property Code As String
            Public Property Description As String
            Public Property DescriptionOnly As String
            Sub New()

            End Sub
        End Class

    End Module



End Namespace

