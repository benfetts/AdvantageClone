Public Partial Class BillingApproval_Approval_Tooltip
    Inherits System.Web.UI.UserControl

    Public Property BatchID() As String
        Get
            If ViewState("BatchID") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("BatchID"), String)
        End Get
        Set(ByVal value As String)
            If Me.BatchID <> value Then
                Me.reset()
            End If
            ViewState("BatchID") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Me.BatchID) Then
            Dim CurrBatchID As Integer = CType(Me.BatchID, Integer)
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsBatchDetails As New DataSet
            Dim dtBatchHeader As New DataTable
            Dim dtBatchAEs As New DataTable
            Dim dtBatchPMs As New DataTable
            Dim dtBatchCDPC As New DataTable
            Dim LoadLevel As String = "CDPC"

            dsBatchDetails = b.GetBatchDetails(CurrBatchID)
            dtBatchHeader = dsBatchDetails.Tables(0)
            dtBatchAEs = dsBatchDetails.Tables(1)
            dtBatchPMs = dsBatchDetails.Tables(2)
            dtBatchCDPC = dsBatchDetails.Tables(3)

            If dtBatchHeader.Rows.Count > 0 Then
                If IsDBNull(dtBatchHeader.Rows(0)("CREATE_DATE")) = False Then
                    Me.LblCreated.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("CREATE_DATE").ToString()).ToShortDateString()
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("CREATE_USER_NAME")) = False Then
                    Me.LblUserID.Text = dtBatchHeader.Rows(0)("CREATE_USER_NAME").ToString()
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("MODIFY_DATE")) = False Then
                    Me.LblModified.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("MODIFY_DATE").ToString()).ToShortDateString()
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("MODIFY_USER_NAME")) = False Then
                    Me.LblModifiedUser.Text = dtBatchHeader.Rows(0)("MODIFY_USER_NAME").ToString()
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                    Me.LblBatchDescription.Text = dtBatchHeader.Rows(0)("BA_BATCH_DESC")
                Else
                    Me.LblBatchDescription.Text = "[None]"
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("BATCH_DATE")) = False Then
                    Me.LblBatchDate.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("BATCH_DATE")).ToShortDateString()
                Else
                    Me.LblBatchDate.Text = "[None]"
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("DATE_CUTOFF")) = False Then
                    Me.LblDateCutoff.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("DATE_CUTOFF")).ToShortDateString()
                Else
                    Me.LblDateCutoff.Text = "[None]"
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("PERIOD_CUTOFF")) = False Then
                    Me.LblPeriodCutoff.Text = dtBatchHeader.Rows(0)("PERIOD_CUTOFF").ToString()
                Else
                    Me.LblPeriodCutoff.Text = "[None]"
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("EMP_CODE")) = False Then
                    Me.LblAssigendEmp.Text = dtBatchHeader.Rows(0)("EMP_CODE")
                Else
                    Me.LblAssigendEmp.Text = "[None]"
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("EMP_FML_NAME")) = False Then
                    Me.LblAssigendEmp.Text &= " - " & dtBatchHeader.Rows(0)("EMP_FML_NAME")
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("LOAD_LEVEL")) = False Then
                    LoadLevel = dtBatchHeader.Rows(0)("LOAD_LEVEL")
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("INCL_NB")) = False Then
                    If CType(dtBatchHeader.Rows(0)("INCL_NB"), Boolean) = True Then
                        Me.LblNonBillableRecs.Text = "Yes"
                    Else
                        Me.LblNonBillableRecs.Text = "No"
                    End If
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("INCL_FEE")) = False Then
                    If CType(dtBatchHeader.Rows(0)("INCL_FEE"), Boolean) = True Then
                        Me.LblFeeTimeRecs.Text = "Yes"
                    Else
                        Me.LblFeeTimeRecs.Text = "No"
                    End If
                End If

                'set status image:
                'If IsDBNull(dtBatchHeader.Rows(0)("BA_EXISTS")) = False Then
                '    If dtBatchHeader.Rows(0)("BA_EXISTS") = True Then
                With Me.ImgStatus
                    .ImageUrl = "~/Images/square_green.png"
                    .AlternateText = "Pending/In Progress"
                    .ToolTip = "Pending/In Progress"
                End With

                '    End If
                'End If
                If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then
                    If dtBatchHeader.Rows(0)("APPROVED") = True Then
                        With Me.ImgStatus
                            .ImageUrl = "~/Images/square_yellow.png"
                            .AlternateText = "Approved"
                            .ToolTip = "Approved"
                        End With
                    End If
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then
                    If dtBatchHeader.Rows(0)("FINISHED") = True Then
                        With Me.ImgStatus
                            .ImageUrl = "~/Images/square_red.png"
                            .AlternateText = "Finished"
                            .ToolTip = "Finished"
                        End With
                    End If
                End If



            End If
            If LoadLevel = "CDPC" Or LoadLevel = "" Then
                LoadLevel = "[All]"
            End If
            Me.LblLOAD_LEVEL.Text = LoadLevel

            Dim str As String = ""
            If dtBatchAEs.Rows.Count > 0 Then
                For i As Integer = 0 To dtBatchAEs.Rows.Count - 1
                    If IsDBNull(dtBatchAEs.Rows(i)("ALERT_DISPLAY")) = False Then
                        str &= dtBatchAEs.Rows(i)("ALERT_DISPLAY").ToString() & ", "
                    End If
                Next
                str = str.TrimEnd()
                str = MiscFN.RemoveTrailingDelimiter(str, ",")
                Me.LblAEs.Text = str
            Else
                Me.LblAEs.Text = "[None]"
            End If

            str = ""
            If dtBatchCDPC.Rows.Count > 0 Then
                For j As Integer = 0 To dtBatchCDPC.Rows.Count - 1
                    If IsDBNull(dtBatchCDPC.Rows(j)("ALERT_DISPLAY")) = False Then
                        str &= dtBatchCDPC.Rows(j)("ALERT_DISPLAY").ToString() & "<br />"
                    End If
                Next
                str = str.Replace("CDPC", "[All]")
                Me.LblSelections.Text = str.Replace(":", ", ")
            Else
                Me.LblSelections.Text = "[None]"
            End If

            'Dim dtJobList As New DataTable
            'dtJobList = b.GetBatchJobList(CurrBatchID)
            'str = ""
            'If dtJobList.Rows.Count > 0 Then
            '    For k As Integer = 0 To dtJobList.Rows.Count - 1
            '        If IsDBNull(dtJobList.Rows(k)("JOB_AND_COMPONENT")) = False Then
            '            str &= dtJobList.Rows(k)("JOB_AND_COMPONENT").ToString() & "<br />"
            '        End If
            '    Next
            '    Me.LblJobs.Text = str
            'Else
            '    Me.LblJobs.Text = "[None]"
            'End If


        End If

    End Sub

    Private Sub reset()
        'clear the uc
    End Sub

End Class