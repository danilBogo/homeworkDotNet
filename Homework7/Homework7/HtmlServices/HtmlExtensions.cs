using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework7.HtmlServices
{
    public static class HtmlExtensions
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            var model = helper.ViewData.ModelMetadata.ModelType;
            var fieldsHtml = model.GetProperties().Select(p => p.ConvertFieldToHtml(helper.ViewData.Model));
            IHtmlContentBuilder result = new HtmlContentBuilder();
            return fieldsHtml.Aggregate(result, (current, content) => current.AppendHtml(content));
        }

        private static IHtmlContent ConvertFieldToHtml(this PropertyInfo propertyInfo, object model)
        {
            var currentDiv = new TagBuilder("div") {Attributes = {{"class", "row mb-4"}}};
            currentDiv.InnerHtml.AppendHtml(CreateTitleLabel(propertyInfo));
            currentDiv.InnerHtml.AppendHtml(CreateInputElement(propertyInfo, model));
            currentDiv.InnerHtml.AppendHtml(Validation.Validate(propertyInfo, model));
            return currentDiv;
        }

        private static IHtmlContent CreateTitleLabel(PropertyInfo propertyInfo)
        {
            var label = new TagBuilder("label")
            {
                Attributes =
                {
                    {"class", "col-lg-1 col-sm-2 col-form-label"},
                    {"for", propertyInfo.Name}
                }
            };
            label.InnerHtml.AppendHtmlLine(GetName(propertyInfo));
            return label;
        }
        
        private static string GetName(MemberInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<DisplayAttribute>()?.Name ??
                   string.Join(" ", GetSplittedByCamelCaseName(propertyInfo.Name));
        }

        private static string GetSplittedByCamelCaseName(string name)
        {
            return System.Text.RegularExpressions.Regex
                .Replace(name, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }

        private static IHtmlContent CreateInputElement(PropertyInfo propertyInfo, object model)
        {
            var div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(propertyInfo.PropertyType.IsEnum
                ? CreateDropDownList(propertyInfo, model)
                : CreateInputField(propertyInfo, model));
            return div;
        }

        private static IHtmlContent CreateDropDownList(PropertyInfo propertyInfo, object model)
        {
            var select = new TagBuilder("select") {Attributes = {{"name", propertyInfo.Name}}};
            var modelValue = model != null ? propertyInfo.GetValue(model) : 0;
            var memberInfo = propertyInfo.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var memInfo in memberInfo)
            {
                var option = CreateVariation(memInfo, modelValue);
                select.InnerHtml.AppendHtml(option);
            }
            return select;
        }

        private static IHtmlContent CreateVariation(FieldInfo memInfo, object modelValue)
        {
            var enumType = memInfo.DeclaringType;
            var option = new TagBuilder("option") {Attributes = {{"value", memInfo.Name}}};
            if (memInfo.GetValue(enumType)?.Equals(modelValue) ?? false)
                option.MergeAttribute("selected", "true");
            option.InnerHtml.AppendHtmlLine(GetName(memInfo));
            return option;
        }

        private static IHtmlContent CreateInputField(PropertyInfo propertyInfo, object model)
        {
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "form-control"},
                    {"id", propertyInfo.Name},
                    {"name", propertyInfo.Name},
                    {"type", propertyInfo.PropertyType.IsIntegerType() ? "number" : "text"},
                    {"value", model != null ? propertyInfo.GetValue(model)?.ToString() ?? "" : ""}
                }
            };
            return input;
        }
    }
}