namespace AAStore.API.Model
{
    public class ProductModel
    {
        public int ProductId {get; set;}
        public string ProductName {get;set;}
        public int Price {get;set;}
        public string PImage {get;set;}
        public int CategoryId {get;set;}
        public int CompanyId {get;set;}
    }
}