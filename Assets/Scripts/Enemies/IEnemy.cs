﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal interface IEnemy
    {
        public void TakeDamage(Collision2D collision);
        
    }
}
