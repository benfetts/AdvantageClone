@Code
    Layout = Nothing
End Code

<div id="documentList">
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width: auto;background-color: #E5E5E5;padding: 8px 0px 8px 0px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px; overflow:auto;">
        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li style="padding:0">
                <button class="k-button wv-icon-button" onclick="uploadDocument()" title="Upload Document"><span class='glyphicon glyphicon-arrow-up'> </span></button>
            </li>
            <li style="padding:0">
                <button class="k-button wv-icon-button" onclick="downloadDocument()" title="Download Document"><span class='glyphicon glyphicon-arrow-down'> </span></button>
            </li>
            <li style="padding:0">
                <button class="k-button wv-icon-button" onclick="removeDocument()" title="Remove Document"><span class='glyphicon glyphicon-remove'> </span></button>
            </li>
            <li style="padding:0">
                <button class="k-button wv-icon-button wv-neutral" onclick="refreshDocumentList()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
            </li>
        </ul>
    </div>

    <div id="DocumentsGrid"></div>
</div>

<script>
    var datasource = null;
    var _JobNumber = null;
    var _JobComponentNumber = null;
    var _SequenceNumber = null;

    $(() => {
        datasource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: '@Url.Content("~/Utilities/Document/LoadTaskDocuments")',
                    data: function () {
                        var jobNumber = 0,
                            componentNumber = 0,
                            sequenseNumber = 0;

                        if (_JobNumber != null) {
                            jobNumber = _JobNumber;
                        }
                        if (_JobComponentNumber != null) {
                            componentNumber = _JobComponentNumber;
                        }
                        if (_SequenceNumber != null) {
                            sequenseNumber = _SequenceNumber;
                        }

                        return {
                            JobNumber: jobNumber,
                            JobComponentNumber: componentNumber,
                            SequenceNumber: sequenseNumber
                        }
                    }
                }
            },
            schema: {
                model: {
                    id: 'ID',
                    fields: {
                        ID: { type: 'number' },
                        FileName: {type: 'string' },
                        Description: { type: 'string' },
                        DocumentTypeDescription: { type: 'string' },
                        FileSize: { type: 'number' },
                        UserCode: { type: 'string' },
                        UploadedDate: { type: 'date' },
                        IsPrivate: { type: 'number' },
                        MIMEType: { type: 'string' },
                        FileSystemFileName: { type: 'string' }
                    }
                }
            }
        });

        $("#documentList").ejDialog({
            title: "Document List",
            closeOnEscape: true,
            showOnInit: false,
            height: '512',
            width: '1024',
            showFooter: false,
            enableModal: false,
            backgroundScroll: false,
            enableResize: true
        });

        $("#DocumentsGrid").kendoGrid({
            columns: [{
                    field: "ID",
                    title: ""
                },
                {
                    field: "FileName",
                    title: "Filename",
                    template: DocumentTemplate
                },
                {
                    field: "Description",
                    title: "Description"
                },
                {
                    field: "",
                    title: "",
                    template: FileIconTemplate,
                    width: 50
                },
                {
                    field: "FileSize",
                    title: "Sive"
                },
                {
                    field: "UserCode",
                    title: "Uploaded By"
                },
                {
                    field: "UploadedDate",
                    title: "Date/Time"
                },
                {
                    field: "IsPrivate",
                    title: "Pravite"
                }],
            dataSource: datasource
        })
    })

    function DocumentTemplate(dataItem) {
        return '<a target="_self" href="@Url.Content("~/Utilities/Document/DownloadFile")?id='+ dataItem.ID +'" >' + dataItem.FileName + '</a>'
    }

    function taskDocumentsClicked(JobNumber, JobComponentNumber, SequenceNumber) {
        _JobNumber = JobNumber;
        _JobComponentNumber = JobComponentNumber;
        _SequenceNumber = SequenceNumber;

        datasource.read().then(() => {
            $("#documentList").ejDialog("open");
        });
            
    }

    function GetDocumentRepositoryDocument(DocumentId) {
        CallUiAction(11, DocumentId, "");
    };

    function FileIconTemplate(dataItem) {
        var WebDivButtonCssClass, Abbreviation, WebLinkButtonCssClass, Description, AddCommentsButtonVisible;
        var documentPng = "";

        switch (dataItem.MIMEType) {
            case "application/msword":
            case "application/vnd.openxmlformats-officedocument.word":
            case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                documentPng = 'document_word.png';

                WebDivButtonCssClass = "document-ms-word";
                Abbreviation = "W";
                WebLinkButtonCssClass = "icon-text";
                Description = "Microsoft Word";


                AddCommentsButtonVisible = true;
                break;

            case "application/mspowerpoint":
            case "application/vnd.ms-powerpoint":
                documentPng = 'document_powerpoint.png';

                WebDivButtonCssClass = "document-ms-powerpoint";
                Abbreviation = "PP";
                WebLinkButtonCssClass = "icon-text-two";
                Description = "Microsoft Powerpoint";
                break;

            case "application/msproject":
            case "application/vnd.ms-msproject":
                documentPng = 'document_project.png';

                WebDivButtonCssClass = "document-ms-project";
                Abbreviation = "PR";
                WebLinkButtonCssClass = "icon-text-two";
                Description = "Microsoft Project";
                break;

            case "application/pdf":
                documentPng = 'document_pdf.png';

                WebDivButtonCssClass = "document-adobe-pdf";
                Abbreviation = "PDF";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Adobe PDF";

                AddCommentsButtonVisible = true;

            case "application/msexcel":
            case "application/vnd.ms-excel":
            case "application/vnd.openxmlformats-officedocument.spre":
                documentPng = 'document_excel.png';

                WebDivButtonCssClass = "document-ms-excel";
                Abbreviation = "XL";
                WebLinkButtonCssClass = "icon-text-two";
                Description = "Microsoft Excel";

                AddCommentsButtonVisible = true;

            case "image/bmp":
                documentPng = 'document_image.png';

                WebDivButtonCssClass = "document-image";
                Abbreviation = "BMP";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Bitmap Image";

                AddCommentsButtonVisible = true;
                break;

            case "image/gif":
                documentPng = 'document_image.png';

                WebDivButtonCssClass = "document-image";
                Abbreviation = "GIF";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Gif Image";

                AddCommentsButtonVisible = true;
                break;

            case "image/jpeg":
            case "image/pjpeg":
                documentPng = 'document_jpg.png';


                WebDivButtonCssClass = "document-image";
                Abbreviation = "JPG";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Jpeg Image";

                AddCommentsButtonVisible = true;
                break;

            case "image/x-png", "image/png":
                documentPng = 'document_png.png';

                WebDivButtonCssClass = "document-image";
                Abbreviation = "PNG";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Png Image";

                AddCommentsButtonVisible = true;
                break;

            case "image/tiff":
                documentPng = 'document_tiff.png';

                WebDivButtonCssClass = "document-image";
                Abbreviation = "TIF";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Tiff Image";

                AddCommentsButtonVisible = true;
                break;

            case "text/plain":
                documentPng = 'document_text.png';

                WebDivButtonCssClass = "document-text";
                Abbreviation = "TXT";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Text file";
                break;

            case "image/x-photoshop":
                documentPng = 'document_photoshop.png';

                WebDivButtonCssClass = "document-adobe-photoshop";
                Abbreviation = "PSD";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Adobe Photoshop";

            case "application/illustrator":
                documentPng = 'document_illustrator.png';

                WebDivButtonCssClass = "document-adobe-illustrator";
                Abbreviation = "AI";
                WebLinkButtonCssClass = "icon-text-two";
                Description = "Adobe Illustrator";
                break;

            case "url":
                documentPng = 'document_url.png';

                WebDivButtonCssClass = "document-url";
                Abbreviation = "URL";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "URL hyperlink";
                break;

            case "application/x-zip-compressed":
            case "application/zip":
                documentPng = 'document_zip.png';

                WebDivButtonCssClass = "document-zip";
                Abbreviation = "ZIP";
                WebLinkButtonCssClass = "icon-text-three";
                Description = "Zip file";
                break;

            case "application/vnd.ms-outlook":
                documentPng = 'document_generic.png';

                WebDivButtonCssClass = "document-ms-outlook";
                Abbreviation = "O";
                WebLinkButtonCssClass = "icon-text";
                Description = "Microsoft Outlook";

                AddCommentsButtonVisible = true;
                break;

            default:

                //If String.IsNullOrWhiteSpace(Me._Filename) = False Then

                //If Me._Filename.ToLower.EndsWith("pdf") Then

                //WebDivButtonCssClass = "document-adobe-pdf"
                //Abbreviation = "PDF"
                //WebLinkButtonCssClass = "icon-text-three"
                //Description = "Adobe PDF"

                //AddCommentsButtonVisible = True

                //ElseIf Me._Filename.ToLower.EndsWith("docx") OrElse Me._Filename.ToLower.EndsWith("doc") Then

                //WebDivButtonCssClass = "document-ms-word"
                //Abbreviation = "W"
                //WebLinkButtonCssClass = "icon-text"
                //Description = "Microsoft Word"

                //AddCommentsButtonVisible = True

                //ElseIf Me._Filename.ToLower.EndsWith("sql") Then

                //Abbreviation = "SQL"
                //Description = "SQL Script"
                //WebLinkButtonCssClass = "icon-text-three"

                //ElseIf Me._Filename.ToLower.EndsWith("xlsx") OrElse Me._Filename.ToLower.EndsWith("xls") Then

                //WebDivButtonCssClass = "document-ms-excel"
                //Abbreviation = "XL"
                //WebLinkButtonCssClass = "icon-text-two"
                //Description = "Microsoft Excel"

                //AddCommentsButtonVisible = True

                //End If

                //Else

                //Abbreviation = "DOC"
                //Description = "Document"
                //WebLinkButtonCssClass = "icon-text-three"

                //End If

        }

        //https://view.officeapps.live.com/op/embed.aspx?src=http://remote.url.tld/path/to/document.doc
        //<button class="k-button wv-icon-button" onclick="uploadDocument()" title="Upload Document"><span class='glyphicon glyphicon-arrow-up'> </span></button>
        return "<a target='_self' href='@Url.Content("~/Utilities/Document/DownloadFile")?id=" + dataItem.ID + "' ><img src='@Url.Content("~/Images")/" + documentPng + "' alt='" + Description +"' style='height: 24px; width: 24px;' /></a>"
    }

</script>
