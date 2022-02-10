
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
//import { initializeVideoViewer } from '@pdftron/webviewer-video';
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
import { ScrollService } from '../services/scroll.service';
import { IScrollEvent } from '../interfaces/scroll-event';
import { FeedbackService } from '../services/feedback.service';
import { initializeHTMLViewer } from '@pdftron/webviewer-html';

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

  public loadHTMLPage: Function = null;
  public myID: number = null;

  baseHref: string = "";

  mimeTypes: { [key: string]: string } = {
    'image/jpeg': 'jpg',
    'application/pdf': 'pdf'
  }


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
    private scrollService: ScrollService,
    private feedbackService: FeedbackService,
    @Inject(APP_BASE_HREF) baseHref: string) {

    this.baseHref = baseHref;
  }

  ngOnInit() {

    this.feedbackService.getFeedBackUpdated().subscribe((documentId: number) => {
      if (documentId) {
        if (this.mainView && this.document?.documentId == documentId) {
          this.annotationService.loadAnotations(this.dl, this.document?.documentId);
        }
        else if (this.document?.documentId == documentId) {
          this.comparisonAnnotationService.loadAnotations(this.dl, this.document?.documentId);
        }
      }
    });

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
      this.searchText(options);
    });

    this.searchService.getClearSearchText().pipe(takeUntil(this.destroy$), filter(o => o != false)).subscribe((clear: boolean) => {
      if (clear) {
        this.clearSearchText();
      }
    });

    this.searchService.getSelectedResult().pipe(takeUntil(this.destroy$), filter(o => o != null)).subscribe((searchResult: ISearchResults) => {
      if (this.wvInstance) {
        var docViewer = this.wvInstance.docViewer;
        if (searchResult.pageNum != docViewer.getCurrentPage()) {
          //its a pretty good bet this was set progmatically so move to the page
          docViewer.setCurrentPage(searchResult.pageNum);
        }

        docViewer.setActiveSearchResult(searchResult.searchResult);
      }
    });

    this.scrollService.getScrollEvent().pipe(takeUntil(this.destroy$)).subscribe((e: IScrollEvent) => {
      if (e.id != this.myID) {
        var frame = this.viewer.nativeElement.querySelector('iframe');

        if (frame) {
          frame.contentDocument.body.querySelector('.DocumentContainer').scrollTop = e.scrollTop;
          frame.contentDocument.body.querySelector('.DocumentContainer').scrollLeft = e.scrollLeft;
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
      //the key below is for the html version of PDFtron
      //licenseKey: 'scott.byrnes@gotoadvantage.com///22:128:203:28:12:246:218:153:163:181:107:50:196:237:29:33:225:193:212:18:207:133:32:144:133:139:236:34:160:2:213:229:5:233:252:197:232:120:115:197:97:4:7:226:63:185:109:203:254:164:61:37:43:212:36:14:253:163:249:35:67:248:45:47:5:13:170:250:228:182:196:196:88:255:221:139:33:130:105:122:233:64:192:187:115:238:34:128:143:36:132:124:172:46:66:127:207:58:45:34:101:32:189:170:103:216:40:246:41:4:178:189:144:245:112:208:8:69:160:254:222:177:238:52:8:210:181:165',
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
      var frame = this.viewer.nativeElement.querySelector('iframe').contentDocument.body.querySelector('.DocumentContainer');
      this.myID = Math.random();
      if (frame) {
        frame.addEventListener("scroll", (e: any) => {
          var scrollEvent: IScrollEvent = {
            id : this.myID,
            scrollLeft : e.srcElement.scrollLeft,
            scrollTop : e.srcElement.scrollTop,
          };
          this.scrollService.setScrollEvent(scrollEvent);
        });
      }
      else {
        console.log("DocumentContainer not found");
      }

      var { Core } = instance;
      Core.PDFNet.initialize('The Advantage Software Company, LLC(gotoadvantage.com):OEM:Webvantage::B+:AMS(20220707):B0A55FBD04E7860A7360B13AC982737860617F8BAF603A63EB1CFC921A345837128A31F5C7');

      this.wvInstance.setAnnotationContentOverlayHandler(annotation => {
        var div = document.createElement('div');
        div.innerHTML = this.getAnnotationTitleText(annotation).trim();
        div.setAttribute("style", "height: 100%; text-overflow: unset; white-space: unset;");
        return div;
      });

      this.wvInstance.annotManager.addEventListener('annotationChanged', (annotations, action, { imported }) => {
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
        }
        else {
          console.log(action);
        }

        return;
      });

      this.wvInstance.annotManager.addEventListener('annotationSelected', (annotations, action) => {
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

            this.wvInstance.annotManager.jumpToAnnotation(annotations[0]);

          }

          if (this.doNotRefireSelect) {
            //short circuit
            this.doNotRefireSelect = false;
            return;
          }

          if (annotations) {
            if (this.mainView) {
              this.annotationService.setToolOpacity(annotations[0].Opacity);
              this.annotationService.setToolSize(annotations[0].StrokeThickness);
              if (annotations[0].Color) {
                this.annotationService.setSelectedColor(annotations[0].Color.toHexString());
              }

              this.annotationService.setSelectedByAU(annotations[0].Dx);
            }
            else {
              this.comparisonAnnotationService.setSelectedByAU(annotations[0].Dx);
            }

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

      this.wvInstance.docViewer.addEventListener('documentLoaded', async () => {
        this.documentLoaded = true;
        this.annotationService.setSelected(null);
        this.setFitMode('actualSize');

        if (this.centralPanelButtonsService.getButtonState(CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION)) {
          this.wvInstance.openElements(['thumbnailsPanel']);
        }

        var docViewer = this.wvInstance.docViewer;

        await docViewer.getDocument().documentCompletePromise();

        docViewer.addEventListener('activeSearchResultChanged', () => {
        });


        if (this.mainView) {
          this.annotationService.loadAnotations(this.dl, this.document?.documentId);
        }
        else {
          this.comparisonAnnotationService.loadAnotations(this.dl, this.document?.documentId);
        }

      });

      if (this.mainView) {
        this.annotationService.getAnnotations().pipe(takeUntil(this.destroy$)).subscribe((annotations) => {
          this.deleteAllAnnotations();

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

            if (this.centralPanelButtonsService.getButtonState(CENTRAL_BUTTONS_TYPES.MARKER_TOOL)) {
              this.hideAnnotations();
              this.useMarkers = true;
            }
          }
        });

        this.comparisonAnnotationService.getSelected()
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


      const searchListener = (searchPattern, options, results) => {
        var searchResults: ISearchResults[] = [];

        results.map(result => {
          var searchResult: ISearchResults = {
            ambientStr: result.ambientStr,
            pageNum: result.pageNum,
            resultStr: result.resultStr,
            resultStrEnd: result.resultStrEnd,
            resultStrStart: result.resultStrStart,
            active: false,
            searchResult: result
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
  }

  SetToolMode(Tool: string): void {
    var docViewer = this.wvInstance?.docViewer;
    if (docViewer) {
      docViewer.setToolMode(docViewer.getTool(Tool));
    }
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
  /*
   * This is where we laod the documents. Right now there are some be assumptions made about the link type. We are assuming that if
   * the file is on a google drive then it is a reguler file and not an html file. Other wise if it is a link we are assuming it is a link
   * to an html page.
   * */
  async loadDocument(dl: string, document?: IDocument, compareDocument?: IDocument) {
    var instance = this.wvInstance;
    this.dl = dl;
    this.document = document;
    this.compareDocument = compareDocument;

    this.documentLoaded = false;
    this.annotationService.clearAnnotations();

    //remove any annotations that were in a draft state
    this.annotationService.clearDraftAnnotations();

    if (instance) {
      //
      if (this.overlay == false || this.mainView) {
        var temp = document?.repositoryFilename;
        console.log('mime', document?.mimeType, 'repositoryFilename', temp, 'document', document)
        if (document?.mimeType == 'URL') {
          if (temp.includes('https://drive.google.com') && !temp.includes('export=download')) {
            //this looks like a google drive shared link we need to make is a direct link
            temp = this.getGoogleDriveDirectLinkFromSharedLink(temp);
          }
          else if (temp.includes('https://1drv.ms')) {
            //one drive
            temp = btoa(encodeURI(temp.trim())).replace('/', '_').replace('+', '-');
            if (temp.length % 4 != 0) {
              temp += ('===').slice(0, 4 - (temp.length % 4));
            }
            temp = 'https://api.onedrive.com/v1.0/shares/u!' + temp + '/root/content';
          }
          else {
            /*
             * This should properly load the html viewer when the package is installed.
             * */

            //lets go with html
            if (this.loadHTMLPage == null) {
              const { loadHTMLPage } = await initializeHTMLViewer(instance);
              this.loadHTMLPage = loadHTMLPage;
            }

            this.loadHTMLPage({
              origUrl: '',
              url: temp,
              width: 1000,
              height: 500,
              license: 'scott.byrnes@gotoadvantage.com///22:128:203:28:12:246:218:153:163:181:107:50:196:237:29:33:225:193:212:18:207:133:32:144:133:139:236:34:160:2:213:229:5:233:252:197:232:120:115:197:97:4:7:226:63:185:109:203:254:164:61:37:43:212:36:14:253:163:249:35:67:248:45:47:5:13:170:250:228:182:196:196:88:255:221:139:33:130:105:122:233:64:192:187:115:238:34:128:143:36:132:124:172:46:66:127:207:58:45:34:101:32:189:170:103:216:40:246:41:4:178:189:144:245:112:208:8:69:160:254:222:177:238:52:8:210:181:165'
            });

            return;
          }

          this.http.get(temp, { responseType: 'blob' }).subscribe((results) => {
            instance.loadDocument(results, { extension: this.mimeTypes[results.type]});
          });
          return

        }
        // else if (document?.mimeType == 'video/mp4') {
        //   // Extends WebViewer to allow loading HTML5 videos (.mp4, ogg, webm).
        //   const {loadVideo} = await initializeVideoViewer(instance,
        //     {
        //       license: "scott.byrnes@gotoadvantage.com///159:21:60:200:148:200:216:191:8:72:220:108:220:174:188:38:66:59:54:111:181:208:204:55:94:24:40:74:0:4:16:229:69:252:47:148:14:98:223:217:98:88:10:73:50:55:3:250:69:66:179:94:99:122:197:102:29:112:118:117:7:222:147:78:85:29:79:167:226:245:250:212:6:221:161:240:123:127:14:181:254:205:178:232:26:165:222:242:157:221:0:12:165:105:42:2:27:74:194:33:57:113:109:161:123:199:35:132:229:27:64:36:191:211:24:127:36:231:135:157:174:191:154:61:96:102:244:149:144:202:140:186:243:50:126:159:58:165:95:57:5:91:114:248:75:19:56:122:61:119:110:77:214:128:113:73:86:0:70:112:54:91:48:7:236:112:156:187:235:29:49:180:93:186:208:33:222:8:252:152:129:79:97:52:79:91:25:37:50:39:150:77:10:207:54:221:234:101:78:21:85:166:45:127:98:193:141:130:86:74:151:5:101:147:89:98:58:103:158:220:73:35:121:188:173:197:132:169:6:91:47:232:243:147:54:248:144:58:40:56:146:89:99:225:29:147:97:135:88:103:71:174:12:68:166:145:138:87:20:211:201:174:162:93:146:37:157:133:73:240:29:18:63:167:175:43:42:184:236:210:4:127:203:66:159:201:176:169:139:74:95:248:242:203:203:78:207:111:37:43:160:76:182:49:70:135:142:204:109:210:217:69:191:161:209:140:194:93:190:173:110:76:129:62:143:66:112:206:73:147:9:17:197:234:141:97:247:24:41:66:177:2:119:39:34:131:129:82:193:82:56:38:84:26:145:50:184:83:236:125:86:6:34:208:77:142:225:190:1:158:167:135:180:64:241:6:50:250:110:75:98:166:144:47:251:68:77:177:152:186:161:71:87:163:96:115:54:244:124:108:244:106:127:170:31:41:213:0:248:109:190:34:180:61:65:149:120:130:242:223:183:150:32:136:94:86:133:124:84:176:67:229:92:184:134:126:58:24:161:184:216:33:160:158:95:21:226:94:35:96:175:157:7:159:166:231:228:35:75:1:77:54:149:110:16:195:74:189:229:50:89:139:18:216:44:184:107:36:17:255:221:171:113:254:208:211:5:12:100:148:13:248:199:103:152:0:36:146:159:114:86:12:56:215:233:195:41:75:136:188:153:111",
        //     });
        //     this.loadVideo = loadVideo;
        //     //Docs here:
        //     //Simplifi/Advantage/Webvantage.Angular/ClientApp/node_modules/@pdftron/webviewer-video/doc/index.html
        //     //https://www.pdftron.com/documentation/web/get-started/manually-video/
        //     //demo: https://webviewer-video.web.app/
        // }
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
            this.http.get(this.baseHref + 'api/ProofingDocumentName/' + this.compareDocument?.documentId + '?dl=' + dl, { responseType: 'text' }).subscribe((compareFileName) => {
              this.compare(dl, this.compareDocument?.documentId, compareFileName ,document?.documentId, filename, document?.mimeType);
            });
          });
      }
    }

    this.documentVersionService.getVersion(document?.documentId).subscribe((version) => {
      this.version.nativeElement.innerHTML = (document != null ? document.filename : '') +  ' Version ' + version;
    })
  }

  compare(dl: string, compareDocumentId: number, compareFileName: string, documentId: number, filename: string, mimeType: string) {
    console.log('start of compare');
    this.wvInstance.UI.openElements(['loadingModal']);
    if (mimeType.startsWith('image')) {
      this.compareDocumentsPixels(dl, compareDocumentId, documentId, filename);
    }
    else {
      this.compareDocuments(dl, compareDocumentId, compareFileName, documentId, filename);
    }

    this.annotationService.loadComparisonAnotations(dl, documentId);

    console.log('end of compare');
    //this.wvInstance.UI.closeElements(['loadingModal']);
  }

  async compareDocuments(dl: string, compareDocumentId: number, compareFileName: string ,documentId: number, filename: string) {
    var url: string = this.baseHref + 'api/ProofingDocument';

    var doc1 = await this.getDocumentPDF(url + '/' + documentId + '/?dl=' + dl, filename);
    var doc2 = await this.getDocumentPDF(url + '/' + compareDocumentId + '/?dl=' + dl, '_' + compareFileName);

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
    if (this.wvInstance && options) {
      var instance = this.wvInstance;
      instance.searchTextFull(options?.searchPhrase, options);
    }
  }

  clearSearchText() {
    if (this.wvInstance) {
      var docViewer = this.wvInstance.docViewer;
      docViewer.clearSearchResults();
    }
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

      case 'AnnotationCreateSticky': {
        toolType = TOOL_TYPE.NOTE;
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
    var annotations = null;

    if (this.mainView) {
      annotations = this.annotationService.getAllWithCommentId(commentID);
    }
    else {
      annotations = this.comparisonAnnotationService.getAllWithCommentId(commentID);
    }

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
        var selected = null;

        if (this.mainView) {
          selected = this.annotationService.getSelectedValue();
        }
        else{
          selected = this.comparisonAnnotationService.getSelectedValue();
        }

        console.log(selected);

        PDFTronannotations.forEach((v, i, a) => {
          if (selected?.name == v.Dx) {
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

    var annotations: IAnnotation[] = null;

    if (this.mainView == true) {
      annotations = this.annotationService.getAnnotationValues();
    }
    else {
      annotations = this.comparisonAnnotationService.getAnnotationValues();
    }

    if (annotations) {
      var annot: IAnnotation = annotations.find((v) => {
        if (v.name) {
          return v.name == Annotation.Dx;
        }
        return false;
      });

      if (annot != null && annot.markup != null) {
        rv = annot.markup;
      }
      else {
        rv = '...';
      }
    }

    return rv;
  }

  getIdString(Annotation): string {
    var annotations: IAnnotation[] = null;

    if (this.mainView == true) {
      annotations = this.annotationService.getAnnotationValues();
    }
    else {
      annotations = this.comparisonAnnotationService.getAnnotationValues();
    }

    if (annotations) {
      var annot: IAnnotation = annotations.find((v) => {
        if (v.name) {
          return v.name == Annotation.Dx;
        }

        return false;
      });

      if (annot) {
        return annot.seqNbr.toString();
      }

      return '';
    }
  }

  getGoogleDriveDirectLinkFromSharedLink(sharedLink: string): string  {
    var idExtractor = /\/d\/(.+?)(?:\/|#|\?|$)/;
    var result = idExtractor.exec(sharedLink);

    var finalLink = "https://drive.google.com/uc?export=download&id=" + result[1];

    return finalLink;
  }
}
