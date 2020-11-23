using Microsoft.AspNetCore.Mvc.Filters;

namespace lineten_adapters_inbevtex.Api.Filters
{
    /// <summary>
     /// Marker attribute to exclude a specific controller or action participating in a transaction
    /// </summary>
    public class SuppressTransactionFilterAttribute : ActionFilterAttribute
    {
    }

}
