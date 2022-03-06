using AutoMapper;
using DiscountCardApp.Application.DTOs.V1.BankDto.Requests;
using DiscountCardApp.Application.DTOs.V1.BankDto.Results;
using DiscountCardApp.Application.DTOs.V1.CategoryDto.Requests;
using DiscountCardApp.Application.DTOs.V1.CategoryDto.Results;
using DiscountCardApp.Application.DTOs.V1.CommercialNetworkDto.Requests;
using DiscountCardApp.Application.DTOs.V1.CommercialNetworkDto.Results;
using DiscountCardApp.Application.DTOs.V1.DashboardDto.Results;
using DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Requests;
using DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Results;
using DiscountCardApp.Application.DTOs.V1.EmptyResult;
using DiscountCardApp.Application.DTOs.V1.MCCCodeDto.Requests;
using DiscountCardApp.Application.DTOs.V1.MCCCodeDto.Results;
using DiscountCardApp.Application.DTOs.V1.StoreDto.Requests;
using DiscountCardApp.Application.DTOs.V1.StoreDto.Results;
using DiscountCardApp.Application.Models.V1.Bank.Results;
using DiscountCardApp.Application.Models.V1.Category.Results;
using DiscountCardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountCardApp.Application.Models.V1.Dashboard.Results;
using DiscountCardApp.Application.Models.V1.DiscountCard.Results;
using DiscountCardApp.Application.Models.V1.EmptyResult;
using DiscountCardApp.Application.Models.V1.MCCCode.Results;
using DiscountCardApp.Application.Models.V1.Store.Results;
using DiscountCardApp.Application.Modules.BankModule.Commands;
using DiscountCardApp.Application.Modules.BankModule.Queries;
using DiscountCardApp.Application.Modules.CategoryModule.Commands;
using DiscountCardApp.Application.Modules.CategoryModule.Queries;
using DiscountCardApp.Application.Modules.CommercialNetworkModule.Commands;
using DiscountCardApp.Application.Modules.CommercialNetworkModule.Queries;
using DiscountCardApp.Application.Modules.DiscountCardModule.Commands;
using DiscountCardApp.Application.Modules.DiscountCardModule.Queries;
using DiscountCardApp.Application.Modules.MCCCodeModule.Commands;
using DiscountCardApp.Application.Modules.MCCCodeModule.Queries;
using DiscountCardApp.Application.Modules.StoreModule.Commands;
using DiscountCardApp.Application.Modules.StoreModule.Queries;
using DiscountCardApp.Domain.EntityModels;

namespace DiscountCardApp.Application.Mapping
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

            #region Category

            CreateMap<GetCategoryDto, GetCategoryQuery>();
            CreateMap<CreateCategoryDto, CreateCategoryCommand>();
            CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
            CreateMap<DeleteCategoryDto, DeleteCategoryCommand>();

            CreateMap<ReplaceCategoryCodesDto, ReplaceCategoryCodesCommand>();

            #endregion

            #region MCCCode

            CreateMap<GetMCCCodeDto, GetMCCCodeQuery>();
            CreateMap<CreateMCCCodeDto, CreateMCCCodeCommand>();
            CreateMap<UpdateMCCCodeDto, UpdateMCCCodeCommand>();
            CreateMap<DeleteMCCCodeDto, DeleteMCCCodeCommand>();

            #endregion

            #region CommercialNetwork

            CreateMap<GetCommercialNetworkDto, GetCommercialNetworkQuery>();
            CreateMap<CreateCommercialNetworkDto, CreateCommercialNetworkCommand>();
            CreateMap<UpdateCommercialNetworkDto, UpdateCommercialNetworkCommand>();
            CreateMap<DeleteCommercialNetworkDto, DeleteCommercialNetworkCommand>();

            #endregion

            #region Store

            CreateMap<GetStoreDto, GetStoreQuery>();
            CreateMap<CreateStoreDto, CreateStoreCommand>();
            CreateMap<UpdateStoreDto, UpdateStoreCommand>();
            CreateMap<DeleteStoreDto, DeleteStoreCommand>();

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

            #region Category

            CreateMap<CategoryResult, CategoryResultDto>();
            CreateMap<ReplaceCodesResult, ReplaceCategoryCodesResultDto>();

            #endregion

            #region MCCCode

            CreateMap<MCCCodeResult, MCCCodeResultDto>();

            #endregion

            #region CommercialNetwork

            CreateMap<CommercialNetworkResult, CommercialNetworkResultDto>();

            #endregion

            #region Store

            CreateMap<StoreResult, StoreResultDto>();

            #endregion

            #region EmptyResult

            CreateMap<EmptyResult, EmptyResultDto>();

            #endregion

            #region Dashboard

            CreateMap<DashboardResult, DashboardResultDto>();

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

            #region Category

            CreateMap<CreateCategoryCommand, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CategoryResult>();

            CreateMap<Domain.Entities.Category, Category>();

            #endregion

            #region MCCCode

            CreateMap<CreateMCCCodeCommand, Domain.Entities.MCCCode>();
            CreateMap<Domain.Entities.MCCCode, MCCCodeResult>();

            CreateMap<Domain.Entities.MCCCode, MCCCode>();

            #endregion

            #region CommercialNetwork

            CreateMap<CreateCommercialNetworkCommand, Domain.Entities.CommercialNetwork>();
            CreateMap<Domain.Entities.CommercialNetwork, CommercialNetworkResult>();

            CreateMap<Domain.Entities.CommercialNetwork, CommercialNetwork>();

            #endregion

            #region Store

            CreateMap<CreateStoreCommand, Domain.Entities.Store>()
                .ForMember(x => x.MCCCode, opt => opt.Ignore());
            CreateMap<Domain.Entities.Store, StoreResult>();

            CreateMap<Domain.Entities.Store, Store>();

            #endregion
        }

        private void ConfigureSharedMappings()
        {

        }
    }
}