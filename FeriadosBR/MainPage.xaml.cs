using FeriadosBR.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FeriadosBR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Fawait rame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Feriado feriado { get; set; }
        private ColecaoFeriado listaFeriadosDoAno { get; set; }
        
        public MainPage()
        {

            this.InitializeComponent();
            
            DateTime data = DateTime.Now;

            FeriadoFactory feriadoFactory = new FeriadoFactory();
            feriado = feriadoFactory.GetProxFeriado();
            listaFeriadosDoAno = feriadoFactory.GetFeriadosAno(data.Year);


            txtDias.Text = feriado.data.intervalo.ToString();
            txtNomeFeriado.Text = feriado.data.nome.ToString();
            txtDiaSemanaFeriado.Text = feriado.data.diaSemanaW.ToString();
            txtDescricaoFeriado.Text = feriado.data.descricao.ToString();
            txtDataFeriado.Text = Convert.ToDateTime(feriado.data.data).ToString("dd");
            
            listFeriados.ItemsSource = listaFeriadosDoAno.data;
        }

       // private void Data_Loaded(object sender, RoutedEventArgs e)
        //{
          //  var listView = (ListView)sender;
            //listView.ItemsSource = listaFeriadosDoAno;
        //}

        

    }
}

