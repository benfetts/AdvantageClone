Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class mediaCalReport

    Public dt As DataTable
    Public client As String
    Public division As String
    Public product As String
    Public year As String
    Public month As String
    Public logopath As String
    Public printtext As String
    Public imgPath As String
    Public type As String
    Public CultureCode As String = "en-US"

    Private Sub mediaCalReport_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Dim c As Integer = dt.Rows.Count
        Dim d As String = dt.Rows(0).Item(5).ToString
        Dim f As String = dt.Rows.Count
        Me.DataSource = dt
    End Sub

    Private Sub Detail1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.AfterPrint
        

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
        Else
            Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
        End If

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.MonthYear.Text = month & " " & year
        If client = "All Clients" Then
            Me.ClientCode.Text = ""
            Me.Label1.Visible = False
        Else
            If client.IndexOf("-") > -1 Then
                Me.ClientCode.Text = client.Substring(client.IndexOf("-")).Trim
                Me.Label1.Visible = True
            Else
                Me.ClientCode.Text = ""
                Me.Label1.Visible = False
            End If
        End If
        If division = "All Divisions" Then
            Me.DivisionCode.Text = ""
            Me.Label2.Visible = False
        Else
            If division.IndexOf("-") > -1 Then
                Me.DivisionCode.Text = division.Substring(division.IndexOf("-")).Trim
                Me.Label2.Visible = True
            Else
                Me.DivisionCode.Text = ""
                Me.Label2.Visible = False
            End If
        End If
        If product = "All Products" Then
            Me.ProductCode.Text = ""
            Me.Label3.Visible = False
        Else
            If product.IndexOf("-") > -1 Then
                Me.ProductCode.Text = product.Substring(product.IndexOf("-")).Trim
                Me.Label3.Visible = True
            Else
                Me.ProductCode.Text = ""
                Me.Label3.Visible = False
            End If
        End If
        Me.TextBox2.Text = printtext
        If type = "Traffic" Then
            Me.TextBox1.Text = "Media Traffic Calendar"
        End If
        If type = "Schedule" Then
            Me.TextBox1.Text = "Media Schedule"
        End If
        

    End Sub
End Class
