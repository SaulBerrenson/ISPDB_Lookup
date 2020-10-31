## ISPDB_Lookup

### About
This is library for looking imap/pop3/smtp config from ISP DB by Mozilla (Thunderbird autoconfig)

### Features
- Lookup by domain (example: bk.ru or gmail.com and etc.);
- Download all configs from specified url ISP DB using dataflow with all cores of processor;

#### Using
	//Lookup config by domain
     LookupDomain lookup = new LookupDomain();
    	 var config_bk =await lookup.Find("bk.ru");	 
	 
	//Download all configs from ISP DB using dataflow (TPL - dataflow) at backend
		//Intialize downloader
            DownloaderISPDB downloader = new DownloaderISPDB();
            //Download all
            await downloader.DownloadDatabase();
            //Get configs
            var all_configs = downloader.GetDatabase();

