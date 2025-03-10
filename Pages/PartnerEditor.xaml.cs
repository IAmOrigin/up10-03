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
	/// Логика взаимодействия для PartnerEditor.xaml
	/// </summary>
	public partial class PartnerEditor : Page
	{
		Entities entities = new Entities();
		private int sharedId;
		public PartnerEditor(int sharedId)
		{
			InitializeComponent();
			this.sharedId = sharedId;
			var editedPartner = entities.Partner.Find(sharedId);
			if (editedPartner != null)
			{
				TextBoxType.Text = editedPartner.Type;
				TextBoxName.Text = editedPartner.Name;
				TextBoxDirector.Text = editedPartner.Director;
				TextBoxEmail.Text = editedPartner.Email;
				TextBoxPhone.Text = editedPartner.Phone;
				TextBoxAdress.Text = editedPartner.Adress;
				TextBoxInn.Text = editedPartner.Inn;
				TextBoxRating.Text = editedPartner.Rating.ToString();
			}
		}

		private void ButtonBack(object sender, RoutedEventArgs e)
		{		
			Manager.MainFrame.GoBack();
		}

		private void ButtonSave(object sender, RoutedEventArgs e)
		{
			var savedPartner = entities.Partner.Find(sharedId);
			if (TextBoxType.Text == "" || TextBoxName.Text == "" || TextBoxDirector.Text == "" ||
				TextBoxEmail.Text == "" || TextBoxPhone.Text == "" || TextBoxAdress.Text == "" ||
				TextBoxInn.Text == "" || TextBoxRating.Text == "")
			{
				MessageBox.Show("Заполните все поля", "Ошибка");
				return;
			}
			else
			{
				if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxPhone.Text, @"^\d{10}$"))
				{
					MessageBox.Show("Номер телефона должен содеражать цифры без +7 или 8", "Ошибка");
					return;
				}
				if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxInn.Text, @"^\d{10}$"))
				{
					MessageBox.Show("ИНН должен состоять из 10 цифр", "Ошибка");
					return;
				}
				if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Электронная почта должна быть по шаблону: example@mail.ru", "Ошибка");
					return;
				}
				if (Convert.ToInt32(TextBoxRating.Text) < 0 || Convert.ToInt32(TextBoxRating.Text) > 10)
				{
					MessageBox.Show("Рейтинг должен быть от 0 до 10", "Ошибка");
					return;
				}
				if (savedPartner == null)
				{
					savedPartner = new Partner();
					entities.Partner.Add(savedPartner);
				}
				savedPartner.Type = TextBoxType.Text;
				savedPartner.Name = TextBoxName.Text;
				savedPartner.Director = TextBoxDirector.Text;
				savedPartner.Email = TextBoxEmail.Text;
				savedPartner.Phone = TextBoxPhone.Text;
				savedPartner.Adress = TextBoxAdress.Text;
				savedPartner.Inn = TextBoxInn.Text;
				savedPartner.Rating = int.Parse(TextBoxRating.Text);
				entities.SaveChanges();
				Manager.MainFrame.Navigate(new PartnersPage());
			}
		}

		private void ButtonDelete(object sender, RoutedEventArgs e)
		{
			if (sharedId == 0)
			{
				Manager.MainFrame.Navigate(new PartnersPage());
			}
			else
			{
				var deletePartner = entities.Partner.Find(sharedId);
				entities.Partner.Remove(deletePartner);
				entities.SaveChanges();
				Manager.MainFrame.Navigate(new PartnersPage());
			}
		}
	}
}
