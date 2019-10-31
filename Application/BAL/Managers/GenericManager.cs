using AutoMapper;
using MODELS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public class GenericManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public GenericManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
