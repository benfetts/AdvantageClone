Namespace Database.Core

    <Serializable()>
    Public Class GeneralLedgerAccount
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Type
            Active
            DepartmentCode
            GeneralLedgerOfficeCrossReferenceCode
            BaseCode
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Description As String = Nothing
        Private _Type As String = Nothing
        Private _Active As String = Nothing
        Private _DepartmentCode As String = Nothing
        Private _GeneralLedgerOfficeCrossReferenceCode As String = Nothing
        Private _BaseCode As String = Nothing

#End Region

#Region " Properties "

        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        Public Property Active() As String
            Get
                Active = _Active
            End Get
            Set(ByVal value As String)
                _Active = value
            End Set
        End Property
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(ByVal value As String)
                _DepartmentCode = value
            End Set
        End Property
        Public Property GeneralLedgerOfficeCrossReferenceCode() As String
            Get
                GeneralLedgerOfficeCrossReferenceCode = _GeneralLedgerOfficeCrossReferenceCode
            End Get
            Set(ByVal value As String)
                _GeneralLedgerOfficeCrossReferenceCode = value
            End Set
        End Property
        Public Property BaseCode() As String
            Get
                BaseCode = _BaseCode
            End Get
            Set(ByVal value As String)
                _BaseCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal GeneralLedgerAccount As Object)

            MyBase.SetValues(GeneralLedgerAccount)

        End Sub

#End Region

    End Class

End Namespace