using Market.Dtoes.Get_Dtoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Independents
{
    public class Response : Controller
    {
        public async Task<IActionResult> GetResponse<TEnity>(TEnity data) where TEnity : class
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        public async Task<IActionResult> CheckState<TEntity>(TEntity dto) where TEntity : class
        {
            if (!ModelState.IsValid)
            {
                var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
                return BadRequest(response);
            }
            return null;

        }
    }
}
