using EfCodeFirstLessonOne;
using Microsoft.EntityFrameworkCore;

using var dbContext = new BookContext();

// insertinimo pavyzdys 
//var newPage = new Page(1, "kazkoks turinys");
//dbContext.Pages.Add(newPage);
//dbContext.SaveChanges();  // cia pridedam page i database

//////////////////////////////////////////////////////////////////////////////////////////////////////

// selectinimo pavyzdys 
//var pageFromDb = dbContext.Pages.FirstOrDefault(p => p.Id == Guid.Parse("B508E588-AE56-4AD2-BE00-9AA366EDF8DD"));
//Console.WriteLine($"puslapio nr {pageFromDb.Number} ir turinys {pageFromDb.Content}");

//////////////////////////////////////////////////////////////////////////////////////////////////////
///
// UPDATE:
//var pageFromDb = dbContext.Pages.FirstOrDefault(p => p.Id == Guid.Parse("B508E588-AE56-4AD2-BE00-9AA366EDF8DD"));
//pageFromDb.Content = "pakeistas puslapio turinys";
//dbContext.SaveChanges();

//DELETE:
//var pageFromDb = dbContext.Pages.FirstOrDefault(p => p.Id == Guid.Parse("B508E588-AE56-4AD2-BE00-9AA366EDF8DD"));
//dbContext.Pages.Remove(pageFromDb);
//dbContext.SaveChanges();

// DELETE BE SELECTO
//var pageToDelete = new Page { Id = Guid.Parse("0C48C06C-2811-45BC-97F7-6199AE77F0CD") };
//dbContext.Pages.Remove(pageToDelete);
//dbContext.SaveChanges();

// Programa pridedanti puslapius i book ir i database updatina book ir pages ( nes mes pridedam pages i book ir book updatinam i database)
//var book = new Book("HARRY POTTER");
//for (int i = 0; i < 565; i++)
//{
//    book.Pages.Add(new Page(i, $"Content - {i}"));
//}
//dbContext.Books.Add(book);
//dbContext.SaveChanges();

// Pridedam knyga be puslapiu
//var book = new Book("altoriu sesely");
//dbContext.Books.Add(book);
//dbContext.SaveChanges();


// pridedam viena puslapi i viena knyga
//var page = new Page(999, "slaptas turinys");
//page.BookId = Guid.Parse("84BF9094-1D08-404E-A079-72AF0BC3AD5B");
//dbContext.Pages.Add(page);
//dbContext.SaveChanges();

// pridedam viena puslapi ne i knyga, o i puslapi tiesiog, nes pakeitem page.cs faila, kad galetume nullable reiskme ideti ( pridejom klaustuka pabaigoje)
//var page = new Page(1001, "slaptas turinys");
//dbContext.Pages.Add(page);
//dbContext.SaveChanges();


///////////////////////////////////////////////////////////////////////////////////
// Pasirenkam knyga, kurios pages norim padaryti console.WriteLine

//var harryPotterBook = dbContext.Books.Include(b=>b.Pages).FirstOrDefault(b => b.Name == "Harry Potter");
//Console.WriteLine($"Book Id: {harryPotterBook.Id}");
//Console.WriteLine("Book pages");
//foreach (var page in harryPotterBook.Pages.OrderBy(p=>p.Number))
//{
//    Console.WriteLine($"Page number: {page.Number}, content: {page.Content}");

//}

///////////////////////////////////////////////////////////////////////////////////
// Gaunam puslapio content ir is kurios knygos yra puslapis // select page and join book

//var page = dbContext.Pages.Include(p => p.Book).FirstOrDefault(p=>p.Id == Guid.Parse("3DF6871F-1A4E-403D-936B-3A33A8098E43"));
//Console.WriteLine($"Page content: {page.Content}");
//Console.WriteLine($"Page is from book named: {page.Book.Name}");

///////////////////////////////////////////////////////////////////////////////////
//Istrinimas // delete book with all pages // istrina knyga, bet kadangi pages padaryti nullable, tai jie lieka, tiesiog bookId pasikeicia i null //

//var harryPotterBook = dbContext.Books.Include(b => b.Pages).FirstOrDefault(b => b.Name == "Harry Potter");
//dbContext.Books.Remove(harryPotterBook);
//dbContext.SaveChanges();


// trinam knyga su visais jos puslapiais, pries tai page nuimam klaustukus nuo guid ir t.t., kad nebutu nullable
// cia istrinam visus sukurtus puslapius ir harry potter knyga

var harryPotterBook = dbContext.Books.Include(b => b.Pages).FirstOrDefault(b => b.Name == "Harry Potter");
////// dbContext.Pages.RemoveRange(harryPotterBook.Pages); sita naudojam jeigu neleidzia trinti knygos, nes neleidzia nullable puslapiu padaryti, 
////// tai naudojant sita istrinam visus puslapius ir tik paskui knyga
dbContext.Books.Remove(harryPotterBook);
dbContext.SaveChanges();