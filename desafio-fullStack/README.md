# desafio-fullStack
Desafio flutter para ilha de fullstack

## Descrição
Montar uma plataforma em flutter que simule uma lista de compras na Smartmentor

Pegar os itens de compra no firebase com a Web API key AIzaSyCvbxfVSKEBhZOy_BzLApc3hBYLxoOGyzU

### To do
 Criar uma lista de itens com imagem, descrição e valor
 
 Ao clicar em adicionar um item ele deve ser adicionardo ao carrinho
 
 Ao clicar em remover um item, ele deve ser removido do carrinho
 
 Se não houver nenhum item no carrinho, ele não pode clicar em remover o item
 
 Pode-se adicionar mais de um item por vez.
 
 Criar uma tela de checkout com os itens selecionados na tela anterior
 
 A tela de checkout deve ter o calculo com a soma de produtos selecionados no carrinho, assim como cada tipo de item exposto e sua quantidade no carrinho.

### plus
 Ao clicar em concluir na tela de checkout deve criar um pedido no firebase na collaction pedidos/[pedido_id](gerado automatico) com um id aleatório.

# Ambientação
Os itens na collection de produtos no firebase estarão no seguinte formato
```
{
  descricao:"String",
  imagem: "string",
  nome: "string",
  preco: number,
}
```

# Atenção
Todos os produtos devem usar a imagem que está salva no ./assets do projeto, não utilizem o que vem da base de dados.
