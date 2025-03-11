using System;

namespace up10_03.Classes
{
	internal class Calculation
	{
		Entities entities = new Entities();
		public int CalculateMaterial(int idTypeProduct, int idProduct, int count, float height,	float width)
		{
			try
			{
				var defect = entities.ProductDefect.Find(idProduct);
				var type = entities.ProductType.Find(idTypeProduct);
				double countMaterial = (double)(height * width * type.Coefficient);
				double result = (double)(countMaterial + countMaterial * defect.Coefficent);
				return (int)Math.Ceiling(result);
			}
			catch
			{
				return -1;
			}
		}
	}
}
