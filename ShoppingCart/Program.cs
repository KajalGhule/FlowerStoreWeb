// See https://aka.ms/new-console-template for more information
using ShoppingCart;

Console.WriteLine("Hello, World!");

Item item = new Item(10,1);
Cart cart = new Cart();
cart.addToCart(item);

List<Item> items = cart.getItemsList();
foreach(Item i in items) {
    Console.WriteLine("Quantity " + i.Quantity + " product id " + i.ProductId);
}
