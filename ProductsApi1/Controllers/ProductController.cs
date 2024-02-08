﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsApi1.Commands;
using ProductsApi1.Models;
using ProductsApi1.Queries;

namespace ProductsApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await mediator.Send(new GetProductsListQuery());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(string id)
        {
            return await mediator.Send(new GetProductByIdQuery() { Id = id});
        }

        [HttpPost]
        public async Task<Product> Add([FromBody]Product product)
        {
            var newproduct = await mediator.Send(new CreateProductCommand(product.Upc, product.Name, product.Model, product.UnitListPrice, product.UnitsInStock));
            return newproduct;
        }

        [HttpPut]
        public async Task<bool> Update([FromBody]Product product)
        {
            var isUpdateProduct = await mediator.Send(new UpdateProductCommand(product.Id!, product.Upc, product.Name, product.Model, product.UnitListPrice, product.UnitsInStock));
            return isUpdateProduct;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = id });
        }
    }
}
