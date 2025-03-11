using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using up10_03.Classes;

namespace up10_03.Pages
{
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
						sum += (int)entity.Count;
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
		private void ButtonNew(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new PartnerEditor(0));
		}
		private void ButtonBack(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new MainPage());
		}
	}
}
