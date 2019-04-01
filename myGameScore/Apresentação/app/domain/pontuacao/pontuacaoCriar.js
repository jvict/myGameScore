var api = 'http://localhost:44309/api/pontuacao/';

var titulo = document.querySelector('#titulo-pontuacao');

var elementosPontuacao = {
    data: document.querySelector('#data'),
    pontos: document.querySelector('#pontos'),
};

var query = location.search.slice(1); // Pega as informações enviadas após o ponto de interrogação na URL

var partes = query.split('&'); // Caso tenha mais de um parâmetro eles serão separados pelo caracter & - A função split quebra a string em arrays, conforme um caracter informado

var data = {}; // Cria um objeto que conterá as informações passadas pela url

partes.forEach(function (parte) { // percorre as informações passadas

    var chaveValor = parte.split('='); // quebra em array o nome da informação e seu valor
    var chave = chaveValor[0]; // o nome da informação fica na posição 0
    var valor = chaveValor[1]; // o valor da informação fica na posição 1
    data[chave] = valor; // Essa é uma notação de array, porém, como chave não é um número, isso acaba também funcioando para criar um objeto
});

console.log(data); 



document.querySelector('#form-pontuacao').addEventListener('submit', function (event) {

    event.preventDefault();

    var pontuacao = {
        data: elementosPontuacao.data.value,
        pontos: elementosPontuacao.pontos.value
    };

    
        inserirPontuacao(pontuacao);
    

});

function inserirPontuacao(pontuacao) {

    var request = new Request(api, {
        method: "POST",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(pontuacao)
    });

    fetch(request)
        .then(function (response) {
            console.log(response);
            if (response.status == 201) {
                alert("Pontuação inserido com sucesso");
                atribuirValorAoFormulario();
            } else {
		
		response.json().then(function(message){
			alert(message.error);
		});

            }
        })
        .catch(function (response) {
            console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });

}


function atribuirValorAoFormulario(Pontuacao = {}) {
    elementosPontuacao.nome.value = Pontuacao.nome || '';
    elementosPontuacao.cpf.value = Pontuacao.cpf || '';
    elementosPontuacao.historico.value = Pontuacao.historico || '';
    elementosPontuacao.nascimento.value = Pontuacao.nascimento || '';
}