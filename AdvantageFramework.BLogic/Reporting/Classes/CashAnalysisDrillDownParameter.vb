Namespace Reporting.Classes

    <Serializable()>
    Public Class CashAnalysisDrillDownParameter
        Implements AdvantageFramework.Reporting.Interfaces.IDynamicReportDrillDownParameter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StartingPostPeriodCode
            EndingPostPeriodCode
            ClientCode
            ColumnName
        End Enum

#End Region

#Region " Variables "

        Private _StartingPostPeriodCode As String = ""
        Private _EndingPostPeriodCode As String = ""
        Private _ClientCode As String = ""
        Private _ColumnName As String = ""

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property StartingPostPeriodCode() As String
            Get
                StartingPostPeriodCode = _StartingPostPeriodCode
            End Get
            Set(value As String)
                _StartingPostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property EndingPostPeriodCode() As String
            Get
                EndingPostPeriodCode = _EndingPostPeriodCode
            End Get
            Set(value As String)
                _EndingPostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property ColumnName() As String
            Get
                ColumnName = _ColumnName
            End Get
            Set(value As String)
                _ColumnName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal StartingPostPeriodCode As String, ByVal EndingPostPeriodCode As String, ByVal ClientCode As String, ByVal ColumnName As String)

            _StartingPostPeriodCode = StartingPostPeriodCode
            _EndingPostPeriodCode = EndingPostPeriodCode
            _ClientCode = ClientCode
            _ColumnName = ColumnName

        End Sub

#End Region

    End Class

End Namespace
