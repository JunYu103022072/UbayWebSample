<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxAccountingNote.aspx.cs" Inherits="AccountingNote.AjaxAccountingNote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>使用 AJAX 更新 AccountingNote</title>
    <script src="Script/jQuery-min-3.6.0.js"></script>
    <script>
        $(function () {
            $("#btnSave").click(function () {
                var id = $("#hfdID").val();
                var actType = $("#ddlActType").val();
                var amount = $("#txtAmount").val();
                var caption = $("#txtCaption").val();
                var desc = $("#txtDesc").val();

                if (id) {
                    $.ajax({
                        url: "http://localhost:4842/Handlers/AccountingNoteHandler.ashx?ActionName=update",
                        type: "POST",
                        data: {
                            "ID": id,
                            "Caption": caption,
                            "Amount": amount,
                            "ActType": actType,
                            "Body": desc
                        },
                        success: function (result) {
                            alert("更新成功");
                        }
                    });
                }
                else {
                    $.ajax({
                        url: "http://localhost:4842/Handlers/AccountingNoteHandler.ashx?ActionName=create",
                        type: "POST",
                        data: {
                            "ActType": actType,
                            "Amount": amount,
                            "Caption": caption,
                            "Body": desc
                        },
                        success: function (result) {
                            alert("新增成功");
                        }
                    });
                }
            });

            /*$("#btnRead").click(function () {*/
            $(document).on("click", ".btnReadData", function () {
                var td = $(this).closest("td");
                var hf = td.find("input.hfdRowID");
                var rowID = hf.val();

                $.ajax({
                    url: "http://localhost:4842/Handlers/AccountingNoteHandler.ashx?ActionName=query",
                    type: "POST",
                    data: {
                        "ID": rowID,
                    },
                    success: function (result) {
                        $("#hfdID").val(result["ID"]);
                        $("#ddlActType").val(result["ActType"]);
                        $("#txtAmount").val(result["Amount"]);
                        $("#txtCaption").val(result["Caption"]);
                        $("#txtDesc").val(result["Body"]);

                        $("#divEditor").show(300);
                    }
                });
            });
            $("#divEditor").hide(300);

            $.ajax({
                url: "http://localhost:4842/Handlers/AccountingNoteHandler.ashx?ActionName=list",
                type: "GET",
                data: {},
                success: function (result) {
                    var table = '<table border="1">';
                    table += '<tr> <th>Caption</th> <th>Amount</th> <th>ActType</th> <th>CreateDate</th> <th>Act</th>';

                    for (var i = 0; i < result.length; i++) {
                        var obj = result[i];
                        var htmlText =
                            `<tr>
                                <td>${obj.Caption}</td>
                                <td>${obj.Amount}</td>
                                <td>${obj.ActType}</td>
                                <td>${obj.CreateDate}</td>
                                <td>
                                    <input type="hidden" class="hfdRowID" value="${obj.ID}" />
                                    <button type="button" class="btnReadData">
                                    <img src="image/search.png" width="20" />
                                    </button>
                                </td>
                            </tr>`;
                        table += htmlText;
                    }
                    table += "</table>";
                    $("#divAccList").append(table);
                }
            });
            $("#btnDelete").click(function () {
                var id = $("#hfdID").val();
                $.ajax({
                    url: "http://localhost:4842/Handlers/AccountingNoteHandler.ashx?ActionName=delete",
                    type: "POST",
                    data: {
                        "ID" : id
                    },
                    success: function (result) {
                        alert("刪除成功");
                        window.location.reload();
                    }
                });
            });
            $("#btnAdd").click(function () {
                $("#hfdID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtDesc").val('');
                $("#divEditor").show(300);
            });

            $("#btnCancle").click(function () {
                $("#hfdID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtDesc").val('');
                $("#divEditor").hide(300);
            });
            $("#divEditor").hide(300);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divEditor">
            <input type="hidden" id="hfdID" />
            <table>
                <tr>
                    <td>
                        <!--這裡放主要訊息-->
                        Type:  
                    <select id="ddlActType">
                        <option value="0">支出</option>
                        <option value="1">收入</option>
                    </select>

                        <br />
                        Amount :
                        <input type="number" id="txtAmount" /><br />
                        Caption :
                        <input id="txtCaption" /><br />
                        Desc :
                        <textarea id="txtDesc" rows="5" cols="60"></textarea><br />
                        <button type="button" id="btnSave">SAVE</button>
                        <button type="button" id="btnCancle">Cancle</button>
                        <button type="button" id="btnDelete">Delete</button>
                    </td>
                </tr>
            </table>
        </div>
        <button type="button" id="btnAdd">Add</button>
        <div id="divAccList"></div>
    </form>
</body>
</html>
