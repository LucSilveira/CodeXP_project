function notasAvaliacao (){

// VARIÁVEIS PARA PEGAR OS VALORES DA AVALIAÇÃO E COLORIR VERIFICANDO AS NOTAS BAIXAS E MAIORES NOTAS
    var notaSabor = document.getElementsByClassName("notaSabor"); // Variável que ira verificar os valores das notas de sabores
    var notaOdor = document.getElementsByClassName("notaOdor"); // Variável que ira verificar os valores das notas de odores
    var notaTextura = document.getElementsByClassName("notaTextura"); // Variável que ira verificar os valores das notas da textura
    var notaAparencia = document.getElementsByClassName("notaAparencia"); // Variável que ira verificar os valores das notas da aparencia
    var indexMaiorNota = 0; // Variável que ira almazenar as maiores notas do produto


// LACOS PARA VERIFICAÇÃO DAS NOTAS INFORMADAS

    // Laço para verificação das notas referente o sabor do produto
    for (i = 0; i < notaSabor.length; i++){

        if(notaSabor[i].innerHTML < 6 && notaOdor[i].innerHTML<6){
            notaSabor[i].style.color = "red";
        }

        if(parseInt(notaSabor[i].innerHTML)>parseInt(notaSabor[indexMaiorNota].innerHTML)){
            indexMaiorNota = i;
        }
    }
    notaSabor[indexMaiorNota].style.color = "green";

    // Laço para verificação das notas referente o odor do produto
    for (i = 0; i < notaOdor.length; i++){

        if(notaOdor[i].innerHTML < 6){
            notaOdor[i].style.color = "red";
        }

        if(parseInt(notaOdor[i].innerHTML)>parseInt(notaOdor[indexMaiorNota].innerHTML)){
            indexMaiorNota = i;
        }
    }
    notaOdor[indexMaiorNota].style.color = "green";

    // Laço para verificação das notas referente a textura do produto
    for (i = 0; i < notaTextura.length; i++){

        if(notaTextura[i].innerHTML<6){
            notaTextura[i].style.color = "red";
        }

        if(parseInt(notaTextura[i].innerHTML)>parseInt(notaTextura[indexMaiorNota].innerHTML)){
            indexMaiorNota = i;
        }
    }
    notaTextura[indexMaiorNota].style.color = "green";

    // Laço para verificação das notas referente a aparência do produto
    for (i = 0; i < notaAparencia.length; i++){

        if(notaAparencia[i].innerHTML<6){
            notaAparencia[i].style.color = "red";
        }

        if(parseInt(notaAparencia[i].innerHTML)>parseInt(notaAparencia[indexMaiorNota].innerHTML)){
            indexMaiorNota = i;
        }
    }
    notaAparencia[indexMaiorNota].style.color = "green";

    // ***********************************************************************************

// LAÇOS PARA PERCORRER AS LINHAS DOS PRODUTOS E CAPTURAR SEUS VALORES
    
    // VARIÁVEIS PARA QUARDAR OS VALORES DA AVALIAÇÃO E ACHAR A MÉDIA
    var contaPrimeiro_prd = document.getElementById("primeiro_produto").getElementsByClassName("contaPrim_produto"); // Variável que ira armazenar a conta da media do produto
    var contaSegundo_prd = document.getElementById("segundo_produto").getElementsByClassName("contaSeg_produto"); // Variável que ira armazenar a conta da media do produto
    var contaTerceiro_prd = document.getElementById("terceiro_produto").getElementsByClassName("contaTerc_produto"); // Variável que ira armazenar a conta da media do produto
    var contaQuarto_prd = document.getElementById("quarto_produto").getElementsByClassName("contaQuar_produto"); // Variável que ira armazenar a conta da media do produto

    var pesos_avalicao = 3 + 2 + 2 + 1;

    // Laço para realizar a conta da média ponderada das avaliações
    for (i = 0; i < contaPrimeiro_prd.length; i++){

        var primeiro_prdt = ((contaPrimeiro_prd[0].innerHTML * 3) + (contaPrimeiro_prd[1].innerHTML * 2)
                + (contaPrimeiro_prd[2].innerHTML * 2) + (contaPrimeiro_prd[3].innerHTML * 1)) / pesos_avalicao;

    }

    // Laço para realizar a conta da média ponderada das avaliações
    for (i = 0; i < contaSegundo_prd.length; i++){

        var segundo_prdt = ((contaSegundo_prd[0].innerHTML * 3) + (contaSegundo_prd[1].innerHTML * 2)
                + (contaSegundo_prd[2].innerHTML * 2) + (contaSegundo_prd[3].innerHTML * 1)) / pesos_avalicao;

    }

    // Laço para realizar a conta da média ponderada das avaliações 
    for (i = 0; i < contaTerceiro_prd.length; i++){

        var terceiro_prdt = ((contaTerceiro_prd[0].innerHTML * 3) + (contaTerceiro_prd[1].innerHTML * 2)
                + (contaTerceiro_prd[2].innerHTML * 2) + (contaTerceiro_prd[3].innerHTML * 1)) / pesos_avalicao;

    }

    // Laço para realizar a conta da média ponderada das avaliações
    for (i = 0; i < contaQuarto_prd.length; i++){

        var quarto_prdt = ((contaQuarto_prd[0].innerHTML * 3) + (contaQuarto_prd[1].innerHTML * 2)
                + (contaQuarto_prd[2].innerHTML * 2) + (contaQuarto_prd[3].innerHTML * 1)) / pesos_avalicao;

    }

    // Variável para listar os produtos de acordo com a pontucao
    var produtos_notas = [{ nome: "Oreo", nota: primeiro_prdt.toFixed(1)},
            { nome: "Negresco", nota: segundo_prdt.toFixed(1)},
            { nome: "Trakinas", nota: terceiro_prdt.toFixed(1)},
            { nome: "Passatempo", nota: quarto_prdt.toFixed(1)}]
        .sort(function(a, b) {
        return a.nota > b.nota ? -1 : a.nota < b.nota ? 1 : 0;
    });

    // Setando a media ponderada no localStorage 
    localStorage.setItem("Produtos", JSON.stringify(produtos_notas));
}

function pontuacaoMedia (){
    
    // VARIÁVEL PARA ARMAZENAS A MEDIA PONDERADA DO LOCALSTORAGE
    var produtos = JSON.parse(localStorage.getItem("Produtos"));

        // Inserindo na tabela os dados da media ponderada
        document.getElementById("nome").innerHTML = "1- " + produtos[0].nome;
        document.getElementById("media").innerHTML = produtos[0].nota;

        document.getElementById("nome1").innerHTML = "2- " + produtos[1].nome;
        document.getElementById("media1").innerHTML = produtos[1].nota;

        document.getElementById("nome2").innerHTML = "3- " + produtos[2].nome;
        document.getElementById("media2").innerHTML = produtos[2].nota;

        document.getElementById("nome3").innerHTML = "4- " + produtos[3].nome;
        document.getElementById("media3").innerHTML = produtos[3].nota;
    
    // Variável para inserir a verificacao negativa das médias 
    var media_negativa = document.getElementsByClassName("posicao_media");

    // Laço para fazer a varredura das médias e identificar se alguma é negativa
    for (i = 0; i < media_negativa.length; i++){

        if(media_negativa[i].innerHTML < 6){
            media_negativa[i].style.color = "red";
        }
    }   
}    