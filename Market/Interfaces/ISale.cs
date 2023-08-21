using Market.Dtoes.Get_Dtoes;

namespace Market.Interfaces
{
    public interface ISale
    {
        public Task<ICollection<SaleGetDto>> GetSales(int Number);

        public Task<SaleGetDto> GetSaleById(int Id);
        public Task<ICollection<SaleGetDto>> GetAllSale(int id);

        public Task<ICollection<SaleGetDto>> AddSale(SaleGetDto dto);

        public Task<ICollection<SaleGetDto>> PutSale(SaleGetDto dto);

        public Task<ICollection<SaleGetDto>> DeleteSale(int Id);
    }
}
