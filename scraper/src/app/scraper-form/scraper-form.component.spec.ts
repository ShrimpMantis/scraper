import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScraperFormComponent } from './scraper-form.component';

describe('ScraperFormComponent', () => {
  let component: ScraperFormComponent;
  let fixture: ComponentFixture<ScraperFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScraperFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScraperFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
