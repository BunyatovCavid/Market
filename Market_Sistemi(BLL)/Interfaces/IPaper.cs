using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;

namespace Market.Interfaces
{
    public interface IPaper
    {
        public Task<ICollection<PaperGetDto>> GetPapers();

        public Task<ICollection<PaperAllGetDto>> GetAllPapers();

        public Task<PaperGetDto> GetPaperbyNumber(int Number);

        public Task<PaperGetDto> CreatePaper(PaperPostDto dto);

        public Task<ICollection<PaperGetDto>> PutPaper(PaperPutDto dto);

        public Task<ICollection<PaperGetDto>> DeletePaper(int Id);
        public Task<ICollection<PaperAllGetDto>> DeletePaperReal(int Id);
        public Task<ICollection<PaperAllGetDto>> ReturnDelete(int Id);

    }
}
