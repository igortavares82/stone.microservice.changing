using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Core;
using Stone.Charging.Messages;
using Stone.Charging.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using Stone.Framework.Utils.ModelValidator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.UnitTest.Helpers
{
    public class ChargeControllerHelper
    {
        internal static ChargeController GetMock()
        {
            ChargeController controller = Substitute.For<ChargeController>(ChargeApplicationHelper.GetMock());
            controller.PostAsync(Arg.Any<ChargeMessage>()).Returns(PostAsyncReturn);

            return controller;
        }

        private static async Task<IActionResult> PostAsyncReturn(CallInfo info)
        {
            IApplicationResult<bool> result = new ApplicationResult<bool>();
            Tuple<bool, List<string>> validationResult = Validator.Validate(info.Arg<ChargeMessage>());

            result.Data = validationResult.Item1;
            result.Messages.AddRange(validationResult.Item2);

            return result;
        }
    }
}
