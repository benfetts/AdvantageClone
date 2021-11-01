Namespace Services.QvAAlert.Classes

    <Serializable()>
    Public Class QvAJob
        Implements IDisposable

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DisposedValue As Boolean = False
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Integer = Nothing
        Private _ComponentDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _Quoted As Decimal = Nothing
        Private _Actual As Decimal = Nothing
        Private _QvA As Decimal = Nothing
        Private _ThresholdAlert As Integer = Nothing
        Private _FunctionList As List(Of QvAFunction) = Nothing
        Private _AccessList As List(Of String) = Nothing

#End Region

#Region " Properties "

        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property ComponentNumber() As Integer
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Integer)
                _ComponentNumber = value
            End Set
        End Property
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        Public Property Quoted() As Decimal
            Get
                Quoted = _Quoted
            End Get
            Set(ByVal value As Decimal)
                _Quoted = value
            End Set
        End Property
        Public Property Actual() As Decimal
            Get
                Actual = _Actual
            End Get
            Set(ByVal value As Decimal)
                _Actual = value
            End Set
        End Property
        Public Property QvA() As Decimal
            Get
                QvA = _QvA
            End Get
            Set(ByVal value As Decimal)
                _QvA = value
            End Set
        End Property
        Public Property ThresholdAlert() As Integer
            Get
                ThresholdAlert = _ThresholdAlert
            End Get
            Set(ByVal value As Integer)
                _ThresholdAlert = value
            End Set
        End Property
        Public ReadOnly Property FunctionList As List(Of QvAFunction)
            Get
                FunctionList = _FunctionList
            End Get
        End Property
        Public ReadOnly Property AccessList As List(Of String)
            Get
                AccessList = _AccessList
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _JobNumber = 0
            _ComponentNumber = 0

            _JobDescription = ""
            _ComponentDescription = ""

            _ClientCode = ""
            _DivisionCode = ""
            _ProductCode = ""
            _ClientName = ""

            _Quoted = 0D
            _Actual = 0D
            _QvA = 0D
            _ThresholdAlert = 0

            _FunctionList = Nothing
            _AccessList = Nothing

            _FunctionList = New List(Of QvAFunction)
            _AccessList = New List(Of String)

        End Sub
        Public Sub New(ByVal OldJob As QvAJob, ByVal IncludeFunctionList As Boolean)

            _JobNumber = OldJob._JobNumber
            _JobDescription = OldJob._JobDescription

            _ComponentNumber = OldJob._ComponentNumber
            _ComponentDescription = OldJob._ComponentDescription

            _ClientCode = OldJob._ClientCode
            _DivisionCode = OldJob._DivisionCode
            _ProductCode = OldJob._ProductCode
            _ClientName = OldJob._ClientName

            _Quoted = OldJob._Quoted
            _Actual = OldJob._Actual
            _QvA = OldJob._QvA

            _ThresholdAlert = OldJob._ThresholdAlert

            If IncludeFunctionList Then

                SetFunctionList(OldJob._FunctionList)

            End If

            SetAccessList(OldJob._AccessList)

        End Sub
        Public Sub AddFunction(ByRef QvAFunction As QvAFunction)

            If _FunctionList Is Nothing Then

                _FunctionList = New List(Of QvAFunction)

            End If

            _FunctionList.Add(QvAFunction)

        End Sub
        Public Sub AddAccess(ByRef EmployeeCode As String)

            If _AccessList Is Nothing Then

                _AccessList = New List(Of String)

            End If

            _AccessList.Add(EmployeeCode)

        End Sub
        Public Sub SetFunctionList(ByRef FunctionList As List(Of QvAFunction))

            'objects
            Dim NewFunctionList = Nothing

            If FunctionList IsNot Nothing Then

                NewFunctionList = New List(Of QvAFunction)

                For Each [Function] In FunctionList

                    NewFunctionList.Add([Function])

                Next

            End If

            _FunctionList = NewFunctionList

        End Sub
        Public Sub SetAccessList(ByRef AccessList As List(Of String))

            Dim NewAccessList = Nothing

            If AccessList IsNot Nothing Then

                NewAccessList = New List(Of String)

                For Each Access In AccessList

                    NewAccessList.Add(Access)

                Next

            End If

            _AccessList = NewAccessList

        End Sub
        Protected Overridable Sub Dispose(disposing As Boolean)

            If Not _DisposedValue Then

                If disposing Then

                    If _FunctionList IsNot Nothing Then

                        _FunctionList.Clear()

                        _FunctionList = Nothing

                    End If

                    If _AccessList IsNot Nothing Then

                        _AccessList.Clear()

                        _AccessList = Nothing

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
