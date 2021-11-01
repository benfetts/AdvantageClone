import { children } from 'aurelia-framework';


export class CommentViewer {

    @children('comment') comments: any;

    attached() {

       //console.log('comment-viewer', this.comments);

    }

}
