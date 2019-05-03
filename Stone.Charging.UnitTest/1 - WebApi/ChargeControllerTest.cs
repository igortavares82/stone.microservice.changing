using Stone.Charging.Messages;
using Stone.Charging.UnitTest.DataProviders;
using Stone.Charging.UnitTest.Helpers;
using Stone.Charging.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Charging.UnitTest.WebApi
{
    public class ChargeControllerTest
    {
        [Theory]
        [MemberData(nameof(ChargeMessageDataProvider.GetValidCharge), MemberType = typeof(ChargeMessageDataProvider))]
        public async Task RegisterCharge_ValidateAllData_ReturnsTrue(ChargeMessage chargeMessage)
        {
            // Arrange
            ChargeController controller = ChargeControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(chargeMessage) as IApplicationResult<bool>;

            // Assert
            Assert.True(result.Data);
        }

        [Theory]
        [MemberData(nameof(ChargeMessageDataProvider.GetInvalidCpfChargeMessage), MemberType = typeof(ChargeMessageDataProvider))]
        public async Task RegisterCharge_ValidateCpf_ReturnsFalse(ChargeMessage chargeMessage)
        {
            // Arrange
            ChargeController controller = ChargeControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(chargeMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("Cpf", result.Messages.First());
        }


        [Theory]
        [MemberData(nameof(ChargeMessageDataProvider.GetInvalidMatirityChargeMessage), MemberType = typeof(ChargeMessageDataProvider))]
        public async Task RegisterCharge_ValidateMaturity_ReturnsFalse(ChargeMessage chargeMessage)
        {
            // Arrange
            ChargeController controller = ChargeControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(chargeMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("Maturity", result.Messages.First());
        }


        [Theory]
        [MemberData(nameof(ChargeMessageDataProvider.GetInvalidValueChargeMessage), MemberType = typeof(ChargeMessageDataProvider))]
        public async Task RegisterCharge_ValidateValue_ReturnsFalse(ChargeMessage chargeMessage)
        {
            // Arrange
            ChargeController controller = ChargeControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(chargeMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("Value", result.Messages.First());
        }
    }
}
