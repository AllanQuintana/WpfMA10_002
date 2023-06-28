using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfMA10_002
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String[] ciudades = new String[50];
        int tope = 0;
        public MainWindow()
        {
            InitializeComponent();
            CargaArreglos();
        }

        private void CargaArreglos()
        {
            // Estructura archivo ciudad, nombre Ciudad
            FileStream f;
            StreamReader rf;
            string linea;
            try
            {
                f = new FileStream("ciudades.txt", FileMode.Open, FileAccess.Read);
                rf = new StreamReader(f);
                while(!rf.EndOfStream)
                {
                    linea = rf.ReadLine();
                    ciudades[tope] = linea;
                    tope++;
                }

                rf.Close();
                f.Close();
            }

            catch (IOException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }


        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            this.lsvCiudades.Items.Clear();
            for(int i = 0; i < tope; i++)
            {
                this.lsvCiudades.Items.Add(ciudades[i]);
            }
        }
    }
}
