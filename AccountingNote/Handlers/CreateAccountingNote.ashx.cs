//using AccountingNote.DBsourse;
//using AccountingNote.ORM.DBModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace AccountingNote.Handlers
//{
//    /// <summary>
//    /// CreateAccountingNote 的摘要描述
//    /// </summary>
//    public class CreateAccountingNote : IHttpHandler
//    {

//        public void ProcessRequest(HttpContext context)
//        {
//            if(context.Request.HttpMethod != "POST")
//            {
//                this.ProcessError(context, "POST only");
//                return;
//            }
//            string caption = context.Request.Form["Caption"];
//            string amountText = context.Request.Form["Amount"];
//            string actTypeText = context.Request.Form["ActType"];
//            string body = context.Request.Form["Body"];
//            // id of admin
//            string id = "D071F78E-7086-4029-91DD-3D3939E844A1";
//            //必須檢查
//            if (string.IsNullOrWhiteSpace(caption) || string.IsNullOrWhiteSpace(amountText) || string.IsNullOrWhiteSpace(actTypeText))
//            {
//                this.ProcessError(context, "caption, amount, actType is required.");
//                return;
//            }
//            //轉型
//            int tempAmount, tempActType;
//            if(!int.TryParse(amountText,out tempAmount) || !int.TryParse(actTypeText, out tempActType))
//            {
//                this.ProcessError(context, "amount, actType should be a integer.");
//                return;
//            }
           
//            //建立流水帳
//            //AccountingManager.CreateAccounting(accounting);
//            AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);
//            context.Response.ContentType = "text/plain";
//            context.Response.Write("OK");
//        }
//        private void ProcessError(HttpContext context,string msg)
//        {
//            context.Response.StatusCode = 400;
//            context.Response.ContentType = "text/plain";
//            context.Response.Write(msg);
//            context.Response.End();
//        }
//        public bool IsReusable
//        {
//            get
//            {
//                return false;
//            }
//        }
//    }
//}