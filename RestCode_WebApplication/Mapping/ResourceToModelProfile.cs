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
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveCommentResource, Comment>();
        }
    }
}
