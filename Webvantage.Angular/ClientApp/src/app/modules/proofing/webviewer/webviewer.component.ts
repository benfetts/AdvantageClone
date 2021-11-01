
import { Component, ViewChild, OnInit, ElementRef, AfterViewInit, OnDestroy, ChangeDetectorRef, HostListener, Input, Inject } from '@angular/core';
import { SliderToolService } from '../services/slider-tool.service';
import { Observable, Subject } from 'rxjs';
import { map, takeUntil, filter } from 'rxjs/operators';
import { CenterPanelButtonsService } from '../services/center-panel-buttons.service';
import { HttpClient } from '@angular/common/http';
import { AnnotationService } from '../services/annotation.service';
import { IAnnotation, wvAnnotation } from '../shared/Models/Annotation';
import { TOOL_TYPE } from '../constants/types/tool-type-constants';
import { TextSelectService } from '../services/text-select.service';
import { ITextSelect } from '../constants/types/quad-typets';
import { initializeVideoViewer } from '@pdftron/webviewer-video';
import { RightPanelButtonsService } from '../services/right-panel-buttons.service';
import { RIGHT_PANEL_BUTTONS_TYPES } from '../constants/types/right-panel-buttons-types.constants';
import { IToolbarCenterButtons } from '../interfaces/toolbar-center-buttons';
import { WebViewerReadyService } from '../services/web-viewer-ready.service';
import { DocumentVersionService } from '../services/document-version.service';
import { isDevMode } from '@angular/core';
import { ComparisonAnnotationService } from '../services/comparison-annotation.service';
import { IDocument } from '../interfaces/document';
import { ISearchOptions } from '../interfaces/search-options';
import { SearchService } from '../services/search.service';
import { ISearchResults } from '../interfaces/search-results';
import { CENTRAL_BUTTONS_TYPES } from '../constants/types/central-buttons-types.constants';
import { APP_BASE_HREF, PlatformLocation } from '@angular/common';

declare var WebViewer: any;

@Component({
  selector: 'web-viewer',
  templateUrl: './webviewer.component.html',
  styleUrls: ['./webviewer.component.css']
})
export class WebViewerComponent implements OnInit, AfterViewInit, OnDestroy {

  @Input() public mainView: boolean = false;
  @Input() public overlay: boolean = false;

  @ViewChild('viewer', { static: true }) viewer: ElementRef;
  @ViewChild('version', { static: true }) version: ElementRef;

  wvInstance: any;
  public panButton: Observable<any>;
  public calloutButton: Observable<any>;
  public linkButton: Observable<any>;
  public pictureButton: Observable<any>;
  public brushButton: Observable<any>;
  public arrowButton: Observable<any>;
  public shapesButton: Observable<any>;
  public selectionButton: Observable<any>;
  public searchButton: Observable<any>;
  public overlayButton: Observable<any>;
  public pageNavigationButton: Observable<any>;
  public currentColor: Observable<string>;
  private destroy$: Subject<void> = new Subject();
  private dl: string = '';
  private document: IDocument = null;
  private compareDocument: IDocument = null;
  private selectedTextStrng = '';
  private selectedAnnotation: wvAnnotation;
  private useMarkers: boolean = false;
  //private annotations: IAnnotation[] = null;
  public loadVideo: (filename: string) => any;
  public doNotRefireSelect: boolean = false;
  public documentLoaded: boolean = false;

  public centerPanelButtons: Observable<IToolbarCenterButtons>;
  public base_href: string = null;

  baseHref: string = "";
  

  constructor(private sliderToolService: SliderToolService,
    private centralPanelButtonsService: CenterPanelButtonsService,
    private ref: ChangeDetectorRef,
    private http: HttpClient,
    private annotationService: AnnotationService,
    private comparisonAnnotationService: ComparisonAnnotationService,
    private textSelectService: TextSelectService,
    private rightPanelButtonsService: RightPanelButtonsService,
    private webViewerReadyService: WebViewerReadyService,
    private documentVersionService: DocumentVersionService,
    private searchService: SearchService,
    private platformLocation: PlatformLocation,
    @Inject(APP_BASE_HREF) baseHref: string) {

    this.baseHref = baseHref;
  }

  ngOnInit() {
    this.sliderToolService.getSliderValue()
      .pipe(takeUntil(this.destroy$))
      .subscribe(value => {
        this.setZoom(value);
        this.ref.detectChanges();
      });

    this.panButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.handSpread;
      }));

    this.panButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('Pan');
        }
        this.ref.detectChanges();
      });

    this.calloutButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.arrowFrom;
      }));

    this.calloutButton.subscribe(e => {
      if (e.selected === true) {
        this.SetToolMode('AnnotationCreateCallout');
      }
      this.ref.detectChanges();
    });

    this.overlayButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.overlay;
      }));

    this.overlayButton.subscribe(e => {
      this.overlay = e.selected;
      if (!this.mainView && this.document != null) {
        this.loadDocument(this.dl, this.document);
      }

      this.ref.detectChanges();
    });


    this.brushButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.brush;
      }));

    this.brushButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('AnnotationCreateFreeHand');
        }
        this.ref.detectChanges();
      });

    this.arrowButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.arrow;
      }));

    this.arrowButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('AnnotationCreateArrow');
        }
        this.ref.detectChanges();
      });

    this.searchButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.magnifyingGlass;
      }));

    this.searchButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
        }
        this.ref.detectChanges();
      });

    this.pageNavigationButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.pageNavigation;
      }));

    this.pageNavigationButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true && this.wvInstance) {
          this.wvInstance.UI.openElements(['leftPanel','thumbnailsPanel']);
        }
        else if (this.wvInstance) {
          this.wvInstance.UI.closeElements(['leftPanel','thumbnailsPanel']);
        }
        this.ref.detectChanges();
      });


    this.selectionButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.selection;
      }));

    this.selectionButton
      .pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('AnnotationEdit');
        }
        this.ref.detectChanges();
      });

    this.centralPanelButtonsService.getShapeButton()
      .pipe(takeUntil(this.destroy$))
      .subscribe((e) => {
        var el = e.find((o) => {
          return o.selected === true;
        })

        if (el) {
          this.SetToolMode(el.name);
        }
      });

    this.centralPanelButtonsService.getTextButton()
      .pipe(takeUntil(this.destroy$))
      .subscribe((e) => {
        var el = e.find((o) => {
          return o.selected === true;
        })

        if (el) {
          this.SetToolMode(el.name);
        }
      });

    this.sliderToolService.getFitMode().subscribe((e) => {
      this.setFitMode(e);
    });

    this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(filter((buttons) => { return buttons.markerTool.selected != this.useMarkers }))
      .subscribe((buttons) => {
        this.useMarkers = buttons.markerTool.selected;

        if (this.useMarkers) {
          this.hideAnnotations();
        }
        else {
          this.showAnnotations()
        }
      });

    this.linkButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.link;
      }));

    this.linkButton.pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('AnnotationCreateFileAttachment');
        }
        this.ref.detectChanges();
      });

    this.pictureButton = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return buttons.pasteImage;
      }));

    this.pictureButton.pipe(takeUntil(this.destroy$))
      .subscribe(e => {
        if (e.selected === true) {
          this.SetToolMode('AnnotationCreateStamp');
        }
        this.ref.detectChanges();
      });

    this.searchService.getSearchOptions().pipe(takeUntil(this.destroy$), filter(o => o != null)).subscribe((options: ISearchOptions) => {
      this.searchText(options)
    });

    this.searchService.getSelectedResult().pipe(takeUntil(this.destroy$), filter(o => o != null)).subscribe((searchResult: ISearchResults) => {
      if (this.wvInstance) {
        var docViewer = this.wvInstance.docViewer;
        if (searchResult.pageNum != docViewer.getCurrentPage()) {
          //its a pretty good bet this was set progmatically so move to the page
          docViewer.setCurrentPage(searchResult.pageNum);
        }
      }
    });
  }

  @HostListener('window:beforeunload')
  async ngOnDestroy() {
    if (this.mainView) {
      this.webViewerReadyService.setWebViewerReady(false);
    }
    else {
      this.webViewerReadyService.setCompareWebViewerReady(false);
    }

    this.destroy$.next();
    this.destroy$.complete();
  }

  ngAfterViewInit(): void {
    // The following code initiates a new instance of WebViewer.
    WebViewer({
      //licenseKey: 'The Advantage Software Company, LLC(gotoadvantage.com):OEM:Webvantage::B+:AMS(20210707):C0A51FBD04E7860AB360B13AC982737860617F8BAF603A63EB1CFC921A345837128A31F5C7',
      licenseKey: 'The Advantage Software Company, LLC(gotoadvantage.com):OEM:Webvantage::B+:AMS(20220707):B0A55FBD04E7860A7360B13AC982737860617F8BAF603A63EB1CFC921A345837128A31F5C7',
      //initialDoc: 'pdf/The Proofing Tool Final Design.pdf',
      path: isDevMode() ? './wv-resources/lib/' : '../wv-resources/lib/',
      //path: './wv-resources/lib/',
      useDownloader: false,
      fullAPI: true,
      disabledElements: ['header',
        'toolsHeader',
        'notesPanel',
        'contextMenuPopup',
        'annotationPopup',
        'textPopup',
        'richTextPopup',
        'documentControl',
        'pageNavOverlay',
        'leftPanelTabs',
        'searchPanel']
    }, this.viewer.nativeElement).then(async instance => {
      this.wvInstance = instance;

      //'leftPanelTabs',
      //  'thumbnailControl',

      // Extends WebViewer to allow loading HTML5 videos (.mp4, ogg, webm).
      //const {
      //  loadVideo,
      //} = await initializeVideoViewer(
      //  instance,
      //  'The Advantage Software Company, LLC(gotoadvantage.com):OEM:Webvantage::B+:AMS(20220707):B0A55FBD04E7860A7360B13AC982737860617F8BAF603A63EB1CFC921A345837128A31F5C7',
      //);

      var { Core } = instance;

      //this.loadVideo = loadVideo;

      //this.wvInstance.iframeWindow.addEventListener('loaderror', (event) => {
      //  event.preventDefault();
      //});

      Core.PDFNet.initialize('The Advantage Software Company, LLC(gotoadvantage.com):OEM:Webvantage::B+:AMS(20220707):B0A55FBD04E7860A7360B13AC982737860617F8BAF603A63EB1CFC921A345837128A31F5C7');

      this.wvInstance.setAnnotationContentOverlayHandler(annotation => {
        var div = document.createElement('div');
        div.appendChild(document.createTextNode(this.getAnnotationTitleText(annotation)));
        return div;
      });


      this.wvInstance.annotManager.on('annotationChanged', (annotations, action, { imported }) => {
        if (imported) {
          //imported
          annotations.forEach((v) => {
            v.ReadOnly = true;
          });
          return;
        }

        if (action == 'add') {
          //expand the left panel
          if (!this.rightPanelButtonsService.isExpanded()) {
            this.rightPanelButtonsService.setRightPanelButtons(RIGHT_PANEL_BUTTONS_TYPES.EXPANDED);
            this.ref.detectChanges();
          }

          //export the annotation as it is so that we can enable the save
          this.wvInstance.annotManager.exportAnnotations({ annotList: annotations }).then((xfdfString: string) => {
            //create our annotation that we actually track
            var annot = new wvAnnotation(0,
              xfdfString, '', '', 0, this.getToolType(annotations), 0);
            annot.name = annotations[0].Dx;
            annot.draw = annotations[0].draw;

            //set the orginal draw function
            if (!annotations[0]['orginal_draw']) {
              annotations[0]['orginal_draw'] = annotations[0].draw;
            }


            //this annotation was just created put it in draft
            this.annotationService.draftAnnotation(annot);
          });
        }
        else if (action === 'modify') {
          //if we get this the annotation should still be in draft
          this.wvInstance.annotManager.exportAnnotations({ annotList: annotations }).then((xfdfString: string) => {
            if (this.selectedAnnotation != null) {
              if (this.selectedAnnotation.draft) {
                this.annotationService.updateDraftAnnotation(xfdfString);
              }
            }
          });
        }
        else if (action === 'delete') {
          console.log('delete called');
          //  annotations.forEach((v) => {
          //    this.annotationService.deleteAnnotation(this.annotationService.getByAU(v.Qw));
          //  });
        }
        else {
          console.log(action);
        }

        return;
      });

      this.wvInstance.annotManager.on('annotationSelected', (annotations, action) => {
        if (action === 'selected') {
          if (annotations) {
            if (this.useMarkers) {
              //hide everything
              this.hideAnnotations();

              //need to find the annotation and change the draw function
              annotations.forEach(async (v, i, a) => {
                if (a[i]['orginal_draw'])
                  a[i].draw = a[i]['orginal_draw'];

                if (a[i].BlendMode) {
                  a[i].BlendMode = 'multiply';
                }

                await this.wvInstance.annotManager.redrawAnnotation(a[i]);

              });
            }
          }

          if (this.doNotRefireSelect) {
            //short circuit

            //but move to the annotation
            var docViewer = this.wvInstance.docViewer;
            if (annotations.length == 1 && annotations[0].PageNumber != docViewer.getCurrentPage()) {
              //its a pretty good bet this was set progmatically so move to the page
              docViewer.setCurrentPage(annotations[0].PageNumber);
            }

            this.doNotRefireSelect = false;
            return;
          }

          if (annotations) {
            this.annotationService.setToolOpacity(annotations[0].Opacity);
            this.annotationService.setToolSize(annotations[0].StrokeThickness);
            if (annotations[0].Color) {
              this.annotationService.setSelectedColor(annotations[0].Color.toHexString());
            }

            this.annotationService.setSelectedByAU(annotations[0].Dx);

            this.ref.detectChanges();
            var docViewer = this.wvInstance.docViewer;
            if (annotations.length == 1 && annotations[0].PageNumber != docViewer.getCurrentPage()) {
              //its a pretty good bet this was set progmatically so move to the page
              docViewer.setCurrentPage(annotations[0].PageNumber);
            }
          }


        } else if (action === 'deselected') {
          this.annotationService.setSelected(null);
          if (this.useMarkers) {
            this.hideAnnotations();
          }
          return;
        }
      });

      this.wvInstance.docViewer.on('documentLoaded', async () => {
        this.documentLoaded = true;
        this.annotationService.setSelected(null);
        this.setFitMode('actualSize');

        if (this.centralPanelButtonsService.getButtonState(CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION)) {
          this.wvInstance.openElements(['thumbnailsPanel']);
        }


        var docViewer = this.wvInstance.docViewer;

        await docViewer.getDocument().documentCompletePromise();

        if (this.mainView) {
          this.annotationService.loadAnotations(this.dl, this.document?.documentId);
        }
        else {
          this.comparisonAnnotationService.loadAnotations(this.dl, this.document?.documentId);
        }

      });

      if (this.mainView) {
        this.annotationService.getAnnotations().pipe(takeUntil(this.destroy$)).subscribe((annotations) => {
          if (annotations != null && this.documentLoaded == true) {
            annotations.forEach((v, i, a) => {
              instance.annotManager.importAnnotations(v.markupXml).then(annotations => {
                if (annotations[0] != null) {
                  a[i].name = annotations[0].Dx;
                  a[i].draw = annotations[0].draw;
                }
              });
            });

            if (this.centralPanelButtonsService.getButtonState(CENTRAL_BUTTONS_TYPES.MARKER_TOOL)) {
              this.hideAnnotations();
              this.useMarkers = true;
            }
          }
        });
      }
      else {
        this.comparisonAnnotationService.getAnnotations().pipe(takeUntil(this.destroy$)).subscribe((annotations) => {
          var instance = this.wvInstance;
          this.deleteAllAnnotations();

          if (annotations != null && this.documentLoaded == true) {
            annotations.forEach((v, i, a) => {
              instance.annotManager.importAnnotations(v.markupXml).then(annotations => {
                if (annotations[0] != null) {
                  a[i].name = annotations[0].Dx;
                }
              });
            });
          }
        });
      }


      const searchListener = (searchPattern, options, results) => {
        var searchResults: ISearchResults[] = [];
        results.map(result => {
          var searchResult: ISearchResults = {
            ambientStr: result.ambientStr,
            pageNum: result.pageNum,
            resultStr: result.resultStr,
            resultStrEnd: result.resultStrEnd,
            resultStrStart: result.resultStrStart,
            active: false
          };

          searchResults.push(searchResult);
        });

        this.searchService.setSearchResults(searchResults);
      };

      instance.addSearchListener(searchListener);

      this.annotationService.getToolSize()
        .pipe(takeUntil(this.destroy$))
        .subscribe((size: number) => {
          this.setSelectedAnnotationSize(size);
        });

      this.annotationService.getToolOpacity()
        .pipe(takeUntil(this.destroy$))
        .subscribe((opacity: number) => {
          this.setSelectedAnnotationOpacity(opacity);
        });

      this.annotationService.getSelectedColor()
        .pipe(takeUntil(this.destroy$))
        .pipe(filter(color => color != ''))
        .subscribe((color) => {
          this.setSelectedAnnotationColor(color);
        });

      if (this.mainView) {
        this.webViewerReadyService.setWebViewerReady(true);
      }
      else {
        this.webViewerReadyService.setCompareWebViewerReady(true);
      }

      this.annotationService.getDraftAnnotations().pipe(takeUntil(this.destroy$), filter(x => x.length == 0)).subscribe((annotations) => {
        this.deleteAllDraftAnnotations();
      });
    });

    this.annotationService.getSelected()
      .pipe(takeUntil(this.destroy$))
      .pipe(filter(annotation => annotation !== null))
      .subscribe((_annotation) => {
        if (_annotation != null) {
          if (this.selectedAnnotation == null || this.selectedAnnotation.name == null || this.selectedAnnotation.name != _annotation.name) {
            this.selectedAnnotation = _annotation;
            this.selectAllAnotationsTiedToComment(this.selectedAnnotation.commentId);
          }
          else {
            var annotations: Array<any> = this.getAnnotationsList();
            this.selectedAnnotation = _annotation;

            this.selectAllAnotationsTiedToComment(_annotation.commentId);
          }
        }
      });
  }

  SetToolMode(Tool: string): void {
    var docViewer = this.wvInstance.docViewer;
    docViewer.setToolMode(docViewer.getTool(Tool));
    this.ref.detectChanges();
  }

  setZoom(zoom: number): void {
    if (this.wvInstance) {
      var docViewer = this.wvInstance.docViewer;
      docViewer.zoomTo(zoom / 100);
    }
  }

  setFitMode(fitMode: string): void {
    if (this.wvInstance) {
      var instance = this.wvInstance;
      var FitMode = this.wvInstance.FitMode;
      switch (fitMode) {
        case 'fitToWidth':
          instance.setFitMode(FitMode.FitWidth);
          break;
        case 'fitToScreen':
          instance.setFitMode(FitMode.FitPage);
          break;
        case 'actualSize':
          instance.setFitMode(FitMode.Zoom);
          this.setZoom(100);
          break;
      }

      this.sliderToolService.setSliderValue(Math.round(instance.docViewer.getZoom() * 100));
    }
  }

  loadDocument(dl: string, document?: IDocument, compareDocument?: IDocument) {
    var instance = this.wvInstance;
    this.dl = dl;
    this.document = document;
    this.compareDocument = compareDocument;

    this.documentLoaded = false;
    this.annotationService.clearAnnotations();

    //remove any annotations that were in a draft state
    this.annotationService.clearDraftAnnotations();

    if (instance) {
      if (this.overlay == false || this.mainView) {
        if (document?.documentId == null) {
          this.http.get(this.baseHref + 'api/ProofingDocumentName?dl=' + dl, { responseType: 'text' })
            .subscribe((filename: string) => {
              if (filename.endsWith('.mp4')) {
                this.loadVideo(this.baseHref + 'api/ProofingDocument?dl=' + dl);
              } else {
                instance.loadDocument(this.baseHref + 'api/ProofingDocument?dl=' + dl, { filename: filename });
              }
            });
        }
        else {
          this.http.get(this.baseHref + 'api/ProofingDocumentName/' + document?.documentId + '?dl=' + dl, { responseType: 'text' })
            .subscribe((filename: string) => {
              if (filename.endsWith('.mp4')) {
                this.loadVideo(this.baseHref + 'api/ProofingDocument/' + document?.documentId + '?dl=' + dl);
              } else {
                instance.loadDocument(this.baseHref + 'api/ProofingDocument/' + document?.documentId + '?dl=' + dl, { filename: filename });
              }
            });
        }
      }
      else {
        this.http.get(this.baseHref + 'api/ProofingDocumentName/' + document?.documentId + '?dl=' + dl, { responseType: 'text' })
          .subscribe((filename: string) => {
            this.compare(dl, this.compareDocument?.documentId, document?.documentId, filename, document?.mimeType);
          });
      }
    }

    this.documentVersionService.getVersion(document?.documentId).subscribe((version) => {
      this.version.nativeElement.innerHTML = document.filename +  ' Version ' + version;
    })
  }

  compare(dl: string, compareDocumentId: number,documentId: number, filename: string, mimeType: string) {
    if (mimeType.startsWith('image')) {
      this.compareDocumentsPixels(dl, compareDocumentId, documentId, filename);
    }
    else {
      this.compareDocuments(dl,compareDocumentId, documentId, filename);
    }

    this.annotationService.loadComparisonAnotations(dl, documentId);
  }

  async compareDocuments(dl: string, compareDocumentId: number, documentId: number, filename: string) {
    console.log('start compare', documentId, compareDocumentId);
    var url: string = this.baseHref + 'api/ProofingDocument';

    var doc1 = await this.getDocumentPDF(url + '/' + documentId + '/?dl=' + dl, filename);
    var doc2 = await this.getDocumentPDF(url + '/' + compareDocumentId + '/?dl=' + dl, '_' + filename);

    var { Core } = this.wvInstance;

    const newDoc = await Core.PDFNet.PDFDoc.create();
    newDoc.lock();

    //const options = await getDiffOptions();

    const pages = [];
    const itr = await doc1.getPageIterator(1);
    const itr2 = await doc2.getPageIterator(1);

    let i = 0;
    for (itr; await itr.hasNext(); itr.next()) {
      const page = await itr.current();
      pages[i] = [page];
      i++;
    }

    i = 0;
    for (itr2; await itr2.hasNext(); itr2.next()) {
      const page = await itr2.current();
      (pages[i] || (pages[i] = [null])).push(page);
      i++;
    }

    console.log(pages);

    pages.forEach(async ([p1, p2]) => {
      if (!p1) {
        p1 = new Core.PDFNet.Page();
      }
      if (!p2) {
        p2 = new Core.PDFNet.Page();
      }

      await newDoc.appendVisualDiff(p1, p2, null);
    });

    await newDoc.unlock();
    this.wvInstance.UI.loadDocument(newDoc);


  //  var doc1 = await this.getDocumentPDF(url + '/' + documentId + '/?dl=' + dl, filename);
  //  var doc1Pages = await this.getPageArray(doc1);

  //  var doc2 = await this.getDocumentPDF(url + '/' + compareDocumentId + '/?dl=' + dl, filename);
  //  var doc2Pages = await this.getPageArray(doc2);

  //  var { Core } = this.wvInstance;
  //  const newDoc = await Core.PDFNet.PDFDoc.create();
  //  newDoc.lock();

  //  const biggestLength = Math.max(doc1Pages.length, doc2Pages.length)
  //  const chain = Promise.resolve();

  //  for (let i = 0; i < biggestLength; i++) {
  //    chain.then(async () => {
  //      var page1 = doc1Pages[i];
  //      var page2 = doc2Pages[i];

  //      if (!page1) {
  //        page1 = new Core.PDFNet.Page(); // create a blank page
  //      }
  //      if (!page2) {
  //        page2 = new Core.PDFNet.Page(); // create a blank page
  //      }

  //      return newDoc.appendVisualDiff(page1, page2, null);
  //    })
  //  }

  //  await chain;
  //  newDoc.unlock();

  //  this.wvInstance.loadDocument(newDoc);
  }

  async compareDocumentsPixels(dl: string, compareDocumentId : number, documentId: number, filename: string) {
    var url: string = this.baseHref + 'api/ProofingDocument';

    var doc1 = await this.getDocument(url + '/' + compareDocumentId + '/?dl=' + dl, filename);
    await doc1.documentCompletePromise();
    var doc2 = await this.getDocument(url + '/' + documentId + '/?dl=' + dl, filename);
    await doc2.documentCompletePromise();

    var PageCount: number = Math.min(doc1.getPageCount(), doc2.getPageCount())

    for (var i = 1; i <= PageCount; i++) {
      var imageData1 = await this.getImageData(doc1, i);
      var imageData2 = await this.getImageData(doc2, i);

      const pixelData1 = (<ImageData>imageData1).data;
      const pixelData2 = (<ImageData>imageData2).data;

      var newImageData = new Uint8ClampedArray((<ImageData>imageData1).width * (<ImageData>imageData1).height * 4);

      for (let i = 0; i < (<ImageData>imageData1).width * (<ImageData>imageData1).height * 4; i += 4) {
        const r1 = pixelData1[i];
        const g1 = pixelData1[i + 1];
        const b1 = pixelData1[i + 2];

        const r2 = pixelData2[i];
        const g2 = pixelData2[i + 1];
        const b2 = pixelData2[i + 2];
        const a2 = pixelData2[i + 3];

        if (Math.abs(r1 - r2) > 5 || Math.abs(g1 - g2) > 5 || Math.abs(b1 - b2) > 5) {
          newImageData[i] = 255;
          newImageData[i + 1] = 0;
          newImageData[i + 2] = 0;
          newImageData[i + 3] = a2;
        }
        else {
          var gray = (r1 + g1 + b1) / 3;
          newImageData[i] = gray;
          newImageData[i + 1] = gray;
          newImageData[i + 2] = gray;
          newImageData[i + 3] = a2;
        }
      }

      const canvas = document.createElement('canvas');
      canvas.width = (<ImageData>imageData1).width;
      canvas.height = (<ImageData>imageData1).height;
      canvas.getContext('2d').putImageData(new ImageData(newImageData, (<ImageData>imageData1).width, (<ImageData>imageData1).height), 0, 0);


      canvas.toBlob(this.blobCallbac(i));
    }
  }

  blobCallbac(pageNumber: number) {
    return async (blob) => {
      if (pageNumber == 1) {
        this.wvInstance.loadDocument(blob, { filename: 'image.png' });
      }
      else {
        var docViewer = this.wvInstance.docViewer;
        var newDoc = await Core.createDocument(blob, { filename: 'image.png' });

        var doc = docViewer.getDocument();
        doc.insertPages(newDoc,1, pageNumber);
      }
    }
  }

  async getDocument(url: string, filename: string) {
    var { Core } = this.wvInstance;
    const newDoc = await Core.createDocument(url, {
      filename: filename
    });
    return newDoc;
  };

  async getDocumentPDF(url: string, filename: string) {
    var { Core } = this.wvInstance;
    const newDoc = await Core.createDocument(url, { filename: filename, loadAsPDF: true });
    await newDoc.documentCompletePromise();
    return await newDoc.getPDFDoc();
  };

  async getPageArray(doc: Core.PDFNet.PDFDoc) {
    const arr = [];
    const itr = await doc.getPageIterator(1);

    for (itr; await itr.hasNext(); itr.next()) {
      const page = await itr.current();
      arr.push(page);
    }
    return arr;
  }

  getImageData(doc, pageIndex = 1) {
    return new Promise(resolve => {
      doc.loadCanvasAsync({
        pageNumber: pageIndex,
        drawComplete: (pageCanvas) => {
          const ctx = pageCanvas.getContext('2d');
          const imageData: ImageData = ctx.getImageData(0, 0, pageCanvas.width, pageCanvas.height);
          resolve(imageData);
        }
      })
    })
  }

  getPageCount(doc): number {
    return doc.getPageCount();
  }

  searchText(options: ISearchOptions): void {
    var instance = this.wvInstance;
    instance.searchTextFull(options.searchPhrase, options);
  }

  getToolType(annotations): TOOL_TYPE {
    var toolType: TOOL_TYPE;

    switch (annotations[0].ToolName) {
      case 'AnnotationCreateFreeHand': {
        toolType = TOOL_TYPE.BRUSH;
        break;
      }

      case 'AnnotationCreateArrow': {
        toolType = TOOL_TYPE.ARROW;
        break;
      }

      case 'AnnotationCreateRectangle': {
        toolType = TOOL_TYPE.RECTANGLE;
        break;
      }

      case 'AnnotationCreateEllipse': {
        toolType = TOOL_TYPE.ELLIPSE;
        break;
      }

      case 'AnnotationCreatePolygon': {
        toolType = TOOL_TYPE.POLYGON;
        break;
      }

      case 'AnnotationCreatePolygonCloud': {
        toolType = TOOL_TYPE.CLOUD;
        break;
      }

      case 'AnnotationCreateFileAttachment': {
        toolType = TOOL_TYPE.LINK;
        break;
      }

      case 'AnnotationCreateStamp': {
        toolType = TOOL_TYPE.STAMP;
        break;
      }

      default: {
        toolType = TOOL_TYPE.BRUSH;
      }
    }

    return toolType;
  }

  setSelectedAnnotationColor(color: string) {
    var annotManager = this.wvInstance.annotManager;
    var docViewer = this.wvInstance.docViewer;
    var selected = annotManager.getSelectedAnnotations();

    selected.forEach((v, i, a) => {
      a[i].Color = this.createColor(color);

      annotManager.updateAnnotation(a[i]);

      if (typeof docViewer.getTool(v.ToolName)['setStyles'] == 'function') {
        docViewer.getTool(v.ToolName).setStyles({
          StrokeColor: this.createColor(color)
        });
      }
    });

    annotManager.trigger('annotationChanged', [selected, 'modify', {}]);
  }

  setSelectedAnnotationSize(size: number): void {
    var annotManager = this.wvInstance.annotManager;
    var docViewer = this.wvInstance.docViewer;
    var selected = annotManager.getSelectedAnnotations();

    selected.forEach((v, i, a) => {
      a[i].StrokeThickness = size;
      annotManager.updateAnnotation(a[i]);

      if (typeof docViewer.getTool(v.ToolName)['setStyles'] == 'function') {
        docViewer.getTool(v.ToolName).setStyles({
          StrokeThickness: size
        });
      }
    });

    if (selected.length > 0) {
      annotManager.trigger('annotationChanged', [selected, 'modify', {}]);
    }
  }

  setSelectedAnnotationOpacity(Opacity: number): void {
    var annotManager = this.wvInstance.annotManager;
    var docViewer = this.wvInstance.docViewer;
    var selected = annotManager.getSelectedAnnotations();

    selected.forEach((v, i, a) => {
      a[i].Opacity = Opacity;

      annotManager.updateAnnotation(a[i]);

      if (typeof docViewer.getTool(v.ToolName)['setStyles'] == 'function') {
        docViewer.getTool(v.ToolName).setStyles({
          Opacity: Opacity
        });
      }
    });

    if (selected.length > 0) {
      annotManager.trigger('annotationChanged', [selected, 'modify', {}]);
    }
  }

  createColor(color: string): Core.Annotations.Color {
    const { Annotations } = this.wvInstance;
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(color);

    return new Annotations.Color(parseInt(result[1], 16), parseInt(result[2], 16), parseInt(result[3], 16));
  }

  getAnnotationsList(): Array<Core.Annotations.Annotation> {
    if (this.wvInstance) {
      return this.wvInstance.annotManager.getAnnotationsList();
    } else {
      return null;
    }
  }

  selectAnnotation(annotation: Core.Annotations.Annotation): void {
    if (this.wvInstance) {
      this.wvInstance.annotManager.selectAnnotation(annotation);
    }
  }

  selectAnnotations(annotations: Core.Annotations.Annotation[]): void {
    if (this.wvInstance) {
      this.wvInstance.annotManager.selectAnnotations(annotations);
    }
  }

  updateAnnotation(annotation: Core.Annotations.Annotation): void {
    if (this.wvInstance) {
      this.wvInstance.annotManager.updateAnnotation(annotation);
    }
  }

  deselectAllAnnotations(): void {
    if (this.wvInstance) {
      this.wvInstance.annotManager.deselectAllAnnotations();
    }
  }

  deleteAllDraftAnnotations(): void {
    var PDFTronannotations: Array<Core.Annotations.Annotation> = this.getAnnotationsList();
    var toDelete: Array<Core.Annotations.Annotation> = [];

    PDFTronannotations.forEach((v, i, a) => {
      if (!v.ReadOnly) {
        //if it is not read only then it is a drafat annotation
        toDelete.push(v);
      }
    });

    this.wvInstance.annotManager.deleteAnnotations(toDelete);

  }

  deleteAllAnnotations(): void {
    var PDFTronannotations: Array<Core.Annotations.Annotation> = this.getAnnotationsList();

    this.wvInstance.annotManager.deleteAnnotations(PDFTronannotations);
  }

  selectAllAnotationsTiedToComment(commentID: number): void {
    var annotations = this.annotationService.getAllWithCommentId(commentID);

    var PDFTronannotations: Array<any> = this.getAnnotationsList();
    var selectedAnnotations: Core.Annotations.Annotation[] = [];


    if (PDFTronannotations) {
      annotations.forEach((av, ai, aa) => {
        PDFTronannotations.forEach((v, i, a) => {
          if (aa[ai].name == v.Dx) {
            a[i].ReadOnly = !av.draft;
            this.updateAnnotation(a[i]);
            selectedAnnotations.push(a[i]);
          }
        });
      });

      if (selectedAnnotations.length == 0) {
        var selected = this.annotationService.getSelectedValue();
        PDFTronannotations.forEach((v, i, a) => {
          if (selected.name == v.Dx) {
            selectedAnnotations.push(a[i]);
          }
        });
      }
      else {
        this.deselectAllAnnotations();
      }

      this.doNotRefireSelect = true;
      this.selectAnnotations(selectedAnnotations);
    }
  }

  hideAnnotations(): void {
    if (this.wvInstance) {
      var annotations = this.wvInstance.annotManager.getAnnotationsList();
      var selectedAnnots = this.wvInstance.annotManager.getSelectedAnnotations();

      annotations.forEach(async (v, i, a) => {
        if (!selectedAnnots.find((annot) => {
          return annot == v;
        })) {
          if (!a[i]['orginal_draw']) {
            a[i]['orginal_draw'] = a[i].draw;
          }

          a[i]['that'] = this;

          a[i].draw = function (ctx, pageMatrix) {

            if (typeof this['setStyles'] == 'function') {
              this.setStyles(ctx, pageMatrix);
            }

            if (this.BlendMode) {
              this.BlendMode = 'normal';
            }


            const img = document.getElementById('marker');
            ctx.translate(this.X, this.Y);

            ctx.drawImage(
              img, // The image to render
              (this.Width - 30) / 2, // The X coordinate of where to place the image
              (this.Height - 40) / 2, // The Y coordinate of where the place the image
              30, // The width of the image in pixels
              40, // The height of the image in pixels
            );

            ctx.font = "15px sans-serif";
            ctx.fillStyle = 'white';
            var text: string = this.that.getIdString(this);
            ctx.fillText(text, (this.Width - (8 * text.length)) / 2, (this.Height) / 2);
            ctx.restore();
          }

          await this.wvInstance.annotManager.redrawAnnotation(a[i]);
        }
      });
    }
  }

  showAnnotations(): void {
    if (this.wvInstance) {

      var annotations = this.wvInstance.annotManager.getAnnotationsList();

      annotations.forEach((v, i, a) => {

        if (a[i]['orginal_draw'] == null) {
          //assume we really shouldn't be here
          a[i]['orginal_draw'] = a[i].draw;
        }
        a[i].draw = a[i]['orginal_draw'];

        if (a[i].BlendMode) {
          a[i].BlendMode = 'multiply';
        }


        this.wvInstance.annotManager.redrawAnnotation(a[i]);
      });
    }
  }

  getAnnotationTitleText(Annotation): string {
    var rv: string = '';

    var annotations : IAnnotation [] = this.annotationService.getAnnotationValues();
    if (annotations) {
      var annot: IAnnotation = annotations.find((v) => {
        if (v.name) {
          return !v.name.localeCompare(Annotation.Dx);
        }

        return false;
      });

      if (annot != null && annot.markup != null) {
        if (annot.markup.length > 20) {
          rv = annot.markup.substr(0, 17);

          rv += '...';
        }
        else {
          rv = annot.markup;
        }
      }
      else {
        rv = '...';
      }
    }

    return rv;
  }

  getIdString(Annotation): string {
    var annotations: IAnnotation[] = this.annotationService.getAnnotationValues();

    if (annotations) {
      var annot: IAnnotation = annotations.find((v) => {
        return !v.name.localeCompare(Annotation.Dx);
      });

      if (annot) {
        return annot.seqNbr.toString();
      }

      return '';
    }
  }
}
