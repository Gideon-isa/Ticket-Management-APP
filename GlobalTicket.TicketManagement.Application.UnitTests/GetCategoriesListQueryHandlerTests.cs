using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Features.Categories.Commands;
using GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.TicketManagement.Application.Profiles;
using GlobalTicket.TicketManagement.Application.UnitTests.Mocks;
using GlobalTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.UnitTests
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            // getting the mocked data
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await  handler.Handle(new GetCategoryListQuery(), CancellationToken.None);
            
            result.ShouldBeOfType<List<CategoryListVm>>();
           
            

        }

    }
}
