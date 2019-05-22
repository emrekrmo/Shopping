using BLL.Managers;
using BLL.Repos;
using BLL.Services;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork : IDisposable
    {
        AlisverisContext _db = new AlisverisContext();
        IEmailService _emailService = new GmailService();

        public BaseRepository<Urun, int> UrunRep;
        public MusteriManager MusteriManager;
        public SepetManager SepetManager;

        public UnitOfWork()
        {
            UrunRep = new BaseRepository<Urun, int>(_db);
            MusteriManager = new MusteriManager(_db, _emailService);
            SepetManager = new SepetManager(_db);
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            _emailService = null;
            UrunRep = null;
            SepetManager = null;
            MusteriManager = null;
        }
    }
}
