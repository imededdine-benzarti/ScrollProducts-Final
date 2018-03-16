using System;
using System.Collections.Generic;
using System.Text;

namespace ScrollProducts.Model
{
    public class ProductPair : Tuple<Products, Products>
    {
       

        public ProductPair(Products item1, Products item2) : base(item1, item2 ?? CreateEmptyModel()) {}

        private static Products CreateEmptyModel()
        {
            return new Products { IsVisible = false };
        }


    }
    
}
