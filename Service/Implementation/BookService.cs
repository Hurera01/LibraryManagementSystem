using System.Runtime.InteropServices;
using System.Text.Json;
using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;
using LibraryManagementSystem.Utility;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

using RedisDatabase = StackExchange.Redis.IDatabase;

namespace LibraryManagementSystem.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository? _bookRepository;
        private readonly IMemoryCache _cache;
        private readonly RedisDatabase _redisCache;

        public BookService(IBookRepository bookRepository, IMemoryCache cache, IConnectionMultiplexer redis)
        {
            _bookRepository = bookRepository;
            _cache = cache;
            _redisCache = redis.GetDatabase();
        }

        public async Task Add(BookDto book)
        {
            await _bookRepository.Add(book);
        }

        public Task<int> AddMultipleBooks(List<BookDto> books)
        {
            return _bookRepository.AddMultipleBooks(books);
        }

        public Task Delete(int book_id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<GetBookWithAuthorDto>> GetBookWithAuthor(int book_id)
        {
            string cacheKey = $"BookWithAuthor_{book_id}";

            if (!_cache.TryGetValue(cacheKey, out Response<GetBookWithAuthorDto>? cachedResult))
            {
                var result = await _bookRepository.GetBookWithAuthor(book_id);

                if (result != null && result.Data != null)
                {
                    _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
                }
                

                return result;
            }

            return cachedResult;
            
        }

        public async Task<BookDto> GetById(int book_id)
        {
            var cacheKey = $"book:{book_id}";
            var cachedBook = await _redisCache.StringGetAsync(cacheKey);
            if (cachedBook.HasValue)
            {
                return JsonSerializer.Deserialize<BookDto>(cachedBook);
            }
            var book = await _bookRepository.GetById(book_id);
            if (book != null)
            {
                // Store the book in the cache for future use
                var serializedBook = JsonSerializer.Serialize(book);
                await _redisCache.StringSetAsync(cacheKey, serializedBook, TimeSpan.FromMinutes(10)); // set an expiration time

                return book;
            }
            return null;
        }

        public Task Update(int id, BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
