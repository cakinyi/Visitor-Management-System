using VisitorManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagement.data;

namespace VisitorManagement.Repository
{
    public class ProductRepository
    {
        //InventoryContextt dbContext = new InventoryContextt();
        private readonly InventoryContextt _inventoryContextt;
        public ProductRepository(InventoryContextt inventoryContextt)
        {
            _inventoryContextt=inventoryContextt;
        }

        public int Approve(Products model)
        {
            var data = _inventoryContextt.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            // Checking if any such record exist  
            if (data != null)
            {
                data.Status = Status.Approved;
                return _inventoryContextt.SaveChanges();
            }
            else
                return 0;

        }
        public int Reject(Products model)
        {
            var data = _inventoryContextt.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            // Checking if any such record exist  
            if (data != null)
            {
                data.Status = Status.Rejected;
                return _inventoryContextt.SaveChanges();
            }
            else
                return 0;

        }
        public Products GetVisitors(int productId)
        {
            try
            {
                Products list = _inventoryContextt.Products.FirstOrDefault(s => s.ProductId == productId);

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
            var products = _inventoryContextt.Products
          .FromSqlRaw("EXECUTE dbo.Sp_VisitorDate @Start, @End", startDate, endDate)
          .ToList();
            return products;
        }
    }
}
