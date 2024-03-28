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
            return connection.QueryFirstOrDefault<Product>("GetProductById", new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public List<Product> GetAllProducts()
        {
            return connection.Query<Product>("GetAllProducts", 
                commandType: CommandType.StoredProcedure).ToList();
        }

        public void UpdateProduct(Product product)
        {
            connection.Execute("UpdateProduct", product, 
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteProduct(int id)
        {
            connection.Execute("DeleteProduct", new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public double GetAverageCalories()
        {
            return connection.Query<double>("GetAverageCalories",
                commandType: CommandType.StoredProcedure).Single();
        }
    }
}
