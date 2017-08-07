using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL
{
    class SqlClasses
    {
        public void CreateTable()
        {
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            connection.Open();

            try
            {
                SqlCommand sqlCreation = new SqlCommand("CREATE TABLE pizza (id INT, name TEXT, num_ingredients INT, ingredients TEXT, bread_type TEXT)",connection);
                sqlCreation.ExecuteNonQuery();
                Console.WriteLine("Table created");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void InserTable(Pizza pizza)
        {
            var connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = pizzeria; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            connection.Open();

            try
            {
                SqlCommand sqlInsert = new SqlCommand("INSERT INTO pizza VALUES (@id, @name, @num_ingredients, @ingredients, @bread_type)", connection);
                {
                    
                    sqlInsert.Parameters.Add(new SqlParameter("@id", pizza.Id));
                    sqlInsert.Parameters.Add(new SqlParameter("@name", pizza.Name));
                    sqlInsert.Parameters.Add(new SqlParameter("@num_ingredients", pizza.Num_Ingredients));
                    sqlInsert.Parameters.Add(new SqlParameter("@ingredients", pizza.Ingredients));
                    sqlInsert.Parameters.Add(new SqlParameter("@bread_type", pizza.Bread_Type));

                }
                sqlInsert.ExecuteNonQuery();
                Console.WriteLine("Table Inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayTable()
        {
            List<Pizza> pizzas = new List<Pizza>();

            var connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = pizzeria; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            connection.Open();

            try
            {
                SqlCommand sqlDisplay = new SqlCommand("SELECT name, num_ingredients, ingredients, bread_type FROM pizza", connection);
                SqlDataReader reader = sqlDisplay.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    int num_ingredients = reader.GetInt32(1);
                    string ingredients = reader.GetString(0);
                    string bread_type = reader.GetString(0);
                    pizzas.Add(new Pizza()
                    {
                        Name = name,
                        Num_Ingredients = num_ingredients,
                        Ingredients = ingredients,
                        Bread_Type = bread_type
                        
                    });
                    foreach (Pizza pizza in pizzas)
                        {
                        Console.WriteLine(pizza);
                        }
                }
                sqlDisplay.ExecuteNonQuery();
                Console.WriteLine("Show table");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AlterTable()
        {
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            SqlCommand command = new SqlCommand("ALTER TABLE pizza ADD precio INT",connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Modify table");

        }


        public void DeleteTable()
        {
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM pizza", connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Table deleted");
        }
    }
}
