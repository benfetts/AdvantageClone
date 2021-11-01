Namespace Database.Classes

    <Serializable()>
    Public Class GeneralLedgerOfficeCrossReference
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CrossReferenceExists
            Code
            OfficeCode
            OfficeName
            ModifiedDate
            UserCode
            AddedForChartOfAccountWizard
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
        Private _CrossReferenceExists As Boolean = Nothing
        Private _Code As String = ""
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _UserCode As String = ""
        Private _AddedForChartOfAccountWizard As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property CrossReferenceExists As Boolean
            Get
                CrossReferenceExists = _CrossReferenceExists
            End Get
            Set(ByVal value As Boolean)
                _CrossReferenceExists = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=True, CustomColumnCaption:="GL Office", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property Code As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.OfficeName)>
        Public Property OfficeName As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(ByVal value As String)
                _OfficeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AddedForChartOfAccountWizard() As Boolean
            Get
                AddedForChartOfAccountWizard = _AddedForChartOfAccountWizard
            End Get
            Set(ByVal value As Boolean)
                _AddedForChartOfAccountWizard = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _GeneralLedgerOfficeCrossReference = New AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference

        End Sub
        Public Sub New(ByVal GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference)

            _GeneralLedgerOfficeCrossReference = GeneralLedgerOfficeCrossReference

            _Code = GeneralLedgerOfficeCrossReference.Code
            _OfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode
            _OfficeName = GeneralLedgerOfficeCrossReference.OfficeCode
            _UserCode = GeneralLedgerOfficeCrossReference.UserCode
            _ModifiedDate = GeneralLedgerOfficeCrossReference.ModifiedDate
            _CrossReferenceExists = True

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReferenceCode As String)

            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            _Code = GeneralLedgerOfficeCrossReferenceCode

            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerOfficeCrossReferenceCode)

            If GeneralLedgerOfficeCrossReference IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference.Office IsNot Nothing Then

                _OfficeName = GeneralLedgerOfficeCrossReference.Office.Name

            End If
            
        End Sub
        Public Function LoadEntity() As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference

            Try

                _GeneralLedgerOfficeCrossReference.Code = _Code
                _GeneralLedgerOfficeCrossReference.OfficeCode = _OfficeCode
                _GeneralLedgerOfficeCrossReference.UserCode = _UserCode
                _GeneralLedgerOfficeCrossReference.ModifiedDate = _ModifiedDate

            Catch ex As Exception

            End Try

            LoadEntity = _GeneralLedgerOfficeCrossReference

        End Function

#End Region

    End Class

End Namespace
