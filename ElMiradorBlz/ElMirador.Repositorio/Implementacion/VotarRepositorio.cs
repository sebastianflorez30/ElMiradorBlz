using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElMirador.Modelo;
using ElMirador.Repositorio.Contrato;
using ElMirador.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ElMirador.Repositorio.Implementacion
{
    public class VotarRepositorio : GenericoRepositorio<Voto>, IVotarRepositorio
    {
        private readonly ElMiradorDbContext _dbContext;
        public VotarRepositorio(ElMiradorDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        private Voto _votacion;
        private string _opcionVoto;

        protected override void OnInitialized()
        {
            _votacion = await _services.VotacionesService.GetByIdAsync(Model.Id);
        }

        private async Task OnSubmitAsync()
        {
            // Validar el voto
            if (_opcionVoto == null)
            {
                // Mostrar un mensaje de error
                return;
            }

            // Emitir el voto
            await _services.VotacionesService.VotarAsync(_votacion.Id, _opcionVoto);

            // Redireccionar al usuario a la página de información de la asamblea
            return RedirectToPage("/Informacion/@_votacion.AsambleaId");
        }


    }

    internal interface IVotarRepositorio
    {
    }
}
