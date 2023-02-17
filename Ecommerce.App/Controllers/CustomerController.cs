using Ecommerce.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.App.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = (from tempcustomer in GetAllCustomers().ToList() //_context.CustomerTB
                                    select tempcustomer);
                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    //customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection); //OrderBy(sortColumn + " " + sortColumnDirection);
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name == searchValue);
                }

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        [NonAction]
        public IEnumerable<CustomerTB> GetAllCustomers()
        {
            return new List<CustomerTB>
            {
                new CustomerTB {
                    CustomerID = 1,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 1",
                    Phoneno = "8494506102"},
                 new CustomerTB {
                    CustomerID = 2,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 2",
                    Phoneno = "8494506103"},
                  new CustomerTB {
                    CustomerID = 3,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                    new CustomerTB {
                    CustomerID = 4,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                      new CustomerTB {
                    CustomerID = 5,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                        new CustomerTB {
                    CustomerID = 6,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                          new CustomerTB {
                    CustomerID = 7,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                            new CustomerTB {
                    CustomerID = 8,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                              new CustomerTB {
                    CustomerID = 9,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                                new CustomerTB {
                    CustomerID = 10,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                                 new CustomerTB {
                    CustomerID = 11,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"},
                                  new CustomerTB {
                    CustomerID = 12,
                    Address = "Calle 5A # 25",
                    City = "Santo Domingo",
                    Country = "Dominican Republic",
                    Name = "Nombre 3",
                    Phoneno = "8494506102"}
            };
        
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
