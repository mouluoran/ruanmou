﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace web.Ajax
{
    /// <summary>
    /// AjaxUpImage 的摘要说明
    /// </summary>
    public class AjaxUpImage : IHttpHandler
    {
        string json = "";
        HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8"); //必须加上，否则会产生乱码
            //接收浏览器 get/post 过来的参数cmd
            string cmd = context.Request["cmd"].ToString();

            switch (cmd)
            {
                case "uploadImage":
                    json = UploadImage();
                    break;
            }
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private string UploadImage()
        {
            HttpPostedFile file = context.Request.Files[0];//获取到从客户端传来的内容
            if (file.ContentType.Contains("image"))//判断传过来的内容是图片
            {
                string extension = Path.GetExtension(file.FileName).ToLower();//获取到上传文件的后缀名

                if (file.ContentLength > 1024 * 1024 * 5)
                {
                    json = "图片大小不能大于5兆";
                    return json;
                }
                if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                {
                    string fielname = Guid.NewGuid().ToString();//获取到全球唯一的文件名
                    string fielPath = context.Server.MapPath("/upfile/AskPic/" + fielname);
                    string fileStr = fielPath + extension;
                    file.SaveAs(fileStr);//上传文件
                    string callstr = "/upfile/AskPic/" + fielname + extension;
                    String callback = context.Request.QueryString["CKEditorFuncNum"];
                    json = "<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + callback + ",'" + callstr + "')</script>";
                }
                else
                {
                    json = "只能上传jpg,png,gif格式的图片";
                    return json;
                }
            }
            else
            {
                json = "上传的不是图片";
            }
            return json;

        }
    }
}