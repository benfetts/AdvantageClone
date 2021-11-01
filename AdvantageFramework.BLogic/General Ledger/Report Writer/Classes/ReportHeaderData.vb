Namespace GeneralLedger.ReportWriter.Classes

    Public Class ReportHeaderData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PostPeriodCode
            PostPeriodDescription
            PostPeriodLongDescription
            PostPeriodFiscalDescription
            PostPeriodYear
            PostPeriodMonth
            OfficeList
            DepartmentList
            ReportName
            CurrencyCode
        End Enum

#End Region

#Region " Variables "

        Private _PostPeriodCode As String = Nothing
        Private _PostPeriodDescription As String = Nothing
        Private _PostPeriodLongDescription As String = Nothing
        Private _PostPeriodFiscalDescription As String = Nothing
        Private _PostPeriodYear As String = Nothing
        Private _PostPeriodMonth As String = Nothing
        Private _OfficeList As String = Nothing
        Private _DepartmentList As String = Nothing
        Private _ReportName As String = Nothing
        Private _CurrencyCode As String = Nothing

#End Region

#Region " Properties "

        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        Public Property PostPeriodDescription() As String
            Get
                PostPeriodDescription = _PostPeriodDescription
            End Get
            Set(value As String)
                _PostPeriodDescription = value
            End Set
        End Property
        Public Property PostPeriodLongDescription() As String
            Get
                PostPeriodLongDescription = _PostPeriodLongDescription
            End Get
            Set(value As String)
                _PostPeriodLongDescription = value
            End Set
        End Property
        Public Property PostPeriodFiscalDescription() As String
            Get
                PostPeriodFiscalDescription = _PostPeriodFiscalDescription
            End Get
            Set(value As String)
                _PostPeriodFiscalDescription = value
            End Set
        End Property
        Public Property PostPeriodYear() As String
            Get
                PostPeriodYear = _PostPeriodYear
            End Get
            Set(value As String)
                _PostPeriodYear = value
            End Set
        End Property
        Public Property PostPeriodMonth() As String
            Get
                PostPeriodMonth = _PostPeriodMonth
            End Get
            Set(value As String)
                _PostPeriodMonth = value
            End Set
        End Property
        Public Property OfficeList() As String
            Get
                OfficeList = _OfficeList
            End Get
            Set(value As String)
                _OfficeList = value
            End Set
        End Property
        Public Property DepartmentList() As String
            Get
                DepartmentList = _DepartmentList
            End Get
            Set(value As String)
                _DepartmentList = value
            End Set
        End Property
        Public Property ReportName() As String
            Get
                ReportName = _ReportName
            End Get
            Set(value As String)
                _ReportName = value
            End Set
        End Property
        Public Property CurrencyCode() As String
            Get
                CurrencyCode = _CurrencyCode
            End Get
            Set(value As String)
                _CurrencyCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod, ByVal ReportName As String, ByVal OfficePresetsDataTable As System.Data.DataTable, ByVal DepartmentTeamPresetsDataTable As System.Data.DataTable,
                       CurrencyCode As String)

            Me.CurrencyCode = CurrencyCode

            If ReportPostPeriod IsNot Nothing Then

                Me.PostPeriodCode = ReportPostPeriod.Code
                Me.PostPeriodDescription = ReportPostPeriod.Description
                Me.PostPeriodLongDescription = "For Period Ending " & ReportPostPeriod.Description & ", " & ReportPostPeriod.Year
                Me.PostPeriodMonth = ReportPostPeriod.Description
                Me.PostPeriodYear = ReportPostPeriod.Year

                If ReportPostPeriod.Month.GetValueOrDefault(1) = 1 Then

                    Me.PostPeriodFiscalDescription = ReportPostPeriod.Month.GetValueOrDefault(1) & "st Period of Fiscal Year " & ReportPostPeriod.Year

                ElseIf ReportPostPeriod.Month.GetValueOrDefault(1) = 2 Then

                    Me.PostPeriodFiscalDescription = ReportPostPeriod.Month.GetValueOrDefault(1) & "nd Period of Fiscal Year " & ReportPostPeriod.Year

                ElseIf ReportPostPeriod.Month.GetValueOrDefault(1) = 3 Then

                    Me.PostPeriodFiscalDescription = ReportPostPeriod.Month.GetValueOrDefault(1) & "rd Period of Fiscal Year " & ReportPostPeriod.Year

                Else

                    Me.PostPeriodFiscalDescription = ReportPostPeriod.Month.GetValueOrDefault(1) & "th Period of Fiscal Year " & ReportPostPeriod.Year

                End If

            Else

                Me.PostPeriodCode = ""
                Me.PostPeriodDescription = ""
                Me.PostPeriodLongDescription = ""
                Me.PostPeriodMonth = ""
                Me.PostPeriodYear = ""
                Me.PostPeriodFiscalDescription = ""

            End If

            Me.ReportName = ReportName

            If OfficePresetsDataTable.Rows.Count > 0 Then

                Me.OfficeList = Join(OfficePresetsDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CStr(DR(OfficePresetFields.Name.ToString))).ToArray, ", ")

            Else

                Me.OfficeList = ""

            End If

            If DepartmentTeamPresetsDataTable.Rows.Count > 0 Then

                Me.DepartmentList = Join(DepartmentTeamPresetsDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CStr(DR(DepartmentTeamPresetFields.Description.ToString))).ToArray, ", ")

            Else

                Me.DepartmentList = ""

            End If


        End Sub

#End Region

    End Class

End Namespace