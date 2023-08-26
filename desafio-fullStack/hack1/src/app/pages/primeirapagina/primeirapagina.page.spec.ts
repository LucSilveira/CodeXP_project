import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { PrimeirapaginaPage } from './primeirapagina.page';

describe('PrimeirapaginaPage', () => {
  let component: PrimeirapaginaPage;
  let fixture: ComponentFixture<PrimeirapaginaPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrimeirapaginaPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(PrimeirapaginaPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
