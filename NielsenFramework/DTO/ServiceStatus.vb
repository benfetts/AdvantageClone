Namespace DTO

    Public Class ServiceStatus
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            LastRan
            IsRunning
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastRan() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsRunning() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ServiceStatus As NielsenFramework.Database.Entities.ServiceStatus)

            Me.ID = ServiceStatus.ID
            Me.LastRan = ServiceStatus.LastRan
            Me.IsRunning = ServiceStatus.IsRunning

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
