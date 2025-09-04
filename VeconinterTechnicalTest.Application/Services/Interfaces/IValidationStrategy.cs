using VeconinterTechnicalTest.Application.Enums;

namespace VeconinterTechnicalTest.Application.Services.Interfaces;

public interface IValidationStrategy<T>
{
    bool IsValid(T entity);
    string GetValidationMessage();
    ValidationStrategyEnum GetValidationStrategy();
}