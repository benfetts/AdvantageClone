Namespace Reporting.Database.Classes

    <Serializable>
    Public Class TimeReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            JobComponent
            Hours
            HoursAmount
            HoursWithMarkupOrMarkdown
            TotalAmountWithResaleTax
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _Hours As Decimal = Nothing
        Private _HoursAmount As Decimal = Nothing
        Private _HoursWithMarkupOrMarkdown As Decimal = Nothing
        Private _TotalAmountWithResaleTax As Decimal = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Hours() As Decimal
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Decimal)
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property HoursAmount() As Decimal
            Get
                HoursAmount = _HoursAmount
            End Get
            Set(ByVal value As Decimal)
                _HoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property HoursWithMarkupOrMarkdown() As Decimal
            Get
                HoursWithMarkupOrMarkdown = _HoursWithMarkupOrMarkdown
            End Get
            Set(ByVal value As Decimal)
                _HoursWithMarkupOrMarkdown = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalAmountWithResaleTax() As Decimal
            Get
                TotalAmountWithResaleTax = _TotalAmountWithResaleTax
            End Get
            Set(ByVal value As Decimal)
                _TotalAmountWithResaleTax = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
