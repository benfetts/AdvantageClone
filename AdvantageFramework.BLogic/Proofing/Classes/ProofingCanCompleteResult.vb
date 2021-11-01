Namespace Proofing.Classes
    <Serializable>
    Public Class ProofingCanCompleteResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CanComplete As Boolean = True
        Public Property CompleteMessage As String = String.Empty
        Public Property IsRouted As Boolean = True
        Public Property IsComplete As Boolean = True
        Public Property OpenCount As Integer = 0
        Public Property ApproveCount As Integer = 0
        Public Property RejectCount As Integer = 0
        Public Property DeferCount As Integer = 0
        Public Property ExternalOpenCount As Integer = 0
        Public Property ExternalApproveCount As Integer = 0
        Public Property ExternalRejectCount As Integer = 0
        Public Property ExternalDeferCount As Integer = 0
        Public ReadOnly Property CompleteMessages As Generic.List(Of String)
            Get

                Dim Messages As Generic.List(Of String) = Nothing

                Try

                    If String.IsNullOrWhiteSpace(CompleteMessage) = False Then

                        Dim ar() As String = CompleteMessage.Split(".")

                        If ar.Length > 0 Then

                            Messages = New List(Of String)

                            For Each Message In ar

                                If String.IsNullOrWhiteSpace(Message) = False Then

                                    Messages.Add(Message.Trim())

                                End If

                            Next

                        End If
                        'If ar.Length > 0 Then

                        '    Messages = ar.ToList()

                        'End If

                        'If Messages IsNot Nothing AndAlso Messages.Count > 0 Then

                        '    For Each Message In Messages

                        '        Message = Message.Trim() & "."

                        '    Next

                        'End If


                    End If

                Catch ex As Exception
                    Messages = Nothing
                End Try

                Return Messages

            End Get
        End Property
#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace
