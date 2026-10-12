using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Omega6.Pages
{
    public class AddEditModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; } = "";

        [BindProperty]
        public string LastNm { get; set; } = "";

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Co { get; set; } = "";

        [BindProperty]
        public string StNo { get; set; } = "";

        [BindProperty]
        public string Street { get; set; } = "";

        [BindProperty]
        public string Addr1 { get; set; } = "";

        [BindProperty]
        public string Addr2 { get; set; } = "";

        [BindProperty]
        public string CityPin { get; set; } = "";

        [BindProperty]
        public string Coun { get; set; } = "";

        [BindProperty]
        public string PhOff { get; set; } = "";

        [BindProperty]
        public int PhRes { get; set; }

        [BindProperty]
        public DateOnly Birth { get; set; }

        [BindProperty]
        public DateOnly Anniv { get; set; }

        public string Message { get; set; } = "";

            public IActionResult OnPost()
            {
            // We will add the SQL INSERT or UPDATE code here.
            string connectionString =
                "Server=ASUS-KASISH\\SQLEXPRESS;" +
                "Database=Omega3i;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            string query =
                "INSERT INTO Address (Id, Name, LastNm, Age, Co, StNo, " +
                "Street, Addr1, Addr2, CityPin, Coun, PhOff, PhRes, Birth," +
                "Anniv) " +
                "VALUES (@Id, @Name, @LastNm, @Age, @Co, @StNo," +
                "@Street, @Addr1, @Addr2, @CityPin, @Coun, @PhOff, @PhRes, @Birth," +
                "@Anniv)";

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection con =
                    new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    con.Open();

                    using (Microsoft.Data.SqlClient.SqlCommand cmd =
                        new Microsoft.Data.SqlClient.SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@LastNm", LastNm);
                        cmd.Parameters.AddWithValue("@Age", Age);
                        cmd.Parameters.AddWithValue("@Co", Co);
                        cmd.Parameters.AddWithValue("@StNo", StNo);
                        cmd.Parameters.AddWithValue("@Street", Street);
                        cmd.Parameters.AddWithValue("@Addr1", Addr1);
                        cmd.Parameters.AddWithValue("@Addr2", Addr2);
                        cmd.Parameters.AddWithValue("@CityPin", CityPin);
                        cmd.Parameters.AddWithValue("@Coun", Coun);
                        cmd.Parameters.AddWithValue("@PhOff", PhOff);
                        cmd.Parameters.AddWithValue("@PhRes", PhRes);
                        cmd.Parameters.AddWithValue("@Birth", Birth);
                        cmd.Parameters.AddWithValue("@Anniv", Anniv);

                        cmd.ExecuteNonQuery();
                    }
                }

                Message = "Record saved successfully!";
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
            }
            return Page();
            }
         }
}