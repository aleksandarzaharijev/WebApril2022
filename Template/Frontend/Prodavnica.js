import{Tip} from "./Tip.js"
import{Brend}from"./Brend.js"
import{Komponenta} from"./Komponenta.js"

export class Prodavnica {
     constructor(id)
     {  
        this.id=id;
        this.naziv=null;
        this.komponenta=null;

        this.kontejner=null;
     }

     removeAllChildNodes(parent) {
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }
    }

     crtaj(host){

        this.kontejner = document.createElement("div");
        this.kontejner.className="Kontejner";
        host.appendChild(this.kontejner);
       
   

        let divFilter = document.createElement("div");
        divFilter.className="divFilter";
        this.kontejner.appendChild(divFilter);
        
       
        let filterKontejner = document.createElement("div");
        filterKontejner.className="filterDiv";
        divFilter.appendChild(filterKontejner);

        let lokalKontejner = document.createElement("div");
        lokalKontejner.className="lokalni";
        filterKontejner.appendChild(lokalKontejner);

        let divNaslov = document.createElement("div");
        divNaslov.className="divNaziv";
        this.kontejner.appendChild(divNaslov);
       
        let divDugme = document.createElement("div");
       divDugme.className = "divDugme";
       filterKontejner.appendChild(divDugme);
       this.crtajFilter(lokalKontejner);

       let komponenteKontejner= document.createElement("div");
       komponenteKontejner.className="komponenteDiv";
       divFilter.appendChild(komponenteKontejner);
       
      
       
       let komponenteK = document.createElement("div");
       komponenteK.className="kontejnerKomponente";
       komponenteKontejner.appendChild(komponenteK);
      
       let tablicaKontejner = document.createElement("div");
       tablicaKontejner.className="tablicaKontejner";
       komponenteKontejner.appendChild(tablicaKontejner);



       let dugmePronadji = document.createElement("button");
       dugmePronadji.className="dugmePronadji";
       dugmePronadji.innerHTML="Pronadji";
       divDugme.appendChild(dugmePronadji);
       dugmePronadji.onclick=(ev)=>this.nadji();

        this.kontejner.appendChild(divFilter);
        this.preuzmiNaslov(divNaslov);
      
       
     }
     
    crtajFilter(host)
    {   

        let divLab = document.createElement("div");
        divLab.className="divLab";
        host.appendChild(divLab);
        
        let divInput = document.createElement("div");
        divInput.className="divInput";
        host.appendChild(divInput);

        let l;
        let labele = ["Tip","Brend","Cena od","Cena do:"];
        labele.forEach(p=>
            {
                l = document.createElement("label");
                l.className="labeleFilter";
                l.innerHTML=p;
                divLab.appendChild(l);
            })
        

            let listaT = document.createElement("select");
            listaT.className = "listaTipova";
            divInput.appendChild(listaT);

            let listaB = document.createElement("select");
            listaB.className="listaBrendova";
            divInput.appendChild(listaB);
           
            let ii
            let inputCene =["CenaOdInput","CenaDoInput"];
            inputCene.forEach(p=>
                {
                    ii = document.createElement("input");
                    ii.className=p;
                    ii.type="number";
                   divInput.appendChild(ii);
                })
                let opcije;
                let pomTip=[];
            let tipovi=[];
            fetch( "https://localhost:5001/Brend/PreuzmiTipoveProdavnice/"+this.id)
                .then(p=>
                    {
                        p.json().then(
                            tip=>{
                                tip.forEach((t1)=>{   
                                   
                                    let t = new Tip(t1.id,t1.naziv);
                                    tipovi.push(t);
                                })
                              
                                const unique1 = tipovi.filter(element=>{
                                const isDuplicate = pomTip.includes(element.id);
                                if(!isDuplicate)
                                    {pomTip.push(element.id);
                                    return true;
                                }
                                    return false;
                               })
                         

                                unique1.forEach(p=>{
                                opcije = document.createElement("option");
                                opcije.value=p.id;
                                opcije.innerHTML=p.naziv;
                                listaT.appendChild(opcije);
                                
                               })
                            }
                        )
                    })
                
                 

           let  opcijaBez = document.createElement("option");
           opcijaBez.value=100;
           opcijaBez.innerHTML="-";
           listaB.appendChild(opcijaBez);
         
        this.promeniBrend(listaB);
              
    }
     
    promeniBrend(host)
    {   
        
        let brendovi=[];
        let rt = this.id;
        let opcije =[];
  
        document.querySelector("select").onchange = function(){
         
        let tipid = document.querySelector("select").value; //vrednost id-a
    

        let pr = document.querySelector(".listaBrendova");//vrednosti brendova
        pr.replaceChildren(pr.children[0]);

        fetch("https://localhost:5001/Brend/PreuzmiBrendoveProdavnice/"+rt+"/"+tipid)
        .then(p=>{
           p.json().then(br2=>{   
              br2.forEach((t1)=>{
                                    
                                    
                                    let t = new Brend(t1.id,t1.naziv);
                                    brendovi=[];
                                    brendovi.push(t);
                                    brendovi.forEach(p=>{
                                    opcije = document.createElement("option");
                                    opcije.value=p.id;
                                    opcije.innerHTML=p.naziv;
                                    host.appendChild(opcije);}) 
                                        
                 });     
                 
            });
        });
    
        
    }     

    }
    preuzmiNaslov(host){
        let naziv;
    
        fetch("https://localhost:5001/Ispit/PreuzmiProdavnicu/"+this.id,{
            method: "GET"
        }).then(p=>{
            if(p.ok){
            p.json().then(naslov=>{
               naziv = naslov[0].naziv;     
               var naslov = document.createElement("h2");
               naslov.className = "Naslov";
               naslov.innerHTML = naziv;
               host.appendChild(naslov);
            });
            
            }  
         else console.log("greska u p");       
        });
     
        return naziv;
    }
   

   nadji()
   { 
    
    let opcija = this.kontejner.querySelectorAll("select");
    let divKomp = document.querySelector(".kontejnerKomponente");
    let divKompCeli = document.querySelectorAll(".glavniDivKomponenta");    
    
    divKompCeli.forEach(p=>{
        p.replaceChild();
    })
    
    console.log(divKomp);
    let tipId = opcija[0].options[opcija[0].selectedIndex].value;
    let brendId = opcija[1].options[opcija[1].selectedIndex].value;
    let brendTekst = opcija[1].options[opcija[1].selectedIndex].text;
    console.log(brendTekst);

    let cena = this.kontejner.querySelectorAll("input");
    let cenaOd = cena[0].value;

    let cenaDo = cena[1].value;
    //"https://localhost:5001/Ispit/Preuzmikomponente/1/2?brendID=3&cenaOd=2&cenaDo=4"
    let lk;
    let listaKomponenti=[];
    if (tipId && brendTekst==='-' && cenaOd==='' && cenaDo ==='')
    {
        fetch("https://localhost:5001/Ispit/Preuzmikomponente/"+this.id+"/"+tipId,
        
        {method:"GET"})
    .then(p=>{
        if(p.ok)
        {
            p.json().then((komp)=>
                {   
                    
                    console.log(komp[0].id);
                    lk=komp;
                    listaKomponenti.push(lk);
                    listaKomponenti[0].forEach(p=>
                        {
                        let k = new Komponenta(p.id,p.sifra,p.naziv,p.cena,p.kolicina);
                         k.crtajKomponentu(divKomp,k.sifra,k.naziv,k.cena);
                        });
                    console.log(listaKomponenti[0]);
                    console.log("bez brenda i cena");
                })
        }
    })
    }

    else if(tipId && brendTekst!=='-' && cenaOd==='' && cenaDo ==='')
    {   
       
        fetch("https://localhost:5001/Ispit/Preuzmikomponente/"+this.id+"/"+tipId+"?"+"brendID="+brendId,{method:"GET"})
    .then(p=>{
        if(p.ok)
        {  //https://localhost:5001/Ispit/Preuzmikomponente/1/7?brendID=1
            p.json().then(komp=>
                {  

                    lk=komp;
                    listaKomponenti.push(lk);
                    listaKomponenti[0].forEach(p=>
                        {
                        let k = new Komponenta(p.id,p.sifra,p.naziv,p.cena,p.kolicina);
                         k.crtajKomponentu(divKomp,k.sifra,k.naziv,k.cena);
                        });
                    console.log(lk);
                    console.log("sa brendom bez cena");
                })
        }
    })
    }
    else if(tipId && brendTekst==='-' && cenaOd!==''&&cenaDo!='')
 { fetch("https://localhost:5001/Ispit/Preuzmikomponente/"+this.id+"/"+tipId+"?"+"cenaOd="+cenaOd+"&"+"cenaDo="+cenaDo,{method:"GET"})
    .then(p=>{
        if(p.ok)
        {
            p.json().then(komp=>
                {   

                    lk=komp;
                    listaKomponenti.push(lk);
                    listaKomponenti[0].forEach(p=>
                        {
                        let k = new Komponenta(p.id,p.sifra,p.naziv,p.cena,p.kolicina);
                         k.crtajKomponentu(divKomp,k.sifra,k.naziv,k.cena);
                        });
                    console.log(lk);
                    console.log("bez brenda sa cenom");
                })
        }
    }) /*https://localhost:5001/Ispit/Preuzmikomponente/1/7?brendID=1&cenaOd=9000&cenaDo=111111*/ 
    //   https://localhost:5001/Ispit/Preuzmikomponente/1/7?brendID=1&cenaOd=9000&cenaDo=111111
   }
   else {

     fetch("https://localhost:5001/Ispit/Preuzmikomponente/"+this.id+"/"+tipId+"?"+"brendID="+brendId+"&"+"cenaOd="+cenaOd+"&"+"cenaDo="+cenaDo,{method:"GET"})
     .then(p=>{
        if(p.ok)
        {
            p.json().then(komp=>
                {   
                    console.log(komp);
                    //let kk = new Komponenta(komp.sifra,komp.naziv,komp.cena)
                    lk=komp;
                    listaKomponenti.push(lk);
                    listaKomponenti[0].forEach(p=>
                        {
                        let k = new Komponenta(p.id,p.sifra,p.naziv,p.cena,p.kolicina);
                         k.crtajKomponentu(divKomp,k.sifra,k.naziv,k.cena);
                        });
                    console.log(lk);
                    console.log("ceo filter");
                })
        }
    });
    
    }


   }
  

}