

using MAUITraining.Models;

namespace MAUITraining.Services;
public class ProductService
{
    static ProductService _instance;
    public static ProductService Instance
    {
        get { return _instance ??= new ProductService(); }
    }

    public List<Product> GetProducts()
    {
        //var products = new List<CartProduct>();
        var products = new List<Product>
        {
            new Product { Id = 1, ProductName="Canon Camera", ProductDescription="HD-4K 2023 Canon Camera", Price=25000, Quantity=10, ImageUrl = "https://shorturl.at/pqIKM"},
            new Product { Id = 2, ProductName=" LV Lip Stick", ProductDescription="Louis Vuitton Pink Glossy Lip Stick", Price=25000, Quantity=10, ImageUrl = "https://shorturl.at/djlHS"},
            new Product { Id = 3, ProductName="Portable Cosmetic Trolley", ProductDescription="Portable toy trolley for puting your cosmetics and keeping your dressing table neat", Price=25000, Quantity=10, ImageUrl = "https://shorturl.at/lnoPZ"},
            new Product { Id = 4, ProductName="Flavored Pancake", ProductDescription="Pan cake with sliced strawberry", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/pancake-with-sliced-strawberry-376464/"},
            new Product { Id = 5, ProductName="Chilli Pepper", ProductDescription="Australlian natural chilli pepper", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/red-chili-pepper-on-white-background-4033324/"},
            new Product { Id = 6, ProductName="Hanger Set", ProductDescription="Wooden texstured hanger set with brush and woven bag", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/body-brushes-and-toiletries-on-wooden-hanger-4210339/"},
            new Product { Id = 7, ProductName="Green pepper", ProductDescription="Whole natural grown green pepper", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/green-bell-pepper-lot-2893635/"},
            new Product { Id = 8, ProductName="Lip liner", ProductDescription="Blue Lip liner", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/close-up-photo-of-blue-container-3373724/"},
            new Product { Id = 9, ProductName="Male Shoe", ProductDescription="Male Fashion Shoe", Price=25000, Quantity=10, ImageUrl = "https://www.istockphoto.com/photo/elegant-black-leather-shoes-gm172417586-4624907"},
            new Product { Id = 10, ProductName="2 piece Jacket", ProductDescription="Female 2-piece blue and white  jacket", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/blue-and-white-sleeveless-top-2850487/"},
            new Product { Id = 11, ProductName="Jeep Wrangler", ProductDescription="White jeep wrangler on a tarred road", Price=25000, Quantity=10, ImageUrl = "https://www.pexels.com/photo/white-jeep-wrangler-on-asphalt-road-2882234/"},
            new Product { Id = 12, ProductName="Canon Camera", ProductDescription="HD-4K 2023 Canon Camera", Price=25000, Quantity=10, ImageUrl = "https://shorturl.at/pqIKM"}
        };
        //for (int i = 0; i < products.Count;i++)
        //{
        //    foreach (Product product in products)
        //    {
        //        //cartProducts[i].ProductId = product.Id;
        //        cartProducts[i].Product = product;
                
        //    }
        //}

        return products;
        

        
    }
}

