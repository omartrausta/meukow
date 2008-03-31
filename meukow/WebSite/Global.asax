<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        try
		{
			// Fetch last error.
			Exception lastError = Server.GetLastError( );
			Exception ex = lastError.GetBaseException( );

			/*
			// If we want to being notfied on errors,
			// this is one of the solutions.
			try
			{	
				MailMessage message = new MailMessage( );
				message.From = "hopur@ru.is";
				message.To = "hopur@ru.is";
				message.Subject = "[WebError]";
				message.Body = BuildMessage( ex );
				message.BodyFormat = MailFormat.Text;
				message.Priority = MailPriority.Normal;
				SmtpMail.SmtpServer = "mail.ru.is";
				SmtpMail.Send( message );
			}
			catch
			{
				// Bad error...
				// ... if error it would be strange...
			}	
			*/

			// Send our error to our ErrorPage, thou not earlier
			// we have stored errior in session.
			Session["LastError"] = ex;
			Server.Transfer( "ErrorPage.aspx" );
		}
		catch
		{
			// This cannot not throw error or we could start 
			// infinity loop
		}
    }
    
    protected String BuildMessage(Exception ex)
    {
        StringBuilder bldr = new StringBuilder(256);

        DateTime date = DateTime.Now;
        String strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
        String strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        String strUrl = Request.Url.AbsoluteUri;

        bldr.Append("When:");
        bldr.Append(date);
        bldr.Append("\r\n\r\n");

        if (ex != null)
        {
            bldr.Append("Message:");
            bldr.Append(ex.Message);
            bldr.Append("\r\n");

            bldr.Append("Source:");
            bldr.Append(ex.Source);
            bldr.Append("\r\n");

            bldr.Append("Stack trace:");
            bldr.Append(ex.StackTrace);
            bldr.Append("\r\n");
        }

        bldr.Append("IP Address:");
        bldr.Append(strIPAddress);
        bldr.Append("\r\n");

        bldr.Append("User agent:");
        bldr.Append(strUserAgent);
        bldr.Append("\r\n");

        bldr.Append("Full URL:");
        bldr.Append(strUrl);
        bldr.Append("\r\n");


       return bldr.ToString();
    }
    
    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
