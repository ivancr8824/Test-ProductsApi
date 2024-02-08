using MediatR;

namespace ProductsApi1.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Upc { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double UnitListPrice { get; set; }
        public int UnitsInStock { get; set; }

        public UpdateProductCommand(string id, string upc, string name, string model, double unitListPrice, int unitInStock)
        {
            Id = id;
            Upc = upc;
            Name = name;
            Model = model;
            UnitListPrice = unitListPrice;
            UnitsInStock = unitInStock;
        }
    }
}
