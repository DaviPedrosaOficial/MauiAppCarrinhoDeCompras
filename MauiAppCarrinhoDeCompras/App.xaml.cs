using MauiAppCarrinhoDeCompras.Helpers;

namespace MauiAppCarrinhoDeCompras
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper _db;

        public static SQLiteDataBaseHelper Db 
        {
            get 
            {
                if (_db == null) 
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(      // Parametro para obter o caminho do diretório local do aplicativo, independente da plataforma
                            Environment.SpecialFolder.LocalApplicationData),        // LocalApplicationData: Diretório local do aplicativo
                                "banco_SQLite_Minhas_Compras.db3");                 // Nome do arquivo do banco de dados

                    _db = new SQLiteDataBaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}