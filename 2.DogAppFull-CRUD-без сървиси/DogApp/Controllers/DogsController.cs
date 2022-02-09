using DogApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Models;
using DogApp.Domain;
using Microsoft.AspNetCore.Http;
using DogApp.Services;
using DogApp.Abstractions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IDogService _dogService;

        public DogsController(ApplicationDbContext context, IDogService dogService)
        {
            this.context = context;
            _dogService = dogService;
        }

        public IActionResult Create()
        {
             return this.View();
           
        }

        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _dogService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                    if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }

        public IActionResult Edit(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture=item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Edit(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(;
                    if (updated)
                {
                    return this.RedirectToAction("All");
                }
            }
            return View(bindingModel);
        }
        

        public IActionResult Delete(int? id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }

            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("All", "Dogs");
            }
            else
            {
                return View();  
            }
        }
            public IActionResult Success()
        {
            return this.View();

        }

        public IActionResult All(string searchStringBreed, string searchStringName)
        {
            { 

            List<DogAllViewModel> dogs = DogService.GetDogs(searchStringBreed, searchStringName)
                .Select(dogFromDb => new DogAllViewModel
                {
                    Id = dogFromDb.Id,
                    Name = dogFromDb.Name,
                    Age = dogFromDb.Age,
                    Breed = dogFromDb.Breed,
                    Picture = dogFromDb.Picture

                }).ToList();
            return this.View(dogs);
            }

            if (!String.IsNullOrEmpty(searchStringBreed)&& !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)&&d.Name.Contains(searchStringName)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Name.Contains(searchStringName)).ToList();
            }

            return this.View(dogs);

        }

        public IActionResult Details(int id)
        {
            Dog item = IDogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

