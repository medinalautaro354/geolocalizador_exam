using System;

namespace AdreaniExam.DataTransferObjects.Factories.Mappers
{
    abstract class MapperEntityBase<TEntity, TDto> where TDto : class, new() where TEntity : class
    {
        protected abstract void MapEntityToDtoBase<T>(TEntity entity, T dto) where T : TDto;

        public T CreateDtoBase<T>(TEntity entity, T dto = null) where T : class, TDto, new()
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (dto == null)
            {
                dto = new T();
            }

            MapEntityToDtoBase(entity, dto);

            return dto;
        }
    }
}
