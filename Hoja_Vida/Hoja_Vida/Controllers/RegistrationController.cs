using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hoja_Vida.Models;
using System.Data.SqlClient;
using System.Data;

namespace Hoja_Vida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration= configuration;

        }

        
        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("HojaVida").ToString());
            SqlCommand cmd = new ("INSERT INTO Registration(UserName, Password, Email, IsActive) VALUES('" + registration.UserName + "', '" + registration.Password + "', '" + registration.Email + "', '" + registration.IsActive + "')", con);
            con.Open();
            int i= cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0) 
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
        }

        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {
            SqlConnection co = new SqlConnection(_configuration.GetConnectionString("HojaVida").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE UserName= '" + registration.UserName + "' AND Password = '" + registration.Password + "' AND IsActive= 1 ", co);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return "Valid User";
            }
            else
            {
                return "Invalid User";
            }
        }
    }
}
