Namespace MediaManager.Classes

    <Serializable()>
    Public Class VendorCollectedDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            OrderNumber
            LineNumber
            OrderDescription
            Quantity
            Rate
            GrossAmount
            CommissionPercent
            NetAmount
            Notes
            AuthorizedBy
            AuthorizedByName
            CreatedDate
            ModifiedDate
            Comments
            ID
        End Enum

#End Region

#Region " Variables "

        Private _CreatedDate As Date = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MediaType As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OrderNumber As Integer = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property LineNumber As Short = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property RevisionNumber As Short = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property IsQuote As Boolean = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OrderDescription As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Quantity As Decimal = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Rate As Decimal = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property GrossAmount As Decimal = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property CommissionPercent As Decimal = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property NetAmount As Decimal = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Notes As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property AuthorizedBy As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property AuthorizedByName As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property CreatedDate As Date
            Get
                CreatedDate = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _CreatedDate)
            End Get
            Set(value As Date)
                _CreatedDate = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property ModifiedDate As Nullable(Of Date)
            Get
                ModifiedDate = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _ModifiedDate)
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset
            Set(value As AdvantageFramework.VCC.Classes.TimezoneOffset)
                _TimezoneOffset = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comments As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer = Nothing

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
