Namespace Database.Classes

    <Serializable()>
    Public Class DetailDocument
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DOCUMENT_ID
            FileType
            FILENAME
            DESCRIPTION
            KEYWORDS
            FILE_SIZE
            UPLOADED_DATE
            MIME_TYPE
            USER_CODE
            CMP_CODE
            OFFICE_CODE
            CL_CODE
            DIV_CODE
            PRD_CODE
            JOB_NUMBER
            JOB_COMPONENT_NBR
            LEVEL
            OFFICE_NAME
            CAMPAIGN_NAME
            CLIENT_NAME
            DIVISION_NAME
            PRODUCT_DESCRIPTION
            JOB_DESCRIPTION
            JOB_COMP_DESCRIPTION
            REPOSITORY_FILENAME
            VENDOR_CODE
            AP_INVOICE
            VENDOR_NAME
            AP_INVOICE_DESC
            AP_ID
            AD_NBR
            AD_NBR_DESC
        End Enum

#End Region

#Region " Variables "

        Private _DOCUMENT_ID As Integer = Nothing
        Private _FILENAME As String = Nothing
        Private _DESCRIPTION As String = Nothing
        Private _KEYWORDS As String = Nothing
        Private _FILE_SIZE As Nullable(Of Integer) = Nothing
        Private _UPLOADED_DATE As Date = Nothing
        Private _MIME_TYPE As String = Nothing
        Private _USER_CODE As String = Nothing
        Private _CMP_CODE As String = Nothing
        Private _OFFICE_CODE As String = Nothing
        Private _CL_CODE As String = Nothing
        Private _DIV_CODE As String = Nothing
        Private _PRD_CODE As String = Nothing
        Private _JOB_NUMBER As Nullable(Of Integer) = Nothing
        Private _JOB_COMPONENT_NBR As Nullable(Of Integer) = Nothing
        Private _LEVEL As String = Nothing
        Private _OFFICE_NAME As String = Nothing
        Private _CAMPAIGN_NAME As String = Nothing
        Private _CLIENT_NAME As String = Nothing
        Private _DIVISION_NAME As String = Nothing
        Private _PRODUCT_DESCRIPTION As String = Nothing
        Private _JOB_DESCRIPTION As String = Nothing
        Private _JOB_COMP_DESCRIPTION As String = Nothing
        Private _REPOSITORY_FILENAME As String = Nothing
        Private _VENDOR_CODE As String = Nothing
        Private _AP_INVOICE As String = Nothing
        Private _VENDOR_NAME As String = Nothing
        Private _AP_INVOICE_DESC As String = Nothing
        Private _AP_ID As Nullable(Of Integer) = Nothing
        Private _AD_NBR As String = Nothing
        Private _AD_NBR_DESC As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:=" ")>
        Public ReadOnly Property FileType() As AdvantageFramework.FileSystem.FileTypes
            Get
                FileType = AdvantageFramework.FileSystem.GetFileType(Me.FILENAME, Me.MIME_TYPE)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property DOCUMENT_ID() As Integer
            Get
                DOCUMENT_ID = _DOCUMENT_ID
            End Get
            Set(ByVal value As Integer)
                _DOCUMENT_ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="File Name")>
        Public Property FILENAME() As String
            Get
                FILENAME = _FILENAME
            End Get
            Set(ByVal value As String)
                _FILENAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="File Size")>
        Public Property FILE_SIZE() As Nullable(Of Integer)
            Get
                FILE_SIZE = _FILE_SIZE
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FILE_SIZE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Description")>
        Public Property DESCRIPTION() As String
            Get
                DESCRIPTION = _DESCRIPTION
            End Get
            Set(ByVal value As String)
                _DESCRIPTION = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Keywords")>
        Public Property KEYWORDS() As String
            Get
                KEYWORDS = _KEYWORDS
            End Get
            Set(ByVal value As String)
                _KEYWORDS = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Uploaded By")>
        Public Property USER_CODE() As String
            Get
                USER_CODE = _USER_CODE
            End Get
            Set(ByVal value As String)
                _USER_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Uploaded Date")>
        Public Property UPLOADED_DATE() As Date
            Get
                UPLOADED_DATE = _UPLOADED_DATE
            End Get
            Set(ByVal value As Date)
                _UPLOADED_DATE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Level")>
        Public Property LEVEL() As String
            Get
                LEVEL = _LEVEL
            End Get
            Set(ByVal value As String)
                _LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, CustomColumnCaption:="MIME Type")>
        Public Property MIME_TYPE() As String
            Get
                MIME_TYPE = _MIME_TYPE
            End Get
            Set(ByVal value As String)
                _MIME_TYPE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Office Code")>
        Public Property OFFICE_CODE() As String
            Get
                OFFICE_CODE = _OFFICE_CODE
            End Get
            Set(ByVal value As String)
                _OFFICE_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Office Description")>
        Public Property OFFICE_NAME() As String
            Get
                OFFICE_NAME = _OFFICE_NAME
            End Get
            Set(ByVal value As String)
                _OFFICE_NAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Client Code")>
        Public Property CL_CODE() As String
            Get
                CL_CODE = _CL_CODE
            End Get
            Set(ByVal value As String)
                _CL_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Client Name")>
        Public Property CLIENT_NAME() As String
            Get
                CLIENT_NAME = _CLIENT_NAME
            End Get
            Set(ByVal value As String)
                _CLIENT_NAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Division Code")>
        Public Property DIV_CODE() As String
            Get
                DIV_CODE = _DIV_CODE
            End Get
            Set(ByVal value As String)
                _DIV_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Division Description")>
        Public Property DIVISION_NAME() As String
            Get
                DIVISION_NAME = _DIVISION_NAME
            End Get
            Set(ByVal value As String)
                _DIVISION_NAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Product Code")>
        Public Property PRD_CODE() As String
            Get
                PRD_CODE = _PRD_CODE
            End Get
            Set(ByVal value As String)
                _PRD_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Product Description")>
        Public Property PRODUCT_DESCRIPTION() As String
            Get
                PRODUCT_DESCRIPTION = _PRODUCT_DESCRIPTION
            End Get
            Set(ByVal value As String)
                _PRODUCT_DESCRIPTION = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Campaign Code")>
        Public Property CMP_CODE() As String
            Get
                CMP_CODE = _CMP_CODE
            End Get
            Set(ByVal value As String)
                _CMP_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Campaign Description")>
        Public Property CAMPAIGN_NAME() As String
            Get
                CAMPAIGN_NAME = _CAMPAIGN_NAME
            End Get
            Set(ByVal value As String)
                _CAMPAIGN_NAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Number")>
        Public Property JOB_NUMBER() As Nullable(Of Integer)
            Get
                JOB_NUMBER = _JOB_NUMBER
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JOB_NUMBER = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Description")>
        Public Property JOB_DESCRIPTION() As String
            Get
                JOB_DESCRIPTION = _JOB_DESCRIPTION
            End Get
            Set(ByVal value As String)
                _JOB_DESCRIPTION = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Component Number")>
        Public Property JOB_COMPONENT_NBR() As Nullable(Of Integer)
            Get
                JOB_COMPONENT_NBR = _JOB_COMPONENT_NBR
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JOB_COMPONENT_NBR = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Component Description")>
        Public Property JOB_COMP_DESCRIPTION() As String
            Get
                JOB_COMP_DESCRIPTION = _JOB_COMP_DESCRIPTION
            End Get
            Set(ByVal value As String)
                _JOB_COMP_DESCRIPTION = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property REPOSITORY_FILENAME() As String
            Get
                REPOSITORY_FILENAME = _REPOSITORY_FILENAME
            End Get
            Set(ByVal value As String)
                _REPOSITORY_FILENAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Vendor / Employee Code")>
        Public Property VENDOR_CODE() As String
            Get
                VENDOR_CODE = _VENDOR_CODE
            End Get
            Set(ByVal value As String)
                _VENDOR_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Vendor / Employee Name")>
        Public Property VENDOR_NAME() As String
            Get
                VENDOR_NAME = _VENDOR_NAME
            End Get
            Set(ByVal value As String)
                _VENDOR_NAME = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Invoice Number")>
        Public Property AP_INVOICE() As String
            Get
                AP_INVOICE = _AP_INVOICE
            End Get
            Set(ByVal value As String)
                _AP_INVOICE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Invoice Description")>
        Public Property AP_INVOICE_DESC() As String
            Get
                AP_INVOICE_DESC = _AP_INVOICE_DESC
            End Get
            Set(ByVal value As String)
                _AP_INVOICE_DESC = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, CustomColumnCaption:="AP ID")>
        Public Property AP_ID() As Nullable(Of Integer)
            Get
                AP_ID = _AP_ID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AP_ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Ad Number")>
        Public Property AD_NBR() As String
            Get
                AD_NBR = _AD_NBR
            End Get
            Set(ByVal value As String)
                _AD_NBR = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Ad Number Description")>
        Public Property AD_NBR_DESC() As String
            Get
                AD_NBR_DESC = _AD_NBR_DESC
            End Get
            Set(ByVal value As String)
                _AD_NBR_DESC = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
