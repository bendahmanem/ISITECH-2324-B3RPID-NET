using System;
using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 


// this designe la classe dans laquelle on se trouve


// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{

    // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
    // ActionResult designe le type de retour de la méthode de controller d'api
    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {

        var books = new List<Book>
        {
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }

    [HttpPost]
    public IActionResult CreateBook(Book book)
    {

        Console.WriteLine(book.Title);

        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }
}