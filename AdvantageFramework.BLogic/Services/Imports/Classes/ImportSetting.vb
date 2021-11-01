Namespace Services.Imports.Classes

    Public Class ImportSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdvantageServiceImportSettingID
            AdvantageServiceImportID
            Enabled
            AutoTrimOverflowData
            FirstLineContainsColumnHeaders
            OverrideDefaultDirectory
            OverridePath
            EmployeeCode
        End Enum

#End Region

#Region " Variables "

        Private _AdvantageServiceImportSettingID As Integer = Nothing
        Private _AdvantageServiceImportID As Long = Nothing
        Private _Enabled As Boolean = Nothing
        Private _AutoTrimOverflowData As Boolean = Nothing
        Private _FirstLineContainsColumnHeaders As Boolean = Nothing
        Private _OverrideDefaultDirectory As Boolean = Nothing
        Private _OverridePath As String = Nothing
        Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AdvantageServiceImportSettingID() As Integer
            Get
                AdvantageServiceImportSettingID = _AdvantageServiceImportSettingID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AdvantageServiceImportID() As Long
            Get
                AdvantageServiceImportID = _AdvantageServiceImportID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Enabled() As Boolean
            Get
                Enabled = _Enabled
            End Get
            Set(value As Boolean)
                _Enabled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AutoTrimOverflowData() As Boolean
            Get
                AutoTrimOverflowData = _AutoTrimOverflowData
            End Get
            Set(value As Boolean)
                _AutoTrimOverflowData = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FirstLineContainsColumnHeaders() As Boolean
            Get
                FirstLineContainsColumnHeaders = _FirstLineContainsColumnHeaders
            End Get
            Set(value As Boolean)
                _FirstLineContainsColumnHeaders = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OverrideDefaultDirectory() As Boolean
            Get
                OverrideDefaultDirectory = _OverrideDefaultDirectory
            End Get
            Set(value As Boolean)
                _OverrideDefaultDirectory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OverridePath() As String
            Get
                OverridePath = _OverridePath
            End Get
            Set(value As String)
                _OverridePath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal AdvantageServiceImportID As Long, ByVal DataContext As AdvantageFramework.Database.DataContext)

            Dim AdvantageServiceImportSetting As AdvantageFramework.Database.Entities.AdvantageServiceImportSetting = Nothing
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            _AdvantageServiceImportID = AdvantageServiceImportID

            For Each EnumObjectAttribute In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Services.Imports.ImportSettings))

                AdvantageServiceImportSetting = AdvantageFramework.Database.Procedures.AdvantageServiceImportSetting.Load(DataContext).Where(Function(E) E.AdvantageServiceImportID = _AdvantageServiceImportID AndAlso _
                                                                                                                                                         E.Code = EnumObjectAttribute.Code).FirstOrDefault()

                If AdvantageServiceImportSetting IsNot Nothing Then

                    Select Case EnumObjectAttribute.Code

                        Case AdvantageFramework.Services.Imports.ImportSettings.Enabled.ToString

                            _Enabled = AdvantageServiceImportSetting.Value

                        Case AdvantageFramework.Services.Imports.ImportSettings.AutoTrimOverflowData.ToString

                            _AutoTrimOverflowData = AdvantageServiceImportSetting.Value

                        Case AdvantageFramework.Services.Imports.ImportSettings.FirstLineContainsColumnHeaders.ToString

                            _FirstLineContainsColumnHeaders = AdvantageServiceImportSetting.Value

                        Case AdvantageFramework.Services.Imports.ImportSettings.OverrideDefaultDirectory.ToString

                            _OverrideDefaultDirectory = AdvantageServiceImportSetting.Value

                        Case AdvantageFramework.Services.Imports.ImportSettings.OverridePath.ToString

                            _OverridePath = AdvantageServiceImportSetting.Value

                        Case AdvantageFramework.Services.Imports.ImportSettings.EmployeeCode.ToString

                            _EmployeeCode = AdvantageServiceImportSetting.Value

                    End Select

                End If

            Next

        End Sub
        Private Sub InsertSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Services.Imports.ImportSettings, ByVal Value As Object)

            Dim AdvantageServiceImportSetting As AdvantageFramework.Database.Entities.AdvantageServiceImportSetting = Nothing

            AdvantageServiceImportSetting = New AdvantageFramework.Database.Entities.AdvantageServiceImportSetting
            AdvantageServiceImportSetting.DataContext = DataContext
            AdvantageServiceImportSetting.AdvantageServiceImportID = _AdvantageServiceImportID

            AdvantageServiceImportSetting.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(Setting).Code
            AdvantageServiceImportSetting.Description = AdvantageFramework.EnumUtilities.LoadEnumObject(Setting).Description

            AdvantageServiceImportSetting.Value = Value

            AdvantageFramework.Database.Procedures.AdvantageServiceImportSetting.Insert(DataContext, AdvantageServiceImportSetting)

        End Sub
        Private Sub UpdateSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Services.Imports.ImportSettings, ByVal Value As Object)

            Dim AdvantageServiceImportSetting As AdvantageFramework.Database.Entities.AdvantageServiceImportSetting = Nothing

            AdvantageServiceImportSetting = AdvantageFramework.Database.Procedures.AdvantageServiceImportSetting.LoadByAdvantageServiceImportIDAndCode(DataContext, _AdvantageServiceImportID, Setting.ToString)

            If AdvantageServiceImportSetting IsNot Nothing Then

                AdvantageServiceImportSetting.Value = Value
                AdvantageFramework.Database.Procedures.AdvantageServiceImportSetting.Update(DataContext, AdvantageServiceImportSetting)

            Else

                InsertSetting(DataContext, Setting, Value)

            End If

        End Sub
        Public Sub Save(ByVal DataContext As AdvantageFramework.Database.DataContext)
            
            UpdateSetting(DataContext, ImportSettings.Enabled, _Enabled)
            UpdateSetting(DataContext, ImportSettings.AutoTrimOverflowData, _AutoTrimOverflowData)
            UpdateSetting(DataContext, ImportSettings.FirstLineContainsColumnHeaders, _FirstLineContainsColumnHeaders)
            UpdateSetting(DataContext, ImportSettings.OverrideDefaultDirectory, _OverrideDefaultDirectory)
            UpdateSetting(DataContext, ImportSettings.OverridePath, _OverridePath)
            UpdateSetting(DataContext, ImportSettings.EmployeeCode, _EmployeeCode)

        End Sub

#End Region

    End Class

End Namespace

