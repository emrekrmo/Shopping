using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repos
{
    public class BaseRepository<TEntity,TKey> where TEntity : class
    {
        AlisverisContext _db;

        public BaseRepository(AlisverisContext db)
        {
            _db = db;
        }

        public List<TEntity> Listele()
        {
            return _db.Set<TEntity>().ToList();
        }   

        public TEntity IdIleGetir(TKey id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Sil(TKey id)
        {
            var silinecek = IdIleGetir(id);
            _db.Set<TEntity>().Remove(silinecek);
        }

        public void Ekle(TEntity yeni)
        {
            _db.Set<TEntity>().Add(yeni);
        }

        public void Guncelle(TEntity guncel)
        {
            Type t = typeof(TEntity);
            string classAdi = t.Name;
            var idProp = t.GetProperty(classAdi + "Id");
            TKey id = (TKey)idProp.GetValue(guncel);

            var eski = IdIleGetir(id);
            _db.Entry(eski).CurrentValues.SetValues(guncel);
        }
    }
}
