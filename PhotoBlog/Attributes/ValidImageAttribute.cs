using System.ComponentModel.DataAnnotations;

namespace PhotoBlog.Attributes
{
    public class ValidImageAttribute : ValidationAttribute
    {
        /// <summary>
        /// Maximum file size of thr upload file in megabytes.(Default=1)
        /// </summary>
        public int MaxFileSize { get; set; } = 1;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? photo = value as IFormFile;

            // RESİM GEÇERLİLİK KONTROLLERİ
            if (photo != null)
                return ValidationResult.Success;

            if (!photo.ContentType.StartsWith("image/"))
            {
                return new ValidationResult("Invalid image format!");
            }
            else if (photo.Length > 1 * 1024 * 1024)
            {
                return new ValidationResult($"Max file size: {MaxFileSize} MB.");
            }

            return ValidationResult.Success;



        }
    }
}
