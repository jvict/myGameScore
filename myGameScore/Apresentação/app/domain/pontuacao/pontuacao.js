var api = 'http://localhost:44309/api/pontuacao/';

var tabela = document.querySelector('#pontuacao');

obterTodos();

function update(pontuacao) {
    tabela.innerHTML = template(pontuacao);
}

function template(pontuacao = []) {
    return `
    <table class="table table-hover table-bordered">
        <thead>
            <tr>
                <th>#</th>
                <th>Jogos Disputados</th>
                <th>Total de Pontos na Temporada</th>
                <th>Media de Pontos por Jogo</th>
                <th>Maior Pontuação em um jogo</th>
                <th>Menor Pontuação em um jogo</th>
                <th>Quantidade de vezes que bateu o próprio recorde</th>
            </tr>
        </thead>
        <tbody>
        ${
            pontuacao.map(function(pontuacao){
                return `
                    <tr>
                        <td>10</td>
                        <td>105</td>
                        <td>18</td>
                        <td>25</td>
                        <td>9</td>
                        <td>2</td>
                        
                    </tr>
                `;
            }).join('')
        }
        </tbody>
    </table>
    `;
}

function obterTodos() {

    var request = new Request(api, {
        method: "GET",
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });

    fetch(request)
        .then(function (response) {
            
            if (response.status == 200) {
                response.json()
                    .then(function (pontuacao) {
                        update(pontuacao);
                    });
            } else {
                alert("Ocorreu um erro ao obter os pontuacao");
            }
        })
        .catch(function (response) {
           
            alert("Desculpe, ocorreu um erro no servidor.");
        });

}
