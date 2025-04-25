// See https://aka.ms/new-console-template for more information
using CRM;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

                                // Name, Email, ContactNumber, Location, Age
// Customer customer = new Customer("Kajal2", "kajal2@gmail.com","741236589","Pune",25);
// bool IsInsert = CustomerDBManager.Insert(customer);
// Console.WriteLine(IsInsert+"!!!!!!!!!!!!!!");


// List<Customer> customers = CustomerDBManager.GetAll();
// foreach(Customer c in customers) {
//     Console.WriteLine("Name :: "+c.Name);
// }

// Customer cust = CustomerDBManager.GetById(1);
// Console.WriteLine("Name :: "+cust.Name);

// bool IsDeleted = CustomerDBManager.Delete(2);
// Console.WriteLine(IsDeleted + "*********");

// Customer customer = new Customer(1, "Omkar R", "omkar@gmail.com", "896574126");


Customer customer = new Customer(1,"Omkar", "omkar@gmail.com","896574126");
bool IsUpdated = CustomerDBManager.Update(customer);
Console.WriteLine(IsUpdated + "************");