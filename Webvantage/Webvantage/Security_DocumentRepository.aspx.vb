Imports Telerik.Web.UI

Partial Public Class Security_DocumentRepository
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private MaxFileSize As Long = 500 'just temporary
    Private ShowRepositoryLimitStuff As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Protected Sub CanceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanceButton.Click
        Me.CloseThisWindow()
    End Sub
    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim FileSizeLimit As Long = 0
        Dim RepositorySizeLimit As Long = 0

        Try

            If Me.TxtFileSizeLimit.Text.Trim() = "" Then

                FileSizeLimit = -1

            Else

                Me.TxtFileSizeLimit.Text = Me.TxtFileSizeLimit.Text.Replace(",", "")

                If IsNumeric(Me.TxtFileSizeLimit.Text) = False Then

                    Me.ShowMessage("Invalid file size")
                    Exit Sub

                Else

                    FileSizeLimit = CType(Me.TxtFileSizeLimit.Text, Long)

                    If FileSizeLimit < 0 Then

                        FileSizeLimit = 0

                    End If
                    If FileSizeLimit > Me.MaxFileSize Then

                        FileSizeLimit = Me.MaxFileSize

                    End If
                End If
            End If
        Catch ex As Exception

            FileSizeLimit = -1

        End Try
        Try

            If Me.TxtRepositorySizeLimit.Text.Trim() = "" Then

                RepositorySizeLimit = -1

            Else

                Me.TxtRepositorySizeLimit.Text = Me.TxtRepositorySizeLimit.Text.Replace(",", "")

                If IsNumeric(Me.TxtRepositorySizeLimit.Text) = False Then

                    Me.ShowMessage("Invalid repository size")
                    Exit Sub

                Else

                    RepositorySizeLimit = CType(Me.TxtRepositorySizeLimit.Text, Long)

                    If RepositorySizeLimit < 0 Then

                        RepositorySizeLimit = 0

                    End If

                End If
            End If
        Catch ex As Exception

            RepositorySizeLimit = -1

        End Try
        Try

            Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))

            RepositorySecuritySettings.SaveSettings(Me.UNCPathTextBox.Text, Me.DomainTextBox.Text, Me.UserNameTextBox.Text,
                                                    AdvantageFramework.Security.Encryption.Encrypt(Me.PasswordTextBox.Text))

            Dim RepSettings As New DocumentRepository(Session("ConnString"))

            RepSettings.SaveRepositoryLimit(Math.Round(RepositorySizeLimit, 0))
            RepSettings.SaveFileSizeLimit(Math.Round(FileSizeLimit, 0))

        Catch ex As Exception

            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))

        End Try

        Me.LoadForm()

    End Sub

#End Region
#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
        Dim AppIsOnASP As Boolean = oApp.IsASPClient

        If AppIsOnASP = True Then

            Me.CloseThisWindow()

        Else

            If Not Me.IsPostBack And Not Me.IsCallback Then

                Me.PageTitle = "Document Repository Settings"
                Me.LoadForm()
                Me.LoadMissingExpenseThumbnailInfo()

            End If

        End If

    End Sub

#End Region

    Private Sub LoadForm()

        Dim d As New DocumentRepository(Session("ConnString"), True)
        Dim c As New AdvantageFramework.Web.Presentation.Colors

        Dim RepositoryMax As Double = d.RepositoryMax 'in bytes
        Dim RepositoryUsed As Double = d.RepositoryUsed 'in bytes

        Dim RepositoryMaxGB As Double = RepositoryMax / DocumentRepository.GB
        Dim RepositoryMaxMB As Double = RepositoryMax / DocumentRepository.MB

        Dim RepositoryUsedGB As Double = RepositoryUsed / DocumentRepository.GB
        Dim RepositoryUsedMB As Double = RepositoryUsed / DocumentRepository.MB

        Dim OverRepositoryLmt As Boolean = d.IsOverRepositoryLimitSet

        'Form:

        ShowRepositoryLimitStuff = True

        Me.LblFileSizeMax.Text = MaxFileSize.ToString()

        Me.TxtRepositorySizeLimit.Text = RepositoryMaxGB.ToString()

        Try

            If IsNumeric(Me.TxtRepositorySizeLimit.Text.Trim()) = True Then

                If CType(Me.TxtRepositorySizeLimit.Text.Trim(), Double) < 0 Then

                    Me.TxtRepositorySizeLimit.Text = ""

                End If

            End If

        Catch ex As Exception

            Me.TxtRepositorySizeLimit.Text = ""

        End Try

        'Currently using

        Me.LblRepositorySize.Text = FormatNumber(CType(RepositoryUsedMB, Double), 0, TriState.False) & " MB of " & RepositoryMaxGB.ToString() & " GB"

        'filesize limit:
        Dim fsz As Long = d.FileSizeMax
        Dim FileSizeMaxMB As Long = fsz / d.MB
        Me.TxtFileSizeLimit.Text = CType(FileSizeMaxMB, Double).ToString()

        Try
            If IsNumeric(Me.TxtFileSizeLimit.Text.Trim()) = True Then

                If CType(Me.TxtFileSizeLimit.Text.Trim(), Double) < 0 Then

                    Me.TxtFileSizeLimit.Text = ""

                End If

            End If
        Catch ex As Exception

            Me.TxtFileSizeLimit.Text = ""

        End Try
        If RepositoryMax < 0 Then

            With Me.LblRepositorySize

                .Text = "Repository is unlimited."

            End With

        Else

            If RepositoryUsed >= RepositoryMax Then

                With Me.LblRepositorySize

                    .CssClass = "CssRequired"
                    .Text &= " (Over limit!)"

                End With

            End If

        End If

        Me.UNCPathTextBox.Text = d.Path
        Me.DomainTextBox.Text = d.UserDomain
        Me.UserNameTextBox.Text = d.UserName
        Me.PasswordTextBox.Text = d.UserPassword

        ' Gauge
        If RepositoryUsedGB > 0 OrElse RepositoryMaxGB > 0 Then

            RepositoryMax = RepositoryMaxGB
            RepositoryUsed = RepositoryUsedGB

        Else

            RepositoryMax = RepositoryMaxMB
            RepositoryUsed = RepositoryUsedMB

        End If

        Me.RadRadialGaugeRepositoryUsed.Scale.Max = CType(RepositoryMax, Decimal)

        If RepositoryMax = 0 Then 'No Data

            Dim gr As New GaugeRange

            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Gray, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            Me.RadRadialGaugeRepositoryUsed.Pointer.Value = 0

        ElseIf RepositoryUsed >= RepositoryMax And OverRepositoryLmt = True Then 'Over limit

            Dim gr As New GaugeRange

            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            Me.RadRadialGaugeRepositoryUsed.Pointer.Value = CType(RepositoryUsed, Decimal)

        ElseIf RepositoryMax < 0 Then 'No limit on repository

            Dim gr As New GaugeRange

            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Green, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            Me.RadRadialGaugeRepositoryUsed.Scale.Max = CType(RepositoryUsed, Double)
            Me.RadRadialGaugeRepositoryUsed.Pointer.Value = CType(RepositoryUsed, Double)

        Else 'Normal usage

            Dim Quarter As Double = RepositoryMax / 4

            Dim gr As New GaugeRange
            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Green, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            gr.From = 0
            gr.To = Quarter
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            gr = Nothing
            gr = New GaugeRange
            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Yellow, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            gr.From = Quarter
            gr.To = Quarter * 2
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            gr = Nothing
            gr = New GaugeRange
            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Orange, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            gr.From = Quarter * 2
            gr.To = Quarter * 3
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

            gr = Nothing
            gr = New GaugeRange
            gr.Color = c.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
            gr.From = Quarter * 3
            gr.To = Quarter * 4
            Me.RadRadialGaugeRepositoryUsed.Scale.Ranges.Add(gr)

        End If

    End Sub

    Private Sub LoadMissingExpenseThumbnailInfo()

        Try

            Dim DocIDs As Generic.List(Of Integer) = Nothing
            DocIDs = Me.LoadMissingThumbnailDocumentIDs(True)

            If DocIDs IsNot Nothing AndAlso DocIDs.Count > 0 Then

                Me.LabelMissingExpenseThumbnailCount.Text = FormatNumber(DocIDs.Count, 0, TriState.False, TriState.False, TriState.True)
                Me.DivFixThumbnails.Visible = True

            Else

                Me.DivFixThumbnails.Visible = False

            End If

        Catch ex As Exception
            Me.DivFixThumbnails.Visible = False
        End Try

    End Sub
    Private Sub ButtonFixThumbnails_Click(sender As Object, e As EventArgs) Handles ButtonFixThumbnails.Click

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim DocIDs As Generic.List(Of Integer) = Nothing

                DocIDs = LoadMissingThumbnailDocumentIDs(False)

                If DocIDs IsNot Nothing AndAlso DocIDs.Count > 0 Then

                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        For Each DocumentID In DocIDs

                            Try

                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, DocumentID, Nothing)

                            Catch ex As Exception
                            End Try

                        Next

                        Me.LoadMissingExpenseThumbnailInfo()

                    End If

                End If

            End Using

        Catch ex As Exception
            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString))
        End Try

    End Sub

    Private Function LoadMissingThumbnailDocumentIDs(ByVal LoadAll As Boolean) As Generic.List(Of Integer)

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim SQL As String = "SELECT {0} A.DOCUMENT_ID FROM " &
                                    " (SELECT D.DOCUMENT_ID FROM DOCUMENTS D INNER JOIN EXPENSE_DOCS ED ON D.DOCUMENT_ID = ED.DOCUMENT_ID WHERE (UPPER(D.MIME_TYPE) LIKE '%IMAGE%') AND D.THUMBNAIL IS NULL " &
                                    "    UNION " &
                                    "  SELECT D.DOCUMENT_ID FROM DOCUMENTS D INNER JOIN EXPENSE_DETAIL_DOCS ED ON D.DOCUMENT_ID = ED.DOCUMENT_ID WHERE (UPPER(D.MIME_TYPE) LIKE '%IMAGE%') AND D.THUMBNAIL IS NULL " &
                                    " ) AS A ORDER BY A.DOCUMENT_ID DESC;"

                Return DbContext.Database.SqlQuery(Of Integer)(String.Format(SQL, If(LoadAll = True, "", "TOP 250"))).ToList

            End Using

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub Security_DocumentRepository_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Security_RepositorySettings)

    End Sub

#End Region

End Class
