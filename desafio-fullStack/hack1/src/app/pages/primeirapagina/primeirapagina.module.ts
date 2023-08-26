import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { PrimeirapaginaPageRoutingModule } from './primeirapagina-routing.module';
import { PrimeirapaginaPage } from './primeirapagina.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PrimeirapaginaPageRoutingModule
  ],
  declarations: [PrimeirapaginaPage]
})

export class PrimeirapaginaPageModule {

}
