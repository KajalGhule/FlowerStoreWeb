namespace ShoppingCart {

    public class Cart
    {
        // public int Id{get;set;}
        private List<Item> items = new List<Item>();
        
        // public List<Item> getItemsList() {
        //     return items;
        // }
        public void addToCart(Item item)
        {
            items.Add(item);
        }

        public void removeFromCart(Item item)
        {
            items.Remove(item);
        }
    }
}