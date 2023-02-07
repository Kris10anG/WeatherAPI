using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TurtorialAPI.Models;

namespace TurtorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemController : ControllerBase
    {
        public readonly IConfiguration Configuration; //Brukes til å lese connection strings fra appsettings.json
        public ItemController(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        [HttpGet] //til swagger 
        public async Task<ActionResult<List<Item>>> GetItem()
        {
            //using sikrer at kastet kalles selv om et unntak oppstår
            using var connection = new SqlConnection(Configuration.GetConnectionString("ItemConn"));
            //QueryAsync returnerer en rekke dynaminske typer asynkront. QueryAsync<Item> returnerer en enumerable av typen Item som er spesifisert
            var items = await connection.QueryAsync<Item>("SELECT konstant, element From temperaturesensitivity_for_element");
            foreach (var item in items)
            {
                Console.WriteLine(item.konstant);

            }
            return Ok(items);
            //List<Item> items = new List<Item>();
            //var query = $"Select * From temperaturesensitivity_for_element";
            //using (var connection = new SqlConnection("Data Source=get-student.database.windows.net;Initial Catalog=test1;User ID=DAMteam;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            //{
            //    await connection.OpenAsync();
            //    items = connection.Query<Item>(query).ToList();
                
            //    return items;
            }
            //var sql = new SqlConnection(Configuration.GetConnectionString("ItemConn"));

            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * From temperaturesensitivity_for_element", sql);

        }
        //private readonly IConfiguration _configuration;

        //public ItemController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public IConfiguration Get_configuration()
        //{
        //    return _configuration;
        //}

        //    [HttpGet]
        //[Route("GetAllItems")]
        //public JsonResult GetItems(IConfiguration _configuration)
        //    {
        //        //SqlConnection con = new (_configuration.GetConnectionStringapi("ItemConn"));
        //        //SqlDataAdapter da = new SqlDataAdapter("SELECT * From temperaturesensitivity_for_element", con);
        //        //DataTable dt = new DataTable();
        //        //da.Fill(dt);
        //        //List<Item> items = new List<Item>();
        //        //if(dt.Rows.Count > 0 )
        //        //{
        //        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        //    {
        //        //        Item item = new Item();

        //        //    }

        //        //}
        //        //return null;
        //        //}

        //    }

    }

