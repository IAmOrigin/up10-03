using System.Diagnostics;
using System;
using System.Windows;
using up10_03.Classes;
using up10_03.Pages;

namespace up10_03
{
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
		private void ButtonCalculate(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new CalculationPage());
		}
    }
}
