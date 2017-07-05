using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString PartialFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string partialViewName, bool prefix = true)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            object model = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            ViewDataDictionary viewData = new ViewDataDictionary(htmlHelper.ViewData);
            if (prefix)
            {
                viewData.TemplateInfo = new TemplateInfo()
                {
                    HtmlFieldPrefix = name,
                };
            };

            return htmlHelper.Partial(partialViewName, model, viewData);
        }
    }
}
