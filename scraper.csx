using System;
using System.Net;
using System.ComponentModel;

Console.WriteLine("Please enter 3 website names");
var count=0;
var webSiteUrls= new List<string>();
while(count<3){
    Console.WriteLine($"Enter website number {count+1}");
    var webSiteUrl=Console.ReadLine();
    webSiteUrls.Add(webSiteUrl);
    count++;
}

Console.WriteLine(webSiteUrls.Count);

//scrape the sites

    foreach(var site in webSiteUrls)
    {
        WebClient client= new WebClient();
        var siteNameContents= site.Split('.');
        var siteName= siteNameContents[1];
        var fileName=$"{siteName}.html";
        var pathName=$"C:\\Dev\\idIq\\{fileName}";
        if(client.IsBusy){
            Console.WriteLine("Downloading the page");
        }
        Console.WriteLine(site);
       
        client.DownloadFile(new System.Uri(site), @pathName);
       
    }


Console.WriteLine("That's ALl Folks");


