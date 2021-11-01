Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class GLReportRow

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ReportName
            Description
            Visible
            ReportType
            DisplayType
            Balance
            IndentSpaces
            Rollup
            Styles
            SuppressIfAllZeros
            AccountRowSelection
            AccountGroupUsed
            AccountTypeSelected
            AccountFrom
            AccountTo
            BaseOnly
            DataCalculation
            DataOption
        End Enum

#End Region

#Region " Variables "

        Private _ReportName As String = Nothing
        Private _Description As String = Nothing
        Private _Visible As String = Nothing
        Private _ReportType As String = Nothing
        Private _DisplayType As String = Nothing
        Private _Balance As String = Nothing
        Private _IndentSpaces As Integer = Nothing
        Private _Rollup As String = Nothing
        Private _Styles As String = Nothing
        Private _SuppressIfAllZeros As String = Nothing
        Private _AccountRowSelection As Integer = Nothing
        Private _AccountGroupUsed As String = Nothing
        Private _AccountTypeSelected As String = Nothing
        Private _AccountFrom As String = Nothing
        Private _AccountTo As String = Nothing
        Private _BaseOnly As String = Nothing
        Private _DataCalculation As String = Nothing
        Private _DataOption As String = Nothing


#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportName() As String
            Get
                ReportName = _ReportName
            End Get
            Set
                _ReportName = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set
                _Description = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Visible() As String
            Get
                Visible = _Visible
            End Get
            Set
                _Visible = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportType() As String
            Get
                ReportType = _ReportType
            End Get
            Set
                _ReportType = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DisplayType() As String
            Get
                DisplayType = _DisplayType
            End Get
            Set(value As String)
                _DisplayType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Balance() As String
            Get
                Balance = _Balance
            End Get
            Set(value As String)
                _Balance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IndentSpaces() As Integer
            Get
                IndentSpaces = _IndentSpaces
            End Get
            Set(value As Integer)
                _IndentSpaces = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rollup() As String
            Get
                Rollup = _Rollup
            End Get
            Set
                _Rollup = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Styles() As String
            Get
                Styles = _Styles
            End Get
            Set
                _Styles = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppressIfAllZeros() As String
            Get
                SuppressIfAllZeros = _SuppressIfAllZeros
            End Get
            Set
                _SuppressIfAllZeros = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountRowSelection() As Integer
            Get
                AccountRowSelection = _AccountRowSelection
            End Get
            Set(value As Integer)
                _AccountRowSelection = value
            End Set
        End Property
        Public Property AccountGroupUsed() As String
            Get
                AccountGroupUsed = _AccountGroupUsed
            End Get
            Set
                _AccountGroupUsed = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountTypeSelected() As String
            Get
                AccountTypeSelected = _AccountTypeSelected
            End Get
            Set(value As String)
                _AccountTypeSelected = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountFrom() As String
            Get
                AccountFrom = _AccountFrom
            End Get
            Set
                _AccountFrom = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountTo() As String
            Get
                AccountTo = _AccountTo
            End Get
            Set
                _AccountTo = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BaseOnly() As String
            Get
                BaseOnly = _BaseOnly
            End Get
            Set
                _BaseOnly = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DataCalculation() As String
            Get
                DataCalculation = _DataCalculation
            End Get
            Set(value As String)
                _DataCalculation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DataOption() As String
            Get
                DataOption = _DataOption
            End Get
            Set(value As String)
                _DataOption = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ReportName.ToString

        End Function

#End Region

    End Class

End Namespace
