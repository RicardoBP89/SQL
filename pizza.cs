using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Pizza
    {

        public Guid Id {get;set;}
        public string Name { get; set;}
        public int Num_Ingredients { get; set; }
        public string Ingredients { get; set; }
        public string Bread_Type { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Num_Ingredients: {1}, Ingredients: {2}, Bread_Type: {3}",Name,Num_Ingredients,Ingredients,Bread_Type);
        }
    }
}
