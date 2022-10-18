﻿using System;
using System.Collections.Generic;
using System.Text;
using Generator.DataAccess.Abstract;
using Generator.DataAccess.EntityFramework;
using Generator.Entities;

namespace Generator.DataAccess.Concrete
{
    public class EfObjectParameterDal : EfEntityRepositoryBase<ObjectParameter, GeneratorContext>, IObjectParameterDal
    {
    }
}