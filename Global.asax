protected void Application_BeginRequest(){
    HttpContext.Current.Response.AddHeader("Access-Control-Allow=Origin","*");
}