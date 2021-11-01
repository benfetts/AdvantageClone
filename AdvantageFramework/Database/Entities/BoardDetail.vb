Namespace Database.Entities

    <Table("BOARD_DTL")>
    Public Class BoardDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            BoardHeaderID
            BoardColumnID
            SequenceNumber
            AlertStateID

            AlertState

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

        <Required>
        <Column("BOARD_HDR_ID")>
        Public Property BoardHeaderID As Integer

        <Required>
        <Column("BOARD_COL_ID")>
        Public Property BoardColumnID As Integer

        <Column("SEQ_NBR")>
        Public Property SequenceNumber As Short?

        <Column("ALERT_STATE_ID")>
        Public Property AlertStateID As Integer

        <NotMapped>
        Public Property AlertStateName As String

        Public Overridable Property AlertState As AdvantageFramework.Database.Entities.AlertState

#End Region

#Region " Methods "

        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace

