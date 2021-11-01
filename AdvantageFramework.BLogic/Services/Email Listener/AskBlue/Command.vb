Namespace Services.EmailListener.AskBlue

    <Serializable()> _
    Public Class Command
        Implements IDisposable

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DisposedValue As Boolean = False ' To detect redundant calls
        Private _Type As Services.EmailListener.AskBlue.CommandType = Nothing
        Private _Phrase As String = ""
        Private _Action As Services.EmailListener.AskBlue.Action = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Type As Services.EmailListener.AskBlue.CommandType
            Get
                Type = _Type
            End Get
        End Property
        Public ReadOnly Property Phrase As String
            Get
                Phrase = _Phrase
            End Get
        End Property
        Public ReadOnly Property Action As Services.EmailListener.AskBlue.Action
            Get
                Action = _Action
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New(ByVal Type As Services.EmailListener.AskBlue.CommandType, ByVal Action As Services.EmailListener.AskBlue.Action, _
                ByVal Phrase As String)

            _Type = Type
            _Phrase = Phrase
            _Action = Action

        End Sub

#Region "IDisposable Support"

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)

            If Not _DisposedValue Then

                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    _Type = Nothing
                    _Phrase = Nothing

                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.

            End If

            _DisposedValue = True

        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)

        End Sub

#End Region

#End Region

    End Class

End Namespace
