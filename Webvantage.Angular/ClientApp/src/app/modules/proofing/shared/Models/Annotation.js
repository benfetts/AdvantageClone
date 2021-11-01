"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.wvAnnotation = void 0;
var wvAnnotation = /** @class */ (function () {
    //id: number;
    //markupXml: string;
    //markup: string;
    //empCode: string;
    //documentId: number;
    //markupTypeId: number;
    //alertId: number;
    function wvAnnotation(id, markupXml, markup, empCode, documentId, markupTypeId, commentId) {
        this.id = id;
        this.markupXml = markupXml;
        this.markup = markup;
        this.empCode = empCode;
        this.documentId = documentId;
        this.markupTypeId = markupTypeId;
        this.commentId = commentId;
        this.draft = true;
    }
    return wvAnnotation;
}());
exports.wvAnnotation = wvAnnotation;
//# sourceMappingURL=Annotation.js.map