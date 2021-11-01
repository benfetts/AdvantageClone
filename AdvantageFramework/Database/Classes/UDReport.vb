Namespace Database.Classes

    <Serializable()>
    Public Class UDReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ReportType
            ReportCategoryID
            ReportCategory
            Description
            DatasetType
            DatasetTypeID
            CreatedByUserCode
            CreatedDate
            UpdatedByUserCode
            UpdatedDate
            ReportDefinition
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _ReportType As AdvantageFramework.Reporting.UDRTypes = AdvantageFramework.Reporting.UDRTypes.Advanced
        Private _ReportCategoryID As Nullable(Of Integer) = Nothing
        Private _ReportCategory As String = Nothing
        Private _Description As String = Nothing
        Private _DatasetType As String = Nothing
        Private _DatasetTypeID As Integer = Nothing
        Private _CreatedByUserCode As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _UpdatedByUserCode As String = Nothing
        Private _UpdatedDate As Date = Nothing
        Private _ReportDefinition As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReportType() As AdvantageFramework.Reporting.UDRTypes
            Get
                ReportType = _ReportType
            End Get
            Set(ByVal value As AdvantageFramework.Reporting.UDRTypes)
                _ReportType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReportCategoryID() As Nullable(Of Integer)
            Get
                ReportCategoryID = _ReportCategoryID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ReportCategoryID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReportCategory() As String
            Get
                ReportCategory = _ReportCategory
            End Get
            Set(ByVal value As String)
                _ReportCategory = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DatasetType() As String
            Get
                DatasetType = _DatasetType
            End Get
            Set(ByVal value As String)
                _DatasetType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DatasetTypeID() As Integer
            Get
                DatasetTypeID = _DatasetTypeID
            End Get
            Set(ByVal value As Integer)
                _DatasetTypeID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreatedByUserCode
            End Get
            Set(ByVal value As String)
                _CreatedByUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(ByVal value As Date)
                _CreatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedByUserCode() As String
            Get
                UpdatedByUserCode = _UpdatedByUserCode
            End Get
            Set(ByVal value As String)
                _UpdatedByUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedDate() As Date
            Get
                UpdatedDate = _UpdatedDate
            End Get
            Set(ByVal value As Date)
                _UpdatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReportDefinition() As String
            Get
                ReportDefinition = _ReportDefinition
            End Get
            Set(ByVal value As String)
                _ReportDefinition = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport)

            Me.ID = DynamicReport.ID
            Me.ReportType = Reporting.UDRTypes.Dynamic
            Me.ReportCategoryID = DynamicReport.UserDefinedReportCategoryID
            Me.ReportCategory = If(DynamicReport.UserDefinedReportCategory IsNot Nothing, DynamicReport.UserDefinedReportCategory.Description, Nothing)
            Me.DatasetType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.DynamicReports), DynamicReport.Type)
            Me.DatasetTypeID = DynamicReport.Type
            Me.Description = DynamicReport.Description
            Me.CreatedByUserCode = DynamicReport.CreatedByUserCode
            Me.CreatedDate = DynamicReport.CreatedDate
            Me.UpdatedByUserCode = DynamicReport.UpdatedByUserCode
            Me.UpdatedDate = DynamicReport.UpdatedDate
            Me.ReportDefinition = Nothing

        End Sub
        Public Sub New(ByVal UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport)

            Me.ID = UserDefinedReport.ID
            Me.ReportType = Reporting.UDRTypes.Advanced
            Me.ReportCategoryID = UserDefinedReport.UserDefinedReportCategoryID
            Me.ReportCategory = If(UserDefinedReport.UserDefinedReportCategory IsNot Nothing, UserDefinedReport.UserDefinedReportCategory.Description, Nothing)
            Me.DatasetType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.AdvancedReportWriterReports), UserDefinedReport.AdvancedReportWriterType)
            Me.DatasetTypeID = UserDefinedReport.AdvancedReportWriterType
            Me.Description = UserDefinedReport.Description
            Me.CreatedByUserCode = UserDefinedReport.CreatedByUserCode
            Me.CreatedDate = UserDefinedReport.CreatedDate
            Me.UpdatedByUserCode = UserDefinedReport.UpdatedByUserCode
            Me.UpdatedDate = UserDefinedReport.UpdatedDate
            Me.ReportDefinition = UserDefinedReport.ReportDefinition

        End Sub
        Public Sub New(ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport)

            Me.ID = EstimateReport.ID
            Me.ReportType = Reporting.UDRTypes.Estimate
            Me.ReportCategoryID = EstimateReport.EstimateReportCategoryID
            Me.DatasetType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.EstimateReportTypes), EstimateReport.EstimateReportType)
            Me.DatasetTypeID = EstimateReport.EstimateReportType
            Me.Description = EstimateReport.Description
            Me.CreatedByUserCode = EstimateReport.CreateByUserCode
            Me.CreatedDate = EstimateReport.CreatedDate
            Me.UpdatedByUserCode = EstimateReport.UpdatedByUserCode
            Me.UpdatedDate = EstimateReport.UpdatedDate
            Me.ReportDefinition = EstimateReport.ReportDefinition

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
