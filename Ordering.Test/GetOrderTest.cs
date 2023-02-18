using AutoMapper;
using Moq;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Test
{
    public class GetOrderTest
    {
        private readonly Mock<IGenericRepository<Order>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetOrdersListQueryHandler _hanlder;

        public GetOrderTest()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IGenericRepository<Order>>();
            _hanlder = new GetOrdersListQueryHandler(_repositoryMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task Handle_ShouldGetOrdersList()
        {
            //Arrange
            var request = new GetOrdersListQuery() { UserName = "Yael" };
            var orders = new List<Order>
            {
                new Order { Id=1, FirstName = "Yael", UserName = "Yael", AddressLine = "Direccione" },
                new Order {Id = 2, FirstName = "Juan", UserName = "Juan", AddressLine = "Otra direccion" }
            };

            var ordersViewModel = new List<OrdersListViewModel>
            {
              new OrdersListViewModel {FirstName = "Yael", UserName = "Yael", AddressLine = "Direccione"   },
              new OrdersListViewModel { FirstName = "Juan", UserName = "Juan", AddressLine = "Otra direccion" }

            };

            _repositoryMock.Setup(x => x.GetAllAsync(x => x.UserName == request.UserName)).ReturnsAsync(orders);

            _mapperMock.Setup(x => x.Map<List<OrdersListViewModel>>(orders)).Returns(ordersViewModel);


            //Act
            var result = await _hanlder.Handle(request, CancellationToken.None);


            //Assert
            _repositoryMock.Verify(x => x.GetAllAsync(x => x.UserName == request.UserName), Times.Once);
            _mapperMock.Verify(x => x.Map<List<OrdersListViewModel>>(orders), Times.Once);

            Assert.Equal(2, result.Count);


        }



    }
}
