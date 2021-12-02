using CrudApi.Application.Products.Queries;
using CrudApi.Domain.Entities;
using CrudApi.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudApi.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
