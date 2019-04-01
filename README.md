# myGameScore
MyGameScore é uma aplicação Web desenvolvida com uma Api utilizando como linguagem base o C#, .net core 2.2.

# Para que serve myGameScore ?
Com o myGameScore o jogador poderá inserir os pontos que ele fez em um jogo naquela determinada data, assim terá como ver estatisticas como qual foi a sua maior pontuação.

#  Dependências
.Net Core 2.2

# Como rodar na sua máquina.
Instale todas as dependências e clone o projeto em sua maquina.

Banco de dados:
Execute o scripts de bancos de dados disponíveis na pasta "dataBaseScripts" na ordem indicada pelo sufixo do arquivo.

API:
Abra a solução usando o Visual Studio (myGameScore.sln).
Defina o projeto da api (myGameScore.Application.WebAPI) como projeto inicialização.
Defina a url de inicio como "swagger":

Botão direito no projeto da api > Propriedades > Debug > Lauch browser: "swagger".

Defina a porta de sua preferencia que sera usada para a API:

Botão direito no projeto da api > Propriedades > Debug > App Url: "http://localhost:44309".

Assim você já deve conseguir usar o swagger para utilizar a API e realizar testes.

Para rodar página dirija-se até o index.html que pode ser encontrado na pasta Apresentacao


