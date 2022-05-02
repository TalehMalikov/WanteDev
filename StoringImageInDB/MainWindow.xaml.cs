using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using System.IO;
using StoringImageInDB.DataAccess;
using StoringImageInDB.ViewModel;

namespace StoringImageInDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            createDB();//Creation of Datbase using code first approach
            DataContext = new MainWindowViewModel();
        }
        void createDB()
        {
            Database DB = new Database();
            ImageClass images = new ImageClass();
            DB.Database.Initialize(false);
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            Database DB = new Database();
            ImageClass images = new ImageClass();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog1.ShowDialog();
            openFileDialog1.DefaultExt = ".jpeg";
            textBox1.Text = openFileDialog1.FileName;
            ImageSource imageSource = new BitmapImage(new Uri(textBox1.Text));
            image1.Source = imageSource;

        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {

            ImageClass image = new ImageClass()
            {
                ImagePath = textBox1.Text,
                ImageToByte = File.ReadAllBytes(textBox1.Text)
            };
            ImageRepository repository = new ImageRepository();
            repository.Add(image);

        //    Database DB = new Database();
        //    ImageClass images = new ImageClass();
        //    images.ImagePath = textBox1.Text;
        //    images.ImageToByte= File.ReadAllBytes(textBox1.Text);
        //    DB.Images.Add(images);
        //    DB.SaveChanges();
        }

        private void Retrieve_Click(object sender, RoutedEventArgs e)
        {
           
            ImageRepository repository = new ImageRepository();
            ImageClass image = repository.Get(1);
            Stream StreamObj = new MemoryStream(image.ImageToByte);
            BitmapImage BitObj = new BitmapImage();
            BitObj.BeginInit();
            BitObj.StreamSource = StreamObj;
            BitObj.EndInit();
            this.image2.Source = BitObj;
            //Database DB = new Database();
            //ImageClass images = new ImageClass();
            //var result = (from t in DB.Images
            //              where t.ImagePath == textBox1.Text
            //              select t.ImageToByte).FirstOrDefault();
            //Stream StreamObj = new MemoryStream(result);
            //BitmapImage BitObj = new BitmapImage();
            //BitObj.BeginInit();
            //BitObj.StreamSource = StreamObj;
            //BitObj.EndInit();
            //this.image2.Source = BitObj;

        }


    }
}
