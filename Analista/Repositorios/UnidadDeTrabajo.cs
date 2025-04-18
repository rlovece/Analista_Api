using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;


namespace Analista.Repositorios
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IRepositorio<SubTipoRequisito> _subTipoRequisitoRepositorio { get; }
        public IRepositorio<TipoRequisito> _TipoRequisitoRepositorio { get; }
        public IRepositorio<Actor> _ActorRepositorio { get; }
        public IRepositorio<CasoDeUso> _CasoDeUsoRepositorio { get; }
        public IRepositorio<CondicionPorCasoDeUso> _CondicionPorCasoDeUsoRepositorio { get; }

        public IRepositorio<Condicion> _CondicionRepositorio { get; }
        public IRepositorio<CriterioDeAceptacion> _CriterioDeAceptacionRepositorio { get; }
        public IRepositorio<Requisito> _RequisitoRepositorio { get; }
        public IRepositorio<Servicio> _ServicioRepositorio { get; }

        private MiDbContext _context;

        private IDbContextTransaction _transaction;

        public UnidadDeTrabajo(
            IRepositorio<SubTipoRequisito> subTipoRequisitoRepositorio,
            IRepositorio<TipoRequisito> tipoRequisitoRepositorio,
            IRepositorio<Actor> actorRepositorio,
            IRepositorio<CasoDeUso> casoDeUsoRepositorio,
            IRepositorio<CondicionPorCasoDeUso> condicionPorCasoDeUsoRepositorio,
            IRepositorio<Condicion> condicionRepositorio,
            IRepositorio<CriterioDeAceptacion> criterioDeAceptacionRepositorio,
            IRepositorio<Requisito> requisitoRepositorio,
            IRepositorio<Servicio> servicioRepositorio,
            MiDbContext context)
        {
            _subTipoRequisitoRepositorio = subTipoRequisitoRepositorio;
            _TipoRequisitoRepositorio = tipoRequisitoRepositorio;
            _ActorRepositorio = actorRepositorio;
            _CasoDeUsoRepositorio = casoDeUsoRepositorio;
            _CondicionPorCasoDeUsoRepositorio = condicionPorCasoDeUsoRepositorio;
            _CondicionRepositorio = condicionRepositorio;
            _CriterioDeAceptacionRepositorio = criterioDeAceptacionRepositorio;
            _RequisitoRepositorio = requisitoRepositorio;
            _ServicioRepositorio = servicioRepositorio;
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction?.CommitAsync();
                _transaction?.Dispose();
            }
            
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.DisposeAsync();
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction?.RollbackAsync();
                _transaction?.Dispose();
            }
        }

    }
}
