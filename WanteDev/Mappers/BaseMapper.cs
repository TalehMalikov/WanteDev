using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Domain.Entities;
using WanteDev.Models;

namespace WanteDev.Mappers
{
    public abstract class BaseMapper<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);

    }
}
