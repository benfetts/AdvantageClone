Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class CustomEstimateReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EstimateReportType
            Description
            CreateByUserCode
            CreatedDate
            UpdatedByUserCode
            UpdatedDate
            ReportDefinition
            EstimateReportCategoryID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EstimateReportType As Integer = Nothing
        Private _Description As String = Nothing
        Private _CreateByUserCode As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _UpdatedByUserCode As String = Nothing
        Private _UpdatedDate As Date = Nothing
        Private _ReportDefinition As String = Nothing
        Private _EstimateReportCategoryID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
       Public Property EstimateReportType() As Integer
            Get
                EstimateReportType = _EstimateReportType
            End Get
            Set(value As Integer)
                _EstimateReportType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreateByUserCode
            End Get
            Set(ByVal value As String)
                _CreateByUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(ByVal value As Date)
                _CreatedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedByUserCode() As String
            Get
                UpdatedByUserCode = _UpdatedByUserCode
            End Get
            Set(ByVal value As String)
                _UpdatedByUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedDate() As Date
            Get
                UpdatedDate = _UpdatedDate
            End Get
            Set(ByVal value As Date)
                _UpdatedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReportDefinition() As String
            Get
                ReportDefinition = _ReportDefinition
            End Get
            Set(ByVal value As String)
                _ReportDefinition = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateReportCategoryID() As Nullable(Of Integer)
            Get
                EstimateReportCategoryID = _EstimateReportCategoryID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateReportCategoryID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal CustomEstimate As AdvantageFramework.Reporting.Database.Entities.EstimateReport)

            'objects
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            Me.ID = CustomEstimate.ID
            'Me.ReportType = Reporting.UDRTypes.Estimate
            'Me.ReportCategoryID = EstimateReport.EstimateReportCategoryID
            'Me.ReportCategory = If(EstimateReport.UserDefinedReportCategory IsNot Nothing, EstimateReport.UserDefinedReportCategory.Description, Nothing)

            Me.Description = CustomEstimate.Description
            Me.CreatedByUserCode = CustomEstimate.CreateByUserCode
            Me.CreatedDate = CustomEstimate.CreatedDate
            Me.UpdatedByUserCode = CustomEstimate.UpdatedByUserCode
            Me.UpdatedDate = CustomEstimate.UpdatedDate
            Me.ReportDefinition = CustomEstimate.ReportDefinition

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
