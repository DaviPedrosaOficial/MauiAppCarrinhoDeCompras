# Aplicação de Carrinho de compras em .NET MAUI

## Descrição do Projeto

 Projeto desenvolvido em C# utilizando sua framework .MAUI (desenvolvimento
de software desktop & mobile), e o banco de dados SQLite.

 O projeto tem como foco o desenvolvimento de habilidades em .NET MAUI, incluindo
a integração de dados recebidos com o banco de dado, manipulando-os através do CRUD.

 Além disso, aproveitei a oportunidade para testar diferentes mecanismos do XAML,
 como DataTemplate, CollectionView, Styles, Triggers, entre outros.

 O projeto é uma aplicação simples de carrinho de compras, onde o usuário pode adicionar,
 remover e visualizar produtos no carrinho. Para isso, o projeto conta com alguns botões
que auxiliarão o usuário a interagir com a aplicação.

 Importante ressaltar que o projeto é apenas um protótipo, e não possui funcionalidades, mas
o mesmo conta com uma interface amigável e intuitiva, e diversos comentários no código para
facilitar o entendimento do funcionamento da aplicação.

### Requisitos

 <ul>
   <li>IDE de sua escolha: Visual Studio Community, JetRiders, ...</li>
   <li>SDK .NET: Utilizado no projeto é a 9.0. Nâo possui o .NET ainda? <a href="https://learn.microsoft.com/pt-br/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio"     target="blank">Instalar SDK</a></li>
   <li>Extensão do .NET MAUI: Caso não tenha instalado, <a href="https://learn.microsoft.com/pt-br/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio" target="blank">clique aqui</a></li>
 </ul>

 ### Instruções de uso do projeto

 O projeto, conta com uma MainPage, que será a lista de compras de seu carrinho,
e no topo direito superior de sua tela, você encontrará 2 botões:
- O primeiro botão (Somar), ao ser clicado, somará todos os valores de seu
carrinho, e exibirá o valor total em um DisplayAlert.
- O segundo botão (Adicionar), ao ser clicado, abrirá uma nova página na qual você poderá
criar o produto que deseja adicionar ao carrinho, e salvar o mesmo no botão "Salvar".

 Além disso, na lista de seu carrinho, será possível clicar em cima de um item para
alterá-lo, ou clicar e segurar para excluir o item do carrinho.

### Lógica do projeto

 Além da estrutura base de uma aplicação em MAUI, o projeto conta com mais alguns arqivos de estrutura simples, sendo eles:

 - Helpers: Onde esta a classe que auxilia na comunicação com o banco de dados (SQLiteDataBaseHelper.cs), nesse arquivo encontraremos
o CRUD (Create, Read, Update, Delete) de nossa aplicação. Criando os metodos necessários para manipular os dados do banco.

 - Models: Onde se encontra nossa classe produto, que será a estrutura base de nosso banco de dados, permitindo criar os produtos baseados
em nossa regra de negócio.

 - Views: Onde estão as páginas em que o nosso usuário irá interagir, sendo elas a ListaProduto (página principal), EditarProduto e NovoProduto.

 ### Observação

 Outro ponto interessante de nosso projeto se diz respeito a sua portabilidade, uma vez que o mesmo foi desenvolvido utilizando o .MAUI,
ele poderá ser executado em diversas plataformas, como Windows, MacOS, Android e iOS, sem a necessidade de alterações no código. Para isso,
basta selecionar a plataforma desejada na IDE e executar o projeto. 

Para isso, será necessário ter o emulador da plataforma desejada instalado e configurado em sua máquina, então peço para que você busque saber
como fazer o mesmo em sua IDE, pois não consegui encontrar um video base, para que pudesse linkar aqui, mas caso no futuro eu encontre, posso deixá-lo aqui.