Namespace Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem

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

        Public Function LoadByServiceFeeReconciliationReportIDAndGridViewID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer, ByVal GridViewID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem)

            LoadByServiceFeeReconciliationReportIDAndGridViewID = From ServiceFeeReconciliationReportSummaryItem In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportSummaryItem)
                                                                  Where ServiceFeeReconciliationReportSummaryItem.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID AndAlso
                                                                        ServiceFeeReconciliationReportSummaryItem.GridViewID = GridViewID
                                                                  Select ServiceFeeReconciliationReportSummaryItem

        End Function
        Public Function LoadByServiceFeeReconciliationReportID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem)

            LoadByServiceFeeReconciliationReportID = From ServiceFeeReconciliationReportSummaryItem In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportSummaryItem)
                                                     Where ServiceFeeReconciliationReportSummaryItem.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID
                                                     Select ServiceFeeReconciliationReportSummaryItem

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem)

            Load = From ServiceFeeReconciliationReportSummaryItem In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReportSummaryItem)
                   Select ServiceFeeReconciliationReportSummaryItem

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, _
                               ByVal ServiceFeeReconciliationReportID As Integer, ByVal SummaryItemType As Integer, _
                               ByVal FieldName As String, ByVal OnFooter As Boolean, ByVal DisplayFormat As String, ByVal ColumnName As String, ByVal GridViewID As Integer, _
                               ByRef ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ServiceFeeReconciliationReportSummaryItem = New AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem

                ServiceFeeReconciliationReportSummaryItem.DbContext = DbContext
                ServiceFeeReconciliationReportSummaryItem.ServiceFeeReconciliationReportID = ServiceFeeReconciliationReportID
                ServiceFeeReconciliationReportSummaryItem.SummaryItemType = SummaryItemType
                ServiceFeeReconciliationReportSummaryItem.FieldName = FieldName
                ServiceFeeReconciliationReportSummaryItem.OnFooter = OnFooter
                ServiceFeeReconciliationReportSummaryItem.DisplayFormat = DisplayFormat
                ServiceFeeReconciliationReportSummaryItem.ColumnName = ColumnName
                ServiceFeeReconciliationReportSummaryItem.GridViewID = GridViewID

                Inserted = Insert(DbContext, ServiceFeeReconciliationReportSummaryItem)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationReportSummaryItems.Add(ServiceFeeReconciliationReportSummaryItem)

                ErrorText = ServiceFeeReconciliationReportSummaryItem.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationReportSummaryItem)

                ErrorText = ServiceFeeReconciliationReportSummaryItem.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationReportSummaryItem)

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
