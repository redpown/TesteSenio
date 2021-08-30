﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;
using testesenior.Domain.Interface;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositorios;

namespace TesteSenior.Data.Repositories
{
    public class ExamesRepository : BaseRepository<Exames>, IExamesRepository
    {
        public ExamesRepository(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }

    }
}
