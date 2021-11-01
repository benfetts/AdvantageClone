Public Class OutputFilterStream
    Inherits System.IO.Stream

    Private ReadOnly InnerStream As System.IO.Stream
    Private ReadOnly CopyStream As System.IO.MemoryStream

    Public Sub New(ByVal inner As System.IO.Stream)
        Me.InnerStream = inner
        Me.CopyStream = New System.IO.MemoryStream()
    End Sub

    Public Function ReadStream() As String
        SyncLock Me.InnerStream

            If Me.CopyStream.Length <= 0L OrElse Not Me.CopyStream.CanRead OrElse Not Me.CopyStream.CanSeek Then
                Return String.Empty
            End If

            Dim pos As Long = Me.CopyStream.Position
            Me.CopyStream.Position = 0L

            Try
                Return New System.IO.StreamReader(Me.CopyStream).ReadToEnd()
            Finally

                Try
                    Me.CopyStream.Position = pos
                Catch
                End Try
            End Try
        End SyncLock
    End Function

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return Me.InnerStream.CanRead
        End Get
    End Property

    Public Overrides ReadOnly Property CanSeek As Boolean
        Get
            Return Me.InnerStream.CanSeek
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return Me.InnerStream.CanWrite
        End Get
    End Property

    Public Overrides Sub Flush()
        Me.InnerStream.Flush()
    End Sub

    Public Overrides ReadOnly Property Length As Long
        Get
            Return Me.InnerStream.Length
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            Return Me.InnerStream.Position
        End Get
        Set(ByVal value As Long)
            Me.InnerStream.Position = value
            Me.CopyStream.Position = value
        End Set
    End Property

    Public Overrides Function Read(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer) As Integer
        Return Me.InnerStream.Read(buffer, offset, count)
    End Function

    Public Overrides Function Seek(ByVal offset As Long, ByVal origin As System.IO.SeekOrigin) As Long
        Me.CopyStream.Seek(offset, origin)
        Return Me.InnerStream.Seek(offset, origin)
    End Function

    Public Overrides Sub SetLength(ByVal value As Long)
        Me.CopyStream.SetLength(value)
        Me.InnerStream.SetLength(value)
    End Sub

    Public Overrides Sub Write(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer)
        Me.CopyStream.Write(buffer, offset, count)
        Me.InnerStream.Write(buffer, offset, count)
    End Sub

End Class
