using AccountingNote.DBsourse;
using AccountingNote.Extensions;
using AccountingNote.Models;
using AccountingNote.ORM.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AccountingNote.Handlers
{
    /// <summary>
    /// AccountingNoteHandler 的摘要描述
    /// </summary>
    public class AccountingNoteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string actionName = context.Request.QueryString["ActionName"];

            if (string.IsNullOrEmpty(actionName))
            {
                this.ProcessError(context, "ActionName is required.");
            }
            if (actionName == "create")
            {
                // ID is admin
                string id = "D071F78E-7086-4029-91DD-3D3939E844A1";
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];


                if (string.IsNullOrWhiteSpace(caption) || string.IsNullOrWhiteSpace(amountText) || string.IsNullOrWhiteSpace(actTypeText))
                {
                    this.ProcessError(context, "caption, amount, actType is required.");
                    return;
                }
                //轉型
                int tempAmount, tempActType;
                if (!int.TryParse(amountText, out tempAmount) || !int.TryParse(actTypeText, out tempActType))
                {
                    this.ProcessError(context, "amount, actType should be a integer.");
                    return;
                }
                try
                {
                    Accounting accounting = new Accounting()
                    {
                        UserID = id.ToGuid(),
                        ActType = tempActType,
                        Amount = tempAmount,
                        Caption = caption,
                        Body = body
                    };
                    AccountingManager.CreateAccounting(accounting);
                    //AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("新增OK");
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error");
                }
            }
            else if (actionName == "update")
            {
                //string userID = "D071F78E-7086-4029-91DD-3D3939E844A1";
                string idText = context.Request.Form["ID"];
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];
                int amount = Convert.ToInt32(amountText);
                int actType = Convert.ToInt32(actTypeText);
                int id;
                try
                {
                    if (int.TryParse(idText, out id))
                    {
                        Accounting accounting = new Accounting()
                        {
                            ActType = actType,
                            Amount = amount,
                            Caption = caption,
                            Body = body
                        };
                        AccountingManager.UpdateAccounting(accounting);
                        //AccountingManager.UpdateAccounting(id, userID, caption, amount, actType, body);
                }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("更新OK");
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error Update");
                }
            }
            else if (actionName == "delete")
            {
                string idText = context.Request.Form["ID"];
                if (string.IsNullOrWhiteSpace(idText))
                    return;
                int id;
                try
                {
                    if (int.TryParse(idText, out id))
                    {
                        AccountingManager.DeleteAccounting_ORM(id);
                    }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("刪除OK");
                }
                catch
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error Delete");
                }
            }
            else if (actionName == "list")
            {
                Guid userGUID = new Guid("D071F78E-7086-4029-91DD-3D3939E844A1");

                List<Accounting> sourceList = AccountingManager.GetAccountingList(userGUID);
                List<AccountingNoteViewModel> list =
                sourceList.Select(obj => new AccountingNoteViewModel()
                {
                    ID = obj.ID,
                    Caption = obj.Caption,
                    Amount = obj.Amount,
                    ActType = (obj.ActType == 0) ? "支出" : "收入",
                    CreateDate = obj.CreateDate.ToString("yyyy-MM-dd")
                }).ToList();

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }
            else if (actionName == "query")
            {
                string idText = context.Request.Form["ID"];
                int id;
                int.TryParse(idText, out id);
                //string userID = "D071F78E-7086-4029-91DD-3D3939E844A1";
                Guid userGuid = new Guid("D071F78E-7086-4029-91DD-3D3939E844A1");

                var accounting = AccountingManager.GetAccounting(id, userGuid);

                if (accounting == null)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No data: " + idText);
                    context.Response.End();
                    return;
                }

                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = accounting.ID,
                    Caption = accounting.Caption.ToString(),
                    Body = accounting.Body,
                    Amount = accounting.Amount,
                    ActType = (accounting.ActType == 0) ? "支出" : "收入",
                    CreateDate = accounting.CreateDate.ToString("yyyy-MM-dd")
                };
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }
        }
        private void ProcessError(HttpContext context, string msg)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}