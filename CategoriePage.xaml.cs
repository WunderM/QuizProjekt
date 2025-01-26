using System.Collections.Generic;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class CategoryPage : Page
    {
        private readonly ApiClient _apiClient;

        public CategoryPage()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadCategories();
        }

        private async void LoadCategories()
        {
            // Kategorien abrufen
            List<string> categories = await _apiClient.GetCategoriesAsync();

            // Kategorien in der ListBox anzeigen
            foreach (var category in categories)
            {
                CategoryList.Items.Add(category);
            }
        }
    }
}
