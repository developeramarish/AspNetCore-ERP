﻿using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Hareketler
{
    public class BankaHareketDal : EfGenericRepository<BankaHareket>, IBankaHareketDal
    {
        public BankaHareketDal(DbContext context) : base(context)
        {
        }
    }
}