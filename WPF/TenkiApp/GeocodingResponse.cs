using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkiApp
{
    class GeocodingResponse {
        public GeocodingResult[] Results { get; set; }
    }

    class GeocodingResult {
        public Geometry Geometry { get; set; }
    }

    class Geometry {
        public Location Location { get; set; }
    }

    class Location {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
}
