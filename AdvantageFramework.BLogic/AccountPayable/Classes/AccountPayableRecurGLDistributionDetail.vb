Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableRecurGLDistributionDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableRecurID
            LineNumber
            GLACode
            GLADescription
            OfficeCode
            Amount
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger = Nothing
        Private _GLADescription As String = Nothing
        Private _IsDeleted As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger
            Get
                AccountPayableRecurGeneralLedger = _AccountPayableRecurGeneralLedger
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableRecurID() As Integer
            Get
                AccountPayableRecurID = _AccountPayableRecurGeneralLedger.AccountPayableRecurID
            End Get
            Set(ByVal value As Integer)
                _AccountPayableRecurGeneralLedger.AccountPayableRecurID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineNumber() As Short
            Get
                LineNumber = _AccountPayableRecurGeneralLedger.LineNumber
            End Get
            Set(ByVal value As Short)
                _AccountPayableRecurGeneralLedger.LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDeleted() As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(ByVal value As Boolean)
                _IsDeleted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableRecurGeneralLedger.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableRecurGeneralLedger.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode As String
            Get
                GLACode = _AccountPayableRecurGeneralLedger.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableRecurGeneralLedger.GLACode = If(value Is Nothing, "", value)
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL Account Description", IsReadOnlyColumn:=True)>
        Public Property GLADescription As String
            Get
                GLADescription = _GLADescription
            End Get
            Set(ByVal value As String)
                _GLADescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Amount() As Decimal
            Get
                Amount = _AccountPayableRecurGeneralLedger.Amount
            End Get
            Set(ByVal value As Decimal)
                _AccountPayableRecurGeneralLedger.Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
            Get
                Comment = _AccountPayableRecurGeneralLedger.Comments
            End Get
            Set(ByVal value As String)
                _AccountPayableRecurGeneralLedger.Comments = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _AccountPayableRecurGeneralLedger = New AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger)

            _AccountPayableRecurGeneralLedger = AccountPayableRecurGeneralLedger
            _GLADescription = AccountPayableRecurGeneralLedger.GeneralLedgerAccount.Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableRecurID

        End Function

#End Region

    End Class

End Namespace


