using ScrollProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScrollProducts.View
{
	
	public partial class CategoriesView : ContentPage
	{

        public List<ProductPair> tempdata;
        public List<Products> tempdata2;
        private List<ProductPair> l1;



        public CategoriesView ()
		{
            InitializeComponent();
            data();
            List1.ItemsSource = tempdata;
        }

        void data()
        {
            tempdata = new List<ProductPair>
            {
                new ProductPair (new Products{Status="ALMOST NEW", Image="glasses.png", ProductName="BROWNIE HIP SUN GLASSES", Price="770.00 SAR", Category="Accessories"},
                                new Products {Status="ACCEPTABLE", Image="holder.png", ProductName="BROWNIE GLASSES HOLDER", Price="220.00 SAR", Category="Accessories"} ),
                new ProductPair (new Products{Status="NEW", Image="handbag.png", ProductName="HANDBAG NATURAL LEATHER", Price="770.00 SAR", Category="Bags"},
                                new Products {Status="ALMOST NEW", Image="handwatch.png", ProductName="CONCORD HANDWATCH", Price="3000.00 SAR", Category="Accessories"} ),
                new ProductPair (new Products{Status="ALMOST NEW", Image="shoes.png", ProductName="EVENING SHOES HIGH HEAL", Price="200.00 SAR",Category="Shoes"},
                                new Products {Status="ALMOST NEW", Image="Leather.png", ProductName="BELT NATURAL LEATHER", Price="100.00 SAR",Category="Travel"} ),
            };
            
        }


        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                List1.ItemsSource = tempdata;
            }

            else
            {

                tempdata2 = new List<Products>();

                foreach (var prod in tempdata)
                {


                    if (prod.Item1.ProductName.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        tempdata2.Add(prod.Item1);
                        prod.Item2.IsVisible = false;
                    }

                    if (prod.Item2.ProductName.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        tempdata2.Add(prod.Item2);
                        prod.Item1.IsVisible = false;
                    }

                }
                l1 = new List<ProductPair>();
                for (int i = 0; i <= tempdata2.Count; i = i + 2)
                {
                    if (i < tempdata2.Count - 1)
                    {
                        ProductPair pp = new ProductPair(tempdata2[i], tempdata2[i + 1]);
                        l1.Add(pp);
                    }
                    else if (i == tempdata2.Count - 1)
                    {
                        ProductPair pp = new ProductPair(tempdata2[i], null);
                        l1.Add(pp);
                    }
                }

                List1.ItemsSource = l1;

            }

        }

        void getdatabycategory(string category)
        {
            tempdata2 = new List<Products>();

            foreach (var prod in tempdata)
            {


                if (prod.Item1.Category.Equals(category))
                {
                    tempdata2.Add(prod.Item1);
                    prod.Item2.IsVisible = false;
                }

                if (prod.Item2.Category.Equals(category))
                {
                    tempdata2.Add(prod.Item2);
                    prod.Item1.IsVisible = false;
                }

            }
            l1 = new List<ProductPair>();

            for (int i = 0; i <= tempdata2.Count; i = i + 2)
            {
                if (i < tempdata2.Count - 1)
                {
                    ProductPair pp = new ProductPair(tempdata2[i], tempdata2[i + 1]);
                    l1.Add(pp);
                }
                else if (i == tempdata2.Count - 1)
                {
                    ProductPair pp = new ProductPair(tempdata2[i], null);
                    l1.Add(pp);
                }
            }

            List1.ItemsSource = l1;
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (sender.Equals(Shoes))
            {
                Travel.TextColor = Color.Gray;
                Shoes.TextColor = Color.White;
              
                Accessories.TextColor = Color.Gray;
                Bags.TextColor = Color.Gray;
                getdatabycategory("Shoes");

            }
            else if (sender.Equals(Bags))
            {
                Travel.TextColor = Color.Gray;
                Shoes.TextColor = Color.Gray;
                Accessories.TextColor = Color.Gray;
                Bags.TextColor = Color.White;
                getdatabycategory("Bags");

            }
            else if (sender.Equals(Accessories))
            {
                Travel.TextColor = Color.Gray;
                Shoes.TextColor = Color.Gray;
                Accessories.TextColor = Color.White;
                Bags.TextColor = Color.Gray;
                getdatabycategory("Accessories");
            }
           
            else if (sender.Equals(Travel))
            {
                Travel.TextColor = Color.White;
                Shoes.TextColor = Color.Gray;
                Accessories.TextColor = Color.Gray;
                Bags.TextColor = Color.Gray;
                getdatabycategory("Travel");

            }
        }



    }
}