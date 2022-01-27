using AutoMapper;
using Discount�ardApp.Application.DTOs.V1.Bank.Requests;
using Discount�ardApp.Application.DTOs.V1.Bank.Results;
using Discount�ardApp.Application.Models.V1.Bank.Requests;
using Discount�ardApp.Application.Models.V1.Bank.Results;
using Discount�ardApp.Application.Modules.Bank.Commands;
using Discount�ardApp.Application.Modules.Bank.Queries;

namespace Discount�ardApp.Application.Mapping
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

            CreateMap<GetBankQuery, GetBank>();
            CreateMap<CreateBankCommand, CreateBank>();
            CreateMap<UpdateBankCommand, UpdateBank>();
            CreateMap<DeleteBankCommand, DeleteBank>();

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