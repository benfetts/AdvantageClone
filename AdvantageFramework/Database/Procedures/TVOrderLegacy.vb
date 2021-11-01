Namespace Database.Procedures.TVOrderLegacy

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderLegacy)

            Load = From TVOrderLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderLegacy)
                   Select TVOrderLegacy

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.TVOrderLegacy

            Try

                LoadByOrderNumber = (From TVOrderLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderLegacy)
                                     Where TVOrderLegacy.OrderNumber = OrderNumber
                                     Order By TVOrderLegacy.RevisionNumber Descending
                                     Select TVOrderLegacy).FirstOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function GetAllMonths() As List(Of String)

            Dim MonthNameList As List(Of String) = Nothing

            MonthNameList = New List(Of String)

            For MonthInteger As Integer = 1 To 12

                MonthNameList.Add(MonthName(MonthInteger, True).ToUpper)

            Next

            GetAllMonths = MonthNameList

        End Function
        Public Function GetAllYears() As List(Of Int16)

            Dim YearList As List(Of Int16) = Nothing

            YearList = New List(Of Int16)

            For Year As Integer = 1990 To Now.Year + 15

                YearList.Add(CShort(Year))

            Next

            GetAllYears = YearList

        End Function
        Public Function GetMonthsByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As List(Of String)

            Dim TVOrderLegacyFirst As AdvantageFramework.Database.Entities.TVOrderLegacy = Nothing
            Dim MonthNameList As List(Of String) = Nothing

            Try

                TVOrderLegacyFirst = (From TVOrderLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderLegacy)
                                      Where TVOrderLegacy.OrderNumber = OrderNumber
                                      Order By TVOrderLegacy.RevisionNumber Descending
                                      Select TVOrderLegacy).FirstOrDefault

            Catch ex As Exception
                TVOrderLegacyFirst = Nothing
            End Try

            MonthNameList = New List(Of String)

            If TVOrderLegacyFirst IsNot Nothing Then

                If TVOrderLegacyFirst.BroadcastYear1 IsNot Nothing AndAlso TVOrderLegacyFirst.FirstMonthYear1 IsNot Nothing AndAlso TVOrderLegacyFirst.LastMonthYear1 IsNot Nothing Then

                    For Months As Integer = TVOrderLegacyFirst.FirstMonthYear1 To TVOrderLegacyFirst.LastMonthYear1

                        If Not MonthNameList.Contains(MonthName(Months, True).ToUpper) Then

                            MonthNameList.Add(MonthName(Months, True).ToUpper)

                        End If

                    Next

                End If

                If TVOrderLegacyFirst.BroadcastYear2 IsNot Nothing AndAlso TVOrderLegacyFirst.FirstMonthYear2 IsNot Nothing AndAlso TVOrderLegacyFirst.LastMonthYear2 IsNot Nothing Then

                    For Months As Integer = TVOrderLegacyFirst.FirstMonthYear2 To TVOrderLegacyFirst.LastMonthYear2

                        If Not MonthNameList.Contains(MonthName(Months, True).ToUpper) Then

                            MonthNameList.Add(MonthName(Months, True).ToUpper)

                        End If

                    Next

                End If

            End If

            GetMonthsByOrderNumber = MonthNameList

        End Function
        Public Function GetYearsByOrderNumberMonth(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, Month As String) As List(Of Int16)

            Dim TVOrderLegacyFirst As AdvantageFramework.Database.Entities.TVOrderLegacy = Nothing
            Dim YearList As List(Of Int16) = Nothing
            Dim MonthNumber As Short = Nothing

            For MonthNumber = 1 To 12

                If MonthName(MonthNumber, True).ToUpper = Month Then

                    Exit For

                End If

            Next

            YearList = New List(Of Short)

            Try

                TVOrderLegacyFirst = (From TVOrderLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderLegacy)
                                      Where TVOrderLegacy.OrderNumber = OrderNumber AndAlso
                                            TVOrderLegacy.FirstMonthYear1 <= MonthNumber AndAlso
                                            TVOrderLegacy.LastMonthYear1 >= MonthNumber
                                      Order By TVOrderLegacy.RevisionNumber Descending
                                      Select TVOrderLegacy).FirstOrDefault

                If TVOrderLegacyFirst.BroadcastYear1 IsNot Nothing Then

                    If Not YearList.Contains(TVOrderLegacyFirst.BroadcastYear1) Then

                        YearList.Add(TVOrderLegacyFirst.BroadcastYear1)

                    End If

                End If

            Catch ex As Exception
                TVOrderLegacyFirst = Nothing
            End Try

            Try

                TVOrderLegacyFirst = (From TVOrderLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderLegacy)
                                      Where TVOrderLegacy.OrderNumber = OrderNumber AndAlso
                                            TVOrderLegacy.FirstMonthYear2 <= MonthNumber AndAlso
                                            TVOrderLegacy.LastMonthYear2 >= MonthNumber
                                      Order By TVOrderLegacy.RevisionNumber Descending
                                      Select TVOrderLegacy).FirstOrDefault

                If TVOrderLegacyFirst.BroadcastYear2 Then

                    If Not YearList.Contains(TVOrderLegacyFirst.BroadcastYear2) Then

                        YearList.Add(TVOrderLegacyFirst.BroadcastYear2)

                    End If

                End If

            Catch ex As Exception
                TVOrderLegacyFirst = Nothing
            End Try

            GetYearsByOrderNumberMonth = YearList

        End Function

#End Region

    End Module

End Namespace
