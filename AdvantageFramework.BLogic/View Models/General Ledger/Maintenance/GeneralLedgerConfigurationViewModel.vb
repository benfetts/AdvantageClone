Imports System.ComponentModel

Namespace ViewModels.GeneralLedger.Maintenance

    Public Class GeneralLedgerConfigurationViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsNew As Boolean

        Public Property GeneralLedgerConfiguration As DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration

        Public Property ComboBoxItemMonths As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property EditSegment As Boolean

        Public Property HasGLAccounts As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsNew = False
            Me.GeneralLedgerConfiguration = New DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration
            Me.ComboBoxItemMonths = New List(Of DTO.ComboBoxItem)
            Me.EditSegment = False
            Me.HasGLAccounts = False

        End Sub

#End Region

    End Class

End Namespace

