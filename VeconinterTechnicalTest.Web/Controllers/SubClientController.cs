using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Application.Services.Interfaces;

namespace VeconinterTechnicalTest.Web.Controllers;

[Authorize]
public class SubClientController : Controller
{
    private readonly ISubClientService _subClientService;
    private readonly IClientService _clientService;

    public SubClientController(ISubClientService subClientService, IClientService clientService)
    {
        _subClientService = subClientService;
        _clientService = clientService;
    }

    // GET: SubClient/Create/5 (clientId)
    public async Task<IActionResult> Create(int clientId)
    {
        var client = await _clientService.GetClientByIdAsync(clientId);
        if (client == null)
            return NotFound();

        var subClient = new SubClientDto { ClientId = clientId };
        ViewBag.ClientName = client.Name;

        return View(subClient);
    }

    // POST: SubClient/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubClientDto subClient)
    {
        if (!ModelState.IsValid)
        {
            var client = await _clientService.GetClientByIdAsync(subClient.ClientId);
            ViewBag.ClientName = client?.Name;
            return View(subClient);
        }

        try
        {
            await _subClientService.CreateSubClientAsync(subClient);
            TempData["SuccessMessage"] = "SubCliente creado exitosamente";
            return RedirectToAction("Details", "Client", new { id = subClient.ClientId });
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            var client = await _clientService.GetClientByIdAsync(subClient.ClientId);
            ViewBag.ClientName = client?.Name;
            return View(subClient);
        }
    }

    // GET: SubClient/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var subClient = await _subClientService.GetSubClientByIdAsync(id);
        if (subClient == null)
            return NotFound();

        return View(subClient);
    }

    // POST: SubClient/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SubClientDto subClient)
    {
        if (id != subClient.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(subClient);

        try
        {
            await _subClientService.UpdateSubClientAsync(subClient);
            TempData["SuccessMessage"] = "SubCliente actualizado exitosamente";
            return RedirectToAction("Details", "Client", new { id = subClient.ClientId });
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(subClient);
        }
    }

    // POST: SubClient/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var subClient = await _subClientService.GetSubClientByIdAsync(id);
            var clientId = subClient?.ClientId ?? 0;

            await _subClientService.DeleteSubClientAsync(id);
            TempData["SuccessMessage"] = "SubCliente eliminado exitosamente";

            return RedirectToAction("Details", "Client", new { id = clientId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Error al eliminar el subcliente: " + ex.Message;
            return RedirectToAction("Index", "Client");
        }
    }
}