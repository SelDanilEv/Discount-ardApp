using AutoMapper;
using DiscountСardApp.Application.DTOs.V1.Bank.Requests;
using DiscountСardApp.Application.DTOs.V1.Bank.Results;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using DiscountСardApp.Application.Modules.Bank.Commands;
using DiscountСardApp.Application.Modules.Bank.Queries;

namespace DiscountСardApp.Application.Mapping
{
    public sealed class DtoV1MappingProfile : Profile
    {
        public DtoV1MappingProfile()
        {
            ConfigureRequestsMappings();

            ConfigureModelMappings();

            ConfigureDomainMappings();

            ConfigureSharedMappings();
        }

        private void ConfigureRequestsMappings()
        {
            #region Bank
            
            CreateMap<GetBankDto, GetBankQuery>();
            CreateMap<CreateBankDto, CreateBankCommand>();
            CreateMap<UpdateBankDto, UpdateBankCommand>();
            CreateMap<DeleteBankDto, DeleteBankCommand>();

            #endregion
        }

        private void ConfigureModelMappings()
        {
            #region Bank

            CreateMap<BankResult, BankResultDto>();

            #endregion
        }

        private void ConfigureDomainMappings()
        {
            //TODO: domain mapping here
        }

        private void ConfigureSharedMappings()
        {
            //TODO: shared mapping here
        }
    }
}