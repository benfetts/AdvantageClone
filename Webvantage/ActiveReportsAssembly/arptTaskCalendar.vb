Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports Webvantage.TaskCalendar


Public Class arptTaskCalendar
    Public dt As DataTable
    Public client As String
    Public division As String
    Public product As String
    Public year As String
    Public month As String
    Public logopath As String
    Public reportTitle As String
    Public imgPath As String
    Public type As String
    Public placement As String
    Public groupLevel As String
    Public SchCommentIncl As String
    Public StatusIncl As String
    Public TaskIncl As String
    'Public HolidayIncl As String
    'Public ApptIncl As String
    Public mConnPath As String

    Private Sub arptTaskCalendar_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Select Case groupLevel
            Case 0
                Me.GroupHeader1.DataField = "dtlmonth"
            Case Else
                Me.GroupHeader1.DataField = "grouping"
        End Select

    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptTaskCalendar_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            Me.DataSource = dt
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim count As Integer = Me.Detail1.Controls.Count
        Dim sundayHeight As Single = Me.Sunday.Height
        Dim mondayHeight As Single = Me.Monday.Height
        Dim tuesdayHeight As Single = Me.Tuesday.Height
        Dim wednesdayHeight As Single = Me.Wednesday.Height
        Dim thursdayHeight As Single = Me.Thursday.Height
        Dim fridayHeight As Single = Me.Friday.Height
        Dim saturdayHeight As Single = Me.Saturday.Height
        Dim maxHeight As Single = 0.0
        Dim maxColumn As String

        If sundayHeight > mondayHeight And sundayHeight > tuesdayHeight And sundayHeight > wednesdayHeight And sundayHeight > thursdayHeight And sundayHeight > fridayHeight And sundayHeight > saturdayHeight Then
            maxHeight = sundayHeight
            maxColumn = "sunday"
        End If
        If mondayHeight > sundayHeight And mondayHeight > tuesdayHeight And mondayHeight > wednesdayHeight And mondayHeight > thursdayHeight And mondayHeight > fridayHeight And mondayHeight > saturdayHeight Then
            maxHeight = mondayHeight
            maxColumn = "monday"
        End If
        If tuesdayHeight > mondayHeight And tuesdayHeight > sundayHeight And tuesdayHeight > wednesdayHeight And tuesdayHeight > thursdayHeight And tuesdayHeight > fridayHeight And tuesdayHeight > saturdayHeight Then
            maxHeight = tuesdayHeight
            maxColumn = "tuesday"
        End If
        If wednesdayHeight > mondayHeight And wednesdayHeight > tuesdayHeight And wednesdayHeight > sundayHeight And wednesdayHeight > thursdayHeight And wednesdayHeight > fridayHeight And wednesdayHeight > saturdayHeight Then
            maxHeight = wednesdayHeight
            maxColumn = "wednesday"
        End If
        If thursdayHeight > mondayHeight And thursdayHeight > tuesdayHeight And thursdayHeight > wednesdayHeight And thursdayHeight > sundayHeight And thursdayHeight > fridayHeight And thursdayHeight > saturdayHeight Then
            maxHeight = thursdayHeight
            maxColumn = "thursday"
        End If
        If fridayHeight > mondayHeight And fridayHeight > tuesdayHeight And fridayHeight > wednesdayHeight And fridayHeight > thursdayHeight And fridayHeight > sundayHeight And fridayHeight > saturdayHeight Then
            maxHeight = fridayHeight
            maxColumn = "friday"
        End If
        If saturdayHeight > mondayHeight And saturdayHeight > tuesdayHeight And saturdayHeight > wednesdayHeight And saturdayHeight > thursdayHeight And saturdayHeight > fridayHeight And saturdayHeight > sundayHeight Then
            maxHeight = saturdayHeight
            maxColumn = "saturday"
        End If

        If maxHeight <> 0.0 Then
            Me.Sunday.Height = maxHeight
            Me.Monday.Height = maxHeight
            Me.Tuesday.Height = maxHeight
            Me.Wednesday.Height = maxHeight
            Me.Thursday.Height = maxHeight
            Me.Friday.Height = maxHeight
            Me.Saturday.Height = maxHeight
        End If
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.Sunday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Sunday.Border.TopStyle = BorderLineStyle.Solid
        Me.Sunday.Border.RightStyle = BorderLineStyle.Solid
        Me.Sunday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Monday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Monday.Border.TopStyle = BorderLineStyle.Solid
        Me.Monday.Border.RightStyle = BorderLineStyle.Solid
        Me.Monday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Tuesday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Tuesday.Border.TopStyle = BorderLineStyle.Solid
        Me.Tuesday.Border.RightStyle = BorderLineStyle.Solid
        Me.Tuesday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Wednesday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Wednesday.Border.TopStyle = BorderLineStyle.Solid
        Me.Wednesday.Border.RightStyle = BorderLineStyle.Solid
        Me.Wednesday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Thursday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Thursday.Border.TopStyle = BorderLineStyle.Solid
        Me.Thursday.Border.RightStyle = BorderLineStyle.Solid
        Me.Thursday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Friday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Friday.Border.TopStyle = BorderLineStyle.Solid
        Me.Friday.Border.RightStyle = BorderLineStyle.Solid
        Me.Friday.Border.LeftStyle = BorderLineStyle.Solid
        Me.Saturday.Border.BottomStyle = BorderLineStyle.Solid
        Me.Saturday.Border.TopStyle = BorderLineStyle.Solid
        Me.Saturday.Border.RightStyle = BorderLineStyle.Solid
        Me.Saturday.Border.LeftStyle = BorderLineStyle.Solid

    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        If logopath <> "" Then
            Dim f As New IO.FileInfo(logopath)
            If f.Exists Then
                Me.Picture1.Image = Drawing.Image.FromFile(logopath)
            Else
                Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
            End If
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        If reportTitle <> "" Then
            Me.TBTitle.Text = reportTitle
        Else
            Me.TBTitle.Text = "Calendar Report"
        End If

        Select Case placement
            Case "right"
                Me.TBTitle.Alignment = TextAlignment.Right
            Case "left"
                Me.TBTitle.Alignment = TextAlignment.Left
            Case "center"
                Me.TBTitle.Alignment = TextAlignment.Center
            Case Else
                Me.TBTitle.Alignment = TextAlignment.Center
        End Select

    End Sub

    Private Function getTrfComment(ByVal job As Integer, ByVal comp As Integer) As String
        Dim comment As String
        Dim cCal As New TaskCalendar.cCalendar(mConnPath)

        comment = cCal.getTrfComment(job, comp)

        Return comment

    End Function

    Private Function getMonthName(ByVal monthNbr As String) As String
        Dim _month As String

        Select Case Me.dtlmonth.Text
            Case "1"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "janvier"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "enero"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "一月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Januar"
                Else
                    _month = "January"
                End If
            Case "2"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "février"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "febrero"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "二月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Februar"
                Else
                    _month = "February"
                End If
            Case "3"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "mars"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "marzo"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "三月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "März"
                Else
                    _month = "March"
                End If
            Case "4"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "avril"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "abril"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "四月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "April"
                Else
                    _month = "April"
                End If
            Case "5"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "mai"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "mayo"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "五月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Mai"
                Else
                    _month = "May"
                End If
            Case "6"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "juin"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "junio"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "六月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Juni"
                Else
                    _month = "June"
                End If
            Case "7"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "juillet"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "julio"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "七月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Juli"
                Else
                    _month = "July"
                End If
            Case "8"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "aout"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "agosto"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "八月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "August"
                Else
                    _month = "August"
                End If
            Case "9"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "septembre"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "septiembre"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "九月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "September"
                Else
                    _month = "September"
                End If
            Case "10"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "octobre"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "octubre"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "十月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Oktober"
                Else
                    _month = "October"
                End If
            Case "11"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "novembre"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "noviembre"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "十一月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "November"
                Else
                    _month = "November"
                End If
            Case "12"
                If ReportFunctions.UserCultureGet() = "fr-FR" Then
                    _month = "decembre"
                ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                    _month = "diciembre"
                ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                    _month = "十二月"
                ElseIf ReportFunctions.UserCultureGet() = "de" Then
                    _month = "Dezember"
                Else
                    _month = "December"
                End If

        End Select

        Return _month

    End Function

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            Dim _month As String
            Dim job, comp As String

            _month = getMonthName(Me.dtlmonth.Text)

            Me.MonthYear.Text = _month & " " & Me.dtlyear.Text
            Me.ClientCode.Text = Me.dtlclientdesc.Text
            Me.DivisionCode.Text = Me.dtldivdesc.Text
            Me.ProductCode.Text = Me.dtlprddesc.Text
            Me.tbJob.Text = Me.dtljob.Text.PadLeft(6, "0") & " - " & Me.dtljobdesc.Text
            Me.tbComponent.Text = Me.dtlcomp.Text.PadLeft(2, "0") & " - " & Me.dtlcompdesc.Text
            Me.status.Text = Me.dtltrfdesc.Text
            job = Me.dtljob.Text
            comp = Me.dtlcomp.Text
            If job <> "" And comp <> "" Then
                Me.schComment.Text = getTrfComment(CInt(Me.dtljob.Text), CInt(Me.dtlcomp.Text))
            End If

            'Set header text according to Group Level
            If groupLevel = 0 Or TaskIncl = False Then  ' Month grouping

                Me.ClientCode.Text = ""
                Me.DivisionCode.Text = ""
                Me.ProductCode.Text = ""
                Me.tbJob.Text = ""
                Me.tbComponent.Text = ""
                Me.status.Text = ""
                Me.schComment.Text = ""
                Me.lblClient.Text = ""
                Me.lblDivision.Text = ""
                Me.lblProduct.Text = ""
                Me.lblJob.Text = ""
                Me.lblComponent.Text = ""
                Me.lblStatus.Text = ""
                Me.lblSchComment.Text = ""

            ElseIf groupLevel = 1 Then  ' Client grouping

                Me.DivisionCode.Text = ""
                Me.ProductCode.Text = ""
                Me.tbJob.Text = ""
                Me.tbComponent.Text = ""
                Me.status.Text = ""
                Me.schComment.Text = ""

                Me.lblDivision.Text = ""
                Me.lblProduct.Text = ""
                Me.lblJob.Text = ""
                Me.lblComponent.Text = ""
                Me.lblStatus.Text = ""
                Me.lblSchComment.Text = ""

            ElseIf groupLevel = 2 Then  'Cl/Div grouping
                Me.ProductCode.Text = ""
                Me.tbJob.Text = ""
                Me.tbComponent.Text = ""
                Me.status.Text = ""
                Me.schComment.Text = ""

                Me.lblProduct.Text = ""
                Me.lblJob.Text = ""
                Me.lblComponent.Text = ""
                Me.lblStatus.Text = ""
                Me.lblSchComment.Text = ""

            ElseIf groupLevel = 3 Then  'Cl/Div/Prd grouping
                Me.tbJob.Text = ""
                Me.tbComponent.Text = ""
                Me.status.Text = ""
                Me.schComment.Text = ""

                Me.lblJob.Text = ""
                Me.lblComponent.Text = ""
                Me.lblStatus.Text = ""
                Me.lblSchComment.Text = ""

            ElseIf groupLevel = 4 Then  'Cl/Div/Prd/Job grouping
                Me.tbComponent.Text = ""
                Me.status.Text = ""
                Me.schComment.Text = ""

                Me.lblComponent.Text = ""
                Me.lblStatus.Text = ""
                Me.lblSchComment.Text = ""

            ElseIf groupLevel = 5 Then  'Cl/Div/Prd/Job/Comp grouping (Show ALL)

            End If

            If SchCommentIncl = "0" Then
                Me.schComment.Text = ""
                Me.lblSchComment.Text = ""
            End If

            If StatusIncl = "0" Then
                Me.status.Text = ""
                Me.lblStatus.Text = ""
            End If

            If ReportFunctions.UserCultureGet() = "fr-FR" Then
                Me.TextBox1.Text = "dimanche"
                Me.TextBox3.Text = "lundi"
                Me.TextBox4.Text = "mardi"
                Me.TextBox5.Text = "mercredi"
                Me.ThursdayTxt.Text = "jeudi"
                Me.FridayTxt.Text = "vendredi"
                Me.SaturdayTxt.Text = "samedi"
            ElseIf ReportFunctions.UserCultureGet() = "es-ES" Then
                Me.TextBox1.Text = "domingo"
                Me.TextBox3.Text = "lunes"
                Me.TextBox4.Text = "martes"
                Me.TextBox5.Text = "miércoles"
                Me.ThursdayTxt.Text = "jueves"
                Me.FridayTxt.Text = "viernes"
                Me.SaturdayTxt.Text = "sábado"
            ElseIf ReportFunctions.UserCultureGet() = "zh-CN" Then
                Me.TextBox1.Text = "星期日"
                Me.TextBox3.Text = "星期一"
                Me.TextBox4.Text = "星期二"
                Me.TextBox5.Text = "星期三"
                Me.ThursdayTxt.Text = "星期四"
                Me.FridayTxt.Text = "星期五"
                Me.SaturdayTxt.Text = "星期六"
            ElseIf ReportFunctions.UserCultureGet() = "de" Then
                Me.TextBox1.Text = "sonntag"
                Me.TextBox3.Text = "montag"
                Me.TextBox4.Text = "dienstag"
                Me.TextBox5.Text = "mittwoch"
                Me.ThursdayTxt.Text = "donnerstag"
                Me.FridayTxt.Text = "freitag"
                Me.SaturdayTxt.Text = "samstag"
            Else
                Me.TextBox1.Text = "Sunday"
                Me.TextBox3.Text = "Monday"
                Me.TextBox4.Text = "Tuesday"
                Me.TextBox5.Text = "Wednesday"
                Me.ThursdayTxt.Text = "Thursday"
                Me.FridayTxt.Text = "Friday"
                Me.SaturdayTxt.Text = "Saturday"
            End If
        Catch ex As Exception

        End Try
        

    End Sub
End Class
