Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableMediaApprovalDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableMediaApproval
            ApplicationSource
            ApprovalStatus
            Status
            RevisionDate
            UserCode
            Comments
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
        Private _ApprovalStatus As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval
            Get
                AccountPayableMediaApproval = _AccountPayableMediaApproval
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Source")>
        Public Property ApplicationSource() As String
            Get
                ApplicationSource = _AccountPayableMediaApproval.ApplicationSource
            End Get
            Set(ByVal value As String)
                _AccountPayableMediaApproval.ApplicationSource = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalStatus() As String
            Get
                ApprovalStatus = _ApprovalStatus
            End Get
            Set(ByVal value As String)
                _ApprovalStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Status() As Nullable(Of Short)
            Get
                Status = _AccountPayableMediaApproval.Status
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableMediaApproval.Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property RevisionDate() As Nullable(Of Date)
            Get
                RevisionDate = _AccountPayableMediaApproval.RevisionDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _AccountPayableMediaApproval.RevisionDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User")>
        Public Property UserCode() As String
            Get
                UserCode = _AccountPayableMediaApproval.UserCode
            End Get
            Set(ByVal value As String)
                _AccountPayableMediaApproval.UserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
            Get
                Comments = _AccountPayableMediaApproval.Comments
            End Get
            Set(ByVal value As String)
                _AccountPayableMediaApproval.Comments = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval)

            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing

            _AccountPayableMediaApproval = AccountPayableMediaApproval

            If AccountPayableMediaApproval.IsActiveRevision.GetValueOrDefault(0) = 1 Then

                _ApprovalStatus = "*"

            End If

            If AccountPayableMediaApproval.Status Is Nothing Then

                _ApprovalStatus += "None"

            Else

                Try

                    MediaApprovalStatus = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatus))
                                           Where KeyValuePair.Key = AccountPayableMediaApproval.Status
                                           Select KeyValuePair).SingleOrDefault

                    _ApprovalStatus += MediaApprovalStatus.Value

                Catch ex As Exception
                    MediaApprovalStatus = Nothing
                End Try

            End If

        End Sub
        'Public Overrides Function ToString() As String

        '    ToString = Me.AccountPayableRecurID.ToString

        'End Function

#End Region

    End Class

End Namespace