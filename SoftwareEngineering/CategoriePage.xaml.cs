using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class CategoryPage : Page
    {
        private readonly ApiClient _apiClient;

        public CategoryPage()
        {
            InitializeComponent();

            DataContext = App.SharedViewModel;
            _apiClient = new ApiClient();
            LoadCategories();
        }

        private async void LoadCategories()
        {
            // Kategorien abrufen
            List<Category> categories = await _apiClient.GetCategoriesAsync();


            CategoryList.ItemsSource = categories;
            CategoryList.DisplayMemberPath = "Title";
        }

        private void CategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryList.SelectedItem is Category selectedCategory)
            {
                App.SharedViewModel.ChangePage("Quiz", selectedCategory.Id);
            }
        }
    }
}
