Namespace Database.Procedures.EmployeeTimeDetail

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

        Public Function LoadByEmployeeTimeIDAndEmployeeTimeDetailID(ByVal DbContext As Database.DbContext,
                                                                    ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short) As Database.Entities.EmployeeTimeDetail

            Dim Entries As Collections.Generic.List(Of Database.Entities.EmployeeTimeDetail) = Nothing
            Dim Entry As Database.Entities.EmployeeTimeDetail = Nothing

            Try

                Entries = (From EmployeeTimeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeDetail).Include("EmployeeTime")
                           Where EmployeeTimeDetail.EmployeeTimeID = EmployeeTimeID And EmployeeTimeDetail.EmployeeTimeDetailID = EmployeeTimeDetailID
                           Select EmployeeTimeDetail).ToList

                If Entries IsNot Nothing Then

                    If Entries.Count = 1 Then

                        Entry = (From Entity In Entries
                                 Select Entity).First

                    ElseIf Entries.Count > 1 Then

                        Entry = (From Entity In Entries
                                 Where Entity.ARInvoiceNumber Is Nothing
                                 Select Entity).First

                    End If

                End If

            Catch ex As Exception
                Entry = Nothing
            End Try

            Return Entry

        End Function
        Public Function LoadByEmployeeTimeID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeDetail)

            LoadByEmployeeTimeID = From EmployeeTimeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeDetail)
                                   Where EmployeeTimeDetail.EmployeeTimeID = EmployeeTimeID
                                   Select EmployeeTimeDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeDetail)

            Load = From EmployeeTimeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeDetail)
                   Select EmployeeTimeDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeDetails.Add(EmployeeTimeDetail)

                ErrorText = EmployeeTimeDetail.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        EmployeeTimeDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext) _
                                                             Where Entity.EmployeeTimeID = EmployeeTimeDetail.EmployeeTimeID
                                                             Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        EmployeeTimeDetail.SequenceNumber = 1
                    End Try

                    If EmployeeTimeDetail.EmployeeTimeDetailID = 0 Then

                        EmployeeTimeDetail.EmployeeTimeDetailID = EmployeeTimeDetail.SequenceNumber

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeDetail)

                ErrorText = EmployeeTimeDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeIDs As System.Collections.Generic.List(Of Integer), _
                                  ByVal UpdateStandardAmount As Boolean, ByVal StandardCostRate As Decimal, ByVal UpdateAlternateAmount As Boolean, ByVal AlternateCostRate As Decimal, _
                                  ByVal UpdateDepartmentTeam As Boolean, ByVal DepartmentTeamCode As String) As Boolean

            'objects
            Dim Updated As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UpdateStatements As System.Collections.Generic.List(Of String) = Nothing
            Dim UpdateStatement As String = Nothing

            Try

                UpdateStatements = New System.Collections.Generic.List(Of String)

                If UpdateStandardAmount Then

                    UpdateStatements.Add("[TOTAL_COST] = [EMP_HOURS] * {0}")
                    UpdateStatements.Add("[EMP_COST_RATE] = {0}")

                End If

                If UpdateAlternateAmount Then

                    UpdateStatements.Add("[ALT_COST_AMT] = [EMP_HOURS] * {1}")
                    UpdateStatements.Add("[ALT_COST_RATE] = {1}")

                End If

                If UpdateDepartmentTeam Then

                    If DepartmentTeamCode IsNot Nothing Then

                        DepartmentTeamCode = DepartmentTeamCode.Trim

                    End If

                    If String.IsNullOrEmpty(DepartmentTeamCode) Then

                        DepartmentTeamCode = "NULL"

                        UpdateStatements.Add("[DP_TM_CODE] = {2}")

                    Else

                        UpdateStatements.Add("[DP_TM_CODE] = '{2}'")

                    End If

                End If

                UpdateStatement = Join(UpdateStatements.ToArray, ", ")

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_DTL SET " & UpdateStatement & " WHERE [ET_ID] IN ({3})", _
                                                                StandardCostRate.ToString(System.Globalization.CultureInfo.InvariantCulture), AlternateCostRate.ToString(System.Globalization.CultureInfo.InvariantCulture), DepartmentTeamCode, _
                                                                Join(EmployeeTimeIDs.Select(Function(ID) CStr(ID)).ToArray, ", ")))

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

            Try

                EmployeeTimeDetail = (From Entity In Load(DbContext) _
                                      Where Entity.EmployeeTimeID = EmployeeTimeID AndAlso _
                                            Entity.EmployeeTimeDetailID = EmployeeTimeDetailID _
                                      Select Entity).SingleOrDefault

                AdvantageFramework.Database.Procedures.EmployeeTimeComment.Delete(DbContext, EmployeeTimeID, EmployeeTimeDetailID, "D")

                DbContext.DeleteEntityObject(EmployeeTimeDetail)

                DbContext.SaveChanges()

                Deleted = True

                If (From Entity In Load(DbContext) _
                    Where Entity.EmployeeTimeID = EmployeeTimeID _
                    Select Entity).Any = False Then

                    If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Load(DbContext) _
                        Where Entity.ID = EmployeeTimeID
                        Select Entity).Any = False Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_TIME] WHERE [ET_ID] = {0}", EmployeeTimeID))

                        Catch ex As Exception

                        End Try

                    End If

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
