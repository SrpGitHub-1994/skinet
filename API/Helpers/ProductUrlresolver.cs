using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlresolver : IValueResolver<Product, ProductDTO, string>
    {
        public IConfiguration Configuration { get; }
        public ProductUrlresolver(IConfiguration configuration)
        {
            this.Configuration = configuration;
            
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return Configuration["ApiUrl"].ToString()+source.PictureUrl;
            }

            return null;
        }
    }
}