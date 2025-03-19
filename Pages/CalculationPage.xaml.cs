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
    public partial class CalculationPage : Page
    {
        Entities entities = new Entities();
        TextBox tboxcount = new TextBox();
        public CalculationPage()
        {
            InitializeComponent();
            foreach (var items in entities.ProductType)
            {
                ComboboxProductType.Items.Add(items);
            }
			foreach (var items in entities.ProductDefect)
			{
				ComboboxDefectType.Items.Add(items);
			}
		}

		private void ButtonBack(object sender, RoutedEventArgs e)
		{
            Manager.MainFrame.GoBack();
		}

		private void ButtonCalculate(object sender, RoutedEventArgs e)
		{
            try
            {
				var typeproduct = ComboboxProductType.SelectedItem as ProductType;
				var defect = ComboboxDefectType.SelectedItem as ProductDefect;
				int idTypeProduct = typeproduct.Id;
				int idProduct = defect.Id;
				int count = Convert.ToInt32(TextBoxCount.Text);
				float height = float.Parse(TextBoxHeight.Text);
				float width = float.Parse(TextBoxWidth.Text);
                Calculation calculation = new Calculation();
                var result = calculation.CalculateMaterial(idTypeProduct, idProduct, count, height, width);
                if (result == -1)
                {
					TextBlockResult.Text = "Проверьте корректность вводимых данных";
				}
                TextBlockResult.Text = "Результат = " + result.ToString();
			}
            catch
            {
                TextBlockResult.Text = "Проверьте корректность вводимых данных";
            }
            
        }
	}
}
