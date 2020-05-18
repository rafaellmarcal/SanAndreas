# Take - SanAndreas
Sistema desenvolvido para atender os correios da cidade de San Andreas,

# Instalação e Execução
Para fazer utilização do sistema basta realizar o download do projeto ou clonar o repositório.
Feito isso, é necessário observar se a porta *:5080 da máquina local está sendo utilizada. Se a porta estiver sendo utilizada,
é possível alterar a porta que o sistema utiliza alterando a seção "applicationUrl": "http://localhost:5080" do arquivo launchSettings.json
que se encontra ao expandir o item 'Properties' dentro do projeto. 

# Objetivo
O sistema foi desenvolvido para atender a demanda dos correios de San Anreas.
No sistema é possível realizar o upload do arquivo .txt com os trechos atualizados, que os correios atenderão, por meio da tela de 'Atualização de Trechos' que é acessível pelo menu.
Outra funcionalidade disponível é o cálculo da melhor rota para as encomendas que devem ser entregues. Na tela de 'Encomendas', que é também acessível pelo menu,
é possível realizar o upload do arquivo .txt das encomendas, que após o cálculo das rotas, com base nos trechos informados na tela de 'Atualização de Trechos',
disponibilizará um arquivo .txt com as melhores rotas para cada encomenda. 
O cálculo é feito partindo da cidade de origem da encomenda até encontrar o trecho que ligue com a cidade de destino.
Quando há uma encomenda que não é possível ser entregue, por não ter trechos que se interliguem e cheguem a cidade de destino, a encomenda é retornada com a flag 'N/D' (Não Disponível).

Encomenda com possibilidade de entrega: <br/>
Ex.: <br/>
  encomendas.txt: SF BC <br/>
  rotas.txt: SF BC 3 <br/>

Encomenda sem possibilidade de entrega: <br/>
Ex.: <br/>
  encomendas.txt: SF BC <br/>
  rotas.txt: SF BC N/D
