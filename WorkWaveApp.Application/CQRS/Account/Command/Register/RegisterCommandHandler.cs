﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Domain.Enums;
namespace WorkWaveApp.Application.CQRS.Account.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResult<RegisterResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<RegisterCommand> _validator;

        public RegisterCommandHandler(IAccountService accountService, IValidator<RegisterCommand> validator)
        {
            _accountService = accountService;
            _validator = validator;
        }

        public async Task<ServiceResult<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            bool validation = validationResult.IsValid;

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                      .GroupBy(x => x.PropertyName)
                      .ToDictionary(
                      g => g.Key,
                      g => g.Select(x => x.ErrorMessage).ToArray());
                foreach(var item in errors)
                {
                    Console.WriteLine(item);
                }

                return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.FluentValidatonError);
            }

            return await _accountService.Register(request.RegisterRequest);
        }
    }
}
