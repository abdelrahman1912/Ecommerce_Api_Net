using ECommerce.lib.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ECommerce.lib.Exeptions
{
    public class ExiptionHandleMiddle(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (DbUpdateException ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExiptionHandleMiddle>>();

                logger.LogError(ex, "Database update error");

                var sqlEx = ex.InnerException as SqlException;

                context.Response.ContentType = "text/plain";

                if (sqlEx != null)
                {
                    switch (sqlEx.Number)
                    {
                        case 2627:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("Duplicate entry (unique constraint violation).");
                            return;

                        case 515:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("A required field is missing.");
                            return;

                        case 547:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Foreign key constraint violation.");
                            return;

                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync(sqlEx.Message);
                            return;
                    }
                }

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExiptionHandleMiddle>>();

                logger.LogError(ex, "Unhandled error");

                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}