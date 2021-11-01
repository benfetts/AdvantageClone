Module Documentation

#Region " Enum "

    Private Enum DocumentTypes
        AdvantageAPI
        AdvantageAPIRestCalls
        AdvantageAPIforMedia
		AdvantageAPIforMediaNoBank
        AdvantageAPIforJobAndEstimate
        AdvantageAPIforJobCopy
        AdvantageAPIforMediaVendors
    End Enum

#End Region

#Region " Variables "

    Private _OutputDirectory As String = My.Application.Info.DirectoryPath & "\Documents\"

#End Region

#Region " Methods "

    Sub Main()

        If System.IO.Directory.Exists(_OutputDirectory) = False Then

            System.IO.Directory.CreateDirectory(_OutputDirectory)

        End If

        GenerateDocument(DocumentTypes.AdvantageAPI)
        GenerateDocument(DocumentTypes.AdvantageAPIRestCalls)
        GenerateDocument(DocumentTypes.AdvantageAPIforMedia)
		GenerateDocument(DocumentTypes.AdvantageAPIforMediaNoBank)
        GenerateDocument(DocumentTypes.AdvantageAPIforJobAndEstimate)
        GenerateDocument(DocumentTypes.AdvantageAPIforJobCopy)
        GenerateDocument(DocumentTypes.AdvantageAPIforMediaVendors)

    End Sub
    Private Sub GenerateDocument(ByVal DocumentType As DocumentTypes)

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim FileName As String = ""
        Dim FullFileName As String = ""

        Select Case DocumentType

            Case DocumentTypes.AdvantageAPI

                XtraReport = New Templates.AdvantageAPI
                FileName = DocumentType.ToString

            Case DocumentTypes.AdvantageAPIRestCalls

                XtraReport = New Templates.AdvantageAPIRestCalls
                FileName = DocumentType.ToString

            Case DocumentTypes.AdvantageAPIforMedia

                XtraReport = New Templates.AdvantageAPIforMedia
                FileName = DocumentType.ToString

            Case DocumentTypes.AdvantageAPIforMediaNoBank

                XtraReport = New Templates.AdvantageAPIforMedia With {.NoBank = True}
                FileName = DocumentType.ToString

			Case DocumentTypes.AdvantageAPIforJobAndEstimate

				XtraReport = New Templates.AdvantageAPIforJobAndEstimate
                FileName = DocumentType.ToString

            Case DocumentTypes.AdvantageAPIforJobCopy

                XtraReport = New Templates.AdvantageAPIforJobCopy
                FileName = DocumentType.ToString

            Case DocumentTypes.AdvantageAPIforMediaVendors

                XtraReport = New Templates.AdvantageAPIforMediaVendors
                FileName = DocumentType.ToString

        End Select

        FullFileName = _OutputDirectory & FileName & ".pdf"

        If System.IO.File.Exists(FullFileName) = True Then

            System.IO.File.Delete(FullFileName)

        End If

        If XtraReport IsNot Nothing Then

            XtraReport.ExportToPdf(FullFileName)

        End If

    End Sub

#End Region

End Module
