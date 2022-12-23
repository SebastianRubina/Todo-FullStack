using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.JsonPatch;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
    private readonly TodoContext _todoContext;
    public TodoItemController(TodoContext todoContext)
    {
        this._todoContext = todoContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _todoContext.TodoItem.ToListAsync();

        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] TodoItem todoItem)
    {
        todoItem.Id = Guid.NewGuid();

        await _todoContext.TodoItem.AddAsync(todoItem);
        await _todoContext.SaveChangesAsync();

        return Ok(todoItem);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateItem(Guid id)
    {
        var item = _todoContext.TodoItem.FirstOrDefault(item => item.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        item.Completed = !item.Completed;
        await _todoContext.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var item = _todoContext.TodoItem.FirstOrDefault(item => item.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        _todoContext.TodoItem.Remove(item);
        await _todoContext.SaveChangesAsync();
        return NoContent();
    }
}