using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IPaper
    {
        public Task<ICollection<PaperGetDto>> GetPapers();

        public Task<ICollection<PaperGetDto>> GetAllPapers();

        public Task<PaperGetDto> GetPaperbyNumber(int Number);

        public Task<PaperGetDto> CreatePaper(PaperPostDto dto);

        public Task<ICollection<PaperGetDto>> PutPaper(PaperPutDto dto);

        public Task<ICollection<PaperGetDto>> DeletePaper(int Number);
        public Task<ICollection<PaperGetDto>> SavePaperByIncluded();

    }
}
