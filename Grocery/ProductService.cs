using Grocery.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Grocery
{
    public class ProductService
    {
        private SqlConnection connection;

        public ProductService(SqlConnection connection)
        {
            this.connection = connection;
        }

        public Product? GetProductById(int id)
        {
            var product = connection.QueryFirstOrDefault<Product>("GetProductById", new { Id = id }, commandType: CommandType.StoredProcedure);
            if (product == null)
            {
                throw new Exception("Продукт не знайдено");
            }
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return connection.Query<Product>("GetAllProducts", commandType: CommandType.StoredProcedure).ToList();
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                connection.Execute("UpdateProduct", product, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка при оновленні продукту", ex);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                connection.Execute("DeleteProduct", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка при видаленні продукту", ex);
            }
        }

        public double GetAverageCalories()
        {
            try
            {
                return connection.Query<double>("GetAverageCalories", commandType: CommandType.StoredProcedure).Single();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка при обчисленні середньої калорійності", ex);
            }
        }
    }
}
