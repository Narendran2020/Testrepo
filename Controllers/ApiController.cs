using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    public abstract class ApiController : Controller
    {

        protected readonly IMapper Mapper;
       
        protected ApiController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}