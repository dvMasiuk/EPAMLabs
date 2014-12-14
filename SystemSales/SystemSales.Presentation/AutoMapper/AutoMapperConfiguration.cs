using SystemSales.Application.AutoMapperProfiles;
using AutoMapper;

namespace SystemSales.Presentation.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDtoMappingProfile>();
                x.AddProfile<DtoToViewModelMappingProfile>();
            });

            Mapper.AddProfile<DtoToEntityMappingProfile>();
            Mapper.AddProfile<EntityToDtoMappingProfile>();
        }
    }
}