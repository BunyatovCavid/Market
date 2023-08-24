using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Visuals;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Market.Services
{
    public class CheckService : ICheck
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public CheckService(IMapper mapper, MarketDbContext db)
        {

            _db = db;
            _mapper = mapper;
        }
        public async Task<ICollection<CheckAllGetDto>> GetAllChecksAsync()
        {
            var data = await _db.Checks.ToListAsync();
            List<CheckAllGetDto> response = new();
            CheckAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CheckAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<CheckGetDto> GetCheckbyNumberAsync(int Id)
        {
            var data = await _db.Checks.FirstOrDefaultAsync(c => c.Id == Id && c.Description != "IsDelete");
            CheckGetDto response = _mapper.Map<CheckGetDto>(data);
            return response;
        }
        public async Task<ICollection<CheckGetDto>> GetChecksAsync()
        {
            var data = await _db.Checks.Where(c => c.Description != "IsDelete").ToListAsync();
            List<CheckGetDto> response = new();
            CheckGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CheckGetDto>(item);
                response.Add(request);
            }
            return response;
        }


        private async Task<CheckGetDto> GetCheckVisualForCreateAsync(int CheckNumber)
        {
            var data = await _db.CheckVisuals.FirstOrDefaultAsync(c => c.CheckNumber == CheckNumber);
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }
        private async Task<CheckBySaleGetDto> GetSaleVisualForUseDiscountAsync(int CheckId)
        {
            var data = await _db.SaleVisuals.Include(c => c.Item).FirstOrDefaultAsync(c => c.CheckId == CheckId);
            var response = _mapper.Map<CheckBySaleGetDto>(data);
            return response;
        }
        private async Task<CheckVisual> GetCheckVisualForAddAmountAsync(int CheckNumber)
        {
            var data = await _db.CheckVisuals.FirstOrDefaultAsync(c => c.CheckNumber == CheckNumber);
            return data;
        }
        private async Task<int> GetNumberForCreateCheck()
        {
            var data = await _db.CheckVisuals.OrderByDescending(c => c.CheckNumber).FirstOrDefaultAsync();
            int number;
            if (data != null)
            {
                if (data.CheckNumber == 0) number = 1;
                else number = data.CheckNumber + 1;
            }
            else number = 1;
            return number;
        }

        public async Task<CheckGetDto> CreateCheckAsync(CheckPostDto dto)
        {
            var request = _mapper.Map<CheckVisual>(dto);
            request.CheckNumber = await GetNumberForCreateCheck();
            await _db.CheckVisuals.AddAsync(request);
            await _db.SaveChangesAsync();

            var response = await GetCheckVisualForCreateAsync(request.CheckNumber);
            return response;
        }
        private async Task<float?> CalculateAmountAsync(int CheckId)
        {
            var data2 = await _db.SaleVisuals.Where(s => s.CheckId == CheckId).ToListAsync();
            float? amount = 0;
            foreach (var item in data2)
            {
                amount += item.Amount;
            }
            return amount;
        }
        public async Task<CheckGetDto> AddAmountInCheckAsync(AddAmountPostDto dto)
        {
            var data = await GetCheckVisualForAddAmountAsync(dto.CheckId);

            if (data != null)
            {
                data.Add_Amount = await CalculateAmountAsync(dto.CheckId);
                data.Out_Amount = data.Amount - data.Add_Amount;
                data.Final_Amount = data.Amount + data.Bonus_Amount;
            }
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }
        public async Task<CheckGetDto> UseBonus_CardAsync(UseCardPostDto dto)
        {
            var data = await GetCheckVisualForAddAmountAsync(dto.CheckId);
            var check_bonus_Card = await _db.Bonus_Cards.FirstOrDefaultAsync(b => b.Description != "IsDelete" && b.Barkod == dto.CardBarkod);
            if (data != null && check_bonus_Card != null && check_bonus_Card.Amount >= dto.Amount)
            {
                data.Bonus_Amount = -(dto.Amount);
            }
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }
        public async Task<CheckGetDto> UseDiscount_CardAsync(UseCardPostDto dto)
        {
            var data = await GetSaleVisualForUseDiscountAsync(dto.CheckId);
            if (data != null)
            {
                foreach (var item in data.Sales)
                {
                    if (item.Item.Sub_Category.Discount_Check == true)
                    {
                        item.Amount = (item.Amount / 100) * 90;
                    }
                }
            }
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }

        private async Task AddBonus(Bonus_Card_ReportPostDto dto)
        {
            Bonus_Card_Report request = new() { Bonus_CardId = dto.Barkod, Amount = dto.Amount, AccountId = dto.AccountId, Date = DateTime.Now };
            await _db.Bonus_Card_Reports.AddAsync(request);
        }
        private async Task<Check> GetCheckBySaleAndRemoveCheckVisualAsync(int CheckId)
        {
                var data = await _db.CheckVisuals.Include(c => c.SaleVisuals).FirstOrDefaultAsync(c => c.CheckNumber == CheckId);
                var response = _mapper.Map<Check>(data);
                _db.CheckVisuals.Remove(data);
                return response;
    
        }
        public async Task<CheckGetDto> SaveCheckByIncluded(int CheckId)
        {
            var data = await _db.CheckVisuals.FirstOrDefaultAsync(c=>c.CheckNumber==CheckId);
            if (data != null)
            {
                var request = _mapper.Map< Check > (data);
                await _db.Checks.AddAsync(request);

                Bonus_Card_ReportPostDto bonus_request = new() { Amount = Convert.ToInt32((data.Amount / 100) + data.Bonus_Amount), Barkod = Convert.ToInt32(data.Bonus_CardId), AccountId = data.AccountId };
                await AddBonus(bonus_request);

                await _db.SaveChangesAsync();
            }
            var response = await GetCheckbyNumberAsync(data.CheckNumber);
            return response;
        }



        private async Task<Check> GetCheckByIdForDeleteAsync(int CheckNumber)
        {
            var data = await _db.Checks.Include(c => c.Sales).FirstOrDefaultAsync(c => c.CheckNumber == CheckNumber);
            return data;
        }
        public async Task<ICollection<CheckGetDto>> DeleteCheckAsync(int Number)
        {
            var data = await GetCheckByIdForDeleteAsync(Number);
            if (data != null)
            {
                data.Description = "IsDelete";
                foreach (var item in data.Sales)
                {
                    item.Description = "IsDelete";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetChecksAsync();
            return response;
        }

        public async Task<ICollection<CheckAllGetDto>> DeleteCheckRealAsync(int Number)
        {
            var data = await GetCheckByIdForDeleteAsync(Number);
            if (data != null)
            {
                _db.Checks.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAllChecksAsync();
            return response;
        }

        public async Task<ICollection<CheckAllGetDto>> ReturnCheckAsync(int Number)
        {
            var data = await GetCheckByIdForDeleteAsync(Number);
            if (data != null)
            {
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetAllChecksAsync();
            return response;
        }




    }
}
