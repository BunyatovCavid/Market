using Market.Dtoes.Get_Dtoes;
using Microsoft.AspNetCore.Mvc;

namespace Market
{
    public class Response:Controller
    {
        public async Task<IActionResult> GetResponse(ICollection<CategoryGetDto> data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(CategoryGetDto data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(ICollection<CategoryBySub_CategoryGetDto> data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(CategoryBySub_CategoryGetDto data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(ICollection<CategoryAllGetDto> data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(ICollection<Sub_CategoryGetDto> data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(Sub_CategoryGetDto data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> GetResponse(ICollection<Sub_CategoryAllGetDto> data)
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}
