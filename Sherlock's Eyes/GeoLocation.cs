﻿using Newtonsoft.Json;

public class GeoData
{
    public string ipLocal { get; set; }
    public string ipRemote { get; set; }
    public string status { get; set; }
    public string country { get; set; }
    public string address { get; set; }
}

public class GeoLocation
{
    public string status { get; set; }
    public string country { get; set; }
    public string countryCode { get; set; }
    public string region { get; set; }
    public string regionName { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string timezone { get; set; }
    public string isp { get; set; }
    public string org { get; set; }
    public string @as { get; set; }
    public string query { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Bounds
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}

public class Components
{
    [JsonProperty("ISO_3166-1_alpha-2")]
    public string ISO31661Alpha2 { get; set; }

    [JsonProperty("ISO_3166-1_alpha-3")]
    public string ISO31661Alpha3 { get; set; }

    [JsonProperty("ISO_3166-2")]
    public List<string> ISO31662 { get; set; }
    public string _category { get; set; }
    public string _type { get; set; }
    public string city { get; set; }
    public string city_district { get; set; }
    public string continent { get; set; }
    public string country { get; set; }
    public string country_code { get; set; }
    public string county { get; set; }
    public string house_number { get; set; }
    public string office { get; set; }
    public string political_union { get; set; }
    public string postcode { get; set; }
    public string road { get; set; }
    public string state { get; set; }
    public string state_code { get; set; }
    public string suburb { get; set; }
}

public class Geometry
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class License
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Northeast
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Rate
{
    public int limit { get; set; }
    public int remaining { get; set; }
    public int reset { get; set; }
}

public class Result
{
    public Bounds bounds { get; set; }
    public Components components { get; set; }
    public int confidence { get; set; }
    public string formatted { get; set; }
    public Geometry geometry { get; set; }
}

public class GeoLocationDetails
{
    public string documentation { get; set; }
    public List<License> licenses { get; set; }
    public Rate rate { get; set; }
    public List<Result> results { get; set; }
    public Status status { get; set; }
    public StayInformed stay_informed { get; set; }
    public string thanks { get; set; }
    public Timestamp timestamp { get; set; }
    public int total_results { get; set; }
}

public class Southwest
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Status
{
    public int code { get; set; }
    public string message { get; set; }
}

public class StayInformed
{
    public string blog { get; set; }
    public string twitter { get; set; }
}

public class Timestamp
{
    public string created_http { get; set; }
    public int created_unix { get; set; }
}



