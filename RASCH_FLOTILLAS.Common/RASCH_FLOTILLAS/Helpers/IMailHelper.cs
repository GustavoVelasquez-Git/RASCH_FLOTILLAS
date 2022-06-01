using RASCH_FLOTILLAS.Common.Models;

namespace RASCH_FLOTILLAS.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
