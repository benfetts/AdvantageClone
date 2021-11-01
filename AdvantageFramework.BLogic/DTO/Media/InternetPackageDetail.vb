Namespace DTO.Media

    Public Class InternetPackageDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail = Nothing
        Private _AdServerSizeID As Long? = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail
            Get
                InternetPackageDetail = _InternetPackageDetail
            End Get
        End Property

        Public ReadOnly Property AdServerSizeID As Long?
            Get
                AdServerSizeID = _AdServerSizeID
            End Get
        End Property

        Public Property ClearedPlacementID As Nullable(Of Long)

#End Region

#Region " Methods "

        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail)

            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            _InternetPackageDetail = InternetPackageDetail

            AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, _InternetPackageDetail.AdSizeCode, "I")

            If AdSize IsNot Nothing Then

                _AdServerSizeID = AdSize.AdServerSizeID

            End If

        End Sub

#End Region

    End Class

End Namespace
