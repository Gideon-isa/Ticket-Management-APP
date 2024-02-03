using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Exceptions;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // mapping from request to an event entity
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            //checking the validationResult if is not null (here, if is greater than zero i.e not null)
            if (validationResult.Errors.Count > 0) 
            {
                throw new ValidationException(validationResult);
            }

            @event = await _eventRepository.AddAsync(@event);


            // Sending email notification to admin address
            var email = new Email()
            {
                To = "innocentgideon10@gmail.com",
                Subject = "A new event was created",
                Body = "A new event was created"

            };

            try
            {
                // using the SendGrid mail client
                await _emailService.SendEmail(email);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            return @event.EventId;

        }
    }
}
