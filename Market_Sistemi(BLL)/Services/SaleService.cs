using AutoMapper;
using Market.Domain.Entities;
using Market.Domain;
using Market.Dtoes.Get_Dtoes;
using Microsoft.EntityFrameworkCore;
using Market.Interfaces;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.PutDto;
using Market.Dtoes.PostDtoes;
using AutoMapper.Execution;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Market.Services
{
    public class SaleService : ISale
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public SaleService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }


        private ICollection<SaleAllGetDto> Get_BackALl(List<Sale> data)
        {
            List<SaleAllGetDto> response = new();
            SaleAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<SaleAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }


        public async Task<ICollection<SaleAllGetDto>> GetAllSalesAsync(int Number)
        {
            var data = await _db.Sales.Where(s => s.CheckId == Number).ToListAsync();
            var response = Get_BackALl(data);
            return response;

        }
        public async Task<SaleGetDto> GetSaleByIdAsync(int Id)
        {
            var data = await _db.Sales.FirstOrDefaultAsync(s => s.Description != "IsDelete" && s.Id == Id);
            var response = _mapper.Map<SaleGetDto>(data);
            return response;
        }



        private ICollection<SaleGetDto> Get_Back(List<Sale> data)
        {
            List<SaleGetDto> response = new();
            SaleGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<SaleGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<SaleGetDto>> GetSalesAsync(int Number)
        {
            var data = await _db.Sales.Where(s => s.CheckId == Number && s.Description != "IsDelete").ToListAsync();
            var response = Get_Back(data);
            return response;
        }
        private async Task<Sale> GetSaleByIdForPut(int Id)
        {
            var data = await _db.Sales.FirstOrDefaultAsync(s => s.Description != "IsDelete" && s.Id == Id);
            return data;
        }
        public async Task<ICollection<SaleGetDto>> PutSaleAsync(SalePutDto dto)
        {
            var data = await GetSaleByIdForPut(dto.Id);
            if (data != null && dto.Number > 0)
            {
                data.Number = dto.Number;
                await _db.SaveChangesAsync();
            }
            var response = await GetSalesAsync(dto.CheckNumber);
            return response;
        }

        private async Task<Sale> GetSaleByIdForDelete(int Id)
        {
            var data = await _db.Sales.FirstOrDefaultAsync(s => s.Id == Id);
            return data;
        }
        public async Task<ICollection<SaleGetDto>> DeleteSaleAsync(int Id)
        {
            var data = await GetSaleByIdForPut(Id);
            ICollection<SaleGetDto> response = null;
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
                response = await GetSalesAsync(data.CheckId);
            }
            return response;
        }
        public async Task<ICollection<SaleAllGetDto>> DeleteSaleRealAsync(int Id)
        {
            var data = await GetSaleByIdForDelete(Id);
            ICollection<SaleAllGetDto> response = null;
            if (data != null)
            {
                _db.Sales.Remove(data);
                await _db.SaveChangesAsync();

                response = await GetAllSalesAsync(data.CheckId);
            }
            return response;
        }
        public async Task<ICollection<SaleGetDto>> ReturnSaleAsync(int Id)
        {
            var data = await GetSaleByIdForDelete(Id);
            ICollection<SaleGetDto> response = null;
            if (data != null && data.Description == "IsDelete")
            {
                data.Description = "ReturnData";
                response = await GetSalesAsync(data.CheckId);
            }
            return response;
        }


        public async Task<ICollection<SaleGetDto>> AddSaleAsync(SalePostDto dto)
        {
            var check = await _db.Sales.FirstOrDefaultAsync(s => s.CheckId == dto.CheckId && s.ItemId == dto.ItemId);
            var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == dto.ItemId);
            if (check != null && item!=null)
            {
                check.Number += dto.Number;
                check.Amount += dto.Number * item.Amount;
            }
            else
            {
                if (item != null)
                {
                    var data = _mapper.Map<Sale>(dto);
                    data.Amount = data.Number * item.Amount;
                    await _db.Sales.AddAsync(data);
                }
            }
            await _db.SaveChangesAsync();

            var response = await GetSalesAsync(dto.CheckId);
            return response;
        }



    }
}
