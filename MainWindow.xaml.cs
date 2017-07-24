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


namespace zadanie_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
               InitializeComponent();
           bindowanie();
            bindowaniePC();
        }
        public List<Produkt> lista1 { get; set; } 
        public List<KAT> lista2 { get; set; }

        private void bindowanie()
        {



            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            var items = db.Produkt.ToList();
            lista1 = items;
            DataContext = lista1;
            doproduktow.ItemsSource = lista1;

            //var query = from Product in db.Product select Product ;
            //DataContext = query;


            

        }
        private void bindowaniePC()
        {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            var items2 = db.KAT.ToList();
            lista2 = items2;
            DataContext = lista2;
            //var query = from ProductCategory in db.ProductCategory select ProductCategory;
            //DataContext = query;
            dopoladrugiego.ItemsSource = lista2;

        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            lista1 = (from p in db.Produkt
                      where p.Name.Contains("D")
                      select p).ToList();
            doproduktow.ItemsSource = lista1;
            lista2 = (from p in db.KAT
                      where p.Name.EndsWith("a") || p.Name.EndsWith("e")
                      select p).ToList();
            dopoladrugiego.ItemsSource = lista2;
            //lista1 = (from p in db.Produkt )  
            


        }

        private void dodajrekord_Click(object sender, RoutedEventArgs e)
        {

            /*  MainWindow okno_glowe = new MainWindow();
              this.Close();
              Window1 okno2 = new Window1();
              okno2.Show();
              */
            /* string k = nazwa_produktu.Text;
             ListBoxItem first = new ListBoxItem();
             first.Content = k;
             ItemsControl xd = new ItemsControl();*/
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            Produkt p = new Produkt();
            p.Name = nazwa_produktu.Text;
            p.Ilosc = 2; 
            db.Produkt.Add(p);
            db.SaveChanges();
            //db.SaveChanges();
            lista1 = db.Produkt.ToList();
            //lista1.Add(p);
            doproduktow.ItemsSource = lista1;

            //doproduktow.Items.Add(nazwa_produktu.Text);










        }

        private void Wyjscie_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void dodajkat_Click(object sender, RoutedEventArgs e)
        {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            KAT p = new KAT();
            
            p.Name = kategoria_nazwa.Text;
            db.KAT.Add(p);
            foreach (KAT x in db.KAT) {
                Console.WriteLine(x.Name);
            }
            
                db.SaveChanges();
            
            //db.SaveChanges();
            lista2 = db.KAT.ToList();
            //lista1.Add(p);
            dopoladrugiego.ItemsSource = lista2;
                   

        }

        private void usunprod_Click(object sender, RoutedEventArgs e)
        {
            
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            
            Produkt p = ((Produkt)doproduktow.SelectedItem);
            var pz = db.Produkt.First(pr => p.Id == pr.Id);
            db.Produkt.Remove(pz);
            
            db.SaveChanges();
            lista1 = db.Produkt.ToList();
            doproduktow.ItemsSource = lista1;

                 
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            string x = edycja.Text;
            Produkt p = ((Produkt)doproduktow.SelectedItem);
            var pz = db.Produkt.First(pr => p.Id == pr.Id);
            db.Produkt.Remove(pz);
            p.Name = x;
            db.Produkt.Add(p);
            db.SaveChanges();
            //db.SaveChanges();
            lista1 = db.Produkt.ToList();
            //lista1.Add(p);
            doproduktow.ItemsSource = lista1;
           


       }
        private void usun2_Click(object sender, RoutedEventArgs e) {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();

            KAT d = ((KAT)dopoladrugiego.SelectedItem);
            var pz = db.KAT.First(pr => d.Id == pr.Id);
            db.KAT.Remove(pz);

            db.SaveChanges();
            lista2 = db.KAT.ToList();
            dopoladrugiego.ItemsSource = lista2;

        }
        private void editkat_Click(object sender, RoutedEventArgs e)
        {
            AdventureWorks2012_DataEntities3 db = new AdventureWorks2012_DataEntities3();
            string x = edycja2.Text;
            KAT p = ((KAT)dopoladrugiego.SelectedItem);
            var pz = db.KAT.First(pr => p.Id == pr.Id);
            db.KAT.Remove(pz);
            p.Name = x;
            db.KAT.Add(p);
            db.SaveChanges();
            //db.SaveChanges();
            lista2 = db.KAT.ToList();
            //lista1.Add(p);
            dopoladrugiego.ItemsSource = lista2;

        }



        }
}
