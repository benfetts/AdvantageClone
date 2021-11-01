Namespace Database.Entities

    <Table("GLACCOUNT_XREF_EXPORT_DETAIL")>
    Public Class GeneralLedgerMappingExportGLAccount
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SourceAccountID
            GeneralLedgerAccountCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("GLACCOUNT_XREF_EXPORT_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("GLACCOUNT_XREF_EXPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property TargetAccountID() As Integer
        <Required>
        <Column("GLACODE", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="General Ledger Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GeneralLedgerAccountCode() As String

        <ForeignKey("TargetAccountID")>
        Public Overridable Property GeneralLedgerMappingExportTargetAccount As Database.Entities.GeneralLedgerMappingExportTargetAccount
        <ForeignKey("GeneralLedgerAccountCode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount.Properties.GeneralLedgerAccountCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerAccounts
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid general ledger code."

                        End If

                        If IsValid Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerMappingExportGLAccounts
                                Where Entity.GeneralLedgerAccountCode.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique general ledger code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
