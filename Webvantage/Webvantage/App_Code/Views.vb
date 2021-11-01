Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Specialized

Public Class vAlertComments
    Inherits _wv_AlertComments

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vAlertAttachmentList
    Inherits _wv_AlertAttachmentList

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vAlertRecipientList
    Inherits _wv_AlertRecipientList

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCPAlertRecipientList
    Inherits _CP_ALERTRECIPIENTLIST

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vAgencySMTPSettings
    Inherits _WV_SMTPSETTINGS

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vMyAlerts
    Inherits _wv_MyAlertsList
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class MyCPAlerts
    Inherits _CP_ALERTLIST
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

End Class
Public Class vMyAlertsJJ
    Inherits _WV_MYALERTSLISTJJ
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class

Public Class vClientDocuments
    Inherits _WV_CLIENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vDivisionDocuments
    Inherits _WV_DIVISION_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vProductDocuments
    Inherits _WV_PRODUCT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCampaignDocuments
    Inherits _WV_CAMPAIGN_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vJobDocuments
    Inherits _WV_JOB_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vJobComponentsDocuments
    Inherits _WV_JOB_COMPONENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vAPDocuments
    Inherits _WV_AP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vAgencyDesktopDocuments
    Inherits _WV_AGENCY_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vExecutiveDesktopDocuments
    Inherits _WV_EXEC_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vDocumentRepositorySettings
    Inherits _WV_DOC_REPOSITORY_SETTINGS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

    Public Function SaveSettings(ByVal uncPath As String, ByVal userDomain As String, ByVal userName As String, ByVal userPassword As String)
        Dim Parms As ListDictionary = New ListDictionary

        Parms.Add("@DOC_PATH", uncPath)
        Parms.Add("@USER_DOMAIN", userDomain)
        Parms.Add("@USER_NAME", userName)
        Parms.Add("@USER_PASSWORD", userPassword)
        
        Me.LoadFromSql("[usp_wv_SaveRepositorySettings]", Parms, CommandType.StoredProcedure)

    End Function
End Class
Public Class vCurrentClientDocuments
    Inherits _WV_CURRENT_CLIENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentDivisionDocuments
    Inherits _WV_CURRENT_DIVISION_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentCampaignDocuments
    Inherits _WV_CURRENT_CAMPAIGN_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentProductDocuments
    Inherits _WV_CURRENT_PRODUCT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentJobDocuments
    Inherits _WV_CURRENT_JOB_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentJobComponentDocuments
    Inherits _WV_CURRENT_JOB_COMPONENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentOfficeDocuments
    Inherits _WV_CURRENT_OFFICE_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentAPDocuments
    Inherits _WV_CURRENT_AP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vOfficeDocuments
    Inherits _WV_OFFICE_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentAgencyDesktopDocuments
    Inherits _WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class
Public Class vCurrentExecutiveDesktopDocuments
    Inherits _WV_CURRENT_EXEC_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
End Class

Public Class vAdvancedDocumentSearch
    Inherits _WV_ADVANCED_DOCUMENT_SEARCH
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

    Public Function Search(ByVal criteria As String, ByVal EmpCode As String, ByVal AccessPrivate As Boolean) As Boolean

        Dim parameters As New System.Collections.Specialized.ListDictionary

        parameters.Add("@SearchCriteria", criteria)
        parameters.Add("@EmpCode", EmpCode)
        parameters.Add("@AccessPrivate", AccessPrivate)

        Me.LoadFromSql("proc_AdvancedDocumentSearch", parameters, CommandType.StoredProcedure)

    End Function
End Class