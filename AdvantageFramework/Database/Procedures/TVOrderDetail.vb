Namespace Database.Procedures.TVOrderDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderDetail)

            Load = From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                   Select TVOrderDetail

        End Function
        Public Function LoadNonCancelledByOrderNumbers(ByVal DbContext As Database.DbContext, ByVal OrderNumbers As System.Collections.Generic.List(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderDetail)

            LoadNonCancelledByOrderNumbers = From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                                             Where OrderNumbers.Contains(TVOrderDetail.TVOrderNumber) AndAlso
                                                   TVOrderDetail.IsActiveRevision = 1 AndAlso
                                                   (TVOrderDetail.IsLineCancelled Is Nothing OrElse
                                                    TVOrderDetail.IsLineCancelled = 0)
                                             Select TVOrderDetail

        End Function
        Public Function LoadNonCancelledByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer,
                                                                   Optional ByVal Month As String = Nothing, Optional ByVal YearNumber As Short? = Nothing) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderDetail)

            Dim MonthNumber As Short? = Nothing

            If Month IsNot Nothing Then

                Select Case Month

                    Case "JAN"
                        MonthNumber = 1
                    Case "FEB"
                        MonthNumber = 2
                    Case "MAR"
                        MonthNumber = 3
                    Case "APR"
                        MonthNumber = 4
                    Case "MAY"
                        MonthNumber = 5
                    Case "JUN"
                        MonthNumber = 6
                    Case "JUL"
                        MonthNumber = 7
                    Case "AUG"
                        MonthNumber = 8
                    Case "SEP"
                        MonthNumber = 9
                    Case "OCT"
                        MonthNumber = 10
                    Case "NOV"
                        MonthNumber = 11
                    Case "DEC"
                        MonthNumber = 12
                    Case Else
                        MonthNumber = Nothing

                End Select

            End If

            LoadNonCancelledByOrderNumber = From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                                            Where TVOrderDetail.TVOrderNumber = OrderNumber AndAlso
                                                  TVOrderDetail.IsActiveRevision = 1 AndAlso
                                                  (TVOrderDetail.IsLineCancelled Is Nothing OrElse
                                                   TVOrderDetail.IsLineCancelled = 0) AndAlso
                                                  TVOrderDetail.MonthNumber = If(MonthNumber IsNot Nothing, MonthNumber, TVOrderDetail.MonthNumber) AndAlso
                                                  TVOrderDetail.YearNumber = If(YearNumber IsNot Nothing, YearNumber, TVOrderDetail.YearNumber)
                                            Select TVOrderDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.TVOrderDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                                                     Where TVOrderDetail.TVOrderNumber = OrderNumber AndAlso
                                                           TVOrderDetail.LineNumber = LineNumber AndAlso
                                                           TVOrderDetail.IsActiveRevision = 1
                                                     Select TVOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function
        Public Function LoadActiveByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderDetail)

            Try

                LoadActiveByOrderNumber = From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                                          Where TVOrderDetail.TVOrderNumber = OrderNumber AndAlso
                                                TVOrderDetail.IsActiveRevision = 1
                                          Select TVOrderDetail

            Catch ex As Exception
                LoadActiveByOrderNumber = Nothing
            End Try

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.TVOrderDetail

            Try

                LoadByAllPrimaryKeys = (From TVOrderDetail In DbContext.GetQuery(Of Database.Entities.TVOrderDetail)
                                        Where TVOrderDetail.TVOrderNumber = OrderNumber AndAlso
                                              TVOrderDetail.LineNumber = LineNumber AndAlso
                                              TVOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              TVOrderDetail.SequenceNumber = SequenceNumber
                                        Select TVOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(TVOrderDetail)

                ErrorText = TVOrderDetail.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
