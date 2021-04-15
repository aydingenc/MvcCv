using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;
namespace MvcCv.Models.Repositories
    //Genericrepository classı oluşturmam da amaç bütün CRUD işlemlerini tek çatı altında toplayıp yönetilmesini kolaylaştırmak ve her yerde ekle sil vb. kodları yazıp kalabalıgı azaltmaktır.
{
    public class GenericRepository<T> where T:class, new() /*GenericRepository adında bir class oluşturdum ve generic yapıda olmasını saglamak için <> koydum içine verdigim T degişkenlik gösterebilir ne gönderirsem o gelsin manasında ve t class olmalı ve newlenebilir olmalı*/
    {
        dbCVEntities1 db = new dbCVEntities1();  /*Veritabanımdan db adında bir örnek türettim bu db. sayesinde veritabanı nesnelerine erişim saglayabilecegim.*/

        public List<T> List() /*List Adında bir metot yazdım geri dönüş tipi de list olsun dedim List<T> gönderdigim tipin degerini liste olarak tut ------------->Listeleme işlemi*/
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p) /*Ekleme işlemi bu ekleme işlemini gönderdigim tipe göre yap*/ 
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p) /*Silme İşlemi*/
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id) /*Id degerine göre bulma*/
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p) /*Güncelleme işlemi*/
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where) // İstedigim degeri getir.
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}