using FluentValidation.Results;

namespace WM.WebAPI.Core.Communication
{
    public class ResponseMessage 
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
