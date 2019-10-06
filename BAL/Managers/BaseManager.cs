﻿using AutoMapper;
using Interface.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public abstract class BaseManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        protected BaseManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
