Namespace Database.Classes

    <Serializable()>
    Public Class WorkflowAlert
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AlertID
            CurrentAlertTemplateID
            CurrentAlertStateID
            NewAlertStateID
            NewDefaultEmployeeCode
            NewStateIsUnassigned
            CurrentStateOrder
            NewStateOrder

        End Enum

#End Region

#Region " Variables "

        Private _AlertID As Nullable(Of Integer) = Nothing
        Private _CurrentAlertTemplateID As Nullable(Of Integer) = Nothing
        Private _CurrentAlertStateID As Nullable(Of Integer) = Nothing
        Private _NewAlertStateID As Nullable(Of Integer) = Nothing
        Private _NewDefaultEmployeeCode As String = Nothing
        Private _NewStateIsUnassigned As Nullable(Of Boolean) = Nothing
        Private _CurrentStateOrder As Nullable(Of Integer) = Nothing
        Private _NewStateOrder As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Nullable(Of Integer)
            Get
                AlertID = _AlertID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AlertID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentAlertTemplateID() As Nullable(Of Integer)
            Get
                CurrentAlertTemplateID = _CurrentAlertTemplateID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CurrentAlertTemplateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentAlertStateID() As Nullable(Of Integer)
            Get
                CurrentAlertStateID = _CurrentAlertStateID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CurrentAlertStateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewAlertStateID() As Nullable(Of Integer)
            Get
                NewAlertStateID = _NewAlertStateID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _NewAlertStateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewDefaultEmployeeCode() As String
            Get
                NewDefaultEmployeeCode = _NewDefaultEmployeeCode
            End Get
            Set(ByVal value As String)
                _NewDefaultEmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewStateIsUnassigned() As Nullable(Of Boolean)
            Get
                NewStateIsUnassigned = _NewStateIsUnassigned
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewStateIsUnassigned = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentStateOrder() As Nullable(Of Integer)
            Get
                CurrentStateOrder = _CurrentStateOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CurrentStateOrder = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewStateOrder() As Nullable(Of Integer)
            Get
                NewStateOrder = _NewStateOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _NewStateOrder = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AlertID.ToString()

        End Function

#End Region

    End Class

End Namespace
