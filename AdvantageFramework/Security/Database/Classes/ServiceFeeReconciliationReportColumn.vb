Namespace Security.Database.Classes

    <Serializable()>
    Public Class ServiceFeeReconciliationReportColumn

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FieldName
            HeaderText
            IsVisible
            SortIndex
            SortOrder
            GroupIndex
            Width
            VisibleIndex
        End Enum

#End Region

#Region " Variables "

        Private _FieldName As String = Nothing
        Private _HeaderText As String = Nothing
        Private _IsVisible As Boolean = Nothing
        Private _SortIndex As Integer = Nothing
        Private _SortOrder As Integer = Nothing
        Private _GroupIndex As Integer = Nothing
        Private _Width As Double = Nothing
        Private _VisibleIndex As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FieldName() As String
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeaderText() As String
            Get
                HeaderText = _HeaderText
            End Get
            Set(ByVal value As String)
                _HeaderText = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsVisible() As Boolean
            Get
                IsVisible = _IsVisible
            End Get
            Set(ByVal value As Boolean)
                _IsVisible = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SortIndex() As Integer
            Get
                SortIndex = _SortIndex
            End Get
            Set(ByVal value As Integer)
                _SortIndex = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SortOrder() As Integer
            Get
                SortOrder = _SortOrder
            End Get
            Set(ByVal value As Integer)
                _SortOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GroupIndex() As Integer
            Get
                GroupIndex = _GroupIndex
            End Get
            Set(ByVal value As Integer)
                _GroupIndex = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Width() As Double
            Get
                Width = _Width
            End Get
            Set(ByVal value As Double)
                _Width = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VisibleIndex() As Integer
            Get
                VisibleIndex = _VisibleIndex
            End Get
            Set(ByVal value As Integer)
                _VisibleIndex = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FieldName

        End Function

#End Region

    End Class

End Namespace