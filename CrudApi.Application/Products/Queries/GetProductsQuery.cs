using CrudApi.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CrudApi.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
