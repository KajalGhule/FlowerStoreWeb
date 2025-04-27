// See https://aka.ms/new-console-template for more information
using CRM;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

                                // Name, Email, ContactNumber, Location, Age
// Customer customer = new Customer("Kajal", "kajal@gmail.com","741236589","Pune",25);
// // bool IsInsert = CustomerDBManager.Insert(customer);
// bool IsInsert = CustomerDisDBManager.Insert(customer);
// Console.WriteLine(IsInsert+"!!!!!!!!!!!!!!");


// List<Customer> customers = CustomerDBManager.GetAll();
List<Customer> customers = CustomerDisDBManager.GetAll();
foreach(Customer c in customers) {
    Console.WriteLine("Name :: "+c.Name);
}

// Customer cust = CustomerDisDBManager.GetById(1);
// Console.WriteLine("Location :: "+cust.Location);

// bool IsDeleted = CustomerDBManager.Delete(2);
// bool IsDeleted = CustomerDisDBManager.Delete(3);
// Console.WriteLine(IsDeleted + "*********");

// Customer customer = new Customer(1, "Omkar R", "omkar@gmail.com", "896574126");


// Customer customer = new Customer(1,"Omkar", "omkar@gmail.com","896574126");
// Customer customer = new Customer(3,"Omkar", "omkar@gmail.com","896574126","Pune",25);
// bool IsUpdated = CustomerDBManager.Update(customer);
// Console.WriteLine(IsUpdated + "************");