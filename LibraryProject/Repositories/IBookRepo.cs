using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Repositories
{
    public interface IBookRepo
    {
        public List<Book> GetAll();
        public void Add(Book obj);
        public void Update(Book obj);
        public void Delete(int id);
        public Book GetById(int id);

        public List<Book> Search(string name);
        public List<Book> SearchTitle(string name);


        public void Save();




    }
}
