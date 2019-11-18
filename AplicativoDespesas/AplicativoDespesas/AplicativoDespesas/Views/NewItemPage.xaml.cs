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
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            Database database = new Database();

        }

        public void Save_Clicked(object sender, EventArgs args)
        {
            Entry entryNome = this.FindByName<Entry>("EntryNome");
            Entry entryValor = this.FindByName<Entry>("EntryValor");
            double tempValor = Convert.ToDouble(entryValor.Text);
            DatePicker datePicker = this.FindByName<DatePicker>("DataPicker");
            Entry entryParcelas = this.FindByName<Entry>("EntryParcelas");
            double tempParcelas = Convert.ToDouble(entryParcelas.Text);

            Despesa despesa = new Despesa();
            Database database = new Database();

            if (tempParcelas >= 2)
            {
                tempValor = Math.Round((tempValor / tempParcelas), 2);
                for (int i = 0; i < tempParcelas; i++)
                {
                    despesa = new Despesa
                    {
                        nome = entryNome.Text,
                        valor = tempValor,
                        data = datePicker.Date,
                        parcelas = (i + 1) + "/" + tempParcelas              
                    };
                    database.Conexao().Insert(despesa);
                }
            }
            else
            {
                despesa = new Despesa
                {
                    nome = entryNome.Text,
                    valor = Convert.ToDouble(entryValor.Text),
                    data = datePicker.Date,
                    parcelas = "1/1"
                };
            }

            database.Conexao().Insert(despesa);
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}