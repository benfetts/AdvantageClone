Imports AdvantageFramework.AlertSystem
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web
Imports Telerik.Web.UI

Namespace Web.Presentation.Controls

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum StandardColor

            Red
            Pink
            Purple
            DeepPurple
            Indigo
            Blue
            LightBlue
            Cyan
            Teal
            Green
            LightGreen
            Lime
            Yellow
            Amber
            LightOrange
            Orange
            DeepOrange
            Brown
            LightGrey
            Grey
            DarkGrey
            BlueGrey
            Black
            White
            Invisible

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub SetJobInfoForControl(ByRef ControlText As String, ByRef ControlToolTip As String,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                        ByVal JobDescription As String, ByVal JobComponentDescription As String,
                                        ByVal ShowJobNumber As Boolean, ByVal ShowJobComponentNumber As Boolean,
                                        ByVal ShowJobDescription As Boolean, ByVal ShowJobComponentDescription As Boolean,
                                        ByVal Truncate As Boolean)

            Try

                Dim TextStringBuilder As New System.Text.StringBuilder
                Dim ToolTipStringBuilder As New System.Text.StringBuilder

                If JobNumber > 0 Then

                    If ShowJobNumber = True Then

                        TextStringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                    Else

                        ShowJobNumber = False

                    End If

                    ToolTipStringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                End If
                If JobComponentNumber > 0 Then

                    If ShowJobComponentNumber = True Then

                        If ShowJobNumber = True Then

                            TextStringBuilder.Append("/")

                        End If

                        TextStringBuilder.Append(JobComponentNumber.ToString.PadLeft(2, "0"))

                    Else

                        ShowJobComponentNumber = False

                    End If

                    If JobNumber > 0 Then

                        ToolTipStringBuilder.Append("/")

                    End If

                    ToolTipStringBuilder.Append(JobComponentNumber.ToString.PadLeft(2, "0"))

                End If

                If (ShowJobNumber = True OrElse ShowJobComponentNumber = True) AndAlso (ShowJobDescription = True OrElse ShowJobComponentDescription = True) Then

                    TextStringBuilder.Append(" - ")

                End If

                ToolTipStringBuilder.Append(" - ")

                If ShowJobDescription = True AndAlso ShowJobComponentDescription = True Then

                    If String.Equals(JobDescription.ToUpper.Trim, JobComponentDescription.ToUpper.Trim) = True Then

                        TextStringBuilder.Append(JobComponentDescription)

                    Else

                        If String.IsNullOrEmpty(JobDescription) = False Then

                            TextStringBuilder.Append(JobDescription)

                        Else

                            ShowJobDescription = False

                        End If
                        If String.IsNullOrEmpty(JobComponentDescription) = False Then

                            If ShowJobDescription = True Then

                                TextStringBuilder.Append("<br />")

                            End If

                            TextStringBuilder.Append(JobComponentDescription)

                        End If

                    End If

                Else

                    If ShowJobDescription = True AndAlso String.IsNullOrEmpty(JobDescription) = False Then

                        TextStringBuilder.Append(JobDescription)

                    End If
                    If ShowJobComponentDescription = True AndAlso String.IsNullOrEmpty(JobComponentDescription) = False Then

                        TextStringBuilder.Append(JobComponentDescription)

                    End If

                End If

                Dim ToolTipHasJobDescription As Boolean = False
                If String.IsNullOrEmpty(JobDescription) = False AndAlso String.IsNullOrEmpty(JobComponentDescription) = False Then

                    If String.Equals(JobDescription.ToUpper.Trim, JobComponentDescription.ToUpper.Trim) = True Then

                        ToolTipStringBuilder.Append(JobComponentDescription)

                    Else

                        If String.IsNullOrEmpty(JobDescription) = False Then

                            ToolTipStringBuilder.Append(JobDescription)

                        End If
                        If String.IsNullOrEmpty(JobComponentDescription) = False Then

                            ToolTipStringBuilder.Append(", ")
                            ToolTipStringBuilder.Append(JobComponentDescription)

                        End If

                    End If

                End If

                ControlText = TextStringBuilder.ToString
                ControlToolTip = ToolTipStringBuilder.ToString

                If Truncate = True Then

                    ControlText = AdvantageFramework.StringUtilities.Truncate(ControlText, 35)

                End If

            Catch ex As Exception
                ControlText = String.Empty
                ControlToolTip = String.Empty
            End Try

        End Sub
        Public Sub SetRadGridExcelExportSettings(ByRef RadGrid As Telerik.Web.UI.RadGrid,
                                                 Optional ByVal Filename As String = "",
                                                 Optional ByVal BiffFormat As Boolean = False,
                                                 Optional ByVal ExportOnlyData As Boolean = True)

            If String.IsNullOrWhiteSpace(Filename) = False Then

                RadGrid.ExportSettings.FileName = Filename

            Else

                RadGrid.ExportSettings.FileName = "Webvantage_Excel_Export"

            End If

            RadGrid.ExportSettings.ExportOnlyData = ExportOnlyData

            If BiffFormat = True Then

                RadGrid.ExportSettings.Excel.Format = GridExcelExportFormat.Biff

            Else

                'RadGrid.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML

            End If

            RadGrid.ExportSettings.OpenInNewWindow = True

            'disable paging on the main grid for the export operation
            RadGrid.ExportSettings.IgnorePaging = True

            'expand detail tables
            RadGrid.MasterTableView.HierarchyDefaultExpanded = True

            Try

                If RadGrid.MasterTableView.DetailTables IsNot Nothing AndAlso RadGrid.MasterTableView.DetailTables.Count > 0 Then

                    For Each DetailTable In RadGrid.MasterTableView.DetailTables

                        DetailTable.HierarchyDefaultExpanded = True
                        DetailTable.AllowPaging = False

                    Next

                End If

            Catch ex As Exception
            End Try

            RadGrid.GridLines = GridLines.Both

        End Sub

        Public Sub RadComboBoxLoadDocumentTypeList(ByVal SecuritySession As AdvantageFramework.Security.Session, ByRef RadComboBox As Telerik.Web.UI.RadComboBox)

            Using dc = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim HasDefault As Boolean = False
                Dim OnlyOneType As Boolean = False
                Dim DocTypes As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType) = Nothing

                DocTypes = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(dc).ToList()

                If DocTypes IsNot Nothing Then

                    OnlyOneType = DocTypes.Count = 1

                    Dim item As RadComboBoxItem = Nothing

                    For Each DocType As AdvantageFramework.Database.Entities.DataContextDocumentType In DocTypes

                        item = New RadComboBoxItem
                        item.Text = DocType.Name
                        item.Value = DocType.ID

                        If (DocType.IsDefault = True AndAlso HasDefault = False) OrElse OnlyOneType = True Then

                            item.Selected = True
                            HasDefault = True

                        End If

                        RadComboBox.Items.Add(item)

                        item = Nothing

                    Next

                    If HasDefault = False Then

                        Dim PleaseSelectItem As New RadComboBoxItem

                        PleaseSelectItem.Text = "[Please select]"
                        PleaseSelectItem.Value = "0"
                        PleaseSelectItem.Selected = True

                        RadComboBox.Items.Insert(0, PleaseSelectItem)

                    End If

                End If

            End Using

        End Sub
        Public Sub SetDocumentEditPopUp(ByRef ImageButton As ImageButton, ByVal DocumentID As Integer, ByVal PageName As String)

            If ImageButton IsNot Nothing Then

                Dim _LabelsQuerystring As AdvantageFramework.Web.QueryString = Nothing

                _LabelsQuerystring = New AdvantageFramework.Web.QueryString
                _LabelsQuerystring.Page = "Document_Edit.aspx"
                _LabelsQuerystring.DocumentID = DocumentID

                ImageButton.ToolTip = "Click to edit document details"
                ImageButton.Attributes.Add("onclick", String.Format("OpenRadWindow('Comments','{0}', 0, 0, false, 0, 0, true,'{1}'); return false;", _LabelsQuerystring.ToString(True), PageName))

                _LabelsQuerystring = Nothing

            End If

        End Sub

        Public Function SetCalenderItemTimeSpan(ByVal CalendarItem As AdvantageFramework.Database.Classes.CalendarItem, ByRef TotalHoursDisplay As String) As String

            Dim TimeDisplay As String = ""
            Dim TypeCode As String = CalendarItem.NON_TASK_TYPE.ToString().Trim().ToUpper()
            Dim StartDate As String = ""
            Dim EndDate As String = ""

            If CalendarItem.START_DATE IsNot Nothing AndAlso IsDate(CalendarItem.START_DATE) Then

                StartDate = CType(CalendarItem.START_DATE, Date).ToShortDateString()

            End If
            If CalendarItem.END_DATE IsNot Nothing AndAlso IsDate(CalendarItem.END_DATE) Then

                EndDate = CType(CalendarItem.END_DATE, Date).ToShortDateString()

            End If
            If TypeCode <> "T" Then

                If CalendarItem.NUM_DAYS > 2 Then

                    'TimeDisplay = "Multiple Days (" & Me._CalendarItem.NUM_DAYS.ToString() & ")"

                    If StartDate <> "" AndAlso EndDate <> "" Then

                        TimeDisplay = StartDate & " to " & EndDate

                    ElseIf StartDate <> "" AndAlso EndDate = "" Then

                        TimeDisplay = "Starts: " & StartDate

                    ElseIf StartDate = "" AndAlso EndDate <> "" Then

                        TimeDisplay = "Due: " & EndDate

                    End If

                ElseIf CalendarItem.ALL_DAY = 1 Then

                    'TimeDisplay = "All Day"
                    TotalHoursDisplay = "All Day"

                Else

                    TimeDisplay = CType(CalendarItem.START_TIME, Date).ToShortTimeString().Replace(":00", "").Replace(":", ".").Replace(" AM", "a").Replace(" PM", "p") &
                                  " to " &
                                  CType(CalendarItem.END_TIME, Date).ToShortTimeString().Replace(":00", "").Replace(":", ".").Replace(" AM", "a").Replace(" PM", "p")

                    Dim s As Date = CType(CalendarItem.START_TIME, Date)
                    Dim ed As Date = CType(CalendarItem.END_TIME, Date)
                    Dim Diff As Long = 0

                    Diff = DateDiff(DateInterval.Hour, s, ed)

                    If Diff > 0 Then

                        If Diff = 1 Then

                            TotalHoursDisplay = Diff.ToString() & " hour"

                        Else

                            TotalHoursDisplay = Diff.ToString() & " hours"

                        End If

                    Else

                        Diff = DateDiff(DateInterval.Minute, s, ed)
                        If Diff = 1 Then

                            TotalHoursDisplay = Diff.ToString() & " minute"

                        Else

                            TotalHoursDisplay = Diff.ToString() & " minutes"

                        End If

                    End If

                End If


            Else 'It is a task

                If StartDate <> "" AndAlso EndDate <> "" Then

                    If StartDate = Today.ToShortDateString() Then StartDate = "Today"
                    If EndDate = Today.ToShortDateString() Then EndDate = "Today"

                    If StartDate = EndDate Then

                        TimeDisplay = StartDate

                    Else

                        TimeDisplay = StartDate & " to " & EndDate

                    End If

                ElseIf StartDate <> "" And EndDate = "" Then

                    TimeDisplay = "Starts: " & StartDate

                ElseIf StartDate = "" And EndDate <> "" Then

                    TimeDisplay = "Due: " & EndDate

                End If

                'If Me._CalendarItem.END_DATE IsNot Nothing AndAlso IsDate(Me._CalendarItem.END_DATE) AndAlso CDate(Me._CalendarItem.END_DATE).ToShortDateString() = Now.Date.ToShortDateString() Then

                '    TimeDisplay = "Due Today!"

                'End If

            End If

            Return TimeDisplay

        End Function

        Public Sub SetDue(ByVal DueDate As Date, ByVal DateTextColumnName As String, ByRef GridRow As GridDataItem)

            Try

                Dim TodaysDate As Date = CType(Now.Date.ToShortDateString, Date)
                Dim DatePastAWeek As Date = TodaysDate.AddDays(7)
                Dim FlagImage As System.Web.UI.WebControls.Image = GridRow.FindControl("ImageFlag")
                Dim FlagColorDiv As HtmlControls.HtmlControl = GridRow.FindControl("DivFlagColor")
                Dim HasColor As Boolean = False

                DueDate = CType(DueDate.ToShortDateString, Date)

                FlagImage.ToolTip = String.Format("Due in {0} day(s) on {1}", DateDiff(DateInterval.Day, TodaysDate, DueDate), DueDate.ToShortDateString())


                If DueDate < TodaysDate Then

                    FlagImage.ToolTip = String.Format("Task is overdue {0} day(s) on {1}", DateDiff(DateInterval.Day, DueDate, TodaysDate), DueDate.ToShortDateString())
                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-red")
                    If String.IsNullOrWhiteSpace(DateTextColumnName) = False Then GridRow(DateTextColumnName).CssClass = "standard-red"
                    HasColor = True

                End If
                If HasColor = False AndAlso DueDate = TodaysDate Then

                    FlagImage.ToolTip = "Task is due today!"
                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-orange")
                    If String.IsNullOrWhiteSpace(DateTextColumnName) = False Then GridRow(DateTextColumnName).CssClass = "standard-orange"
                    HasColor = True

                End If
                If HasColor = False AndAlso IsWeekendDay(DueDate) = True AndAlso DueDate > TodaysDate Then

                    FlagImage.ToolTip = "Due date is on a weekend!"
                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-light-grey")
                    If String.IsNullOrWhiteSpace(DateTextColumnName) = False Then GridRow(DateTextColumnName).CssClass = "standard-light-grey"
                    HasColor = True

                End If
                If HasColor = False AndAlso (DueDate > TodaysDate And DueDate < TodaysDate.AddDays(8)) Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-yellow")
                    If String.IsNullOrWhiteSpace(DateTextColumnName) = False Then GridRow(DateTextColumnName).CssClass = "standard-yellow"
                    HasColor = True

                End If
                If HasColor = False Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-green")

                End If

                If String.IsNullOrWhiteSpace(DateTextColumnName) = False Then GridRow(DateTextColumnName).ToolTip = FlagImage.ToolTip

            Catch ex As Exception
            End Try

        End Sub
        Public Function IsWeekendDay(ByVal TheDate As Date) As Boolean
            Try
                Select Case TheDate.DayOfWeek
                    Case DayOfWeek.Saturday, DayOfWeek.Sunday
                        Return True
                    Case Else
                        Return False
                End Select
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function SetReturnValueJQuery(ByVal ControlName As String, ByVal Value As String) As String
            Dim returnValueTemplate As String = ""
            returnValueTemplate = "CallingWindowContent.$('#{0}').val('{1}');"
            SetReturnValueJQuery = String.Format(returnValueTemplate, ControlName, System.Web.HttpUtility.JavaScriptStringEncode(Value))
        End Function
        Public Function SetReturnValueJavascript(ByVal ClientControlPrefix As String, ByVal ControlName As String, ByVal Value As String) As String
            SetReturnValueJavascript = ClientControlPrefix & ControlName & "').value = '" & System.Web.HttpUtility.JavaScriptStringEncode(Value) & "';"
        End Function
        Public Sub SetDocumentIcon(ByRef DocumentBackgroundDiv As HtmlControls.HtmlControl, ByRef DocumentLinkButton As WebControls.LinkButton,
                                   ByVal MimeType As String, Optional ByRef AddCommentsButtonVisible As Boolean = False, Optional ByRef FileName As String = Nothing)

            Dim DocIcon As New AdvantageFramework.DocumentManager.Classes.DocumentIcon(MimeType, FileName)

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DocumentBackgroundDiv, DocIcon.WebDivButtonCssClass)
            DocumentLinkButton.Text = DocIcon.Abbreviation
            DocumentLinkButton.ToolTip = DocIcon.Description
            DocumentLinkButton.CssClass = DocIcon.WebLinkButtonCssClass
            AddCommentsButtonVisible = DocIcon.AddCommentsButtonVisible

            Try

                If FileName.Length > 0 Then

                    If FileName.ToUpper().EndsWith(".MSG") Then

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DocumentBackgroundDiv, "document-ms-outlook")
                        DocumentLinkButton.Text = "MSG"
                        DocumentLinkButton.CssClass = "icon-text-three"
                        DocumentLinkButton.ToolTip = "Microsoft Outlook"
                        AddCommentsButtonVisible = True

                    End If

                    DocumentLinkButton.ToolTip &= ":  " & FileName

                End If

            Catch ex As Exception
            End Try

        End Sub

        Public Sub SetDocumentBlock(ByRef FileTypeDiv As HtmlControls.HtmlControl, ByVal MimeType As String,
                                    ByRef FileTypeLabel As Label, ByRef AddCommentsDiv As HtmlControls.HtmlControl,
                                    ByVal Filename As String, ByVal FileSize As Integer, ByVal UploadedByUserCode As String,
                                    ByVal GeneratedDate As DateTime, ByVal IsPrivate As Boolean)

            AddCommentsDiv.Visible = False

            Dim Size As String = String.Empty
            Dim ToolTip As New System.Text.StringBuilder
            Dim FileType As String = String.Empty

            Select Case MimeType
                Case "application/msword",
                     "application/vnd.openxmlformats-officedocument.word",
                     "application/vnd.openxmlformats-officedocument.wordprocessingml.document"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-word")
                    FileTypeLabel.Text = "W"
                    FileType = "Microsoft Word"
                    AddCommentsDiv.Visible = True

                Case "application/mspowerpoint", "application/vnd.ms-powerpoint"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-powerpoint")
                    FileTypeLabel.Text = "PP"
                    FileType = "Microsoft Powerpoint"

                Case "application/msproject", "application/vnd.ms-msproject"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-project")
                    FileTypeLabel.Text = "PR"
                    FileType = "Microsoft Project"

                Case "application/pdf"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-adobe-pdf")
                    FileTypeLabel.Text = "PDF"
                    FileType = "Adobe PDF"
                    AddCommentsDiv.Visible = True

                Case "application/msexcel", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spre"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-excel")
                    FileTypeLabel.Text = "XL"
                    FileType = "Microsoft Excel"
                    AddCommentsDiv.Visible = True

                Case "image/bmp"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-image")
                    FileTypeLabel.Text = "BMP"
                    FileType = "Bitmap Image"
                    AddCommentsDiv.Visible = True

                Case "image/gif"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-image")
                    FileTypeLabel.Text = "GIF"
                    FileType = "Gif Image"
                    AddCommentsDiv.Visible = True

                Case "image/jpeg", "image/pjpeg"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-image")
                    FileTypeLabel.Text = "JPG"
                    FileType = "Jpeg Image"
                    AddCommentsDiv.Visible = True

                Case "image/x-png", "image/png"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-image")
                    FileTypeLabel.Text = "PNG"
                    FileType = "Png Image"
                    AddCommentsDiv.Visible = True

                Case "image/tiff"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-image")
                    FileTypeLabel.Text = "TIF"
                    FileType = "Tiff Image"
                    AddCommentsDiv.Visible = True

                Case "text/plain"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-text")
                    FileTypeLabel.Text = "TXT"
                    FileType = "Text file"

                Case "image/x-photoshop"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-adobe-photoshop")
                    FileTypeLabel.Text = "PSD"
                    FileType = "Adobe Photoshop"

                Case "application/illustrator"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-adobe-illustrator")
                    FileTypeLabel.Text = "AI"
                    FileType = "Adobe Illustrator"

                Case "URL"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-url")
                    FileTypeLabel.Text = "URL"
                    FileType = "URL hyperlink"

                Case "application/x-zip-compressed", "application/zip"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-zip")
                    FileTypeLabel.Text = "ZIP"
                    FileType = "Zip file"

                Case "application/vnd.ms-outlook"

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-outlook")
                    FileTypeLabel.Text = "O"
                    FileType = "Microsoft Outlook"
                    AddCommentsDiv.Visible = True

                Case Else

                    FileTypeLabel.Text = "DOC"
                    FileType = "Document"

            End Select

            Try

                If Filename.Length > 0 Then

                    If Filename.ToUpper().EndsWith(".MSG") Then

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FileTypeDiv, "document-ms-outlook")
                        FileTypeLabel.Text = "MSG"
                        FileType = "Microsoft Outlook"
                        AddCommentsDiv.Visible = True

                    End If

                End If

            Catch ex As Exception
            End Try

            If String.IsNullOrWhiteSpace(FileType) = False Then

                ToolTip.Append(FileType)
                ToolTip.Append(", ")

            End If

            If FileSize > 0 Then

                FileSize = FileSize / 1024

                Select Case FileSize
                    Case Is < 1

                        Size = "< 1K"

                    Case 0 To 1023

                        Size = FileSize.ToString("#,###") & " KB"

                    Case Is >= 1024

                        Size = (FileSize / 1024).ToString("#,###.##") & " MB"

                End Select

                ToolTip.Append("Size:  ")
                ToolTip.Append(Size)
                ToolTip.Append(", ")

            End If

            ToolTip.Append("Added:  ")
            ToolTip.Append(GeneratedDate)

            ToolTip.Append(", by:  ")
            ToolTip.Append(UploadedByUserCode)

            If IsPrivate = True Then

                ToolTip.Append(" (PRIVATE)")

            End If

            FileTypeLabel.ToolTip = ToolTip.ToString
            FileTypeDiv.Attributes.Add("title", FileTypeLabel.ToolTip)

        End Sub

        Public Sub SetFlagColor(ByRef FlagBackgroundDiv As HtmlControls.HtmlControl, ByVal Threshold As Double, ByVal Quoted As Decimal, ByVal Actual As Decimal)

            Try

                Dim Title As String = String.Empty
                Dim ThresholdDisplay As Double = 0

                If Threshold > 0 Then

                    Title = String.Format("Quoted: {0}; Actual: {1}", FormatNumber(Quoted, 2, TriState.True, TriState.False, TriState.True),
                                          FormatNumber(Actual, 2, TriState.True, TriState.False, TriState.True))

                    ThresholdDisplay = Threshold
                    Threshold = Threshold * 0.01

                    If Quoted > 0 Then

                        Dim QuotedTimesThreshold As Decimal = CType(Quoted * Threshold, Decimal)

                        Title &= String.Format("; Threshold: {0}, ({1}%)", FormatNumber(QuotedTimesThreshold, 2, TriState.True, TriState.False, TriState.True),
                                               FormatNumber(ThresholdDisplay, 0, TriState.True, TriState.False, TriState.True))

                        If Actual > QuotedTimesThreshold Then

                            'Title &= String.Format("; Over quote by: {0}", FormatNumber(Actual - Quoted, 2, TriState.True, TriState.True, TriState.True))
                            'Title &= String.Format(", Over threshold by: {0}", FormatNumber(Actual - QuotedTimesThreshold, 2, TriState.True, TriState.True, TriState.True))
                            'Title &= String.Format("; Remaining to threshold: {0}", FormatNumber(QuotedTimesThreshold - Actual, 2, TriState.True, TriState.False, TriState.True))
                            Title &= String.Format("; Remaining: {0}", FormatNumber(Quoted - Actual, 2, TriState.True, TriState.False, TriState.True))
                            SetFlagColor(FlagBackgroundDiv, StandardColor.Red)

                        ElseIf Actual < QuotedTimesThreshold Then

                            'Title &= String.Format("; Under quote by: {0}", FormatNumber(Quoted - Actual, 2, TriState.True, TriState.True, TriState.True))
                            'Title &= String.Format(", Under threshold by: {0}", FormatNumber(QuotedTimesThreshold - Actual, 2, TriState.True, TriState.True, TriState.True))
                            'Title &= String.Format("; Remaining to threshold: {0}", FormatNumber(QuotedTimesThreshold - Actual, 2, TriState.True, TriState.False, TriState.True))
                            Title &= String.Format("; Remaining: {0}", FormatNumber(Quoted - Actual, 2, TriState.True, TriState.False, TriState.True))
                            SetFlagColor(FlagBackgroundDiv, StandardColor.Green)

                        ElseIf Actual = QuotedTimesThreshold Then

                            Title &= "; Actual equals Quoted!"
                            SetFlagColor(FlagBackgroundDiv, StandardColor.Green)

                        End If

                    Else

                        SetFlagColor(FlagBackgroundDiv, StandardColor.Amber)

                    End If

                Else

                    Title = String.Format("Quoted: {0}; Actual: {1}; Threshold: None", FormatNumber(Quoted, 2, TriState.True, TriState.False, TriState.True), Actual.ToString())
                    SetFlagColor(FlagBackgroundDiv, StandardColor.Green)

                End If

                FlagBackgroundDiv.Attributes.Add("title", Title)

            Catch ex As Exception

                SetFlagColor(FlagBackgroundDiv, StandardColor.Green)

            End Try

        End Sub
        Public Sub SetFlagColor(ByRef FlagBackgroundDiv As HtmlControls.HtmlControl, ByRef Color As StandardColor)

            Dim BaseCSS As String = "icon-background background-color-sidebar "
            If Color = StandardColor.Invisible Then

                DivHide(FlagBackgroundDiv)

            Else

                DivSetCssClass(FlagBackgroundDiv, BaseCSS & GetStandardColorCSS(Color))

            End If

        End Sub

        Public Sub DivSetForeColor(ByRef Div As HtmlControls.HtmlControl, ByVal ColorCode As String)

            DivSetStyle(Div, "color: " & ColorCode & " !important;")

        End Sub
        Public Sub DivSetBackgroundColor(ByRef Div As HtmlControls.HtmlControl, ByVal ColorCode As String)

            DivSetStyle(Div, "background-color: " & ColorCode & " !important;")

        End Sub
        Public Sub DivHide(ByRef Div As HtmlControls.HtmlControl)

            DivSetCssClass(Div, "hidden")

        End Sub
        Public Sub DivAddCssClass(ByRef Div As HtmlControls.HtmlControl, ByVal CssClass As String)

            Dim CurrrentCss As String = Div.Attributes("class")
            DivSetCssClass(Div, CurrrentCss & " " & CssClass)

        End Sub
        Public Sub DivSetStyle(ByRef Div As HtmlControls.HtmlControl, ByVal Style As String)

            Div.Attributes.Remove("style")
            Div.Attributes.Add("style", Style)

        End Sub
        Public Sub DivSetCssClass(ByRef Div As HtmlControls.HtmlControl, ByVal CssClass As String)

            Div.Attributes.Remove("class")
            Div.Attributes.Add("class", CssClass)

        End Sub

        Public Function GetStandardColorCSS(ByVal Color As StandardColor) As String

            Select Case Color
                Case StandardColor.Red

                    Return "standard-red"

                Case StandardColor.Pink

                    Return "standard-pink"

                Case StandardColor.Purple

                    Return "standard-purple"

                Case StandardColor.DeepPurple

                    Return "standard-deep-purple"

                Case StandardColor.Indigo

                    Return "standard-indigo"

                Case StandardColor.Blue

                    Return "standard-blue"

                Case StandardColor.LightBlue

                    Return "standard-light-blue"

                Case StandardColor.Cyan

                    Return "standard-cyan"

                Case StandardColor.Teal

                    Return "standard-teal"

                Case StandardColor.Green

                    Return "standard-green"

                Case StandardColor.LightGreen

                    Return "standard-light-green"

                Case StandardColor.Lime

                    Return "standard-lime"

                Case StandardColor.Yellow

                    Return "standard-yellow"

                Case StandardColor.Amber

                    Return "standard-amber"

                Case StandardColor.LightOrange

                    Return "standard-light-orange"

                Case StandardColor.Orange

                    Return "standard-orange"

                Case StandardColor.DeepOrange

                    Return "standard-deep-orange"

                Case StandardColor.Brown

                    Return "standard-brown"

                Case StandardColor.LightGrey

                    Return "standard-light-grey"

                Case StandardColor.Grey

                    Return "standard-grey"

                Case StandardColor.DarkGrey

                    Return "standard-dark-grey"

                Case StandardColor.BlueGrey

                    Return "standard-blue-grey"

                Case StandardColor.Black

                    Return "standard-black"

                Case StandardColor.White

                    Return "standard-white"

                    'Case StandardColor.Invisible

                    '    Return "; display: none !important"

                Case Else

                    Return ""

            End Select

        End Function

        Public Sub ClearTextBoxesCascadeDown(ByRef TextBoxesToClear() As System.Web.UI.WebControls.TextBox)

            If TextBoxesToClear.Length > 0 Then

                Dim TextBoxStack As Stack(Of TextBox) = New Stack(Of TextBox)(TextBoxesToClear)
                Dim CurrentControl As TextBox = Nothing

                For i As Integer = 0 To TextBoxesToClear.Length - 1

                    CurrentControl = TextBoxStack.Pop
                    ClearTextBoxes(CurrentControl, TextBoxStack.ToArray())

                Next

            End If

        End Sub
        Public Sub ClearTextBoxes(ByRef OnChangeTextBoxID As System.Web.UI.WebControls.TextBox, ByVal TextBoxesToClear() As System.Web.UI.WebControls.TextBox)
            Dim sb As New System.Text.StringBuilder

            If TextBoxesToClear.Length > 0 Then

                sb.Append("ClearTextboxes(")

                For Each Control As System.Web.UI.WebControls.TextBox In TextBoxesToClear

                    sb.Append("'")
                    sb.Append(Control.ClientID)
                    sb.Append("',")

                Next

                sb.Append(");")

            End If

            Dim Script As String = sb.ToString().Replace(",);", ");")

            OnChangeTextBoxID.Attributes.Remove("onkeydown")
            OnChangeTextBoxID.Attributes.Add("onkeydown", Script)

        End Sub

        Public Sub SaveColumnUserSetting(ByVal ConnectionString As String, ByVal UserCode As String, ByVal DataGridViewName As String, ByVal DataGridViewColumnName As String, ByVal IsVisible As Boolean)

            'objects
            Dim DataGridView As AdvantageFramework.Database.Entities.DataGridView = Nothing
            Dim DataGridViewColumn As AdvantageFramework.Database.Entities.DataGridViewColumn = Nothing
            Dim DataGridViewColumnUserSetting As AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                Try

                    DataGridView = (From Entity In AdvantageFramework.Database.Procedures.DataGridView.Load(DbContext).Include("DataGridViewColumns").Include("DataGridViewColumnUserSettings")
                                    Where Entity.Name = DataGridViewName
                                    Select Entity).Single

                Catch ex As Exception
                    DataGridView = Nothing
                End Try

                If DataGridView IsNot Nothing Then

                    Try

                        DataGridViewColumn = (From Entity In DataGridView.DataGridViewColumns
                                              Where Entity.Name = DataGridViewColumnName
                                              Select Entity).Single

                    Catch ex As Exception
                        DataGridViewColumn = Nothing
                    End Try

                    If DataGridViewColumn IsNot Nothing Then

                        If DataGridViewColumn.IsEditable = True Then

                            Try

                                DataGridViewColumnUserSetting = (From Entity In DataGridView.DataGridViewColumnUserSettings
                                                                 Where Entity.DataGridViewColumnID = DataGridViewColumn.ID AndAlso
                                                                       Entity.UserCode = DbContext.UserCode
                                                                 Select Entity).Single

                            Catch ex As Exception
                                DataGridViewColumnUserSetting = Nothing
                            End Try

                            If DataGridViewColumnUserSetting IsNot Nothing Then

                                If IsVisible Then

                                    DataGridViewColumnUserSetting.IsVisible = 1

                                Else

                                    DataGridViewColumnUserSetting.IsVisible = 0

                                End If

                                AdvantageFramework.Database.Procedures.DataGridViewColumnUserSetting.Update(DbContext, DataGridViewColumnUserSetting)

                            Else

                                DataGridViewColumnUserSetting = New AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting

                                DataGridViewColumnUserSetting.DataGridViewID = DataGridView.ID
                                DataGridViewColumnUserSetting.DataGridViewColumnID = DataGridViewColumn.ID
                                DataGridViewColumnUserSetting.UserCode = DbContext.UserCode

                                If IsVisible Then

                                    DataGridViewColumnUserSetting.IsVisible = 1

                                Else

                                    DataGridViewColumnUserSetting.IsVisible = 0

                                End If

                                AdvantageFramework.Database.Procedures.DataGridViewColumnUserSetting.Insert(DbContext, DataGridViewColumnUserSetting)

                            End If

                            Dim Key As String = "GRID_SETTINGS__" & UserCode & "_" & DataGridViewName
                            HttpContext.Current.Session(Key) = Nothing

                        End If

                    End If

                End If

            End Using

        End Sub
        Private Sub HeaderContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)

            'objects
            Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
            Dim ColumnValues() As String = Nothing
            Dim ColumnNameIndex As Integer = 0

            If TypeOf e.Item.Parent Is Telerik.Web.UI.RadMenuItem AndAlso DirectCast(e.Item.Parent, Telerik.Web.UI.RadMenuItem).Value = "ColumnsContainer" AndAlso
                    e.Item.Controls.Count = 1 AndAlso TypeOf e.Item.Controls(0) Is System.Web.UI.WebControls.CheckBox Then

                If e.Item.Value.ToString().IndexOf("|") > -1 Then
                    ColumnValues = Split(e.Item.Value, "|")
                    ColumnNameIndex = ColumnValues.Length - 1
                End If

                Try

                    GridColumn = (From Column In DirectCast(sender.parent, Telerik.Web.UI.RadGrid).Columns.OfType(Of Telerik.Web.UI.GridColumn)()
                                  Where Column.UniqueName = ColumnValues(ColumnNameIndex)
                                  Select Column).Single

                Catch ex As Exception
                    GridColumn = Nothing
                Finally

                    If GridColumn IsNot Nothing Then
                        If GridColumn.HeaderAbbr = "FIXED" Then
                            e.Item.Visible = False
                        End If
                    End If

                End Try


            Else

                If e.Item.Value <> "ColumnsContainer" Then

                    e.Item.Visible = False

                End If

            End If

        End Sub
        Private Sub LoadDataGridViewColumnUserSettings(ByVal DataGridViewName As String, ByVal ConnectionString As String, ByVal UserCode As String, ByVal GridColumnsList As Generic.List(Of Telerik.Web.UI.GridColumn))

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Dim UserColumn As New List(Of String)
                    UserColumn = GetUserColumnList(ConnectionString, DataGridViewName, UserCode)

                    If UserColumn Is Nothing Then

                    End If

                    For Each GridColumn In GridColumnsList

                        If UserColumn.Contains(GridColumn.UniqueName) = True Then

                            GridColumn.Display = False

                        End If

                    Next

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Function GetUserColumnList(ByVal ConnectionString As String, ByVal GridName As String, ByVal UserCode As String) As List(Of String)

            Dim UserColumn As New List(Of String)
            Dim Key As String = "GRID_SETTINGS__" & UserCode & "_" & GridName

            If HttpContext.Current.Session(Key) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    UserColumn = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GRID_COLUMN.NAME FROM GRID WITH(NOLOCK) INNER JOIN GRID_COLUMN WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN.GRID_ID " &
                                                                                          "INNER JOIN GRID_COLUMN_SETTING WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN_SETTING.GRID_ID AND GRID_COLUMN.GRID_COLUMN_ID = GRID_COLUMN_SETTING.GRID_COLUMN_ID " &
                                                                                          "WHERE (GRID_COLUMN_SETTING.IS_VISIBLE = 0) AND (GRID.NAME = '{0}') AND (GRID_COLUMN_SETTING.USER_CODE = '{1}');", GridName, UserCode)).ToList()

                    HttpContext.Current.Session(Key) = UserColumn

                End Using

            Else

                UserColumn = HttpContext.Current.Session(Key)

            End If

            Return UserColumn

        End Function

        Public Function CheckUserColumns(ByVal ConnectionString As String, ByVal GridName As String, ByVal UserCode As String) As Integer

            Dim UserColumn As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                UserColumn = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM GRID_COLUMN_SETTING INNER JOIN GRID WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN_SETTING.GRID_ID " &
                                                                                          "WHERE (GRID.NAME = '{0}') AND (GRID_COLUMN_SETTING.USER_CODE = '{1}');", GridName, UserCode)).FirstOrDefault

            End Using

            Return UserColumn

        End Function

        Public Sub LoadDataGridViewColumnUserSettings(ByRef RadGrid As Telerik.Web.UI.RadGrid)

            If Not RadGrid.Page.Session("ConnString") Is Nothing And Not RadGrid.Page.Session("UserCode") Is Nothing Then

                AddHandler RadGrid.HeaderContextMenu.ItemCreated, AddressOf HeaderContextMenuItemCreated

                LoadDataGridViewColumnUserSettings(RadGrid.ID, RadGrid.Page.Session("ConnString").ToString, RadGrid.Page.Session("UserCode").ToString, RadGrid.Columns.OfType(Of Telerik.Web.UI.GridColumn).ToList)

            End If

        End Sub
        Public Sub SetMaxLength(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EnumProperty As System.Enum, TextBox As System.Web.UI.WebControls.TextBox)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim MaxLength As Long = 0

            PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(EnumProperty)

            If PropertyDescriptor IsNot Nothing Then

                MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                If MaxLength > 0 Then

                    TextBox.MaxLength = MaxLength

                End If

            End If

        End Sub
        Public Function RadComboBoxAutoFillGetStatusMessage(ByVal offset As Integer, ByVal total As Integer) As String
            If total <= 0 Then
                Return "No matches"
            End If

            Return [String].Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total)
        End Function
        Public Sub PerformRadTreeViewDragAndDrop(ByVal dropPosition As RadTreeViewDropPosition, ByVal sourceNode As RadTreeNode, ByVal destNode As RadTreeNode, ByVal AllowOver As Boolean)
            Select Case dropPosition
                Case RadTreeViewDropPosition.Over
                    If AllowOver = True Then
                        ' child
                        If Not sourceNode.IsAncestorOf(destNode) Then
                            sourceNode.Owner.Nodes.Remove(sourceNode)
                            destNode.Nodes.Add(sourceNode)
                        End If
                        Exit Select
                    End If
                Case RadTreeViewDropPosition.Above
                    ' sibling - above
                    sourceNode.Owner.Nodes.Remove(sourceNode)
                    destNode.InsertBefore(sourceNode)
                    Exit Select
                Case RadTreeViewDropPosition.Below
                    ' sibling - below
                    sourceNode.Owner.Nodes.Remove(sourceNode)
                    destNode.InsertAfter(sourceNode)
                    Exit Select
            End Select

        End Sub
        Public Sub SetIconState(ByRef ImgBtn As ImageButton, ByVal State As ActionIconState, ByRef Div As HtmlControls.HtmlControl, ByRef HfIsAssignment As HiddenField, ByRef HfIsTask As HiddenField, ByVal isTask As Boolean)

            With ImgBtn

                Select Case State

                    Case ActionIconState.Dismiss

                        .Enabled = True
                        .ToolTip = "Dismiss Alert"
                        .AlternateText = .ToolTip
                        .CommandName = ActionIconState.Dismiss.ToString()
                        .ImageUrl = "~/Images/Icons/White/256/garbage.png"

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(Div, "standard-light-green")

                        End If

                        HfIsAssignment.Value = 0
                        HfIsTask.Value = 0

                    Case ActionIconState.Undismiss

                        .Enabled = True
                        .ToolTip = "Un-dismiss Alert"
                        .AlternateText = .ToolTip
                        .CommandName = ActionIconState.Undismiss.ToString()
                        .ImageUrl = "~/Images/Icons/White/256/garbage_full.png"

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(Div, "standard-amber")

                        End If

                        HfIsAssignment.Value = 0
                        HfIsTask.Value = 0

                    Case ActionIconState.Complete

                        .Enabled = True
                        .ToolTip = "Complete"
                        .AlternateText = .ToolTip
                        .CommandName = ActionIconState.Complete.ToString()
                        .ImageUrl = "~/Images/Icons/White/256/ok.png"

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(Div, "standard-light-green")

                        End If

                        If isTask = True Then
                            HfIsTask.Value = 1
                            HfIsAssignment.Value = 0
                        Else
                            HfIsAssignment.Value = 1
                            HfIsTask.Value = 0
                        End If

                    Case ActionIconState.ReOpen

                        .Enabled = True
                        If isTask = True Then
                            .ToolTip = "Not Complete"
                        Else
                            .ToolTip = "Re-open Assignment"
                        End If
                        .AlternateText = .ToolTip
                        .CommandName = ActionIconState.ReOpen.ToString()
                        .ImageUrl = "~/Images/Icons/White/256/ok.png"

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(Div, "standard-amber")

                        End If

                        If isTask = True Then
                            HfIsTask.Value = 1
                            HfIsAssignment.Value = 0
                        Else
                            HfIsAssignment.Value = 1
                            HfIsTask.Value = 0
                        End If

                    Case ActionIconState.DeleteDraft

                        .Enabled = True
                        .ToolTip = "Delete Draft"
                        .AlternateText = .ToolTip
                        .CommandName = ActionIconState.DeleteDraft.ToString()
                        .ImageUrl = "~/Images/Icons/White/256/delete.png"
                        .Attributes.Add("onclick", "return confirm('Are you sure you want to delete this draft?')")

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(Div, "standard-red")

                        End If

                        HfIsAssignment.Value = 0
                        HfIsTask.Value = 0

                    Case ActionIconState.Hide

                        .Enabled = False
                        .ToolTip = ""
                        .AlternateText = .ToolTip
                        .CommandArgument = 0
                        .CommandName = Nothing
                        .ImageUrl = "Images/spacer.gif"

                        If Div IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(Div)

                        End If

                        HfIsAssignment.Value = 0
                        HfIsTask.Value = 0

                End Select

            End With

        End Sub
        Public Sub SetIconLabelPriority(ByRef PriorityDiv As HtmlControls.HtmlControl, ByRef PriorityLabel As Label, ByVal Priority As Short)

            Dim BaseCSS As String = "icon-background "

            DivSetCssClass(PriorityDiv, BaseCSS & GetPriorityCSS(Priority, PriorityLabel.Text, PriorityLabel.ToolTip))

        End Sub
        Public Function GetPriorityCSS(ByVal Priority As Short,
                                       Optional ByRef PriorityAbbreviation As String = "N", Optional ByRef PriorityText As String = "Normal",
                                       Optional ByRef CssClass As String = "icon-text") As String

            Try

                Select Case Priority
                    Case 1

                        PriorityAbbreviation = "H"
                        PriorityText = "Highest Priority"
                        'CssClass = "icon-text-two"
                        Return "alert-priority-highest"

                    Case 2

                        PriorityAbbreviation = "H"
                        PriorityText = "High Priority"
                        Return "alert-priority-high"

                    Case 4

                        PriorityAbbreviation = "L"
                        PriorityText = "Low Priority"
                        Return "alert-priority-low"

                    Case 5

                        PriorityAbbreviation = "L"
                        PriorityText = "Lowest Priority"
                        'CssClass = "icon-text-two"
                        Return "alert-priority-lowest"

                    Case Else

                        PriorityAbbreviation = "N"
                        PriorityText = "Normal Priority"
                        Return "alert-priority-normal"

                End Select

            Catch ex As Exception

                PriorityAbbreviation = "N"
                PriorityText = "Normal Priority"
                Return "alert-priority-normal"

            End Try

        End Function
        Public Sub SetInOutBoardColor(ByRef Div As HtmlControls.HtmlControl, ByVal stat As Int16)

            If stat = 1 Then

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Div, AdvantageFramework.Web.Presentation.Controls.StandardColor.Red)
                Div.Attributes.Add("title", "Out")

            Else

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Div, AdvantageFramework.Web.Presentation.Controls.StandardColor.LightGreen)
                Div.Attributes.Add("title", "In")

            End If

        End Sub

        Public Sub SetRadgridDocumentColumns(ByRef DeleteImageButton As ImageButton,
                                             ByRef DownloadLinkButton As System.Web.UI.WebControls.LinkButton,
                                             ByRef AddCommentsDiv As HtmlControls.HtmlControl, ByRef AddCommentsImageButton As ImageButton,
                                             ByRef DigitallySignDiv As HtmlControls.HtmlControl, ByRef LinkButtonDigitallySign As LinkButton,
                                             ByRef DocumentHistoryDiv As HtmlControls.HtmlControl, ByRef DocumentHistoryLinkButton As System.Web.UI.WebControls.LinkButton,
                                             ByRef DocumentTypeDiv As HtmlControls.HtmlControl, ByRef DocumentTypeLinkButton As System.Web.UI.WebControls.LinkButton,
                                             ByRef ProofHQDiv As HtmlControls.HtmlControl, ByRef ProofHQLinkButton As System.Web.UI.WebControls.LinkButton, ByVal ProofHQURL As String,
                                             ByRef SizeCellText As String,
                                             ByVal DocumentID As Integer, ByVal MimeType As String, ByVal Filename As String, ByVal RepositoryFilename As String, ByVal Description As String, ByVal FileSize As Double,
                                             ByVal Level As String, ByVal ForeignKey As String, ByVal AlertID As Integer)

            Dim AddCommentsButtonVisible As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If DeleteImageButton IsNot Nothing Then

                DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

            Select Case MimeType
                Case "URL"
                    Dim fullUrl As String = String.Empty

                    If (RepositoryFilename.ToLower.StartsWith("http://") OrElse RepositoryFilename.ToLower.StartsWith("https://")) Then
                        fullUrl = RepositoryFilename
                    Else
                        fullUrl = "http://" + RepositoryFilename
                    End If
                    If DocumentTypeDiv IsNot Nothing AndAlso DownloadLinkButton IsNot Nothing Then
                        DownloadLinkButton.Text = Filename
                        DownloadLinkButton.Attributes.Add("onclick", String.Format(" window.open('{0}'); return false;", fullUrl))
                    End If

                    If DocumentTypeDiv IsNot Nothing AndAlso DocumentTypeLinkButton IsNot Nothing Then
                        AdvantageFramework.Web.Presentation.Controls.SetDocumentIcon(DocumentTypeDiv, DocumentTypeLinkButton, MimeType, AddCommentsButtonVisible, Filename)
                        DocumentTypeLinkButton.Attributes.Add("onclick", String.Format(" window.open('{0}'); return false;", fullUrl))
                    End If

                    If DownloadLinkButton IsNot Nothing Then

                        If Description <> "" Then
                            DownloadLinkButton.ToolTip = String.Format("{0} - {1}", Filename, Description)
                        Else
                            DownloadLinkButton.ToolTip = Filename
                        End If

                    End If

                    If DocumentHistoryDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentHistoryDiv)
                    If ProofHQDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(ProofHQDiv)

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency.AllowProofHQ = False AndAlso ProofHQDiv IsNot Nothing Then
                            AdvantageFramework.Web.Presentation.Controls.DivHide(ProofHQDiv)
                        End If
                    End Using

                Case Else

                    FileSize = FileSize / 1024

                    Select Case FileSize
                        Case Is < 1

                            SizeCellText = "< 1K"

                        Case 0 To 999

                            SizeCellText = FileSize.ToString("#,###") & " KB"

                        Case Is >= 1024

                            SizeCellText = (FileSize / 1024).ToString("#,###.##") & " MB"

                    End Select

                    If DownloadLinkButton IsNot Nothing Then

                        DownloadLinkButton.ToolTip = Filename
                        DownloadLinkButton.Text = Filename

                        Try

                            If Description.Length > 0 Then DownloadLinkButton.ToolTip = DownloadLinkButton.ToolTip & " - " & Description

                        Catch ex As Exception

                        End Try

                        DownloadLinkButton.OnClientClick = "GetDocumentRepositoryDocument(" & DocumentID & "); return false;"

                    End If

                    If DocumentTypeDiv IsNot Nothing AndAlso DocumentTypeLinkButton IsNot Nothing Then

                        AdvantageFramework.Web.Presentation.Controls.SetDocumentIcon(DocumentTypeDiv, DocumentTypeLinkButton, MimeType, AddCommentsButtonVisible, Filename)

                    End If

                    If DocumentHistoryLinkButton IsNot Nothing Then

                        'If Level = "" AndAlso ForeignKey = "" Then

                        '    DocumentHistoryLinkButton.CommandArgument = Filename

                        'Else

                        '    DocumentHistoryLinkButton.CommandArgument = "Level=" & Level & "&FK=" & ForeignKey & "&filename=" & Filename

                        'End If

                        '' MUST DISABLE AJAX to allow the popup window.
                        'DocumentHistoryLinkButton.Attributes.Add("onclick", String.Format("realPostBack('{0}', ''); return false;", DocumentHistoryLinkButton.UniqueID))

                        DocumentHistoryLinkButton.CommandArgument = "Level=" & Level & "&FK=" & ForeignKey & "&filename=" & HttpUtility.UrlEncode(Filename)

                        Dim qs As New AdvantageFramework.Web.QueryString

                        qs.Page = "Documents_History.aspx"
                        qs.Add("Level", Level)
                        qs.Add("FK", ForeignKey)
                        qs.Add("filename", Filename)
                        qs.DocumentID = DocumentID

                        DocumentHistoryLinkButton.Attributes.Add("onclick", String.Format("OpenRadWindow('','" & qs.ToString(True) & "'); return false;"))

                        qs = Nothing

                    End If

            End Select

            If AddCommentsButtonVisible Then

                Try

                    If AddCommentsImageButton IsNot Nothing Then

                        Dim URL As String = ""

                        If Filename.ToUpper.EndsWith(".PDF") Then

                            URL = "Documents_PDFViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1&AlertID=" & AlertID

                        ElseIf Filename.ToUpper.EndsWith(".DOC") OrElse Filename.ToUpper.EndsWith(".DOCX") Then

                            URL = "Documents_WordViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                        ElseIf Filename.ToUpper.EndsWith(".GIF") OrElse Filename.ToUpper.EndsWith(".JPEG") OrElse
                               Filename.ToUpper.EndsWith(".PJPEG") OrElse Filename.ToUpper.EndsWith(".PNG") OrElse
                               Filename.ToUpper.EndsWith(".JPG") OrElse Filename.ToUpper.EndsWith(".TIFF") OrElse
                               Filename.ToUpper.EndsWith(".BMP") Then

                            URL = "Documents_ImageViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                        ElseIf Filename.ToUpper.EndsWith(".MSG") Then

                            URL = "Documents_MSGViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                        ElseIf Filename.ToUpper.Contains(".XLS") OrElse Filename.ToUpper.Contains(".XLSX") Then

                            URL = "Documents_ExcelViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=0"

                        End If

                        If URL <> "" Then

                            'AddCommentsImageButton.OnClientClick = HookUpOpenWindow("", URL, 800, 1200)
                            AddCommentsImageButton.Attributes.Add("onclick", String.Format("OpenRadWindow('Comments','" & URL & "',800,1200); return false;"))
                            AddCommentsImageButton.Visible = True

                        Else

                            If AddCommentsDiv IsNot Nothing Then AddCommentsDiv.Visible = False

                        End If

                    End If

                Catch ex As Exception
                    If AddCommentsDiv IsNot Nothing Then AddCommentsDiv.Visible = False
                End Try

            Else

                If AddCommentsDiv IsNot Nothing Then AddCommentsDiv.Visible = False

            End If

            Try

                If LinkButtonDigitallySign IsNot Nothing Then

                    If Filename.ToUpper.EndsWith(".PDF") Then

                        LinkButtonDigitallySign.Visible = True

                    Else

                        If DigitallySignDiv IsNot Nothing Then

                            If DigitallySignDiv IsNot Nothing Then DigitallySignDiv.Visible = False

                        End If

                    End If

                End If

            Catch ex As Exception
                If DigitallySignDiv IsNot Nothing Then DigitallySignDiv.Visible = False
            End Try

            If ProofHQDiv IsNot Nothing AndAlso ProofHQLinkButton IsNot Nothing Then

                If ProofHQURL <> "" Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ProofHQDiv, "standard-green")
                    ProofHQLinkButton.ToolTip = "Open this attachment in Proof HQ"
                    ProofHQLinkButton.CommandName = "ProofHQLink"
                    ProofHQLinkButton.CommandArgument = ProofHQURL

                Else

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ProofHQDiv, "standard-orange")
                    ProofHQLinkButton.ToolTip = "Upload this attachment to Proof HQ"
                    ProofHQLinkButton.CommandName = "ProofHQUpload"
                    ProofHQLinkButton.CommandArgument = ProofHQURL

                End If

            End If

        End Sub
        Private Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As String

            Title = AdvantageFramework.StringUtilities.JavascriptSafe(Title)
            [URL] = AdvantageFramework.StringUtilities.JavascriptSafe([URL])

            Return "GetRadWindow().browserWindow.OpenRadWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & Top & "," & Left & ");return false;"

        End Function

        Public Function RadComboSelectTextScript(ByRef RadCombo As Telerik.Web.UI.RadComboBox) As String

            Dim script As New System.Text.StringBuilder

            script.Append("Sys.Application.add_load(function(){")
            script.Append("var combo2 = $find('" + RadCombo.ClientID + "');")
            script.Append("combo2.get_inputDomElement().focus();")
            script.Append("combo2.selectText(combo2.get_text().length, combo2.get_text().length); });")

            Return script.ToString()

        End Function

#End Region

    End Module

End Namespace