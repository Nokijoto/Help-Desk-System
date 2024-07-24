using CrudBase;

namespace ServiceDesk.Assets.API.Builders
{
    public class CrudOperationResultBuilder<TDto>
    {
        private CrudOperationResultStatus _status;
        private TDto? _result;
        private string _message;

        public CrudOperationResultBuilder()
        {
            _status = CrudOperationResultStatus.None;
            _result = default(TDto);
            _message = string.Empty;
        }

        public CrudOperationResultBuilder<TDto> WithStatus(CrudOperationResultStatus status)
        {
            _status = status;
            return this;
        }

        public CrudOperationResultBuilder<TDto> WithResult(TDto? result)
        {
            _result = result;
            return this;
        }

        public CrudOperationResultBuilder<TDto> WithMessage(string message)
        {
            _message = message;
            return this;
        }

        public CrudOperationResult<TDto> Build()
        {
            return new CrudOperationResult<TDto>
            {
                Status = _status,
                Result = _result,
                Message = _message
            };
        }
    }
}
