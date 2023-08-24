using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;

namespace Market.Interfaces
{
    public interface ICompany
    {
        public Task<ICollection<CompanyGetDto>> GetCompanyAsync();
        public Task<ICollection<CompanyAllGetDo>> GetAllCompanyAsync();
        public Task<CompanyGetDto> GetCompanyByIdAsync(int Id);

        public Task<ICollection<CompanyGetDto>> CreateCompanyAsync(CompanyPostDto dto);

        public Task<ICollection<CompanyGetDto>> PutCompanyAsync(CompanyPutDto dto);

        public Task<ICollection<CompanyGetDto>> DeleteCompanyAsync(int ID);
        public Task<ICollection<CompanyAllGetDo>> DeleteCompanyRealAsync(int id);

        public Task<ICollection<CompanyAllGetDo>> ReturnCompanyAsync(int Id);

    }
}
