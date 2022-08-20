using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Template.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class BrendController : ControllerBase
    {
         public IspitDbContext Context {get;set;}

         public BrendController(IspitDbContext c)=> Context=c;
    
       
       [Route("PreuzmiTipoveProdavnice/{prodavnicaID}")]
       [HttpGet]
       public async Task<ActionResult> preuzmitipove(int prodavnicaID)
       {
        var tipovi = await Context.Spojevi
                            .Include(p=>p.Komponenta)
                            .ThenInclude(q=>q.Tip)
                            .Where(p=>p.Prodavnica.ProdavnicaID==prodavnicaID)
                            .Select(p=>new{
                                Id = p.Komponenta.Tip.TipID,
                                Naziv = p.Komponenta.Tip.Naziv
                            })
                            .ToListAsync();
        return Ok(tipovi);
       }
        [Route("PreuzmiBrendoveProdavnice/{prodavnicaID}/{tipID}")]
        [HttpGet]
        public async Task<ActionResult> preuzmiBrendove (int prodavnicaID, int tipID)
        {
            var brendovi = await Context.Spojevi
                                        .Include(p=>p.Komponenta)
                                        .ThenInclude(p=>p.Brend)
                                        .Where(p=>p.Prodavnica.ProdavnicaID==prodavnicaID && p.Komponenta.Tip.TipID==tipID)
                                        .Select(p=>new{
                                            Id=p.Komponenta.Brend.BrendID,
                                            Naziv = p.Komponenta.Brend.Naziv
                                        })
                                      .ToListAsync();
            
            
            return Ok(brendovi);
        }

    }
}