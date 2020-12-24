using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFday1
{
    class Program
    {
        static void Main(string[] args)
        {
            //FillCategories();
            AddOperation();
            GetByCategory();
        }

        static void AddOperation()
        {
            while (true)
            {
                Console.WriteLine("Do you want to add new operation? y/n");
                string addnew = Console.ReadLine();
                if (addnew == "n")
                {
                    return;
                }
                Console.WriteLine("Select Category");
                using (var context = new BookingDbContext())
                {
                    foreach (var category in context.Categories)
                    {
                        Console.WriteLine($"{category.Id} - {category.Name}");

                    }
                    var categorySelectedId = int.Parse(Console.ReadLine());
                    var categorySelected = context
                        .Categories
                        .Include(x => x.Operations)
                        .FirstOrDefault(x => x.Id == categorySelectedId);
                    var operation = new Operation();
                    Console.WriteLine("What operation name is it?");
                    operation.Name = Console.ReadLine();
                    Console.WriteLine("What was the summ? - for spending money");
                    operation.Summ = decimal.Parse(Console.ReadLine());
                    operation.DateTimeCreated = DateTime.Now;
                    categorySelected.Operations.Add(operation);
                    context.SaveChanges();
                }
            }
        }

        static void GetByCategory()
        {
            Console.WriteLine("Select category to get report");
            using (var context = new BookingDbContext())
            {
                foreach (var category in context.Categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Name}");

                }
                var categorySelectedId = int.Parse(Console.ReadLine());
                var categorySelected = context
                    .Categories
                    .Include(x => x.Operations)
                    .FirstOrDefault(x => x.Id == categorySelectedId);
                foreach (var operation in categorySelected.Operations)
                {
                    Console.WriteLine($"The operation {operation.Name} with summ of {operation.Summ} was performed on {operation.DateTimeCreated.ToShortDateString()}");
                }
                Console.WriteLine($"total for category was {categorySelected.Operations.Sum(x => x.Summ)}");
            }
        }

        static void FillCategories()
        {
            using (var context = new BookingDbContext())
            {
                context.Categories.Add(new Category() { Name = "Salary" });
                context.Categories.Add(new Category() { Name = "Food" });
                context.Categories.Add(new Category() { Name = "Entertainment" });
                context.Categories.Add(new Category() { Name = "Buhlou" });
                context.Categories.Add(new Category() { Name = "Smoking" });
                context.Categories.Add(new Category() { Name = "Charity" });
                context.Categories.Add(new Category() { Name = "Clothing" });
                context.Categories.Add(new Category() { Name = "Long Term Purchases" });
                context.Categories.Add(new Category() { Name = "Car and fuel" });
                context.Categories.Add(new Category() { Name = "Public transport" });

                context.SaveChanges();
            }
        }
    }
}
