Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI

Public Class JobTemplate_Update
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _HasItems As Boolean = False

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Function SplitFindAndReplaceComponentsToBatches(ByVal Components As String) As String()

        'objects
        Dim Batches As Generic.List(Of String) = Nothing
        Dim BatchComponents As Generic.List(Of String) = Nothing
        Dim SqlMax As Short = 8000

        If Components.Length > SqlMax Then

            Batches = New List(Of String)
            BatchComponents = New List(Of String)

            For Each Component In Components.Split("|")

                If (String.Join("|", BatchComponents).Length + Component.Length + 1) < SqlMax Then

                    BatchComponents.Add(Component)

                Else

                    Batches.Add(String.Join("|", BatchComponents))
                    BatchComponents.Clear()
                    BatchComponents.Add(Component)

                End If

            Next

            Batches.Add(String.Join("|", BatchComponents))

            Return Batches.ToArray

        Else

            Return {Components}

        End If

    End Function
    Private Function UpdateAccountExecutive(AccountExecutive As String, IsDefault As Boolean, Components As String, ByRef RowCount As Integer) As Boolean

        'objects
        Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
        Dim Updated As Boolean = False
        Dim Inserted As Boolean = False
        Dim AE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
        Dim AcctExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim ProductAccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
        Dim DefaultAE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Dim jobcomp() As String = ComponentBatch.Split("|")

                    For i As Integer = 0 To jobcomp.Count - 1
                        Dim job() As String = jobcomp(i).Split(",")

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                        If JobComponent IsNot Nothing Then

                            AE = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode, AccountExecutive)

                            If AE Is Nothing Then

                                If IsDefault = True Then

                                    ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                    For Each AccountExecutiveClass In ProductAccountExecutivesList
                                        If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                            DefaultAE = AccountExecutiveClass
                                        End If
                                    Next

                                    If DefaultAE IsNot Nothing Then
                                        DefaultAE.IsDefaultAccountExecutive = 0
                                        AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                    End If

                                    AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                    AcctExecutive.DbContext = DbContext

                                    AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                    AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                    AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                    AcctExecutive.EmployeeCode = AccountExecutive
                                    AcctExecutive.IsDefaultAccountExecutive = 1
                                    AcctExecutive.ManagementLevelID = 1

                                    Inserted = AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AcctExecutive)

                                Else

                                    AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                    AcctExecutive.DbContext = DbContext

                                    AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                    AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                    AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                    AcctExecutive.EmployeeCode = AccountExecutive
                                    AcctExecutive.IsDefaultAccountExecutive = 0
                                    AcctExecutive.ManagementLevelID = 1

                                    Inserted = AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AcctExecutive)

                                End If

                                If Inserted = True Then
                                    JobComponent.AccountExecutiveEmployeeCode = AcctExecutive.EmployeeCode
                                    AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)
                                End If

                            Else

                                If IsDefault = True And AE.IsDefaultAccountExecutive = 0 Then

                                    ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                    For Each AccountExecutiveClass In ProductAccountExecutivesList
                                        If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                            DefaultAE = AccountExecutiveClass
                                        End If
                                    Next

                                    If DefaultAE IsNot Nothing Then
                                        DefaultAE.IsDefaultAccountExecutive = 0
                                        AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                    End If


                                    AE.IsDefaultAccountExecutive = 1
                                    Updated = AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AE)
                                End If

                                JobComponent.AccountExecutiveEmployeeCode = AE.EmployeeCode
                                AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                            End If

                            RowCount += 1

                        End If

                    Next

                Next
            End Using


            Updated = True

        Catch ex As Exception
            Updated = False
            RowCount = 0
        End Try

        UpdateAccountExecutive = Updated

    End Function
    Private Function UpdateAlertGroup(AlertGroup As String, IsDefault As Boolean, Components As String, ByRef RowCount As Integer) As Boolean

        'objects
        Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
        Dim Updated As Boolean = False
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim AlertGroupClass As AdvantageFramework.Database.Entities.AlertGroup = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Dim jobcomp() As String = ComponentBatch.Split("|")

                    For i As Integer = 0 To jobcomp.Count - 1

                        Dim job() As String = jobcomp(i).Split(",")

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                        If JobComponent IsNot Nothing Then
                            JobComponent.AlertGroupCode = AlertGroup
                            AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)
                        End If

                        If IsDefault = True Then
                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode)

                            Product.ProductionAlertGroup = AlertGroup
                            AdvantageFramework.Database.Procedures.Product.Update(DbContext, Product)

                        End If

                        RowCount += 1

                    Next

                Next

            End Using

            Updated = True

        Catch ex As Exception
            Updated = False
            RowCount = 0
        End Try

        UpdateAlertGroup = Updated

    End Function


#Region " Controls "



#End Region

#Region " Page "

    Private Sub Job_Template_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Request.QueryString("update") = "AE" Then
                Me.PanelAE.Visible = True
                Me.PanelAlertGroup.Visible = False
            End If

            If Request.QueryString("update") = "AG" Then
                Me.PanelAE.Visible = False
                Me.PanelAlertGroup.Visible = True
            End If


            Me.hlAccountExecutive.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobupdate&control=" & Me.txtAccountExecutive.ClientID & "&type=empcode');return false;")
            Me.LinkButtonAlertGroup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobupdate&control=" & Me.TextBoxAlertGroup.ClientID & "&type=alertgroups');return false;")

        Else



        End If

    End Sub

    Private Sub RadToolBarUpdateJob_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarUpdateJob.ButtonClick
        Try
            Dim rowcount As Integer
            Dim Validator As Webvantage.cValidations = New cValidations(Me.SecuritySession.ConnectionString)
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing

            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim ComponentArray As String() = Nothing
            Dim Components As String = Request.QueryString("Components")

            If e.Item.Value = "UpdateAll" Then

                ComponentArray = Session("JT_FIND_REPLACE_COMPONENTS").Split("|")

            Else

                ComponentArray = Components.Split("|")

            End If

            Components = String.Join("|", ComponentArray)


            Select Case e.Item.Value
                Case "Update"

                    If PanelAE.Visible = True Then

                        If Components = "" Then
                            Me.ShowMessage("No jobs selected.")
                            Me.CloseThisWindow()
                            Exit Sub
                        End If

                        If Me.txtAccountExecutive.Text <> "" Then

                            If Validator.ValidateEmpCode(Me.txtAccountExecutive.Text) = False Then

                                Me.ShowMessage("Invalid Account Executive.")
                                Exit Sub

                            End If

                        Else

                            Me.ShowMessage("Account Executive is required.")
                            Exit Sub

                        End If

                        UpdateAccountExecutive(Me.txtAccountExecutive.Text, CheckboxDefaultAE.Checked, Components, rowcount)

                        Me.ShowMessage("Account Executive was updated for " & rowcount.ToString & " job(s)")

                    End If

                    If PanelAlertGroup.Visible = True Then

                        If Components = "" Then
                            Me.ShowMessage("No jobs selected.")
                            Me.CloseThisWindow()
                            Exit Sub
                        End If

                        If Me.TextBoxAlertGroup.Text <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, Me.TextBoxAlertGroup.Text).FirstOrDefault
                            End Using

                            If AlertGroup Is Nothing Then

                                Me.ShowMessage("Invalid Alert Group.")
                                Exit Sub

                            End If

                        Else

                            Me.ShowMessage("Alert Group is required.")
                            Exit Sub

                        End If
                        UpdateAlertGroup(Me.TextBoxAlertGroup.Text, CheckboxDefaultAlertGroup.Checked, Components, rowcount)

                        Me.ShowMessage("Alert Group was updated for " & rowcount.ToString & " job(s)")
                    End If

                    Me.CloseThisWindow()

                Case "UpdateAll"

                    If PanelAE.Visible = True Then
                        If Me.txtAccountExecutive.Text <> "" Then

                            If Validator.ValidateEmpCode(Me.txtAccountExecutive.Text) = False Then

                                Me.ShowMessage("Invalid Account Executive.")
                                Exit Sub

                            End If

                        Else

                            Me.ShowMessage("Account Executive is required.")
                            Exit Sub

                        End If

                        UpdateAccountExecutive(Me.txtAccountExecutive.Text, CheckboxDefaultAE.Checked, Components, rowcount)

                        Me.ShowMessage("Account Executive was updated for " & rowcount.ToString & " job(s)")

                    End If

                    If PanelAlertGroup.Visible = True Then
                        If Me.TextBoxAlertGroup.Text <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, Me.TextBoxAlertGroup.Text).FirstOrDefault
                            End Using

                            If AlertGroup Is Nothing Then

                                Me.ShowMessage("Invalid Alert Group.")
                                Exit Sub

                            End If

                        Else

                            Me.ShowMessage("Alert Group is required.")
                            Exit Sub

                        End If
                        UpdateAlertGroup(Me.TextBoxAlertGroup.Text, CheckboxDefaultAlertGroup.Checked, Components, rowcount)

                        Me.ShowMessage("Alert Group was updated for " & rowcount.ToString & " job(s)")
                    End If

                    Me.CloseThisWindow()

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region


#End Region

End Class