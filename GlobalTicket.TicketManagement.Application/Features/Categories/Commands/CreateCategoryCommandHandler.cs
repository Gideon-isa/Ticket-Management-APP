using AutoMapper;
using FluentValidation.Results;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _Mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _Mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            // instantiating a fluentValidation instance
            var validator = new CreateCategoryCommandValidator();

            ValidationResult validationResult =  await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                if (createCategoryCommandResponse.Success)
                {
                    var category = new Category() { Name = request.Name };
                    category = await _categoryRepository.AddAsync(category);
                    createCategoryCommandResponse.Category = _Mapper.Map<CreateCategoryDto>(category);
                }
            }
            return createCategoryCommandResponse;
        }
    }
}
