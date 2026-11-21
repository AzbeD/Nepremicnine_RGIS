using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nepremicnine_RGIS.Controllers;

namespace Nepremicnine_RGIS.Tests
{
    [TestClass]
    public sealed class Testi
    {
        private BazaContext NovaBaza()
        {
            var options = new DbContextOptionsBuilder<BazaContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new BazaContext(options);
        }

        [TestMethod]
        public async Task TestRegistracijaOK()
        {
            var controller = new AvtentikacijaController(NovaBaza());
            var dto = new RegistracijaDTO
            {
                UporabniskoIme = "user1",
                Geslo = "Geslo123"
            };
            var result = await controller.Registracija(dto);
            var statusResult = Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(201, statusResult.StatusCode);
        }
    }
}
