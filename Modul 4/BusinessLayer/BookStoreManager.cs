using AutoMapper;
using BusinessLayer.ModelsDTO;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class BookStoreManager
    {
        private readonly BookStoreRepository _bookStoreRepository;
        private readonly Mapper _mapper;
        public BookStoreManager()
        {
            _bookStoreRepository = new BookStoreRepository();
            
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<AuthorDTO, Author>();

            });
            _mapper = new Mapper(conf);
        }

        public IList<BookDTO> GetAllBooks()
        {
            return _mapper.Map<IList<BookDTO>>(_bookStoreRepository.GetAllBooks());
        }



        public BookDTO GetBookById(int id)
        {
            return _mapper.Map<BookDTO>(_bookStoreRepository.GetBookById(id));
        }

        public void UpdateBook(BookDTO book)
        {
            _bookStoreRepository.UpdateBook(_mapper.Map<Book>(book));
        }

        public void RemoveById(int id)
        {
            _bookStoreRepository.RemoveBook(id);
        }

        public void AddBook(BookDTO bookDto)
        {
            _bookStoreRepository.SaveBook(_mapper.Map<Book>(bookDto));
        }

    }
}
