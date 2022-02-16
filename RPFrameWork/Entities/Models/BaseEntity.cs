namespace Entities.Models
{
    public class BaseEntity
    {
        #region Constructors
        public BaseEntity()
        {
            Enabled = true;            
        }
        #endregion

        #region Fields
        public bool Enabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } 
        #endregion
    }
}
