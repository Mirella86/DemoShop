﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public interface IEntity
    {
        bool CompareTo(IEntity otherEntity);
    }
}
