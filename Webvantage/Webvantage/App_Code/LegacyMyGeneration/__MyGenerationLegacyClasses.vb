'unaltered MyGeneration classes
Public Class AlertAttachment
    Inherits _ALERT_ATTACHMENT

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class AlertCategory
    Inherits _ALERT_CATEGORY

    Public Sub New(ByVal connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class AlertRecipient
    Inherits _ALERT_RCPT

    Public Sub New(ByVal connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class CPAlertRecipient
    Inherits _CP_ALERT_RCPT

    Public Sub New(ByVal connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class AlertType
    Inherits _ALERT_TYPE

    Public Sub New(ByVal connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class CAMPAIGN
    Inherits _CAMPAIGN

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class CDP_CONTACT_HDR
    Inherits _CDP_CONTACT_HDR

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class CP_DESKTOP_OBJECTS
    Inherits _CP_DESKTOP_OBJECTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class UserTabDesktopObjects
    Inherits _CP_USER_TAB_DESKTOP_OBJECT
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class CLIENT
    Inherits _CLIENT

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class DIVISION
    Inherits _DIVISION

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class JOB_COMPONENT
    Inherits _JOB_COMPONENT

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class JOB_LOG
    Inherits _JOB_LOG

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class JOB_TRAFFIC
    Inherits _JOB_TRAFFIC
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class JOB_TRAFFIC_DET
    Inherits _JOB_TRAFFIC_DET
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class JOB_TRAFFIC_DET_EMPS
    Inherits _JOB_TRAFFIC_DET_EMPS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class JOB_TRAFFIC_DET_PREDS
    Inherits _JOB_TRAFFIC_DET_PREDS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class OFFICE
    Inherits _OFFICE

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class PRODUCT
    Inherits _PRODUCT

    Public Sub New(connectionString As String)

        Me.ConnectionString = connectionString

    End Sub
End Class
Public Class CPDesktopTabs
    Inherits _CP_USER_TABS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class

Public Class UserCPApps
    Inherits _CP_USER_SEC_APP
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class


