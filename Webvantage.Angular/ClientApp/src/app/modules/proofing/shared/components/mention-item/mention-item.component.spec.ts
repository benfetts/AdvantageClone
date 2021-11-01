import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentionItemComponent } from './mention-item.component';

describe('MentionItemComponent', () => {
  let component: MentionItemComponent;
  let fixture: ComponentFixture<MentionItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentionItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentionItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
