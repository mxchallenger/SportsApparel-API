﻿using System;
using System.Collections.Generic;
using System.Linq;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.SeedData
{
    public class ShippingRates
    {
        //public readonly string[] statesArray =
        //{
        //    "Alabama",
        //    "Alaska",
        //    "American Samoa",
        //    "Arizona",
        //    "Arkansas",
        //    "California",
        //    "Colorado",
        //    "Connecticut",
        //    "Delaware",
        //    "District of Columbia",
        //    "Federated States of Micronesia",
        //    "Florida",
        //    "Georgia",
        //    "Guam",
        //    "Hawaii",
        //    "Idaho",
        //    "Illinois",
        //    "Indiana",
        //    "Iowa",
        //    "Kansas",
        //    "Kentucky",
        //    "Louisiana",
        //    "Maine",
        //    "Marshall Island",
        //    "Maryland",
        //    "Massachusetts",
        //    "Michigan",
        //    "Minnesota",
        //    "Mississippi",
        //    "Missouri",
        //    "Montana",
        //    "Nebraska",
        //    "Nevada",
        //    "New Hampshire",
        //    "New Jersey",
        //    "New Mexico",
        //    "New York",
        //    "North Carolina",
        //    "North Dakota",
        //    "Northern Mariana Islands",
        //    "Ohio",
        //    "Oklahoma",
        //    "Oregon",
        //    "Palau",
        //    "Pennslyvania",
        //    "Puerto Rico",
        //    "Rhode Island",
        //    "South Carolina",
        //    "South Dakota",
        //    "Tennessee",
        //    "Texas",
        //    "Utah",
        //    "Vermont",
        //    "Virgin Island",
        //    "Virginia",
        //    "Washington",
        //    "West Virginia",
        //    "Wisconsin",
        //    "Wyoming",
        //};
       
        public List<ShippingRate> AssignRates(string[] statesArray)
        {
            var shippingRateList = new List<ShippingRate>();
           
            foreach (string state in statesArray)
            {
                var shippingRate = new ShippingRate();
                shippingRateList.Add(shippingRate);
                
                if (state == "Hawaii" || state == "Alaska")
                {
                    shippingRate.Rate = 10.00;
                    shippingRate.State = state;
                    var id = shippingRateList.IndexOf(shippingRate) + 1;
                    shippingRate.Id = id;
                }
                else
                {
                    shippingRate.Rate = 5.00;
                    shippingRate.State = state;
                    var id = shippingRateList.IndexOf(shippingRate) + 1;
                    shippingRate.Id = id;

                }
            }
            return shippingRateList;

        }
    }
}

