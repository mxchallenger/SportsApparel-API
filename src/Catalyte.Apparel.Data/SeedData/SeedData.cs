using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();
            var shippingRateList = new ShippingRates();


            modelBuilder.Entity<Product>().HasData(productFactory.GenerateRandomProducts(1000));

            var lineItem = new LineItem()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 1,
                Quantity = 1,
                PurchaseId = 1
            };

            modelBuilder.Entity<LineItem>().HasData(lineItem);

            var purchase = new Purchase()
            {
                Id = 1,
                BillingCity = "Atlanta",
                BillingEmail = "customer@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "123",
                OrderDate = new DateTime(2021, 5, 4)
            };

            modelBuilder.Entity<Purchase>().HasData(purchase);

            var promoCode = new PromoCode()
            {
                Id = 1,
                Title = "CODE00",
                Type = "flat or %",
                Description = "Description of Promo",
                Rate = 8888,
            };


            //modelBuilder.Entity<PromoCode>().HasData(promoCode);
       
            var statesArray = new string []
            {
            "AL",
            "AK",
            "AS",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FM",
            "FL",
            "GA",
            "GU",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MH",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "MP",
            "OH",
            "OK",
            "OR",
            "PW",
            "PA",
            "PR",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VI",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY",
            };
            modelBuilder.Entity<ShippingRate>().HasData(shippingRateList.AssignRates(statesArray));

            var user = new User()
            {
                Id = 1,
                Email = "blamboy@catalyte.io",
                Role = "customer",
                FirstName = "Benjamin",
                LastName = "Lamboy",
                Street = "123 Main",
                City = "Denver",
                State = "Colorado",
                Zip = 12345
            };

            modelBuilder.Entity<User>().HasData(user);

        }
    }
}
