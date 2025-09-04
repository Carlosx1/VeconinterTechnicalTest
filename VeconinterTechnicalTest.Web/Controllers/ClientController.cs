using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Application.Services.Interfaces;

namespace VeconinterTechnicalTest.Web.Controllers;

[Authorize]
public class ClientController : Controller
{
    private readonly IClientService _clientService;
    private readonly ISubClientService _subClientService;

    public ClientController(IClientService clientService, ISubClientService subClientService)
    {
        _clientService = clientService;
        _subClientService = subClientService;
    }

    // GET: Client
    public async Task<IActionResult> Index()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return View(clients);
    }

    // GET: Client/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        if (client == null)
            return NotFound();

        var subClients = await _subClientService.GetSubClientsByClientIdAsync(id)  ?? new List<SubClientDto>();
        ViewBag.SubClients = subClients;

        return View(client);
    }

    // GET: Client/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Client/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClientDto client)
    {
        if (!ModelState.IsValid)
            return View(client);

        try
        {
            await _clientService.CreateClientAsync(client);
            TempData["SuccessMessage"] = "Cliente creado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(client);
        }
    }

    // GET: Client/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        if (client == null)
            return NotFound();

        return View(client);
    }

    // POST: Client/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ClientDto client)
    {
        if (id != client.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(client);

        try
        {
            await _clientService.UpdateClientAsync(client);
            TempData["SuccessMessage"] = "Cliente actualizado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(client);
        }
    }

    // GET: Client/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        if (client == null)
            return NotFound();

        return View(client);
    }

    // POST: Client/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _clientService.DeleteClientAsync(id);
            TempData["SuccessMessage"] = "Cliente eliminado exitosamente";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Error al eliminar el cliente: " + ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}