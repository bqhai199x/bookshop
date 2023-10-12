using System.Text.RegularExpressions;

namespace Entities
{
    public partial class Product
    {
        public string SubDescription
        {
            get
            {
                return Regex.Replace(Description, @"<\/?[a-z][a-z0-9]*[^<>]*>", "");
            }
        }
    }
}
