Namespace ViewModels.MediaManager

    Public Class TrafficInstructionFormViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsValid As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property InDifferentOrderState As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasBeenAccepted As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AcceptedByAt As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property QueryString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ConnectionString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property UserCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AlertID As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property Subject As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        <System.Web.Mvc.AllowHtml>
        Public Property Body As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property DatabaseName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property Email As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaTrafficVendorID As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AgencyName As String

        Public Property DetailDocuments As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.DetailDocument)

        Public ReadOnly Property DataSource As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.DetailDocument)
            Get
                DataSource = (From Entity In (From DD In Me.DetailDocuments
                                              Select DD.ParentID,
                                                     DD.CableNetworkStationCodes,
                                                     DD.DaypartDescription,
                                                     DD.Length,
                                                     DD.StartTime,
                                                     DD.EndTime,
                                                     DD.AdNumber,
                                                     DD.CreativeTitle,
                                                     DD.Location,
                                                     DD.Position,
                                                     DD.Rotation,
                                                     DD.IsBookend,
                                                     DD.BookendName).Distinct.ToList
                              Select New AdvantageFramework.DTO.Media.Traffic.DetailDocument With {
                                                      .ParentID = Entity.ParentID,
                                                      .CableNetworkStationCodes = Entity.CableNetworkStationCodes,
                                                      .DaypartDescription = Entity.DaypartDescription,
                                                      .Length = Entity.Length,
                                                      .StartTime = Entity.StartTime,
                                                      .EndTime = Entity.EndTime,
                                                      .AdNumber = Entity.AdNumber,
                                                      .CreativeTitle = Entity.CreativeTitle,
                                                      .Location = Entity.Location,
                                                      .Position = Entity.Position,
                                                      .Rotation = Entity.Rotation,
                                                      .IsBookend = Entity.IsBookend,
                                                      .BookendName = Entity.BookendName}).Distinct.ToList

                For Each DetailDocument In DataSource
                    DetailDocument.HasDocuments = Me.DetailDocuments.Where(Function(DD) DD.ParentID = DetailDocument.ParentID AndAlso DD.DocumentID.HasValue).Any
                Next

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
