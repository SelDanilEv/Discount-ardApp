using AutoMapper;

namespace Discount—ardApp.Application.Mapping
{
    public sealed class DtoV1MappingProfile : Profile
    {
        public DtoV1MappingProfile()
        {
            ConfigureModelMappings();

            ConfigureDomainMappings();

            ConfigureRequestsMappings();

            ConfigureSharedMappings();
        }

        private void ConfigureModelMappings()
        {
            //TODO: models mapping here
        }

        private void ConfigureDomainMappings()
        {
            //TODO: domain mapping here
        }

        private void ConfigureRequestsMappings()
        {
            //TODO: request mapping here
        }

        private void ConfigureSharedMappings()
        {
            //TODO: shared mapping here
        }
    }
}