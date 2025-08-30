namespace MauiAppCarrinhoDeCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Somar_Clicked(object sender, EventArgs e)
    {
        
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
}