Namespace Media

    Public Class MediaATBDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision
            Set(value As AdvantageFramework.Database.Entities.MediaATBRevision)
                _MediaATBRevision = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader.BeforePrint

            If _MediaATBRevision IsNot Nothing Then

                LabelRevisionDetailsHeader_Amount.Text = ""
                LabelRevisionDetailsHeader_MarkupPercent.Text = ""
                LabelRevisionDetailsHeader_MarkupAmount.Text = ""

                Select Case _MediaATBRevision.BuyGrossOrNetFlag.GetValueOrDefault(0)

                    Case 0

                        LabelRevisionDetailsHeader_Amount.Lines = {"Net", "Amount"}
                        LabelRevisionDetailsHeader_MarkupPercent.Lines = {"Markup", "%"}
                        LabelRevisionDetailsHeader_MarkupAmount.Lines = {"Markup", "Amount"}

                    Case 1

                        LabelRevisionDetailsHeader_Amount.Lines = {"Gross", "Amount"}
                        LabelRevisionDetailsHeader_MarkupPercent.Lines = {"Comm", "%"}
                        LabelRevisionDetailsHeader_MarkupAmount.Lines = {"Comm", "Amount"}

                End Select

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
