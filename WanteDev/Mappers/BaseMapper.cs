using System;
using System.Linq;
using WanteDev.Core.Domain.Entities;
using WanteDev.Models;

namespace E_Service.Mappers
{
    public class BaseMapper<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        public TModel Map(TEntity entity)
        {
            TModel model = new TModel();

            Type entitytype = typeof(TEntity);

            Type modeltype = typeof(TModel);

            var modelProps = modeltype.GetProperties();

            var entityProps = entitytype.GetProperties();

            foreach (var modelPropInfo in modelProps)
            {
                var entityPropInfo = entityProps.FirstOrDefault(x => x.Name == modelPropInfo.Name);

                if (entityPropInfo == null)
                    continue;

                var propValue = entityPropInfo.GetValue(entity);

                if (entityPropInfo.PropertyType.BaseType == typeof(BaseEntity))
                {
                    Type genericType = typeof(BaseMapper<,>).MakeGenericType(entityPropInfo.PropertyType, modelPropInfo.PropertyType);
                    var baseMapper = Activator.CreateInstance(genericType);

                    var methods = baseMapper.GetType().GetMethods();
                    var method = methods.FirstOrDefault(x => x.ReturnType.BaseType == typeof(BaseModel));

                    if (method == null)
                        continue;


                    var modelPropValue = method.Invoke(baseMapper, new object[] { propValue });

                    modelPropInfo.SetValue(model, modelPropValue);
                }
                else
                {
                    modelPropInfo.SetValue(model, propValue);
                }
            }

            return model;
        }


        public TEntity Map(TModel model)
        {
            TEntity entity = new TEntity();

            Type entitytype = typeof(TEntity);

            Type modeltype = typeof(TModel);

            var modelProps = modeltype.GetProperties();

            var entityProps = entitytype.GetProperties();

            foreach (var entityPropInfo in entityProps)
            {
                var modelPropInfo = modelProps.FirstOrDefault(x => x.Name == entityPropInfo.Name);

                if (modelPropInfo == null)
                    continue;

                var propValue = modelPropInfo.GetValue(model);

                if (modelPropInfo.PropertyType.BaseType == typeof(BaseModel))
                {
                    Type genericType = typeof(BaseMapper<,>).MakeGenericType(entityPropInfo.PropertyType, modelPropInfo.PropertyType);
                    var baseMapper = Activator.CreateInstance(genericType);

                    var methods = baseMapper.GetType().GetMethods();
                    var method = methods.FirstOrDefault(x => x.ReturnType.BaseType == typeof(BaseEntity));

                    if (method == null)
                        continue;

                    var entityPropValue = method.Invoke(baseMapper, new object[] { propValue });

                    entityPropInfo.SetValue(entity, entityPropValue);

                }
                else
                {
                    entityPropInfo.SetValue(entity, propValue);
                }
            }

            return entity;
        }
    }
}
