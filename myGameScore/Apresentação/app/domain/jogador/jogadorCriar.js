var api = 'http://localhost:44309/api/Jogador';


var titulo = document.querySelector('#titulo-medico');
var especialidade = document.querySelector('#especialidade');
var form1 = document.getElementById("form-jogador");

var elementosJogador= {
    nomeJogador: document.querySelector('#nomeJogador'),
    timeJogador: document.querySelector('#timeJogador'),
    emailJogador: document.querySelector('#emailJogador'),
    senhaJogador: document.querySelector('#senhaJogador')
};

var query = location.search.slice(1); 

var partes = query.split('&'); 

var data = {}; 

partes.forEach(function (parte) { // percorre as informações passadas

    var chaveValor = parte.split('='); 
    var chave = chaveValor[0]; 
    var valor = chaveValor[1]; 
    data[chave] = valor; 
});

console.log(data); 



document.querySelector('#form-jogador').addEventListener('submit', function (event) {

    event.preventDefault();

    var jogador = {
        NomeJogador: elementosJogador.nomeJogador,
        TimeJogador: elementosJogador.timeJogador,
        EmailJogador: elementosJogador.emailJogador,
        senhaJogador: elementosJogador.senhaJogador
    };

    
   
        inserirJogador(jogador);
    

});

function inserirJogador(jogador) {

    var request = new Request(api, {
        method: "POST",
        headers: new Headers({
            'Content-Type': 'application/json',
           
        }),
        body: JSON.stringify(jogador)
    });

    fetch(request)
        .then(function (response) {
            console.log(response);
            if (response.status == 201) {
                alert("Jogador inserido com sucesso");
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

function alterarJogador(idJogador, jogador) {

    var request = new Request(api + idJogador, {
        method: "PUT",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(jogador)
    });

    fetch(request)
        .then(function (response) {
            // console.log(response);
            if (response.status == 202) {
                alert("Jogador alterado com sucesso");
                window.location.href="jogador.html";
            } else {
		response.json().then(function(message){
			alert(message.error);
		});
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });

}

function obterJogador(idJogador) {
    var request = new Request(api + idJogador, {
        method: "GET",
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });

    fetch(request)
        .then(function (response) {
            // console.log(response);
            if (response.status == 200) {
                response.json()
                .then(function(jogador){
                    atribuirValorAoFormulario(jogador);
                    obterEspecialidades(jogador.idEspecialidade);
                });
            } else {
                alert("Ocorreu um erro ao obter o Jogador");
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });
}




// masks
/*$(document).ready(function(){
    $('.cpf').mask('000.000.000-00');
    $('.crm').mask('000000/AA');
    $('.senha').mask('AAAAAAAA');
    $('.data').mask('00-00-0000');
    $('.time').mask('00:00:00');
    $('.cep').mask('00000-000');
    $('.telpes').mask('(00)00000-0000');
    $('.telres').mask('(00)0000-0000');    
    $('.valor').mask('000.000.000,00');
  });*/

