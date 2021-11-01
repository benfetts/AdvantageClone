Namespace Database.Classes

    <Serializable()>
    Public Class OverheadAccountDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OverheadAccount
            OverheadAccountCode
            FromGLACode
            FromDescription
            ToGLACode
            ToDescription
        End Enum

#End Region

#Region " Variables "

        Private _OverheadAccountCode As String = Nothing
        Private _FromDescription As String = Nothing
        Private _ToDescription As String = Nothing
        Private _OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount
            Get
                OverheadAccount = _OverheadAccount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property OverheadAccountCode As String
            Get
                OverheadAccountCode = _OverheadAccount.Code
            End Get
            Set(ByVal value As String)
                _OverheadAccount.Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Account From")>
        Public Property FromGLACode As String
            Get
                FromGLACode = _OverheadAccount.FromGLACode
            End Get
            Set(ByVal value As String)
                _OverheadAccount.FromGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description", IsReadOnlyColumn:=True)>
        Public Property FromDescription As String
            Get
                FromDescription = _FromDescription
            End Get
            Set(ByVal value As String)
                _FromDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Account To")>
        Public Property ToGLACode As String
            Get
                ToGLACode = _OverheadAccount.ToGLACode
            End Get
            Set(ByVal value As String)
                _OverheadAccount.ToGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description", IsReadOnlyColumn:=True)>
        Public Property ToDescription As String
            Get
                ToDescription = _ToDescription
            End Get
            Set(ByVal value As String)
                _ToDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OverheadAccount = New AdvantageFramework.Database.Entities.OverheadAccount

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount)

            _OverheadAccountCode = OverheadAccount.Code

            Try

                _FromDescription = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, OverheadAccount.FromGLACode).Description

            Catch ex As Exception
                _FromDescription = ""
            End Try

            Try

                _ToDescription = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, OverheadAccount.ToGLACode).Description

            Catch ex As Exception
                _ToDescription = ""
            End Try

            _OverheadAccount = OverheadAccount

        End Sub

#End Region

    End Class

End Namespace
