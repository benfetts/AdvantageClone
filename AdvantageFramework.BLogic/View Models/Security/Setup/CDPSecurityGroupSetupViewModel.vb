Namespace ViewModels.Security.Setup

    Public Class CDPSecurityGroupSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property RefreshEnabled As Boolean

        Public Property CDPSecurityGroups As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup)
        Public Property SelectedCDPSecurityGroup As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup

        Public ReadOnly Property HasASelectedCDPSecurityGroup As Boolean
            Get
                HasASelectedCDPSecurityGroup = (Me.SelectedCDPSecurityGroup IsNot Nothing)
            End Get
        End Property

        Public Property SelectedCDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

        Public Property CDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.CancelEnabled = False
            Me.DeleteEnabled = False
            Me.RefreshEnabled = True

            Me.CDPSecurityGroups = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup)
            Me.SelectedCDPSecurityGroup = Nothing

            Me.SelectedCDPSecurityGroupViewModel = Nothing

            Me.CDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

        End Sub

#End Region

    End Class

End Namespace
