Public Module StringExtensions

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public ReadOnly Property EmailRegularExpressionString As String
        Get
            EmailRegularExpressionString = "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
        End Get
    End Property

#End Region

#Region " Methods "

    Public Function SetStringToBlankIfNullOrWhitespace(Value As String) As String

        If String.IsNullOrWhiteSpace(Value) Then

            SetStringToBlankIfNullOrWhitespace = String.Empty

        Else

            SetStringToBlankIfNullOrWhitespace = Value

        End If

    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function AppendTrailingCharacter(InitialString As String, ByRef AppendCharacter As String) As String

        If InitialString.Length > 0 Then

            If InitialString.Substring(InitialString.Length - 1) <> AppendCharacter Then

                InitialString += AppendCharacter

            End If

        End If

        AppendTrailingCharacter = InitialString

    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function IsValidEmailAddress(EmailAddress As String) As Boolean

        Dim Regex As System.Text.RegularExpressions.Regex = Nothing

        If EmailAddress <> Nothing Then

            Regex = New System.Text.RegularExpressions.Regex(EmailRegularExpressionString, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            IsValidEmailAddress = Regex.IsMatch(EmailAddress)

        Else

            IsValidEmailAddress = False

        End If

    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function GetNameAsWords(Value As String) As String

        Try
            If String.IsNullOrWhiteSpace(Value) = False Then
                'objects
                Dim NewName As String = ""
                Dim CharIndex As Integer = 0
                Dim ThisCharacter As String = ""
                Dim LastCharacter As String = ""

                If String.IsNullOrEmpty(Value) = False Then

                    For Each ThisCharacter In Value

                        Select Case ThisCharacter

                            Case "A" To "Z", 0 To 9

                                Select Case LastCharacter

                                    Case "A" To "Z", " ", ""

                                        If CharIndex + 1 < Value.Length AndAlso Value.Chars(CharIndex + 1).ToString.ToLower = Value.Chars(CharIndex + 1).ToString Then

                                            NewName &= " " & ThisCharacter

                                        Else

                                            NewName &= ThisCharacter

                                        End If

                                    Case Else

                                        If IsNumeric(LastCharacter) AndAlso IsNumeric(ThisCharacter) Then

                                            NewName &= ThisCharacter

                                        Else

                                            NewName &= " " & ThisCharacter

                                        End If

                                End Select

                            Case Else

                                NewName &= ThisCharacter

                        End Select

                        LastCharacter = ThisCharacter

                        CharIndex += 1

                    Next

                End If

                GetNameAsWords = NewName.TrimStart(" ")
            Else
                Return Value
            End If
        Catch ex As Exception
            Return Value
        End Try

    End Function

#End Region

End Module
