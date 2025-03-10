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
using up10_03.Pages;

namespace up10_03
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Manager.MainFrame = Frame1;
		}

		private void ButtonPartners(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new PartnersPage());
		}

		private void ButtonHome(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new MainPage());
		}

		private void ButtonHistory(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new HistoryPage());
		}
	}
}
