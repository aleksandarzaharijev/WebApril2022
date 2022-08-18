export class Komponenta{
 
    constructor(id,sifra,naziv,cena,kolicina)
    {   
        
        this.id = id;
        this.sifra=sifra;
        this.naziv=naziv;
        this.cena=cena;
        this.kolicina-kolicina;
        this.kont=null;
    }


    crtajKomponentu(host,sifra,naziv,cena)
    {   
        

        let glavniDivKomponenta =document.createElement("div");
        glavniDivKomponenta.className="glavniDivKomponenta";
        host.appendChild(glavniDivKomponenta);

        let divKomponenta= document.createElement("div");
        divKomponenta.className="divKomponenta";
        glavniDivKomponenta.appendChild(divKomponenta);
        
        let divLabele = document.createElement("div");
        divLabele.className = "divLabeleKomponenta";
        divKomponenta.appendChild(divLabele);

        let divLabeleVrednosti = document.createElement("div");
        divLabeleVrednosti.className="labeleVrednostiKomponente";
        divKomponenta.appendChild(divLabeleVrednosti);
        
        let dugmeKonfigurisi = document.createElement("div");
        dugmeKonfigurisi.className="dugmeKonfigurisi";
        glavniDivKomponenta.appendChild(dugmeKonfigurisi);

        let dugme = document.createElement("button");
        dugme.className="dugme";
        dugme.innerHTML="Konfigurisi";
        dugmeKonfigurisi.appendChild(dugme);

        let l;
        let labele = ["Sifra","Naziv","Cena"];
        labele.forEach(p=>{
            l = document.createElement("label");
            l.className=p;
            l.innerHTML=p;
            divLabele.appendChild(l);
        })

        
        
        let labelaSifra = document.createElement("label");
        labelaSifra.className="labelaSifra";
        labelaSifra.innerHTML=sifra;
        divLabeleVrednosti.appendChild(labelaSifra);

        let labelaNaziv = document.createElement("label");
        labelaNaziv.className="labelaSifra";
        labelaNaziv.innerHTML=naziv;
        divLabeleVrednosti.appendChild(labelaNaziv);

        let labelaCena = document.createElement("label");
        labelaCena.className="labelaSifra";
        labelaCena.innerHTML=cena;
        divLabeleVrednosti.appendChild(labelaCena);


    }

}