Namespace GeneralLedger.Classes

    <Serializable()>
    Public Class GLAOtherCode
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            AddedForChartOfAccountWizard
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = ""
        Private _AddedForChartOfAccountWizard As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=True, CustomColumnCaption:="Other Code", PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property Code As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AddedForChartOfAccountWizard() As Boolean
            Get
                AddedForChartOfAccountWizard = _AddedForChartOfAccountWizard
            End Get
            Set(ByVal value As Boolean)
                _AddedForChartOfAccountWizard = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal OtherCode As String)

            _Code = OtherCode

        End Sub

#End Region

    End Class

End Namespace
