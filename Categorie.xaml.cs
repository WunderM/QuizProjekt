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
using System.Windows.Shapes;

namespace SoftwareEngineering
{
    /// <summary>
    /// Interaktionslogik für Categorie.xaml
    /// </summary>
    public partial class Categorie : Page
    {
        public Categorie()
        {
            InitializeComponent();
        }

        // Öffnet die Fragen-Page mit der entsprechenden Kategorie
        private void OpenCategoryPage(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string category = button.Tag.ToString();
                NavigationService?.Navigate(new Questions(category));
            }
        }
    }
}
