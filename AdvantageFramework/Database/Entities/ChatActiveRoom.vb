Namespace Database.Entities

    Public Class ChatActiveRoom
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            RoomID
            Name
            Description
            StartedByUserCode
            CreateDate
            IsPrivate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        Public Property RoomID As String = Nothing
        Public Property Name As String = Nothing
        Public Property Description As String = Nothing
        Public Property StartedByUserCode As String = Nothing
        Public Property CreateDate As DateTime
        Public Property IsPrivate As Boolean = False

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
