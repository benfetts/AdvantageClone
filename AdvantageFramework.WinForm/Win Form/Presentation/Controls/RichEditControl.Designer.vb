Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RichEditControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim OptionsSpelling1 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
            Me.RichEdit = New DevExpress.XtraRichEdit.RichEditControl()
            Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
            Me.CommonBar1 = New DevExpress.XtraRichEdit.UI.CommonBar()
            Me.UndoItem1 = New DevExpress.XtraRichEdit.UI.UndoItem()
            Me.RedoItem1 = New DevExpress.XtraRichEdit.UI.RedoItem()
            Me.ClipboardBar1 = New DevExpress.XtraRichEdit.UI.ClipboardBar()
            Me.CutItem1 = New DevExpress.XtraRichEdit.UI.CutItem()
            Me.CopyItem1 = New DevExpress.XtraRichEdit.UI.CopyItem()
            Me.PasteItem1 = New DevExpress.XtraRichEdit.UI.PasteItem()
            Me.PasteSpecialItem1 = New DevExpress.XtraRichEdit.UI.PasteSpecialItem()
            Me.FontBar1 = New DevExpress.XtraRichEdit.UI.FontBar()
            Me.ChangeFontNameItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontNameItem()
            Me.RepositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
            Me.ChangeFontSizeItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontSizeItem()
            Me.RepositoryItemRichEditFontSizeEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit()
            Me.FontSizeIncreaseItem1 = New DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem()
            Me.FontSizeDecreaseItem1 = New DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem()
            Me.ToggleFontBoldItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontBoldItem()
            Me.ToggleFontItalicItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontItalicItem()
            Me.ToggleFontUnderlineItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem()
            Me.ToggleFontDoubleUnderlineItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem()
            Me.ToggleFontStrikeoutItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem()
            Me.ToggleFontDoubleStrikeoutItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem()
            Me.ToggleFontSuperscriptItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem()
            Me.ToggleFontSubscriptItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem()
            Me.ChangeFontColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontColorItem()
            Me.ChangeFontBackColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem()
            Me.ChangeTextCaseItem1 = New DevExpress.XtraRichEdit.UI.ChangeTextCaseItem()
            Me.MakeTextUpperCaseItem1 = New DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem()
            Me.MakeTextLowerCaseItem1 = New DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem()
            Me.ToggleTextCaseItem1 = New DevExpress.XtraRichEdit.UI.ToggleTextCaseItem()
            Me.ClearFormattingItem1 = New DevExpress.XtraRichEdit.UI.ClearFormattingItem()
            Me.ParagraphBar1 = New DevExpress.XtraRichEdit.UI.ParagraphBar()
            Me.ToggleBulletedListItem1 = New DevExpress.XtraRichEdit.UI.ToggleBulletedListItem()
            Me.ToggleNumberingListItem1 = New DevExpress.XtraRichEdit.UI.ToggleNumberingListItem()
            Me.ToggleMultiLevelListItem1 = New DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem()
            Me.DecreaseIndentItem1 = New DevExpress.XtraRichEdit.UI.DecreaseIndentItem()
            Me.IncreaseIndentItem1 = New DevExpress.XtraRichEdit.UI.IncreaseIndentItem()
            Me.ToggleParagraphAlignmentLeftItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem()
            Me.ToggleParagraphAlignmentCenterItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem()
            Me.ToggleParagraphAlignmentRightItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem()
            Me.ToggleParagraphAlignmentJustifyItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem()
            Me.ToggleShowWhitespaceItem1 = New DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem()
            Me.ShowParagraphFormItem1 = New DevExpress.XtraRichEdit.UI.ShowParagraphFormItem()
            Me.ChangeParagraphLineSpacingItem1 = New DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem()
            Me.SetSingleParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem()
            Me.SetSesquialteralParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem()
            Me.SetDoubleParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem()
            Me.ShowLineSpacingFormItem1 = New DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem()
            Me.AddSpacingBeforeParagraphItem1 = New DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem()
            Me.RemoveSpacingBeforeParagraphItem1 = New DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem()
            Me.AddSpacingAfterParagraphItem1 = New DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem()
            Me.RemoveSpacingAfterParagraphItem1 = New DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem()
            Me.ChangeParagraphBackColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem()
            Me.StylesBar1 = New DevExpress.XtraRichEdit.UI.StylesBar()
            Me.ChangeStyleItem1 = New DevExpress.XtraRichEdit.UI.ChangeStyleItem()
            Me.RepositoryItemRichEditStyleEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit()
            Me.ShowEditStyleFormItem1 = New DevExpress.XtraRichEdit.UI.ShowEditStyleFormItem()
            Me.EditingBar1 = New DevExpress.XtraRichEdit.UI.EditingBar()
            Me.FindItem1 = New DevExpress.XtraRichEdit.UI.FindItem()
            Me.ReplaceItem1 = New DevExpress.XtraRichEdit.UI.ReplaceItem()
            Me.LinksBar1 = New DevExpress.XtraRichEdit.UI.LinksBar()
            Me.InsertHyperlinkItem1 = New DevExpress.XtraRichEdit.UI.InsertHyperlinkItem()
            Me.SymbolsBar1 = New DevExpress.XtraRichEdit.UI.SymbolsBar()
            Me.DocumentProofingBar1 = New DevExpress.XtraRichEdit.UI.DocumentProofingBar()
            Me.CheckSpellingItem1 = New DevExpress.XtraRichEdit.UI.CheckSpellingItem()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.ShowFontFormItem1 = New DevExpress.XtraRichEdit.UI.ShowFontFormItem()
            Me.InsertPageBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertPageBreakItem()
            Me.InsertTableItem1 = New DevExpress.XtraRichEdit.UI.InsertTableItem()
            Me.InsertPictureItem1 = New DevExpress.XtraRichEdit.UI.InsertPictureItem()
            Me.InsertFloatingPictureItem1 = New DevExpress.XtraRichEdit.UI.InsertFloatingPictureItem()
            Me.EditPageHeaderItem1 = New DevExpress.XtraRichEdit.UI.EditPageHeaderItem()
            Me.EditPageFooterItem1 = New DevExpress.XtraRichEdit.UI.EditPageFooterItem()
            Me.InsertPageNumberItem1 = New DevExpress.XtraRichEdit.UI.InsertPageNumberItem()
            Me.InsertPageCountItem1 = New DevExpress.XtraRichEdit.UI.InsertPageCountItem()
            Me.InsertTextBoxItem1 = New DevExpress.XtraRichEdit.UI.InsertTextBoxItem()
            Me.InsertSymbolItem1 = New DevExpress.XtraRichEdit.UI.InsertSymbolItem()
            Me.ChangeSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPageMarginsItem()
            Me.SetNormalSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetNormalSectionPageMarginsItem()
            Me.SetNarrowSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetNarrowSectionPageMarginsItem()
            Me.SetModerateSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetModerateSectionPageMarginsItem()
            Me.SetWideSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetWideSectionPageMarginsItem()
            Me.ShowPageMarginsSetupFormItem1 = New DevExpress.XtraRichEdit.UI.ShowPageMarginsSetupFormItem()
            Me.ChangeSectionPageOrientationItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPageOrientationItem()
            Me.SetPortraitPageOrientationItem1 = New DevExpress.XtraRichEdit.UI.SetPortraitPageOrientationItem()
            Me.SetLandscapePageOrientationItem1 = New DevExpress.XtraRichEdit.UI.SetLandscapePageOrientationItem()
            Me.ChangeSectionPaperKindItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPaperKindItem()
            Me.ChangeSectionColumnsItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionColumnsItem()
            Me.SetSectionOneColumnItem1 = New DevExpress.XtraRichEdit.UI.SetSectionOneColumnItem()
            Me.SetSectionTwoColumnsItem1 = New DevExpress.XtraRichEdit.UI.SetSectionTwoColumnsItem()
            Me.SetSectionThreeColumnsItem1 = New DevExpress.XtraRichEdit.UI.SetSectionThreeColumnsItem()
            Me.ShowColumnsSetupFormItem1 = New DevExpress.XtraRichEdit.UI.ShowColumnsSetupFormItem()
            Me.InsertBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertBreakItem()
            Me.InsertColumnBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertColumnBreakItem()
            Me.InsertSectionBreakNextPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakNextPageItem()
            Me.InsertSectionBreakEvenPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakEvenPageItem()
            Me.InsertSectionBreakOddPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakOddPageItem()
            Me.ChangeSectionLineNumberingItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionLineNumberingItem()
            Me.SetSectionLineNumberingNoneItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingNoneItem()
            Me.SetSectionLineNumberingContinuousItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingContinuousItem()
            Me.SetSectionLineNumberingRestartNewPageItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewPageItem()
            Me.SetSectionLineNumberingRestartNewSectionItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewSectionItem()
            Me.ToggleParagraphSuppressLineNumbersItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphSuppressLineNumbersItem()
            Me.ShowLineNumberingFormItem1 = New DevExpress.XtraRichEdit.UI.ShowLineNumberingFormItem()
            Me.ChangePageColorItem1 = New DevExpress.XtraRichEdit.UI.ChangePageColorItem()
            Me.InsertTableOfContentsItem1 = New DevExpress.XtraRichEdit.UI.InsertTableOfContentsItem()
            Me.UpdateTableOfContentsItem1 = New DevExpress.XtraRichEdit.UI.UpdateTableOfContentsItem()
            Me.AddParagraphsToTableOfContentItem1 = New DevExpress.XtraRichEdit.UI.AddParagraphsToTableOfContentItem()
            Me.SetParagraphHeadingLevelItem1 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem2 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem3 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem4 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem5 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem6 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem7 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem8 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem9 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.SetParagraphHeadingLevelItem10 = New DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem()
            Me.InsertCaptionPlaceholderItem1 = New DevExpress.XtraRichEdit.UI.InsertCaptionPlaceholderItem()
            Me.InsertFiguresCaptionItems1 = New DevExpress.XtraRichEdit.UI.InsertFiguresCaptionItems()
            Me.InsertTablesCaptionItems1 = New DevExpress.XtraRichEdit.UI.InsertTablesCaptionItems()
            Me.InsertEquationsCaptionItems1 = New DevExpress.XtraRichEdit.UI.InsertEquationsCaptionItems()
            Me.InsertTableOfFiguresPlaceholderItem1 = New DevExpress.XtraRichEdit.UI.InsertTableOfFiguresPlaceholderItem()
            Me.InsertTableOfFiguresItems1 = New DevExpress.XtraRichEdit.UI.InsertTableOfFiguresItems()
            Me.InsertTableOfTablesItems1 = New DevExpress.XtraRichEdit.UI.InsertTableOfTablesItems()
            Me.InsertTableOfEquationsItems1 = New DevExpress.XtraRichEdit.UI.InsertTableOfEquationsItems()
            Me.UpdateTableOfFiguresItem1 = New DevExpress.XtraRichEdit.UI.UpdateTableOfFiguresItem()
            Me.InsertMergeFieldItem1 = New DevExpress.XtraRichEdit.UI.InsertMergeFieldItem()
            Me.ShowAllFieldCodesItem1 = New DevExpress.XtraRichEdit.UI.ShowAllFieldCodesItem()
            Me.ShowAllFieldResultsItem1 = New DevExpress.XtraRichEdit.UI.ShowAllFieldResultsItem()
            Me.ToggleViewMergedDataItem1 = New DevExpress.XtraRichEdit.UI.ToggleViewMergedDataItem()
            Me.ProtectDocumentItem1 = New DevExpress.XtraRichEdit.UI.ProtectDocumentItem()
            Me.ChangeRangeEditingPermissionsItem1 = New DevExpress.XtraRichEdit.UI.ChangeRangeEditingPermissionsItem()
            Me.UnprotectDocumentItem1 = New DevExpress.XtraRichEdit.UI.UnprotectDocumentItem()
            Me.SwitchToSimpleViewItem1 = New DevExpress.XtraRichEdit.UI.SwitchToSimpleViewItem()
            Me.SwitchToDraftViewItem1 = New DevExpress.XtraRichEdit.UI.SwitchToDraftViewItem()
            Me.SwitchToPrintLayoutViewItem1 = New DevExpress.XtraRichEdit.UI.SwitchToPrintLayoutViewItem()
            Me.ToggleShowHorizontalRulerItem1 = New DevExpress.XtraRichEdit.UI.ToggleShowHorizontalRulerItem()
            Me.ToggleShowVerticalRulerItem1 = New DevExpress.XtraRichEdit.UI.ToggleShowVerticalRulerItem()
            Me.ZoomOutItem1 = New DevExpress.XtraRichEdit.UI.ZoomOutItem()
            Me.ZoomInItem1 = New DevExpress.XtraRichEdit.UI.ZoomInItem()
            Me.GoToPageHeaderItem1 = New DevExpress.XtraRichEdit.UI.GoToPageHeaderItem()
            Me.GoToPageFooterItem1 = New DevExpress.XtraRichEdit.UI.GoToPageFooterItem()
            Me.GoToNextHeaderFooterItem1 = New DevExpress.XtraRichEdit.UI.GoToNextHeaderFooterItem()
            Me.GoToPreviousHeaderFooterItem1 = New DevExpress.XtraRichEdit.UI.GoToPreviousHeaderFooterItem()
            Me.ToggleLinkToPreviousItem1 = New DevExpress.XtraRichEdit.UI.ToggleLinkToPreviousItem()
            Me.ToggleDifferentFirstPageItem1 = New DevExpress.XtraRichEdit.UI.ToggleDifferentFirstPageItem()
            Me.ToggleDifferentOddAndEvenPagesItem1 = New DevExpress.XtraRichEdit.UI.ToggleDifferentOddAndEvenPagesItem()
            Me.ClosePageHeaderFooterItem1 = New DevExpress.XtraRichEdit.UI.ClosePageHeaderFooterItem()
            Me.ChangeTableCellsShadingItem1 = New DevExpress.XtraRichEdit.UI.ChangeTableCellsShadingItem()
            Me.ChangeTableBordersItem1 = New DevExpress.XtraRichEdit.UI.ChangeTableBordersItem()
            Me.ToggleTableCellsBottomBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomBorderItem()
            Me.ToggleTableCellsTopBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsTopBorderItem()
            Me.ToggleTableCellsLeftBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsLeftBorderItem()
            Me.ToggleTableCellsRightBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsRightBorderItem()
            Me.ResetTableCellsAllBordersItem1 = New DevExpress.XtraRichEdit.UI.ResetTableCellsAllBordersItem()
            Me.ToggleTableCellsAllBordersItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsAllBordersItem()
            Me.ToggleTableCellsOutsideBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsOutsideBorderItem()
            Me.ToggleTableCellsInsideBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideBorderItem()
            Me.ToggleTableCellsInsideHorizontalBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideHorizontalBorderItem()
            Me.ToggleTableCellsInsideVerticalBorderItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideVerticalBorderItem()
            Me.ToggleShowTableGridLinesItem1 = New DevExpress.XtraRichEdit.UI.ToggleShowTableGridLinesItem()
            Me.ChangeTableBorderLineStyleItem1 = New DevExpress.XtraRichEdit.UI.ChangeTableBorderLineStyleItem()
            Me.RepositoryItemBorderLineStyle1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle()
            Me.ChangeTableBorderLineWeightItem1 = New DevExpress.XtraRichEdit.UI.ChangeTableBorderLineWeightItem()
            Me.RepositoryItemBorderLineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight()
            Me.ChangeTableBorderColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeTableBorderColorItem()
            Me.SelectTableElementsItem1 = New DevExpress.XtraRichEdit.UI.SelectTableElementsItem()
            Me.SelectTableCellItem1 = New DevExpress.XtraRichEdit.UI.SelectTableCellItem()
            Me.SelectTableColumnItem1 = New DevExpress.XtraRichEdit.UI.SelectTableColumnItem()
            Me.SelectTableRowItem1 = New DevExpress.XtraRichEdit.UI.SelectTableRowItem()
            Me.SelectTableItem1 = New DevExpress.XtraRichEdit.UI.SelectTableItem()
            Me.ShowTablePropertiesFormItem1 = New DevExpress.XtraRichEdit.UI.ShowTablePropertiesFormItem()
            Me.DeleteTableElementsItem1 = New DevExpress.XtraRichEdit.UI.DeleteTableElementsItem()
            Me.ShowDeleteTableCellsFormItem1 = New DevExpress.XtraRichEdit.UI.ShowDeleteTableCellsFormItem()
            Me.DeleteTableColumnsItem1 = New DevExpress.XtraRichEdit.UI.DeleteTableColumnsItem()
            Me.DeleteTableRowsItem1 = New DevExpress.XtraRichEdit.UI.DeleteTableRowsItem()
            Me.DeleteTableItem1 = New DevExpress.XtraRichEdit.UI.DeleteTableItem()
            Me.InsertTableRowAboveItem1 = New DevExpress.XtraRichEdit.UI.InsertTableRowAboveItem()
            Me.InsertTableRowBelowItem1 = New DevExpress.XtraRichEdit.UI.InsertTableRowBelowItem()
            Me.InsertTableColumnToLeftItem1 = New DevExpress.XtraRichEdit.UI.InsertTableColumnToLeftItem()
            Me.InsertTableColumnToRightItem1 = New DevExpress.XtraRichEdit.UI.InsertTableColumnToRightItem()
            Me.ShowInsertTableCellsFormItem1 = New DevExpress.XtraRichEdit.UI.ShowInsertTableCellsFormItem()
            Me.MergeTableCellsItem1 = New DevExpress.XtraRichEdit.UI.MergeTableCellsItem()
            Me.ShowSplitTableCellsForm1 = New DevExpress.XtraRichEdit.UI.ShowSplitTableCellsForm()
            Me.SplitTableItem1 = New DevExpress.XtraRichEdit.UI.SplitTableItem()
            Me.ToggleTableAutoFitItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableAutoFitItem()
            Me.ToggleTableAutoFitContentsItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableAutoFitContentsItem()
            Me.ToggleTableAutoFitWindowItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableAutoFitWindowItem()
            Me.ToggleTableFixedColumnWidthItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableFixedColumnWidthItem()
            Me.ToggleTableCellsTopLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsTopLeftAlignmentItem()
            Me.ToggleTableCellsMiddleLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleLeftAlignmentItem()
            Me.ToggleTableCellsBottomLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomLeftAlignmentItem()
            Me.ToggleTableCellsTopCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsTopCenterAlignmentItem()
            Me.ToggleTableCellsMiddleCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleCenterAlignmentItem()
            Me.ToggleTableCellsBottomCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomCenterAlignmentItem()
            Me.ToggleTableCellsTopRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsTopRightAlignmentItem()
            Me.ToggleTableCellsMiddleRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleRightAlignmentItem()
            Me.ToggleTableCellsBottomRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomRightAlignmentItem()
            Me.ShowTableOptionsFormItem1 = New DevExpress.XtraRichEdit.UI.ShowTableOptionsFormItem()
            Me.ChangeFloatingObjectFillColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFloatingObjectFillColorItem()
            Me.ChangeFloatingObjectOutlineColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFloatingObjectOutlineColorItem()
            Me.ChangeFloatingObjectOutlineWeightItem1 = New DevExpress.XtraRichEdit.UI.ChangeFloatingObjectOutlineWeightItem()
            Me.RepositoryItemFloatingObjectOutlineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight()
            Me.ChangeFloatingObjectTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.ChangeFloatingObjectTextWrapTypeItem()
            Me.SetFloatingObjectSquareTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectSquareTextWrapTypeItem()
            Me.SetFloatingObjectTightTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectTightTextWrapTypeItem()
            Me.SetFloatingObjectThroughTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectThroughTextWrapTypeItem()
            Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectTopAndBottomTextWrapTypeItem()
            Me.SetFloatingObjectBehindTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectBehindTextWrapTypeItem()
            Me.SetFloatingObjectInFrontOfTextWrapTypeItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectInFrontOfTextWrapTypeItem()
            Me.ChangeFloatingObjectAlignmentItem1 = New DevExpress.XtraRichEdit.UI.ChangeFloatingObjectAlignmentItem()
            Me.SetFloatingObjectTopLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectTopLeftAlignmentItem()
            Me.SetFloatingObjectTopCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectTopCenterAlignmentItem()
            Me.SetFloatingObjectTopRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectTopRightAlignmentItem()
            Me.SetFloatingObjectMiddleLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleLeftAlignmentItem()
            Me.SetFloatingObjectMiddleCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleCenterAlignmentItem()
            Me.SetFloatingObjectMiddleRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleRightAlignmentItem()
            Me.SetFloatingObjectBottomLeftAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomLeftAlignmentItem()
            Me.SetFloatingObjectBottomCenterAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomCenterAlignmentItem()
            Me.SetFloatingObjectBottomRightAlignmentItem1 = New DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomRightAlignmentItem()
            Me.FloatingObjectBringForwardSubItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectBringForwardSubItem()
            Me.FloatingObjectBringForwardItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectBringForwardItem()
            Me.FloatingObjectBringToFrontItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectBringToFrontItem()
            Me.FloatingObjectBringInFrontOfTextItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectBringInFrontOfTextItem()
            Me.FloatingObjectSendBackwardSubItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectSendBackwardSubItem()
            Me.FloatingObjectSendBackwardItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectSendBackwardItem()
            Me.FloatingObjectSendToBackItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectSendToBackItem()
            Me.FloatingObjectSendBehindTextItem1 = New DevExpress.XtraRichEdit.UI.FloatingObjectSendBehindTextItem()
            Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
            Me.RichEditBarController1 = New DevExpress.XtraRichEdit.UI.RichEditBarController(Me.components)
            Me.InsertPageBreakItem2 = New DevExpress.XtraRichEdit.UI.InsertPageBreakItem()
            CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemRichEditStyleEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RichEdit
            '
            Me.RichEdit.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
            Me.RichEdit.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichEdit.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
            Me.RichEdit.Location = New System.Drawing.Point(0, 62)
            Me.RichEdit.MenuManager = Me.BarManager1
            Me.RichEdit.Name = "RichEdit"
            Me.RichEdit.Size = New System.Drawing.Size(1045, 326)
            Me.RichEdit.SpellChecker = Me.SpellChecker1
            Me.SpellChecker1.SetSpellCheckerOptions(Me.RichEdit, OptionsSpelling1)
            Me.RichEdit.TabIndex = 0
            '
            'BarManager1
            '
            Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.CommonBar1, Me.ClipboardBar1, Me.FontBar1, Me.ParagraphBar1, Me.StylesBar1, Me.EditingBar1, Me.LinksBar1, Me.SymbolsBar1, Me.DocumentProofingBar1})
            Me.BarManager1.DockControls.Add(Me.barDockControlTop)
            Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
            Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
            Me.BarManager1.DockControls.Add(Me.barDockControlRight)
            Me.BarManager1.Form = Me
            Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UndoItem1, Me.RedoItem1, Me.PasteItem1, Me.CutItem1, Me.CopyItem1, Me.PasteSpecialItem1, Me.ChangeFontNameItem1, Me.ChangeFontSizeItem1, Me.FontSizeIncreaseItem1, Me.FontSizeDecreaseItem1, Me.ToggleFontBoldItem1, Me.ToggleFontItalicItem1, Me.ToggleFontUnderlineItem1, Me.ToggleFontDoubleUnderlineItem1, Me.ToggleFontStrikeoutItem1, Me.ToggleFontDoubleStrikeoutItem1, Me.ToggleFontSuperscriptItem1, Me.ToggleFontSubscriptItem1, Me.ChangeFontColorItem1, Me.ChangeFontBackColorItem1, Me.ChangeTextCaseItem1, Me.MakeTextUpperCaseItem1, Me.MakeTextLowerCaseItem1, Me.ToggleTextCaseItem1, Me.ClearFormattingItem1, Me.ShowFontFormItem1, Me.ToggleBulletedListItem1, Me.ToggleNumberingListItem1, Me.ToggleMultiLevelListItem1, Me.DecreaseIndentItem1, Me.IncreaseIndentItem1, Me.ToggleParagraphAlignmentLeftItem1, Me.ToggleParagraphAlignmentCenterItem1, Me.ToggleParagraphAlignmentRightItem1, Me.ToggleParagraphAlignmentJustifyItem1, Me.ToggleShowWhitespaceItem1, Me.ChangeParagraphLineSpacingItem1, Me.SetSingleParagraphSpacingItem1, Me.SetSesquialteralParagraphSpacingItem1, Me.SetDoubleParagraphSpacingItem1, Me.ShowLineSpacingFormItem1, Me.AddSpacingBeforeParagraphItem1, Me.RemoveSpacingBeforeParagraphItem1, Me.AddSpacingAfterParagraphItem1, Me.RemoveSpacingAfterParagraphItem1, Me.ChangeParagraphBackColorItem1, Me.ShowParagraphFormItem1, Me.ChangeStyleItem1, Me.ShowEditStyleFormItem1, Me.FindItem1, Me.ReplaceItem1, Me.InsertPageBreakItem1, Me.InsertTableItem1, Me.InsertPictureItem1, Me.InsertFloatingPictureItem1, Me.InsertHyperlinkItem1, Me.EditPageHeaderItem1, Me.EditPageFooterItem1, Me.InsertPageNumberItem1, Me.InsertPageCountItem1, Me.InsertTextBoxItem1, Me.InsertSymbolItem1, Me.ChangeSectionPageMarginsItem1, Me.SetNormalSectionPageMarginsItem1, Me.SetNarrowSectionPageMarginsItem1, Me.SetModerateSectionPageMarginsItem1, Me.SetWideSectionPageMarginsItem1, Me.ShowPageMarginsSetupFormItem1, Me.ChangeSectionPageOrientationItem1, Me.SetPortraitPageOrientationItem1, Me.SetLandscapePageOrientationItem1, Me.ChangeSectionPaperKindItem1, Me.ChangeSectionColumnsItem1, Me.SetSectionOneColumnItem1, Me.SetSectionTwoColumnsItem1, Me.SetSectionThreeColumnsItem1, Me.ShowColumnsSetupFormItem1, Me.InsertBreakItem1, Me.InsertColumnBreakItem1, Me.InsertSectionBreakNextPageItem1, Me.InsertSectionBreakEvenPageItem1, Me.InsertSectionBreakOddPageItem1, Me.ChangeSectionLineNumberingItem1, Me.SetSectionLineNumberingNoneItem1, Me.SetSectionLineNumberingContinuousItem1, Me.SetSectionLineNumberingRestartNewPageItem1, Me.SetSectionLineNumberingRestartNewSectionItem1, Me.ToggleParagraphSuppressLineNumbersItem1, Me.ShowLineNumberingFormItem1, Me.ChangePageColorItem1, Me.InsertTableOfContentsItem1, Me.UpdateTableOfContentsItem1, Me.AddParagraphsToTableOfContentItem1, Me.SetParagraphHeadingLevelItem1, Me.SetParagraphHeadingLevelItem2, Me.SetParagraphHeadingLevelItem3, Me.SetParagraphHeadingLevelItem4, Me.SetParagraphHeadingLevelItem5, Me.SetParagraphHeadingLevelItem6, Me.SetParagraphHeadingLevelItem7, Me.SetParagraphHeadingLevelItem8, Me.SetParagraphHeadingLevelItem9, Me.SetParagraphHeadingLevelItem10, Me.InsertCaptionPlaceholderItem1, Me.InsertFiguresCaptionItems1, Me.InsertTablesCaptionItems1, Me.InsertEquationsCaptionItems1, Me.InsertTableOfFiguresPlaceholderItem1, Me.InsertTableOfFiguresItems1, Me.InsertTableOfTablesItems1, Me.InsertTableOfEquationsItems1, Me.UpdateTableOfFiguresItem1, Me.InsertMergeFieldItem1, Me.ShowAllFieldCodesItem1, Me.ShowAllFieldResultsItem1, Me.ToggleViewMergedDataItem1, Me.CheckSpellingItem1, Me.ProtectDocumentItem1, Me.ChangeRangeEditingPermissionsItem1, Me.UnprotectDocumentItem1, Me.SwitchToSimpleViewItem1, Me.SwitchToDraftViewItem1, Me.SwitchToPrintLayoutViewItem1, Me.ToggleShowHorizontalRulerItem1, Me.ToggleShowVerticalRulerItem1, Me.ZoomOutItem1, Me.ZoomInItem1, Me.GoToPageHeaderItem1, Me.GoToPageFooterItem1, Me.GoToNextHeaderFooterItem1, Me.GoToPreviousHeaderFooterItem1, Me.ToggleLinkToPreviousItem1, Me.ToggleDifferentFirstPageItem1, Me.ToggleDifferentOddAndEvenPagesItem1, Me.ClosePageHeaderFooterItem1, Me.ChangeTableCellsShadingItem1, Me.ChangeTableBordersItem1, Me.ToggleTableCellsBottomBorderItem1, Me.ToggleTableCellsTopBorderItem1, Me.ToggleTableCellsLeftBorderItem1, Me.ToggleTableCellsRightBorderItem1, Me.ResetTableCellsAllBordersItem1, Me.ToggleTableCellsAllBordersItem1, Me.ToggleTableCellsOutsideBorderItem1, Me.ToggleTableCellsInsideBorderItem1, Me.ToggleTableCellsInsideHorizontalBorderItem1, Me.ToggleTableCellsInsideVerticalBorderItem1, Me.ToggleShowTableGridLinesItem1, Me.ChangeTableBorderLineStyleItem1, Me.ChangeTableBorderLineWeightItem1, Me.ChangeTableBorderColorItem1, Me.SelectTableElementsItem1, Me.SelectTableCellItem1, Me.SelectTableColumnItem1, Me.SelectTableRowItem1, Me.SelectTableItem1, Me.ShowTablePropertiesFormItem1, Me.DeleteTableElementsItem1, Me.ShowDeleteTableCellsFormItem1, Me.DeleteTableColumnsItem1, Me.DeleteTableRowsItem1, Me.DeleteTableItem1, Me.InsertTableRowAboveItem1, Me.InsertTableRowBelowItem1, Me.InsertTableColumnToLeftItem1, Me.InsertTableColumnToRightItem1, Me.ShowInsertTableCellsFormItem1, Me.MergeTableCellsItem1, Me.ShowSplitTableCellsForm1, Me.SplitTableItem1, Me.ToggleTableAutoFitItem1, Me.ToggleTableAutoFitContentsItem1, Me.ToggleTableAutoFitWindowItem1, Me.ToggleTableFixedColumnWidthItem1, Me.ToggleTableCellsTopLeftAlignmentItem1, Me.ToggleTableCellsMiddleLeftAlignmentItem1, Me.ToggleTableCellsBottomLeftAlignmentItem1, Me.ToggleTableCellsTopCenterAlignmentItem1, Me.ToggleTableCellsMiddleCenterAlignmentItem1, Me.ToggleTableCellsBottomCenterAlignmentItem1, Me.ToggleTableCellsTopRightAlignmentItem1, Me.ToggleTableCellsMiddleRightAlignmentItem1, Me.ToggleTableCellsBottomRightAlignmentItem1, Me.ShowTableOptionsFormItem1, Me.ChangeFloatingObjectFillColorItem1, Me.ChangeFloatingObjectOutlineColorItem1, Me.ChangeFloatingObjectOutlineWeightItem1, Me.ChangeFloatingObjectTextWrapTypeItem1, Me.SetFloatingObjectSquareTextWrapTypeItem1, Me.SetFloatingObjectTightTextWrapTypeItem1, Me.SetFloatingObjectThroughTextWrapTypeItem1, Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1, Me.SetFloatingObjectBehindTextWrapTypeItem1, Me.SetFloatingObjectInFrontOfTextWrapTypeItem1, Me.ChangeFloatingObjectAlignmentItem1, Me.SetFloatingObjectTopLeftAlignmentItem1, Me.SetFloatingObjectTopCenterAlignmentItem1, Me.SetFloatingObjectTopRightAlignmentItem1, Me.SetFloatingObjectMiddleLeftAlignmentItem1, Me.SetFloatingObjectMiddleCenterAlignmentItem1, Me.SetFloatingObjectMiddleRightAlignmentItem1, Me.SetFloatingObjectBottomLeftAlignmentItem1, Me.SetFloatingObjectBottomCenterAlignmentItem1, Me.SetFloatingObjectBottomRightAlignmentItem1, Me.FloatingObjectBringForwardSubItem1, Me.FloatingObjectBringForwardItem1, Me.FloatingObjectBringToFrontItem1, Me.FloatingObjectBringInFrontOfTextItem1, Me.FloatingObjectSendBackwardSubItem1, Me.FloatingObjectSendBackwardItem1, Me.FloatingObjectSendToBackItem1, Me.FloatingObjectSendBehindTextItem1})
            Me.BarManager1.MaxItemId = 220
            Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemFontEdit1, Me.RepositoryItemRichEditFontSizeEdit1, Me.RepositoryItemRichEditStyleEdit1, Me.RepositoryItemBorderLineStyle1, Me.RepositoryItemBorderLineWeight1, Me.RepositoryItemFloatingObjectOutlineWeight1})
            '
            'CommonBar1
            '
            Me.CommonBar1.Control = Me.RichEdit
            Me.CommonBar1.DockCol = 2
            Me.CommonBar1.DockRow = 0
            Me.CommonBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.CommonBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.UndoItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.RedoItem1)})
            Me.CommonBar1.Offset = 102
            Me.CommonBar1.OptionsBar.AllowQuickCustomization = False
            Me.CommonBar1.OptionsBar.DisableCustomization = True
            Me.CommonBar1.OptionsBar.DrawBorder = False
            '
            'UndoItem1
            '
            Me.UndoItem1.Id = 7
            Me.UndoItem1.Name = "UndoItem1"
            '
            'RedoItem1
            '
            Me.RedoItem1.Id = 8
            Me.RedoItem1.Name = "RedoItem1"
            '
            'ClipboardBar1
            '
            Me.ClipboardBar1.Control = Me.RichEdit
            Me.ClipboardBar1.DockCol = 3
            Me.ClipboardBar1.DockRow = 0
            Me.ClipboardBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.ClipboardBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.CutItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.CopyItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PasteItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PasteSpecialItem1)})
            Me.ClipboardBar1.Offset = 201
            Me.ClipboardBar1.OptionsBar.AllowQuickCustomization = False
            Me.ClipboardBar1.OptionsBar.DisableCustomization = True
            Me.ClipboardBar1.OptionsBar.DrawBorder = False
            '
            'CutItem1
            '
            Me.CutItem1.Id = 10
            Me.CutItem1.Name = "CutItem1"
            '
            'CopyItem1
            '
            Me.CopyItem1.Id = 11
            Me.CopyItem1.Name = "CopyItem1"
            '
            'PasteItem1
            '
            Me.PasteItem1.Id = 9
            Me.PasteItem1.Name = "PasteItem1"
            '
            'PasteSpecialItem1
            '
            Me.PasteSpecialItem1.Id = 12
            Me.PasteSpecialItem1.Name = "PasteSpecialItem1"
            '
            'FontBar1
            '
            Me.FontBar1.Control = Me.RichEdit
            Me.FontBar1.DockCol = 1
            Me.FontBar1.DockRow = 1
            Me.FontBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.FontBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeFontNameItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeFontSizeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontBoldItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontItalicItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontUnderlineItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontDoubleUnderlineItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontStrikeoutItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontDoubleStrikeoutItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontSuperscriptItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleFontSubscriptItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeFontColorItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeFontBackColorItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeTextCaseItem1)})
            Me.FontBar1.Offset = 199
            Me.FontBar1.OptionsBar.AllowQuickCustomization = False
            Me.FontBar1.OptionsBar.DisableCustomization = True
            Me.FontBar1.OptionsBar.DrawBorder = False
            '
            'ChangeFontNameItem1
            '
            Me.ChangeFontNameItem1.Edit = Me.RepositoryItemFontEdit1
            Me.ChangeFontNameItem1.Id = 13
            Me.ChangeFontNameItem1.Name = "ChangeFontNameItem1"
            '
            'RepositoryItemFontEdit1
            '
            Me.RepositoryItemFontEdit1.AutoHeight = False
            Me.RepositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemFontEdit1.Name = "RepositoryItemFontEdit1"
            '
            'ChangeFontSizeItem1
            '
            Me.ChangeFontSizeItem1.Edit = Me.RepositoryItemRichEditFontSizeEdit1
            Me.ChangeFontSizeItem1.Id = 14
            Me.ChangeFontSizeItem1.Name = "ChangeFontSizeItem1"
            '
            'RepositoryItemRichEditFontSizeEdit1
            '
            Me.RepositoryItemRichEditFontSizeEdit1.AutoHeight = False
            Me.RepositoryItemRichEditFontSizeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemRichEditFontSizeEdit1.Control = Me.RichEdit
            Me.RepositoryItemRichEditFontSizeEdit1.Name = "RepositoryItemRichEditFontSizeEdit1"
            '
            'FontSizeIncreaseItem1
            '
            Me.FontSizeIncreaseItem1.Id = 15
            Me.FontSizeIncreaseItem1.Name = "FontSizeIncreaseItem1"
            '
            'FontSizeDecreaseItem1
            '
            Me.FontSizeDecreaseItem1.Id = 16
            Me.FontSizeDecreaseItem1.Name = "FontSizeDecreaseItem1"
            '
            'ToggleFontBoldItem1
            '
            Me.ToggleFontBoldItem1.Id = 17
            Me.ToggleFontBoldItem1.Name = "ToggleFontBoldItem1"
            '
            'ToggleFontItalicItem1
            '
            Me.ToggleFontItalicItem1.Id = 18
            Me.ToggleFontItalicItem1.Name = "ToggleFontItalicItem1"
            '
            'ToggleFontUnderlineItem1
            '
            Me.ToggleFontUnderlineItem1.Id = 19
            Me.ToggleFontUnderlineItem1.Name = "ToggleFontUnderlineItem1"
            '
            'ToggleFontDoubleUnderlineItem1
            '
            Me.ToggleFontDoubleUnderlineItem1.Id = 20
            Me.ToggleFontDoubleUnderlineItem1.Name = "ToggleFontDoubleUnderlineItem1"
            '
            'ToggleFontStrikeoutItem1
            '
            Me.ToggleFontStrikeoutItem1.Id = 21
            Me.ToggleFontStrikeoutItem1.Name = "ToggleFontStrikeoutItem1"
            '
            'ToggleFontDoubleStrikeoutItem1
            '
            Me.ToggleFontDoubleStrikeoutItem1.Id = 22
            Me.ToggleFontDoubleStrikeoutItem1.Name = "ToggleFontDoubleStrikeoutItem1"
            '
            'ToggleFontSuperscriptItem1
            '
            Me.ToggleFontSuperscriptItem1.Id = 23
            Me.ToggleFontSuperscriptItem1.Name = "ToggleFontSuperscriptItem1"
            '
            'ToggleFontSubscriptItem1
            '
            Me.ToggleFontSubscriptItem1.Id = 24
            Me.ToggleFontSubscriptItem1.Name = "ToggleFontSubscriptItem1"
            '
            'ChangeFontColorItem1
            '
            Me.ChangeFontColorItem1.Id = 25
            Me.ChangeFontColorItem1.Name = "ChangeFontColorItem1"
            '
            'ChangeFontBackColorItem1
            '
            Me.ChangeFontBackColorItem1.Id = 26
            Me.ChangeFontBackColorItem1.Name = "ChangeFontBackColorItem1"
            '
            'ChangeTextCaseItem1
            '
            Me.ChangeTextCaseItem1.Id = 27
            Me.ChangeTextCaseItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MakeTextUpperCaseItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.MakeTextLowerCaseItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTextCaseItem1)})
            Me.ChangeTextCaseItem1.Name = "ChangeTextCaseItem1"
            '
            'MakeTextUpperCaseItem1
            '
            Me.MakeTextUpperCaseItem1.Id = 28
            Me.MakeTextUpperCaseItem1.Name = "MakeTextUpperCaseItem1"
            '
            'MakeTextLowerCaseItem1
            '
            Me.MakeTextLowerCaseItem1.Id = 29
            Me.MakeTextLowerCaseItem1.Name = "MakeTextLowerCaseItem1"
            '
            'ToggleTextCaseItem1
            '
            Me.ToggleTextCaseItem1.Id = 30
            Me.ToggleTextCaseItem1.Name = "ToggleTextCaseItem1"
            '
            'ClearFormattingItem1
            '
            Me.ClearFormattingItem1.Id = 31
            Me.ClearFormattingItem1.Name = "ClearFormattingItem1"
            '
            'ParagraphBar1
            '
            Me.ParagraphBar1.Control = Me.RichEdit
            Me.ParagraphBar1.DockCol = 6
            Me.ParagraphBar1.DockRow = 0
            Me.ParagraphBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.ParagraphBar1.FloatLocation = New System.Drawing.Point(-843, 137)
            Me.ParagraphBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleBulletedListItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleNumberingListItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleMultiLevelListItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.DecreaseIndentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.IncreaseIndentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphAlignmentLeftItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphAlignmentCenterItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphAlignmentRightItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphAlignmentJustifyItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleShowWhitespaceItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowParagraphFormItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeParagraphLineSpacingItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeParagraphBackColorItem1)})
            Me.ParagraphBar1.Offset = 436
            Me.ParagraphBar1.OptionsBar.AllowQuickCustomization = False
            Me.ParagraphBar1.OptionsBar.DisableCustomization = True
            Me.ParagraphBar1.OptionsBar.DrawBorder = False
            '
            'ToggleBulletedListItem1
            '
            Me.ToggleBulletedListItem1.Id = 33
            Me.ToggleBulletedListItem1.Name = "ToggleBulletedListItem1"
            '
            'ToggleNumberingListItem1
            '
            Me.ToggleNumberingListItem1.Id = 34
            Me.ToggleNumberingListItem1.Name = "ToggleNumberingListItem1"
            '
            'ToggleMultiLevelListItem1
            '
            Me.ToggleMultiLevelListItem1.Id = 35
            Me.ToggleMultiLevelListItem1.Name = "ToggleMultiLevelListItem1"
            '
            'DecreaseIndentItem1
            '
            Me.DecreaseIndentItem1.Id = 36
            Me.DecreaseIndentItem1.Name = "DecreaseIndentItem1"
            '
            'IncreaseIndentItem1
            '
            Me.IncreaseIndentItem1.Id = 37
            Me.IncreaseIndentItem1.Name = "IncreaseIndentItem1"
            '
            'ToggleParagraphAlignmentLeftItem1
            '
            Me.ToggleParagraphAlignmentLeftItem1.Id = 38
            Me.ToggleParagraphAlignmentLeftItem1.Name = "ToggleParagraphAlignmentLeftItem1"
            '
            'ToggleParagraphAlignmentCenterItem1
            '
            Me.ToggleParagraphAlignmentCenterItem1.Id = 39
            Me.ToggleParagraphAlignmentCenterItem1.Name = "ToggleParagraphAlignmentCenterItem1"
            '
            'ToggleParagraphAlignmentRightItem1
            '
            Me.ToggleParagraphAlignmentRightItem1.Id = 40
            Me.ToggleParagraphAlignmentRightItem1.Name = "ToggleParagraphAlignmentRightItem1"
            '
            'ToggleParagraphAlignmentJustifyItem1
            '
            Me.ToggleParagraphAlignmentJustifyItem1.Id = 41
            Me.ToggleParagraphAlignmentJustifyItem1.Name = "ToggleParagraphAlignmentJustifyItem1"
            '
            'ToggleShowWhitespaceItem1
            '
            Me.ToggleShowWhitespaceItem1.Id = 42
            Me.ToggleShowWhitespaceItem1.Name = "ToggleShowWhitespaceItem1"
            '
            'ShowParagraphFormItem1
            '
            Me.ShowParagraphFormItem1.Id = 53
            Me.ShowParagraphFormItem1.Name = "ShowParagraphFormItem1"
            '
            'ChangeParagraphLineSpacingItem1
            '
            Me.ChangeParagraphLineSpacingItem1.Id = 43
            Me.ChangeParagraphLineSpacingItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetSingleParagraphSpacingItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSesquialteralParagraphSpacingItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetDoubleParagraphSpacingItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowLineSpacingFormItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.AddSpacingBeforeParagraphItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.RemoveSpacingBeforeParagraphItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.AddSpacingAfterParagraphItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.RemoveSpacingAfterParagraphItem1)})
            Me.ChangeParagraphLineSpacingItem1.Name = "ChangeParagraphLineSpacingItem1"
            '
            'SetSingleParagraphSpacingItem1
            '
            Me.SetSingleParagraphSpacingItem1.Id = 44
            Me.SetSingleParagraphSpacingItem1.Name = "SetSingleParagraphSpacingItem1"
            '
            'SetSesquialteralParagraphSpacingItem1
            '
            Me.SetSesquialteralParagraphSpacingItem1.Id = 45
            Me.SetSesquialteralParagraphSpacingItem1.Name = "SetSesquialteralParagraphSpacingItem1"
            '
            'SetDoubleParagraphSpacingItem1
            '
            Me.SetDoubleParagraphSpacingItem1.Id = 46
            Me.SetDoubleParagraphSpacingItem1.Name = "SetDoubleParagraphSpacingItem1"
            '
            'ShowLineSpacingFormItem1
            '
            Me.ShowLineSpacingFormItem1.Id = 47
            Me.ShowLineSpacingFormItem1.Name = "ShowLineSpacingFormItem1"
            '
            'AddSpacingBeforeParagraphItem1
            '
            Me.AddSpacingBeforeParagraphItem1.Id = 48
            Me.AddSpacingBeforeParagraphItem1.Name = "AddSpacingBeforeParagraphItem1"
            '
            'RemoveSpacingBeforeParagraphItem1
            '
            Me.RemoveSpacingBeforeParagraphItem1.Id = 49
            Me.RemoveSpacingBeforeParagraphItem1.Name = "RemoveSpacingBeforeParagraphItem1"
            '
            'AddSpacingAfterParagraphItem1
            '
            Me.AddSpacingAfterParagraphItem1.Id = 50
            Me.AddSpacingAfterParagraphItem1.Name = "AddSpacingAfterParagraphItem1"
            '
            'RemoveSpacingAfterParagraphItem1
            '
            Me.RemoveSpacingAfterParagraphItem1.Id = 51
            Me.RemoveSpacingAfterParagraphItem1.Name = "RemoveSpacingAfterParagraphItem1"
            '
            'ChangeParagraphBackColorItem1
            '
            Me.ChangeParagraphBackColorItem1.Id = 52
            Me.ChangeParagraphBackColorItem1.Name = "ChangeParagraphBackColorItem1"
            '
            'StylesBar1
            '
            Me.StylesBar1.Control = Me.RichEdit
            Me.StylesBar1.DockCol = 0
            Me.StylesBar1.DockRow = 1
            Me.StylesBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.StylesBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ChangeStyleItem1)})
            Me.StylesBar1.OptionsBar.AllowQuickCustomization = False
            Me.StylesBar1.OptionsBar.DisableCustomization = True
            Me.StylesBar1.OptionsBar.DrawBorder = False
            '
            'ChangeStyleItem1
            '
            Me.ChangeStyleItem1.Edit = Me.RepositoryItemRichEditStyleEdit1
            Me.ChangeStyleItem1.Id = 54
            Me.ChangeStyleItem1.Name = "ChangeStyleItem1"
            '
            'RepositoryItemRichEditStyleEdit1
            '
            Me.RepositoryItemRichEditStyleEdit1.AutoHeight = False
            Me.RepositoryItemRichEditStyleEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemRichEditStyleEdit1.Control = Me.RichEdit
            Me.RepositoryItemRichEditStyleEdit1.Name = "RepositoryItemRichEditStyleEdit1"
            '
            'ShowEditStyleFormItem1
            '
            Me.ShowEditStyleFormItem1.Id = 55
            Me.ShowEditStyleFormItem1.Name = "ShowEditStyleFormItem1"
            Me.ShowEditStyleFormItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            '
            'EditingBar1
            '
            Me.EditingBar1.Control = Me.RichEdit
            Me.EditingBar1.DockCol = 1
            Me.EditingBar1.DockRow = 0
            Me.EditingBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.EditingBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FindItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ReplaceItem1)})
            Me.EditingBar1.Offset = 24
            Me.EditingBar1.OptionsBar.AllowQuickCustomization = False
            Me.EditingBar1.OptionsBar.DrawBorder = False
            '
            'FindItem1
            '
            Me.FindItem1.Id = 56
            Me.FindItem1.Name = "FindItem1"
            '
            'ReplaceItem1
            '
            Me.ReplaceItem1.Id = 57
            Me.ReplaceItem1.Name = "ReplaceItem1"
            '
            'LinksBar1
            '
            Me.LinksBar1.Control = Me.RichEdit
            Me.LinksBar1.DockCol = 4
            Me.LinksBar1.DockRow = 0
            Me.LinksBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.LinksBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InsertHyperlinkItem1)})
            Me.LinksBar1.Offset = 330
            Me.LinksBar1.OptionsBar.AllowQuickCustomization = False
            Me.LinksBar1.OptionsBar.DisableCustomization = True
            Me.LinksBar1.OptionsBar.DrawBorder = False
            '
            'InsertHyperlinkItem1
            '
            Me.InsertHyperlinkItem1.Id = 63
            Me.InsertHyperlinkItem1.Name = "InsertHyperlinkItem1"
            '
            'SymbolsBar1
            '
            Me.SymbolsBar1.BarName = ""
            Me.SymbolsBar1.Control = Me.RichEdit
            Me.SymbolsBar1.DockCol = 5
            Me.SymbolsBar1.DockRow = 0
            Me.SymbolsBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.SymbolsBar1.Offset = 361
            Me.SymbolsBar1.OptionsBar.AllowQuickCustomization = False
            Me.SymbolsBar1.OptionsBar.DrawBorder = False
            Me.SymbolsBar1.Text = ""
            '
            'DocumentProofingBar1
            '
            Me.DocumentProofingBar1.Control = Me.RichEdit
            Me.DocumentProofingBar1.DockCol = 0
            Me.DocumentProofingBar1.DockRow = 0
            Me.DocumentProofingBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.DocumentProofingBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.CheckSpellingItem1)})
            Me.DocumentProofingBar1.OptionsBar.AllowQuickCustomization = False
            Me.DocumentProofingBar1.OptionsBar.DisableCustomization = True
            Me.DocumentProofingBar1.OptionsBar.DrawBorder = False
            '
            'CheckSpellingItem1
            '
            Me.CheckSpellingItem1.Id = 124
            Me.CheckSpellingItem1.Name = "CheckSpellingItem1"
            '
            'barDockControlTop
            '
            Me.barDockControlTop.CausesValidation = False
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Manager = Me.BarManager1
            Me.barDockControlTop.Size = New System.Drawing.Size(1045, 62)
            '
            'barDockControlBottom
            '
            Me.barDockControlBottom.CausesValidation = False
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 388)
            Me.barDockControlBottom.Manager = Me.BarManager1
            Me.barDockControlBottom.Size = New System.Drawing.Size(1045, 0)
            '
            'barDockControlLeft
            '
            Me.barDockControlLeft.CausesValidation = False
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 62)
            Me.barDockControlLeft.Manager = Me.BarManager1
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 326)
            '
            'barDockControlRight
            '
            Me.barDockControlRight.CausesValidation = False
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(1045, 62)
            Me.barDockControlRight.Manager = Me.BarManager1
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 326)
            '
            'ShowFontFormItem1
            '
            Me.ShowFontFormItem1.Id = 32
            Me.ShowFontFormItem1.Name = "ShowFontFormItem1"
            '
            'InsertPageBreakItem1
            '
            Me.InsertPageBreakItem1.Id = 58
            Me.InsertPageBreakItem1.Name = "InsertPageBreakItem1"
            '
            'InsertTableItem1
            '
            Me.InsertTableItem1.Id = 59
            Me.InsertTableItem1.Name = "InsertTableItem1"
            '
            'InsertPictureItem1
            '
            Me.InsertPictureItem1.Id = 60
            Me.InsertPictureItem1.Name = "InsertPictureItem1"
            '
            'InsertFloatingPictureItem1
            '
            Me.InsertFloatingPictureItem1.Id = 61
            Me.InsertFloatingPictureItem1.Name = "InsertFloatingPictureItem1"
            '
            'EditPageHeaderItem1
            '
            Me.EditPageHeaderItem1.Id = 64
            Me.EditPageHeaderItem1.Name = "EditPageHeaderItem1"
            '
            'EditPageFooterItem1
            '
            Me.EditPageFooterItem1.Id = 65
            Me.EditPageFooterItem1.Name = "EditPageFooterItem1"
            '
            'InsertPageNumberItem1
            '
            Me.InsertPageNumberItem1.Id = 66
            Me.InsertPageNumberItem1.Name = "InsertPageNumberItem1"
            '
            'InsertPageCountItem1
            '
            Me.InsertPageCountItem1.Id = 67
            Me.InsertPageCountItem1.Name = "InsertPageCountItem1"
            '
            'InsertTextBoxItem1
            '
            Me.InsertTextBoxItem1.Id = 68
            Me.InsertTextBoxItem1.Name = "InsertTextBoxItem1"
            '
            'InsertSymbolItem1
            '
            Me.InsertSymbolItem1.Id = 69
            Me.InsertSymbolItem1.Name = "InsertSymbolItem1"
            '
            'ChangeSectionPageMarginsItem1
            '
            Me.ChangeSectionPageMarginsItem1.Id = 70
            Me.ChangeSectionPageMarginsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetNormalSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetNarrowSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetModerateSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetWideSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowPageMarginsSetupFormItem1)})
            Me.ChangeSectionPageMarginsItem1.Name = "ChangeSectionPageMarginsItem1"
            '
            'SetNormalSectionPageMarginsItem1
            '
            Me.SetNormalSectionPageMarginsItem1.Id = 71
            Me.SetNormalSectionPageMarginsItem1.Name = "SetNormalSectionPageMarginsItem1"
            '
            'SetNarrowSectionPageMarginsItem1
            '
            Me.SetNarrowSectionPageMarginsItem1.Id = 72
            Me.SetNarrowSectionPageMarginsItem1.Name = "SetNarrowSectionPageMarginsItem1"
            '
            'SetModerateSectionPageMarginsItem1
            '
            Me.SetModerateSectionPageMarginsItem1.Id = 73
            Me.SetModerateSectionPageMarginsItem1.Name = "SetModerateSectionPageMarginsItem1"
            '
            'SetWideSectionPageMarginsItem1
            '
            Me.SetWideSectionPageMarginsItem1.Id = 74
            Me.SetWideSectionPageMarginsItem1.Name = "SetWideSectionPageMarginsItem1"
            '
            'ShowPageMarginsSetupFormItem1
            '
            Me.ShowPageMarginsSetupFormItem1.Id = 75
            Me.ShowPageMarginsSetupFormItem1.Name = "ShowPageMarginsSetupFormItem1"
            '
            'ChangeSectionPageOrientationItem1
            '
            Me.ChangeSectionPageOrientationItem1.Id = 76
            Me.ChangeSectionPageOrientationItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetPortraitPageOrientationItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetLandscapePageOrientationItem1)})
            Me.ChangeSectionPageOrientationItem1.Name = "ChangeSectionPageOrientationItem1"
            '
            'SetPortraitPageOrientationItem1
            '
            Me.SetPortraitPageOrientationItem1.Id = 77
            Me.SetPortraitPageOrientationItem1.Name = "SetPortraitPageOrientationItem1"
            '
            'SetLandscapePageOrientationItem1
            '
            Me.SetLandscapePageOrientationItem1.Id = 78
            Me.SetLandscapePageOrientationItem1.Name = "SetLandscapePageOrientationItem1"
            '
            'ChangeSectionPaperKindItem1
            '
            Me.ChangeSectionPaperKindItem1.Id = 79
            Me.ChangeSectionPaperKindItem1.Name = "ChangeSectionPaperKindItem1"
            '
            'ChangeSectionColumnsItem1
            '
            Me.ChangeSectionColumnsItem1.Id = 80
            Me.ChangeSectionColumnsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionOneColumnItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionTwoColumnsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionThreeColumnsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowColumnsSetupFormItem1)})
            Me.ChangeSectionColumnsItem1.Name = "ChangeSectionColumnsItem1"
            '
            'SetSectionOneColumnItem1
            '
            Me.SetSectionOneColumnItem1.Id = 81
            Me.SetSectionOneColumnItem1.Name = "SetSectionOneColumnItem1"
            '
            'SetSectionTwoColumnsItem1
            '
            Me.SetSectionTwoColumnsItem1.Id = 82
            Me.SetSectionTwoColumnsItem1.Name = "SetSectionTwoColumnsItem1"
            '
            'SetSectionThreeColumnsItem1
            '
            Me.SetSectionThreeColumnsItem1.Id = 83
            Me.SetSectionThreeColumnsItem1.Name = "SetSectionThreeColumnsItem1"
            '
            'ShowColumnsSetupFormItem1
            '
            Me.ShowColumnsSetupFormItem1.Id = 84
            Me.ShowColumnsSetupFormItem1.Name = "ShowColumnsSetupFormItem1"
            '
            'InsertBreakItem1
            '
            Me.InsertBreakItem1.Id = 85
            Me.InsertBreakItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InsertPageBreakItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertColumnBreakItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakNextPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakEvenPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakOddPageItem1)})
            Me.InsertBreakItem1.Name = "InsertBreakItem1"
            '
            'InsertColumnBreakItem1
            '
            Me.InsertColumnBreakItem1.Id = 86
            Me.InsertColumnBreakItem1.Name = "InsertColumnBreakItem1"
            '
            'InsertSectionBreakNextPageItem1
            '
            Me.InsertSectionBreakNextPageItem1.Id = 87
            Me.InsertSectionBreakNextPageItem1.Name = "InsertSectionBreakNextPageItem1"
            '
            'InsertSectionBreakEvenPageItem1
            '
            Me.InsertSectionBreakEvenPageItem1.Id = 88
            Me.InsertSectionBreakEvenPageItem1.Name = "InsertSectionBreakEvenPageItem1"
            '
            'InsertSectionBreakOddPageItem1
            '
            Me.InsertSectionBreakOddPageItem1.Id = 89
            Me.InsertSectionBreakOddPageItem1.Name = "InsertSectionBreakOddPageItem1"
            '
            'ChangeSectionLineNumberingItem1
            '
            Me.ChangeSectionLineNumberingItem1.Id = 90
            Me.ChangeSectionLineNumberingItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingNoneItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingContinuousItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingRestartNewPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingRestartNewSectionItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphSuppressLineNumbersItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowLineNumberingFormItem1)})
            Me.ChangeSectionLineNumberingItem1.Name = "ChangeSectionLineNumberingItem1"
            '
            'SetSectionLineNumberingNoneItem1
            '
            Me.SetSectionLineNumberingNoneItem1.Id = 91
            Me.SetSectionLineNumberingNoneItem1.Name = "SetSectionLineNumberingNoneItem1"
            '
            'SetSectionLineNumberingContinuousItem1
            '
            Me.SetSectionLineNumberingContinuousItem1.Id = 92
            Me.SetSectionLineNumberingContinuousItem1.Name = "SetSectionLineNumberingContinuousItem1"
            '
            'SetSectionLineNumberingRestartNewPageItem1
            '
            Me.SetSectionLineNumberingRestartNewPageItem1.Id = 93
            Me.SetSectionLineNumberingRestartNewPageItem1.Name = "SetSectionLineNumberingRestartNewPageItem1"
            '
            'SetSectionLineNumberingRestartNewSectionItem1
            '
            Me.SetSectionLineNumberingRestartNewSectionItem1.Id = 94
            Me.SetSectionLineNumberingRestartNewSectionItem1.Name = "SetSectionLineNumberingRestartNewSectionItem1"
            '
            'ToggleParagraphSuppressLineNumbersItem1
            '
            Me.ToggleParagraphSuppressLineNumbersItem1.Id = 95
            Me.ToggleParagraphSuppressLineNumbersItem1.Name = "ToggleParagraphSuppressLineNumbersItem1"
            '
            'ShowLineNumberingFormItem1
            '
            Me.ShowLineNumberingFormItem1.Id = 96
            Me.ShowLineNumberingFormItem1.Name = "ShowLineNumberingFormItem1"
            '
            'ChangePageColorItem1
            '
            Me.ChangePageColorItem1.Id = 97
            Me.ChangePageColorItem1.Name = "ChangePageColorItem1"
            '
            'InsertTableOfContentsItem1
            '
            Me.InsertTableOfContentsItem1.Id = 98
            Me.InsertTableOfContentsItem1.Name = "InsertTableOfContentsItem1"
            '
            'UpdateTableOfContentsItem1
            '
            Me.UpdateTableOfContentsItem1.Id = 99
            Me.UpdateTableOfContentsItem1.Name = "UpdateTableOfContentsItem1"
            '
            'AddParagraphsToTableOfContentItem1
            '
            Me.AddParagraphsToTableOfContentItem1.Id = 100
            Me.AddParagraphsToTableOfContentItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem5), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem6), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem7), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem8), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem9), New DevExpress.XtraBars.LinkPersistInfo(Me.SetParagraphHeadingLevelItem10)})
            Me.AddParagraphsToTableOfContentItem1.Name = "AddParagraphsToTableOfContentItem1"
            '
            'SetParagraphHeadingLevelItem1
            '
            Me.SetParagraphHeadingLevelItem1.Id = 101
            Me.SetParagraphHeadingLevelItem1.Name = "SetParagraphHeadingLevelItem1"
            Me.SetParagraphHeadingLevelItem1.OutlineLevel = 0
            '
            'SetParagraphHeadingLevelItem2
            '
            Me.SetParagraphHeadingLevelItem2.Id = 102
            Me.SetParagraphHeadingLevelItem2.Name = "SetParagraphHeadingLevelItem2"
            Me.SetParagraphHeadingLevelItem2.OutlineLevel = 1
            '
            'SetParagraphHeadingLevelItem3
            '
            Me.SetParagraphHeadingLevelItem3.Id = 103
            Me.SetParagraphHeadingLevelItem3.Name = "SetParagraphHeadingLevelItem3"
            Me.SetParagraphHeadingLevelItem3.OutlineLevel = 2
            '
            'SetParagraphHeadingLevelItem4
            '
            Me.SetParagraphHeadingLevelItem4.Id = 104
            Me.SetParagraphHeadingLevelItem4.Name = "SetParagraphHeadingLevelItem4"
            Me.SetParagraphHeadingLevelItem4.OutlineLevel = 3
            '
            'SetParagraphHeadingLevelItem5
            '
            Me.SetParagraphHeadingLevelItem5.Id = 105
            Me.SetParagraphHeadingLevelItem5.Name = "SetParagraphHeadingLevelItem5"
            Me.SetParagraphHeadingLevelItem5.OutlineLevel = 4
            '
            'SetParagraphHeadingLevelItem6
            '
            Me.SetParagraphHeadingLevelItem6.Id = 106
            Me.SetParagraphHeadingLevelItem6.Name = "SetParagraphHeadingLevelItem6"
            Me.SetParagraphHeadingLevelItem6.OutlineLevel = 5
            '
            'SetParagraphHeadingLevelItem7
            '
            Me.SetParagraphHeadingLevelItem7.Id = 107
            Me.SetParagraphHeadingLevelItem7.Name = "SetParagraphHeadingLevelItem7"
            Me.SetParagraphHeadingLevelItem7.OutlineLevel = 6
            '
            'SetParagraphHeadingLevelItem8
            '
            Me.SetParagraphHeadingLevelItem8.Id = 108
            Me.SetParagraphHeadingLevelItem8.Name = "SetParagraphHeadingLevelItem8"
            Me.SetParagraphHeadingLevelItem8.OutlineLevel = 7
            '
            'SetParagraphHeadingLevelItem9
            '
            Me.SetParagraphHeadingLevelItem9.Id = 109
            Me.SetParagraphHeadingLevelItem9.Name = "SetParagraphHeadingLevelItem9"
            Me.SetParagraphHeadingLevelItem9.OutlineLevel = 8
            '
            'SetParagraphHeadingLevelItem10
            '
            Me.SetParagraphHeadingLevelItem10.Id = 110
            Me.SetParagraphHeadingLevelItem10.Name = "SetParagraphHeadingLevelItem10"
            Me.SetParagraphHeadingLevelItem10.OutlineLevel = 9
            '
            'InsertCaptionPlaceholderItem1
            '
            Me.InsertCaptionPlaceholderItem1.Id = 111
            Me.InsertCaptionPlaceholderItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InsertFiguresCaptionItems1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertTablesCaptionItems1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertEquationsCaptionItems1)})
            Me.InsertCaptionPlaceholderItem1.Name = "InsertCaptionPlaceholderItem1"
            '
            'InsertFiguresCaptionItems1
            '
            Me.InsertFiguresCaptionItems1.Id = 112
            Me.InsertFiguresCaptionItems1.Name = "InsertFiguresCaptionItems1"
            '
            'InsertTablesCaptionItems1
            '
            Me.InsertTablesCaptionItems1.Id = 113
            Me.InsertTablesCaptionItems1.Name = "InsertTablesCaptionItems1"
            '
            'InsertEquationsCaptionItems1
            '
            Me.InsertEquationsCaptionItems1.Id = 114
            Me.InsertEquationsCaptionItems1.Name = "InsertEquationsCaptionItems1"
            '
            'InsertTableOfFiguresPlaceholderItem1
            '
            Me.InsertTableOfFiguresPlaceholderItem1.Id = 115
            Me.InsertTableOfFiguresPlaceholderItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InsertTableOfFiguresItems1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertTableOfTablesItems1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertTableOfEquationsItems1)})
            Me.InsertTableOfFiguresPlaceholderItem1.Name = "InsertTableOfFiguresPlaceholderItem1"
            '
            'InsertTableOfFiguresItems1
            '
            Me.InsertTableOfFiguresItems1.Id = 116
            Me.InsertTableOfFiguresItems1.Name = "InsertTableOfFiguresItems1"
            '
            'InsertTableOfTablesItems1
            '
            Me.InsertTableOfTablesItems1.Id = 117
            Me.InsertTableOfTablesItems1.Name = "InsertTableOfTablesItems1"
            '
            'InsertTableOfEquationsItems1
            '
            Me.InsertTableOfEquationsItems1.Id = 118
            Me.InsertTableOfEquationsItems1.Name = "InsertTableOfEquationsItems1"
            '
            'UpdateTableOfFiguresItem1
            '
            Me.UpdateTableOfFiguresItem1.Id = 119
            Me.UpdateTableOfFiguresItem1.Name = "UpdateTableOfFiguresItem1"
            '
            'InsertMergeFieldItem1
            '
            Me.InsertMergeFieldItem1.Id = 120
            Me.InsertMergeFieldItem1.Name = "InsertMergeFieldItem1"
            '
            'ShowAllFieldCodesItem1
            '
            Me.ShowAllFieldCodesItem1.Id = 121
            Me.ShowAllFieldCodesItem1.Name = "ShowAllFieldCodesItem1"
            '
            'ShowAllFieldResultsItem1
            '
            Me.ShowAllFieldResultsItem1.Id = 122
            Me.ShowAllFieldResultsItem1.Name = "ShowAllFieldResultsItem1"
            '
            'ToggleViewMergedDataItem1
            '
            Me.ToggleViewMergedDataItem1.Id = 123
            Me.ToggleViewMergedDataItem1.Name = "ToggleViewMergedDataItem1"
            '
            'ProtectDocumentItem1
            '
            Me.ProtectDocumentItem1.Id = 125
            Me.ProtectDocumentItem1.Name = "ProtectDocumentItem1"
            '
            'ChangeRangeEditingPermissionsItem1
            '
            Me.ChangeRangeEditingPermissionsItem1.Id = 126
            Me.ChangeRangeEditingPermissionsItem1.Name = "ChangeRangeEditingPermissionsItem1"
            '
            'UnprotectDocumentItem1
            '
            Me.UnprotectDocumentItem1.Id = 127
            Me.UnprotectDocumentItem1.Name = "UnprotectDocumentItem1"
            '
            'SwitchToSimpleViewItem1
            '
            Me.SwitchToSimpleViewItem1.Id = 128
            Me.SwitchToSimpleViewItem1.Name = "SwitchToSimpleViewItem1"
            '
            'SwitchToDraftViewItem1
            '
            Me.SwitchToDraftViewItem1.Id = 129
            Me.SwitchToDraftViewItem1.Name = "SwitchToDraftViewItem1"
            '
            'SwitchToPrintLayoutViewItem1
            '
            Me.SwitchToPrintLayoutViewItem1.Id = 130
            Me.SwitchToPrintLayoutViewItem1.Name = "SwitchToPrintLayoutViewItem1"
            '
            'ToggleShowHorizontalRulerItem1
            '
            Me.ToggleShowHorizontalRulerItem1.Id = 131
            Me.ToggleShowHorizontalRulerItem1.Name = "ToggleShowHorizontalRulerItem1"
            '
            'ToggleShowVerticalRulerItem1
            '
            Me.ToggleShowVerticalRulerItem1.Id = 132
            Me.ToggleShowVerticalRulerItem1.Name = "ToggleShowVerticalRulerItem1"
            '
            'ZoomOutItem1
            '
            Me.ZoomOutItem1.Id = 133
            Me.ZoomOutItem1.Name = "ZoomOutItem1"
            '
            'ZoomInItem1
            '
            Me.ZoomInItem1.Id = 134
            Me.ZoomInItem1.Name = "ZoomInItem1"
            '
            'GoToPageHeaderItem1
            '
            Me.GoToPageHeaderItem1.Id = 135
            Me.GoToPageHeaderItem1.Name = "GoToPageHeaderItem1"
            '
            'GoToPageFooterItem1
            '
            Me.GoToPageFooterItem1.Id = 136
            Me.GoToPageFooterItem1.Name = "GoToPageFooterItem1"
            '
            'GoToNextHeaderFooterItem1
            '
            Me.GoToNextHeaderFooterItem1.Id = 137
            Me.GoToNextHeaderFooterItem1.Name = "GoToNextHeaderFooterItem1"
            '
            'GoToPreviousHeaderFooterItem1
            '
            Me.GoToPreviousHeaderFooterItem1.Id = 138
            Me.GoToPreviousHeaderFooterItem1.Name = "GoToPreviousHeaderFooterItem1"
            '
            'ToggleLinkToPreviousItem1
            '
            Me.ToggleLinkToPreviousItem1.Id = 139
            Me.ToggleLinkToPreviousItem1.Name = "ToggleLinkToPreviousItem1"
            '
            'ToggleDifferentFirstPageItem1
            '
            Me.ToggleDifferentFirstPageItem1.Id = 140
            Me.ToggleDifferentFirstPageItem1.Name = "ToggleDifferentFirstPageItem1"
            '
            'ToggleDifferentOddAndEvenPagesItem1
            '
            Me.ToggleDifferentOddAndEvenPagesItem1.Id = 141
            Me.ToggleDifferentOddAndEvenPagesItem1.Name = "ToggleDifferentOddAndEvenPagesItem1"
            '
            'ClosePageHeaderFooterItem1
            '
            Me.ClosePageHeaderFooterItem1.Id = 142
            Me.ClosePageHeaderFooterItem1.Name = "ClosePageHeaderFooterItem1"
            '
            'ChangeTableCellsShadingItem1
            '
            Me.ChangeTableCellsShadingItem1.Id = 143
            Me.ChangeTableCellsShadingItem1.Name = "ChangeTableCellsShadingItem1"
            '
            'ChangeTableBordersItem1
            '
            Me.ChangeTableBordersItem1.Id = 144
            Me.ChangeTableBordersItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsBottomBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsTopBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsLeftBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsRightBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ResetTableCellsAllBordersItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsAllBordersItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsOutsideBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsInsideBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsInsideHorizontalBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableCellsInsideVerticalBorderItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleShowTableGridLinesItem1)})
            Me.ChangeTableBordersItem1.Name = "ChangeTableBordersItem1"
            '
            'ToggleTableCellsBottomBorderItem1
            '
            Me.ToggleTableCellsBottomBorderItem1.Id = 145
            Me.ToggleTableCellsBottomBorderItem1.Name = "ToggleTableCellsBottomBorderItem1"
            '
            'ToggleTableCellsTopBorderItem1
            '
            Me.ToggleTableCellsTopBorderItem1.Id = 146
            Me.ToggleTableCellsTopBorderItem1.Name = "ToggleTableCellsTopBorderItem1"
            '
            'ToggleTableCellsLeftBorderItem1
            '
            Me.ToggleTableCellsLeftBorderItem1.Id = 147
            Me.ToggleTableCellsLeftBorderItem1.Name = "ToggleTableCellsLeftBorderItem1"
            '
            'ToggleTableCellsRightBorderItem1
            '
            Me.ToggleTableCellsRightBorderItem1.Id = 148
            Me.ToggleTableCellsRightBorderItem1.Name = "ToggleTableCellsRightBorderItem1"
            '
            'ResetTableCellsAllBordersItem1
            '
            Me.ResetTableCellsAllBordersItem1.Id = 149
            Me.ResetTableCellsAllBordersItem1.Name = "ResetTableCellsAllBordersItem1"
            '
            'ToggleTableCellsAllBordersItem1
            '
            Me.ToggleTableCellsAllBordersItem1.Id = 150
            Me.ToggleTableCellsAllBordersItem1.Name = "ToggleTableCellsAllBordersItem1"
            '
            'ToggleTableCellsOutsideBorderItem1
            '
            Me.ToggleTableCellsOutsideBorderItem1.Id = 151
            Me.ToggleTableCellsOutsideBorderItem1.Name = "ToggleTableCellsOutsideBorderItem1"
            '
            'ToggleTableCellsInsideBorderItem1
            '
            Me.ToggleTableCellsInsideBorderItem1.Id = 152
            Me.ToggleTableCellsInsideBorderItem1.Name = "ToggleTableCellsInsideBorderItem1"
            '
            'ToggleTableCellsInsideHorizontalBorderItem1
            '
            Me.ToggleTableCellsInsideHorizontalBorderItem1.Id = 153
            Me.ToggleTableCellsInsideHorizontalBorderItem1.Name = "ToggleTableCellsInsideHorizontalBorderItem1"
            '
            'ToggleTableCellsInsideVerticalBorderItem1
            '
            Me.ToggleTableCellsInsideVerticalBorderItem1.Id = 154
            Me.ToggleTableCellsInsideVerticalBorderItem1.Name = "ToggleTableCellsInsideVerticalBorderItem1"
            '
            'ToggleShowTableGridLinesItem1
            '
            Me.ToggleShowTableGridLinesItem1.Id = 155
            Me.ToggleShowTableGridLinesItem1.Name = "ToggleShowTableGridLinesItem1"
            '
            'ChangeTableBorderLineStyleItem1
            '
            Me.ChangeTableBorderLineStyleItem1.Edit = Me.RepositoryItemBorderLineStyle1
            Me.ChangeTableBorderLineStyleItem1.EditWidth = 130
            Me.ChangeTableBorderLineStyleItem1.Id = 156
            Me.ChangeTableBorderLineStyleItem1.Name = "ChangeTableBorderLineStyleItem1"
            '
            'RepositoryItemBorderLineStyle1
            '
            Me.RepositoryItemBorderLineStyle1.AutoHeight = False
            Me.RepositoryItemBorderLineStyle1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemBorderLineStyle1.Control = Me.RichEdit
            Me.RepositoryItemBorderLineStyle1.Name = "RepositoryItemBorderLineStyle1"
            '
            'ChangeTableBorderLineWeightItem1
            '
            Me.ChangeTableBorderLineWeightItem1.Edit = Me.RepositoryItemBorderLineWeight1
            Me.ChangeTableBorderLineWeightItem1.EditValue = 20
            Me.ChangeTableBorderLineWeightItem1.EditWidth = 130
            Me.ChangeTableBorderLineWeightItem1.Id = 157
            Me.ChangeTableBorderLineWeightItem1.Name = "ChangeTableBorderLineWeightItem1"
            '
            'RepositoryItemBorderLineWeight1
            '
            Me.RepositoryItemBorderLineWeight1.AutoHeight = False
            Me.RepositoryItemBorderLineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemBorderLineWeight1.Control = Me.RichEdit
            Me.RepositoryItemBorderLineWeight1.Name = "RepositoryItemBorderLineWeight1"
            '
            'ChangeTableBorderColorItem1
            '
            Me.ChangeTableBorderColorItem1.Id = 158
            Me.ChangeTableBorderColorItem1.Name = "ChangeTableBorderColorItem1"
            '
            'SelectTableElementsItem1
            '
            Me.SelectTableElementsItem1.Id = 159
            Me.SelectTableElementsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SelectTableCellItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SelectTableColumnItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SelectTableRowItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SelectTableItem1)})
            Me.SelectTableElementsItem1.Name = "SelectTableElementsItem1"
            '
            'SelectTableCellItem1
            '
            Me.SelectTableCellItem1.Id = 160
            Me.SelectTableCellItem1.Name = "SelectTableCellItem1"
            '
            'SelectTableColumnItem1
            '
            Me.SelectTableColumnItem1.Id = 161
            Me.SelectTableColumnItem1.Name = "SelectTableColumnItem1"
            '
            'SelectTableRowItem1
            '
            Me.SelectTableRowItem1.Id = 162
            Me.SelectTableRowItem1.Name = "SelectTableRowItem1"
            '
            'SelectTableItem1
            '
            Me.SelectTableItem1.Id = 163
            Me.SelectTableItem1.Name = "SelectTableItem1"
            '
            'ShowTablePropertiesFormItem1
            '
            Me.ShowTablePropertiesFormItem1.Id = 164
            Me.ShowTablePropertiesFormItem1.Name = "ShowTablePropertiesFormItem1"
            '
            'DeleteTableElementsItem1
            '
            Me.DeleteTableElementsItem1.Id = 165
            Me.DeleteTableElementsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ShowDeleteTableCellsFormItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteTableColumnsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteTableRowsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteTableItem1)})
            Me.DeleteTableElementsItem1.Name = "DeleteTableElementsItem1"
            '
            'ShowDeleteTableCellsFormItem1
            '
            Me.ShowDeleteTableCellsFormItem1.Id = 166
            Me.ShowDeleteTableCellsFormItem1.Name = "ShowDeleteTableCellsFormItem1"
            '
            'DeleteTableColumnsItem1
            '
            Me.DeleteTableColumnsItem1.Id = 167
            Me.DeleteTableColumnsItem1.Name = "DeleteTableColumnsItem1"
            '
            'DeleteTableRowsItem1
            '
            Me.DeleteTableRowsItem1.Id = 168
            Me.DeleteTableRowsItem1.Name = "DeleteTableRowsItem1"
            '
            'DeleteTableItem1
            '
            Me.DeleteTableItem1.Id = 169
            Me.DeleteTableItem1.Name = "DeleteTableItem1"
            '
            'InsertTableRowAboveItem1
            '
            Me.InsertTableRowAboveItem1.Id = 170
            Me.InsertTableRowAboveItem1.Name = "InsertTableRowAboveItem1"
            '
            'InsertTableRowBelowItem1
            '
            Me.InsertTableRowBelowItem1.Id = 171
            Me.InsertTableRowBelowItem1.Name = "InsertTableRowBelowItem1"
            '
            'InsertTableColumnToLeftItem1
            '
            Me.InsertTableColumnToLeftItem1.Id = 172
            Me.InsertTableColumnToLeftItem1.Name = "InsertTableColumnToLeftItem1"
            '
            'InsertTableColumnToRightItem1
            '
            Me.InsertTableColumnToRightItem1.Id = 173
            Me.InsertTableColumnToRightItem1.Name = "InsertTableColumnToRightItem1"
            '
            'ShowInsertTableCellsFormItem1
            '
            Me.ShowInsertTableCellsFormItem1.Id = 174
            Me.ShowInsertTableCellsFormItem1.Name = "ShowInsertTableCellsFormItem1"
            '
            'MergeTableCellsItem1
            '
            Me.MergeTableCellsItem1.Id = 175
            Me.MergeTableCellsItem1.Name = "MergeTableCellsItem1"
            '
            'ShowSplitTableCellsForm1
            '
            Me.ShowSplitTableCellsForm1.Id = 176
            Me.ShowSplitTableCellsForm1.Name = "ShowSplitTableCellsForm1"
            '
            'SplitTableItem1
            '
            Me.SplitTableItem1.Id = 177
            Me.SplitTableItem1.Name = "SplitTableItem1"
            '
            'ToggleTableAutoFitItem1
            '
            Me.ToggleTableAutoFitItem1.Id = 178
            Me.ToggleTableAutoFitItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableAutoFitContentsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableAutoFitWindowItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleTableFixedColumnWidthItem1)})
            Me.ToggleTableAutoFitItem1.Name = "ToggleTableAutoFitItem1"
            '
            'ToggleTableAutoFitContentsItem1
            '
            Me.ToggleTableAutoFitContentsItem1.Id = 179
            Me.ToggleTableAutoFitContentsItem1.Name = "ToggleTableAutoFitContentsItem1"
            '
            'ToggleTableAutoFitWindowItem1
            '
            Me.ToggleTableAutoFitWindowItem1.Id = 180
            Me.ToggleTableAutoFitWindowItem1.Name = "ToggleTableAutoFitWindowItem1"
            '
            'ToggleTableFixedColumnWidthItem1
            '
            Me.ToggleTableFixedColumnWidthItem1.Id = 181
            Me.ToggleTableFixedColumnWidthItem1.Name = "ToggleTableFixedColumnWidthItem1"
            '
            'ToggleTableCellsTopLeftAlignmentItem1
            '
            Me.ToggleTableCellsTopLeftAlignmentItem1.Id = 182
            Me.ToggleTableCellsTopLeftAlignmentItem1.Name = "ToggleTableCellsTopLeftAlignmentItem1"
            '
            'ToggleTableCellsMiddleLeftAlignmentItem1
            '
            Me.ToggleTableCellsMiddleLeftAlignmentItem1.Id = 183
            Me.ToggleTableCellsMiddleLeftAlignmentItem1.Name = "ToggleTableCellsMiddleLeftAlignmentItem1"
            '
            'ToggleTableCellsBottomLeftAlignmentItem1
            '
            Me.ToggleTableCellsBottomLeftAlignmentItem1.Id = 184
            Me.ToggleTableCellsBottomLeftAlignmentItem1.Name = "ToggleTableCellsBottomLeftAlignmentItem1"
            '
            'ToggleTableCellsTopCenterAlignmentItem1
            '
            Me.ToggleTableCellsTopCenterAlignmentItem1.Id = 185
            Me.ToggleTableCellsTopCenterAlignmentItem1.Name = "ToggleTableCellsTopCenterAlignmentItem1"
            '
            'ToggleTableCellsMiddleCenterAlignmentItem1
            '
            Me.ToggleTableCellsMiddleCenterAlignmentItem1.Id = 186
            Me.ToggleTableCellsMiddleCenterAlignmentItem1.Name = "ToggleTableCellsMiddleCenterAlignmentItem1"
            '
            'ToggleTableCellsBottomCenterAlignmentItem1
            '
            Me.ToggleTableCellsBottomCenterAlignmentItem1.Id = 187
            Me.ToggleTableCellsBottomCenterAlignmentItem1.Name = "ToggleTableCellsBottomCenterAlignmentItem1"
            '
            'ToggleTableCellsTopRightAlignmentItem1
            '
            Me.ToggleTableCellsTopRightAlignmentItem1.Id = 188
            Me.ToggleTableCellsTopRightAlignmentItem1.Name = "ToggleTableCellsTopRightAlignmentItem1"
            '
            'ToggleTableCellsMiddleRightAlignmentItem1
            '
            Me.ToggleTableCellsMiddleRightAlignmentItem1.Id = 189
            Me.ToggleTableCellsMiddleRightAlignmentItem1.Name = "ToggleTableCellsMiddleRightAlignmentItem1"
            '
            'ToggleTableCellsBottomRightAlignmentItem1
            '
            Me.ToggleTableCellsBottomRightAlignmentItem1.Id = 190
            Me.ToggleTableCellsBottomRightAlignmentItem1.Name = "ToggleTableCellsBottomRightAlignmentItem1"
            '
            'ShowTableOptionsFormItem1
            '
            Me.ShowTableOptionsFormItem1.Id = 191
            Me.ShowTableOptionsFormItem1.Name = "ShowTableOptionsFormItem1"
            '
            'ChangeFloatingObjectFillColorItem1
            '
            Me.ChangeFloatingObjectFillColorItem1.Id = 192
            Me.ChangeFloatingObjectFillColorItem1.Name = "ChangeFloatingObjectFillColorItem1"
            '
            'ChangeFloatingObjectOutlineColorItem1
            '
            Me.ChangeFloatingObjectOutlineColorItem1.Id = 193
            Me.ChangeFloatingObjectOutlineColorItem1.Name = "ChangeFloatingObjectOutlineColorItem1"
            '
            'ChangeFloatingObjectOutlineWeightItem1
            '
            Me.ChangeFloatingObjectOutlineWeightItem1.Edit = Me.RepositoryItemFloatingObjectOutlineWeight1
            Me.ChangeFloatingObjectOutlineWeightItem1.EditValue = 20
            Me.ChangeFloatingObjectOutlineWeightItem1.Id = 194
            Me.ChangeFloatingObjectOutlineWeightItem1.Name = "ChangeFloatingObjectOutlineWeightItem1"
            '
            'RepositoryItemFloatingObjectOutlineWeight1
            '
            Me.RepositoryItemFloatingObjectOutlineWeight1.AutoHeight = False
            Me.RepositoryItemFloatingObjectOutlineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemFloatingObjectOutlineWeight1.Control = Me.RichEdit
            Me.RepositoryItemFloatingObjectOutlineWeight1.Name = "RepositoryItemFloatingObjectOutlineWeight1"
            '
            'ChangeFloatingObjectTextWrapTypeItem1
            '
            Me.ChangeFloatingObjectTextWrapTypeItem1.Id = 195
            Me.ChangeFloatingObjectTextWrapTypeItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectSquareTextWrapTypeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectTightTextWrapTypeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectThroughTextWrapTypeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectBehindTextWrapTypeItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectInFrontOfTextWrapTypeItem1)})
            Me.ChangeFloatingObjectTextWrapTypeItem1.Name = "ChangeFloatingObjectTextWrapTypeItem1"
            '
            'SetFloatingObjectSquareTextWrapTypeItem1
            '
            Me.SetFloatingObjectSquareTextWrapTypeItem1.Id = 196
            Me.SetFloatingObjectSquareTextWrapTypeItem1.Name = "SetFloatingObjectSquareTextWrapTypeItem1"
            '
            'SetFloatingObjectTightTextWrapTypeItem1
            '
            Me.SetFloatingObjectTightTextWrapTypeItem1.Id = 197
            Me.SetFloatingObjectTightTextWrapTypeItem1.Name = "SetFloatingObjectTightTextWrapTypeItem1"
            '
            'SetFloatingObjectThroughTextWrapTypeItem1
            '
            Me.SetFloatingObjectThroughTextWrapTypeItem1.Id = 198
            Me.SetFloatingObjectThroughTextWrapTypeItem1.Name = "SetFloatingObjectThroughTextWrapTypeItem1"
            '
            'SetFloatingObjectTopAndBottomTextWrapTypeItem1
            '
            Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1.Id = 199
            Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1.Name = "SetFloatingObjectTopAndBottomTextWrapTypeItem1"
            '
            'SetFloatingObjectBehindTextWrapTypeItem1
            '
            Me.SetFloatingObjectBehindTextWrapTypeItem1.Id = 200
            Me.SetFloatingObjectBehindTextWrapTypeItem1.Name = "SetFloatingObjectBehindTextWrapTypeItem1"
            '
            'SetFloatingObjectInFrontOfTextWrapTypeItem1
            '
            Me.SetFloatingObjectInFrontOfTextWrapTypeItem1.Id = 201
            Me.SetFloatingObjectInFrontOfTextWrapTypeItem1.Name = "SetFloatingObjectInFrontOfTextWrapTypeItem1"
            '
            'ChangeFloatingObjectAlignmentItem1
            '
            Me.ChangeFloatingObjectAlignmentItem1.Id = 202
            Me.ChangeFloatingObjectAlignmentItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectTopLeftAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectTopCenterAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectTopRightAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectMiddleLeftAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectMiddleCenterAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectMiddleRightAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectBottomLeftAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectBottomCenterAlignmentItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetFloatingObjectBottomRightAlignmentItem1)})
            Me.ChangeFloatingObjectAlignmentItem1.Name = "ChangeFloatingObjectAlignmentItem1"
            '
            'SetFloatingObjectTopLeftAlignmentItem1
            '
            Me.SetFloatingObjectTopLeftAlignmentItem1.Id = 203
            Me.SetFloatingObjectTopLeftAlignmentItem1.Name = "SetFloatingObjectTopLeftAlignmentItem1"
            '
            'SetFloatingObjectTopCenterAlignmentItem1
            '
            Me.SetFloatingObjectTopCenterAlignmentItem1.Id = 204
            Me.SetFloatingObjectTopCenterAlignmentItem1.Name = "SetFloatingObjectTopCenterAlignmentItem1"
            '
            'SetFloatingObjectTopRightAlignmentItem1
            '
            Me.SetFloatingObjectTopRightAlignmentItem1.Id = 205
            Me.SetFloatingObjectTopRightAlignmentItem1.Name = "SetFloatingObjectTopRightAlignmentItem1"
            '
            'SetFloatingObjectMiddleLeftAlignmentItem1
            '
            Me.SetFloatingObjectMiddleLeftAlignmentItem1.Id = 206
            Me.SetFloatingObjectMiddleLeftAlignmentItem1.Name = "SetFloatingObjectMiddleLeftAlignmentItem1"
            '
            'SetFloatingObjectMiddleCenterAlignmentItem1
            '
            Me.SetFloatingObjectMiddleCenterAlignmentItem1.Id = 207
            Me.SetFloatingObjectMiddleCenterAlignmentItem1.Name = "SetFloatingObjectMiddleCenterAlignmentItem1"
            '
            'SetFloatingObjectMiddleRightAlignmentItem1
            '
            Me.SetFloatingObjectMiddleRightAlignmentItem1.Id = 208
            Me.SetFloatingObjectMiddleRightAlignmentItem1.Name = "SetFloatingObjectMiddleRightAlignmentItem1"
            '
            'SetFloatingObjectBottomLeftAlignmentItem1
            '
            Me.SetFloatingObjectBottomLeftAlignmentItem1.Id = 209
            Me.SetFloatingObjectBottomLeftAlignmentItem1.Name = "SetFloatingObjectBottomLeftAlignmentItem1"
            '
            'SetFloatingObjectBottomCenterAlignmentItem1
            '
            Me.SetFloatingObjectBottomCenterAlignmentItem1.Id = 210
            Me.SetFloatingObjectBottomCenterAlignmentItem1.Name = "SetFloatingObjectBottomCenterAlignmentItem1"
            '
            'SetFloatingObjectBottomRightAlignmentItem1
            '
            Me.SetFloatingObjectBottomRightAlignmentItem1.Id = 211
            Me.SetFloatingObjectBottomRightAlignmentItem1.Name = "SetFloatingObjectBottomRightAlignmentItem1"
            '
            'FloatingObjectBringForwardSubItem1
            '
            Me.FloatingObjectBringForwardSubItem1.Id = 212
            Me.FloatingObjectBringForwardSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectBringForwardItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectBringToFrontItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectBringInFrontOfTextItem1)})
            Me.FloatingObjectBringForwardSubItem1.Name = "FloatingObjectBringForwardSubItem1"
            '
            'FloatingObjectBringForwardItem1
            '
            Me.FloatingObjectBringForwardItem1.Id = 213
            Me.FloatingObjectBringForwardItem1.Name = "FloatingObjectBringForwardItem1"
            '
            'FloatingObjectBringToFrontItem1
            '
            Me.FloatingObjectBringToFrontItem1.Id = 214
            Me.FloatingObjectBringToFrontItem1.Name = "FloatingObjectBringToFrontItem1"
            '
            'FloatingObjectBringInFrontOfTextItem1
            '
            Me.FloatingObjectBringInFrontOfTextItem1.Id = 215
            Me.FloatingObjectBringInFrontOfTextItem1.Name = "FloatingObjectBringInFrontOfTextItem1"
            '
            'FloatingObjectSendBackwardSubItem1
            '
            Me.FloatingObjectSendBackwardSubItem1.Id = 216
            Me.FloatingObjectSendBackwardSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectSendBackwardItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectSendToBackItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.FloatingObjectSendBehindTextItem1)})
            Me.FloatingObjectSendBackwardSubItem1.Name = "FloatingObjectSendBackwardSubItem1"
            '
            'FloatingObjectSendBackwardItem1
            '
            Me.FloatingObjectSendBackwardItem1.Id = 217
            Me.FloatingObjectSendBackwardItem1.Name = "FloatingObjectSendBackwardItem1"
            '
            'FloatingObjectSendToBackItem1
            '
            Me.FloatingObjectSendToBackItem1.Id = 218
            Me.FloatingObjectSendToBackItem1.Name = "FloatingObjectSendToBackItem1"
            '
            'FloatingObjectSendBehindTextItem1
            '
            Me.FloatingObjectSendBehindTextItem1.Id = 219
            Me.FloatingObjectSendBehindTextItem1.Name = "FloatingObjectSendBehindTextItem1"
            '
            'SpellChecker1
            '
            Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("en-US")
            Me.SpellChecker1.ParentContainer = Me.RichEdit
            '
            'RichEditBarController1
            '
            Me.RichEditBarController1.BarItems.Add(Me.UndoItem1)
            Me.RichEditBarController1.BarItems.Add(Me.RedoItem1)
            Me.RichEditBarController1.BarItems.Add(Me.PasteItem1)
            Me.RichEditBarController1.BarItems.Add(Me.CutItem1)
            Me.RichEditBarController1.BarItems.Add(Me.CopyItem1)
            Me.RichEditBarController1.BarItems.Add(Me.PasteSpecialItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFontNameItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFontSizeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FontSizeIncreaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FontSizeDecreaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontBoldItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontItalicItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontUnderlineItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontDoubleUnderlineItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontStrikeoutItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontDoubleStrikeoutItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontSuperscriptItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleFontSubscriptItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFontColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFontBackColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTextCaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.MakeTextUpperCaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.MakeTextLowerCaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTextCaseItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ClearFormattingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowFontFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleBulletedListItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleNumberingListItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleMultiLevelListItem1)
            Me.RichEditBarController1.BarItems.Add(Me.DecreaseIndentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.IncreaseIndentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphAlignmentLeftItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphAlignmentCenterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphAlignmentRightItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphAlignmentJustifyItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleShowWhitespaceItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeParagraphLineSpacingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSingleParagraphSpacingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSesquialteralParagraphSpacingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetDoubleParagraphSpacingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowLineSpacingFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.AddSpacingBeforeParagraphItem1)
            Me.RichEditBarController1.BarItems.Add(Me.RemoveSpacingBeforeParagraphItem1)
            Me.RichEditBarController1.BarItems.Add(Me.AddSpacingAfterParagraphItem1)
            Me.RichEditBarController1.BarItems.Add(Me.RemoveSpacingAfterParagraphItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeParagraphBackColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowParagraphFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeStyleItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowEditStyleFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FindItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ReplaceItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertPageBreakItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertPictureItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertFloatingPictureItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertHyperlinkItem1)
            Me.RichEditBarController1.BarItems.Add(Me.EditPageHeaderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.EditPageFooterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertPageNumberItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertPageCountItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTextBoxItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertSymbolItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPageMarginsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetNormalSectionPageMarginsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetNarrowSectionPageMarginsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetModerateSectionPageMarginsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetWideSectionPageMarginsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowPageMarginsSetupFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPageOrientationItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetPortraitPageOrientationItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetLandscapePageOrientationItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPaperKindItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionColumnsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionOneColumnItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionTwoColumnsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionThreeColumnsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowColumnsSetupFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertBreakItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertPageBreakItem2)
            Me.RichEditBarController1.BarItems.Add(Me.InsertColumnBreakItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakNextPageItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakEvenPageItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakOddPageItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionLineNumberingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingNoneItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingContinuousItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingRestartNewPageItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingRestartNewSectionItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphSuppressLineNumbersItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowLineNumberingFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangePageColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableOfContentsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.UpdateTableOfContentsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.AddParagraphsToTableOfContentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem2)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem3)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem4)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem5)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem6)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem7)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem8)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem9)
            Me.RichEditBarController1.BarItems.Add(Me.SetParagraphHeadingLevelItem10)
            Me.RichEditBarController1.BarItems.Add(Me.InsertCaptionPlaceholderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertFiguresCaptionItems1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTablesCaptionItems1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertEquationsCaptionItems1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableOfFiguresPlaceholderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableOfFiguresItems1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableOfTablesItems1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableOfEquationsItems1)
            Me.RichEditBarController1.BarItems.Add(Me.UpdateTableOfFiguresItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertMergeFieldItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowAllFieldCodesItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowAllFieldResultsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleViewMergedDataItem1)
            Me.RichEditBarController1.BarItems.Add(Me.CheckSpellingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ProtectDocumentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeRangeEditingPermissionsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.UnprotectDocumentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SwitchToSimpleViewItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SwitchToDraftViewItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SwitchToPrintLayoutViewItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleShowHorizontalRulerItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleShowVerticalRulerItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ZoomOutItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ZoomInItem1)
            Me.RichEditBarController1.BarItems.Add(Me.GoToPageHeaderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.GoToPageFooterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.GoToNextHeaderFooterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.GoToPreviousHeaderFooterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleLinkToPreviousItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleDifferentFirstPageItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleDifferentOddAndEvenPagesItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ClosePageHeaderFooterItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTableCellsShadingItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTableBordersItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsBottomBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsTopBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsLeftBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsRightBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ResetTableCellsAllBordersItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsAllBordersItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsOutsideBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsInsideBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsInsideHorizontalBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsInsideVerticalBorderItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleShowTableGridLinesItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTableBorderLineStyleItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTableBorderLineWeightItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeTableBorderColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SelectTableElementsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SelectTableCellItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SelectTableColumnItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SelectTableRowItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SelectTableItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowTablePropertiesFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.DeleteTableElementsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowDeleteTableCellsFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.DeleteTableColumnsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.DeleteTableRowsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.DeleteTableItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableRowAboveItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableRowBelowItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableColumnToLeftItem1)
            Me.RichEditBarController1.BarItems.Add(Me.InsertTableColumnToRightItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowInsertTableCellsFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.MergeTableCellsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowSplitTableCellsForm1)
            Me.RichEditBarController1.BarItems.Add(Me.SplitTableItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableAutoFitItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableAutoFitContentsItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableAutoFitWindowItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableFixedColumnWidthItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsTopLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsMiddleLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsBottomLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsTopCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsMiddleCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsBottomCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsTopRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsMiddleRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ToggleTableCellsBottomRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ShowTableOptionsFormItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFloatingObjectFillColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFloatingObjectOutlineColorItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFloatingObjectOutlineWeightItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFloatingObjectTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectSquareTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectTightTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectThroughTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectTopAndBottomTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectBehindTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectInFrontOfTextWrapTypeItem1)
            Me.RichEditBarController1.BarItems.Add(Me.ChangeFloatingObjectAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectTopLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectTopCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectTopRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectMiddleLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectMiddleCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectMiddleRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectBottomLeftAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectBottomCenterAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.SetFloatingObjectBottomRightAlignmentItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectBringForwardSubItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectBringForwardItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectBringToFrontItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectBringInFrontOfTextItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectSendBackwardSubItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectSendBackwardItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectSendToBackItem1)
            Me.RichEditBarController1.BarItems.Add(Me.FloatingObjectSendBehindTextItem1)
            Me.RichEditBarController1.Control = Me.RichEdit
            '
            'InsertPageBreakItem2
            '
            Me.InsertPageBreakItem2.Id = -1
            Me.InsertPageBreakItem2.Name = "InsertPageBreakItem2"
            '
            'RichEditControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RichEdit)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.Name = "RichEditControl"
            Me.Size = New System.Drawing.Size(1045, 388)
            CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemRichEditStyleEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Protected WithEvents RichEdit As DevExpress.XtraRichEdit.RichEditControl
        Protected WithEvents BarManager1 As DevExpress.XtraBars.BarManager
        Protected WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
        Protected WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Protected WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Protected WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
        Protected WithEvents CommonBar1 As DevExpress.XtraRichEdit.UI.CommonBar
        Protected WithEvents UndoItem1 As DevExpress.XtraRichEdit.UI.UndoItem
        Protected WithEvents RedoItem1 As DevExpress.XtraRichEdit.UI.RedoItem
        Protected WithEvents ClipboardBar1 As DevExpress.XtraRichEdit.UI.ClipboardBar
        Protected WithEvents PasteItem1 As DevExpress.XtraRichEdit.UI.PasteItem
        Protected WithEvents CutItem1 As DevExpress.XtraRichEdit.UI.CutItem
        Protected WithEvents CopyItem1 As DevExpress.XtraRichEdit.UI.CopyItem
        Protected WithEvents PasteSpecialItem1 As DevExpress.XtraRichEdit.UI.PasteSpecialItem
        Protected WithEvents FontBar1 As DevExpress.XtraRichEdit.UI.FontBar
        Protected WithEvents ChangeFontNameItem1 As DevExpress.XtraRichEdit.UI.ChangeFontNameItem
        Protected WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
        Protected WithEvents ChangeFontSizeItem1 As DevExpress.XtraRichEdit.UI.ChangeFontSizeItem
        Protected WithEvents RepositoryItemRichEditFontSizeEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
        Protected WithEvents FontSizeIncreaseItem1 As DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem
        Protected WithEvents FontSizeDecreaseItem1 As DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem
        Protected WithEvents ToggleFontBoldItem1 As DevExpress.XtraRichEdit.UI.ToggleFontBoldItem
        Protected WithEvents ToggleFontItalicItem1 As DevExpress.XtraRichEdit.UI.ToggleFontItalicItem
        Protected WithEvents ToggleFontUnderlineItem1 As DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem
        Protected WithEvents ToggleFontDoubleUnderlineItem1 As DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem
        Protected WithEvents ToggleFontStrikeoutItem1 As DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem
        Protected WithEvents ToggleFontDoubleStrikeoutItem1 As DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem
        Protected WithEvents ToggleFontSuperscriptItem1 As DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem
        Protected WithEvents ToggleFontSubscriptItem1 As DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem
        Protected WithEvents ChangeFontColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFontColorItem
        Protected WithEvents ChangeFontBackColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem
        Protected WithEvents ChangeTextCaseItem1 As DevExpress.XtraRichEdit.UI.ChangeTextCaseItem
        Protected WithEvents MakeTextUpperCaseItem1 As DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem
        Protected WithEvents MakeTextLowerCaseItem1 As DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem
        Protected WithEvents ToggleTextCaseItem1 As DevExpress.XtraRichEdit.UI.ToggleTextCaseItem
        Protected WithEvents ClearFormattingItem1 As DevExpress.XtraRichEdit.UI.ClearFormattingItem
        Protected WithEvents ShowFontFormItem1 As DevExpress.XtraRichEdit.UI.ShowFontFormItem
        Protected WithEvents ParagraphBar1 As DevExpress.XtraRichEdit.UI.ParagraphBar
        Protected WithEvents ToggleBulletedListItem1 As DevExpress.XtraRichEdit.UI.ToggleBulletedListItem
        Protected WithEvents ToggleNumberingListItem1 As DevExpress.XtraRichEdit.UI.ToggleNumberingListItem
        Protected WithEvents ToggleMultiLevelListItem1 As DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem
        Protected WithEvents DecreaseIndentItem1 As DevExpress.XtraRichEdit.UI.DecreaseIndentItem
        Protected WithEvents IncreaseIndentItem1 As DevExpress.XtraRichEdit.UI.IncreaseIndentItem
        Protected WithEvents ToggleParagraphAlignmentLeftItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem
        Protected WithEvents ToggleParagraphAlignmentCenterItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem
        Protected WithEvents ToggleParagraphAlignmentRightItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem
        Protected WithEvents ToggleParagraphAlignmentJustifyItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem
        Protected WithEvents ToggleShowWhitespaceItem1 As DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem
        Protected WithEvents ChangeParagraphLineSpacingItem1 As DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem
        Protected WithEvents SetSingleParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem
        Protected WithEvents SetSesquialteralParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem
        Protected WithEvents SetDoubleParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem
        Protected WithEvents ShowLineSpacingFormItem1 As DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem
        Protected WithEvents AddSpacingBeforeParagraphItem1 As DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem
        Protected WithEvents RemoveSpacingBeforeParagraphItem1 As DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem
        Protected WithEvents AddSpacingAfterParagraphItem1 As DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem
        Protected WithEvents RemoveSpacingAfterParagraphItem1 As DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem
        Protected WithEvents ChangeParagraphBackColorItem1 As DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem
        Protected WithEvents ShowParagraphFormItem1 As DevExpress.XtraRichEdit.UI.ShowParagraphFormItem
        Protected WithEvents StylesBar1 As DevExpress.XtraRichEdit.UI.StylesBar
        Protected WithEvents ChangeStyleItem1 As DevExpress.XtraRichEdit.UI.ChangeStyleItem
        Protected WithEvents RepositoryItemRichEditStyleEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit
        Protected WithEvents ShowEditStyleFormItem1 As DevExpress.XtraRichEdit.UI.ShowEditStyleFormItem
        Protected WithEvents EditingBar1 As DevExpress.XtraRichEdit.UI.EditingBar
        Protected WithEvents FindItem1 As DevExpress.XtraRichEdit.UI.FindItem
        Protected WithEvents ReplaceItem1 As DevExpress.XtraRichEdit.UI.ReplaceItem
        Protected WithEvents InsertPageBreakItem1 As DevExpress.XtraRichEdit.UI.InsertPageBreakItem
        Protected WithEvents InsertTableItem1 As DevExpress.XtraRichEdit.UI.InsertTableItem
        Protected WithEvents InsertPictureItem1 As DevExpress.XtraRichEdit.UI.InsertPictureItem
        Protected WithEvents InsertFloatingPictureItem1 As DevExpress.XtraRichEdit.UI.InsertFloatingPictureItem
        Protected WithEvents LinksBar1 As DevExpress.XtraRichEdit.UI.LinksBar
        Protected WithEvents InsertHyperlinkItem1 As DevExpress.XtraRichEdit.UI.InsertHyperlinkItem
        Protected WithEvents EditPageHeaderItem1 As DevExpress.XtraRichEdit.UI.EditPageHeaderItem
        Protected WithEvents EditPageFooterItem1 As DevExpress.XtraRichEdit.UI.EditPageFooterItem
        Protected WithEvents InsertPageNumberItem1 As DevExpress.XtraRichEdit.UI.InsertPageNumberItem
        Protected WithEvents InsertPageCountItem1 As DevExpress.XtraRichEdit.UI.InsertPageCountItem
        Protected WithEvents InsertTextBoxItem1 As DevExpress.XtraRichEdit.UI.InsertTextBoxItem
        Protected WithEvents SymbolsBar1 As DevExpress.XtraRichEdit.UI.SymbolsBar
        Protected WithEvents InsertSymbolItem1 As DevExpress.XtraRichEdit.UI.InsertSymbolItem
        Protected WithEvents ChangeSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPageMarginsItem
        Protected WithEvents SetNormalSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetNormalSectionPageMarginsItem
        Protected WithEvents SetNarrowSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetNarrowSectionPageMarginsItem
        Protected WithEvents SetModerateSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetModerateSectionPageMarginsItem
        Protected WithEvents SetWideSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetWideSectionPageMarginsItem
        Protected WithEvents ShowPageMarginsSetupFormItem1 As DevExpress.XtraRichEdit.UI.ShowPageMarginsSetupFormItem
        Protected WithEvents ChangeSectionPageOrientationItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPageOrientationItem
        Protected WithEvents SetPortraitPageOrientationItem1 As DevExpress.XtraRichEdit.UI.SetPortraitPageOrientationItem
        Protected WithEvents SetLandscapePageOrientationItem1 As DevExpress.XtraRichEdit.UI.SetLandscapePageOrientationItem
        Protected WithEvents ChangeSectionPaperKindItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPaperKindItem
        Protected WithEvents ChangeSectionColumnsItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionColumnsItem
        Protected WithEvents SetSectionOneColumnItem1 As DevExpress.XtraRichEdit.UI.SetSectionOneColumnItem
        Protected WithEvents SetSectionTwoColumnsItem1 As DevExpress.XtraRichEdit.UI.SetSectionTwoColumnsItem
        Protected WithEvents SetSectionThreeColumnsItem1 As DevExpress.XtraRichEdit.UI.SetSectionThreeColumnsItem
        Protected WithEvents ShowColumnsSetupFormItem1 As DevExpress.XtraRichEdit.UI.ShowColumnsSetupFormItem
        Protected WithEvents InsertBreakItem1 As DevExpress.XtraRichEdit.UI.InsertBreakItem
        Protected WithEvents InsertColumnBreakItem1 As DevExpress.XtraRichEdit.UI.InsertColumnBreakItem
        Protected WithEvents InsertSectionBreakNextPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakNextPageItem
        Protected WithEvents InsertSectionBreakEvenPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakEvenPageItem
        Protected WithEvents InsertSectionBreakOddPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakOddPageItem
        Protected WithEvents ChangeSectionLineNumberingItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionLineNumberingItem
        Protected WithEvents SetSectionLineNumberingNoneItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingNoneItem
        Protected WithEvents SetSectionLineNumberingContinuousItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingContinuousItem
        Protected WithEvents SetSectionLineNumberingRestartNewPageItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewPageItem
        Protected WithEvents SetSectionLineNumberingRestartNewSectionItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewSectionItem
        Protected WithEvents ToggleParagraphSuppressLineNumbersItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphSuppressLineNumbersItem
        Protected WithEvents ShowLineNumberingFormItem1 As DevExpress.XtraRichEdit.UI.ShowLineNumberingFormItem
        Protected WithEvents ChangePageColorItem1 As DevExpress.XtraRichEdit.UI.ChangePageColorItem
        Protected WithEvents InsertTableOfContentsItem1 As DevExpress.XtraRichEdit.UI.InsertTableOfContentsItem
        Protected WithEvents UpdateTableOfContentsItem1 As DevExpress.XtraRichEdit.UI.UpdateTableOfContentsItem
        Protected WithEvents AddParagraphsToTableOfContentItem1 As DevExpress.XtraRichEdit.UI.AddParagraphsToTableOfContentItem
        Protected WithEvents SetParagraphHeadingLevelItem1 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem2 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem3 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem4 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem5 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem6 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem7 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem8 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem9 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents SetParagraphHeadingLevelItem10 As DevExpress.XtraRichEdit.UI.SetParagraphHeadingLevelItem
        Protected WithEvents InsertCaptionPlaceholderItem1 As DevExpress.XtraRichEdit.UI.InsertCaptionPlaceholderItem
        Protected WithEvents InsertFiguresCaptionItems1 As DevExpress.XtraRichEdit.UI.InsertFiguresCaptionItems
        Protected WithEvents InsertTablesCaptionItems1 As DevExpress.XtraRichEdit.UI.InsertTablesCaptionItems
        Protected WithEvents InsertEquationsCaptionItems1 As DevExpress.XtraRichEdit.UI.InsertEquationsCaptionItems
        Protected WithEvents InsertTableOfFiguresPlaceholderItem1 As DevExpress.XtraRichEdit.UI.InsertTableOfFiguresPlaceholderItem
        Protected WithEvents InsertTableOfFiguresItems1 As DevExpress.XtraRichEdit.UI.InsertTableOfFiguresItems
        Protected WithEvents InsertTableOfTablesItems1 As DevExpress.XtraRichEdit.UI.InsertTableOfTablesItems
        Protected WithEvents InsertTableOfEquationsItems1 As DevExpress.XtraRichEdit.UI.InsertTableOfEquationsItems
        Protected WithEvents UpdateTableOfFiguresItem1 As DevExpress.XtraRichEdit.UI.UpdateTableOfFiguresItem
        Protected WithEvents InsertMergeFieldItem1 As DevExpress.XtraRichEdit.UI.InsertMergeFieldItem
        Protected WithEvents ShowAllFieldCodesItem1 As DevExpress.XtraRichEdit.UI.ShowAllFieldCodesItem
        Protected WithEvents ShowAllFieldResultsItem1 As DevExpress.XtraRichEdit.UI.ShowAllFieldResultsItem
        Protected WithEvents ToggleViewMergedDataItem1 As DevExpress.XtraRichEdit.UI.ToggleViewMergedDataItem
        Protected WithEvents DocumentProofingBar1 As DevExpress.XtraRichEdit.UI.DocumentProofingBar
        Protected WithEvents CheckSpellingItem1 As DevExpress.XtraRichEdit.UI.CheckSpellingItem
        Protected WithEvents ProtectDocumentItem1 As DevExpress.XtraRichEdit.UI.ProtectDocumentItem
        Protected WithEvents ChangeRangeEditingPermissionsItem1 As DevExpress.XtraRichEdit.UI.ChangeRangeEditingPermissionsItem
        Protected WithEvents UnprotectDocumentItem1 As DevExpress.XtraRichEdit.UI.UnprotectDocumentItem
        Protected WithEvents SwitchToSimpleViewItem1 As DevExpress.XtraRichEdit.UI.SwitchToSimpleViewItem
        Protected WithEvents SwitchToDraftViewItem1 As DevExpress.XtraRichEdit.UI.SwitchToDraftViewItem
        Protected WithEvents SwitchToPrintLayoutViewItem1 As DevExpress.XtraRichEdit.UI.SwitchToPrintLayoutViewItem
        Protected WithEvents ToggleShowHorizontalRulerItem1 As DevExpress.XtraRichEdit.UI.ToggleShowHorizontalRulerItem
        Protected WithEvents ToggleShowVerticalRulerItem1 As DevExpress.XtraRichEdit.UI.ToggleShowVerticalRulerItem
        Protected WithEvents ZoomOutItem1 As DevExpress.XtraRichEdit.UI.ZoomOutItem
        Protected WithEvents ZoomInItem1 As DevExpress.XtraRichEdit.UI.ZoomInItem
        Protected WithEvents GoToPageHeaderItem1 As DevExpress.XtraRichEdit.UI.GoToPageHeaderItem
        Protected WithEvents GoToPageFooterItem1 As DevExpress.XtraRichEdit.UI.GoToPageFooterItem
        Protected WithEvents GoToNextHeaderFooterItem1 As DevExpress.XtraRichEdit.UI.GoToNextHeaderFooterItem
        Protected WithEvents GoToPreviousHeaderFooterItem1 As DevExpress.XtraRichEdit.UI.GoToPreviousHeaderFooterItem
        Protected WithEvents ToggleLinkToPreviousItem1 As DevExpress.XtraRichEdit.UI.ToggleLinkToPreviousItem
        Protected WithEvents ToggleDifferentFirstPageItem1 As DevExpress.XtraRichEdit.UI.ToggleDifferentFirstPageItem
        Protected WithEvents ToggleDifferentOddAndEvenPagesItem1 As DevExpress.XtraRichEdit.UI.ToggleDifferentOddAndEvenPagesItem
        Protected WithEvents ClosePageHeaderFooterItem1 As DevExpress.XtraRichEdit.UI.ClosePageHeaderFooterItem
        Protected WithEvents ChangeTableCellsShadingItem1 As DevExpress.XtraRichEdit.UI.ChangeTableCellsShadingItem
        Protected WithEvents ChangeTableBordersItem1 As DevExpress.XtraRichEdit.UI.ChangeTableBordersItem
        Protected WithEvents ToggleTableCellsBottomBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomBorderItem
        Protected WithEvents ToggleTableCellsTopBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsTopBorderItem
        Protected WithEvents ToggleTableCellsLeftBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsLeftBorderItem
        Protected WithEvents ToggleTableCellsRightBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsRightBorderItem
        Protected WithEvents ResetTableCellsAllBordersItem1 As DevExpress.XtraRichEdit.UI.ResetTableCellsAllBordersItem
        Protected WithEvents ToggleTableCellsAllBordersItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsAllBordersItem
        Protected WithEvents ToggleTableCellsOutsideBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsOutsideBorderItem
        Protected WithEvents ToggleTableCellsInsideBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideBorderItem
        Protected WithEvents ToggleTableCellsInsideHorizontalBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideHorizontalBorderItem
        Protected WithEvents ToggleTableCellsInsideVerticalBorderItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsInsideVerticalBorderItem
        Protected WithEvents ToggleShowTableGridLinesItem1 As DevExpress.XtraRichEdit.UI.ToggleShowTableGridLinesItem
        Protected WithEvents ChangeTableBorderLineStyleItem1 As DevExpress.XtraRichEdit.UI.ChangeTableBorderLineStyleItem
        Protected WithEvents RepositoryItemBorderLineStyle1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle
        Protected WithEvents ChangeTableBorderLineWeightItem1 As DevExpress.XtraRichEdit.UI.ChangeTableBorderLineWeightItem
        Protected WithEvents RepositoryItemBorderLineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight
        Protected WithEvents ChangeTableBorderColorItem1 As DevExpress.XtraRichEdit.UI.ChangeTableBorderColorItem
        Protected WithEvents SelectTableElementsItem1 As DevExpress.XtraRichEdit.UI.SelectTableElementsItem
        Protected WithEvents SelectTableCellItem1 As DevExpress.XtraRichEdit.UI.SelectTableCellItem
        Protected WithEvents SelectTableColumnItem1 As DevExpress.XtraRichEdit.UI.SelectTableColumnItem
        Protected WithEvents SelectTableRowItem1 As DevExpress.XtraRichEdit.UI.SelectTableRowItem
        Protected WithEvents SelectTableItem1 As DevExpress.XtraRichEdit.UI.SelectTableItem
        Protected WithEvents ShowTablePropertiesFormItem1 As DevExpress.XtraRichEdit.UI.ShowTablePropertiesFormItem
        Protected WithEvents DeleteTableElementsItem1 As DevExpress.XtraRichEdit.UI.DeleteTableElementsItem
        Protected WithEvents ShowDeleteTableCellsFormItem1 As DevExpress.XtraRichEdit.UI.ShowDeleteTableCellsFormItem
        Protected WithEvents DeleteTableColumnsItem1 As DevExpress.XtraRichEdit.UI.DeleteTableColumnsItem
        Protected WithEvents DeleteTableRowsItem1 As DevExpress.XtraRichEdit.UI.DeleteTableRowsItem
        Protected WithEvents DeleteTableItem1 As DevExpress.XtraRichEdit.UI.DeleteTableItem
        Protected WithEvents InsertTableRowAboveItem1 As DevExpress.XtraRichEdit.UI.InsertTableRowAboveItem
        Protected WithEvents InsertTableRowBelowItem1 As DevExpress.XtraRichEdit.UI.InsertTableRowBelowItem
        Protected WithEvents InsertTableColumnToLeftItem1 As DevExpress.XtraRichEdit.UI.InsertTableColumnToLeftItem
        Protected WithEvents InsertTableColumnToRightItem1 As DevExpress.XtraRichEdit.UI.InsertTableColumnToRightItem
        Protected WithEvents ShowInsertTableCellsFormItem1 As DevExpress.XtraRichEdit.UI.ShowInsertTableCellsFormItem
        Protected WithEvents MergeTableCellsItem1 As DevExpress.XtraRichEdit.UI.MergeTableCellsItem
        Protected WithEvents ShowSplitTableCellsForm1 As DevExpress.XtraRichEdit.UI.ShowSplitTableCellsForm
        Protected WithEvents SplitTableItem1 As DevExpress.XtraRichEdit.UI.SplitTableItem
        Protected WithEvents ToggleTableAutoFitItem1 As DevExpress.XtraRichEdit.UI.ToggleTableAutoFitItem
        Protected WithEvents ToggleTableAutoFitContentsItem1 As DevExpress.XtraRichEdit.UI.ToggleTableAutoFitContentsItem
        Protected WithEvents ToggleTableAutoFitWindowItem1 As DevExpress.XtraRichEdit.UI.ToggleTableAutoFitWindowItem
        Protected WithEvents ToggleTableFixedColumnWidthItem1 As DevExpress.XtraRichEdit.UI.ToggleTableFixedColumnWidthItem
        Protected WithEvents ToggleTableCellsTopLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsTopLeftAlignmentItem
        Protected WithEvents ToggleTableCellsMiddleLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleLeftAlignmentItem
        Protected WithEvents ToggleTableCellsBottomLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomLeftAlignmentItem
        Protected WithEvents ToggleTableCellsTopCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsTopCenterAlignmentItem
        Protected WithEvents ToggleTableCellsMiddleCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleCenterAlignmentItem
        Protected WithEvents ToggleTableCellsBottomCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomCenterAlignmentItem
        Protected WithEvents ToggleTableCellsTopRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsTopRightAlignmentItem
        Protected WithEvents ToggleTableCellsMiddleRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsMiddleRightAlignmentItem
        Protected WithEvents ToggleTableCellsBottomRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.ToggleTableCellsBottomRightAlignmentItem
        Protected WithEvents ShowTableOptionsFormItem1 As DevExpress.XtraRichEdit.UI.ShowTableOptionsFormItem
        Protected WithEvents ChangeFloatingObjectFillColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFloatingObjectFillColorItem
        Protected WithEvents ChangeFloatingObjectOutlineColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFloatingObjectOutlineColorItem
        Protected WithEvents ChangeFloatingObjectOutlineWeightItem1 As DevExpress.XtraRichEdit.UI.ChangeFloatingObjectOutlineWeightItem
        Protected WithEvents RepositoryItemFloatingObjectOutlineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight
        Protected WithEvents ChangeFloatingObjectTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.ChangeFloatingObjectTextWrapTypeItem
        Protected WithEvents SetFloatingObjectSquareTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectSquareTextWrapTypeItem
        Protected WithEvents SetFloatingObjectTightTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectTightTextWrapTypeItem
        Protected WithEvents SetFloatingObjectThroughTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectThroughTextWrapTypeItem
        Protected WithEvents SetFloatingObjectTopAndBottomTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectTopAndBottomTextWrapTypeItem
        Protected WithEvents SetFloatingObjectBehindTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectBehindTextWrapTypeItem
        Protected WithEvents SetFloatingObjectInFrontOfTextWrapTypeItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectInFrontOfTextWrapTypeItem
        Protected WithEvents ChangeFloatingObjectAlignmentItem1 As DevExpress.XtraRichEdit.UI.ChangeFloatingObjectAlignmentItem
        Protected WithEvents SetFloatingObjectTopLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectTopLeftAlignmentItem
        Protected WithEvents SetFloatingObjectTopCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectTopCenterAlignmentItem
        Protected WithEvents SetFloatingObjectTopRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectTopRightAlignmentItem
        Protected WithEvents SetFloatingObjectMiddleLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleLeftAlignmentItem
        Protected WithEvents SetFloatingObjectMiddleCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleCenterAlignmentItem
        Protected WithEvents SetFloatingObjectMiddleRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectMiddleRightAlignmentItem
        Protected WithEvents SetFloatingObjectBottomLeftAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomLeftAlignmentItem
        Protected WithEvents SetFloatingObjectBottomCenterAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomCenterAlignmentItem
        Protected WithEvents SetFloatingObjectBottomRightAlignmentItem1 As DevExpress.XtraRichEdit.UI.SetFloatingObjectBottomRightAlignmentItem
        Protected WithEvents FloatingObjectBringForwardSubItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectBringForwardSubItem
        Protected WithEvents FloatingObjectBringForwardItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectBringForwardItem
        Protected WithEvents FloatingObjectBringToFrontItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectBringToFrontItem
        Protected WithEvents FloatingObjectBringInFrontOfTextItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectBringInFrontOfTextItem
        Protected WithEvents FloatingObjectSendBackwardSubItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectSendBackwardSubItem
        Protected WithEvents FloatingObjectSendBackwardItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectSendBackwardItem
        Protected WithEvents FloatingObjectSendToBackItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectSendToBackItem
        Protected WithEvents FloatingObjectSendBehindTextItem1 As DevExpress.XtraRichEdit.UI.FloatingObjectSendBehindTextItem
        Protected WithEvents RichEditBarController1 As DevExpress.XtraRichEdit.UI.RichEditBarController
        Protected WithEvents InsertPageBreakItem2 As DevExpress.XtraRichEdit.UI.InsertPageBreakItem
        Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    End Class

End Namespace