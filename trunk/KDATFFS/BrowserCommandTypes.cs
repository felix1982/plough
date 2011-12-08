using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{

    /// <summary>
    /// Browser Command Type Enum
    /// </summary>
   public enum BrowserCommandTypes
    {
       /// <summary>
       /// no define
       /// </summary>
       None=0,

       /// <summary>
       /// close browser
       /// </summary>
       Close=1,

       /// <summary>
       /// exec javascript
       /// </summary>
       ExecuteScript=2,

       /// <summary>
       /// screeshot 
       /// </summary>
       GetScreenshot=4,

       /// <summary>
       /// goto
       /// </summary>
       Goto=8,

       /// <summary>
       /// alert dialog dismiss
       /// </summary>
       SwitchToAlertDismiss =16,

       /// <summary>
       /// return web page source
       /// </summary>
       GetPageSource=32,


       /// <summary>
       /// return session
       /// </summary>
       SessionId=64,
       

       /// <summary>
       ///retrun web page title
       /// </summary>
       GetTitle=128,


       /// <summary>
       /// retrun web page url
       /// </summary>
       GetUrl=256,


       /// <summary>
       /// alert dialog accept
       /// </summary>
       SwitchToAlertAccept=512,


       /// <summary>
       /// wait for page load 
       /// </summary>
       WaitForPageLoad =1024,

       /// <summary>
       /// back
       /// </summary>
       Back= 1500,

       /// <summary>
       /// forward
       /// </summary>
       Forward =1600,

       /// <summary>
       /// refresh
       /// </summary>
       Refresh =1700,





    }
}
