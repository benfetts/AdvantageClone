Namespace Database.Entities

    <Table("BOARD_COL")>
    Public Class BoardColumn
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            Name
            Description
            ToolTip
            SequenceNumber
            BoardHeaderID
            ParentColumnID
            IsSystem
            BackgroundColorCode
            HeaderColorCode

        End Enum

#End Region

#Region " Variables "

        Private _Keys As String = String.Empty

#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <MaxLength(50)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name As String

        <Column("DESCRIPTION", TypeName:="varchar(MAX)")>
        Public Property Description As String

        <MaxLength(30)>
        <Column("TOOLTIP", TypeName:="varchar")>
        Public Property ToolTip As String

        <Column("SEQ_NBR")>
        Public Property SequenceNumber As Short?

        <Required>
        <Column("BOARD_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BoardHeaderID As Integer?

        <Column("PARENT_COL_ID")>
        Public Property ParentColumnID As Integer?

        <Column("IS_SYSTEM")>
        Public Property IsSystem As Boolean?

        <MaxLength(25)>
        <Column("COLOR_CODE", TypeName:="varchar")>
        Public Property BackgroundColorCode As String

        <MaxLength(25)>
        <Column("COLOR_CODE_HEADER", TypeName:="varchar")>
        Public Property HeaderColorCode As String

        Public ReadOnly Property StateCount As Integer
            Get

                Dim i As Integer = 0

                Try

                    If BoardDetails IsNot Nothing Then

                        i = BoardDetails.Count

                    End If

                Catch ex As Exception
                    i = 0
                End Try

                Return i

            End Get
        End Property

        <NotMapped>
        Public Property Keys As String
            Get
                Return _Keys
            End Get
            Set(value As String)
                _Keys = value
            End Set
        End Property

        Public Overridable Property BoardDetails As ICollection(Of Database.Entities.BoardDetail)

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
