using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up10_03.Classes
{
	internal class Calculation
	{
		Entities entities = new Entities();
		public int CalculateMaterial(int idTypeProduct, int idProduct, int count, float height,	float width)
		{
			var defect = entities.ProductDefect.Find(idProduct);
			var type = entities.ProductType.Find(idTypeProduct);
			double countMaterial = (double)(height * width * type.Coefficient);
			double result = (double)(countMaterial + countMaterial * defect.Coefficent);
			return (int)Math.Ceiling(result);
		}
	}
}
