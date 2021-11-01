Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EPEstimateFunctionComment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateDesc
            EstimateComponentNumber
            EstimateCompDesc
            QuoteNumber
            QuoteDesc
            RevisionNumber
            FunctionCode
            FunctionDescription
            Comment
            SuppliedByNotes
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumber As Integer = Nothing
        Private _EstimateDesc As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateCompDesc As String = Nothing
        Private _QuoteNumber As String = Nothing
        Private _QuoteDesc As String = Nothing
        Private _RevisionNumber As Short = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Comment As String = Nothing
        Private _SuppliedByNotes As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateDesc() As String
            Get
                EstimateDesc = _EstimateDesc
            End Get
            Set(value As String)
                _EstimateDesc = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateComponentNumber() As Short
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Short)
                _EstimateComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateCompDesc() As String
            Get
                EstimateCompDesc = _EstimateCompDesc
            End Get
            Set(value As String)
                _EstimateCompDesc = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property QuoteNumber() As String
            Get
                QuoteNumber = _QuoteNumber
            End Get
            Set(value As String)
                _QuoteNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property QuoteDesc() As String
            Get
                QuoteDesc = _QuoteDesc
            End Get
            Set(value As String)
                _QuoteDesc = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property RevisionNumber() As String
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As String)
                _RevisionNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property SuppliedByNotes() As String
            Get
                SuppliedByNotes = _SuppliedByNotes
            End Get
            Set(value As String)
                _SuppliedByNotes = value
            End Set
        End Property


#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EstimateFunctionComment As AdvantageFramework.Database.Views.EstimateFunctionComment)

            Me.EstimateNumber = EstimateFunctionComment.EstimateNumber
            Me.EstimateDesc = EstimateFunctionComment.EstimateDesc
            Me.EstimateComponentNumber = EstimateFunctionComment.EstimateComponentNumber
            Me.EstimateCompDesc = EstimateFunctionComment.EstimateCompDesc
            Me.QuoteNumber = EstimateFunctionComment.QuoteNumber
            Me.QuoteDesc = EstimateFunctionComment.QuoteDesc
            Me.FunctionCode = EstimateFunctionComment.FunctionCode
            Me.FunctionDescription = EstimateFunctionComment.FunctionDescription
            Me.Comment = EstimateFunctionComment.Comment
            Me.SuppliedByNotes = EstimateFunctionComment.SuppliedByNotes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace

