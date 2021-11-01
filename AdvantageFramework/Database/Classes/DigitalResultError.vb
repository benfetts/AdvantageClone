Namespace Database.Classes

    <Serializable()>
    Public Class DigitalResultError
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportID
            MediaPlanErrorMessage
            ClientErrorMessage
            DivisionErrorMessage
            ProductErrorMessage
            JobErrorMessage
            JobComponentErrorMessage
            MediaPlanDetailErrorMessage
            SalesClassErrorMessage
            CampaignErrorMessage
            VendorErrorMessage
            MarketErrorMessage
            AdSizeErrorMessage
            AdNumberErrorMessage
            InternetTypeErrorMessage
        End Enum

#End Region

#Region " Variables "

        Private _ImportID as Integer = Nothing
        Private _MediaPlanErrorMessage As String = Nothing
        Private _ClientErrorMessage As String = Nothing
        Private _DivisionErrorMessage As String = Nothing
        Private _ProductErrorMessage As String = Nothing
        Private _JobErrorMessage As String = Nothing
        Private _JobComponentErrorMessage As String = Nothing
        Private _MediaPlanDetailErrorMessage As String = Nothing
        Private _SalesClassErrorMessage As String = Nothing
        Private _CampaignErrorMessage As String = Nothing
        Private _VendorErrorMessage As String = Nothing
        Private _MarketErrorMessage As String = Nothing
        Private _AdSizeErrorMessage As String = Nothing
        Private _AdNumberErrorMessage As String = Nothing
        Private _InternetTypeErrorMessage As String = Nothing

#End Region

#Region " Properties "

        Public Property ImportID As Integer
            Get
                ImportID = _ImportID
            End Get
            Set(ByVal value As Integer)
                _ImportID = value
            End Set
        End Property
        Public Property MediaPlanErrorMessage() As String
            Get
                MediaPlanErrorMessage = _MediaPlanErrorMessage
            End Get
            Set(ByVal value As String)
                _MediaPlanErrorMessage = value
            End Set
        End Property
        Public Property ClientErrorMessage() As String
            Get
                ClientErrorMessage = _ClientErrorMessage
            End Get
            Set(ByVal value As String)
                _ClientErrorMessage = value
            End Set
        End Property
        Public Property DivisionErrorMessage() As String
            Get
                DivisionErrorMessage = _DivisionErrorMessage
            End Get
            Set(ByVal value As String)
                _DivisionErrorMessage = value
            End Set
        End Property
        Public Property ProductErrorMessage() As String
            Get
                ProductErrorMessage = _ProductErrorMessage
            End Get
            Set(ByVal value As String)
                _ProductErrorMessage = value
            End Set
        End Property
        Public Property JobErrorMessage() As String
            Get
                JobErrorMessage = _JobErrorMessage
            End Get
            Set(ByVal value As String)
                _JobErrorMessage = value
            End Set
        End Property
        Public Property JobComponentErrorMessage() As String
            Get
                JobComponentErrorMessage = _JobComponentErrorMessage
            End Get
            Set(ByVal value As String)
                _JobComponentErrorMessage = value
            End Set
        End Property
        Public Property MediaPlanDetailErrorMessage() As String
            Get
                MediaPlanDetailErrorMessage = _MediaPlanDetailErrorMessage
            End Get
            Set(ByVal value As String)
                _MediaPlanDetailErrorMessage = value
            End Set
        End Property
        Public Property SalesClassErrorMessage() As String
            Get
                SalesClassErrorMessage = _SalesClassErrorMessage
            End Get
            Set(ByVal value As String)
                _SalesClassErrorMessage = value
            End Set
        End Property
        Public Property CampaignErrorMessage() As String
            Get
                CampaignErrorMessage = _CampaignErrorMessage
            End Get
            Set(ByVal value As String)
                _CampaignErrorMessage = value
            End Set
        End Property
        Public Property VendorErrorMessage() As String
            Get
                VendorErrorMessage = _VendorErrorMessage
            End Get
            Set(ByVal value As String)
                _VendorErrorMessage = value
            End Set
        End Property
        Public Property MarketErrorMessage() As String
            Get
                MarketErrorMessage = _MarketErrorMessage
            End Get
            Set(ByVal value As String)
                _MarketErrorMessage = value
            End Set
        End Property
        Public Property AdSizeErrorMessage() As String
            Get
                AdSizeErrorMessage = _AdSizeErrorMessage
            End Get
            Set(ByVal value As String)
                _AdSizeErrorMessage = value
            End Set
        End Property
        Public Property AdNumberErrorMessage() As String
            Get
                AdNumberErrorMessage = _AdNumberErrorMessage
            End Get
            Set(ByVal value As String)
                _AdNumberErrorMessage = value
            End Set
        End Property
        Public Property InternetTypeErrorMessage() As String
            Get
                InternetTypeErrorMessage = _InternetTypeErrorMessage
            End Get
            Set(ByVal value As String)
                _InternetTypeErrorMessage = value
            End Set
        End Property
        Public Property DaypartCodeErrorMessage() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
