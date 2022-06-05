using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebShopHardware.Helpers
{
    /// <summary>
    /// Класс-расширение для существующего
    /// HtmlHelper
    /// </summary>
    public static class Paginator
    {
        public static MvcHtmlString PagesLinks(this HtmlHelper html, int count)
        {
            var sb = new StringBuilder();
            // создаём html-строку со ссылками
            // на страницы
            // <a href="/Page1"> 1 </a>
            // <a href="/Page2"> 2 </a>
            for (int i = 1; i <= count; i++)
            {
                // создаём Тэг
                var tag = new TagBuilder("a"); // <a> </a>
                // вставляем атрибут href
                tag.MergeAttribute("href","/Page"+i);
                // вставляем текст в тэг
                tag.InnerHtml = i.ToString();
                // добавляем все тэги в строку
                sb.Append(tag.ToString());
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString PagesLinksBootstrap(this HtmlHelper html, int active, int count)
        {
            var sb = new StringBuilder();
            // создаём html-строку со ссылками
            // на страницы
            // <a href="/Page1"> 1 </a>
            // <a href="/Page2"> 2 </a>
            for (int i = 1; i <= count; i++)
            {
                // создаём Тэг
                var tagA = new TagBuilder("a"); // <a> </a>
                // вставляем атрибут href
                tagA.MergeAttribute("href", "/Page" + i);
                // вставляем текст в тэг
                tagA.InnerHtml = i.ToString();

                // обернём ссылки в элементы списка
                var tagLi = new TagBuilder("li"); // <li> </li>
                tagLi.InnerHtml = tagA.ToString();
                // добавляем все тэги в строку
                if (i == active)
                {
                    tagLi.AddCssClass("active");
                }
                sb.Append(tagLi.ToString());
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}