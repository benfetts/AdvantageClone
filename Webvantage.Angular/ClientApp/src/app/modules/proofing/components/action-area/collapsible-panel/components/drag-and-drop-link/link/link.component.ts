import { Component, Input, OnInit } from '@angular/core';

const MAX_LENGTH = 29;
const FILE_NAME_LENGTH = 29;

@Component({
  selector: 'proof-link',
  templateUrl: './link.component.html',
  styleUrls: ['./link.component.scss']
})
export class LinkComponent implements OnInit {
  @Input() public link: string;

  public ngOnInit(): void {
    this.link = this.link.length > MAX_LENGTH
      ? `${this.link.slice(0, FILE_NAME_LENGTH)}...`
      : this.link;
  }
}
