Namespace Importing.Classes

    Public Class ComDataAC29File

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Line1000
            Line9999
            File
            FileLines
            ComDataAC29FileDetails
        End Enum

#End Region

#Region " Variables "

        Private _Line1000 As String = ""
        Private _Line9999 As String = ""
        Private _File As String = ""
        Private _FileLines As Generic.List(Of String) = Nothing
        Private _ComDataAC29FileDetails As Generic.List(Of ComDataAC29FileDetail) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Line1000() As String
            Get
                Line1000 = _Line1000
            End Get
        End Property
        Public ReadOnly Property Line9999() As String
            Get
                Line9999 = _Line9999
            End Get
        End Property
        Public ReadOnly Property File() As String
            Get
                File = _File
            End Get
        End Property
        Public ReadOnly Property FileLines As Generic.List(Of String)
            Get
                FileLines = _FileLines
            End Get
        End Property
        Public ReadOnly Property ComDataAC29FileDetails As Generic.List(Of ComDataAC29FileDetail)
            Get
                ComDataAC29FileDetails = _ComDataAC29FileDetails
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal File As String, ByVal FileLines As Generic.List(Of String))

            'objects
            Dim FileDetailLines As Generic.List(Of String) = Nothing

            _FileLines = FileLines
            _File = File
            _ComDataAC29FileDetails = New Generic.List(Of ComDataAC29FileDetail)
            FileDetailLines = New Generic.List(Of String)

            If Me.FileLines IsNot Nothing AndAlso Me.FileLines.Count > 0 Then

                For Each FileLine In FileLines

                    If FileLine.StartsWith("1000") Then

                        _Line1000 = FileLine

                    ElseIf FileLine.StartsWith("9999") Then

                        _Line9999 = FileLine

                    Else

                        If FileLine.StartsWith("1001") Then

                            If FileDetailLines.Count = 0 Then

                                FileDetailLines.Add(FileLine)

                            Else

                                _ComDataAC29FileDetails.Add(New ComDataAC29FileDetail(Me, FileDetailLines))

                                FileDetailLines.Clear()
                                FileDetailLines.Add(FileLine)

                            End If

                        Else

                            FileDetailLines.Add(FileLine)

                        End If

                    End If

                Next

                _ComDataAC29FileDetails.Add(New ComDataAC29FileDetail(Me, FileDetailLines))

            End If

        End Sub

#End Region

    End Class

End Namespace

