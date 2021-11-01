Namespace Services.Exports.Classes

    Public Class ExportSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdvantageServiceExportSettingID
            AdvantageServiceExportID
            Enabled
            RunAt
            ExportPath
            JobNumberPrependText
            NonJobCode
            CurrentProcessControl
            CurrentProcessControl2
            ChangeToProcessControl
            ChangeAfter
            NumberOfDaysOldCutoff
            UseSSLForFTP
            FTPAddress
            FTPPort
            FTPFolder
            FTPUserName
            FTPPassword
            SSLModeForFTP
            EmailAddress
            ProcessNowTransactionDate
        End Enum

#End Region

#Region " Variables "

        Private _AdvantageServiceExportSettingID As Integer = Nothing
        Private _AdvantageServiceExportID As Long = Nothing
        Private _ExportTemplateType As Short = Nothing
        Private _Enabled As Boolean = Nothing
        Private _RunAt As System.DateTime? = Nothing
        Private _ExportPath As String = Nothing
        Private _JobNumberPrependText As String = Nothing
        Private _NonJobCode As String = Nothing
        Private _CurrentProcessControl As Short? = Nothing
        Private _CurrentProcessControl2 As Short? = Nothing
        Private _ChangeToProcessControl As Short? = Nothing
        Private _ChangeAfter As Integer? = Nothing
        Private _NumberOfDaysOldCutoff As Integer? = Nothing
        Private _UseSSLForFTP As Boolean = False
        Private _FTPAddress As String = Nothing
        Private _FTPPort As Integer? = Nothing
        Private _FTPFolder As String = Nothing
        Private _FTPUserName As String = Nothing
        Private _FTPPassword As String = Nothing
        Private _SSLModeForFTP As Rebex.Net.SslMode = Rebex.Net.SslMode.None
        Private _EmailAddress As String = Nothing
        Private _ProcessNowTransactionDate As Date = Now

        Private _AdvantageServiceExport As AdvantageFramework.Database.Entities.AdvantageServiceExport = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AdvantageServiceExportSettingID() As Integer
            Get
                AdvantageServiceExportSettingID = _AdvantageServiceExportSettingID
            End Get
        End Property
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
                ExportTemplateType = _ExportTemplateType
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
        Public Property RunAt() As DateTime?
            Get
                RunAt = _RunAt
            End Get
            Set(value As DateTime?)
                _RunAt = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExportPath() As String
            Get
                ExportPath = _ExportPath
            End Get
            Set(value As String)
                _ExportPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumberPrependText() As String
            Get
                JobNumberPrependText = _JobNumberPrependText
            End Get
            Set(value As String)
                _JobNumberPrependText = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NonJobCode() As String
            Get
                NonJobCode = _NonJobCode
            End Get
            Set(value As String)
                _NonJobCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrentProcessControl() As Short?
            Get
                CurrentProcessControl = _CurrentProcessControl
            End Get
            Set(value As Short?)
                _CurrentProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrentProcessControl2() As Short?
            Get
                CurrentProcessControl2 = _CurrentProcessControl2
            End Get
            Set(value As Short?)
                _CurrentProcessControl2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ChangeToProcessControl() As Short?
            Get
                ChangeToProcessControl = _ChangeToProcessControl
            End Get
            Set(value As Short?)
                _ChangeToProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Change After (Days)")>
        Public Property ChangeAfter() As Integer?
            Get
                ChangeAfter = _ChangeAfter
            End Get
            Set(value As Integer?)
                _ChangeAfter = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Cutoff After (Days)", UseMinValue:=True, MinValue:=0)>
        Public Property NumberOfDaysOldCutoff() As Integer?
            Get
                NumberOfDaysOldCutoff = _NumberOfDaysOldCutoff
            End Get
            Set(value As Integer?)
                _NumberOfDaysOldCutoff = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UseSSLForFTP() As Boolean
            Get
                UseSSLForFTP = _UseSSLForFTP
            End Get
            Set(value As Boolean)
                _UseSSLForFTP = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FTPAddress() As String
            Get
                FTPAddress = _FTPAddress
            End Get
            Set(value As String)
                _FTPAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FTPPort() As Integer?
            Get
                FTPPort = _FTPPort
            End Get
            Set(value As Integer?)
                _FTPPort = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FTPFolder() As String
            Get
                FTPFolder = _FTPFolder
            End Get
            Set(value As String)
                _FTPFolder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FTPUserName() As String
            Get
                FTPUserName = _FTPUserName
            End Get
            Set(value As String)
                _FTPUserName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FTPPassword() As String
            Get
                FTPPassword = _FTPPassword
            End Get
            Set(value As String)
                _FTPPassword = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SSLModeForFTP() As Rebex.Net.SslMode
            Get
                SSLModeForFTP = _SSLModeForFTP
            End Get
            Set(value As Rebex.Net.SslMode)
                _SSLModeForFTP = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProcessNowTransactionDate() As Date
            Get
                ProcessNowTransactionDate = _ProcessNowTransactionDate
            End Get
            Set(value As Date)
                _ProcessNowTransactionDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(AdvantageServiceExport As AdvantageFramework.Database.Entities.AdvantageServiceExport, DataContext As AdvantageFramework.Database.DataContext)

            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            _AdvantageServiceExport = AdvantageServiceExport
            _AdvantageServiceExportID = AdvantageServiceExport.ID
            _ExportTemplateType = AdvantageServiceExport.ExportTemplate.Type

            For Each EnumObjectAttribute In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Services.Exports.ExportSettings))

                AdvantageServiceExportSetting = AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.Load(DataContext).Where(Function(E) E.AdvantageServiceExportID = _AdvantageServiceExportID AndAlso
                                                                                                                                                         E.Code = EnumObjectAttribute.Code).FirstOrDefault()

                If AdvantageServiceExportSetting IsNot Nothing Then

                    Select Case EnumObjectAttribute.Code

                        Case AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString

                            _Enabled = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString

                            _ExportPath = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.JobNumberPrependText.ToString

                            _JobNumberPrependText = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.NonJobCode.ToString

                            _NonJobCode = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString

                            _RunAt = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.ChangeAfter.ToString

                            _ChangeAfter = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl.ToString

                            _CurrentProcessControl = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl2.ToString

                            _CurrentProcessControl2 = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.ChangeToProcessControl.ToString

                            _ChangeToProcessControl = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.NumberOfDaysOldCutoff.ToString

                            _NumberOfDaysOldCutoff = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.UseSSLForFTP.ToString

                            _UseSSLForFTP = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.FTPAddress.ToString

                            _FTPAddress = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.FTPPort.ToString

                            _FTPPort = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.FTPFolder.ToString

                            _FTPFolder = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.FTPUserName.ToString

                            _FTPUserName = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.FTPPassword.ToString

                            _FTPPassword = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.SSLModeForFTP.ToString

                            _SSLModeForFTP = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.EmailAddress.ToString

                            _EmailAddress = AdvantageServiceExportSetting.Value

                        Case AdvantageFramework.Services.Exports.ExportSettings.ProcessNowTransactionDate.ToString

                            _ProcessNowTransactionDate = AdvantageServiceExportSetting.Value

                    End Select

                End If

            Next

        End Sub
        Private Sub InsertSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Services.Exports.ExportSettings, ByVal Value As Object)

            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing

            AdvantageServiceExportSetting = New AdvantageFramework.Database.Entities.AdvantageServiceExportSetting
            AdvantageServiceExportSetting.DataContext = DataContext
            AdvantageServiceExportSetting.AdvantageServiceExportID = _AdvantageServiceExportID

            AdvantageServiceExportSetting.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(Setting).Code
            AdvantageServiceExportSetting.Description = AdvantageFramework.EnumUtilities.LoadEnumObject(Setting).Description

            AdvantageServiceExportSetting.Value = Value

            If Setting = ExportSettings.NextRunAt Then

                AdvantageServiceExportSetting.DefaultValue = CDate("01/01/2001 01:00 AM")

            End If

            AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.Insert(DataContext, AdvantageServiceExportSetting)

        End Sub
        Private Sub UpdateOrInsertSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Services.Exports.ExportSettings, ByVal Value As Object)

            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing

            AdvantageServiceExportSetting = AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.LoadByAdvantageServiceExportIDAndCode(DataContext, _AdvantageServiceExportID, Setting.ToString)

            If AdvantageServiceExportSetting IsNot Nothing Then

                AdvantageServiceExportSetting.Value = Value
                AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.Update(DataContext, AdvantageServiceExportSetting)

            Else

                InsertSetting(DataContext, Setting, Value)

            End If

        End Sub
        Private Sub UpdateSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Services.Exports.ExportSettings, ByVal Value As Object)

            Dim NextRunAtObject As Object = Nothing
            Dim NextRunAt As Date = Nothing
            Dim RunAtDate As Date = Nothing

            If IsExportSettingCodeUsed(Setting.ToString) Then

                UpdateOrInsertSetting(DataContext, Setting, Value)

                If Setting = AdvantageFramework.Services.Exports.ExportSettings.RunAt Then

                    If Value IsNot Nothing Then

                        NextRunAtObject = LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt)

                        If NextRunAtObject IsNot Nothing Then

                            DateTime.TryParse(Value, RunAtDate)
                            DateTime.TryParse(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt), NextRunAt)

                            If NextRunAt <> CDate("01/01/2001 01:00 AM") Then 'service has never ran

                                If RunAtDate.TimeOfDay <> NextRunAt.TimeOfDay Then ' service originally set to another time

                                    If RunAtDate.TimeOfDay > NextRunAt.TimeOfDay Then

                                        NextRunAt = RunAtDate

                                    Else

                                        NextRunAt = RunAtDate.AddDays(1)

                                    End If

                                    UpdateOrInsertSetting(DataContext, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt, NextRunAt)

                                End If

                            End If

                        Else

                            NextRunAt = Now.AddDays(1).ToShortDateString & " " & RunAtDate.ToShortTimeString

                            UpdateOrInsertSetting(DataContext, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt, NextRunAt)

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub Save(ByVal DataContext As AdvantageFramework.Database.DataContext)

            UpdateSetting(DataContext, Exports.ExportSettings.Enabled, _Enabled)
            UpdateSetting(DataContext, Exports.ExportSettings.RunAt, _RunAt)
            UpdateSetting(DataContext, Exports.ExportSettings.ExportPath, _ExportPath)
            UpdateSetting(DataContext, Exports.ExportSettings.JobNumberPrependText, _JobNumberPrependText)
            UpdateSetting(DataContext, Exports.ExportSettings.NonJobCode, _NonJobCode)
            UpdateSetting(DataContext, Exports.ExportSettings.ChangeAfter, _ChangeAfter)
            UpdateSetting(DataContext, Exports.ExportSettings.CurrentProcessControl, _CurrentProcessControl)
            UpdateSetting(DataContext, Exports.ExportSettings.CurrentProcessControl2, _CurrentProcessControl2)
            UpdateSetting(DataContext, Exports.ExportSettings.ChangeToProcessControl, _ChangeToProcessControl)
            UpdateSetting(DataContext, Exports.ExportSettings.NumberOfDaysOldCutoff, _NumberOfDaysOldCutoff)
            UpdateSetting(DataContext, Exports.ExportSettings.UseSSLForFTP, _UseSSLForFTP)
            UpdateSetting(DataContext, Exports.ExportSettings.FTPAddress, _FTPAddress)
            UpdateSetting(DataContext, Exports.ExportSettings.FTPPort, _FTPPort)
            UpdateSetting(DataContext, Exports.ExportSettings.FTPFolder, _FTPFolder)
            UpdateSetting(DataContext, Exports.ExportSettings.FTPUserName, _FTPUserName)
            UpdateSetting(DataContext, Exports.ExportSettings.FTPPassword, _FTPPassword)
            UpdateSetting(DataContext, Exports.ExportSettings.SSLModeForFTP, _SSLModeForFTP)
            UpdateSetting(DataContext, Exports.ExportSettings.EmailAddress, _EmailAddress)
            UpdateSetting(DataContext, Exports.ExportSettings.ProcessNowTransactionDate, _ProcessNowTransactionDate)

        End Sub
        Public Function IsExportSettingCodeUsed(ByVal ExportSetting As String) As Boolean

            'objects
            Dim UsedSettings As String() = Nothing

            Select Case _ExportTemplateType

                Case AdvantageFramework.Exporting.ExportTypes.ArchivedJobs

                    UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.JobNumberPrependText.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ChangeAfter.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl2.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ChangeToProcessControl.ToString}

                Case AdvantageFramework.Exporting.ExportTypes.Job

                    If _AdvantageServiceExport IsNot Nothing AndAlso _AdvantageServiceExport.ExportTemplate.Type = 4 AndAlso _AdvantageServiceExport.ExportTemplate.IsSystemTemplate AndAlso _AdvantageServiceExport.ExportTemplate.Name.ToUpper = AdvantageFramework.Exporting.JOB_INFO_TO_FTP_1.ToUpper Then

                        UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.UseSSLForFTP.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.FTPAddress.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.FTPPort.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.FTPFolder.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.FTPUserName.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.FTPPassword.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.SSLModeForFTP.ToString}

                    Else

                        UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.JobNumberPrependText.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString,
                                        AdvantageFramework.Services.Exports.ExportSettings.NumberOfDaysOldCutoff.ToString}

                    End If

                Case AdvantageFramework.Exporting.ExportTypes.Time

                    UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.JobNumberPrependText.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.NonJobCode.ToString}

                Case AdvantageFramework.Exporting.ExportTypes.PurchaseOrder

                    UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString}

                Case AdvantageFramework.Exporting.ExportTypes.AccountPayable

                    UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString}

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations,
                     AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions,
                     AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts

                    UsedSettings = {AdvantageFramework.Services.Exports.ExportSettings.Enabled.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.RunAt.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ExportPath.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.UseSSLForFTP.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.FTPAddress.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.FTPPort.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.FTPFolder.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.FTPUserName.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.FTPPassword.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.SSLModeForFTP.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.EmailAddress.ToString,
                                    AdvantageFramework.Services.Exports.ExportSettings.ProcessNowTransactionDate.ToString}

            End Select

            IsExportSettingCodeUsed = UsedSettings.Contains(ExportSetting)

        End Function

#End Region

    End Class

End Namespace

