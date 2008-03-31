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
			// Sækjum hvaða villa kom síðast upp:
			Exception lastError = Server.GetLastError( );
			Exception ex = lastError.GetBaseException( );

			/*
			// Ef við viljum fá að vita um villur sem gætu komið upp
			// þá er þetta ein leið:
			try
			{	
				MailMessage message = new MailMessage( );
				message.From = "someone@ru.is";
				message.To = "sásemskrifaðiforritið@ru.is";
				message.Subject = "[WebError]";
				message.Body = BuildMessage( ex );
				message.BodyFormat = MailFormat.Text;
				message.Priority = MailPriority.Normal;
				SmtpMail.SmtpServer = "mail.ru.is";
				SmtpMail.Send( message );
			}
			catch
			{
				// Viljum ekki að villum sé kastað héðan...
				// ... ef þetta klikkar þá bara töff...
			}	
			*/

			// Sendum vinnsluna yfir á villusíðuna okkar, en þó ekki fyrr
			// en við erum búin að geyma í Session hvaða villa kom upp.
			Session["LastError"] = ex;
			Server.Transfer( "ErrorPage.aspx" );
		}
		catch
		{
			// Þetta fall má engum villum kasta, því annars
			// yrði kallað aftur í það, hugsanlega með jafn
			// katastrófískum afleiðingum, og það gæti endað í
			// endalausri lykkju!
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
