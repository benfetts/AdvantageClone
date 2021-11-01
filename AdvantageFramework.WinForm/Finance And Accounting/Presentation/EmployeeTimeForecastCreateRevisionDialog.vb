Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastCreateRevisionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeForecastOfficeDetailID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property EmployeeTimeForecastOfficeDetailID As Integer
            Get
                EmployeeTimeForecastOfficeDetailID = _EmployeeTimeForecastOfficeDetailID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeTimeForecastOfficeDetailID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID

        End Sub
        
#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmployeeTimeForecastOfficeDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastCreateRevisionDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastCreateRevisionDialog = Nothing

            EmployeeTimeForecastCreateRevisionDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastCreateRevisionDialog(EmployeeTimeForecastOfficeDetailID)

            ShowFormDialog = EmployeeTimeForecastCreateRevisionDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastCreateRevisionDialog.EmployeeTimeForecastOfficeDetailID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastCreateRevisionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, _EmployeeTimeForecastOfficeDetailID)

                If EmployeeTimeForecastOfficeDetail Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Create.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim NewEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim RevisionCreated As Boolean = False
            Dim UpdateEmployeeRates As Boolean = False
            Dim UpdateRevenueAmounts As Boolean = False
            Dim ExcludeHoursEntered As Boolean = False

            UpdateEmployeeRates = CheckBoxForm_UpdateEmployeeRates.Checked
            UpdateRevenueAmounts = CheckBoxForm_UpdateRevenueAmounts.Checked
            ExcludeHoursEntered = CheckBoxForm_ExcludeHoursEnteredInCopy.Checked

            Me.ShowWaitForm()
            Me.ShowWaitForm("Creating Employee Time Forecast Revision...")
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EmployeeTimeForecastOfficeDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetailWithOptions(DbContext, _EmployeeTimeForecastOfficeDetailID)

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        RevisionCreated = AdvantageFramework.EmployeeTimeForecast.CreateRevisionForEmployeeTimeForecastOfficeDetail(DbContext, Me.Session.ConnectionString, EmployeeTimeForecastOfficeDetail, NewEmployeeTimeForecastOfficeDetail, UpdateEmployeeRates, UpdateRevenueAmounts, ExcludeHoursEntered)

                    End If

                End Using

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
            Me.CloseWaitForm()

            If RevisionCreated Then

                _EmployeeTimeForecastOfficeDetailID = NewEmployeeTimeForecastOfficeDetail.ID

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Failed creating revision.")

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace