Namespace Database.Procedures.RadioOrderLegacy

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderLegacy)

            Load = From RadioOrderLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderLegacy)
                   Select RadioOrderLegacy

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.RadioOrderLegacy

            Try

                LoadByOrderNumber = (From RadioOrderLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderLegacy)
                                     Where RadioOrderLegacy.OrderNumber = OrderNumber
                                     Order By RadioOrderLegacy.RevisionNumber Descending
                                     Select RadioOrderLegacy).FirstOrDefault

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

            Dim RadioOrderLegacyFirst As AdvantageFramework.Database.Entities.RadioOrderLegacy = Nothing
            Dim MonthNameList As List(Of String) = Nothing

            Try

                RadioOrderLegacyFirst = (From RadioOrderLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderLegacy)
                                         Where RadioOrderLegacy.OrderNumber = OrderNumber
                                         Order By RadioOrderLegacy.RevisionNumber Descending
                                         Select RadioOrderLegacy).FirstOrDefault

            Catch ex As Exception
                RadioOrderLegacyFirst = Nothing
            End Try

            MonthNameList = New List(Of String)

            If RadioOrderLegacyFirst IsNot Nothing Then

                If RadioOrderLegacyFirst.BroadcastYear1 IsNot Nothing AndAlso RadioOrderLegacyFirst.FirstMonthYear1 IsNot Nothing AndAlso RadioOrderLegacyFirst.LastMonthYear1 IsNot Nothing Then

                    For Months As Integer = RadioOrderLegacyFirst.FirstMonthYear1 To RadioOrderLegacyFirst.LastMonthYear1

                        If Not MonthNameList.Contains(MonthName(Months, True).ToUpper) Then

                            MonthNameList.Add(MonthName(Months, True).ToUpper)

                        End If

                    Next

                End If

                If RadioOrderLegacyFirst.BroadcastYear2 IsNot Nothing AndAlso RadioOrderLegacyFirst.FirstMonthYear2 IsNot Nothing AndAlso RadioOrderLegacyFirst.LastMonthYear2 IsNot Nothing Then

                    For Months As Integer = RadioOrderLegacyFirst.FirstMonthYear2 To RadioOrderLegacyFirst.LastMonthYear2

                        If Not MonthNameList.Contains(MonthName(Months, True).ToUpper) Then

                            MonthNameList.Add(MonthName(Months, True).ToUpper)

                        End If

                    Next

                End If

            End If

            GetMonthsByOrderNumber = MonthNameList

        End Function
        Public Function GetYearsByOrderNumberMonth(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, Month As String) As List(Of Int16)

            Dim RadioOrderLegacyFirst As AdvantageFramework.Database.Entities.RadioOrderLegacy = Nothing
            Dim YearList As List(Of Int16) = Nothing
            Dim MonthNumber As Short = Nothing

            For MonthNumber = 1 To 12

                If MonthName(MonthNumber, True).ToUpper = Month Then

                    Exit For

                End If

            Next

            YearList = New List(Of Short)

            Try

                RadioOrderLegacyFirst = (From RadioOrderLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderLegacy)
                                         Where RadioOrderLegacy.OrderNumber = OrderNumber AndAlso
                                               RadioOrderLegacy.FirstMonthYear1 <= MonthNumber AndAlso
                                               RadioOrderLegacy.LastMonthYear1 >= MonthNumber
                                         Order By RadioOrderLegacy.RevisionNumber Descending
                                         Select RadioOrderLegacy).FirstOrDefault

                If RadioOrderLegacyFirst.BroadcastYear1 IsNot Nothing Then

                    If Not YearList.Contains(RadioOrderLegacyFirst.BroadcastYear1) Then

                        YearList.Add(RadioOrderLegacyFirst.BroadcastYear1)

                    End If

                End If

            Catch ex As Exception
                RadioOrderLegacyFirst = Nothing
            End Try

            Try

                RadioOrderLegacyFirst = (From RadioOrderLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderLegacy)
                                         Where RadioOrderLegacy.OrderNumber = OrderNumber AndAlso
                                               RadioOrderLegacy.FirstMonthYear2 <= MonthNumber AndAlso
                                               RadioOrderLegacy.LastMonthYear2 >= MonthNumber
                                         Order By RadioOrderLegacy.RevisionNumber Descending
                                         Select RadioOrderLegacy).FirstOrDefault

                If RadioOrderLegacyFirst.BroadcastYear2 Then

                    If Not YearList.Contains(RadioOrderLegacyFirst.BroadcastYear2) Then

                        YearList.Add(RadioOrderLegacyFirst.BroadcastYear2)

                    End If

                End If

            Catch ex As Exception
                RadioOrderLegacyFirst = Nothing
            End Try

            GetYearsByOrderNumberMonth = YearList

        End Function

#End Region

    End Module

End Namespace
