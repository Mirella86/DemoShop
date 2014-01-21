using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModels
{
    public abstract class IModel 
    {
        protected int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
