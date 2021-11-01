Namespace Security

    <Serializable()> _
    Public Class ErrorMessages

#Region " Enums "

        Public Enum MessageType
            ClCode
            DivCode
            PrdCode
            JobNumber
            JobComponentNbr
            OfficeCode
            ResourceIsBooked
        End Enum

        Public Enum SystemMessageType
            DefaultMessage
            NoConnString
            NoUserCode
            NoSecUserId
            NoUserGUID
            SessionIdMismatch
            InvalidUserLicense
            ApplicationNotFound
            AccessDenied
            CannotConnect
            UserDoesNotHaveDataReaderPermissions
            UserDoesNotHaveDataWriterPermissions
            DidNotSignOutProperly
            TimeOut
            NoClientPortalUserId
            InvalidSystemLicense
        End Enum

        Public Enum OutputType
            HTML
            Javascript
            PlainText
        End Enum

#End Region

#Region " Variables "

        Private _OutputType As OutputType
        Private _LineBreak As Object

#End Region

#Region " Methods "

        Public Function Invalid(ByVal InvalidType As MessageType, Optional ByVal CustomMessage As String = "") As String
            Dim Prefix As String = "Invalid "
            Dim Suffix As String = ""
            If CustomMessage.Trim() <> "" Then
                Suffix = Me._LineBreak & CustomMessage
            End If
            Select Case InvalidType
                Case MessageType.ResourceIsBooked
                    Return ResolveMessageTypeText(MessageType.ResourceIsBooked) & Suffix
                Case Else
                    Return Prefix & ResolveMessageTypeText(InvalidType) & Suffix
            End Select
        End Function

        Public Shared Function System(ByVal WhatWentWrong As SystemMessageType) As String
            Select Case WhatWentWrong
                Case SystemMessageType.DefaultMessage
                    Return ""
                Case SystemMessageType.NoConnString
                    Return "Could not get Connection String"
                Case SystemMessageType.NoUserCode
                    Return "Could not get User Code"
                Case SystemMessageType.NoSecUserId
                    Return "Could not get Security User Id"
                Case SystemMessageType.NoUserGUID
                    Return "Could not get Client Portal UserGUID"
                Case SystemMessageType.SessionIdMismatch
                    Return "Your current Session ID does not match the Session ID when you signed in"
                Case SystemMessageType.InvalidUserLicense
                    Return "Invalid license key.  Please contact Advantage Support."
                Case SystemMessageType.InvalidUserLicense
                    Return "Invalid user license"
                Case SystemMessageType.ApplicationNotFound
                    Return "Application not found - Access denied"
                Case SystemMessageType.AccessDenied
                    Return "Access denied"
                Case SystemMessageType.CannotConnect
                    Return "Please verify that you are connecting to the correct server and database and that your login username and password is correct"
                Case SystemMessageType.UserDoesNotHaveDataReaderPermissions
                    Return "User trying to login is not apart of the database role db_datareader"
                Case SystemMessageType.UserDoesNotHaveDataWriterPermissions
                    Return "User trying to login is not apart of the database role db_datawriter"
                Case SystemMessageType.DidNotSignOutProperly
                    Return "You have failed to properly sign out from your last session"
                Case SystemMessageType.TimeOut
                    Return "You have been timed out"
                Case SystemMessageType.NoClientPortalUserId
                    Return "Could not get Client Portal User Id"
                Case Else
                    Return ""
            End Select
        End Function


        Private Function ResolveMessageTypeText(ByVal ErrorMessage As MessageType) As String
            Select Case ErrorMessage
                Case MessageType.ClCode
                    Return "Client"
                Case MessageType.DivCode
                    Return "Division"
                Case MessageType.OfficeCode
                    Return "Office"
                Case MessageType.PrdCode
                    Return "Product"
                Case MessageType.ResourceIsBooked
                    Return "This Resource is booked on another event"
                Case MessageType.JobNumber
                    Return "Job Number"
                Case MessageType.JobComponentNbr
                    Return "Job Component Number"
                Case Else
                    Return ""
            End Select
        End Function

        Public Sub New(ByVal MessageOutputType As OutputType)
            Select Case MessageOutputType
                Case OutputType.PlainText
                    _LineBreak = Environment.NewLine()
                Case OutputType.HTML
                    _LineBreak = CType("<br />", String)
                Case OutputType.Javascript
                    _LineBreak = "\n"
            End Select
        End Sub

#End Region

    End Class

End Namespace
