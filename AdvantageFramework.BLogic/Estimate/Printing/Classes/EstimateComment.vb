Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EPEstimateComment

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
            Comment
            CompComment
            QuoteComment
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumber As Integer = Nothing
        Private _EstimateDesc As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateCompDesc As String = Nothing
        Private _QuoteNumber As Short = Nothing
        Private _QuoteDesc As String = Nothing
        Private _Comment As String = Nothing
        Private _CompComment As String = Nothing
        Private _QuoteComment As String = Nothing

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
        Public Property QuoteNumber() As Short
            Get
                QuoteNumber = _QuoteNumber
            End Get
            Set(value As Short)
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
        Public Property CompComment() As String
            Get
                CompComment = _CompComment
            End Get
            Set(value As String)
                _CompComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property QuoteComment() As String
            Get
                QuoteComment = _QuoteComment
            End Get
            Set(value As String)
                _QuoteComment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EstimateComment As AdvantageFramework.Database.Views.EstimateComment)

            Me.EstimateNumber = EstimateComment.EstimateNumber
            Me.EstimateDesc = EstimateComment.EstimateDesc
            Me.EstimateComponentNumber = EstimateComment.EstimateComponentNumber
            Me.EstimateCompDesc = EstimateComment.EstimateCompDesc
            Me.QuoteNumber = EstimateComment.QuoteNumber
            Me.QuoteDesc = EstimateComment.QuoteDesc
            Me.Comment = EstimateComment.Comment
            Me.CompComment = EstimateComment.CompComment
            Me.QuoteComment = EstimateComment.QuoteComment

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace
