using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LazarBruno_Blathy_cafe
{
    public partial class MainWindow
    {
        int latteKeszlet;
        int espressoKeszlet;
        int macchiatoKeszlet;
        int tejKeszlet;
        int mandulaKeszlet;
        int laktozmentesKeszlet;
        int kockaCukorKeszlet;
        int barnaCukorKeszlet;
        int edesitoCukorKeszlet;

        string valasztottKave = "";
        int kaveAr = 0;
        string valasztottTej = "";

        bool kaveKivalasztva = false;

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            KeszletekBeallitasa();
        }

        private void KeszletekBeallitasa()
        {
            latteKeszlet = random.Next(3, 16);
            espressoKeszlet = random.Next(3, 16);
            macchiatoKeszlet = random.Next(3, 16);

            tejKeszlet = random.Next(1, 4);
            mandulaKeszlet = random.Next(1, 4);
            laktozmentesKeszlet = random.Next(1, 4);

            kockaCukorKeszlet = random.Next(12, 31);
            barnaCukorKeszlet = random.Next(12, 31);
            edesitoCukorKeszlet = random.Next(12, 31);
        }

        private void KaveGomb_Click(object sender, RoutedEventArgs e)
        {
            Button gomb = (Button)sender;

            if (gomb.Name == "Latte")
            {
                if (latteKeszlet <= 0)
                {
                    UzenetMutat("A Latte-ból elfogyott!");
                    return;
                }
                valasztottKave = "Latte";
                kaveAr = 250;
            }
            else if (gomb.Name == "Espresso")
            {
                if (espressoKeszlet <= 0)
                {
                    UzenetMutat("Az Espresso-ból elfogyott!");
                    return;
                }
                valasztottKave = "Espresso";
                kaveAr = 180;
            }
            else if (gomb.Name == "Macchiato")
            {
                if (macchiatoKeszlet <= 0)
                {
                    UzenetMutat("A Cappuccino-ból elfogyott!");
                    return;
                }
                valasztottKave = "Cappuccino";
                kaveAr = 220;
            }

            kaveKivalasztva = true;

            Tej.IsEnabled = true;
            MandulaTej.IsEnabled = true;
            Laktozmentes.IsEnabled = true;

            sliderKocka.IsEnabled = true;
            sliderBarna.IsEnabled = true;
            sliderEdes.IsEnabled = true;

            StatusFrissites();
        }

        private void TejGomb_Click(object sender, RoutedEventArgs e)
        {
            if (!kaveKivalasztva)
            {
                return;
            }

            Button gomb = (Button)sender;

            if (gomb.Name == "Tej")
            {
                if (tejKeszlet <= 0)
                {
                    UzenetMutat("A tejből elfogyott!");
                    return;
                }
                valasztottTej = "Tej";
            }
            else if (gomb.Name == "MandulaTej")
            {
                if (mandulaKeszlet <= 0)
                {
                    UzenetMutat("A mandula tejből elfogyott!");
                    return;
                }
                valasztottTej = "Mandula Tej";
            }
            else if (gomb.Name == "Laktozmentes")
            {
                if (laktozmentesKeszlet <= 0)
                {
                    UzenetMutat("A laktózmentes tejből elfogyott!");
                    return;
                }
                valasztottTej = "Laktózmentes Tej";
            }

            StatusFrissites();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!kaveKivalasztva) return;

            Slider slider = (Slider)sender;
            int ertek = (int)slider.Value;

            if (slider.Name == "sliderKocka")
            {
                if (ertek > kockaCukorKeszlet)
                {
                    slider.Value = kockaCukorKeszlet;
                    ertek = kockaCukorKeszlet;
                }
                Kocka.Text = ertek + " db";
            }
            else if (slider.Name == "sliderBarna")
            {
                if (ertek > barnaCukorKeszlet)
                {
                    slider.Value = barnaCukorKeszlet;
                    ertek = barnaCukorKeszlet;
                }
                Barna.Text = ertek + " db";
            }
            else if (slider.Name == "sliderEdes")
            {
                if (ertek > edesitoCukorKeszlet)
                {
                    slider.Value = edesitoCukorKeszlet;
                    ertek = edesitoCukorKeszlet;
                }
                Edes.Text = ertek + " db";
            }
        }

        private void Fizetes_Click(object sender, RoutedEventArgs e)
        {
            if (!kaveKivalasztva)
            {
                UzenetMutat("Először válassz kávét!");
                return;
            }

            bool hibavan = false;

            if (valasztottKave == "Latte" && latteKeszlet <= 0)
            {
                hibavan = true;
            }
            if (valasztottKave == "Espresso" && espressoKeszlet <= 0)
            {
                hibavan = true;
            }
            if (valasztottKave == "Macchiato" && macchiatoKeszlet <= 0)
            {
                hibavan = true;
            }
            
            if (valasztottTej == "Tej" && tejKeszlet <= 0)
            {
                hibavan = true;
            }
            if (valasztottTej == "Mandula Tej" && mandulaKeszlet <= 0)
            {
                hibavan = true;
            }
            if (valasztottTej == "Laktózmentes Tej" && laktozmentesKeszlet <= 0)
            {
                hibavan = true;
            }

            int kocka = (int)sliderKocka.Value;
            int barna = (int)sliderBarna.Value;
            int edes = (int)sliderEdes.Value;

            if (kocka > kockaCukorKeszlet)
            {
                hibavan = true;
            }
            if (barna > barnaCukorKeszlet)
            {
                hibavan = true;
            }
            if (edes > edesitoCukorKeszlet)
            {
                hibavan = true;
            }

            if (hibavan)
            {
                UzenetMutat("Valamelyik termékből nincs elég készlet!");
            }

            if (valasztottKave == "Latte")
            {
                latteKeszlet = latteKeszlet - 1;
            }
            if (valasztottKave == "Espresso")
            {
                espressoKeszlet = espressoKeszlet - 1;
            }
            if (valasztottKave == "Macchiato")
            {
                macchiatoKeszlet = macchiatoKeszlet - 1;
            }

            if (valasztottTej == "Tej")
            {
                tejKeszlet = tejKeszlet - 1;
            }
            if (valasztottTej == "Mandula Tej")
            {
                mandulaKeszlet = mandulaKeszlet - 1;
            }
            if (valasztottTej == "Laktózmentes Tej")
            {
                laktozmentesKeszlet = laktozmentesKeszlet - 1;
            }

            kockaCukorKeszlet = kockaCukorKeszlet - kocka;
            barnaCukorKeszlet = barnaCukorKeszlet - barna;
            edesitoCukorKeszlet = edesitoCukorKeszlet - edes;

            UzenetMutat("A fizetés sikeres volt, a termék ára " + kaveAr + " Ft. Viszont látásra!");

            UjraKezdes();
        }

        private void StatusFrissites()
        {
            string szoveg = "Kiválasztva: " + valasztottKave;
            if (valasztottTej != "")
            {
                szoveg += " + " + valasztottTej;
            }

            Statusz.Text = szoveg;
            Ar.Text = "Teljes ár: " + kaveAr + " Ft";
        }

        private void UjraKezdes()
        {
            valasztottKave = "";
            valasztottTej = "";
            kaveAr = 0;
            kaveKivalasztva = false;

            sliderKocka.Value = 0;
            sliderBarna.Value = 0;
            sliderEdes.Value = 0;

            Kocka.Text = "0 db";
            Barna.Text = "0 db";
            Edes.Text = "0 db";

            Tej.IsEnabled = false;
            MandulaTej.IsEnabled = false;
            Laktozmentes.IsEnabled = false;

            sliderKocka.IsEnabled = false;
            sliderBarna.IsEnabled = false;
            sliderEdes.IsEnabled = false;

            Statusz.Text = "Válassz egy kávét!";
            Ar.Text = "Teljes ár: 0 Ft";
        }

        private void UzenetMutat(string uzenet)
        {
            Uzenet.Text = uzenet;
            Uzenet.Visibility = Visibility.Visible;
            UzenetOK.Visibility = Visibility.Visible;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Uzenet.Visibility = Visibility.Hidden;
            UzenetOK.Visibility = Visibility.Hidden;
        }
    }
}