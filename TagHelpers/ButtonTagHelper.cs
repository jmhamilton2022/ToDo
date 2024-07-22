using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ToDoList.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "is-submit")]
    public class ButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("type", "submit");
        }
    }
}
