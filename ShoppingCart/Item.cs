namespace ShoppingCart
{
    public class Item
    {
        public int Quantity{get;set;}
        public int ProductId{get;set;}

        public Item() {}
        public Item(int quantity, int productId) {
            this.Quantity = quantity;
            this.ProductId = productId;
        }

        
    }
} 