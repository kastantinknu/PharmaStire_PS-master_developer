using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaStire_PS.Models.ViewModels;
using PharmaStire_PS.Models;
//using Wangkanai.Detection;

namespace PharmaStire_PS.Controllers
{
    public class ProductController : Controller
    {
       // private readonly IDetection _detection;


        //public IActionResult Index()
        //{
        //    return View(_detection);
        //}


        private IProductRepository repository;
        //количество продуктов на странице, IDetection detectionService
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {

            //_detection = detectionService;
            repository = repo;
        }

        //отображение всего списка на одной странице
        //public ViewResult List() => View(repositoty.Products);

        //разбиение на страници
        //public ViewResult List(int productPage = 1)
        //    => View(repositoty.Products
        //    .OrderBy(p => p.ProductID)
        //    .Skip((productPage -1)*PageSize)
        //    .Take(PageSize));


        //разбиение на страници снабжение представления сведениями  о товарах
        //отображаемых на страницах и информацией о разбиении на страницы
        //это обеспечивает передачу представлению  объекта ProductsListViewModel как даные модели.




        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                //Products = repositoty.Products
                //    .OrderBy(p => p.ProductID)
                //    .Skip((productPage - 1) * PageSize)
                //    .Take(PageSize),

                //Добавление поддержки категорий  к методу действия List()
                //В метод действия List () внесены три изменения. Первое-добавлен
                //новый параметр по  имени category. Он  применяется вторым изменением,
                //которое связано с расширением запроса LINQ. Если  значение category неравно
                //null, тогда выбираются только объекты Product с соответствующим значением
                //в свойстве Category. Последнее, третье, изменение касается установки значения
                //свойства CurrentCategory, которое было добавлено в класс ProductsListViewModel.
                //Однако в результате таких изменений значение Paginginfo. Totalitems вычисляется
                //некорректно, потому что оно не принимает во внимание фильтр по категории.
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    //TotalItems = repositoty.Products.Count()

                    //корректировка счетчика страниц
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e =>
                        e.Category == category).Count()
                },
                CurrentCategory = category
            });
        //public ViewResult List(int productPage = 1)
        //    => View(
        //    //{new ProductsListViewModelProducts =
        //         repository.Products
        //            .OrderBy(p => p.ProductID)
        //            .Skip((productPage - 1) * PageSize)
        //            .Take(PageSize));

        //Добавление поддержки категорий  к методу действия List()
        //В метод действия List () внесены три изменения. Первое-добавлен
        //новый параметр по  имени category. Он  применяется вторым изменением,
        //которое связано с расширением запроса LINQ. Если  значение category неравно
        //null, тогда выбираются только объекты Product с соответствующим значением
        //в свойстве Category. Последнее, третье, изменение касается установки значения
        //свойства CurrentCategory, которое было добавлено в класс ProductsListViewModel.
        //Однако в результате таких изменений значение Paginginfo. Totalitems вычисляется
        //некорректно, потому что оно не принимает во внимание фильтр по категории.
        //Products = repositoty.Products
        //    .Where(p => category == null || p.Category == category)
        //    .OrderBy(p => p.ProductID)
        //    .Skip((productPage - 1) * PageSize)
        //    .Take(PageSize),
        //PagingInfo = new PagingInfo
        //{
        //    CurrentPage = productPage,
        //    ItemsPerPage = PageSize,
        //    //TotalItems = repositoty.Products.Count()

        //    //корректировка счетчика страниц
        //    TotalItems = category == null ? repositoty.Products.Count() : repositoty.Products.Where(e =>
        //        e.Category == category).Count()
        //},
        //CurrentCategory = category
        //});




    }
}
