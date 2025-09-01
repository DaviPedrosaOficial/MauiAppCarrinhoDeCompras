using MauiAppCarrinhoDeCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();      // Cria uma cole��o observ�vel para armazenar os produtos e atualizar a interface automaticamente 

    // <----------------------- Construtor da classe ------------------------->
    public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;

    }

    // <----------------------- Evento OnAppearing ------------------------->
    // Evento disparado quando a p�gina aparece na tela, fazendo a carga inicial dos produtos atrav�s do banco de dados armazenado em nosso App
    protected async override void OnAppearing()
    {
        try 
        {
            lista.Clear();                                              // Limpa a lista para evitar duplicidade de itens ao retornar para a p�gina

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

            string msg = $"O total atual � {soma:C}";                   // Formata a mensagem com o valor total em formato de moeda

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

            lst_produtos.IsRefreshing = true;                                   // Inicia o estado de atualiza��o da lista para indicar que uma busca est� em andamento, ou seja, uma notifica��o visual para o usu�rio que indica o processo de busca

            lista.Clear();                                                     // Limpa a lista atual para exibir os resultados da busca

            List<Produto> lista_temp = await App.Db.Search(digitado);          // Realiza a busca no banco de dados com o texto digitado

            lista_temp.ForEach(i => lista.Add(i));                             // Adiciona os produtos encontrados na lista vis�vel
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
        finally 
        {
            lst_produtos.IsRefreshing = false;                                  // Encerra o estado de atualiza��o da lista
        }
    }

    private async void MenuItem_Remover_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem menuItem = (MenuItem)sender;                           // Obtem o MenuItem que disparou o evento de clique
            Produto produto_selecionado = (Produto)menuItem.BindingContext; // Obtem o produto selecionado atrav�s do contexto de liga��o do MenuItem em nosso arquivo XAML

            // Alerta de confirma��o para remo��o do produto
            bool confirma = await DisplayAlert("Confirma��o", $"Deseja remover o produto {produto_selecionado.Descricao}?", "Sim", "N�o"); 

            if (!confirma) return;                                          // Se o usu�rio n�o confirmar, sai do m�todo

            // Remo��o do produto, caso o usu�rio confirme
            lista.Remove(produto_selecionado);                              // Remove o produto da lista vis�vel na tela
            await App.Db.Delete(produto_selecionado.Id);                          // Remove o produto do banco de dados, utilizando o Id do produto selecionado
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
    }

    // Evento disparado quando um item da lista � selecionado (redicionar� para a p�gina de edi��o do produto)
    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto produto_selecionado = (Produto)e.SelectedItem;          // Obtem o produto selecionado na lista

            Navigation.PushAsync(new Views.EditarProduto()
                {
                    BindingContext = produto_selecionado                     // Passa o produto selecionado como contexto de liga��o para a p�gina de edi��o
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
            lista.Clear();                                              // Limpa a lista para evitar duplicidade de itens ao retornar para a p�gina

            List<Produto> lista_temporaria = await App.Db.GetAll();

            lista_temporaria.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
        finally
        {
            lst_produtos.IsRefreshing = false;                           // Encerra o estado de atualiza��o da lista
        }
    }
}