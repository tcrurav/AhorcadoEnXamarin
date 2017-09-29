using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhorcadoEnXamarin
{
    public partial class MainPage : ContentPage
    {
        readonly string[] ALFABETO = { "A", "B", "C", "D", "E", "F", "G",
                                        "A", "B", "C", "D", "E", "F", "G",
                                        "A", "B", "C", "D", "E", "F", "G",
                                        "A", "B", "C", "D", "E", "F", "*"};
        int numFallos = 0;
        readonly int MAX_FALLOS = 6;
        Button[] letrasPulsadas;

        public MainPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            letrasPulsadas = new Button[MAX_FALLOS];
            imageAhorcado.Source = ImageSource.FromResource("AhorcadoEnXamarin.img.0.png");
            for(int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 7; columna++)
                {
                    Button boton = new Button
                    {
                        Text = ALFABETO[fila * 7 + columna]
                    };
                    boton.Clicked += Boton_Clicked;
                    gridBotonera.Children.Add(boton, columna, fila);
                }
            }   
        }

        private void Boton_Clicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == "*")
            {
                Reiniciar();
            }

            if(numFallos < MAX_FALLOS)
            {
                numFallos++;
                imageAhorcado.Source = ImageSource.FromResource("AhorcadoEnXamarin.img." + numFallos + ".png");

                ((Button)sender).BackgroundColor = Color.Red;
            } else
            {
                Reiniciar();
            }
            
        }

        private void Reiniciar()
        {
            numFallos = 0;
            imageAhorcado.Source = ImageSource.FromResource("AhorcadoEnXamarin.img." + numFallos + ".png");
            for(int i = 0; i < MAX_FALLOS; i++)
            {
                letrasPulsadas[i].BackgroundColor = Color.Default;
            }
        }
    }
}
