using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TestAuth.Core.Utils.Extensions;

namespace TestAuth.Api.Controllers.Base;

public class ControllerNameConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ControllerName = controller.ControllerName.ToLowerCaseWithDash();
    }
}

