﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Resources
{
    public static class Define
    {
        public enum OrderBy
        {
            Ascendant = 1,
            Descendent = 2
        }

        public enum RoleAssignationState
        { 
            Assigned = 1,
            NotAssigned = 2
        }
    }
}
