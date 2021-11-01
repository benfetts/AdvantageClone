Namespace Services.Exports.Classes

    Public Class ExportTemplate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdvantageServiceExportID
            ExportTemplateType
            ExportTemplateTypeName
            TemplateName
            IsSystemTemplate
        End Enum

#End Region

#Region " Variables "

        Private _ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
        Private _AdvantageServiceExportID As Long = Nothing
        Private _ExportTemplateTypeName As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AdvantageServiceExportID() As Long
            Get
                AdvantageServiceExportID = _AdvantageServiceExportID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ExportTemplateType() As Short
            Get
                ExportTemplateType = _ExportTemplate.Type
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Export Type")>
        Public ReadOnly Property ExportTemplateTypeName() As String
            Get
                ExportTemplateTypeName = _ExportTemplateTypeName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TemplateName() As String
            Get
                TemplateName = _ExportTemplate.Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsSystemTemplate() As Boolean
            Get
                IsSystemTemplate = _ExportTemplate.IsSystemTemplate
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate, ByVal AdvantageServiceExportID As Long)

            Dim ExportTemplateTypeName As Generic.KeyValuePair(Of Long, String) = Nothing

            _ExportTemplate = ExportTemplate

            _AdvantageServiceExportID = AdvantageServiceExportID

            If _ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails Then

                _ExportTemplateTypeName = "YayPay Export"

            Else

                Try

                    ExportTemplateTypeName = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Exporting.ExportTypes))
                                              Where KeyValuePair.Key = CLng(ExportTemplate.Type)
                                              Select KeyValuePair).SingleOrDefault

                Catch ex As Exception
                    ExportTemplateTypeName = Nothing
                End Try

                _ExportTemplateTypeName = ExportTemplateTypeName.Value.ToString.Replace("_", "")

            End If

        End Sub

#End Region

    End Class

End Namespace
