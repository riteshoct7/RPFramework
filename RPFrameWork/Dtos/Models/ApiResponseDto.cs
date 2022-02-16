namespace Dtos.Models
{
    public class ApiResponseDto
    {
        #region Constructors
        public ApiResponseDto()
        {

        }
        #endregion

        #region Fields

        public bool IsSuccess { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = string.Empty;

        public List<string> ErrorMessages { get; set; }

        #endregion
    }
}
