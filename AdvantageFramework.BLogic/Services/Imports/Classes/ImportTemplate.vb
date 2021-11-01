Namespace Services.Imports.Classes

    Public Class ImportTemplate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdvantageServiceImportID
            ImportTemplateType
            TemplateName
            IsSystemTemplate
        End Enum

#End Region

#Region " Variables "

        Private _ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
        Private _AdvantageServiceImportID As Long = Nothing
        Private _ImportTemplateTypeName As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AdvantageServiceImportID() As Long
            Get
                AdvantageServiceImportID = _AdvantageServiceImportID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Import Type")>
        Public ReadOnly Property ImportTemplateTypeName() As String
            Get
                ImportTemplateTypeName = _ImportTemplateTypeName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TemplateName() As String
            Get
                TemplateName = _ImportTemplate.Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsSystemTemplate() As Boolean
            Get
                IsSystemTemplate = _ImportTemplate.IsSystemTemplate
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, ByVal AdvantageServiceImportID As Long)

            Dim ImportTemplateTypeName As Generic.KeyValuePair(Of Long, String) = Nothing

            _ImportTemplate = ImportTemplate

            _AdvantageServiceImportID = AdvantageServiceImportID

            Try

                ImportTemplateTypeName = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.ImportTemplateTypes)) _
                                          Where KeyValuePair.Key = CLng(ImportTemplate.Type) _
                                          Select KeyValuePair).SingleOrDefault

            Catch ex As Exception
                ImportTemplateTypeName = Nothing
            End Try

            If ImportTemplateTypeName.Key = AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default Then

                _ImportTemplateTypeName = "PTO Default"

            ElseIf ImportTemplateTypeName.Key = AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default Then

                _ImportTemplateTypeName = "Media Results Default"

            ElseIf ImportTemplateTypeName.Key = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                _ImportTemplateTypeName = "Accounts Payable 4A's Broadcast"

            Else

                _ImportTemplateTypeName = ImportTemplateTypeName.Value.ToString.Replace("_", "")

            End If

        End Sub

#End Region

    End Class

End Namespace

