import { NgModule } from '@angular/core';
import { APP_BASE_HREF, CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToolBarModule } from '@progress/kendo-angular-toolbar';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { UploadsModule } from '@progress/kendo-angular-upload';
import { GridModule } from '@progress/kendo-angular-grid';
import { TooltipModule } from '@progress/kendo-angular-tooltip';
import { DialogModule } from "@progress/kendo-angular-dialog";
import { NgScrollbarModule } from 'ngx-scrollbar';

import { WorkspaceContainerComponent } from './components/central-container/workspace-container/workspace-container.component';
import { ActionAreaComponent } from './components/action-area/action-area.component';
import { AssetExplorerToolbarComponent } from './components/bottom-container/asset-explorer-toolbar/asset-explorer-toolbar.component';
import { AssetExplorerItemComponent } from './components/bottom-container/asset-explorer-item/asset-explorer-item.component';
import { ProofingComponent } from './components/proofing/proofing.component';
import { WorkspaceToolbarComponent } from './components/central-container/workspace-toolbar/workspace-toolbar.component';
import { CentralContainerComponent } from './components/central-container/central-container.component';
import { BottomContainerComponent } from './components/bottom-container/bottom-container.component';
import { WorkspaceViewComponent } from './components/central-container/workspace-container/workspace-view/workspace-view.component';
import { WorkspacePagePreviewComponent } from './components/central-container/workspace-container/workspace-page-preview/workspace-page-preview.component';
import { SliderComponent } from './shared/components/slider/slider.component';
import { CustomToolbarItemComponent } from './shared/components/custom-toolbar-item/custom-toolbar-item.component';
//import { WorkspacePagerComponent } from './components/central-container/workspace-container/workspace-pager/workspace-pager.component';
import { DropDownComponent } from './shared/components/drop-down/drop-down.component';
import { DialogWindowComponent } from './shared/components/dialog-window/dialog-window.component';
import { FileNameComponent } from './shared/components/file-name/file-name.component';
import { ItemComponent } from './components/bottom-container/asset-explorer-item/item/item.component';
import { DropDownSelectorComponent } from './shared/components/drop-down-selector/drop-down-selector.component';
import { WorkspaceViewSplitVerticalComponent } from './components/central-container/workspace-container/workspace-view-split-vertical/workspace-view-split-vertical.component';
import { WorkspaceViewSplitHorizontalComponent } from './components/central-container/workspace-container/workspace-view-split-horizontal/workspace-view-split-horizontal.component';
import { CollapsiblePanelComponent } from './components/action-area/collapsible-panel/collapsible-panel.component';
import { ColorPickerComponent } from './components/action-area/collapsible-panel/components/color-picker/color-picker.component';
import { SaveButtonComponent } from './components/action-area/collapsible-panel/components/save-button/save-button.component';
import { DescriptionComponent } from './components/action-area/collapsible-panel/components/description/description.component';
import { UploadedItemImageComponent } from './components/action-area/collapsible-panel/components/drag-and-drop-image/uploaded-item-image/uploaded-item-image.component';
import { ItemLinkComponent } from './components/action-area/collapsible-panel/components/drag-and-drop-link/item-link/item-link.component';
import { PageSelectorComponent } from './components/action-area/collapsible-panel/components/drag-and-drop-link/page-selector/page-selector.component';
import { LinkTypeSelectorComponent } from './components/action-area/collapsible-panel/components/drag-and-drop-link/link-type-selector/link-type-selector.component';
import { InputComponent } from './shared/components/input/input.component';
import { LinkComponent } from './components/action-area/collapsible-panel/components/drag-and-drop-link/link/link.component';
import { FeedbacksComponent } from './components/action-area/collapsible-panel/feedbacks/feedbacks.component';
import { FeedbackComponent } from './components/action-area/collapsible-panel/feedbacks/feedback/feedback.component';
import { DropDownFeedbackComponent } from './components/action-area/collapsible-panel/feedbacks/drop-down-feedback/drop-down-feedback.component';
import { PastedImageComponent } from './shared/components/pasted-image/pasted-image.component';
import { TextareaComponent } from './shared/components/textarea/textarea.component';
import { ReviewsComponent } from './components/action-area/collapsible-panel/reviews/reviews.component';
import { ReviewTypeSelectorComponent } from './components/action-area/collapsible-panel/reviews/review-type-selector/review-type-selector.component';
import { ReviewVersionsComponent } from './components/action-area/collapsible-panel/reviews/review-versions/review-versions.component';
import { ReviewUserBlockComponent } from './components/action-area/collapsible-panel/reviews/review-versions/review-user-block/review-user-block.component';
import { ReviewVersionBlockComponent } from './components/action-area/collapsible-panel/reviews/review-versions/review-version-block/review-version-block.component';
import { FileIconsComponent } from './shared/components/file-icons/file-icons.component';
import { ReviewFileNameComponent } from './components/action-area/collapsible-panel/reviews/review-versions/review-file-name/review-file-name.component';
import { ReviewApprovalComponent } from './components/action-area/collapsible-panel/reviews/review-approval/review-approval.component';
import { AssetInfoComponent } from './components/action-area/collapsible-panel/asset-info/asset-info.component';
import { AssetGridComponent } from './components/action-area/collapsible-panel/asset-info/asset-grid/asset-grid.component';
import { TagComponent } from './components/action-area/collapsible-panel/asset-info/asset-grid/tag/tag.component';
import { FileGridComponent } from './components/action-area/collapsible-panel/asset-info/file-grid/file-grid.component';
import { VersionsGridComponent } from './components/action-area/collapsible-panel/asset-info/versions-grid/versions-grid.component';
import { FolderCompareButtonsComponent } from './shared/components/folder-compare-buttons/folder-compare-buttons.component';
import { AdditionalInfoComponent } from './components/action-area/collapsible-panel/asset-info/additional-info/additional-info.component';
import { WebViewerComponent } from './webviewer/webviewer.component';
import { CommentComponent } from './components/action-area/collapsible-panel/comment/comment.component';
import { CommentViewComponent } from './components/action-area/collapsible-panel/comment-view/comment-view.component';
import { CommentReplyComponent } from './components/action-area/collapsible-panel/comment-reply/comment-reply.component';
import { FileSizePipe } from './shared/Pipes/file-size';
import { SearchComponent } from './components/action-area/collapsible-panel/search/search.component';
import { SearchResultsComponent } from './components/action-area/collapsible-panel/search/search-results/search-results.component';
import { SearchInputComponent } from './components/action-area/collapsible-panel/search/search-input/search-input.component'
import { EditorModule } from '@progress/kendo-angular-editor';
import { SearchResultComponent } from './components/action-area/collapsible-panel/search/search-result/search-result.component';
import { MentionItemComponent } from './shared/components/mention-item/mention-item.component';
import { Safe } from './shared/pipes/safe-html';

@NgModule({
  declarations: [
    ProofingComponent,
    WorkspaceToolbarComponent,
    ActionAreaComponent,
    CentralContainerComponent,
    WorkspaceContainerComponent,
    BottomContainerComponent,
    AssetExplorerToolbarComponent,
    AssetExplorerItemComponent,
    WorkspaceViewComponent,
    WorkspacePagePreviewComponent,
    SliderComponent,
    CustomToolbarItemComponent,
    //WorkspacePagerComponent,
    DropDownComponent,
    DialogWindowComponent,
    FileNameComponent,
    ItemComponent,
    DropDownSelectorComponent,
    WorkspaceViewSplitVerticalComponent,
    WorkspaceViewSplitHorizontalComponent,
    CollapsiblePanelComponent,
    ColorPickerComponent,
    SaveButtonComponent,
    DescriptionComponent,
    UploadedItemImageComponent,
    ItemLinkComponent,
    PageSelectorComponent,
    LinkTypeSelectorComponent,
    InputComponent,
    LinkComponent,
    FeedbacksComponent,
    FeedbackComponent,
    DropDownFeedbackComponent,
    PastedImageComponent,
    TextareaComponent,
    ReviewsComponent,
    ReviewTypeSelectorComponent,
    ReviewVersionsComponent,
    ReviewUserBlockComponent,
    ReviewVersionBlockComponent,
    FileIconsComponent,
    ReviewFileNameComponent,
    ReviewApprovalComponent,
    AssetInfoComponent,
    AssetGridComponent,
    TagComponent,
    FileGridComponent,
    VersionsGridComponent,
    FolderCompareButtonsComponent,
    AdditionalInfoComponent,
    WebViewerComponent,
    CommentComponent,
    CommentViewComponent,
    CommentReplyComponent,
    FileSizePipe,
    SearchComponent,
    SearchResultsComponent,
    SearchInputComponent,
    SearchResultComponent,
    MentionItemComponent,
    Safe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ToolBarModule,
    LayoutModule,
    ButtonsModule,
    InputsModule,
    DropDownsModule,
    DialogsModule,
    NgScrollbarModule,
    UploadsModule,
    GridModule,
    TooltipModule,
    EditorModule,
    DialogModule
  ],
  exports: [ProofingComponent, WorkspaceToolbarComponent],
  providers: [Safe],
})
export class ProofingModule {
}
