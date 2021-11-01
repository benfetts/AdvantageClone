Namespace Exporting.DataClasses

    <Serializable()>
    Public Class GeneralLedgerMappingExport
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TargetAccountCode
            GeneralLedgerAccountCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property TargetAccountCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property GeneralLedgerAccountCode() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
