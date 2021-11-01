Namespace Database.Classes

    <Serializable()>
    Public Class GeneralLedgerDepartmentTeamCrossReference
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CrossReferenceExists
            Code
            DepartmentCode
            DepartmentName
            ModifiedDate
            UserCode
            AddedForChartOfAccountWizard
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing
        Private _CrossReferenceExists As Boolean = Nothing
        Private _Code As String = ""
        Private _DepartmentCode As String = Nothing
        Private _DepartmentName As String = Nothing
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=True, CustomColumnCaption:="GL Department", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property Code As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentCode As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(ByVal value As String)
                _DepartmentCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentName As String
            Get
                DepartmentName = _DepartmentName
            End Get
            Set(ByVal value As String)
                _DepartmentName = value
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

            _GeneralLedgerDepartmentTeamCrossReference = New AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference

        End Sub
        Public Sub New(ByVal GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference)

            _GeneralLedgerDepartmentTeamCrossReference = GeneralLedgerDepartmentTeamCrossReference

            _Code = GeneralLedgerDepartmentTeamCrossReference.Code
            _DepartmentCode = GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode
            _DepartmentName = GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode
            _UserCode = GeneralLedgerDepartmentTeamCrossReference.UserCode
            _ModifiedDate = GeneralLedgerDepartmentTeamCrossReference.ModifiedDate
            _CrossReferenceExists = True

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerDepartmentTeamCrossReferenceCode As String)

            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing

            _Code = GeneralLedgerDepartmentTeamCrossReferenceCode

            GeneralLedgerDepartmentTeamCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.LoadByCode(DbContext, GeneralLedgerDepartmentTeamCrossReferenceCode)

            If GeneralLedgerDepartmentTeamCrossReference IsNot Nothing AndAlso GeneralLedgerDepartmentTeamCrossReference.DepartmentTeam IsNot Nothing Then

                _DepartmentCode = GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode
                _DepartmentName = GeneralLedgerDepartmentTeamCrossReference.DepartmentTeam.Description

            End If

        End Sub
        Public Function LoadEntity() As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference

            Try

                _GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode = _DepartmentCode
                _GeneralLedgerDepartmentTeamCrossReference.Code = _Code
                _GeneralLedgerDepartmentTeamCrossReference.UserCode = _UserCode
                _GeneralLedgerDepartmentTeamCrossReference.ModifiedDate = _ModifiedDate

            Catch ex As Exception

            End Try

            LoadEntity = _GeneralLedgerDepartmentTeamCrossReference

        End Function

#End Region

    End Class

End Namespace
