using MauiAppCarrinhoDeCompras.Models;

namespace MauiAppCarrinhoDeCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void btn_salvar_Clicked(object sender, EventArgs e)
    {
		Produto produto_anexado = (Produto)BindingContext;

		Produto produto = new Produto
		{
			Id = produto_anexado.Id,
			Descricao = txt_descricao.Text,
			Quantidade = Convert.ToDouble(txt_quantidade.Text),
			Preco = Convert.ToDouble(txt_preco.Text)
		};

		await App.Db.Update(produto);
		await DisplayAlert("Sucesso", "Produto atualizado com sucesso!", "Ok");
		await Navigation.PopAsync();
    }
}