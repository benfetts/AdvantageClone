Namespace DTO

    Public Class EventLog
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EventDateTime
            EventMessage
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property EventDateTime() As Date

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EventMessage() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(EventLog As Database.Entities.EventLog)

            Me.ID = EventLog.ID
            Me.EventDateTime = EventLog.EventDateTime
            Me.EventMessage = EventLog.EventMessage

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
