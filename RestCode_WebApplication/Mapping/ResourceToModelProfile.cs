using AutoMapper;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveRestaurantResource, Restaurant>();
			CreateMap<SaveSaleResource, Sale>();
			CreateMap<SaveSaleDetailResource, SaleDetail>();
			CreateMap<SaveOwnerResource, Owner>();
        }
    }
}
