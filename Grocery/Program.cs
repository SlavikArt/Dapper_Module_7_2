using Grocery.Entities;
using Microsoft.Data.SqlClient;

namespace Grocery
{
    public class Program
    {
        private static string connectionString = @"Server=LAPTOP-MCLUN3BN\SQLSERVER;Database=Grocery;Trusted_Connection=True;Encrypt=False;";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var db = new ProductService(connection);

                // Get Product By ID
                var product = db.GetProductById(1);
                Console.WriteLine($"Product Id: {product.Id}, " +
                    $"Name: {product.Name}, Type: {product.Type}, " +
                    $"Color: {product.Color}, Calories: {product.Calories}\n");

                // Get All Products
                var allProducts = db.GetAllProducts();
                foreach (var p in allProducts)
                    Console.WriteLine($"Product Id: {p.Id}, Name: {p.Name}, " +
                        $"Type: {p.Type}, Color: {p.Color}, Calories: {p.Calories}");
                Console.WriteLine();

                // Update Product
                product.Name = "Тыква";
                db.UpdateProduct(product);

                // Delete Product
                db.DeleteProduct(1);

                // Get Average Calories
                var averageCalories = db.GetAverageCalories();
                Console.WriteLine($"Average Calories: {averageCalories}\n");
            }
        }
    }
}
