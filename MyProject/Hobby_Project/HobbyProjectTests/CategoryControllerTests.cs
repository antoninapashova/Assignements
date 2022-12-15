using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests
{
    
    public class CategoryControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Get_All_Categories_GetAllCategoriesQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCategoriesListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CategoryController(_mockMediator.Object);
            await controller.GetAllCategories();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCategoriesListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Category_By_Id_GetCategoryQueryIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new CategoryController(_mockMediator.Object);

            await controller.GetById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

    }
}
