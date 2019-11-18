using AplicativoDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoDespesas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Database database = new Database();

            this.FindByName<ListView>("ListDespesas").ItemsSource = database.Conexao().Table<Despesa>().ToList();
        }

        public void Pagar_Clicked(object sender, EventArgs e)
        {
            Button botao = ((Button)sender);
           
            Database database = new Database();

            database.Conexao().Delete(botao.Id);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            var NewItemPage = new NewItemPage();
            await Navigation.PushModalAsync(NewItemPage);
        }
    }
}