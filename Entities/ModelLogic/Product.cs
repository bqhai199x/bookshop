using System.Text.RegularExpressions;

namespace Entities
{
    public partial class Product
    {
        public double? RateAVG
        {
            get
            {
                double? rateAVG = Reviews.Where(x => x.Rating != 0).Average(x => x.Rating);
                if (rateAVG == null) rateAVG = 0;
                return rateAVG * 10;
            }
        }

        public string SubDescription
        {
            get
            {
                return Regex.Replace(Description, @"<\/?[a-z][a-z0-9]*[^<>]*>", "");
            }
        }
    }
}
