Namespace ViewModels.Security.Setup

    Public Class CDPSecurityGroupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CDPSecurityGroup As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup
        Public Property CDPSecurityGroupEmployees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee)

        Public Property CDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
        Public Property AvailableCDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
        Public Property GroupCDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)

        Public Property SelectedAvailableCDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
        Public Property SelectedGroupCDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)

        Public ReadOnly Property HasASelectedAvailableCDP As Boolean
            Get
                HasASelectedAvailableCDP = (Me.SelectedAvailableCDPs IsNot Nothing AndAlso Me.SelectedAvailableCDPs.Count > 0)
            End Get
        End Property
        Public ReadOnly Property HasASelectedGroupCDP As Boolean
            Get
                HasASelectedGroupCDP = (Me.SelectedGroupCDPs IsNot Nothing AndAlso Me.SelectedGroupCDPs.Count > 0)
            End Get
        End Property
        Public ReadOnly Property CanAddCDPToGroup As Boolean
            Get
                CanAddCDPToGroup = Me.HasASelectedAvailableCDP
            End Get
        End Property
        Public ReadOnly Property CanRemoveCDPFromGroup As Boolean
            Get
                CanRemoveCDPFromGroup = Me.HasASelectedGroupCDP
            End Get
        End Property

        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
        Public Property AvailableEmployees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
        Public Property GroupEmployees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

        Public Property SelectedAvailableEmployees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
        Public Property SelectedGroupEmployees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

        Public ReadOnly Property HasASelectedAvailableEmployee As Boolean
            Get
                HasASelectedAvailableEmployee = (Me.SelectedAvailableEmployees IsNot Nothing AndAlso Me.SelectedAvailableEmployees.Count > 0)
            End Get
        End Property
        Public ReadOnly Property HasASelectedGroupEmployee As Boolean
            Get
                HasASelectedGroupEmployee = (Me.SelectedGroupEmployees IsNot Nothing AndAlso Me.SelectedGroupEmployees.Count > 0)
            End Get
        End Property
        Public ReadOnly Property CanAddEmployeeToGroup As Boolean
            Get
                CanAddEmployeeToGroup = Me.HasASelectedAvailableEmployee
            End Get
        End Property
        Public ReadOnly Property CanRemoveEmployeeFromGroup As Boolean
            Get
                CanRemoveEmployeeFromGroup = Me.HasASelectedGroupEmployee
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.CDPSecurityGroup = Nothing
            Me.CDPSecurityGroupEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee)

            Me.CDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
            Me.AvailableCDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
            Me.GroupCDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)

            Me.SelectedAvailableCDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
            Me.SelectedGroupCDPs = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)

            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
            Me.AvailableEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
            Me.GroupEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

            Me.SelectedAvailableEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
            Me.SelectedGroupEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

        End Sub

#End Region

    End Class

End Namespace
