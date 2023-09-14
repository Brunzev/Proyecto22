using Microsoft.EntityFrameworkCore;
using Proyecto.Models.Entities;
using Proyecto.Models.ViewModel;

namespace Proyecto.Data.DataAccess
{
    public class TransaccionDA
    {

        public IEnumerable<QueryTransaccion> GetTransacciones()
        {
            var listado = new List<QueryTransaccion>();
            using (var db = new ApplicationDbContext())
            {
                var query = from cli in db.Cliente
                            join fin in db.ClienteFinanza
                                on cli.Id_Cliente equals fin.Fk_Cliente
                            join tra in db.Transaccion
                                on fin.Id_Cliente_Finanza equals tra.Fk_Cliente_Finanza
                            select new QueryTransaccion()
                            {
                                Nombre = cli.Nombre,
                                MontoTransaccion = tra.MontoTransaccion,
                                FechaMonto = tra.FechaMonto
                            };
                listado = query.ToList();
            }
            return listado;
        }

        public IEnumerable<QueryTransaccion> GetCliente(string dni)
        {
            var listado = new List<QueryTransaccion>();
            using (var db = new ApplicationDbContext())
            {
                var query = from cli in db.Cliente
                            join fin in db.ClienteFinanza
                                on cli.Id_Cliente equals fin.Fk_Cliente
                            join tra in db.Transaccion
                                on fin.Id_Cliente_Finanza equals tra.Fk_Cliente_Finanza
                            where cli.DNI == dni
                            select new QueryTransaccion()
                            {
                                Nombre = cli.Nombre,
                                MontoTransaccion = tra.MontoTransaccion,
                                FechaMonto = tra.FechaMonto,
                                DNI = cli.DNI
                            };
                listado = query.ToList();
            }
            return listado;
        }

    }
}
