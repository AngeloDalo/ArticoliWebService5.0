using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext alphaShopDbContext;

        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext =  alphaShopDbContext;
        }

        public async Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.Descrizione.Contains(Descrizione))
                .OrderBy(a => a.Descrizione)
                .ToListAsync();
        }

        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt.Equals(Code))
                .include(a => a.barcode)
                .FirstOrDefaultAsync();
        }
        public async Task<Articoli> SelArticoloByEan(string Ean)
        {
            return await this.alphaShopDbContext.Barcode
                .Where(b => b.Barcode.Equals(Ean))
                .Select(a => a.articolo)
                .FirstOrDefaultAsync();       
        }

        public bool InsArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool Salva()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ArticoloExists(string Code)
        {
            return await this.alphaShopDbContext.Articoli
                .AnyAsync(c => c.CodArt == Code);
        }
    }
}