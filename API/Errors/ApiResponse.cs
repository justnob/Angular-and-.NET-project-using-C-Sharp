namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string massage = null)
        {
            StatusCode = statusCode;
            Massage = massage ?? GetDefultMassageForStatusCode(statusCode);
        }

        

        public int StatusCode { get; set; }

        public string Massage { get; set; }

        private string GetDefultMassageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "Authorized, you are not",
                404 => "Resource found , it was not",
                500 => "Error are the path to the dark side. Error leads to anger leads to hete. Hate leads to career change",
                _ => null
            };
        }
         
    }
}