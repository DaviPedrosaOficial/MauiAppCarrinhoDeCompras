using MauiAppCarrinhoDeCompras.Models;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Salvar_Clicked(object sender, EventArgs e)
    {
		try 
		{
			Produto produto = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

		}
		catch (Exception ex)
		{
			DisplayAlert("Ocorreu um erro!", "Erro apresentado: " + ex.Message, "Ok");
		}
    }
}