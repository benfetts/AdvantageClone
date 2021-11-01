Namespace Database.Entities

    <Table("SPRINT_DTL")>
    Public Class SprintDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            SprintHeaderID
            AlertID
            SequenceNumber
            BacklogBoardID
            CardQueryID

            SprintDetailEmployees

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Column("SPRINT_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SprintHeaderID As Integer

        <Column("ALERT_ID")>
        Public Property AlertID As Integer?

        <Column("SEQ_NBR")>
        Public Property SequenceNumber As Short?

        <Column("BACKLOG_BOARD_ID")>
        Public Property BacklogBoardID As Integer?

        <Column("CARD_QUERY_ID")>
        Public Property CardQueryID As Integer?

        Public Overridable Property SprintDetailEmployees As ICollection(Of Database.Entities.SprintEmployee)

#End Region

#Region " Methods "

        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

        '        Public Class EmployeeImage

        '#Region " Constants "



        '#End Region

        '#Region " Enum "



        '#End Region

        '#Region " Variables "



        '#End Region

        '#Region " Properties "

        '            Public Property FullName As String
        '            Public Property RawPicture As Byte()
        '            Public Property ImageString As String

        '#End Region

        '#Region " Methods "

        '            Sub New()

        '            End Sub

        '#End Region

        '        End Class

    End Class

End Namespace
