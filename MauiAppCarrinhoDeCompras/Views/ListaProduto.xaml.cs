using MauiAppCarrinhoDeCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        List<Produto> lista_temporaria = await App.Db.GetAll();

        lista_temporaria.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Somar_Clicked(object sender, EventArgs e)
    {
        try
        {
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total atual é {soma:C}";

            DisplayAlert("TOTAL", msg, "Ok");

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
        string digitado = e.NewTextValue;

        lista.Clear();

        List<Produto> lista_temp = await App.Db.Search(digitado);

        lista_temp.ForEach(i => lista.Add(i));
    }

    private void MenuItem_Remover_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem menuItem = (MenuItem)sender;                           // Obtem o MenuItem que disparou o evento de clique
            Produto produto_selecionado = (Produto)menuItem.BindingContext; // Obtem o produto selecionado através do contexto de ligação do MenuItem em nosso arquivo XAML
            lista.Remove(produto_selecionado);                              // Remove o produto da lista visível na tela
            App.Db.Delete(produto_selecionado.Id);                          // Remove o produto do banco de dados, utilizando o Id do produto selecionado
        }
        catch (Exception ex)
        {
            DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }
    }
}