using Application.Categories.Commands.Create;
using Application.Categories.Commands.Edit;
using Azure.Core;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests
{
    
    public class CategoryControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
     

        public CategoryControllerTests()
        {
          
        }

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
                .Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), 
                                   It.IsAny<CancellationToken>()))
                                   .Verifiable();

            var controller = new CategoryController(_mockMediator.Object);

            await controller.GetById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCategoryByIdQuery>(), 
                                             It.IsAny<CancellationToken>()), Times.Once());
        }
      
    }
}
