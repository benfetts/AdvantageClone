Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertEmail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertID As Integer = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Subject As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCodesToSendEmailTo As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientPortalEmailAddressessToSendTo As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AppName As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SupervisorApprovalComment As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExcludeAttachments As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InsertEmailBodyAsAlertDescription As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsClientPortal As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeOriginator As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ErrorMessage As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MessageExceedsMaximumEmailSize As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SessionID As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Sent As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PhysicalApplicationPath As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _Guid As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _ConnectionString As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _UserCode As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _EmployeeCode As String = ""

#End Region

#Region " Methods "

        Public Sub Send()

            Dim EmailThreadStart As New System.Threading.ParameterizedThreadStart(AddressOf SendEmail)
            Dim EmailThread As New System.Threading.Thread(EmailThreadStart)
            EmailThread.Start()

        End Sub
        Private Sub SendEmail()

            Try

                Using oc As New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                    Dim alrt As New AdvantageFramework.Database.Entities.Alert
                    alrt = Nothing
                    alrt = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(oc, Me.AlertID)

                    If Not alrt Is Nothing Then

                        Me.EmployeeCodesToSendEmailTo = AdvantageFramework.StringUtilities.CleanStringForSplit(Me.EmployeeCodesToSendEmailTo, ",")
                        Me.ClientPortalEmailAddressessToSendTo = AdvantageFramework.StringUtilities.CleanStringForSplit(Me.ClientPortalEmailAddressessToSendTo, ",")

                        Me.Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Me._ConnectionString, Me._UserCode, alrt, Me.Subject, Me.EmployeeCodesToSendEmailTo, Me.ClientPortalEmailAddressessToSendTo,
                                                                                        Me.AppName, Me.SupervisorApprovalComment, Me.ExcludeAttachments, Me.InsertEmailBodyAsAlertDescription, Me.IsClientPortal,
                                                                                        Me.IncludeOriginator,
                                                                                        "", "", Me.ErrorMessage)

                    End If

                End Using

                If Me.Sent = False Then

                    Me.ErrorMessage = Me.ErrorMessage

                Else

                    If Me.ErrorMessage.ToString().Contains("Message exceeds maximum email size") Then

                        Me.Sent = False

                    End If

                End If

            Catch ThreadAbortEx As System.Threading.ThreadAbortException

                Me.Sent = False
                Me.ErrorMessage = ThreadAbortEx.Message.ToString() & Environment.NewLine & ThreadAbortEx.InnerException.Message.ToString()

            Catch ex As Exception

                Me.Sent = False
                Me.ErrorMessage = ex.Message.ToString()

                If ex.InnerException IsNot Nothing Then

                    Me.ErrorMessage &= Environment.NewLine & ex.InnerException.Message.ToString()

                End If

            Finally

                If Me.Sent = True Then

                    Me.ErrorMessage = ""

                Else

                    Me.ErrorMessage = "Error sending email:  " & Me.ErrorMessage
                    AdvantageFramework.Security.AddWebvantageEventLog(Me.ErrorMessage, Diagnostics.EventLogEntryType.Error)

                End If

            End Try

        End Sub
        Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            Me._ConnectionString = ConnectionString
            Me._UserCode = UserCode

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class TreeNode

        Public Property id As String = String.Empty
        Public Property text As String = String.Empty
        Public Property expanded As Boolean = True
        Public Property checked As Boolean = False
        Public Property isClientContact As Boolean = False
        Public Property clientContactId As Integer? = 0

    End Class

    <Serializable()>
    Public Class EmailGroupTreeViewDataSimple

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property id As String = String.Empty
        Public Property text As String = String.Empty
        Public Property expanded As Boolean = True
        Public Property checked As Boolean = False
        Public Property isClientContact As Boolean = False

        Public Property items As Generic.List(Of TreeNode)

#End Region

#Region " Methods "

        Sub New()

            Me.items = New List(Of TreeNode)

        End Sub

#End Region

    End Class
    <Serializable()>
    Public Class EmailGroupTreeViewData

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Group As EmailGroup
        Public Property Members As Generic.List(Of EmailGroup)

#End Region

#Region " Methods "

        Sub New()

            Me.Group = New EmailGroup
            Me.Members = New List(Of EmailGroup)

        End Sub

#End Region

    End Class
    <Serializable()>
    Public Class EmailGroup

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            IsGroup
            EmailGroupCode
            Code
            Description
            IsChecked
            Order
            EmployeeFullName
            IsContacts
            ClientContactID

        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsGroup As Boolean? = False
        Public Property EmailGroupCode As String = String.Empty
        Public Property Code As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property IsChecked As Boolean? = False
        Public Property Order As Integer? = 0
        Public Property EmployeeFullName As String = String.Empty
        Public Property IsContacts As Boolean? = False
        Public Property ClientContactID As Integer? = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
