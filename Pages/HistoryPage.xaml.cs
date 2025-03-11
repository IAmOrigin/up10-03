using System.Windows;
using System.Windows.Controls;
using up10_03.Classes;

namespace up10_03.Pages
{
	public partial class HistoryPage : Page
	{
		Entities entities = new Entities();
		public HistoryPage()
		{
			InitializeComponent();
			foreach(var entity in entities.Partner)
			{
				ListViewPartners.Items.Add(entity);
			}
		}

		private void ListViewPartners_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGridPartnerProducts.Items.Clear();
			var selectedItem = ListViewPartners.SelectedItem as Partner;
			foreach (var entity in entities.PartnerProduct)
			{
				if (entity.PartnerId == selectedItem.Id)
				{
					DataGridPartnerProducts.Items.Add(entity);
				}
			}
			//Отображение истории заказов выбранного партнера
		}

		private void ButtonBack(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new MainPage());
		}
	}
}
