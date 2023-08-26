
document.getElementById('btn').onclick = geraNome;



function geraNome(){
    var nome1 = document.getElementById('name').value;
    var nome2 = document.getElementById('sobrename').value;

    document.getElementById('codigo-js').innerHTML = nome1 + " " + nome2;
}