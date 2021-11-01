Namespace Security.Database.Procedures.ServiceFeeReconciliationReportColumn

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

        Public Function LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer, ByVal FieldName As String, ByVal GridViewID As Integer) As Database.Entities.ServiceFeeReconciliationReportColumn

            Try

                LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID = (From ServiceFeeReconciliationReportColumn In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportColumn)
                                                                                   Where ServiceFeeReconciliationReportColumn.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID AndAlso
                                                                                         ServiceFeeReconciliationReportColumn.FieldName = FieldName AndAlso
                                                                                         ServiceFeeReconciliationReportColumn.GridViewID = GridViewID
                                                                                   Select ServiceFeeReconciliationReportColumn).SingleOrDefault

            Catch ex As Exception
                LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID = Nothing
            End Try

        End Function
        Public Function LoadByServiceFeeReconciliationReportIDAndGridViewID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer, ByVal GridViewID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportColumn)

            LoadByServiceFeeReconciliationReportIDAndGridViewID = From ServiceFeeReconciliationReportColumn In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportColumn)
                                                                  Where ServiceFeeReconciliationReportColumn.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID AndAlso
                                                                        ServiceFeeReconciliationReportColumn.GridViewID = GridViewID
                                                                  Select ServiceFeeReconciliationReportColumn

        End Function
        Public Function LoadByServiceFeeReconciliationReportID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportColumn)

            LoadByServiceFeeReconciliationReportID = From ServiceFeeReconciliationReportColumn In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportColumn)
                                                     Where ServiceFeeReconciliationReportColumn.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID
                                                     Select ServiceFeeReconciliationReportColumn

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportColumn)

            Load = From ServiceFeeReconciliationReportColumn In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportColumn)
                   Select ServiceFeeReconciliationReportColumn

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer, _
                               ByVal FieldName As String, ByVal HeaderText As String, ByVal IsVisible As Boolean, ByVal SortIndex As Integer, _
                               ByVal SortOrder As Integer, ByVal GroupIndex As Integer, ByVal Width As Integer, ByVal VisibleIndex As Integer, ByVal GridViewID As Integer, _
                               ByRef ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ServiceFeeReconciliationReportColumn = New AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn

                ServiceFeeReconciliationReportColumn.DbContext = DbContext
                ServiceFeeReconciliationReportColumn.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID
                ServiceFeeReconciliationReportColumn.FieldName = FieldName
                ServiceFeeReconciliationReportColumn.HeaderText = HeaderText
                ServiceFeeReconciliationReportColumn.IsVisible = IsVisible
                ServiceFeeReconciliationReportColumn.SortIndex = SortIndex
                ServiceFeeReconciliationReportColumn.SortOrder = SortOrder
                ServiceFeeReconciliationReportColumn.GroupIndex = GroupIndex
                ServiceFeeReconciliationReportColumn.Width = Width
                ServiceFeeReconciliationReportColumn.GridViewID = GridViewID

                If ServiceFeeReconciliationReportColumn.IsVisible AndAlso ServiceFeeReconciliationReportColumn.Width = 0 Then

                    ServiceFeeReconciliationReportColumn.Width = 100

                End If

                If ServiceFeeReconciliationReportColumn.IsVisible AndAlso ServiceFeeReconciliationReportColumn.GroupIndex = -1 Then

                    ServiceFeeReconciliationReportColumn.VisibleIndex = VisibleIndex

                Else

                    ServiceFeeReconciliationReportColumn.VisibleIndex = -1

                End If

				If String.IsNullOrWhiteSpace(ServiceFeeReconciliationReportColumn.HeaderText) = False AndAlso ServiceFeeReconciliationReportColumn.HeaderText.Length > 50 Then

					ServiceFeeReconciliationReportColumn.HeaderText = ServiceFeeReconciliationReportColumn.HeaderText.Substring(0, 50)

				End If

				Inserted = Insert(DbContext, ServiceFeeReconciliationReportColumn)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationReportColumns.Add(ServiceFeeReconciliationReportColumn)

                ErrorText = ServiceFeeReconciliationReportColumn.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationReportColumn)

                ErrorText = ServiceFeeReconciliationReportColumn.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationReportColumn)

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
