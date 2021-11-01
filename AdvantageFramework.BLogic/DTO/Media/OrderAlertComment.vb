Namespace DTO.Media

    Public Class OrderAlertComment
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            VendorCode
            CommentID
            VendorName
            Name
            CommentDate
            Comment
            Email
            AlertID
            CommentDateString
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CommentID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="By")>
        Public Property Name As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date/Time", DisplayFormat:="g")>
        Public Property CommentDate As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Email As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date/Time", DisplayFormat:="g")>
        Public Property CommentDateString As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
