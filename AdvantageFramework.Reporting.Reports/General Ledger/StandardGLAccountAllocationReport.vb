Namespace GeneralLedger

    Public Class StandardGLAccountAllocationReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub StandardGLAccountAllocationReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelDetail_Account_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Account.BeforePrint

            'objects
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing
            Dim LabelText As String = ""

            Try

                GLAllocation = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Entities.GLAllocation)

                If GLAllocation IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLAllocation.GLAccountCode)

                        LabelText = GeneralLedgerAccount.Code & vbTab & GeneralLedgerAccount.Description

                    End Using

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelDetail_Account.Text = LabelText
            End Try

        End Sub
        Private Sub LabelDetail_Type_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Type.BeforePrint

            'objects
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing
            Dim LabelText As String = ""

            Try

                GLAllocation = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Entities.GLAllocation)

                If GLAllocation IsNot Nothing Then

                    Select Case GLAllocation.Type.GetValueOrDefault(1)

                        Case 1

                            LabelText = "Percentage"

                        Case 2

                            LabelText = "Square Footage"

                        Case 3

                            LabelText = "Number of Employees"

                    End Select

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelDetail_Type.Text = LabelText
            End Try

        End Sub
        Private Sub LabelDetail_TotalSquareFeet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_TotalSquareFeet.BeforePrint

            'objects
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing
            Dim LabelText As String = ""

            Try

                GLAllocation = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Entities.GLAllocation)

                If GLAllocation IsNot Nothing AndAlso GLAllocation.Type = 2 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            LabelText = (From Entity In AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationID(DbContext, GLAllocation.ID)
                                         Select Entity.GLAltAllocation).Sum.ToString

                        Catch ex As Exception
                            LabelText = ""
                        End Try

                    End Using

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelDetail_TotalSquareFeet.Text = LabelText
            End Try

        End Sub
        Private Sub LabelDetail_TotalNumberOfEmployees_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_TotalNumberOfEmployees.BeforePrint

            'objects
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing
            Dim LabelText As String = ""

            Try

                GLAllocation = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Entities.GLAllocation)

                If GLAllocation IsNot Nothing AndAlso GLAllocation.Type = 3 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            LabelText = (From Entity In AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationID(DbContext, GLAllocation.ID)
                                         Select Entity.GLAltAllocation).Sum.ToString

                        Catch ex As Exception
                            LabelText = ""
                        End Try

                    End Using

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelDetail_TotalNumberOfEmployees.Text = LabelText
            End Try

        End Sub
        Private Sub SubReport_AllocationDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles SubReport_AllocationDetails.BeforePrint

            'objects
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing

            Try

                GLAllocation = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.GLAllocation)

                DirectCast(SubReport_AllocationDetails.ReportSource, AdvantageFramework.Reporting.Reports.GeneralLedger.AccountAllocationDetailsSubReport).Session = _Session

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubReport_AllocationDetails.ReportSource.DataSource = AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationID(DbContext, GLAllocation.ID).ToList

                End Using

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
