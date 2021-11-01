Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class CommentView
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Enum "

        Public Enum Properties
            CommentDate
            CommentHours
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _CommentDate As Date = Nothing
        Private _CommentHours As Nullable(Of Decimal) = Nothing
        Private _Comment As String = Nothing
        Private _DayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property CommentDate As Date
            Get
                CommentDate = _CommentDate
            End Get
            Set(value As Date)
                _CommentDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2", CustomColumnCaption:="Hours")>
        Public Property CommentHours As Nullable(Of Decimal)
            Get
                CommentHours = _CommentHours
            End Get
            Set(value As Nullable(Of Decimal))
                _CommentHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                DayStatus = _DayStatus
            End Get
            Set(value As AdvantageFramework.EmployeeTimesheet.DayStatus)
                _DayStatus = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
