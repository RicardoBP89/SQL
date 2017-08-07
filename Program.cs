using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Menú: 1: Create table 2: Insert table: 3: Display table 4: Modify table 5: Delete table 6: Salir");
            //int option = Console.Read();

            var p = new Pizza();
            p.Id = Guid.NewGuid();
            p.Name = "margarita";
            p.Num_Ingredients = 3;
            p.Ingredients = "Queso";
            p.Bread_Type = "fino";

            var s = new SqlClasses();
            s.CreateTable();
            s.InserTable(p);
            s.DisplayTable();
            s.AlterTable();
            s.DeleteTable();
            /*
            do
            {
                switch (option)
                {
                    case 1:
                        s.CreateTable();
                        break;
                    case 2:
                        s.InserTable(p);
                        break;
                    case 3:
                        s.DisplayTable();
                        break;
                    case 4:
                        s.AlterTable();
                        break;
                    case 5:
                        s.DeleteTable();
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }

            } while (option != 6);
            */

        }
    }
 }
