using System.Collections.Generic;
using System.Threading.Tasks;
using ArticoliWebService.Models;

namespace ArticoliWebService.Services
{
    public interface IArticoliRepository
    {
        ICollection<Articoli> SelArticoliByDescrizione(string Descrizione);
        Articoli SelArticoloByCodice(string Code);
        Articoli SelArticoloByEan(string Ean);
        bool InsArticoli(Articoli articolo);
        bool UpdArticoli(Articoli articolo);
        bool DelArticoli(Articoli articolo);
        bool Salva();
        Task<bool> ArticoloExists(string Code);
    }
}