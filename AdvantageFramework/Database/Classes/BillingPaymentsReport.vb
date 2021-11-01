Namespace Database.Classes

    <Serializable()>
    Public Class BillingPaymentsReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceDate
            InvoiceAmount
            CheckNumber
            CheckDate
            CheckAmount
            JobNumber
            JobComponentNumber
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _CheckNumber As String = Nothing
        Private _CheckDate As Date = Nothing
        Private _CheckAmount As Nullable(Of Decimal) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "


        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property InvoiceAmount() As Nullable(Of Decimal)
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property CheckNumber() As String
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(ByVal value As String)
                _CheckNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Nullable(Of Date)
            Get
                CheckDate = _CheckDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CheckDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CheckAmount() As Nullable(Of Decimal)
            Get
                CheckAmount = _CheckAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CheckAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
