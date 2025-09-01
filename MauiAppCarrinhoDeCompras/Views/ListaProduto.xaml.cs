using MauiAppCarrinhoDeCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();      // Cria uma coleção observável para armazenar os produtos e atualizar a interface automaticamente 

    // <----------------------- Construtor da classe ------------------------->
    public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;

    }

    // <----------------------- Evento OnAppearing ------------------------->
    // Evento disparado quando a página aparece na tela, fazendo a carga inicial dos produtos através do banco de dados armazenado em nosso App
    protected async override void OnAppearing()
    {
        try 
        {
            lista.Clear();                                              // Limpa a lista para evitar duplicidade de itens ao retornar para a página

            List<Produto> lista_temporaria = await App.Db.GetAll();

            lista_temporaria.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
    }

    // <----------------------- Eventos de clique ------------------------->
    private void ToolbarItem_Somar_Clicked(object sender, EventArgs e)
    {
        try
        {
            double soma = lista.Sum(i => i.Total);                      // Calcula a soma total dos produtos na lista

            string msg = $"O total atual é {soma:C}";                   // Formata a mensagem com o valor total em formato de moeda

            DisplayAlert("TOTAL", msg, "Ok");                           // Exibe um alerta com o total calculado

        }
        catch (Exception ex)
        {
            DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        };
    }

    private void ToolbarItem_Adicionar_Clicked_1(object sender, EventArgs e)
    {
        try 
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message , "Ok");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try 
        {
            string digitado = e.NewTextValue;                                  // Obtem o texto digitado no campo de busca

            lst_produtos.IsRefreshing = true;                                   // Inicia o estado de atualização da lista para indicar que uma busca está em andamento, ou seja, uma notificação visual para o usuário que indica o processo de busca

            lista.Clear();                                                     // Limpa a lista atual para exibir os resultados da busca

            List<Produto> lista_temp = await App.Db.Search(digitado);          // Realiza a busca no banco de dados com o texto digitado

            lista_temp.ForEach(i => lista.Add(i));                             // Adiciona os produtos encontrados na lista visível
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
        finally 
        {
            lst_produtos.IsRefreshing = false;                                  // Encerra o estado de atualização da lista
        }
    }

    private async void MenuItem_Remover_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem menuItem = (MenuItem)sender;                           // Obtem o MenuItem que disparou o evento de clique
            Produto produto_selecionado = (Produto)menuItem.BindingContext; // Obtem o produto selecionado através do contexto de ligação do MenuItem em nosso arquivo XAML

            // Alerta de confirmação para remoção do produto
            bool confirma = await DisplayAlert("Confirmação", $"Deseja remover o produto {produto_selecionado.Descricao}?", "Sim", "Não"); 

            if (!confirma) return;                                          // Se o usuário não confirmar, sai do método

            // Remoção do produto, caso o usuário confirme
            lista.Remove(produto_selecionado);                              // Remove o produto da lista visível na tela
            await App.Db.Delete(produto_selecionado.Id);                          // Remove o produto do banco de dados, utilizando o Id do produto selecionado
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
    }

    // Evento disparado quando um item da lista é selecionado (redicionará para a página de edição do produto)
    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto produto_selecionado = (Produto)e.SelectedItem;          // Obtem o produto selecionado na lista

            Navigation.PushAsync(new Views.EditarProduto()
                {
                    BindingContext = produto_selecionado                     // Passa o produto selecionado como contexto de ligação para a página de edição
                });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
    }

    private async void lst_produtos_Refreshing(object sender, EventArgs e)
    {
        try
        {
            lista.Clear();                                              // Limpa a lista para evitar duplicidade de itens ao retornar para a página

            List<Produto> lista_temporaria = await App.Db.GetAll();

            lista_temporaria.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
        finally
        {
            lst_produtos.IsRefreshing = false;                           // Encerra o estado de atualização da lista
        }
    }
}