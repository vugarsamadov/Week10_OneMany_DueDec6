using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using PustokProject.CoreModels;
using PustokProject.Persistance;
using PustokProject.ViewModels.Author;

namespace PustokProject.Areas.Admin.Controllers;

[Area("Admin")]
public class BookAuthorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookAuthorsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var authors = await _context.Authors
            .ToListAsync();
        
        if (authors == null) return BadRequest();
        
        var model = new VM_BookAuthors();
        model.Authors = authors;
        
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAuthor(int id,VM_BookAuthors model)
    {
        await _context.Authors.AddAsync(new Author(){Name = model.Name,Surname = model.Surname});
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { id = id});
    }
    
        // public async Task<IActionResult> AddAuthor(int id,int authorId)
        // {
        //     var book = await _context.Books.Include(b => b.BookAuthors).FirstOrDefaultAsync(b => b.Id == id);
        //     if (book == null) return BadRequest();
        //     book.BookAuthors.Add(new BookAuthor(){Id = id});
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index), new { id = id});
        // }
    public async Task<IActionResult> DeleteAuthor(int id,int authorId)
    {
        var author = await _context.BookAuthors
            .FirstOrDefaultAsync(a=>a.Id == authorId);
        if (author != null) author.Delete();
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { id = id});
        }
    
    public async Task<IActionResult> RevokeDeleteAuthor(int id,int authorId)
            {
                var author = await _context.BookAuthors
                    .FirstOrDefaultAsync(a=>a.Id == authorId);
                if (author != null) author.RevokeDelete();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id});
            }
}