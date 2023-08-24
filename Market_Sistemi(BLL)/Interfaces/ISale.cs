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

        public Task<ICollection<SaleGetDto>> AddSaleVisualAsync(SalePostDto dto);

        public Task<ICollection<SaleGetDto>> PutSaleOwnerAsync(SalePutDto dto);
        public Task<ICollection<SaleGetDto>> PutSaleVisualAsync(SalePutDto dto);
        public Task<ICollection<SaleGetDto>> PutSaleVisualOwnerAsync(SalePutDto dto);

        public Task<ICollection<SaleGetDto>> DeleteSaleVisualAsync(int Id);
        public Task<ICollection<SaleGetDto>> DeleteSaleAsync(int Id);
        public Task<ICollection<SaleAllGetDto>> DeleteSaleRealAsync(int Id);
        public Task<ICollection<SaleGetDto>> ReturnSaleAsync(int Id);


        public Task<ICollection<SaleGetDto>> GetSaleVisualAsync(int Number);



    }
}
