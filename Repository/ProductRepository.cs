using VisitorManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagement.Repository
{
    public class ProductRepository
    {
        VisitorContext dbContext = new VisitorContext();

        public int Approve(Products model)
        {
            var data = dbContext.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            // Checking if any such record exist  
            if (data != null)
            {
                data.Status = Status.Approved;
                return dbContext.SaveChanges();
            }
            else
                return 0;

        }
        public int Reject(Products model)
        {
            var data = dbContext.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            // Checking if any such record exist  
            if (data != null)
            {
                data.Status = Status.Rejected;
                return dbContext.SaveChanges();
            }
            else
                return 0;

        }
        public Products GetVisitors(int productId)
        {
            try
            {
                Products list = dbContext.Products.FirstOrDefault(s => s.ProductId == productId);

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<Products> SearchDate(DateTime Start, DateTime End)
        {
            var startDate = new SqlParameter("@Start", Start);
            var endDate = new SqlParameter("@End", End);
            var products = dbContext.Products
          .FromSqlRaw("EXECUTE dbo.Sp_VisitorDate @Start, @End", startDate, endDate)
          .ToList();
            return products;
        }
    }
}
