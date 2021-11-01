Namespace Database.Classes

    <Serializable()>
    Public Class ContractReportDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContractReport
            ID
            Description
            CycleCode
            LastCompletedDate
            NextStartDate
            NotifyInternalContacts
            EmployeeCode
            AlertDaysPrior
            SendAlertDaysPrior
            SendAlertUponCompletion
            HasDocuments
        End Enum

#End Region

#Region " Variables "

        Private _ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
        Private _HasDocuments As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.ContractReport)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ContractReport As AdvantageFramework.Database.Entities.ContractReport
            Get
                ContractReport = _ContractReport
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID As Integer
            Get
                ID = _ContractReport.ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description As String
            Get
                Description = _ContractReport.Description
            End Get
            Set(ByVal value As String)
                _ContractReport.Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Frequency")>
        Public Property CycleCode As String
            Get
                CycleCode = _ContractReport.CycleCode
            End Get
            Set(ByVal value As String)
                _ContractReport.CycleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastCompletedDate As Nullable(Of Date)
            Get
                LastCompletedDate = _ContractReport.LastCompletedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ContractReport.LastCompletedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NextStartDate As Nullable(Of Date)
            Get
                NextStartDate = _ContractReport.NextStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ContractReport.NextStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NotifyInternalContacts As Boolean
            Get
                NotifyInternalContacts = _ContractReport.NotifyInternalContacts
            End Get
            Set(ByVal value As Boolean)
                _ContractReport.NotifyInternalContacts = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _ContractReport.EmployeeCode
            End Get
            Set(ByVal value As String)
                _ContractReport.EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(UseMaxValue:=True, UseMaxValue:=True, MaxValue:=999)>
        Public Property AlertDaysPrior As Nullable(Of Short)
            Get
                AlertDaysPrior = _ContractReport.AlertDaysPrior
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ContractReport.AlertDaysPrior = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SendAlertDaysPrior As Boolean
            Get
                SendAlertDaysPrior = _ContractReport.SendAlertDaysPrior
            End Get
            Set(ByVal value As Boolean)
                _ContractReport.SendAlertDaysPrior = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SendAlertUponCompletion As Boolean
            Get
                SendAlertUponCompletion = _ContractReport.SendAlertUponCompletion
            End Get
            Set(ByVal value As Boolean)
                _ContractReport.SendAlertUponCompletion = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property HasDocuments As Boolean
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(ByVal value As Boolean)
                _HasDocuments = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ContractReport = New AdvantageFramework.Database.Entities.ContractReport

        End Sub
        Public Sub New(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport)

            _ContractReport = ContractReport

            _HasDocuments = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadByContractReportID(DataContext, _ContractReport.ID).Any

        End Sub

#End Region

    End Class

End Namespace
