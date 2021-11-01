Namespace Database.Procedures.EmployeeOffice

    <HideModuleName()>
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

        Public Function LoadByGroupCode(ByVal DbContext As Database.DbContext, ByVal GroupCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeOffice)

            LoadByGroupCode = From EmployeeOffice In DbContext.GetQuery(Of Database.Entities.EmployeeOffice)
                              Where EmployeeOffice.UserGroupCode = GroupCode
                              Select EmployeeOffice

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeOffice)

            LoadByEmployeeCode = From EmployeeOffice In DbContext.GetQuery(Of Database.Entities.EmployeeOffice)
                                 Where EmployeeOffice.EmployeeCode = EmployeeCode
                                 Select EmployeeOffice

        End Function
        Public Function LoadByOfficeCodesByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As Collections.Generic.List(Of String)

            Dim OfficeCodes As Collections.Generic.List(Of String) = Nothing

            Try

                OfficeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT OFFICE_CODE FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", EmployeeCode)).ToList

            Catch ex As Exception
                OfficeCodes = New Collections.Generic.List(Of String)
            End Try

            LoadByOfficeCodesByEmployeeCode = OfficeCodes

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeOffice)

            Load = From EmployeeOffice In DbContext.GetQuery(Of Database.Entities.EmployeeOffice)
                   Select EmployeeOffice

        End Function
        Public Function ValidateJobOffice(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal JobNumber As Integer) As Boolean

            Dim UserEmployeeOfficeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Valid As Boolean = False

            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                For Each EmpOffice In UserEmployeeOfficeList
                    If EmpOffice.OfficeCode = jobdata.OfficeCode Then
                        Valid = True
                        Exit For
                    Else
                        Valid = False
                    End If
                Next

            Else

                Valid = True

            End If

            ValidateJobOffice = Valid

        End Function

        Public Function ValidateCDPOffice(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            Dim UserEmployeeOfficeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Valid As Boolean = False

            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                For Each EmpOffice In UserEmployeeOfficeList
                    If EmpOffice.OfficeCode = Product.OfficeCode Then
                        Valid = True
                        Exit For
                    Else
                        Valid = False
                    End If
                Next

            Else

                Valid = True

            End If

            ValidateCDPOffice = Valid

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeOffices.Add(EmployeeOffice)

                ErrorText = EmployeeOffice.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeOffice)

                ErrorText = EmployeeOffice.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeOffice)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeOffice).Where(Function(EmpOffice) EmpOffice.EmployeeCode = EmployeeCode)

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

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
