Namespace GeneralLedger

    Public Class AccountAllocationDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AccountAllocationType As AdvantageFramework.Database.Entities.AccountAllocationTypes = Nothing

#End Region

#Region " Properties "

        Public Property Session() As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            'objects
            Dim GLATrailer As AdvantageFramework.Database.Entities.GLATrailer = Nothing

            Try

                GLATrailer = DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Database.Entities.GLATrailer)).FirstOrDefault

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _AccountAllocationType = (From Entity In AdvantageFramework.Database.Procedures.GLAllocation.Load(DbContext)
                                              Where Entity.ID = GLATrailer.GLAllocationID
                                              Select Entity).SingleOrDefault.Type

                End Using

            Catch ex As Exception
                _AccountAllocationType = AdvantageFramework.Database.Entities.AccountAllocationTypes.Percentage
            End Try

        End Sub
        Private Sub TableCell_GLAccount_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableCell_GLAccount.BeforePrint

            'objects
            Dim GLATrailer As AdvantageFramework.Database.Entities.GLATrailer = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing
            Dim TableCellText As String = Nothing

            Try

                GLATrailer = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.GLATrailer)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    GeneralLedgerAccount = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext)
                                            Where Entity.Code = GLATrailer.GLAltCode
                                            Select Entity).SingleOrDefault

                End Using

                TableCellText = GeneralLedgerAccount.Code & " - " & GeneralLedgerAccount.Description

            Catch ex As Exception
                TableCellText = ""
            Finally
                TableCell_GLAccount.Text = TableCellText
            End Try

        End Sub
        Private Sub TableCell_Percent_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableCell_Percent.BeforePrint

            If _AccountAllocationType <> AdvantageFramework.Database.Entities.AccountAllocationTypes.Percentage Then

                TableCell_Percent.Text = ""

            End If

        End Sub
        Private Sub TableCell_NumberOfEmployees_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableCell_NumberOfEmployees.BeforePrint

            If _AccountAllocationType <> AdvantageFramework.Database.Entities.AccountAllocationTypes.NumberOfEmployees Then

                TableCell_NumberOfEmployees.Text = ""

            End If

        End Sub
        Private Sub TableCell_SquareFeet_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableCell_SquareFeet.BeforePrint

            If _AccountAllocationType <> AdvantageFramework.Database.Entities.AccountAllocationTypes.SquareFootage Then

                TableCell_SquareFeet.Text = ""

            End If

        End Sub

#End Region

#End Region
        
    End Class

End Namespace
