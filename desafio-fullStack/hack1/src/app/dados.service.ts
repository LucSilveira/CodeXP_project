import { Injectable } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection, AngularFirestoreDocument, DocumentReference } from '@angular/fire/firestore';
import { map, take } from 'rxjs/operators';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class DadosService {

  private produtos: Observable<any[]>;
  private produtosCollection: AngularFirestoreCollection<any>;
  
  constructor(private afs: AngularFirestore) { 
    this.produtosCollection = this.afs.collection<any>('produtos');

    this.produtos = this.produtosCollection.snapshotChanges().pipe(
      map(actions => {
        return actions.map(a => {
          const data = a.payload.doc.data();
          const id = a.payload.doc.id;
          return { id, ...data };
        });
      })
    );
  }

  getProdutos(): Observable<any[]> {
    return this.produtos;
  }
 
  getProduto(id: string): Observable<any> {
    return this.produtosCollection.doc<any>(id).valueChanges().pipe(
      take(1),
      map(idea => {
        idea.id = id;
        return idea
      })
    );
  }
 
  addProduto(dados: any): Promise<DocumentReference> {
    return this.produtosCollection.add(dados);
  }
 
  updateProduto(dados: any): Promise<void> {
    return this.produtosCollection.doc(dados.id).update(
      { 
        nome: dados.nome, 
        email: dados.email, 
        telefone: dados.telefone
      }
    );
  }
 
  deletarProduto(id: string): Promise<void> {
    return this.produtosCollection.doc(id).delete();
  }
}
