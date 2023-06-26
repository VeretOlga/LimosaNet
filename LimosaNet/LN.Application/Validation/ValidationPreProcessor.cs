using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace LN.Application.Validation
{
    public sealed class ValidationPreProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        /// <summary>
        /// Валилатор (опционально).
        /// </summary>
        private readonly IValidator<TRequest> _validator;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ValidationPreProcessor{TRequest}"/>.
        /// </summary>
        /// <param name="services">Сервисы приложения.</param>
        public ValidationPreProcessor(IServiceProvider services)
        {
            _validator = services.GetService<IValidator<TRequest>>();
        }

        /// <inheritdoc />
        public async Task Process(TRequest request, CancellationToken token)
        {
            if (_validator != null)
                await _validator.ValidateAndThrowAsync(request, cancellationToken: token);
        }
    }
}
