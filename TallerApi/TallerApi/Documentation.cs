using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TallerApi
{
    public class Documentation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var routePath = context.ApiDescription.RelativePath;
            var routeVerb = context.ApiDescription.HttpMethod;

            if (!string.IsNullOrEmpty(routePath))
            {
                if (routePath.ToString().Equals("Customer") && routeVerb == HttpMethod.Get.Method)
                {
                    operation.Summary = "Get all customers";
                    operation.Description = "List all the customers in the database";
                }
                if (routePath.ToString().Equals("Customer") && routeVerb == HttpMethod.Post.Method)
                {
                    operation.Summary = "Register a customer";
                    operation.Description = "Save a new customer in the database";
                }
            }
        }
    }
}
