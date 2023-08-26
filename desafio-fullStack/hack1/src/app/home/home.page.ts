import { Component } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';
import { map, take } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { DadosService } from '../dados.service';



@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  items: Observable<any[]>;
  itensCart: any = [];

  constructor(private ddServ: DadosService) {
    
    this.ddServ.getProdutos().subscribe( (res:any) => {
      console.log(res);

      this.items = res;
    });
  }

  ngOnInit() {

  }

  click(dado){
    console.log(dado);
    this.itensCart.push(dado);
    localStorage.setItem("cart", JSON.stringify(this.itensCart));
    }

}
