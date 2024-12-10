using E_Commerce.Dto.ProductImageDto;
using E_Commerce.Entities;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers;

public class ImageController : Controller
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(int id, IFormFile image)
    {
        if (image == null && image.Length< 0) return RedirectToAction("Details","Product", new {id = id});
        try
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(image.FileName).ToLower();

           
            // Save the image
            var filePath = Path.Combine("wwwroot/productimages", Path.GetFileName(image.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            var dto = new ProductImageDto()
            {
                ProductId = id,
                ImageUrl =  $"/productimages/{image.FileName}",
            };
            await _imageService.Create(dto);
            TempData["Success"] = "Product image added successfully.";

            return RedirectToAction("Details", "Product", new {id = id});
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
            return RedirectToAction("Details", "Product", new {id = id});
        }
    }
}