﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace lineten_adapters_inbevtex.Api.Filters
{
    /// <summary>
    /// Marker attribute to force a transaction to be applied to a specific controller or action
    /// </summary>
    public class ForceTransactionFilterAttribute : ActionFilterAttribute
    {
    }

}
