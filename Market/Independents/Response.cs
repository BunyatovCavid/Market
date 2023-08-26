using Market.Dtoes.Get_Dtoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Market.Independents
{
    public class Response : Controller
    {
        public IActionResult GetResponse<TEnity>(TEnity data) where TEnity : class
        {
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        public IActionResult CheckState<TEntity>(TEntity dto) where TEntity : class
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
