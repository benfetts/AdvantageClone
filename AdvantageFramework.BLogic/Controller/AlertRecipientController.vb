Namespace Controller

    Public Class AlertRecipientController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AlertRecipientSourceType
            MediaRFPHeader
            OrderNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(MediaRFPHeaderIDs As IEnumerable(Of Integer), ExistingEmployeeCodes As Generic.List(Of String)) As AdvantageFramework.ViewModels.AlertRecipientViewModel

            Dim AlertIDs As IEnumerable(Of Integer) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.Load(DbContext)
                            Where MediaRFPHeaderIDs.Contains(Entity.ID) AndAlso
                                  Entity.AlertID.HasValue
                            Select Entity.AlertID.Value).ToArray

                Load = Load(DbContext, ExistingEmployeeCodes, AlertIDs)

            End Using

        End Function
        Public Function Load(DictionaryOrderNumbers As Dictionary(Of Integer, String), ExistingEmployeeCodes As Generic.List(Of String)) As AdvantageFramework.ViewModels.AlertRecipientViewModel

            Dim AlertIDs As Generic.List(Of Integer) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing

            AlertIDs = New Generic.List(Of Integer)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                OrderNumbers = DictionaryOrderNumbers.Where(Function(I) I.Value = "T").Select(Function(O) O.Key).ToArray

                AlertIDs.AddRange(From Entity In AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)
                                  Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                        Entity.AlertID.HasValue
                                  Select Entity.AlertID.Value)

                OrderNumbers = DictionaryOrderNumbers.Where(Function(I) I.Value = "R").Select(Function(O) O.Key).ToArray

                AlertIDs.AddRange(From Entity In AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)
                                  Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                        Entity.AlertID.HasValue
                                  Select Entity.AlertID.Value)

                Load = Load(DbContext, ExistingEmployeeCodes, AlertIDs)

            End Using

        End Function
        Private Function Load(DbContext As AdvantageFramework.Database.DbContext, ExistingEmployeeCodes As Generic.List(Of String), AlertIDs As IEnumerable(Of Integer)) As AdvantageFramework.ViewModels.AlertRecipientViewModel

            'objects
            Dim AlertRecipientViewModel As AdvantageFramework.ViewModels.AlertRecipientViewModel = Nothing
            Dim AlertController As AdvantageFramework.Controller.Desktop.AlertController = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing

            AlertRecipientViewModel = New AdvantageFramework.ViewModels.AlertRecipientViewModel

            If ExistingEmployeeCodes IsNot Nothing Then

                EmployeeCodes = ExistingEmployeeCodes

            Else

                EmployeeCodes = New Generic.List(Of String)

            End If

            AlertRecipientViewModel.Employees.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                       Where Entity.AlertNotificationType = 2 OrElse
                                                             Entity.AlertNotificationType = 3
                                                       Select Entity)

            AlertRecipientViewModel.DistinctAlertGroups.AddRange(AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList)
            AlertRecipientViewModel.AlertGroups.AddRange(AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext).ToList)

            If AlertIDs.Count > 0 Then

                AlertController = New AdvantageFramework.Controller.Desktop.AlertController(Me.Session)

                For Each AlertID In AlertIDs

                    EmployeeCodes.AddRange(From Entity In AlertController.LoadAlertRecipients(DbContext, AlertID)
                                           Where Entity.EmployeeCode <> Session.User.EmployeeCode AndAlso
                                                 Entity.IsCurrentRecipient = True
                                           Select Entity.EmployeeCode)

                Next

            End If

            AlertRecipientViewModel.SelectedEmployees = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                         Where EmployeeCodes.Contains(Entity.Code)
                                                         Select Entity).Distinct.ToList

            Load = AlertRecipientViewModel

        End Function

#End Region

    End Class

End Namespace
