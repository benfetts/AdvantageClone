'Namespace Exporting

'    <HideModuleName()> _
'    Public Module Methods

'#Region " Constants "



'#End Region

'#Region " Enum "

'        Public Enum FileTypes As Short
'            CSV = 1
'            Fixed = 2
'        End Enum

'        Public Enum ExportTypes As Short
'            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Media Plan Data")>
'            MediaPlanData = 1
'            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "GL Detail")>
'            GeneralLedgerDetail = 2
'        End Enum

'        Public Enum DataColumnExtendedProperties
'            Start
'            Length
'            Position
'            PropertyDescriptor
'            Precision
'            Scale
'        End Enum

'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "



'#End Region

'#Region " Methods "

'        Public Function CopyExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateID As Integer, ByRef NewExportTemplateID As Integer, ByVal NewExportTemplateName As String) As Boolean

'            'objects
'            Dim Copied As Boolean = False
'            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
'            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
'            Dim NewExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
'            Dim NewExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
'            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

'            If DbContext.Database.Connection.State = ConnectionState.Closed Then

'                DbContext.Database.Connection.Open()

'            End If

'            DbTransaction = DbContext.Database.BeginTransaction

'            Try

'                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID)

'                If ExportTemplate IsNot Nothing Then

'                    NewExportTemplate = New AdvantageFramework.Database.Entities.ExportTemplate

'                    NewExportTemplate.DbContext = DbContext
'                    NewExportTemplate.Type = ExportTemplate.Type
'                    NewExportTemplate.Name = NewExportTemplateName
'                    NewExportTemplate.FileType = ExportTemplate.FileType
'                    NewExportTemplate.CreatedByUserCode = DbContext.UserCode
'                    NewExportTemplate.CreatedDate = Now
'                    NewExportTemplate.Delimiter = ExportTemplate.Delimiter

'                    If AdvantageFramework.Database.Procedures.ExportTemplate.Insert(DbContext, NewExportTemplate) Then

'                        Copied = True

'                        For Each ExportTemplateDetail In ExportTemplate.ExportTemplateDetails.ToList

'                            NewExportTemplateDetail = New AdvantageFramework.Database.Entities.ExportTemplateDetail

'                            NewExportTemplateDetail.DbContext = DbContext
'                            NewExportTemplateDetail.ExportTemplateID = NewExportTemplate.ID
'                            NewExportTemplateDetail.FieldName = ExportTemplateDetail.FieldName
'                            NewExportTemplateDetail.Start = ExportTemplateDetail.Start
'                            NewExportTemplateDetail.Length = ExportTemplateDetail.Length
'                            NewExportTemplateDetail.Position = ExportTemplateDetail.Position
'                            NewExportTemplateDetail.CreatedByUserCode = DbContext.UserCode
'                            NewExportTemplateDetail.CreatedDate = Now

'                            If AdvantageFramework.Database.Procedures.ExportTemplateDetail.Insert(DbContext, NewExportTemplateDetail) = False Then

'                                Copied = False
'                                Exit For

'                            End If

'                        Next

'                    End If

'                End If

'            Catch ex As Exception
'                Copied = False
'            End Try

'            Try

'                If Copied Then

'                    DbTransaction.Commit()

'                Else

'                    DbTransaction.Rollback()

'                End If

'            Catch ex As Exception
'                Copied = False
'            End Try

'            If Copied Then

'                NewExportTemplateID = NewExportTemplate.ID

'            End If

'            DbContext.Database.Connection.Close()

'            CopyExportTemplate = Copied

'        End Function
'        Public Function CreateDataFilterByExportTemplateType(ByVal ExportType As ExportTypes) As AdvantageFramework.Exporting.Interfaces.IExportDataFilter

'            'objects
'            Dim DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing

'            Select Case ExportType

'                Case ExportTypes.MediaPlanData

'                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData

'                Case ExportTypes.GeneralLedgerDetail

'                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail

'            End Select

'            CreateDataFilterByExportTemplateType = DataFilter

'        End Function
'        Public Function CreateExportFileByExportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ExportType As ExportTypes, _
'                                                         ByVal ExportTemplateID As Integer, ByVal Folder As String, _
'                                                         ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, _
'                                                         ByVal DataTable As System.Data.DataTable, _
'                                                         ByRef FullFileName As String) As Boolean

'            'objects
'            Dim ExportFileCreated As Boolean = False

'            Try

'                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

'                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

'                        ExportFileCreated = CreateExportFileByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplateID, Folder, DataFilter, DataTable, FullFileName)

'                    End Using

'                End Using

'            Catch ex As Exception
'                ExportFileCreated = False
'            End Try

'            CreateExportFileByExportTemplate = ExportFileCreated

'        End Function
'        Public Function CreateExportFileByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, _
'                                                         ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer, _
'                                                         ByVal Folder As String, ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, _
'                                                         ByVal DataTable As System.Data.DataTable, _
'                                                         ByRef FullFileName As String) As Boolean

'            'objects
'            Dim ExportFileCreated As Boolean = False
'            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
'            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing
'            Dim ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail) = Nothing
'            Dim StringBuilder As System.Text.StringBuilder = Nothing
'            Dim Data As String = ""
'            Dim LineData As String = ""
'            Dim FileName As String = ""
'            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
'            Dim FileType As AdvantageFramework.Exporting.FileTypes = FileTypes.CSV

'            Try

'                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID)

'                If ExportTemplate IsNot Nothing Then

'                    ExportTemplateDetails = AdvantageFramework.Database.Procedures.ExportTemplateDetail.LoadByExportTemplateID(DbContext, ExportTemplate.ID).ToList
'                    FileType = ExportTemplate.FileType

'                End If

'                If My.Computer.FileSystem.DirectoryExists(Folder) Then

'                    If DataTable Is Nothing Then

'                        If CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplate, DataFilter, DataTable) = False Then

'                            DataTable = Nothing

'                        End If

'                    End If

'                    If DataTable IsNot Nothing Then

'                        If ExportTemplate IsNot Nothing Then

'                            FileName = ExportTemplate.Name & "_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

'                        Else

'                            FileName = ExportType.ToString & "_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

'                        End If

'                        FullFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & FileName

'                        ExportFields = LoadExportFields(DbContext, ExportType, ExportTemplateDetails)

'                        StringBuilder = New System.Text.StringBuilder

'                        If FileType = AdvantageFramework.Exporting.FileTypes.CSV Then

'                            FullFileName = FullFileName & ".csv"

'                            ExportFields = ExportFields.OrderBy(Function(Entity) Entity.Position).ToList

'                            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

'                                LineData = ""

'                                For Each ExportField In ExportFields

'                                    Data = ""

'                                    Data = GetRowData(DataRow(ExportField.FieldName))

'                                    If Data.Contains(",") OrElse Data.Contains("""") Then

'                                        Data = """" & Data.Replace("""", """""") & """"

'                                    End If

'                                    If LineData = "" Then

'                                        LineData = Data

'                                    Else

'                                        LineData = LineData & "," & Data

'                                    End If

'                                Next

'                                StringBuilder.AppendLine(LineData)

'                            Next

'                        ElseIf FileType = AdvantageFramework.Exporting.FileTypes.Fixed Then

'                            FullFileName = FullFileName & ".txt"

'                            ExportTemplateDetails = ExportTemplateDetails.Where(Function(Entity) Entity.Start.HasValue AndAlso Entity.Length.HasValue AndAlso Entity.Length.Value > 0).OrderBy(Function(Entity) Entity.Start).ToList

'                            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

'                                LineData = ""

'                                For Each ExportField In ExportFields

'                                    Data = ""

'                                    Data = GetRowData(DataRow(ExportField.FieldName))

'                                    If LineData.Length <> ExportField.Start.GetValueOrDefault(0) - 1 Then

'                                        LineData = AdvantageFramework.StringUtilities.PadWithCharacter(LineData, ExportField.Start.GetValueOrDefault(0))

'                                    End If

'                                    LineData &= AdvantageFramework.StringUtilities.PadWithCharacter(Data, ExportField.Length.GetValueOrDefault(0))

'                                Next

'                                StringBuilder.AppendLine(LineData)

'                            Next

'                        End If

'                        Try

'                            My.Computer.FileSystem.WriteAllText(FullFileName, StringBuilder.ToString, False)

'                        Catch ex As Exception

'                        End Try

'                        ExportFileCreated = My.Computer.FileSystem.FileExists(FullFileName)

'                    End If

'                End If

'            Catch ex As Exception
'                ExportFileCreated = False
'            End Try

'            CreateExportFileByExportTemplate = ExportFileCreated

'        End Function
'        Public Function CreateExportDataSourceByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, _
'                                                               ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, _
'                                                               ByVal ExportType As ExportTypes, _
'                                                               ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate, _
'                                                               ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, _
'                                                               ByRef DataTable As System.Data.DataTable) As Boolean

'            'objects
'            Dim DataSourceCreated As Boolean = False

'            Try

'                If ExportTemplate IsNot Nothing Then

'                    DataTable = CreateDataTableFromTemplate(DbContext, ExportType, ExportTemplate.ExportTemplateDetails.ToList)

'                Else

'                    DataTable = CreateDataTableFromTemplate(DbContext, ExportType, Nothing)

'                End If

'                DataTable.BeginLoadData()

'                Try

'                    For Each Entity In LoadEntityDataSourceByExportTemplateType(DbContext, SecurityDbContext, ExportType, DataFilter)

'                        InsertRowIntoDataTableFromEntity(DataTable, Entity)

'                    Next

'                    DataSourceCreated = True

'                Catch ex As Exception

'                End Try

'                DataTable.EndLoadData()

'            Catch ex As Exception
'                DataSourceCreated = False
'            Finally
'                CreateExportDataSourceByExportTemplate = DataSourceCreated
'            End Try

'        End Function
'        Public Function CreateExportDataSourceByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, _
'                                                               ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, _
'                                                               ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer, _
'                                                               ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, _
'                                                               ByRef DataTable As System.Data.DataTable) As Boolean

'            'objects
'            Dim DataSourceCreated As Boolean = False

'            Try

'                DataSourceCreated = CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID), DataFilter, DataTable)

'            Catch ex As Exception
'                DataSourceCreated = False
'            Finally
'                CreateExportDataSourceByExportTemplate = DataSourceCreated
'            End Try

'        End Function
'        Public Function CreateExportDataSourceByExportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer, ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, ByRef DataTable As System.Data.DataTable) As Boolean

'            'objects
'            Dim DataSourceCreated As Boolean = False

'            Try

'                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

'                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

'                        DataSourceCreated = CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplateID, DataFilter, DataTable)

'                    End Using

'                End Using

'                DataSourceCreated = True

'            Catch ex As Exception
'                DataSourceCreated = False
'            Finally
'                CreateExportDataSourceByExportTemplate = DataSourceCreated
'            End Try

'        End Function
'        Public Function LoadClassTypeByExportTemplateType(ByVal ExportType As ExportTypes) As System.Type

'            'objects
'            Dim ClassType As System.Type = Nothing

'            Select Case ExportType

'                Case ExportTypes.MediaPlanData

'                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

'                Case ExportTypes.GeneralLedgerDetail

'                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail)

'            End Select

'            LoadClassTypeByExportTemplateType = ClassType

'        End Function
'        Public Function LoadEntityTypeByExportTemplateType(ByVal ExportType As ExportTypes) As System.Type

'            'objects
'            Dim EntityType As System.Type = Nothing

'            Select Case ExportType

'                Case ExportTypes.MediaPlanData

'                    EntityType = GetType(AdvantageFramework.Database.Views.MediaPlanData)

'                Case ExportTypes.GeneralLedgerDetail

'                    EntityType = Nothing

'            End Select

'            LoadEntityTypeByExportTemplateType = EntityType

'        End Function
'        Public Function LoadPropertiesByExportTemplateType(ByVal ExportType As ExportTypes) As Generic.List(Of System.ComponentModel.PropertyDescriptor)

'            'objects
'            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

'            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(LoadClassTypeByExportTemplateType(ExportType)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

'            For Each PropertyDescriptor In PropertyDescriptors.ToList

'                If PropertyDescriptor.PropertyType Is GetType(System.Guid) Then

'                    PropertyDescriptors.Remove(PropertyDescriptor)

'                ElseIf PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Any(Function(EA) EA.ShowColumnInGrid = False) OrElse _
'                        PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any(Function(BA) BA.Browsable = False) Then

'                    PropertyDescriptors.Remove(PropertyDescriptor)

'                End If

'            Next

'            LoadPropertiesByExportTemplateType = PropertyDescriptors

'        End Function
'        Public Function LoadFieldNamesByExportTemplateType(ByVal ExportType As ExportTypes) As Generic.List(Of String)

'            'objects
'            Dim FieldNames As Generic.List(Of String) = Nothing

'            FieldNames = LoadPropertiesByExportTemplateType(ExportType).Select(Function(PropertyDescriptor) PropertyDescriptor.Name).ToList

'            LoadFieldNamesByExportTemplateType = FieldNames

'        End Function
'        Private Function LoadEntityDataSourceByExportTemplateType(ByVal DbContext As AdvantageFramework.Database.DbContext, _
'                                                                  ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, _
'                                                                  ByVal ExportType As ExportTypes, _
'                                                                  ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter) As IEnumerable

'            'objects
'            Dim DataSource As IEnumerable = Nothing

'            Select Case ExportType

'                Case ExportTypes.MediaPlanData

'                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData)(DataFilter.EntityFilterString).ToList

'                Case ExportTypes.GeneralLedgerDetail

'                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail)(DataFilter.EntityFilterString).ToList

'            End Select

'            LoadEntityDataSourceByExportTemplateType = DataSource

'        End Function
'        Private Function InsertRowIntoDataTableFromEntity(ByVal DataTable As System.Data.DataTable, _
'                                                          ByVal Entity As Object) As Boolean

'            'objects
'            Dim RowInserted As Boolean = False
'            Dim DataRow As System.Data.DataRow = Nothing
'            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
'            Dim PropertyValue As Object = Nothing

'            Try

'                DataRow = DataTable.NewRow

'                For Each DataColumn In DataTable.Columns

'                    Try

'                        PropertyDescriptor = DataColumn.ExtendedProperties("PropertyDescriptor")

'                    Catch ex As Exception
'                        PropertyDescriptor = Nothing
'                    End Try

'                    If PropertyDescriptor IsNot Nothing Then

'                        Try

'                            PropertyValue = PropertyDescriptor.GetValue(Entity)

'                        Catch ex As Exception
'                            PropertyValue = Nothing
'                        End Try

'                        DataRow(DataColumn) = If(PropertyValue Is Nothing, System.DBNull.Value, PropertyValue)

'                    End If

'                Next

'                DataTable.Rows.Add(DataRow)

'                RowInserted = True

'            Catch ex As Exception
'                RowInserted = False
'            End Try

'            InsertRowIntoDataTableFromEntity = RowInserted

'        End Function
'        Private Function LoadExportFields(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportType As ExportTypes, _
'                                          Optional ByVal ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail) = Nothing, _
'                                          Optional ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing, _
'                                          Optional ByVal EntityType As System.Data.Metadata.Edm.EntityType = Nothing) As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)

'            'objects
'            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
'            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
'            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing

'            ExportFields = New Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)

'            If EntityType Is Nothing Then

'                EntityType = AdvantageFramework.BaseClasses.Entity.LoadEntityType(DbContext, LoadEntityTypeByExportTemplateType(ExportType))

'            End If

'            If PropertyDescriptorsList Is Nothing Then

'                Try

'                    PropertyDescriptorsList = LoadPropertiesByExportTemplateType(ExportType)

'                Catch ex As Exception

'                End Try

'            End If

'            If ExportTemplateDetails Is Nothing Then

'                For Each PropertyDescriptor In PropertyDescriptorsList

'                    ExportFields.Add(New AdvantageFramework.Exporting.Classes.ExportField(PropertyDescriptor.Name, ExportFields.Count))

'                Next

'            Else

'                For Each ExportTemplateDetail In ExportTemplateDetails.OrderBy(Function(Entity) Entity.Position).ToList

'                    Try

'                        PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PD) PD.Name = ExportTemplateDetail.FieldName)

'                    Catch ex As Exception
'                        PropertyDescriptor = Nothing
'                    End Try

'                    ExportFields.Add(New AdvantageFramework.Exporting.Classes.ExportField(ExportTemplateDetail, PropertyDescriptor, EntityType))

'                Next

'            End If

'            LoadExportFields = ExportFields

'        End Function
'        Public Function CreateDataTableFromTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportType As ExportTypes, _
'                                                    ByVal ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail)) As System.Data.DataTable

'            'objects
'            Dim DataTable As System.Data.DataTable = Nothing
'            Dim DataColumn As System.Data.DataColumn = Nothing
'            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
'            Dim EntityType As System.Data.Metadata.Edm.EntityType = Nothing
'            Dim MaxLength As Long = 0
'            Dim Precision As Long = 0
'            Dim Scale As Long = 0
'            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
'            Dim EntityObjectType As System.Type = Nothing
'            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
'            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing

'            Try

'                EntityObjectType = LoadEntityTypeByExportTemplateType(ExportType)

'                Try

'                    PropertyDescriptorsList = LoadPropertiesByExportTemplateType(ExportType)

'                Catch ex As Exception

'                End Try

'                If PropertyDescriptorsList IsNot Nothing Then

'                    EntityType = AdvantageFramework.BaseClasses.Entity.LoadEntityType(DbContext, EntityObjectType)

'                    ExportFields = LoadExportFields(DbContext, ExportType, ExportTemplateDetails, PropertyDescriptorsList, EntityType)

'                    DataTable = New System.Data.DataTable

'                    For Each ExportField In ExportFields.OrderBy(Function(Entity) Entity.Position)

'                        MaxLength = -1

'                        Try

'                            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ExportField.FieldName)

'                        Catch ex As Exception
'                            PropertyDescriptor = Nothing
'                        End Try

'                        If PropertyDescriptor IsNot Nothing Then

'                            DataColumn = DataTable.Columns.Add(PropertyDescriptor.Name)

'                            If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

'                                DataColumn.AllowDBNull = True
'                                DataColumn.DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

'                            Else

'                                DataColumn.DataType = PropertyDescriptor.PropertyType

'                            End If

'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Precision.ToString, -1)
'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Scale.ToString, -1)

'                            If DataColumn.DataType Is GetType(String) Then

'                                If EntityType IsNot Nothing Then

'                                    MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))

'                                End If

'                                If MaxLength = 0 Then

'                                    MaxLength = -1

'                                End If

'                                DataColumn.MaxLength = MaxLength

'                            ElseIf DataColumn.DataType Is GetType(Decimal) Then

'                                Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))
'                                Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))

'                                DataColumn.ExtendedProperties(DataColumnExtendedProperties.Precision.ToString) = Precision
'                                DataColumn.ExtendedProperties(DataColumnExtendedProperties.Scale.ToString) = Scale

'                            End If

'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Start.ToString, ExportField.Start.GetValueOrDefault(0))
'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Length.ToString, ExportField.Length.GetValueOrDefault(0))
'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Position.ToString, ExportField.Position)
'                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.PropertyDescriptor.ToString, PropertyDescriptor)

'                        End If

'                    Next

'                End If

'            Catch ex As Exception
'                DataTable = Nothing
'            End Try

'            CreateDataTableFromTemplate = DataTable

'        End Function
'        Private Function GetRowData(ByVal RowData As Object) As String

'            'objects
'            Dim NewRowData As String = ""

'            Try

'                If TypeOf RowData Is System.DBNull Then

'                    NewRowData = ""

'                Else

'                    NewRowData = RowData

'                End If

'            Catch ex As Exception
'                NewRowData = ""
'            End Try

'            GetRowData = NewRowData

'        End Function
'        Public Function LoadPreDefinedLength(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityType As System.Data.Metadata.Edm.EntityType) As Integer

'            'objects
'            Dim PreDefinedLength As Long = 0
'            Dim Precision As Long = 0
'            Dim Scale As Long = 0
'            Dim DataType As System.Type = Nothing
'            Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing

'            If PropertyDescriptor IsNot Nothing Then

'                If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

'                    DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

'                Else

'                    DataType = PropertyDescriptor.PropertyType

'                End If

'                If DataType Is GetType(String) Then

'                    If EntityType IsNot Nothing Then

'                        PreDefinedLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))

'                    Else

'                        MaxLengthAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).SingleOrDefault

'                        If MaxLengthAttribute IsNot Nothing Then

'                            PreDefinedLength = MaxLengthAttribute.MaximumLength

'                        End If

'                    End If

'                ElseIf DataType Is GetType(Decimal) Then

'                    If EntityType IsNot Nothing Then

'                        Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))
'                        Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(AdvantageFramework.BaseClasses.Entity.LoadProperty(EntityType, PropertyDescriptor.Name))

'                    End If

'                    If Precision <> 0 OrElse Scale <> 0 Then

'                        PreDefinedLength = Precision + Scale + 1

'                    Else

'                        PreDefinedLength = 29

'                    End If

'                ElseIf DataType Is GetType(Double) Then

'                    PreDefinedLength = 16

'                ElseIf DataType Is GetType(Integer) Then

'                    PreDefinedLength = 10

'                ElseIf DataType Is GetType(Short) Then

'                    PreDefinedLength = 5

'                ElseIf DataType Is GetType(Byte) Then

'                    PreDefinedLength = 3

'                ElseIf DataType Is GetType(Long) Then

'                    PreDefinedLength = 20

'                ElseIf DataType Is GetType(Single) Then

'                    PreDefinedLength = 7

'                ElseIf DataType Is GetType(Date) Or DataType Is GetType(DateTime) Then

'                    PreDefinedLength = 20

'                End If

'            End If

'            If PreDefinedLength = 0 Then

'                PreDefinedLength = 100

'            End If

'            LoadPreDefinedLength = PreDefinedLength

'        End Function

'#End Region

'    End Module

'End Namespace
