Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class LocationSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            LocationCode
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
        End Enum

#End Region

#Region " Variables "

        Private _LocationCode As String = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String
            Get
                LocationCode = _LocationCode
            End Get
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String
            Get
                PageHeaderLogoPath = _PageHeaderLogoPath
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String
            Get
                PageFooterLogoPath = _PageFooterLogoPath
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String
            Get
                PageFooterLogoPathLandscape = _PageFooterLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageHeaderLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageFooterLogo() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.LocationCode.ToString

        End Function

#End Region

    End Class

End Namespace
