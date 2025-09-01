# Aplica��o de Carrinho de compras em .NET MAUI

## Descri��o do Projeto

 Projeto desenvolvido em C# utilizando sua framework .MAUI (desenvolvimento
de software desktop & mobile), e o banco de dados SQLite.

 O projeto tem como foco o desenvolvimento de habilidades em .NET MAUI, incluindo
a integra��o de dados recebidos com o banco de dado, manipulando-os atrav�s do CRUD.

 Al�m disso, aproveitei a oportunidade para testar diferentes mecanismos do XAML,
 como DataTemplate, CollectionView, Styles, Triggers, entre outros.

 O projeto � uma aplica��o simples de carrinho de compras, onde o usu�rio pode adicionar,
 remover e visualizar produtos no carrinho. Para isso, o projeto conta com alguns bot�es
que auxiliar�o o usu�rio a interagir com a aplica��o.

 Importante ressaltar que o projeto � apenas um prot�tipo, e n�o possui funcionalidades, mas
o mesmo conta com uma interface amig�vel e intuitiva, e diversos coment�rios no c�digo para
facilitar o entendimento do funcionamento da aplica��o.

### Requisitos

 <ul>
   <li>IDE de sua escolha: Visual Studio Community, JetRiders, ...</li>
   <li>SDK .NET: Utilizado no projeto � a 9.0. N�o possui o .NET ainda? <a href="https://learn.microsoft.com/pt-br/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio"     target="blank">Instalar SDK</a></li>
   <li>Extens�o do .NET MAUI: Caso n�o tenha instalado, <a href="https://learn.microsoft.com/pt-br/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio" target="blank">clique aqui</a></li>
 </ul>

 ### Instru��es de uso do projeto

 O projeto, conta com uma MainPage, que ser� a lista de compras de seu carrinho,
e no topo direito superior de sua tela, voc� encontrar� 2 bot�es:
- O primeiro bot�o (Somar), ao ser clicado, somar� todos os valores de seu
carrinho, e exibir� o valor total em um DisplayAlert.
- O segundo bot�o (Adicionar), ao ser clicado, abrir� uma nova p�gina na qual voc� poder�
criar o produto que deseja adicionar ao carrinho, e salvar o mesmo no bot�o "Salvar".

 Al�m disso, na lista de seu carrinho, ser� poss�vel clicar em cima de um item para
alter�-lo, ou clicar e segurar para excluir o item do carrinho.

### L�gica do projeto

 Al�m da estrutura base de uma aplica��o em MAUI, o projeto conta com mais alguns arqivos de estrutura simples, sendo eles:

 - Helpers: Onde esta a classe que auxilia na comunica��o com o banco de dados (SQLiteDataBaseHelper.cs), nesse arquivo encontraremos
o CRUD (Create, Read, Update, Delete) de nossa aplica��o. Criando os metodos necess�rios para manipular os dados do banco.

 - Models: Onde se encontra nossa classe produto, que ser� a estrutura base de nosso banco de dados, permitindo criar os produtos baseados
em nossa regra de neg�cio.

 - Views: Onde est�o as p�ginas em que o nosso usu�rio ir� interagir, sendo elas a ListaProduto (p�gina principal), EditarProduto e NovoProduto.

 ### Observa��o

 Outro ponto interessante de nosso projeto se diz respeito a sua portabilidade, uma vez que o mesmo foi desenvolvido utilizando o .MAUI,
ele poder� ser executado em diversas plataformas, como Windows, MacOS, Android e iOS, sem a necessidade de altera��es no c�digo. Para isso,
basta selecionar a plataforma desejada na IDE e executar o projeto. 

Para isso, ser� necess�rio ter o emulador da plataforma desejada instalado e configurado em sua m�quina, ent�o pe�o para que voc� busque saber
como fazer o mesmo em sua IDE, pois n�o consegui encontrar um video base, para que pudesse linkar aqui, mas caso no futuro eu encontre, posso deix�-lo aqui.