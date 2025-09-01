using MauiAppCarrinhoDeCompras.Helpers;
using System.Globalization;

namespace MauiAppCarrinhoDeCompras
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper _db;                                            // Instância estática do banco de dados SQLite

        public static SQLiteDataBaseHelper Db 
        {
            get 
            {
                if (_db == null) 
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(                                  // Parametro para obter o caminho do diretório local do aplicativo, independente da plataforma
                            Environment.SpecialFolder.LocalApplicationData),        // LocalApplicationData: Diretório local do aplicativo
                                "banco_SQLite_Minhas_Compras.db3");                 // Nome do arquivo do banco de dados, que será criado se não existir

                    _db = new SQLiteDataBaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto())
            {
                BarBackgroundColor = Colors.DarkGray,
                BarTextColor = Colors.Black
            };
        }
    }
}