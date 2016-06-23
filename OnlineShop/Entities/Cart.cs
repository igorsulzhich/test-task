using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.ProductService;

namespace OnlineShop.Entities
{
    public class Cart
    {
        public List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Products product, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Products product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}