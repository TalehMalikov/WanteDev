using StoringImageInDB.DataAccess.Utils;
using System.Configuration;
using System.Windows;

namespace StoringImageInDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Kernel.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }
    }
}
