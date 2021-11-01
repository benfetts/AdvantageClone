Namespace Services.QvAAlert.Classes

    <Serializable()>
    Public Class QvAEmployee
        Implements IDisposable

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DisposedValue As Boolean = False
        Private _EmployeeCode As String = Nothing
        Private _JobsList As List(Of QvAJob) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property JobsList As List(Of QvAJob)
            Get
                JobsList = _JobsList
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal EmployeeCode As String, ByRef QvAJob As QvAJob)

            _EmployeeCode = EmployeeCode

            AddJob(QvAJob)

        End Sub
        Public Sub AddJob(ByRef QvAJob As QvAJob)

            'objects
            Dim NewQvAJob As QvAJob = Nothing

            If _JobsList Is Nothing Then

                _JobsList = New List(Of QvAJob)()

            End If

            NewQvAJob = New QvAJob(QvAJob, True)

            _JobsList.Add(NewQvAJob)

        End Sub
        Protected Overridable Sub Dispose(disposing As Boolean)

            If Not _DisposedValue Then

                If disposing Then

                    If JobsList IsNot Nothing Then

                        For Each Job In JobsList

                            Try

                                If Job IsNot Nothing Then

                                    Job.Dispose()

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                        _JobsList.Clear()

                        _JobsList = Nothing

                    End If

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
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)

        End Sub

#End Region

    End Class

End Namespace
