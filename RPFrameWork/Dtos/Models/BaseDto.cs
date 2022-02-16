namespace Dtos.Models
{
    public class BaseDto
    {
        #region Constructors
        public BaseDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields
        public bool Enabled { get; set; } 
        #endregion
    }
}
