Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports Webvantage
Imports System.Drawing

Public Class arptJobTrafficSchedulebyJobDays
    Public Agency As String
    Public dtTS As DataTable
    Public dtJob As DataTable
    Public dtAgency As DataTable
    Public connstring As String
    Public usercode As String
    Public imgPath As String
    Public hours As Integer
    Public due As Integer
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public excludeTC As Boolean
    Public excludephase As Boolean
    Public excluderesource As Boolean
    Public excludemilestone As Boolean
    Public excludetimedue As Boolean
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub 'New
    Public CultureCode As String = "en-US"

    Private Sub arptJobTrafficSchedulebyJob_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        If dtJob.Rows.Count > 0 Then
            Try
                If IsDBNull(dtJob.Rows(0)("ClientCode")) = False Then
                    Me.txtClCode.Text = dtJob.Rows(0)("ClientCode")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("ClientName")) = False Then
                    Me.txtClientName.Text = dtJob.Rows(0)("ClientName")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("DivisionCode")) = False Then
                    Me.txtDivCode.Text = dtJob.Rows(0)("DivisionCode")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("DivisionName")) = False Then
                    Me.txtDivisionName.Text = dtJob.Rows(0)("DivisionName")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("ProductCode")) = False Then
                    Me.txtPrdCode.Text = dtJob.Rows(0)("ProductCode")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("ProductName")) = False Then
                    Me.txtProductName.Text = dtJob.Rows(0)("ProductName")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("JobNumber")) = False Then
                    Me.txtJobNumber.Text = dtJob.Rows(0)("JobNumber")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("JobDescription")) = False Then
                    Me.txtJobDesc.Text = dtJob.Rows(0)("JobDescription")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("JobCompNumber")) = False Then
                    Me.txtComponent.Text = dtJob.Rows(0)("JobCompNumber")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("JobCompDescription")) = False Then
                    Me.txtCompDesc.Text = dtJob.Rows(0)("JobCompDescription")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("StatusCode")) = False Then
                    Me.txtStatus.Text = dtJob.Rows(0)("StatusCode")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("JobStatus")) = False Then
                    Me.txtStatusDesc.Text = dtJob.Rows(0)("JobStatus")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(dtJob.Rows(0)("TRFComments")) = False Then
                    Me.txtJobComments.Text = dtJob.Rows(0)("TRFComments")
                End If
            Catch ex As Exception
            End Try
        End If
        If Me.excludephase = True Then
            Me.GroupHeader1.DataField = ""
            Me.GroupHeader1.Visible = False
        End If

        Me.DataSource = dtTS
        Try
            'Me.lblAgency.Text = Agency
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            If Me.txtDueDate.Text <> "" Then
                'Dim duedate As DateTime = Convert.ToDateTime(Me.txtDueDate.Text)
                'Me.txtDueDate.Text = duedate.ToShortDateString
                'Me.txtDueDate.Text = Format(duedate, "MM/dd/yyy")
                Me.txtDueDate.Text = CDate(Me.txtDueDate.Text).ToShortDateString
            End If
            If Me.txtStartDate.Text <> "" Then
                'Dim startdate As DateTime = Convert.ToDateTime(Me.txtStartDate.Text)
                'Me.txtStartDate.Text = startdate.ToShortDateString
                'Me.txtStartDate.Text = Format(startdate, "MM/dd/yyy")
                Me.txtStartDate.Text = CDate(Me.txtStartDate.Text).ToShortDateString
            End If
            If Me.txtTaskComments.Text = "" Then
                Me.txtTaskComments.Visible = False
            Else
                Me.txtTaskComments.Visible = True
            End If
            If Me.txtMilestone.Text = "0" Then
                Me.txtMilestone.Text = ""
            End If
            If Me.txtMilestone.Text = "1" Then
                Me.txtMilestone.Text = "X"
            End If
            If hours = 0 Then
                Me.TextBoxHours.Text = ""
            End If
            If due = 1 Then
                Me.txtStartDate.Text = ""
            End If
            If excludeTC = True Then
                Me.txtTaskComments.Text = ""
            End If
            'If Me.excluderesource = True Then
            '    Me.txtDays.Text = ""
            'End If

            If Me.excludetimedue = True Then
                Me.txtTimeDue.Text = ""
            End If
            If Me.excludemilestone = True Then
                Me.txtMilestone.Text = ""
            End If

            If Me.txtTaskComments.Visible = True AndAlso Not String.IsNullOrWhiteSpace(Me.txtTaskComments.Text) Then

                Me.TxtSpacer.Location = New Drawing.PointF(Me.TxtSpacer.Location.X, Me.txtTaskComments.Location.Y + Me.txtTaskComments.Size.Height)

            Else

                Me.TxtSpacer.Location = New Drawing.PointF(Me.TxtSpacer.Location.X, Me.txtTaskComments.Location.Y)

            End If

            Dim HasChildrenField As Field = Me.Fields("HAS_CHILDREN")
            Dim TxtBoxControl As TextBox = Nothing
            Dim HeaderControl As ARControl = Nothing

            For Each TxtBoxControl In DirectCast(sender, Detail).Controls.OfType(Of TextBox)

                If TxtBoxControl Is txtMilestone Then

                    HeaderControl = lblMilestone

                ElseIf TxtBoxControl Is TextBoxHours Then

                    HeaderControl = LabelHours

                ElseIf TxtBoxControl Is txtDays Then

                    HeaderControl = lblDays

                ElseIf TxtBoxControl Is txtTimeDue Then

                    HeaderControl = lblTimeDue

                ElseIf TxtBoxControl Is txtDueDate Then

                    HeaderControl = lblDueDate

                ElseIf TxtBoxControl Is txtStartDate Then

                    HeaderControl = txtStartDatelbl

                ElseIf TxtBoxControl Is txtTask Then

                    txtTask.Width = lblTask.Width
                    HeaderControl = lblTask

                Else

                    HeaderControl = Nothing

                End If

                If HeaderControl IsNot Nothing Then

                    TxtBoxControl.Location = New Drawing.PointF(HeaderControl.Location.X, TxtBoxControl.Location.Y)

                End If

                If HasChildrenField IsNot Nothing AndAlso HasChildrenField.Value = True Then

                    TxtBoxControl.Font = New System.Drawing.Font(TxtBoxControl.Font, Drawing.FontStyle.Bold)

                Else

                    TxtBoxControl.Font = New System.Drawing.Font(TxtBoxControl.Font, Drawing.FontStyle.Regular)

                End If

            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub


    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            If Me.txtJobNumber.Text <> "" Then
                If Me.txtJobNumber.Text.Length = 1 Then
                    Me.txtJobNumber.Text = "00000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 2 Then
                    Me.txtJobNumber.Text = "0000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 3 Then
                    Me.txtJobNumber.Text = "000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 4 Then
                    Me.txtJobNumber.Text = "00" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 5 Then
                    Me.txtJobNumber.Text = "0" & Me.txtJobNumber.Text
                End If
            End If

            If Me.txtComponent.Text <> "" Then
                If Me.txtComponent.Text.Length = 1 Then
                    Me.txtComponent.Text = "0" & Me.txtComponent.Text
                End If
            End If

            If _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                    Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                        Dim bm As Bitmap

                        bm = New Bitmap(img)

                        Me.Picture1.Image = bm

                    End Using

                End Using

            Else

                If Me.LogoPath <> "" Then
                    Dim f As New IO.FileInfo(Me.LogoPath)
                    If f.Exists Then
                        Me.Picture1.Image = Drawing.Image.FromFile(Me.LogoPath)
                    Else
                        'Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                    End If
                Else
                    'Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If

            End If


            If Me.LogoID = "None" Then
                Me.PageHeader1.Visible = False
            End If

            Dim str3 As String
            If Me.dtAgency.Rows.Count > 0 And Me.LogoID <> "None" And Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then

                If Me.dtAgency.Rows(0)("PRT_NAME").ToString = "1" Then
                    If Me.dtAgency.Rows(0)("NAME").ToString <> "" Then
                        Me.txtAgencyName.Text = Me.dtAgency.Rows(0)("NAME")
                    Else
                        Me.txtAgencyName.Text = ""
                    End If
                Else
                    Me.txtAgencyName.Text = ""
                End If

                If Me.dtAgency.Rows(0)("PRT_ADDR1").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS1").ToString <> "" Then
                    str3 = Me.dtAgency.Rows(0)("ADDRESS1").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                    str3 = str3 & " • " & Me.dtAgency.Rows(0)("ADDRESS2").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                    str3 = str3 & " • " & Me.dtAgency.Rows(0)("CITY").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                    str3 = str3 & ", " & Me.dtAgency.Rows(0)("STATE").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                    str3 = str3 & "  " & Me.dtAgency.Rows(0)("ZIP").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtAgency.Rows(0)("PHONE").ToString <> "" Then
                    str3 = str3 & " • " & Me.dtAgency.Rows(0)("PHONE").ToString
                End If
                If Me.dtAgency.Rows(0)("PRT_FAX").ToString = "1" And Me.dtAgency.Rows(0)("FAX").ToString <> "" Then
                    str3 = str3 & " • " & Me.dtAgency.Rows(0)("FAX").ToString & " Fax"
                End If
                If Me.dtAgency.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtAgency.Rows(0)("EMAIL").ToString <> "" Then
                    str3 = str3 & " • " & Me.dtAgency.Rows(0)("EMAIL").ToString
                End If
                Me.txtAgencyInfo.Text = str3
            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            If hours = 0 Then
                Me.LabelHours.Text = ""
            End If
            If due = 1 Then
                Me.txtStartDatelbl.Text = ""
            End If
            If Me.excluderesource = True Then
                Me.lblDays.Text = ""
            End If
            If Me.excludemilestone = True Then
                Me.lblMilestone.Text = ""
            End If
            If Me.excludetimedue = True Then
                Me.lblTimeDue.Text = ""
            End If

            Dim HeaderControl As ARControl = Nothing
            Dim NextPositionX As Single? = Nothing
            Dim LastControl As ARControl = Nothing
            Dim Spacer As Single = 0.07

            For Each HeaderControl In (From Item In GroupHeader2.Controls.OfType(Of ARControl)
                                       Select Item
                                       Order By Item.Location.X Descending)

                If (TypeOf HeaderControl Is TextBox AndAlso Not String.IsNullOrWhiteSpace(DirectCast(HeaderControl, TextBox).Text)) OrElse
                    (TypeOf HeaderControl Is Label AndAlso Not String.IsNullOrWhiteSpace(DirectCast(HeaderControl, Label).Text)) Then

                    If LastControl Is Nothing Then

                        NextPositionX = Me.PrintWidth

                    End If

                    If HeaderControl Is lblTask Then

                        lblTask.Width = LastControl.Location.X - HeaderControl.Location.X - Spacer

                    Else

                        NextPositionX = NextPositionX - (HeaderControl.Size.Width + Spacer)

                        HeaderControl.Location = New Drawing.PointF(NextPositionX, HeaderControl.Location.Y)

                    End If

                    LastControl = HeaderControl

                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Try
            If Me.LogoPlacement = 1 Then
                Me.LabelHours.Alignment = TextAlignment.Left
            ElseIf Me.LogoPlacement = 2 Then
                Me.LabelHours.Alignment = TextAlignment.Center
            ElseIf Me.LogoPlacement = 3 Then
                Me.LabelHours.Alignment = TextAlignment.Right
            Else
                Me.LabelHours.Alignment = TextAlignment.Left
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
