using AutoMapper;
using DiscountСardApp.Application.DTOs.V1.BankDto.Requests;
using DiscountСardApp.Application.DTOs.V1.BankDto.Results;
using DiscountСardApp.Application.DTOs.V1.DiscountCardDto.Requests;
using DiscountСardApp.Application.DTOs.V1.DiscountCardDto.Results;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Application.Modules.BankModule.Commands;
using DiscountСardApp.Application.Modules.BankModule.Queries;
using DiscountСardApp.Application.Modules.DiscountCardModule.Commands;
using DiscountСardApp.Application.Modules.DiscountCardModule.Queries;
using DiscountСardApp.Domain.EntityModels;

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


            #region DiscountCard

            CreateMap<GetDiscountCardDto, GetDiscountCardQuery>();
            CreateMap<CreateDiscountCardDto, CreateDiscountCardCommand>();
            CreateMap<UpdateDiscountCardDto, UpdateDiscountCardCommand>();
            CreateMap<DeleteDiscountCardDto, DeleteDiscountCardCommand>();

            #endregion
        }

        private void ConfigureModelMappings()
        {
            #region Bank

            CreateMap<BankResult, BankResultDto>();

            #endregion

            #region DiscountCard

            CreateMap<DiscountCardResult, DiscountCardResultDto>();

            #endregion
        }

        private void ConfigureDomainMappings()
        {
            #region Bank

            CreateMap<CreateBankCommand, Domain.Entities.Bank>();
            CreateMap<Domain.Entities.Bank, BankResult>();

            CreateMap<Domain.Entities.Bank, Bank>();

            #endregion

            #region DiscountCard

            CreateMap<CreateDiscountCardCommand, Domain.Entities.DiscountCard>();
            CreateMap<Domain.Entities.DiscountCard, DiscountCardResult>();

            CreateMap<Domain.Entities.DiscountCard, DiscountCard>();

            #endregion


        }

        private void ConfigureSharedMappings()
        {
            //TODO: shared mapping here
        }
    }
}