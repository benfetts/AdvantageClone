Namespace Database.Procedures.RadioOrderDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderDetail)

            Load = From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                   Select RadioOrderDetail

        End Function
        Public Function LoadNonCancelledByOrderNumbers(ByVal DbContext As Database.DbContext, ByVal OrderNumbers As System.Collections.Generic.List(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderDetail)

            LoadNonCancelledByOrderNumbers = From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                                             Where OrderNumbers.Contains(RadioOrderDetail.RadioOrderNumber) AndAlso
                                                   RadioOrderDetail.IsActiveRevision = 1 AndAlso
                                                   (RadioOrderDetail.IsLineCancelled Is Nothing OrElse
                                                    RadioOrderDetail.IsLineCancelled = 0)
                                             Select RadioOrderDetail

        End Function
        Public Function LoadNonCancelledByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer,
                                                      Optional ByVal Month As String = Nothing, Optional ByVal YearNumber As Short? = Nothing) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderDetail)

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

            LoadNonCancelledByOrderNumber = From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                                            Where RadioOrderDetail.RadioOrderNumber = OrderNumber AndAlso
                                                  RadioOrderDetail.IsActiveRevision = 1 AndAlso
                                                  (RadioOrderDetail.IsLineCancelled Is Nothing OrElse
                                                   RadioOrderDetail.IsLineCancelled = 0) AndAlso
                                                  RadioOrderDetail.MonthNumber = If(MonthNumber IsNot Nothing, MonthNumber, RadioOrderDetail.MonthNumber) AndAlso
                                                  RadioOrderDetail.YearNumber = If(YearNumber IsNot Nothing, YearNumber, RadioOrderDetail.YearNumber)
                                            Select RadioOrderDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.RadioOrderDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                                                     Where RadioOrderDetail.RadioOrderNumber = OrderNumber AndAlso
                                                           RadioOrderDetail.LineNumber = LineNumber AndAlso
                                                           RadioOrderDetail.IsActiveRevision = 1
                                                     Select RadioOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function
        Public Function LoadActiveByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderDetail)

            Try

                LoadActiveByOrderNumber = From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                                          Where RadioOrderDetail.RadioOrderNumber = OrderNumber AndAlso
                                                RadioOrderDetail.IsActiveRevision = 1
                                          Select RadioOrderDetail

            Catch ex As Exception
                LoadActiveByOrderNumber = Nothing
            End Try

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.RadioOrderDetail

            Try

                LoadByAllPrimaryKeys = (From RadioOrderDetail In DbContext.GetQuery(Of Database.Entities.RadioOrderDetail)
                                        Where RadioOrderDetail.RadioOrderNumber = OrderNumber AndAlso
                                              RadioOrderDetail.LineNumber = LineNumber AndAlso
                                              RadioOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              RadioOrderDetail.SequenceNumber = SequenceNumber
                                        Select RadioOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RadioOrderDetail)

                ErrorText = RadioOrderDetail.ValidateEntity(IsValid)

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
