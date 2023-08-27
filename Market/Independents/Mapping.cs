using AutoMapper;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Market_Sistemi_BLL_.Dtoes.PostDtoes;
using Market_Sistemi_BLL_.Interfaces;

namespace Market.Independents
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<LoginDto, Account>();
            CreateMap<LoginDto, RegisterDto>();
            CreateMap<Account, AccountGetDto>();
            CreateMap<AccountPutDto, AccountGetDto>();
            CreateMap<AccountPutDto, Account>();
            CreateMap<Account, AccountAllGetDto>();

            CreateMap<Account, CrossGetDto>();
            CreateMap<Cross_Account_Role, Cross_Account_RoleBackGetDto>();




            CreateMap<Item, ItemGetDto>();
            CreateMap<ItemGetDto, Item>();
            CreateMap<ItemPutDto, ItemGetDto>();
            CreateMap<ItemPostDto, Item >();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<RolePostDto, Role>();
            CreateMap<List<Role>?, ICollection<RoleDto>?>();


            CreateMap<PaperPostDto, Paper>();
            CreateMap<Paper, PaperGetDto>();
            CreateMap<PaperPutDto, Paper>();
            CreateMap<Paper, PaperAllGetDto>();

            CreateMap<Included, IncludedGetDto>();
            CreateMap<IncludedGetDto, Included>();

            CreateMap<Cash, CashGetDto>();
            CreateMap<CashPostDto, Cash>();
            CreateMap<CashPutDto, Cash>();


            CreateMap<CheckPostDto, Check>();
            CreateMap<Check, CheckGetDto>();
            CreateMap<CheckGetDto, Check>();


            CreateMap<Sale, SaleGetDto>();
            CreateMap<Sale, SaleAllGetDto>();
            CreateMap<SaleGetDto, Sale>();

            CreateMap<Discount_Card, Discount_CardGetDto>();
            CreateMap<Discount_Card, Discount_CardAllGetDto>();
            CreateMap<Discount_CardPostDto, Discount_Card>();
            CreateMap<Discount_CardPutDto, Discount_Card>();

            CreateMap<Bonus_Card, Bonus_CardGetDto>();
            CreateMap<Bonus_CardPostDto, Bonus_Card>();
            CreateMap<Bonus_cardPutDto, Bonus_Card>();
            CreateMap<Bonus_Card, Bonus_CardAllGetDto>();

            CreateMap<Bonus_Card_Report, Bonus_Card_ReportGetDto>();
            CreateMap<Bonus_CardPostDto, Bonus_Card_Report>();


            CreateMap<Category, CategoryGetDto>();
            CreateMap<Category, CategoryAllGetDto>();
            CreateMap<Category, CategoryBySub_CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();

            CreateMap<Sub_Category, Sub_CategoryAllGetDto>();
            CreateMap<Sub_Category, Sub_CategoryGetDto>();
            CreateMap<Sub_CategoryPostDto, Sub_Category>();
            CreateMap<Sub_CategoryPutDto, Sub_Category>();

            CreateMap<Company, CompanyAllGetDo>();
            CreateMap<Company, CompanyGetDto>();
            CreateMap<CompanyPostDto, Company>();


        }
    }
}
