using MediatR;
using ProductsApi1.Models;

namespace ProductsApi1.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Upc { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double UnitListPrice { get; set; }
        public int UnitsInStock { get; set; }

        public CreateProductCommand(string upc, string name, string model, double unitListPrice, int unitInStock)
        {
            Upc = upc;
            Name = name;
            Model = model;
            UnitListPrice = unitListPrice;
            UnitsInStock = unitInStock;
        }
    }
}
