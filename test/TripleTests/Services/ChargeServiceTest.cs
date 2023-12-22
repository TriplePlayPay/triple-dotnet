using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Triple.Entities.Charges;
using Triple.Services;

namespace TripleTests.Services
{
    public class ChargeServiceTest : BaseTripleTest
    {
        private readonly ChargeService service;
        private readonly ChargeCreateOptions createOptions;

        public ChargeServiceTest(
            TripleMockFixture TripleMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(TripleMockFixture, mockHttpClientFixture)
        {
            this.service = new ChargeService(this.TripleClient);

            this.createOptions = new ChargeCreateOptions
            {
                Amount = 123,
                CreditCardNumber = "4242424242424242",
                CardVerificationValue = "123",
                ExpirationMonth = "05",
                ExpirationYear = "29",
                Source = "Testing",
            };
        }

        [Fact]
        public void Create()
        {
            var charge = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/charge");
            Assert.NotNull(charge);
            Assert.IsType<Charge>(charge);
            Assert.NotNull(charge.Id);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var charge = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/charge");
            Assert.NotNull(charge);
            Assert.IsType<Charge>(charge);
            Assert.NotNull(charge.Id);
        }
    }
}
