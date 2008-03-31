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
			// S�kjum hva�a villa kom s��ast upp:
			Exception lastError = Server.GetLastError( );
			Exception ex = lastError.GetBaseException( );

			/*
			// Ef vi� viljum f� a� vita um villur sem g�tu komi� upp
			// �� er �etta ein lei�:
			try
			{	
				MailMessage message = new MailMessage( );
				message.From = "someone@ru.is";
				message.To = "s�semskrifa�iforriti�@ru.is";
				message.Subject = "[WebError]";
				message.Body = BuildMessage( ex );
				message.BodyFormat = MailFormat.Text;
				message.Priority = MailPriority.Normal;
				SmtpMail.SmtpServer = "mail.ru.is";
				SmtpMail.Send( message );
			}
			catch
			{
				// Viljum ekki a� villum s� kasta� h��an...
				// ... ef �etta klikkar �� bara t�ff...
			}	
			*/

			// Sendum vinnsluna yfir � villus��una okkar, en �� ekki fyrr
			// en vi� erum b�in a� geyma � Session hva�a villa kom upp.
			Session["LastError"] = ex;
			Server.Transfer( "ErrorPage.aspx" );
		}
		catch
		{
			// �etta fall m� engum villum kasta, �v� annars
			// yr�i kalla� aftur � �a�, hugsanlega me� jafn
			// katastr�f�skum aflei�ingum, og �a� g�ti enda� �
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
