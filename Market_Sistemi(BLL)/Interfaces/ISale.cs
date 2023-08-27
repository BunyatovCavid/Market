using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface ISale
    {
        public Task<ICollection<SaleGetDto>> GetSalesAsync(int Number);
        public Task<ICollection<SaleAllGetDto>> GetAllSalesAsync(int Number);

        public Task<SaleGetDto> GetSaleByIdAsync(int Id);

        public Task<ICollection<SaleGetDto>> AddSaleAsync(SalePostDto dto);

        public Task<ICollection<SaleGetDto>> PutSaleAsync(SalePutDto dto);


        public Task<ICollection<SaleGetDto>> DeleteSaleAsync(int Id);
        public Task<ICollection<SaleAllGetDto>> DeleteSaleRealAsync(int Id);
        public Task<ICollection<SaleGetDto>> ReturnSaleAsync(int Id);



    }
}
