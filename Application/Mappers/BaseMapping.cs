using AutoMapper;

namespace Application.Mappers
{
    public abstract class BaseMapping<S, T> : Profile
    {

        protected BaseMapping()
        {
            var createMap = CreateMap<S, T>();
            createMap.ForAllMembers(config => config.Condition((src, dest, srcMember) => srcMember != null));
            doComplexMapping(createMap);
        }

        protected virtual void doComplexMapping(IMappingExpression<S,T> createMap)
        {

        }

    }
}
