##################################################################################
"SEO.Statistics" Solution has 2 projects:
1) SEO.Statistics.WebUI - .Net Core 5.0 Web MVC FrontEnd
2) SEO.Statistics.Service - .Net Core 5.0 Service Layer Class Library

Key points:
1.	When the MVC Project is run, the screen will show a textbox for entering Search keyword and a dropdown for selecting search engine. 
2.	Depending on Search Engine selection, using DI, proper Service Implementation is selected which calls proper search engine.
3.	Google and Bing Search Engine services have their own implementation to get search results. For demonstration purpose, 2 Mock JSON files are used with search results which contains some results with the link "sympli.com.au". These static files are placed in wwwroot folder "mock_data". 
4.	Server Side InMemory Caching is used in MVC Controller with 1 hour expiry for performance improvements.
5.	A ViewModelService is used which has the common code logic for doing further handling of returned data from search engines.


###################################################################################
