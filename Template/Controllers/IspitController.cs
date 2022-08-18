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
    public class IspitController :ControllerBase
    { 
        public IspitDbContext Context {get;set;}

        public IspitController(IspitDbContext c) => Context=c;
        
      [Route("Preuzmikomponente/{prodavnicaID}/{tipID}")]
      [HttpGet]
      public async Task<ActionResult> preuzmiKomponente (int prodavnicaID,int tipID, int brendID, int cenaOd, int cenaDo)
      {

        if(tipID<0)
            return BadRequest("Morate uneti barem tip po kome cete pretrazivati komponente");
        if(cenaOd > cenaDo)
            return BadRequest("Unesite pravilan opseg cena koje pretrazujete");
        
        try
        {
                var prodavnica = Context.Spojevi
                                .Include(p=>p.Komponenta)
                                .Where(p=>p.Prodavnica.ProdavnicaID==prodavnicaID&&p.Komponenta.Tip.TipID==tipID);

        if(brendID>0 && cenaOd<=0 && cenaDo<=0)
           {
            prodavnica = prodavnica
                                   .Where(p=>p.Komponenta.Brend.BrendID == brendID);
           }
        
        if (brendID<=0 && cenaOd>0 && cenaDo>0 )
        {
            prodavnica = prodavnica
                                  .Where(p=>p.Cena>=cenaOd && p.Cena<=cenaDo);

        }
        if(brendID>0 && cenaOd>0 && cenaDo>0)
         {
            prodavnica =  prodavnica
                                   .Where(p=>p.Komponenta.Brend.BrendID==brendID&& p.Cena>=cenaOd && p.Cena<=cenaDo);
                                   
         }

        return Ok(await prodavnica.Select(p=>
                                new{
                                    Id = p.SpojID,
                                    Sifra = p.Sifra,
                                    Naziv = p.Komponenta.Naziv,
                                    Cena = p.Cena
                                }).ToListAsync());
        }
        catch(Exception e )
        {
            return BadRequest("Ne postoji proizvod sa zadatim tipom u prodavnici \n"+e.Message);
        }
    }
    
      [Route("Kupi konfiguraciju/{prodavnicaID}/{komponentaID}/{kolicina}")]
        [HttpPut]

        public async Task<ActionResult> kupiKonfiguraciju(int prodavnicaID,int komponentaID, int kolicina)
        {   
            try{
            var komponenta = Context.Spojevi
                                      .Include(p=>p.Komponenta)
                                      .Where(p=>p.Prodavnica.ProdavnicaID==prodavnicaID && p.Komponenta.KomponentaID==komponentaID)
                                      .FirstOrDefault();
              if(komponenta!=null)
            {

            if(kolicina > komponenta.Kolicina)

            {
               return BadRequest("Nemamo toliko komponenti na zalihama");
            }
              komponenta.Kolicina = komponenta.Kolicina-kolicina;
               await Context.SaveChangesAsync();
              return Ok("Kupljena konfiguracija, kolicina oduzeta");

            }
            else{
                return Ok("Ne postoji ovakva komponenta u bazi");
            }
            }
            catch(Exception e )
            {
              return BadRequest(e.Message);
            }
           
         }
         [Route("PreuzmiProdavnicu/{id}")]
         [HttpGet]
         public async Task<ActionResult> preuzmiIme(int id)
         {
            var prodavnica = Context.Prodavnice.Where(p=>p.ProdavnicaID==id);

            return Ok(await prodavnica.Select(p=> 
            new{
                Id = p.ProdavnicaID,
                Naziv = p.Naziv
            }).ToListAsync()
            );
         }
    }     
}




























/*

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
    public class ProdavnicaController:ControllerBase
    {
        public IspitDbContext Context {get;set;}

        public ProdavnicaController(IspitDbContext con)
        {
            Context=con;
        }

      [Route("Preuzmi komponente/{prodavnicaID}/{tipID}")]
      [HttpGet]
      public async Task<ActionResult> preuzmiKomponente (int prodavnicaID,int tipID, int brendID, int cenaOd, int cenaDo)
      {

        if(tipID<0)
            return BadRequest("Morate uneti barem tip po kome cete pretrazivati komponente");
        if(cenaOd > cenaDo)
            return BadRequest("Unesite pravilan opseg cena koje pretrazujete");
        
        try
        {
                var prodavnica = Context.Spojevi
                                .Include(p=>p.Komponenta)
                                .Where(p=>p.Prodavnica.ProdavnicaID==prodavnicaID&&p.Komponenta.Tip.TipID==tipID);

        if(brendID>0 && cenaOd<=0 && cenaDo<=0)
           {
            prodavnica = prodavnica
                                   .Where(p=>p.Komponenta.Brend.BrendID == brendID);
           }
        
        if (brendID<=0 && cenaOd>0 && cenaDo>0 )
        {
            prodavnica = prodavnica
                                  .Where(p=>p.Cena>=cenaOd && p.Cena<=cenaDo);

        }
        if(brendID>0 && cenaOd>0 && cenaDo>0)
         {
            prodavnica =  prodavnica
                                   .Where(p=>p.Komponenta.Brend.BrendID==brendID&& p.Cena>=cenaOd && p.Cena<=cenaDo);
                                   
         }

        return Ok(await prodavnica.Select(p=>
                                new{
                                    Sifra = p.Sifra,
                                    Naziv = p.Komponenta.Naziv,
                                    Cena = p.Cena
                                }).ToListAsync());
        }
        catch(Exception e )
        {
            return BadRequest("Ne postoji proizvod sa zadatim tipom u prodavnici \n"+e.Message);
        }
       
       

      }

        
        [Route("Kupi konfiguraciju/{prodavnicaID}/{komponentaID}/{kolicina}")]
        [HttpPut]

        public async Task<ActionResult> kupiKonfiguraciju(int prodavnicaID,int komponentaID, int kolicina)
        {   
            
            var komponenta =              Context.Prodavnice
                                          .Include(p=>p.Komponenta)
                                          .Where(p=>p.ProdavnicaID==prodavnicaID && p.KomponentaID==komponentaID);

            
            
            
            
            
            
                                      /*Context.Spojevi
                                    .Include(p=>p.Komponenta)
                                    .ThenInclude(p=>p.KomponentaProdavnica)
                                    .Where(p=>p.Komponenta.KomponentaID==komponentaID&&p.KomponentaProdavnica.ProdavnicaID==prodavnicaID)
                                    .ToListAsync();*/
        
         /*    if(kolicina>komponenta.KomponentaProdavnica.Kolicina)
                {
                    return BadRequest("Nema toliko komponenti u prodavnici");
                }
             

        return Ok();
        
        }*/
         

      
/*
    }*/

