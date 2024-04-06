using HojaDeVida.Models;

namespace HojaDeVida.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel() {UserName = "rvaleria", Password= "valeria22", Rol="Administrador", EmailAddress= "rvaleria@gmail.com", FirstName="Valeria", LastName="Rivera"},
            new UserModel() {UserName = "fdiaz", Password= "diaz11", Rol="Solicitante", EmailAddress= "fdiaz@gmail.com", FirstName="Fabian", LastName="Diaz"},
        };
    }
}
