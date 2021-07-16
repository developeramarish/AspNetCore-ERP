﻿using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface ISehirService : IBaseService<Sehir>
    {
        List<Sehir> GetAllByActiveCars(bool durum);
    }
}