using AutoMapper;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;

namespace Market
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<LoginDto, Account>();  
            CreateMap<LoginDto, RegisterDto>();  
            CreateMap<Account?, Account>();
            CreateMap<AccountPutDto, Account>(); 
        }
    }
}
