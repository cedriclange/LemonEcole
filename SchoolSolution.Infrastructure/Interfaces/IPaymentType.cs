﻿using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IPaymentType
    {
        IEnumerable<PaiementType> DropDownList();
    }
}
