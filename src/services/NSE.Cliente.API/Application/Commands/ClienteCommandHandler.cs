﻿using FluentValidation.Results;
using MediatR;
using NSE.Cliente.API.Models;
using NSE.Cliente.API.Models;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var cliente = new NSE.Cliente.API.Models.Cliente(request.Id, request.Nome, request.Email, request.Cpf);

            // Validações de negócio

            // Persistir no banco

            return request.ValidationResult;
        }
    }
}