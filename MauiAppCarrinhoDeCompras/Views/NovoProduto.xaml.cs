using MauiAppCarrinhoDeCompras.Models;
using System.Threading.Tasks;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void btn_salvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Insert(produto);
            await DisplayAlert("Produto Registrado", "O produto foi registrado em seu carrinho de compras!", "Ok");

            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
        }

    }
}