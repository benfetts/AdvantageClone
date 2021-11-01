Namespace Database.Classes

    Public Class ServiceFee
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobServiceFeeContractID
            IncomeOnlyReference
            InvoiceDate
            Amount
            Description
            IncomeOnlyID
            IncomeOnlySequenceNumber
            Created
        End Enum

#End Region

#Region " Variables "

        Private _JobServiceFeeContractID As Integer = Nothing
        Private _IncomeOnlyReference As String = ""
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _Description As String = ""
        Private _IncomeOnlyID As System.Nullable(Of Integer) = Nothing
        Private _IncomeOnlySequenceNumber As System.Nullable(Of Short) = Nothing
        Private _Created As System.Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobServiceFeeContractID() As Integer
            Get
                JobServiceFeeContractID = _JobServiceFeeContractID
            End Get
            Set(ByVal value As Integer)
                _JobServiceFeeContractID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="I/O Reference", ShowColumnInGrid:=True)>
        Public Property IncomeOnlyReference() As String
            Get
                IncomeOnlyReference = _IncomeOnlyReference
            End Get
            Set(ByVal value As String)
                _IncomeOnlyReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date", ShowColumnInGrid:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="", ShowColumnInGrid:=True)>
        Public Property Amount() As Decimal
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Decimal)
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", ShowColumnInGrid:=True)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", ShowColumnInGrid:=False)>
        Public Property IncomeOnlyID() As System.Nullable(Of Integer)
            Get
                IncomeOnlyID = _IncomeOnlyID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _IncomeOnlyID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", ShowColumnInGrid:=False)>
        Public Property IncomeOnlySequenceNumber() As System.Nullable(Of Short)
            Get
                IncomeOnlySequenceNumber = _IncomeOnlySequenceNumber
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _IncomeOnlySequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property Created() As System.Nullable(Of Boolean)
            Get
                Created = _Created
            End Get
            Set(ByVal value As System.Nullable(Of Boolean))
                _Created = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
