using AutoMapper;

namespace SystemSales.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DtoToEntityMappingProfile>();
                x.AddProfile<EntityToDtoMappingProfile>();
            });
        }
    }
}