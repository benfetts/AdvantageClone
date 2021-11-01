Imports System.Drawing.Printing

Namespace Employee

    Public Class EmployeeExpenseReportReceipts

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _PrintApproverName As Boolean = False
        Private _ExcludeEmployeeSignature As Boolean = False
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
        Public Property PrintApproverName As Boolean
            Get
                PrintApproverName = _PrintApproverName
            End Get
            Set(value As Boolean)
                _PrintApproverName = value
            End Set
        End Property
        Public Property ExcludeEmployeeSignature As Boolean
            Get
                ExcludeEmployeeSignature = _ExcludeEmployeeSignature
            End Get
            Set(value As Boolean)
                _ExcludeEmployeeSignature = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint



        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)


        End Sub

        Private Sub PictureBoxReceipt_BeforePrint(sender As Object, e As PrintEventArgs)



        End Sub


#End Region

#End Region

    End Class

End Namespace
