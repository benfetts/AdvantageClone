Namespace GeneralLedger.ReportWriter.Presentation.Classes

    Public Class ReportCommandHandler
        Implements DevExpress.XtraReports.UserDesigner.ICommandHandler

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _XRDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Type As Integer = 0
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = 0

#End Region

#Region " Properties "

        Public Property Type As Integer
            Get
                Type = _Type
            End Get
            Set(value As Integer)
                _Type = value
            End Set
        End Property
        Public Property Description As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property UserDefinedReportCategoryID As Nullable(Of Integer)
            Get
                UserDefinedReportCategoryID = _UserDefinedReportCategoryID
            End Get
            Set(value As Nullable(Of Integer))
                _UserDefinedReportCategoryID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal XrDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController, ByVal Session As AdvantageFramework.Security.Session)

            _XRDesignMdiController = XrDesignMdiController
            _Session = Session

        End Sub
        Public Overridable Function CanHandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.CanHandleCommand

            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.Delete Then

                CanHandleCommand = True
                useNextHandler = (_XRDesignMdiController.ActiveDesignPanel.GetSelectedComponents.OfType(Of DevExpress.XtraReports.UI.PageHeaderBand).Any = False)

            Else

                CanHandleCommand = False

            End If

        End Function
        Public Overridable Sub HandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal Args() As Object) Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.HandleCommand



        End Sub

#End Region

    End Class

End Namespace

