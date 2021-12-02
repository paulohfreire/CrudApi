using AutoMapper;
using CrudApi.Application.DTOs;
using CrudApi.Application.Interfaces;
using CrudApi.Application.Products.Commands;
using CrudApi.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApi.Application.Services
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
             _mediator = mediator;
             _mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded.");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception($"Entity could be not loaded");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
