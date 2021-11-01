Namespace Database.Classes

    <Serializable()>
    Public Class GLAllocation
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAccountCode
            GLAccountDescription
            Status
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _GLAccountCode As String = Nothing
        Private _GLAccountDescription As String = Nothing
        Private _Status As String = Nothing
        Private _Comment As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Code")>
        Public Property GLAccountCode() As String
            Get
                GLAccountCode = _GLAccountCode
            End Get
            Set(value As String)
                _GLAccountCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property GLAccountDescription() As String
            Get
                GLAccountDescription = _GLAccountDescription
            End Get
            Set(value As String)
                _GLAccountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Allocation Description")>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace