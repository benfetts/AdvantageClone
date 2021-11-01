Namespace Services.QvAAlert.Classes

    <Serializable()>
    Public Class QvASendAlerts
        Implements IDisposable

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DisposedValue As Boolean = False
        Private _EmployeeList As List(Of QvAEmployee) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property EmployeeList As List(Of QvAEmployee)
            Get
                EmployeeList = _EmployeeList
            End Get
        End Property

#End Region

#Region " Methods "

        Private Function FindEmployee(ByVal NewEmployee As String) As QvAEmployee

            'objects
            Dim QvAEmployee As QvAEmployee = Nothing

            Try

                If _EmployeeList IsNot Nothing Then

                    If _EmployeeList.Count > 0 Then

                        For Each Employee In _EmployeeList

                            If NewEmployee = Employee.EmployeeCode Then

                                QvAEmployee = Employee

                                Exit For

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                QvAEmployee = Nothing
            End Try

            FindEmployee = QvAEmployee

        End Function
        Private Sub AddEmployee(ByVal QvAEmployee As QvAEmployee)

            If _EmployeeList Is Nothing Then

                _EmployeeList = New List(Of QvAEmployee)()

            End If

            _EmployeeList.Add(QvAEmployee)

        End Sub
        Public Sub AddJob(ByRef QvAJob As QvAJob)

            'objects
            Dim NewJob As QvAJob = Nothing
            Dim NewEmployee As QvAEmployee = Nothing

            For Each Employee In QvAJob.AccessList

                NewJob = New QvAJob(QvAJob, True)

                NewEmployee = FindEmployee(Employee)

                If NewEmployee Is Nothing Then

                    NewEmployee = New QvAEmployee(Employee, NewJob)

                    AddEmployee(NewEmployee)

                Else

                    NewEmployee.AddJob(NewJob)

                End If

            Next

        End Sub
        Protected Overridable Sub Dispose(disposing As Boolean)

            If Not _DisposedValue Then

                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    If EmployeeList IsNot Nothing Then

                        For Each Employee In _EmployeeList

                            Try

                                If Employee IsNot Nothing Then

                                    Employee.Dispose()

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                        _EmployeeList.Clear()

                        _EmployeeList = Nothing

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