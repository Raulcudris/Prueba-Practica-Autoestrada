using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Producto.Core.Interfaces;
using Producto.Core.Services;

namespace ControllerTesting
{
    [TestClass]
    public class ControllerTesting
    {
        [TestMethod]
        public void GetProduct_ShoulReturnSameProductAsync()
        {
            //Arrange
            Mock<IProductsService> IproductService = new Mock<IProductsService>();
            Mock<IUnitOfWork> unitofwork = new Mock<IUnitOfWork>();
        }
    }
}
