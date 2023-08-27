using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
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
        private IBonus_Card _bonus;

        public CheckService(IMapper mapper, MarketDbContext db, IBonus_Card bonus)
        {
            _bonus = bonus;
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
        public async Task<CheckGetDto> GetCheckbyIdAsync(int Id)
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



        public async Task<ICollection<CheckGetDto>> CreateCheckAsync(CheckPostDto dto)
        {
            var check = await GetCheckbyIdAsync(dto.CashId);
            if (check == null)
            {
                var request = _mapper.Map<Check>(dto);
                request.Date = DateTime.Now;
                await _db.Checks.AddAsync(request);
                await _db.SaveChangesAsync();
            }
            var response = await GetChecksAsync();
            return response;
        }
        private async Task<float?> CalculateAmountAsync(int CheckId)
        {
            var data2 = await _db.Sales.Where(s => s.CheckId == CheckId).ToListAsync();
            float? amount = 0;
            foreach (var item in data2)
            {
                amount += item.Amount;
            }
            return amount;
        }
        public async Task<CheckGetDto> AddAmountInCheckAsync(AddAmountPostDto dto)
        {
            var data = await GetCheckByIdForDeleteAsync(dto.CheckId);

            if (data != null)
            {
                data.Add_Amount = await CalculateAmountAsync(dto.CheckId);
                data.Out_Amount = data.Amount - data.Add_Amount;
                if (data.Bonus_Amount != null)
                {
                    data.Final_Amount = data.Amount - (data.Bonus_Amount/10);
                }
                else
                {
                    data.Final_Amount = data.Amount;
                }
                await _db.SaveChangesAsync();
            }
           
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }
        public async Task<CheckGetDto> UseBonus_CardAsync(UseCardPostDto dto)
        {
            var data = await GetCheckByIdForDeleteAsync(dto.CheckId);
            var check_bonus_Card = await _db.Bonus_Cards.FirstOrDefaultAsync(b => b.Description != "IsDelete" && b.Barkod == dto.CardBarkod);
            if (data != null && check_bonus_Card != null)
            {
                data.Bonus_CardId = dto.CardBarkod;
                data.Bonus_Amount += Convert.ToInt32((data.Amount / 100));
            }
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }

        public async Task<CheckGetDto> UseDiscount_CardAsync(UseCardPostDto dto)
        {
            var data = await GetCheckByIdForDeleteAsync(dto.CheckId);
            if (data != null)
            {
                foreach (var item in data.Sales)
                {
                    if (item.Item.Sub_Category.Discount_Check == true)
                    {
                        item.Amount = (item.Amount / 100) * 90;
                    }
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetCheckbyIdAsync(dto.CheckId);
            return response;
        }

        private async Task IncreedDecreedItems(Check data, string symbol)
        {
            foreach (var item in data.Sales)
            {
                var request = await _db.Items.FirstOrDefaultAsync(c=>c.Id==item.ItemId);
                if (symbol == "+")
                    request.Number += item.Number;
                else if (symbol == "-")
                    request.Number -= item.Number;

            }
        }


        public async Task<CheckGetDto> SaveCheckByIncluded(int CheckId)
        {
            var data = await GetCheckByIdForDeleteAsync(CheckId);
            if(data.Bonus_CardId != null)
            {
                IncreedDecreedItems(data, "+");   
                _bonus.CreateBonus_CardReportAsync(new() { Barkod = (int)data.Bonus_CardId, Amount = (int)data.Bonus_Amount });
            }
            var response = _mapper.Map<CheckGetDto>(data);
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
                IncreedDecreedItems(data, "-");
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
                if(data.Description !="IsDelete")
                {
                    IncreedDecreedItems(data, "-");
                }
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
                IncreedDecreedItems(data, "+");
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetAllChecksAsync();
            return response;
        }

        public async Task<CheckGetDto> UseBonusAsync(UseCardPostDto dto)
        {
            var data = await GetCheckByIdForDeleteAsync(dto.CheckId);
            var check_bonus_Card = await _db.Bonus_Cards.FirstOrDefaultAsync(b => b.Description != "IsDelete" && b.Barkod == dto.CardBarkod);
            if (data!=null && data.Bonus_CardId !=null &&  check_bonus_Card.Amount>=dto.Amount)
            {
                data.Bonus_Amount +=( -dto.Amount);
            }
            var response = await GetCheckbyIdAsync(dto.CheckId);
            return response;
        }
    }
}
