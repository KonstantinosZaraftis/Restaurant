namespace Mango.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        //We use Dto to transef Data and not directly from the model
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages  { get; set; }
    }
}
