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
	/// Логика взаимодействия для PartnersPage.xaml
	/// </summary>
	public partial class PartnersPage : Page
	{
		Entities entities = new Entities();
		public PartnersPage()
		{
			InitializeComponent();
			foreach (var partner in entities.Partner)
			{
				int sum = 0;
				foreach (var entity in entities.PartnerProduct)
				{
					if (entity.PartnerId == partner.Id)
					{
						sum += Convert.ToInt32(entity.Count);
					}
				}
				if (sum  < 10000)
				{
					partner.Discount = 0;
				}
				else if(sum < 50000)
				{
					partner.Discount = 5;
				}
				else if(sum < 300000)
				{
					partner.Discount = 10;
				}
				else
				{
					partner.Discount = 15;
				}
				ListViewPartners.Items.Add(partner);
			}
		}

		private void ListViewPartners_MouseDoubleClick(object sender, MouseButtonEventArgs e) 
		{
			var editedItem = ListViewPartners.SelectedItem as Partner;
			Manager.MainFrame.Navigate(new PartnerEditor(editedItem.Id));
		}

		private void ButtonBack(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new MainPage());
		}

		private void ButtonNew(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new PartnerEditor(0));
		}
	}
}
