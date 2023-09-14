namespace Proyecto.Models.ViewModel
{
    public class BuscarTransaccion
    {
        public string dni { get; set; }

        public List<QueryTransaccion> Resultado { get; set; }
    }
}
