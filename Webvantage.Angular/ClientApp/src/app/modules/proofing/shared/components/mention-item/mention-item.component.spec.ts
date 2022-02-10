import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MentionItemComponent } from './mention-item.component';

describe('MentionItemComponent', () => {
  let component: MentionItemComponent;
  let fixture: ComponentFixture<MentionItemComponent>;

  beforeEach(waitForAsync(() => {
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
