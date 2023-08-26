import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PrimeirapaginaPage } from './primeirapagina.page';

const routes: Routes = [
  {
    path: '',
    component: PrimeirapaginaPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PrimeirapaginaPageRoutingModule {}
