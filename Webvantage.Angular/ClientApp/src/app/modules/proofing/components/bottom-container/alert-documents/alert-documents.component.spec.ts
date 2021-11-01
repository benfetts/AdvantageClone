import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertDocumentsComponent } from './alert-documents.component';

describe('AlertDocumentsComponent', () => {
  let component: AlertDocumentsComponent;
  let fixture: ComponentFixture<AlertDocumentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlertDocumentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlertDocumentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
