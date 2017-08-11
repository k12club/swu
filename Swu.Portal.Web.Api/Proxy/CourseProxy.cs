﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "numberOfRegistered")]
        public int NumberOfRegistered { get; set; }
        [JsonProperty(PropertyName = "numberOfComments")]
        public int NumberOfComments { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
    }
}
