Imports System.ComponentModel

Namespace ViewModels.GeneralLedger.Maintenance

    Public Class GeneralLedgerMappingExportViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectedGeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount
        Public Property GeneralLedgerMappingExportTargetAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount)
        Public Property GeneralLedgerMappingExportGLAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount)
        Public Property SelectedGeneralLedgerMappingExportGLAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount)
        Public Property RepositoryGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)
        Public Property AllMappedGeneralLedgerAccounts As Generic.List(Of String)
        Public ReadOnly Property AvailableGeneralLedgerAccounts(Optional ByVal IncludeCode As String = "") As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)
            Get
                Return (From Item In Me.RepositoryGeneralLedgerAccounts
                        Group Join AllGlExportGLAccount In AllMappedGeneralLedgerAccounts On Item.Code Equals AllGlExportGLAccount Into Group
                        From AllGlX In Group.DefaultIfEmpty
                        Where AllGlX Is Nothing OrElse
                              Item.Code = IncludeCode
                        Order By Item.Code
                        Select Item).ToList
            End Get
        End Property
		Public Property RecordSources As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property SelectedRecordSource As AdvantageFramework.Database.Entities.RecordSource
        Public Property ExportType As AdvantageFramework.Exporting.ExportTypes
        Public Property ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate
        Public ReadOnly Property HasASelectedSourceAccount As Boolean
            Get
                HasASelectedSourceAccount = (SelectedGeneralLedgerMappingExportTargetAccount IsNot Nothing)
            End Get
        End Property
        Public ReadOnly Property HasASelectedRecordSource As Boolean
            Get
                HasASelectedRecordSource = (SelectedRecordSource IsNot Nothing)
            End Get
        End Property
        Public ReadOnly Property HasASelectedGLAccount As Boolean
            Get
                HasASelectedGLAccount = (SelectedGeneralLedgerMappingExportGLAccounts IsNot Nothing AndAlso SelectedGeneralLedgerMappingExportGLAccounts.Count > 0)
            End Get
        End Property
        Public Property DetailIsNewItemRow As Boolean
        Public Property DetailCancelEnabled As Boolean
        Public Property DetailDeleteEnabled As Boolean
        Public Property IsNewItemRow As Boolean
        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public ReadOnly Property SyncEnabled As Boolean
            Get
                Return Me.HasASelectedRecordSource AndAlso Not Me.IsNewItemRow AndAlso Not Me.DetailIsNewItemRow
            End Get
        End Property
        Public ReadOnly Property ExportEnabled As Boolean
            Get
                Return Me.HasASelectedRecordSource AndAlso Not Me.IsNewItemRow AndAlso Not Me.DetailIsNewItemRow
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace

