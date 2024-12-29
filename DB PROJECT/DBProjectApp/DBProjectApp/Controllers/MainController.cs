using DBProjectApp.Data;
using DBProjectApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBProjectApp.Controllers
{

    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly AppDbContext db;
        public MainController(AppDbContext _db)
        {
            db = _db;
        }

        //--------Select--------

        //Giriş yap
        public class LoginDTO { public string? email { get; set; } }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            return Ok(db.Customers.FromSql($"Login {loginDTO.email}").ToList().FirstOrDefault());
        }

        //Kategorileri getir
        [HttpPost]
        [Route("get-categories")]
        public IActionResult GetCategories()
        {
            return Ok(db.Categories.FromSql($"GetCategories").ToList());
        }

        //Ürün ara (boş ise tamamı)
        public class FindProductsDTO { public string? searchValue { get; set; } }
        [HttpPost]
        [Route("find-products")]
        public IActionResult FindProducts(FindProductsDTO findProductsDTO)
        {
            return Ok(db.Products.FromSql($"FindProducts {findProductsDTO.searchValue}").ToList());
        }

        //En çok satan 10 ürünü getir
        [HttpPost]
        [Route("get-best-selling-products")]
        public IActionResult GetBestSellingProducts()
        {
            return Ok(db.Products.FromSql($"GetBestSellingProducts").ToList());
        }

        //En çok satan 10 ürünü getir (FromView)
        [HttpPost]
        [Route("get-best-selling-products-from-view")]
        public IActionResult GetBestSellingProductsFromView()
        {
            return Ok(db.Products.FromSql($"GetBestSellingProductsFromView").ToList());
        }

        //En çok harcama yapan 10 müşteriyi getir
        [HttpPost]
        [Route("get-most-spending-customers")]
        public IActionResult GetMostSpendingCustomers()
        {
            return Ok(db.Customers.FromSql($"GetMostSpendingCustomers").ToList());
        }

        //En çok harcama yapan 10 müşteriyi getir (FromView)
        [HttpPost]
        [Route("get-most-spending-customers-from-view")]
        public IActionResult GetMostSpendingCustomersFromView()
        {
            return Ok(db.Customers.FromSql($"GetMostSpendingCustomersFromView").ToList());
        }

        //Müşterinin ödemesi yapılmamış siparişini (sepetini) getir
        public class GetCheckoutOrderByCustomerIdDTO { public int? customerId { get; set; } }
        [HttpPost]
        [Route("get-checkout-order-by-customer-id")]
        public IActionResult GetCheckoutOrderByCustomerId(GetCheckoutOrderByCustomerIdDTO getCheckoutOrderByCustomerIdDTO)
        {
            return Ok(db.Orders.FromSql($"GetCheckoutOrderByCustomerId {getCheckoutOrderByCustomerIdDTO.customerId}").ToList().FirstOrDefault());
        }

        //Müşterinin siparişlerini getir
        public class GetOrdersByCustomerIdDTO { public int? customerId { get; set; } }
        [HttpPost]
        [Route("get-orders-by-customer-id")]
        public IActionResult GetOrdersByCustomerId(GetOrdersByCustomerIdDTO getOrdersByCustomerIdDTO)
        {
            return Ok(db.Orders.FromSql($"GetOrdersByCustomerId {getOrdersByCustomerIdDTO.customerId}").ToList().FirstOrDefault());
        }

        //Sipariş detaylarını getir
        public class GetOrderDetailsByOrderIdDTO { public int? orderId { get; set; } }
        [HttpPost]
        [Route("get-order-details-by-order-id")]
        public IActionResult GetOrderDetailsByOrderId(GetOrderDetailsByOrderIdDTO getOrderDetailsByOrderIdDTO)
        {
            return Ok(db.OrderDetails.FromSql($"GetOrderDetailsByOrderId {getOrderDetailsByOrderIdDTO.orderId}").ToList());
        }



        //--------Create/Update/Delete--------

        //Müşteri ekle
        public class CreateCustomerDTO { public string? firstName { get; set; } public string? lastName { get; set; } public string? email { get; set; } }
        [HttpPost]
        [Route("create-customer")]
        public IActionResult CreateCustomer(CreateCustomerDTO createCustomerDTO)
        {
            db.Database.ExecuteSql($"CreateCustomer @FirstName={createCustomerDTO.firstName}, @LastName={createCustomerDTO.lastName}, @Email={createCustomerDTO.email}");
            return Ok();
        }

        //Müşteri bilgisi güncelle
        public class UpdateCustomerDTO { public int? customerId { get; set; } public string? firstName { get; set; } public string? lastName { get; set; } public string? email { get; set; } }
        [HttpPost]
        [Route("update-customer")]
        public IActionResult UpdateCustomer(UpdateCustomerDTO updateCustomerDTO)
        {
            db.Database.ExecuteSql($"UpdateCustomer @CustomerId={updateCustomerDTO.customerId}, @FirstName={updateCustomerDTO.firstName}, @LastName={updateCustomerDTO.lastName}, @Email={updateCustomerDTO.email}");
            return Ok();
        }

        //Müşteri sil
        public class DeleteCustomerDTO { public int? customerId { get; set; } }
        [HttpPost]
        [Route("delete-customer")]
        public IActionResult DeleteCustomer(DeleteCustomerDTO deleteCustomerDTO)
        {
            db.Database.ExecuteSql($"DeleteCustomer @CustomerId={deleteCustomerDTO.customerId}");
            return Ok();
        }

        //Ürünü sepete ekle
        public class AddToCheckoutDTO { public int? customerId { get; set; } public int? productId { get; set; } public int? quantity { get; set; } }
        [HttpPost]
        [Route("add-to-checkout")]
        public IActionResult AddToCheckout(AddToCheckoutDTO addToCheckoutDTO)
        {
            db.Database.ExecuteSql($"AddToCheckout @CustomerId={addToCheckoutDTO.customerId}, @ProductId={addToCheckoutDTO.productId}, @Quantity={addToCheckoutDTO.quantity}");
            return Ok();
        }

        //Ürünü sepetten çıkar
        public class RemoveFromCheckoutDTO { public int? orderDetailId { get; set; } }
        [HttpPost]
        [Route("remove-from-checkout")]
        public IActionResult RemoveFromCheckout(RemoveFromCheckoutDTO removeFromCheckoutDTO)
        {
            db.Database.ExecuteSql($"RemoveFromCheckout @OrderDetailId={removeFromCheckoutDTO.orderDetailId}");
            return Ok();
        }

        //Siparişi tamamla
        public class CheckoutDTO { public int? orderId { get; set; } }
        [HttpPost]
        [Route("checkout")]
        public IActionResult Checkout(CheckoutDTO checkoutDTO)
        {
            db.Database.ExecuteSql($"Checkout @OrderId={checkoutDTO.orderId}");
            return Ok();
        }
    }
}

