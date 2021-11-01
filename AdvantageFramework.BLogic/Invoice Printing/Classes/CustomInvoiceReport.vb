Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class CustomInvoiceReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            'ReportType
            'ReportCategoryID
            'ReportCategory
            Description
            InvoiceType
            InvoiceTypeID
            CreatedByUserCode
            CreatedDate
            UpdatedByUserCode
            UpdatedDate
            ReportDefinition
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        'Private _ReportType As AdvantageFramework.Reporting.UDRTypes = AdvantageFramework.Reporting.UDRTypes.Advanced
        'Private _ReportCategoryID As Nullable(Of Integer) = Nothing
        'Private _ReportCategory As String = Nothing
        Private _Description As String = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceTypeID As Integer = Nothing
        Private _CreatedByUserCode As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _UpdatedByUserCode As String = Nothing
        Private _UpdatedDate As Date = Nothing
        Private _ReportDefinition As String = Nothing

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
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property ReportType() As AdvantageFramework.Reporting.UDRTypes
        '    Get
        '        ReportType = _ReportType
        '    End Get
        '    Set(ByVal value As AdvantageFramework.Reporting.UDRTypes)
        '        _ReportType = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property ReportCategoryID() As Nullable(Of Integer)
        '    Get
        '        ReportCategoryID = _ReportCategoryID
        '    End Get
        '    Set(ByVal value As Nullable(Of Integer))
        '        _ReportCategoryID = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property ReportCategory() As String
        '    Get
        '        ReportCategory = _ReportCategory
        '    End Get
        '    Set(ByVal value As String)
        '        _ReportCategory = value
        '    End Set
        'End Property
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
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(ByVal value As String)
                _InvoiceType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property InvoiceTypeID() As Integer
            Get
                InvoiceTypeID = _InvoiceTypeID
            End Get
            Set(ByVal value As Integer)
                _InvoiceTypeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreatedByUserCode
            End Get
            Set(ByVal value As String)
                _CreatedByUserCode = value
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

#End Region

#Region " Methods "

        Public Sub New(ByVal CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice, InvoiceTypes As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))

            'objects
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            Me.ID = CustomInvoice.ID
            'Me.ReportType = Reporting.UDRTypes.Estimate
            'Me.ReportCategoryID = EstimateReport.EstimateReportCategoryID
            'Me.ReportCategory = If(EstimateReport.UserDefinedReportCategory IsNot Nothing, EstimateReport.UserDefinedReportCategory.Description, Nothing)

            Try

                If InvoiceTypes IsNot Nothing Then

                    EnumObject = InvoiceTypes.SingleOrDefault(Function(EObject) EObject.Code = CustomInvoice.Type)

                End If
                
            Catch ex As Exception
                EnumObject = Nothing
            End Try

            If EnumObject IsNot Nothing Then

                Me.InvoiceType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.InvoicePrinting.InvoiceTypes), CustomInvoice.Type)
                Me.InvoiceTypeID = CustomInvoice.Type

            End If

            Me.Description = CustomInvoice.Description
            Me.CreatedByUserCode = CustomInvoice.CreatedByUserCode
            Me.CreatedDate = CustomInvoice.CreatedDate
            Me.UpdatedByUserCode = CustomInvoice.UpdatedByUserCode
            Me.UpdatedDate = CustomInvoice.UpdatedDate
            Me.ReportDefinition = CustomInvoice.ReportDefinition

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
