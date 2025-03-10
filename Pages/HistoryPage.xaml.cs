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
using up10_03.Classes;

namespace up10_03.Pages
{
	/// <summary>
	/// Логика взаимодействия для HistoryPage.xaml
	/// </summary>
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
		}

		private void ButtonBack(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new MainPage());
		}
	}
}
