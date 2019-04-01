var api = 'http://localhost:44309/api/login/';

var elementosForm = {
    email: document.querySelector('#Email'),
    senha: document.querySelector('#senha')
};

console.log("testestes");
document.querySelector('#form-login')
    .addEventListener('submit', function (event) {

        event.preventDefault();

        var obj = {
            email: elementosForm.email.value,
            senha: elementosForm.senha.value
        };
        console.log(obj);

        var teste = autenticarUsuario(obj)
        if(teste != null){
            window.location.href="../pontuacao/pontuacaoCriar.html";
        }else{
            console.log("error")
        }

        

    });

function autenticarUsuario(obj){
    
    obterLogin(obj);
    
}

function obterLogin() {
    var request = new Request(api + elementosForm.email.value +"/"+ elementosForm.senha.value, {
        method: "GET",
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });

    fetch(request)
        .then(function (response) {
            console.log(response);
            if (response.status == 200) {
                response.json()
                .then(function(login){
                    
                });
            } else {
                alert("Ocorreu um erro ao obter o médico");
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });
}