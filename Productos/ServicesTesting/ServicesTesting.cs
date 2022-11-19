using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Producto.Core.CustomEntities;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
using Producto.Core.Services;
using System.Threading.Tasks;

namespace ServicesTesting
{
    [TestClass]
    public class ServicesTesting
    {     

        [TestMethod]
        public async Task GetProduct_ShoulReturnSameProductAsync()
        {
            //Arrange
            Mock<IProductsService> IproductService = new Mock<IProductsService>();
            Mock<IUnitOfWork> unitofwork = new Mock<IUnitOfWork>();
            
            //Act
            ProductsService productsService = new ProductsService(unitofwork.Object);
            int Product_Id = 1;

            //Assert
            Assert.AreEqual(Product_Id, productsService.GetProduct(Product_Id).Id);

        }

        [TestMethod]
        public async Task InsertProducts_ShoulReturnSameProductAsync()
        {
            Mock<IProductsService> IproductService = new Mock<IProductsService>();
            Mock<IUnitOfWork> unitofwork = new Mock<IUnitOfWork>();
            ProductsService productsService = new ProductsService(unitofwork.Object);
            Products productsEntities = new Products();

            var products = new {
                descripcion = "Leche xxxxxx",
                estado_Producto = "Activo",
                fecha_Fabricacion = "2022-11-11",
                fecha_Validez = "2023-11-11",
                codigo_Proveedor = 1
            };

            //var response = await productsService.InsertProduct(productsEntities products).Id;

            //Assert.AreEqual(Product_Id, prod);

        }

    }
}
